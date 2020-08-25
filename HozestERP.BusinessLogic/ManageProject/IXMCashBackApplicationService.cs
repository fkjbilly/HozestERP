
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-19 14:14:47
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMCashBackApplicationService
    {
        #region IXMCashBackApplicationService成员
        /// <summary>
        /// Insert into XMCashBackApplication
        /// </summary>
        /// <param name="xmcashbackapplication">XMCashBackApplication</param>
    	void InsertXMCashBackApplication(XMCashBackApplication xmcashbackapplication);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="BuyerName">姓名</param>
        /// <param name="CashBackMoney">金额</param>
        /// <param name="BuyerAlipayNo">收款账号</param>
        /// <param name="ApplicationTypeId">申请类型：返现、赔付</param>
        /// <param name="Dmoney">返现设置—金额（小于不需要运营审核，大于需运营审核）</param>
        /// <param name="Finance">财务限额</param>
        int InsertXMCashBackApplication(string OrderCode, string WantNo, string BuyerName, decimal CashBackMoney, string BuyerAlipayNo,int  ApplicationTypeId,decimal Dmoney, decimal Finance);
    	
        /// <summary>
        /// Update into XMCashBackApplication
        /// </summary>
        /// <param name="xmcashbackapplication">XMCashBackApplication</param>
        void UpdateXMCashBackApplication(XMCashBackApplication xmcashbackapplication);

        /// <summary>
        /// 根据订单号、旺旺号、收款账号查询
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="BuyerAlipayNo">收款账号</param> 
    	/// <param name="ManagerStatus">店长审核状态</param> 
        /// <param name="CashBackStatus">返现状态</param>
        /// <param name="ApplicationTypeId">申请类型</param>
    	/// <returns></returns>
        List<XMCashBackApplication> GetXMCashBackApplicationList(DateTime? min, DateTime? max, int PlatformId, string  NickId, int ProjectId, string OrderCode, string WantNo, string BuyerAlipayNo, int ManagerStatus, int CashBackStatus, int ApplicationTypeId);
        List<XMCashBackApplication> GetXMCashBackApplicationListNoOrder(DateTime? min, DateTime? max, string NickId, int ProjectId, string OrderCode, string WantNo, string BuyerAlipayNo, int ManagerStatus, int CashBackStatus, int ApplicationTypeId);
        List<XMCashBackApplication> GetXMCashBackApplicationListByQuestionDetailID(string QuestionDetailID);

        /// <summary>
        ///  返现明细：根据订单付款时间 、返现状态：已返现
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickIdList">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="CashBackStatus">返现状态：已返现</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> GetXMCashBackApplicationDetailsList(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int CashBackStatus, int OrderStatusId);

        /// <summary>
        /// 获取返现成本
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="NickIdList"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <param name="CashBackStatus"></param>
        /// <returns></returns>
        decimal getCashBackCost(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int CashBackStatus);

        /// <summary>
        /// 返现明细：
        /// </summary>
        /// <param name="OrderInfoListNew">订单集合</param>
        /// <param name="CashBackStatus">返现状态</param>
        /// <returns></returns>
        //List<XMCashBackApplication> GetXMCashBackApplicationDetailsList(List<OrderInfoSalesDetails> OrderInfoListNew, int CashBackStatus);


        /// <summary>
        /// get to XMCashBackApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCashBackApplication Page List</returns>
        PagedList<XMCashBackApplication> SearchXMCashBackApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
    	/// 根据订单号查询
    	/// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="ApplicationTypeId">返现类型：返现、赔付</param>
    	/// <returns></returns>
        List<XMCashBackApplication> GetXMCashBackApplicationByOrderCode(string OrderCode, int ApplicationTypeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        XMCashBackApplication GetXMCashBackApplicationById(int id);


        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        List<XMCashBackApplication> GetXMCashBackApplicationByIdList(List<int> Id);
    
    	/// <summary>
        /// delete XMCashBackApplication by Id
        /// </summary>
        /// <param name="Id">XMCashBackApplication Id</param>
        void DeleteXMCashBackApplication(int id);
    	
    	/// <summary>
        /// Batch delete XMCashBackApplication by Id
        /// </summary>
        /// <param name="Ids">XMCashBackApplication Id</param>
        void BatchDeleteXMCashBackApplication(List<int> ids);

        #endregion
    }
}
