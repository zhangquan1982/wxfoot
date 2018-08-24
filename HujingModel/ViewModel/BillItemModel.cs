using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel.ViewModel
{
     public  class BillItemModel
    {
        public DateTime date { get; set; }

        public decimal fee  { get; set; }

        public string remark { get; set; }

        public string time { get; set; }

        public int orderNumber { get; set; }
    }
}
