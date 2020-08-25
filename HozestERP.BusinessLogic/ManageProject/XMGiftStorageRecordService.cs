
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-09-06 16:02:26
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
    public partial class XMGiftStorageRecordService: IXMGiftStorageRecordService
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
    	public XMGiftStorageRecordService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMGiftStorageRecordService成员
        /// <summary>
        /// Insert into XMGiftStorageRecord
        /// </summary>
        /// <param name="xmgiftstoragerecord">XMGiftStorageRecord</param>
    	public void InsertXMGiftStorageRecord(XMGiftStorageRecord xmgiftstoragerecord)
    	{	
            if (xmgiftstoragerecord == null)
                return;
    
            if (!this._context.IsAttached(xmgiftstoragerecord))
    			
                this._context.XMGiftStorageRecords.AddObject(xmgiftstoragerecord);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMGiftStorageRecord
        /// </summary>
        /// <param name="xmgiftstoragerecord">XMGiftStorageRecord</param>
        public void UpdateXMGiftStorageRecord(XMGiftStorageRecord xmgiftstoragerecord)
        {
            if (xmgiftstoragerecord == null)
                return;
    
            if (this._context.IsAttached(xmgiftstoragerecord))
                this._context.XMGiftStorageRecords.Attach(xmgiftstoragerecord);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMGiftStorageRecord list
        /// </summary>
        public List<XMGiftStorageRecord> GetXMGiftStorageRecordList()
        {		
            var query = from p in this._context.XMGiftStorageRecords
                        where p.IsEnable==false
                        select p;
            return query.ToList();
        }

        public List<XMGiftStorageRecord> GetXMGiftStorageRecordListByParm()
        {
            string batch = DateTime.Now.ToString("yyMMddHHmmss");
            var query = from p in this._context.XMProducts
                        where p.IsEnable == false
                        && p.IsPremiums == true
                        select p;
            List<XMGiftStorageRecord> list =new List<XMGiftStorageRecord>();
            foreach (XMProduct p in query.ToList())
            {
                XMGiftStorageRecord one = new XMGiftStorageRecord();
                one.ProductId = p.Id;
                one.Batch = batch;
                list.Add(one);
            }
            return list;
        }

        public List<XMGiftStorageRecord> GetXMGiftStorageRecordListByDate(DateTime Begin, DateTime End)
        {
            var query = from p in this._context.XMGiftStorageRecords
                        join project in this._context.XMProducts
                        on p.ProductId equals project.Id
                        where p.IsEnable == false
                        && p.CreateDate>Begin
                        && p.CreateDate<=End
                        && project.IsPremiums==true
                        && project.IsEnable==false
                        select p;
            return query.ToList();
        }

        public XMProduct GetProductInfo(int ProductId)
        {
            var query = from p in this._context.XMProducts
                        where p.IsEnable == false
                        && p.Id == ProductId
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMProduct> GetXMProductListByCode(string ProductCode)
        {
            var query = from p in this._context.XMProducts
                        where p.IsEnable == false
                        && (ProductCode == "" || p.ManufacturersCode.Contains(ProductCode))
                        && p.IsPremiums==true
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMGiftStorageRecord Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMGiftStorageRecord Page List</returns>
        public PagedList<XMGiftStorageRecord> SearchXMGiftStorageRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMGiftStorageRecords
                        orderby p.Id
                        select p;
            return new PagedList<XMGiftStorageRecord>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMGiftStorageRecord by Id
        /// </summary>
        /// <param name="id">XMGiftStorageRecord Id</param>
        /// <returns>XMGiftStorageRecord</returns>   
        public XMGiftStorageRecord GetXMGiftStorageRecordById(int id)
        {
            var query = from p in this._context.XMGiftStorageRecords
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMGiftStorageRecord by Id
        /// </summary>
        /// <param name="Id">XMGiftStorageRecord Id</param>
        public void DeleteXMGiftStorageRecord(int id)
        {
            var xmgiftstoragerecord = this.GetXMGiftStorageRecordById(id);
            if (xmgiftstoragerecord == null)
                return;
    
            if (!this._context.IsAttached(xmgiftstoragerecord))
                this._context.XMGiftStorageRecords.Attach(xmgiftstoragerecord);
    
            this._context.DeleteObject(xmgiftstoragerecord);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMGiftStorageRecord by Id
        /// </summary>
        /// <param name="Ids">XMGiftStorageRecord Id</param>
        public void BatchDeleteXMGiftStorageRecord(List<int> ids)
        {
    	   var query = from q in _context.XMGiftStorageRecords
                    where ids.Contains(q.Id)
                    select q;
            var xmgiftstoragerecords = query.ToList();
            foreach (var item in xmgiftstoragerecords)
            {
                if (!_context.IsAttached(item))
                    _context.XMGiftStorageRecords.Attach(item);  
    
                _context.XMGiftStorageRecords.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
