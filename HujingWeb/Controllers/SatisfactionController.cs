using HujingModel;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers
{
    public class SatisfactionController : Controller
    {

        public ISatisfactionLogic logic { get; set; }
        //
        // GET: /Satisfaction/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetSatisfactGroupDate(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
        {
            string Condition = " and (CancUser is null or CancUser = '')";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and OrderDinner.OrderDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and OrderDinner.OrderDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<SatisfactGroupDate> orderTotal = new List<SatisfactGroupDate>();
            DataTable dataDinner = logic.GetSatisfactGroupDate(Condition, 888888, 1, "", "");
            int rowIndex = 1;
            if (dataDinner.Rows.Count > 0)
            {
                foreach (DataRow row in dataDinner.Rows)
                {
                    rowIndex += 1;

                    SatisfactGroupDate orderInfo = new SatisfactGroupDate();
                    orderInfo.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                    orderInfo.TypeCode = row["TypeCode"].ToString();
                    orderInfo.Num1Count = int.Parse(row["Num1Count"].ToString());
                    orderInfo.Num2Count = int.Parse(row["Num2Count"].ToString());
                    orderInfo.Num3Count = int.Parse(row["Num3Count"].ToString());
                    orderTotal.Add(orderInfo);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = orderTotal.Count();
            dic.Add("total", orderTotal.Count);
            dic.Add("data", orderTotal);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

    }
}
