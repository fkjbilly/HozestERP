
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-06-07 14:27:58
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial interface IProvinceWarehouseService
    {
        #region IProvinceWarehouseService成员
        /// <summary>
        /// Insert into ProvinceWarehouse
        /// </summary>
        /// <param name="provincewarehouse">ProvinceWarehouse</param>
        void InsertProvinceWarehouse(ProvinceWarehouse provincewarehouse);

        /// <summary>
        /// Update into ProvinceWarehouse
        /// </summary>
        /// <param name="provincewarehouse">ProvinceWarehouse</param>
        void UpdateProvinceWarehouse(ProvinceWarehouse provincewarehouse);

        /// <summary>
        /// get to ProvinceWarehouse list
        /// </summary>
        List<ProvinceWarehouse> GetProvinceWarehouseList();

        List<ProvinceWarehouse> GetProvinceWarehouseListByWarehouseID(int WarehouseID);

        List<ProvinceWarehouse> GetProvinceWarehouseListByParam(int WarehouseID, string ProvinceName);

        CodeList GetWarehouseName(int CodeID);

        /// <summary>
        /// get to ProvinceWarehouse Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ProvinceWarehouse Page List</returns>
        PagedList<ProvinceWarehouse> SearchProvinceWarehouse(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a ProvinceWarehouse by ID
        /// </summary>
        /// <param name="id">ProvinceWarehouse ID</param>
        /// <returns>ProvinceWarehouse</returns>   
        ProvinceWarehouse GetProvinceWarehouseByID(int id);

        /// <summary>
        /// delete ProvinceWarehouse by ID
        /// </summary>
        /// <param name="ID">ProvinceWarehouse ID</param>
        void DeleteProvinceWarehouse(int id);

        /// <summary>
        /// Batch delete ProvinceWarehouse by ID
        /// </summary>
        /// <param name="IDs">ProvinceWarehouse ID</param>
        void BatchDeleteProvinceWarehouse(List<int> ids);

        #endregion
    }
}
