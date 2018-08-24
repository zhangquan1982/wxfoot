using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICommonAccess
{
    public  interface ILoadAllPage<T>
    {
        /// <summary>
        /// 加载所有对象
        /// </summary>
        IList<T> LoadAll(string condition, int pageSize, int startIndex, string sortField, string sortOrder);
    }
}
