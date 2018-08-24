using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Web.Script.Serialization;
namespace HujingWeb
{
    public static class JsonHelper
    {
        /// <summary>
        /// 不分页形式返回json拼接  
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RtnJson(string code, string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"code\"");
            sb.Append(":");
            sb.Append(code);
            sb.Append(",");
            sb.Append("\"msg\"");
            sb.Append(":");
            sb.Append(string.IsNullOrEmpty(msg) ? "\"\"" : "\"" + msg + "\"");
            sb.Append("}");
            return sb.ToString();
            
        }
       
        /// <summary>
        /// 分页形式返回json拼接 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="total">总页数</param>
        /// <param name="current">当前第几页</param>
        /// <returns></returns>
        public static string RtnJson(string code, string msg, string data, int total, int current)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"code\"");
            sb.Append(":");
            sb.Append(code);
            sb.Append(",");
            sb.Append("\"msg\"");
            sb.Append(":");
            sb.Append(string.IsNullOrEmpty(msg) ? "\"\"" : "\"" + msg + "\"");
            sb.Append(",");
            sb.Append("\"data\"");
            sb.Append(":{");
            sb.Append(data.Substring(1, data.Length - 2) + ",");
          
            sb.Append("\"page\":{");
            sb.Append("\"total\":");
            sb.Append(total+",");
            sb.Append("\"current\":");
            sb.Append(current+",");
            sb.Append("\"data\":[");
            sb.Append(RtnPageCount(current, total));
            sb.Append("]}");

            sb.Append("}");

            sb.Append("}");
            return sb.ToString();
           
        }

        public static string RtnJsonNew( string data, int total)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"total\":");
            sb.Append(total + ",");
            sb.Append("\"data\"");
            sb.Append(data.Substring(1, data.Length - 2) + ",");
            sb.Append("}");
            return sb.ToString();

        }

        /// <summary>
        /// 根据当前页，页的总数来获取返回的页
        /// </summary>
        /// <param name="current"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        private static string RtnPageCount(int current, int total)
        {
            StringBuilder sb = new StringBuilder();
            int subtract = 0;

            if (total > 0)
            {
                if (total > 5)
                {
                    for (int i = 5; i < total; i += 5)
                    {
                        if (current <= i)
                        {
                            subtract = i - current;
                            for (int j = 0; j < subtract; j++)
                            {
                                sb.Append(current + j + ",");
                            }
                        }
                    }
                }
                else
                {
                    for (int k = 1; k <= total; k++)
                    {
                        sb.Append(k + ",");
                    }

                }
                return sb.ToString().Substring(0, sb.ToString().Length - 1);
            }
            else
            {
                return "";
            }
        }


        public static string RtnJsonCodeMsg(string code, string strMsg)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("code", code);
            dic.Add("msg", strMsg);
            dic.Add("data", "");
            return JsonConvert.SerializeObject(dic);
        }


        public static string DataTable2Json(DataTable dt,int totalCount)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.Append("\"total\":");
            jsonBuilder.Append(totalCount + ",");
            jsonBuilder.Append("\"data\":");
            jsonBuilder.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");
                        jsonBuilder.Append(dt.Rows[i][j].ToString().Trim());
                        jsonBuilder.Append("\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }


        public static string SerializeDataTable(DataTable dt)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)//每一行信息，新建一个Dictionary<string,object>,将该行的每列信息加入到字典
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                list.Add(result);
            }
            return serializer.Serialize(list);//调用Serializer方法 
        }

          /// <summary>
        /// Msdn
        /// </summary>
        /// <param name="jsonName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
    }
}
