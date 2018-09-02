using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb.Model.OrgApply
{
    public class RefundsApplyVM
    {

        ///<sumary>
        /// 
        ///</sumary>
        public string ApplyId
        {
            get;
            set;
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string UserId
        {
            get;
            set;
        }
        ///<sumary>
        /// 
        ///</sumary>
        public System.Decimal Amount
        {
            get;
            set;
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string Reason
        {
            get;
            set;
        }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime ApplyDate
        {
            get;
            set;
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string IsBack
        {
            get;
            set;
        }
        ///<sumary>
        /// 
        ///</sumary>
        public string PayId
        {
            get;
            set;
        }



        public string BackUserId
        {
            get;
            set;
        }

        public DateTime? BackDate
        {
            get;
            set;
        }


        public string UserName
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }
    }
}