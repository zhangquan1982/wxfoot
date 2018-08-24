using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public interface IDictCodeAccess : ICount, ISave<bool, DictCodeEntity>, IUpdate<bool, DictCodeEntity>, ILoadAll<DictCodeEntity>
    {
        bool Delete(DictCodeEntity entiy);

        DictCodeEntity Load(DictCodeEntity dictEntity);

        bool InitOrgDictCode(string Condition);
    }
}
