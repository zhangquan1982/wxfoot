/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2018-07-03
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
    /// PatiInBillItem 
    /// </summary>
    [Serializable]
    public class PatiInBillItemEntity
    {
        public PatiInBillItemEntity()
        {

        }

        private string _billitemid;
        private string _userid;
        private string _ordid;
        private System.Decimal _amount;
        private string _isunusual;
        private string _unusualmemo;
        private DateTime _createdate;
        private string _typecode;
        private string _createuser;

        public string UserName { get; set; }

        public string SexName { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string BillItemId
        {
            get { return _billitemid; }
            set { _billitemid = value; }
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
        public string OrdId
        {
            get { return _ordid; }
            set { _ordid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string IsUnusual
        {
            get { return _isunusual; }
            set { _isunusual = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string UnusualMemo
        {
            get { return _unusualmemo; }
            set { _unusualmemo = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        public string TypeCode
        {
            get { return _typecode; }
            set { _typecode = value; }
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
