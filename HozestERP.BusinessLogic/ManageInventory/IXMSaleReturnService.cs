
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:13
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMSaleReturnService
    {
        #region IXMSaleReturnService成员
        /// <summary>
        /// Insert into XMSaleReturn
        /// </summary>
        /// <param name="xmsalereturn">XMSaleReturn</param>
        void InsertXMSaleReturn(XMSaleReturn xmsalereturn);

        /// <summary>
        /// Update into XMSaleReturn
        /// </summary>
        /// <param name="xmsalereturn">XMSaleReturn</param>
        void UpdateXMSaleReturn(XMSaleReturn xmsalereturn);

        /// <summary>
        /// get to XMSaleReturn list
        /// </summary>
        List<XMSaleReturn> GetXMSaleReturnList();
        List<XMSaleReturn> GetXMSaleReturnListByDate(DateTime Begin, DateTime End, List<int?> WareHousesList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleReturnCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        List<XMSaleReturn> GetXMSaleReturnListByParm(string saleReturnCode, string begin, string end, string wareHoursesIDs, int status, int projectId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleReturnCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="status"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMSaleReturn> GetXMSaleReturnListByPorjectID(string saleReturnCode, string begin, string end, int wareHoursesID, int status, string projectids, int projectId);
        /// <summary>
        ///  get to XMSaleReturn list  by  WareHoursesID
        /// </summary>
        /// <param name="wareHousesID"></param>
        /// <returns></returns>
        List<XMSaleReturn> GetXMSaleReturnListByWareHoursesID(int wareHousesID);
        /// <summary>
        /// get to XMSaleReturn Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleReturn Page List</returns>
        PagedList<XMSaleReturn> SearchXMSaleReturn(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMSaleReturn by Id
        /// </summary>
        /// <param name="id">XMSaleReturn Id</param>
        /// <returns>XMSaleReturn</returns>   
        XMSaleReturn GetXMSaleReturnById(int id);

        /// <summary>
        /// delete XMSaleReturn by Id
        /// </summary>
        /// <param name="Id">XMSaleReturn Id</param>
        void DeleteXMSaleReturn(int id);

        /// <summary>
        /// Batch delete XMSaleReturn by Id
        /// </summary>
        /// <param name="Ids">XMSaleReturn Id</param>
        void BatchDeleteXMSaleReturn(List<int> ids);

        #endregion
    }
}
