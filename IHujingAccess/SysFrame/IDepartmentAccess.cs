using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;
using ICommonAccess;

namespace HujingAccess
{
    public interface IDepartmentAccess : ICount, ILoad<DepartmentEntity, string>, IDelete<bool, string>, ISave<bool, DepartmentEntity>, IUpdate<bool, DepartmentEntity>, ILoadAll<DepartmentEntity>
    {
        string GetMaxDepId(string parentid);

        IList<DepartmentEntity> LoadNurseDep(string Condition);
    }
}
