using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HujingModel;
using System.Web.Script.Serialization;
using System.Collections;
using IHujingLogic;
using HujingWeb.Filter;

namespace HujingWeb.Controllers
{
    public class DictCodeController : Controller
    {
        IDictCodeLogic codeLogic;
        public DictCodeController(IDictCodeLogic logic)
        {
            codeLogic = logic;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 功能：类别
        /// 日期：add by 2015-12-1
        /// key: 423211xxxyyy
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeAdd()
        {
            return View();
        }



        public ActionResult Add()
        {
            return View();
        }


        public ActionResult Edit(string codetypeid, string codeid)
        {
            if (!string.IsNullOrEmpty(codetypeid))
            {
                DictCodeEntity entityLoad = new DictCodeEntity();
                entityLoad.CodeTypeId = codetypeid;
                entityLoad.CodeId = codeid;
                DictCodeEntity entity = codeLogic.Load(entityLoad);
                return View(entity);
            }
            return View(new DictCodeEntity());
        }


        /// <summary>
        /// 功能：类别集合
        /// 日期：add by 2015-12-1
        /// key: 423211xxxyyy
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTypeList()
        {
            IList<DictCodeEntity> codeEntity = codeLogic.LoadAll(" and codeid='000' ", 10000, 1, "CodeTypeId");
            List<JsonTreeModel> nodes = new List<JsonTreeModel>();
            foreach (var item in codeEntity)
            {
                JsonTreeModel cnode = new JsonTreeModel();
                cnode.id = item.CodeTypeId;
                cnode.name = item.CodeTypeName;
                cnode.pid = "";
                cnode.expanded = true;
                nodes.Add(cnode);
            }
            return Json(nodes);
        }

        public ActionResult GetList(string CodeTypeId, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            pageIndex = pageIndex + 1;
            string Condition = " and CodeTypeId ='" + CodeTypeId + "' and codeid <> '000' ";
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "CodeId ";
            }
            IList<DictCodeEntity> roomEntity = codeLogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int count = codeLogic.Count(Condition);
            dic.Add("total", count);
            dic.Add("data", roomEntity);
            return Json(dic);
        }


        /// <summary>
        /// 功能：类别保存
        /// 日期：add by 2015-12-1
        /// key: 423211xabcyyy
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeSave(string CodeTypeId, string CodeTypeName, string Memo)
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            DictCodeEntity enty = new DictCodeEntity();
            enty.CodeTypeId = CodeTypeId;
            enty.CodeTypeName = CodeTypeName;
            enty.Memo = Memo;
            enty.CodeId = "000";
            enty.CodeName = "";
            enty.CreateDate = DateTime.Now;
            enty.CreateUser = strUserId;
            bool save = codeLogic.Save(enty);
            if (save == true)
            {
                return Json("ok");
            }
            else
            {
                return Json("no");
            }
        }


        /// <summary>
        /// 功能：字典保存
        /// 日期：add by 2015-12-22
        /// key: 423214xabcyyy
        /// <param name="CodeTypeId"></param>
        /// <param name="CodeTypeName"></param>
        /// <param name="CodeId"></param>
        /// <param name="CodeName"></param>
        /// <param name="Memo"></param>
        /// <returns></returns>
        public ActionResult Save(string CodeTypeId, string CodeTypeName, string CodeId, string CodeName, string Memo)
        {
            string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
            DictCodeEntity enty = new DictCodeEntity();
            enty.CreateUser = strUserId;
            enty.CodeTypeId = CodeTypeId;
            enty.CodeTypeName = CodeTypeName;
            enty.Memo = Memo;
            enty.CodeId = CodeId;
            enty.CodeName = CodeName;
            enty.CreateDate = DateTime.Now;
            enty.Flag = false;
            bool save = codeLogic.Save(enty);
            if (save == true)
            {
                return Json("ok");
            }
            else
            {
                return Json("no");
            }
        }

        public ActionResult Update(DictCodeEntity dictCode)
        {
            bool save = codeLogic.Update(dictCode);
            if (save == true)
            {
                return Json("ok");
            }
            else
            {
                return Json("no");
            }
        }


        public ActionResult Delete(string CodeTypeId, string CodeId)
        {
            DictCodeEntity entiy = new DictCodeEntity();
            entiy.CodeTypeId = CodeTypeId;
            entiy.CodeId = CodeId;
            bool isOk = codeLogic.Delete(entiy);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }


        public ActionResult GetCommonDictCode(string codeType)
        {
            IList<DictCodeEntity> codList = new List<DictCodeEntity>();

           string  Condition = " and codeid <> '000'  and codetypeid = '" + codeType + "'";

            codList = codeLogic.LoadAll(Condition,99,1, "codeid");
            return Json(codList, JsonRequestBehavior.AllowGet);
        }
    }
}
