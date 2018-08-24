using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.SysFrame
{
    public interface IRegionAreaLogic
    {
        int Count(string condition);

        RegionAreaEntity Load(string code);

        bool Delete(string obj);

        bool Save(HujingModel.RegionAreaEntity obj);

        bool Update(RegionAreaEntity entity);

        IList<RegionAreaEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        string SetRegCode(string parentid);
    }
}
