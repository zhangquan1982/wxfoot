using HujingAccess.ChargeManager;
using HujingModel;
using HujingModel.ViewModel;
using IHujingLogic;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers
{
    public class StaticalReportController : Controller
    {
        public IPatiInBillItemLogic billitemLogic { get; set; }
        public IUserInfoLogic userLogic { get; set; }

        public IOrderDinnerLogic userOrderLogic { get; set; }
        //
        // GET: /StaticalReport/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult UserFeeDetail()
        {
            return View();
        }


        public ActionResult UserFeeTotal()
        {
            return View();
        }


        public ActionResult UserMonthFeeTotal()
        {
            return View();
        }



        public ActionResult UserFeeList(string userName, string dateBegin, string dateEnd, int? pageIndex, int? pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;

            if (pageSize == null)
            {
                pageSize = 15;
            }

            string Condition = " and 1=1";
            if (!string.IsNullOrEmpty(userName))
            {
                Condition += " and ( UserName like '%" + userName + "%') ";
            }
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and PatiInBillItem.CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and PatiInBillItem.CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateDate";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "desc";
            }

            IList<PatiInBillItemEntity> lstBillItem = billitemLogic.LoadAllBillItem(Condition, pageSize.Value, pageIndex.Value, sortField, sortOrder);
            foreach (var item in lstBillItem)
            {
                UserInfoEntity userEntity = userLogic.Load(item.UserId);
                item.UserName = userEntity.UserName;
                item.SexName = userEntity.Sex == "0" ? "男" : "女";
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = billitemLogic.Count(Condition);
            dic.Add("total", count);
            dic.Add("data", lstBillItem);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public FileResult Export_UserFeeDetail_Excel(string userName, string dateBegin, string dateEnd)
        {
            string Condition = " and 1=1";
            if (!string.IsNullOrEmpty(userName))
            {
                Condition += " and ( UserName like '%" + userName + "%') ";
            }
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and PatiInBillItem.CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and PatiInBillItem.CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            string sortField = "CreateDate";

            string sortOrder = "desc";


            IList<PatiInBillItemEntity> lstBillItem = billitemLogic.LoadAllBillItem(Condition, 9999, 1, sortField, sortOrder);
            foreach (var item in lstBillItem)
            {
                UserInfoEntity userEntity = userLogic.Load(item.UserId);
                item.UserName = userEntity.UserName;
                item.SexName = userEntity.Sex == "0" ? "男" : "女";
            }

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            // List<modelList> listRainInfo = m_BLL.GetSchoolListAATQ(schoolname);
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("员工姓名");
            row1.CreateCell(1).SetCellValue("员工性别");
            row1.CreateCell(2).SetCellValue("就餐日期");
            row1.CreateCell(3).SetCellValue("午别");
            row1.CreateCell(4).SetCellValue("金额");
            row1.CreateCell(5).SetCellValue("创建日期");
            row1.CreateCell(6).SetCellValue("创建人");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < lstBillItem.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(lstBillItem[i].UserName.ToString());
                rowtemp.CreateCell(1).SetCellValue(lstBillItem[i].SexName.ToString());
                rowtemp.CreateCell(2).SetCellValue(lstBillItem[i].CreateDate.ToString());
                if(lstBillItem[i].TypeCode=="01")
                {
                    rowtemp.CreateCell(3).SetCellValue("早餐");
                }
                else if (lstBillItem[i].TypeCode == "02")
                {
                    rowtemp.CreateCell(3).SetCellValue("午餐");
                }
                else if (lstBillItem[i].TypeCode == "03")
                {
                    rowtemp.CreateCell(3).SetCellValue("晚餐");
                }
                rowtemp.CreateCell(4).SetCellValue(lstBillItem[i].Amount.ToString());
                rowtemp.CreateCell(5).SetCellValue(lstBillItem[i].CreateDate.ToString());
                rowtemp.CreateCell(6).SetCellValue(lstBillItem[i].CreateUser.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }


        public ActionResult UserFeeDayList(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex + 1;

            if (pageSize == null)
            {
                pageSize = 15;
            }

            string Condition = " and 1=1";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and PatiInBillItem.CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and PatiInBillItem.CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserBillTotal> billTotal = new List<UserBillTotal>();
            DataTable lstBillItem = billitemLogic.GetPersonBillTypeAmount(Condition, pageSize.Value, pageIndex.Value, "", "");
            if (lstBillItem != null && lstBillItem.Rows.Count > 0)
            {
                foreach (DataRow drNew in lstBillItem.Rows)
                {
                    UserBillTotal item = new UserBillTotal();
                    item.BillDate = drNew[0].ToString();
                    item.TotalAmount = decimal.Parse(drNew[1].ToString());
                    billTotal.Add(item);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = billTotal.Count();
            dic.Add("total", count);
            dic.Add("data", billTotal);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public FileResult ExportExcel(string dateBegin, string dateEnd)
        {
            string Condition = " and 1=1";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and PatiInBillItem.CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and PatiInBillItem.CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserBillTotal> billTotal = new List<UserBillTotal>();
            DataTable lstBillItem = billitemLogic.GetPersonBillTypeAmount(Condition, 9999, 1, "", "");
            if (lstBillItem != null && lstBillItem.Rows.Count > 0)
            {
                foreach (DataRow drNew in lstBillItem.Rows)
                {
                    UserBillTotal item = new UserBillTotal();
                    item.BillDate = drNew[0].ToString();
                    item.TotalAmount = decimal.Parse(drNew[1].ToString());
                    billTotal.Add(item);
                }
            }
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            // List<modelList> listRainInfo = m_BLL.GetSchoolListAATQ(schoolname);
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("就餐日期");
            row1.CreateCell(1).SetCellValue("金额");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < billTotal.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(billTotal[i].BillDate.ToString());
                rowtemp.CreateCell(1).SetCellValue(billTotal[i].TotalAmount.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }


        public ActionResult UserMonthDayList(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex + 1;

            if (pageSize == null)
            {
                pageSize = 15;
            }

            string Condition = " and 1=1";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and PatiInBillItem.CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and PatiInBillItem.CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserBillTotal> billTotal = new List<UserBillTotal>();
            DataTable lstBillItem = billitemLogic.GetPersonBillMonthAmount(Condition, pageSize.Value, pageIndex.Value, "", "");
            if (lstBillItem != null && lstBillItem.Rows.Count > 0)
            {
                foreach (DataRow drNew in lstBillItem.Rows)
                {
                    UserBillTotal item = new UserBillTotal();
                    item.BillDate = drNew[0].ToString();
                    item.TotalAmount = decimal.Parse(drNew[1].ToString());
                    billTotal.Add(item);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = billTotal.Count();
            dic.Add("total", count);
            dic.Add("data", billTotal);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserOrderTotal()
        {
            return View();
        }


        public ActionResult UserOrderDetail()
        {
            return View();
        }


        public ActionResult UserOrderDayList(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex + 1;

            if (pageSize == null)
            {
                pageSize = 25;
            }

            string Condition = " and (CancUser is null or CancUser='')";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and OrderDinner.OrderDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and OrderDinner.OrderDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserOrderTotal> orderTotal = new List<UserOrderTotal>();
            DataTable dataDinner = userOrderLogic.GetOrderDinnerCollect(Condition, pageSize.Value, pageIndex.Value, "", "");
            if (dataDinner != null && dataDinner.Rows.Count > 0)
            {
                foreach (DataRow drNew in dataDinner.Rows)
                {
                    UserOrderTotal item = new UserOrderTotal();
                    item.OrderDate = drNew[0].ToString();
                    item.TypeCode = drNew[1].ToString();
                    item.Quantity = int.Parse(drNew[2].ToString());
                    orderTotal.Add(item);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = orderTotal.Count();
            dic.Add("total", count);
            dic.Add("data", orderTotal);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserOrderDetailList(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex + 1;

            if (pageSize == null)
            {
                pageSize = 25;
            }

            string Condition = " and (CancUser is null or CancUser='')";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and OrderDinner.OrderDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and OrderDinner.OrderDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserOrderDetail> orderTotal = new List<UserOrderDetail>();
            DataTable dataDinner = userOrderLogic.GetOrderDinnerDetail(Condition, pageSize.Value, pageIndex.Value, "", "");

            int rowcount = userOrderLogic.GetOrderDinnerDetailCount(Condition);
            if (dataDinner != null && dataDinner.Rows.Count > 0)
            {
                foreach (DataRow drNew in dataDinner.Rows)
                {
                    UserOrderDetail item = new UserOrderDetail();
                    item.orderDate = DateTime.Parse(drNew["OrderDate"].ToString());
                    item.userId = drNew[0].ToString();
                    item.userName = drNew["UserName"].ToString();
                    item.type = drNew["TypeCode"].ToString();
                    item.Quantity = int.Parse(drNew["Quantity"].ToString());
                    orderTotal.Add(item);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = orderTotal.Count();
            dic.Add("total", rowcount);
            dic.Add("data", orderTotal);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserOrderNoEat()
        {
            return View();
        }

        public ActionResult EatNoUserOrder()
        {
            return View();
        }


        public ActionResult GetUserOrderNoEatList(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
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

            IList<UserOrderDetail> orderTotal = new List<UserOrderDetail>();
            DataTable dataDinner = userOrderLogic.GetOrderDinnerDetail(Condition, 888888, 1, "", "");
            int rowIndex = 1;
            if (dataDinner.Rows.Count > 0)
            {
                foreach (DataRow row in dataDinner.Rows)
                {
                    rowIndex += 1;
                    string typeCode = row["TypeCode"].ToString();
                    string userid = row["UserId"].ToString();
                    string strBeg = DateTime.Parse(row["OrderDate"].ToString()).ToString("yyyy-MM-dd 00:00:00.000");
                    string strEnd = DateTime.Parse(row["OrderDate"].ToString()).ToString("yyyy-MM-dd 23:59:59");

                    string strCondition = " and IsUnusual='0' and UserId='" + userid + "' and TypeCode='" + typeCode + "'  and  CreateDate between   '" + strBeg + "'  and  '" + strEnd + "'";
                    //string strSql = @"  select * from  PatiInBillItem  where ";
                    int rowount= billitemLogic.Count(strCondition);
                    if (rowount > 0)
                    {
                        continue;
                    }

                    UserOrderDetail orderInfo = new UserOrderDetail();
                    orderInfo.orderDate = DateTime.Parse(row["OrderDate"].ToString());
                    orderInfo.type = row["TypeCode"].ToString();
                    orderInfo.userId = row["userid"].ToString();
                    orderInfo.userName = row["UserName"].ToString();
                    orderInfo.Quantity = int.Parse(row["Quantity"].ToString());
                    orderTotal.Add(orderInfo);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = orderTotal.Count();
            dic.Add("total", orderTotal.Count);
            dic.Add("data", orderTotal);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetEatNoUserOrderList(string dateBegin, string dateEnd, int? pageIndex, int? pageSize)
        {
            string Condition = " and IsUnusual='0'";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<PatiInBillItemEntity> billNoOrder = new List<PatiInBillItemEntity>();
            IList<PatiInBillItemEntity> billItem = billitemLogic.LoadAll(Condition, 888888, 1, "CreateDate");
            int rowIndex = 1;
            if (billItem != null && billItem.Count > 0)
            {
                foreach (PatiInBillItemEntity item in billItem)
                {
                    rowIndex += 1;

                    string strCondition = " and (CancUser is null or CancUser = '') and UserId='" + item.UserId + "' and TypeCode='" + item.TypeCode + "'  and  OrderDate between   '" + item.CreateDate.ToString("yyyy-MM-dd 00:00:00") + "'  and  '" + item.CreateDate.ToString("yyyy-MM-dd 23:59:59") + "'";
                    //string strSql = @"  select * from  PatiInBillItem  where ";
                    int rowount = userOrderLogic.Count(strCondition);
                    if (rowount > 0)
                    {
                        continue;
                    }
                    UserInfoEntity user = userLogic.Load(item.UserId);
                    item.UserName = user.UserName;
                    billNoOrder.Add(item);
                }
            }

            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = billNoOrder.Count();
            dic.Add("total", billNoOrder.Count);
            dic.Add("data", billNoOrder);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }


        public FileResult Export_UserOrderTotal_Excel(string dateBegin, string dateEnd)
        {
            string Condition = " and (CancUser is null or CancUser='')";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and OrderDinner.OrderDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and OrderDinner.OrderDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserOrderTotal> orderTotal = new List<UserOrderTotal>();
            DataTable dataDinner = userOrderLogic.GetOrderDinnerCollect(Condition, 9999, 1, "", "");
            if (dataDinner != null && dataDinner.Rows.Count > 0)
            {
                foreach (DataRow drNew in dataDinner.Rows)
                {
                    UserOrderTotal item = new UserOrderTotal();
                    item.OrderDate = drNew[0].ToString();
                    item.TypeCode = drNew[1].ToString();
                    item.Quantity = int.Parse(drNew[2].ToString());
                    orderTotal.Add(item);
                }
            }

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            // List<modelList> listRainInfo = m_BLL.GetSchoolListAATQ(schoolname);
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("预约日期");
            row1.CreateCell(1).SetCellValue("午别");
            row1.CreateCell(2).SetCellValue("数量");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < orderTotal.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(orderTotal[i].OrderDate.ToString());
                if (orderTotal[i].TypeCode == "01")
                {
                    rowtemp.CreateCell(1).SetCellValue("早餐");
                }
                else if (orderTotal[i].TypeCode == "02")
                {
                    rowtemp.CreateCell(1).SetCellValue("午餐");
                }
                else if (orderTotal[i].TypeCode == "03")
                {
                    rowtemp.CreateCell(1).SetCellValue("晚餐");
                }
                rowtemp.CreateCell(2).SetCellValue(orderTotal[i].Quantity.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }


        public FileResult  Export_UserOrderDetail_Excel(string dateBegin, string dateEnd)
        {
            string Condition = " and (CancUser is null or CancUser='')";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and OrderDinner.OrderDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and OrderDinner.OrderDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<UserOrderDetail> orderTotal = new List<UserOrderDetail>();
            DataTable dataDinner = userOrderLogic.GetOrderDinnerDetail(Condition, 9999, 1, "OrderDate", "");
            if (dataDinner != null && dataDinner.Rows.Count > 0)
            {
                foreach (DataRow drNew in dataDinner.Rows)
                {
                    UserOrderDetail item = new UserOrderDetail();
                    item.orderDate = DateTime.Parse(drNew["OrderDate"].ToString());
                    item.userId = drNew[0].ToString();
                    item.userName = drNew["UserName"].ToString();
                    item.type = drNew["TypeCode"].ToString();
                    item.Quantity = int.Parse(drNew["Quantity"].ToString());
                    orderTotal.Add(item);
                }
            }


            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            // List<modelList> listRainInfo = m_BLL.GetSchoolListAATQ(schoolname);
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("预约日期");
            row1.CreateCell(1).SetCellValue("工号");
            row1.CreateCell(2).SetCellValue("姓名");
            row1.CreateCell(3).SetCellValue("午别");
            row1.CreateCell(4).SetCellValue("数量");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < orderTotal.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(orderTotal[i].orderDate.ToString("yyyy-MM-dd"));
                rowtemp.CreateCell(1).SetCellValue(orderTotal[i].userId);
                rowtemp.CreateCell(2).SetCellValue(orderTotal[i].userName);
                if (orderTotal[i].type == "01")
                {
                    rowtemp.CreateCell(3).SetCellValue("早餐");
                }
                else if (orderTotal[i].type == "02")
                {
                    rowtemp.CreateCell(3).SetCellValue("午餐");
                }
                else if (orderTotal[i].type == "03")
                {
                    rowtemp.CreateCell(3).SetCellValue("晚餐");
                }
                rowtemp.CreateCell(4).SetCellValue(orderTotal[i].Quantity.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }


        public FileResult Export_UserOrderNoEat_Excel(string dateBegin, string dateEnd)
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

            IList<UserOrderDetail> orderTotal = new List<UserOrderDetail>();
            DataTable dataDinner = userOrderLogic.GetOrderDinnerDetail(Condition, 888888, 1, "", "");
            int rowIndex = 1;
            if (dataDinner.Rows.Count > 0)
            {
                foreach (DataRow row in dataDinner.Rows)
                {
                    rowIndex += 1;
                    string typeCode = row["TypeCode"].ToString();
                    string userid = row["UserId"].ToString();
                    string strBeg = DateTime.Parse(row["OrderDate"].ToString()).ToString("yyyy-MM-dd 00:00:00.000");
                    string strEnd = DateTime.Parse(row["OrderDate"].ToString()).ToString("yyyy-MM-dd 23:59:59");

                    string strCondition = " and IsUnusual='0' and UserId='" + userid + "' and TypeCode='" + typeCode + "'  and  CreateDate between   '" + strBeg + "'  and  '" + strEnd + "'";
                    //string strSql = @"  select * from  PatiInBillItem  where ";
                    int rowount = billitemLogic.Count(strCondition);
                    if (rowount > 0)
                    {
                        continue;
                    }

                    UserOrderDetail orderInfo = new UserOrderDetail();
                    orderInfo.orderDate = DateTime.Parse(row["OrderDate"].ToString());
                    orderInfo.type = row["TypeCode"].ToString();
                    orderInfo.userId = row["userid"].ToString();
                    orderInfo.userName = row["UserName"].ToString();
                    orderInfo.Quantity = int.Parse(row["Quantity"].ToString());
                    orderTotal.Add(orderInfo);
                }
            }


            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            // List<modelList> listRainInfo = m_BLL.GetSchoolListAATQ(schoolname);
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("预约日期");
            row1.CreateCell(1).SetCellValue("员工工号");
            row1.CreateCell(2).SetCellValue("员工姓名");
            row1.CreateCell(3).SetCellValue("午别");
            row1.CreateCell(4).SetCellValue("数量");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < orderTotal.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(orderTotal[i].orderDate.ToString("yyyy-MM-dd"));
                rowtemp.CreateCell(1).SetCellValue(orderTotal[i].userId);
                rowtemp.CreateCell(2).SetCellValue(orderTotal[i].userName);
                if (orderTotal[i].type == "01")
                {
                    rowtemp.CreateCell(3).SetCellValue("早餐");
                }
                else if (orderTotal[i].type == "02")
                {
                    rowtemp.CreateCell(3).SetCellValue("午餐");
                }
                else if (orderTotal[i].type == "03")
                {
                    rowtemp.CreateCell(3).SetCellValue("晚餐");
                }
                rowtemp.CreateCell(4).SetCellValue(orderTotal[i].Quantity.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        //Export_EatNoUserOrder_Excel
        public FileResult Export_EatNoUserOrder_Excel(string dateBegin, string dateEnd)
        {
            string Condition = " and IsUnusual='0'";
            if (!string.IsNullOrEmpty(dateBegin))
            {
                Condition += " and CreateDate >= '" + DateTime.Parse(dateBegin).ToString("yyyy-MM-dd 00:00:00") + "'";
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                Condition += " and CreateDate <= '" + DateTime.Parse(dateEnd).ToString("yyyy-MM-dd 23:59:59") + "'";
            }

            IList<PatiInBillItemEntity> billNoOrder = new List<PatiInBillItemEntity>();
            IList<PatiInBillItemEntity> billItem = billitemLogic.LoadAll(Condition, 888888, 1, "CreateDate");
            int rowIndex = 1;
            if (billItem != null && billItem.Count > 0)
            {
                foreach (PatiInBillItemEntity item in billItem)
                {
                    rowIndex += 1;

                    string strCondition = " and (CancUser is null or CancUser = '') and UserId='" + item.UserId + "' and TypeCode='" + item.TypeCode + "'  and  OrderDate between   '" + item.CreateDate.ToString("yyyy-MM-dd 00:00:00") + "'  and  '" + item.CreateDate.ToString("yyyy-MM-dd 23:59:59") + "'";
                    //string strSql = @"  select * from  PatiInBillItem  where ";
                    int rowount = userOrderLogic.Count(strCondition);
                    if (rowount > 0)
                    {
                        continue;
                    }
                    UserInfoEntity user = userLogic.Load(item.UserId);
                    item.UserName = user.UserName;
                    billNoOrder.Add(item);
                }
            }


            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            // List<modelList> listRainInfo = m_BLL.GetSchoolListAATQ(schoolname);
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("就餐日期");
            row1.CreateCell(1).SetCellValue("员工工号");
            row1.CreateCell(2).SetCellValue("员工姓名");
            row1.CreateCell(3).SetCellValue("午别");
            row1.CreateCell(4).SetCellValue("金额");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < billNoOrder.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(billNoOrder[i].CreateDate.ToString("yyyy-MM-dd"));
                rowtemp.CreateCell(1).SetCellValue(billNoOrder[i].UserId);
                rowtemp.CreateCell(2).SetCellValue(billNoOrder[i].UserName);
                if (billNoOrder[i].TypeCode == "01")
                {
                    rowtemp.CreateCell(3).SetCellValue("早餐");
                }
                else if (billNoOrder[i].TypeCode == "02")
                {
                    rowtemp.CreateCell(3).SetCellValue("午餐");
                }
                else if (billNoOrder[i].TypeCode == "03")
                {
                    rowtemp.CreateCell(3).SetCellValue("晚餐");
                }
                rowtemp.CreateCell(4).SetCellValue(billNoOrder[i].Amount.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

    }
}
