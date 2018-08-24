using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic
{
    public interface IPackageTypeLogic
    {
        int Count(string condition);


        PackageTypeEntity Load(string code);


        bool Delete(string ItemIds);


        bool Save(PackageTypeEntity obj);


        IList<PackageTypeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);
    }
}
