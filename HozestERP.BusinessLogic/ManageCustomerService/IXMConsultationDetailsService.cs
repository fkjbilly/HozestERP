
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial interface IXMConsultationDetailsService
    {
        #region IXMConsultationDetailsService成员
        /// <summary>
        /// Insert into XMConsultationDetails
        /// </summary>
        /// <param name="xmconsultationdetails">XMConsultationDetails</param>
    	void InsertXMConsultationDetails(XMConsultationDetails xmconsultationdetails);
    	
        /// <summary>
        /// Update into XMConsultationDetails
        /// </summary>
        /// <param name="xmconsultationdetails">XMConsultationDetails</param>
        void UpdateXMConsultationDetails(XMConsultationDetails xmconsultationdetails);	
    	
        /// <summary>
        /// get to XMConsultationDetails list
        /// </summary>
        List<XMConsultationDetails> GetXMConsultationDetailsList();
    	       
    	/// <summary>
    	/// get to XMConsultationDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMConsultationDetails Page List</returns>
    	PagedList<XMConsultationDetails> SearchXMConsultationDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMConsultationDetails by id
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        /// <returns>XMConsultationDetails</returns>   
        XMConsultationDetails GetXMConsultationDetailsByid(int id);
    
    	/// <summary>
        /// delete XMConsultationDetails by id
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        void DeleteXMConsultationDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMConsultationDetails by id
        /// </summary>
        /// <param name="ids">XMConsultationDetails id</param>
        void BatchDeleteXMConsultationDetails(List<int> ids);

        /// <summary>
        /// 根据主表id查询聊天记录
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        /// <returns>XMConsultationDetails</returns>   
        XMConsultationDetails GetXMConsultationDetailsByConid(int id);

        /// <summary>
        /// 根据主表id查询聊天记录时间的总数
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        /// <returns>XMConsultationDetails</returns>   
        int GetXMConsultationDetailsCount(int id);

        /// <summary>
        /// 根据主表id查询聊天记录
        /// </summary>
        /// <param name="id">XMConsultationDetails id</param>
        /// <returns>XMConsultationDetails</returns>   
        List<XMConsultationDetails> GetXMConsultationDetailsByClist(int id);

        #endregion
    }
}
