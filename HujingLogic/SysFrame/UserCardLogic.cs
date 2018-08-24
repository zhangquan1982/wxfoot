using HujingModel;
using IHujingAccess.SysFrame;
using IHujingLogic.SysFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingLogic.SysFrame
{
    class UserCardLogic : IUserCardLogic
    {
        public IUserCardAccess  access { get; set; }
        public UserCardEntity Load(string UserId)
        {
            return access.Load(UserId);
        }

        public bool Update(UserCardEntity entity)
        {
            return access.Update(entity);
        }
    }
}
