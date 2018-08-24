using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess.Basic
{
    public interface IScheItemDateAccess : ICount, ILoad<ScheItemDateEntity, string>, IDelete<bool, string>, ISave<bool, ScheItemDateEntity>, ILoadAll<ScheItemDateEntity>
    {
        IList<ScheItemDateEntityAll> LoadScheAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool DeleteScheItemDates(string SchIds);

        DataTable GetScheDateList(string Condition);

        DataTable GetScheDateListByDateAndType(string Condition);
    }
}
