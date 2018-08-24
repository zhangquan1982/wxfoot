using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;

namespace IHujingLogic
{
    public interface IOrgCardLogic
    {
        OrgCardEntity Load(string OrgId);
    }
}
