using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingAccess;
using IHujingLogic;
using HujingModel;

namespace HujingLogic
{
    public class SysUserRoleLogic : ISysUserRoleLogic
    {
        ISysUserRoleAccess userroleAccess;

        public SysUserRoleLogic(ISysUserRoleAccess access)
        {
            userroleAccess = access;
        }

        

        public IList<SysUserRoleEntity> LoadAllUserRole(string Condition)
        {
            return userroleAccess.LoadAllUserRole(Condition);
        }

        public bool DeleteUserRole(List<SysUserRoleEntity> userRoles)
        {
            return userroleAccess.DeleteUserRole(userRoles);
        }

        public bool SaveUserRole(List<SysUserRoleEntity> userRoleEnty)
        {
            return userroleAccess.SaveUserRole(userRoleEnty);
        }


        public IList<SysUserRoleEntity> SelectBindRole(string Condition)
        {
            return userroleAccess.SelectBindRole(Condition);
        }
    }
}
