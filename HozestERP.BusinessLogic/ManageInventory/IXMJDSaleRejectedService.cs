
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-08-10 10:40:32
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
    public partial interface IXMJDSaleRejectedService
    {
        #region IXMJDSaleRejectedService成员
        /// <summary>
        /// Insert into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
        void InsertXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected);

        /// <summary>
        /// Update into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
        void UpdateXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected);

        /// <summary>
        /// get to XMJDSaleRejected list
        /// </summary>
        List<XMJDSaleRejected> GetXMJDSaleRejectedList();
        List<XMJDSaleRejected> GetXMJDSaleRejectedListOtherProject(DateTime begin, DateTime end);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rejectedCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="returnCategoryID"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids"></param>
        /// <param name="nickids2"></param>
        /// <param name="jdIsConfirm"></param>
        /// <param name="xbIsConfirm"></param>
        /// <param name="xlmIsConfirm"></param>
        /// <returns></returns>
        List<XMJDSaleRejected> GetXMJDSaleRejectedListByParm(string rejectedCode, string begin, string end, string jdbegin, string jdend, string xlmbegin, string xlmend, int returnCategoryID, int projectId, string nickids, string nickids2,int FactoryID, int jdIsConfirm, int xbIsConfirm, int xlmIsConfirm, string paramNote, string PrepareCode);

        List<XMJDSaleReport> GetXMJDSaleReportData(string begin, string end,string nickid);
        /// <summary>
        /// 更具退货单号查询记录
        /// </summary>
        /// <param name="saleRejectCode"></param>
        /// <returns></returns>
        List<XMJDSaleRejected> GetXMJDSaleRejectedBySaleRejectCode(string saleRejectCode);

        XMJDSaleRejected GetXMJDSaleRejectedByRefAndReturnCategoryID(string Ref, int ReturnCategoryID);

        XMJDSaleRejected GetXMJDSaleRejectedByRef(string Ref);

        /// <summary>
        /// get to XMJDSaleRejected Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDSaleRejected Page List</returns>
        PagedList<XMJDSaleRejected> SearchXMJDSaleRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMJDSaleRejected by Id
        /// </summary>
        /// <param name="id">XMJDSaleRejected Id</param>
        /// <returns>XMJDSaleRejected</returns>   
        XMJDSaleRejected GetXMJDSaleRejectedById(int id);

        /// <summary>
        /// delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Id">XMJDSaleRejected Id</param>
        void DeleteXMJDSaleRejected(int id);

        /// <summary>
        /// Batch delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Ids">XMJDSaleRejected Id</param>
        void BatchDeleteXMJDSaleRejected(List<int> ids);

        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<XMJDSaleRejectedExport> Export(List<XMJDSaleRejected> list);

        #endregion
    }
}
