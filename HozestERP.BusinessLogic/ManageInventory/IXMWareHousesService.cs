
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-25 17:06:12
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMWareHousesService
    {
        #region IXMWareHousesService成员
        /// <summary>
        /// Insert into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
        void InsertXMWareHouses(XMWareHouses xmwarehouses);

        /// <summary>
        /// Update into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
        void UpdateXMWareHouses(XMWareHouses xmwarehouses);

        /// <summary>
        /// get to XMWareHouses list
        /// </summary>
        List<XMWareHouses> GetXMWareHousesList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWareHousesListByParentID(int parentID);

        /// <summary>
        /// get to XMWareHouses Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMWareHouses Page List</returns>
        PagedList<XMWareHouses> SearchXMWareHouses(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMWareHouses by Id
        /// </summary>
        /// <param name="id">XMWareHouses Id</param>
        /// <returns>XMWareHouses</returns>   
        XMWareHouses GetXMWareHousesById(int id);
        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        List<AreaCode> GetProvinceList();
        /// <summary>
        /// 根据省份ID查询对应城市列表
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        List<AreaCode> GetCityList(string ProvinceID);

        List<AreaCode> GetCountyList(string CityID);
        /// <summary>
        /// 根据ProvinceId 查询对应省份
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        AreaCode GetProvinceByProvinceId(string ProvinceID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        AreaCode GetCityInfoByCityId(string cityID, int rank);
        /// <summary>
        /// 根据城市ID和仓库名称进行查询
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <param name="CityID"></param>
        /// <param name="CountyID"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="nickId"></param>
        /// <param name="projectedId"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseList(string ProvinceID, string CityID, string CountyID, string WarehouseName, string nickids, int projectedId, string nickids2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickids"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseListByNickIds(string nickids);
        List<XMWareHouses> GetXMWarehouseListByNickIds(List<int> nickIdList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseListByProjectIds(string projectids);

        List<XMWareHouses> GetXMWarehouseListByProjectId(string projectid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <param name="CityID"></param>
        /// <param name="CountyID"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseListByProjectID(string ProvinceID, string CityID, string CountyID, string WarehouseName, string projectids, int projectId);
        /// <summary> 
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseListByProjectId(int projectId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickID"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseListByNickID(int nickID);
        /// <summary>
        /// 根据相关参数查询仓库列表
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <param name="nickId">店铺ID</param>
        /// <param name="name">仓库名称</param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseByParm(string cityId, int nickId, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesName"></param>
        /// <returns></returns>
        List<XMWareHouses> GetXMWarehouseByWareHousesName(string wareHousesName);
        /// <summary>
        /// delete XMWareHouses by Id
        /// </summary>
        /// <param name="Id">XMWareHouses Id</param>
        void DeleteXMWareHouses(int id);

        /// <summary>
        /// Batch delete XMWareHouses by Id
        /// </summary>
        /// <param name="Ids">XMWareHouses Id</param>
        void BatchDeleteXMWareHouses(List<int> ids);

        #endregion
    }
}
