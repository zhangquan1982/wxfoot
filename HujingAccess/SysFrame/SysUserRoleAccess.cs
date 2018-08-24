using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using IHujingAccess;
using HujingModel;

namespace HujingAccess
{
    class SysUserRoleAccess : SqlMapClientTemplate, ISysUserRoleAccess
    {


        public IList<SysUserRoleEntity> LoadAllUserRole(string Condition)
        {
            try
            {
                return QueryForList<SysUserRoleEntity>("SysUserRoleMap.SelectSysUserRole", Condition);
            }
            catch
            {
                throw;
            }
        }

        public IList<SysUserRoleEntity> SelectBindRole(string Condition)
        {
            try
            {
                return QueryForList<SysUserRoleEntity>("SysUserRoleMap.SelectBindRole", Condition);
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteUserRole(List<SysUserRoleEntity> userRoles)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                foreach (SysUserRoleEntity userRole in userRoles)
                {
                    Delete("SysUserRoleMap.Delete", userRole);
                }

                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }

        public bool SaveUserRole(List<SysUserRoleEntity> userRoleEnty)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();

                foreach (SysUserRoleEntity userRole in userRoleEnty)
                {
                    Insert("SysUserRoleMap.Save", userRole);
                }
                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }
    }
}
