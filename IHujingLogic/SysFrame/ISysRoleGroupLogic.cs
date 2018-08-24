using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface ISysRoleGroupLogic
    {
        int Count(string condition);
        IList<SysRoleGroupEntity> LoadAllRoleGroup(string roleid);
        bool SaveRoleGroup(List<HujingModel.SysRoleGroupEntity> obj);
        bool DeleteRoleGroup(List<HujingModel.SysRoleGroupEntity> roleGroups);


    }
}
