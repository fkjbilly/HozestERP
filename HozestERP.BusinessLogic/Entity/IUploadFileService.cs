
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
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
    public partial interface IUploadFileService
    {
        #region IUploadFileService成员
        /// <summary>
        /// Insert into UploadFile
        /// </summary>
        /// <param name="uploadfile">UploadFile</param>
    	void InsertUploadFile(UploadFile uploadfile);
    	
        /// <summary>
        /// Update into UploadFile
        /// </summary>
        /// <param name="uploadfile">UploadFile</param>
        void UpdateUploadFile(UploadFile uploadfile);	
    	
        /// <summary>
        /// get to UploadFile list
        /// </summary>
        List<UploadFile> GetUploadFileList();
    	       
    	/// <summary>
    	/// get to UploadFile Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>UploadFile Page List</returns>
    	PagedList<UploadFile> SearchUploadFile(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a UploadFile by UploadFileID
        /// </summary>
        /// <param name="uploadfileid">UploadFile UploadFileID</param>
        /// <returns>UploadFile</returns>   
        UploadFile GetUploadFileByUploadFileID(int uploadfileid);
    
    	/// <summary>
        /// delete UploadFile by UploadFileID
        /// </summary>
        /// <param name="UploadFileID">UploadFile UploadFileID</param>
        void DeleteUploadFile(int uploadfileid);
    	
    	/// <summary>
        /// Batch delete UploadFile by UploadFileID
        /// </summary>
        /// <param name="UploadFileIDs">UploadFile UploadFileID</param>
        void BatchDeleteUploadFile(List<int> uploadfileids);

        #endregion
    }
}
