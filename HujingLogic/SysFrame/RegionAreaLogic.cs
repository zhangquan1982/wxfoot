using IHujingAccess.SysFrame;
using IHujingLogic.SysFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingLogic.SysFrame
{
    public class RegionAreaLogic : IRegionAreaLogic
    {
        public IRegionAreaAccess access { get; set; }
        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public HujingModel.RegionAreaEntity Load(string code)
        {
            return access.Load(code);
        }

        public bool Delete(string obj)
        {
            return access.Delete(obj);
        }

        public bool Save(HujingModel.RegionAreaEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(HujingModel.RegionAreaEntity entity)
        {
            return access.Save(entity);
        }

        public IList<HujingModel.RegionAreaEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }


        public string SetRegCode(string parentid)
        {
            return access.SetRegCode(parentid);
        }
    }
}
