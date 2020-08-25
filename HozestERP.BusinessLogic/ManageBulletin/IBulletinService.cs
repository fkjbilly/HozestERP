using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageBulletin
{
    public partial interface IBulletinService
    {
        /// <summary>
        /// 获取公告列表
        /// </summary> 
        /// <param name="bulletinTitle">标题</param>
        /// <param name="BulletinStatus">状态</param>
        /// <param name="BulletinType">公告类型</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        PagedList<Bulletin> GetBulletin(string bulletinTitle, int bulletinStatus, int bulletinType, DateTime? StartDate, DateTime? EndDate, int pageIndex, int pageSize);

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="bulletinTitle">标题</param>
        /// <param name="bulletinStatus">状态</param>
        /// <param name="bulletinType">公告类型</param>
        /// <param name="StartDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>Bulletin Paged List</returns>
        PagedList<Bulletin> GetBulletinByCustomerID(int customerID, string bulletinTitle, int bulletinStatus, int bulletinType, DateTime? StartDate, DateTime? EndDate, int pageIndex, int pageSize);

        /// <summary>
        /// 根据ID获取公告列表
        /// </summary>
        /// <param name="bulletinID"></param>
        /// <returns>Bulletin</returns>
        Bulletin GetBulletinByBulletinID(int bulletinID);

        /// <summary>
        /// 更新公告信息
        /// </summary>
        /// <param name="Bulletin"></param>
        void UpdateBulletin(Bulletin bulletin);

        /// <summary>
        /// 新增公告信息
        /// </summary>
        /// <param name="Bulletin"></param>
        Bulletin InsertBulletin(Bulletin bulletin);

        /// <summary>
        /// 新增发公告信息的用户
        /// </summary>
        /// <param name="customerGUID"></param>
        /// <param name="bulletinID"></param>
        void AddBulletinCusotmer(int customerID, int bulletinID);

        /// <summary>
        /// 删除公告用户信息列表
        /// </summary>
        /// <param name="bulletinID"></param>
        void DeleteBulletinCusotmer(int bulletinID);

        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="bulletinIDs">公告信息ID</param>
        void DeleteBulletin(List<int> bulletinIDs);

        /// <summary>
        /// 公告发布
        /// </summary>
        /// <param name="bulletinIDs">公告信息ID</param>
        void bulletinReleased(List<int> bulletinIDs);

        /// <summary>
        /// 公告终止
        /// </summary>
        /// <param name="bulletinIDs">公告信息ID</param>
        void bulletinEnd(List<int> bulletinIDs);

        /// <summary>
        /// 获取已发布并且生效的个人通告
        /// </summary>
        /// <returns>List</returns>
        List<Bulletin> GetStartBulletin();

        List<Bulletin> GetOrderBulletin();

        Bulletin GetOrderWarning();

        List<Bulletin> GetProductMin();

        /// <summary>
        /// 获取个人公告列表
        /// </summary> 
        /// <param name="bulletinTitle">标题</param>
        /// <param name="BulletinStatus">状态</param>
        /// <param name="BulletinType">公告类型</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        PagedList<Bulletin> GetBulletins(string bulletinTitle, int bulletinStatus, int bulletinType, DateTime? StartDate, DateTime? EndDate, int pageIndex, int pageSize);

    }
}
