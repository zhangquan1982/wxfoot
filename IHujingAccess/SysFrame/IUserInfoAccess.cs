using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICommonAccess;
using HujingModel;
namespace HujingAccess
{
    public interface IUserInfoAccess : ICount, ILoad<UserInfoEntity, string>, IDelete<bool, string>, ISave<bool, UserInfoEntity>, IUpdate<bool, UserInfoEntity>, ILoadAllPage<UserInfoEntity>
    {
        UserInfoEntity LoadByLoginName(string loginname);

        string GetMaxUserId();

        bool UpdatePwd(UserInfoEntity entity);

        UserInfoEntity LoadByMobile(string mobile);

        bool SaveUserCard(UserInfoEntity user, UserCardEntity cardInfo);

        bool CheckUser(string UserIds, string checkUser);
    }
}
