using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;
using ICommonAccess;

namespace IHujingAccess
{
    public interface ISysRoleGroupAccess : ICount,IDelete<bool, string>
    {
        IList<SysRoleGroupEntity> LoadAllRoleGroup(string roleid);
        bool SaveRoleGroup(List<SysRoleGroupEntity> obj);
        bool DeleteRoleGroup(List<SysRoleGroupEntity> roleGroups);
    }
}
