using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface IDictCodeLogic
    {
        int Count(string condition);

        DictCodeEntity Load(DictCodeEntity dictEntity);

        bool Delete(DictCodeEntity entiy);

        bool Save(DictCodeEntity obj);

        bool Update(DictCodeEntity obj);

        IList<DictCodeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool InitOrgDictCode(string Condition);
    }
}
