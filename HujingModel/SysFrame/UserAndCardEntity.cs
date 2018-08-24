using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel.SysFrame
{
    public class UserAndCardEntity
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string AgeName { get; set; }  // 年龄。

        public string SexName { get; set; }  // 性别。

        public string CardId { get; set; } 

        public decimal PreAmount { get; set; } //预交金

        public decimal FeeAmount { get; set; } //消费金额


    }
}
