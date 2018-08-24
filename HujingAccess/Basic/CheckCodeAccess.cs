using ICommonAccess;
using IHujingAccess.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HujingModel;

namespace HujingAccess.Basic
{
    class CheckCodeAccess : SqlMapClientTemplate, ICheckCodeAccess
    {
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("CheckCodeMap.Count", condition);
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
                Delete("CheckCodeMap.Delete", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetNewCode(string mobile)
        {
            try
            {
                CheckCodeEntity code = QueryForObject<CheckCodeEntity>("CheckCodeMap.GetNewCode", mobile);
                if (code == null)
                {
                    return "";
                }
                else
                {
                    return code.Code;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CheckCodeEntity Load(string code)
        {
            try
            {
                CheckCodeEntity cateEntity = QueryForObject<CheckCodeEntity>("CheckCodeMap.Load", code);
                return cateEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<CheckCodeEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            try
            {
                return QueryForList<CheckCodeEntity>("CheckCodeMap.LoadAll", condition);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(CheckCodeEntity obj)
        {
            try
            {
                Insert("CheckCodeMap.Save", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CheckCodeEntity obj)
        {
            try
            {
                Update("CheckCodeMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
