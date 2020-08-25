
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-23 16:30:07
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMXLMInventoryService
    {
        #region IXMXLMInventoryService成员
        /// <summary>
        /// Insert into XMXLMInventory
        /// </summary>
        /// <param name="xmxlminventory">XMXLMInventory</param>
        void InsertXMXLMInventory(XMXLMInventory xmxlminventory);

        /// <summary>
        /// Update into XMXLMInventory
        /// </summary>
        /// <param name="xmxlminventory">XMXLMInventory</param>
        void UpdateXMXLMInventory(XMXLMInventory xmxlminventory);
        /// <summary>
        /// 修改喜临门库存信息
        /// </summary>
        /// <param name="Updatexmxlminventory"></param>
        /// <param name="Insertxmxlminventory"></param>
        void OperationXMXLMInventory(List<XMXLMInventory> Updatexmxlminventory, List<XMXLMInventory> Insertxmxlminventory);

        /// <summary>
        /// get to XMXLMInventory list
        /// </summary>
        List<XMXLMInventory> GetXMXLMInventoryList();

        List<XMXLMInventory> GetXMXLMInventoryListByParm(int WarehouseID, string ManufacturersCode, string ProductName);

        List<XMXLMInventory> GetXMXLMInventoryListByParm(int WarehouseID, string ManufacturersCode);
        /// <summary>
        /// 获取喜临门库存中的库存信息
        /// </summary>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        List<XMXLMInventory> GetXMXLMInventoryListByParm(List<string> ManufacturersCode);
        /// <summary>
        /// 提交千胜订单是判断库存
        /// </summary>
        /// <param name="WarehouseName"></param>
        /// <param name="ManufacturersCode"></param>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        List<XMXLMInventory> GetXMXLMInventoryListByParm(string WarehouseName, string ManufacturersCode);

        /// <summary>
        /// get to XMXLMInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMXLMInventory Page List</returns>
        PagedList<XMXLMInventory> SearchXMXLMInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMXLMInventory by ID
        /// </summary>
        /// <param name="id">XMXLMInventory ID</param>
        /// <returns>XMXLMInventory</returns>   
        XMXLMInventory GetXMXLMInventoryByID(int id);

        /// <summary>
        /// delete XMXLMInventory by ID
        /// </summary>
        /// <param name="ID">XMXLMInventory ID</param>
        void DeleteXMXLMInventory(int id);

        /// <summary>
        /// Batch delete XMXLMInventory by ID
        /// </summary>
        /// <param name="IDs">XMXLMInventory ID</param>
        void BatchDeleteXMXLMInventory(List<int> ids);

        #endregion
    }
}
