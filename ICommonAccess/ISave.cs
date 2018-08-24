/*----------------------------------------------------------------
// Copyright (C) 2011 永新软件技术工作室
// 版权所有。 
//
// 文件名：IUpdate.cs
// 文件功能描述：更新数据接口
//
// 
// 创建标识：2012-09-09 蒋勇
//
// 修改标识：
// 修改描述：
//
//
//----------------------------------------------------------------*/


namespace ICommonAccess
{
    /// <summary>
    /// 保存新增对象接口
    /// </summary>
    public interface ISave<T, T1>
    {

        /// <summary>
        /// 保存一个新增的对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>T</returns>
        T Save(T1 obj);
    }

}