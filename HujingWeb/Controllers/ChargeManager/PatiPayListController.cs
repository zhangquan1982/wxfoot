using HujingModel;
using IHujingLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.ChargeManager
{
    public class PatiPayListController : Controller
    {
        //
        // GET: /PatiPayList/
        public IPatiPayListLogic payLogic { get; set; }


        public IPackageTypeLogic packLogic { get; set; }

        public IOrganizationLogic orgLogic { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CancelIndex()
        {
            return View();
        }

        public ActionResult GetPersonPayListVM(string patiname, string dateBegin, string dateEnd, string userid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            string Condition = "";
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
                Condition = "1=2";
            }
            else
            {
                Condition = " and  pay.CreateUser='" + strUserId + "'";
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

        public ActionResult GetPersonPayListBySerialNum(string SerialNum, int? pageIndex, int? pageSize, string sortField, string sortOrder)
        {
            string Condition = "";
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
            if (string.IsNullOrEmpty(SerialNum))
            {
                Condition = " and 1=2";
            }
            else
            {
                Condition = " and vt.SerialNum='" + SerialNum + "'";
            }

            IList<PersonPayVoiceVM> payList = payLogic.GetPersonPayList(Condition, 1000, 1, sortField, sortOrder);
            int total = payLogic.GetPersonPayListCount(Condition);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", total);
            dic.Add("data", payList);
            return Json(dic);
        }

        public JsonResult CancelPayment(string payid,string CNote)
        {
            string userid = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            string orgid = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
            if(string.IsNullOrEmpty(payid))
            {
                return Json(false);
            }
            PatiPayListEntity paOld = payLogic.Load(payid);
            if (paOld == null)
            {
                return Json(false);
            }

            PatiPayListEntity newPay = payLogic.Load(payid);
            newPay.CancId = newPay.PayId;
            newPay.PayId = userid + "-PayId-" + DateTime.Now.ToString("yyMMddHHmmss");
            newPay.Direction = -1;
            newPay.CancReason = "";
            newPay.CancDate = DateTime.Now;
            newPay.CancUser = userid;


            paOld.CancDate = DateTime.Now;
            paOld.CancUser = userid;
            paOld.CancReason = CNote;
            paOld.CancId = newPay.PayId;

            //OldPersonInvisitEntity person = oldLogic.Load(paOld.SerialNum);
            //person.UpdateDate = DateTime.Now;
            //person.UpdateUser = userid;
            //person.PreAmount = person.PreAmount - paOld.PayAmount;

            //PatiIn_Pay_InvoiceEntity voice = voiceLogic.LoadByPayId(payid);
            //voice.CancDate = DateTime.Now;
            //voice.CancUser = userid;
            //voice.CancReason = CNote;

            //bool isOK = payLogic.CancelPayAndVoice(newPay,paOld,person,voice);
            return Json(true);
        }

        public ActionResult Add(string serialnum)
        {
            string userid = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
            OrganizationEntity orgentity = orgLogic.Load(strOrgId);
            string orgTitle = orgentity.OrgName + "（缴费）收据";
            //OldPersonVisitListCollect person = oldLogic.GetOldPersonVisitCollect(serialnum);
            //if (person != null)
            //{
            //    ViewBag.SerialNum = person.SerialNum;

            //    ViewBag.PatiID = person.PatiID;
            //    string sexname = person.SexName;
            //    ViewBag.PatiName = "[姓名]-" + person.PatiName + "---[性别]-" + sexname + "---[年龄]-" + person.Age;
            //    ViewBag.Address = person.Address;
            //    //Fin_Invoice_StoreEntity voiceEntity = finInvoice.Load("");
            //    ViewBag.InVoiceNo = userid + "-" + DateTime.Now.ToString("yyMMddHHmmss");
            //    ViewBag.orgTitle = strOrgId;
            //    ViewBag.UserId = userid;
            //    ViewBag.orgTitle = orgTitle;
            //    return View(ViewBag);
            //}
            //else
            //{
            //    Response.Write("错误，请联系管理员");
            //    Response.End();
            //}
            return View();
        }



        //public ActionResult GetPersonVisit(string SerialNum)
        //{
        //    OldPersonVisitListCollect person = oldLogic.GetOldPersonVisitCollect(SerialNum);
        //    if (person != null)
        //    {
        //        return Json(person);
        //    }
        //    else
        //    {
        //        return Json(false);
        //    }
        //}

    }
}
