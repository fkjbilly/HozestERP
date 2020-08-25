
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial class XMOrderInfoPlanRecordService: IXMOrderInfoPlanRecordService
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
    	public XMOrderInfoPlanRecordService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMOrderInfoPlanRecordService成员
        /// <summary>
        /// Insert into XMOrderInfoPlanRecord
        /// </summary>
        /// <param name="xmorderinfoplanrecord">XMOrderInfoPlanRecord</param>
    	public void InsertXMOrderInfoPlanRecord(XMOrderInfoPlanRecord xmorderinfoplanrecord)
    	{	
            if (xmorderinfoplanrecord == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfoplanrecord))
    			
                this._context.XMOrderInfoPlanRecords.AddObject(xmorderinfoplanrecord);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMOrderInfoPlanRecord
        /// </summary>
        /// <param name="xmorderinfoplanrecord">XMOrderInfoPlanRecord</param>
        public void UpdateXMOrderInfoPlanRecord(XMOrderInfoPlanRecord xmorderinfoplanrecord)
        {
            if (xmorderinfoplanrecord == null)
                return;
    
            if (this._context.IsAttached(xmorderinfoplanrecord))
                this._context.XMOrderInfoPlanRecords.Attach(xmorderinfoplanrecord);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMOrderInfoPlanRecord list
        /// </summary>
        public List<XMOrderInfoPlanRecord> GetXMOrderInfoPlanRecordList()
        {		
            var query = from p in this._context.XMOrderInfoPlanRecords
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMOrderInfoPlanRecord Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoPlanRecord Page List</returns>
        public PagedList<XMOrderInfoPlanRecord> SearchXMOrderInfoPlanRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoPlanRecords
                        orderby p.ID
                        select p;
            return new PagedList<XMOrderInfoPlanRecord>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMOrderInfoPlanRecord by ID
        /// </summary>
        /// <param name="id">XMOrderInfoPlanRecord ID</param>
        /// <returns>XMOrderInfoPlanRecord</returns>   
        public XMOrderInfoPlanRecord GetXMOrderInfoPlanRecordByID(int id)
        {
            var query = from p in this._context.XMOrderInfoPlanRecords
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMOrderInfoPlanRecord by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoPlanRecord ID</param>
        public void DeleteXMOrderInfoPlanRecord(int id)
        {
            var xmorderinfoplanrecord = this.GetXMOrderInfoPlanRecordByID(id);
            if (xmorderinfoplanrecord == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfoplanrecord))
                this._context.XMOrderInfoPlanRecords.Attach(xmorderinfoplanrecord);
    
            this._context.DeleteObject(xmorderinfoplanrecord);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMOrderInfoPlanRecord by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoPlanRecord ID</param>
        public void BatchDeleteXMOrderInfoPlanRecord(List<int> ids)
        {
    	   var query = from q in _context.XMOrderInfoPlanRecords
                    where ids.Contains(q.ID)
                    select q;
            var xmorderinfoplanrecords = query.ToList();
            foreach (var item in xmorderinfoplanrecords)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoPlanRecords.Attach(item);  
    
                _context.XMOrderInfoPlanRecords.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
