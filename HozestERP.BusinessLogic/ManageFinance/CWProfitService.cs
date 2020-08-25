
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-06-02 15:24:37
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
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWProfitService : ICWProfitService
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
        public CWProfitService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region ICWProfitService成员
        /// <summary>
        /// Insert into CWProfit
        /// </summary>
        /// <param name="cwprofit">CWProfit</param>
        public void InsertCWProfit(CWProfit cwprofit)
        {
            if (cwprofit == null)
                return;

            if (!this._context.IsAttached(cwprofit))

                this._context.CWProfits.AddObject(cwprofit);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into CWProfit
        /// </summary>
        /// <param name="cwprofit">CWProfit</param>
        public void UpdateCWProfit(CWProfit cwprofit)
        {
            if (cwprofit == null)
                return;

            if (this._context.IsAttached(cwprofit))
                this._context.CWProfits.Attach(cwprofit);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to CWProfit list
        /// </summary>
        public List<CWProfit> GetCWProfitList()
        {
            var query = from p in this._context.CWProfits
                        select p;
            return query.ToList();
        }

        public CWProfit GetCWProfitByData(int FinancialFieldId, int ProjectId, int NickId, int DepartmentType, string YearStr, string MonthStr)
        {
            var query = from p in this._context.CWProfits
                        where p.IsEnable == false
                        && p.FinancialFieldId == FinancialFieldId
                        && p.YearStr == YearStr
                        && p.MonthStr == MonthStr
                        && ((DepartmentType == -1 && (ProjectId == -1 || p.ProjectId == ProjectId) && (NickId == -1 || p.NickId == NickId))
                        || (DepartmentType != -1 && p.DepartmentTypeId == DepartmentType))
                        select p;
            return query.SingleOrDefault();
        }

        public List<CWProfit> GetCWProfitListByData(int FinancialFieldId, int ProjectId, int NickId, int DepartmentType, string YearStr, string MonthStr)
        {
            var query = from p in this._context.CWProfits
                        where p.IsEnable == false
                        && p.FinancialFieldId == FinancialFieldId
                        && p.YearStr == YearStr
                        && p.MonthStr == MonthStr
                        && ((DepartmentType == -1 && (ProjectId == -1 || p.ProjectId == ProjectId) && (NickId == -1 || p.NickId == NickId))
                        || (DepartmentType != -1 && p.DepartmentTypeId == DepartmentType))
                        select p;
            return query.ToList();
        }

        public List<CWProfit> GetCWProfitListByData(int FinancialFieldId, int ProjectId, string YearStr, string MonthStr)
        {
            var query = from p in this._context.CWProfits
                        where p.IsEnable == false
                        && p.FinancialFieldId == FinancialFieldId
                        && p.YearStr == YearStr
                        && p.MonthStr == MonthStr
                        && p.ProjectId == ProjectId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据查询 返回结果
        /// </summary>
        /// <param name="ProjectId">项目说明Id</param>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="DateTimeId">时间类型Id</param>
        /// <param name="YearStr">年份</param>
        /// <param name="MonthStr">月份</param>
        /// <returns></returns>
        //public List<CWProfit> GetCWProfitList(int ProjectId, int PlatformTypeId, int NickId, int DateTimeId, string YearStr, string MonthStr)
        //{ 
        //    var query = from p in this._context.CWProfits
        //                where p.ProjectId==ProjectId
        //                && (p.PlatformTypeId == PlatformTypeId || PlatformTypeId==-1)
        //                && (p.NickId == NickId || NickId == -1)
        //                && p.DateTimeId==DateTimeId
        //                && p.YearStr.Equals(YearStr)
        //                && p.MonthStr.Equals(MonthStr)
        //                && p.IsEnable==false
        //                select p;
        //    return query.ToList();
        //}

        /// <summary>
        /// 根据查询 返回结果
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="DateTimeId">时间类型Id</param>
        /// <param name="YearStr">年份</param>
        /// <param name="MonthStr">月份</param>
        /// <param name="ProjectId">项目Id</param>
        /// <returns></returns>
        //public List<CWProfit> GetCWProfitSearchList(int PlatformTypeId, List<int> NickId, int DateTimeId, string YearStr, string MonthStr, int ProjectId)
        //{
        //    List<string> MonthStrList = new List<string>();

        //    if (MonthStr != "")
        //    { 
        //        if (MonthStr.IndexOf(",") > -1)
        //        {
        //            string[] OrderCodestr = MonthStr.Split(',');
        //            MonthStrList = new List<string>(OrderCodestr);
        //        }
        //        else if (MonthStr.IndexOf("，") > -1)
        //        { 
        //            string[] OrderCodestr = MonthStr.Split('，');
        //            MonthStrList = new List<string>(OrderCodestr);
        //        }
        //        else
        //        { 
        //            MonthStrList.Add(MonthStr);
        //        }
        //    }

        //    var query = from p in this._context.CWProfits
        //                join c in this._context.CWProjects on p.ProjectId equals c.Id
        //                where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
        //                && NickId.Contains(p.NickId.Value)
        //                && p.DateTimeId == DateTimeId
        //                && p.YearStr.Equals(YearStr)
        //                && MonthStrList.Contains(p.MonthStr)
        //                && p.IsEnable == false
        //                && (p.ProjectId == ProjectId || ProjectId == -1)
        //                select p;

        //    //var query = from c in this._context.CWProjects
        //    //            join p in this._context.CWProfits on c.Id equals p.ProjectId into JoinedCP
        //    //            from p in JoinedCP.DefaultIfEmpty()
        //    //            where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
        //    //            && NickId.Contains(p.NickId.Value)
        //    //            && p.DateTimeId == DateTimeId
        //    //            && p.YearStr.Equals(YearStr)
        //    //            && MonthStrList.Contains(p.MonthStr)
        //    //            && p.IsEnable == false
        //    //            && (c.Id == Id || Id == -1)
        //    //            && c.TableTypeId==486
        //    //            select new CWProfitMapping
        //    //             {
        //    //                 Id = c.Id,
        //    //                 ParentID=c.ParentID,
        //    //                 ProjectExplanation=c.ProjectExplanation,
        //    //                 TableTypeId=c.TableTypeId,
        //    //                 ProjectId = p.ProjectId,
        //    //                 CountMoney = p.CountMoney == null ? 0 : p.CountMoney.Value,
        //    //                 YearCountMoney = 0,
        //    //                 MonthProfit = 0,
        //    //                 YearProfit = 0
        //    //             };

        //    // return queryTrue.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();
        //    return query.ToList();

        //}


        /// <summary>
        /// get to CWProfit Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param> 
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CWProfit Page List</returns>
        public PagedList<CWProfit> SearchCWProfit(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CWProfits
                        orderby p.Id
                        select p;
            return new PagedList<CWProfit>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a CWProfit by Id
        /// </summary>
        /// <param name="id">CWProfit Id</param>
        /// <returns>CWProfit</returns>   
        public CWProfit GetCWProfitById(int id)
        {
            var query = from p in this._context.CWProfits
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete CWProfit by Id
        /// </summary>
        /// <param name="Id">CWProfit Id</param>
        public void DeleteCWProfit(int id)
        {
            var cwprofit = this.GetCWProfitById(id);
            if (cwprofit == null)
                return;

            if (!this._context.IsAttached(cwprofit))
                this._context.CWProfits.Attach(cwprofit);

            this._context.DeleteObject(cwprofit);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete CWProfit by Id
        /// </summary>
        /// <param name="Ids">CWProfit Id</param>
        public void BatchDeleteCWProfit(List<int> ids)
        {
            var query = from q in _context.CWProfits
                        where ids.Contains(q.Id)
                        select q;
            var cwprofits = query.ToList();
            foreach (var item in cwprofits)
            {
                if (!_context.IsAttached(item))
                    _context.CWProfits.Attach(item);

                _context.CWProfits.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion


        /// <summary>
        /// 定时执行 利润数据统计
        /// </summary>
        //public void TimingGetCWProfit()
        //{
        //    //返回率润表 项目名称
        //    var CWProjectList = IoC.Resolve<ICWProjectService>().GetCWProjectList(486);

        //    //返回所有店铺
        //    var NickList = IoC.Resolve<IXMNickService>().GetXMNickList();
        //    List<int> nickIdList = NickList.Select(p => p.nick_id).ToList();

        //    //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
        //    //var cbOrderStatusId = "1,2,3,4"; 
        //    DateTime dt1 = DateTime.Now;
        //    DateTime dt = Convert.ToDateTime(dt1.ToString("yyyy-MM-dd"));

        //    DateTime startMonth = dt.AddDays(1 - dt.Day); //本月月初  
        //    DateTime endMonth = startMonth.AddMonths(1).AddDays(-1); //本月月末   

        //    //DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初  
        //    //DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1); //本季度末  

        //    //DateTime startYear = new DateTime(dt.Year, 1, 1); //本年年初  
        //    //DateTime endYear = new DateTime(dt.Year, 12, 31); //本年年末  


        //    if (CWProjectList.Count > 0)
        //    {
        //        foreach (var item in CWProjectList)
        //        {
        //            #region 营业收入
        //            if (item.ProjectExplanation == "营业收入")
        //            {
        //                #region  创单时间:1 、 付款时间：2、发货时间：3、交易成功时间：4

        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    int OrderStatusId = i; //时间类型
        //                    var xmOrderInfoList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(Convert.ToInt32(-1), nickIdList, Convert.ToDateTime(startMonth), Convert.ToDateTime(endMonth), Convert.ToInt32(OrderStatusId), "");

        //                    // 根据平台、店铺 Group By
        //                    List<OrderInfoSalesDetails> xmOrderInfoListNew =
        //                          xmOrderInfoList.GroupBy(g => new { g.PlatformTypeId, g.NickID }).
        //                          Select(group => new OrderInfoSalesDetails()
        //                          {
        //                              PlatformTypeId = group.Key.PlatformTypeId,
        //                              NickID = group.Key.NickID,
        //                              PayPrice = group.Sum(l => l.PayPrice)
        //                          }).ToList();

        //                    if (xmOrderInfoListNew.Count > 0)
        //                    {
        //                        CWProfit cwProfit = null;
        //                        foreach (var item1 in xmOrderInfoListNew)
        //                        {
        //                            var CWProfitList = IoC.Resolve<ICWProfitService>().GetCWProfitList(item.Id, item1.PlatformTypeId.Value, item1.NickID.Value, OrderStatusId, startMonth.Year.ToString(), startMonth.Month.ToString());

        //                            if (CWProfitList.Count > 0)
        //                            {
        //                                cwProfit = CWProfitList[0];
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.PayPrice;


        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }

        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
        //                            }
        //                            else
        //                            {
        //                                cwProfit = new CWProfit();
        //                                cwProfit.ProjectId = item.Id;//项目Id
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.PayPrice;
        //                                cwProfit.IsEnable = false;

        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.CreateID = customer[0].CustomerID;
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.CreateDateTime = DateTime.Now;
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
        //                            }

        //                        }
        //                    }
        //                }

        //                #endregion

        //            }
        //            #endregion

        //            #region 进货成本 订单
        //            if (item.ProjectExplanation == "进货成本")
        //            {

        //                #region  创单时间:1 、 付款时间：2、发货时间：3、交易成功时间：4

        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    int OrderStatusId = i; //时间类型  
        //                    // 产品明细 
        //                    var OrderInfoSalesDetailsList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetOrderInfoSalesDetailsList(Convert.ToInt32(-1), nickIdList, Convert.ToDateTime(startMonth), Convert.ToDateTime(endMonth), Convert.ToInt32(OrderStatusId), "");

        //                    // 根据平台、店铺 Group By 出厂价
        //                    List<OrderInfoSalesDetails> xmOrderInfoListNew =
        //                          OrderInfoSalesDetailsList.GroupBy(g => new { g.PlatformTypeId, g.NickID }).
        //                          Select(group => new OrderInfoSalesDetails()
        //                          {
        //                              PlatformTypeId = group.Key.PlatformTypeId,
        //                              NickID = group.Key.NickID,
        //                              FactoryPrice = group.Sum(l => l.FactoryPrice)
        //                          }).ToList();

        //                    if (xmOrderInfoListNew.Count > 0)
        //                    {
        //                        CWProfit cwProfit = null;
        //                        foreach (var item1 in xmOrderInfoListNew)
        //                        {
        //                            var CWProfitList = IoC.Resolve<ICWProfitService>().GetCWProfitList(item.Id, item1.PlatformTypeId.Value, item1.NickID.Value, OrderStatusId, startMonth.Year.ToString(), startMonth.Month.ToString());

        //                            if (CWProfitList.Count > 0)
        //                            {
        //                                cwProfit = CWProfitList[0];
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.FactoryPrice;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
        //                            }
        //                            else
        //                            {
        //                                cwProfit = new CWProfit();
        //                                cwProfit.ProjectId = item.Id;//项目Id
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.FactoryPrice;
        //                                cwProfit.IsEnable = false;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.CreateID = customer[0].CustomerID;
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.CreateDateTime = DateTime.Now;
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
        //                            }

        //                        }
        //                    }


        //                }

        //                #endregion
        //            }
        //            #endregion

        //            #region 进货成本 赠品
        //            if (item.ProjectExplanation == "赠品成本")
        //            {
        //                #region  创单时间:1 、 付款时间：2、发货时间：3、交易成功时间：4

        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    int OrderStatusId = i; //时间类型  
        //                    // 赠品明细 
        //                    var XMOrderInfoAndPremiumsDetailsList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(-1), nickIdList, Convert.ToDateTime(startMonth), Convert.ToDateTime(endMonth), Convert.ToInt32(OrderStatusId));

        //                    // 根据平台、店铺 Group By 出厂价
        //                    List<OrderInfoSalesDetails> xmOrderInfoListNew =
        //                          XMOrderInfoAndPremiumsDetailsList.GroupBy(g => new { g.PlatformTypeId, g.NickID }).
        //                          Select(group => new OrderInfoSalesDetails()
        //                          {
        //                              PlatformTypeId = group.Key.PlatformTypeId,
        //                              NickID = group.Key.NickID,
        //                              FactoryPrice = group.Sum(l => l.FactoryPrice)
        //                          }).ToList();

        //                    if (xmOrderInfoListNew.Count > 0)
        //                    {
        //                        CWProfit cwProfit = null;
        //                        foreach (var item1 in xmOrderInfoListNew)
        //                        {
        //                            var CWProfitList = IoC.Resolve<ICWProfitService>().GetCWProfitList(item.Id, item1.PlatformTypeId.Value, item1.NickID.Value, OrderStatusId, startMonth.Year.ToString(), startMonth.Month.ToString());

        //                            if (CWProfitList.Count > 0)
        //                            {
        //                                cwProfit = CWProfitList[0];
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.FactoryPrice;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
        //                            }
        //                            else
        //                            {
        //                                cwProfit = new CWProfit();
        //                                cwProfit.ProjectId = item.Id;//项目Id
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.FactoryPrice;
        //                                cwProfit.IsEnable = false;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.CreateID = customer[0].CustomerID;
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.CreateDateTime = DateTime.Now;
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
        //                            }

        //                        }
        //                    }



        //                }
        //                #endregion
        //            }
        //            #endregion

        //            #region 刷拍成本
        //            if (item.ProjectExplanation == "刷拍成本")
        //            {
        //                #region  创单时间:1 、 付款时间：2、发货时间：3、交易成功时间：4

        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    int OrderStatusId = i; //时间类型

        //                    List<OrderInfoSalesDetails> XMScalpingDetailsList = IoC.Resolve<IXMScalpingService>().GetXMScalpingDetailsList(Convert.ToInt32(-1), nickIdList, Convert.ToDateTime(startMonth), Convert.ToDateTime(endMonth), Convert.ToInt32(OrderStatusId));

        //                    // 根据平台、店铺 Group By  佣金 （佣金包含空包费）
        //                    List<OrderInfoSalesDetails> xmOrderInfoListNew =
        //                          XMScalpingDetailsList.GroupBy(g => new { g.PlatformTypeId, g.NickID }).
        //                          Select(group => new OrderInfoSalesDetails()
        //                          {
        //                              PlatformTypeId = group.Key.PlatformTypeId,
        //                              NickID = group.Key.NickID,
        //                              Fee = group.Sum(l => l.Fee)
        //                          }).ToList();

        //                    if (xmOrderInfoListNew.Count > 0)
        //                    {
        //                        CWProfit cwProfit = null;
        //                        foreach (var item1 in xmOrderInfoListNew)
        //                        {
        //                            var CWProfitList = IoC.Resolve<ICWProfitService>().GetCWProfitList(item.Id, item1.PlatformTypeId.Value, item1.NickID.Value, OrderStatusId, startMonth.Year.ToString(), startMonth.Month.ToString());

        //                            if (CWProfitList.Count > 0)
        //                            {
        //                                cwProfit = CWProfitList[0];
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.Fee;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                // cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
        //                            }
        //                            else
        //                            {
        //                                cwProfit = new CWProfit();
        //                                cwProfit.ProjectId = item.Id;//项目Id
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.Fee;
        //                                cwProfit.IsEnable = false;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.CreateID = customer[0].CustomerID;
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.CreateDateTime = DateTime.Now;
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
        //                            }

        //                        }
        //                    }

        //                }
        //                #endregion
        //            }
        //            #endregion

        //            #region 返现成本
        //            if (item.ProjectExplanation == "返现成本")
        //            {
        //                #region  创单时间:1 、 付款时间：2、发货时间：3、交易成功时间：4

        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    int OrderStatusId = i; //时间类型

        //                    List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationDetailsList(Convert.ToInt32(-1), nickIdList, Convert.ToDateTime(startMonth), Convert.ToDateTime(endMonth), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(OrderStatusId));

        //                    // 根据平台、店铺 Group By  佣金 （佣金包含空包费）
        //                    List<OrderInfoSalesDetails> xmOrderInfoListNew =
        //                          XMCashBackApplicationDetailsList.GroupBy(g => new { g.PlatformTypeId, g.NickID }).
        //                          Select(group => new OrderInfoSalesDetails()
        //                          {
        //                              PlatformTypeId = group.Key.PlatformTypeId,
        //                              NickID = group.Key.NickID,
        //                              CashBackMoney = group.Sum(l => l.CashBackMoney)
        //                          }).ToList();

        //                    if (xmOrderInfoListNew.Count > 0)
        //                    {
        //                        CWProfit cwProfit = null;
        //                        foreach (var item1 in xmOrderInfoListNew)
        //                        {
        //                            var CWProfitList = IoC.Resolve<ICWProfitService>().GetCWProfitList(item.Id, item1.PlatformTypeId.Value, item1.NickID.Value, OrderStatusId, startMonth.Year.ToString(), startMonth.Month.ToString());

        //                            if (CWProfitList.Count > 0)
        //                            {
        //                                cwProfit = CWProfitList[0];
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.CashBackMoney;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
        //                            }
        //                            else
        //                            {
        //                                cwProfit = new CWProfit();
        //                                cwProfit.ProjectId = item.Id;//项目Id
        //                                cwProfit.DateTimeId = OrderStatusId;
        //                                cwProfit.NickId = item1.NickID.Value;
        //                                cwProfit.PlatformTypeId = item1.PlatformTypeId.Value;
        //                                cwProfit.YearStr = startMonth.Year.ToString();
        //                                cwProfit.MonthStr = startMonth.Month.ToString();
        //                                cwProfit.CountMoney = item1.CashBackMoney;
        //                                cwProfit.IsEnable = false;
        //                                if (HozestERPContext.Current.User != null)
        //                                {
        //                                    cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                    cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;

        //                                }
        //                                else
        //                                {
        //                                    string UserName = "admin";
        //                                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

        //                                    if (customer.Count > 0)
        //                                    {
        //                                        cwProfit.CreateID = customer[0].CustomerID;
        //                                        cwProfit.UpdateID = customer[0].CustomerID;
        //                                    }
        //                                }
        //                                // cwProfit.CreateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.CreateDateTime = DateTime.Now;
        //                                //cwProfit.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                                cwProfit.UpdateDateTime = DateTime.Now;
        //                                IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
        //                            }

        //                        }
        //                    }

        //                }
        //                #endregion
        //            }
        //            #endregion

        //        }
        //    }
        //}

        int[] Setting = { 64, 78, 79, 148, 107, 109, 110, 114, 115, 111, 98, 101, 100, 112, 113 };//一般项目定时统计的字段,去除广告费用86，添加推广费148
        int[] OperatingExpenses = { 111, 98, 101, 100, 112, 113, 148 };
        int[] BCSetting = { 63, 66, 93, 94, 95, 96, 97, 99, 103, 105, 98, 101, 100 };//B2B,B2C定时统计的字段

        public decimal GetFinancialCapitalFlow(int FinancialFieldID, string Begin, string End, int DepartmentType, int ProjectId)
        {
            decimal Value = 0;
            List<XMFinancialCapitalFlow> list = new List<XMFinancialCapitalFlow>();

            if (FinancialFieldID == 63 && DepartmentType == 6)//B2B收入
            {
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(Begin, End, DepartmentType, -1);
            }
            else if (FinancialFieldID == 75)//B2C收入
            {
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByReceivablesType(Begin, End, DepartmentType, 645);//B2C服务收入
            }
            else if (FinancialFieldID == 66 && DepartmentType == 6)//B2B支出
            {
                List<int?> BudgetTypeList = new List<int?> { 93, 94, 95, 96, 97, 99, 101, 100, 103, 105 };//营业费用FinancialFieldID
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTableB2BCByBudgetType(Begin, End, DepartmentType, BudgetTypeList);
            }
            else
            {
                list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByDataToTable(Begin, End, DepartmentType, ProjectId, FinancialFieldID);
            }

            if (list.Count > 0)
            {
                Value = (decimal)list.Sum(x => x.Amount);
            }
            return Value;
        }

        public decimal GetCWProfitValue(int FinancialFieldID, int year, int month, int cbOrderStatusId, List<int> nickIdList, int DepartmentType, int ProjectId)
        {
            List<int?> NickIdList = new List<int?>();
            foreach (int nick in nickIdList)
            {
                NickIdList.Add(nick);
            }
            DateTime min = DateTime.Parse(year + "-" + month + "-" + "01");
            DateTime max = DateTime.Parse(year + "-" + month + "-" + "01").AddMonths(1).AddSeconds(-1);
            decimal value = 0;
            //int Department = 0;
            //if (DepartmentType == 6)
            //{
            //    Department = 297;
            //}
            //else if (DepartmentType == 197)
            //{
            //    Department = 63;
            //}

            //营业收入
            if (FinancialFieldID == 64)
            {
                List<OrderInfoSalesDetails> CWProfitList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoList(-1, nickIdList, min, max, cbOrderStatusId, "");
                if (CWProfitList.Count > 0)
                {
                    value = CWProfitList.Sum(a => a.PayPrice == null ? 0 : a.PayPrice.Value);
                }
            }
            //进货成本
            if (FinancialFieldID == 78)
            {
                List<OrderInfoSalesDetails> CWJinList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetOrderInfoSalesDetailsList(-1, nickIdList, min, max, cbOrderStatusId);
                if (CWJinList.Count > 0)
                {
                    value = CWJinList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                }
            }

            //赠品成本
            if (FinancialFieldID == 79)
            {
                List<OrderInfoSalesDetails> CWZengList = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoAndPremiumsDetailsList(-1, nickIdList, min, max, cbOrderStatusId);
                if (CWZengList.Count > 0)
                {
                    value = CWZengList.Sum(a => a.FactoryPrice == null ? 0 : a.FactoryPrice.Value);
                }
            }

            //广告费用
            if (FinancialFieldID == 148)//86
            {
                //List<XMAdvertisingFee> CWFeeList = IoC.Resolve<IXMAdvertisingFeeService>().GetXMXMAdvertisingFeeByDetails(nickIdList, min, max);
                //if (CWFeeList.Count > 0)
                //{
                //    value = Math.Round(CWFeeList.Sum(a => a.Fee == null ? 0 : a.Fee.Value), 2);
                //}
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }

            //平台费用
            if (FinancialFieldID == 107)
            {
                List<OrderInfoSalesDetails> CWPlatformSpendingList = IoC.Resolve<IXMOrderInfoService>().GetCWPlatformSpendingSearchListSSS(-1, nickIdList, min, max, cbOrderStatusId);
                if (CWPlatformSpendingList.Count > 0)
                {
                    value = decimal.Round(CWPlatformSpendingList.Select(p => p.PayPrice.Value).Sum(), 2);
                }
            }
            //刷拍成本
            if (FinancialFieldID == 109)
            {
                List<OrderInfoSalesDetails> CWShuaList = IoC.Resolve<IXMScalpingService>().GetXMScalpingDetailsList(-1, nickIdList, min, max, cbOrderStatusId);
                if (CWShuaList.Count > 0)
                {
                    //刷拍佣金Fee 刷拍成本=刷拍佣金+扣点金额
                    value = Math.Round(CWShuaList.Sum(a => a.OrderPrice == null ? 0 : a.OrderPrice.Value), 2);
                }
            }
            //返现成本
            if (FinancialFieldID == 110)
            {
                List<OrderInfoSalesDetails> CWFanList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationDetailsList(-1, nickIdList, min, max, Convert.ToInt32(StatusEnum.AlreadyCashBack), cbOrderStatusId);
                if (CWFanList.Count > 0)
                {
                    value = CWFanList.Sum(a => a.CashBackMoney == null ? 0 : a.CashBackMoney.Value);
                }
            }
            //退款金额,退货成本
            if (FinancialFieldID == 114 || FinancialFieldID == 115)
            {
                List<XMApplication> xmConsultation = IoC.Resolve<IXMApplicationService>().GetXMConsultationListByData(-1, NickIdList, "", (DateTime?)min, (DateTime?)max, cbOrderStatusId);
                if (xmConsultation.Count > 0)
                {
                    if (FinancialFieldID == 114)
                    {
                        value = xmConsultation.Sum(a => a.Amount == null ? 0 : a.Amount.Value);
                    }
                    else if (FinancialFieldID == 115)
                    {
                        foreach (XMApplication info in xmConsultation)
                        {
                            var list = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeByAppID(info.ID, 0, 1, 2);
                            if (list != null && list.Count > 0)
                            {
                                foreach (XMApplicationExchange Info in list)
                                {
                                    if (Info.IsApplication == 2)
                                    {
                                        value += Info.FactoryPrice == null ? 0 : Info.FactoryPrice.Value;
                                    }
                                    else if (Info.IsApplication == 1)
                                    {
                                        value -= Info.FactoryPrice == null ? 0 : Info.FactoryPrice.Value;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //营业业绩额
            if (FinancialFieldID == 63 || FinancialFieldID == 75)
            {
                //List<XMBusinessDataAll> list = new List<XMBusinessDataAll>();
                //list = IoC.Resolve<IXMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(Department, min, max);
                //value = (decimal)list.Where(x => x.AmountType == 568).Sum(x => x.Amount);

                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //营业成本
            if (FinancialFieldID == 66)
            {
                //List<XMBusinessDataAll> list = new List<XMBusinessDataAll>();
                //list = IoC.Resolve<XMBusinessDataDetailService>().GetXMBusinessDataDetailListByDepID(Department, min, max);
                //value = (decimal)list.Where(x => x.AmountType == 567).Sum(x => x.Amount);

                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }

            //资金明细计算
            //运营部门销售奖金
            if (FinancialFieldID == 111)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //差旅费
            if (FinancialFieldID == 98)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //办公费用
            if (FinancialFieldID == 101)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //其他费用
            if (FinancialFieldID == 100)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //固定资产折旧
            if (FinancialFieldID == 112)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //摊销费用
            if (FinancialFieldID == 113)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }

            //工资
            if (FinancialFieldID == 93)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //社保
            if (FinancialFieldID == 94)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //奖金
            if (FinancialFieldID == 95)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //补贴
            if (FinancialFieldID == 96)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //销售激励
            if (FinancialFieldID == 97)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //福利费
            if (FinancialFieldID == 99)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //市场费
            if (FinancialFieldID == 103)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            //服务器租赁费
            if (FinancialFieldID == 105)
            {
                value = GetFinancialCapitalFlow(FinancialFieldID, min.ToString(), max.ToString(), DepartmentType, ProjectId);
            }
            return value;
        }

        /// <summary>
        /// 定时执行 利润数据统计
        /// </summary>
        public void TimingGetCWProfitByTwoMonth()
        {
            int cbOrderStatusId = 3;//发货时间
            int Year = DateTime.Now.Year;
            int[] OtherDepartmentType = { 6, 197, 507 };//B2B,B2C,综管
            List<int> nickIdList = new List<int>();
            int UserId = 0;
            if (HozestERPContext.Current.User != null)
            {
                UserId = HozestERPContext.Current.User.CustomerID;
            }
            else
            {
                string UserName = "admin";
                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);
                if (customer.Count > 0)
                {
                    UserId = customer[0].CustomerID;
                }
            }

            var ProjectList = IoC.Resolve<IXMProjectService>().GetXMProjectList();
            if (ProjectList.Count > 0)
            {
                foreach (XMProject project in ProjectList)
                {
                    var NickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(project.Id);
                    if (NickList.Count > 0)
                    {
                        foreach (XMNick nick in NickList)
                        {
                            nickIdList = new List<int>();
                            nickIdList.Add(nick.nick_id);
                            for (int i = 0; i < 3; i++)//同步3个月数据
                            {
                                int year = Year;
                                int month = DateTime.Now.Month - i;
                                if (month <= 0)
                                {
                                    year--;
                                    month += 12;
                                }
                                foreach (int FinancialFieldId in Setting)
                                {
                                    int Nick = nick.nick_id;
                                    decimal value = GetCWProfitValue(FinancialFieldId, year, month, cbOrderStatusId, nickIdList, 505, project.Id);
                                    if (OperatingExpenses.Contains(FinancialFieldId))
                                    {
                                        Nick = -1;
                                    }
                                    var cwProfit = IoC.Resolve<ICWProfitService>().GetCWProfitByData(FinancialFieldId, project.Id, Nick, -1, year.ToString(), month.ToString());
                                    if (cwProfit != null)
                                    {
                                        cwProfit.CountMoney = value;
                                        cwProfit.UpdateID = UserId;
                                        cwProfit.UpdateDateTime = DateTime.Now;
                                        IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
                                    }
                                    else
                                    {
                                        cwProfit = new CWProfit();
                                        cwProfit.FinancialFieldId = FinancialFieldId;
                                        cwProfit.ProjectId = project.Id;
                                        cwProfit.NickId = Nick;
                                        cwProfit.DepartmentTypeId = -1;
                                        cwProfit.YearStr = year.ToString();
                                        cwProfit.MonthStr = month.ToString();
                                        cwProfit.CountMoney = value;
                                        cwProfit.IsEnable = false;
                                        cwProfit.CreateID = UserId;
                                        cwProfit.CreateDateTime = DateTime.Now;
                                        cwProfit.UpdateID = UserId;
                                        cwProfit.UpdateDateTime = DateTime.Now;
                                        IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (int DepartmentType in OtherDepartmentType)
            {
                nickIdList = new List<int>();
                for (int i = 0; i < 3; i++)//同步3个月数据
                {
                    int year = Year;
                    int month = DateTime.Now.Month - i;
                    if (month <= 0)
                    {
                        year--;
                        month += 12;
                    }

                    DateTime Begin = DateTime.Parse(year + "/" + month + "/01");
                    DateTime End = Begin.AddMonths(1);

                    if (DepartmentType == 507)//综管
                    {
                        var IntegratedManagementList = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldByParentID(70).Where(x => x.IsManagementField == true);//营业费用
                        if (IntegratedManagementList.Count() > 0)
                        {
                            foreach (XMFinancialField item in IntegratedManagementList)
                            {
                                decimal value = (decimal)IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByBudgetType(Begin, End, DepartmentType, item.Id).Sum(x => x.Amount);
                                var cwProfit = IoC.Resolve<ICWProfitService>().GetCWProfitByData(item.Id, -1, -1, DepartmentType, year.ToString(), month.ToString());
                                if (cwProfit != null)
                                {
                                    cwProfit.CountMoney = value;
                                    cwProfit.UpdateID = UserId;
                                    cwProfit.UpdateDateTime = DateTime.Now;
                                    IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
                                }
                                else
                                {
                                    cwProfit = new CWProfit();
                                    cwProfit.FinancialFieldId = item.Id;
                                    cwProfit.ProjectId = -1;
                                    cwProfit.NickId = -1;
                                    cwProfit.DepartmentTypeId = DepartmentType;
                                    cwProfit.YearStr = year.ToString();
                                    cwProfit.MonthStr = month.ToString();
                                    cwProfit.CountMoney = value;
                                    cwProfit.IsEnable = false;
                                    cwProfit.CreateDateTime = DateTime.Now;
                                    cwProfit.CreateID = UserId;
                                    cwProfit.UpdateID = UserId;
                                    cwProfit.UpdateDateTime = DateTime.Now;
                                    IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (int FinancialFieldID in BCSetting)
                        {
                            int financialFieldID = FinancialFieldID;
                            if (DepartmentType == 197 && FinancialFieldID == 63)//B2C的营业业绩额字段
                            {
                                financialFieldID = 75;
                            }
                            decimal value = GetCWProfitValue(financialFieldID, year, month, cbOrderStatusId, nickIdList, DepartmentType, -1);
                            var cwProfit = IoC.Resolve<ICWProfitService>().GetCWProfitByData(financialFieldID, -1, -1, DepartmentType, year.ToString(), month.ToString());
                            if (cwProfit != null)
                            {
                                cwProfit.CountMoney = value;
                                cwProfit.UpdateID = UserId;
                                cwProfit.UpdateDateTime = DateTime.Now;
                                IoC.Resolve<ICWProfitService>().UpdateCWProfit(cwProfit);
                            }
                            else
                            {
                                cwProfit = new CWProfit();
                                cwProfit.FinancialFieldId = financialFieldID;
                                cwProfit.ProjectId = -1;
                                cwProfit.NickId = -1;
                                cwProfit.DepartmentTypeId = DepartmentType;
                                cwProfit.YearStr = year.ToString();
                                cwProfit.MonthStr = month.ToString();
                                cwProfit.CountMoney = value;
                                cwProfit.IsEnable = false;
                                cwProfit.CreateID = UserId;
                                cwProfit.CreateDateTime = DateTime.Now;
                                cwProfit.UpdateID = UserId;
                                cwProfit.UpdateDateTime = DateTime.Now;
                                IoC.Resolve<ICWProfitService>().InsertCWProfit(cwProfit);
                            }
                        }
                    }
                }
            }
        }
    }
}

