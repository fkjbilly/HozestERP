
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:21
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
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMInventoryInfoService : IXMInventoryInfoService
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
        public XMInventoryInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMInventoryInfoService成员
        /// <summary>
        /// Insert into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
        public void InsertXMInventoryInfo(XMInventoryInfo xminventoryinfo)
        {
            if (xminventoryinfo == null)
                return;

            if (!this._context.IsAttached(xminventoryinfo))

                this._context.XMInventoryInfoes.AddObject(xminventoryinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMInventoryInfo
        /// </summary>
        /// <param name="xminventoryinfo">XMInventoryInfo</param>
        public void UpdateXMInventoryInfo(XMInventoryInfo xminventoryinfo)
        {
            if (xminventoryinfo == null)
                return;

            if (this._context.IsAttached(xminventoryinfo))
                this._context.XMInventoryInfoes.Attach(xminventoryinfo);

            this._context.SaveChanges();
        }
        /// <summary>
        /// get to XMInventoryInfo list
        /// </summary>
        public List<XMInventoryInfo> GetXMInventoryInfoList()
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMInventoryInfo> GetXMInventoryInfoListByWfIds(List<int> Ids)
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.IsEnable == false
                        && Ids.Contains(p.WfId)
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="wareHoursesId"></param>
        private int GetSaleCount(string begin, string end, int wareHoursesId, string platformMerchantCode)
        {
            int saleCount = 0;
            var saleDelivery = IoC.Resolve<IXMSaleDeliveryService>().GetXMSaleDeliveryListByParm(begin, end, wareHoursesId);
            if (saleDelivery != null && saleDelivery.Count > 0)
            {
                foreach (XMSaleDelivery delivery in saleDelivery)
                {
                    var saleDelvieryPorductDetai = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsBySaleDeliveryID(delivery.Id);
                    if (saleDelvieryPorductDetai != null && saleDelvieryPorductDetai.Count > 0)
                    {
                        foreach (XMSaleDeliveryProductDetails detail in saleDelvieryPorductDetai)
                        {
                            if (detail.PlatformMerchantCode == platformMerchantCode)
                            {
                                saleCount += detail.SaleCount.Value;
                            }
                        }
                    }
                }
            }
            return saleCount;
        }

        /// <summary>
        /// 库存预警定时程序
        /// </summary>
        public void TimingInventoryWarning() 
        {

        }

        /// <summary>
        /// 定时程序   根据条件判断当前库存产品滞销情况
        /// </summary>
        public void TimingGetInventoryStatus()
        {
            int day1 = 0;
            int day2 = 0;
            decimal max2 = 0;
            decimal min1 = 0;
            int saleCount1 = 0;
            int saleCount2 = 0;
            var saleDay1 = IoC.Resolve<ISettingManager>().GetSettingByName("Inventory.Sale.NumberOfDays1");            //几天 销量天数1
            var saleDay2 = IoC.Resolve<ISettingManager>().GetSettingByName("Inventory.Sale.NumberOfDays2");            //几天 销售天数2
            var min = IoC.Resolve<ISettingManager>().GetSettingByName("Inventory.Sale.MinimumCoefficient");               //条件最小系数  
            var max = IoC.Resolve<ISettingManager>().GetSettingByName("Inventory.Sale.MaximumCoefficient");              //条件最大系数
            List<XMInventoryInfo> List = IoC.Resolve<XMInventoryInfoService>().GetXMInventoryInfoList();
            if (List != null && List.Count > 0)
            {
                //遍历所有库存产品
                foreach (XMInventoryInfo Info in List)
                {
                    //获取
                    if (saleDay1 != null)             //销量天数1（15天）
                    {
                        if (int.TryParse(saleDay1.Value.Trim(), out day1) && saleDay1.Value.Trim() != "0")
                        {
                            day1 = int.Parse(saleDay1.Value.Trim());
                            DateTime End = DateTime.Parse(DateTime.Now.ToShortDateString());
                            DateTime Begin = End.AddDays(-day1);
                            saleCount1 = GetSaleCount(Begin.ToString(), End.ToString(), Info.WfId, Info.PlatformMerchantCode);     //销售天数1   15天
                            if (saleCount1 != 0 && Info.StockNumber != 0 && Info.StockNumber >= saleCount1)       //表示商品滞销，标红
                            {
                                //更新产品库存状态
                                Info.SaleStatus = 1000;    //商品滞销
                                Info.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(Info);
                            }
                            if (saleCount1 != 0 && Info.StockNumber != 0 && Info.StockNumber < saleCount1)     //表示商品脱销，应入仓
                            {
                                //更新产品库存状态
                                Info.SaleStatus = 1001;    //商品脱销
                                Info.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(Info);
                            }
                            if (saleCount1 == 0 && Info.StockNumber != 0)   //表示商品滞销，
                            {
                                //更新产品库存状态
                                Info.SaleStatus = 1000;    //商品滞销
                                Info.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(Info);
                            }
                            if (Info.StockNumber == 0 && saleCount1 != 0)    //表示商品脱销，应入仓
                            {
                                //更新产品库存状态
                                Info.SaleStatus = 1001;    //商品脱销
                                Info.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(Info);
                            }
                            if (saleCount1 == 0 && Info.StockNumber == 0)     //   无销量 无库存  标黄
                            {
                                Info.SaleStatus = 1002;    //无销量 无库存
                                Info.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(Info);
                            }
                        }
                    }


                    if (saleDay2 != null)                         //销量数量2（7天）
                    {
                        if (int.TryParse(saleDay2.Value.Trim(), out day2) && saleDay2.Value.Trim() != "0")
                        {
                            day2 = int.Parse(saleDay2.Value.Trim());
                            DateTime End = DateTime.Parse(DateTime.Now.ToShortDateString());
                            DateTime Begin = End.AddDays(-day2);
                            saleCount2 = GetSaleCount(Begin.ToString(), End.ToString(), Info.WfId, Info.PlatformMerchantCode);     //销售天数2   7天
                        }
                    }

                    //根据条件公式 计算可入仓量
                    //入仓量=（现有库存M/15天销量N）*7天销量
                    int storageCount = 0;    //可入仓量
                    if (saleCount1 != 0)
                    {
                        if ((Info.StockNumber / saleCount1) >= decimal.Parse(min.Value) && (Info.StockNumber / saleCount1) <= decimal.Parse(max.Value) && Info.StockNumber != 0 && saleCount1 != 0)
                        {
                            storageCount = (int)((Info.StockNumber.Value / saleCount1) * saleCount2);
                        }
                        if ((Info.StockNumber / saleCount1) < decimal.Parse(min.Value) && Info.StockNumber != 0 && saleCount1 != 0)
                        {
                            storageCount = (int)(decimal.Parse(max.Value) * saleCount2);
                        }
                        if (Info.StockNumber / saleCount1 > decimal.Parse(max.Value) && Info.StockNumber != 0 && saleCount1 != 0)
                        {
                            storageCount = 0;
                        }
                    }
                    if (Info.StockNumber == 0 && saleCount1 != 0)
                    {
                        storageCount = (int)(decimal.Parse(max.Value) * saleCount2);
                    }
                    if (saleCount1 == 0 && Info.StockNumber != 0)
                    {
                        storageCount = 0;
                    }
                    //更新推荐入库数量
                    Info.CanStorageCount = storageCount;      //更新推荐入库数量
                    Info.UpdateDate = DateTime.Now;
                    IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(Info);

                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wareHouesesID"></param>
        /// <returns></returns>
        public List<XMInventoryInfo> GetXMInventoryInfoListByWareHouesesID(int wareHouesesID)
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.IsEnable == false
                        && p.WfId == wareHouesesID
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get to XMInventoryInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryInfo Page List</returns>
        public PagedList<XMInventoryInfo> SearchXMInventoryInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickID"></param>
        /// <param name="wareHoursesID"></param>
        /// <returns></returns>
        public List<XMInventoryInfo> GetXMInventoryInfoByParm(string platformCode, string productName, string nickids, string wareHoursesID, int projectId, string nickids2, int saleStatus, bool isParent)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nickIdlist.Count() > 0 && nickIdlist[0] != -1)
            {
                nick_id = int.Parse(nickIdlist[0].ToString());
            }
            int?[] nickIdlist2 = Array.ConvertAll<string, int?>(nickids2.Split(','), delegate(string s) { return int.Parse(s); });

            int?[] wareHoursesIDlist = Array.ConvertAll<string, int?>(wareHoursesID.Split(','), delegate(string s) { return int.Parse(s); });
            if (isParent == true)
            {
                var query = from p in this._context.XMInventoryInfoes
                            join t in this._context.XMWareHouses
                            on p.WfId equals t.Id
                            join m in this._context.XMProducts
                            on p.PrductId equals m.Id
                            where p.IsEnable == false
                                  && (platformCode == "" || p.PlatformMerchantCode.Contains(platformCode))
                                 && (productName == "" || m.ProductName.Contains(productName))
                               && wareHoursesIDlist.Contains(p.WfId)
                               && (saleStatus == -1 || p.SaleStatus == saleStatus)
                              && t.ParentID == 0
                            select p;
                return query.ToList();
            }
            else
            {
                var query = from p in this._context.XMInventoryInfoes
                            join t in this._context.XMWareHouses
                            on p.WfId equals t.Id
                            join m in this._context.XMProducts
                            on p.PrductId equals m.Id
                            where p.IsEnable == false
                                  && (platformCode == "" || p.PlatformMerchantCode.Contains(platformCode))
                                 && (productName == "" || m.ProductName.Contains(productName))
                                 && (nick_id == -1 || nickIdlist.Contains(t.NickId))
                                 && nickIdlist2.Contains(t.NickId)
                               && (wareHoursesID == "-1" || p.WfId.ToString() == wareHoursesID)
                               && (projectId == -1 || t.ProjectId == projectId)
                               && (saleStatus == -1 || p.SaleStatus == saleStatus)
                            select p;
                return query.ToList();
            }
        }
        /// <summary>
        /// nickid==-1  &&  projectid!=-1
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickids"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMInventoryInfo> GetXMInventoryInfoByPorjectID(string platformCode, string productName, string wareHoursesID, string projectids, int projectId, int saleStatus)
        {
            int?[] wareHoursesIDlist = Array.ConvertAll<string, int?>(wareHoursesID.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMInventoryInfoes
                        join t in this._context.XMWareHouses
                        on p.WfId equals t.Id
                        join m in this._context.XMProducts
                        on p.PrductId equals m.Id
                        where p.IsEnable == false
                                && (platformCode == "" || p.PlatformMerchantCode==platformCode)
                                && (productName == "" || m.ProductName.Contains(productName))
                                 && wareHoursesIDlist.Contains(p.WfId)
                                //&& (saleStatus == -1 || p.SaleStatus == saleStatus)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询所有库存数量低于警戒值的库存产品列表
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nickID"></param>
        /// <param name="wareHoursesID"></param>
        /// <returns></returns>
        public List<XMInventoryInfo> GetXMInventoryInfoByLessWarningNumber(string platformCode, string productName, string nicks, string wareHoursesID, int projectId, string nickids)
        {
            int?[] wareHoursesIDs = Array.ConvertAll<string, int?>(wareHoursesID.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMInventoryInfoes
                        join m in this._context.XMProducts
                        on p.PrductId equals m.Id
                        join t in this._context.XMWareHouses
                        on p.WfId equals t.Id
                        where p.IsEnable == false
                          && (platformCode == "" || p.PlatformMerchantCode.Contains(platformCode))
                             && (productName == "" || m.ProductName.Contains(productName))
                           && wareHoursesIDs.Contains(t.Id)
                           //&& (projectId == -1 || t.ProjectId == projectId)
                           && p.StockNumber <= p.WarningValue
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformCode"></param>
        /// <param name="productName"></param>
        /// <param name="nicks"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids"></param>
        /// <param name="projectids"></param>
        /// <returns></returns>
        public List<XMInventoryInfo> GetXMInventoryInfoByLessWarningNumberListByPorjectID(string platformCode, string productName, int wareHoursesID, int projectId, string projectids)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(projectids.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMInventoryInfoes
                        join m in this._context.XMProducts
                        on p.PrductId equals m.Id
                        join t in this._context.XMWareHouses
                        on p.WfId equals t.Id
                        where p.IsEnable == false
                          && (platformCode == "" || p.PlatformMerchantCode.Contains(platformCode))
                          && (productName == "" || m.ProductName.Contains(productName))
                          && (wareHoursesID == -1 || p.WfId == wareHoursesID)
                          && (projectId == -1 || t.ProjectId == projectId)
                          && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                          && p.StockNumber <= p.WarningValue
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XMInventoryInfo GetXMInventoryInfoByParm(string platformCode, int wareHoursesID)
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.IsEnable == false
                           && p.PlatformMerchantCode == platformCode
                           && p.WfId == wareHoursesID
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get a XMInventoryInfo by Id
        /// </summary>
        /// <param name="id">XMInventoryInfo Id</param>
        /// <returns>XMInventoryInfo</returns>   
        public XMInventoryInfo GetXMInventoryInfoById(int id)
        {
            var query = from p in this._context.XMInventoryInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfo Id</param>
        public void DeleteXMInventoryInfo(int id)
        {
            var xminventoryinfo = this.GetXMInventoryInfoById(id);
            if (xminventoryinfo == null)
                return;

            if (!this._context.IsAttached(xminventoryinfo))
                this._context.XMInventoryInfoes.Attach(xminventoryinfo);

            this._context.DeleteObject(xminventoryinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMInventoryInfo by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfo Id</param>
        public void BatchDeleteXMInventoryInfo(List<int> ids)
        {
            var query = from q in _context.XMInventoryInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xminventoryinfos = query.ToList();
            foreach (var item in xminventoryinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryInfoes.Attach(item);

                _context.XMInventoryInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
