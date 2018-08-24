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
    public class OrderDinnerAccess : SqlMapClientTemplate, IOrderDinnerAccess
    {
        public int Count(string condition)
        {
            try
            {
                int result = QueryForObject<int>("OrderDinnerMap.Count", condition);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public OrderDinnerEntity Load(string code)
        {
            try
            {
                if(!string.IsNullOrEmpty(code))
                {
                    OrderDinnerEntity dinner = QueryForObject<OrderDinnerEntity>("OrderDinnerMap.Load", code);
                    return dinner;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<OrderDinnerEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<OrderDinnerEntity>("OrderDinnerMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(OrderDinnerEntity obj)
        {
            try
            {
                Insert("OrderDinnerMap.Insert", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Task<bool>  SaveAsync(OrderDinnerEntity obj)
        {
            try
            {
                Insert("OrderDinnerMap.Insert", obj);
                //return new Task<bool>(() => true);
                return  Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
                //return new Task<bool>(() => false);
            }
        }

        public bool Update(OrderDinnerEntity obj)
        {
            try
            {
                Update("OrderDinnerMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataTable GetOrderDinnerCollect(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return SqlMapClient.QueryForDataTable("OrderDinnerMap.GetOrderDinnerCollect", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GetOrderDinnerDetail(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
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
                return SqlMapClient.QueryForDataTable("OrderDinnerMap.GetOrderDinnerDetail", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public int GetOrderDinnerDetailCount(string Condition)
        {
            try
            {
                int result = QueryForObject<int>("OrderDinnerMap.GetOrderDinnerDetailCount", Condition);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
