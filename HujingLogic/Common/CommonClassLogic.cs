using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using HujingModel;
using IHujingAccess;

namespace HujingLogic
{
    class CommonClassLogic : ICommonClassLogic
    {
        IDictCodeAccess commonAccess;
        public CommonClassLogic(IDictCodeAccess access)
        {
            commonAccess = access;
        }

        public IList<DictCodeEntity> GetDictCodeList(string Condition)
        {
            return commonAccess.LoadAll(Condition, 100, 1, "codeid");
        }
    }
}
