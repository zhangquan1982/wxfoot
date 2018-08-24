using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommonAccess;
using System.Data;

namespace IHujingAccess.UserOrder
{
    public interface IOrderDinnerAccess : ILoad<OrderDinnerEntity, string>, ISave<bool, OrderDinnerEntity>, IUpdate<bool, OrderDinnerEntity>, ILoadAll<OrderDinnerEntity>, ICount
    {
        DataTable GetOrderDinnerCollect(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        /// <summary>
        /// 获取预约订餐明细。
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="pageSize"></param>
        /// <param name="startIndex"></param>
        /// <param name="sortField"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        DataTable GetOrderDinnerDetail(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        int GetOrderDinnerDetailCount(string Condition);


        Task<bool> SaveAsync(OrderDinnerEntity obj);
    }
}
