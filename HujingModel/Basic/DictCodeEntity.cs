/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-8-23
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
    /// DictCode 
    /// </summary>
    [Serializable]
    public class DictCodeEntity
    {
        public DictCodeEntity()
        {

        }

        private string _codetypeid;
        private string _codetypename;
        private string _codeid;
        private string _codename;
        private string _memo;
        private DateTime _createdate;
        private string _createuser;
        private bool _flag;
        private string _orgid;

        ///<sumary>
        /// 
        ///</sumary>
        public string CodeTypeId
        {
            get { return _codetypeid; }
            set { _codetypeid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CodeTypeName
        {
            get { return _codetypename; }
            set { _codetypename = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CodeId
        {
            get { return _codeid; }
            set { _codeid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CodeName
        {
            get { return _codename; }
            set { _codename = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
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
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public string OrgId
        {
            get { return _orgid; }
            set { _orgid = value; }
        }
    }
}
