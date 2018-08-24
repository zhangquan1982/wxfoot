using HujingModel;
using ICommonAccess;
using IHujingAccess.ChargeManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.ChargeManager
{
    class PatiInBillItemAccess : SqlMapClientTemplate, IPatiInBillItemAccess
    {

        public PatiInBillItemEntity Load(string code)
        {
            try
            {
                PatiInBillItemEntity invoiceStore = QueryForObject<PatiInBillItemEntity>("PatiInBillItemMap.Load", code);
                return invoiceStore;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save(HujingModel.PatiInBillItemEntity obj)
        {
            try
            {
                Insert("PatiInBillItemMap.Insert", obj);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据条件查询数据.
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="pageSize"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public IList<PatiInBillItemEntity> LoadAllBillItem(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return QueryForList<PatiInBillItemEntity>("PatiInBillItemMap.LoadAllBillItem", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IList<PatiInBillItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<PatiInBillItemEntity>("PatiInBillItemMap.LoadAll", ht);
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
                int result = QueryForObject<int>("PatiInBillItemMap.Count", condition);
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        public int GetPersonBillCount(string Condition)
        {
            try
            {
                int result = QueryForObject<int>("PatiInBillItemMap.GetPersonBillCount", Condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetPersonPatiBillCondition(string Condition, int pageSize, int startIndex)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = Condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                return SqlMapClient.QueryForDataTable("PatiInBillItemMap.GetPersonBillList", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetPersonPatiBackBillCondition(string Condition, int pageSize, int startIndex)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = Condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                return SqlMapClient.QueryForDataTable("PatiInBillItemMap.GetPersonBackBillList", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetPersonPatiBillCollectCondition(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return SqlMapClient.QueryForDataTable("PatiInBillItemMap.GetPersonBillCollect", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetPersonBillTypeAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return SqlMapClient.QueryForDataTable("PatiInBillItemMap.GetPersonBillCollect", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GetPersonBillMonthAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return SqlMapClient.QueryForDataTable("PatiInBillItemMap.GetPersonBillMonthCollect", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
