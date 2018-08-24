using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb.Models
{
    public class ConsultVisitModel
    {
        ///</sumary>
        public string VisitId
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string VisitPersonName
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string IDCard
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string CardType
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public int PersonNum
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string Telephone
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime VisitDate
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime LeaveDate
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public string PatiId
        { get; set; }

        ///</sumary>
        public string PatiName
        { get; set; }

        ///</sumary>
        public string BuildName
        { get; set; }

        ///</sumary>
        public string BedName
        { get; set; }

        ///</sumary>
        public string RoomName
        { get; set; }


        public string Purpose { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string CreateUser
        { get; set; }
        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate
        { get; set; }
    }
}