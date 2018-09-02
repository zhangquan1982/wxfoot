using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.UserOrder
{
    public interface IRefundsApplyLogic
    {
        int Count(string condition);

        RefundsApplyEntity Load(string code);

        IList<RefundsApplyEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Save(RefundsApplyEntity obj);

        bool Update(RefundsApplyEntity obj);


        bool BackUserFee(string applyId, string backUserId);

    }
}
