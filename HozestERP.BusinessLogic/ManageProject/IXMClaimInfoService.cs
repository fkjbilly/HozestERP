
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-07-28 17:30:52
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
    public partial interface IXMClaimInfoService
    {
        #region IXMClaimInfoService成员
        /// <summary>
        /// Insert into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
        void InsertXMClaimInfo(XMClaimInfo xmclaiminfo);

        /// <summary>
        /// Update into XMClaimInfo
        /// </summary>
        /// <param name="xmclaiminfo">XMClaimInfo</param>
        void UpdateXMClaimInfo(XMClaimInfo xmclaiminfo);

        /// <summary>
        /// get to XMClaimInfo list
        /// </summary>
        List<XMClaimInfo> GetXMClaimInfoList();
        List<XMClaimInfo> GetXMClaimInfoListByDate(string Begin,string End);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName">客户姓名</param>
        /// <param name="orderCode">订单号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="isReturn">是否退回</param>
        /// <param name="projectId">项目</param>
        /// <param name="nickids">店铺</param>
        /// <param name="responsiblePerson">责任人姓名</param>
        /// <returns></returns>
        List<XMClaimInfo> GetXMClaimInfoListByParm(string fullName, string orderCode, string claimCode, string begin, string end, int isReturn, int projectId, string nickids, string responsiblePerson);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="orderCode"></param>
        /// <param name="claimCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="isReturn"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids"></param>
        /// <param name="claimTypeID"></param>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        List<XMClaimInfo> GetXMClaimInfoListByParm(string fullName, string orderCode, string claimCode, string begin, string end, int isReturn, int projectId, string nickids, int claimTypeID, int isConfirm);
        /// <summary>
        /// get to XMClaimInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfo Page List</returns>
        PagedList<XMClaimInfo> SearchXMClaimInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMClaimInfo by Id
        /// </summary>
        /// <param name="id">XMClaimInfo Id</param>
        /// <returns>XMClaimInfo</returns>   
        XMClaimInfo GetXMClaimInfoById(int id);
        XMClaimInfo GetXMClaimInfoByPremiumsId(int PremiumsId);

        XMClaimInfo GetXMClaimInfoByLogisticsNumber(string logisticsNumber);

        /// <summary>
        /// delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Id">XMClaimInfo Id</param>
        void DeleteXMClaimInfo(int id);

        /// <summary>
        /// Batch delete XMClaimInfo by Id
        /// </summary>
        /// <param name="Ids">XMClaimInfo Id</param>
        void BatchDeleteXMClaimInfo(List<int> ids);

        #endregion
    }
}
