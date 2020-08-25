
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
    public partial interface IXMInventoryInfoService
    {
        #region IXMInventoryInfoService成员
        /// <summary>
        /// Insert into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
        void InsertXMInventoryInfo(XMInventoryInfo xminventoryinfo);

        /// <summary>
        /// Update into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
        void UpdateXMInventoryInfo(XMInventoryInfo xminventoryinfo);

        /// <summary>
        /// 定时程序   根据条件判断当前库存滞销情况
        /// </summary>
        void TimingGetInventoryStatus();

        /// <summary>
        /// get to XMInventoryInfo list
        /// </summary>
        List<XMInventoryInfo> GetXMInventoryInfoList();
        List<XMInventoryInfo> GetXMInventoryInfoListByWfIds(List<int> Ids);

        /// <summary>
        /// get to XMInventoryInfo  List by WareHouesesID
        /// </summary>
        /// <param name="wareHouesesID"></param>
        /// <returns></returns>
        List<XMInventoryInfo> GetXMInventoryInfoListByWareHouesesID(int wareHouesesID);

        /// <summary>
        /// get to XMInventoryInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryInfo Page List</returns>
        PagedList<XMInventoryInfo> SearchXMInventoryInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickids"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids2"></param>
        /// <param name="saleStatus"></param>
        /// <returns></returns>
        List<XMInventoryInfo> GetXMInventoryInfoByParm(string platformCode, string productName, string nickids, string wareHoursesID, int projectId, string nickids2, int saleStatus,bool isParent);

        /// <summary>
        /// nickid ==-1 && projectId!=-1
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickids"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMInventoryInfo> GetXMInventoryInfoByPorjectID(string platformCode, string productName, string wareHoursesID, string projectids, int projectId, int saleStatuts);

        /// <summary>
        /// 查询库存中低于警戒值的产品列表
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickID"></param>
        /// <param name="wareHoursesID"></param>
        /// <returns></returns>
        List<XMInventoryInfo> GetXMInventoryInfoByLessWarningNumber(string platformCode, string productName, string nicks, string wareHoursesID, int projectId, string nickids);
        List<XMInventoryInfo> GetXMInventoryInfoByLessWarningNumberListByPorjectID(string platformCode, string productName, int wareHoursesID, int projectId, string projectids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="wareHoursesID"></param>
        /// <returns></returns>
        XMInventoryInfo GetXMInventoryInfoByParm(string platformCode, int wareHoursesID);


        /// <summary>
        /// get a XMInventoryInfo by Id
        /// </summary>
        /// <param name="id">XMInventoryInfo Id</param>
        /// <returns>XMInventoryInfo</returns>   
        XMInventoryInfo GetXMInventoryInfoById(int id);

        /// <summary>
        /// delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfo Id</param>
        void DeleteXMInventoryInfo(int id);

        /// <summary>
        /// Batch delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfo Id</param>
        void BatchDeleteXMInventoryInfo(List<int> ids);

        #endregion
    }
}
