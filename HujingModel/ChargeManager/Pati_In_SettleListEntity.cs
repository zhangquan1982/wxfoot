/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/3/16 星期三
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
    /// Pati_In_SettleList 
    /// </summary>
    [Serializable]
    public class Pati_In_SettleListEntity
    {
        public Pati_In_SettleListEntity()
        {

        }

        private string _settleid;
        private string _serialnum;
        private string _settletype;
        private System.Decimal _preamount;
        private System.Decimal _settlepayamount;
        private System.Decimal _settleamount;
        private System.Decimal _patiamount;
        private System.Decimal _addamount;
        private string _addreson;
        private System.Decimal _lessamount;
        private System.Decimal _lessreson;
        private int _printtimes;
        private string _cancuser;
        private DateTime? _cancdate;
        private string _cancreason;
        private string _cancid;
        private DateTime _createdate;
        private string _createuser;
        private DateTime? _updatedate;
        private string _updateuser;
        private string _orgid;


        public string OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string SettleId
        {
            get { return _settleid; }
            set { _settleid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string SerialNum
        {
            get { return _serialnum; }
            set { _serialnum = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string SettleType
        {
            get { return _settletype; }
            set { _settletype = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal PreAmount
        {
            get { return _preamount; }
            set { _preamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal SettlePayAmount
        {
            get { return _settlepayamount; }
            set { _settlepayamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal SettleAmount
        {
            get { return _settleamount; }
            set { _settleamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal PatiAmount
        {
            get { return _patiamount; }
            set { _patiamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal AddAmount
        {
            get { return _addamount; }
            set { _addamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string AddReson
        {
            get { return _addreson; }
            set { _addreson = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal LessAmount
        {
            get { return _lessamount; }
            set { _lessamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal LessReson
        {
            get { return _lessreson; }
            set { _lessreson = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int PrintTimes
        {
            get { return _printtimes; }
            set { _printtimes = value; }
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
        public string CancId
        {
            get { return _cancid; }
            set { _cancid = value; }
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
        public string CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime? UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
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
