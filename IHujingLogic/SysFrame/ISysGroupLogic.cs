using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface ISysGroupLogic
    {
        int Count(string condition);

        SysGroupEntity Load(string code);

        bool Delete(string GroupIds);

        bool Save(SysGroupEntity obj);

        bool SaveSysOrgGroup(IList<SysOrgGroupEntity> obj);

        bool Update(SysGroupEntity obj);

        IList<SysGroupEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        IList<SysGroupEntity> LoadGroupListByUserId(string UserId);

        int GetSysOrgGroupCount(string Condition);

        IList<SysGroupEntity> LoadAllByParentIdAndUserId(string condition, int pageSize, int startIndex, string OrderBy);
    }
}
