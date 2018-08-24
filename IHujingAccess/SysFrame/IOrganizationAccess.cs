using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public interface IOrganizationAccess : ICount, ILoad<OrganizationEntity, string>, IDelete<bool, string>, ISave<bool, OrganizationEntity>, IUpdate<bool, OrganizationEntity>, ILoadAll<OrganizationEntity>
    {
        string GetMaxOrgCode(string parentid);

        IList<CommonNameCount> LoadAllOrgBed(string Condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
