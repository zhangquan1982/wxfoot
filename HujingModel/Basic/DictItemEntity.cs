/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-8-30
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
    /// DictItem 
    /// </summary>
    [Serializable]
    public class DictItemEntity
    {
        public DictItemEntity()
        {

        }

        private string _itemid;
        private string _itemname;
        private string _cateid;
        private string _catetype;
        private string _itemdes;
        private string _inputstr;
        private bool _stopflag;
        private System.Decimal _salesprice;
        private string _itemspec;
        private string _unitname;
        private string _unittypeid;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;

        ///<sumary>
        /// 
        ///</sumary>
        public string ItemID
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
        public string CateID
        {
            get { return _cateid; }
            set { _cateid = value; }
        }

        public string CateType
        {
            get { return _catetype; }
            set { _catetype = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string ItemDes
        {
            get { return _itemdes; }
            set { _itemdes = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string InputStr
        {
            get { return _inputstr; }
            set { _inputstr = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public bool StopFlag
        {
            get { return _stopflag; }
            set { _stopflag = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal SalesPrice
        {
            get { return _salesprice; }
            set { _salesprice = value; }
        }



        ///<sumary>
        /// 
        ///</sumary>
        public string ItemSpec
        {
            get { return _itemspec; }
            set { _itemspec = value; }
        }

        ///<sumary>
        /// 
        ///</sumary>
        public string UnitName
        {
            get { return _unitname; }
            set { _unitname = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string UnitTypeId
        {
            get { return _unittypeid; }
            set { _unittypeid = value; }
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
