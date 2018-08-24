using HujingModel;
using IHujingAccess;
using IHujingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingLogic
{
    class PackageTypeLogic : IPackageTypeLogic
    {
        IPackageTypeAccess typeAccess;
        public PackageTypeLogic(IPackageTypeAccess access)
        {
            typeAccess = access;
        }

        public int Count(string condition)
        {
            return typeAccess.Count(condition);
        }

        public HujingModel.PackageTypeEntity Load(string code)
        {
            return typeAccess.Load(code);
        }

        public bool Delete(string ItemIds)
        {
            return typeAccess.Delete(ItemIds);
        }


        public IList<PackageTypeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return typeAccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }


        public bool Save(PackageTypeEntity obj)
        {
            return typeAccess.Save(obj);
        }
    }
}
