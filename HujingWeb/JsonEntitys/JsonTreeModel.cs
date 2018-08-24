using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb
{
    /// <summary>
    /// 实体树对象
    /// </summary>
    public class JsonTreeModel
    {
        public string name { get; set; }

        public string id { get; set; }

        public bool expanded { get; set; }

        public string pid { get; set; }

    }
}