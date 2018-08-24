using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HujingModel;
using IHujingLogic;
using HujingWeb.Filter;
using HujingCommon;

namespace HujingWeb.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        IUserInfoLogic usLogic;

        public UserController(IUserInfoLogic userlogic)
        {
            usLogic = userlogic;
        }

        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserIndex()
        {
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
                Condition += " and DepId= '" + upperid + "'";
            }
            else
            {
                Condition += " and (DepId is null or DepId = '')";
            }
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateDate";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "desc";
            }

            IList<UserInfoEntity> orgEntity = usLogic.LoadAll(Condition, pageSize, pageIndex, sortField, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("total", orgEntity.Count);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        public ActionResult GetNurseUser(string UserName)
        {
            string Condition = " and depId like '%10001101%'  and UserName like '%" + UserName + "%'";
            IList<UserInfoEntity> orgEntity = usLogic.LoadAll(Condition, 10, 1, "CreateDate", "desc");
            return Json(orgEntity);
        }


        public ActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public JsonResult Save(UserInfoEntity newObj)
        {
            JsonResult result = new JsonResult();
            try
            {
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

                newObj.UserId = GetMaxUserId();
                Random rad = new Random();
                string numString = rad.Next(100, 999).ToString();
                string CardId = newObj.UserId + numString;
                newObj.CardId = CardId;
                newObj.LoginName = newObj.UserId;
                newObj.Flag = false;
                newObj.Password = StringCipherCls.EncryptDES("654321", StringCipherCls.keyIn);
                newObj.CreateDate = DateTime.Now;
                newObj.CreateUser = strUserId;
                newObj.DepId = newObj.DepId;
                newObj.RoleType = "";
                newObj.UpdateDate = DateTime.Now;
                newObj.RoleType = "0";
                newObj.CreateDate = DateTime.Now;
                newObj.CreateUser = strUserId;
                newObj.UpdateDate = DateTime.Now;
                newObj.UpdateUser = strUserId;

                // 生成卡号。
                UserCardEntity cardEntity = new UserCardEntity();
                cardEntity.CardId = CardId;
                cardEntity.Flag = "0";
                cardEntity.UserId = newObj.UserId;
                cardEntity.CreateDate = DateTime.Now;
                cardEntity.CreateUser = strUserId;
                cardEntity.UpdateDate = DateTime.Now;
                cardEntity.UpdateUser = strUserId;

                bool isOK = usLogic.SaveUserCard(newObj, cardEntity);
                return Json(isOK);
            }
            catch
            {
                return Json(false);
            }
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Edit(string userid)
        {
            if (!string.IsNullOrEmpty(userid))
            {
                UserInfoEntity entity = usLogic.Load(userid);
                return View(entity);
            }
            return View(new OrganizationEntity());
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public ActionResult Update(UserInfoEntity entity)
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            try
            {
                UserInfoEntity userOld = usLogic.Load(entity.UserId);

                userOld.UserName = entity.UserName;
                userOld.UpdateDate = System.DateTime.Now;
                userOld.UpdateUser = strUserId;
                userOld.Address = entity.Address;
                userOld.InputStr = entity.InputStr;
                userOld.Address = entity.Address;
                userOld.Phone = entity.Phone;
                userOld.Mobile = entity.Mobile;
                userOld.Sex = entity.Sex;
                userOld.BirthDate = entity.BirthDate;
                userOld.Email = entity.Email;
                userOld.Memo = entity.Memo;
                userOld.BirthDate = entity.BirthDate;
                userOld.IdentyCard = entity.IdentyCard;

                bool isOK = usLogic.Update(userOld);
                return Json(isOK);
            }
            catch (Exception ex)
            {
                return Json("no");
            }

        }

        public ActionResult Delete(string UserIds)
        {
            bool isOk = usLogic.Delete(UserIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }

        public ActionResult ReSetPwd(string UserIds)
        {
            string userid = UserIds;
            if (string.IsNullOrEmpty(UserIds))
            {
                return Json("no");
            }
            UserInfoEntity usermodel = usLogic.Load(userid);
            string newpasswod = StringCipherCls.EncryptDES("654321", StringCipherCls.keyIn);
            usermodel.Password = newpasswod;
            usermodel.UpdateDate = DateTime.Now;
            usermodel.UpdateUser = usermodel.UserId;
            bool isok = usLogic.UpdatePwd(usermodel);
            string result = (isok == true ? "ok" : "no");
            return Json(result);
        }

        private string GetMaxUserId()
        {
            return usLogic.GetMaxUserId();
        }

        public ActionResult UserCheck()
        {
            return View();
        }

        public ActionResult CheckUser(string Ids)
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;

            bool isok = usLogic.CheckUser(Ids, strUserId);
            return Json(isok);
        }

        //public ActionResult GetUserSelect(string input)
        //{
        //    string Condition = " and 1=1";
        //    if (!string.IsNullOrEmpty(input))
        //    {
        //        Condition += " and ( (UserName like '%" + input + "%') or ( UserId like  '%" + input + "%')) ";
        //    }
        //    else
        //    {
        //        Condition += "and 1=2";
        //    }

        //    //IList<UserInfoEntity> personVisit = userLogic(Condition, 10, 1, "CreateDate", "desc");

        //    return Json(personVisit, JsonRequestBehavior.AllowGet);
        //}

    }
}
