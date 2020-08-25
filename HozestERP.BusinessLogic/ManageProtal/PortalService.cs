using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;

namespace HozestERP.BusinessLogic.ManageProtal
{
    public partial class PortalService : IPortalService
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
        public PortalService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        /// <summary>
        /// 获取用户的桌面
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        public List<PortalColumnNumber> GetPortalColumnNumbers(int customerid)
        {
            var query = from pc in this._context.PortalColumns
                        join p in this._context.Portals on pc.PortalID equals p.ID
                        join pcn in this._context.PortalColumnNumbers on pc.ColumnNumberID equals pcn.ID
                        where pcn.CustomerID.Equals(customerid)
                        orderby pc.SortIndex
                        select pcn;
            return query.ToList();
        }

        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public List<PortalColumnNumber> GetPortalColumnNumberList(int customerid)
        {
            var query = from p in this._context.PortalColumnNumbers
                        where p.CustomerID.Equals(customerid)
                        orderby p.Display
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 设置列数
        /// </summary>
        /// <param name="portalColumn"></param>
        public void UpdatePortalColumnsNumber(List<PortalColumnNumber> portalColumnNumbers)
        {
            if (portalColumnNumbers.Count == 0)
            {
                throw new ArgumentNullException("portalColumnNumbers");
            }
            foreach (var item in portalColumnNumbers)
            {
                if (!_context.IsAttached(item))
                    _context.PortalColumnNumbers.Attach(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 获取可以添加的栏目
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<Portal> GetAddPortalClomuns(int customerID)
        {
            var query = (from p in this._context.Portals
                         select p).Except(from pc in this._context.PortalColumns
                                          join p in this._context.Portals on pc.PortalID equals p.ID
                                          join pcn in this._context.PortalColumnNumbers on pc.ColumnNumberID equals pcn.ID
                                          where pcn.CustomerID.Equals(customerID)
                                          orderby pc.SortIndex
                                          select p);
            return query.ToList();
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="columns"></param>
        public void InsertColumns(List<PortalColumn> columns)
        {
            if (columns.Count == 0)
                throw new ArgumentNullException("columns");

            foreach (var item in columns)
            {
                _context.PortalColumns.AddObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 保存栏目
        /// </summary>
        /// <param name="portalColumns"></param>
        public void SavePortalColumnsNumber(List<PortalColumn> portalColumns)
        {
            if (portalColumns.Count == 0)
            {
                throw new ArgumentNullException("portalColumns");
            }
            foreach (var item in portalColumns)
            {
                if (!_context.IsAttached(item))
                    _context.PortalColumns.Attach(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 获取桌面模块信息
        /// </summary>
        /// <param name="portalcolumnid"></param>
        /// <returns></returns>
        public PortalColumn GetPortalColumnByID(int portalcolumnid)
        {
            var query = from p in this._context.PortalColumns
                        where p.ID.Equals(portalcolumnid)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 更新桌面模块信息
        /// </summary>
        /// <param name="portalcolumnid"></param>
        /// <param name="columnNumberID"></param>
        /// <param name="position"></param>
        public void UpdatePortalColumn(int portalcolumnid, int columnNumberID, int position)
        {
            var portalcolumn = this.GetPortalColumnByID(portalcolumnid);
            if (portalcolumn == null)
                return;
            if (portalcolumn.ColumnNumberID.Equals(columnNumberID))
            {
                var query = from p in this._context.PortalColumns
                            where p.SortIndex >= position && p.ColumnNumberID.Equals(columnNumberID)
                            select p;

                foreach (var item in query.ToList())
                {
                    item.SortIndex = position + 1;
                    if (!_context.IsAttached(item))
                        _context.PortalColumns.Attach(item);
                }
                portalcolumn.ColumnNumberID = columnNumberID;
                portalcolumn.SortIndex = position;

                if (!_context.IsAttached(portalcolumn))
                    _context.PortalColumns.Attach(portalcolumn);

                _context.SaveChanges();
            }
            else
            {
                var query = from p in this._context.PortalColumns
                            where p.ColumnNumberID.Equals(columnNumberID)
                            select p;

                int sortIndex = 0;
                foreach (var item in query.ToList())
                {
                    if (sortIndex.Equals(position))
                    {
                        sortIndex++;
                    }
                    item.SortIndex = sortIndex;
                    if (!_context.IsAttached(item))
                        _context.PortalColumns.Attach(item);
                    sortIndex++;
                }

                portalcolumn.ColumnNumberID = columnNumberID;
                portalcolumn.SortIndex = position;

                if (!_context.IsAttached(portalcolumn))
                    _context.PortalColumns.Attach(portalcolumn);

                _context.SaveChanges();
            }

        }

        /// <summary>
        /// 删除桌面模块信息
        /// </summary>
        /// <param name="portalcolumnid"></param>
        public void DeletePortalColumn(int portalcolumnid)
        {
            var portalcolumn = this.GetPortalColumnByID(portalcolumnid);
            if (portalcolumn == null)
                return;


            if (!_context.IsAttached(portalcolumn))
                _context.PortalColumns.Attach(portalcolumn);

            _context.DeleteObject(portalcolumn);

            _context.SaveChanges();

        }

        /// <summary>
        /// 桌面栏目设置保存
        /// </summary>
        /// <param name="portalcolumnnumbers"></param>
        /// <param name="customerID"></param>
        public void SavePortalColumnsNumber(List<PortalColumnNumber> portalcolumnnumbers, int customerID)
        {
            System.Data.Common.DbTransaction tran = null;
            try
            {
                this._context.Connection.Open();
                tran = this._context.Connection.BeginTransaction();
                string sql = "DELETE Sys_PortalColumnNumber WHERE customerID='" + customerID.ToString() + "'";

                this._context.ExecuteStoreCommand(sql);


                foreach (var item in portalcolumnnumbers)
                {
                    _context.PortalColumnNumbers.AddObject(item);

                }
                _context.SaveChanges();
                tran.Commit();
            }
            catch (Exception err)
            {
                if (tran != null)
                    tran.Rollback();
                throw err;
            }
            finally
            {
                if (this._context != null && this._context.Connection.State != System.Data.ConnectionState.Closed)
                    this._context.Connection.Close();
            }
        }

        /// <summary>
        /// 根据ID获取portal
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public Portal GetPortal(int portalID)
        {
            var query = from p in this._context.Portals
                        where p.ID.Equals(portalID)
                        select p;
            return query.SingleOrDefault();
        }
    }
}
