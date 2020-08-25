/******************************************************************
** Copyright (c) 2008 -2012 呈邦食品
** 创建人:方银朗
** 创建日期:2011-04-19
** 修改人: 方银朗
** 修改日期: 2011-04-19
** 描 述: 方银朗 2011-04-19 创建
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Configuration;

using HozestERP.Common;

namespace HozestERP.BusinessLogic.Notices
{
    public partial interface INoticeService
    {
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <returns>List</returns>
        List<Notice> GetNotices();

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="content">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        PagedList<Notice> GetNotices(string content, int pageIndex, int pageSize);

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="content">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">记录数</param>
        /// <returns>List</returns>
        PagedList<Notice> GetStartNotices(string content, int pageIndex, int pageSize);

        /// <summary>
        /// 获取已发布并且生效的通知
        /// </summary>
        /// <returns>List</returns>
        List<Notice> GetStartNotices();

        /// <summary>
        /// 根据ID获取当前通知信息
        /// </summary>
        /// <param name="noticeId">ID</param>
        /// <returns>notice</returns>
        Notice GetNoticeByID(Guid noticeId);

        
        /// <summary>
        /// Deletes a Notice item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        void DeleteNotice(List<int> noticeIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        Notice InsertNotice(Notice notice);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notice"></param>
        void UpdateNotice(Notice notice);
    }
}
