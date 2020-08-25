
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-07-07 10:13:35
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
    public partial interface IXMAdvertisingFeeService
    {
        #region IXMAdvertisingFeeService成员
        /// <summary>
        /// Insert into XMAdvertisingFee
        /// </summary>
        /// <param name="xmadvertisingfee">XMAdvertisingFee</param>
        void InsertXMAdvertisingFee(XMAdvertisingFee xmadvertisingfee);

        /// <summary>
        /// Update into XMAdvertisingFee
        /// </summary>
        /// <param name="xmadvertisingfee">XMAdvertisingFee</param>
        void UpdateXMAdvertisingFee(XMAdvertisingFee xmadvertisingfee);

        /// <summary>
        /// get to XMAdvertisingFee list
        /// </summary>
        List<XMAdvertisingFee> GetXMAdvertisingFeeList();

        /// <summary>
        /// get to XMAdvertisingFee Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdvertisingFee Page List</returns>
        PagedList<XMAdvertisingFee> SearchXMAdvertisingFee(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// 根据条件查询广告费用
        /// </summary>
        /// <param name="NickId">店铺列表</param>
        /// <param name="min">开始时间</param>
        /// <param name="max">结束时间</param>
        /// <returns></returns>
        List<XMAdvertisingFee> GetXMXMAdvertisingFeeByDetails(List<int> NickId, DateTime? min, DateTime? max);
        
        List<XMAdvertisingFee> GetXMXMAdvertisingFeeByParm(int nickId);

        /// <summary>
        /// 根据某店铺条件查询广告费用
        /// </summary>
        /// <param name="NickId">店铺</param>
        /// <param name="min">时间</param>
        /// <returns></returns>
        List<XMAdvertisingFee> GetXMByIdmin(int NickId, DateTime? min);

        /// <summary>
        /// get a XMAdvertisingFee by Id
        /// </summary>
        /// <param name="id">XMAdvertisingFee Id</param>
        /// <returns>XMAdvertisingFee</returns>   
        XMAdvertisingFee GetXMAdvertisingFeeById(int id);

        /// <summary>
        /// delete XMAdvertisingFee by Id
        /// </summary>
        /// <param name="Id">XMAdvertisingFee Id</param>
        void DeleteXMAdvertisingFee(int id);

        /// <summary>
        /// Batch delete XMAdvertisingFee by Id
        /// </summary>
        /// <param name="Ids">XMAdvertisingFee Id</param>
        void BatchDeleteXMAdvertisingFee(List<int> ids);

        #endregion
    }
}
