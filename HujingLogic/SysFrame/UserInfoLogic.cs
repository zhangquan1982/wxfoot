using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using HujingModel;
using HujingAccess;
using HujingModel.SysFrame;
namespace HujingLogic
{
    public class UserInfoLogic : IUserInfoLogic
    {

        IUserInfoAccess useraccess;

        public UserInfoLogic(IUserInfoAccess access)
        {
            useraccess = access;
        }

        public int Count(string condition)
        {
            return useraccess.Count(condition);
        }

        public UserInfoEntity Load(string userid)
        {
            return useraccess.Load(userid);
        }

        public UserInfoEntity LoadByMobile(string mobile)
        {
            return useraccess.LoadByMobile(mobile);
        }

        public UserInfoEntity LoadByLoginName(string LoginName)
        {
            return useraccess.LoadByLoginName(LoginName);
        }


        public bool Delete(string userid)
        {
            return useraccess.Delete(userid);
        }

        public bool Save(UserInfoEntity entity)
        {
            return useraccess.Save(entity);
        }

        public bool Update(UserInfoEntity entity)
        {
            return useraccess.Update(entity);
        }


        public IList<UserInfoEntity> LoadAll(string condition, int pageSize, int startIndex, string sortField, string sortOrder)
        {
            return useraccess.LoadAll(condition, pageSize, startIndex, sortField, sortOrder);
        }

        public string GetMaxUserId()
        {
            return useraccess.GetMaxUserId();
        }

        public IList<UserVM> GetUserVM(string Condition)
        {
            var listuser = useraccess.LoadAll(Condition, 1000, 1, "CreateDate", "desc");
            if (listuser != null)
            {
                return listuser.Select(e =>
                {
                    return new UserVM()
                    {
                        UserId = e.UserId,
                        UserName = e.UserName,
                        Age = (DateTime.Now.Year - e.BirthDate.Year),
                        Sex = (e.Sex == "0" ? "男" : "女")
                    };
                }).ToList();
            }
            return null;
        }


        public bool UpdatePwd(UserInfoEntity entity)
        {
            return useraccess.UpdatePwd(entity);
        }

        public bool SaveUserCard(UserInfoEntity user, UserCardEntity cardInfo)
        {
            return useraccess.SaveUserCard(user, cardInfo);
        }

        public bool CheckUser(string UserIds,string checkUser)
        {
            return useraccess.CheckUser(UserIds,checkUser);
        }

    }
}
