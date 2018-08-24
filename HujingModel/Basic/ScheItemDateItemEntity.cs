using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel.Basic
{
    public class ScheItemDateItemEntity
    {
        public DateTime dateTime { get; set; }
        public string date { get; set; }

        public IList<FootType> foots { get; set; }
    }


    public class FootType
    {
        public string type { get; set; }

        public List<string> names { get; set; }
    }
}
