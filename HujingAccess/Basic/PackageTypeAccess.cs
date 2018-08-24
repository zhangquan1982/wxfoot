using HujingModel;
using ICommonAccess;
using IHujingAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess
{
    class PackageTypeAccess : SqlMapClientTemplate,IPackageTypeAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("PackageTypeMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PackageTypeEntity Load(string code)
        {
            try
            {
                PackageTypeEntity cateEntity = QueryForObject<PackageTypeEntity>("PackageTypeMap.Load", code);
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
                        Delete("PackageTypeMap.Delete", ids[i]);
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

        public bool Save(PackageTypeEntity obj)
        {
            try
            {
                Insert("PackageTypeMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<PackageTypeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            try
            {
                //IDictionary ht = new Hashtable();
                //int Prev = startIndex * pageSize;
                //int Next = pageSize * (startIndex - 1) + 1;
                //ht["Condition"] = condition;
                //ht["Prev"] = Prev;
                //ht["Next"] = Next;
                //ht["OrderBy"] = OrderBy;
                return QueryForList<PackageTypeEntity>("PackageTypeMap.LoadAll", condition);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
