using HujingModel;
using ICommonAccess;
using IHujingAccess.SysFrame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.SysFrame
{
    class RegionAreaAccess : SqlMapClientTemplate, IRegionAreaAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("RegionAreaMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HujingModel.RegionAreaEntity Load(string code)
        {
            try
            {
                RegionAreaEntity orgInfo = QueryForObject<RegionAreaEntity>("RegionAreaMap.Load", code);
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
                Update("RegionAreaMap.Delete", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(HujingModel.RegionAreaEntity obj)
        {
            try
            {
                Insert("RegionAreaMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(RegionAreaEntity entity)
        {
            try
            {
                Update("RegionAreaMap.Update", entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<HujingModel.RegionAreaEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
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
                return QueryForList<RegionAreaEntity>("RegionAreaMap.LoadAll", ht);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SetRegCode(string parentid)
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
                object obj = QueryForObject<object>("RegionAreaMap.GetMaxRegId", Condition);
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
