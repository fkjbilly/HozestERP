
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-25 16:55:21
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
    public partial interface IXMInventoryLedgerDetailService
    {
        #region IXMInventoryLedgerDetailService成员
        /// <summary>
        /// Insert into XMInventoryLedgerDetail
        /// </summary>
        /// <param name="xminventoryledgerdetail">XMInventoryLedgerDetail</param>
        void InsertXMInventoryLedgerDetail(XMInventoryLedgerDetail xminventoryledgerdetail);

        /// <summary>
        /// Update into XMInventoryLedgerDetail
        /// </summary>
        /// <param name="xminventoryledgerdetail">XMInventoryLedgerDetail</param>
        void UpdateXMInventoryLedgerDetail(XMInventoryLedgerDetail xminventoryledgerdetail);

        /// <summary>
        /// get to XMInventoryLedgerDetail list
        /// </summary>
        List<XMInventoryLedgerDetail> GetXMInventoryLedgerDetailList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHouseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        List<XMInventoryLedgerDetail> GetXMInventoryLedgerDetailListByParm(string begin, string end, int wareHouseId, string platformMerchantCode);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHouseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        List<XMInventoryLedgerDetail> GetXMInventoryLedgerDetailListByParm(int wareHouseId, string platformMerchantCode);
        /// <summary>
        /// 更具业务状态 查询所有记录
        /// </summary>
        /// <param name="wareHouseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        List<XMInventoryLedgerDetail> GetXMInventoryLedgerDetailListByParm(int wareHouseId, string platformMerchantCode, int status);
        /// <summary>
        /// get to XMInventoryLedgerDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryLedgerDetail Page List</returns>
        PagedList<XMInventoryLedgerDetail> SearchXMInventoryLedgerDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMInventoryLedgerDetail by Id
        /// </summary>
        /// <param name="id">XMInventoryLedgerDetail Id</param>
        /// <returns>XMInventoryLedgerDetail</returns>   
        XMInventoryLedgerDetail GetXMInventoryLedgerDetailById(int id);

        /// <summary>
        /// delete XMInventoryLedgerDetail by Id
        /// </summary>
        /// <param name="Id">XMInventoryLedgerDetail Id</param>
        void DeleteXMInventoryLedgerDetail(int id);

        /// <summary>
        /// Batch delete XMInventoryLedgerDetail by Id
        /// </summary>
        /// <param name="Ids">XMInventoryLedgerDetail Id</param>
        void BatchDeleteXMInventoryLedgerDetail(List<int> ids);

        #endregion
    }
}
