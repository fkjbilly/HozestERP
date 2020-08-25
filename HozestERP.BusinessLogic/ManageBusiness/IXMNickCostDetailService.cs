
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-29 09:08:36
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
    public partial interface IXMNickCostDetailService
    {
        #region IXMNickCostDetailService成员
        /// <summary>
        /// Insert into XMNickCostDetail
        /// </summary>
        /// <param name="xmnickcostdetail">XMNickCostDetail</param>
        void InsertXMNickCostDetail(XMNickCostDetail xmnickcostdetail);

        /// <summary>
        /// Update into XMNickCostDetail
        /// </summary>
        /// <param name="xmnickcostdetail">XMNickCostDetail</param>
        void UpdateXMNickCostDetail(XMNickCostDetail xmnickcostdetail);

        /// <summary>
        /// get to XMNickCostDetail list
        /// </summary>
        List<XMNickCostDetail> GetXMNickCostDetailList();

        /// <summary>
        /// get to XMNickCostDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickCostDetail Page List</returns>
        PagedList<XMNickCostDetail> SearchXMNickCostDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMNickCostDetail by Id
        /// </summary>
        /// <param name="id">XMNickCostDetail Id</param>
        /// <returns>XMNickCostDetail</returns>   
        XMNickCostDetail GetXMNickCostDetailById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectID"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        XMNickCostDetail GetXMNickCostDataByParm(int id, int projectID, int year);

       List<XMNickCostDetail> GetXMNickCostDataByParm2(int projectID, int year);

       List<XMNickCostDetail> GetXMNickCostDataByParm3(int projectID, int year);

       List<XMNickCostDetail> GetXMNickDataByParm4(int projectID, int year, int parentID);

       List<XMNickCostDetail> GetXMNickCostByData(int ProjectId, int year, int FinancialFieldId);

        /// <summary>
        /// delete XMNickCostDetail by Id
        /// </summary>
        /// <param name="Id">XMNickCostDetail Id</param>
        void DeleteXMNickCostDetail(int id);

        /// <summary>
        /// Batch delete XMNickCostDetail by Id
        /// </summary>
        /// <param name="Ids">XMNickCostDetail Id</param>
        void BatchDeleteXMNickCostDetail(List<int> ids);

        #endregion
    }
}
