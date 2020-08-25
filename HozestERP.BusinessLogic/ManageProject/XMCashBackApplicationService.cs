
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-19 14:14:49
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMCashBackApplicationService : IXMCashBackApplicationService
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
        public XMCashBackApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMCashBackApplicationService成员
        /// <summary>
        /// Insert into XMCashBackApplication
        /// </summary>
        /// <param name="xmcashbackapplication">XMCashBackApplication</param>
        public void InsertXMCashBackApplication(XMCashBackApplication xmcashbackapplication)
        {
            if (xmcashbackapplication == null)
                return;

            if (!this._context.IsAttached(xmcashbackapplication))

                this._context.XMCashBackApplications.AddObject(xmcashbackapplication);

            this._context.SaveChanges();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="BuyerName">姓名</param>
        /// <param name="CashBackMoney">金额</param>
        /// <param name="BuyerAlipayNo">收款账号</param>
        /// <param name="ApplicationTypeId">申请类型：返现、赔付</param>
        /// <param name="Dmoney">返现设置—金额（小于不需要运营审核，大于需运营审核）</param>
        /// <param name="Finance">财务限额</param>
        public int InsertXMCashBackApplication(string OrderCode, string WantNo, string BuyerName, decimal CashBackMoney, string BuyerAlipayNo, int ApplicationTypeId, decimal Dmoney,decimal Finance)
        {
            int inst = 0;//返回操作结果
            List<XMCashBackApplication> CBAList = GetXMCashBackApplicationByOrderCode(OrderCode, ApplicationTypeId);
            List<XMCashBackApplication> CBAList2 = CBAList.Where(p => p.ManagerStatus.Value == 3 && p.CashBackStatus.Value == 0).ToList();
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
            if (CBAList2.Count > 0)
            {
                XMCashBackApplication xmcashbackapplicationNew = new XMCashBackApplication();

                xmcashbackapplicationNew = CBAList[0];

                xmcashbackapplicationNew.ApplicationTypeId = ApplicationTypeId;
                xmcashbackapplicationNew.OrderCode = OrderCode;
                xmcashbackapplicationNew.WantNo = WantNo;
                xmcashbackapplicationNew.BuyerName = BuyerName;
                //判断 返现金额 小于项目限额，财务限额，自动审核
                if(CashBackMoney<= Dmoney)
                {
                    xmcashbackapplicationNew.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                    xmcashbackapplicationNew.FinanceIsAudit = true;
                    xmcashbackapplicationNew.ManagerPeople = UserId;// HozestERPContext.Current.User.CustomerID;
                    xmcashbackapplicationNew.ManagerTime = DateTime.Now;
                }
                //返现金额 大于项目限额 小于 财务限额，项目未审核，财务审核
                else if (CashBackMoney> Dmoney&& CashBackMoney<= Finance)
                {
                    xmcashbackapplicationNew.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                    xmcashbackapplicationNew.FinanceIsAudit = true;
                }
                //返现金额 大于项目限额 大于 财务限额,都不审核
                else
                {
                    xmcashbackapplicationNew.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                    xmcashbackapplicationNew.FinanceIsAudit = false;
                }
                xmcashbackapplicationNew.CashBackMoney = CashBackMoney;
                xmcashbackapplicationNew.BuyerAlipayNo = BuyerAlipayNo;
                xmcashbackapplicationNew.UpdatorID = UserId;// HozestERPContext.Current.User.CustomerID;
                xmcashbackapplicationNew.UpdateTime = DateTime.Now;
                UpdateXMCashBackApplication(xmcashbackapplicationNew);
                inst = 1;


            }
            else if (CBAList.Count > 0)
            {

            }
            else
            {

                XMCashBackApplication xmcashbackapplication = new XMCashBackApplication();
                xmcashbackapplication.ApplicationTypeId = ApplicationTypeId;
                xmcashbackapplication.OrderCode = OrderCode;
                xmcashbackapplication.WantNo = WantNo;
                xmcashbackapplication.BuyerName = BuyerName;
                xmcashbackapplication.CashBackMoney = CashBackMoney;
                xmcashbackapplication.BuyerAlipayNo = BuyerAlipayNo;
                xmcashbackapplication.CashBackStatus = Convert.ToInt32(StatusEnum.NotCashBack);

                //判断 返现金额 小于项目限额，财务限额，自动审核
                if (CashBackMoney <= Dmoney)
                {
                    xmcashbackapplication.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                    xmcashbackapplication.FinanceIsAudit = true;
                    xmcashbackapplication.ManagerPeople = UserId;// HozestERPContext.Current.User.CustomerID;
                    xmcashbackapplication.ManagerTime = DateTime.Now;
                }
                //返现金额 大于项目限额 小于 财务限额，项目未审核，财务审核
                else if (CashBackMoney > Dmoney && CashBackMoney <= Finance)
                {
                    xmcashbackapplication.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                    xmcashbackapplication.FinanceIsAudit = true;
                }
                //返现金额 大于项目限额 大于 财务限额,都不审核
                else
                {
                    xmcashbackapplication.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                    xmcashbackapplication.FinanceIsAudit = false;
                }

                //判断 返现金额 大于 设置返现金额 需运营审核
                //if (CashBackMoney > Dmoney)
                //{
                //    xmcashbackapplication.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                //}
                //else
                //{
                //    xmcashbackapplication.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                //    xmcashbackapplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                //    xmcashbackapplication.ManagerTime = DateTime.Now;
                //}
                xmcashbackapplication.IsEnable = false;
                xmcashbackapplication.CreatorID = UserId;// HozestERPContext.Current.User.CustomerID;
                xmcashbackapplication.CreateTime = DateTime.Now;
                xmcashbackapplication.UpdatorID = UserId;// HozestERPContext.Current.User.CustomerID;
                xmcashbackapplication.UpdateTime = DateTime.Now;
                InsertXMCashBackApplication(xmcashbackapplication);
                inst = 1;
            }
            return inst;

        }
        /// <summary>
        /// Update into XMCashBackApplication
        /// </summary>
        /// <param name="xmcashbackapplication">XMCashBackApplication</param>
        public void UpdateXMCashBackApplication(XMCashBackApplication xmcashbackapplication)
        {
            if (xmcashbackapplication == null)
                return;

            if (this._context.IsAttached(xmcashbackapplication))
                this._context.XMCashBackApplications.Attach(xmcashbackapplication);

            this._context.SaveChanges();
        }

        /// <summary>
        /// 根据订单号、旺旺号、收款账号查询
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="BuyerAlipayNo">收款账号</param> 
        /// <param name="ManagerStatus">运营审核状态</param> 
        /// <param name="CashBackStatus">返现状态</param>
        /// <param name="ApplicationTypeId">申请状态</param>
        /// <returns></returns>
        public List<XMCashBackApplication> GetXMCashBackApplicationList(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, string BuyerAlipayNo, int ManagerStatus, int CashBackStatus, int ApplicationTypeId)
        {
            bool IsYMX = false;//ManagerStatus为3,4时，平台为亚马逊时，不检查订单状态。因为亚马逊同步不及时，客服无法发赠品
            if (PlatformId == 376 && (ManagerStatus == 3 || ManagerStatus == 4))
            {
                IsYMX = true;
            }

            int?[] nicklist = Array.ConvertAll<string, int?>(NickId.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] == -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }

            
            var query = from p in this._context.XMCashBackApplications
                        join s in this._context.XMOrderInfoes  //订单表
                        on p.OrderCode equals s.OrderCode
                        join z in this._context.XMNicks  //店铺
                        on s.NickID equals z.nick_id
                        join o in this._context.XMProjects //项目
                        on z.ProjectId equals o.Id
                        where p.OrderCode.Contains(OrderCode)
                        && p.WantNo.Contains(WantNo)
                        && p.BuyerAlipayNo.Contains(BuyerAlipayNo)
                        && (ManagerStatus == -1 || p.ManagerStatus.Value == ManagerStatus)
                        && (CashBackStatus == -1 || p.CashBackStatus.Value == CashBackStatus)
                        && (ApplicationTypeId == -1 || p.ApplicationTypeId.Value == ApplicationTypeId)
                        && p.IsEnable.Value == false
                        && s.IsEnable.Value == false
                        && (PlatformId == -1 || s.PlatformTypeId == PlatformId) //平台
                        && (nick_id == -1 || nicklist.Contains(s.NickID))  //店铺
                        && (ProjectId == -1 || z.ProjectId == ProjectId)  //项目
                                                                          //&& z.ProjectId != 3 && z.ProjectId != 5 //不选取（3.5卓氏.曲美）项目
                                                                          //&& z.nick_id != 6 && z.nick_id != 8 //不选取（6.8卓氏.曲美）店铺
                        && o.ProjectTypeId == 362 //自运营项目
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        orderby p.CreateTime descending
                        select p;

            //换个方法的尝试，实际并没有什么卵用
            //var query = 
            //            from p in (from s in _context.XMOrderInfoes  //订单表
            //                       join z in this._context.XMNicks  //店铺
            //                       on s.NickID equals z.nick_id
            //                       join o in this._context.XMProjects //项目
            //                       on z.ProjectId equals o.Id
            //                       where (PlatformId == -1 || s.PlatformTypeId == PlatformId)//平台
            //                       && (nick_id == -1 || nicklist.Contains(s.NickID))  //店铺
            //                       && (ProjectId == -1 || z.ProjectId == ProjectId)  //项目
            //                       && o.ProjectTypeId == 362 //自运营项目
            //                       && s.IsEnable.Value == false
            //                       select new
            //                       {
            //                           OrderCode = s.OrderCode,
            //                           IsEnable = s.IsEnable,
            //                           PlatformTypeId = s.PlatformTypeId,
            //                           NickID = s.NickID,
            //                           ProjectId = z.ProjectId,
            //                           ProjectTypeId = o.ProjectTypeId
            //                       }
            //            ) 
            //            join m in this._context.XMCashBackApplications on p.OrderCode equals m.OrderCode into temp
            //            from ptemp in temp.DefaultIfEmpty()
            //            where ptemp.OrderCode.Contains(OrderCode)
            //            && ptemp.WantNo.Contains(WantNo)
            //            && ptemp.BuyerAlipayNo.Contains(BuyerAlipayNo)
            //            && (ManagerStatus == -1 || ptemp.ManagerStatus.Value == ManagerStatus)
            //            && (CashBackStatus == -1 || ptemp.CashBackStatus.Value == CashBackStatus)
            //            && (ApplicationTypeId == -1 || ptemp.ApplicationTypeId.Value == ApplicationTypeId)
            //            && ptemp.IsEnable.Value == false
            //            && (ptemp.CreateTime >= min || !min.HasValue) && (!max.HasValue || ptemp.CreateTime <= max) //创建时间范围
            //            orderby ptemp.CreateTime descending
            //            select ptemp;

            //添加没有订单情况的记录
            //query = query.Union(from p in _context.XMCashBackApplications where string.IsNullOrEmpty(p.OrderCode) select p);

            if (ManagerStatus == 3 && !IsYMX)
            {
                query = from x in query
                        join t in this._context.XMOrderInfoes  //订单表
                        on x.OrderCode equals t.OrderCode
                        where t.OrderStatus == "TRADE_FINISHED" || t.OrderStatus == "DS_DEAL_END_NORMAL" || t.OrderStatus == "FINISHED_L"
                        || t.OrderStatus == "STATUS_25" || t.OrderStatus == "ORDER_FINISH" || t.OrderStatus == "30"
                        orderby x.CreateTime descending
                        select x;
            }
            return query.ToList();
        }

        public List<XMCashBackApplication> GetXMCashBackApplicationListNoOrder(DateTime? min, DateTime? max, string NickId, int ProjectId, string OrderCode, string WantNo, string BuyerAlipayNo, int ManagerStatus, int CashBackStatus, int ApplicationTypeId)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(NickId.Split(','), delegate (string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] == -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }

            IQueryable<XMCashBackApplication> query = null;
            if (string.IsNullOrEmpty(OrderCode))
            {
                 query = from p in this._context.XMCashBackApplications
                            join z in this._context.XMNicks  //店铺
                            on p.NickID equals z.nick_id
                            join o in this._context.XMProjects //项目
                            on z.ProjectId equals o.Id
                            where p.OrderCode.StartsWith("NoOrder")
                            && p.WantNo.Contains(WantNo)
                            && p.BuyerAlipayNo.Contains(BuyerAlipayNo)
                            && (ManagerStatus == -1 || p.ManagerStatus.Value == ManagerStatus)
                            && (CashBackStatus == -1 || p.CashBackStatus.Value == CashBackStatus)
                            && (ApplicationTypeId == -1 || p.ApplicationTypeId.Value == ApplicationTypeId)
                            && p.IsEnable.Value == false
                            && (nick_id == -1 || nicklist.Contains(p.NickID))  //店铺
                            && (ProjectId == -1 || z.ProjectId == ProjectId)  //项目
                                                                              //&& z.ProjectId != 3 && z.ProjectId != 5 //不选取（3.5卓氏.曲美）项目
                                                                              //&& z.nick_id != 6 && z.nick_id != 8 //不选取（6.8卓氏.曲美）店铺
                            && o.ProjectTypeId == 362 //自运营项目
                            && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                            orderby p.CreateTime descending
                            select p;
            }
            else
            {
                query = from p in this._context.XMCashBackApplications
                        join z in this._context.XMNicks  //店铺
                        on p.NickID equals z.nick_id
                        join o in this._context.XMProjects //项目
                        on z.ProjectId equals o.Id
                        where p.OrderCode.Contains(OrderCode)
                        && p.WantNo.Contains(WantNo)
                        && p.BuyerAlipayNo.Contains(BuyerAlipayNo)
                        && (ManagerStatus == -1 || p.ManagerStatus.Value == ManagerStatus)
                        && (CashBackStatus == -1 || p.CashBackStatus.Value == CashBackStatus)
                        && (ApplicationTypeId == -1 || p.ApplicationTypeId.Value == ApplicationTypeId)
                        && p.IsEnable.Value == false
                        && (nick_id == -1 || nicklist.Contains(p.NickID))  //店铺
                        && (ProjectId == -1 || z.ProjectId == ProjectId)  //项目
                                                                          //&& z.ProjectId != 3 && z.ProjectId != 5 //不选取（3.5卓氏.曲美）项目
                                                                          //&& z.nick_id != 6 && z.nick_id != 8 //不选取（6.8卓氏.曲美）店铺
                        && o.ProjectTypeId == 362 //自运营项目
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        orderby p.CreateTime descending
                        select p;
            }

            return query.ToList();
        }

        public List<XMCashBackApplication> GetXMCashBackApplicationListByQuestionDetailID(string QuestionDetailID)
        {
            var query = from q in _context.XMCashBackApplications
                        where q.IsEnable == false
                        && q.QuestionDetailID == QuestionDetailID
                        select q;
            return query.ToList();
        }

        /// <summary>
        ///  返现明细：根据订单付款时间 、返现状态：已返现
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickIdList">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">订单付款开始时间</param>
        /// <param name="OrderInfoModifiedEnd">订单付款结束时间</param>
        /// <param name="CashBackStatus">返现状态：已返现</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> GetXMCashBackApplicationDetailsList(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int CashBackStatus, int OrderStatusId)
        {

            IQueryable<OrderInfoSalesDetails> query = null;

            //左链接
            query = from a in this._context.XMCashBackApplications
                    join b in this._context.XMOrderInfoes
                    on a.OrderCode equals b.OrderCode into JoinedAB
                    from b in JoinedAB.DefaultIfEmpty()

                    join e in this._context.XMNicks on b.NickID equals e.nick_id
                    into eJoin
                    from eInfo in eJoin.DefaultIfEmpty()

                    join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                    into fJoin
                    from fInfo in fJoin.DefaultIfEmpty()

                    where ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null) || (a.CreateTime >= OrderInfoModifiedStart && a.CreateTime < OrderInfoModifiedEnd))
                    && a.CashBackStatus.Value == CashBackStatus
                    && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                    && NickIdList.Contains(b.NickID.Value)
                    && a.IsEnable.Value == false
                    && b.IsEnable.Value == false
                    && b.FinancialAudit == true
                    && eInfo.isEnable == true
                    && fInfo.IsEnable == true
                    orderby a.CreateTime descending
                    select new OrderInfoSalesDetails
                    {
                        ID = b.ID,
                        PlatformTypeId = b.PlatformTypeId,
                        NickID = b.NickID,
                        OrderCode = b.OrderCode,
                        OrderInfoCreateDate = b.OrderInfoCreateDate,
                        PayDate = b.PayDate,
                        DeliveryTime = b.DeliveryTime,
                        CompletionTime = b.CompletionTime,
                        XMCashBackApplicationWantNo = a.WantNo,
                        BuyerName = a.BuyerName,
                        CashBackMoney = a.CashBackMoney,
                        BuyerAlipayNo = a.BuyerAlipayNo,
                        ProjectName = fInfo.ProjectName,
                        NickName = eInfo.nick,
                        MarkDate = a.CreateTime
                    };
            return query.ToList();
        }

        /// <summary>
        /// 获取返现成本
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="NickIdList"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <param name="CashBackStatus"></param>
        /// <returns></returns>
        public decimal getCashBackCost(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int CashBackStatus)
        {
            var query= from a in this._context.XMCashBackApplications
                       join b in this._context.XMOrderInfoes
                       on a.OrderCode equals b.OrderCode into JoinedAB
                       from b in JoinedAB.DefaultIfEmpty()

                       join e in this._context.XMNicks on b.NickID equals e.nick_id
                       into eJoin
                       from eInfo in eJoin.DefaultIfEmpty()

                       join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                       into fJoin
                       from fInfo in fJoin.DefaultIfEmpty()

                       where ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null) || (a.CreateTime >= OrderInfoModifiedStart && a.CreateTime < OrderInfoModifiedEnd))
                       && a.CashBackStatus.Value == CashBackStatus
                       && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                       && NickIdList.Contains(b.NickID.Value)
                       && a.IsEnable.Value == false
                       && b.IsEnable.Value == false
                       && b.FinancialAudit == true
                       && eInfo.isEnable == true
                       && fInfo.IsEnable == true
                       orderby a.CreateTime descending
                       select new OrderInfoSalesDetails
                       {
                           ID = b.ID,
                           PlatformTypeId = b.PlatformTypeId,
                           NickID = b.NickID,
                           OrderCode = b.OrderCode,
                           OrderInfoCreateDate = b.OrderInfoCreateDate,
                           PayDate = b.PayDate,
                           DeliveryTime = b.DeliveryTime,
                           CompletionTime = b.CompletionTime,
                           XMCashBackApplicationWantNo = a.WantNo,
                           BuyerName = a.BuyerName,
                           CashBackMoney = a.CashBackMoney,
                           BuyerAlipayNo = a.BuyerAlipayNo,
                           ProjectName = fInfo.ProjectName,
                           NickName = eInfo.nick,
                           MarkDate = a.CreateTime
                       };

            decimal? cost = query.Select(a => a.CashBackMoney).Sum();

            #region 无订单
            var query1 = from p in this._context.XMCashBackApplications
                         join m in _context.XMNicks on p.NickID equals m.nick_id into temp
                         from pm in temp.DefaultIfEmpty()
                         where p.OrderCode.StartsWith("NoOrder") && pm.isEnable && (PlatformTypeId == -1 || pm.PlatformTypeId.Value == PlatformTypeId)
                         && NickIdList.Contains((int)p.NickID)
                         select p;

            decimal? cost1 = query1.Select(a => a.CashBackMoney).Sum();

            #endregion

            decimal total = (cost == null ? 0 : (decimal)cost) + (cost1 == null ? 0 : (decimal)cost1);

            return total;
        }


        /// <summary>
        /// 返现明细：
        /// </summary>
        /// <param name="OrderInfoListNew">订单集合</param>
        /// <param name="CashBackStatus">返现状态</param>
        /// <returns></returns>
        //public List<XMCashBackApplication> GetXMCashBackApplicationDetailsList(List<OrderInfoSalesDetails> OrderInfoListNew, int CashBackStatus)
        //{

        //    var query = from a in this._context.XMCashBackApplications
        //                join b in OrderInfoListNew
        //                 on a.OrderCode equals b.OrderCode into JoinedAB
        //                from b in JoinedAB.DefaultIfEmpty()
        //                where a.CashBackStatus.Value == CashBackStatus
        //                && a.IsEnable.Value == false
        //                select a;
        //    return query.ToList();
        //}

        /// <summary>
        /// get to XMCashBackApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCashBackApplication Page List</returns>
        public PagedList<XMCashBackApplication> SearchXMCashBackApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCashBackApplications
                        orderby p.Id
                        select p;
            return new PagedList<XMCashBackApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public List<XMCashBackApplication> GetXMCashBackApplicationByOrderCode(string OrderCode, int ApplicationTypeId)
        {

            var query = from p in this._context.XMCashBackApplications
                        where p.OrderCode.Equals(OrderCode)
                        && (p.ApplicationTypeId == ApplicationTypeId || ApplicationTypeId == -1)
                        && p.IsEnable.Value == false
                        //&& p.CashBackStatus.Value == 0 && p.ManagerStatus == 3
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// get a XMCashBackApplication by Id
        /// </summary>
        /// <param name="id">XMCashBackApplication Id</param>
        /// <returns>XMCashBackApplication</returns>   
        public XMCashBackApplication GetXMCashBackApplicationById(int id)
        {
            var query = from p in this._context.XMCashBackApplications
                        where p.Id.Equals(id)
                        && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        }


        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        public List<XMCashBackApplication> GetXMCashBackApplicationByIdList(List<int> Id)
        {

            var query = from p in this._context.XMCashBackApplications
                        where Id.Contains(p.Id)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// delete XMCashBackApplication by Id
        /// </summary>
        /// <param name="Id">XMCashBackApplication Id</param>
        public void DeleteXMCashBackApplication(int id)
        {
            var xmcashbackapplication = this.GetXMCashBackApplicationById(id);
            if (xmcashbackapplication == null)
                return;

            if (!this._context.IsAttached(xmcashbackapplication))
                this._context.XMCashBackApplications.Attach(xmcashbackapplication);

            this._context.DeleteObject(xmcashbackapplication);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMCashBackApplication by Id
        /// </summary>
        /// <param name="Ids">XMCashBackApplication Id</param>
        public void BatchDeleteXMCashBackApplication(List<int> ids)
        {
            var query = from q in _context.XMCashBackApplications
                        where ids.Contains(q.Id)
                        select q;
            var xmcashbackapplications = query.ToList();
            foreach (var item in xmcashbackapplications)
            {
                if (!_context.IsAttached(item))
                    _context.XMCashBackApplications.Attach(item);

                _context.XMCashBackApplications.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
