using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public interface ISysRoleAccess : ICount, ILoad<SysRoleEntity, string>, IDelete<bool, string>, ISave<bool, SysRoleEntity>, IUpdate<bool, SysRoleEntity>, ILoadAll<SysRoleEntity>
    {
        string GetMaxRoleId();
    }
}
