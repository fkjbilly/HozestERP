
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMInstallationListService: IXMInstallationListService
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
    	public XMInstallationListService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInstallationListService成员
        /// <summary>
        /// Insert into XMInstallationList
        /// </summary>
        /// <param name="xminstallationlist">XMInstallationList</param>
    	public void InsertXMInstallationList(XMInstallationList xminstallationlist)
    	{	
            if (xminstallationlist == null)
                return;
    
            if (!this._context.IsAttached(xminstallationlist))
    			
                this._context.XMInstallationLists.AddObject(xminstallationlist);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInstallationList
        /// </summary>
        /// <param name="xminstallationlist">XMInstallationList</param>
        public void UpdateXMInstallationList(XMInstallationList xminstallationlist)
        {
            if (xminstallationlist == null)
                return;
    
            if (this._context.IsAttached(xminstallationlist))
                this._context.XMInstallationLists.Attach(xminstallationlist);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInstallationList list
        /// </summary>
        public List<XMInstallationList> GetXMInstallationListList()
        {		
            var query = from p in this._context.XMInstallationLists
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInstallationList Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInstallationList Page List</returns>
        public PagedList<XMInstallationList> SearchXMInstallationList(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInstallationLists
                        orderby p.ID
                        select p;
            return new PagedList<XMInstallationList>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInstallationList by ID
        /// </summary>
        /// <param name="id">XMInstallationList ID</param>
        /// <returns>XMInstallationList</returns>   
        public XMInstallationList GetXMInstallationListByID(int id)
        {
            var query = from p in this._context.XMInstallationLists
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public int GetXMInstallationIDByOrderCode(string id)
        {
            var query = from p in this._context.XMInstallationLists
                        where p.OrderCode.Equals(id)
                        select p.ID;
            return query.SingleOrDefault();
        }

        public string GetXMInstallationOrderCode(string OrderCode)
        {
            var query = from p in this._context.XMInstallationLists
                        where p.OrderCode.Equals(OrderCode)
                        select p.OrderCode;
            return query.SingleOrDefault();
        }

    	/// <summary>
        /// delete XMInstallationList by ID
        /// </summary>
        /// <param name="ID">XMInstallationList ID</param>
        public void DeleteXMInstallationList(int id)
        {
            var xminstallationlist = this.GetXMInstallationListByID(id);
            if (xminstallationlist == null)
                return;
    
            if (!this._context.IsAttached(xminstallationlist))
                this._context.XMInstallationLists.Attach(xminstallationlist);
    
            this._context.DeleteObject(xminstallationlist);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInstallationList by ID
        /// </summary>
        /// <param name="IDs">XMInstallationList ID</param>
        public void BatchDeleteXMInstallationList(List<int> ids)
        {
    	   var query = from q in _context.XMInstallationLists
                    where ids.Contains(q.ID)
                    select q;
            var xminstallationlists = query.ToList();
            foreach (var item in xminstallationlists)
            {
                if (!_context.IsAttached(item))
                    _context.XMInstallationLists.Attach(item);  
    
                _context.XMInstallationLists.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 判断安装单是否已存在
        /// </summary>
        /// <param name="ordercode">订单编号</param>
        /// <param name="address">安装地址</param>
        /// <returns>记录条数</returns>
        public int JudgmentRepetition(string ordercode, string address) 
        {
            var query = from x in _context.XMInstallationLists
                        where ordercode.Equals(x.OrderCode)
                        && address.Equals(x.InstallAddress)
                        select x;
            return query.Count();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="paramWintID">买家ID</param>
        /// <param name="paramOrderCode">订单号</param>
        /// <param name="CustomerName">客户姓名</param>
        /// <param name="CustomerTel">客户电话</param>
        /// <returns></returns>
        public List<XMInstallationList> SearchXMInstallationList(string paramWintID, string paramOrderCode, string CustomerName, string CustomerTel, int paramIsArrange, int paramIsInstall) 
        {
            var query = from x in _context.XMInstallationLists
                        where x.WantID.Contains(paramWintID)
                        && x.OrderCode.Contains(paramOrderCode)
                        && x.CustomerName.Contains(CustomerName)
                        && x.CustomerTel.Contains(CustomerTel)
                        && (paramIsArrange == -1 || x.IsArrange.Value.Equals(paramIsArrange == 0 ? false : true))
                        && (paramIsInstall == -1 || x.IsInstall.Value.Equals(paramIsInstall == 0 ? false : true))
                        select x;

            return query.ToList();
        }

        public List<XMInstallationListNew> SearchXMInstallationList2(string paramWintID, string paramOrderCode, string CustomerName, string CustomerTel, int paramIsArrange, int paramIsInstall, int ddXMProject, string Nick, string start, string end)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(Nick.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
             if(!string.IsNullOrEmpty(start))
            {
                startTime = DateTime.Parse(start);
            }

             if(!string.IsNullOrEmpty(end))
            {
                endTime = DateTime.Parse(end);
            }
            //int nickID = int.Parse(Nick);
            var query = from x in _context.XMInstallationLists
                        join m in _context.XMWorkerInfoes on x.WorkerID equals m.ID into temp
                        from pm in temp.DefaultIfEmpty()
                        where x.WantID.Contains(paramWintID)
                        && x.OrderCode.Contains(paramOrderCode)
                        && x.CustomerName.Contains(CustomerName)
                        && x.CustomerTel.Contains(CustomerTel)
                        && (ddXMProject == -1 || ddXMProject == 99 || x.ProjectId.Value == ddXMProject)
                        && (Nick == "-1"||nicklist.Contains(x.NickId))
                        && (paramIsArrange == -1 || x.IsArrange.Value.Equals(paramIsArrange == 0 ? false : true))
                        && (paramIsInstall == -1 || x.IsInstall.Value.Equals(paramIsInstall == 0 ? false : true))
                        &&(start==""||end==""||(x.CreateDate>startTime&&x.CreateDate<endTime))
                        select new XMInstallationListNew
                        {
                            ID=x.ID,
                            NickId=x.NickId,
                            ProjectId=x.ProjectId,
                            WantID=x.WantID,
                            OrderCode=x.OrderCode,
                            CustomerName=x.CustomerName,
                            CustomerTel=x.CustomerTel,
                            InstallAddress=x.InstallAddress,
                            ArrangeDate=x.ArrangeDate,
                            InstallType=x.InstallType,
                            WorkerID=x.WorkerID,
                            ContactInfo=x.ContactInfo,
                            InstallationFee=x.InstallationFee,
                            PaymentDate=x.PaymentDate,
                            Remarks=x.Remarks,
                            IsArrange=x.IsArrange,
                            IsInstall=x.IsInstall,
                            CreateID=x.CreateID,
                            CreateDate=x.CreateDate,
                            UpdateID=x.UpdateID,
                            UpdateDate=x.UpdateDate,
                            FullName=pm.FullName,
                            WorkerTel=pm.Tel
                        };

            return query.ToList();
        }
        
        public List<InstallationCount> getInstallationFinish(int projectID, int nickID, string start, string end, string header)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;

            if(!string.IsNullOrEmpty(start))
            {
                startTime = DateTime.Parse(start);
            }

            if(!string.IsNullOrEmpty(end))
            {
                endTime = DateTime.Parse(end);
            }

            var query = from p in _context.XMInstallationLists
                        join m in _context.XMNicks on p.NickId equals m.nick_id into temp
                        from pm in temp.DefaultIfEmpty()
                        join n in _context.XMProjects on p.ProjectId equals n.Id into temp1
                        from pn in temp1.DefaultIfEmpty()
                        join o in _context.XMWorkerInfoes on p.WorkerID equals o.ID into temp2
                        from po in temp2.DefaultIfEmpty()
                        where (projectID == -1 || p.ProjectId == projectID) && (nickID == -1 || p.NickId == nickID) && po.FullName.Contains(header)
                        && (start==""|| end==""||(p.CreateDate> startTime&&p.CreateDate<endTime))
                        group p by new { p.ProjectId, p.NickId, p.WorkerID } into g
                        select new InstallationCount
                        {
                            projectID = g.Key.ProjectId,
                            nickID = g.Key.NickId,
                            installationCount = g.Count(),
                            installationFinishCount=g.Count(a=>a.IsInstall==true),
                            installationMoney=g.Sum(a=>a.InstallationFee),
                            finishRate= (g.Count(a => a.IsInstall == true)/ g.Count())*100,
                            workID=g.Key.WorkerID,
                        };

            return query.ToList();
        }

        /// <summary>
        /// 统计安装费用
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickIdList">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">订单付款开始时间</param>
        /// <param name="OrderInfoModifiedEnd">订单付款结束时间</param>
        /// <returns></returns>
        public decimal InstallationCost(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd)
        {
            var query = from a in _context.XMInstallationLists
                        join b in this._context.XMOrderInfoes
                        on a.OrderCode equals b.OrderCode into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()

                        join e in this._context.XMNicks on b.NickID equals e.nick_id
                      into eJoin
                        from eInfo in eJoin.DefaultIfEmpty()

                        join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                        into fJoin
                        from fInfo in fJoin.DefaultIfEmpty()

                        where ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null) || (a.CreateDate >= OrderInfoModifiedStart && a.CreateDate < OrderInfoModifiedEnd))
                        && a.IsInstall==true
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && NickIdList.Contains(b.NickID.Value)
                        && b.IsEnable.Value == false
                        && b.FinancialAudit == true
                        && eInfo.isEnable == true
                        && fInfo.IsEnable == true
                        select new XMInstallationDetails
                        {
                            InstallationFee=a.InstallationFee,
                        };

            if(query.Count()>0)
            {
                return (decimal)query.Sum(a => a.InstallationFee == null ? 0 : a.InstallationFee);
            }
            else
            {
                return 0;
            }


        }

        #endregion
    }
}
