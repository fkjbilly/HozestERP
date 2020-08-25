
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-03-04 12:29:00
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
    public partial class XMCommunicationRecordService: IXMCommunicationRecordService
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
    	public XMCommunicationRecordService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCommunicationRecordService成员
        /// <summary>
        /// Insert into XMCommunicationRecord
        /// </summary>
        /// <param name="xmcommunicationrecord">XMCommunicationRecord</param>
    	public void InsertXMCommunicationRecord(XMCommunicationRecord xmcommunicationrecord)
    	{	
            if (xmcommunicationrecord == null)
                return;
    
            if (!this._context.IsAttached(xmcommunicationrecord))
    			
                this._context.XMCommunicationRecords.AddObject(xmcommunicationrecord);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCommunicationRecord
        /// </summary>
        /// <param name="xmcommunicationrecord">XMCommunicationRecord</param>
        public void UpdateXMCommunicationRecord(XMCommunicationRecord xmcommunicationrecord)
        {
            if (xmcommunicationrecord == null)
                return;
    
            if (this._context.IsAttached(xmcommunicationrecord))
                this._context.XMCommunicationRecords.Attach(xmcommunicationrecord);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCommunicationRecord list
        /// </summary>
        public List<XMCommunicationRecord> GetXMCommunicationRecordList()
        {		
            var query = from p in this._context.XMCommunicationRecords
                        select p;
            return query.ToList();
        }



        /// <summary>
        /// 根据主表Id查询 沟通记录
        /// </summary>
        /// <param name="QuestionID"></param>
        /// <returns></returns>
        public List<XMCommunicationRecord> GetXMCommunicationRecordListByQuestionID(int QuestionID) {
            var query = from p in this._context.XMCommunicationRecords
                        where p.QuestionID==QuestionID
                        && p.IsEnable==false
                        select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to XMCommunicationRecord Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCommunicationRecord Page List</returns>
        public PagedList<XMCommunicationRecord> SearchXMCommunicationRecord(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCommunicationRecords
                        orderby p.Id
                        select p;
            return new PagedList<XMCommunicationRecord>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCommunicationRecord by Id
        /// </summary>
        /// <param name="id">XMCommunicationRecord Id</param>
        /// <returns>XMCommunicationRecord</returns>   
        public XMCommunicationRecord GetXMCommunicationRecordById(int id)
        {
            var query = from p in this._context.XMCommunicationRecords
                        where p.Id.Equals(id)
                        && p.IsEnable==false
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCommunicationRecord by Id
        /// </summary>
        /// <param name="Id">XMCommunicationRecord Id</param>
        public void DeleteXMCommunicationRecord(int id)
        {
            var xmcommunicationrecord = this.GetXMCommunicationRecordById(id);
            if (xmcommunicationrecord == null)
                return;
    
            if (!this._context.IsAttached(xmcommunicationrecord))
                this._context.XMCommunicationRecords.Attach(xmcommunicationrecord);
    
            this._context.DeleteObject(xmcommunicationrecord);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCommunicationRecord by Id
        /// </summary>
        /// <param name="Ids">XMCommunicationRecord Id</param>
        public void BatchDeleteXMCommunicationRecord(List<int> ids)
        {
    	   var query = from q in _context.XMCommunicationRecords
                    where ids.Contains(q.Id)
                    select q;
            var xmcommunicationrecords = query.ToList();
            foreach (var item in xmcommunicationrecords)
            {
                if (!_context.IsAttached(item))
                    _context.XMCommunicationRecords.Attach(item);  
    
                _context.XMCommunicationRecords.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
