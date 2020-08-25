
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
    public partial interface IBannedIpAddressService
    {
        #region IBannedIpAddressService成员
        /// <summary>
        /// Insert into BannedIpAddress
        /// </summary>
        /// <param name="bannedipaddress">BannedIpAddress</param>
    	void InsertBannedIpAddress(BannedIpAddress bannedipaddress);
    	
        /// <summary>
        /// Update into BannedIpAddress
        /// </summary>
        /// <param name="bannedipaddress">BannedIpAddress</param>
        void UpdateBannedIpAddress(BannedIpAddress bannedipaddress);	
    	
        /// <summary>
        /// get to BannedIpAddress list
        /// </summary>
        List<BannedIpAddress> GetBannedIpAddressList();
    	       
    	/// <summary>
    	/// get to BannedIpAddress Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>BannedIpAddress Page List</returns>
    	PagedList<BannedIpAddress> SearchBannedIpAddress(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a BannedIpAddress by BannedIpAddressID
        /// </summary>
        /// <param name="bannedipaddressid">BannedIpAddress BannedIpAddressID</param>
        /// <returns>BannedIpAddress</returns>   
        BannedIpAddress GetBannedIpAddressByBannedIpAddressID(int bannedipaddressid);
    
    	/// <summary>
        /// delete BannedIpAddress by BannedIpAddressID
        /// </summary>
        /// <param name="BannedIpAddressID">BannedIpAddress BannedIpAddressID</param>
        void DeleteBannedIpAddress(int bannedipaddressid);
    	
    	/// <summary>
        /// Batch delete BannedIpAddress by BannedIpAddressID
        /// </summary>
        /// <param name="BannedIpAddressIDs">BannedIpAddress BannedIpAddressID</param>
        void BatchDeleteBannedIpAddress(List<int> bannedipaddressids);

        #endregion
    }
}
