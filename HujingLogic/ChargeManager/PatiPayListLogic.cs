using HujingModel;
using IHujingAccess;
using IHujingAccess.SysFrame;
using IHujingLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HujingLogic
{
    class PatiPayListLogic : IPatiPayListLogic
    {
        public IPatiPayListAccess access { get; set; }

        public IUserCardAccess usercard { get; set; }

        public IUserCardAccess cardAccess { get; set; }

        public PatiPayListEntity Load(string code)
        {
            return access.Load(code);
        }

        public bool Save(HujingModel.PatiPayListEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(PatiPayListEntity obj)
        {
            return access.Update(obj);
        }

        public IList<PatiPayListEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public int Count(string condition)
        {
            return access.Count(condition);
        }

        //public bool SavePayListVoice(PatiPayListEntity payEnty, PatiIn_Pay_InvoiceEntity payInVoice, OldPersonInvisitEntity visit)
        //{
        //    return access.SavePayListVoice(payEnty, payInVoice, visit);
        //}

        public IList<PersonPayVoiceVM> GetPersonPayList(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
             return access.GetPersonPayList(Condition, pageSize, startIndex,sortField, sortOrder);
        }

        //public bool CancelPayAndVoice(PatiPayListEntity newPayment, PatiPayListEntity oldPayMent, , PatiIn_Pay_InvoiceEntity voice)
        //{
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        try
        //        {
        //            bool isTrue = access.Save(newPayment);
        //            if (isTrue == false)
        //            {
        //                return false;
        //            }
        //            isTrue = access.Update(oldPayMent);
        //            if (isTrue == false)
        //            {
        //                return false;
        //            }
        //            isTrue = personVisitaccess.Update(oldPerson);
        //            if (isTrue == false)
        //            {
        //                return false;
        //            }
        //            isTrue = voiceAccess.Update(voice);
        //            if (isTrue == false)
        //            {
        //                return false;
        //            }
        //            trans.Complete();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }
        //}

        public DataTable GetPayListOneDay(string Condition, int pageSize, int startIndex)
        {
            return access.GetPayListOneDay(Condition, pageSize, startIndex);
        }

        public DataTable GetPayListDetailDay(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetPayListDetailDay(Condition, pageSize, startIndex, sortField, sortOrder);
        }

        public int GetPayDetailCount(string condition)
        {
            return access.GetPayDetailCount(condition);
        }

        public int GetPersonPayListCount(string Condition)
        {
            return access.GetPersonPayListCount(Condition);
        }

        public DataTable GetPayListUser(string Condition)
        {
            return access.GetPayListUser(Condition);
        }

        public bool SavePayList(PatiPayListEntity newPayment, UserCardEntity usercard)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool isTrue = access.Save(newPayment);
                    if (isTrue == false)
                    {
                        return false;
                    }
                    isTrue = cardAccess.Update(usercard);
                    if (isTrue == false)
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
    }
}
