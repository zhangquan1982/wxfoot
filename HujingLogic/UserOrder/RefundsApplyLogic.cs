using HujingAccess;
using HujingModel;
using IHujingAccess.SysFrame;
using IHujingAccess.UserOrder;
using IHujingLogic;
using IHujingLogic.UserOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HujingLogic.UserOrder
{
    class RefundsApplyLogic : IRefundsApplyLogic
    {
        public IRefundsApplyAccess access { get; set; }

        public IUserCardAccess usercardAccess { get; set; }

        public IUserInfoAccess userAccess { get; set; }


        public IPatiPayListLogic paylistLogic { get; set; }

        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public RefundsApplyEntity Load(string code)
        {
            return access.Load(code);
        }

        public IList<RefundsApplyEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool Save(RefundsApplyEntity obj)
        {
            return access.Save(obj);
        }

        public bool Update(RefundsApplyEntity obj)
        {
            return access.Update(obj);
        }


        public bool BackUserFee(string applyId,string backUserId)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool isok = true;
                    RefundsApplyEntity entity = access.Load(applyId);
                    entity.BackUserId = backUserId;
                    entity.BackDate = DateTime.Now;
                    entity.IsBack = "1";
                    isok = access.Update(entity);
                    if (isok == false)
                    {
                        return false;
                    }


                    UserInfoEntity user = userAccess.Load(entity.UserId);
                    if (user != null)
                    {
                        UserCardEntity cardEnty = usercardAccess.Load(user.CardId);
                        cardEnty.PreAmount = cardEnty.PreAmount - entity.Amount;
                        cardEnty.UpdateDate = DateTime.Now;
                        cardEnty.UpdateUser = backUserId;
                        isok = usercardAccess.Update(cardEnty);
                        if (isok == false)
                        {
                            return false;
                        }
                    }


                    PatiPayListEntity payInfo = new PatiPayListEntity();
                    payInfo.PayId = backUserId + DateTime.Now.ToString("yyMMddHHmmssff");
                    payInfo.UserId = entity.UserId;
                    payInfo.CardId = user.CardId;
                    payInfo.Direction = -1;
                    payInfo.CreateDate = DateTime.Now;
                    payInfo.CreateUser = backUserId;
                    payInfo.PayAmount = entity.Amount;
                    isok = paylistLogic.Save(payInfo); // 保存数据。




                    if (isok == true)
                    {
                        trans.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
