/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015/12/23 星期三
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
    /// PackageType 
    /// </summary>
    [Serializable]
    public class PackageTypeEntity
    {
        public PackageTypeEntity()
        {

        }

        private string _packagetypeid;
        private string _packagetypename;
        private bool _flag;
        private string _createuser;
        private DateTime _createdate;
        private string _updateuser;
        private DateTime _updatedate;
        private string _orgid;


        ///<sumary>
        /// 
        ///</sumary>
        public string OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }


        ///<sumary>
        /// 
        ///</sumary>
        public string PackAgeTypeId
        {
            get { return _packagetypeid; }
            set { _packagetypeid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string PackAgeTypeName
        {
            get { return _packagetypename; }
            set { _packagetypename = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
        }
    }
}
