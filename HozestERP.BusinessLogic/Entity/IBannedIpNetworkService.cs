
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial interface IBannedIpNetworkService
    {
        #region IBannedIpNetworkService成员
        /// <summary>
        /// Insert into BannedIpNetwork
        /// </summary>
        /// <param name="bannedipnetwork">BannedIpNetwork</param>
    	void InsertBannedIpNetwork(BannedIpNetwork bannedipnetwork);
    	
        /// <summary>
        /// Update into BannedIpNetwork
        /// </summary>
        /// <param name="bannedipnetwork">BannedIpNetwork</param>
        void UpdateBannedIpNetwork(BannedIpNetwork bannedipnetwork);	
    	
        /// <summary>
        /// get to BannedIpNetwork list
        /// </summary>
        List<BannedIpNetwork> GetBannedIpNetworkList();
    	       
    	/// <summary>
    	/// get to BannedIpNetwork Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>BannedIpNetwork Page List</returns>
    	PagedList<BannedIpNetwork> SearchBannedIpNetwork(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a BannedIpNetwork by BannedIpNetworkID
        /// </summary>
        /// <param name="bannedipnetworkid">BannedIpNetwork BannedIpNetworkID</param>
        /// <returns>BannedIpNetwork</returns>   
        BannedIpNetwork GetBannedIpNetworkByBannedIpNetworkID(int bannedipnetworkid);
    
    	/// <summary>
        /// delete BannedIpNetwork by BannedIpNetworkID
        /// </summary>
        /// <param name="BannedIpNetworkID">BannedIpNetwork BannedIpNetworkID</param>
        void DeleteBannedIpNetwork(int bannedipnetworkid);
    	
    	/// <summary>
        /// Batch delete BannedIpNetwork by BannedIpNetworkID
        /// </summary>
        /// <param name="BannedIpNetworkIDs">BannedIpNetwork BannedIpNetworkID</param>
        void BatchDeleteBannedIpNetwork(List<int> bannedipnetworkids);

        #endregion
    }
}
