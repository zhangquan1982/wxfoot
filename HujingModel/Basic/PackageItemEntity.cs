/***************************************************************************
 * 
 *       功能：     实体类
 *       作者：     jy
 *       日期：     2015/12/23 星期三
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
    /// PackageItem 
    /// </summary>
    [Serializable]
    public class PackageItemEntity
    {

        ///<sumary>
        /// 
        ///</sumary>
        public string PackItemId
        { get; set; }


        ///<sumary>
        /// 
        ///</sumary>
        public string PackTypeId
        { get; set; }


        ///<sumary>
        /// 
        ///</sumary>
        public string PackTypeName
        { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string ItemID
        { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string ItemName
        { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public bool Flag
        { get; set; }

        public string UnitTypeId
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string UnitName
        { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public decimal SalesPrice { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public int Quantity { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public decimal SalesAmount { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string CreateUser{ get; set; }

        public string _state { get; set; }

        public string OrgId { get; set; }

    }
}
