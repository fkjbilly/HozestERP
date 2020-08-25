
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 15:24:23
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMNickCustomerMappingService : IXMNickCustomerMappingService
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
        public XMNickCustomerMappingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMNickCustomerMappingService成员
        /// <summary>
        /// Insert into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
        public void InsertXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping)
        {
            if (xmnickcustomermapping == null)
                return;

            if (!this._context.IsAttached(xmnickcustomermapping))

                this._context.XMNickCustomerMappings.AddObject(xmnickcustomermapping);

            this._context.SaveChanges();
        }


        /// <summary>
        /// 批量新增店铺分配表
        /// </summary>
        /// <param name="NickIds">要分配的店铺列表</param>
        /// <param name="customerID">负责人ID</param>
        /// <param name="depId">部门Id</param>
        public void BatchMarkXMNickCustomerMappingsInsert(List<int> NickIds, int customerID, int depId)
        {
            foreach (var nickId in NickIds)
            {
                var query = from p in this._context.XMNickCustomerMappings
                            where  //NickIds.Contains(System.Convert.ToInt32(p.NickId))  
                            NickIds.Contains(p.NickId.Value)
                            && p.CustomerTypeID == (int)depId && p.CustomerID == (int)customerID
                            select p;
                var objLst = query.ToList();
                if (objLst.Count == 0)
                {
                    var contractCustomerMapping = new XMNickCustomerMapping()
                    {
                        NickId = nickId,
                        CustomerID = customerID,
                        CustomerTypeID = depId,
                        Created = DateTime.Now,
                        CreatorID = HozestERPContext.Current.User.CustomerID,
                        Updated = DateTime.Now,
                        UpdatorID = HozestERPContext.Current.User.CustomerID
                    };
                    _context.XMNickCustomerMappings.AddObject(contractCustomerMapping);
                }
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// 批量店铺 更改
        /// </summary>
        /// <param name="NickCustomerMappingIDs">分配表</param>
        /// <param name="NickIds">要分配的店铺列表</param>
        /// <param name="customerID">负责人ID</param>
        /// <param name="customerTypeEnum">人员类型</param> 
        public void BatchMarkXMNickCustomerMapping(List<int> NickCustomerMappingIDs, List<int> NickIds, int customerID, int customerTypeEnum)
        {//NickIds.Contains(System.Convert.ToInt32(p.NickId))  
            //NickCustomerMappingIDs.Contains(System.Convert.ToInt32(p.NickCustomerID))
            var query = from p in this._context.XMNickCustomerMappings
                        where
                        NickIds.Contains(p.NickId.Value)
                        && NickCustomerMappingIDs.Contains(p.NickCustomerID)
                        && p.CustomerTypeID == (int)customerTypeEnum
                        select p;
            foreach (var contractCustomer in query.ToList())
            {
                contractCustomer.CustomerID = customerID;
                contractCustomer.CustomerTypeID = customerTypeEnum;
                contractCustomer.Updated = DateTime.Now;
                contractCustomer.UpdatorID = HozestERPContext.Current.User.CustomerID;

                if (!_context.IsAttached(contractCustomer))
                    _context.XMNickCustomerMappings.Attach(contractCustomer);
            }

            //foreach (var nickId in NickIds)
            //{
            //    var contractCustomerMapping = new XMNickCustomerMapping()
            //    {
            //        NickId = nickId,
            //        CustomerID = customerID,
            //        CustomerTypeID = customerTypeEnum,
            //        Created = DateTime.Now,
            //        CreatorID = HozestERPContext.Current.User.CustomerID,
            //        Updated = DateTime.Now,
            //        UpdatorID = HozestERPContext.Current.User.CustomerID
            //    };
            //    _context.XMNickCustomerMappings.AddObject(contractCustomerMapping);

            //}

            _context.SaveChanges();
        }

        /// <summary>
        /// Update into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
        public void UpdateXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping)
        {
            if (xmnickcustomermapping == null)
                return;

            if (this._context.IsAttached(xmnickcustomermapping))
                this._context.XMNickCustomerMappings.Attach(xmnickcustomermapping);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMNickCustomerMapping list
        /// </summary>
        public List<XMNickCustomerMapping> GetXMNickCustomerMappingList()
        {
            var query = from p in this._context.XMNickCustomerMappings
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nick_id"></param>
        /// <returns></returns>
        public List<XMNickCustomerMapping> GetXMNickCustomerMappingList(int nick_id)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        where p.NickId == nick_id
                        orderby p.Created descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 根据customerId 查询对应店铺列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<XMNickCustomerMapping> GetProjectXMNickCustomerMappingListByCustomerID(int customerId)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        where p.CustomerID == customerId
                        orderby p.Created descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> GetNickCustomerIDs(int nickID)
        {
            List<int> myIDs = new List<int>();
            List<XMNickCustomerMapping> Info = GetXMNickCustomerMappingList(nickID);
            foreach (XMNickCustomerMapping p in Info)
            {
                  if(p!=null)
                  {
                      myIDs.Add(p.NickCustomerID);
                  }
            }
            return myIDs;
        }


        /// <summary>
        /// get to XMNickCustomerMapping Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickCustomerMapping Page List</returns>
        public PagedList<XMNickCustomerMapping> SearchXMNickCustomerMapping(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        orderby p.NickCustomerID
                        select p;
            return new PagedList<XMNickCustomerMapping>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="nickcustomerid">XMNickCustomerMapping NickCustomerID</param>
        /// <returns>XMNickCustomerMapping</returns>   
        public XMNickCustomerMapping GetXMNickCustomerMappingByNickCustomerID(int nickcustomerid)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        where p.NickCustomerID.Equals(nickcustomerid)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 通过人员类型获取业务员（项目部店铺管理）
        /// </summary>
        /// <param name="NickID">店铺ID</param>
        /// <param name="depId">部门ID</param>
        /// <param name="CustomerID">业务员ID</param>

        public XMNickCustomerMapping GetProjectXMNickCustomerMapping(int NickID, int depId, int CustomerID)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        where p.CustomerTypeID == depId && p.NickId == NickID && p.CustomerID == CustomerID
                        select p;
            return query.SingleOrDefault();
        }


        /// <summary>
        /// delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerID">XMNickCustomerMapping NickCustomerID</param>
        public void DeleteXMNickCustomerMapping(int nickcustomerid)
        {
            var xmnickcustomermapping = this.GetXMNickCustomerMappingByNickCustomerID(nickcustomerid);
            if (xmnickcustomermapping == null)
                return;

            if (!this._context.IsAttached(xmnickcustomermapping))
                this._context.XMNickCustomerMappings.Attach(xmnickcustomermapping);

            this._context.DeleteObject(xmnickcustomermapping);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerIDs">XMNickCustomerMapping NickCustomerID</param>
        public void BatchDeleteXMNickCustomerMapping(List<int> nickcustomerids)
        {
            var query = from q in _context.XMNickCustomerMappings
                        where nickcustomerids.Contains(q.NickCustomerID)
                        select q;
            var xmnickcustomermappings = query.ToList();
            foreach (var item in xmnickcustomermappings)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickCustomerMappings.Attach(item);

                _context.XMNickCustomerMappings.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
