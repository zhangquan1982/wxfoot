using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface ISysRoleLogic
    {
        int Count(string condition);

        SysRoleEntity Load(string code);

        bool Delete(string RoleIds);

        bool Save(HujingModel.SysRoleEntity obj);

        bool Update(SysRoleEntity obj);

        IList<SysRoleEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        string GetMaxRoleId();
    }
}
