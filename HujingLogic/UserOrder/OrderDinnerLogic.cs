using HujingModel;
using IHujingAccess.UserOrder;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HujingLogic.UserOrder
{
    public class OrderDinnerLogic : IOrderDinnerLogic
    {
        public IOrderDinnerAccess access { get; set; }
        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public OrderDinnerEntity Load(string code)
        {
            return access.Load(code);
        }

        public IList<OrderDinnerEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Save(OrderDinnerEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(OrderDinnerEntity obj)
        {
            return access.Update(obj);
        }

        public DataTable GetOrderDinnerCollect(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetOrderDinnerCollect(Condition, pageSize, startIndex, sortField, sortOrder);
        }

        public DataTable GetOrderDinnerDetail(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetOrderDinnerDetail(Condition, pageSize, startIndex, sortField, sortOrder);
        }


        public int GetOrderDinnerDetailCount(string Condition)
        {
            return access.GetOrderDinnerDetailCount(Condition);
        }

        public bool CancelOrderDinner(string[] cancelOrderIds)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool isok = true;
                    foreach (var itemstring in cancelOrderIds)
                    {
                        OrderDinnerEntity dinner = access.Load(itemstring);
                        if (dinner != null)
                        {
                            dinner.CancDate = DateTime.Now;
                            dinner.CancUser = dinner.CreateUser;
                            isok = access.Update(dinner);
                            if(isok==false)
                            {
                                return false;
                            }
                        }
                    }

                    if (isok == true)
                    {
                        trans.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public Task<bool> setBatchOrder(IList<OrderDinnerEntity> orderList)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    Task<bool> isok = Task.FromResult(true);
                    foreach (var orderItem in orderList)
                    {
                        //isok = access.Save(orderItem);
                        isok= access.SaveAsync(orderItem) ;
                    }

                    if (isok.Result == false)
                    {
                        return Task.FromResult(false);
                    }
                    trans.Complete();
                    return Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    return Task.FromResult(false);
                }
            }
        }



    }
}
