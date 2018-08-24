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
    /// SysGroup 
    /// </summary>
    [Serializable]
    public class SysGroupEntity
    {
        public SysGroupEntity()
        {

        }

        private string _groupid;
        private string _groupname;
        private string _parentid;
        private int _showorder;
        private string _iconcls;
        private string _url;
        private bool _flag;
        private string _histype;
        private string _iconclass;

        public string IconClass
        {
            get { return _iconclass; }
            set { _iconclass = value; }
        }

        public string HisType
        {
            get { return _histype; }
            set { _histype = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string GroupID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int ShowOrder
        {
            get { return _showorder; }
            set { _showorder = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string IconCls
        {
            get { return _iconcls; }
            set { _iconcls = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
