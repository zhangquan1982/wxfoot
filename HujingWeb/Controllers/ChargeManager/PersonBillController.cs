//using HujingAccess.ChargeManager;
//using HujingModel;
//using IHujingLogic.ChargeManager;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace HujingWeb.Controllers.ChargeManager
//{
//    public class PersonBillController : Controller
//    {
//        public IPatiInBillItemLogic billItemLogic { get; set; }
//        public IPatiInBillLogic billLogic { get; set; }
//        //
//        // GET: /PatiBill/

//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult PersonIndex()
//        {
//            return View();
//        }

//        public ActionResult PreViewGrid(string serialnum)
//        {
//            if(string.IsNullOrEmpty(serialnum))
//            {
//                throw new Exception("没有找到老人入住编号！");
//            }
//            ViewBag.SerialNum = serialnum;
//            return View();
//        }

//        public ActionResult PesonBillView(string serialnum)
//        {
//            if(string.IsNullOrEmpty(serialnum))
//            {
//                throw new Exception("没有找到老人入住编号！");
//            }
//            ViewBag.SerialNum = serialnum;
//            return View();
//        }

        

//        public ContentResult GetPatiBillCollect(string SerialNum,string strBeginDate, string strEndDate, int pageIndex, int pageSize, string sortField, string sortOrder)
//        {
//            pageIndex = pageIndex + 1;

//            string Condition = "";
//            Condition = " and SerialNum = '" + SerialNum + "'";
//            if (!string.IsNullOrEmpty(strBeginDate))
//            {
//                Condition += " and s1.CreateDate >= '" + strBeginDate + "'";
//            }
//            if (!string.IsNullOrEmpty(strEndDate))
//            {
//                Condition += " and s1.CreateDate <= '" + strEndDate + "'";
//            }
//            if(sortField=="")
//            {
//                sortField = " s2.ItemId";
//            }
//            if(sortOrder == "")
//            {
//                sortOrder = "asc";
//            }
//            DataTable billList = billItemLogic.GetPersonPatiBillCollectCondition(Condition, pageSize, pageIndex, sortField, sortOrder);
//            int total = billList.Rows.Count;
//            string dePersonJson = JsonHelper.DataTable2Json(billList, total);
//            IDictionary<string, object> dic = new Dictionary<string, object>();
//            dic.Add("total", total);
//            dic.Add("data", dePersonJson);
//            string strJson = dePersonJson; // JsonHelper.RtnJsonNew(dePersonJson, total);
//            strJson = strJson.Replace("\\", "");
//            strJson = strJson.Replace(@"\", "");
//            return Content(strJson);
//        }

//        public ContentResult GetPatiBillList(string SerialNum,string strBeginDate, string strEndDate, string ItemId, int pageIndex, int pageSize)
//        {
//            pageIndex = pageIndex + 1;

//            string Condition = "";
//            Condition = " and SerialNum = '" + SerialNum + "'";
//            if (!string.IsNullOrEmpty(ItemId))
//            {
//                Condition += "and s2.ItemID='" + ItemId + "'";
//            }
//            if (!string.IsNullOrEmpty(strBeginDate))
//            {
//                Condition += " and s1.CreateDate >= '" + strBeginDate + "'";
//            }
//            if (!string.IsNullOrEmpty(strEndDate))
//            {
//                Condition += " and s1.CreateDate <= '" + strEndDate + "'";
//            }
//            DataTable billList = billItemLogic.GetPersonPatiBillCondition(Condition, pageSize, pageIndex);
//            int total = billItemLogic.GetPersonBillCount(Condition);
//            string dePersonJson = JsonHelper.DataTable2Json(billList, total);
//            IDictionary<string, object> dic = new Dictionary<string, object>();
//            dic.Add("total", total);
//            dic.Add("data", dePersonJson);
//            string strJson = dePersonJson; // JsonHelper.RtnJsonNew(dePersonJson, total);
//            strJson = strJson.Replace("\\", "");
//            strJson = strJson.Replace(@"\", "");
//            return Content(strJson);

//        }

//        public JsonResult SavePersonBill(PatiInBillEntity billHead,
//            IList<Pati_In_Order_ItemEntity> billItem)
//        {
//            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
//            string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
//            //IList<Pati_In_Order_ItemEntity> billItem

//            billHead.OrgId = strOrgId;
//            billHead.BillId = strUserId+"-"+DateTime.Now.ToString("yyMMddHHmmssfff");
//            billHead.BillUser = strUserId;
//            billHead.CreateDate= DateTime.Now;
//            billHead.CreateUser = strUserId;
            
//            IList<PatiInBillItemEntity> billItemss = new List<PatiInBillItemEntity>();
//            foreach (Pati_In_Order_ItemEntity item in billItem)
//            {
//                if(!string.IsNullOrEmpty(item.ItemID))
//                {
//                    PatiInBillItemEntity inItem = new PatiInBillItemEntity();
//                    inItem.BillItemId = System.Guid.NewGuid().ToString();
//                    inItem.BillId = billHead.BillId;
//                    inItem.ItemId = item.ItemID;
//                    inItem.Quantity = item.Quantity;
//                    inItem.Price = item.Price;
//                    inItem.TotalAmount = item.Price * item.Quantity;
//                    inItem.RcvAmount = inItem.TotalAmount;
//                    inItem.UnitName = item.UnitName;
//                    inItem.CreateDate = DateTime.Now;
//                    inItem.CreateUser = strUserId;
//                    inItem.OrdId = strOrgId;
//                    billItemss.Add(inItem);
           

                    
//                }
//            }
//            if (billItemss.Count>0)
//            {
//                bool isOk  =billLogic.SaveBillHeadAndItem(billHead, billItemss);
//                return Json(isOk);
//            }
//            else
//            {
//                return Json(false);
//            }
//        }


//    }
//}
