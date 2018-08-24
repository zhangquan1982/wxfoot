using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHujingLogic;
using HujingWeb.Models;
using HujingModel;
using System.Text;
using HujingWeb.Filter;
using HujingCommon;

namespace HujingWeb.Common
{
    public class GetMenu : Controller
    {
        public ISysGroupLogic IgroupLogic { get; set; }
        public IUserInfoLogic IUserLogic { get; set; }

        public IList<SysGroupEntity> GetSysGroup()
        {
            try
            {
                if (HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"] != null)
                {
                    string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                    string LoginName = Request.Cookies["LoginName"].Value;
                    if (LoginName.ToUpper() == "ADMIN")
                    {

                        string Condition = " and orgid='888'";
                        IList<SysGroupEntity> groupList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                        if (groupList.Count > 0)
                        {

                            IList<SysGroupVM> groupvmList = new List<SysGroupVM>();
                            foreach (SysGroupEntity enty in groupList)
                            {
                                SysGroupVM groupvm = new SysGroupVM();
                                groupvm.id = enty.GroupID;
                                groupvm.text = enty.GroupName;
                                groupvm.iconCls = enty.IconCls;
                                groupvm.pid = enty.ParentID;
                                groupvm.url = enty.URL;
                                groupvm.iconPosition = "top";
                                groupvmList.Add(groupvm);
                            }

                            return groupList;
                        }

                    }
                    else
                    {
                        UserInfoEntity usermodel = IUserLogic.Load(LoginName);
                        IList<SysGroupEntity> groupList;
                        if ((usermodel != null) && (usermodel.RoleType == "1"))
                        {
                            groupList = IgroupLogic.LoadAll(" and orgid = '100' ", 1000, 1, "GroupID");
                        }
                        else
                        {
                            groupList = IgroupLogic.LoadGroupListByUserId(strUserId);
                        }


                        if (groupList.Count > 0)
                        {

                            IList<SysGroupVM> groupvmList = new List<SysGroupVM>();
                            foreach (SysGroupEntity enty in groupList)
                            {
                                SysGroupVM groupvm = new SysGroupVM();
                                groupvm.id = enty.GroupID;
                                groupvm.text = enty.GroupName;
                                groupvm.iconCls = enty.IconCls;
                                groupvm.pid = enty.ParentID;
                                groupvm.url = enty.URL;
                                groupvm.iconPosition = "top";
                                groupvmList.Add(groupvm);
                            }

                            return groupList;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}