using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel.ChargeManager
{
    public class InvoiceSelCondition
    {
        public string SerialNum { get; set; }
        public string PatiName { get; set; }
        public string UserId { get; set; }
        public DateTime? dateBegin { get; set; }
        public DateTime? dateEnd { get; set; }
    }
}
