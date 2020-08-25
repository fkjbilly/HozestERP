
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-09-20 15:57:22
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMInventoryInfoStatisticsService : IXMInventoryInfoStatisticsService
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
        public XMInventoryInfoStatisticsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMInventoryInfoStatisticsService成员
        /// <summary>
        /// Insert into XMInventoryInfoStatistics
        /// </summary>
        /// <param name="xminventoryinfostatistics">XMInventoryInfoStatistics</param>
        public void InsertXMInventoryInfoStatistics(XMInventoryInfoStatistics xminventoryinfostatistics)
        {
            if (xminventoryinfostatistics == null)
                return;

            if (!this._context.IsAttached(xminventoryinfostatistics))

                this._context.XMInventoryInfoStatistics.AddObject(xminventoryinfostatistics);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMInventoryInfoStatistics
        /// </summary>
        /// <param name="xminventoryinfostatistics">XMInventoryInfoStatistics</param>
        public void UpdateXMInventoryInfoStatistics(XMInventoryInfoStatistics xminventoryinfostatistics)
        {
            if (xminventoryinfostatistics == null)
                return;

            if (this._context.IsAttached(xminventoryinfostatistics))
                this._context.XMInventoryInfoStatistics.Attach(xminventoryinfostatistics);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMInventoryInfoStatistics list
        /// </summary>
        public List<XMInventoryInfoStatistics> GetXMInventoryInfoStatisticsList()
        {
            var query = from p in this._context.XMInventoryInfoStatistics
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 定时执行根据库存信息统计进销存明细
        /// </summary>
        public void AutoStatisticsInventoryInfo()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month - 1;
            DateTime startDate = new DateTime(year, month, 1, 0, 0, 0);
            DateTime endDate = DateTime.Now;
            var inventoryInfo = IoC.Resolve<XMInventoryInfoService>().GetXMInventoryInfoList();
            if (inventoryInfo != null && inventoryInfo.Count > 0)
            {
                foreach (XMInventoryInfo Info in inventoryInfo)
                {
                    var products = IoC.Resolve<XMProductService>().getXMProductByManufacturersCode(Info.PlatformMerchantCode);

                    var lastInventoryStatistics = GetXMInventoryInfoStatisticsByParm(year, month - 1, Info.WfId, Info.PlatformMerchantCode);    //统计月份上个月
                    if (lastInventoryStatistics != null)    //上上个月数据存在   上上个月库存 等于下个月的期初库存
                    {
                        var InventoryStatistics = GetXMInventoryInfoStatisticsByParm(year, month, Info.WfId, Info.PlatformMerchantCode);
                        if (InventoryStatistics == null)               //数据不存在新增
                        {
                            int purStorageCount = 0;    //采购入库数量
                            decimal purStorageMoney = 0;   //采购入库金额
                            int saleDeliveryCount = 0;    //出库数量
                            decimal saleDeliveryMoney = 0;     //出库金额
                            //新增
                            XMInventoryInfoStatistics parm = new XMInventoryInfoStatistics();
                            parm.WfID = Info.WfId;
                            parm.Year = year;
                            parm.Month = month;
                            if (products != null)
                            {
                                parm.ManufacturersCode = Info.PlatformMerchantCode;
                                parm.ProductName = products.ProductName;
                                parm.Specifications = products.Specifications;
                            }
                            parm.InventoryCount = Info.StockNumber;           //库存数量
                            //通过移动加权法计算成本平均单价
                            decimal inventPrice = GetInventPrice(Info.PlatformMerchantCode);
                            parm.InventoryMoney = parm.InventoryCount * inventPrice;     //库存金额
                            //采购入库记录
                            var storageProductDetails = IoC.Resolve<XMStorageProductDetailsService>().GetXMStorageProductDetailsListByParm(startDate, endDate, Info.WfId, Info.PlatformMerchantCode);
                            if (storageProductDetails != null && storageProductDetails.Count > 0)
                            {
                                foreach (XMStorageProductDetails p in storageProductDetails)
                                {
                                    purStorageCount += p.ProductsCount;
                                    purStorageMoney += p.ProductsPrice * p.ProductsCount;
                                }
                            }
                            parm.StorageCount = purStorageCount;
                            parm.StorageMoney = purStorageMoney;
                            //销售出库记录
                            var saleDeliveryProductDetails = IoC.Resolve<XMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsByParm(startDate, endDate, Info.WfId, Info.PlatformMerchantCode);
                            if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
                            {
                                foreach (XMSaleDeliveryProductDetails t in saleDeliveryProductDetails)
                                {
                                    saleDeliveryCount += t.SaleCount.Value;
                                    saleDeliveryMoney += t.SaleCount.Value * t.ProductPrice.Value;
                                }
                            }
                            parm.DeliveryCount = saleDeliveryCount;
                            parm.DeliveryMoney = saleDeliveryMoney;
                            parm.InitialCount = lastInventoryStatistics.InventoryCount;
                            parm.InitialMoney = lastInventoryStatistics.InventoryMoney;
                            parm.IsEnable = false;
                            parm.CreateDate = DateTime.Now;
                            IoC.Resolve<XMInventoryInfoStatisticsService>().InsertXMInventoryInfoStatistics(parm);
                        }
                    }
                    else                                  //上上个月数据不存在    下月期初库存需要通过库存进行计算
                    {
                        var InventoryStatistics = GetXMInventoryInfoStatisticsByParm(year, month, Info.WfId, Info.PlatformMerchantCode);
                        if (InventoryStatistics == null)               //数据不存在新增
                        {
                            int purStorageCount2 = 0;    //采购入库数量
                            decimal purStorageMoney2 = 0;   //采购入库金额
                            int saleDeliveryCount2 = 0;    //出库数量
                            decimal saleDeliveryMoney2 = 0;     //出库金额
                            //新增
                            XMInventoryInfoStatistics Statistics = new XMInventoryInfoStatistics();
                            Statistics.WfID = Info.WfId;
                            Statistics.Year = year;
                            Statistics.Month = month;
                            if (products != null)
                            {
                                Statistics.ManufacturersCode = Info.PlatformMerchantCode;
                                Statistics.ProductName = products.ProductName;
                                Statistics.Specifications = products.Specifications;
                            }
                            Statistics.InventoryCount = Info.StockNumber;           //库存数量
                            //通过移动加权法计算成本平均单价
                            decimal inventPrice = GetInventPrice(Info.PlatformMerchantCode);
                            Statistics.InventoryMoney = Statistics.InventoryCount * inventPrice;     //库存金额
                            //采购入库记录
                            var storageProductDetails = IoC.Resolve<XMStorageProductDetailsService>().GetXMStorageProductDetailsListByParm(startDate, endDate, Info.WfId, Info.PlatformMerchantCode);
                            if (storageProductDetails != null && storageProductDetails.Count > 0)
                            {
                                foreach (XMStorageProductDetails p in storageProductDetails)
                                {
                                    purStorageCount2 += p.ProductsCount;
                                    purStorageMoney2 += p.ProductsPrice * p.ProductsCount;
                                }
                            }
                            Statistics.StorageCount = purStorageCount2;
                            Statistics.StorageMoney = purStorageMoney2;
                            //销售出库记录
                            var saleDeliveryProductDetails = IoC.Resolve<XMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsByParm(startDate, endDate, Info.WfId, Info.PlatformMerchantCode);
                            if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
                            {
                                foreach (XMSaleDeliveryProductDetails t in saleDeliveryProductDetails)
                                {
                                    saleDeliveryCount2 += t.SaleCount.Value;
                                    saleDeliveryMoney2 += t.SaleCount.Value * t.ProductPrice.Value;
                                }
                            }
                            Statistics.DeliveryCount = saleDeliveryCount2;
                            Statistics.DeliveryMoney = saleDeliveryMoney2;
                            //期初数据 通过库存进行推算   
                            int storageRejectedCount = StorgedRejectdCount(startDate, endDate, Info.WfId, Info.PlatformMerchantCode);           //已入库退货数量
                            Statistics.InitialCount = Info.StockNumber.Value == 0 ? 0 : Info.StockNumber.Value - purStorageCount2 + saleDeliveryCount2 + storageRejectedCount;
                            Statistics.InitialMoney = inventPrice * Statistics.InitialCount;
                            Statistics.IsEnable = false;
                            Statistics.CreateDate = DateTime.Now;
                            IoC.Resolve<XMInventoryInfoStatisticsService>().InsertXMInventoryInfoStatistics(Statistics);
                        }
                    }


                }
            }
        }

        /// <summary>
        /// 返回入库退货数量
        /// </summary>
        /// <returns></returns>
        public int StorgedRejectdCount(DateTime startDate, DateTime endDate, int wdID, string PlatformMerchantCode)
        {
            int storageRejectedCount = 0;
            var Info = IoC.Resolve<XMPurchaseRejectedProductDetailsService>().GetXMPurchaseRejectedProductDetailsListByParm(startDate, endDate, wdID, PlatformMerchantCode);
            if (Info != null && Info.Count > 0)
            {
                foreach (XMPurchaseRejectedProductDetails p in Info)
                {
                    storageRejectedCount += p.RejectionCount;
                }
            }
            return storageRejectedCount;
        }



        //通过移动加权法计算成本平均单价
        public decimal GetInventPrice(string PlatformMerchantCode)
        {
            decimal inventPrice = 0;    //平均单价
            decimal TotalMoney = 0;    //总采购金额
            decimal TotalCount = 0;    //总采购数量
            DateTime startDate = DateTime.Now.AddDays(-365);
            DateTime endDate = DateTime.Now;
            //获取一年内所有指定产品采购记录
            var purProductDetails = IoC.Resolve<XMPurchaseProductDetailsService>().GetXMPurchaseProductDetailsByDateTime(startDate, endDate, PlatformMerchantCode);
            if (purProductDetails != null && purProductDetails.Count > 0)
            {
                foreach (XMPurchaseProductDetails parm in purProductDetails)
                {
                    TotalMoney += parm.ProductCount * parm.ProductPrice;
                    TotalCount += parm.ProductCount;
                }
            }
            if (TotalCount != 0)
            {
                inventPrice = Math.Round(TotalMoney / TotalCount, 2);                     //平均单价
            }
            return inventPrice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        public XMInventoryInfoStatistics GetXMInventoryInfoStatisticsByParm(int year, int month, int wareHoursesID, string ManufacturersCode)
        {
            var query = from p in this._context.XMInventoryInfoStatistics
                        join t in this._context.XMWareHouses
                on p.WfID equals t.Id
                        where p.IsEnable == false
                             && p.Year == year
                     && p.Month == month
                     && p.WfID == wareHoursesID
                     && p.ManufacturersCode == ManufacturersCode
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectID"></param>
        /// <param name="nickids"></param>
        /// <returns></returns>
        public List<XMInventoryInfoStatistics> GetXMInventoryInfoStatisticsListByParm(int year, int month, int wareHoursesID, int projectID, string nickids)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMInventoryInfoStatistics
                        join t in this._context.XMWareHouses
                         on p.WfID equals t.Id
                        where p.IsEnable == false
                        && p.Year == year
                        && p.Month == month
                        && (wareHoursesID == -1 || p.WfID == wareHoursesID)
                        && (projectID == -1 || t.ProjectId == projectID)
                        && nickIdlist.Contains(t.NickId)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="wareHoursesID"></param>
        /// <param name="projectID"></param>
        /// <param name="pids"></param>
        /// <returns></returns>
        public List<XMInventoryInfoStatistics> GetXMInventoryInfoStatisticsListByProjectIds(int year, int month, int wareHoursesID, int projectID, string pids)
        {
            int?[] projectlist = Array.ConvertAll<string, int?>(pids.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMInventoryInfoStatistics
                        join t in this._context.XMWareHouses
                              on p.WfID equals t.Id
                        where p.IsEnable == false
                        && p.Year == year
                        && p.Month == month
                        && (wareHoursesID == -1 || p.WfID == wareHoursesID)
                        && (projectID == -1 || t.ProjectId == projectID)
                          && ((t.NickId == -1 || t.NickId == 99) && projectlist.Contains(t.ProjectId))
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMInventoryInfoStatistics Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInventoryInfoStatistics Page List</returns>
        public PagedList<XMInventoryInfoStatistics> SearchXMInventoryInfoStatistics(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInventoryInfoStatistics
                        orderby p.Id
                        select p;
            return new PagedList<XMInventoryInfoStatistics>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="id">XMInventoryInfoStatistics Id</param>
        /// <returns>XMInventoryInfoStatistics</returns>   
        public XMInventoryInfoStatistics GetXMInventoryInfoStatisticsById(int id)
        {
            var query = from p in this._context.XMInventoryInfoStatistics
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="Id">XMInventoryInfoStatistics Id</param>
        public void DeleteXMInventoryInfoStatistics(int id)
        {
            var xminventoryinfostatistics = this.GetXMInventoryInfoStatisticsById(id);
            if (xminventoryinfostatistics == null)
                return;

            if (!this._context.IsAttached(xminventoryinfostatistics))
                this._context.XMInventoryInfoStatistics.Attach(xminventoryinfostatistics);

            this._context.DeleteObject(xminventoryinfostatistics);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMInventoryInfoStatistics by Id
        /// </summary>
        /// <param name="Ids">XMInventoryInfoStatistics Id</param>
        public void BatchDeleteXMInventoryInfoStatistics(List<int> ids)
        {
            var query = from q in _context.XMInventoryInfoStatistics
                        where ids.Contains(q.Id)
                        select q;
            var xminventoryinfostatisticss = query.ToList();
            foreach (var item in xminventoryinfostatisticss)
            {
                if (!_context.IsAttached(item))
                    _context.XMInventoryInfoStatistics.Attach(item);

                _context.XMInventoryInfoStatistics.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
