using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb
{
    /// <summary>
    /// http请求返回信息
    /// </summary>
    public class QueryResult
    {
        /// <summary>
        /// 状态码
        /// 100-成功
        /// 200-没有数据
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        public object result_data { get; set; }
    }

    /// <summary>
    /// 列表
    /// </summary>
    public class QueryInfoList
    {
        /// <summary>
        /// 列表数据
        /// </summary>
        public object list_data
        {
            get;
            set;
        }
        /// <summary>
        /// 总行数
        /// </summary>
        public int list_count
        {
            get;
            set;
        }
    }
}