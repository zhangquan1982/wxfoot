using HujingModel;
using IHujingAccess.UserOrder;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingLogic.UserOrder
{
    class SatisfactionLogic : ISatisfactionLogic
    {
        public ISatisfactionAccess access { get; set; }
        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public DataTable GetSatisfactGroupDate(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return access.GetSatisfactGroupDate(Condition, pageSize, startIndex, sortField, sortOrder);
        }

        public SatisfactionEntity Load(string code)
        {
            return access.Load(code);
        }

        public IList<SatisfactionEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Save(SatisfactionEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(SatisfactionEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
