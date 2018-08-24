using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHujingLogic;
using HujingModel;

namespace HujingWeb.Controllers
{
    public class SysGroupController : Controller
    {
        //
        // GET: /SysGroup/


        ISysGroupLogic groupLogic;
        public SysGroupController(ISysGroupLogic logic)
        {
            groupLogic = logic;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList(string name, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string Condition = "";
            if (!string.IsNullOrEmpty(name))
            {
                Condition = " and groupname like '%" + name + "%'";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = " GroupId";
            }

            IList<SysGroupEntity> orgEntity = groupLogic.LoadAll(Condition, pageSize, pageIndex, "");
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = groupLogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }


        public ActionResult Add()
        {
            return View();
        }

        public ActionResult GetRootGroup()
        {
            IList<SysGroupEntity> codList = new List<SysGroupEntity>();
            codList = groupLogic.LoadAll(" and (ParentID is null) ", 1000, 1, " GroupId");
            return Json(codList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(SysGroupEntity newObj)
        {
            try
            {
                bool isOK = groupLogic.Save(newObj);
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



        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Edit(string groupid)
        {
            if (!string.IsNullOrEmpty(groupid))
            {
                SysGroupEntity entity = groupLogic.Load(groupid);
                return View(entity);
            }
            return View(new OrganizationEntity());
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Update(SysGroupEntity entity)
        {
            try
            {
                bool isOK = this.groupLogic.Update(entity);
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


        public ActionResult Delete(string GroupIds)
        {
            bool isOk = groupLogic.Delete(GroupIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }
    }
}
