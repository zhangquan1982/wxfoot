using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess
{
    public interface IPackageTypeAccess : ICount, ILoad<PackageTypeEntity, string>, IDelete<bool, string>, ISave<bool, PackageTypeEntity>, ILoadAll<PackageTypeEntity>
    {

    }
}
