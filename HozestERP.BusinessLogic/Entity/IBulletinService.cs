
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
    public partial interface IBulletinService
    {
        #region IBulletinService成员
        /// <summary>
        /// Insert into Bulletin
        /// </summary>
        /// <param name="bulletin">Bulletin</param>
    	void InsertBulletin(Bulletin bulletin);
    	
        /// <summary>
        /// Update into Bulletin
        /// </summary>
        /// <param name="bulletin">Bulletin</param>
        void UpdateBulletin(Bulletin bulletin);	
    	
        /// <summary>
        /// get to Bulletin list
        /// </summary>
        List<Bulletin> GetBulletinList();
    	       
    	/// <summary>
    	/// get to Bulletin Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Bulletin Page List</returns>
    	PagedList<Bulletin> SearchBulletin(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Bulletin by BulletinID
        /// </summary>
        /// <param name="bulletinid">Bulletin BulletinID</param>
        /// <returns>Bulletin</returns>   
        Bulletin GetBulletinByBulletinID(int bulletinid);
    
    	/// <summary>
        /// delete Bulletin by BulletinID
        /// </summary>
        /// <param name="BulletinID">Bulletin BulletinID</param>
        void DeleteBulletin(int bulletinid);
    	
    	/// <summary>
        /// Batch delete Bulletin by BulletinID
        /// </summary>
        /// <param name="BulletinIDs">Bulletin BulletinID</param>
        void BatchDeleteBulletin(List<int> bulletinids);

        #endregion
    }
}
