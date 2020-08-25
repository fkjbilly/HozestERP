
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
    public partial interface IACLService
    {
        #region IACLService成员
        /// <summary>
        /// Insert into ACL
        /// </summary>
        /// <param name="acl">ACL</param>
    	void InsertACL(ACL acl);
    	
        /// <summary>
        /// Update into ACL
        /// </summary>
        /// <param name="acl">ACL</param>
        void UpdateACL(ACL acl);	
    	
        /// <summary>
        /// get to ACL list
        /// </summary>
        List<ACL> GetACLList();
    	       
    	/// <summary>
    	/// get to ACL Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>ACL Page List</returns>
    	PagedList<ACL> SearchACL(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a ACL by ACLID
        /// </summary>
        /// <param name="aclid">ACL ACLID</param>
        /// <returns>ACL</returns>   
        ACL GetACLByACLID(int aclid);
    
    	/// <summary>
        /// delete ACL by ACLID
        /// </summary>
        /// <param name="ACLID">ACL ACLID</param>
        void DeleteACL(int aclid);
    	
    	/// <summary>
        /// Batch delete ACL by ACLID
        /// </summary>
        /// <param name="ACLIDs">ACL ACLID</param>
        void BatchDeleteACL(List<int> aclids);

        #endregion
    }
}
