
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-08 13:14:13
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMBusinessDataDetailService: IXMBusinessDataDetailService
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
    	public XMBusinessDataDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMBusinessDataDetailService成员
        /// <summary>
        /// Insert into XMBusinessDataDetail
        /// </summary>
        /// <param name="xmbusinessdatadetail">XMBusinessDataDetail</param>
    	public void InsertXMBusinessDataDetail(XMBusinessDataDetail xmbusinessdatadetail)
    	{	
            if (xmbusinessdatadetail == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdatadetail))
    			
                this._context.XMBusinessDataDetails.AddObject(xmbusinessdatadetail);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMBusinessDataDetail
        /// </summary>
        /// <param name="xmbusinessdatadetail">XMBusinessDataDetail</param>
        public void UpdateXMBusinessDataDetail(XMBusinessDataDetail xmbusinessdatadetail)
        {
            if (xmbusinessdatadetail == null)
                return;
    
            if (this._context.IsAttached(xmbusinessdatadetail))
                this._context.XMBusinessDataDetails.Attach(xmbusinessdatadetail);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMBusinessDataDetail list
        /// </summary>
        public List<XMBusinessDataDetail> GetXMBusinessDataDetailList()
        {		
            var query = from p in this._context.XMBusinessDataDetails
                        select p;
            return query.ToList();
        }

        public List<XMBusinessDataDetail> GetXMBusinessDataDetailListByBusinessDataID(int BusinessDataID)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        where p.IsEnabled == false
                        && p.BusinessDataID == BusinessDataID
                        select p;
            return query.ToList();
        }

        public List<XMBusinessDataDetail> GetXMBusinessDataDetailListByBusinessDataIDReceivables(int BusinessDataID)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        where p.IsEnabled == false
                        && p.BusinessDataID == BusinessDataID
                        && p.AmountType == 568//收款
                        && p.FinancialStatus == false
                        select p;
            return query.ToList();
        }

        public List<XMBusinessDataAll> GetXMBusinessDataDetailListByDepID(int DepID, DateTime Begin, DateTime End)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        join q in this._context.XMBusinessDatas
                        on p.BusinessDataID equals q.ID
                        where p.IsEnabled == false
                        && q.BelongingDepID == DepID
                        && p.FinancialStatus == true
                        && q.SubmitDate >= Begin
                        && q.SubmitDate <= End
                        select new XMBusinessDataAll
                        {
                            AmountType = p.AmountType,
                            Amount = p.Amount,
                            SubmitDate = q.SubmitDate
                        };
            return query.ToList();
        }

        public bool GetSpendingAuthority(int CustomerRoleID)
        {
            var query = from p in this._context.CustomerActions
                        join q in this._context.ACLs
                        on p.CustomerActionID equals q.CustomerActionID
                        where p.Name == "B2B详细管理-支付查看权限"
                        && q.CustomerRoleID == CustomerRoleID
                        && q.Allow == true
                        select p;
            if (query.ToList() != null && query.ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    	
        /// <summary>
        /// get to XMBusinessDataDetail Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMBusinessDataDetail Page List</returns>
        public PagedList<XMBusinessDataDetail> SearchXMBusinessDataDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMBusinessDataDetail>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMBusinessDataDetail by ID
        /// </summary>
        /// <param name="id">XMBusinessDataDetail ID</param>
        /// <returns>XMBusinessDataDetail</returns>   
        public XMBusinessDataDetail GetXMBusinessDataDetailByID(int id)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMBusinessDataDetail by ID
        /// </summary>
        /// <param name="ID">XMBusinessDataDetail ID</param>
        public void DeleteXMBusinessDataDetail(int id)
        {
            var xmbusinessdatadetail = this.GetXMBusinessDataDetailByID(id);
            if (xmbusinessdatadetail == null)
                return;
    
            if (!this._context.IsAttached(xmbusinessdatadetail))
                this._context.XMBusinessDataDetails.Attach(xmbusinessdatadetail);
    
            this._context.DeleteObject(xmbusinessdatadetail);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMBusinessDataDetail by ID
        /// </summary>
        /// <param name="IDs">XMBusinessDataDetail ID</param>
        public void BatchDeleteXMBusinessDataDetail(List<int> ids)
        {
    	   var query = from q in _context.XMBusinessDataDetails
                    where ids.Contains(q.ID)
                    select q;
            var xmbusinessdatadetails = query.ToList();
            foreach (var item in xmbusinessdatadetails)
            {
                if (!_context.IsAttached(item))
                    _context.XMBusinessDataDetails.Attach(item);  
    
                _context.XMBusinessDataDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}