
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-08-24 09:15:43
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
    public partial interface IXMInvoiceInfoDetailService
    {
        #region IXMInvoiceInfoDetailService成员
        /// <summary>
        /// Insert into XMInvoiceInfoDetail
        /// </summary>
        /// <param name="xminvoiceinfodetail">XMInvoiceInfoDetail</param>
        void InsertXMInvoiceInfoDetail(XMInvoiceInfoDetail xminvoiceinfodetail);

        /// <summary>
        /// Update into XMInvoiceInfoDetail
        /// </summary>
        /// <param name="xminvoiceinfodetail">XMInvoiceInfoDetail</param>
        void UpdateXMInvoiceInfoDetail(XMInvoiceInfoDetail xminvoiceinfodetail);

        /// <summary>
        /// get to XMInvoiceInfoDetail list
        /// </summary>
        List<XMInvoiceInfoDetail> GetXMInvoiceInfoDetailList();
        List<XMInvoiceInfoDetail> GetXMInvoiceInfoDetailListByOrderCode(string OrderCode);
        List<XMInvoiceInfoDetail> GetXMInvoiceInfoDetailListByInvoiceInfoID(int InvoiceInfoID);

        /// <summary>
        /// get to XMInvoiceInfoDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInvoiceInfoDetail Page List</returns>
        PagedList<XMInvoiceInfoDetail> SearchXMInvoiceInfoDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMInvoiceInfoDetail by ID
        /// </summary>
        /// <param name="id">XMInvoiceInfoDetail ID</param>
        /// <returns>XMInvoiceInfoDetail</returns>   
        XMInvoiceInfoDetail GetXMInvoiceInfoDetailByID(int id);

        /// <summary>
        /// delete XMInvoiceInfoDetail by ID
        /// </summary>
        /// <param name="ID">XMInvoiceInfoDetail ID</param>
        void DeleteXMInvoiceInfoDetail(int id);

        /// <summary>
        /// Batch delete XMInvoiceInfoDetail by ID
        /// </summary>
        /// <param name="IDs">XMInvoiceInfoDetail ID</param>
        void BatchDeleteXMInvoiceInfoDetail(List<int> ids);

        #endregion
    }
}
