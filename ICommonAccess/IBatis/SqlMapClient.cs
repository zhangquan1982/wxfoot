/*
 * Created by: Jerome Gagner
 * Created: Monday, January 08, 2007
 */

using System;
using System.Configuration;
using System.Xml;
using IBatisNet.Common;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Reflection;
using System.IO;
using IBatisNet.Common.Logging;
using System.Data;
using IBatisNet.DataMapper.Configuration.Statements;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;

namespace ICommonAccess
{
    public class SqlMapClient
    {
        private static readonly object syncObj = new object();
        private static readonly ILog log = LogManager.GetLogger(typeof(SqlMapClient));


        public static ISqlMapper mapper;

        /// <summary>
        /// ����ģʽ
        /// </summary>
        static SqlMapClient()
        {

            if (mapper == null)
            {
                lock (syncObj)
                {
                    if (mapper == null)
                    {
                        Assembly assembly = Assembly.Load("SqlMaps");
                        Stream stream = assembly.GetManifestResourceStream("SqlMaps.sqlmap.config");

                        DomSqlMapBuilder builder = new DomSqlMapBuilder();
                        mapper = builder.Configure(stream);
                    }
                }
            }
        }

        #region QueryForSql/QueryForDataTable

        /**/
        /// <summary>
        /// �õ����������SQL
        /// </summary>
        public static string QueryForSql(string tag, object paramObject)
        {
            IStatement statement = mapper.GetMappedStatement(tag).Statement;
            IMappedStatement mapStatement = mapper.GetMappedStatement(tag);
            ISqlMapSession session = new SqlMapSession(mapper);
            RequestScope request = statement.Sql.GetRequestScope(mapStatement, paramObject, session);
            return request.PreparedStatement.PreparedSql;
        }

        public static IDbCommand GetDbCommand(string tag, object paramObject)
        {
            IMappedStatement statement = mapper.GetMappedStatement(tag);
            if (!mapper.IsSessionStarted)
            {
                mapper.OpenConnection();
            }
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
            statement.PreparedCommand.Create(request, mapper.LocalSession, statement.Statement, paramObject);

            IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
            command.CommandText = request.IDbCommand.CommandText;
            foreach (IDataParameter pa in request.IDbCommand.Parameters)
            {
                IDbDataParameter para = mapper.LocalSession.CreateDataParameter();
                para.ParameterName = pa.ParameterName;
                para.Value = pa.Value;
                command.Parameters.Add(para);
            }
            return command;

        }

        public static DataSet QueryForDataSet(string tag, object paramObject)
        {
            DataSet ds = new DataSet();
            IDbCommand command = GetDbCommand(tag, paramObject);
            mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
            return ds;
        }


        /// <summary>
        /// ͨ�õ���DataTable�ķ�ʽ�õ�Select�Ľ��(xml�ļ��в���Ҫʹ��$��ǵ�ռλ����)
        /// </summary>
        /// <param name="tag">���ID</param>
        /// <param name="paramObject">�������Ҫ�Ĳ���</param>
        /// <returns>�õ���DataTable</returns>
        public static DataTable QueryForDataTable(string tag, object paramObject)
        {
            return QueryForDataSet(tag, paramObject).Tables[0];
        }

        /// <summary>
        /// ���ڷ�ҳ�ؼ�ʹ��
        /// </summary>
        /// <param name="tag">���ID</param>
        /// <param name="paramObject">�������Ҫ�Ĳ���</param>
        /// <param name="PageSize">ÿҳ��ʾ��Ŀ</param>
        /// <param name="curPage">��ǰҳ</param>
        /// <param name="recCount">��¼����</param>
        /// <returns>�õ���DataTable</returns>
        public static DataTable QueryForDataTable(string tag, object paramObject, int PageSize, int curPage, out int recCount)
        {
            IDataReader dr = null;
            bool isSessionLocal = false;
            string sql = QueryForSql(tag, paramObject);
            string strCount = "select count(*) " + sql.Substring(sql.ToLower().IndexOf("from"));

            IDalSession session = mapper.LocalSession;
            DataTable dt = new DataTable();
            if (session == null)
            {
                session = new SqlMapSession(mapper);
                session.OpenConnection();
                isSessionLocal = true;
            }
            try
            {
                IDbCommand cmdCount = GetDbCommand(tag, paramObject);
                cmdCount.Connection = session.Connection;
                cmdCount.CommandText = strCount;
                object count = cmdCount.ExecuteScalar();
                recCount = Convert.ToInt32(count);

                IDbCommand cmd = GetDbCommand(tag, paramObject);
                cmd.Connection = session.Connection;
                dr = cmd.ExecuteReader();

                dt = QueryForPaging(dr, PageSize, curPage);
            }
            finally
            {
                if (isSessionLocal)
                {
                    session.CloseConnection();
                }
            }
            return dt;
        }


        /// <summary>
        /// 
        /// ȡ�غ�������������
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="PageSize"></param>
        /// <param name="curPage"></param>
        /// <returns></returns>
        public static DataTable QueryForPaging(IDataReader dataReader, int PageSize, int curPage)
        {
            DataTable dt;
            dt = new DataTable();
            int colCount = dataReader.FieldCount;
            for (int i = 0; i < colCount; i++)
            {
                dt.Columns.Add(new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i)));
            }

            // ��ȡ���ݡ���DataReader�е����ݶ�ȡ��DataTable��

            object[] vald = new object[colCount];
            int iCount = 0; // ��ʱ��¼����
            while (dataReader.Read())
            {
                // ��ǰ��¼�ڵ�ǰҳ��¼��Χ��

                if (iCount >= PageSize * (curPage - 1) && iCount < PageSize * curPage)
                {
                    for (int i = 0; i < colCount; i++)
                        vald[i] = dataReader.GetValue(i);

                    dt.Rows.Add(vald);
                }
                else if (iCount > PageSize * curPage)
                {
                    break;
                }
                iCount++; // ��ʱ��¼��������
            }

            if (!dataReader.IsClosed)
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            return dt;
        }

        #endregion
    }


}