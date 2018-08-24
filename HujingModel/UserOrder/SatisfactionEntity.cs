/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2018-08-02
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
    /// Satisfaction 
    /// </summary>
    [Serializable]
    public class SatisfactionEntity
    {
        public SatisfactionEntity()
        {

        }

        private string _satisid;
        private string _orderid;
        private string _satisresult;
        private DateTime _createdate;

        ///<sumary>
        /// 
        ///</sumary>
        public string SatisId
        {
            get { return _satisid; }
            set { _satisid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrderId
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string SatisResult
        {
            get { return _satisresult; }
            set { _satisresult = value; }
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
    }
}
