using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess.SysFrame
{
    public interface IRegionAreaAccess : ICount, ILoad<RegionAreaEntity, string>, IDelete<bool, string>, ISave<bool, RegionAreaEntity>, IUpdate<bool, RegionAreaEntity>, ILoadAll<RegionAreaEntity>
    {
        string SetRegCode(string parentid);
    }
}
