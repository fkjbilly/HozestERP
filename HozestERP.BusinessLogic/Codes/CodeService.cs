using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;

using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class CodeService : ICodeService
    {
        #region Constants
        private const string CodeLists_ALL_KEY = "CRM.CodeLists.all-{0}-{1}";
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
        public CodeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPStaticCache();
        }

        #endregion

        #region ICodeService Members

        public List<CodeList> GetCodeListAll()
        {
            var query = from c in _context.CodeLists
                        where c.Deleted == false
                        orderby c.DisplayOrder ascending
                        select c;

            return query.ToList();
        }

        public List<CodeList> GetCodeList(int codeID)
        {
            var query = from c in _context.CodeLists
                        where c.CodeID == codeID
                        orderby c.DisplayOrder ascending
                        select c;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeIDs"></param>
        /// <returns></returns>
        public List<CodeList> GetCodeListInfoByCodeIDs(string codeIDs)
        {
            int?[] codeIdlist = Array.ConvertAll<string, int?>(codeIDs.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from c in _context.CodeLists
                        where codeIdlist.Contains(c.CodeID)
                        orderby c.DisplayOrder ascending
                        select c;
            return query.ToList();
        }

        public List<CodeList> GetCodeListInfoByCodeTypeID(int codeTypeID)
        {
            var query = from c in _context.CodeLists
                        where c.CodeTypeID == codeTypeID
                        && c.Deleted == false
                        orderby c.DisplayOrder ascending
                        select c;
            return query.ToList();
        }


        /// <summary>
        /// 根据CodeTypeID、CodeName查询公用代码信息
        /// </summary>
        /// <param name="CodeID">codeID</param>
        public List<CodeList> GetCodeListInfoByCodeTypeIDAndCodeName(int codeTypeID, string CodeName)
        {
            var query = from c in _context.CodeLists
                        where c.CodeTypeID == codeTypeID
                        && c.CodeName.Equals(CodeName)
                        && c.Deleted == false
                        orderby c.DisplayOrder ascending
                        select c;
            return query.ToList();

        }


        public List<CodeList> GetCodeListInfoByCodeTypeID(int codeTypeID, bool isDeleted)
        {
            string key = string.Format(CodeLists_ALL_KEY, codeTypeID, isDeleted);
            object obj2 = _cacheManager.Get(key);
            if (this.CacheEnabled && (obj2 != null))
            {
                return (List<CodeList>)obj2;
            }
            var query = from c in _context.CodeLists
                        where c.CodeTypeID == codeTypeID && c.Deleted == isDeleted
                        orderby c.DisplayOrder ascending
                        select c;
            var codeLists = query.ToList();

            if (this.CacheEnabled)
            {
                _cacheManager.Add(key, codeLists);
            }
            return codeLists;
        }

        public List<CodeList> GetCodeListInfoByCodeTypeIDWithoutCache(int codeTypeID, bool isDeleted)
        {
            var query = from c in _context.CodeLists
                        where c.CodeTypeID == codeTypeID && c.Deleted == isDeleted
                        orderby c.DisplayOrder ascending
                        select c;

            return query.ToList();
        }


        public CodeList GetCodeListInfoByCodeID(int codeID)
        {
            if (codeID == 0)
                return null;
            var query = from c in _context.CodeLists
                        where c.CodeID == codeID
                        select c;
            var codeList = query.SingleOrDefault();
            return codeList;
        }

        public CodeList GetCodeListByCodeTypeID(int codeTypeID)
        {
            if (codeTypeID == 0)
                return null;
            var query = from c in _context.CodeLists
                        where c.CodeTypeID == codeTypeID
                        select c;
            var codeList = query.SingleOrDefault();
            return codeList;
        }

        public void InsertCodeList(CodeList codeList)
        {
            if (codeList == null)
                throw new ArgumentNullException("codeList");
            _context.CodeLists.AddObject(codeList);
            _context.SaveChanges();
        }

        public void UpdateCodeList(CodeList codeList)
        {
            if (codeList == null)
                throw new ArgumentNullException("codeList");
            if (!_context.IsAttached(codeList))
                _context.CodeLists.Attach(codeList);

            _context.SaveChanges();
        }

        public void DeleteCodeList(int codeID)
        {
            var codeList = GetCodeListInfoByCodeID(codeID);
            if (codeList == null)
                return;
            if (!_context.IsAttached(codeList))
                _context.CodeLists.Attach(codeList);
            _context.DeleteObject(codeList);
            _context.SaveChanges();
        }


        //public CodeList GetCodeName(string CodeName)
        //{
        //    if (CodeName == "")
        //        return null;
        //    var query = from c in _context.CodeLists
        //                where c.CodeName.Equals(CodeName)
        //                select c;
        //    var codeList = query.FirstOrDefault();
        //    return codeList;
        //} 

        /// <summary>
        /// 根据代码类型ID和代码编号获取代码列表
        /// </summary>
        /// <param name="codeTypeID"></param>
        /// <param name="CodeNo"></param>
        /// <returns></returns>
        public List<CodeList> GetCodeListByCodeTypeIDCodeNo(int codeTypeID, string CodeNo)
        {
            var query = from p in this._context.CodeLists
                        where p.CodeTypeID == codeTypeID
                        && p.CodeNO.Equals(CodeNo)
                        && !p.Deleted
                        select p;
            return query.ToList();
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
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Cache.CodeList.CacheEnabled");
            }
        }
        #endregion
    }
}
