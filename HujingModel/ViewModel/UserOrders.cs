using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel.ViewModel
{
    public class UserOrders
    {
        public string orderId { get; set; }

        public DateTime orderDate { get; set; }

        public string type { get; set; }

        public int count { get; set; }
    }
}
