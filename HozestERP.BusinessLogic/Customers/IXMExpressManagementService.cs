
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-10-12 10:51:25
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial interface IXMExpressManagementService
    {
        #region IXMExpressManagementService成员
        /// <summary>
        /// Insert into XMExpressManagement
        /// </summary>
        /// <param name="xmexpressmanagement">XMExpressManagement</param>
        void InsertXMExpressManagement(XMExpressManagement xmexpressmanagement);

        /// <summary>
        /// Update into XMExpressManagement
        /// </summary>
        /// <param name="xmexpressmanagement">XMExpressManagement</param>
        void UpdateXMExpressManagement(XMExpressManagement xmexpressmanagement);

        /// <summary>
        /// get to XMExpressManagement list
        /// </summary>
        List<XMExpressManagement> GetXMExpressManagementList();
        List<XMExpressManagement> GetXMExpressManagementListByParam(string CourierNumber, int DepartmentID, List<int?> CustomerInfoIDs, string ReceivingName, int Print);
        /// <summary>
        /// get to XMExpressManagement list by  CourierNumber
        /// </summary>
        /// <param name="CourierNumber"></param>
        /// <returns></returns>
        List<XMExpressManagement> GetXMExpressManagementListByCourierNumber(string CourierNumber);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<XMExpressManagement> GetXMExpressManagementListByparm(int year, int month, string expressID);



        /// <summary>
        /// get to XMExpressManagement Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMExpressManagement Page List</returns>
        PagedList<XMExpressManagement> SearchXMExpressManagement(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMExpressManagement by ID
        /// </summary>
        /// <param name="id">XMExpressManagement ID</param>
        /// <returns>XMExpressManagement</returns>   
        XMExpressManagement GetXMExpressManagementByID(int id);

        /// <summary>
        /// get a XMExpressManagement by ID
        /// </summary>
        /// <param name="id">XMExpressManagement ID</param>
        /// <returns>XMExpressManagement</returns>   
        List<XMExpressManagement> GetXMExpressManagementByID(List<int> ids);

        /// <summary>
        /// delete XMExpressManagement by ID
        /// </summary>
        /// <param name="ID">XMExpressManagement ID</param>
        void DeleteXMExpressManagement(int id);

        /// <summary>
        /// Batch delete XMExpressManagement by ID
        /// </summary>
        /// <param name="IDs">XMExpressManagement ID</param>
        void BatchDeleteXMExpressManagement(List<int> ids);

        #endregion
    }
}
