using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HujingModel;
using IHujingLogic;
using System.Collections;
using HujingWeb.Filter;
using HujingCommon;

namespace HujingWeb.Controllers
{
    public class DictItemController : Controller
    {

        IDictItemLogic itemLogic;
        ICommonClassLogic commlogic;
        IDictCodeLogic dictCodeLogic;

        public IDictItem_CateLogic  itemCateLogic { get; set; }
        public DictItemController(IDictItemLogic logic, ICommonClassLogic cmLogic, IDictCodeLogic CodeLogic)
        {
            itemLogic = logic;
            commlogic = cmLogic;
            dictCodeLogic = CodeLogic;
        }
        //
        // GET: /DictItem/
        [LoginValidateAttribute]
        public ActionResult Index()
        {
            if (Request.Cookies["UserId"] == null)
            {
                ContentResult content = new ContentResult();
                content.Content = string.Format("<script language='javaScript' type='text/javaScript'>window.parent.window.location.href = '/Home/Login';</script>");
                return content;
            }
            return View();
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList(string upperid, int pageIndex, int pageSize, string sortField, string sortOrder)
        {
            string Condition = "";
            pageIndex = pageIndex + 1;
            if (!string.IsNullOrEmpty(upperid))
            {
                Condition += " and CateID= '" + upperid + "'";
            }
            else
            {
                Condition += " and (CateID is null or CateID = '')";
            }
            IList<DictItemEntity> orgEntity = itemLogic.LoadAll(Condition, pageSize, pageIndex, "ItemID");
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = itemLogic.Count(Condition);
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        [LoginValidateAttribute]
        public JsonResult Save(IList<DictItemEntity> entity)
        {
            try
            {
                string strCateId = HttpContext.ApplicationInstance.Context.Request.Params["CateId"].ToString();
                string strAddType = HttpContext.ApplicationInstance.Context.Request.Params["addType"].ToString();
                string olditemid = HttpContext.ApplicationInstance.Context.Request.Params["ItemId"].ToString();
                string strUserId = HttpContext.ApplicationInstance.Context.Request.Cookies["UserId"].Value;
                string Condition = "";
                Hashtable dt = new Hashtable();

                foreach (DictItemEntity item in entity)
                {
                    if (dt.Contains(item.ItemName))
                    {
                        string json = JsonHelper.RtnJson("300", item.ItemName + "已经存在！");
                        return Json(json);
                    }
                    else
                    {
                        dt.Add(item.ItemName, item.ItemName);
                    }

                    if (strAddType == "Add")
                    {
                        Condition += " and itemname='" + item.ItemName + "'";
                    }
                    else
                    {
                        Condition = " and itemid != '" + olditemid + "' and itemname='" + item.ItemName + "'";
                    }
                    int itemCount = itemLogic.Count(Condition);
                    if (itemCount > 0)
                    {
                        string json = JsonHelper.RtnJson("300", item.ItemName + "已经存在！");
                        return Json(json);
                    }
                }
     
                for (int i = 0; i < entity.Count; i++)
                {
                    if (strAddType == "Add")
                    {
                        entity[i].ItemID = strUserId + "-ItemId-" + DateTime.Now.ToString("yyMMddHHmmssfff") + i.ToString();
                    }
      
                    entity[i].CateID = strCateId;
                    entity[i].CreateDate = DateTime.Now;
                    entity[i].CreateUser = strUserId;
                    DictCodeEntity codeEntity = new DictCodeEntity();
                    codeEntity.CodeTypeId = DictCodeTypeClass.UnitType;
                    codeEntity.CodeId = entity[i].UnitTypeId;
                    DictCodeEntity entity2 = dictCodeLogic.Load(codeEntity);
                    if (entity2 != null)
                    {
                        entity[i].UnitName = entity2.CodeName;
                    }
                    //entity[i].UnitName = entity[i].UnitTypeId;
                }

                bool isOk = false;
                if (strAddType == "Add")
                {
                    isOk = itemLogic.SaveList(entity);
                }
                else
                {
                    //if (entity[0].ItemID != olditemid)
                    //{
                    //    itemLogic.Delete(olditemid);
                    //    isOk = itemLogic.SaveList(entity);
                    //}
                    //else
                    //{
                        entity[0].UpdateDate = DateTime.Now;
                        entity[0].UpdateUser = strUserId;
                        isOk = itemLogic.Update(entity[0]);
                    //}
                }

                if (isOk == true)
                {
                    string strjson = JsonHelper.RtnJson("100", "");
                    return Json(strjson);
                }
                else
                {
                    string strjson = JsonHelper.RtnJson("300", "保存失败");
                    return Json(strjson);
                }
            }
            catch (Exception ex)
            {
                string strjson = JsonHelper.RtnJson("300", ex.Message);
                return Json(strjson);
            }
        }


        public ActionResult Delete(string ItemIds)
        {
            bool isOk = itemLogic.Delete(ItemIds);
            string result = (isOk == true ? "ok" : "no");
            return Json(result);
        }

        public ActionResult GetUnitType()
        {
            IList<DictCodeEntity> codList = new List<DictCodeEntity>();
            codList = commlogic.GetDictCodeList(DictCodeTypeClass.UnitType);
            return Json(codList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetItemListByFloor(string floorid)
        {
            IList<DictItemEntity> orgEntity = itemLogic.LoadAllByFloorId(floorid);
            IDictionary<string, object> dic = new Dictionary<string, object>();
            int total = orgEntity.Count();
            dic.Add("total", total);
            dic.Add("data", orgEntity);
            return Json(dic);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDictItemList(string inputStr, string typename)
        {
            string Condition = "";
            string catetypeid = "";
            //if (!string.IsNullOrEmpty(typename))
            //{
            //    Condition += " and CateName == '%" + typename + "%'";
            //    IList<DictItem_CateEntity> cateType = itemCateLogic.LoadAll(Condition, 10, 1, "CreateDate");
            //    if ((cateType != null) && (cateType.Count > 0))
            //    {
            //        catetypeid = cateType[0].CateId;
            //    }
            //}


            Condition = "";
            if (!string.IsNullOrEmpty(catetypeid))
            {
                Condition += " and CateID = '" + catetypeid + "'";
            }
            if (!string.IsNullOrEmpty(inputStr))
            {
                Condition += " and ((InputStr like '%" + inputStr + "%') or (itemname like '%"+ inputStr + "%'))";
            }


            IList<DictItemEntity> itemsList = itemLogic.LoadAll(Condition, 10, 1, "ItemName");

            return Json(itemsList);
        }


        public ActionResult GetDictItem_CateList(string codeType)
        {
            IList<DictItem_CateEntity> itemList = itemCateLogic.LoadAll("", 11, 1, "CateID");
            return Json(itemList, JsonRequestBehavior.AllowGet);
        }
    }
}
