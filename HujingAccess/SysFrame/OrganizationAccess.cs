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
    public class OrganizationAccess : SqlMapClientTemplate, IOrganizationAccess
    {
        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("OrganizationMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OrganizationEntity Load(string code)
        {
            try
            {
                OrganizationEntity orgInfo = QueryForObject<OrganizationEntity>("OrganizationMap.Load", code);
                return orgInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string OrgIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = OrgIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("OrganizationMap.Delete", ids[i]);
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

        public bool Save(OrganizationEntity obj)
        {
            try
            {
                Insert("OrganizationMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(OrganizationEntity entity)
        {
            try
            {
                Update("OrganizationMap.Update", entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<OrganizationEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<OrganizationEntity>("OrganizationMap.LoadAll", ht);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IList<CommonNameCount> LoadAllOrgBed(string Condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = Condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                ht["sortField"] = sortField;
                ht["sortOrder"] = sortOrder;
                return QueryForList<CommonNameCount>("OrganizationMap.LoadOrgBedList", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public string GetMaxOrgCode(string parentid)
        {//GetMaxOrgId
            try
            {
                string Condition = "";
                if (!string.IsNullOrEmpty(parentid))
                {
                    Condition = " and UpperId = '" + parentid + "'";
                }
                object obj = QueryForObject<object>("OrganizationMap.GetMaxOrgId", Condition);
                if ((obj == null) || (obj == DBNull.Value))
                {
                    if (!string.IsNullOrEmpty(parentid))
                    {
                        return parentid + "100";
                    }
                    else
                    {
                        return "100";
                    }
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
