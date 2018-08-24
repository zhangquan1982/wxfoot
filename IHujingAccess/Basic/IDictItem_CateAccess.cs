using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;

namespace IHujingAccess
{
    public  interface IDictItem_CateAccess : ICount,ILoad<DictItem_CateEntity,string>,IDelete<bool,string>, ISave<bool, DictItem_CateEntity>, IUpdate<bool, DictItem_CateEntity>, ILoadAll<DictItem_CateEntity>
    {
        string GetMaxCateId(string Condition);
    }
}
