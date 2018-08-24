using HujingModel;
using IHujingAccess.Basic;
using IHujingLogic.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HujingLogic.Basic
{
    class ScheItemDateLogic : IScheItemDateLogic
    {
        public IScheItemDateAccess access { get; set; }
        public int Count(string condition)
        {
            return access.Count(condition);
        }

        public ScheItemDateEntity Load(string code)
        {
            return access.Load(code);
        }

        public bool Delete(string obj)
        {
            return access.Delete(obj);
        }

        public bool Save(ScheItemDateEntity obj)
        {
            return access.Save(obj);
        }

        public IList<ScheItemDateEntity> LoadAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadAll(condition, pageSize, startIndex, OrderBy);
        }


        public IList<ScheItemDateEntityAll> LoadScheAll(string condition, int pageSize, int startIndex, string OrderBy)
        {
            return access.LoadScheAll(condition, pageSize, startIndex, OrderBy);
        }

        public bool SaveItemList(IList<ScheItemDateEntity> items)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    bool isTrue = true;
                    foreach (ScheItemDateEntity item in items)
                    {
                        if (item.ItemID.Length > 0)
                        {
                            isTrue = access.Save(item);
                            if (isTrue == false)
                            {
                                return false;
                            }
                        }
                    }

                    trans.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteScheItemDates(string SchIds)
        {
            return access.DeleteScheItemDates(SchIds);
        }


        public DataTable GetScheDateList(string Condition)
        {
            return access.GetScheDateList(Condition);
        }

        public DataTable GetScheDateListByDateAndType(string Condition)
        {
            return access.GetScheDateListByDateAndType(Condition);
        }
    }
}
