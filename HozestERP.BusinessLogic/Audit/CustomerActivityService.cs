using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.Audit
{
    /// <summary>
    /// Customer activity service
    /// </summary>
    public partial class CustomerActivityService : ICustomerActivityService
    {
        #region Constants
        private const string ACTIVITYTYPE_ALL_KEY = "CRM.activitytype.all";
        private const string ACTIVITYTYPE_BY_ID_KEY = "CRM.activitytype.id-{0}";
        private const string ACTIVITYTYPE_PATTERN_KEY = "CRM.activitytype.";
        #endregion

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
        public CustomerActivityService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public void InsertActivityType(ActivityLogType activityLogType)
        {
            if (activityLogType == null)
                throw new ArgumentNullException("activityLogType");

            activityLogType.SystemKeyword = CommonHelper.EnsureNotNull(activityLogType.SystemKeyword);
            activityLogType.SystemKeyword = CommonHelper.EnsureMaximumLength(activityLogType.SystemKeyword, 50);
            activityLogType.Name = CommonHelper.EnsureNotNull(activityLogType.Name);
            activityLogType.Name = CommonHelper.EnsureMaximumLength(activityLogType.Name, 100);



            _context.ActivityLogTypes.AddObject(activityLogType);
            _context.SaveChanges();

            if (this.CacheEnabled)
                _cacheManager.RemoveByPattern(ACTIVITYTYPE_PATTERN_KEY);
        }

        /// <summary>
        /// Updates an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public void UpdateActivityType(ActivityLogType activityLogType)
        {
            if (activityLogType == null)
                throw new ArgumentNullException("activityLogType");

            activityLogType.SystemKeyword = CommonHelper.EnsureNotNull(activityLogType.SystemKeyword);
            activityLogType.SystemKeyword = CommonHelper.EnsureMaximumLength(activityLogType.SystemKeyword, 50);
            activityLogType.Name = CommonHelper.EnsureNotNull(activityLogType.Name);
            activityLogType.Name = CommonHelper.EnsureMaximumLength(activityLogType.Name, 100);


            if (!_context.IsAttached(activityLogType))
                _context.ActivityLogTypes.Attach(activityLogType);

            _context.SaveChanges();

            if (this.CacheEnabled)
                _cacheManager.RemoveByPattern(ACTIVITYTYPE_PATTERN_KEY);
        }

        /// <summary>
        /// Deletes an activity log type item
        /// </summary>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        public void DeleteActivityType(int activityLogTypeId)
        {
            var activityLogType = GetActivityTypeById(activityLogTypeId);
            if (activityLogType == null)
                return;


            if (!_context.IsAttached(activityLogType))
                _context.ActivityLogTypes.Attach(activityLogType);
            _context.DeleteObject(activityLogType);
            _context.SaveChanges();

            if (this.CacheEnabled)
                _cacheManager.RemoveByPattern(ACTIVITYTYPE_PATTERN_KEY);
        }

        /// <summary>
        /// Gets all activity log type items
        /// </summary>
        /// <returns>Activity log type collection</returns>
        public List<ActivityLogType> GetAllActivityTypes()
        {
            if (this.CacheEnabled)
            {
                object cache = _cacheManager.Get(ACTIVITYTYPE_ALL_KEY);
                if (cache != null)
                    return (List<ActivityLogType>)cache;
            }


            var query = from at in _context.ActivityLogTypes
                        orderby at.Name
                        select at;
            var collection = query.ToList();

            if (this.CacheEnabled)
                _cacheManager.Add(ACTIVITYTYPE_ALL_KEY, collection);

            return collection;
        }

        /// <summary>
        /// Gets an activity log type item
        /// </summary>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <returns>Activity log type item</returns>
        public ActivityLogType GetActivityTypeById(int activityLogTypeId)
        {
            if (activityLogTypeId == 0)
                return null;

            string key = string.Format(ACTIVITYTYPE_BY_ID_KEY, activityLogTypeId);
            if (this.CacheEnabled)
            {
                object cache = _cacheManager.Get(key);
                if (cache != null)
                    return (ActivityLogType)cache;
            }


            var query = from at in _context.ActivityLogTypes
                        where at.ActivityLogTypeID == activityLogTypeId
                        select at;
            var activityLogType = query.SingleOrDefault();

            if (this.CacheEnabled)
                _cacheManager.Add(key, activityLogType);

            return activityLogType;
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(string systemKeyword, string comment)
        {
            return InsertActivity(systemKeyword, comment, new object[0]);
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(string systemKeyword,
            string comment, params object[] commentParams)
        {
            if (HozestERPContext.Current.User == null ||
                HozestERPContext.Current.User.IsGuest)
                return null;

            var activityTypes = GetAllActivityTypes();
            var activityType = activityTypes.FindBySystemKeyword(systemKeyword);
            if (activityType == null || !activityType.Enabled)
                return null;

            int customerId = HozestERPContext.Current.User.CustomerID;
            comment = CommonHelper.EnsureNotNull(comment);
            comment = string.Format(comment, commentParams);
            comment = CommonHelper.EnsureMaximumLength(comment, 4000);



            var activity = _context.ActivityLogs.CreateObject();
            activity.ActivityLogTypeID = activityType.ActivityLogTypeID;
            activity.CustomerID = customerId;
            activity.Comment = comment;
            activity.CreatedOn = DateTime.UtcNow;

            _context.ActivityLogs.AddObject(activity);
            _context.SaveChanges();

            return activity;
        }


        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(int merchantID, string systemKeyword,
            string comment, params object[] commentParams)
        {
            if (HozestERPContext.Current.User == null ||
                HozestERPContext.Current.User.IsGuest)
                return null;

            var activityTypes = GetAllActivityTypes();
            var activityType = activityTypes.FindBySystemKeyword(systemKeyword);
            if (activityType == null || !activityType.Enabled)
                return null;

            int customerId = HozestERPContext.Current.User.CustomerID;
            comment = CommonHelper.EnsureNotNull(comment);
            comment = string.Format(comment, commentParams);
            comment = CommonHelper.EnsureMaximumLength(comment, 4000);



            var activity = _context.ActivityLogs.CreateObject();
            activity.MerchantID = merchantID;
            activity.ActivityLogTypeID = activityType.ActivityLogTypeID;
            activity.CustomerID = customerId;
            activity.Comment = comment;
            activity.CreatedOn = DateTime.UtcNow;

            _context.ActivityLogs.AddObject(activity);
            _context.SaveChanges();

            return activity;
        }

        /// <summary>
        /// Deletes an activity log item
        /// </summary>
        /// <param name="activityLogId">Activity log type identifier</param>
        public void DeleteActivity(int activityLogId)
        {
            var activity = GetActivityById(activityLogId);
            if (activity == null)
                return;


            if (!_context.IsAttached(activity))
                _context.ActivityLogs.Attach(activity);
            _context.DeleteObject(activity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all activity log items
        /// </summary>
        /// <param name="createdOnFrom">Log item creation from; null to load all customers</param>
        /// <param name="createdOnTo">Log item creation to; null to load all customers</param>
        /// <param name="email">Customer Email</param>
        /// <param name="username">Customer username</param>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Activity log collection</returns>
        public PagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom,
            DateTime? createdOnTo, string email, string username, int activityLogTypeId,
            int pageIndex, int pageSize)
        {
            var query = from al in _context.ActivityLogs
                        where (!createdOnFrom.HasValue || createdOnFrom.Value <= al.CreatedOn) &&
                        (!createdOnTo.HasValue || createdOnTo.Value >= al.CreatedOn) &&
                        (activityLogTypeId == 0 || activityLogTypeId == al.ActivityLogTypeID) &&
                        (String.IsNullOrEmpty(email) || al.SCustomer.Email.Contains(email)) &&
                        (String.IsNullOrEmpty(username) || al.SCustomer.Username.Contains(username)) &&
                        !al.SCustomer.IsGuest &&
                        !al.SCustomer.Deleted
                        orderby al.CreatedOn descending
                        select al;
            var activityLog = new PagedList<ActivityLog>(query, pageIndex, pageSize);
            return activityLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantID"></param>
        /// <param name="systemKeyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<ActivityLog> GetAllActivitiesByMerchantID(int merchantID, string systemKeyword, int pageIndex, int pageSize)
        {

            var activityTypes = GetAllActivityTypes();
            var activityType = activityTypes.FindBySystemKeyword(systemKeyword);

            var query = from al in _context.ActivityLogs
                        where al.MerchantID == merchantID 
                        && al.ActivityLogTypeID == activityType.ActivityLogTypeID 
                        && !al.SCustomer.IsGuest &&
                        !al.SCustomer.Deleted
                        orderby al.CreatedOn descending
                        select al;
            var activityLog = new PagedList<ActivityLog>(query, pageIndex, pageSize);
            return activityLog;
        }

        /// <summary>
        /// Gets an activity log item
        /// </summary>
        /// <param name="activityLogId">Activity log identifier</param>
        /// <returns>Activity log item</returns>
        public ActivityLog GetActivityById(int activityLogId)
        {
            if (activityLogId == 0)
                return null;


            var query = from al in _context.ActivityLogs
                        where al.ActivityLogID == activityLogId
                        select al;
            var activityLog = query.SingleOrDefault();
            return activityLog;
        }

        /// <summary>
        /// Clears activity log
        /// </summary>
        public void ClearAllActivities()
        {

            var activityLog = _context.ActivityLogs.ToList();
            foreach (var activityLogItem in activityLog)
                _context.DeleteObject(activityLogItem);
            _context.SaveChanges();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public bool CacheEnabled
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.CustomerActivityManager.CacheEnabled");
            }
        }
        #endregion
    }
}
