using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;
using ICommonAccess;
using HujingAccess;
using System.Collections;


namespace WebHis.Access
{
    public class DepartmentAccess : SqlMapClientTemplate, IDepartmentAccess
    {

        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("DepartmentMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DepartmentEntity Load(string code)
        {
            try
            {
                DepartmentEntity depInfo = QueryForObject<DepartmentEntity>("DepartmentMap.Load", code);
                return depInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<DepartmentEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<DepartmentEntity>("DepartmentMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<DepartmentEntity> LoadNurseDep(string Condition)
        {
            try
            {
                return QueryForList<DepartmentEntity>("DepartmentMap.LoadNurseDep", Condition);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string obj)
        {
            try
            {

                if (obj != "")
                {
                    Delete("DepartmentMap.Delete", obj);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetMaxDepId(string parentid)
        {
            try
            {
                string Condition = "";
                if (!string.IsNullOrEmpty(parentid))
                {
                    Condition = " and UpperId = '" + parentid + "'";
                }
                else
                {
                    Condition = " and UpperId is null ";
                }
                object obj = QueryForObject<object>("DepartmentMap.GetMaxDepId", Condition);
                if ((obj == null) || (obj == DBNull.Value))
                {
                    if (!string.IsNullOrEmpty(parentid))
                    {
                        return parentid + "101";
                    }
                    else
                    {
                        return  "101";
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



        public bool Save(DepartmentEntity obj)
        {
            try
            {
                Insert("DepartmentMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DepartmentEntity obj)
        {
            try
            {
                Update("DepartmentMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
