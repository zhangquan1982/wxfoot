using HujingCommon;
using HujingModel;
using HujingWeb.Filter;
using IHujingLogic;
using IHujingLogic.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.Basic
{
    public class ScheItemDateController : Controller
    {
        public IScheItemDateLogic logic { get; set; }
        public IDictCodeLogic dictCodeLogic { get; set; }
        //
        // GET: /ScheItemDate/
        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult GetList(string pname, string ptype, string dateBegin, string dateEnd, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            string Condition = "";
            if (!string.IsNullOrEmpty(pname))
            {
                Condition = " and s2.itemname like '%" + pname + "%'";
            }
            if (!string.IsNullOrEmpty(ptype))
            {
                Condition = " and s1.ScheType = " + ptype;
            }
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and s1.ScheDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and s1.ScheDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<ScheItemDateEntityAll> orgEntity = logic.LoadScheAll(Condition, pageSize, pageIndex, "s1.ScheDate desc, s1.TypeCode");
            if ((orgEntity != null) && (orgEntity.Count > 0))
            {
                foreach (ScheItemDateEntityAll allItem in orgEntity)
                {
                    //if (allItem.TypeCode == "01")
                    //{
                    //    allItem.TypeCode = "早餐";
                    //}
                    //else if (allItem.TypeCode == "02")
                    //{
                    //    allItem.TypeCode = "午餐";
                    //}
                    //else if (allItem.TypeCode == "03")
                    //{
                    //    allItem.TypeCode = "晚餐";
                    //}
                }
            }
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = logic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        public ActionResult SaveData(ScheItemDateEntity head, IList<ScheItemDateEntity> items)
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            if (head.ScheType == "1")
            {
                head.TypeCode = head.ItemID;
            }
            if ((items != null) && (items.Count > 0))
            {
                int row = 1;
                foreach (ScheItemDateEntity item in items)
                {
                    if (!string.IsNullOrEmpty(item.ItemID))
                    {
                        item.SchId = strUserId + "-" + DateTime.Now.ToString("yyMMddHHmmssff") + row.ToString();
                        item.ScheDate = head.ScheDate;
                        item.ScheType = "10035";
                        item.TypeCode = head.TypeCode;
                        item.CreateDate = DateTime.Now;
                        item.CreateUser = strUserId;
                        row++;
                    }
                }
                bool isOK = logic.SaveItemList(items);
                return Json(isOK);

            }
            return Json(false);
        }

        public ActionResult Delete(string SchIds)
        {
            bool result = logic.DeleteScheItemDates(SchIds);
            return Json(result);
        }

    }
}
