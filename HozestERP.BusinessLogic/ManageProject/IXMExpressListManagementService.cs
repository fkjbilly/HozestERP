
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-10-27 11:05:07
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
    public partial interface IXMExpressListManagementService
    {
        #region IXMExpressListManagementService成员
        /// <summary>
        /// Insert into XMExpressListManagement
        /// </summary>
        /// <param name="xmexpresslistmanagement">XMExpressListManagement</param>
        void InsertXMExpressListManagement(XMExpressListManagement xmexpresslistmanagement);

        /// <summary>
        /// Update into XMExpressListManagement
        /// </summary>
        /// <param name="xmexpresslistmanagement">XMExpressListManagement</param>
        void UpdateXMExpressListManagement(XMExpressListManagement xmexpresslistmanagement);

        /// <summary>
        /// get to XMExpressListManagement list
        /// </summary>
        List<XMExpressListManagement> GetXMExpressListManagementList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="expressID"></param>
        /// <param name="provinceID"></param>
        /// <returns></returns>
        List<XMExpressListManagement> GetXMExpressListManagementByParm(string number, int year, int month, string expressID, string provinceID);

        List<XMNewExpressListManage> GetXMExpressListManagementByParm(int year, int month, string expressIDs);

        /// <summary>
        /// get to XMExpressListManagement Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMExpressListManagement Page List</returns>
        PagedList<XMExpressListManagement> SearchXMExpressListManagement(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMExpressListManagement by Id
        /// </summary>
        /// <param name="id">XMExpressListManagement Id</param>
        /// <returns>XMExpressListManagement</returns>   
        XMExpressListManagement GetXMExpressListManagementById(int id);
        /// <summary>
        /// 根据相关参数（物刘单号 年份  月份）
        /// </summary>
        /// <param name="expressID"></param>
        /// <param name="number"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        XMExpressListManagement GetXMExpressListManagementByParm(int expressID, string number, int year, int month);

        /// <summary>
        /// delete XMExpressListManagement by Id
        /// </summary>
        /// <param name="Id">XMExpressListManagement Id</param>
        void DeleteXMExpressListManagement(int id);

        /// <summary>
        /// Batch delete XMExpressListManagement by Id
        /// </summary>
        /// <param name="Ids">XMExpressListManagement Id</param>
        void BatchDeleteXMExpressListManagement(List<int> ids);

        #endregion
    }
}
