using HujingAccess.ChargeManager;
using HujingModel;
using HujingModel.ViewModel;
using IHujingLogic;
using IHujingLogic.SysFrame;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers
{
    public class UserOrderController : Controller
    {
        public IUserInfoLogic userLogic { get; set; }

        public IOrderDinnerLogic dinnerlogic { get; set; }

        public IUserCardLogic usercardLogic { get; set; }

        public IRefundsApplyLogic refundLogic { get; set; }

        public IPatiInBillItemLogic billitemLogic { get; set; }

        public ISatisfactionLogic Satislogic { get; set; }


        //
        // GET: /UserOrder/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult setOrder(string userid, DateTime orderDate, int orderNumber, string footTime)
        {
            try
            {
                JsonResult result = new JsonResult();
                UserInfoEntity user = userLogic.Load(userid);
                Random rad = new Random();
                if (user != null)
                {
                    string Condition = " and userid='" + userid + "'  and orderdate between '" + orderDate.ToString("yyyy-MM-dd 00:00:00") + "'  and  '" + orderDate.ToString("yyyy-MM-dd 23:59:59") + "' and typecode=" + footTime;
                    int rowCount = dinnerlogic.Count(Condition);
                    if (rowCount > 0)
                    {
                        result.Data = new { status = 200, msg = "此期间，订餐您已经预定!" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }


                    OrderDinnerEntity ordDinner = new OrderDinnerEntity();
                    ordDinner.OrdId = userid + "-" + DateTime.Now.ToString("yyMMddHHmmss") + rad.Next(10, 99);
                    ordDinner.OrdName = userid + "-预定餐饮";
                    ordDinner.UserId = userid;
                    ordDinner.OrderDate = orderDate;
                    ordDinner.TypeCode = footTime;
                    ordDinner.Quantity = orderNumber;
                    ordDinner.OrdStatus = "0";
                    ordDinner.CreateUser = userid;
                    ordDinner.CreateDate = DateTime.Now;
                    bool isok = dinnerlogic.Save(ordDinner);
                    if (isok)
                    {
                        result.Data = new { status = 100, msg = "success" };
                    }
                    else
                    {
                        result.Data = new { status = 200, msg = "订餐失败" };
                    }
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.Data = new { status = 200, msg = "用户不存在", userid = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message, userid = "" };
                return Json(result, JsonRequestBehavior.AllowGet);

            }
        }


        public ActionResult cancelOrderByIds(string[] cancelOrderIds)
        {
            try
            {
                JsonResult result = new JsonResult();
                if (cancelOrderIds.Length == 0)
                {
                    result.Data = new { status = 200, msg = "没有需要取消的点餐数据！", orders = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                foreach (var item in cancelOrderIds)
                {
                    if (item != "")
                    {
                        OrderDinnerEntity dinner = dinnerlogic.Load(item);
                        DateTime orderTimeEnd = DateTime.Parse(dinner.OrderDate.ToString("yyyy-MM-dd 23:59:59"));
                        if (DateTime.Now.CompareTo(orderTimeEnd) > 0)
                        {
                            result.Data = new { status = 200, msg = "此预定不允许取消,只能当天取消！", orders = "" };
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                bool isok = dinnerlogic.CancelOrderDinner(cancelOrderIds);
                if (isok)
                {
                    result.Data = new { status = 100, msg = "success", orders = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.Data = new { status = 200, msg = "取消失败！", orders = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message, orders = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult getOrdersByUser(string userid)
        {
            JsonResult result = new JsonResult();
            UserInfoEntity user = userLogic.Load(userid);
            Random rad = new Random();
            if (user != null)
            {
                IList<UserOrders> orderslst = new List<UserOrders>();
                IList<OrderDinnerEntity> dinners = dinnerlogic.LoadAll(" and OrderDate>='" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "'  and (CancUser is null or CancUser='')  and UserId = '" + userid + "'", 99, 1, "OrderDate desc");
                foreach (var item in dinners)
                {
                    UserOrders itemModel = new UserOrders();
                    itemModel.orderDate = item.OrderDate;
                    itemModel.orderId = item.OrdId;
                    if (item.TypeCode == "01")
                    {
                        itemModel.type = "早餐";
                    }
                    else if (item.TypeCode == "02")
                    {
                        itemModel.type = "午餐";
                    }
                    else if (item.TypeCode == "03")
                    {
                        itemModel.type = "晚餐";
                    }
                    itemModel.count = item.Quantity;

                    orderslst.Add(itemModel);
                }

                result.Data = new { status = 100, msg = "success", orders = orderslst };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result.Data = new { status = 200, msg = "用户不存在", orders = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult getRemainSum(string userid)
        {
            JsonResult result = new JsonResult();
            UserInfoEntity user = userLogic.Load(userid);
            if (user == null)
            {
                result.Data = new { status = 200, msg = "用户不存在" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            UserCardEntity cardEnty = usercardLogic.Load(user.CardId);
            if (cardEnty == null)
            {
                result.Data = new { status = 200, msg = "用户卡号不存在" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            decimal leaveAmount = cardEnty.PreAmount - cardEnty.FeeAmount;
            result.Data = new { status = 100, msg = "success", remainSum = leaveAmount };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult submitReturnsFee(string userid, decimal returnsFee, string remark)
        {
            JsonResult result = new JsonResult();
            try
            {
                UserInfoEntity user = userLogic.Load(userid);
                if (user == null)
                {
                    result.Data = new { status = 200, msg = "用户不存在" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                RefundsApplyEntity apply = new RefundsApplyEntity();
                apply.ApplyId = userid + DateTime.Now.ToString("yyMMddHHmmssfff");
                apply.UserId = userid;
                apply.ApplyDate = DateTime.Now;
                apply.Amount = returnsFee;
                apply.Reason = remark;
                apply.IsBack = "0";
                bool isok = refundLogic.Save(apply);
                if (isok)
                {
                    result.Data = new { status = 100, msg = "success" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.Data = new { status = 200, msg = "failt" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult getAbnormalInfo(string userid)
        {
            JsonResult result = new JsonResult();
            try
            {
                IList<PatiInBillItemEntity> billList = billitemLogic.LoadAll(" and IsUnusual='1' and userid='" + userid + "'", 999, 1, "CreateDate desc");
                IList<BillItemModel> modelItem = new List<BillItemModel>();
                foreach (PatiInBillItemEntity item in billList)
                {
                    BillItemModel itembill = new BillItemModel();
                    itembill.fee = item.Amount;
                    itembill.remark = item.UnusualMemo;
                    itembill.date = item.CreateDate;
                    if (item.TypeCode == "01")
                    {
                        itembill.time = "早餐";
                    }
                    else if (item.TypeCode == "02")
                    {
                        itembill.time = "午餐";
                    }
                    else if (item.TypeCode == "03")
                    {
                        itembill.time = "晚餐";
                    }
                    modelItem.Add(itembill);
                }
                result.Data = new { status = 100, msg = "success", abnormalInfo = modelItem };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult getOrderHisByDate(string userid, DateTime orderDate)
        {
            JsonResult result = new JsonResult();
            try
            {
                string Condition = "and IsUnusual='0' and userid='" + userid + "'";
                Condition += " and CreateDate between '" + orderDate.ToString("yyyy-MM-dd 00:00:00") + "' and '" + orderDate.ToString("yyyy-MM-dd 23:59:59") + "' ";

                IList<PatiInBillItemEntity> billList = billitemLogic.LoadAll(Condition, 999, 1, "CreateDate desc");
                IList<BillItemModel> modelItem = new List<BillItemModel>();
                foreach (PatiInBillItemEntity item in billList)
                {
                    BillItemModel itembill = new BillItemModel();
                    itembill.fee = item.Amount;
                    itembill.remark = item.UnusualMemo;
                    itembill.date = item.CreateDate;
                    if (item.TypeCode == "01")
                    {
                        itembill.time = "早餐";
                    }
                    else if (item.TypeCode == "02")
                    {
                        itembill.time = "午餐";
                    }
                    else if (item.TypeCode == "03")
                    {
                        itembill.time = "晚餐";
                    }
                    itembill.orderNumber = 1;
                    modelItem.Add(itembill);
                }
                result.Data = new { status = 100, msg = "success", ordersHis = modelItem };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// 获取已消费的订单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ActionResult getOrdersBySurvey(string userid)
        {
            JsonResult result = new JsonResult();
            try
            {
                string Condition = " and UserId='" + userid + "' and (CancUser is null or CancUser = '')";


                Condition += " and OrderDinner.OrderDate <= '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 23:59:59") + "'";

                IList<OrdersBySurvey> orderTotal = new List<OrdersBySurvey>();
                IList<OrderDinnerEntity> dataDinner = dinnerlogic.LoadAll(Condition, 888888, 1, "");
                int rowIndex = 1;
                if (dataDinner.Count > 0)
                {
                    foreach (OrderDinnerEntity row in dataDinner)
                    {
                        rowIndex += 1;
                        string typeCode = row.TypeCode;
                        string strBeg = row.OrderDate.ToString("yyyy-MM-dd 00:00:00.000");
                        string strEnd = row.OrderDate.ToString("yyyy-MM-dd 23:59:59");

                        string strCondition = " and IsUnusual='0' and UserId='" + userid + "' and TypeCode='" + typeCode + "'  and  CreateDate between   '" + strBeg + "'  and  '" + strEnd + "'";
                        //string strSql = @"  select * from  PatiInBillItem  where ";
                        int rowount = billitemLogic.Count(strCondition);
                        if (rowount == 0)
                        {
                            continue;
                        }

                        int radCount = Satislogic.Count(" and OrderId='" + row.OrdId + "'");
                        if (radCount > 0)
                        {
                            continue;
                        }

                        OrdersBySurvey orderInfo = new OrdersBySurvey();
                        orderInfo.orderid = row.OrdId;
                        orderInfo.date = row.OrderDate;
                        if (row.TypeCode == "01")
                        {
                            orderInfo.food = "早餐";
                        }
                        else if (row.TypeCode == "02")
                        {
                            orderInfo.food = "午餐";
                        }
                        else if (row.TypeCode == "03")
                        {
                            orderInfo.food = "晚餐";
                        }
                        orderInfo.orderNumber = row.Quantity;
                        orderTotal.Add(orderInfo);
                    }
                }
                result.Data = new { status = 100, msg = "success", orders = orderTotal };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(true);
        }


        public ActionResult setOrderBySurvey(string orderid, string survey)
        {

            JsonResult result = new JsonResult();
            OrderDinnerEntity orderEnty = dinnerlogic.Load(orderid);
            if (orderEnty != null)
            {
                SatisfactionEntity model = new SatisfactionEntity();
                model.SatisId = orderid + "-" + DateTime.Now.ToString("yyMMddHHmmss");
                model.OrderId = orderid;
                model.SatisResult = survey;
                model.CreateDate = DateTime.Now;
                bool isok = Satislogic.Save(model);
                result.Data = new { status = 100, msg = "成功！" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result.Data = new { status = 200, msg = "此订单不存在！" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //return Json(result, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public async Task<ActionResult> setBatchOrder(string userid, DateTime startDate, DateTime endDate, int orderNumber, string footTime)
        {
            //aaddds

            try
            {
                JsonResult result = new JsonResult();
                UserInfoEntity user = userLogic.Load(userid);
                Random rad = new Random();
                if (user != null)
                {
                    if ((startDate.CompareTo(DateTime.Now) < 0) || (endDate.CompareTo(DateTime.Now) < 0))
                    {
                        result.Data = new { status = 200, msg = "开始日期或结束日期不能早于或者等于当前日期" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }

                    string Condition = " and userid='"+ userid + "'  and orderdate between '" + startDate.ToString("yyyy-MM-dd 00:00:00") + "'  and  '" + endDate.ToString("yyyy-MM-dd 23:59:59") + "' and typecode="+ footTime;
                    int rowCount =  dinnerlogic.Count(Condition);
                    if(rowCount>0)
                    {
                        result.Data = new { status = 200, msg = "此期间，您已经预定!" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    TimeSpan tsCha = endDate - startDate;
                    int daysCha = tsCha.Days; // 相差几天
                    IList<OrderDinnerEntity> dinnerList = new List<OrderDinnerEntity>();
                    for (int row = 0; row <= daysCha; row++)
                    {
                        DateTime dtOrderDate = startDate.AddDays(row);
                        OrderDinnerEntity ordDinner = new OrderDinnerEntity();
                        ordDinner.OrdId = userid + "-" + DateTime.Now.ToString("yyMMddHHmmss") + rad.Next(10, 99);
                        ordDinner.OrdName = userid + "-预定餐饮";
                        ordDinner.UserId = userid;
                        ordDinner.OrderDate = dtOrderDate;
                        ordDinner.TypeCode = footTime;
                        ordDinner.Quantity = orderNumber;
                        ordDinner.OrdStatus = "0";
                        ordDinner.CreateUser = userid;
                        ordDinner.CreateDate = DateTime.Now;
                        dinnerList.Add(ordDinner);
                    }

                    var taskResult = await Task.FromResult(dinnerlogic.setBatchOrder(dinnerList));
                    Task<bool> isok = taskResult;
                    if (isok.Result==true)
                    {
                        result.Data = new { status = 100, msg = "success" };
                    }
                    else
                    {
                        result.Data = new { status = 200, msg = "订餐失败" };
                    }
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.Data = new { status = 200, msg = "用户不存在" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message, userid = "" };
                return Json(result, JsonRequestBehavior.AllowGet);

            }
        }

    }
}
