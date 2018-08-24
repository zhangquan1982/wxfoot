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
    class SysRoleAccess : SqlMapClientTemplate, ISysRoleAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("SysRoleMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SysRoleEntity Load(string code)
        {
            try
            {
                SysRoleEntity orgInfo = QueryForObject<SysRoleEntity>("SysRoleMap.Load", code);
                return orgInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string RoleIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = RoleIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("SysRoleMap.Delete", ids[i]);
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

        public bool Save(HujingModel.SysRoleEntity obj)
        {
            try
            {
                Insert("SysRoleMap.Save", obj);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(SysRoleEntity obj)
        {
            try
            {
                Update("SysRoleMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<SysRoleEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<SysRoleEntity>("SysRoleMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public string GetMaxRoleId()
        {
            try
            {
                object obj = QueryForObject<object>("SysRoleMap.GetMaxRoleId","");
                if ((obj == null) || (obj == DBNull.Value))
                {
                    return  "101";
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
    }
}
