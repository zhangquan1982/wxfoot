using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb.Model.OrgApply
{
    public class BedSidyApplyModel
    {

        ///<sumary>
        /// 
        ///</sumary>
        public string ApplyId { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string OrgId { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string OrgName { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public int Year { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public int RoomNum { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public int BedNum { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal BedRate { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string ApplyContent { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string CreateUser { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public DateTime UpdateDate { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string UpdateUser { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string OrgType { get; set; }

        public string RelationPeople { get; set; }

        public string SetupTime { get; set; }

        public float Area { get; set; }

        public string TelPhone { get; set; }

        public int Mobile { get; set; }

        public string Address { get; set; }
    }
}