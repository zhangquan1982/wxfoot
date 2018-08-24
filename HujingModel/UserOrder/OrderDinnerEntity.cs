/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2018-07-02
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
    /// OrderDinner 
    /// </summary>
    [Serializable]
    public class OrderDinnerEntity
    {
        public OrderDinnerEntity()
        {

        }

        private string _ordid;
        private string _ordname;
        private string _userid;
        private DateTime _orderdate;
        private string _typecode;
        private int _quantity;
        private string _cancuser;
        private string _cancreason;
        private string _createuser;
        private DateTime _createdate;
        private string _ordstatus;
        private DateTime? _cancdate;

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
        public string OrdName
        {
            get { return _ordname; }
            set { _ordname = value; }
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
        public DateTime OrderDate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string TypeCode
        {
            get { return _typecode; }
            set { _typecode = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
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
        public string OrdStatus
        {
            get { return _ordstatus; }
            set { _ordstatus = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime? CancDate
        {
            get { return _cancdate; }
            set { _cancdate = value; }
        }
    }
}
