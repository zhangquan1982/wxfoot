using HujingModel;
using ICommonAccess;
using IHujingAccess.UserOrder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.UserOrder
{
    class SatisfactionAccess : SqlMapClientTemplate, ISatisfactionAccess
    {
        public int Count(string condition)
        {
            try
            {
                int result = QueryForObject<int>("SatisfactionMap.Count", condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public SatisfactionEntity Load(string code)
        {
            try
            {
                SatisfactionEntity dinner = QueryForObject<SatisfactionEntity>("SatisfactionMap.Load", code);
                return dinner;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<SatisfactionEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            throw new NotImplementedException();
        }

        public bool Save(SatisfactionEntity obj)
        {
            try
            {
                Insert("SatisfactionMap.Insert", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(SatisfactionEntity obj)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSatisfactGroupDate(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = Condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                ht["sortField"] = sortField;
                ht["sortOrder"] = sortOrder;
                return SqlMapClient.QueryForDataTable("SatisfactionMap.GetSatisfactGroupDate", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
