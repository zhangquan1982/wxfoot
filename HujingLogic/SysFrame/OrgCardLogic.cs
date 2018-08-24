using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using HujingModel;
using IHujingAccess;

namespace HujingLogic
{
    class OrgCardLogic : IOrgCardLogic
    {
        IOrgCardAccess icardaccess;
        public OrgCardLogic(IOrgCardAccess access)
        {
            icardaccess = access;
        }
        public OrgCardEntity Load(string OrgId)
        {
            return icardaccess.Load(OrgId);
        }
    }
}
