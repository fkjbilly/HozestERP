
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-25 17:06:17
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMWareHousesService : IXMWareHousesService
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
        public XMWareHousesService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMWareHousesService成员
        /// <summary>
        /// Insert into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
        public void InsertXMWareHouses(XMWareHouses xmwarehouses)
        {
            if (xmwarehouses == null)
                return;

            if (!this._context.IsAttached(xmwarehouses))

                this._context.XMWareHouses.AddObject(xmwarehouses);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
        public void UpdateXMWareHouses(XMWareHouses xmwarehouses)
        {
            if (xmwarehouses == null)
                return;

            if (this._context.IsAttached(xmwarehouses))
                this._context.XMWareHouses.Attach(xmwarehouses);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMWareHouses list
        /// </summary>
        public List<XMWareHouses> GetXMWareHousesList()
        {
            var query = from p in this._context.XMWareHouses
                        where p.isEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWareHousesListByParentID(int parentID)
        {
            var query = from p in this._context.XMWareHouses
                        where p.isEnable == false
                       && p.ParentID == parentID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHousesName"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseByWareHousesName(string wareHousesName)
        {
            var query = from p in this._context.XMWareHouses
                        where p.isEnable == false
                        && p.Name.Contains(wareHousesName)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public List<AreaCode> GetProvinceList()
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == 2
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据省份ID查询对应城市列表
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public List<AreaCode> GetCityList(string ProvinceID)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == 3
                        && p.Preceding == ProvinceID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public List<AreaCode> GetCountyList(string CityID)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == 4
                        && p.Enabled == false
                        && p.Preceding == CityID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public AreaCode GetProvinceByProvinceId(string ProvinceID)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == 2
                        && p.NumberID == ProvinceID
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public AreaCode GetCityInfoByCityId(string cityID, int rank)
        {
            var query = from p in this._context.AreaCodes
                        where p.Rank == rank
                        && p.NumberID.Contains(cityID)
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 根据城市ID和仓库名称进行查询
        /// </summary>
        /// <param name="CityID"></param>
        /// <param name="WarehouseName"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseList(string ProvinceID, string CityID, string CountyID, string WarehouseName, string nickids, int projectedId, string nickids2)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            int?[] nicklist2 = Array.ConvertAll<string, int?>(nickids2.Split(','), delegate(string s) { return int.Parse(s); });     //用户包含店铺列表
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMWareHouses
                        where (WarehouseName == "" || p.Name.Contains(WarehouseName))
                        && (CityID == "" || p.CityId.Contains(CityID))
                        && (ProvinceID == "" || p.CityId.Contains(ProvinceID))
                        && (CountyID == "" || p.CityId == CountyID)
                        && ((nick_id == -1 || nick_id == 99) || nicklist.Contains(p.NickId))
                        && nicklist2.Contains(p.NickId)
                        && (projectedId == -1 || p.ProjectId == projectedId)
                        && p.isEnable == false
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickids"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseListByNickIds(string nickids)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMWareHouses
                        where (nick_id == -1 || nicklist.Contains(p.NickId))
                           && p.isEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMWareHouses> GetXMWarehouseListByNickIds(List<int> nickIdList)
        {
            if (nickIdList.Count > 1)
            {
                List<int?> projectIds = new List<int?>();
                foreach (var Id in nickIdList)
                {
                    var project = IoC.Resolve<IXMNickService>().GetProjectNameByID(Id);
                    if (project != null && !projectIds.Contains(project.Id))
                    {
                        projectIds.Add(project.Id);
                    }
                }

                var query = from p in this._context.XMWareHouses
                            where p.isEnable == false
                            && projectIds.Contains(p.ProjectId)
                            select p;
                return query.ToList();
            }
            else
            {
                List<int?> NickIdList = nickIdList.Select<int, int?>(x => Convert.ToInt32(x)).ToList();
                var query = from p in this._context.XMWareHouses
                            where p.isEnable == false
                            && NickIdList.Contains(p.NickId)
                            select p;
                return query.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseListByProjectIds(string projectids)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            int projectId = -1;
            if (projectlist.Count() > 0 && projectlist[0] != -1)
            {
                projectId = int.Parse(projectlist[0].ToString());
            }
            var query = from p in this._context.XMWareHouses
                        where (projectId == -1 || projectlist.Contains(p.ProjectId))
                         && p.isEnable == false
                         && p.ParentID == 0
                        select p;
            return query.ToList();
        }

        public List<XMWareHouses> GetXMWarehouseListByProjectId(string projectid)
        {
            int Pid = int.Parse(projectid);
            var query = from p in this._context.XMWareHouses
                        where p.ProjectId== Pid
                         && p.isEnable == false
                         && p.ParentID == 0
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <param name="CityID"></param>
        /// <param name="CountyID"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseListByProjectID(string ProvinceID, string CityID, string CountyID, string WarehouseName, string projectids, int projectId)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMWareHouses
                        where (WarehouseName == "" || p.Name.Contains(WarehouseName))
                        && (CityID == "" || p.CityId.Contains(CityID))
                       && (ProvinceID == "" || p.CityId.Contains(ProvinceID))
                       && (CountyID == "" || p.CityId == CountyID)
                       && ((p.NickId == -1 || p.NickId == 99) && projectlist.Contains(p.ProjectId))
                            && (projectId == -1 || p.ProjectId == projectId)
                        && p.isEnable == false
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 根据相关条件查询仓库记录(判断仓库是否存在)
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="nickId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseByParm(string cityId, int nickId, string name)
        {
            var query = from p in this._context.XMWareHouses
                        where p.CityId == cityId
                        && p.NickId == nickId
                        && p.Name.Contains(name)
                        && p.isEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseListByProjectId(int projectId)
        {
            var query = from p in this._context.XMWareHouses
                        where p.isEnable == false
                        && p.ProjectId == projectId
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickId"></param>
        /// <returns></returns>
        public List<XMWareHouses> GetXMWarehouseListByNickID(int nickId)
        {
            var query = from p in this._context.XMWareHouses
                        where p.isEnable == false
                        && p.NickId == nickId
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMWareHouses Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMWareHouses Page List</returns>
        public PagedList<XMWareHouses> SearchXMWareHouses(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMWareHouses
                        orderby p.Id
                        select p;
            return new PagedList<XMWareHouses>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMWareHouses by Id
        /// </summary>
        /// <param name="id">XMWareHouses Id</param>
        /// <returns>XMWareHouses</returns>   
        public XMWareHouses GetXMWareHousesById(int id)
        {
            var query = from p in this._context.XMWareHouses
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMWareHouses by Id
        /// </summary>
        /// <param name="Id">XMWareHouses Id</param>
        public void DeleteXMWareHouses(int id)
        {
            var xmwarehouses = this.GetXMWareHousesById(id);
            if (xmwarehouses == null)
                return;

            if (!this._context.IsAttached(xmwarehouses))
                this._context.XMWareHouses.Attach(xmwarehouses);

            this._context.DeleteObject(xmwarehouses);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMWareHouses by Id
        /// </summary>
        /// <param name="Ids">XMWareHouses Id</param>
        public void BatchDeleteXMWareHouses(List<int> ids)
        {
            var query = from q in _context.XMWareHouses
                        where ids.Contains(q.Id)
                        select q;
            var xmwarehousess = query.ToList();
            foreach (var item in xmwarehousess)
            {
                if (!_context.IsAttached(item))
                    _context.XMWareHouses.Attach(item);

                _context.XMWareHouses.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
