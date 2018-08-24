using HujingModel;
using ICommonAccess;
using IHujingAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.ChargeManager
{
    public class PatiPayListAccess : SqlMapClientTemplate, IPatiPayListAccess
    {

        public PatiPayListEntity Load(string PayId)
        {
            try
            {
                PatiPayListEntity payEntity = QueryForObject<PatiPayListEntity>("PatiPayListMap.Load", PayId);
                return payEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(PatiPayListEntity obj)
        {
            try
            {
                Insert("PatiPayListMap.Insert", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PatiPayListEntity obj)
        {
            try
            {
                Update("PatiPayListMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SavePayListVoice(PatiPayListEntity payEnty, PatiIn_Pay_InvoiceEntity payInVoice)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                Insert("PatiPayListMap.Insert", payEnty);
                Insert("PatiIn_Pay_InvoiceMap.Insert", payInVoice);
                //Update("OldPersonInvisitMap.Update", visit);
                //Fin_Invoice_StoreEntity store = new Fin_Invoice_StoreEntity();
                //Update("Fin_Invoice_StoreMap.UpdateNowInvoice", store);
                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }

        }

        public IList<PatiPayListEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<PatiPayListEntity>("PatiPayListMap.LoadAll", ht);
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
                int result = QueryForObject<int>("PatiPayListMap.Count", condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public int GetPayDetailCount(string condition)
        {
            try
            {
                int result = QueryForObject<int>("PatiPayListMap.GetPayDetailCount", condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }


        public int GetPersonPayListCount(string Condition)
        {
            try
            {
                int result = QueryForObject<int>("PatiPayListMap.GetPersonPayListCount", Condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="pageSize"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public IList<PersonPayVoiceVM> GetPersonPayList(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return QueryForList<PersonPayVoiceVM>("PatiPayListMap.GetPersonPayList", ht);
            }
            catch (Exception)
            {
                throw;

            }
        }

        public DataTable GetPayListOneDay(string Condition, int pageSize, int startIndex)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = Condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                return SqlMapClient.QueryForDataTable("PatiPayListMap.GetPayListOneDay", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GetPayListDetailDay(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            IDictionary ht = new Hashtable();
            int Prev = startIndex * pageSize;
            int Next = pageSize * (startIndex - 1) + 1;
            ht["Condition"] = Condition;
            ht["Prev"] = Prev;
            ht["Next"] = Next;
            ht["sortField"] = sortField;
            ht["sortOrder"] = sortOrder;
            return SqlMapClient.QueryForDataTable("PatiPayListMap.GetPayListDetailDay", ht);
        }


        public DataTable GetPayListUser(string Condition)
        {
            try
            {
                return SqlMapClient.QueryForDataTable("PatiPayListMap.GetPayListUser", Condition);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
