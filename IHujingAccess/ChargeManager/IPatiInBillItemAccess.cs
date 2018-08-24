using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HujingModel;
using ICommonAccess;
using System.Data;
namespace IHujingAccess.ChargeManager
{
    public interface IPatiInBillItemAccess : ILoad<PatiInBillItemEntity, string>, ISave<bool, PatiInBillItemEntity>, ILoadAll<PatiInBillItemEntity>, ICount
    {
        DataTable GetPersonPatiBillCondition(string Condition, int pageSize, int startIndex);

        DataTable GetPersonPatiBackBillCondition(string Condition, int pageSize, int startIndex);

        DataTable GetPersonPatiBillCollectCondition(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        DataTable GetPersonBillTypeAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        int GetPersonBillCount(string Condition);

        IList<PatiInBillItemEntity> LoadAllBillItem(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        DataTable GetPersonBillMonthAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
