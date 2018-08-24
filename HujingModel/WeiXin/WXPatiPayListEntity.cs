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
    /// WXPatiPayList 
    /// </summary>
    [Serializable]
    public class WXPatiPayListEntity
    {
        public WXPatiPayListEntity()
        {

        }

        private string _payid;
        private string _orgid;
        private string _patiid;
        private System.Decimal _payamount;
        private string _createuser;
        private DateTime _createdate;
        private string _memo;

        ///<sumary>
        /// 
        ///</sumary>
        public string PayId
        {
            get { return _payid; }
            set { _payid = value; }
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
        public string PatiId
        {
            get { return _patiid; }
            set { _patiid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal PayAmount
        {
            get { return _payamount; }
            set { _payamount = value; }
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
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
    }
}
