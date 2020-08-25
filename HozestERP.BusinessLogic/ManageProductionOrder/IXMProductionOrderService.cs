
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-14 10:05:13
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

namespace HozestERP.BusinessLogic.ManageProductionOrder
{
    public partial interface IXMProductionOrderService
    {
        #region IXMProductionOrderService成员
        /// <summary>
        /// Insert into XMProductionOrder
        /// </summary>
        /// <param name="xmproductionorder">XMProductionOrder</param>
        void InsertXMProductionOrder(XMProductionOrder xmproductionorder);

        /// <summary>
        /// Update into XMProductionOrder
        /// </summary>
        /// <param name="xmproductionorder">XMProductionOrder</param>
        void UpdateXMProductionOrder(XMProductionOrder xmproductionorder);

        /// <summary>
        /// get to XMProductionOrder list
        /// </summary>
        List<XMProductionOrder> GetXMProductionOrderList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMProjectId"></param>
        /// <param name="NickId"></param>
        /// <param name="OrderStatusId"></param>
        /// <param name="PlatformTypeId"></param>
        /// <param name="StorageDateStart"></param>
        /// <param name="StorageDateEnd"></param>
        /// <param name="WantID"></param>
        /// <param name="SingleRow"></param>
        /// <param name="Mobile"></param>
        /// <param name="Address"></param>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        List<XMProductionOrder> GetXMProductionOrderInfoListSearch(int xMProjectId, int NickId, int OrderStatusId, int PlatformTypeId, string Begin, string End, string WantID, int SingleRow, string Mobile, string Address, string ManufacturersCode, int status);
        /// <summary>
        /// 根据订单号查询生产单 （每个订单只允许出现一个生产单）
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        XMProductionOrder GetXMProductionOrderInfoByOrderCode(string orderCode);

        /// <summary>
        /// get to XMProductionOrder Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductionOrder Page List</returns>
        PagedList<XMProductionOrder> SearchXMProductionOrder(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMProductionOrder by Id
        /// </summary>
        /// <param name="id">XMProductionOrder Id</param>
        /// <returns>XMProductionOrder</returns>   
        XMProductionOrder GetXMProductionOrderById(int id);

        /// <summary>
        /// delete XMProductionOrder by Id
        /// </summary>
        /// <param name="Id">XMProductionOrder Id</param>
        void DeleteXMProductionOrder(int id);

        /// <summary>
        /// Batch delete XMProductionOrder by Id
        /// </summary>
        /// <param name="Ids">XMProductionOrder Id</param>
        void BatchDeleteXMProductionOrder(List<int> ids);

        #endregion
    }
}
