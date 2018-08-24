/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/7/10 星期日
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
    /// RegionArea 
    /// </summary>
    [Serializable]
    public class RegionAreaEntity
    {
        public RegionAreaEntity()
        {

        }

        private string _regid;
        private string _regname;
        private string _upperid;
        private string _inputstr;
        private string _regtype;
        private string _regtypename;
        private string _flag;
        private string _memo;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;

        ///<sumary>
        /// 
        ///</sumary>
        public string RegId
        {
            get { return _regid; }
            set { _regid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string RegName
        {
            get { return _regname; }
            set { _regname = value; }
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
        public string RegType
        {
            get { return _regtype; }
            set { _regtype = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string RegTypeName
        {
            get { return _regtypename; }
            set { _regtypename = value; }
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
    }
}
