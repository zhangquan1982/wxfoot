using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHujingLogic;
using HujingModel;
using System.Collections;
using Newtonsoft.Json;
using HujingWeb.Filter;

namespace HujingWeb.Controllers
{
    public class DictItemCateController : Controller
    {
        IDictItem_CateLogic catelogic;

        /// <summary>
        /// 功能：项目类别
        /// 日期：2016-2-1
        /// KEY:322332FFFAA
        /// </summary>
        /// <param name="logic"></param>
        public DictItemCateController(IDictItem_CateLogic logic)
        {
            catelogic = logic;
        }


        // GET: /DictCate/
        [LoginValidateAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }


        public ActionResult Edit(string cateid)
        {
            DictItem_CateEntity entity = new DictItem_CateEntity();
            if (!string.IsNullOrEmpty(cateid))
            {
                entity.CateId = cateid;
                entity = catelogic.Load(cateid);
            }
            return View(entity);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList(string upperid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            string Condition = " and 1=1";

            pageIndex = pageIndex + 1;

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
                sortOrder = "CateId";
            }

            IList<DictItem_CateEntity> orgEntity = catelogic.LoadAll(Condition, pageSize, pageIndex, sortOrder);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = catelogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }
        public ActionResult GetListByParent(string pName)
        {
            string Condition = "";
            if (string.IsNullOrEmpty(pName))
            {
                Condition += " and 1=2";
            }
            else
            {
                Condition += " and (CateName = '"+ pName + "')";
            }

            IList<DictItem_CateEntity> cateEntity = catelogic.LoadAll(Condition, 11, 1, "CateId");
            string uppid = "";
            if( (cateEntity != null ) && (cateEntity.Count>0))
            {
                uppid = cateEntity[0].CateId;
            }

            IList<DictItem_CateEntity> cateList = new List<DictItem_CateEntity>();
            if (!string.IsNullOrEmpty(uppid))
            {
                Condition = " and UpperId = '"+ uppid + "'";
                cateList = catelogic.LoadAll(Condition, 333, 1, "CateId");
                return Json(cateList,JsonRequestBehavior.AllowGet);
            }
            else
            {
                cateList = catelogic.LoadAll(" and 1=2", 333, 1, "CateId");
                return Json(cateList, JsonRequestBehavior.AllowGet);
            }
        }





        [HttpPost]
        public ActionResult GetNurseGrade()
        {
            string Condition = "and upperid = (select cateid from DictItem_Cate where catename = '护理等级')";
            IList<DictItem_CateEntity> items = catelogic.LoadAll(Condition, 100, 1, "createdate");
            return Json(items);
        }

        /// <summary>
        /// 功能：项目类别树加载
        /// 日期：2016-2-1
        /// KEY:322332FFFAA
        /// </summary>
        public ActionResult GetDictCateTree()
        {
            string Condition = " and 1=1";
            IList<DictItem_CateEntity> orgEntity = catelogic.LoadAll(Condition, 10000, 1, "CateId");
            List<JsonTreeModel> nodes = new List<JsonTreeModel>();
            foreach (var item in orgEntity)
            {
                JsonTreeModel cnode = new JsonTreeModel();
                cnode.id = item.CateId;
                cnode.name = item.CateName;
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



        public JsonResult Save(DictItem_CateEntity cateEntity)
        {
            try
            {
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                cateEntity.CateId = strUserId + "-Cate-" + DateTime.Now.ToString("yyyyMMddHHmmss");  // catelogic.GetMaxCateId("");
                string Condition = " and CateName='" + cateEntity.CateName + "'";
                int itemCount = catelogic.Count(Condition);
                if (itemCount > 0)
                {
                    string json = JsonHelper.RtnJson("300", "此分类名称已经存在！");
                    return Json(json);
                }
                cateEntity.CreateDate = System.DateTime.Now;
                cateEntity.UpdateDate = cateEntity.CreateDate;
                cateEntity.CreateUser = strUserId;
                bool isOk = catelogic.Save(cateEntity);
                if (isOk == true)
                {
                    string json = JsonHelper.RtnJson("100", "保存成功！");
                    return Json(json);
                }
                else
                {
                    string json = JsonHelper.RtnJson("200", "保存失败！");
                    return Json(json);
                }
            }
            catch
            {
                string json = JsonHelper.RtnJson("200", "保存失败！");
                return Json(json);
            }
        }


        public JsonResult Update(DictItem_CateEntity cateEntity)
        {
            try
            {
                cateEntity.UpdateDate = System.DateTime.Now;
                cateEntity.CreateUser = "admin";
                bool isOk = catelogic.Update(cateEntity);
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


        public ActionResult Delete(string CateIds)
        {
            bool isOk = catelogic.Delete(CateIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }


    }
}
