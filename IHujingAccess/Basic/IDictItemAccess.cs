using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public interface IDictItemAccess : ICount, ILoad<DictItemEntity, string>, IDelete<bool, string>, ISave<bool, DictItemEntity>, IUpdate<bool, DictItemEntity>, ILoadAll<DictItemEntity>
    {
        bool SaveList(IList<DictItemEntity> list);

        IList<DictItemEntity> LoadAllByPacktypeId(string PackTypeId);

        IList<DictItemEntity> LoadAllDictItemJoin(string Condition);

        IList<DictItemEntity> LoadAllByFloorId(string LoadAllByFloorId);
    }
}
