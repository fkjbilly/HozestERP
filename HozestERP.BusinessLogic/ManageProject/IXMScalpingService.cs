
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-08 09:34:20
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
    public partial interface IXMScalpingService
    {
        #region IXMScalpingService成员
        /// <summary>
        /// Insert into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
    	void InsertXMScalping(XMScalping xmscalping);
    	
        /// <summary>
        /// Update into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
        void UpdateXMScalping(XMScalping xmscalping);	
    	
        /// <summary>
        /// get to XMScalping list
        /// </summary>
        List<XMScalping> GetXMScalpingList();
         
       /// <summary>
       /// 根据订单号查询
       /// </summary>
       /// <param name="OrderCode"></param>
       /// <returns></returns>
        List<XMScalping> GetXMScalpingByOrderCode(string OrderCode);


        /// <summary>
        /// 根据刷单Id查询
        /// </summary>
        /// <param name="ScalpingId">刷单Id</param>
        /// <returns></returns>
        List<XMScalping> GetXMScalpingByScalpingId(int ScalpingId);



        /// <summary>
        /// 根据刷单Id查询 (List<int>) //并判断刷单单号不等于null
        /// </summary>
        /// <param name="ScalpingId">刷单Id</param>
        /// <returns></returns>
        List<XMScalping> GetXMScalpingByIDs(List<int> IDs);



        /// <summary>
        /// 根据刷单Id、订单号 查询
        /// </summary>
        /// <param name="ScalpingId">刷单Id</param>
        /// <returns></returns>
        List<XMScalping> GetXMScalpingList(int ScalpingId, string OrderCode);  



        /// <summary>
       ///  刷单记录明细：根据订单付款时间 、返现状态：已返现
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickIdList">店铺集合</param>
       /// <param name="OrderInfoModifiedStart">订单付款开始时间</param>
       /// <param name="OrderInfoModifiedEnd">订单付款结束时间</param>
       /// <param name="CashBackStatus">返现状态：已返现</param>
        /// <param name="OrderStatusId">时间类型</param>
       /// <returns></returns>
        List<OrderInfoSalesDetails> GetXMScalpingDetailsList(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId);

        /// <summary>
        /// 获取刷拍成本
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="NickIdList"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <returns></returns>
        decimal getScalpingCost(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="OrderCode">订单编号</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalping  List</returns>
        List<XMScalping> SearchXMScalping(int PlatformTypeId, List<int> NickId, string ScalpingCode, string OrderCode, int IsAbnormal, DateTime? orderCreateStart, DateTime? orderCreateEnd);

        List<XMScalping> SearchXMScalpingYFK(int PlatformTypeId, List<int> NickId, string ScalpingCode, string OrderCode, int IsAbnormal, DateTime? orderCreateStart, DateTime? orderCreateEnd);
        

    	/// <summary>
        /// get a XMScalping by ID
        /// </summary>
        /// <param name="id">XMScalping ID</param>
        /// <returns>XMScalping</returns>   
        XMScalping GetXMScalpingByID(int id);
    
    	/// <summary>
        /// delete XMScalping by ID
        /// </summary>
        /// <param name="ID">XMScalping ID</param>
        void DeleteXMScalping(int id);
    	
    	/// <summary>
        /// Batch delete XMScalping by ID
        /// </summary>
        /// <param name="IDs">XMScalping ID</param>
        void BatchDeleteXMScalping(List<int> ids);

        /// <summary>
        /// 刷单批量打印查询
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<XMOrderInfo> GetXMOrderinfoShudan(int[] ids);

        #endregion
    }
}
