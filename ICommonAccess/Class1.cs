using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;

namespace ICommonAccess
{
    public class Class1 : SqlMapClientTemplate
    {

        public int Count(string condition)
        {
            SqlMapClientTemplate.mapper.BeginTransaction();
            int count = QueryForObject<int>("DataAccessTB_PAYMENT_NODETYPE.GetCount", condition);
            return count;
        }
    }
}
