using HujingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHujingLogic.SysFrame
{
    public interface IUserCardLogic
    {
        UserCardEntity Load(string carid);

        bool Update(UserCardEntity entity);
    }
}
