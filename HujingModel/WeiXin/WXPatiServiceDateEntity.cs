/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/5/16 星期一
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
    /// WXPatiServiceDate 
    /// </summary>
    [Serializable]
    public class WXPatiServiceDateEntity
    {
        public WXPatiServiceDateEntity()
        {

        }

        private string _patiid;
        private DateTime _begindate;
        private DateTime _enddate;
        private DateTime _createdate;
        private DateTime? _updatedate;

        ///<sumary>
        /// 
        ///</sumary>
        public string PatiID
        {
            get { return _patiid; }
            set { _patiid = value; }
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
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime? UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
        }
    }
}
