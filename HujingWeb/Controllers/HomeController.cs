

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
using IHujingLogic.Basic;
using HujingWeb.Common;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using HujingModel.Basic;
using System.Data;

namespace HujingWeb.Controllers
{
    public class HomeController : Controller
    {
        public ICheckCodeLogic checkLogic { get; set; }
        public IUserInfoLogic IUserLogic { get; set; }
        public ISysGroupLogic IgroupLogic { get; set; }

        public IOrganizationLogic orgLogic { get; set; }

        public IScheItemDateLogic schdateLogic { get; set; }


        public HomeController()
        {

        }

        [LoginValidateAttribute]
        public ActionResult Index()
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            string strUserName = HttpUtility.UrlDecode(HttpContext.ApplicationInstance.Request.Cookies["UserName"].Value.ToString(), Encoding.GetEncoding("UTF-8"));

            ViewBag.UserName = strUserName;
            return View();
        }

        public ActionResult OrgRegist()
        {
            return View();
        }

        public ActionResult Login(UserInfoModel model)
        {
            if (string.IsNullOrEmpty(model.LoginName))
            {
                return View(model);
            }
            else
            {
                string keyword = StringCipherCls.EncryptDES(model.Password, StringCipherCls.keyIn);
                UserInfoEntity usermodel = IUserLogic.Load(model.LoginName); //登录用户

                if ((usermodel != null) && (usermodel.Password == keyword))
                {
                    Response.Cookies["UserId"].Value = usermodel.UserId;
                    Response.Cookies["UserId"].Expires = System.DateTime.Now.AddHours(1);
                    //Response.Cookies["UserName"].Value = usermodel.UserName;
                    Response.Cookies["UserName"].Value = HttpUtility.UrlEncode(usermodel.UserName, Encoding.GetEncoding("UTF-8"));
                    Response.Cookies["UserName"].Expires = System.DateTime.Now.AddHours(1);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.Msg = "用户名密码错误！";
                    return View(model);
                    //return RedirectToAction("Login", "Home");
                }
            }
        }

        public ActionResult RegistWeiXin(UserInfoModel model)
        {
            //if (string.IsNullOrEmpty(model.Mobile))
            //{
            //    string NickName = "";
            //    if (!string.IsNullOrEmpty(model.NickName))
            //    {
            //        NickName = HttpUtility.UrlDecode(model.NickName, Encoding.GetEncoding("UTF-8"));
            //    }
            //    model.NickName = NickName;
            //    return View(model);
            //}
            //else
            //{
            //    UserInfoEntity usermodel = IUserLogic.LoadByMobile(model.Mobile); //登录用户
            //    if (usermodel != null)
            //    {
            //        model.Msg = "此手机号已注册，请用手机号+密码的方式登录后进入个人主页，自行重置密码；同时建议登录后扫码绑定微信，以实现免密码登录。如初始登录密码遗忘，或通过首页底部的“找回密码”功能，通过手机验证码找回密码。";
            //        return View(model);
            //    }
            //    string code = checkLogic.GetNewCode(model.Mobile);
            //    log.Writelog("GetNewCode" + code);
            //    log.Writelog("model.YZM" + model.YZM);
            //    if (code != model.YZM)
            //    {
            //        model.YZM = "";
            //        model.Msg = "短信验证码不正确！";
            //        return View(model);
            //    }
            //    Random rad = new Random();
            //    int Result = rad.Next(1001, 9999);
            //    UserInfoEntity entity = new UserInfoEntity();
            //    entity.UserId = GetMaxUserId();   // DateTime.Now.ToString("yyMMddHHmmssfff") + Result.ToString();
            //    entity.UserName = "";
            //    entity.Sex = int.Parse(model.Sex);
            //    entity.NickName = model.NickName;
            //    entity.OpenId = model.OpenId;
            //    if (string.IsNullOrEmpty(model.HeadImgUrl))
            //    {
            //        entity.HeadImgUrl = HujingCommon.DictCodeTypeClass.ImgNimin;
            //    }
            //    else
            //    {
            //        entity.HeadImgUrl = model.HeadImgUrl;
            //    }

            //    entity.Mobile = model.Mobile;
            //    entity.Flag = false;
            //    entity.Password = StringCipherCls.EncryptDES(model.Password, StringCipherCls.keyIn);
            //    entity.CreateDate = DateTime.Now;
            //    entity.RoleType = (int)UserRoleType.NormalUser;
            //    entity.CreateDate = DateTime.Now;

            //    bool isOK = IUserLogic.Save(entity);
            //    if (isOK == true)
            //    {
            //        Response.Cookies["UserId"].Value = entity.UserId.ToString();
            //        Response.Cookies["UserId"].Expires = System.DateTime.Now.AddHours(1);

            //        string strname = HttpUtility.UrlEncode(entity.NickName, Encoding.GetEncoding("UTF-8"));
            //        Response.Cookies["NickName"].Value = strname;
            //        Response.Cookies["NickName"].Expires = System.DateTime.Now.AddHours(1);

            //        return RedirectToAction("RegistEnd", "RegistNext");
            //    }
            //    else
            //    {
            //        model.Msg = "注册失败!";
            //        return View(model);
            //    }
            //}

            return Json(true);
        }





