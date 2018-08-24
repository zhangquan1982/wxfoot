using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingAccess;
using HujingModel;
using ICommonAccess;
using System.Collections;

namespace HujingAccess
{
    public class DictItemAccess : SqlMapClientTemplate, IDictItemAccess
    {

        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("DictItemMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DictItemEntity Load(string code)
        {
            try
            {
                DictItemEntity cateEntity = QueryForObject<DictItemEntity>("DictItemMap.Load", code);
                return cateEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<DictItemEntity> LoadAllByPacktypeId(string PackTypeId)
        {
            try
            {
                IList<DictItemEntity> cateEntity = QueryForList<DictItemEntity>("DictItemMap.LoadAllByPacktypeId", PackTypeId);
                return cateEntity;
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public IList<DictItemEntity> LoadAllByFloorId(string FloorId)
        {
            try
            {
                IList<DictItemEntity> cateEntity = QueryForList<DictItemEntity>("DictItemMap.LoadAllByFloorId", FloorId);
                return cateEntity;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public bool Delete(string ItemIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = ItemIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("DictItemMap.Delete", ids[i]);
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

        public bool Save(DictItemEntity obj)
        {
            try
            {
                Insert("DictItemMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveList(IList<DictItemEntity> list)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                foreach (DictItemEntity item in list)
                {
                    Insert("DictItemMap.Save", item);
                }
                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch(Exception ex)
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }

        public bool Update(HujingModel.DictItemEntity obj)
        {
            try
            {
                Update("DictItemMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<DictItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<DictItemEntity>("DictItemMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<DictItemEntity> LoadAllDictItemJoin(string Condition)
        {
            try
            {
                return QueryForList<DictItemEntity>("DictItemMap.LoadDictItemJoin", Condition);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
