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
    class PackageItemAccess : SqlMapClientTemplate, IPackageItemAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("PackageItemMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HujingModel.PackageItemEntity Load(string code)
        {
            try
            {
                PackageItemEntity cateEntity = QueryForObject<PackageItemEntity>("PackageItemMap.Load", code);
                return cateEntity;
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
                //SqlMapClientTemplate.mapper.BeginTransaction();
                //string[] ids = obj.Split(',');
                //for (int i = 0; i < ids.Length; i++)
                //{
                //    if (ids[i] != "")
                //    {
                Delete("PackageItemMap.Delete", obj);
                //    }
                //}

                //SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }


        public IList<HujingModel.PackageItemEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<PackageItemEntity>("PackageItemMap.LoadAll", condition);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveList(IList<PackageItemEntity> list)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                if (list.Count > 0)
                {
                    int irow = 0; 
                    foreach (PackageItemEntity item in list)
                    {
                        irow++;
                        if (item._state == "added")
                        {
                            Random rad = new Random();
                            int value = rad.Next(100, 1000);
                            item.PackItemId = item.CreateUser + item.CreateUser + System.DateTime.Now.ToString("yyMMddhhmmssff") + irow;
                            Insert("PackageItemMap.Save", item);
                        }
                        else if (item._state == "removed")
                        {
                            Delete("PackageItemMap.Delete", item);
                        }
                        else if (item._state == "modified")
                        {
                            Update("PackageItemMap.Update", item);
                        }
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

        public bool Save(PackageItemEntity obj)
        {
            try
            {
                Insert("PackageItemMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
