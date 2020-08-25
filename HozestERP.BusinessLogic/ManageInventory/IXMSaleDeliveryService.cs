
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
    public partial interface IXMSaleDeliveryService
    {
        #region IXMSaleDeliveryService成员
        /// <summary>
        /// Insert into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
        void InsertXMSaleDelivery(XMSaleDelivery xmsaledelivery);

        /// <summary>
        /// Update into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
        void UpdateXMSaleDelivery(XMSaleDelivery xmsaledelivery);

        /// <summary>
        /// get to XMSaleDelivery list
        /// </summary>
        List<XMSaleDelivery> GetXMSaleDeliveryList();
        List<XMSaleDelivery> GetXMSaleDeliveryListOtherProject(DateTime begin, DateTime end, List<int> WareHousesList);
        /// <summary>
        ///查询赠品自动生成的 状态为未出库的出库单记录
        /// </summary>
        /// <param name="wareHoueseID"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByPremiums(int wareHoueseID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInfoID"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByOrderInfoID(int orderInfoID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleInfoID"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListBySaleInfoID(int saleInfoID);
        /// <summary>
        /// 根据赠品ID 和出库单ID 查询相关记录
        /// </summary>
        /// <param name="premiumsID"></param>
        /// <param name="deliveryID"></param>
        /// <returns></returns>
        XMSaleDelivery GetXMSaleDeliveryByParm(int premiumsID, int deliveryID);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByParm(int deliveryID);

        List<XMSaleDelivery> GetXMSaleDeliveryListByDeliveryID(int deliveryID);
        /// <summary>
        /// 查询已经出库的出库单
        /// </summary>
        /// <param name="saleInfoID"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByDeliveryStatus(int saleInfoID);

        /// <summary>
        /// get to XMSaleDelivery list
        /// </summary>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByParm(string deliveryCode, string begin, string end, string wareHourseId, int status, int projectId, string nickids, string saleCode, int bizUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHourseId"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByParm(string begin, string end, int wareHourseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="wareHourseId"></param>
        /// <returns></returns>
        XMSaleDelivery GetXMSaleDeliveryByParm(string begin, int wareHourseId);

        /// <summary>
        /// nickid == -1 && projectId != -1 
        /// </summary>
        /// <param name="deliveryCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHourseId"></param>
        /// <param name="status"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByProjectID(string deliveryCode, string begin, string end, int wareHourseId, int status, string projectids, int projectId, string saleCode, int bizUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHourseID"></param>
        /// <returns></returns>
        List<XMSaleDelivery> GetXMSaleDeliveryListByWareHoursesID(int wareHourseID);
        /// <summary>
        /// get to XMSaleDelivery Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleDelivery Page List</returns>
        PagedList<XMSaleDelivery> SearchXMSaleDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMSaleDelivery by Id
        /// </summary>
        /// <param name="id">XMSaleDelivery Id</param>
        /// <returns>XMSaleDelivery</returns>   
        XMSaleDelivery GetXMSaleDeliveryById(int id);

        /// <summary>
        /// delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Id">XMSaleDelivery Id</param>
        void DeleteXMSaleDelivery(int id);

        /// <summary>
        /// Batch delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Ids">XMSaleDelivery Id</param>
        void BatchDeleteXMSaleDelivery(List<int> ids);

        #endregion
    }
}
