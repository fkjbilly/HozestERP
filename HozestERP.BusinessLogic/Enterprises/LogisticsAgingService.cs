
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-19 09:32:39
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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class LogisticsAgingService : ILogisticsAgingService
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
        public LogisticsAgingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region ILogisticsAgingService成员
        /// <summary>
        /// Insert into LogisticsAging
        /// </summary>
        /// <param name="logisticsaging">LogisticsAging</param>
        public void InsertLogisticsAging(LogisticsAging logisticsaging)
        {
            if (logisticsaging == null)
                return;

            if (!this._context.IsAttached(logisticsaging))

                this._context.LogisticsAgings.AddObject(logisticsaging);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into LogisticsAging
        /// </summary>
        /// <param name="logisticsaging">LogisticsAging</param>
        public void UpdateLogisticsAging(LogisticsAging logisticsaging)
        {
            if (logisticsaging == null)
                return;

            if (this._context.IsAttached(logisticsaging))
                this._context.LogisticsAgings.Attach(logisticsaging);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to LogisticsAging list
        /// </summary>
        public List<LogisticsAging> GetLogisticsAgingList()
        {
            var query = from p in this._context.LogisticsAgings
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to LogisticsAging list
        /// </summary>
        public List<LogisticsAging> GetLogisticsAgingListByParam(string DepartureCity, string DestinationCity, string Pathway)
        {
            var query = from p in this._context.LogisticsAgings
                        where p.IsEnabled == false
                        && p.DepartureCity.Contains(DepartureCity)
                        && p.DestinationCity.Contains(DestinationCity)
                        && (Pathway == "-1" || (Pathway != "-1" && p.Pathway.Contains(Pathway)))
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to LogisticsAging Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>LogisticsAging Page List</returns>
        public PagedList<LogisticsAging> SearchLogisticsAging(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.LogisticsAgings
                        orderby p.ID
                        select p;
            return new PagedList<LogisticsAging>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a LogisticsAging by ID
        /// </summary>
        /// <param name="id">LogisticsAging ID</param>
        /// <returns>LogisticsAging</returns>   
        public LogisticsAging GetLogisticsAgingByID(int id)
        {
            var query = from p in this._context.LogisticsAgings
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete LogisticsAging by ID
        /// </summary>
        /// <param name="ID">LogisticsAging ID</param>
        public void DeleteLogisticsAging(int id)
        {
            var logisticsaging = this.GetLogisticsAgingByID(id);
            if (logisticsaging == null)
                return;

            if (!this._context.IsAttached(logisticsaging))
                this._context.LogisticsAgings.Attach(logisticsaging);

            this._context.DeleteObject(logisticsaging);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete LogisticsAging by ID
        /// </summary>
        /// <param name="IDs">LogisticsAging ID</param>
        public void BatchDeleteLogisticsAging(List<int> ids)
        {
            var query = from q in _context.LogisticsAgings
                        where ids.Contains(q.ID)
                        select q;
            var logisticsagings = query.ToList();
            foreach (var item in logisticsagings)
            {
                if (!_context.IsAttached(item))
                    _context.LogisticsAgings.Attach(item);

                _context.LogisticsAgings.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        public void TimingGetLogisticsAging()
        {
            int UserID = 0;
            if (HozestERPContext.Current.User != null)
            {
                UserID = HozestERPContext.Current.User.CustomerID;
            }
            else
            {
                string UserName = "admin";
                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                if (customer.Count > 0)
                {
                    UserID = customer[0].CustomerID;
                }
            }

            int days = 0;
            var Days = IoC.Resolve<ISettingManager>().GetSettingByName("Logistics.Aging.NumberOfDays");
            if (Days != null)
            {
                if (int.TryParse(Days.Value.Trim(), out days) && Days.Value.Trim() != "0")
                {
                    days = int.Parse(Days.Value.Trim());
                    DateTime End = DateTime.Now;
                    DateTime Begin = End.AddMonths(-6);
                    var OrderIDList = IoC.Resolve<IXMOrderInfoService>().GetVPHXMOrderInfoListByDateTime(Begin, End);
                    if (OrderIDList != null && OrderIDList.Count > 0)
                    {
                        foreach (int ID in OrderIDList)
                        {
                            var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(ID);
                            var LogisticsInfoList = IoC.Resolve<IXMLogisticsInfoService>().GetXMLogisticsInfoListByOrderInfoID(ID).OrderBy(x => x.CreateDate).ToList();
                            if (OrderInfo != null)
                            {
                                var LogisticsAgingList = IoC.Resolve<ILogisticsAgingService>().GetLogisticsAgingListByParam("", OrderInfo.City.Replace("市", "").Replace("区", ""), "-1");
                                if (LogisticsAgingList.Count > 0)
                                {
                                    int Total = 0;
                                    int TotalDay = 0;
                                    LogisticsAging LogisticsAgingInfo = LogisticsAgingList[0];
                                    TimeSpan ts1 = new TimeSpan(((DateTime)OrderInfo.DeliveryTime).Ticks);
                                    TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                                    TimeSpan ts = ts1.Subtract(ts2).Duration();//显示时间
                                    TotalDay += ts.Days;
                                    Total = GetDue(TotalDay, LogisticsAgingInfo, days);

                                    if (LogisticsInfoList.Count < Total)
                                    {
                                        List<string> list = GetFictitiousLogisticsInfoList((DateTime)OrderInfo.DeliveryTime, days, LogisticsAgingInfo);
                                        if (list.Count >= Total)
                                        {
                                            for (int i = LogisticsInfoList.Count; i < Total; i++)
                                            {
                                                XMLogisticsInfo Info = new XMLogisticsInfo();
                                                Info.OrderInfoID = ID;
                                                Info.LogisticsDate = DateTime.Now;
                                                if (LogisticsInfoList.Count > 0)
                                                {
                                                    Info.LogisticsNumber = LogisticsInfoList[0].LogisticsNumber;
                                                    Info.LogisticsCompany = LogisticsInfoList[0].LogisticsCompany;
                                                }
                                                else
                                                {
                                                    Info.LogisticsNumber = "";
                                                    Info.LogisticsCompany = "";
                                                }
                                                Info.Note = list[i];
                                                Info.IsExport = false;
                                                Info.IsEnable = false;
                                                Info.CreateID = UserID;
                                                Info.CreateDate = DateTime.Now;
                                                Info.UpdateID = UserID;
                                                Info.UpdateTime = DateTime.Now;
                                                IoC.Resolve<IXMLogisticsInfoService>().InsertXMLogisticsInfo(Info);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<string> GetFictitiousLogisticsInfoList(DateTime DeliveryTime, int days, LogisticsAging LogisticsAgingInfo)
        {
            DateTime LogisticsDate = DeliveryTime;
            List<string> list = new List<string>();
            string Str = LogisticsAgingInfo.DepartureCity + "仓拣单出库，物流开始承运。";
            if (LogisticsAgingInfo.Pathway != "")
            {
                int Count1 = GetMod((int)LogisticsAgingInfo.PathwayDate, days);
                for (int i = 0; i < Count1; i++)
                {
                    Str += "物品正在发往" + LogisticsAgingInfo.Pathway + "中转站，等待转运。";
                    //XMLogisticsInfo info = new XMLogisticsInfo();
                    //info.Note = Str;
                    //LogisticsDate = LogisticsDate.AddDays(i * days);
                    //info.LogisticsDate = LogisticsDate;
                    list.Add(Str);
                    Str = "";
                }
                Str = "物品已抵达" + LogisticsAgingInfo.Pathway + "中转站。物品从" + LogisticsAgingInfo.Pathway + "中转站发出。";
            }

            int Count2 = GetMod((int)LogisticsAgingInfo.DestinationDate, days);
            for (int i = 0; i < Count2; i++)
            {
                Str += "物品正在发往" + LogisticsAgingInfo.DestinationCity + "城市途中。";
                list.Add(Str);
                Str = "";
            }
            Str = "物品已经到达" + LogisticsAgingInfo.DestinationCity + "，等待派件员取货。物品已经取走，正在派送。签收人签收，草签。";
            list.Add(Str);
            return list;
        }

        public int GetMod(int a, int b)
        {
            int c = a % b;
            int d = a / b;
            if (c != 0)
            {
                d++;
            }
            return d;
        }

        public int GetDue(int total, LogisticsAging info, int days)//应有记录条数
        {
            int count = 0;
            if (total == 0)
            {
                count++;
                return count;
            }
            if (info.Pathway != "")
            {
                if (total >= info.PathwayDate)
                {
                    if (info.PathwayDate > days)
                    {
                        count += GetMod((int)info.PathwayDate, days);
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    if (total > days)
                    {
                        count += GetMod(total, days);
                    }
                    else if (total == days)
                    {
                        count += GetMod(total, days) + 1;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            else
            {
                count++;//发货后，自动生成的第一条记录
            }

            int result = (int)(info.PathwayDate == null ? 0 : info.PathwayDate);
            if (total >= result)
            {
                total = total - result;
                if (total >= info.DestinationDate)
                {
                    if (info.DestinationDate > days)
                    {
                        count += GetMod((int)info.DestinationDate, days);
                        int mod = (int)info.DestinationDate % days;//剩余天数，是否正好整除
                        if (mod == 0)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    if (total > days)
                    {
                        count += GetMod(total, days);
                    }
                    else if (total == days)
                    {
                        count += GetMod(total, days) + 1;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        #endregion
    }
}
