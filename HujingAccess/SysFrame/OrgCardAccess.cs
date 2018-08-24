using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using IHujingAccess;
using HujingModel;

namespace HujingAccess
{
    class OrgCardAccess : SqlMapClientTemplate, IOrgCardAccess
    {
        public OrgCardEntity Load(string orgid)
        {
            try
            {
                OrgCardEntity cardInfo = QueryForObject<OrgCardEntity>("OrgCardMap.Load", orgid);
                return cardInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save(OrgCardEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
