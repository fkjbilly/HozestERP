
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
    public partial interface IEnterpriseService
    {
        #region IEnterpriseService成员
        /// <summary>
        /// Insert into Enterprise
        /// </summary>
        /// <param name="enterprise">Enterprise</param>
    	void InsertEnterprise(Enterprise enterprise);
    	
        /// <summary>
        /// Update into Enterprise
        /// </summary>
        /// <param name="enterprise">Enterprise</param>
        void UpdateEnterprise(Enterprise enterprise);	
    	
        /// <summary>
        /// get to Enterprise list
        /// </summary>
        List<Enterprise> GetEnterpriseList();
    	       
    	/// <summary>
    	/// get to Enterprise Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Enterprise Page List</returns>
    	PagedList<Enterprise> SearchEnterprise(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Enterprise by EntId
        /// </summary>
        /// <param name="entid">Enterprise EntId</param>
        /// <returns>Enterprise</returns>   
        Enterprise GetEnterpriseByEntId(int entid);
    
    	/// <summary>
        /// delete Enterprise by EntId
        /// </summary>
        /// <param name="EntId">Enterprise EntId</param>
        void DeleteEnterprise(int entid);
    	
    	/// <summary>
        /// Batch delete Enterprise by EntId
        /// </summary>
        /// <param name="EntIds">Enterprise EntId</param>
        void BatchDeleteEnterprise(List<int> entids);

        #endregion
    }
}
