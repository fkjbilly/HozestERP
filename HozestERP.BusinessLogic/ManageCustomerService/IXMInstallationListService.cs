
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial interface IXMInstallationListService
    {
        #region IXMInstallationListService成员
        /// <summary>
        /// Insert into XMInstallationList
        /// </summary>
        /// <param name="xminstallationlist">XMInstallationList</param>
    	void InsertXMInstallationList(XMInstallationList xminstallationlist);
    	
        /// <summary>
        /// Update into XMInstallationList
        /// </summary>
        /// <param name="xminstallationlist">XMInstallationList</param>
        void UpdateXMInstallationList(XMInstallationList xminstallationlist);	
    	
        /// <summary>
        /// get to XMInstallationList list
        /// </summary>
        List<XMInstallationList> GetXMInstallationListList();
    	       
    	/// <summary>
    	/// get to XMInstallationList Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMInstallationList Page List</returns>
    	PagedList<XMInstallationList> SearchXMInstallationList(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMInstallationList by ID
        /// </summary>
        /// <param name="id">XMInstallationList ID</param>
        /// <returns>XMInstallationList</returns>   
        XMInstallationList GetXMInstallationListByID(int id);
    
    	/// <summary>
        /// delete XMInstallationList by ID
        /// </summary>
        /// <param name="ID">XMInstallationList ID</param>
        void DeleteXMInstallationList(int id);
    	
    	/// <summary>
        /// Batch delete XMInstallationList by ID
        /// </summary>
        /// <param name="IDs">XMInstallationList ID</param>
        void BatchDeleteXMInstallationList(List<int> ids);

        /// <summary>
        /// 判断安装单是否已存在
        /// </summary>
        /// <param name="ordercode">订单编号</param>
        /// <param name="address">安装地址</param>
        /// <returns>记录条数</returns>
        int JudgmentRepetition(string ordercode, string address);

        int GetXMInstallationIDByOrderCode(string id);

        string GetXMInstallationOrderCode(string OrderCode);

          /// <summary>
        /// 查询
        /// </summary>
        /// <param name="paramWintID">买家ID</param>
        /// <param name="paramOrderCode">订单号</param>
        /// <param name="CustomerName">客户姓名</param>
        /// <param name="CustomerTel">客户电话</param>
        /// <returns></returns>
        List<XMInstallationList> SearchXMInstallationList(string paramWintID, string paramOrderCode, string CustomerName, string CustomerTel, int paramIsArrange, int paramIsInstall);

        List<XMInstallationListNew> SearchXMInstallationList2(string paramWintID, string paramOrderCode, string CustomerName, string CustomerTel, int paramIsArrange, int paramIsInstall,int ddXMProject,string Nick,string start,string end);

        List<InstallationCount> getInstallationFinish(int projectID, int nickID, string start, string end, string header);
        /// <summary>
        /// 统计安装费用
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickIdList">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">订单付款开始时间</param>
        /// <param name="OrderInfoModifiedEnd">订单付款结束时间</param>
        /// <returns></returns>
        decimal InstallationCost(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd);
        #endregion
    }
}
