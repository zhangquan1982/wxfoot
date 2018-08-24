using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HujingModel
{
    public class SysGroupVM
    {
        public string id { get; set; }

        public string pid { get; set; }

        public string text { get; set; }

        public string iconCls { get; set; }

        public string url { get; set; }

        public string HisType { get; set; }

        public string iconPosition { get; set; }

        public IList<SysGroupEntity> subList;

    }
}
