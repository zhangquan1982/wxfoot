using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess.UserOrder
{
    public interface IRefundsApplyAccess : ILoad<RefundsApplyEntity, string>, ISave<bool, RefundsApplyEntity>, IUpdate<bool, RefundsApplyEntity>, ILoadAll<RefundsApplyEntity>, ICount
    {
    }
}
