using HujingAccess.ChargeManager;
using HujingModel;
using IHujingLogic.ChargeManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.ChargeManager
{
     

    public class PatiBillBackController : Controller
    {

        public IPatiInBillItemLogic billItemLogic { get; set; }
        public IPatiInBillLogic billLogic { get; set; }
        //
        // GET: /PatiBillBack/

        public ActionResult Index()
        {
            return View();
        }


        public ContentResult GetPatiBillBackList(string SerialNum, string ItemId, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex + 1;

            string Condition = "";
            Condition = " and SerialNum = '" + SerialNum + "'";
            if (!string.IsNullOrEmpty(ItemId))
            {
                Condition += "and s2.ItemID='" + ItemId + "'";
            }
            DataTable billList = billItemLogic.GetPersonPatiBackBillCondition(Condition, pageSize, pageIndex);
            //DataColumn column = new DataColumn();
            //column.Caption = "退数量";
            //column.ColumnName = "BackQuantity";
            //column.DataType = System.Type.GetType("System.Decimal");
            //column.DefaultValue = 0;
            //billList.Columns.Add(column);
            // billList.Columns.Add() 
            int total = billList.Rows.Count;
            string dePersonJson = JsonHelper.DataTable2Json(billList, total);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", total);
            dic.Add("data", dePersonJson);
            string strJson = dePersonJson; // JsonHelper.RtnJsonNew(dePersonJson, total);
            strJson = strJson.Replace("\\", "");
            strJson = strJson.Replace(@"\", "");
            return Content(strJson);

        }

        public ActionResult SavePatiBackBill(string SerialNum, IList<PatiInBillItemEntity> billItem)
        {
            if(string.IsNullOrEmpty(SerialNum))
            {
                return Json(false);
            }
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
            PatiInBillEntity billhead = new PatiInBillEntity();

            //IList<Pati_In_Order_ItemEntity> billItem
            billhead.BillId = strUserId + "-" + "BillHead"+ DateTime.Now.ToString("yyMMddHHmmssfff");
            billhead.BillUser = strUserId;
            billhead.CreateDate = DateTime.Now;
            billhead.CreateUser = strUserId;
            billhead.SerialNum = SerialNum;
            billhead.OrgId = strOrgId;

            IList<PatiInBillItemEntity> billItemss = new List<PatiInBillItemEntity>();
            foreach (PatiInBillItemEntity item in billItem)
            {
                //if (!string.IsNullOrEmpty(item.ItemId))
                //{
                //    PatiInBillItemEntity inItem = new PatiInBillItemEntity();
                //    inItem.BillItemId = System.Guid.NewGuid().ToString();
                //    inItem.BillId = billhead.BillId;
                //    inItem.ItemId = item.ItemId;
                //    inItem.Quantity = -item.Quantity;
                //    inItem.Price = item.Price;
                //    inItem.TotalAmount = item.Price * inItem.Quantity;
                //    inItem.RcvAmount = inItem.TotalAmount;
                //    inItem.UnitName = item.UnitName;
                //    inItem.OrdId = strOrgId;
                //    billItemss.Add(inItem);

                //}
            }
            if (billItemss.Count > 0)
            {
                bool isOk = billLogic.SaveBillHeadAndItem(billhead, billItemss);
                return Json(isOk);
            }
            else
            {
                return Json(false);
            }
            return Json(false);
        }

    }
}
