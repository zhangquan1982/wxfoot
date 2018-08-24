using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface IDepartmentLogic
    {
        int Count(string condition);

        DepartmentEntity Load(string DepId);

        IList<DepartmentEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Delete(string userid);

        bool Save(DepartmentEntity entity);

        bool Update(DepartmentEntity entity);

        string GetMaxDepId(string parentid);

        IList<DepartmentEntity> LoadNurseDep(string Condition);
    }
}
