
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-25 17:06:12
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
    public partial interface IXMSuppliersService
    {
        #region IXMSuppliersService成员
        /// <summary>
        /// Insert into XMSuppliers
        /// </summary>
        /// <param name="xmsuppliers">XMSuppliers</param>
        void InsertXMSuppliers(XMSuppliers xmsuppliers);

        /// <summary>
        /// Update into XMSuppliers
        /// </summary>
        /// <param name="xmsuppliers">XMSuppliers</param>
        void UpdateXMSuppliers(XMSuppliers xmsuppliers);

        /// <summary>
        /// get to XMSuppliers list
        /// </summary>
        List<XMSuppliers> GetXMSuppliersList();

        List<XMSuppliers> GetXMSuppliersListDirect();
        /// <summary>
        /// 根据供应商编码和供应商名称进行查询
        /// </summary>
        /// <param name="supplierCode">供应商编码</param>
        /// <param name="supplierName">供应商名称</param>
        /// <returns></returns>
        List<XMSuppliers> GetXMSuppliersListByParm(string supplierCode, string supplierName);
        /// <summary>
        /// 根据供应商编码查询供应商信息
        /// </summary>
        /// <param name="supplierCode">供应商名称</param>
        /// <returns></returns>
        List<XMSuppliers> GetXMSupplierBySupplierName(string supplierName);
        /// <summary>
        /// get to XMSuppliers Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSuppliers Page List</returns>
        PagedList<XMSuppliers> SearchXMSuppliers(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMSuppliers by Id
        /// </summary>
        /// <param name="id">XMSuppliers Id</param>
        /// <returns>XMSuppliers</returns>   
        XMSuppliers GetXMSuppliersById(int id);

        XMSuppliers GetXMSuppliersByIdDirect(int id);

        /// <summary>
        /// delete XMSuppliers by Id
        /// </summary>
        /// <param name="Id">XMSuppliers Id</param>
        void DeleteXMSuppliers(int id);

        /// <summary>
        /// Batch delete XMSuppliers by Id
        /// </summary>
        /// <param name="Ids">XMSuppliers Id</param>
        void BatchDeleteXMSuppliers(List<int> ids);

        #endregion
    }
}
