
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
    public partial interface IXMClaimInfoPictureService
    {
        #region IXMClaimInfoPictureService成员
        /// <summary>
        /// Insert into XMClaimInfoPicture
        /// </summary>
        /// <param name="xmclaiminfopicture">XMClaimInfoPicture</param>
    	void InsertXMClaimInfoPicture(XMClaimInfoPicture xmclaiminfopicture);
    	
        /// <summary>
        /// Update into XMClaimInfoPicture
        /// </summary>
        /// <param name="xmclaiminfopicture">XMClaimInfoPicture</param>
        void UpdateXMClaimInfoPicture(XMClaimInfoPicture xmclaiminfopicture);	
    	
        /// <summary>
        /// get to XMClaimInfoPicture list
        /// </summary>
        List<XMClaimInfoPicture> GetXMClaimInfoPictureList();
    	       
    	/// <summary>
    	/// get to XMClaimInfoPicture Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMClaimInfoPicture Page List</returns>
    	PagedList<XMClaimInfoPicture> SearchXMClaimInfoPicture(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMClaimInfoPicture by ID
        /// </summary>
        /// <param name="id">XMClaimInfoPicture ID</param>
        /// <returns>XMClaimInfoPicture</returns>   
        XMClaimInfoPicture GetXMClaimInfoPictureByID(int id);
    
    	/// <summary>
        /// delete XMClaimInfoPicture by ID
        /// </summary>
        /// <param name="ID">XMClaimInfoPicture ID</param>
        void DeleteXMClaimInfoPicture(int id);
    	
    	/// <summary>
        /// Batch delete XMClaimInfoPicture by ID
        /// </summary>
        /// <param name="IDs">XMClaimInfoPicture ID</param>
        void BatchDeleteXMClaimInfoPicture(List<int> ids);

        #endregion
    }
}
