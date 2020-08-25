
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 15:24:22
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
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMNickService
    {
        #region IXMNickService成员

        /// <summary>
        /// 分页获取所有店铺
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        PagedList<XMNick> GetXMNickList(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// 根据店铺名称、是否在运营查询
        /// </summary>
        /// <param name="nick">店铺名称</param>
        /// <param name="IsEnable">是否在运营</param>
        /// <param name="ProjectId">项目</param>
        /// <returns></returns>
        List<XMNick> GetXMNickList(string nick, int IsEnable, int ProjectId);

        List<XMNick> GetXMNickListByPlatformType(int PlatformTypeId);

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="nick">店铺名称</param>
        /// <param name="shopManager">店长</param>
        /// <param name="customerRoleID">角色id</param>
        /// <returns></returns>
        List<XMNick> GetXMNickListByConditon(string nick, string shopManager, int customerRoleID);

        XMProject GetProjectNameByID(int NickId);

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="customerID">用户id</param>
        /// <param name="nick"></param>
        /// <param name="shopManager"></param>
        /// <param name="customerRoleID"></param>
        /// <returns></returns>
        List<XMNick> GetMyNickListByConditon(int customerID, string nick, string shopManager, int customerRoleID);


        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="customerID">用户id</param>
        /// <param name="nick"></param> 
        /// <returns></returns>
        List<XMNick> GetMyNickListByCustomer(int customerID, string nick, int CustomerTypeID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        List<XMNick> GetMyNickListByCustomerID(int customerID);
        /// <summary>
        /// 获取所有的可用店铺
        /// </summary>
        /// <returns></returns>
        List<XMNick> GetXMNickList();

        /// <summary>
        /// 按店铺名称获取数据
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        List<XMNick> GetXMNickListByNick(string nick);

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="customerID">用户id</param>
        /// <param name="nick"></param> 
        /// <returns></returns>
        List<XMNick> GetMyNickListByCustomerList(int customerID, string nick, int ProjectId);

        List<XMNick> GetMyNickListByProjectNick(int PlatformType, int ProjectId);

        /// <summary>
        /// 根据项目id查询包含的所以店铺
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        List<XMNick> GetXMNickListByProjectId(List<int> ProjectId);

        List<XMNick> GetXMNickListByProjectId(int ProjectId);

        /// <summary>
        /// 根据项目Id、项目类型Id查询
        /// </summary>
        /// <param name="ProjectId">项目Id</param>
        /// <param name="ProjectTypeId">项目类型</param>
        /// <returns></returns>
        List<XMNick> GetXMNickListByProjectId(int ProjectId, int ProjectTypeId);


        /// <summary>
        /// 根据人员查询项目
        /// </summary>
        List<XMNick> GetXMProjectListSS(int customerId, int ProjectName);

        /// <summary>
        /// 通过人员类型获取业务员(项目部)
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="customerTypeID">人员类型ID</param>
        CustomerInfo GetProjectXMNickCustomer(int nickId, int customerTypeID);

        /// <summary>
        /// 根据id获取店铺数据
        /// </summary>
        /// <param name="nickID">店铺id</param>
        /// <returns></returns>
        XMNick GetXMNickByID(int nickID);

        /// <summary>
        /// 更新店铺记录
        /// </summary>
        /// <param name="xMNick"></param>
        void UpdateXMNick(XMNick xMNick);

        /// <summary>
        /// 新增店铺记录
        /// </summary>
        /// <param name="xMNick"></param>
        void InsertXMNick(XMNick xMNick);

        /// <summary>
        /// 删除店铺记录
        /// </summary>
        /// <param name="xMNick"></param>
        void DeleteXMNick(XMNick xMNick);

        /// <summary>
        /// 根据店铺id获取店铺名称
        /// </summary>
        /// <param name="NickID"></param>
        /// <returns></returns>
        string ReturnNickNameByID(int NickID);
        #endregion
    }
}
