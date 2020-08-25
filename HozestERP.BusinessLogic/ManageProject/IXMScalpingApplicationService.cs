
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-31 15:51:19
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
    public partial interface IXMScalpingApplicationService
    {
        #region IXMScalpingApplicationService成员
        /// <summary>
        /// Insert into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
    	void InsertXMScalpingApplication(XMScalpingApplication xmscalpingapplication);
    	
        /// <summary>
        /// Update into XMScalpingApplication
        /// </summary>
        /// <param name="xmscalpingapplication">XMScalpingApplication</param>
        void UpdateXMScalpingApplication(XMScalpingApplication xmscalpingapplication);	
    	
        /// <summary>
        /// get to XMScalpingApplication list
        /// </summary>
        List<XMScalpingApplication> GetXMScalpingApplicationList();
    	       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalpingApplication Page List</returns>
        PagedList<XMScalpingApplication> SearchXMScalpingApplication(int PlatformTypeId, List<int> NickId, string ScalpingCode, int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="scalpingid">XMScalpingApplication ScalpingId</param>
        /// <returns>XMScalpingApplication</returns>   
        XMScalpingApplication GetXMScalpingApplicationByScalpingId(int scalpingid);
    

        /// <summary>
        /// 根据刷单单号查询(查询刷单单号 部门审核通过的)
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        List<XMScalpingApplication> GetXMScalpingApplicationByScalpingCode(string ScalpingCode);

        /// <summary>
        /// 根据刷单单号查询 (部门审核通过的刷单信息)
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        List<XMScalpingApplication> GetXMScalpingApplicationByEqualsScalpingCode(string ScalpingCode);

        /// <summary>
        /// 根据刷单单号关联暂支单查询（查询暂支单中不存在的刷单单号）
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        List<XMScalpingApplication> GetXMScalpingApplicationByScalpingCodeList(string ScalpingCode);


        /// <summary>
        /// 根据刷单单号关联暂支单查询（查询暂支单中暂支状态是使用中的数据）
        /// </summary>
        /// <param name="ScalpingCode">刷单单号</param>
        /// <returns></returns>
        List<XMScalpingApplication> GetXMScalpingApplicationByAdvanceState(string ScalpingCode);


    	/// <summary>
        /// delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingId">XMScalpingApplication ScalpingId</param>
        void DeleteXMScalpingApplication(int scalpingid);
    	
    	/// <summary>
        /// Batch delete XMScalpingApplication by ScalpingId
        /// </summary>
        /// <param name="ScalpingIds">XMScalpingApplication ScalpingId</param>
        void BatchDeleteXMScalpingApplication(List<int> scalpingids);

        #endregion
    }
}
