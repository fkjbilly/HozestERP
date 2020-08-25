using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRM.Common;
using CRM.BusinessLogic.Data;
using CRM.BusinessLogic.Caching;
using CRM.Common.Utils;

namespace CRM.BusinessLogic.Media
{
    /// <summary>
    /// Service implement
    /// </summary>
    public partial class MisSettingService : IMisSettingService
    {
        #region Variables

        /// <summary>
        /// Object context
        /// </summary>
        private readonly CRMObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Object context</param>
        public MisSettingService(CRMObjectContext context)
        {
            this._context = context;
            this._cacheManager = new CRMStaticCache();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get an object by id
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <returns>the new object</returns>
        public Mis_Setting GetById(int id)
        {
            if (id == 0) return null;
            var query = from m in _context.Mis_Setting
                        where m.Id == id
                        select m;
            var mMisSetting = query.SingleOrDefault();

            return mMisSetting;
        }

        /// <summary>
        /// Get a setting by name
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>Setting instance</returns>
        public Mis_Setting GetSettingByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return null;

            name = name.Trim().ToLowerInvariant();

            var settings = GetAllSettings();
            if (settings.ContainsKey(name))
            {
                var setting = settings[name];
                return setting;
            }
            return null;
        }

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Mis_Setting> GetAllSettings()
        {
            var query = from m in _context.Mis_Setting
                        orderby m.Name
                        select m;
            var settings = query.ToDictionary(m => m.Name.ToLowerInvariant());

            return settings;
        }

        /// <summary>
        ///  Gets all settings
        /// </summary>
        /// <param name="Name">setting's name</param>
        /// <param name="pageIndex">start index</param>
        /// <param name="pageSize">size of per page</param>
        /// <returns>Setting collection</returns>
        public PagedList<Mis_Setting> GetAllSettings(string Name, int pageIndex, int pageSize)
        {
            var query = from m in this._context.Mis_Setting
                        where m.Name.Contains(Name)
                        orderby m.Name
                        select m;

            return new PagedList<Mis_Setting>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public Mis_Setting SetParam(string name, string value, string memo)
        {
            var mMisSetting = this.GetSettingByName(name);

            if (mMisSetting == null)
                mMisSetting = Insert(name, value, memo);
            else
                mMisSetting = Update(mMisSetting.Id, name, value, memo);

            return mMisSetting;
        }

        #region CRUD Methods

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="name">setting's name</param>
        /// <param name="value">setting's value</param>
        /// <param name="memo">setting's memo</param>
        /// <returns>the new object</returns>
        public Mis_Setting Insert(string name, string value, string memo)
        {
            name = CommonHelper.EnsureNotNull(name);
            name = CommonHelper.EnsureMaximumLength(name, 200);
            value = CommonHelper.EnsureNotNull(value);
            value = CommonHelper.EnsureMaximumLength(value, 2000);
            memo = CommonHelper.EnsureNotNull(memo);

            var mMisSetting = _context.Mis_Setting.CreateObject();
            mMisSetting.Name = name;
            mMisSetting.Value = value;
            mMisSetting.Memo = memo;

            _context.Mis_Setting.AddObject(mMisSetting);
            _context.SaveChanges();

            return mMisSetting;
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <param name="name">setting's name</param>
        /// <param name="value">setting's value</param>
        /// <param name="memo">setting's memo</param>
        /// <returns>the new object instance</returns>
        public Mis_Setting Update(int id, string name, string value, string memo)
        {
            name = CommonHelper.EnsureNotNull(name);
            name = CommonHelper.EnsureMaximumLength(name, 200);
            value = CommonHelper.EnsureNotNull(value);
            value = CommonHelper.EnsureMaximumLength(value, 2000);
            memo = CommonHelper.EnsureNotNull(memo);

            var mMisSetting = GetById(id);
            if (mMisSetting == null) return null;
            if (!_context.IsAttached(mMisSetting))
                _context.Mis_Setting.Attach(mMisSetting);

            mMisSetting.Name = name;
            mMisSetting.Value = value;
            mMisSetting.Memo = memo;
            _context.SaveChanges();

            return mMisSetting;
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id">identifier id</param>
        public void Delete(int id)
        {
            var mMisSetting = GetById(id);
            if (mMisSetting == null) return;

            if (!_context.IsAttached(mMisSetting))
                _context.Mis_Setting.Attach(mMisSetting);
            _context.DeleteObject(mMisSetting);
            _context.SaveChanges();
        }

        #endregion

        #endregion

    }
}
