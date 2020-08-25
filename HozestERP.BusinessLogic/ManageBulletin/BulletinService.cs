using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageProtal;

namespace HozestERP.BusinessLogic.ManageBulletin
{
    public partial class BulletinService : IBulletinService
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
        public BulletinService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IBulletinService 成员

        /// <summary>
        /// 获取公告列表
        /// </summary> 
        /// <param name="bulletinTitle">标题</param>
        /// <param name="BulletinStatus">状态</param>
        /// <param name="BulletinType">公告类型</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        public PagedList<Bulletin> GetBulletin(string bulletinTitle, int bulletinStatus, int bulletinType, DateTime? StartDate, DateTime? EndDate, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Bulletins
                        where !p.Deleted
                        && p.BulletinTitle.Contains(bulletinTitle)
                        && (bulletinStatus.Equals(-1) || p.BulletinStatus.Equals(bulletinStatus))
                        && (bulletinType.Equals(0) || p.BulletinTypeID.Equals(bulletinType))
                        && (!StartDate.HasValue || p.ReleasedDate >= StartDate.Value)
                        && (!EndDate.HasValue || p.ReleasedDate <= EndDate.Value)
                        orderby p.ReleasedDate descending, p.EffectiveDate descending, p.PriorTypeID descending
                        select p;
            return new PagedList<Bulletin>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="bulletinTitle">标题</param>
        /// <param name="bulletinStatus">状态</param>
        /// <param name="bulletinType">公告类型</param>
        /// <param name="StartDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>Bulletin Paged List</returns>
        public PagedList<Bulletin> GetBulletinByCustomerID(int customerID, string bulletinTitle, int bulletinStatus, int bulletinType, DateTime? StartDate, DateTime? EndDate, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Bulletins
                        where !p.Deleted
                        && p.BulletinTitle.Contains(bulletinTitle)
                        && (bulletinStatus.Equals(-1) || p.BulletinStatus.Equals(bulletinStatus))
                        && (bulletinType.Equals(-1) || p.BulletinTypeID.Equals(bulletinType))
                        && (!StartDate.HasValue || p.ReleasedDate >= StartDate.Value)
                        && (!EndDate.HasValue || p.ReleasedDate <= EndDate.Value)
                        && p.CreatorID.Equals(customerID)
                        orderby p.ReleasedDate descending, p.EffectiveDate descending, p.PriorTypeID descending
                        select p;
            return new PagedList<Bulletin>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// 根据ID获取公告列表
        /// </summary>
        /// <param name="bulletinID"></param>
        /// <returns>Bulletin</returns>
        public Bulletin GetBulletinByBulletinID(int bulletinID)
        {
            var query = from b in this._context.Bulletins
                        where !b.Deleted
                        && b.BulletinID.Equals(bulletinID)
                        select b;
            var bulletin = query.SingleOrDefault();
            return bulletin;
        }

        /// <summary>
        /// 更新公告信息
        /// </summary>
        /// <param name="Bulletin"></param>
        public void UpdateBulletin(Bulletin bulletin)
        {
            if (bulletin == null)
                throw new ArgumentNullException("bulletin");
            if (!_context.IsAttached(bulletin))
                _context.Bulletins.Attach(bulletin);
            _context.SaveChanges();
        }

        /// <summary>
        /// 新增公告信息
        /// </summary>
        /// <param name="Bulletin"></param>
        public Bulletin InsertBulletin(Bulletin bulletin)
        {
            if (bulletin == null)
                throw new ArgumentNullException("bulletin");

            _context.Bulletins.AddObject(bulletin);
            _context.SaveChanges();
            return bulletin;
        }

        /// <summary>
        /// 新增发公告信息的用户
        /// </summary>
        /// <param name="customerGUID"></param>
        /// <param name="bulletinID"></param>
        public void AddBulletinCusotmer(int customerID, int bulletinID)
        {
            var customerInfo = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(customerID);
            if (customerInfo == null)
                return;
            var bulletin = GetBulletinByBulletinID(bulletinID);
            if (bulletin == null)
                return;

            if (!_context.IsAttached(customerInfo))
                _context.CustomerInfoes.Attach(customerInfo);
            if (!_context.IsAttached(bulletin))
                _context.Bulletins.Attach(bulletin);

            if (customerInfo.SBulletins == null)
                this._context.LoadProperty(customerInfo, c => c.SBulletins);

            customerInfo.SBulletins.Add(bulletin);

            _context.SaveChanges();
        }

        /// <summary>
        /// 删除公告信息发送人列表
        /// </summary>
        /// <param name="bulletinID"></param>
        public void DeleteBulletinCusotmer(int bulletinID)
        {
            string sql = " DELETE OA_Bulletin_CusotmerMapping WHERE BulletinID=" + bulletinID.ToString();
            this._context.ExecuteStoreCommand(sql);
        }

        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="bulletinIDs">公告信息ID</param>
        public void DeleteBulletin(List<int> bulletinIDs)
        {
            var query = from p in this._context.Bulletins
                        where bulletinIDs.Contains(p.BulletinID) && !p.Deleted
                        select p;
            var bulletinItems = query.ToList();
            foreach (var item in bulletinItems)
            {
                item.Deleted = true;

                if (!_context.IsAttached(item))
                    _context.Bulletins.Attach(item);

            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 公告发布
        /// </summary>
        /// <param name="bulletinIDs">公告信息ID</param>
        public void bulletinReleased(List<int> bulletinIDs)
        {
            var query = from p in this._context.Bulletins
                        where bulletinIDs.Contains(p.BulletinID) && !p.Deleted
                        && p.BulletinStatus.Equals((int)BulletinStatusEnum.Found)
                        select p;
            var bulletinItems = query.ToList();
            foreach (var item in bulletinItems)
            {
                item.BulletinStatus = (int)BulletinStatusEnum.Released;

                if (!_context.IsAttached(item))
                    _context.Bulletins.Attach(item);

            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 公告终止
        /// </summary>
        /// <param name="bulletinIDs">公告信息ID</param>
        public void bulletinEnd(List<int> bulletinIDs)
        {
            var query = from p in this._context.Bulletins
                        where bulletinIDs.Contains(p.BulletinID) && !p.Deleted
                        && p.BulletinStatus.Equals((int)BulletinStatusEnum.Released)
                        select p;
            var bulletinItems = query.ToList();
            foreach (var item in bulletinItems)
            {
                item.BulletinStatus = (int)BulletinStatusEnum.End;

                if (!_context.IsAttached(item))
                    _context.Bulletins.Attach(item);

            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 获取已发布并且生效的个人通告
        /// </summary>
        /// <returns>List</returns>
        public List<Bulletin> GetStartBulletin()
        {
            var query = from b in this._context.Bulletins
                        from c in b.SCustomerInfo
                        where b.Published
                        && b.EffectiveDate <= DateTime.Now
                        && b.InvalidDate >= DateTime.Now
                        && !b.Deleted
                        && b.BulletinStatus == (int)BulletinStatusEnum.Released
                        && c.CustomerID == HozestERPContext.Current.User.CustomerID
                        orderby b.ReleasedDate descending, b.EffectiveDate descending, b.PriorTypeID descending
                        select b;
            var bulletins = query.Distinct().ToList();
            return bulletins;
        }

        public List<Bulletin> GetOrderBulletin()
        {
            List<Bulletin> list = new List<Bulletin>();
            List<XMProject> projectList = null;

            var data = IoC.Resolve<IXMOrderInfoService>().getUnusualOrder();

            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                projectList = IoC.Resolve<IXMProjectService>().GetXMProjectList();
            }
            else
            {
                projectList = IoC.Resolve<IXMProjectService>().GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            }

            foreach (var item in projectList)
            {
                int count = data.Where(a => a.ProjectId == item.Id).Count();
                if (count != 0)
                {
                    Bulletin bulletin = new Bulletin();
                    bulletin.BulletinTitle = item.ProjectName + "异常订单：" + count;
                    bulletin.BulletinID = item.Id;
                    list.Add(bulletin);
                }
            }



            return list;
        }

        public Bulletin GetOrderWarning()
        {
            var data = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetWarningOrderList();

            Bulletin bulletin = new Bulletin();
            bulletin.BulletinTitle = "订单信息异常：" + data.Count;

            return bulletin;
        }

        public List<Bulletin> GetProductMin()
        {
            List<Bulletin> list = new List<Bulletin>();

            var data = IoC.Resolve<IXMProductService>().getProductByMinPriceUnSet(-1);

            List<int?> countlist = data.GroupBy(a => a.BrandTypeId).Select(b => b.Key).ToList();

            foreach(var item in countlist)
            {
                Bulletin bulletin = new Bulletin();
                List<UnSetMinPriceProduct> productlist = data.Where(a => a.BrandTypeId == item).ToList();
                bulletin.BulletinTitle = productlist[0].BrandTypeCodeName + " 未设置最低售价商品：" + productlist.Count;
                bulletin.BulletinID = (int)item;
                list.Add(bulletin);
            }
            return list;
        }

        /// <summary>
        /// 获取个人公告列表
        /// </summary> 
        /// <param name="bulletinTitle">标题</param>
        /// <param name="BulletinStatus">状态</param>
        /// <param name="BulletinType">公告类型</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        public PagedList<Bulletin> GetBulletins(string bulletinTitle, int bulletinStatus, int bulletinType, DateTime? StartDate, DateTime? EndDate, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Bulletins
                        from c in p.SCustomerInfo
                        where !p.Deleted
                        && c.CustomerID.Equals(HozestERPContext.Current.User.CustomerID)
                        && p.BulletinTitle.Contains(bulletinTitle)
                        && p.ReleasedDate >= p.EffectiveDate
                        && p.ReleasedDate < p.InvalidDate
                        && (bulletinStatus.Equals(-1) || p.BulletinStatus.Equals(bulletinStatus))
                        && (bulletinType.Equals(0) || p.BulletinTypeID.Equals(bulletinType))
                        && (!StartDate.HasValue || p.ReleasedDate >= StartDate.Value)
                        && (!EndDate.HasValue || p.ReleasedDate <= EndDate.Value)
                        orderby p.ReleasedDate descending, p.EffectiveDate descending, p.PriorTypeID descending
                        select p;
            return new PagedList<Bulletin>(query, pageIndex, pageSize);
        }

        #endregion
    }
}

