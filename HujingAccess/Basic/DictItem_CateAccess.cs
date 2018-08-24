using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using IHujingAccess;
using HujingModel;
using System.Collections;

namespace HujingAccess
{
    public class DictItem_CateAccess : SqlMapClientTemplate, IDictItem_CateAccess
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public string GetMaxCateId(string Condition)
        {
            try
            {
                object obj = QueryForObject<object>("DictItem_CateMap.GetMaxCateId", Condition);
                if ((obj == null) || (obj == DBNull.Value))
                {
                    return "1001";
                }
                else
                {
                    return (double.Parse(obj.ToString()) + 1).ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("DictItem_CateMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DictItem_CateEntity Load(string code)
        {
            try
            {
                DictItem_CateEntity cateEntity = QueryForObject<DictItem_CateEntity>("DictItem_CateMap.Load", code);
                return cateEntity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<DictItem_CateEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                ht["OrderBy"] = OrderBy;
                return QueryForList<DictItem_CateEntity>("DictItem_CateMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(DictItem_CateEntity obj)
        {
            try
            {
                Insert("DictItem_CateMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DictItem_CateEntity obj)
        {
            try
            {
                Update("DictItem_CateMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(string CateIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = CateIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("DictItem_CateMap.Delete", ids[i]);
                    }
                }

                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }

    }
}
