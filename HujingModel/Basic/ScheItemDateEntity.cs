/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2016/4/30 星期六
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
    /// ScheItemDate 
    /// </summary>
    [Serializable]
    public class ScheItemDateEntity
    {
        public ScheItemDateEntity()
        {

        }

        private string _schid;
        private string _itemid;
        private DateTime _schedate;
        private string _schetype;
        public string _typecode;
        private DateTime _createdate;
        private string _createuser;

        ///<sumary>
        /// 
        ///</sumary>
        public string SchId
        {
            get { return _schid; }
            set { _schid = value; }
        }
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
        public DateTime ScheDate
        {
            get { return _schedate; }
            set { _schedate = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string ScheType
        {
            get { return _schetype; }
            set { _schetype = value; }
        }

        public string TypeCode
        {
            get { return _typecode; }
            set { _typecode = value; }
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
