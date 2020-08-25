
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-12-13 09:24:35
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial interface IXMBillsService
    {
        #region IXMBillsService成员
        /// <summary>
        /// Insert into XMBills
        /// </summary>
        /// <param name="xmbills">XMBills</param>
    	void InsertXMBills(XMBills xmbills);
        /// <summary>
        /// Update into XMBills
        /// </summary>
        /// <param name="xmbills">XMBills</param>
        void UpdateXMBills(XMBills xmbills);	
    	
        /// <summary>
        /// get to XMBills list
        /// </summary>
        List<XMBills> GetXMBillsList();
    	       
    	/// <summary>
    	/// get to XMBills Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMBills Page List</returns>
    	PagedList<XMBills> SearchXMBills(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMBills by BillID
        /// </summary>
        /// <param name="billid">XMBills BillID</param>
        /// <returns>XMBills</returns>   
        XMBills GetXMBillsByBillID(int billid);
    
    	/// <summary>
        /// delete XMBills by BillID
        /// </summary>
        /// <param name="BillID">XMBills BillID</param>
        void DeleteXMBills(int billid);
    	
    	/// <summary>
        /// Batch delete XMBills by BillID
        /// </summary>
        /// <param name="BillIDs">XMBills BillID</param>
        void BatchDeleteXMBills(List<int> billids);

        #endregion

        /// <summary>
        /// get to XMBills list
        /// </summary>
        System.Collections.Generic.List<XMBills> GetXMBillsListSearch(string SuppliersID, string VerificationStatus, string DeliveryId, string PlatformMerchantCode, DateTime CreateDateEBegin, DateTime CreateDateEnd);

        /// <summary>
        /// Insert into List<XMBills>
        /// </summary>
        /// <param name="xmbills">XMBills</param>
        void InsertXMBills(List<XMBills> xmbills);

        /// <summary>
        /// Update into List<XMBills>
        /// </summary>
        /// <param name="xmbills">XMBills</param>
        void UpdateXMBills(List<XMBills> xmbills,Dictionary<string,string> Dic);

      

        /// <summary>
        /// get to XMBills list
        /// <param name="billsIdList">List<BillID></param>
        /// </summary>
        List<XMBills> GetXMBillsList(List<int> billsIdList);

        /// <summary>
        /// update into XMDeliveryDetails
        /// <param name="dic">存储发货单号和核销状态的字典</param>
        /// </summary>
        void UpdateXMDelivery(Dictionary<string,string> dic);
        /// <summary>
        /// 返回核销状态对应的text
        /// </summary>
        /// <param name="VerificationStatus">核销状态</param>
        /// <returns></returns>
        string ReturnStatusText(string VerificationStatus);
        /// <summary>
        /// 返回供应商名称
        /// </summary>
        /// <param name="VerificationStatus">供应商ID</param>
        /// <returns></returns>
        string ReturnSuppliersName(int SuppliersId);
    }
}
