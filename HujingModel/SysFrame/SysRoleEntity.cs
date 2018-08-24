/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-6-27
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
    /// SysRole 
    /// </summary>
    [Serializable]
    public class SysRoleEntity
    {
        public SysRoleEntity()
        {

        }

        private string _roleid;
        private string _rolename;
        private string _memo;


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
        ///<sumary>
        /// 
        ///</sumary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
    }
}
