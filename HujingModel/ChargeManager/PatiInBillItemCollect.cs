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
    /// PatiInBillItem 
    /// </summary>
    [Serializable]
    public class PatiInBillItemCollectEntity
    {
        public PatiInBillItemCollectEntity()
        {

        }
        private string _itemid;
        private string _itemname;
        private decimal _quantity;
        private System.Decimal _price;
        private System.Decimal _totalamount;
        private System.Decimal _rcvamount;
        private string _depexec;
        private string _deploc;

        ///<sumary>
        /// 
        ///</sumary>
        public string ItemId
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal TotalAmount
        {
            get { return _totalamount; }
            set { _totalamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal RcvAmount
        {
            get { return _rcvamount; }
            set { _rcvamount = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string DepExec
        {
            get { return _depexec; }
            set { _depexec = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string DepLoc
        {
            get { return _deploc; }
            set { _deploc = value; }
        }
    }
}
