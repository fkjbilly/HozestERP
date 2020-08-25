using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class CodeTypeService : ICodeTypeService
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
        public CodeTypeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region ICodeTypeService Members

        public List<CodeType> GetCodeTypeAll()
        {
            var query = from c in _context.CodeTypes 
                        where c.Deleted == false
                        orderby c.ModuleID, c.CodeTypeCode
                        select c;

            return query.ToList();
        }

        public List<CodeType> GetCodeTypeByModuleID(int moduleID)
        {
            var query = from c in _context.CodeTypes
                        where !c.Deleted && c.ModuleID == moduleID
                        orderby c.DisplayOrder ascending
                        select c;

            return query.ToList();
        }

        /// <summary>
        /// 返回公用代码信息
        /// </summary>
        public CodeType GetCodeTypeByCodeTypeName(string CodeTypeName)
        {
            var query = from c in _context.CodeTypes
                        where c.CodeTypeName.Equals(CodeTypeName)
                        select c;
            var codeType = query.SingleOrDefault();
            return codeType;
        
        }

        public List<CodeType> GetCodeType(int codeTypeID)
        {
            var query = from c in _context.CodeTypes
                        where c.CodeTypeID == codeTypeID
                        select c;
            return query.ToList();
        }

        public CodeType  GetCodeTypeByCodeTypeID(int codeTypeID)
        {
            if (codeTypeID == 0)
                return null;
            var query=from c in _context.CodeTypes 
                      where c.CodeTypeID == codeTypeID
                      select c;
            var codeType = query.SingleOrDefault();
            return codeType;
        }

        public void InsertCodeType(CodeType codeType)
        {
            if (codeType==null )
                throw new ArgumentNullException("codeType");
            _context.CodeTypes.AddObject(codeType);
            _context.SaveChanges();
        }

        public void UpdateCodeType(CodeType codeType)
        {
            if (codeType == null)
                throw new ArgumentNullException("codeType");
            if (!_context.IsAttached(codeType))
                _context.CodeTypes.Attach(codeType);

            _context.SaveChanges();
        }

        public void DeleteCodeType(int codeTypeID)
        {
            var codeType = GetCodeTypeByCodeTypeID(codeTypeID);
            if (codeType == null)
                return;
            if (!_context.IsAttached(codeType))
                _context.CodeTypes.Attach(codeType);
            _context.DeleteObject(codeType);
            _context.SaveChanges();

        }

        public List<CodeType> GetCodeTypeByPlatFormTypeId(string platformtypeid)
        {
            var query = from c in _context.CodeTypes
                        where c.CodeTypeCode.Contains(platformtypeid)
                        && c.Deleted == false
                        select c;
            return query.ToList().Where(p => !p.CodeTypeCode.Contains("a") && !p.CodeTypeCode.Contains("b")).ToList();
        }

        #endregion

        #region ICodeTypeService Members
        #endregion       
    }
}
