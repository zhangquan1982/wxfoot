using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public interface ISysGroupAccess : ICount, ILoad<SysGroupEntity, string>, IDelete<bool, string>, ISave<bool, SysGroupEntity>, IUpdate<bool, SysGroupEntity>, ILoadAll<SysGroupEntity>
    {
        int GetSysOrgGroupCount(string Condition);
        IList<SysGroupEntity> LoadGroupListByUserId(string userid);

        SysOrgGroupEntity LoadSysGroup(string orgid, string groupid);

        bool SaveSysOrgGroup(HujingModel.SysOrgGroupEntity obj);

        IList<SysGroupEntity> LoadAllByParentIdAndUserId(string condition, int pageSize, int startIndex, string OrderBy);
    }
}
