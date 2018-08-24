using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHujingLogic;
using HujingModel;
using System.Collections;
using Newtonsoft.Json;
using HujingCommon;

namespace HujingWeb.Controllers
{
    public class OrganizationController : Controller
    {
        IOrganizationLogic orgLogic;
        ICommonClassLogic commonClassLogic;
        IOrgCardLogic orgcardLogic;
        IUserInfoLogic usLogic;
        public ISysGroupLogic groupLogic { get; set; }
        public IDictCodeLogic dictcodeLogic { get; set; }
        public OrganizationController(IOrganizationLogic logic, ICommonClassLogic classLogic, IOrgCardLogic ocaLogic, IUserInfoLogic userLogic)
        {
            orgLogic = logic;
            commonClassLogic = classLogic;
            orgcardLogic = ocaLogic;
            usLogic = userLogic;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OrgUser(string OrgId)
        {
            if (OrgId != "")
            {
                IList<UserInfoEntity> userInfo = usLogic.LoadAll(" and RoleType=1 and orgid='" + OrgId+"'", 10, 1, "createdate","desc");
                if (userInfo.Count > 0)
                {
                    ViewData["LoginName"] = OrgId;
                }
                else
                {
                    ViewData["LoginName"] = OrgId;
                    return View();
                }
            }
            else
            {

            }
            return View();
        }

        public ActionResult OrgGroup(string OrgId)
        {
            if (!string.IsNullOrEmpty(OrgId))
            {
                OrganizationEntity entity = new OrganizationEntity(); //角色模块实体
                return View(entity);
            }
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList(string upperid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
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
                sortOrder = "Organization.OrgId";
            }

            IList<OrganizationEntity> orgEntity = orgLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", orgEntity.Count);
            dic.Add("data", orgEntity);
            return Json(dic);
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrgBedList(string upperid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string Condition = "";
            if (!string.IsNullOrEmpty(upperid))
            {
                Condition += " and Organization.upperid like '" + upperid + "%'";
            }
            else
            {
                Condition += " ";
            }
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "COUNT(BedId)";
            }
            if(string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "desc";
            }

            IList<CommonNameCount> orgEntity = orgLogic.LoadAllOrgBed(Condition, pageSize, pageIndex, sortField, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", orgEntity.Count);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetListAndParent(string upperid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string Condition = "";
            if (!string.IsNullOrEmpty(upperid))
            {
                Condition += " and upperid like '" + upperid + "%'";
            }
            else
            {
                Condition += " and Organization.orgid <> '888'";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Organization.OrgId";
            }

            IList<OrganizationEntity> orgEntity = orgLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", orgEntity.Count);
            dic.Add("data", orgEntity);
            return Json(dic);
        }


        /// <summary>
        /// 功能：加载模块树
        /// 时间：add by 2015-10-1
        /// key:322123aaabbbcc
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGroupTree(string orgid)
        {
            IList<SysGroupEntity> orgGroup = groupLogic.LoadAll(" and orgid = '100'", 10000, 1, "GroupID");
            List<JsonTreeCheckBoxModel> nodes = new List<JsonTreeCheckBoxModel>();
            foreach (var item in orgGroup)
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
                string conditonitem = " and groupid='" + item.GroupID + "'";
                conditonitem += " and orgid = '" + orgid + "'";
                int count = groupLogic.Count(conditonitem);
                if (count > 0)
                {
                    cnode.@checked = true;
                }
                nodes.Add(cnode);
            }
            return Json(nodes);
        }

        public ActionResult SaveOrgGroup(string groupIds, string orgid)
        {
            try
            {
                int count = groupLogic.GetSysOrgGroupCount(" and orgid='" + orgid + "'");
                if(count>0)
                {
                    string json = JsonHelper.RtnJson("300", "此机构初始菜单已经维护！");
                    return Json(json);
                }

                List<SysOrgGroupEntity> groupList = new List<SysOrgGroupEntity>();
                string[] list = groupIds.Split(',');

                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] != "")//报错角色模块集合
                    {
                        SysOrgGroupEntity group = new SysOrgGroupEntity();
                        group.OrgId = orgid;
                        group.GroupID = list[i].Trim();
                        SysGroupEntity entity = groupLogic.Load(group.GroupID);
                        if (entity != null)
                        {
                            group.BeginDate = DateTime.Now;
                            group.EndDate = DateTime.Now;
                            group.ChargePrice = 0;
                            group.ChargeUrl = "";
                            group.CreateDate = DateTime.Now;
                            group.CreateUser = "admin";
                            group.UpdateDate = DateTime.Now;
                            group.BeginDate = DateTime.Now;
                            group.EndDate = DateTime.Now.AddYears(1);
                            groupList.Add(group);
                        }

                    }
                }
                bool isOk = groupLogic.SaveSysOrgGroup(groupList);
                if (isOk == true)
                {
                    string json = JsonHelper.RtnJson("100", "维护成功！");
                    return Json(json);
                }
                else
                {
                    string json = JsonHelper.RtnJson("200", "维护失败！");
                    return Json(json);
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
        public ActionResult GetOrgTree()
        {
            string Condition = " and 1=1";
            IList<OrganizationEntity> orgEntity = orgLogic.LoadAll(Condition, 10000, 1, "Organization.orgid");
            List<JsonTreeModel> nodes = new List<JsonTreeModel>();
            foreach (var item in orgEntity)
            {
                JsonTreeModel cnode = new JsonTreeModel();
                cnode.id = item.OrgId;
                cnode.name = item.OrgName;
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

        public ActionResult GetOrgGroupTree(string orgid)
        {
            string Condition = " and orgid = '100'";
            IList<SysGroupEntity> orgEntity = groupLogic.LoadAll(Condition, 10000, 1, "GroupID");
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

                int count = groupLogic.GetSysOrgGroupCount(" and orgid='" + orgid + "' and groupid='" + item.GroupID + "'");
                if (count > 0)
                {
                    cnode.@checked = true;
                }
                nodes.Add(cnode);
            }
            return Json(nodes);
        }

        public ActionResult Delete(string OrgIds)
        {
            bool isOk = orgLogic.Delete(OrgIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }

        public ActionResult InitDictCode(string OrgIds)
        {
            if(string.IsNullOrEmpty(OrgIds))
            {
                string json = JsonHelper.RtnJson("200", "未选择机构！");
                return Json(json);
            }
            string Condition = " and orgid = '" + OrgIds + "'";
            int count = dictcodeLogic.Count(Condition);
            if(count>0)
            {
                string json = JsonHelper.RtnJson("200", "此机构已经初始化数据字典！");
                return Json(json);
            }
            bool isOk = dictcodeLogic.InitOrgDictCode(OrgIds);
            if (isOk == true)
            {
                string json = JsonHelper.RtnJson("100", "维护成功！");
                return Json(json);
            }
            else
            {
                string json = JsonHelper.RtnJson("200", "维护失败！");
                return Json(json);
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(OrganizationEntity newObj)
        {
            JsonResult result = new JsonResult();
            try
            {
                DictCodeEntity selCode = new DictCodeEntity();
                selCode.CodeTypeId= "10006";
                selCode.CodeId=newObj.OrgType;
                selCode.OrgId = "admin";
                DictCodeEntity code = dictcodeLogic.Load(selCode);
                if (code != null)
                {
                    newObj.OrgTypeName = code.CodeName;
                }
                newObj.OrgId = SetOrgCode(newObj.UpperId);
                newObj.CreateDate = DateTime.Now;
                newObj.UpdateDate = DateTime.Now;
                newObj.CreateUser = "admin";
                newObj.Flag = (newObj.Flag == null ? "0" : newObj.Flag);
                bool isOK = orgLogic.Save(newObj);
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

        public JsonResult SaveOrgUser(string OrgId, string UserId, string Password)
        {
            JsonResult result = new JsonResult();
            bool isOk = false;
            try
            {
                OrgCardEntity orgcard = orgcardLogic.Load(OrgId);
                if (orgcard != null)
                {
                    UserInfoEntity user = new UserInfoEntity();
                    user.UserId = orgcard.OrgIdU;
                    user.LoginName = UserId;
                    user.UserName = UserId;
                    user.Password = Password;
                    user.Flag = false;
                    user.RoleType = "1";
                    user.CreateDate = DateTime.Now;
                    user.BirthDate = DateTime.Now;
                    user.CreateUser = "admin";
                    string Condition = " and OrgId='" + OrgId + "' and roletype=1 ";
                    IList<UserInfoEntity> userList = usLogic.LoadAll(Condition, 20, 1, "CreateDate","desc");

                    if ((userList != null) && (userList.Count > 0))
                    {
                        UserInfoEntity userNew = userList[0];
                        //isOk = usLogic.Delete(userNew.UserId);

                        string keyword = StringCipherCls.EncryptDES(Password, StringCipherCls.keyIn);
                        userNew.Password = keyword;
                        userNew.UpdateDate = DateTime.Now;
                        userNew.UpdateUser = "admin";
                        isOk = usLogic.Update(userNew);
                    }
                    else
                    {
                        string keyword = StringCipherCls.EncryptDES(Password, StringCipherCls.keyIn);
                        user.Password = keyword;
                        isOk = usLogic.Save(user);
                    }

                }
                if (isOk == true)
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
        public ActionResult Edit(string orgid)
        {
            if (!string.IsNullOrEmpty(orgid))
            {
                OrganizationEntity entity = orgLogic.Load(orgid);
                return View(entity);
            }
            return View(new OrganizationEntity());
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Update(OrganizationEntity entity)
        {
            try
            {
                if(entity.Flag == null)
                {
                    entity.Flag = "0";
                }
                entity.UpdateDate = System.DateTime.Now;
                entity.UpdateUser = "admin";
                DictCodeEntity selCode = new DictCodeEntity();
                selCode.CodeTypeId = "10006";
                selCode.CodeId = entity.OrgType;
                selCode.OrgId = "888";
                DictCodeEntity code = dictcodeLogic.Load(selCode);
                if (code != null)
                {
                    entity.OrgTypeName = code.CodeName;
                }
                bool isOK = orgLogic.Update(entity);
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
            return orgLogic.GetMaxOrgCode(parentid);
        }


    }
}
