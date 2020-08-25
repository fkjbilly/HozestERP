
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-03-27 13:44:51
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
    public partial class XMJDRealTimeInventoryService : IXMJDRealTimeInventoryService
    {
        #region Fields
        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public XMJDRealTimeInventoryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMJDRealTimeInventoryService成员
        /// <summary>
        /// Insert into XMJDRealTimeInventory
        /// </summary>
        /// <param name="xmjdrealtimeinventory">XMJDRealTimeInventory</param>
        public void InsertXMJDRealTimeInventory(XMJDRealTimeInventory xmjdrealtimeinventory)
        {
            if (xmjdrealtimeinventory == null)
                return;

            if (!this._context.IsAttached(xmjdrealtimeinventory))

                this._context.XMJDRealTimeInventories.AddObject(xmjdrealtimeinventory);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMJDRealTimeInventory
        /// </summary>
        /// <param name="xmjdrealtimeinventory">XMJDRealTimeInventory</param>
        public void UpdateXMJDRealTimeInventory(XMJDRealTimeInventory xmjdrealtimeinventory)
        {
            if (xmjdrealtimeinventory == null)
                return;

            if (this._context.IsAttached(xmjdrealtimeinventory))
                this._context.XMJDRealTimeInventories.Attach(xmjdrealtimeinventory);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMJDRealTimeInventory list
        /// </summary>
        public List<XMJDRealTimeInventory> GetXMJDRealTimeInventoryList()
        {
            var query = from p in this._context.XMJDRealTimeInventories
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickids"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids2"></param>
        /// <returns></returns>
        public List<XMJDRealTimeInventory> GetXMJDRealTimeInventoryListByParm(string platformCode, string productName, string nickids, int wareHoursesID, int projectId, string nickids2)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nickIdlist.Count() > 0 && nickIdlist[0] != -1)
            {
                nick_id = int.Parse(nickIdlist[0].ToString());
            }
            int?[] nickIdlist2 = Array.ConvertAll<string, int?>(nickids2.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMJDRealTimeInventories
                        join t in this._context.XMWareHouses
                      on p.WfId equals t.Id
                        join m in this._context.XMProducts
                        on p.ProductId equals m.Id
                        where p.IsEnable == false
                          && (platformCode == "" || p.PlatformMerchantCode.Contains(platformCode))
                          && (productName == "" || m.ProductName.Contains(productName))
                          && (nick_id == -1 || nickIdlist.Contains(t.NickId))
                          && nickIdlist2.Contains(t.NickId)
                          && (wareHoursesID == -1 || p.WfId == wareHoursesID)
                          && (projectId == -1 || t.ProjectId == projectId)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMJDRealTimeInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDRealTimeInventory Page List</returns>
        public PagedList<XMJDRealTimeInventory> SearchXMJDRealTimeInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMJDRealTimeInventories
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMJDRealTimeInventory>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="id">XMJDRealTimeInventory Id</param>
        /// <returns>XMJDRealTimeInventory</returns>   
        public XMJDRealTimeInventory GetXMJDRealTimeInventoryById(int id)
        {
            var query = from p in this._context.XMJDRealTimeInventories
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformMerchantCode"></param>
        /// <param name="wfId"></param>
        /// <returns></returns>
        public XMJDRealTimeInventory GetXMJDRealTimeInventoryParm(string platformMerchantCode, int wfId)
        {
            var query = from p in this._context.XMJDRealTimeInventories
                        where p.IsEnable == false
                        && p.PlatformMerchantCode == platformMerchantCode
                        && p.WfId == wfId
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="Id">XMJDRealTimeInventory Id</param>
        public void DeleteXMJDRealTimeInventory(int id)
        {
            var xmjdrealtimeinventory = this.GetXMJDRealTimeInventoryById(id);
            if (xmjdrealtimeinventory == null)
                return;

            if (!this._context.IsAttached(xmjdrealtimeinventory))
                this._context.XMJDRealTimeInventories.Attach(xmjdrealtimeinventory);

            this._context.DeleteObject(xmjdrealtimeinventory);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="Ids">XMJDRealTimeInventory Id</param>
        public void BatchDeleteXMJDRealTimeInventory(List<int> ids)
        {
            var query = from q in _context.XMJDRealTimeInventories
                        where ids.Contains(q.Id)
                        select q;
            var xmjdrealtimeinventorys = query.ToList();
            foreach (var item in xmjdrealtimeinventorys)
            {
                if (!_context.IsAttached(item))
                    _context.XMJDRealTimeInventories.Attach(item);

                _context.XMJDRealTimeInventories.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
