/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/7/11 星期一
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
    /// Organization 
    /// </summary>
    [Serializable]
    public class OrganizationEntity
    {
        public OrganizationEntity()
        {

        }

        private string _orgid;
        private string _orgname;
        private string _upperid;
        private string _inputstr;
        private string _orgtype;
        private string _orgtypename;
        private string _flag;
        private string _memo;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;
        private string _imgurl;
        private DateTime _setuptime;
        private int _bednum;
        private string _area;
        private string _relationpeople;
        private string _address;
        private string _telphone;
        private int _mobile;
        private string _orgemail;
        private string _loginname;
        private string _password;

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
        public string OrgName
        {
            get { return _orgname; }
            set { _orgname = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string UpperId
        {
            get { return _upperid; }
            set { _upperid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string InputStr
        {
            get { return _inputstr; }
            set { _inputstr = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrgType
        {
            get { return _orgtype; }
            set { _orgtype = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrgTypeName
        {
            get { return _orgtypename; }
            set { _orgtypename = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
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
        public DateTime UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
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
        public string UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ImgUrl
        {
            get { return _imgurl; }
            set { _imgurl = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime SetupTime
        {
            get { return _setuptime; }
            set { _setuptime = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int BedNum
        {
            get { return _bednum; }
            set { _bednum = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string RelationPeople
        {
            get { return _relationpeople; }
            set { _relationpeople = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string TelPhone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrgEmail
        {
            get { return _orgemail; }
            set { _orgemail = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
