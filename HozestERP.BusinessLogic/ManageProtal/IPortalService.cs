using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProtal
{
    public partial interface IPortalService
    {
        /// <summary>
        /// 获取用户的桌面
        /// </summary>
        /// <param name="customerid">Sys_Customer identifier</param>
        /// <returns></returns>
        List<PortalColumnNumber> GetPortalColumnNumbers(int customerid);

        /// <summary>
        /// 设置列数
        /// </summary>
        /// <param name="portalColumnNumbers"></param>
        void UpdatePortalColumnsNumber(List<PortalColumnNumber> portalColumnNumbers);

        /// <summary>
        /// 获取可以添加的栏目
        /// </summary>
        /// <param name="customerID">Sys_Customer identifier</param>
        /// <returns></returns>
        List<Portal> GetAddPortalClomuns(int customerID);

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="columnIndex"></param>
        void InsertColumns(List<PortalColumn> columns);

        /// <summary>
        /// 保存栏目
        /// </summary>
        /// <param name="portalColumns"></param>
        void SavePortalColumnsNumber(List<PortalColumn> portalColumns);

        
        /// <summary>
        /// 获取桌面模块信息
        /// </summary>
        /// <param name="portalcolumnid"></param>
        /// <returns></returns>
        PortalColumn GetPortalColumnByID(int portalcolumnid);

        /// <summary>
        /// 删除桌面模块信息
        /// </summary>
        /// <param name="portalcolumnid"></param>
        void DeletePortalColumn(int portalcolumnid);

        
        /// <summary>
        /// 更新桌面模块信息
        /// </summary>
        /// <param name="portalcolumnid"></param>
        /// <param name="columnNumberID"></param>
        /// <param name="position"></param>
        void UpdatePortalColumn(int portalcolumnid, int columnNumberID, int position);

        

        /// <summary>
        /// 桌面栏目设置保存
        /// </summary>
        /// <param name="portalcolumnnumbers"></param>
        /// <param name="customerID">Sys_Customer identifier</param>
        void SavePortalColumnsNumber(List<PortalColumnNumber> portalcolumnnumbers, int customerID);

        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <param name="customerid">Sys_Customer identifier</param>
        /// <returns></returns>
        List<PortalColumnNumber> GetPortalColumnNumberList(int customerid);

        /// <summary>
        /// 根据ID获取portal
        /// </summary>
        /// <param name="portalID"></param>
        Portal GetPortal(int portalID);
    }
}
