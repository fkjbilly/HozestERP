
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
    public partial interface IXMAdjustedInfoService
    {
        #region IXMAdjustedInfoService成员
        /// <summary>
        /// Insert into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
        void InsertXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo);

        /// <summary>
        /// Update into XMAdjustedInfo
        /// </summary>
        /// <param name="xmadjustedinfo">XMAdjustedInfo</param>
        void UpdateXMAdjustedInfo(XMAdjustedInfo xmadjustedinfo);

        /// <summary>
        /// get to XMAdjustedInfo list
        /// </summary>
        List<XMAdjustedInfo> GetXMAdjustedInfoList();

        /// <summary>
        /// get to XMAdjustedInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdjustedInfo Page List</returns>
        PagedList<XMAdjustedInfo> SearchXMAdjustedInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustedCode"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="wareHousesId"></param>
        /// <returns></returns>
        List<XMAdjustedInfo> GetXMAdjustedInfoByParm(string adjustedCode, string Begin, string End, string wareHousesId, int projectId, string nickids);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustedCode"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="wareHousesId"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMAdjustedInfo> GetXMAdjustedInfoByProjectID(string adjustedCode, string Begin, string End, int wareHousesId, string projectids, int projectId);

        /// <summary>
        /// 根据单号查询
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        XMAdjustedInfo GetXMAdjustedInfoByRef(string code);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesID"></param>
        /// <returns></returns>
        List<XMAdjustedInfo> GetXMAdjustedInfoByWareHousesID(int wareHousesID);

        /// <summary>
        /// get a XMAdjustedInfo by Id
        /// </summary>
        /// <param name="id">XMAdjustedInfo Id</param>
        /// <returns>XMAdjustedInfo</returns>   
        XMAdjustedInfo GetXMAdjustedInfoById(int id);

        /// <summary>
        /// delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Id">XMAdjustedInfo Id</param>
        void DeleteXMAdjustedInfo(int id);

        /// <summary>
        /// Batch delete XMAdjustedInfo by Id
        /// </summary>
        /// <param name="Ids">XMAdjustedInfo Id</param>
        void BatchDeleteXMAdjustedInfo(List<int> ids);

        #endregion
    }
}
