
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-23 15:30:16
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMAdvertisingFeeDetailService
    {
        #region IXMAdvertisingFeeDetailService成员
        /// <summary>
        /// Insert into XMAdvertisingFeeDetail
        /// </summary>
        /// <param name="xmadvertisingfeedetail">XMAdvertisingFeeDetail</param>
    	void InsertXMAdvertisingFeeDetail(XMAdvertisingFeeDetail xmadvertisingfeedetail);
    	
        /// <summary>
        /// Update into XMAdvertisingFeeDetail
        /// </summary>
        /// <param name="xmadvertisingfeedetail">XMAdvertisingFeeDetail</param>
        void UpdateXMAdvertisingFeeDetail(XMAdvertisingFeeDetail xmadvertisingfeedetail);	
    	
        /// <summary>
        /// get to XMAdvertisingFeeDetail list
        /// </summary>
        List<XMAdvertisingFeeDetail> GetXMAdvertisingFeeDetailList();
    	       
    	/// <summary>
    	/// get to XMAdvertisingFeeDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMAdvertisingFeeDetail Page List</returns>
    	PagedList<XMAdvertisingFeeDetail> SearchXMAdvertisingFeeDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMAdvertisingFeeDetail by Id
        /// </summary>
        /// <param name="id">XMAdvertisingFeeDetail Id</param>
        /// <returns>XMAdvertisingFeeDetail</returns>   
        XMAdvertisingFeeDetail GetXMAdvertisingFeeDetailById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
       List<XMAdvertisingFeeDetail> GetXMAdvertingFeeDetailByAdvertingFeeID(int fid);
        /// <summary>
        /// 根据广告费主表ID和字段ID查询广告费从表信息
        /// </summary>
        /// <param name="advertingFeeId"></param>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        XMAdvertisingFeeDetail GetXMAdvertisingFeeDetailByAdvertingFeeIdAndFieldID(int advertingFeeId, int fieldId);
    
    	/// <summary>
        /// delete XMAdvertisingFeeDetail by Id
        /// </summary>
        /// <param name="Id">XMAdvertisingFeeDetail Id</param>
        void DeleteXMAdvertisingFeeDetail(int id);
    	
    	/// <summary>
        /// Batch delete XMAdvertisingFeeDetail by Id
        /// </summary>
        /// <param name="Ids">XMAdvertisingFeeDetail Id</param>
        void BatchDeleteXMAdvertisingFeeDetail(List<int> ids);

        #endregion
    }
}
