using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using System.Runtime.Caching;
using JdSdk;
using JdSdk.Request;
using JdSdk.Response;
using Newtonsoft.Json;
using JdSdk.Domains;
using HozestERP.BusinessLogic.ManageCustomerService;
using JdSdk.Domain;


namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class ProjectService : IProjectService
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


        static ObjectCache cache = MemoryCache.Default;
        static CacheItemPolicy mPolicy = null;
        const string EXECUTIONDATETIME = "DATETIME.OF.OrderInfo";


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public ProjectService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPStaticCache();
        }

        #endregion

        #region Properties
        /// <summary> 
        /// 人员数据权限
        /// </summary>
        private IQueryable<int> SecuritySql
        {
            get
            {
                return this._context.Security(HozestERPContext.Current.User.CustomerID);
            }
        }
        #endregion

    }
}
