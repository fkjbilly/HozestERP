
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-09-19 13:36:09
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial interface IXMDeliveryProductInventoryService
    {
        #region IXMDeliveryProductInventoryService成员
        /// <summary>
        /// Insert into XMDeliveryProductInventory
        /// </summary>
        /// <param name="xmdeliveryproductinventory">XMDeliveryProductInventory</param>
        void InsertXMDeliveryProductInventory(XMDeliveryProductInventory xmdeliveryproductinventory);

        /// <summary>
        /// Update into XMDeliveryProductInventory
        /// </summary>
        /// <param name="xmdeliveryproductinventory">XMDeliveryProductInventory</param>
        void UpdateXMDeliveryProductInventory(XMDeliveryProductInventory xmdeliveryproductinventory);

        /// <summary>
        /// get to XMDeliveryProductInventory list
        /// </summary>
        List<XMDeliveryProductInventory> GetXMDeliveryProductInventoryList();
        List<XMDeliveryProductInventory> GetXMDeliveryProductInventoryListByParam(List<int?> NickIds, int Year, int Month);

        /// <summary>
        /// get to XMDeliveryProductInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeliveryProductInventory Page List</returns>
        PagedList<XMDeliveryProductInventory> SearchXMDeliveryProductInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="id">XMDeliveryProductInventory ID</param>
        /// <returns>XMDeliveryProductInventory</returns>   
        XMDeliveryProductInventory GetXMDeliveryProductInventoryByID(int id);

        /// <summary>
        /// delete XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="ID">XMDeliveryProductInventory ID</param>
        void DeleteXMDeliveryProductInventory(int id);

        /// <summary>
        /// Batch delete XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="IDs">XMDeliveryProductInventory ID</param>
        void BatchDeleteXMDeliveryProductInventory(List<int> ids);

        /// <summary>
        /// 每月1号0点统计发出商品库存
        /// </summary>
        void TimingDeliveryProductInventory();

        #endregion
    }
}
