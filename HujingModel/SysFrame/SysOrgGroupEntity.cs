/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/5/26 星期四
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
    /// SysOrgGroup 
    /// </summary>
    [Serializable]
    public class SysOrgGroupEntity
    {
        public SysOrgGroupEntity()
        {

        }

        private string _orgid;
        private string _groupid;
        private string _chargestatus;
        private DateTime _begindate;
        private DateTime _enddate;
        private System.Decimal _chargeprice;
        private string _chargememo;
        private string _chargeurl;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;

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
        public string GroupID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ChargeStatus
        {
            get { return _chargestatus; }
            set { _chargestatus = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime BeginDate
        {
            get { return _begindate; }
            set { _begindate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal ChargePrice
        {
            get { return _chargeprice; }
            set { _chargeprice = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ChargeMemo
        {
            get { return _chargememo; }
            set { _chargememo = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ChargeUrl
        {
            get { return _chargeurl; }
            set { _chargeurl = value; }
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
    }
}
