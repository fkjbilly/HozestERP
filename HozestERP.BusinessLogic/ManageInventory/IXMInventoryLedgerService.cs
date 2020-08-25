
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
    public partial interface IXMInventoryLedgerService
    {
        #region IXMInventoryLedgerService成员
        /// <summary>
        /// Insert into XMInventoryLedger
        /// </summary>
        /// <param name="xminventoryledger">XMInventoryLedger</param>
        void InsertXMInventoryLedger(XMInventoryLedger xminventoryledger);

        /// <summary>
        /// Update into XMInventoryLedger
        /// </summary>
        /// <param name="xminventoryledger">XMInventoryLedger</param>
        void UpdateXMInventoryLedger(XMInventoryLedger xminventoryledger);

        /// <summary>
        /// get to XMInventoryLedger list
        /// </summary>
        List<XMInventoryLedger> GetXMInventoryLedgerList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="productName"></param>
        /// <param name="nickID"></param>
        /// <param name="wareHouseID"></param>
        /// <returns></returns>
        List<XMInventoryLedger> GetXMInventoryLedgerListByParm(string code, string productName, string nicks, string wareHouseID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="productName"></param>
        /// <param name="wareHouseID"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMInventoryLedger> GetXMInventoryLedgerListByProjectID(string code, string productName, int wareHouseID, string projectids);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        XMInventoryLedger GetXMInventoryLedgerByParm(int wareHousesID, string PlatformMerchantCode);
        /// <summary>
        /// get to XMInventoryLedger Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryLedger Page List</returns>
        PagedList<XMInventoryLedger> SearchXMInventoryLedger(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMInventoryLedger by Id
        /// </summary>
        /// <param name="id">XMInventoryLedger Id</param>
        /// <returns>XMInventoryLedger</returns>   
        XMInventoryLedger GetXMInventoryLedgerById(int id);

        /// <summary>
        /// delete XMInventoryLedger by Id
        /// </summary>
        /// <param name="Id">XMInventoryLedger Id</param>
        void DeleteXMInventoryLedger(int id);

        /// <summary>
        /// Batch delete XMInventoryLedger by Id
        /// </summary>
        /// <param name="Ids">XMInventoryLedger Id</param>
        void BatchDeleteXMInventoryLedger(List<int> ids);

        #endregion
    }
}
