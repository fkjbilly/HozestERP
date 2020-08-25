
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-08-04 09:20:45
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

namespace HozestERP.BusinessLogic.ManageApplication
{
    public partial class XMApplicationService : IXMApplicationService
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
        public XMApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMApplicationService成员
        /// <summary>
        /// Insert into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
        public void InsertXMApplication(XMApplication xmapplication)
        {
            if (xmapplication == null)
                return;

            if (!this._context.IsAttached(xmapplication))

                this._context.XMApplications.AddObject(xmapplication);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
        public void UpdateXMApplication(XMApplication xmapplication)
        {
            if (xmapplication == null)
                return;

            if (this._context.IsAttached(xmapplication))
                this._context.XMApplications.Attach(xmapplication);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMApplication list
        /// </summary>
        public List<XMApplication> GetXMApplicationList()
        {
            var query = from p in this._context.XMApplications
                        select p;
            return query.ToList();
        }

        public List<XMApplication> GetXMApplicationListByReturnTime(DateTime Begin, DateTime End, List<int?> ApplicationTypeList)
        {
            var query = from p in this._context.XMApplications
                        where p.IsEnable == false
                        && p.ReturnTime != null
                        && p.ReturnTime >= Begin
                        && p.ReturnTime < End
                        && ApplicationTypeList.Contains(p.ApplicationType)
                        select p;
            return query.ToList();
        }

        public List<XMApplication> GetXMApplicationListByFinishTime(DateTime Begin, DateTime End, int ApplicationType)
        {
            var query = from p in this._context.XMApplications
                        where p.IsEnable == false
                        && p.FinishTime != null
                        && p.FinishTime >= Begin
                        && p.FinishTime < End
                        && p.ApplicationType == ApplicationType
                        select p;
            return query.ToList();
        }

        public List<XMApplication> GetDataAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> nickcount, int ApplicationType)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1).AddSeconds(-1);
            }
            var query = from p in this._context.XMApplications
                        where p.IsEnable == false
                        && (PlatformId == -1 || p.PlatformTypeId == PlatformId)
                        && ((NickId == -1 || p.NickId == NickId) || (NickId == -2 && nickcount.Contains(p.NickId)))
                        && ((BeginDate == null && EndDate == null) || (p.CreateDate >= BeginDate && p.CreateDate <= EndDate))
                        && (CustomerId == -1 || p.CreateID == CustomerId)
                        && (ApplicationType == -1 || p.ApplicationType == ApplicationType)
                        orderby p.CreateID, p.PlatformTypeId, p.NickId
                        select p;
            return query.ToList();
        }

        public int GetNickCount(List<XMApplication> Questionlist, int PlatformTypeId, int NickId)
        {
            int count = 0;
            var query = from p in Questionlist
                        where p.PlatformTypeId == PlatformTypeId
                        && p.NickId == NickId
                        select p;
            if (query != null)
            {
                count = query.ToList().Count;
            }
            return count;
        }

        public List<XMApplication> GetXMApplicationListByApplicationNo(string ApplicationNo)
        {
            var query = from p in this._context.XMApplications
                        where p.IsEnable == false
                        && p.ApplicationNo.Contains(ApplicationNo)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMApplication Page List</returns>
        public PagedList<XMApplication> SearchXMApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMApplications
                        orderby p.ID
                        select p;
            return new PagedList<XMApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMApplication by ID
        /// </summary>
        /// <param name="id">XMApplication ID</param>
        /// <returns>XMApplication</returns>   
        public XMApplication GetXMApplicationByID(int id)
        {
            var query = from p in this._context.XMApplications
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }


        /// <summary>
        /// 根据订单Id集合 查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public List<XMApplication> GetXMApplicationListByIds(List<int> Ids)
        {

            var query = from p in this._context.XMApplications
                        where p.IsEnable == false
                        && Ids.Contains(p.ID)
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// delete XMApplication by ID
        /// </summary>
        /// <param name="ID">XMApplication ID</param>
        public void DeleteXMApplication(int id)
        {
            var xmapplication = this.GetXMApplicationByID(id);
            if (xmapplication == null)
                return;

            if (!this._context.IsAttached(xmapplication))
                this._context.XMApplications.Attach(xmapplication);

            this._context.DeleteObject(xmapplication);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMApplication by ID
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        public void BatchDeleteXMApplication(List<int> ids)
        {
            var query = from q in _context.XMApplications
                        where ids.Contains(q.ID)
                        select q;
            var xmapplications = query.ToList();
            foreach (var item in xmapplications)
            {
                if (!_context.IsAttached(item))
                    _context.XMApplications.Attach(item);

                _context.XMApplications.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        class Parameter
        {
            public int? ID { get; set; }
            public int? TypeID { get; set; }
        }

        /// <summary>
        /// 退换货
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<XMApplication> GetXMConsultationList(int ddlPlatform, int nickid, int timetype, int ApplicaType, int Supervisor, int Financial, int Send, string txtSrvAfterCustomerID, DateTime? txtBeginDate, DateTime? txtEndDate, List<int?> a, string Tel, string fullName)
        {
            IQueryable<XMApplication> query = null;
            var bb = false;
            if (Supervisor == 1)
            {
                bb = true;
            }
            var cc = false;
            if (Financial == 1)
            {
                cc = true;
            }
            var sen = false;
            if (Send == 1)
            {
                sen = true;
            }

            if (timetype == 1)
            {
                query = from p in _context.XMApplications
                        join n in _context.XMSpareAddresses on new Parameter { ID = p.ID, TypeID = 710 } equals new Parameter { ID = n.OtherID, TypeID = n.TypeID } into temp1
                        from pn in temp1.DefaultIfEmpty()
                            //join m in _context.XMOrderInfoes on p.OrderCode equals m.OrderCode into temp
                            //from pm in temp.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (ddlPlatform == -1 || p.PlatformTypeId == ddlPlatform)
                        && ((nickid == -1 || p.NickId == nickid) || (nickid == -2 && a.Contains(p.NickId)))
                        && (ApplicaType == -1 || p.ApplicationType == ApplicaType)
                        && (Supervisor == -1 || p.SupervisorStatus == bb)
                        && (Financial == -1 || p.FinancialStatus == cc)
                        && (Send == -1 || p.IsSend == sen)
                        && (txtSrvAfterCustomerID == null || p.OrderCode.Contains(txtSrvAfterCustomerID))
                        && (string.IsNullOrEmpty(Tel) || pn.Mobile == Tel)
                        && (string.IsNullOrEmpty(fullName) || pn.FullName == fullName)
                        && p.CreateDate >= txtBeginDate && p.CreateDate < txtEndDate
                        select p;
            }
            else if (timetype == 2)
            {
                query = from p in _context.XMApplications
                        join n in _context.XMSpareAddresses on new Parameter { ID = p.ID, TypeID = 710 } equals new Parameter { ID = n.OtherID, TypeID = n.TypeID } into temp1
                        from pn in temp1.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (ddlPlatform == -1 || p.PlatformTypeId == ddlPlatform)
                        && ((nickid == -1 || p.NickId == nickid) || (nickid == -2 && a.Contains(p.NickId)))
                        && (ApplicaType == -1 || p.ApplicationType == ApplicaType)
                        && (Supervisor == -1 || p.SupervisorStatus == bb)
                        && (Financial == -1 || p.FinancialStatus == cc)
                        && (Send == -1 || p.IsSend == sen)
                        && (txtSrvAfterCustomerID == null || p.OrderCode.Contains(txtSrvAfterCustomerID))
                        && (string.IsNullOrEmpty(Tel) || pn.Mobile == Tel)
                        && (string.IsNullOrEmpty(fullName) || pn.FullName == fullName)
                        && p.FinishTime >= txtBeginDate && p.FinishTime < txtEndDate
                        select p;
            }
            else if (timetype == 3)
            {
                query = from p in _context.XMApplications
                        join n in _context.XMSpareAddresses on new Parameter { ID = p.ID, TypeID = 710 } equals new Parameter { ID = n.OtherID, TypeID = n.TypeID } into temp1
                        from pn in temp1.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (ddlPlatform == -1 || p.PlatformTypeId == ddlPlatform)
                        && ((nickid == -1 || p.NickId == nickid) || (nickid == -2 && a.Contains(p.NickId)))
                        && (ApplicaType == -1 || p.ApplicationType == ApplicaType)
                        && (Supervisor == -1 || p.SupervisorStatus == bb)
                        && (Financial == -1 || p.FinancialStatus == cc)
                        && (Send == -1 || p.IsSend == sen)
                        && (txtSrvAfterCustomerID == null || p.OrderCode.Contains(txtSrvAfterCustomerID))
                        && (string.IsNullOrEmpty(Tel) || pn.Mobile == Tel)
                        && (string.IsNullOrEmpty(fullName) || pn.FullName == fullName)
                        && p.ReturnTime >= txtBeginDate && p.ReturnTime < txtEndDate
                        select p;
            }
            return query.ToList();
        }

        public List<XMApplicationReport> GetXMApplicationReportData(int Platform, int Nick, int TimeType, int ApplicaType, DateTime BeginDate, DateTime EndDate, int Type)
        {
            List<XMApplicationReport> list = new List<XMApplicationReport>();

            if (TimeType == 1)
            {
                var query = from p in _context.XMApplicationExchanges
                            join m in _context.XMApplications on p.ApplicationId equals m.ID into temp
                            from pm in temp.DefaultIfEmpty()
                            join n in (from a in _context.XMProductDetails
                                       join b in _context.XMProducts on a.ProductId equals b.Id
                                       where a.IsEnable == false && b.IsEnable == false
                                       select new
                                       {
                                           a.PlatformTypeId,
                                           a.PlatformMerchantCode,
                                           b.ProductName,
                                           b.ManufacturersCode
                                       }) on new { p.PlatformMerchantCode, pm.PlatformTypeId } equals new { n.PlatformMerchantCode, n.PlatformTypeId }
                            where pm.IsEnable == false
                            && (Platform == -1 || pm.PlatformTypeId == Platform)
                            && (Nick == -1 || pm.NickId == Nick)
                            && (ApplicaType == -1 || pm.ApplicationType == ApplicaType) && p.IsApplication == Type
                            && pm.CreateDate >= BeginDate && pm.CreateDate < EndDate
                            group p by new { n.ManufacturersCode, n.ProductName } into g
                            select new XMApplicationReport
                            {
                                ManufacturersCode = g.Key.ManufacturersCode,
                                ProductName = g.Key.ProductName,
                                Num = g.Count()
                            };

                list = query.ToList();
            }
            else if (TimeType == 2)
            {
                var query = from p in _context.XMApplicationExchanges
                            join m in _context.XMApplications on p.ApplicationId equals m.ID into temp
                            from pm in temp.DefaultIfEmpty()
                            join n in (from a in _context.XMProductDetails
                                       join b in _context.XMProducts on a.ProductId equals b.Id
                                       where a.IsEnable == false && b.IsEnable == false
                                       select new
                                       {
                                           a.PlatformTypeId,
                                           a.PlatformMerchantCode,
                                           b.ProductName,
                                           b.ManufacturersCode
                                       }) on new { p.PlatformMerchantCode, pm.PlatformTypeId } equals new { n.PlatformMerchantCode, n.PlatformTypeId } into temp1
                            from pn in temp1.DefaultIfEmpty()
                            where pm.IsEnable == false
                            && (Platform == -1 || pm.PlatformTypeId == Platform)
                            && (Nick == -1 || pm.NickId == Nick)
                            && (ApplicaType == -1 || pm.ApplicationType == ApplicaType) && p.IsApplication == Type
                            && pm.FinishTime >= BeginDate && pm.FinishTime < EndDate
                            group p by new { pn.ManufacturersCode, pn.ProductName } into g
                            select new XMApplicationReport
                            {
                                ManufacturersCode = g.Key.ManufacturersCode,
                                ProductName = g.Key.ProductName,
                                Num = g.Count()
                            };

                list = query.ToList();
            }
            else if (TimeType == 3)
            {
                var query = from p in _context.XMApplicationExchanges
                            join m in _context.XMApplications on p.ApplicationId equals m.ID into temp
                            from pm in temp.DefaultIfEmpty()
                            join n in (from a in _context.XMProductDetails
                                       join b in _context.XMProducts on a.ProductId equals b.Id
                                       where a.IsEnable == false && b.IsEnable == false
                                       select new
                                       {
                                           a.PlatformTypeId,
                                           a.PlatformMerchantCode,
                                           b.ProductName,
                                           b.ManufacturersCode
                                       }) on new { p.PlatformMerchantCode, pm.PlatformTypeId } equals new { n.PlatformMerchantCode, n.PlatformTypeId } into temp1
                            from pn in temp1.DefaultIfEmpty()
                            where pm.IsEnable == false
                            && (Platform == -1 || pm.PlatformTypeId == Platform)
                            && (Nick == -1 || pm.NickId == Nick)
                            && (ApplicaType == -1 || pm.ApplicationType == ApplicaType) && p.IsApplication == Type
                            && pm.ReturnTime >= BeginDate && pm.ReturnTime < EndDate
                            group p by new { pn.ManufacturersCode, pn.ProductName } into g
                            select new XMApplicationReport
                            {
                                ManufacturersCode = g.Key.ManufacturersCode,
                                ProductName = g.Key.ProductName,
                                Num = g.Count()
                            };

                list = query.ToList();
            }

            int AllCount = list.Sum(a => a.Num);
            foreach(var item in list)
            {
                item.CountProportion= Math.Round(Math.Round(decimal.Parse(item.Num.ToString()) / AllCount, 4) * 100, 2) + "%";
            }

            return list;
        }

        /// <summary>
        /// 导出execl数据 （退款金额明细）
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="nickIdList"></param>
        /// <param name="OrderCode"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="timeType"></param>
        /// <returns></returns>
        public List<XMApplication> GetXMApplicationExcelData(int platform, List<int> nickIdList, string OrderCode, DateTime? BeginDate, DateTime? EndDate, int timeType)
        {
            //相关限制条件临时注释
            IQueryable<XMApplication> query = null;
            if (timeType == 1 || timeType == 2)                         //创单时间 付款时间
            {
                query = from p in _context.XMApplications
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId.Value)
                        && (OrderCode == "" || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        select p;
            }
            else if (timeType == 3)                                        //发货时间
            {
                query = from p in _context.XMApplications
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId.Value)
                        && (OrderCode == "" || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7, 8 }.Contains((int)p.ApplicationType)
                        select p;
            }
            else if (timeType == 4)                               //交易成功时间
            {
                query = from p in _context.XMApplications
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId.Value)
                        && (OrderCode == "" || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7, 8 }.Contains((int)p.ApplicationType)
                        select p;
                //List<string> list = query1.ToList().Select(p => p.OrderCode).Distinct().ToList();
                //var query2 = from p in _context.XMOrderInfoes
                //             where p.IsEnable == false
                //             && list.Contains(p.OrderCode)
                //             select p;
                //query = from p in query1.Distinct()
                //        join q in query2.Distinct()
                //        on p.OrderCode equals q.OrderCode
                //        where q.CompletionTime < p.CreateDate
                //        select p;
            }
            return new List<XMApplication>(query.ToList());
        }

        public List<XMApplicationExchange> GetXMConsultationListByDataByBrandType(List<XMApplication> List, int BrandType)
        {
            var query = from p in this._context.XMApplicationExchanges
                        join q in List
                        on p.ApplicationId equals q.ID
                        join a in this._context.XMProductDetails
                        on p.PlatformMerchantCode equals a.PlatformMerchantCode
                        join b in this._context.XMProducts
                        on a.ProductId equals b.Id
                        where a.IsEnable == false
                        && b.IsEnable == false
                        && b.BrandTypeId == BrandType
                        select p;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// 退款金额详细
        /// </summary>
        public List<XMApplication> GetXMConsultationListByData(int platform, List<int?> nickIdList, string OrderCode, DateTime? BeginDate, DateTime? EndDate, int timeType)
        {
            //相关限制条件临时注释
            IQueryable<XMApplication> query = null;
            if (timeType == 1 || timeType == 2)                         //创单时间 付款时间
            {
                query = from p in _context.XMApplications
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId)
                        && (OrderCode == null || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        select p;
            }
            else if (timeType == 3)                                        //发货时间
            {
                query = from p in _context.XMApplications
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId)
                        && (OrderCode == null || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7, 8 }.Contains((int)p.ApplicationType)
                        select p;
            }
            else if (timeType == 4)                               //交易成功时间
            {
                query = from p in _context.XMApplications
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId)
                        && (OrderCode == null || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7, 8 }.Contains((int)p.ApplicationType)
                        select p;
                //List<string> list = query1.ToList().Select(p => p.OrderCode).Distinct().ToList();
                //var query2 = from p in _context.XMOrderInfoes
                //             where p.IsEnable == false
                //             && list.Contains(p.OrderCode)
                //             select p;
                //query = from p in query1.Distinct()
                //        join q in query2.Distinct()
                //        on p.OrderCode equals q.OrderCode
                //        where q.CompletionTime < p.CreateDate
                //        select p;
            }
            return new List<XMApplication>(query.ToList());
        }

        /// <summary>
        /// 退换货生成报表
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<XMApplication> GetXMEXList(int ddlPlatform, List<int> nickid, DateTime? txtBeginDate, DateTime? txtEndDate)
        {
            List<int?> nick = new List<int?>();
            foreach (var a in nickid)
            {
                nick.Add(a);
            }
            IQueryable<XMApplication> query = null;
            query = from p in _context.XMApplications
                    where p.IsEnable == false
                    && (ddlPlatform == -1 || p.PlatformTypeId == ddlPlatform)
                    && (nick.Contains(p.NickId))
                    && p.CreateDate >= txtBeginDate && p.CreateDate < txtEndDate
                    && p.FinishTime != null
                    && p.IsSend == true
                    && p.FinancialStatus == true
                    && p.SupervisorStatus == true
                    select p;
            return new List<XMApplication>(query.Distinct().ToList());
        }

        /// <summary>
        /// 根据订单号查询该订单的退换货记录
        /// </summary>
        public List<XMApplication> GetXMApplicationListByOrderCode(string OrderCode)
        {
            var query = from p in this._context.XMApplications
                        where p.OrderCode == OrderCode
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        #endregion
    }
}
