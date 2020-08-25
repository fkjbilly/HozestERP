
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-19 17:00:23
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial interface IAdvanceApplicationService
    {
        #region IAdvanceApplicationService成员
        /// <summary>
        /// Insert into AdvanceApplication
        /// </summary>
        /// <param name="advanceapplication">AdvanceApplication</param>
    	void InsertAdvanceApplication(AdvanceApplication advanceapplication);
    	
        /// <summary>
        /// Update into AdvanceApplication
        /// </summary>
        /// <param name="advanceapplication">AdvanceApplication</param>
        void UpdateAdvanceApplication(AdvanceApplication advanceapplication);	
    	
        /// <summary>
        /// get to AdvanceApplication list
        /// </summary>
        List<AdvanceApplication> GetAdvanceApplicationList();

 
        /// <summary>
        /// get to AdvanceApplication Page List
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="ManagerIsAudit">部门审核</param>
        /// <param name="FinanceIsAudit">财务审核</param>
        /// <param name="AdvanceState">暂支状态</param>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>AdvanceApplication Page List</returns>
        PagedList<AdvanceApplication> SearchAdvanceApplication(int PlatformTypeId,List<int> NickId,int ManagerIsAudit,int FinanceIsAudit,int FinanceOkIsAudit, int AdvanceState,string ScalpingCode, int pageIndex, int pageSize, string sortExpression, string sortDirection);


        /// <summary>
        /// 根据暂支类型、店铺名称、申请人、暂支状态查询
        /// </summary>
        /// <param name="TheAdvanceType">暂支类型</param>
        /// <param name="NickId">店铺名称</param>
        /// <param name="ApplicantsName">申请人</param>
        /// <param name="AdvanceState">暂支状态</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns></returns>
        PagedList<AdvanceApplication> SearchAdvanceApplication(int TheAdvanceType, int NickId, string ApplicantsName, int AdvanceState, string ScalpingCode, int pageIndex, int pageSize, string sortExpression, string sortDirection);
    

    	/// <summary>
        /// get a AdvanceApplication by Id
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        AdvanceApplication GetAdvanceApplicationById(int id);


        /// <summary>
        /// 根据刷单id 查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        List<AdvanceApplication> GetAdvanceApplicationByScalpingId(int ScalpingId);

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        List<AdvanceApplication> GetAdvanceApplicationListById(List<int> Id);



        /// <summary>
        /// 根据店铺Id查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        List<AdvanceApplication> GetAdvanceApplicationListByNickId(List<int> NickId);

    	/// <summary>
        /// delete AdvanceApplication by Id
        /// </summary>
        /// <param name="Id">AdvanceApplication Id</param>
        void DeleteAdvanceApplication(int id);
    	
    	/// <summary>
        /// Batch delete AdvanceApplication by Id
        /// </summary>
        /// <param name="Ids">AdvanceApplication Id</param>
        void BatchDeleteAdvanceApplication(List<int> ids);

        #endregion
    }
}
