using HujingModel;
using IHujingLogic;
using IHujingLogic.ChargeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.ChargeManager
{
    public class PatiSettleController : Controller
    {
        //public IPati_In_SettleListLogic patiSettle { get; set; }
        //public IOldPersonInvisitLogic oldpersonVisitLogic { get; set; }
        //public CommonController commControol { get; set; }
        public IPackageTypeLogic packTypeLogic { get; set; }
        //
        // GET: /PatiSettle/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LessIndex()
        {
            return View();
        }


        public ActionResult GetInPatiPersonStatus(string input, string status)
        {
            string Condition = "";
            if (!string.IsNullOrEmpty(input))
            {
                Condition = " and ( (PatiName like '%" + input + "%') or (serialnum like '%" + input + "%') ) ";
            }
            Condition += " and Status='" + status + "'";
            //IList<OldPersonVisitListCollect> personVisit = oldpersonVisitLogic.GetOldPersonVisitCollectList(Condition, 10, 1, "AdmitDate", "desc");
            //if ((personVisit != null) && (personVisit.Count > 0))
            //{
            //    for (int irow = 0; irow < personVisit.Count; irow++)
            //    {
            //    }
            //}
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}
