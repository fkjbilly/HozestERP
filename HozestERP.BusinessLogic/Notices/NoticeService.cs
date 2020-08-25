using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Notices
{
    public partial class NoticeService : INoticeService
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
        public NoticeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region INoticeService 成员
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <returns>List</returns>
        public List<Notice> GetNotices()
        {
            var query = from p in this._context.Notices                       
                        orderby p.DateTime descending
                        select p;
            var notices = query.ToList();

            return notices;
        }

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="content">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        public PagedList<Notice> GetNotices(string content, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Notices
                        where p.Title.Contains(content) || p.Description.Contains(content)
                        orderby p.DateTime descending
                        select p;
            var notices = new PagedList<Notice>(query, pageIndex, pageSize);
            return notices;
        }

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="content">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        public PagedList<Notice> GetStartNotices(string content, int pageIndex, int pageSize)
        {
            var query = from p in this._context.Notices
                        where p.Title.Contains(content) || p.Description.Contains(content)
                        && p.Published
                        orderby p.DateTime descending
                        select p;
            var notices = new PagedList<Notice>(query, pageIndex, pageSize);
            return notices;
        }

        /// <summary>
        /// 获取已发布并且生效的通知
        /// </summary>
        /// <returns>List</returns>
        public List<Notice> GetStartNotices()
        {
            var query = from p in this._context.Notices
                        where p.Published && p.StartTime <= DateTime.Now
                        orderby p.DateTime descending
                        select p;
            var notices = query.ToList();
            return notices;
        }

        /// <summary>
        /// 根据ID获取当前通知信息
        /// </summary>
        /// <param name="noticeId">ID</param>
        /// <returns>notice</returns>
        public Notice GetNoticeByID(Guid noticeId)
        {
            var query = from p in this._context.Notices
                        where p.ID == noticeId
                        select p;
            var notice = query.SingleOrDefault();
            return notice;
        }


        /// <summary>
        /// Deletes a Notice item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        public void DeleteNotice(List<int> noticeIds)
        {
            foreach (var id in noticeIds)
            {
                var notice = GetNoticeByID(new Guid(id.ToString()));
                if (notice == null)
                    break;

                if (!_context.IsAttached(notice))
                    _context.Notices.Attach(notice);

                _context.DeleteObject(notice);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        public Notice InsertNotice(Notice notice)
        {
            if (notice == null)
                throw new ArgumentNullException("notice");

            _context.Notices.AddObject(notice);
            _context.SaveChanges();


            return notice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notice"></param>
        public void UpdateNotice(Notice notice)
        {
            if (notice == null)
                throw new ArgumentNullException("notice");

            if (!_context.IsAttached(notice))
                _context.Notices.Attach(notice);
            _context.SaveChanges();
        }
        #endregion
    }
}
