using HujingModel;
using IHujingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.ChargeManager
{
    public class OpeReceivePayController : Controller
    {

        public IPatiPayListLogic payLogic { get; set; }
        //
        // GET: /OpeReceivePay/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetPersonPayListVM(string patiname, string dateBegin, string dateEnd, string userid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            string strOrgId = HttpContext.ApplicationInstance.Request.Cookies["OrgId"].Value.ToString();
            string Condition = " and pay.orgid = '" + strOrgId + "'";
            pageIndex = pageIndex + 1;
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "pay.CreateDate";
                sortOrder = "desc";
            }
            else
            {
                if ((sortField == "SerialNum") || (sortField == "PatiName"))
                {
                    sortField = "vt." + sortField;
                }
                else if (sortField == "InvoiceId")
                {
                    sortField = "voice." + sortField;
                }
                else
                {
                    sortField = "pay." + sortField;
                }
            }
            if (string.IsNullOrEmpty(strUserId))
            {
                Condition += "1=2";
            }
            else
            {
                Condition += " and  pay.CreateUser='" + strUserId + "'";
            }
            if (!string.IsNullOrEmpty(patiname))
            {
                Condition = " and ( (vt.PatiName like '%" + patiname + "%') or (vt.serialnum like '%" + patiname + "%') ) ";
            }
            if (!string.IsNullOrEmpty(userid))
            {
                Condition += " and pay.CreateUser like '%" + userid + "%'";
            }
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and pay.CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and pay.CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }
            IList<PersonPayVoiceVM> payList = payLogic.GetPersonPayList(Condition, pageSize, pageIndex, sortField, sortOrder);
            int total = payLogic.GetPersonPayListCount(Condition);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", total);
            dic.Add("data", payList);
            return Json(dic);
        }

        public ActionResult GetPesonPayBySerialNum(string serialnum, string sortField, string sortOrder)
        {
            string Condition = "and vt.SerialNum='" + serialnum + "'";
            IList<PersonPayVoiceVM> payList = payLogic.GetPersonPayList(Condition, 100, 1, sortField, sortOrder);
            int total = payLogic.GetPersonPayListCount(Condition);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", payList.Count);
            dic.Add("data", payList);
            return Json(dic);
        }

    }
}
