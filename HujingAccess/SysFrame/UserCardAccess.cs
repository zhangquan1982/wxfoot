using HujingModel;
using ICommonAccess;
using IHujingAccess.SysFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HujingAccess.SysFrame
{
    public class UserCardAccess : SqlMapClientTemplate, IUserCardAccess
    {
        public int Count(string condition)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string obj)
        {
            throw new NotImplementedException();
        }

        public UserCardEntity Load(string code)
        {
            try
            {
                UserCardEntity uarcard = QueryForObject<UserCardEntity>("UserCardMap.Load", code);
                return uarcard;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<UserCardEntity> LoadAll(string condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public bool Save(UserCardEntity obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserCardEntity obj)
        {
            try
            {
                Update("UserCardMap.Update", obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
