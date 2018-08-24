using HujingModel;
using ICommonAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingAccess.SysFrame
{
    public interface IUserCardAccess : ICount, ILoad<UserCardEntity, string>, IDelete<bool, string>, ISave<bool, UserCardEntity>, IUpdate<bool, UserCardEntity>, ILoadAllPage<UserCardEntity>
    {

    }
}
