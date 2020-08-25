
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-03-13 16:28:56
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
    public partial interface IXMJDZYSaleCoefficientsService
    {
        #region IXMJDZYSaleCoefficientsService成员
        /// <summary>
        /// Insert into XMJDZYSaleCoefficients
        /// </summary>
        /// <param name="xmjdzysalecoefficients">XMJDZYSaleCoefficients</param>
        void InsertXMJDZYSaleCoefficients(XMJDZYSaleCoefficients xmjdzysalecoefficients);

        /// <summary>
        /// Update into XMJDZYSaleCoefficients
        /// </summary>
        /// <param name="xmjdzysalecoefficients">XMJDZYSaleCoefficients</param>
        void UpdateXMJDZYSaleCoefficients(XMJDZYSaleCoefficients xmjdzysalecoefficients);

        /// <summary>
        /// get to XMJDZYSaleCoefficients list
        /// </summary>
        List<XMJDZYSaleCoefficients> GetXMJDZYSaleCoefficientsList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickids"></param>
        /// <param name="projectId"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        List<XMJDZYSaleCoefficients> GetXMJDZYSaleCoefficientsByParm(string nickids, int month);

        /// <summary>
        /// get to XMJDZYSaleCoefficients Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDZYSaleCoefficients Page List</returns>
        PagedList<XMJDZYSaleCoefficients> SearchXMJDZYSaleCoefficients(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMJDZYSaleCoefficients by Id
        /// </summary>
        /// <param name="id">XMJDZYSaleCoefficients Id</param>
        /// <returns>XMJDZYSaleCoefficients</returns>   
        XMJDZYSaleCoefficients GetXMJDZYSaleCoefficientsById(int id);

        /// <summary>
        /// delete XMJDZYSaleCoefficients by Id
        /// </summary>
        /// <param name="Id">XMJDZYSaleCoefficients Id</param>
        void DeleteXMJDZYSaleCoefficients(int id);

        /// <summary>
        /// Batch delete XMJDZYSaleCoefficients by Id
        /// </summary>
        /// <param name="Ids">XMJDZYSaleCoefficients Id</param>
        void BatchDeleteXMJDZYSaleCoefficients(List<int> ids);

        #endregion
    }
}
