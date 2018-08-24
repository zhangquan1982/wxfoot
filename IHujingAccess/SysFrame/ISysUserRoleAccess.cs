using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;
using ICommonAccess;

namespace IHujingAccess
{
    public interface ISysUserRoleAccess
    {
        IList<SysUserRoleEntity> LoadAllUserRole(string userid);

        IList<SysUserRoleEntity> SelectBindRole(string Condition);

        bool DeleteUserRole(List<SysUserRoleEntity> userRoles);

        bool SaveUserRole(List<SysUserRoleEntity> userRoleEnty);
    }
}
