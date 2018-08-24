using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface ISysUserRoleLogic
    {
        IList<SysUserRoleEntity> LoadAllUserRole(string Condition);

        IList<SysUserRoleEntity> SelectBindRole(string Condition);

        bool DeleteUserRole(List<SysUserRoleEntity> userRoles);

        bool SaveUserRole(List<SysUserRoleEntity> userRoleEnty);
    }
}
