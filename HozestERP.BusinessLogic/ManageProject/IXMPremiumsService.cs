
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-02-10 09:55:48
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
    public partial interface IXMPremiumsService
    {
        #region IXMPremiumsService成员
        /// <summary>
        /// Insert into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
        void InsertXMPremiums(XMPremiums xmpremiums);

        /// <summary>
        /// Insert into XMPremiums
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantId">旺旺号</param>
        /// <param name="ActivityExplanation">活动说明</param>
        int InsertXMPremiums(string OrderCode, string WantId, int PremiumsTypeId, string ActivityExplanation, bool paramIsEvaluation,decimal price,int platformTypeID,int nickID);

        /// <summary>
        /// Update into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
        void UpdateXMPremiums(XMPremiums xmpremiums);

        /// <summary>
        /// get to XMPremiums list
        /// </summary>
        List<XMPremiums> GetXMPremiumsList();
        XMPremiums GetXMPremiumsListByQuestionDetailID(string QuestionDetailID);

        /// <summary>
        /// 根据订单号查询、类型查询
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        List<XMPremiums> GetXMPremiumsListByOrderCode(string OrderCode, int PremiumsTypeId);

        /// <summary>
        /// 根据订单号查询、类型查询、商品编码
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        List<XMPremiums> GetXMPremiumsListByOrderCodeproductcode(string OrderCode, int PremiumsTypeId, string productcode);

        List<XMPremiums> GetXMPremiumsListByCreateTime(DateTime Begin);

        /// <summary>
        /// 根据条件查询 赠品信息
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="PremiumsStatus">赠品状态</param> 
        /// <param name="ManagerStatus">运营审核</param>
        /// <param name="IsSingleRow">是否排单</param>
        /// <param name="PremiumsTypeId">//申请类型：赠品:11、赔付：10</param>
        /// <returns></returns>
        List<XMPremiums> GetXMPremiumsList(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="PremiumsStatus"></param>
        /// <param name="ManagerStatus"></param>
        /// <param name="IsSingleRow"></param>
        /// <param name="PremiumsTypeId"></param>
        /// <param name="FullName"></param>
        /// <param name="Mobile"></param>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        List<XMPremiums> GetXMPremiumsListNoOrder(DateTime? min, DateTime? max, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId, string FullName, string Mobile, string OrderCode);

        /// <summary>
        /// 根据条件查询 赠品信息(关联订单表 状态是确认收货)
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="PremiumsStatus">赠品状态</param> 
        /// <param name="ManagerStatus">运营审核</param>
        /// <param name="IsSingleRow">是否排单</param>
        /// <param name="PremiumsTypeId">//申请类型：赠品:11、赔付：10</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        List<XMPremiums> GetXMPremiumsListByOrderStatus(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId, List<string> OrderStatus, bool paramIsEvaluation, string paramActivityExplanation, bool IsYMX);

        /// <summary>
        /// 根据条件查询 赠品信息(关联订单表 状态是已付款)
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="PremiumsStatus">赠品状态</param> 
        /// <param name="ManagerStatus">运营审核</param>
        /// <param name="IsSingleRow">是否排单</param>
        /// <param name="PremiumsTypeId">//申请类型：赠品:11、赔付：10</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        List<XMPremiums> GetXMPremiumsListByPay(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId, List<string> OrderStatus, bool paramIsEvaluation, string paramActivityExplanation);


        /// <summary>
        /// get to XMPremiums Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPremiums Page List</returns>
        PagedList<XMPremiums> SearchXMPremiums(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMPremiums by Id
        /// </summary>
        /// <param name="id">XMPremiums Id</param>
        /// <returns>XMPremiums</returns>   
        XMPremiums GetXMPremiumsById(int id);

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns> 
        List<XMPremiums> GetXMPremiumsByListIds(List<int> Ids);

        /// <summary>
        /// delete XMPremiums by Id
        /// </summary>
        /// <param name="Id">XMPremiums Id</param>
        void DeleteXMPremiums(int id);

        /// <summary>
        /// Batch delete XMPremiums by Id
        /// </summary>
        /// <param name="Ids">XMPremiums Id</param>
        void BatchDeleteXMPremiums(List<int> ids);

        #endregion
    }
}
