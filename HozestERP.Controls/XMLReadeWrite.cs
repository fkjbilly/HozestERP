using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using System.Configuration;

namespace HozestERP.Controls
{

    public class XMLReadeWrite
    {
        #region xml example
        //<configuration>
        //<appSettings>
        //    <add key="ConnectionString" value="Data Source=CODESERVER\SQL2k5;Initial Catalog=LindonERP;Persist Security Info=True;User Id=sa;Password=!@#123" />
        //    <add key="DataBaseType" value="SQLSERVER" />
        //</appSettings>
        //</configuration>
        #endregion

        #region public static string GetXml(string paramKey)
        /// <summary>
        ///  获取App.config中add节点的值值
        /// </summary>
        /// <param name="paramKey"></param>
        /// <returns></returns>
        public static string GetXml(string paramKey)
        {
            return XMLReadeWrite.GetXml(paramKey, AppDomain.CurrentDomain.BaseDirectory + "Web.config", "configuration/appSettings/add");
        }
        #endregion

        #region  public static string GetXml(string paramKey,string paramXmlFileName,string paramNodesPath)
        /// <summary>
        ///  获取xml文件中特定节点的特定键Key的value值
        /// </summary>
        /// <param name="paramKey">keyName</param>
        /// <param name="paramXmlFileName">XmlFileName</param>
        /// <param name="paramNodes">XmlNodePath</param>
        /// <returns></returns>
        public static string GetXml(string paramKey, string paramXmlFileName, string paramNodesPath)
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(paramXmlFileName);// (AppDomain.CurrentDomain.BaseDirectory + paramXmlFileName);
            XmlNodeList mXmlNodeList = myXml.SelectNodes(paramNodesPath);
            foreach (XmlNode myXmlNode in mXmlNodeList)
            {
                if (myXmlNode.Attributes["key"].Value == paramKey)
                {
                    return myXmlNode.Attributes["value"].Value;
                }
            }
            return string.Empty;
        }
        #endregion

