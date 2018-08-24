using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface IDictItem_CateLogic
    {
        int Count(string condition);

        DictItem_CateEntity Load(string code);

        bool Delete(string CateIds);

        IList<DictItem_CateEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Save(DictItem_CateEntity obj);

        bool Update(DictItem_CateEntity obj);

        string GetMaxCateId(string Condition);
    }
}
