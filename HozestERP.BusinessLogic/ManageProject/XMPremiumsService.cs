
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-02-10 09:55:50
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
    public partial class XMPremiumsService : IXMPremiumsService
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
        public XMPremiumsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPremiumsService成员
        /// <summary>
        /// Insert into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
        public void InsertXMPremiums(XMPremiums xmpremiums)
        {
            if (xmpremiums == null)
                return;

            if (!this._context.IsAttached(xmpremiums))

                this._context.XMPremiums.AddObject(xmpremiums);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Insert into XMPremiums
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantId">旺旺号</param>
        /// <param name="ActivityExplanation">活动说明</param>
        public int InsertXMPremiums(string OrderCode, string WantId, int PremiumsTypeId, string ActivityExplanation, bool paramIsEvaluation, decimal price, int platformTypeID, int nickID)
        {
            var XMDeductionSetUpService = IoC.Resolve<IXMDeductionSetUpService>();
            var XMPremiumsDetailsService = IoC.Resolve<IXMPremiumsDetailsService>();
            var XMNickService = IoC.Resolve<IXMNickService>();
            XMDeductionSetUp entity = null;
            List<XMPremiums> CBAList = GetXMPremiumsListByOrderCode(OrderCode, PremiumsTypeId);

            XMPremiums xMPremiums = new XMPremiums();
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
            if (CBAList.Count > 0)
            {
                xMPremiums = CBAList[0];

                xMPremiums.OrderCode = OrderCode;
                xMPremiums.WantId = WantId;
                xMPremiums.ActivityExplanation = ActivityExplanation;
                xMPremiums.UpdatorID = UserId;//HozestERPContext.Current.User.CustomerID;
                xMPremiums.UpdateTime = DateTime.Now;
                xMPremiums.IsEvaluation = paramIsEvaluation;
                UpdateXMPremiums(xMPremiums);


            }
            else
            {
                //财务未审核
                bool FinanceIsAudit = false;
                //项目未审核
                int ManagerStatus = 3;

                var xmNick = XMNickService.GetXMNickByID(nickID);
                if (xmNick != null)
                {
                    entity = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId((int)xmNick.ProjectId, 476, platformTypeID);
                }

                if (entity != null&& price!=0)
                {
                    //根据项目限额，平台限额，自动设置审核进度
                    if (price <= entity.Deduction)
                    {
                        FinanceIsAudit = true;
                        //项目审核
                        ManagerStatus = 4;
                    }
                    else if (price > entity.Deduction && price <= entity.Finance)
                    {
                        FinanceIsAudit = true;
                    }
                }
                else if(entity==null&& price != 0)
                {
                    //通用
                    var XMDeductionSetUpUsually = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId((int)xmNick.ProjectId, 476, 508);
                    if(XMDeductionSetUpUsually!=null)
                    {
                        //根据项目限额，平台限额，自动设置审核进度
                        if (price <= XMDeductionSetUpUsually.Deduction)
                        {
                            FinanceIsAudit = true;
                            //项目审核
                            ManagerStatus = 4;
                        }
                        else if (price > XMDeductionSetUpUsually.Deduction && price <= XMDeductionSetUpUsually.Finance)
                        {
                            FinanceIsAudit = true;
                        }
                    }
                }

                xMPremiums.OrderCode = OrderCode;
                xMPremiums.WantId = WantId;
                xMPremiums.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                xMPremiums.PremiumsTypeId = PremiumsTypeId;//赠品状态
                xMPremiums.ActivityExplanation = ActivityExplanation;
                xMPremiums.FinanceIsAudit = FinanceIsAudit;
                xMPremiums.ManagerStatus = ManagerStatus;
                //xMPremiums.ManagerStatus = Convert.ToInt32(StatusEnum.NotCheck);
                //xMPremiums.DirectorStatus = Convert.ToInt32(StatusEnum.NotCheck);
                xMPremiums.IsSingleRow = false;
                xMPremiums.IsEnable = false;
                xMPremiums.IsEvaluation = paramIsEvaluation;
                xMPremiums.CreatorID = UserId;// HozestERPContext.Current.User.CustomerID;
                xMPremiums.CreateTime = DateTime.Now;
                xMPremiums.UpdatorID = UserId;// HozestERPContext.Current.User.CustomerID;
                xMPremiums.UpdateTime = DateTime.Now;
                InsertXMPremiums(xMPremiums);
            }
            return xMPremiums.Id;
        }

        /// <summary>
        /// Update into XMPremiums
        /// </summary>
        /// <param name="xmpremiums">XMPremiums</param>
        public void UpdateXMPremiums(XMPremiums xmpremiums)
        {
            if (xmpremiums == null)
                return;

            if (this._context.IsAttached(xmpremiums))
                this._context.XMPremiums.Attach(xmpremiums);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPremiums list
        /// </summary>
        public List<XMPremiums> GetXMPremiumsList()
        {
            var query = from p in this._context.XMPremiums
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public XMPremiums GetXMPremiumsListByQuestionDetailID(string QuestionDetailID)
        {
            var query = from m in _context.XMPremiums
                        where m.IsEnable == false
                        && m.QuestionDetailID == QuestionDetailID
                        select m;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据订单号查询、类型查询
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<XMPremiums> GetXMPremiumsListByOrderCode(string OrderCode, int PremiumsTypeId)
        {
            var query = from p in this._context.XMPremiums
                        where p.OrderCode.Equals(OrderCode)
                        && (p.PremiumsTypeId == PremiumsTypeId || PremiumsTypeId == -1)
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据订单号查询、类型查询、商品编码
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<XMPremiums> GetXMPremiumsListByOrderCodeproductcode(string OrderCode, int PremiumsTypeId, string productcode)
        {
            var query = from p in this._context.XMPremiums
                        join pd in this._context.XMPremiumsDetails on p.Id equals pd.PremiumsId
                        where p.OrderCode.Equals(OrderCode)
                        && (p.PremiumsTypeId == PremiumsTypeId || PremiumsTypeId == -1)
                        && p.IsEnable == false
                        && pd.PlatformMerchantCode.Equals(productcode)
                        select p;
            return query.ToList();
        }

        public List<XMPremiums> GetXMPremiumsListByCreateTime(DateTime Begin)
        {
            var query = from p in this._context.XMPremiums
                        where p.IsEnable == false
                        && p.CreateTime != null
                        && p.CreateTime >= Begin
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据条件查询 赠品信息
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="PremiumsStatus">赠品状态</param> 
        /// <param name="ManagerStatus">运营审核</param>
        /// <param name="IsSingleRow">是否排单</param>
        /// <param name="PremiumsTypeId">//申请类型：赠品:11、赔付：10</param>
        /// <returns></returns>
        public List<XMPremiums> GetXMPremiumsList(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(NickId.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMPremiums
                        join s in this._context.XMOrderInfoes  //订单表
                        on p.OrderCode equals s.OrderCode
                        join z in this._context.XMNicks  //店铺
                        on s.NickID equals z.nick_id
                        join o in this._context.XMProjects //项目
                        on z.ProjectId equals o.Id
                        where p.OrderCode.Contains(OrderCode)
                        && p.WantId.Contains(WantNo)
                        && (PremiumsStatus == -1 || p.PremiumsStatus == PremiumsStatus)
                            //&& (FinanceIsAudit == -1 || p.FinanceIsAudit.Value.Equals(FinanceIsAudit == 0 ? false : true))
                        && (ManagerStatus == -1 || p.ManagerStatus == ManagerStatus)
                            //&& (DirectorStatus == -1 || p.DirectorStatus == DirectorStatus)
                        && (IsSingleRow == -1 || p.IsSingleRow.Value.Equals(IsSingleRow == 0 ? false : true))
                        && (PremiumsTypeId == -1 || p.PremiumsTypeId == PremiumsTypeId)
                        && p.IsEnable == false
                        && (PlatformId == -1 || s.PlatformTypeId == PlatformId) //平台
                        && (nick_id == -1 || nicklist.Contains(s.NickID))
                        && (ProjectId == -1 || ProjectId == 99 || z.ProjectId == ProjectId)  //项目
                        && o.ProjectTypeId == 362 //自运营项目
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        orderby p.CreateTime descending
                        select p;
            return query.ToList();
        }

        public List<XMPremiums> GetXMPremiumsListNoOrder(DateTime? min, DateTime? max, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId, string FullName, string Mobile, string OrderCode)
        {
            IQueryable<XMPremiums> query = null;
            if (string.IsNullOrEmpty(OrderCode))
            {
                query = from p in this._context.XMPremiums
                        where (PremiumsStatus == -1 || p.PremiumsStatus == PremiumsStatus)
                        && (ManagerStatus == -1 || p.ManagerStatus == ManagerStatus)
                        && (IsSingleRow == -1 || p.IsSingleRow.Value.Equals(IsSingleRow == 0 ? false : true))
                        && (PremiumsTypeId == -1 || p.PremiumsTypeId == PremiumsTypeId)
                        && p.OrderCode.StartsWith("NoOrder")
                        && p.IsEnable == false
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        orderby p.CreateTime descending
                        select p;
            }
            else
            {
                query = from p in this._context.XMPremiums
                        where (PremiumsStatus == -1 || p.PremiumsStatus == PremiumsStatus)
                        && (ManagerStatus == -1 || p.ManagerStatus == ManagerStatus)
                        && (IsSingleRow == -1 || p.IsSingleRow.Value.Equals(IsSingleRow == 0 ? false : true))
                        && (PremiumsTypeId == -1 || p.PremiumsTypeId == PremiumsTypeId)
                        && p.OrderCode.Contains(OrderCode)
                        && p.IsEnable == false
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        orderby p.CreateTime descending
                        select p;
            }

            if (!string.IsNullOrEmpty(FullName) || !string.IsNullOrEmpty(Mobile))
            {
                var Ids = from p in this._context.XMSpareAddresses
                          where p.IsEnable == false
                          && p.TypeID == 711//赠品
                          && p.FullName.Contains(FullName)
                          && p.Mobile.Contains(Mobile)
                          select p.OtherID;

                return query.Where(x => Ids.Contains(x.Id)).ToList();
            }

            return query.ToList();
        }

        /// <summary>
        /// 根据条件查询 赠品信息(关联订单表 状态是确认收货)
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="PremiumsStatus">赠品状态</param> 
        /// <param name="ManagerStatus">运营审核</param>
        /// <param name="IsSingleRow">是否排单</param>
        /// <param name="PremiumsTypeId">//申请类型：赠品:11、赔付：10</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        public List<XMPremiums> GetXMPremiumsListByOrderStatus(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId, List<string> OrderStatus, bool paramIsEvaluation, string paramActivityExplanation, bool IsYMX)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(NickId.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMPremiums
                        join x in this._context.XMOrderInfoes
                        on p.OrderCode equals x.OrderCode
                        join z in this._context.XMNicks  //店铺
                        on x.NickID equals z.nick_id
                        into JoinedA
                        from z in JoinedA.DefaultIfEmpty()
                        join o in this._context.XMProjects //项目
                        on z.ProjectId equals o.Id
                        into JoinedB
                        from o in JoinedB.DefaultIfEmpty()
                        where p.OrderCode.Contains(OrderCode)
                        && p.WantId.Contains(WantNo)
                        && (PremiumsStatus == -1 || p.PremiumsStatus == PremiumsStatus)
                        && (ManagerStatus == -1 || p.ManagerStatus == ManagerStatus)
                        && (IsSingleRow == -1 || p.IsSingleRow.Value.Equals(IsSingleRow == 0 ? false : true))
                        && (PremiumsTypeId == -1 || p.PremiumsTypeId == PremiumsTypeId)
                        && p.IsEnable == false
                        && (IsYMX == true || OrderStatus.Contains(x.OrderStatus))//查询指定状态的订单的赠品信息
                        && x.IsEnable == false
                        && (PlatformId == -1 || x.PlatformTypeId == PlatformId) //平台
                        && (nick_id == -1 || nicklist.Contains(x.NickID))  //店铺
                        && (ProjectId == -1 || ProjectId == 99 || z.ProjectId == ProjectId)  //项目
                        && (paramIsEvaluation == false || p.IsEvaluation == paramIsEvaluation)
                        && o.ProjectTypeId == 362 //自运营项目
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        && p.ActivityExplanation.Contains(paramActivityExplanation)
                        orderby p.CreateTime descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据条件查询 赠品信息(关联订单表 状态是已付款)
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="PremiumsStatus">赠品状态</param> 
        /// <param name="ManagerStatus">运营审核</param>
        /// <param name="IsSingleRow">是否排单</param>
        /// <param name="PremiumsTypeId">//申请类型：赠品:11、赔付：10</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        public List<XMPremiums> GetXMPremiumsListByPay(DateTime? min, DateTime? max, int ProjectId, string NickId, int PlatformId, string OrderCode, string WantNo, int PremiumsStatus, int ManagerStatus, int IsSingleRow, int PremiumsTypeId, List<string> OrderStatus, bool paramIsEvaluation, string paramActivityExplanation)
        {
            DateTime checkDate = DateTime.Parse("2011/10/10");
            int?[] nicklist = Array.ConvertAll<string, int?>(NickId.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMPremiums
                        join x in this._context.XMOrderInfoes
                        on p.OrderCode equals x.OrderCode
                        join z in this._context.XMNicks  //店铺
                        on x.NickID equals z.nick_id
                        into JoinedA
                        from z in JoinedA.DefaultIfEmpty()
                        join o in this._context.XMProjects //项目
                        on z.ProjectId equals o.Id
                        into JoinedB
                        from o in JoinedB.DefaultIfEmpty()
                        where p.OrderCode.Contains(OrderCode)
                        && p.WantId.Contains(WantNo)
                        && (PremiumsStatus == -1 || p.PremiumsStatus == PremiumsStatus)
                        && (ManagerStatus == -1 || p.ManagerStatus == ManagerStatus)
                        && (IsSingleRow == -1 || p.IsSingleRow.Value.Equals(IsSingleRow == 0 ? false : true))
                        && (PremiumsTypeId == -1 || p.PremiumsTypeId == PremiumsTypeId)
                        && p.IsEnable == false
                        && x.PayDate > checkDate//判断付款时间不为空
                        && !OrderStatus.Contains(x.OrderStatus)//不包含这些订单状态
                        && x.IsEnable == false
                        && (PlatformId == -1 || x.PlatformTypeId == PlatformId) //平台
                        && (nick_id == -1 || nicklist.Contains(x.NickID))  //店铺
                        && (ProjectId == -1 || ProjectId == 99 || z.ProjectId == ProjectId)  //项目
                        && (paramIsEvaluation == false || p.IsEvaluation == paramIsEvaluation)
                        && o.ProjectTypeId == 362 //自运营项目
                        && (p.CreateTime >= min || !min.HasValue) && (!max.HasValue || p.CreateTime <= max) //创建时间范围
                        && p.ActivityExplanation.Contains(paramActivityExplanation)
                        orderby p.CreateTime descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMPremiums Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPremiums Page List</returns>
        public PagedList<XMPremiums> SearchXMPremiums(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPremiums
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPremiums>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPremiums by Id
        /// </summary>
        /// <param name="id">XMPremiums Id</param>
        /// <returns>XMPremiums</returns>   
        public XMPremiums GetXMPremiumsById(int id)
        {
            var query = from p in this._context.XMPremiums
                        where p.Id.Equals(id)
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns> 
        public List<XMPremiums> GetXMPremiumsByListIds(List<int> Ids)
        {

            var query = from p in this._context.XMPremiums
                        where Ids.Contains(p.Id)
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMPremiums by Id
        /// </summary>
        /// <param name="Id">XMPremiums Id</param>
        public void DeleteXMPremiums(int id)
        {
            var xmpremiums = this.GetXMPremiumsById(id);
            if (xmpremiums == null)
                return;

            if (!this._context.IsAttached(xmpremiums))
                this._context.XMPremiums.Attach(xmpremiums);

            this._context.DeleteObject(xmpremiums);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPremiums by Id
        /// </summary>
        /// <param name="Ids">XMPremiums Id</param>
        public void BatchDeleteXMPremiums(List<int> ids)
        {
            var query = from q in _context.XMPremiums
                        where ids.Contains(q.Id)
                        && q.IsEnable == false
                        select q;
            var xmpremiumss = query.ToList();
            foreach (var item in xmpremiumss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPremiums.Attach(item);

                _context.XMPremiums.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
