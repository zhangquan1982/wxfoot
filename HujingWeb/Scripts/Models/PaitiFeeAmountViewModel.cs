using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HujingWeb.Models
{
    public class PaitiFeeAmountViewModel
    {
        public int? Patiid { get; set; }
        public string PatiName { get; set; }
        public decimal? FeeAmount { get; set; }
        public DateTime FeeDate { get; set; }
        public int? Age { get; set; }
        public string PatiType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}