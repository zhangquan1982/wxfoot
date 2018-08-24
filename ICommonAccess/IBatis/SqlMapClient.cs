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
        /// 单例模式
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
        /// 得到参数化后的SQL
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
        /// 通用的以DataTable的方式得到Select的结果(xml文件中参数要使用$标记的占位参数)
        /// </summary>
        /// <param name="tag">语句ID</param>
        /// <param name="paramObject">语句所需要的参数</param>
        /// <returns>得到的DataTable</returns>
        public static DataTable QueryForDataTable(string tag, object paramObject)
        {
            return QueryForDataSet(tag, paramObject).Tables[0];
        }

        /// <summary>
        /// 用于分页控件使用
        /// </summary>
        /// <param name="tag">语句ID</param>
        /// <param name="paramObject">语句所需要的参数</param>
        /// <param name="PageSize">每页显示数目</param>
        /// <param name="curPage">当前页</param>
        /// <param name="recCount">记录总数</param>
        /// <returns>得到的DataTable</returns>
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
        /// 取回合适数量的数据
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

            // 读取数据。将DataReader中的数据读取到DataTable中

            object[] vald = new object[colCount];
            int iCount = 0; // 临时记录变量
            while (dataReader.Read())
            {
                // 当前记录在当前页记录范围内

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
                iCount++; // 临时记录变量递增
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