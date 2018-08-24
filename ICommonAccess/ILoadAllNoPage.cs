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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICommonAccess
{
    /// <summary>
    /// 加载所有树型对象接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILoadAllNoPage<T>
    {
        /// <summary>
        /// 加载所有对象
        /// </summary>
        IList<T> LoadAllNoPage(string condition);
    }
}
