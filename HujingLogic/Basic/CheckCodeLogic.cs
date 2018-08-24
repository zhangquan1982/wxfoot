using IHujingLogic.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HujingModel;
using IHujingAccess.Basic;

namespace HujingLogic.Basic
{
    class CheckCodeLogic : ICheckCodeLogic
    {
        public ICheckCodeAccess access { get; set; }
        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public bool Delete(string obj)
        {
            throw new NotImplementedException();
        }

        public CheckCodeEntity Load(string code)
        {
            return access.Load(code);
        }

        public IList<CheckCodeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            throw new NotImplementedException();
        }

        public bool Save(CheckCodeEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(CheckCodeEntity obj)
        {
            return access.Update(obj);
        }

        public string GetNewCode(string mobile)
        {
            return access.GetNewCode(mobile);
        }
    }
}
