
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-17 10:08:30
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
    public partial interface IXMStorageProductBarCodeDetailService
    {
        #region IXMStorageProductBarCodeDetailService成员
        /// <summary>
        /// Insert into XMStorageProductBarCodeDetail
        /// </summary>
        /// <param name="xmstorageproductbarcodedetail">XMStorageProductBarCodeDetail</param>
        void InsertXMStorageProductBarCodeDetail(XMStorageProductBarCodeDetail xmstorageproductbarcodedetail);

        /// <summary>
        /// Update into XMStorageProductBarCodeDetail
        /// </summary>
        /// <param name="xmstorageproductbarcodedetail">XMStorageProductBarCodeDetail</param>
        void UpdateXMStorageProductBarCodeDetail(XMStorageProductBarCodeDetail xmstorageproductbarcodedetail);

        /// <summary>
        /// get to XMStorageProductBarCodeDetail list
        /// </summary>
        List<XMStorageProductBarCodeDetail> GetXMStorageProductBarCodeDetailList();
        /// <summary>
        /// 根据入库产品详情ID 查询入库产品条形码明细表
        /// </summary>
        /// <param name="spdID"></param>
        /// <returns></returns>
        List<XMStorageProductBarCodeDetail> GetXMStorageProductBarCodeDetailListBySpdID(int spdID);
        /// <summary>
        /// 根据入库产品ID 和 条形码查询产品相关信息
        /// </summary>
        /// <param name="spdID"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        XMStorageProductBarCodeDetail GetXMStorageProductBarCodeDetailByParm(int spdID, string barCode);
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="spdID"></param>
        /// <returns></returns>
        List<XMStorageProductBarCodeDetail> GetXMStorageProductBarCodeDetailListByParm(string barCode, int spdID);
        /// <summary>
        /// get to XMStorageProductBarCodeDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorageProductBarCodeDetail Page List</returns>
        PagedList<XMStorageProductBarCodeDetail> SearchXMStorageProductBarCodeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMStorageProductBarCodeDetail by Id
        /// </summary>
        /// <param name="id">XMStorageProductBarCodeDetail Id</param>
        /// <returns>XMStorageProductBarCodeDetail</returns>   
        XMStorageProductBarCodeDetail GetXMStorageProductBarCodeDetailById(int id);

        /// <summary>
        /// delete XMStorageProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Id">XMStorageProductBarCodeDetail Id</param>
        void DeleteXMStorageProductBarCodeDetail(int id);

        /// <summary>
        /// Batch delete XMStorageProductBarCodeDetail by Id
        /// </summary>
        /// <param name="Ids">XMStorageProductBarCodeDetail Id</param>
        void BatchDeleteXMStorageProductBarCodeDetail(List<int> ids);

        #endregion
    }
}
