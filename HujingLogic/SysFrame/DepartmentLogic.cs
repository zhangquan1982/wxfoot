using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using HujingAccess;
using HujingModel;


namespace HujingLogic
{
    public class DepartmentLogic : IDepartmentLogic
    {
        IDepartmentAccess depAccess;
        public DepartmentLogic(IDepartmentAccess access)
        {
            depAccess = access;
        }

        public int Count(string condition)
        {
            return depAccess.Count(condition);
        }

        public DepartmentEntity Load(string depId)
        {
            return depAccess.Load(depId);
        }

        public IList<DepartmentEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return depAccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Delete(string userid)
        {
            return depAccess.Delete(userid);
        }

        public bool Save(DepartmentEntity entity)
        {
            return depAccess.Save(entity);
        }

        public bool Update(DepartmentEntity entity)
        {
            return depAccess.Update(entity);
        }

        public string GetMaxDepId(string parentid)
        {
            return depAccess.GetMaxDepId(parentid);
        }

        public IList<DepartmentEntity> LoadNurseDep(string Condition)
        {
            return depAccess.LoadNurseDep(Condition);
        }
    }
}
