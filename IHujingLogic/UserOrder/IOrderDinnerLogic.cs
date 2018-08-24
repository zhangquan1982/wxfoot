using HujingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.UserOrder
{
    public interface IOrderDinnerLogic
    {
        int Count(string condition);

        OrderDinnerEntity Load(string code);

        IList<OrderDinnerEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Save(OrderDinnerEntity obj);

        bool Update(OrderDinnerEntity obj);

        DataTable GetOrderDinnerCollect(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);


        DataTable GetOrderDinnerDetail(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        int GetOrderDinnerDetailCount(string Condition);

        bool CancelOrderDinner(string[] cancelOrderIds);


        Task<bool> setBatchOrder(IList<OrderDinnerEntity> orderList);


    }
}
