/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/4/22 星期五
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
    /// PatiInBill 
    /// </summary>
    [Serializable]
    public class PatiInBillEntity
    {
        public PatiInBillEntity()
        {

        }

        private string _billid;
        private string _serialnum;
        private string _deporg;
        private string _deploc;
        private string _billuser;
        private string _settleid;
        private string _settledate;
        private DateTime _createdate;
        private string _createuser;

        private string _orgid;

        public string OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string BillId
        {
            get { return _billid; }
            set { _billid = value; }
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
        public string DepOrg
        {
            get { return _deporg; }
            set { _deporg = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string DepLoc
        {
            get { return _deploc; }
            set { _deploc = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string BillUser
        {
            get { return _billuser; }
            set { _billuser = value; }
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
        public string SettleDate
        {
            get { return _settledate; }
            set { _settledate = value; }
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
    }
}
