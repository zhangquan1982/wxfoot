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
    public class SysUserRoleController : Controller
    {
        //
        // GET: /SysUserRole/
        ISysUserRoleLogic sysuserroleLogic;
        ISysRoleLogic rolelogic;
        IUserInfoLogic userLogic;
        public SysUserRoleController(ISysUserRoleLogic logic, ISysRoleLogic rlogic, IUserInfoLogic ulogic)
        {
            sysuserroleLogic = logic;
            rolelogic = rlogic;
            userLogic = ulogic;
        }
        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult BindRole(string userid)
        {
            if (!string.IsNullOrEmpty(userid))
            {
                SysUserRoleEntity entity = new SysUserRoleEntity();
                entity.UserId = userid;
                entity.RoleId = "";
                return View(entity);
            }
            return View();
        }

        public ActionResult GetRole(string userid)
        {
            string strSql = " and exists ( select * from SysUserRole where sysrole.roleid = SysUserRole.roleid and userid = '" + userid + "' )";
            IList<SysUserRoleEntity> entity = sysuserroleLogic.SelectBindRole(strSql);

            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNoRole(string userid)
        {
            string strSql = " and not exists ( select * from SysUserRole where sysrole.roleid = SysUserRole.roleid and userid = '" + userid + "' )";
            IList<SysUserRoleEntity> entity = sysuserroleLogic.SelectBindRole(strSql);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveUserRole(string roles, string userid)
        {
            try
            {
                List<SysUserRoleEntity> roleList = new List<SysUserRoleEntity>();
                string[] list = roles.Split(',');

                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] != "")
                    {
                        SysUserRoleEntity userrole = new SysUserRoleEntity();
                        userrole.RoleId = list[i];
                        SysRoleEntity role = rolelogic.Load(userrole.RoleId);
                        userrole.RoleName = role.RoleName;
                        userrole.UserId = userid;
                        UserInfoEntity usentity = userLogic.Load(userrole.UserId);
                        userrole.UserName = usentity.UserName;
                        roleList.Add(userrole);
                    }
                }
                bool isOk = sysuserroleLogic.SaveUserRole(roleList);
                if (isOk == true)
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


        public ActionResult DeleteUserRole(string roles, string userid)
        {
            try
            {
                List<SysUserRoleEntity> roleList = new List<SysUserRoleEntity>();
                string[] list = roles.Split(',');

                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] != "")
                    {
                        SysUserRoleEntity userrole = new SysUserRoleEntity();
                        userrole.RoleId = list[i].Trim();
                        userrole.UserId = userid;
                        roleList.Add(userrole);
                    }
                }
                bool isOk = sysuserroleLogic.DeleteUserRole(roleList);
                if (isOk == true)
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
    }
}
