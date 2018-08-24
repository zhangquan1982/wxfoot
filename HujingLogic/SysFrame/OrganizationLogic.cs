using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using IHujingAccess;
using HujingModel;

namespace HujingLogic
{
    public class OrganizationLogic : IOrganizationLogic
    {
        IOrganizationAccess iorg;
        public OrganizationLogic(IOrganizationAccess access)
        {
            iorg = access;
        }

        public IList<OrganizationEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return iorg.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public int Count(string condition)
        {
            return iorg.Count(condition);
        }

        public OrganizationEntity Load(string OrgId)
        {
            return iorg.Load(OrgId);
        }

        public bool Delete(string OrgIds)
        {
            return iorg.Delete(OrgIds);
        }

        public bool Save(OrganizationEntity entity)
        {
           return iorg.Save(entity);
        }

        public bool Update(OrganizationEntity entity)
        {
            return iorg.Update(entity);
        }

        public string GetMaxOrgCode(string parentid)
        {
            return iorg.GetMaxOrgCode(parentid);
        }

        public IList<CommonNameCount> LoadAllOrgBed(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return iorg.LoadAllOrgBed(Condition,  pageSize,  startIndex,  sortField,  sortOrder);
        }
    }
}
