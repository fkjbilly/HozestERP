
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
    public partial interface IPictureService
    {
        #region IPictureService成员
        /// <summary>
        /// Insert into Picture
        /// </summary>
        /// <param name="picture">Picture</param>
    	void InsertPicture(Picture picture);
    	
        /// <summary>
        /// Update into Picture
        /// </summary>
        /// <param name="picture">Picture</param>
        void UpdatePicture(Picture picture);	
    	
        /// <summary>
        /// get to Picture list
        /// </summary>
        List<Picture> GetPictureList();
    	       
    	/// <summary>
    	/// get to Picture Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Picture Page List</returns>
    	PagedList<Picture> SearchPicture(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Picture by PictureID
        /// </summary>
        /// <param name="pictureid">Picture PictureID</param>
        /// <returns>Picture</returns>   
        Picture GetPictureByPictureID(int pictureid);
    
    	/// <summary>
        /// delete Picture by PictureID
        /// </summary>
        /// <param name="PictureID">Picture PictureID</param>
        void DeletePicture(int pictureid);
    	
    	/// <summary>
        /// Batch delete Picture by PictureID
        /// </summary>
        /// <param name="PictureIDs">Picture PictureID</param>
        void BatchDeletePicture(List<int> pictureids);

        #endregion
    }
}
