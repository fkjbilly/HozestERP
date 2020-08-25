
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-07-27 15:27:46
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
using System.Linq.Expressions;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsFeeMainService: IXMLogisticsFeeMainService
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
    	public XMLogisticsFeeMainService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

    	
        #region IXMLogisticsFeeMainService成员
        /// <summary>
        /// Insert into XMLogisticsFeeMain
        /// </summary>
        /// <param name="xmlogisticsfeemain">XMLogisticsFeeMain</param>
    	public void InsertXMLogisticsFeeMain(XMLogisticsFeeMain xmlogisticsfeemain,bool flag)
    	{	
            if (xmlogisticsfeemain == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsfeemain))
    			
                this._context.XMLogisticsFeeMains.AddObject(xmlogisticsfeemain);

            if(flag)
            {
                this._context.SaveChanges();
            }
    	}
    		
        /// <summary>
        /// Update into XMLogisticsFeeMain
        /// </summary>
        /// <param name="xmlogisticsfeemain">XMLogisticsFeeMain</param>
        public void UpdateXMLogisticsFeeMain(XMLogisticsFeeMain xmlogisticsfeemain)
        {
            if (xmlogisticsfeemain == null)
                return;
    
            if (this._context.IsAttached(xmlogisticsfeemain))
                this._context.XMLogisticsFeeMains.Attach(xmlogisticsfeemain);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMLogisticsFeeMain list
        /// </summary>
        public IQueryable<XMLogisticsFeeMainNew> GetXMLogisticsFeeMainList()
        {
            var query = from p in this._context.XMLogisticsFeeMains
                        join a in _context.XMProjects on p.ProjectID equals a.Id into temp
                        from ap in temp.DefaultIfEmpty()
                        select new XMLogisticsFeeMainNew()
                        {
                            ID=p.ID,
                            Project=ap.ProjectName,
                            WareHouseID=(int)p.WareHouseID,
                            Province=p.Province,
                            City=p.City,
                            Area=p.Area,
                            LogisticsID=(int)p.LogisticsID,
                            Fee=(decimal)p.Fee,
                        };
            return query;
        }
    
    	
        /// <summary>
        /// get to XMLogisticsFeeMain Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsFeeMain Page List</returns>
        public PagedList<XMLogisticsFeeMain> SearchXMLogisticsFeeMain(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMLogisticsFeeMains
                        orderby p.ID
                        select p;
            return new PagedList<XMLogisticsFeeMain>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMLogisticsFeeMain by ID
        /// </summary>
        /// <param name="id">XMLogisticsFeeMain ID</param>
        /// <returns>XMLogisticsFeeMain</returns>   
        public XMLogisticsFeeMain GetXMLogisticsFeeMainByID(int id)
        {
            var query = from p in this._context.XMLogisticsFeeMains
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMLogisticsFeeMain by ID
        /// </summary>
        /// <param name="ID">XMLogisticsFeeMain ID</param>
        public void DeleteXMLogisticsFeeMain(int id, bool flag)
        {
            var xmlogisticsfeemain = this.GetXMLogisticsFeeMainByID(id);
            if (xmlogisticsfeemain == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsfeemain))
                this._context.XMLogisticsFeeMains.Attach(xmlogisticsfeemain);
    
            this._context.DeleteObject(xmlogisticsfeemain);

            if(flag)
            {
                this._context.SaveChanges();
            }
        }
    	
    	/// <summary>
        /// Batch delete XMLogisticsFeeMain by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsFeeMain ID</param>
        public void BatchDeleteXMLogisticsFeeMain(List<int> ids)
        {
    	   var query = from q in _context.XMLogisticsFeeMains
                    where ids.Contains(q.ID)
                    select q;
            var xmlogisticsfeemains = query.ToList();
            foreach (var item in xmlogisticsfeemains)
            {
                if (!_context.IsAttached(item))
                    _context.XMLogisticsFeeMains.Attach(item);  
    
                _context.XMLogisticsFeeMains.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        public XMLogisticsFeeMain getSingle(Expression<Func<XMLogisticsFeeMain, bool>> predicate)
        {
            XMLogisticsFeeMain entity = _context.XMLogisticsFeeMains.FirstOrDefault(predicate);
            return entity;
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        #endregion

    }
}
