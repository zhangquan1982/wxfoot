/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-10-10
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
    /// PatiCard 
    /// </summary>
    [Serializable]
    public class UserCardEntity
    {
        public UserCardEntity()
        {

        }

        private string _userid;
        private string _cardid;
        private string _flag;
        private string _note;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;
        private decimal _preamount;
        private decimal _feeamount;

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
        public string Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
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


        public decimal PreAmount
        {
            get { return _preamount; }
            set { _preamount = value; }
        }
        public decimal FeeAmount
        {
            get { return _feeamount; }
            set { _feeamount = value; }
        }

    }
}
