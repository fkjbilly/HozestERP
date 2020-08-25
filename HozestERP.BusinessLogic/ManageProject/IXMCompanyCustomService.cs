
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-30 10:31:27
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
    public partial interface IXMCompanyCustomService
    {
        #region IXMCompanyCustomService成员
        /// <summary>
        /// Insert into XMCompanyCustom
        /// </summary>
        /// <param name="xmcompanycustom">XMCompanyCustom</param>
    	void InsertXMCompanyCustom(XMCompanyCustom xmcompanycustom);
    	
        /// <summary>
        /// Update into XMCompanyCustom
        /// </summary>
        /// <param name="xmcompanycustom">XMCompanyCustom</param>
        void UpdateXMCompanyCustom(XMCompanyCustom xmcompanycustom);	
    	
        /// <summary>
        /// get to XMCompanyCustom list
        /// </summary>
        List<XMCompanyCustom> GetXMCompanyCustomList();
        List<XMCompanyCustom> GetXMCompanyCustomListByCompanyCode(string CompanyCode);
    	       
    	/// <summary>
    	/// get to XMCompanyCustom Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMCompanyCustom Page List</returns>
    	PagedList<XMCompanyCustom> SearchXMCompanyCustom(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMCompanyCustom by Id
        /// </summary>
        /// <param name="id">XMCompanyCustom Id</param>
        /// <returns>XMCompanyCustom</returns>   
        XMCompanyCustom GetXMCompanyCustomById(int id);
    
    	/// <summary>
        /// delete XMCompanyCustom by Id
        /// </summary>
        /// <param name="Id">XMCompanyCustom Id</param>
        void DeleteXMCompanyCustom(int id);
    	
    	/// <summary>
        /// Batch delete XMCompanyCustom by Id
        /// </summary>
        /// <param name="Ids">XMCompanyCustom Id</param>
        void BatchDeleteXMCompanyCustom(List<int> ids);

        XMCompanyCustom GetXMCompanyCustomByLogisticsName(string LogisticsName, int PlatformTypeId);

        XMCompanyCustom GetXMCompanyCustomByLogisticId(string LoginsiticId);

        /// <summary>
        /// 根据 店铺Id、平台Id查询
        /// </summary>
        /// <param name="NickId">店铺Id</param>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <returns></returns>
        List<XMCompanyCustom> GetXMCompanyCustomByNickIdAndPlatformTypeId(int NickId, int PlatformTypeId);

        #endregion
    }
}
