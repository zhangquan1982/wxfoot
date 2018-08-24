using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb.Common
{
    public class SaveResult
    {
        /// <summary>
        /// 状态码
        /// 100-成功
        /// 200-失败
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        public string msg { get; set; }
    }
}