using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel
{
    public class PatiIn_Settle_InVoiceEntity
    {
        public string InvoiceId { get; set; }

        public string SettleId { get; set; }
        public string InvType { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string CancUser { get; set; }
        public DateTime? CancDate { get; set; }
        public string CancReason { get; set; }
        public string PayId { get; set; }
        public DateTime? FootDate { get; set; }
        public string FootId { get; set; }
        public string OrgId { get; set; }
    }
}
