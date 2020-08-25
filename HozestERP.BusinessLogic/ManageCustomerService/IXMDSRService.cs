
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-05-27 15:07:07
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
    public partial interface IXMDSRService
    {
        #region IXMDSRService成员
        /// <summary>
        /// Insert into XMDSR
        /// </summary>
        /// <param name="xmdsr">XMDSR</param>
    	void InsertXMDSR(XMDSR xmdsr);
    	
        /// <summary>
        /// Update into XMDSR
        /// </summary>
        /// <param name="xmdsr">XMDSR</param>
        void UpdateXMDSR(XMDSR xmdsr);	
    	
        /// <summary>
        /// get to XMDSR list
        /// </summary>
        List<XMDSR> GetXMDSRList(int NickId,int PlatformTypeId,string Month);
    	       
    	/// <summary>
    	/// get to XMDSR Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMDSR Page List</returns>
    	PagedList<XMDSR> SearchXMDSR(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMDSR by ID
        /// </summary>
        /// <param name="id">XMDSR ID</param>
        /// <returns>XMDSR</returns>   
        XMDSR GetXMDSRByID(int id);
    
    	/// <summary>
        /// delete XMDSR by ID
        /// </summary>
        /// <param name="ID">XMDSR ID</param>
        void DeleteXMDSR(int id);
    	
    	/// <summary>
        /// Batch delete XMDSR by ID
        /// </summary>
        /// <param name="IDs">XMDSR ID</param>
        void BatchDeleteXMDSR(List<int> ids);

        #endregion
    }
}
