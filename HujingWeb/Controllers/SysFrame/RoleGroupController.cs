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
    public class RoleGroupController : Controller
    {
        ISysGroupLogic groupLogic;
        ISysRoleGroupLogic rolegroupLogic;
        public RoleGroupController(ISysGroupLogic logic, ISysRoleGroupLogic rolgroup)
        {
            groupLogic = logic;
            rolegroupLogic = rolgroup;
        }
        //
        // GET: /RoleGroup/
        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string roleid)
        {
            if (!string.IsNullOrEmpty(roleid))
            {
                SysRoleGroupEntity entity = new SysRoleGroupEntity(); //角色模块实体
                entity.RoleId = roleid;
                entity.GroupId = "";
                return View(entity);
            }
            return View();
        }

        public ActionResult Save(string groupIds, string roleId)
        {
            try
            {
                List<SysRoleGroupEntity> roleList = new List<SysRoleGroupEntity>();
                string[] list = groupIds.Split(',');

                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] != "")//报错角色模块集合
                    {
                        SysRoleGroupEntity rolegroup = new SysRoleGroupEntity();
                        rolegroup.RoleId = roleId;
                        rolegroup.GroupId = list[i].Trim();
                        roleList.Add(rolegroup);
                    }
                }
                bool isOk = rolegroupLogic.SaveRoleGroup(roleList);
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




        /// <summary>
        /// 功能：加载模块树
        /// 时间：add by 2015-10-1
        /// key:322123aaabbbcc
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGroupTree(string roleid)
        {
            IList<SysGroupEntity> orgEntity = groupLogic.LoadAll("", 10000, 1, "GroupID");
            List<JsonTreeCheckBoxModel> nodes = new List<JsonTreeCheckBoxModel>();
            foreach (var item in orgEntity)
            {
                JsonTreeCheckBoxModel cnode = new JsonTreeCheckBoxModel();
                cnode.id = item.GroupID;
                cnode.text = item.GroupName;
                if (!string.IsNullOrEmpty(item.ParentID))
                {
                    cnode.pid = item.ParentID;
                }
                else
                {
                    cnode.pid = "";
                }

                int count = rolegroupLogic.Count(" and roleid='" + roleid + "' and groupid='" + item.GroupID + "'");
                if (count > 0)
                {
                    cnode.@checked = true;
                }
                nodes.Add(cnode);
            }
            return Json(nodes);
        }
    }
}
