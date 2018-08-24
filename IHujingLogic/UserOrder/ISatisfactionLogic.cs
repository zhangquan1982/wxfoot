using HujingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.UserOrder
{
    public interface ISatisfactionLogic
    {
        int Count(string condition);

        SatisfactionEntity Load(string code);

        IList<SatisfactionEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Save(SatisfactionEntity obj);

        bool Update(SatisfactionEntity obj);

        DataTable GetSatisfactGroupDate(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
