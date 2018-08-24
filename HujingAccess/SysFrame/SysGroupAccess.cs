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
    class SysGroupAccess : SqlMapClientTemplate, ISysGroupAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("SysGroupMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SysGroupEntity Load(string code)
        {
            try
            {
                SysGroupEntity orgInfo = QueryForObject<SysGroupEntity>("SysGroupMap.Load", code);
                return orgInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string GroupIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = GroupIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("SysGroupMap.Delete", ids[i]);
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


        public bool Save(HujingModel.SysGroupEntity obj)
        {
            try
            {
                Insert("SysGroupMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool SaveSysOrgGroup(HujingModel.SysOrgGroupEntity obj)
        {
            try
            {
                Insert("SysOrgGroupMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

  

        public bool Update(SysGroupEntity obj)
        {
            try
            {
                Update("SysGroupMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<SysGroupEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<SysGroupEntity>("SysGroupMap.LoadAll", ht);
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
                object obj = QueryForObject<object>("SysGroupMap.GetMaxRoleId", "");
                if ((obj == null) || (obj == DBNull.Value))
                {
                    return "101";
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

        /// <summary>
        /// 根据用户ID获取模块
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IList<SysGroupEntity> LoadGroupListByUserId(string UserId)
        {
            try
            {
                return QueryForList<SysGroupEntity>("SysGroupMap.LoadGroupListByUserId", UserId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SysOrgGroupEntity LoadSysGroup(string orgid, string groupid)
        {
            try
            {
                SysOrgGroupEntity orgGroup = new SysOrgGroupEntity();
                orgGroup.OrgId = orgid;
                orgGroup.GroupID = groupid;
                SysOrgGroupEntity orgInfo = QueryForObject<SysOrgGroupEntity>("SysOrgGroupMap.Load", orgGroup);
                return orgInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetSysOrgGroupCount(string Condition)
        {
            try
            {
                return QueryForObject<int>("SysOrgGroupMap.Count", Condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<SysGroupEntity> LoadAllByParentIdAndUserId(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<SysGroupEntity>("SysGroupMap.LoadAllByParentIdAndUserId", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
