
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-23 15:24:23
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
    public partial class XMNickService : IXMNickService
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
        public XMNickService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMNickService成员

        /// <summary>
        /// 分页获取所有店铺
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public PagedList<XMNick> GetXMNickList(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from x in this._context.XMNicks
                        where x.isEnable
                        orderby x.createTime
                        select x;
            return new PagedList<XMNick>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// 根据店铺名称、是否在运营查询
        /// </summary>
        /// <param name="nick">店铺名称</param>
        /// <param name="IsEnable">是否在运营</param>
        /// <param name="ProjectId">项目Id</param>
        /// <returns></returns>
        public List<XMNick> GetXMNickList(string nick, int IsEnable, int ProjectId)
        {
            var query = from p in this._context.XMNicks
                        where p.nick.Contains(nick)
                        && (ProjectId == -1 || p.ProjectId == ProjectId)
                         && (IsEnable == -1 || p.isEnable.Equals(IsEnable == 0 ? false : true))
                        select p;
            return query.ToList();

        }

        public List<XMNick> GetXMNickListByPlatformType(int PlatformTypeId)
        {
            var query = from p in this._context.XMNicks
                        where p.isEnable == true
                        && p.PlatformTypeId == PlatformTypeId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="nick">店铺名称</param>
        /// <param name="shopManager">店长</param>
        /// <param name="customerRoleID">角色id</param>
        /// <returns></returns>
        public List<XMNick> GetXMNickListByConditon(string nick, string shopManager, int customerRoleID)
        {
            string sql = @"select * from XM_Nick
            where nick like {0} ";//  and isEnable='true'
            if (customerRoleID != 0)
                sql += " and customerRoleID=" + customerRoleID;
            var nickList = this._context.ExecuteStoreQuery<XMNick>(sql, "%" + nick + "%");
            return nickList.ToList();
        }

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="customerID">用户id</param>
        /// <param name="nick"></param>
        /// <param name="shopManager"></param>
        /// <param name="customerRoleID"></param>
        /// <returns></returns>
        public List<XMNick> GetMyNickListByConditon(int customerID, string nick, string shopManager, int customerRoleID)
        {
            string sql = @"select * from XM_Nick n
                        inner join Sys_Customer_CustomerRole_Mapping m
                        on n.customerRoleID=m.CustomerRoleID
                        where m.CustomerID={0}  and n.nick like {1} and n.shopManager like {2}  and n.isEnable='true'";
            if (customerRoleID != 0)
                sql += " and n.customerRoleID=" + customerRoleID;
            var nickList = this._context.ExecuteStoreQuery<XMNick>(sql, customerID, "%" + nick + "%", "%" + shopManager + "%");
            return nickList.ToList();
        }

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="customerID">用户id</param>
        /// <param name="nick"></param> 
        /// <returns></returns>
        public List<XMNick> GetMyNickListByCustomer(int customerID, string nick, int CustomerTypeID)
        {

            string sql = @"select *  from XM_Nick n where nick_id in(select NickId from  
                            dbo.XM_Nick_Customer_Mapping m where  m.CustomerId={0}  ";
            if (CustomerTypeID != 0)
            {
                sql += "and m.CustomerTypeID=" + CustomerTypeID;
            }

            sql += " group by m.NickId) and n.nick like  {1} and isEnable='true'";


            var nickList = this._context.ExecuteStoreQuery<XMNick>(sql, customerID, "%" + nick + "%");//, "%" + shopManager + "%"
            return nickList.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<XMNick> GetMyNickListByCustomerID(int customerID)
        {
            string sql = @"select *  from XM_Nick n where nick_id in(select NickId from  
                            dbo.XM_Nick_Customer_Mapping m where  m.CustomerId={0}  ";
            sql += " group by m.NickId)  and isEnable='true'";
            var nickList = this._context.ExecuteStoreQuery<XMNick>(sql, customerID);
            return nickList.ToList();
        }

        /// <summary>
        /// 获取所有的可用店铺
        /// </summary>
        /// <returns></returns>
        public List<XMNick> GetXMNickList()
        {
            var query = from m in this._context.XMNicks // where m.isEnable
                        where m.isEnable == true
                        select m;
            return query.ToList();
        }

        public XMProject GetProjectNameByID(int NickId)
        {
            var query = from m in this._context.XMNicks
                        join p in this._context.XMProjects
                        on m.ProjectId equals p.Id
                        where m.nick_id == NickId
                        select p;
            return query.Single();
        }

        /// <summary>
        /// 按店铺名称获取数据
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public List<XMNick> GetXMNickListByNick(string nick)
        {
            var query = from m in this._context.XMNicks
                        where m.nick.Equals(nick)//m.isEnable &&
                        select m;
            return query.ToList();
        }

        /// <summary>
        /// 按条件获取店铺数据
        /// </summary>
        /// <param name="customerID">用户id</param>
        /// <param name="nick"></param> 
        /// <returns></returns>
        public List<XMNick> GetMyNickListByCustomerList(int customerID, string nick, int ProjectId)
        {
            string sql = @"select *  from XM_Nick n where nick_id in(select NickId from  
                            dbo.XM_Nick_Customer_Mapping m where  m.CustomerId={0}   
                            group by m.NickId) and n.nick like  {1} and isEnable='true'  and n.ProjectId={2} ";
            var nickList = this._context.ExecuteStoreQuery<XMNick>(sql, customerID, "%" + nick + "%", ProjectId);//, "%" + shopManager + "%"
            return nickList.ToList();
        }

        /// <summary>
        /// 根据项目id查询包含的所以店铺
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public List<XMNick> GetXMNickListByProjectId(List<int> ProjectId)
        {
            var query = from m in this._context.XMNicks
                        where ProjectId.Contains(m.ProjectId.Value)
                        && m.isEnable == true
                        select m;
            return query.ToList();
        }

        public List<XMNick> GetMyNickListByProjectNick(int PlatformType, int ProjectId)
        {
            var query = from m in this._context.XMNicks
                        where (ProjectId == -1 || m.ProjectId == ProjectId)
                        && m.PlatformTypeId == PlatformType
                        && m.isEnable == true
                        select m;
            return query.ToList();
        }

        /// <summary>
        /// 根据项目id查询包含的所以店铺
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public List<XMNick> GetXMNickListByProjectId(int ProjectId)
        {
            var query = from m in this._context.XMNicks
                        where ProjectId.Equals(m.ProjectId.Value)
                        && m.isEnable == true
                        select m;
            return query.ToList();
        }


        /// <summary>
        /// 根据项目Id、项目类型Id查询
        /// </summary>
        /// <param name="ProjectId">项目Id</param>
        /// <param name="ProjectTypeId">项目类型</param>
        /// <returns></returns>
        public List<XMNick> GetXMNickListByProjectId(int ProjectId, int ProjectTypeId)
        {
            var query = from m in this._context.XMNicks
                        join c in this._context.XMProjects
                        on m.ProjectId equals c.Id
                        where (ProjectId == -1 || m.ProjectId == ProjectId)
                        && (ProjectTypeId == -1 || c.ProjectTypeId == ProjectTypeId)
                        && m.isEnable == true
                        select m;
            return query.ToList();
        }

        /// <summary>
        /// 根据人员查询项目
        /// </summary>
        public List<XMNick> GetXMProjectListSS(int customerId, int ProjectName)
        {

            IQueryable<XMNick> query = from b in this._context.XMNicks
                                       join a in this._context.XMProjects
                                       on b.ProjectId equals a.Id
                                       into JoinedEmpDept
                                       from a in JoinedEmpDept.DefaultIfEmpty()
                                       join c in this._context.XMNickCustomerMappings
                                       on b.nick_id equals c.NickId
                                       into JoinedEmpDept2
                                       from c in JoinedEmpDept2.DefaultIfEmpty()
                                       where (a.customerId == customerId || c.CustomerID == customerId)
                                       && a.IsEnable == true && b.isEnable == true && (a.ProjectTypeId == ProjectName || ProjectName == 0)
                                       //group b by new { nick = b.nick, nick_id = b.nick_id } into p
                                       select b;
            return new List<XMNick>(query.ToList().Distinct());
        }

        /// <summary>
        /// 通过人员类型获取业务员(项目部)
        /// </summary>
        /// <param name="nickId">合同ID</param>
        /// <param name="customerTypeID">人员类型ID</param>
        public CustomerInfo GetProjectXMNickCustomer(int nickId, int customerTypeID)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        join d in this._context.CustomerInfoes on p.CustomerID equals d.CustomerID
                        where p.CustomerTypeID == customerTypeID && p.NickId == nickId
                        select d;
            return query.SingleOrDefault();

        }
        /// <summary>
        /// 根据id获取店铺数据
        /// </summary>
        /// <param name="nickID">店铺id</param>
        /// <returns></returns>
        public XMNick GetXMNickByID(int nickID)
        {
            var query = from x in this._context.XMNicks
                        where x.nick_id.Equals(nickID)
                        select x;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 更新店铺记录
        /// </summary>
        /// <param name="xMNick"></param>
        public void UpdateXMNick(XMNick xMNick)
        {
            if (xMNick == null)
                throw new ArgumentNullException("xMNick");

            if (!_context.IsAttached(xMNick))
                _context.XMNicks.Attach(xMNick);

            _context.SaveChanges();
        }


        /// <summary>
        /// 新增店铺记录
        /// </summary>
        /// <param name="xMNick"></param>
        public void InsertXMNick(XMNick xMNick)
        {
            if (xMNick == null)
                throw new ArgumentNullException("xMNick");

            _context.XMNicks.AddObject(xMNick);
            _context.SaveChanges();
        }

        /// <summary>
        /// 删除店铺记录
        /// </summary>
        /// <param name="xMNick"></param>
        public void DeleteXMNick(XMNick xMNick)
        {
            if (xMNick == null)
                throw new ArgumentNullException("xMNick");
            _context.XMNicks.DeleteObject(xMNick);
            _context.SaveChanges();
        }

        /// <summary>
        /// 根据店铺id获取店铺名称
        /// </summary>
        /// <param name="NickID"></param>
        /// <returns></returns>
        public string ReturnNickNameByID(int NickID)
        {
            var query = from p in this._context.XMNicks
                        where p.nick_id == NickID
                        select p;
            if (query.ToList().Count != 0)
            {
                return query.ToList().FirstOrDefault().nick;
            }
            else
            {
                return "";
            }
        }

        #endregion
    }
}
