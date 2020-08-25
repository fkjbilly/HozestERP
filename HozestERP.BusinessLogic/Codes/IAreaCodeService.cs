using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HozestERP.Common;

namespace HozestERP.BusinessLogic.Codes
{
    public partial interface IAreaCodeService
    {
        /// <summary>
        /// 根据父节点选择列表
        /// </summary>
        /// <returns>SAreaCode list</returns>
        PagedList<AreaCode> GetAreaCodeByParentID(string prepath, int paramPageIndex, int paramPageSize);

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <returns></returns>
        List<AreaCode> GetAreaCode();
        
        /// <summary>
        /// 获得区域(启用)
        /// </summary>
        /// <returns></returns>
        List<AreaCode> GetAreaCode(int rank, string preceding);

        List<AreaCode> GetAreaCodeByRank(int rank);

        List<AreaCode> GetAreaCodeByCity(int rank, string city);

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <returns></returns>
        List<AreaCode> GetAreaCode(string preceding);

        /// <summary>
        /// 根据number获取区域
        /// </summary>
        /// <param name="numberID"></param>
        /// <returns></returns>
        AreaCode GetAreaByNumberID(string numberID);
        /// <summary>
        /// 根据省份查询
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        AreaCode GetAreaByCity(string city);
        /// <summary>
        /// 根据ID获得区域信息
        /// </summary>
        /// <param name="xmID"></param>
        /// <returns></returns>
        AreaCode GetAreaByXmID(int xmID);

        /// <summary>
        /// 根据NumberID获得区域信息
        /// </summary>
        /// <param name="NumberID"></param>
        /// <returns></returns>
        AreaCode GetAreaByXmID(string NumberID);

        void UpdateAreaCode(AreaCode entity);

        void InsertAreaCode(AreaCode entity);

        /// <summary>
        /// 批量生效区域
        /// </summary>
        /// <param name="areaIDs">areaIDs</param>
        void MarkAreasBatchPublished(string areaIDs,string noxmlids);
    }
}
