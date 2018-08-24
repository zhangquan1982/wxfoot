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
    class PackageItemLogic : IPackageItemLogic
    {
        IPackageItemAccess itemAccess; 
        public PackageItemLogic(IPackageItemAccess access)
        {
            itemAccess = access;
        }

        public int Count(string condition)
        {
            return itemAccess.Count(condition);
        }

        public PackageItemEntity Load(string code)
        {
            return itemAccess.Load(code);
        }

        public bool Delete(string ItemId)
        {
            return itemAccess.Delete(ItemId);
        }

        public bool Save(PackageItemEntity obj)
        {
            return itemAccess.Save(obj);
        }

        public bool SaveList(IList<PackageItemEntity> obj)
        {
            return itemAccess.SaveList(obj);
        }

        public IList<PackageItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return itemAccess.LoadAll(condition, pageSize,startIndex,OrderBy);
        }
    }
}
