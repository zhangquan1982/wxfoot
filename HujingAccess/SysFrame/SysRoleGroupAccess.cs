using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using IHujingAccess;
using HujingModel;

namespace HujingAccess
{
    class SysRoleGroupAccess : SqlMapClientTemplate, ISysRoleGroupAccess
    {

        public IList<SysRoleGroupEntity> LoadAllRoleGroup(string roleid)
        {
            try
            {
                string Condition = " and roleid= '" + roleid + "'";
                return QueryForList<SysRoleGroupEntity>("SysRoleGroupMap.LoadAllRoleGroup", Condition);
            }
            catch
            {
                throw;
            }
        }

        public bool SaveRoleGroup(List<SysRoleGroupEntity> obj)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();

                bool isDel= Delete(obj[0].RoleId);
                if (isDel == false)
                {
                    SqlMapClientTemplate.mapper.RollBackTransaction();
                    return false;
                }

                foreach (SysRoleGroupEntity rolegroup in obj)
                {
                    Insert("SysRoleGroupMap.SaveRoleGroup", rolegroup);
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



        public bool DeleteRoleGroup(List<HujingModel.SysRoleGroupEntity> roleGroups)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                foreach (SysRoleGroupEntity rolegroup in roleGroups)
                {
                    Insert("SysRoleGroupMap.DeleteRoleGroup", rolegroup);
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




        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("SysRoleGroupMap.Count", condition);
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(string roleid)
        {
            try
            {
                Delete("SysRoleGroupMap.Delete", roleid);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
