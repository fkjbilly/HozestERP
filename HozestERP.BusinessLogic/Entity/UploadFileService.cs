
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
    public partial class UploadFileService: IUploadFileService
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
    	public UploadFileService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IUploadFileService成员
        /// <summary>
        /// Insert into UploadFile
        /// </summary>
        /// <param name="uploadfile">UploadFile</param>
    	public void InsertUploadFile(UploadFile uploadfile)
    	{	
            if (uploadfile == null)
                return;
    
            if (!this._context.IsAttached(uploadfile))
    			
                this._context.UploadFiles.AddObject(uploadfile);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into UploadFile
        /// </summary>
        /// <param name="uploadfile">UploadFile</param>
        public void UpdateUploadFile(UploadFile uploadfile)
        {
            if (uploadfile == null)
                return;
    
            if (this._context.IsAttached(uploadfile))
                this._context.UploadFiles.Attach(uploadfile);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to UploadFile list
        /// </summary>
        public List<UploadFile> GetUploadFileList()
        {		
            var query = from p in this._context.UploadFiles
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to UploadFile Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>UploadFile Page List</returns>
        public PagedList<UploadFile> SearchUploadFile(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.UploadFiles
                        orderby p.UploadFileID
                        select p;
            return new PagedList<UploadFile>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a UploadFile by UploadFileID
        /// </summary>
        /// <param name="uploadfileid">UploadFile UploadFileID</param>
        /// <returns>UploadFile</returns>   
        public UploadFile GetUploadFileByUploadFileID(int uploadfileid)
        {
            var query = from p in this._context.UploadFiles
                        where p.UploadFileID.Equals(uploadfileid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete UploadFile by UploadFileID
        /// </summary>
        /// <param name="UploadFileID">UploadFile UploadFileID</param>
        public void DeleteUploadFile(int uploadfileid)
        {
            var uploadfile = this.GetUploadFileByUploadFileID(uploadfileid);
            if (uploadfile == null)
                return;
    
            if (!this._context.IsAttached(uploadfile))
                this._context.UploadFiles.Attach(uploadfile);
    
            this._context.DeleteObject(uploadfile);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete UploadFile by UploadFileID
        /// </summary>
        /// <param name="UploadFileIDs">UploadFile UploadFileID</param>
        public void BatchDeleteUploadFile(List<int> uploadfileids)
        {
    	   var query = from q in _context.UploadFiles
                    where uploadfileids.Contains(q.UploadFileID)
                    select q;
            var uploadfiles = query.ToList();
            foreach (var item in uploadfiles)
            {
                if (!_context.IsAttached(item))
                    _context.UploadFiles.Attach(item);  
    
                _context.UploadFiles.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
