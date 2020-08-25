
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
    public partial interface IXMStorageService
    {
        #region IXMStorageService成员
        /// <summary>
        /// Insert into XMStorage
        /// </summary>
        /// <param name="xmstorage">XMStorage</param>
        void InsertXMStorage(XMStorage xmstorage);

        /// <summary>
        /// Update into XMStorage
        /// </summary>
        /// <param name="xmstorage">XMStorage</param>
        void UpdateXMStorage(XMStorage xmstorage);

        /// <summary>
        /// get to XMStorage list
        /// </summary>
        List<XMStorage> GetXMStorageList();

        /// <summary>
        /// 根据采购单ID 查询入库单列表
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <returns></returns>
        List<XMStorage> GetXMStorageListByPurcahaseID(int purchaseID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <param name="storageStatus"></param>
        /// <returns></returns>
        List<XMStorage> GetXMStorageListByPurcahaseIDAndStorageStatus(int purchaseID, int storageStatus);

        /// <summary>
        /// get to XMStorage Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorage Page List</returns>
        PagedList<XMStorage> SearchXMStorage(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="supplierId"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        List<XMStorage> GetXMStorageByParm(string storageCode, string begin, string end, int supplierId, string  wareHousesId, int status, int projectId, string nickids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="supplierId"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="status"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMStorage> GetXMStorageByProjectID(string storageCode, string begin, string end, int supplierId, int wareHousesId, int status, string projectids, int projectid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        List<XMStorage> GetXMStorageBySupplierId(int supplierID);

        List<XMStorage> GetXMStorageByRef(string Ref);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHoursesID"></param>
        /// <returns></returns>
        List<XMStorage> GetXMStorageByWareHoursesId(int wareHoursesID);

        /// <summary>
        /// get a XMStorage by Id
        /// </summary>
        /// <param name="id">XMStorage Id</param>
        /// <returns>XMStorage</returns>   
        XMStorage GetXMStorageById(int id);

        ImportStorage GetDetail(string refNo, string manufacturersCode);

        /// <summary>
        /// delete XMStorage by Id
        /// </summary>
        /// <param name="Id">XMStorage Id</param>
        void DeleteXMStorage(int id);

        /// <summary>
        /// Batch delete XMStorage by Id
        /// </summary>
        /// <param name="Ids">XMStorage Id</param>
        void BatchDeleteXMStorage(List<int> ids);

        #endregion
    }
}
