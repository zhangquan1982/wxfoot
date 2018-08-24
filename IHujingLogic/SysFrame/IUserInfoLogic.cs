using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HujingModel;
using HujingModel.SysFrame;


namespace IHujingLogic
{
    public interface IUserInfoLogic
    {
        int Count(string condition);


        UserInfoEntity Load(string UserId);

        UserInfoEntity LoadByMobile(string mobile);

        UserInfoEntity LoadByLoginName(string LoginName);

        IList<UserInfoEntity> LoadAll(string condition, int pageSize, int startIndex,string sortField, string sortOrder);

        bool Delete(string userid);

        bool Save(UserInfoEntity entity);

        bool SaveUserCard(UserInfoEntity user, UserCardEntity cardInfo);

        bool Update(UserInfoEntity entity);

        string GetMaxUserId();

        IList<UserVM> GetUserVM(string Condition);

        bool UpdatePwd(UserInfoEntity entity);

        bool CheckUser(string UserIds, string checkUser);
    }
}
