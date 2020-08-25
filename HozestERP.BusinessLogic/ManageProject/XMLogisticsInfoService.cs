
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-28 16:34:22
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsInfoService : IXMLogisticsInfoService
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
        public XMLogisticsInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMLogisticsInfoService成员
        /// <summary>
        /// Insert into XMLogisticsInfo
        /// </summary>
        /// <param name="xmlogisticsinfo">XMLogisticsInfo</param>
        public void InsertXMLogisticsInfo(XMLogisticsInfo xmlogisticsinfo)
        {
            if (xmlogisticsinfo == null)
                return;

            if (!this._context.IsAttached(xmlogisticsinfo))

                this._context.XMLogisticsInfoes.AddObject(xmlogisticsinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMLogisticsInfo
        /// </summary>
        /// <param name="xmlogisticsinfo">XMLogisticsInfo</param>
        public void UpdateXMLogisticsInfo(XMLogisticsInfo xmlogisticsinfo)
        {
            if (xmlogisticsinfo == null)
                return;

            if (this._context.IsAttached(xmlogisticsinfo))
                this._context.XMLogisticsInfoes.Attach(xmlogisticsinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMLogisticsInfo list
        /// </summary>
        public List<XMLogisticsInfo> GetXMLogisticsInfoList()
        {
            var query = from p in this._context.XMLogisticsInfoes
                        select p;
            return query.ToList();
        }

        public List<XMLogisticsInfo> GetXMLogisticsInfoListByParam()
        {
            var query = from p in this._context.XMLogisticsInfoes
                        where p.IsEnable == false
                        && p.IsExport == false
                        && p.LogisticsCompany != ""
                        && p.LogisticsNumber != ""
                        select p;
            return query.ToList();
        }

        /// <summary>
        ///根据订单信息表主键ID 查询对应物流跟踪信息
        /// </summary>
        /// <param name="OrderInfoId"></param>
        /// <returns></returns>
        public List<XMLogisticsInfo> GetXMLogisticsInfoListByOrderInfoID(int OrderInfoId)
        {
            var query = from p in this._context.XMLogisticsInfoes
                        where p.OrderInfoID == OrderInfoId
                        && p.IsEnable == false
                        orderby p.LogisticsDate descending
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMLogisticsInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsInfo Page List</returns>
        public PagedList<XMLogisticsInfo> SearchXMLogisticsInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMLogisticsInfoes
                        orderby p.Id
                        select p;
            return new PagedList<XMLogisticsInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        public List<XMLogisticsProject> getXMLogisticsProjectList(string beginDate, string endDate, string logisticsID)
        {
            IQueryable<XMLogisticsProject> query = null;
            IQueryable<XMLogisticsProject> query1 = null;

            int expressID = int.Parse(logisticsID);

            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime begin = Convert.ToDateTime(beginDate);
                DateTime end= Convert.ToDateTime(endDate).AddDays(1);
                if(begin>= end)
                {
                    throw new Exception("起始时间不能大于结束时间");
                }
                      query = from p in _context.XMDeliveries
                            join m in _context.XMOrderInfoes on p.OrderCode equals m.OrderCode into temp
                            from pm in temp.DefaultIfEmpty()
                            join n in _context.XMNicks on pm.NickID equals n.nick_id into temp1
                            from pn in temp1.DefaultIfEmpty()
                            join r in _context.XMProjects on pn.ProjectId equals r.Id into temp2
                            from pr in temp2.DefaultIfEmpty()
                            join s in _context.Departments on pr.DepartmentID equals s.DepartmentID into temp3
                            from ps in temp3.DefaultIfEmpty()
                            where (bool)!p.IsEnabled && (bool)p.IsDelivery && !p.OrderCode.Contains("NoOrder")
                            &&p.PrintDateTime>= begin&&p.PrintDateTime<=end && (expressID==-1||p.LogisticsId== expressID)
                              group new { DepID = ps.DepartmentID, DepName = ps.DepName, ProjectID = pr.Id, ProjectName = pr.ProjectName }
                            by new { ps.DepartmentID, ps.DepName, pr.Id, pr.ProjectName } into g
                            select new XMLogisticsProject
                            {
                                DepID = g.Key.DepartmentID,
                                DepName = g.Key.DepName,
                                ProjectID = g.Key.Id,
                                ProjectName = g.Key.ProjectName,
                                PackageNum = g.Count()
                            };

                    query1 = from p in _context.XMExpressManagements
                             join m in _context.Departments on p.DepartmentID equals m.DepartmentID into temp
                             from pm in temp.DefaultIfEmpty()
                             where (bool)!p.IsEnable && p.PrintDate>=begin&&p.PrintDate<=end && (expressID==-1||p.ExpressID== expressID)
                             group new { DepID = pm.DepartmentID, DepName = pm.DepName }
                             by new { pm.DepartmentID, pm.DepName } into g
                             select new XMLogisticsProject
                             {
                                 DepID = g.Key.DepartmentID,
                                 DepName = g.Key.DepName,
                                 ProjectID = g.Key.DepartmentID + 100,
                                 ProjectName = "无列名",
                                 PackageNum = g.Count()
                             };
            }
            else
            {
                query = from p in _context.XMDeliveries
                        join m in _context.XMOrderInfoes on p.OrderCode equals m.OrderCode into temp
                        from pm in temp.DefaultIfEmpty()
                        join n in _context.XMNicks on pm.NickID equals n.nick_id into temp1
                        from pn in temp1.DefaultIfEmpty()
                        join r in _context.XMProjects on pn.ProjectId equals r.Id into temp2
                        from pr in temp2.DefaultIfEmpty()
                        join s in _context.Departments on pr.DepartmentID equals s.DepartmentID into temp3
                        from ps in temp3.DefaultIfEmpty()
                        where (bool)!p.IsEnabled && (bool)p.IsDelivery && !p.OrderCode.Contains("NoOrder") && (expressID == -1 || p.LogisticsId == expressID)
                        group new { DepID = ps.DepartmentID, DepName = ps.DepName, ProjectID = pr.Id, ProjectName = pr.ProjectName }
                        by new { ps.DepartmentID, ps.DepName, pr.Id, pr.ProjectName } into g
                        select new XMLogisticsProject
                        {
                            DepID = g.Key.DepartmentID,
                            DepName = g.Key.DepName,
                            ProjectID = g.Key.Id,
                            ProjectName = g.Key.ProjectName,
                            PackageNum = g.Count()
                        };

                query1 = from p in _context.XMExpressManagements
                         join m in _context.Departments on p.DepartmentID equals m.DepartmentID into temp
                         from pm in temp.DefaultIfEmpty()
                         where (bool)!p.IsEnable && (expressID == -1 || p.ExpressID == expressID)
                         group new { DepID = pm.DepartmentID, DepName = pm.DepName }
                         by new { pm.DepartmentID, pm.DepName } into g
                         select new XMLogisticsProject
                         {
                             DepID = g.Key.DepartmentID,
                             DepName = g.Key.DepName,
                             ProjectID = g.Key.DepartmentID + 100,
                             ProjectName = "无列名",
                             PackageNum = g.Count()
                         };
            }

            List<XMLogisticsProject> list = query.Where(a=>a.DepID!=null).ToList();
            List<XMLogisticsProject> list1 = query1.ToList();

            List<XMLogisticsProject> realList = list.Concat(list1).ToList();

            return realList;
        }

        /// <summary>
        /// get a XMLogisticsInfo by Id
        /// </summary>
        /// <param name="id">XMLogisticsInfo Id</param>
        /// <returns>XMLogisticsInfo</returns>   
        public XMLogisticsInfo GetXMLogisticsInfoById(int id)
        {
            var query = from p in this._context.XMLogisticsInfoes
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMLogisticsInfo by Id
        /// </summary>
        /// <param name="Id">XMLogisticsInfo Id</param>
        public void DeleteXMLogisticsInfo(int id)
        {
            var xmlogisticsinfo = this.GetXMLogisticsInfoById(id);
            if (xmlogisticsinfo == null)
                return;

            if (!this._context.IsAttached(xmlogisticsinfo))
                this._context.XMLogisticsInfoes.Attach(xmlogisticsinfo);

            this._context.DeleteObject(xmlogisticsinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMLogisticsInfo by Id
        /// </summary>
        /// <param name="Ids">XMLogisticsInfo Id</param>
        public void BatchDeleteXMLogisticsInfo(List<int> ids)
        {
            var query = from q in _context.XMLogisticsInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmlogisticsinfos = query.ToList();
            foreach (var item in xmlogisticsinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMLogisticsInfoes.Attach(item);

                _context.XMLogisticsInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
