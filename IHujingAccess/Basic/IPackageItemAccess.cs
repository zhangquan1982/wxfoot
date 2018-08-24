using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess
{
    public interface IPackageItemAccess : ICount, ILoad<PackageItemEntity, string>, IDelete<bool, string>, ISave<bool, PackageItemEntity>, ILoadAll<PackageItemEntity>
    {
        bool SaveList(IList<PackageItemEntity> list);
    }
}
