/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016-09-21
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
    /// BedSidyApply 
    /// </summary>
    [Serializable]
    public class BedSidyApplyEntity
    {
        public BedSidyApplyEntity()
        {

        }

        private string _applyid;
        private string _orgid;
        private string _orgname;
        private int _year;
        private int _roomnum;
        private int _bednum;
        private System.Decimal _bedrate;
        private string _applycontent;
        private DateTime _createdate;
        private string _createuser;
        private DateTime? _updatedate;
        private string _updateuser;

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
        public string OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrgName
        {
            get { return _orgname; }
            set { _orgname = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int RoomNum
        {
            get { return _roomnum; }
            set { _roomnum = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public int BedNum
        {
            get { return _bednum; }
            set { _bednum = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal BedRate
        {
            get { return _bedrate; }
            set { _bedrate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ApplyContent
        {
            get { return _applycontent; }
            set { _applycontent = value; }
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
