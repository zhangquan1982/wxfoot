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
    /// 修改一个对象接口
    /// </summary>
    public interface IUpdate<T, T1>
    {

        /// <summary>
        /// 修改对象
        /// </summary>
        /// <param name="obj">修改的对象</param>
        /// <returns>T</returns>
        T Update(T1 obj);
    }

}