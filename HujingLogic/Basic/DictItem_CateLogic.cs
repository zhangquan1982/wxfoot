using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using IHujingAccess;
using HujingModel;

namespace HujingLogic
{
    class DictItem_CateLogic : IDictItem_CateLogic
    {
        IDictItem_CateAccess cateAccess;
        public DictItem_CateLogic(IDictItem_CateAccess access)
        {
            cateAccess = access;
        }

        public int Count(string condition)
        {
            return cateAccess.Count(condition);
        }

        public DictItem_CateEntity Load(string code)
        {
            return cateAccess.Load(code);
        }

        public IList<DictItem_CateEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return cateAccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Save(DictItem_CateEntity obj)
        {
            return cateAccess.Save(obj);
        }

        public bool Update(DictItem_CateEntity obj)
        {
            return cateAccess.Update(obj);
        }

        public bool Delete(string CateIds)
        {
            return cateAccess.Delete(CateIds);
        }


        public string GetMaxCateId(string Condition)
        {
            return cateAccess.GetMaxCateId(Condition);
        }
    }
}
