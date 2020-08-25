using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRM.Common;
using CRM.BusinessLogic.Data;

namespace CRM.BusinessLogic.Media
{
    /// <summary>
    /// Service implement
    /// </summary>
    public partial class MisPlayService : IMisPlayService
    {
        #region Variables

        /// <summary>
        /// Object context
        /// </summary>
        private readonly CRMObjectContext _context;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Object context</param>
        public MisPlayService(CRMObjectContext context)
        {
            this._context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get an object by id
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <returns>the new object</returns>
        public Mis_Play GetById(int id)
        {
            if (id == 0) return null;
            var query = from m in _context.Mis_Play
                        where m.Id == id
                        select m;
            var mMisPlay = query.SingleOrDefault();

            return mMisPlay;
        }

        /// <summary>
        /// Get a setting by name
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>model instance</returns>
        public Mis_Play GetAllByMusicName(string MusicName)
        {
            if (String.IsNullOrEmpty(MusicName))
                return null;

            MusicName = MusicName.Trim().ToLowerInvariant();
            var mLst = GetAll();
            if (mLst.ContainsKey(MusicName))
            {
                var mRecord = mLst[MusicName];
                return mRecord;
            }
            return null;
        }

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Mis_Play> GetAll()
        {
            var query = from m in _context.Mis_Play
                        orderby m.MusicName
                        select m;
            var mLst = query.ToDictionary(m => m.MusicName.ToLowerInvariant());

            return mLst;
        }

        /// <summary>
        ///  Gets all records
        /// </summary>
        /// <param name="pageIndex">start index</param>
        /// <param name="pageSize">size of per page</param>
        /// <returns>Setting collection</returns>
        public PagedList<Mis_Play> GetAll(int pageIndex, int pageSize)
        {
            var query = from m in this._context.Mis_Play
                        orderby m.Id ascending
                        select m;

            return new PagedList<Mis_Play>(query, pageIndex, pageSize);
        }

        ///// <summary>
        ///// Inserts/updates a param
        ///// </summary>
        ///// <param name="name">The name</param>
        ///// <param name="value">The value</param>
        ///// <param name="description">The description</param>
        ///// <returns>Setting</returns>
        //public Mis_Play SetParam(string name, string value, string memo)
        //{
        //    var mMisSetting = this.GetSettingByName(name);

        //    if (mMisSetting == null)
        //        mMisSetting = Insert(name, value, memo);
        //    else
        //        mMisSetting = Update(mMisSetting.Id, name, value, memo);

        //    return mMisSetting;
        //}
        
        #region CRUD Methods

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="musicName">music name</param>
        /// <param name="musicUrl">music url</param>
        /// <returns>the new object</returns>
        public Mis_Play Insert(string musicName, string musicUrl)
        {
            var mMisPlay = _context.Mis_Play.CreateObject();
            mMisPlay.MusicName = musicName;
            mMisPlay.MusicUrl = musicUrl;
            mMisPlay.PlayUserId = CRMContext.Current.User.CustomerID.ToString();
            mMisPlay.PlayUserName = CRMContext.Current.User.Username;

            _context.Mis_Play.AddObject(mMisPlay);
            _context.SaveChanges();

            return mMisPlay;
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="id">identifier id</param>
        /// <param name="musicName">music name</param>
        /// <param name="musicUrl">music url</param>
        /// <returns>the new object instance</returns>
        public Mis_Play Update(int id, string musicName, string musicUrl)
        {
            var mMisPlay = GetById(id);
            if (mMisPlay == null) return null;
            if (!_context.IsAttached(mMisPlay))
                _context.Mis_Play.Attach(mMisPlay);

            mMisPlay.MusicName = musicName;
            mMisPlay.MusicUrl = musicUrl;
            //mMisPlay.PlayUserId = CRMContext.Current.User.CustomerID.ToString();
            //mMisPlay.PlayUserName = CRMContext.Current.User.Username;
            _context.SaveChanges();

            return mMisPlay;
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id">identifier id</param>
        public void Delete(int id)
        {
            var mMisPlay = GetById(id);
            if (mMisPlay == null) return;

            if (!_context.IsAttached(mMisPlay))
                _context.Mis_Play.Attach(mMisPlay);
            _context.DeleteObject(mMisPlay);
            _context.SaveChanges();
        }

        #endregion

        #endregion

    }
}
