
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMJDSaleRejectedProductDetailService
    {
        #region IXMJDSaleRejectedProductDetailService成员
        /// <summary>
        /// Insert into XMJDSaleRejectedProductDetail
        /// </summary>
        /// <param name="xmjdsalerejectedproductdetail">XMJDSaleRejectedProductDetail</param>
        void InsertXMJDSaleRejectedProductDetail(XMJDSaleRejectedProductDetail xmjdsalerejectedproductdetail);

        /// <summary>
        /// Update into XMJDSaleRejectedProductDetail
        /// </summary>
        /// <param name="xmjdsalerejectedproductdetail">XMJDSaleRejectedProductDetail</param>
        void UpdateXMJDSaleRejectedProductDetail(XMJDSaleRejectedProductDetail xmjdsalerejectedproductdetail);

        /// <summary>
        /// get to XMJDSaleRejectedProductDetail list
        /// </summary>
        List<XMJDSaleRejectedProductDetail> GetXMJDSaleRejectedProductDetailList();
        List<XMJDSaleRejectedProductDetail> GetXMJDSaleRejectedProductDetailListJDSelf(DateTime begin, DateTime end);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jdSaleRejectID"></param>
        /// <returns></returns>
        List<XMJDSaleRejectedProductDetail> GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(int jdSaleRejectID);

        /// <summary>
        /// get to XMJDSaleRejectedProductDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDSaleRejectedProductDetail Page List</returns>
        PagedList<XMJDSaleRejectedProductDetail> SearchXMJDSaleRejectedProductDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMJDSaleRejectedProductDetail by Id
        /// </summary>
        /// <param name="id">XMJDSaleRejectedProductDetail Id</param>
        /// <returns>XMJDSaleRejectedProductDetail</returns>   
        XMJDSaleRejectedProductDetail GetXMJDSaleRejectedProductDetailById(int id);

        /// <summary>
        /// delete XMJDSaleRejectedProductDetail by Id
        /// </summary>
        /// <param name="Id">XMJDSaleRejectedProductDetail Id</param>
        void DeleteXMJDSaleRejectedProductDetail(int id);

        /// <summary>
        /// Batch delete XMJDSaleRejectedProductDetail by Id
        /// </summary>
        /// <param name="Ids">XMJDSaleRejectedProductDetail Id</param>
        void BatchDeleteXMJDSaleRejectedProductDetail(List<int> ids);

        #endregion
    }
}
