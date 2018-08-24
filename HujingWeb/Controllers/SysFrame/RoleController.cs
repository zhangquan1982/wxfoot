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
    public class RoleController : Controller
    {
        //
        // GET: /User/
        ISysRoleLogic roleLogic;

        public RoleController(ISysRoleLogic logic)
        {
            roleLogic = logic;
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
        public ActionResult GetList(string rolename, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            if (Request.Cookies["UserId"] == null)
            {
                ContentResult content = new ContentResult();
                content.Content = string.Format("<script language='javaScript' type='text/javaScript'>window.parent.window.location.href = '/Home/Login';</script>");
                return content;
            }
            pageIndex = pageIndex + 1;
            string Condition = "";
            if (!string.IsNullOrEmpty(rolename))
            {
                Condition = " and rolename like '%" + rolename + "%'";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = " RoleId";
            }

            IList<SysRoleEntity> orgEntity = roleLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = roleLogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(SysRoleEntity newObj)
        {
            try
            {
                string Condition = " and RoleName='" + newObj.RoleName + "'";
                int itemCount = roleLogic.Count(Condition);
                JsonResult result = new JsonResult();
                if (itemCount > 0)
                {
                    result.Data = new { status = 200, msg = "此名称已经存在" };
                    return Json(result);
                }
                newObj.RoleId = this.GetMaxRoleId();
                bool isOK = roleLogic.Save(newObj);
                if (isOK == true)
                {
                    result.Data = new { status = 100, msg = "" };
                    return Json(result);
                }
                else
                {
                    result.Data = new { status = 200, msg = "保存失败" };
                    return Json(result);
                }
            }
            catch(Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result);
            }
        }



        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Edit(string roleid)
        {
            if (!string.IsNullOrEmpty(roleid))
            {
                SysRoleEntity entity = roleLogic.Load(roleid);
                return View(entity);
            }
            return View(new OrganizationEntity());
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Update(SysRoleEntity entity)
        {
            JsonResult result = new JsonResult();
            try
            {
                bool isOK = this.roleLogic.Update(entity);
                if (isOK == true)
                {
                    result.Data = new { status = 100, msg = "" };
                }
                else
                {
                    result.Data = new { status = 200, msg = "更新失败" };
                }
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
            }
            return Json(result);
        }


        public ActionResult Delete(string RoleIds)
        {
            bool isOk = roleLogic.Delete(RoleIds);
            return Json(isOk);
        }

        private string GetMaxRoleId()
        {
            return roleLogic.GetMaxRoleId();
        }
    }
}
