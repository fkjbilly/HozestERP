
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-07-16 14:53:30
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
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMConsultationService : IXMConsultationService
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
        public XMConsultationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMConsultationService成员
        /// <summary>
        /// Insert into XMConsultation
        /// </summary>
        /// <param name="xmconsultation">XMConsultation</param>
        public void InsertXMConsultation(XMConsultation xmconsultation)
        {
            if (xmconsultation == null)
                return;

            if (!this._context.IsAttached(xmconsultation))

                this._context.XMConsultations.AddObject(xmconsultation);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMConsultation
        /// </summary>
        /// <param name="xmconsultation">XMConsultation</param>
        public void UpdateXMConsultation(XMConsultation xmconsultation)
        {
            if (xmconsultation == null)
                return;

            if (this._context.IsAttached(xmconsultation))
                this._context.XMConsultations.Attach(xmconsultation);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMConsultation list
        /// </summary>
        public List<XMConsultation> GetXMConsultationList()
        {
            var query = from p in this._context.XMConsultations
                        select p;
            return query.ToList();
        }

        public List<CustomerInfo> GetCustomerServiceList(string DepCode)
        {
            string[] DepList = DepCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var query = from p in this._context.CustomerInfoes
                        join dep in this._context.Departments
                        on p.DepartmentID equals dep.DepartmentID
                        where p.Deleted == false
                        && dep.Deleted == false
                        && DepList.Contains(dep.DepCode)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMConsultation Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMConsultation Page List</returns>
        public PagedList<XMConsultation> SearchXMConsultation(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMConsultations
                        orderby p.Id
                        select p;
            return new PagedList<XMConsultation>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        public List<XMConsultation> GetDataAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> nickcount, int Shift)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1);
            }
            BeginDate = DateTime.Parse(((DateTime)BeginDate).ToShortDateString() + " 08:40:00");
            EndDate = DateTime.Parse(((DateTime)EndDate).ToShortDateString() + " 08:40:00");
            var query = from p in this._context.XMConsultations
                        where p.IsEnable == false
                        && (PlatformId == -1 || p.PlatformTypeId == PlatformId)
                        && ((NickId == -1 || p.NickId == NickId) || (NickId == -2 && nickcount.Contains(p.NickId)))
                        && (p.ReceptionDate >= BeginDate && p.ReceptionDate < EndDate)
                        && (CustomerId == -1 || p.CreatorID == CustomerId)
                        orderby p.CreatorID, p.PlatformTypeId, p.NickId, p.ReceptionDate
                        select p;
            if (Shift == -1)
            {
                return query.ToList();
            }
            else
            {
                List<XMConsultation> MorningShift = new List<XMConsultation>();
                List<XMConsultation> EveningShift = new List<XMConsultation>();
                foreach (XMConsultation info in query.ToList())
                {
                    DateTime begin = DateTime.Parse(((DateTime)info.ReceptionDate).ToShortDateString() + " 08:40:00");
                    DateTime end = DateTime.Parse(((DateTime)info.ReceptionDate).ToShortDateString() + " 17:30:00");
                    if ((DateTime)info.ReceptionDate >= begin && (DateTime)info.ReceptionDate <= end)
                    {
                        MorningShift.Add(info);
                    }
                    else
                    {
                        EveningShift.Add(info);
                    }
                }
                if (Shift == 0)
                {
                    return MorningShift;
                }
                else
                {
                    return EveningShift;
                }
            }
        }

        public List<XMDataAnalysy> GetDataAnalysisNoDealList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> nickcount, string NoTurnoverType, int FollowCount, int Shift)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1);
            }
            BeginDate = DateTime.Parse(((DateTime)BeginDate).ToShortDateString() + " 08:40:00");
            EndDate = DateTime.Parse(((DateTime)EndDate).ToShortDateString() + " 08:40:00");
            var query = from p in this._context.XMConsultations
                        where p.IsEnable == false
                        && (PlatformId == -1 || p.PlatformTypeId == PlatformId)
                        && ((NickId == -1 || p.NickId == NickId) || (NickId == -2 && nickcount.Contains(p.NickId)))
                        && (p.ReceptionDate >= BeginDate && p.ReceptionDate <= EndDate)
                        && (CustomerId == -1 || p.CreatorID == CustomerId)
                        && (NoTurnoverType == "-1" || p.NoTurnoverType == NoTurnoverType)
                        && (p.IsOrder == false || p.IsOrder == null)
                        orderby p.NoTurnoverType, p.PlatformTypeId, p.NickId
                        select new XMDataAnalysy
                        {
                            ID = p.Id,
                            PlatformTypeId = p.PlatformTypeId,
                            NickId = p.NickId,
                            CreatorID = p.CreatorID,
                            NoTurnoverType = p.NoTurnoverType,
                            DateReason = p.DateReason,
                            ReceptionDate = p.ReceptionDate
                        };
            List<XMDataAnalysy> all = new List<XMDataAnalysy>();
            if (Shift == -1)
            {
                all = query.ToList();
            }
            else
            {
                List<XMDataAnalysy> MorningShift = new List<XMDataAnalysy>();
                List<XMDataAnalysy> EveningShift = new List<XMDataAnalysy>();
                foreach (XMDataAnalysy info in query.ToList())
                {
                    DateTime begin = DateTime.Parse(((DateTime)info.ReceptionDate).ToShortDateString() + " 08:40:00");
                    DateTime end = DateTime.Parse(((DateTime)info.ReceptionDate).ToShortDateString() + " 17:30:00");
                    if ((DateTime)info.ReceptionDate >= begin && (DateTime)info.ReceptionDate <= end)
                    {
                        MorningShift.Add(info);
                    }
                    else
                    {
                        EveningShift.Add(info);
                    }
                }
                if (Shift == 0)
                {
                    all = MorningShift;
                }
                else
                {
                    all = EveningShift;
                }
            }

            List<XMDataAnalysy> list = new List<XMDataAnalysy>();
            foreach (XMDataAnalysy info in all)
            {
                var q = from p in this._context.XMConsultationDetails
                        where p.ConsultationId == info.ID
                        select p;
                if (FollowCount == -1 || (q != null && (q.ToList()).Count == FollowCount))
                {
                    info.FollowCount = (q.ToList()).Count;
                    list.Add(info);
                }
            }
            return list;
        }

        public string GetDepName(int DepartmentID)
        {
            var query = from p in this._context.Departments
                        where p.Deleted == false
                        && p.DepartmentID == DepartmentID
                        orderby p.DepName
                        select p.DepName;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get a XMConsultation by Id
        /// </summary>
        /// <param name="id">XMConsultation Id</param>
        /// <returns>XMConsultation</returns>   
        public XMConsultation GetXMConsultationById(int id)
        {
            var query = from p in this._context.XMConsultations
                        where p.Id.Equals(id)
                        && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMConsultation by Id
        /// </summary>
        /// <param name="Id">XMConsultation Id</param>
        public void DeleteXMConsultation(int id)
        {
            var xmconsultation = this.GetXMConsultationById(id);
            if (xmconsultation == null)
                return;

            if (!this._context.IsAttached(xmconsultation))
                this._context.XMConsultations.Attach(xmconsultation);

            this._context.DeleteObject(xmconsultation);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMConsultation by Id
        /// </summary>
        /// <param name="Ids">XMConsultation Id</param>
        public void BatchDeleteXMConsultation(List<int> ids)
        {
            var query = from q in _context.XMConsultations
                        where ids.Contains(q.Id)
                        select q;
            var xmconsultations = query.ToList();
            foreach (var item in xmconsultations)
            {
                if (!_context.IsAttached(item))
                    _context.XMConsultations.Attach(item);

                _context.XMConsultations.DeleteObject(item);
            }
            _context.SaveChanges();
        }


        /// <summary>
        /// 查询咨询跟进
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<XMConsultation> GetXMConsultationList(string IsOrder, int PlatformTypeId, int nickid, DateTime? starttime, DateTime? endtime, string cust, string creat, int paramPageIndex, int paramPageSize, int count, string grade, List<int?> nickcount)
        {
            bool isorder = false;
            if (IsOrder == "1")
            {
                isorder = true;
            }
            if (endtime != null)
            {
                endtime = ((DateTime)endtime).AddDays(1).AddSeconds(-1);
            }
            IQueryable<XMConsultation> query;
            if (count == -1)
            {
                query = from p in _context.XMConsultations
                        join a in this._context.XMConsultationDetails
                        on p.Id equals a.ConsultationId
                        into temp
                        from tt in temp.DefaultIfEmpty()
                        join c in this._context.CustomerInfoes  //管理员
                        on p.CreatorID equals c.CustomerID
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && p.IsEnable == false
                        && ((nickid == -1 || p.NickId == nickid) || (nickid == -2 && nickcount.Contains(p.NickId)))
                        && ((starttime == null && endtime == null) ||
                        (p.ReceptionDate >= starttime && p.ReceptionDate <= endtime))
                        && (cust == null || p.CustomerID.Contains(cust))
                        && (creat == null || c.FullName.Contains(creat))
                        && (grade == "-1" || p.FollowGrade == grade)
                        && (IsOrder == "-1" || (isorder == true && p.IsOrder == true) || (isorder == false && (p.IsOrder == false || p.IsOrder == null)))
                        //&& p.XMConsultationDetails >= 1
                        //orderby p.ReceptionDate descending
                        select p;
            }
            else
            {
                query = from p in _context.XMConsultations
                        join a in this._context.XMConsultationDetails
                        on p.Id equals a.ConsultationId into temp
                        from a in temp.DefaultIfEmpty()
                        join c in this._context.CustomerInfoes  //管理员
                        on p.CreatorID equals c.CustomerID
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && p.IsEnable == false
                        && ((nickid == -1 || p.NickId == nickid) || (nickid == -2 && nickcount.Contains(p.NickId)))
                        && ((starttime == null && endtime == null) ||
                        (p.ReceptionDate >= starttime && p.ReceptionDate <= endtime))
                        && (cust == null || p.CustomerID.Contains(cust))
                        && (creat == null || c.FullName.Contains(creat))
                        && (grade == "-1" || p.FollowGrade == grade)
                        && (IsOrder == "-1" || (isorder == true && p.IsOrder == true) || (isorder == false && (p.IsOrder == false || p.IsOrder == null)))
                        group
                        new
                        {
                            p = p,
                            ConsultationId = a.ConsultationId
                        } by new
                        {
                            a.ConsultationId,
                            p
                        } into g
                        where ((g.Count() == count && (count == 1 || count == 2) && g.Key.ConsultationId != null) || (g.Count() >= count && count == 3) || (g.Count() == 1 && count == 0 && g.Key.ConsultationId == null))
                        //orderby g.Key.p.ReceptionDate descending
                        select g.Key.p;
            }
            return new List<XMConsultation>(query.Distinct().ToList());
        }

        /// <summary>
        /// 根据条件查询是否重复
        /// </summary>
        /// <param name="id">XMConsultation Id</param>
        /// <returns>XMConsultation</returns>   
        public XMConsultation GetXMConsultationByCx(int PlatformTypeId, string cust, string ManufacturersCode)
        {
            var query = from p in this._context.XMConsultations
                        where p.PlatformTypeId == PlatformTypeId
                        && p.CustomerID == cust
                        && p.IsEnable.Value == false
                        && p.IsOrder == false
                        && p.ManufacturersCode == ManufacturersCode
                        select p;
            return query.SingleOrDefault();
        }

        public XMConsultation GetXMConsultationByOrderCode(string OrderCode, string ManufacturersCode)
        {
            var query = from p in this._context.XMConsultations
                        where p.OrderCode == OrderCode
                        && p.IsEnable.Value == false
                        && p.ManufacturersCode == ManufacturersCode
                        select p;
            return query.SingleOrDefault();
        }

        #endregion
    }
}
