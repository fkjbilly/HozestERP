
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Entity
{
    public partial class PictureService: IPictureService
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
    	public PictureService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IPictureService成员
        /// <summary>
        /// Insert into Picture
        /// </summary>
        /// <param name="picture">Picture</param>
    	public void InsertPicture(Picture picture)
    	{	
            if (picture == null)
                return;
    
            if (!this._context.IsAttached(picture))
    			
                this._context.Pictures.AddObject(picture);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Picture
        /// </summary>
        /// <param name="picture">Picture</param>
        public void UpdatePicture(Picture picture)
        {
            if (picture == null)
                return;
    
            if (this._context.IsAttached(picture))
                this._context.Pictures.Attach(picture);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Picture list
        /// </summary>
        public List<Picture> GetPictureList()
        {		
            var query = from p in this._context.Pictures
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Picture Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Picture Page List</returns>
        public PagedList<Picture> SearchPicture(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Pictures
                        orderby p.PictureID
                        select p;
            return new PagedList<Picture>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Picture by PictureID
        /// </summary>
        /// <param name="pictureid">Picture PictureID</param>
        /// <returns>Picture</returns>   
        public Picture GetPictureByPictureID(int pictureid)
        {
            var query = from p in this._context.Pictures
                        where p.PictureID.Equals(pictureid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Picture by PictureID
        /// </summary>
        /// <param name="PictureID">Picture PictureID</param>
        public void DeletePicture(int pictureid)
        {
            var picture = this.GetPictureByPictureID(pictureid);
            if (picture == null)
                return;
    
            if (!this._context.IsAttached(picture))
                this._context.Pictures.Attach(picture);
    
            this._context.DeleteObject(picture);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Picture by PictureID
        /// </summary>
        /// <param name="PictureIDs">Picture PictureID</param>
        public void BatchDeletePicture(List<int> pictureids)
        {
    	   var query = from q in _context.Pictures
                    where pictureids.Contains(q.PictureID)
                    select q;
            var pictures = query.ToList();
            foreach (var item in pictures)
            {
                if (!_context.IsAttached(item))
                    _context.Pictures.Attach(item);  
    
                _context.Pictures.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
