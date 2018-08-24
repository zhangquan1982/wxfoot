using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHujingLogic;
using HujingModel;
using HujingWeb.Filter;


namespace HujingWeb.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentLogic depLogic;
        ICommonClassLogic commlogic;
        IDictCodeLogic codeLogic;
        public DepartmentController(IDepartmentLogic logic, ICommonClassLogic cLogic, IDictCodeLogic dLogic)
        {
            depLogic = logic;
            commlogic = cLogic;
            codeLogic = dLogic;
        }

        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList(string upperid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {

            pageIndex = pageIndex + 1;

            string Condition = "";
            if (!string.IsNullOrEmpty(upperid))
            {
                Condition += " and upperid= '" + upperid + "'";
            }
            else
            {
                Condition += " and (upperid is null or upperid = '')";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "DepId";
            }

            IList<DepartmentEntity> orgEntity = depLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", orgEntity.Count);
            dic.Add("data", orgEntity);
            return Json(dic);
        }


        public ActionResult GetAllDepList(string name)
        {
            string Condition = "";
            if (!string.IsNullOrEmpty(name))
            {
                Condition += " and DepName like '%" + name + "%'";
            }
            IList<DepartmentEntity> orgEntity = depLogic.LoadAll(Condition, 999, 1, "DepId");
            return Json(orgEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepTree()
        {
            IList<DepartmentEntity> orgEntity = depLogic.LoadAll("", 10000, 1, "depid");
            List<JsonTreeModel> nodes = new List<JsonTreeModel>();
            foreach (var item in orgEntity)
            {
                JsonTreeModel cnode = new JsonTreeModel();
                cnode.id = item.DepId;
                cnode.name = item.DepName;
                if (!string.IsNullOrEmpty(item.UpperId))
                {
                    cnode.pid = item.UpperId;
                }
                else
                {
                    cnode.pid = "";
                }


                cnode.expanded = true;

                nodes.Add(cnode);
            }
            return Json(nodes);
        }

        public ActionResult Delete(string DepIds)
        {
            bool isOk = depLogic.Delete(DepIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }

        public ActionResult Add()
        {
            DepartmentEntity depEntiy = new DepartmentEntity();
            return View(depEntiy);

        }

        public ActionResult Edit(string Depid)
        {
            if (string.IsNullOrEmpty(Depid))
            {
                throw new Exception("");
            }
            DepartmentEntity depEntiy = depLogic.Load(Depid);
            return View(depEntiy);
        }

        [HttpPost]
        public JsonResult Save(DepartmentEntity newObj)
        {
            JsonResult result = new JsonResult();
            try
            {
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                if (string.IsNullOrEmpty(newObj.DepId))
                {
                    string Condition = "  and DepName='" + newObj.DepName + "'";
                    int itemCount = depLogic.Count(Condition);
                    if (itemCount > 0)
                    {
                        string json = JsonHelper.RtnJson("300", "此名称已经存在！");
                        return Json(json);
                    }
                    newObj.DepId = strUserId + "-Dep-" + DateTime.Now.ToString("yyMMddHHmmssff"); // SetOrgCode(newObj.UpperId, OrgId);
                    newObj.CreateDate = DateTime.Now;
                    newObj.UpdateDate = DateTime.Now;
                    newObj.CreateUser = strUserId;
                    newObj.DepTypeName = "部门";
                    newObj.DepType = "部门";
                    newObj.Flag = (newObj.Flag == null ? "0" : newObj.Flag);

                    bool isOK = depLogic.Save(newObj);
                    if (isOK == true)
                    {
                        string json = JsonHelper.RtnJson("100", "");
                        return Json(json);
                    }
                    else
                    {
                        string json = JsonHelper.RtnJson("200", "");
                        return Json(json);
                    }
                }
                else
                {
                    newObj.UpdateDate = DateTime.Now;
                    newObj.UpdateUser = strUserId;
                    newObj.Flag = (newObj.Flag == null ? "0" : newObj.Flag);
                    bool isOK = depLogic.Update(newObj);
                    if (isOK == true)
                    {
                        return Json("ok");
                    }
                    else
                    {
                        return Json("no");
                    }
                }

            }
            catch
            {
                return Json("no");
            }
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public ActionResult Update(DepartmentEntity entity)
        {
            try
            {
                entity.UpdateDate = System.DateTime.Now;
                entity.UpdateUser = "admin";
                bool isOK = depLogic.Update(entity);
                if (isOK == true)
                {
                    return Json("ok");
                }
                else
                {
                    return Json("no");
                }
            }
            catch (Exception ex)
            {
                return Json("no");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string SetOrgCode(string parentid)
        {
            return depLogic.GetMaxDepId(parentid);
        }

    }
}
