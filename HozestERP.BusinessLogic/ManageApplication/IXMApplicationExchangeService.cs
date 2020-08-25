
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-08-04 09:20:45
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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageApplication
{
    public partial interface IXMApplicationExchangeService
    {
        #region IXMApplicationExchangeService成员
        /// <summary>
        /// Insert into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
        void InsertXMApplicationExchange(XMApplicationExchange xmapplicationexchange);

        /// <summary>
        /// Update into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
        void UpdateXMApplicationExchange(XMApplicationExchange xmapplicationexchange);

        /// <summary>
        /// get to XMApplicationExchange list
        /// </summary>
        List<XMApplicationExchange> GetXMApplicationExchangeList();
        List<ProductSalesData> GetApplicationExchangeSalesArrange(List<XMApplicationExchange> DataList);
        List<XMApplicationExchange> GetApplicationExchangeSales(DateTime Begin, DateTime End, int ApplicaType, bool GoodsNotConfirmSendOut, bool GoodsConfirmSendOut, bool GoodsConfirmReturn, List<int?> NickIdList);

        /// <summary>
        /// get to XMApplicationExchange Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMApplicationExchange Page List</returns>
        PagedList<XMApplicationExchange> SearchXMApplicationExchange(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMApplicationExchange by ID
        /// </summary>
        /// <param name="id">XMApplicationExchange ID</param>
        /// <returns>XMApplicationExchange</returns>   
        XMApplicationExchange GetXMApplicationExchangeByID(int id);

        /// <summary>
        /// delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="ID">XMApplicationExchange ID</param>
        void DeleteXMApplicationExchange(int id);

        /// <summary>
        /// Batch delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="IDs">XMApplicationExchange ID</param>
        void BatchDeleteXMApplicationExchange(List<int> ids);

        /// <summary>
        /// 根据退换货主表id查询子表内容
        /// </summary>
        List<XMApplicationExchange> GetXMApplicationExchangeByAppID(int? AppId, int type, int type2, int type3);

        /// <summary>
        /// 根据退换货主表id查询子表内容
        /// </summary>
        /// <param name="AppId"></param>
        /// <returns></returns>
        List<XMApplicationExchange> GetXMApplicationExchangeByAppID(int? AppId);

        /// <summary>
        /// 根据退换货主表id查询子表内容
        /// </summary>
        XMApplicationExchange GetXMApplicationExchangeByIsOrID(int? AppId, int scid, int type);

        /// <summary>
        /// 根据退换货主表id查询子表内容聊表
        /// </summary>
        List<XMApplicationExchange> GetXMApplicationExchangeByIsOrIDlist(int? AppId, int scid, int type);

        /// <summary>
        /// 根据订单换过货产品id查询子表内容列表
        /// </summary>
        List<XMApplicationExchange> GetXMApplicationExchangeByIsNewOrIDlist(int? AppId, int scid, int type);

        List<XMApplicationExchange> GetXMApplicationExchangeListByApplicationIDType(int ApplicationID, int Type);

        /// <summary>
        /// 查询指定id换货成功的产品
        /// </summary>
        List<XMApplicationExchange> GetXMApplicationExchangeByFinlist(string OrderCode, int type);

        List<XMApplicationExchange> GetXMApplicationExchangeByOrderCodeAndType(string OrderCode, int type, int scid);

        /// <summary>
        /// 根据订单换过货产品id查询子表内容
        /// </summary>
        XMApplicationExchange GetXMApplicationExchangeByIsNewOrID(int? AppId, int scid, int type);

        #endregion
    }
}
