using HujingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic
{
    public interface IPatiPayListLogic
    {
        PatiPayListEntity Load(string code);

        bool Save(PatiPayListEntity obj);

        bool Update(PatiPayListEntity obj);

        IList<PatiPayListEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        int Count(string condition);

        //bool SavePayListVoice(PatiPayListEntity payEnty, PatiIn_Pay_InvoiceEntity payInVoice, OldPersonInvisitEntity visit);

        int GetPersonPayListCount(string Condition);

        IList<PersonPayVoiceVM> GetPersonPayList(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        //bool CancelPayAndVoice(PatiPayListEntity newPayment, PatiPayListEntity oldPayMent, OldPersonInvisitEntity oldPerson, PatiIn_Pay_InvoiceEntity voice);

        DataTable GetPayListOneDay(string Condition, int pageSize, int startIndex);

        DataTable GetPayListDetailDay(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        int GetPayDetailCount(string condition);

        DataTable GetPayListUser(string Condition);

        bool SavePayList(PatiPayListEntity newPayment, UserCardEntity usercard);
    }
}
