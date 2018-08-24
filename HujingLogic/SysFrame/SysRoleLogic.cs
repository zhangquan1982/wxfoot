using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using IHujingAccess;
using HujingModel;

namespace HujingLogic
{
    public class SysRoleLogic : ISysRoleLogic
    {
        ISysRoleAccess roleAccess;
        public SysRoleLogic(ISysRoleAccess access)
        {
            roleAccess = access;
        }

        public int Count(string condition)
        {
            return roleAccess.Count(condition);
        }

        public SysRoleEntity Load(string roleId)
        {
            return roleAccess.Load(roleId);
        }

        public bool Delete(string RoleIds)
        {
            return roleAccess.Delete(RoleIds);
        }

        public bool Save(SysRoleEntity role)
        {
            return roleAccess.Save(role);
        }

        public bool Update(SysRoleEntity entity)
        {
            return roleAccess.Update(entity);
        }

        public IList<SysRoleEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return roleAccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }


        public string GetMaxRoleId()
        {
            return roleAccess.GetMaxRoleId();
        }
    }
}
