using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface IOrganizationLogic
    {
        int Count(string condition);

        OrganizationEntity Load(string OrgId);

        IList<OrganizationEntity> LoadAll(string condition, int pageSize, int startIndex,string OrderBy);

        bool Delete(string userid);

        bool Save(OrganizationEntity entity);

        bool Update(OrganizationEntity entity);

        string GetMaxOrgCode(string parentid);

        IList<CommonNameCount> LoadAllOrgBed(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
