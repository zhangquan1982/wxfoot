using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using IHujingAccess;
using HujingModel;

namespace HujingLogic
{
    class DictItemLogic : IDictItemLogic
    {
        IDictItemAccess itemAccess;

        public DictItemLogic(IDictItemAccess access)
        {
            itemAccess = access;
        }

        public int Count(string condition)
        {
            return itemAccess.Count(condition);
        }

        public DictItemEntity Load(string code)
        {
            return itemAccess.Load(code);
        }

        public bool Delete(string items)
        {
            return itemAccess.Delete(items);
        }

        public IList<DictItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return itemAccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Save(HujingModel.DictItemEntity obj)
        {
            return itemAccess.Save(obj);
        }

        public bool Update(HujingModel.DictItemEntity obj)
        {
            return itemAccess.Update(obj);
        }

        public string GetMaxCateId(string Condition)
        {
            throw new NotImplementedException();
        }


        public bool SaveList(IList<DictItemEntity> list)
        {
            return itemAccess.SaveList(list);
        }

        public IList<DictItemEntity> LoadAllByPacktypeId(string PackTypeId)
        {
            return itemAccess.LoadAllByPacktypeId(PackTypeId);
        }


        public IList<DictItemEntity> LoadAllDictItemJoin(string Condition)
        {
            return itemAccess.LoadAllDictItemJoin(Condition);
        }

        public IList<DictItemEntity> LoadAllByFloorId(string fllorid)
        {
            return itemAccess.LoadAllByFloorId(fllorid);
        }
    }
}
