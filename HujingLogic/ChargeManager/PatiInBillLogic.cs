using HujingModel;
using IHujingAccess;
using IHujingAccess.ChargeManager;
using IHujingLogic.ChargeManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HujingLogic.ChargeManager
{
    class PatiInBillLogic : IPatiInBillLogic
    {
        public IPatiInBillAccess billAcces { get; set; }
        public IPatiInBillItemAccess billItemAccess { get; set; }

        //public IOldPersonInvisitAccess personVisit { get; set; }

        public PatiInBillEntity Load(string code)
        {
            return billAcces.Load(code);
        }

        public bool Save(PatiInBillEntity obj)
        {
            return billAcces.Save(obj);
        }

        public IList<PatiInBillEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return billAcces.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public int Count(string condition)
        {
            return billAcces.Count(condition);
        }

        public bool SaveBillHeadAndItem(PatiInBillEntity bill, IList<PatiInBillItemEntity> billItem)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool ok1 = billAcces.Save(bill);
                    bool ok2 = true;
                    decimal decAllAmount = 0;
                    foreach (PatiInBillItemEntity item in billItem)
                    {
                        decAllAmount = decAllAmount;
                        bool ok3 = billItemAccess.Save(item);
                        if(ok3==false)
                        {
                            ok2 = false;
                        }
                    }
               
                    //OldPersonInvisitEntity person = personVisit.Load(bill.SerialNum);
                    //person.UpdateDate = DateTime.Now;
                    //person.UpdateUser = bill.CreateUser;
                    //person.FeeAmount = person.FeeAmount + decAllAmount;
                    //bool ok4 = personVisit.Update(person);
                    if ((ok1 && ok2 ) == false)
                    {
                        throw new Exception("错误！");
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

    }
}
