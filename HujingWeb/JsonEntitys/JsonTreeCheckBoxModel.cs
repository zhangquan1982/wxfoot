using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HujingWeb
{
    [Serializable]
    public class JsonTreeCheckBoxModel
    {
        public string text { get; set; }

        public string id { get; set; }

        public string pid { get; set; }

        [DataMember(Name = "checked")]
        public bool @checked { get; set; }

        public int fnum { get; set; }
    }
}