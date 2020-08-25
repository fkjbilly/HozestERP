
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-08-03 14:08:15
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial interface IXMZMReservationService
    {
        #region IXMZMReservationService成员
        /// <summary>
        /// Insert into XMZMReservation
        /// </summary>
        /// <param name="xmzmreservation">XMZMReservation</param>
    	void InsertXMZMReservation(XMZMReservation xmzmreservation);
    	
        /// <summary>
        /// Update into XMZMReservation
        /// </summary>
        /// <param name="xmzmreservation">XMZMReservation</param>
        void UpdateXMZMReservation(XMZMReservation xmzmreservation);	
    	
        /// <summary>
        /// get to XMZMReservation list
        /// </summary>
        List<XMZMReservation> GetXMZMReservationList();

        XMZMReservation GetXMZMReservationListByInstallationID(int InstallationID, int paramTypeID);

        List<XMZMReservation> GetXMZMReservationByRID(int ID);
    	       
    	/// <summary>
    	/// get to XMZMReservation Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMZMReservation Page List</returns>
    	PagedList<XMZMReservation> SearchXMZMReservation(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMZMReservation by ID
        /// </summary>
        /// <param name="id">XMZMReservation ID</param>
        /// <returns>XMZMReservation</returns>   
        XMZMReservation GetXMZMReservationByID(int id);
        XMZMReservation GetXMZMReservationByXMInstallationListID(int id);
    
    	/// <summary>
        /// delete XMZMReservation by ID
        /// </summary>
        /// <param name="ID">XMZMReservation ID</param>
        void DeleteXMZMReservation(int id);
    	
    	/// <summary>
        /// Batch delete XMZMReservation by ID
        /// </summary>
        /// <param name="IDs">XMZMReservation ID</param>
        void BatchDeleteXMZMReservation(List<int> ids);

        #endregion
    }
}
