
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 15:24:22
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
    public partial interface IXMNickCustomerMappingService
    {
        #region IXMNickCustomerMappingService成员
        /// <summary>
        /// Insert into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
        void InsertXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping);

        /// <summary>
        /// 批量新增店铺分配表
        /// </summary>
        /// <param name="NickIds">要分配的店铺列表</param>
        /// <param name="customerID">负责人ID</param>
        /// <param name="customerTypeEnum">人员类型</param>
        void BatchMarkXMNickCustomerMappingsInsert(List<int> NickIds, int customerID, int customerTypeEnum);
        /// <summary>
        /// 批量店铺 更改
        /// </summary>
        /// <param name="NickCustomerMappingIDs">分配表</param>
        /// <param name="NickIds">要分配的店铺列表</param>
        /// <param name="customerID">负责人ID</param>
        /// <param name="customerTypeEnum">人员类型</param>
        void BatchMarkXMNickCustomerMapping(List<int> NickCustomerMappingIDs, List<int> NickIds, int customerID, int customerTypeEnum);

        /// <summary>
        /// Update into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
        void UpdateXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping);

        /// <summary>
        /// get to XMNickCustomerMapping list
        /// </summary>
        List<XMNickCustomerMapping> GetXMNickCustomerMappingList();

        /// <summary>
        /// 分页获取返回用户信息
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <param name="fullName"></param>
        /// <param name="departmentID"></param>
        /// <param name="enterpriseID"></param>
        /// <param name="CustomerStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<XMNickCustomerMapping> GetXMNickCustomerMappingList(int nick_id);
        /// <summary>
        /// 通过customerId  查询mapping数据
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<XMNickCustomerMapping> GetProjectXMNickCustomerMappingListByCustomerID(int customerId);

        List<int> GetNickCustomerIDs(int nickID);

        /// <summary>
        /// get to XMNickCustomerMapping Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickCustomerMapping Page List</returns>
        PagedList<XMNickCustomerMapping> SearchXMNickCustomerMapping(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="nickcustomerid">XMNickCustomerMapping NickCustomerID</param>
        /// <returns>XMNickCustomerMapping</returns>   
        XMNickCustomerMapping GetXMNickCustomerMappingByNickCustomerID(int nickcustomerid);

        /// <summary>
        /// 通过店铺ID 部门ID 人员ID获取业务员（项目部店铺管理）
        /// </summary>
        /// <param name="NickID">店铺ID</param>
        /// <param name="depId">部门ID</param>
        /// <param name="customerID">人员ID</param>
        /// <returns></returns>
        XMNickCustomerMapping GetProjectXMNickCustomerMapping(int NickID, int depId, int customerID);

        /// <summary>
        /// delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerID">XMNickCustomerMapping NickCustomerID</param>
        void DeleteXMNickCustomerMapping(int nickcustomerid);

        /// <summary>
        /// Batch delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerIDs">XMNickCustomerMapping NickCustomerID</param>
        void BatchDeleteXMNickCustomerMapping(List<int> nickcustomerids);

        #endregion
    }
}
