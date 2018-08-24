using HujingModel;
using ICommonAccess;
using IHujingAccess.ChargeManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.ChargeManager
{
    class PatiInBillAccess : SqlMapClientTemplate, IPatiInBillAccess
    {

        public PatiInBillEntity Load(string code)
        {
            try
            {
                PatiInBillEntity billEntity = QueryForObject<PatiInBillEntity>("PatiInBillMap.Load", code);
                return billEntity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save(PatiInBillEntity obj)
        {
            try
            {
                Insert("PatiInBillMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<HujingModel.PatiInBillEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            try
            {
                IDictionary ht = new Hashtable();
                ht["Condition"] = condition;
                ht["PageSize"] = pageSize;
                ht["Next"] = pageSize * (startIndex - 1);
                return QueryForList<PatiInBillEntity>("PatiInBillMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;

            }
        }

        public int Count(string condition)
        {
            try
            {
                int result = QueryForObject<int>("PatiInBillMap.Count", condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
