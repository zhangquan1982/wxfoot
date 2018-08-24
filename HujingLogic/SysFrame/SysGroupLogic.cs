using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHujingLogic;
using IHujingAccess;
using HujingModel;
using System.Transactions;

namespace HujingLogic
{
     class SysGroupLogic : ISysGroupLogic
    {
        ISysGroupAccess groupaccess;
        public SysGroupLogic(ISysGroupAccess access)
        {
            groupaccess = access;
        }

        public int Count(string condition)
        {
            return groupaccess.Count(condition);
        }

        public SysGroupEntity Load(string roleId)
        {
            return groupaccess.Load(roleId);
        }

        public bool Delete(string RoleIds)
        {
            return groupaccess.Delete(RoleIds);
        }

        public bool Save(SysGroupEntity role)
        {
            return groupaccess.Save(role);
        }

        public bool Update(SysGroupEntity entity)
        {
            return groupaccess.Update(entity);
        }

        public IList<SysGroupEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return groupaccess.LoadAll(condition, pageSize, startIndex, OrderBy);
        }


        public IList<SysGroupEntity> LoadGroupListByUserId(string UserId)
        {
            return groupaccess.LoadGroupListByUserId(UserId);
        }


        public bool SaveSysOrgGroup(IList<SysOrgGroupEntity> obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool isok = true;
                    foreach(SysOrgGroupEntity enty in obj )
                    {
                        //SysOrgGroupEntity entyNew = groupaccess.LoadSysGroup(enty.OrgId, enty.GroupID);
                        if(groupaccess.SaveSysOrgGroup(enty)==false)
                        {
                            isok = false;
                            break;
                        }
                    }

                    if (isok==true)
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


        public int GetSysOrgGroupCount(string Condition)
        {
            return groupaccess.GetSysOrgGroupCount(Condition);
        }

        public IList<SysGroupEntity> LoadAllByParentIdAndUserId(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return groupaccess.LoadAllByParentIdAndUserId(condition, pageSize, startIndex, OrderBy);
        }
    }
}
