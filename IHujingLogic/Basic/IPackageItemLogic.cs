using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic
{
    public interface IPackageItemLogic
    {
        int Count(string condition);

        PackageItemEntity Load(string code);

        bool Delete(string ItemIds);

        bool Save(PackageItemEntity obj);

        bool SaveList(IList<PackageItemEntity> list);

        IList<PackageItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);
    }
}
