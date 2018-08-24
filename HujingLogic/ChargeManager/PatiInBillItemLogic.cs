using HujingAccess.ChargeManager;
using HujingModel;
using IHujingAccess.ChargeManager;
using IHujingAccess.SysFrame;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HujingLogic
{
    class PatiInBillItemLogic : IPatiInBillItemLogic
    {
        public IPatiInBillItemAccess access { get; set; }

        public IUserCardAccess cardAccess { get; set; }
        public HujingModel.PatiInBillItemEntity Load(string code)
        {
            return access.Load(code);
        }

        public bool Save(HujingModel.PatiInBillItemEntity obj)
        {
            return access.Save(obj);
        }

        public IList<HujingModel.PatiInBillItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public  DataTable GetPersonPatiBillCondition(string Condition, int pageSize, int startIndex)
        {
            return access.GetPersonPatiBillCondition(Condition, pageSize, startIndex);
        }

        public DataTable GetPersonPatiBackBillCondition(string Condition, int pageSize, int startIndex)
        {
            return access.GetPersonPatiBackBillCondition(Condition, pageSize, startIndex);
        }

        public DataTable GetPersonPatiBillCollectCondition(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetPersonPatiBillCollectCondition(Condition, pageSize, startIndex, sortField, sortOrder);
        }

        public DataTable GetPersonBillTypeAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetPersonBillTypeAmount(Condition, pageSize, startIndex, sortField, sortOrder);
        }

        public int GetPersonBillCount(string Condition)
        {
            return access.GetPersonBillCount(Condition);
        }

        public bool SaveBillItemAndUserCard(PatiInBillItemEntity billItem, UserCardEntity cardEntity)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool ok1 = access.Save(billItem);

                    if (ok1 == false)
                    {
                        return false;
                    }

                    ok1 = cardAccess.Update(cardEntity);
                    if (ok1 == false)
                    {
                        return false;
                    }


                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<PatiInBillItemEntity> LoadAllBillItem(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.LoadAllBillItem(Condition,  pageSize,  startIndex,  sortField,  sortOrder);
        }


        public DataTable GetPersonBillMonthAmount(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetPersonBillMonthAmount(Condition, pageSize, startIndex, sortField, sortOrder);
        }
    }
}
