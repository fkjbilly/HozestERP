
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
    public partial interface IXMSaleInfoService
    {
        #region IXMSaleInfoService成员
        /// <summary>
        /// Insert into XMSaleInfo
        /// </summary>
        /// <param name="xmsaleinfo">XMSaleInfo</param>
        void InsertXMSaleInfo(XMSaleInfo xmsaleinfo);

        /// <summary>
        /// Update into XMSaleInfo
        /// </summary>
        /// <param name="xmsaleinfo">XMSaleInfo</param>
        void UpdateXMSaleInfo(XMSaleInfo xmsaleinfo);

        /// <summary>
        /// get to XMSaleInfo list
        /// </summary>
        List<XMSaleInfo> GetXMSaleInfoList();
        List<XMSaleInfo> GetXMSaleInfoListByRef(string Ref);

        /// <summary>
        /// get to XMSaleInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleInfo Page List</returns>
        PagedList<XMSaleInfo> SearchXMSaleInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
        /// <summary>
        /// 根据相关条件查询相关记录
        /// </summary>
        /// <param name="saleCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="status"></param>
        /// <param name="customerName"></param>
        /// <param name="customerids"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        List<XMSaleInfo> GetXMSaleInfoListByParm(string saleCode, string begin, string end, int status, string customerName, string customerids, int projectId);

        /// <summary>
        /// get a XMSaleInfo by Id
        /// </summary>
        /// <param name="id">XMSaleInfo Id</param>
        /// <returns>XMSaleInfo</returns>   
        XMSaleInfo GetXMSaleInfoById(int id);

        /// <summary>
        /// delete XMSaleInfo by Id
        /// </summary>
        /// <param name="Id">XMSaleInfo Id</param>
        void DeleteXMSaleInfo(int id);

        /// <summary>
        /// Batch delete XMSaleInfo by Id
        /// </summary>
        /// <param name="Ids">XMSaleInfo Id</param>
        void BatchDeleteXMSaleInfo(List<int> ids);

        #endregion
    }
}
