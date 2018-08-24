/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015-11-7
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
    /// OrgCard 
    /// </summary>
    [Serializable]
    public class OrgCardEntity
    {
        public OrgCardEntity()
        {

        }

        private string _orgid;
        private string _orgidu;
        private string _orgidp;

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
        public string OrgIdU
        {
            get { return _orgidu; }
            set { _orgidu = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrgIdP
        {
            get { return _orgidp; }
            set { _orgidp = value; }
        }
    }
}
