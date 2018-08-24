using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel.ViewModel
{
    public class UserOrderDetail
    {
        public string orderId { get; set; }

        public DateTime orderDate { get; set; }

        public string userId { get; set; }

        public string userName { get; set; }

        public string type { get; set; }

        public int Quantity { get; set; }
    }
}
