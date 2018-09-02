using HujingAccess.ChargeManager;
using HujingModel;
using HujingModel.SysFrame;
using HujingModel.ViewModel;
using HujingWeb.Filter;
using HujingWeb.Model.OrgApply;
using IHujingLogic;
using IHujingLogic.SysFrame;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers
{

    /// <summary>
    /// 卡管理.
    /// </summary>
    public class UserCardChagerController : Controller
    {
        public IPatiPayListLogic payLogic { get; set; }

        public IUserInfoLogic userLogic { get; set; }

        public IUserCardLogic usercardLogic { get; set; }

        public IPatiInBillItemLogic billitemLogic { get; set; }


        public IUserCardLogic cardlogic { get; set; }

        public IOrderDinnerLogic dinnerlogic { get; set; }


        public IRefundsApplyLogic resundApply { get; set; }


        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add(string UserId)
        {
            string CreateUser = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

            UserInfoEntity user = userLogic.Load(UserId);
            if (user != null)
            {
                ViewBag.CardId = user.CardId;
                string sexname = (user.Sex == "0" ? "男" : "女").ToString();
                ViewBag.UserName = user.UserName;
                return View(user);
            }
            else
            {
                Response.Write("错误，请联系管理员");
                Response.End();
            }
            return View();
        }

        public ActionResult CancelIndex()
        {
            return View();
        }

        public ActionResult GetUserPayListByUserId(string UserId)
        {
            string Condition = "";
            if (string.IsNullOrEmpty(UserId))
            {
                Condition = " and 1=2";
            }
            else
            {
                Condition = " and UserId='" + UserId + "'";
            }
            IList<PatiPayListEntity> payList = payLogic.LoadAll(Condition, 1000, 1, "");
            int total = payLogic.Count(Condition);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", total);
            dic.Add("data", payList);
            return Json(dic);
        }


        public ActionResult GetUserSelect(string input)
        {
            string Condition = " and 1=1";
            if (!string.IsNullOrEmpty(input))
            {
                Condition += " and ( (UserName like '%" + input + "%') or ( UserId like  '%" + input + "%')) ";
            }
            else
            {
                Condition += "and 1=2";
            }

            IList<UserInfoEntity> userList = userLogic.LoadAll(Condition, 10, 1, "CreateDate", "desc");
            IList<UserAndCardEntity> usercardList = new List<UserAndCardEntity>();
            foreach (UserInfoEntity item in userList)
            {
                UserCardEntity card = usercardLogic.Load(item.CardId);
                UserAndCardEntity uscardentity = new UserAndCardEntity();
                uscardentity.UserName = item.UserName;
                uscardentity.UserId = item.UserId;
                uscardentity.CardId = item.CardId;
                uscardentity.PreAmount = card.PreAmount;
                uscardentity.FeeAmount = card.FeeAmount;
                uscardentity.AgeName = (DateTime.Now.Year - item.BirthDate.Year).ToString();
                uscardentity.SexName = (item.Sex == "0" ? "男" : "女");
                usercardList.Add(uscardentity);
            }
            return Json(usercardList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SavePatiPayList(PatiPayListEntity payInfo)
        {
            string CreateUser = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            payInfo.PayId = CreateUser + DateTime.Now.ToString("yyMMddHHmmssff");
            payInfo.Direction = 1;
            payInfo.CreateDate = DateTime.Now;
            payInfo.CreateUser = CreateUser;

            UserCardEntity cardEnty = usercardLogic.Load(payInfo.CardId);
            cardEnty.PreAmount = cardEnty.PreAmount + payInfo.PayAmount;
            bool isok = payLogic.SavePayList(payInfo, cardEnty);
            return Json(isok, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SavePatiBillItem(string userid, string cardid , decimal amount)
        {
            string CreateUser = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

            PatiInBillItemEntity billitem = new PatiInBillItemEntity();
            billitem.BillItemId = CreateUser + DateTime.Now.ToString("yyMMddHHmmssfff");
            billitem.UserId = userid;
            billitem.Amount = amount;
            billitem.IsUnusual = "0";
            billitem.OrdId = "";
            if(DateTime.Now.Hour<10)
            {
                billitem.TypeCode = "01";
            }
            else if (DateTime.Now.Hour > 10 && DateTime.Now.Hour<15)
            {
                billitem.TypeCode = "02";
            }
            else if (DateTime.Now.Hour > 15 && DateTime.Now.Hour <22)
            {
                billitem.TypeCode = "03";
            }
            billitem.BillDate = DateTime.Now;
            billitem.CreateDate = DateTime.Now;
            billitem.CreateUser = CreateUser;


            UserCardEntity cardEnty = this.usercardLogic.Load(cardid);
            cardEnty.FeeAmount += amount;
            cardEnty.UpdateDate = DateTime.Now;
            cardEnty.UpdateUser = CreateUser;
            bool isok = billitemLogic.SaveBillItemAndUserCard(billitem, cardEnty);


            return Json(isok, JsonRequestBehavior.AllowGet);
        }



        public ActionResult RefundsApply()
        {
            return View();
        }

        public ActionResult SweepCodeCharger()
        {
            return View();
        }


        public ActionResult GetUserByCardCode(string carid)
        {
            JsonResult result = new JsonResult();
            try
            {
                UserCardEntity cardInfo = cardlogic.Load(carid);

                if (cardInfo == null)
                {
                    result.Data = new { status = 200, msg = "无此用户" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                UserInfoEntity userinfo = userLogic.Load(cardInfo.UserId);
                if (userinfo.Flag == -1)
                {
                    result.Data = new { status = 200, msg = "此用户已经停用，不能扫码收费！" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                //if (userinfo.Flag == 0)
                //{
                //    result.Data = new { status = 200, msg = "此用户未审核，不能扫码收费！" };
                //    return Json(result, JsonRequestBehavior.AllowGet);
                //}

                string TypeCode = "";
                string typeCodeName = "";
                if (DateTime.Now.Hour < 10)
                {
                    TypeCode = "01";
                    typeCodeName = "早餐";
                }
                else if (DateTime.Now.Hour > 10 && DateTime.Now.Hour < 15)
                {
                    TypeCode = "02";
                    typeCodeName = "午餐";
                }
                else if (DateTime.Now.Hour > 15 && DateTime.Now.Hour < 22)
                {
                    TypeCode = "03";
                    typeCodeName = "晚餐";
                }

                IList<OrderDinnerEntity> dinners = dinnerlogic.LoadAll(" and TypeCode='"+ TypeCode + "' and OrderDate between '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59") + "'  and (CancUser is null or CancUser='')  and UserId = '" + userinfo.UserId + "'", 99, 1, "OrderDate desc");
                if(dinners != null && dinners.Count>0)
                {
                    int quantity = dinners[0].Quantity;
                    string ShowMsg = userinfo.UserName + "--"+ dinners[0].OrderDate.ToString("yyyy-MM-dd") + "--预定[" + typeCodeName + "]--[" + quantity.ToString()+"份]";
                    result.Data = new { status = 100, msg = ShowMsg, userData = userinfo };
                }
                else
                {
                    result.Data = new { status = 100, msg = userinfo.UserName+ "-没有预定午餐", userData = userinfo };
                }

              
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// 退费页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetListRefundsApply(string strType,int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string Condition = " and IsBack = " + strType;
            IList<RefundsApplyEntity> refundList = resundApply.LoadAll(Condition, pageSize, pageIndex, "");
            IList<RefundsApplyVM> refVMList = new List<RefundsApplyVM>();
            if (refundList != null  && refundList.Count>0)
            {
                foreach(var item in refundList)
                {
                    RefundsApplyVM vmItem = new RefundsApplyVM();
                    UserInfoEntity user = userLogic.Load(item.UserId);
                    vmItem.ApplyId = item.ApplyId;
                    vmItem.UserId = item.UserId;
                    vmItem.ApplyDate = item.ApplyDate;
                    vmItem.Amount = item.Amount;
                    vmItem.BackDate = DateTime.Now;
                    vmItem.IsBack = item.IsBack;
                    vmItem.BackUserId = item.BackUserId;
                    vmItem.UserName = user.UserName;
                    vmItem.Sex = user.Sex;
                    refVMList.Add(vmItem);
                }
            }
            return Json(refVMList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult BackUserFee(string ApplyId)
        {
            JsonResult result = new JsonResult();
            if (string.IsNullOrEmpty(ApplyId))
            {
                result.Data = new { status = 200, msg = "申请单号不能为空!", userid = "", cardCode = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            string CreateUser = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            bool isok = resundApply.BackUserFee(ApplyId, CreateUser);
            if (isok)
            {
                result.Data = new { status = 100, msg = "", userid = "", cardCode = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result.Data = new { status = 200, msg = "退费失败！", userid = "", cardCode = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
