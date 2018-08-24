using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HujingModel
{
    public class SysRoleGroupEntity
    {
        private string _groupid;
        private string _roleid;


        ///<sumary>
        /// 模块Id
        ///</sumary>
        public string GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

   

        ///<sumary>
        /// 角色Id
        ///</sumary>
        public string RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
    }
}
