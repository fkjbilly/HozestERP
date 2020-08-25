
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-31 15:51:21
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
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMScalpingApplicationService: IXMScalpingApplicationService
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
    	public XMScalpingApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMScalpingApplicationService成员
        /// <summary>
        /// Insert into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
    	public void InsertXMScalpingApplication(XMScalpingApplication xmscalpingapplication)
    	{	
            if (xmscalpingapplication == null)
                return;
    
            if (!this._context.IsAttached(xmscalpingapplication))
    			
                this._context.XMScalpingApplications.AddObject(xmscalpingapplication);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
        public void UpdateXMScalpingApplication(XMScalpingApplication xmscalpingapplication)
        {
            if (xmscalpingapplication == null)
                return;
    
            if (this._context.IsAttached(xmscalpingapplication))
                this._context.XMScalpingApplications.Attach(xmscalpingapplication);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMScalpingApplication list
        /// </summary>
        public List<XMScalpingApplication> GetXMScalpingApplicationList()
        {		
            var query = from p in this._context.XMScalpingApplications
                        where p.IsEnable.Value==false
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalpingApplication Page List</returns>
        public PagedList<XMScalpingApplication> SearchXMScalpingApplication(int PlatformTypeId, List<int> NickId, string ScalpingCode, int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {


            if (NickId.Count > 1)
            { 
                var query = from p in this._context.XMScalpingApplications
                            where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                            && NickId.Contains(p.NickId.Value)
                            && p.ScalpingCode.Contains(ScalpingCode)
                            && p.IsEnable.Value == false
                            orderby p.ScalpingCode descending
                            select p; 
                return new PagedList<XMScalpingApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
            }
            else
            {

                int nickId = NickId[0];
                var query = from p in this._context.XMScalpingApplications
                            where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                            && (nickId == -1 || p.NickId == nickId)
                            && p.ScalpingCode.Contains(ScalpingCode)
                            && p.IsEnable.Value == false
                            orderby p.ScalpingCode descending
                            select p;
                 
                return new PagedList<XMScalpingApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
            }

            
        }
    
    	/// <summary>
        /// get a XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="scalpingid">XMScalpingApplication ScalpingId</param>
        /// <returns>XMScalpingApplication</returns>   
        public XMScalpingApplication GetXMScalpingApplicationByScalpingId(int scalpingid)
        {
            var query = from p in this._context.XMScalpingApplications
                        where p.ScalpingId.Equals(scalpingid)
                        && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据刷单单号查询(查询刷单单号 部门审核通过的)
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        public List<XMScalpingApplication> GetXMScalpingApplicationByScalpingCode(string ScalpingCode)
        {
            var query = from p in this._context.XMScalpingApplications
                        where p.ScalpingCode.Contains(ScalpingCode)
                        && p.ManagerIsAudit==true
                        && p.IsEnable.Value == false
                        orderby p.ScalpingCode descending
                        select p; 
            return query.ToList();
        }




        /// <summary>
        /// 根据刷单单号查询 (部门审核通过的刷单信息)
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        public List<XMScalpingApplication> GetXMScalpingApplicationByEqualsScalpingCode(string ScalpingCode)
        {
            var query = from p in this._context.XMScalpingApplications
                        where p.ScalpingCode.Equals(ScalpingCode)
                        && p.ManagerIsAudit == true
                        && p.IsEnable.Value == false 
                        select p;
            return query.ToList();
        }




        /// <summary>
        /// 根据刷单单号关联暂支单查询（查询暂支单中不存在的刷单单号）
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        public  List<XMScalpingApplication> GetXMScalpingApplicationByScalpingCodeList(string ScalpingCode) {

//            string sql = @"select * from XM_ScalpingApplication 
//                            where  ScalpingId not in (select ScalpingId from Sys_AdvanceApplication) 
//                            and ScalpingCode like {0} 
//                            and ManagerIsAudit='true'
//                            and IsEnable='false'
//                            order by ScalpingCode desc";

            string sql = @"select * from XM_ScalpingApplication   a 
                           where  a.ScalpingId not in (select b.ScalpingId from Sys_AdvanceApplication b where b.ScalpingId is not null  and b.IsEnable='false')  
                            and a.ScalpingCode like {0}
                            and a.ManagerIsAudit='true'
                            and a.IsEnable='false'
                            order by ScalpingCode desc";

            var scalpingApplicationList = this._context.ExecuteStoreQuery<XMScalpingApplication>(sql, "%" + ScalpingCode + "%");
            return scalpingApplicationList.ToList();
        
        }



        /// <summary>
        /// 根据刷单单号关联暂支单查询（查询暂支单中暂支状态是使用中的数据）
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
       public  List<XMScalpingApplication> GetXMScalpingApplicationByAdvanceState(string ScalpingCode) {

           var query = from p in this._context.XMScalpingApplications
                       join b in this._context.AdvanceApplications
                       on p.ScalpingId equals b.ScalpingId
                       where p.ScalpingCode.Contains(ScalpingCode)
                       && p.ManagerIsAudit == true
                       && p.IsEnable.Value == false
                       && b.AdvanceState == (int)AdvanceStateEnum.TheAdvanceUse
                       orderby p.ScalpingCode descending
                       select p;
           return query.ToList();
        
        }
    
    	/// <summary>
        /// delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingId">XMScalpingApplication ScalpingId</param>
        public void DeleteXMScalpingApplication(int scalpingid)
        {
            var xmscalpingapplication = this.GetXMScalpingApplicationByScalpingId(scalpingid);
            if (xmscalpingapplication == null)
                return;
    
            if (!this._context.IsAttached(xmscalpingapplication))
                this._context.XMScalpingApplications.Attach(xmscalpingapplication);
    
            this._context.DeleteObject(xmscalpingapplication);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingIds">XMScalpingApplication ScalpingId</param>
        public void BatchDeleteXMScalpingApplication(List<int> scalpingids)
        {
    	   var query = from q in _context.XMScalpingApplications
                    where scalpingids.Contains(q.ScalpingId)
                    select q;
            var xmscalpingapplications = query.ToList();
            foreach (var item in xmscalpingapplications)
            {
                if (!_context.IsAttached(item))
                    _context.XMScalpingApplications.Attach(item);  
    
                _context.XMScalpingApplications.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
