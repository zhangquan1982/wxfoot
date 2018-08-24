using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.Basic
{
    public interface ICheckCodeLogic
    {
        int Count(string condition);

        bool Delete(string obj);

        CheckCodeEntity Load(string code);

        IList<CheckCodeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy);

        bool Save(CheckCodeEntity obj);

        bool Update(CheckCodeEntity obj);

        string GetNewCode(string mobile);
    }
}
