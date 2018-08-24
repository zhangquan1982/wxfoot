using HujingModel;
using ICommonAccess;
using IHujingAccess.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.Basic
{
    class ScheItemDateAccess : SqlMapClientTemplate, IScheItemDateAccess
    {

        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("ScheItemDateMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ScheItemDateEntity Load(string code)
        {
            try
            {
                ScheItemDateEntity orgInfo = QueryForObject<ScheItemDateEntity>("ScheItemDateMap.Load", code);
                return orgInfo;
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
                Delete("ScheItemDateMap.Delete", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteScheItemDates(string SchIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = SchIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("ScheItemDateMap.Delete", ids[i]);
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

        public bool Save(ScheItemDateEntity obj)
        {
            try
            {
                Insert("ScheItemDateMap.Save", obj);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IList<ScheItemDateEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<ScheItemDateEntity>("ScheItemDateMap.LoadAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<ScheItemDateEntityAll> LoadScheAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<ScheItemDateEntityAll>("ScheItemDateMap.LoadScheAll", ht);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable GetScheDateList(string Condition)
        {
            try
            {
                IDictionary ht = new Hashtable();
                ht["Condition"] = Condition;
                return SqlMapClient.QueryForDataTable("ScheItemDateMap.GetScheDateList", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GetScheDateListByDateAndType(string Condition)
        {
            try
            {
                IDictionary ht = new Hashtable();
                ht["Condition"] = Condition;
                return SqlMapClient.QueryForDataTable("ScheItemDateMap.GetScheDateListByDateAndType", ht);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
