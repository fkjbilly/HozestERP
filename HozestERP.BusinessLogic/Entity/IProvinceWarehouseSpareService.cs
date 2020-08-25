
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
    public partial interface IProvinceWarehouseSpareService
    {
        #region IProvinceWarehouseSpareService成员
        /// <summary>
        /// Insert into ProvinceWarehouseSpare
        /// </summary>
        /// <param name="provincewarehousespare">ProvinceWarehouseSpare</param>
    	void InsertProvinceWarehouseSpare(ProvinceWarehouseSpare provincewarehousespare);
    	
        /// <summary>
        /// Update into ProvinceWarehouseSpare
        /// </summary>
        /// <param name="provincewarehousespare">ProvinceWarehouseSpare</param>
        void UpdateProvinceWarehouseSpare(ProvinceWarehouseSpare provincewarehousespare);	
    	
        /// <summary>
        /// get to ProvinceWarehouseSpare list
        /// </summary>
        List<ProvinceWarehouseSpare> GetProvinceWarehouseSpareList();
    	       
    	/// <summary>
    	/// get to ProvinceWarehouseSpare Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>ProvinceWarehouseSpare Page List</returns>
    	PagedList<ProvinceWarehouseSpare> SearchProvinceWarehouseSpare(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a ProvinceWarehouseSpare by ID
        /// </summary>
        /// <param name="id">ProvinceWarehouseSpare ID</param>
        /// <returns>ProvinceWarehouseSpare</returns>   
        ProvinceWarehouseSpare GetProvinceWarehouseSpareByID(int id);
    
    	/// <summary>
        /// delete ProvinceWarehouseSpare by ID
        /// </summary>
        /// <param name="ID">ProvinceWarehouseSpare ID</param>
        void DeleteProvinceWarehouseSpare(int id);
    	
    	/// <summary>
        /// Batch delete ProvinceWarehouseSpare by ID
        /// </summary>
        /// <param name="IDs">ProvinceWarehouseSpare ID</param>
        void BatchDeleteProvinceWarehouseSpare(List<int> ids);

        #endregion
    }
}
