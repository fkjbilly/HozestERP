using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class AreaCodeService : IAreaCodeService
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
        public AreaCodeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IAreaCodeService 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberid"></param>
        /// <returns></returns>
        public PagedList<AreaCode> GetAreaCodeByParentID(string prepath, int paramPageIndex, int paramPageSize)
        {
            var query = from p in this._context.AreaCodes
                        where (p.PrePath.Contains(prepath)
                        || p.City.Contains(prepath)
                        || p.Spell.Contains(prepath)
                        || p.shortening.Contains(prepath)
                        || p.Post.Contains(prepath)
                        || p.AreaID.Contains(prepath)
                        || p.CityType.Contains(prepath))
                        orderby p.NumberID ascending
                        select p;
            return new PagedList<AreaCode>(query, paramPageIndex, paramPageSize);
        }

        /// <summary>
        /// 获得区域(启用)
        /// </summary>
        /// <returns></returns>
        public List<AreaCode> GetAreaCode()
        {
            var query = from p in this._context.AreaCodes
                        where p.Enabled
                        orderby p.NumberID ascending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 获得区域(启用)
        /// </summary>
        /// <returns></returns>
        public List<AreaCode> GetAreaCode(int rank, string preceding)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == rank
                        && p.Preceding.Contains(preceding)
                        orderby p.NumberID ascending
                        select p;
            return query.ToList();
        }

        public List<AreaCode> GetAreaCodeByRank(int rank)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == rank
                        orderby p.NumberID ascending
                        select p;
            return query.ToList();
        }

        public List<AreaCode> GetAreaCodeByCity(int rank, string city)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == rank
                        && p.PrePath.Contains(city)
                        orderby p.NumberID ascending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 获得区域(启用)
        /// </summary>
        /// <returns></returns>
        public List<AreaCode> GetAreaCode(string preceding)
        {
            var query = from p in this._context.AreaCodes
                        where p.Preceding.Equals(preceding)
                        orderby p.NumberID ascending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据numberID获得区域
        /// </summary>
        /// <param name="numberID"></param>
        /// <returns></returns>
        public AreaCode GetAreaByNumberID(string numberID)
        {
            var query = from p in this._context.AreaCodes
                        where p.NumberID.Equals(numberID)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public AreaCode GetAreaByCity(string city)
        {
            var query = from p in this._context.AreaCodes
                        where p.City == city && p.Rank == 2
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据ID获得区域信息
        /// </summary>
        /// <param name="xmID"></param>
        /// <returns></returns>
        public AreaCode GetAreaByXmID(int xmID)
        {
            var query = from p in this._context.AreaCodes
                        where p.xmlid.Equals(xmID)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据NumberID获得区域信息
        /// </summary>
        /// <param name="NumberID"></param>
        /// <returns></returns>
        public AreaCode GetAreaByXmID(string numberID)
        {
            var query = from p in this._context.AreaCodes
                        where p.NumberID.Equals(numberID)
                        select p;
            return query.SingleOrDefault();
        }

        public void UpdateAreaCode(AreaCode entity)
        {
            if (entity == null)
                throw new ArgumentNullException("codeList");
            if (!_context.IsAttached(entity))
                _context.AreaCodes.Attach(entity);

            _context.SaveChanges();
        }

        public void InsertAreaCode(AreaCode entity)
        {
            if (entity == null)
                return;

            if (!this._context.IsAttached(entity))

                this._context.AreaCodes.AddObject(entity);

            this._context.SaveChanges();
        }

        /// <summary>
        /// 批量生效区域
        /// </summary>
        /// <param name="areaIDs">areaIDs</param>
        public void MarkAreasBatchPublished(string areaIDs, string noxmlids)
        {
            string sql = " UPDATE SYS_AREACODE SET ENABLED='true' WHERE xmlid in (" + areaIDs + ") AND ENABLED='false'; UPDATE SYS_AREACODE SET ENABLED='false' WHERE xmlid IN (" + noxmlids + ") AND ENABLED='true'; ";
            this._context.ExecuteStoreCommand(sql);
        }
        #endregion
    }
}
