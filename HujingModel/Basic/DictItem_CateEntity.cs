/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-8-28
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
    /// DictItem_Cate 
    /// </summary>
    [Serializable]
    public class DictItem_CateEntity
    {
        public DictItem_CateEntity()
        {

        }

        private string _cateid;
        private string _catename;
        private string _upperid;
        private string _inputstr;
        private string _catetype;
        private int _flag;
        private DateTime _createdate;
        private DateTime _updatedate;
        private string _createuser;
        private string _updateuser;


        ///<sumary>
        /// 
        ///</sumary>
        public string CateId
        {
            get { return _cateid; }
            set { _cateid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string CateName
        {
            get { return _catename; }
            set { _catename = value; }
        }

        public string CateType
        {
            get { return _catetype; }
            set { _catetype = value; }
        }


        ///<sumary>
        /// 
        ///</sumary>
        public string UpperId
        {
            get { return _upperid; }
            set { _upperid = value; }
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
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
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
