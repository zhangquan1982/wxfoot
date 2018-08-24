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
    /// Pati_In_Settle_Detail 
    /// </summary>
    [Serializable]
    public class Pati_In_Settle_DetailEntity
    {
        public Pati_In_Settle_DetailEntity()
        {

        }

        private string _settleid;
        private string _itemid;
        private string _itemname;
        private System.Decimal _quantity;
        private System.Decimal _price;
        private System.Decimal _totalamount;
        private DateTime _createdate;
        private string _createuser;

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
        public System.Decimal Quantity
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
