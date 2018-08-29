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
    public class UserInfoAccess : SqlMapClientTemplate, IUserInfoAccess
    {

        public UserInfoEntity LoadByLoginName(string loginname)
        {
            try
            {
                UserInfoEntity userInfo = QueryForObject<UserInfoEntity>("UserInfoMap.LoadByLoginName", loginname);
                return userInfo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Count(string condition)
        {
            try
            {
                return QueryForObject<int>("UserInfoMap.Count", condition);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserInfoEntity Load(string LoginName)
        {
            try
            {
                UserInfoEntity userInfo = QueryForObject<UserInfoEntity>("UserInfoMap.Load", LoginName);
                return userInfo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Delete(string userIds)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = userIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        Delete("UserInfoMap.Delete", ids[i]);
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

        public bool Save(UserInfoEntity obj)
        {
            try
            {
                Insert("UserInfoMap.Save", obj);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(UserInfoEntity entity)
        {
            try
            {
                Update("UserInfoMap.Update", entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePwd(UserInfoEntity entity)
        {
            try
            {
                Update("UserInfoMap.UpdatePwd", entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<UserInfoEntity> LoadAll(string condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            try
            {
                IDictionary ht = new Hashtable();
                int Prev = startIndex * pageSize;
                int Next = pageSize * (startIndex - 1) + 1;
                ht["Condition"] = condition;
                ht["Prev"] = Prev;
                ht["Next"] = Next;
                ht["sortField"] = sortField;
                ht["sortOrder"] = sortOrder;
                return QueryForList<UserInfoEntity>("UserInfoMap.LoadAll", ht);
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
        public string GetMaxUserId()
        {//GetMaxOrgId
            try
            {
                object obj = QueryForObject<object>("UserInfoMap.GetMaxUserId", "");

                return (double.Parse(obj.ToString()) + 1).ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public UserInfoEntity LoadByMobile(string mobile)
        {
            try
            {
                return QueryForObject<UserInfoEntity>("UserInfoMap.LoadByMobile", mobile);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SaveUserCard(UserInfoEntity user, UserCardEntity cardInfo)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();

                Insert("UserInfoMap.Save", user); // 员工保存

                Insert("UserCardMap.Insert", cardInfo); // 员工账号保存

                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;

            }
            catch (Exception ex)
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }


        public bool CheckUser(string UserIds, string checkUser)
        {
            try
            {
                SqlMapClientTemplate.mapper.BeginTransaction();
                string[] ids = UserIds.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != "")
                    {
                        UserInfoEntity userInfo = QueryForObject<UserInfoEntity>("UserInfoMap.Load", ids[i]);
                        userInfo.Flag = 1;
                        userInfo.UpdateDate = DateTime.Now;
                        userInfo.UpdateUser = checkUser;
                        Update("UserInfoMap.CheckUser", userInfo);
                    }
                }

                SqlMapClientTemplate.mapper.CommitTransaction();
                return true;
            }
            catch(Exception ex)
            {
                SqlMapClientTemplate.mapper.RollBackTransaction();
                return false;
            }
        }

    }
}
