using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HozestERP.WebApi.Manager
{
    /// <summary>
    /// 公共处理类
    /// </summary>
    public class UtilManager
    {
        /// <summary>
        /// 将实体类的属性名称和值存入字典回传
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetNameOrValue<T>(List<string> nameList, T t) where T : class
        {
            var properties = typeof(T).GetProperties();
            var dictionary = new Dictionary<string, object>();//存储属性名称和值
            foreach (var elem in properties)
            {
                if (elem.CanRead && !nameList.Contains(elem.Name))
                {
                    var value = elem.GetValue(t, null);
                    dictionary.Add(elem.Name, value);
                }
            }
            return dictionary;
        }

        public HttpResponseMessage HttpMessage(string strJson)
        {
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(strJson, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        public string GetValues(Dictionary<string, System.Type> dictionaryProperty, Dictionary<string, object> dictionaryValue)
        {
            var valueList = new List<object>();

            foreach (var elem in dictionaryProperty)
            {
                if (dictionaryValue.Keys.Contains(elem.Key))
                {
                    if (elem.Value == typeof(Nullable<System.DateTime>))
                    {
                        if (dictionaryValue[elem.Key] == null)
                            valueList.Add("NULL");
                        else
                            valueList.Add("'" + dictionaryValue[elem.Key] + "'");
                    }
                    else if (elem.Value == typeof(System.DateTime))
                    {
                        valueList.Add("'" + dictionaryValue[elem.Key] + "'");
                    }
                    else if (elem.Value == typeof(System.String))
                    {
                        valueList.Add("'" + dictionaryValue[elem.Key] + "'");
                    }
                    else if (elem.Value == typeof(Nullable<System.Decimal>))
                    {
                        if (dictionaryValue[elem.Key] == null)
                            valueList.Add("NULL");
                        else
                            valueList.Add(dictionaryValue[elem.Key]);
                    }
                    else if (elem.Value == typeof(Nullable<System.Int32>) || elem.Value == typeof(Nullable<System.Int64>) || elem.Value == typeof(Nullable<System.Int16>))
                    {
                        if (dictionaryValue[elem.Key] == null)
                            valueList.Add("NULL");
                        else
                            valueList.Add(dictionaryValue[elem.Key]);
                    }
                    else if (elem.Value == typeof(Nullable<System.Boolean>))
                    {
                        if (dictionaryValue[elem.Key] == null)
                            valueList.Add("NULL");
                        else
                            valueList.Add(Convert.ToBoolean(dictionaryValue[elem.Key]) ? 1 : 0);
                    }
                    else if (elem.Value == typeof(System.Boolean))
                    {
                        if (dictionaryValue[elem.Key] == null)
                            valueList.Add("NULL");
                        else
                            valueList.Add(Convert.ToBoolean(dictionaryValue[elem.Key]) ? 1 : 0);
                    }
                    else
                    {
                        valueList.Add(dictionaryValue[elem.Key]);
                    }
                }
            }
            var sqlvalue = string.Join(",", valueList.ToArray());

            return sqlvalue;
        }
        /// <summary>
        /// 写入数据到txt
        /// </summary>
        public void Write(string value)
        {
            var canWrite = ConfigurationManager.AppSettings["canWrite"];
            if (!string.IsNullOrWhiteSpace(canWrite) && canWrite == "true")
            {
                var path = ConfigurationManager.AppSettings["writePath"];
                FileStream fs;
                if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.Append);
                    //获得字节数组
                }
                else
                {
                    fs = new FileStream(path, FileMode.Create);
                    //获得字节数组
                }
                byte[] data = System.Text.Encoding.Default.GetBytes(value);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
        }

        /// <summary>
        /// 读取txt文件内容
        /// </summary>
        /// <param name="Path">文件地址</param>
        public string  ReadTxtContent()
        {
            var str = string.Empty;
            var path = ConfigurationManager.AppSettings["insertPath"];
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string content;
            while ((content = sr.ReadLine()) != null)
            {
                str = content.ToString();
            }
            sr.Close();
            return str;
        }
        /// <summary>
        /// 将对象T中的属性与N相同的字段的值赋给N
        /// </summary>
        /// <typeparam name="T">赋值对象类型</typeparam>
        /// <typeparam name="N">被赋值对象类型</typeparam>
        /// <param name="NoFillNameList">不需要赋值的属性对象的名称</param>
        /// <param name="t">赋值对象</param>
        /// <param name="n">被赋值对象</param>
        public void FillofObject<T, N>(List<string> NoFillNameList, T t, N n) where T : class where N : class
        {
            var TProperties = typeof(T).GetProperties();
            var NProperties = typeof(N).GetProperties();
            var NPropertiesDictionary = new Dictionary<string, PropertyInfo>();
            foreach (var elem in NProperties)
            {
                NPropertiesDictionary.Add(elem.Name, elem);
            }
            foreach (var elem in TProperties)
            {
                var tPropertie = elem;
                if (NPropertiesDictionary.Keys.Contains(elem.Name) && elem.CanRead && elem.Name != "ID")
                {
                    var nPropertie = NPropertiesDictionary[elem.Name];
                    try
                    {
                        if (nPropertie.CanWrite)
                        {
                            if (NoFillNameList != null && NoFillNameList.Contains(nPropertie.Name))
                                continue;
                            var value = tPropertie.GetValue(t, null);
                            if (value != null)
                            {
                                nPropertie.SetValue(n, value, null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

            }
        }
        /// <summary>
        /// dataTable 转 实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public  IEnumerable<T> ToEntity<T>(DataTable dataTable)
        {
            List<T> result = new List<T>();
            var properties = typeof(T).GetProperties();
            foreach (DataRow row in dataTable.Rows)
            {
                var entity = System.Activator.CreateInstance<T>();
                properties.AsParallel().ForAll(m =>
                {
                    try
                    {
                        FillEntity(m, row, entity);
                    }
                    catch (Exception ex)
                    {
                    }
                });
                //foreach (var elem in properties)
                //{
                //    try
                //    {
                //        if (elem.PropertyType.Namespace == "System.Collections.Generic")
                //            continue;
                //        object value = row[elem.Name];
                //        elem.SetValue(entity, Convert.ChangeType(value, Nullable.GetUnderlyingType(elem.PropertyType) ?? elem.PropertyType), null);
                //    }
                //    catch
                //    {
                //    }
                //}
                result.Add(entity);
            }
            return result;
        }

        public void FillEntity<T>(PropertyInfo m,DataRow row,T entity)
        {
            if (m.PropertyType.Namespace != "System.Collections.Generic")
            {
                object value = row[m.Name];
                m.SetValue(entity, Convert.ChangeType(value, Nullable.GetUnderlyingType(m.PropertyType) ?? m.PropertyType), null);
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns></returns>
        public string MD5Encrypt(string input)
        {
            return MD5Encrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// md5加密16|32位
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string MD5Encrypt(string input, int length)
        {
            string res = MD5Encrypt(input, new UTF8Encoding());
            if (length == 16)
            {
                res = res.Substring(8, 16);
            }
            return res;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        public string MD5Encrypt(string input, Encoding encode)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(encode.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}