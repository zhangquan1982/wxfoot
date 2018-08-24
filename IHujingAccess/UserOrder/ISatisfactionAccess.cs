using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess.UserOrder
{
    public interface ISatisfactionAccess : ILoad<SatisfactionEntity, string>, ISave<bool, SatisfactionEntity>, IUpdate<bool, SatisfactionEntity>, ILoadAll<SatisfactionEntity>, ICount
    {

        DataTable GetSatisfactGroupDate(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
