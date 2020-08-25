
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
    public partial interface IXMDailySaleInfoService
    {
        #region IXMDailySaleInfoService成员
        /// <summary>
        /// Insert into XMDailySaleInfo
        /// </summary>
        /// <param name="xmdailysaleinfo">XMDailySaleInfo</param>
        void InsertXMDailySaleInfo(XMDailySaleInfo xmdailysaleinfo);

        /// <summary>
        /// Update into XMDailySaleInfo
        /// </summary>
        /// <param name="xmdailysaleinfo">XMDailySaleInfo</param>
        void UpdateXMDailySaleInfo(XMDailySaleInfo xmdailysaleinfo);

        /// <summary>
        /// get to XMDailySaleInfo list
        /// </summary>
        List<XMDailySaleInfo> GetXMDailySaleInfoList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        List<XMDailySaleInfo> GetXMDailySaleInfoListByParm(string productCode, string productName, string begin, string end, int projectID, int nickID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="activityDate"></param>
        /// <param name="projectID"></param>
        /// <param name="nickID"></param>
        /// <returns></returns>
        List<XMDailySaleInfo> GetXMDailySaleInfoByParm(string productCode, DateTime activityDate, int projectID, int nickID);

        /// <summary>
        /// 查询当前时间产品数据
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        XMDailySaleInfo GetXMDailySaleInfoByPlatformMerchantCodeAndDate(string productCode, DateTime currentDate);

        /// <summary>
        /// get to XMDailySaleInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDailySaleInfo Page List</returns>
        PagedList<XMDailySaleInfo> SearchXMDailySaleInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMDailySaleInfo by Id
        /// </summary>
        /// <param name="id">XMDailySaleInfo Id</param>
        /// <returns>XMDailySaleInfo</returns>   
        XMDailySaleInfo GetXMDailySaleInfoById(int id);

        /// <summary>
        /// delete XMDailySaleInfo by Id
        /// </summary>
        /// <param name="Id">XMDailySaleInfo Id</param>
        void DeleteXMDailySaleInfo(int id);

        /// <summary>
        /// Batch delete XMDailySaleInfo by Id
        /// </summary>
        /// <param name="Ids">XMDailySaleInfo Id</param>
        void BatchDeleteXMDailySaleInfo(List<int> ids);

        #endregion
    }
}
