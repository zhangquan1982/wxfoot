using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface IDictItemLogic
    {
        int Count(string condition);

        DictItemEntity Load(string code);

        bool Delete(string items);

        IList<DictItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Save(DictItemEntity obj);

        bool Update(DictItemEntity obj);

        string GetMaxCateId(string Condition);

        bool SaveList(IList<DictItemEntity> list);

        IList<DictItemEntity> LoadAllByPacktypeId(string PackTypeId);

        IList<DictItemEntity> LoadAllDictItemJoin(string Condition);

        IList<DictItemEntity> LoadAllByFloorId(string PackTypeId);
    }
}
