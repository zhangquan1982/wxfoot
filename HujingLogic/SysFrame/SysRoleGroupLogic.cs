using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingAccess;
using IHujingLogic;
using HujingModel;

namespace HujingLogic
{
    class SysRoleGroupLogic : ISysRoleGroupLogic
    {
        ISysRoleGroupAccess rolegroupAccess;



        public SysRoleGroupLogic(ISysRoleGroupAccess rolegroup)
        {
            rolegroupAccess = rolegroup;
        }

        public int Count(string condition)
        {
            return rolegroupAccess.Count(condition);
        }


        public bool SaveRoleGroup(List<HujingModel.SysRoleGroupEntity> obj)
        {
            return rolegroupAccess.SaveRoleGroup(obj);
        }



        public bool DeleteRoleGroup(List<HujingModel.SysRoleGroupEntity> roleGroups)
        {
            return rolegroupAccess.DeleteRoleGroup(roleGroups);
        }


        public IList<SysRoleGroupEntity> LoadAllRoleGroup(string roleid)
        {
            return rolegroupAccess.LoadAllRoleGroup(roleid);
        }
    }
}
