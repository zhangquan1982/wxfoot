using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingModel
{
    public class vmBed
    {
        public string RoomId { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string BedId { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string BedName { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public bool IsAdd { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string Status { get; set; }


        ///<sumary>
        /// 
        ///</sumary>
        public DateTime CreateDate { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public DateTime UpdateDate { get; set; }

        ///<sumary>
        /// 
        ///</sumary>
        public string CreateUser { get; set; }


        ///<sumary>
        /// 
        ///</sumary>
        public string UpdateUser { get; set; }


        public string SerialNum { get; set; }

        public string PatiName { get; set; }
    }
}
