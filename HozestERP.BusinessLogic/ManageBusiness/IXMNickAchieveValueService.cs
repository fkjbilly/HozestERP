
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-01-04 17:32:49
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial interface IXMNickAchieveValueService
    {
        #region IXMNickAchieveValueService成员
        /// <summary>
        /// Insert into XMNickAchieveValue
        /// </summary>
        /// <param name="xm_nickachievevalue">XMNickAchieveValue</param>
    	void InsertXMNickAchieveValue(XMNickAchieveValue xmnickachievevalue);
    	
        /// <summary>
        /// Update into XMNickAchieveValue
        /// </summary>
        /// <param name="xm_nickachievevalue">XMNickAchieveValue</param>
        void UpdateXMNickAchieveValue(XMNickAchieveValue xmnickachievevalue);	
    	
        /// <summary>
        /// get to XMNickAchieveValue list
        /// </summary>
        List<XMNickAchieveValue> GetXMNickAchieveValueList();

        List<XMNickAchieveValue> GetXMNickAchieveValueListByData(List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd);
    	       
    	/// <summary>
    	/// get to XMNickAchieveValue Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XM_NickAchieveValue Page List</returns>
    	PagedList<XMNickAchieveValue> SearchXMNickAchieveValue(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XM_NickAchieveValue by Id
        /// </summary>
        /// <param name="id">XMNickAchieveValue Id</param>
        /// <returns>XMNickAchieveValue</returns>   
        XMNickAchieveValue GetXMNickAchieveValueById(int id);

        /// <summary>
        /// XMNickAchieveValue
        /// </summary> 
        /// <returns></returns>
        int GetXMNickAchieveValueListAll(int NickID, DateTime dateTime);
    
    	/// <summary>
        /// delete XMNickAchieveValue by Id
        /// </summary>
        /// <param name="Id">XMNickAchieveValue Id</param>
        void DeleteXMNickAchieveValue(int id);
    	
    	/// <summary>
        /// Batch delete XMNickAchieveValue by Id
        /// </summary>
        /// <param name="Ids">XMNickAchieveValue Id</param>
        void BatchDeleteXMNickAchieveValue(List<int> ids);

        #endregion
    }
}
