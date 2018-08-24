using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel
{
    public class PersonPayVoiceVM
    {
        public string SerialNum { get; set; }
        public string Status { get; set; }
        public string PatiName { get; set; }
        public string PayId { get; set; }
        public decimal PayAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string PayModeType { get; set; }
        public string CreateUser { get; set; }
        public string InvoiceId { get; set; }
    }
}
