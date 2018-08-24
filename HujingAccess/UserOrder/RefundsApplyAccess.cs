using HujingModel;
using ICommonAccess;
using IHujingAccess.UserOrder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.UserOrder
{
    class RefundsApplyAccess : SqlMapClientTemplate, IRefundsApplyAccess
    {
        public int Count(string condition)
        {
            try
            {
                int result = QueryForObject<int>("RefundsApplyMap.Count", condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public RefundsApplyEntity Load(string code)
        {
            try
            {
                RefundsApplyEntity dinner = QueryForObject<RefundsApplyEntity>("RefundsApplyMap.Load", code);
                return dinner;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<RefundsApplyEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<RefundsApplyEntity>("RefundsApplyMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(RefundsApplyEntity obj)
        {
            try
            {
                Insert("RefundsApplyMap.Insert", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(RefundsApplyEntity obj)
        {
            try
            {
                Update("RefundsApplyMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
