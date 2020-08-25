
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-02-02 16:29:59
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
    public partial interface IXMDeductionSetUpService
    {
        #region IXMDeductionSetUpService成员
        /// <summary>
        /// Insert into XMDeductionSetUp
        /// </summary>
        /// <param name="xmdeductionsetup">XMDeductionSetUp</param>
    	void InsertXMDeductionSetUp(XMDeductionSetUp xmdeductionsetup);
    	
        /// <summary>
        /// Update into XMDeductionSetUp
        /// </summary>
        /// <param name="xmdeductionsetup">XMDeductionSetUp</param>
        void UpdateXMDeductionSetUp(XMDeductionSetUp xmdeductionsetup);	
    	
        /// <summary>
        /// get to XMDeductionSetUp list
        /// </summary>
        List<XMDeductionSetUp> GetXMDeductionSetUpList();
    	       
       /// <summary>
       /// 根据项目Id  、平台类型Id 查询扣点设置数据信息
       /// </summary>
       /// <param name="ProjectId">项目id</param>
        /// <param name="PlatformTypeId">平台类型Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeductionSetUp Page List</returns>
        PagedList<XMDeductionSetUp> SearchXMDeductionSetUp(int ProjectId,int SpeciesTypeId, int PlatformTypeId, int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// 根据项目Id、平台类型Id查询
        /// </summary>
        /// <param name="ProjectId">项目Id</param>
        /// <param name="PlatformTypeId">平台类型Id</param>
        /// <returns></returns>
        XMDeductionSetUp GetXMDeductionSetUpByProjectAndPlatformTypeId(int ProjectId,int SpeciesTypeId, int PlatformTypeId);

    	/// <summary>
        /// get a XMDeductionSetUp by Id
        /// </summary>
        /// <param name="id">XMDeductionSetUp Id</param>
        /// <returns>XMDeductionSetUp</returns>   
        XMDeductionSetUp GetXMDeductionSetUpById(int id);
    
    	/// <summary>
        /// delete XMDeductionSetUp by Id
        /// </summary>
        /// <param name="Id">XMDeductionSetUp Id</param>
        void DeleteXMDeductionSetUp(int id);
    	
    	/// <summary>
        /// Batch delete XMDeductionSetUp by Id
        /// </summary>
        /// <param name="Ids">XMDeductionSetUp Id</param>
        void BatchDeleteXMDeductionSetUp(List<int> ids);

        #endregion
    }
}
