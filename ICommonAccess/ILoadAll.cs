/*----------------------------------------------------------------
/*----------------------------------------------------------------
// Copyright (C) 2011 �����������������
// ��Ȩ���С� 
//
// �ļ�����IUpdate.cs
// �ļ������������������ݽӿ�
//
// 
// ������ʶ��2012-09-09 ����
//
// �޸ı�ʶ��
// �޸�������
//
//
//----------------------------------------------------------------*/

using System.Collections.Generic;
using System.Collections;
namespace ICommonAccess
{
    /// <summary>
    /// �������ж���ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILoadAll<T>
    {

        /// <summary>
        /// �������ж���
        /// </summary>
        IList<T> LoadAll(string condition, int pageSize, int startIndex,string OrderBy);
    }

}