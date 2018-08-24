/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2018-07-01
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
    /// PatiPayList 
    /// </summary>
    [Serializable]
    public class PatiPayListEntity
    {
        public PatiPayListEntity()
        {

        }

        private string _payid;
        private string _userid;
        private string _cardid;
        private string _memo;
        private System.Decimal _payamount;
        private int _direction;
        private string _cancuser;
        private DateTime? _cancdate;
        private string _cancreason;
        private string _createuser;
        private DateTime _createdate;
        private string _cancid;
        private int _printtimes;

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
        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
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
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
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
        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CancUser
        {
            get { return _cancuser; }
            set { _cancuser = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime? CancDate
        {
            get { return _cancdate; }
            set { _cancdate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CancReason
        {
            get { return _cancreason; }
            set { _cancreason = value; }
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
        public string CancId
        {
            get { return _cancid; }
            set { _cancid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int PrintTimes
        {
            get { return _printtimes; }
            set { _printtimes = value; }
        }
    }
}
