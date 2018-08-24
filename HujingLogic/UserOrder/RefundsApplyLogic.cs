using HujingModel;
using IHujingAccess.UserOrder;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingLogic.UserOrder
{
    class RefundsApplyLogic : IRefundsApplyLogic
    {
        public IRefundsApplyAccess access { get; set; }
        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public RefundsApplyEntity Load(string code)
        {
            return access.Load(code);
        }

        public IList<RefundsApplyEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Save(RefundsApplyEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(RefundsApplyEntity obj)
        {
            return access.Update(obj);
        }
    }
}
