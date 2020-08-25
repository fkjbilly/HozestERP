
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-07-14 10:23:22
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
    public partial interface IXMActivityService
    {
        #region IXMActivityService成员
        /// <summary>
        /// Insert into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
        void InsertXMActivity(XMActivity xmactivity);

        /// <summary>
        /// Update into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
        void UpdateXMActivity(XMActivity xmactivity);

        /// <summary>
        /// get to XMActivity list
        /// </summary>
        List<XMActivity> GetXMActivityList();
       /// <summary>
        /// 根据相关条件查询相关记录
       /// </summary>
       /// <param name="activityTypeID"></param>
       /// <param name="begin"></param>
       /// <param name="end"></param>
       /// <param name="productName"></param>
       /// <param name="projectID"></param>
       /// <param name="nickID"></param>
       /// <returns></returns>
        List<XMActivity> GetXMActivityListByParm(int activityTypeID, string begin, string end, string productName, int projectID, int nickID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityTypeID"></param>
        /// <returns></returns>
        List<XMActivity> GetXMActivityListByactivityTypeID(int activityTypeID);
        /// <summary>
        /// 根据活动时间和商品编码获取活动信息
        /// </summary>
        /// <param name="activtyDate"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        XMActivity GetXMActivityByParm(DateTime activtyDate, string platformMerchantCode);

        /// <summary>
        /// get to XMActivity Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMActivity Page List</returns>
        PagedList<XMActivity> SearchXMActivity(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMActivity by Id
        /// </summary>
        /// <param name="id">XMActivity Id</param>
        /// <returns>XMActivity</returns>   
        XMActivity GetXMActivityById(int id);

        /// <summary>
        /// delete XMActivity by Id
        /// </summary>
        /// <param name="Id">XMActivity Id</param>
        void DeleteXMActivity(int id);

        /// <summary>
        /// Batch delete XMActivity by Id
        /// </summary>
        /// <param name="Ids">XMActivity Id</param>
        void BatchDeleteXMActivity(List<int> ids);

        #endregion
    }
}
