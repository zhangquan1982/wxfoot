using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HujingModel;
using ICommonAccess;

namespace IHujingAccess.ChargeManager
{
    public interface IPatiInBillAccess : ILoad<PatiInBillEntity, string>, ISave<bool, PatiInBillEntity>, ILoadAll<PatiInBillEntity>, ICount
    {

    }
}
