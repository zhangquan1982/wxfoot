using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using IHujingAccess;
using HujingModel;

namespace HujingLogic
{
    class DictCodeLogic : IDictCodeLogic
    {
        IDictCodeAccess codeAccess;
        public DictCodeLogic(IDictCodeAccess access)
        {
            codeAccess = access;
        }

        public int Count(string condition)
        {
            return codeAccess.Count(condition);
        }

        public DictCodeEntity Load(DictCodeEntity dictEntity)
        {
            return codeAccess.Load(dictEntity);
        }

        public bool Delete(DictCodeEntity entiy)
        {
            return codeAccess.Delete(entiy);
        }

        public bool Save(DictCodeEntity obj)
        {
            return codeAccess.Save(obj);
        }

        public bool Update(DictCodeEntity obj)
        {
            return codeAccess.Update(obj);
        }

        public IList<DictCodeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return codeAccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public  bool InitOrgDictCode(string Condition)
        {
            return codeAccess.InitOrgDictCode(Condition);
        }
    }
}
