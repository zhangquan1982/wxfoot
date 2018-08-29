/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-6-23
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
    /// UserInfo 
    /// </summary>
    [Serializable]
    public class UserInfoEntity
    {
        public UserInfoEntity()
        {

        }

        private string _userid;
        private string _username;
        private string _inputstr;
        private string _password;
        private string _depid;
        private int _flag;
        private string _address;
        private string _phone;
        private string _mobile;
        private string _loginname;
        private string _sex;
        private DateTime _birthdate;
        private string _email;
        private string _memo;
        private string _roletype;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;
        private string _openid;
        private string _cardid;
        private string _identycard;

        ///<sumary>
        /// 
        ///</sumary>
        public string CardId
        {
            get { return _cardid; }
            set { _cardid = value; }
        }


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
        public string InputStr
        {
            get { return _inputstr; }
            set { _inputstr = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
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
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
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
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
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
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime BirthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public string RoleType
        {
            get { return _roletype; }
            set { _roletype = value; }
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

        public string OpenId
        {
            get { return _openid; }
            set { _openid = value; }
        }


        public string IdentyCard
        {
            get { return _identycard; }
            set { _identycard = value; }
        }
    }
}
