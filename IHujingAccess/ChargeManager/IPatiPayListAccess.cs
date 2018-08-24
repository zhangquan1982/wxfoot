using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess
{
    public interface IPatiPayListAccess : ILoad<PatiPayListEntity, string>, ISave<bool, PatiPayListEntity>, ILoadAll<PatiPayListEntity>, ICount
    {
        //bool SavePayListVoice(PatiPayListEntity payEnty, PatiIn_Pay_InvoiceEntity payInVoice, OldPersonInvisitEntity visit);

        IList<PersonPayVoiceVM> GetPersonPayList(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        bool Update(PatiPayListEntity obj);

        DataTable GetPayListOneDay(string Condition, int pageSize, int startIndex);

        DataTable GetPayListDetailDay(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);

        int GetPayDetailCount(string condition);

        int GetPersonPayListCount(string Condition);

        DataTable GetPayListUser(string Condition);
    }
}