        #region  public static string GetXml(string paramKey,string paramXmlFileName)
        /// <summary>
        ///  获取xml文件中特定节点的特定键Key的value值
        /// </summary>
        /// <param name="paramKey">keyName</param>
        /// <param name="paramXmlFileName">XmlFileName</param>
        /// <returns></returns>
        public static string GetXml(string paramKey, string paramXmlFileName)
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(AppDomain.CurrentDomain.BaseDirectory + paramXmlFileName);//位于bin/debug中的文件
            XmlNodeList mXmlNodeList = myXml.SelectNodes(myXml.DocumentElement.Name);
            foreach (XmlNode myXmlNode in mXmlNodeList)
            {
                if (myXmlNode.Attributes["key"].Value == paramKey)
                {
                    return myXmlNode.Attributes["value"].Value;
                }
            }
            return string.Empty;
        }
        #endregion

        #region  public static string GetXml(string paramKey,string paramXmlFilePath)
        /// <summary>
        ///  获取xml文件中特定节点的特定键Key的value值
        /// </summary>
        /// <param name="paramKey">keyName</param>
        /// <param name="paramXmlFilePath">XmlFileName文件路径</param>
        /// <returns></returns>
        public static string GetXmlValue(string paramKey, string paramXmlFilePath)
        {
            string strResult = string.Empty;
            XmlDocument myXml = new XmlDocument();
            //myXml.Load(AppDomain.CurrentDomain.BaseDirectory + paramXmlFileName);//位于bin/debug中的文件
            myXml.Load(paramXmlFilePath);
            XmlNodeList mXmlNodeList = myXml.SelectNodes(myXml.DocumentElement.Name);
            foreach (XmlNode myXmlNode in mXmlNodeList)
            {
                if (myXmlNode.NodeType == XmlNodeType.Element)
                {
                    if (myXmlNode.Attributes.GetNamedItem("key") != null && myXmlNode.Attributes.GetNamedItem("key").Value == paramKey)
                    {
                        strResult = myXmlNode.Attributes.GetNamedItem("value").Value;
                        return strResult;
                    }
                    else
                    {
                        strResult = GetString(myXmlNode, paramKey);
                        if (!strResult.Equals("#error"))
                        {
                            return strResult;
                        }
                    }
                }
            }
            return strResult;
        }

        public static string GetString(XmlNode paramXmlNode, string paramKey)
        {
            string strResult = string.Empty;
            if (paramXmlNode.ChildNodes.Count == 0)
            {
                return "#error";
            }
            foreach (XmlNode myXmlNode in paramXmlNode.ChildNodes)
            {
                if (myXmlNode.NodeType == XmlNodeType.Element)
                {
                    if (myXmlNode.Attributes.GetNamedItem("key") != null && myXmlNode.Attributes.GetNamedItem("key").Value == paramKey)
                    {
                        return myXmlNode.Attributes.GetNamedItem("value").Value;
                    }
                    else
                    {
                        strResult = GetString(myXmlNode, paramKey);
                        if (!strResult.Equals("#error"))
                        {
                            return strResult;
                        }
                    }
                }
            }
            return "#error";
        }

        #endregion

        #region public static void SetXml(string paramKey, string paramValue)
        /// <summary>
        ///   设置App.config值
        /// </summary>
        /// <param name="paramKey"></param>
        /// <returns></returns>
        public static void SetXml(string paramKey, string paramValue)
        {
            XMLReadeWrite.SetXml(paramKey, paramValue, "app.config", "configuration/appSettings/add");
        }
        #endregion

        #region public static void SetXml(string paramKey, string paramValue, string paramXmlFileName, string paramNodesPath)
        /// <summary>
        /// 修改xml文件中特定节点的特定键Key的value值
        /// </summary>
        /// <param name="paramKey">keyName</param>
        /// <param name="paramValue">KeyValue</param>
        /// <param name="paramXmlFileName">XmlFileName</param>
        /// <param name="paramNodesPath">XmlNodePath</param>
        public static void SetXml(string paramKey, string paramValue, string paramXmlFileName, string paramNodesPath)
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(AppDomain.CurrentDomain.BaseDirectory + paramXmlFileName);
            XmlNodeList mXmlNodeList = myXml.SelectNodes(paramNodesPath);
            foreach (XmlNode myXmlNode in mXmlNodeList)
            {
                if (myXmlNode.Attributes["key"].Value == paramKey)
                {
                    myXmlNode.Attributes["value"].Value = paramValue;
                }
            }
            myXml.Save(AppDomain.CurrentDomain.BaseDirectory + paramXmlFileName);
        }
        #endregion

        #region xml change DataTable
        //适用于统一格式化的xml文件

        /// <summary>
        /// 获得节点路径
        /// </summary>
        /// <param name="paramXmlDocument">XmlDocument对象</param>
        /// <returns>string节点路径</returns>
        private static string GetXmlNodePath(XmlDocument paramXmlDocument)
        {
            string _XmlNodePath = string.Empty;
            XmlNode _node;
            if (paramXmlDocument.FirstChild.NodeType == XmlNodeType.Element)
            {
                _node = paramXmlDocument.FirstChild;
            }
            _node = paramXmlDocument.DocumentElement;
            while (_node != null)
            {
                _XmlNodePath += "/" + _node.Name;
                _node = _node.FirstChild;
            }
            return _XmlNodePath.Substring(1);
        }

        /// <summary>
        /// 将xml文件转化为DataTable
        /// </summary>
        /// <param name="paramXmlFileName">xml文件名</param>
        /// <returns>DataTable数据</returns>
        public static DataTable GetDataTable(string paramXmlFileName)
        {
            DataTable myDataTable = new DataTable();
            DataRow row;
            XmlDocument myXml = new XmlDocument();
            myXml.Load(AppDomain.CurrentDomain.BaseDirectory + paramXmlFileName);
            XmlNodeList mXmlNodeList = myXml.SelectNodes(GetXmlNodePath(myXml));
            //添加列
            foreach (XmlAttribute xmlatt in mXmlNodeList[0].Attributes)
            {
                myDataTable.Columns.Add(xmlatt.Name, xmlatt.Value.GetType());
            }
            //添加行
            foreach (XmlNode myXmlNode in mXmlNodeList)
            {
                row = myDataTable.NewRow();
                foreach (DataColumn col in myDataTable.Columns)
                {
                    row[col.ColumnName] = myXmlNode.Attributes[col.ColumnName].Value;
                }
                myDataTable.Rows.Add(row);
            }
            return myDataTable;
        }

        #endregion

        #region DataTable change xml

        public static void ChangeXml(DataTable paramDataTable)
        {
            //AppDomain.CurrentDomain.BaseDirectory
            // System.Windows.Forms.Application.StartupPath 
            //paramDataTable.WriteXml();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Goods";
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "\\" + paramDataTable.TableName + ".xml";
                XmlDocument mydoc = new XmlDocument();
                if (System.IO.File.Exists(path))
                {
                    //mydoc.Load(path);
                    //System.IO.File.Create(path);
                }
                XmlElement xmlele = mydoc.CreateElement("Goods");
                XmlNode newNode;
                foreach (DataRow row in paramDataTable.Rows)
                {
                    newNode = mydoc.CreateElement("Good");
                    XmlAttribute newatr;
                    for (int i = 0; i < paramDataTable.Columns.Count; i++)
                    {
                        DataColumn col = paramDataTable.Columns[i];
                        newatr = mydoc.CreateAttribute(col.ColumnName);
                        newatr.InnerText = row[col.ColumnName].ToString();
                        newNode.Attributes.Append(newatr);
                    }
                    xmlele.AppendChild(newNode);
                }
                mydoc.AppendChild(xmlele);
                //mydoc.DocumentElement.InsertAfter(xmlele, mydoc.DocumentElement.LastChild);
                mydoc.Save(path);
            }
            catch { }
        }

        #endregion
    }
}
