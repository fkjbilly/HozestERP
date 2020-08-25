
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-28 16:34:18
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMLogisticsInfoService
    {
        #region IXMLogisticsInfoService成员
        /// <summary>
        /// Insert into XMLogisticsInfo
        /// </summary>
        /// <param name="xmlogisticsinfo">XMLogisticsInfo</param>
        void InsertXMLogisticsInfo(XMLogisticsInfo xmlogisticsinfo);

        /// <summary>
        /// Update into XMLogisticsInfo
        /// </summary>
        /// <param name="xmlogisticsinfo">XMLogisticsInfo</param>
        void UpdateXMLogisticsInfo(XMLogisticsInfo xmlogisticsinfo);

        /// <summary>
        /// get to XMLogisticsInfo list
        /// </summary>
        List<XMLogisticsInfo> GetXMLogisticsInfoList();
        List<XMLogisticsInfo> GetXMLogisticsInfoListByParam();

        List<XMLogisticsProject> getXMLogisticsProjectList(string beginDate,string endDate,string logisticsID);

        /// <summary>
        /// 根据订单信息表主键ID查询订单产品物流跟踪信息
        /// </summary>
        /// <param name="OrderInfoId"></param>
        /// <returns></returns>
        List<XMLogisticsInfo> GetXMLogisticsInfoListByOrderInfoID(int OrderInfoId);

        /// <summary>
        /// get to XMLogisticsInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsInfo Page List</returns>
        PagedList<XMLogisticsInfo> SearchXMLogisticsInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMLogisticsInfo by Id
        /// </summary>
        /// <param name="id">XMLogisticsInfo Id</param>
        /// <returns>XMLogisticsInfo</returns>   
        XMLogisticsInfo GetXMLogisticsInfoById(int id);

        /// <summary>
        /// delete XMLogisticsInfo by Id
        /// </summary>
        /// <param name="Id">XMLogisticsInfo Id</param>
        void DeleteXMLogisticsInfo(int id);

        /// <summary>
        /// Batch delete XMLogisticsInfo by Id
        /// </summary>
        /// <param name="Ids">XMLogisticsInfo Id</param>
        void BatchDeleteXMLogisticsInfo(List<int> ids);

        #endregion
    }
}
