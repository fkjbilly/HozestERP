
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-30 10:31:27
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.PlatOrderGrab
{
    public partial interface IJD
    {
         #region 京东同步订单
        /// <summary>
        ///  京东订单检索（360buy.order.search）
        ///  定时同步时使用
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="orderState"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        string GetOrderList(string startDate, string endDate, string orderState, string page, string pageSize, out Int32 totalCount, bool recursive);
        #endregion
    }
}
