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
    /// RefundsApply 
    /// </summary>
    [Serializable]
    public class RefundsApplyEntity
    {
        public RefundsApplyEntity()
        {

        }

        private string _applyid;
        private string _userid;
        private System.Decimal _amount;
        private string _reason;
        private DateTime _applydate;
        private string _isback;
        private string _payid;

        ///<sumary>
        /// 
        ///</sumary>
        public string ApplyId
        {
            get { return _applyid; }
            set { _applyid = value; }
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
        public System.Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime ApplyDate
        {
            get { return _applydate; }
            set { _applydate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string IsBack
        {
            get { return _isback; }
            set { _isback = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string PayId
        {
            get { return _payid; }
            set { _payid = value; }
        }
    }
}
