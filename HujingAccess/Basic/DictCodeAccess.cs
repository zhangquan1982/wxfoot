using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using IHujingAccess;
using HujingModel;
using System.Collections;

namespace HujingAccess
{
    class DictCodeAccess : SqlMapClientTemplate, IDictCodeAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("DictCodeMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DictCodeEntity Load(DictCodeEntity dictEntity)
        {
            try
            {
                DictCodeEntity orgInfo = QueryForObject<DictCodeEntity>("DictCodeMap.Load", dictEntity);
                return orgInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(DictCodeEntity entity)
        {
            try
            {
                Delete("DictCodeMap.Delete", entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(DictCodeEntity obj)
        {
            try
            {
                Insert("DictCodeMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InitOrgDictCode(string Condition)
        {
            try
            {
                DictCodeEntity code = new DictCodeEntity();
                code.OrgId = Condition;
                Insert("DictCodeMap.InitOrgDictCode", code);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DictCodeEntity obj)
        {
            try
            {
                Update("DictCodeMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<DictCodeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                ht["OrderBy"] = OrderBy;
                return QueryForList<DictCodeEntity>("DictCodeMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
