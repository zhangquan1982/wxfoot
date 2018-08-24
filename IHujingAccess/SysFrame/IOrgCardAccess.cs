using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public interface IOrgCardAccess : ILoad<OrgCardEntity, string>, ISave<bool, OrgCardEntity>
    {

    }
}
