using HujingModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.Basic
{
    public interface IScheItemDateLogic
    {
        int Count(string condition);

        ScheItemDateEntity Load(string code);

        bool Delete(string obj);


        bool Save(ScheItemDateEntity obj);

        IList<ScheItemDateEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        IList<ScheItemDateEntityAll> LoadScheAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool SaveItemList(IList<ScheItemDateEntity> items);

        bool DeleteScheItemDates(string SchIds);

        DataTable GetScheDateList(string Condition);

        DataTable GetScheDateListByDateAndType(string Condition);
    }
}
