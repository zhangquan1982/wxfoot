using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess.Basic
{
    public interface ICheckCodeAccess : ICount, ILoad<CheckCodeEntity, string>, IDelete<bool, string>, ISave<bool, CheckCodeEntity>, IUpdate<bool, CheckCodeEntity>, ILoadAll<CheckCodeEntity>
    {
        string GetNewCode(string mobile);
    }
}
