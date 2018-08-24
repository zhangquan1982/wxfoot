using HujingModel;
using HujingWeb.Filter;
using IHujingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.Basic
{
    public class PackageController : Controller
    {

        IPackageTypeLogic typeLogic;
        IPackageItemLogic pckitemLogic;
        public PackageController(IPackageTypeLogic logic, IPackageItemLogic itemLogic)
        {
            typeLogic = logic;
            pckitemLogic = itemLogic;
        }
        //
        // GET: /Package/


        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        [LoginValidateAttribute]
        public ActionResult TypeIndex()
        {
            return View();
        }

        public ActionResult TypeAdd()
        {
            return View();
        }

        public ActionResult DeleteType(string TypeIds)
        {
            bool isOk = typeLogic.Delete(TypeIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }

        public ActionResult DeletePackageItem(string itemid)
        {
            bool isOk = pckitemLogic.Delete(itemid);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTypeTree()
        {
            string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
            string Condition = " and orgid = '" + strOrgId + "'";
            IList<PackageTypeEntity> typeEntity = typeLogic.LoadAll(Condition, 1000, 1, "CreateDate");
            List<JsonTreeModel> nodes = new List<JsonTreeModel>();
            foreach (var item in typeEntity)
            {
                JsonTreeModel cnode = new JsonTreeModel();
                cnode.id = item.PackAgeTypeId;
                cnode.name = item.PackAgeTypeName;
                cnode.pid = "";
                cnode.expanded = true;
                nodes.Add(cnode);
            }
            return Json(nodes);
        }


        public ActionResult GetTypeList(string name, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
            string Condition = " and orgid = '" + strOrgId + "'";
            if (!string.IsNullOrEmpty(name))
            {
                Condition += " and PackAgeTypeName like '%" + name + "%'";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = " CreateDate";
            }

            IList<PackageTypeEntity> orgEntity = typeLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = typeLogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        public ActionResult GetTypeListDefault()
        {
            IList<PackageTypeEntity> typeList = typeLogic.LoadAll("", 100, 1, "CreateDate");
            return Json(typeList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetList(string TypeId, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
            string Condition = " and PackageItem.orgid='" + strOrgId + "'";
            if (!string.IsNullOrEmpty(TypeId))
            {
                Condition += " and PackTypeId = '" + TypeId + "'";
            }
            else
            {
                Condition += " and 1=2";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = " PackageItem.CreateDate";
            }

            IList<PackageItemEntity> orgEntity = pckitemLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = pckitemLogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        public ActionResult GetInitCost()
        {

            string Condition = " and packtypeid = 'CS001'";
            string sortOrder = " CreateDate";

            IList<PackageItemEntity> orgEntity = pckitemLogic.LoadAll(Condition, 100, 1, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = pckitemLogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }


        public ActionResult SaveType(PackageTypeEntity type)
        {
            try
            {
                string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
                string struserid =  HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                string Condition = " and PackAgeTypeName='" + type.PackAgeTypeName + "' and orgid='" + strOrgId + "'";
                int itemCount = typeLogic.Count(Condition);
                if (itemCount > 0)
                {
                    string json = JsonHelper.RtnJson("300", "此分类名称已经存在！");
                    return Json(json);
                }
                type.CreateUser = struserid;
                type.PackAgeTypeId = struserid + "-PackageType-" + DateTime.Now.ToString("yyMMddHHmmssfff");
                type.CreateDate = DateTime.Now;
                type.OrgId = strOrgId;
                type.Flag = false;
                bool isOK = typeLogic.Save(type);
                if (isOK == true)
                {
                    string json = JsonHelper.RtnJson("100", "保存成功！");
                    return Json(json);
                }
                else
                {
                    string json = JsonHelper.RtnJson("300", "保存失败！");
                    return Json(json);
                }
            }
            catch
            {
                return Json("no");
            }
        }

        public ActionResult SavePackItem(string TypeId, string strTypeName, IList<PackageItemEntity> list)
        {
            try
            {
                string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
                string struserid = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

                //type.CreateUser = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                //type.CreateDate = DateTime.Now;
                //type.Flag = false;
                if (list.Count > 0)
                {
                    foreach (PackageItemEntity item in list)
                    {
                        item.CreateUser = struserid;
                        item.PackTypeId = TypeId;
                        item.PackTypeName = strTypeName;
                        item.CreateDate = DateTime.Now;
                        item.OrgId = strOrgId;

                    }
                }

                bool isOK = pckitemLogic.SaveList(list);
                if (isOK == true)
                {
                    return Json("ok");
                }
                else
                {
                    return Json("no");
                }
            }
            catch
            {
                return Json("no");
            }
        }

    }
}
