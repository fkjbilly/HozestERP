
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-08-04 09:20:45
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

namespace HozestERP.BusinessLogic.ManageApplication
{
    public partial interface IXMApplicationService
    {
        #region IXMApplicationService成员
        /// <summary>
        /// Insert into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
        void InsertXMApplication(XMApplication xmapplication);

        /// <summary>
        /// Update into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
        void UpdateXMApplication(XMApplication xmapplication);

        /// <summary>
        /// get to XMApplication list
        /// </summary>
        List<XMApplication> GetXMApplicationList();
        List<XMApplication> GetXMApplicationListByApplicationNo(string ApplicationNo);
        List<XMApplication> GetDataAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> a, int ApplicationType);
        int GetNickCount(List<XMApplication> Questionlist, int PlatformTypeId, int NickId);
        List<XMApplicationReport> GetXMApplicationReportData(int Platform,int Nick,int TimeType,int ApplicaType,DateTime BeginDate,DateTime EndDate,int Type);
        /// <summary>
        /// get to XMApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMApplication Page List</returns>
        PagedList<XMApplication> SearchXMApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMApplication by ID
        /// </summary>
        /// <param name="id">XMApplication ID</param>
        /// <returns>XMApplication</returns>   
        XMApplication GetXMApplicationByID(int id);

        /// <summary>
        /// delete XMApplication by ID
        /// </summary>
        /// <param name="ID">XMApplication ID</param>
        void DeleteXMApplication(int id);

        /// <summary>
        /// Batch delete XMApplication by ID
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        void BatchDeleteXMApplication(List<int> ids);

        /// <summary>
        /// 退换货
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        List<XMApplication> GetXMConsultationList(int Platform, int nickid, int timetype, int ApplicaType, int Supervisor, int Financial, int Send, string SrvAfterCustomerID, DateTime? BeginDate, DateTime? EndDate, List<int?> a,string Tel,string fullName);

        /// <summary>
        /// 退款金额详细
        /// </summary>
        List<XMApplication> GetXMConsultationListByData(int platform, List<int?> nickIdList, string OrderCode, DateTime? BeginDate, DateTime? EndDate, int timeType);
        List<XMApplication> GetXMApplicationExcelData(int platform, List<int> nickIdList, string OrderCode, DateTime? BeginDate, DateTime? EndDate, int timeType);
        List<XMApplication> GetXMApplicationListByReturnTime(DateTime Begin, DateTime End, List<int?> ApplicationTypeList);
        List<XMApplication> GetXMApplicationListByFinishTime(DateTime Begin, DateTime End, int ApplicationType);
        List<XMApplicationExchange> GetXMConsultationListByDataByBrandType(List<XMApplication> List, int BrandType);

        /// <summary>
        /// 退换货订单导出
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        List<XMApplication> GetXMEXList(int ddlPlatform, List<int> nickid, DateTime? txtBeginDate, DateTime? txtEndDate);

        /// <summary>
        /// 根据订单号查询该订单的退换货记录
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        List<XMApplication> GetXMApplicationListByOrderCode(string OrderCode);


        /// <summary>
        /// 根据退换货Id集合 查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        List<XMApplication> GetXMApplicationListByIds(List<int> Ids);
        #endregion

    }
}
