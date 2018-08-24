/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-7-2
 * 
 *       修改日期： 
 *       修改人：
 *       修改内容：
 * 
 * *************************************************************************/
namespace HujingModel
{
    using System;

    /// <summary>
    /// SysUserRole 
    /// </summary>
    [Serializable]
    public class SysUserRoleEntity
    {
        public SysUserRoleEntity()
        {

        }

        private string _userid;
        private string _username;
        private string _roleid;
        private string _rolename;

        ///<sumary>
        /// 
        ///</sumary>
        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
    }
}
