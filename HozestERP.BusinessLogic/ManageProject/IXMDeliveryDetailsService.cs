
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-04-09 10:25:22
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
    public partial interface IXMDeliveryDetailsService
    {
        #region IXMDeliveryDetailsService成员
        /// <summary>
        /// Insert into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
    	void InsertXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails);
    	
        /// <summary>
        /// Update into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
        void UpdateXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails);	
    	
        /// <summary>
        /// get to XMDeliveryDetails list
        /// </summary>
        List<XMDeliveryDetails> GetXMDeliveryDetailsList();
    	       
    	/// <summary>
    	/// get to XMDeliveryDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMDeliveryDetails Page List</returns>
    	PagedList<XMDeliveryDetails> SearchXMDeliveryDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMDeliveryDetails by Id
        /// </summary>
        /// <param name="id">XMDeliveryDetails Id</param>
        /// <returns>XMDeliveryDetails</returns>   
        XMDeliveryDetails GetXMDeliveryDetailsById(int id);

    	/// <summary>
        /// delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Id">XMDeliveryDetails Id</param>
        void DeleteXMDeliveryDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Ids">XMDeliveryDetails Id</param>
        void BatchDeleteXMDeliveryDetails(List<int> ids);



        /// <summary>
        /// 根据主表Id查询
        /// </summary>
        /// <param name="DeliveryId">主表Id</param>
        /// <returns></returns>
        List<XMDeliveryDetails> GetXMDeliveryDetailsByDeliveryId(int DeliveryId);



        /// <summary>
        /// 根据明细Id查询
        /// </summary>
        /// <param name="Ids">明细Id集合</param>
        /// <returns></returns>
        List<XMDeliveryDetails> GetXMDeliveryDetailsById(List<int> Ids);


         /// <summary>
        /// 根据订单号、是否发货、未打印 查询 
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="IsDelivery">是否发货：0：未发货，1 :已发货</param>
        /// <param name="PrintQuantity">打印次数 ：0：未打印</param>
        /// <returns></returns>
        List<XMDeliveryDetails> GetXMDeliveryDetailsSearchByOrderCodeList(string OrderCode, int IsDelivery, int PrintQuantity);

        List<XMDeliveryDetailsMapping> GetXMDeliveryDetailsMappingSearch(string OrderCode, string PartNo);

        /// <summary>
        /// 根据 发货单主表Id查询详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<XMDeliveryDetailsMapping> GetXMDeliveryDetailsMappingSearchList(int Id);
        #endregion

        /// <summary>
        /// 根据发货单ID和商品编码查询对应的发货单详细信息
        /// </summary>
        /// <param name="DeliveryNumberList">发货单号</param>
        /// <param name="PlatformMerchantCode">商品编码</param>
        /// <returns></returns>
        IEnumerable<dynamic> GetXMDeliveryDetailsList(List<string> DeliveryNumberList);
    }
}
