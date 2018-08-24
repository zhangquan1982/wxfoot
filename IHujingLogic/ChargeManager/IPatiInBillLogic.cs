using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.ChargeManager
{
    public interface IPatiInBillLogic
    {
        PatiInBillEntity Load(string code);

        bool Save(PatiInBillEntity obj);

        IList<PatiInBillEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        int Count(string condition);

        bool SaveBillHeadAndItem(PatiInBillEntity bill, IList<PatiInBillItemEntity> billItem);
    }
}
