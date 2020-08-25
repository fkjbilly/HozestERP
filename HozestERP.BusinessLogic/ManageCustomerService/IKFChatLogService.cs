
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-24 16:05:05
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
    public partial interface IKFChatLogService
    {
        #region IKFChatLogService成员
        /// <summary>
        /// Insert into KFChatLog
        /// </summary>
        /// <param name="kfchatlog">KFChatLog</param>
    	void InsertKFChatLog(KFChatLog kfchatlog);
    	
        /// <summary>
        /// Update into KFChatLog
        /// </summary>
        /// <param name="kfchatlog">KFChatLog</param>
        void UpdateKFChatLog(KFChatLog kfchatlog);	
    	
        /// <summary>
        /// get to KFChatLog list
        /// </summary>
        List<KFChatLog> GetKFChatLogList();

        /// <summary>
        /// get to KFChatLog list
        /// </summary>
        List<KFChatLog> GetKFChatLogList(string customer, string waiter);
    	/// <summary>
    	/// get to KFChatLog Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>KFChatLog Page List</returns>
    	PagedList<KFChatLog> SearchKFChatLog(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a KFChatLog by Id
        /// </summary>
        /// <param name="id">KFChatLog Id</param>
        /// <returns>KFChatLog</returns>   
        KFChatLog GetKFChatLogById(long id);
    
    	/// <summary>
        /// delete KFChatLog by Id
        /// </summary>
        /// <param name="Id">KFChatLog Id</param>
        void DeleteKFChatLog(long id);
    	
    	/// <summary>
        /// Batch delete KFChatLog by Id
        /// </summary>
        /// <param name="Ids">KFChatLog Id</param>
        void BatchDeleteKFChatLog(List<long> ids);

        /// <summary>
        /// 360buy.order.get 根据订单id获取单个订单(京东)
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        void getSessionList(DateTime start_date, DateTime end_date, List<XMOrderInfoApp> orderInfoAppList);

        /// <summary>
        /// 定时抓取聊天记录
        /// </summary>
        void doJob();

        /// <summary>
        /// 查询最后聊天时间
        /// </summary> 
        DateTime GetFinTime();

        #endregion
    }
}
