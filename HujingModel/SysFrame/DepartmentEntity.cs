/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-9-9
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
    /// Department 
    /// </summary>
    [Serializable]
    public class DepartmentEntity
    {
        public DepartmentEntity()
        {

        }

        private string _depid;
        private string _orgid;
        private string _depname;
        private string _upperid;
        private string _inputstr;
        private string _deptype;
        private string _deptypename;
        private string _memo;
        private string _flag;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;

        ///<sumary>
        /// 
        ///</sumary>
        public string DepId
        {
            get { return _depid; }
            set { _depid = value; }
        }
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
        public string DepName
        {
            get { return _depname; }
            set { _depname = value; }
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
        public string DepType
        {
            get { return _deptype; }
            set { _deptype = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string DepTypeName
        {
            get { return _deptypename; }
            set { _deptypename = value; }
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
        public string Flag
        {
            get { return _flag; }
            set { _flag = value; }
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
    }
}
