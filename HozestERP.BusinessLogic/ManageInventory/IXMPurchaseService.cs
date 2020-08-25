
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:13
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMPurchaseService
    {
        #region IXMPurchaseService成员
        /// <summary>
        /// Insert into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
        void InsertXMPurchase(XMPurchase xmpurchase);

        /// <summary>
        /// Update into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
        void UpdateXMPurchase(XMPurchase xmpurchase);

        /// <summary>
        /// get to XMPurchase list
        /// </summary>
        List<XMPurchase> GetXMPurchaseList();

        /// <summary>
        /// get to XMPurchase Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchase Page List</returns>
        PagedList<XMPurchase> SearchXMPurchase(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMPurchase by Id
        /// </summary>
        /// <param name="id">XMPurchase Id</param>
        /// <returns>XMPurchase</returns>   
        XMPurchase GetXMPurchaseById(int id);

        ImportPurchase GetDetail(string purchaseNumber, string manufacturersCode);

        List<XMPurchase> GetXMPurchaseByIDs(List<int> IDs);

        /// <summary>
        /// 根据相关参数查询相关采购数据
        /// </summary>
        /// <param name="purChaseCode">采购单号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="supplierId">供应商ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        List<XMPurchase> GetXMPurchaseByParm(string purChaseCode, string begin, string end, int supplierId, int status, int storageStatus, string customerids, string EmitFactory, int BuildOrder);
        List<XMPurchase> GetXMPurchaseByParm(int PlatformTypeId, string MerchantCode, DateTime begin, DateTime end);

        /// <summary>
        /// 根据供应商ID 查询相关采购数据
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        List<XMPurchase> GetXMPurchaseListBySupplierID(int supplierId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purChaseCode"></param>
        /// <returns></returns>
        List<XMPurchase> GetXMPurchaseBypurChaseCode(string purChaseCode);
        /// <summary>
        /// 京东自营采购单导入查询（采购单号  交货地址）
        /// </summary>
        /// <param name="purChaseCode"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        List<XMPurchase> GetXMPurchaseJDZYByParm(string purChaseCode, string address);

        /// <summary>
        /// delete XMPurchase by Id
        /// </summary>
        /// <param name="Id">XMPurchase Id</param>
        void DeleteXMPurchase(int id);

        /// <summary>
        /// Batch delete XMPurchase by Id
        /// </summary>
        /// <param name="Ids">XMPurchase Id</param>
        void BatchDeleteXMPurchase(List<int> ids);

        #endregion
    }
}
