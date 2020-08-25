
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-02-02 16:30:01
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
    public partial class XMDeductionSetUpService: IXMDeductionSetUpService
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
    	public XMDeductionSetUpService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMDeductionSetUpService成员
        /// <summary>
        /// Insert into XMDeductionSetUp
        /// </summary>
        /// <param name="xmdeductionsetup">XMDeductionSetUp</param>
    	public void InsertXMDeductionSetUp(XMDeductionSetUp xmdeductionsetup)
    	{	
            if (xmdeductionsetup == null)
                return;
    
            if (!this._context.IsAttached(xmdeductionsetup))
    			
                this._context.XMDeductionSetUps.AddObject(xmdeductionsetup);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMDeductionSetUp
        /// </summary>
        /// <param name="xmdeductionsetup">XMDeductionSetUp</param>
        public void UpdateXMDeductionSetUp(XMDeductionSetUp xmdeductionsetup)
        {
            if (xmdeductionsetup == null)
                return;
    
            if (this._context.IsAttached(xmdeductionsetup))
                this._context.XMDeductionSetUps.Attach(xmdeductionsetup);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMDeductionSetUp list
        /// </summary>
        public List<XMDeductionSetUp> GetXMDeductionSetUpList()
        {		
            var query = from p in this._context.XMDeductionSetUps
                        where p.IsEnable.Value==false
                        select p;
            return query.ToList();
        }
    
    	
       /// <summary>
       /// 根据项目Id  、平台类型Id 查询扣点设置数据信息
       /// </summary>
       /// <param name="ProjectId">项目id</param>
        /// <param name="PlatformTypeId">平台类型Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeductionSetUp Page List</returns>
        public PagedList<XMDeductionSetUp> SearchXMDeductionSetUp(int ProjectId,int SpeciesTypeId,int PlatformTypeId, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeductionSetUps
                        where p.ProjectId==ProjectId 
                        && p.SpeciesTypeId==SpeciesTypeId
                        && (PlatformTypeId==-1 || p.PlatformTypeId==PlatformTypeId)
                        && p.IsEnable.Value==false
                        orderby p.Id
                        select p;
            return new PagedList<XMDeductionSetUp>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }



        /// <summary>
        /// 根据项目Id、平台类型Id查询
        /// </summary>
        /// <param name="ProjectId">项目Id</param>
        /// <param name="PlatformTypeId">平台类型Id</param>
        /// <returns></returns>
        public XMDeductionSetUp GetXMDeductionSetUpByProjectAndPlatformTypeId(int ProjectId, int SpeciesTypeId, int PlatformTypeId)
        {
             
            var query = from p in this._context.XMDeductionSetUps
                        where p.ProjectId==ProjectId
                        && p.SpeciesTypeId==SpeciesTypeId
                        && p.PlatformTypeId==PlatformTypeId
                        && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        
        }
    	/// <summary>
        /// get a XMDeductionSetUp by Id
        /// </summary>
        /// <param name="id">XMDeductionSetUp Id</param>
        /// <returns>XMDeductionSetUp</returns>   
        public XMDeductionSetUp GetXMDeductionSetUpById(int id)
        {
            var query = from p in this._context.XMDeductionSetUps
                        where p.Id.Equals(id)
                        && p.IsEnable.Value==false
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMDeductionSetUp by Id
        /// </summary>
        /// <param name="Id">XMDeductionSetUp Id</param>
        public void DeleteXMDeductionSetUp(int id)
        {
            var xmdeductionsetup = this.GetXMDeductionSetUpById(id);
            if (xmdeductionsetup == null)
                return;
    
            if (!this._context.IsAttached(xmdeductionsetup))
                this._context.XMDeductionSetUps.Attach(xmdeductionsetup);
    
            this._context.DeleteObject(xmdeductionsetup);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMDeductionSetUp by Id
        /// </summary>
        /// <param name="Ids">XMDeductionSetUp Id</param>
        public void BatchDeleteXMDeductionSetUp(List<int> ids)
        {
    	   var query = from q in _context.XMDeductionSetUps
                    where ids.Contains(q.Id)
                    select q;
            var xmdeductionsetups = query.ToList();
            foreach (var item in xmdeductionsetups)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeductionSetUps.Attach(item);  
    
                _context.XMDeductionSetUps.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
