/*
 * Created by: Jerome Gagner
 * Created: Monday, January 08, 2007
 */

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using System.Reflection;
using System.IO;
using IBatisNet.DataMapper.Configuration;
using System.Data;
using IBatisNet.Common;
using IBatisNet.DataMapper.Scope;
using IBatisNet.DataMapper.Configuration.Statements;

namespace ICommonAccess
{
    public abstract class SqlMapClientTemplate
    {
        //private  SqlMapClient _sqlMapClient;

        //public static  SqlMapClient SqlMapClient
        //{
        //    get { return _sqlMapClient; }
        //    set
        //    {
        //        _sqlMapClient = value;
        //        mapper = _sqlMapClient.mapper;
        //    }
        //}

        private static readonly object syncObj = new object();

        /// <summary>
        /// ¹¹Ôìº¯Êý
        /// </summary>
        public SqlMapClientTemplate()
        {
            if (mapper == null)
            {
                lock (syncObj)
                {
                    if (mapper == null)
                    {
                        Assembly assembly = Assembly.Load("SqlMaps");
                        Stream stream = assembly.GetManifestResourceStream("SqlMaps.sqlmap.config");
                        DomSqlMapBuilder builder = new DomSqlMapBuilder();
                        mapper = builder.Configure(stream);
                    }
                }
            }

        }

        public static ISqlMapper mapper;



        protected object Insert(String query, Object parameters)
        {
            return mapper.Insert(query, parameters);
        }

        protected int Update(String query, object parameters)
        {
            return mapper.Update(query, parameters);
        }

        protected int Delete(String query, object parameters)
        {
            return mapper.Delete(query, parameters);
        }

        protected IDictionary QueryForDictionary(string statementName, object parameterObject, string keyProperty,
                                                 string valueProperty)
        {
            return mapper.QueryForDictionary(statementName, parameterObject, keyProperty, valueProperty);
        }

        protected IDictionary QueryForDictionary(string statementName, object parameterObject, string keyProperty)
        {
            return mapper.QueryForDictionary(statementName, parameterObject, keyProperty);
        }

        protected void QueryForList(string statementName, object parameterObject, IList resultObject)
        {
            mapper.QueryForList(statementName, parameterObject, resultObject);
        }

        protected IList QueryForList(string statementName, object parameterObject)
        {
            return mapper.QueryForList(statementName, parameterObject);
        }

        protected IList QueryForList(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            return mapper.QueryForList(statementName, parameterObject, skipResults, maxResults);
        }

        protected IDictionary QueryForMap(string statementName, object parameterObject, string keyProperty)
        {
            return mapper.QueryForMap(statementName, parameterObject, keyProperty);
        }

        protected IDictionary QueryForMap(string statementName, object parameterObject, string keyProperty,
                                          string valueProperty)
        {
            return mapper.QueryForMap(statementName, parameterObject, keyProperty, valueProperty);
        }

        protected IDictionary QueryForMapWithRowDelegate(string statementName, object parameterObject,
                                                         string keyProperty,
                                                         string valueProperty,
                                                        DictionaryRowDelegate rowDelegate)
        {
            return
                mapper.QueryForMapWithRowDelegate(statementName, parameterObject, keyProperty, valueProperty,
                                                  rowDelegate);
        }

        protected object QueryForObject(string statementName, object parameterObject, object resultObject)
        {
            return mapper.QueryForObject(statementName, parameterObject, resultObject);
        }

        protected object QueryForObject(string statementName, object parameterObject)
        {
            return mapper.QueryForObject(statementName, parameterObject);
        }

        protected PaginatedList QueryForPaginatedList(string statementName, object parameterObject, int pageSize)
        {
            return mapper.QueryForPaginatedList(statementName, parameterObject, pageSize);
        }

        protected IList QueryWithRowDelegate(string statementName, object parameterObject,
                                             RowDelegate rowDelegate)
        {
            return mapper.QueryWithRowDelegate(statementName, parameterObject, rowDelegate);
        }

        protected T QueryForObject<T>(string statementName, object parameterObject, T instanceObject)
        {
            return mapper.QueryForObject<T>(statementName, parameterObject, instanceObject);
        }

        protected T QueryForObject<T>(string statementName, object parameterObject)
        {
            return mapper.QueryForObject<T>(statementName, parameterObject);
        }

        protected IList<T> QueryForList<T>(string statementName, object parameterObject)
        {
            return mapper.QueryForList<T>(statementName, parameterObject);
        }

        protected void QueryForList<T>(string statementName, object parameterObject, IList<T> resultObject)
        {
            mapper.QueryForList<T>(statementName, parameterObject, resultObject);
        }

        protected IList<T> QueryForList<T>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            return mapper.QueryForList<T>(statementName, parameterObject, skipResults, maxResults);
        }

        protected IList<T> QueryWithRowDelegate<T>(string statementName, object parameterObject,
                                                   RowDelegate<T> rowDelegate)
        {
            return mapper.QueryWithRowDelegate<T>(statementName, parameterObject, rowDelegate);
        }



    }
}