        public ActionResult SendMessage(string phoneNumber)
        {
            Random rad = new Random();
            //int num = rad.Next(1000, 9999);
            int num = 6666;
            CheckCodeEntity entity = new CheckCodeEntity();
            entity.Mobile = phoneNumber;
            entity.Code = num.ToString();
            entity.IPAddress = CommonClass.IPAddress();
            entity.CreateDate = DateTime.Now;
            entity.IsUse = "0";


            bool isok = checkLogic.Save(entity);
            SaveResult reust = new SaveResult();
            if (isok)
            {
                reust.status = 100;
                reust.msg = "success";
                return Json(reust, JsonRequestBehavior.AllowGet);
            }
            else
            {
                reust.status = 200;
                reust.msg = "failure";
                return Json(reust, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult submitUserInfo(string tel, string userCode, string code)
        {
            try
            {
                Logger.Info("userCode", "code:" + userCode);
                Logger.Info("tel", "tel:" + tel);
                Logger.Info("code", "code:" + code);
                UserInfoEntity usermodel = IUserLogic.Load(userCode); //登录用户
                JsonResult result = new JsonResult();
                if (usermodel == null)
                {
                    result.Data = new { status = 200, msg = "此工号和手机号不正确!", userid = "", cardCode = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                if (usermodel != null && (usermodel.Mobile != tel))
                {
                    result.Data = new { status = 200, msg = "此工号和手机号不正确!", userid = "", cardCode = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                var url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid=wx58b1bd1bc740a401&secret=6e08ad586e56b588443ae5d5e3fbd3a7&js_code={0}&grant_type=authorization_code", code);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                var response = request.GetResponse();
                var respStream = response.GetResponseStream();
                var reader = new StreamReader(respStream, Encoding.UTF8);
                string wxResult = reader.ReadToEnd();
                Logger.Info("wxResult", "wxResult:" + wxResult);
                //wxResult = @"session_key":"U + LFYy1NA0uIlNYGMT4koQ == ","openid":"oTnGZ5UjWwAcVmHbWtXNRSZEbKxo";
                var userWX = JsonConvert.DeserializeObject<WXUserInfo>(wxResult.ToString());
                if (!string.IsNullOrEmpty(userWX.openid))
                {
                    Logger.Info("userWX.openid", "userWX.openid:" + userWX.openid);

                    if (!string.IsNullOrEmpty(usermodel.OpenId) && (usermodel.OpenId != userWX.openid))
                    {
                        result.Data = new { status = 200, msg = "此手机号已被注册绑定，请联系管理员!", userid = "", cardCode = "" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }

                    usermodel.OpenId = userWX.openid;
                    usermodel.UpdateDate = DateTime.Now;
                    Logger.Info("OpenId", "usermodel.OpenId:" + userWX.openid);
                    bool isOK = IUserLogic.Update(usermodel);
                    Logger.Info("isOK", "IUserLogic.Update:" + isOK);
                    if (isOK == true)
                    {
                        result.Data = new { status = 100, msg = "注册成功", userid = usermodel.UserId, cardCode = usermodel.CardId };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        result.Data = new { status = 200, msg = "注册失败", userid = "", cardCode = "" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    result.Data = new { status = 200, msg = "注册失败", userid = "", cardCode = "" };
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message.ToString(), userid = "", cardCode = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RegisterPhone(string phoneNumber, string messageCode, string code)
        {
            try
            {
                Logger.Info("UserLogin", "code:" + code);
                Logger.Info("phoneNumber", "phoneNumber:" + phoneNumber);
                Logger.Info("messageCode", "messageCode:" + messageCode);
                UserInfoEntity usermodel = IUserLogic.LoadByMobile(phoneNumber); //登录用户
                JsonResult result = new JsonResult();
                if (usermodel != null)
                {
                    result.Data = new { status = 200, msg = "此手机号已注册", userid = "" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                var url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid=wx58b1bd1bc740a401&secret=6e08ad586e56b588443ae5d5e3fbd3a7&js_code={0}&grant_type=authorization_code", code);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                var response = request.GetResponse();
                var respStream = response.GetResponseStream();
                var reader = new StreamReader(respStream, Encoding.UTF8);
                string wxResult = reader.ReadToEnd();
                Logger.Info("wxResult", "wxResult:" + wxResult);
                //wxResult = @"session_key":"U + LFYy1NA0uIlNYGMT4koQ == ","openid":"oTnGZ5UjWwAcVmHbWtXNRSZEbKxo";
                var userWX = JsonConvert.DeserializeObject<WXUserInfo>(wxResult.ToString());
                if (!string.IsNullOrEmpty(userWX.openid))
                {
                    Logger.Info("userWX.openid", "userWX.openid:" + userWX.openid);
                    UserInfoEntity entity = new UserInfoEntity();
                    entity.OpenId = userWX.openid;
                    entity.UserId = GetMaxUserId();   // DateTime.Now.ToString("yyMMddHHmmssfff") + Result.ToString();
                    entity.UserName = "";
                    entity.Mobile = phoneNumber;
                    entity.Flag = false;
                    entity.Password = StringCipherCls.EncryptDES("666666", StringCipherCls.keyIn);
                    entity.CreateDate = DateTime.Now;
                    entity.RoleType = "0";
                    entity.UpdateDate = DateTime.Now;
                    entity.BirthDate = DateTime.Now;
                    Random rdm = new Random();
                    entity.CardId = entity.UserId + rdm.Next(1000, 9999);
                    entity.CreateDate = DateTime.Now;

                    bool isOK = IUserLogic.Save(entity);
                    if (isOK == true)
                    {
                        result.Data = new { status = 100, msg = "注册成功", userid = entity.UserId, carid = entity.CardId };
                    }
                    else
                    {
                        result.Data = new { status = 200, msg = "注册失败", userid = "" };
                    }
                }
                else
                {
                    result.Data = new { status = 200, msg = "注册失败", userid = "" };
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message.ToString(), userid = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        ///add by jy
        ///南京瑚景软件有限公司版权所有
        ///add by 2017-3-14
        private string GetMaxUserId()
        {
            return IUserLogic.GetMaxUserId();
        }


        public ActionResult UserLogin(string code)
        {
            try
            {
                Logger.Info("UserLogin", "code:" + code);
                var url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid=wx58b1bd1bc740a401&secret=6e08ad586e56b588443ae5d5e3fbd3a7&js_code={0}&grant_type=authorization_code", code);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                var response = request.GetResponse();
                var respStream = response.GetResponseStream();
                var reader = new StreamReader(respStream, Encoding.UTF8);
                string wxresult = reader.ReadToEnd();
                Logger.Info("wxresult", "wxresult:" + wxresult);
                var userWX = JsonConvert.DeserializeObject<WXUserInfo>(wxresult);
                JsonResult result = new JsonResult();
                if (!string.IsNullOrEmpty(userWX.openid))
                {
                    Logger.Info("UserLogin", "userWX.openid:" + userWX.openid);
                    IList<UserInfoEntity> userList = IUserLogic.LoadAll(string.Format(" and openid = '{0}'", userWX.openid), 999, 1, "UserId", "");
                    if (userList.Count > 0)
                    {
                        result.Data = new { status = 100, msg = "success", userid = userList[0].UserId, cardid = userList[0].CardId };
                    }
                    else
                    {
                        result.Data = new { status = 100, msg = "此openid没有对应的用户", userid = "" };
                    }
                }
                else
                {
                    result.Data = new { status = 200, msg = "未找到openid", userid = "" };

                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult();
                result.Data = new { status = 200, msg = ex.Message.ToString(), userid = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }


            //string keyword = StringCipherCls.EncryptDES(pwd, StringCipherCls.keyIn);
            //UserInfoEntity usermodel = IUserLogic.Load(userid); //登录用户
            //SaveResult reust = new SaveResult();

            //if ((usermodel != null) && (usermodel.Password == keyword))
            //{
            //    reust.status = 100;
            //    reust.msg = "success";
            //    return Json(reust, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    reust.status = 200;
            //    reust.msg = "failure";
            //    return Json(reust, JsonRequestBehavior.AllowGet);
            //}
        }

        //public ActionResult UserLogin(string userid, string pwd)
        //{
        //    string keyword = StringCipherCls.EncryptDES(pwd, StringCipherCls.keyIn);
        //    UserInfoEntity usermodel = IUserLogic.Load(userid); //登录用户
        //    SaveResult reust = new SaveResult();

        //    if ((usermodel != null) && (usermodel.Password == keyword))
        //    {
        //        reust.status = 100;
        //        reust.msg = "success";
        //        return Json(reust, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        reust.status = 200;
        //        reust.msg = "failure";
        //        return Json(reust, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult First()
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

            ViewBag.UserId = strUserId;
            return View();
        }

        public ActionResult Top()
        {
            return View();
        }

        public PartialViewResult TopYL()
        {
            string strUserName = HttpUtility.UrlDecode(HttpContext.ApplicationInstance.Request.Cookies["UserName"].Value.ToString(), Encoding.GetEncoding("UTF-8"));
            string strOrgId = HttpContext.ApplicationInstance.Request.Cookies["OrgId"].Value.ToString();
            OrganizationEntity entity = orgLogic.Load(strOrgId);
            if (entity != null)
            {
                //ViewBag.ImgUrl = entity.ImgUrl;
                ViewBag.OrgName = entity.OrgName + "养老云平台";
            }

            ViewBag.UserName = strUserName;
            return PartialView();
        }

        public ActionResult LoginOn(UserInfoModel model)
        {
            return View();
        }

        public ActionResult ChangePwd()
        {
            return View();
        }
        public ActionResult SavePwd(string OldPwd, string NewPwd)
        {
            try
            {
                string loginname = HttpContext.ApplicationInstance.Context.Request.Cookies["LoginName"].Value;
                string keyword = StringCipherCls.EncryptDES(OldPwd, StringCipherCls.keyIn);
                UserInfoEntity usermodel = IUserLogic.Load(loginname); //修改密码
                if (usermodel == null)
                {
                    string json = JsonHelper.RtnJson("300", "此用户不存在！");
                    return Json(json);
                }
                if (usermodel.Password != keyword)
                {
                    string json = JsonHelper.RtnJson("300", "旧密码不正确！");
                    return Json(json);
                }
                else
                {
                    string newpasswod = StringCipherCls.EncryptDES(NewPwd, StringCipherCls.keyIn);
                    usermodel.Password = newpasswod;
                    usermodel.UpdateDate = DateTime.Now;
                    usermodel.UpdateUser = usermodel.UserId;
                    bool isok = IUserLogic.UpdatePwd(usermodel);
                    if (isok == true)
                    {
                        string strjson = JsonHelper.RtnJson("100", "密码修改成功！");
                        return Json(strjson);
                    }
                    else
                    {
                        string strjson = JsonHelper.RtnJson("300", "密码修改失败！");
                        return Json(strjson);
                    }

                }
            }
            catch (Exception ex)
            {
                string strjson = JsonHelper.RtnJson("300", ex.Message);
                return Json(strjson);
            }
        }


        public PartialViewResult Menu()
        {

            if (HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"] != null)
            {
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

                string Condition = " and ( ParentID is null or ParentID='') ";
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
                        groupvm.HisType = enty.HisType;
                        groupvm.iconPosition = "top";

                        Condition = " and ParentID = '" + enty.GroupID + "'";
                        IList<SysGroupEntity> itemList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                        groupvm.subList = new List<SysGroupEntity>();
                        groupvm.subList = itemList;
                        groupvmList.Add(groupvm);
                    }

                    return PartialView(new MenuModel { Menus = groupvmList });


                }
            }
            return null;
        }

        public PartialViewResult MenuOld()
        {

            if (HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"] != null)
            {
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
                string LoginName = Request.Cookies["LoginName"].Value;
                if (LoginName.ToUpper() == "ADMIN")
                {
                    #region  管理员
                    string Condition = " and orgid='888' and ( ParentID is null or ParentID='') ";
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
                            groupvm.HisType = enty.HisType;
                            groupvm.iconPosition = "top";

                            Condition = " and ParentID = '" + enty.GroupID + "'";
                            IList<SysGroupEntity> itemList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                            groupvm.subList = new List<SysGroupEntity>();
                            groupvm.subList = itemList;
                            groupvmList.Add(groupvm);
                        }

                        return PartialView(new MenuModel { Menus = groupvmList });


                    }
                    #endregion
                }
                else
                {
                    #region
                    UserInfoEntity usermodel = IUserLogic.Load(LoginName);
                    IList<SysGroupEntity> groupList;
                    string Condition = " and orgid='" + strOrgId + "' and ( ParentID is null or ParentID='') ";
                    if ((usermodel != null) && (usermodel.RoleType == "1"))
                    {
                        groupList = IgroupLogic.LoadAll(" and orgid = '100' and ( ParentID is null or ParentID='') ", 1000, 1, "GroupID");
                    }
                    else
                    {
                        if (strUserId != "3001")
                        {
                            groupList = IgroupLogic.LoadGroupListByUserId(strUserId);
                        }
                        else
                        {
                            groupList = IgroupLogic.LoadGroupListByUserId(strUserId);
                        }
                    }
                    //groupList = IgroupLogic.LoadAll(Condition, 1000, 1, "GroupID");
                    List<SysGroupEntity> groupListNew = new List<SysGroupEntity>();
                    if (groupList.Count > 0)
                    {
                        foreach (SysGroupEntity enty in groupList)
                        {
                            if (string.IsNullOrEmpty(enty.ParentID))
                            {
                                groupListNew.Add(enty);
                            }
                        }
                    }


                    if (groupListNew.Count > 0)
                    {
                        IList<SysGroupVM> groupvmList = new List<SysGroupVM>();
                        foreach (SysGroupEntity enty in groupListNew)
                        {

                            SysGroupVM groupvm = new SysGroupVM();
                            groupvm.id = enty.GroupID;
                            groupvm.text = enty.GroupName;
                            groupvm.iconCls = enty.IconCls;
                            groupvm.pid = enty.ParentID;
                            groupvm.url = enty.URL;
                            groupvm.HisType = enty.HisType;
                            groupvm.iconPosition = "top";

                            Condition = " and ParentID = '" + enty.GroupID + "'";
                            //IList<SysGroupEntity> itemList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                            if (strUserId != "3001")
                            {
                                Condition = " and UserInfo.userid = '" + strUserId + "' and SysGroup.parentid = '" + enty.GroupID + "'";
                                IList<SysGroupEntity> itemList = IgroupLogic.LoadAllByParentIdAndUserId(Condition, 1000, 1, "groupid");
                                groupvm.subList = new List<SysGroupEntity>();
                                groupvm.subList = itemList;
                                groupvmList.Add(groupvm);
                            }
                            else
                            {
                                IList<SysGroupEntity> itemList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                                groupvm.subList = new List<SysGroupEntity>();
                                groupvm.subList = itemList;
                                groupvmList.Add(groupvm);
                            }

                        }

                        return PartialView(new MenuModel { Menus = groupvmList });
                    }
                    #endregion
                }
            }
            return null;
        }

        public PartialViewResult MenuHis()
        {

            if (HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"] != null)
            {
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                string strOrgId = HttpContext.ApplicationInstance.Context.Request.Cookies["OrgId"].Value;
                string LoginName = Request.Cookies["LoginName"].Value;
                if (LoginName.ToUpper() == "ADMIN")
                {
                    #region  管理员
                    string Condition = " and orgid='888' and ( ParentID is null or ParentID='') ";
                    IList<SysGroupEntity> groupList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                    if (groupList.Count > 0)
                    {

                        IList<SysGroupVM> groupvmList = new List<SysGroupVM>();
                        foreach (SysGroupEntity enty in groupList)
                        {
                            if (enty.HisType != "1")
                            {
                                continue;
                            }
                            SysGroupVM groupvm = new SysGroupVM();
                            groupvm.id = enty.GroupID;
                            groupvm.text = enty.GroupName;
                            groupvm.iconCls = enty.IconCls;
                            groupvm.pid = enty.ParentID;
                            groupvm.url = enty.URL;
                            groupvm.HisType = enty.HisType;
                            groupvm.iconPosition = "top";

                            Condition = " and ParentID = '" + enty.GroupID + "'";
                            IList<SysGroupEntity> itemList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                            groupvm.subList = new List<SysGroupEntity>();
                            groupvm.subList = itemList;
                            groupvmList.Add(groupvm);
                        }

                        return PartialView(new MenuModel { Menus = groupvmList });


                    }
                    #endregion
                }
                else
                {
                    #region
                    UserInfoEntity usermodel = IUserLogic.Load(LoginName);
                    IList<SysGroupEntity> groupList;
                    string Condition = " and orgid='" + strOrgId + "' and ( ParentID is null or ParentID='') ";
                    if ((usermodel != null) && (usermodel.RoleType == "1"))
                    {
                        groupList = IgroupLogic.LoadAll(" and orgid = '100' and ( ParentID is null or ParentID='') ", 1000, 1, "GroupID");
                    }
                    else
                    {
                        groupList = IgroupLogic.LoadGroupListByUserId(strUserId);
                    }
                    //groupList = IgroupLogic.LoadAll(Condition, 1000, 1, "GroupID");

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
                            groupvm.HisType = enty.HisType;
                            groupvm.iconPosition = "top";

                            Condition = " and ParentID = '" + enty.GroupID + "'";
                            IList<SysGroupEntity> itemList = IgroupLogic.LoadAll(Condition, 1000, 1, "groupid");
                            groupvm.subList = new List<SysGroupEntity>();
                            groupvm.subList = itemList;
                            groupvmList.Add(groupvm);
                        }

                        return PartialView(new MenuModel { Menus = groupvmList });
                    }
                    #endregion
                }
            }
            return null;
        }

        public ActionResult GetSysGroup()
        {
            try
            {
                if (HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"] != null)
                {
                    string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                    string LoginName = Request.Cookies["LoginName"].Value;
                    if (LoginName.ToUpper() == "ADMIN")
                    {
                        //IList<SysGroupVM> groupvmList = new List<SysGroupVM>();
                        //SysGroupVM groupvm = new SysGroupVM();
                        //groupvm.id = "A00100B";
                        //groupvm.text = "超级管理员";
                        //groupvm.iconCls = "icon-system";
                        //groupvmList.Add(groupvm);


                        //SysGroupVM groupvmItem = new SysGroupVM();
                        //groupvmItem.id = "A00100B0-01";
                        //groupvmItem.text = "区域管理";
                        //groupvmItem.iconCls = "icon-system";
                        //groupvmItem.pid = "A00100B";
                        //groupvmItem.url = "/SysFrame/RegionArea/Index";
                        //groupvmItem.iconPosition = "top";
                        //groupvmList.Add(groupvmItem);

                        //groupvm = new SysGroupVM();
                        //groupvm.id = "A00100B0-02";
                        //groupvm.text = "机构管理";
                        //groupvm.iconCls = "icon-system";
                        //groupvm.pid = "A00100B";
                        //groupvm.url = "/SysFrame/Organization/Index";
                        //groupvm.iconPosition = "top";
                        //groupvmList.Add(groupvm);
                        //return Json(groupvmList, JsonRequestBehavior.AllowGet);

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

                            return Json(groupvmList, JsonRequestBehavior.AllowGet);
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

                            return Json(groupvmList, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }

                return Json("");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult getMenuWeek()
        {
            DateTime mondy = GetMondayDate(DateTime.Now);
            DateTime sundy = GetSundayDate(DateTime.Now);
            string Condition = " and ScheDate between '" + mondy.ToString("yyyy-MM-dd 00:00:00") + "' and '" + sundy.ToString("yyyy-MM-dd 23:59:59") + "' ";
            DataTable dtSche = schdateLogic.GetScheDateList(Condition);
            IList<ScheItemDateItemEntity> Schelist = new List<ScheItemDateItemEntity>();

            for (int irow = 0; irow < 7; irow++)
            {
                ScheItemDateItemEntity entity = new ScheItemDateItemEntity();
                entity.date = mondy.AddDays(irow).ToString("yyyy-MM-dd");
                entity.dateTime = mondy.AddDays(irow);
                Schelist.Add(entity);
            }

            foreach(var item in Schelist)
            {
                IList<FootType> foots = new List<FootType>();
                Condition = " and TypeCode='01' and ScheDate between '" + item.dateTime.ToString("yyyy-MM-dd 00:00:00") + "' and '" + item.dateTime.ToString("yyyy-MM-dd 23:59:59") + "' ";
                DataTable dtDayType = schdateLogic.GetScheDateListByDateAndType(Condition);
                FootType type01 = new FootType();
                type01.type = "早餐";
                List<string> lst01 = new List<string>();
                if (dtDayType != null && dtDayType.Rows.Count>0)
                {
                    foreach(DataRow row01 in dtDayType.Rows)
                    {
                        lst01.Add(row01["ItemName"].ToString());
                    }
                }
                type01.names = lst01;
                foots.Add(type01);

                FootType type02 = new FootType();
                List<string> lst02 = new List<string>();
                Condition = " and TypeCode='02' and ScheDate between '" + item.dateTime.ToString("yyyy-MM-dd 00:00:00") + "' and '" + item.dateTime.ToString("yyyy-MM-dd 23:59:59") + "' ";
                dtDayType = schdateLogic.GetScheDateListByDateAndType(Condition);
                type02.type = "午餐";
                if (dtDayType != null && dtDayType.Rows.Count > 0)
                {
                    foreach (DataRow row01 in dtDayType.Rows)
                    {
                        lst02.Add(row01["ItemName"].ToString());
                    }
                }
                type02.names = lst02;
                foots.Add(type02);

                FootType type03 = new FootType();
                List<string> lst03 = new List<string>();
                Condition = " and TypeCode='03' and ScheDate between '" + item.dateTime.ToString("yyyy-MM-dd 00:00:00") + "' and '" + item.dateTime.ToString("yyyy-MM-dd 23:59:59") + "' ";
                dtDayType = schdateLogic.GetScheDateListByDateAndType(Condition);
                type03.type = "晚餐";
                if (dtDayType != null && dtDayType.Rows.Count > 0)
                {
                    foreach (DataRow row01 in dtDayType.Rows)
                    {
                        lst03.Add(row01["ItemName"].ToString());
                    }
                }
                type03.names = lst03;
                foots.Add(type03);

                item.foots = foots;
            }

            JsonResult result = new JsonResult();

            result.Data = new { status = 100, msg = "success!", menus = Schelist, updateDate = DateTime.Now};

            return Json(result);
        }

        public DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }


        public DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }
    }
}
