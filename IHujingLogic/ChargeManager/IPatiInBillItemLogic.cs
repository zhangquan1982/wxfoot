using HujingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.ChargeManager
{
    public interface IPatiInBillItemLogic
    {
        PatiInBillItemEntity Load(string code);

        bool Save(PatiInBillItemEntity obj);

        IList<PatiInBillItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        int Count(string condition);
        DataTable GetPersonPatiBillCondition(string Condition, int pageSize, int startIndex);

        DataTable GetPersonPatiBackBillCondition(string Condition, int pageSize, int startIndex);

        DataTable GetPersonPatiBillCollectCondition(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        DataTable GetPersonBillTypeAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        int GetPersonBillCount(string Condition);


        bool SaveBillItemAndUserCard(PatiInBillItemEntity billItem, UserCardEntity cardEntity);

        IList<PatiInBillItemEntity> LoadAllBillItem(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        DataTable GetPersonBillMonthAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
