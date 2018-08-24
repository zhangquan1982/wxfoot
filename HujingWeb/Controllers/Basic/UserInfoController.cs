using HujingModel;
using HujingWeb.Filter;
using IHujingLogic;
using IHujingLogic.SysFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Controllers.Basic
{
    public class UserInfoController : Controller
    {
        public  IUserInfoLogic usLogic { get; set; }

        public ISysUserRoleLogic userRoleLogic { get; set; }

        public IUserCardLogic cardlogic { get; set; }
        //
        // GET: /UserInfo/

        [LoginValidateAttribute]
        public ActionResult Index()
        {
            if (Request.Cookies["UserId"] == null) 
            {
                ContentResult content = new ContentResult();
                content.Content = string.Format("<script language='javaScript' type='text/javaScript'>window.parent.window.location.href = '/Home/Login';</script>");
                return content;
            }
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            string strUserName = HttpUtility.UrlDecode(HttpContext.ApplicationInstance.Request.Cookies["UserName"].Value.ToString(), Encoding.GetEncoding("UTF-8"));
            UserInfoEntity user = usLogic.Load(strUserId);
            ViewBag.UserId = strUserId;
            if (string.IsNullOrEmpty(user.RoleType) == false && user.RoleType == "1")
            {
                ViewBag.RoleName = "【管理员】";
            }
            else
            {
                IList<SysUserRoleEntity> urole = userRoleLogic.LoadAllUserRole(" and userid = '" + strUserId + "'");
                if (urole != null && urole.Count > 0)
                {
                    ViewBag.RoleName += "【";
                    for (int irow = 0; irow < urole.Count; irow++)
                    {
                        ViewBag.RoleName += urole[irow].RoleName;
                        if (irow < urole.Count - 1)
                        {
                            ViewBag.RoleName += ",";
                        }
                    }
                    ViewBag.RoleName += "】";
                }
                else
                {
                    ViewBag.RoleName = "";
                }
            }
            ViewBag.LoginName = user.LoginName;
            ViewBag.UserName = strUserName;
            return View();
        }


        [LoginValidateAttribute]
        public ActionResult GetUserByCardCode(string carid)
        {
            JsonResult result = new JsonResult();
            try
            {
                UserCardEntity cardInfo = cardlogic.Load(carid);
                UserInfoEntity userinfo = usLogic.Load(cardInfo.UserId);
                if (userinfo == null)
                {
                    result.Data = new { status = 200, msg = "无此用户" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                result.Data = new { status = 100, msg = "success", userData = userinfo };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result.Data = new { status = 200, msg = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
