/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2017/6/4 星期日
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
    /// CheckCode 
    /// </summary>
    [Serializable]
    public class CheckCodeEntity
    {
        public CheckCodeEntity()
        {

        }

        private string _mobile;
        private string _code;
        private string _ipaddress;
        private DateTime _createdate;
        private DateTime? _expiredate;
        private string _isuse;
        private DateTime? _userdate;

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
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string IPAddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
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
        public DateTime? ExpireDate
        {
            get { return _expiredate; }
            set { _expiredate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string IsUse
        {
            get { return _isuse; }
            set { _isuse = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime? UserDate
        {
            get { return _userdate; }
            set { _userdate = value; }
        }
    }
}
