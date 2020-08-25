
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-07-16 14:53:29
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
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial interface IXMConsultationService
    {
        #region IXMConsultationService成员
        /// <summary>
        /// Insert into XMConsultation
        /// </summary>
        /// <param name="xmconsultation">XMConsultation</param>
        void InsertXMConsultation(XMConsultation xmconsultation);

        /// <summary>
        /// Update into XMConsultation
        /// </summary>
        /// <param name="xmconsultation">XMConsultation</param>
        void UpdateXMConsultation(XMConsultation xmconsultation);

        /// <summary>
        /// get to XMConsultation list
        /// </summary>
        List<XMConsultation> GetXMConsultationList();

        /// <summary>
        /// get to XMConsultation Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMConsultation Page List</returns>
        PagedList<XMConsultation> SearchXMConsultation(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMConsultation by Id
        /// </summary>
        /// <param name="id">XMConsultation Id</param>
        /// <returns>XMConsultation</returns>   
        XMConsultation GetXMConsultationById(int id);

        /// <summary>
        /// delete XMConsultation by Id
        /// </summary>
        /// <param name="Id">XMConsultation Id</param>
        void DeleteXMConsultation(int id);

        /// <summary>
        /// Batch delete XMConsultation by Id
        /// </summary>
        /// <param name="Ids">XMConsultation Id</param>
        void BatchDeleteXMConsultation(List<int> ids);

        /// <summary>
        /// 查询咨询跟进
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<XMConsultation> GetXMConsultationList(string IsOrder, int PlatformTypeId, int nickid, DateTime? starttime, DateTime? endtime, string cust, string creat, int paramPageIndex, int paramPageSize, int count, string grade, List<int?> a);

        List<CustomerInfo> GetCustomerServiceList(string DepCode);
        List<XMConsultation> GetDataAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> a, int Shift);
        List<XMDataAnalysy> GetDataAnalysisNoDealList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> a, string NoTurnoverType, int FollowCount, int Shift);
        string GetDepName(int DepartmentID);

        /// <summary>
        /// 根据条件查询是否重复
        /// </summary>
        /// <param name="id">XMConsultation Id</param>
        /// <returns>XMConsultation</returns>   
        XMConsultation GetXMConsultationByCx(int PlatformTypeId, string cust, string ManufacturersCode);

        XMConsultation GetXMConsultationByOrderCode(string OrderCode, string ManufacturersCode);
        #endregion
    }
}
