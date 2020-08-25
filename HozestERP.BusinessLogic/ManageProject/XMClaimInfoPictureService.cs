
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-02-14 13:41:17
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMClaimInfoPictureService : IXMClaimInfoPictureService
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
        public XMClaimInfoPictureService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMClaimInfoPictureService成员
        /// <summary>
        /// Insert into XMClaimInfoPicture
        /// </summary>
        /// <param name="xmclaiminfopicture">XMClaimInfoPicture</param>
        public void InsertXMClaimInfoPicture(XMClaimInfoPicture xmclaiminfopicture)
        {
            if (xmclaiminfopicture == null)
                return;

            if (!this._context.IsAttached(xmclaiminfopicture))

                this._context.XMClaimInfoPictures.AddObject(xmclaiminfopicture);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMClaimInfoPicture
        /// </summary>
        /// <param name="xmclaiminfopicture">XMClaimInfoPicture</param>
        public void UpdateXMClaimInfoPicture(XMClaimInfoPicture xmclaiminfopicture)
        {
            if (xmclaiminfopicture == null)
                return;

            if (this._context.IsAttached(xmclaiminfopicture))
                this._context.XMClaimInfoPictures.Attach(xmclaiminfopicture);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMClaimInfoPicture list
        /// </summary>
        public List<XMClaimInfoPicture> GetXMClaimInfoPictureList()
        {
            var query = from p in this._context.XMClaimInfoPictures
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMClaimInfoPicture Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfoPicture Page List</returns>
        public PagedList<XMClaimInfoPicture> SearchXMClaimInfoPicture(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimInfoPictures
                        orderby p.ID
                        select p;
            return new PagedList<XMClaimInfoPicture>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMClaimInfoPicture by ID
        /// </summary>
        /// <param name="id">XMClaimInfoPicture ID</param>
        /// <returns>XMClaimInfoPicture</returns>   
        public XMClaimInfoPicture GetXMClaimInfoPictureByID(int id)
        {
            var query = from p in this._context.XMClaimInfoPictures
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMClaimInfoPicture> GetXMClaimInfoPictureListByClaimInfoID(int ClaimInfoID)
        {
            var query = from p in this._context.XMClaimInfoPictures
                        where p.IsEnable == false
                        && p.ClaimInfoID == ClaimInfoID
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMClaimInfoPicture by ID
        /// </summary>
        /// <param name="ID">XMClaimInfoPicture ID</param>
        public void DeleteXMClaimInfoPicture(int id)
        {
            var xmclaiminfopicture = this.GetXMClaimInfoPictureByID(id);
            if (xmclaiminfopicture == null)
                return;

            if (!this._context.IsAttached(xmclaiminfopicture))
                this._context.XMClaimInfoPictures.Attach(xmclaiminfopicture);

            this._context.DeleteObject(xmclaiminfopicture);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMClaimInfoPicture by ID
        /// </summary>
        /// <param name="IDs">XMClaimInfoPicture ID</param>
        public void BatchDeleteXMClaimInfoPicture(List<int> ids)
        {
            var query = from q in _context.XMClaimInfoPictures
                        where ids.Contains(q.ID)
                        select q;
            var xmclaiminfopictures = query.ToList();
            foreach (var item in xmclaiminfopictures)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimInfoPictures.Attach(item);

                _context.XMClaimInfoPictures.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
