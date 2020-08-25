using HozestERP.WebApi.Message;
using HozestERP.WebApi.SQl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Manager
{

    public class SearchInventoryManager : IDisposable
    {
        public UtilManager _utilManager;
        public UtilManager CurUtilManager
        {
            get
            {
                if (_utilManager == null)
                {
                    _utilManager = new UtilManager();
                }
                return _utilManager;
            }
        }
        /// <summary>
        /// 获取五道项目对应的仓库
        /// </summary>
        /// <returns></returns>
        public List<int> getWarehouseIds()
        {
            var sql = "select * from XM_WareHouses where isEnable = 0 and ParentID = 0 and ProjectId = 1";//五道数据库中是1
            //var sql = "select Id from XM_WareHouses where isEnable = 0 and ParentID = 0 and ProjectId = 21";
            var dt = SqlDataHelper.GetDatatableBySql(sql);
            var ErpWarehouse = CurUtilManager.ToEntity<ErpWarehouseId>(dt);
            var ErpWarehouseIdList = ErpWarehouse.Select(m => m.Id).ToList();
            return ErpWarehouseIdList;
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="manufacturersCodeList">商品编码数据</param>
        /// <param name="pageSize">每页获取条数</param>
        /// <param name="pageNum">获取页码</param>
        /// <returns></returns>
        public List<ErpInventoryList> GetXLMInventory(List<string> manufacturersCodeList, TotalHeader header)
        {
            try
            {
                DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());
                var sqlWhere = string.Join("','", manufacturersCodeList);
                var sql = string.Format(@"select c.PlatformMerchantCode,b.ProductName,a.BarCode,b.ProductUnit as Unit,a.Inventory from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode
              join XM_ProductDetails c on c.ProductId = b.Id
where c.PlatformMerchantCode in ('{0}') and b.IsEnable = 0 and c.IsEnable = 0 and a.CreateDate > '{1}'", sqlWhere, date.ToString());//从喜临门当日库存获取信息的sql语句
                var dt = SqlDataHelper.GetDatatableBySql(sql);
                var ErpInventoryList = CurUtilManager.ToEntity<ErpInventoryList>(dt);
                #region  如果喜临门当日库存中没有这些商品库存，就到库存管理中寻找
                var ids = getWarehouseIds();
                var sqlwehereids = string.Join(",", ids);
                var sql1 = string.Format(@" select c.PlatformMerchantCode,b.ProductName,null as BarCode,b.ProductUnit as Unit,a.CanOrderCount as Inventory from XM_InventoryInfo a join XM_Product b on a.PlatformMerchantCode = b.ManufacturersCode
            join XM_ProductDetails c on c.ProductId = b.Id
where c.PlatformMerchantCode in ('{0}') and c.PlatformMerchantCode and a.WfId in ({1}) not in(
    select c.PlatformMerchantCode
    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where b.IsEnable = 0 and c.IsEnable = 0) and b.IsEnable = 0 and c.IsEnable = 0", sqlWhere, sqlwehereids);//从库存管理获取信息的sql语句
                var dt1 = SqlDataHelper.GetDatatableBySql(sql1);
                var ErpInventoryList1 = CurUtilManager.ToEntity<ErpInventoryList>(dt1);
                #endregion
                var ErpInventoryAllList = ErpInventoryList.Concat(ErpInventoryList1).Distinct().ToList();
                #region 判断传入的商品编号是否都找得到对应的商品信息
                var ErpPlatformMerchantCodeList = ErpInventoryAllList.Select(m => m.PlatformMerchantCode).ToList();
                var ExceptList = manufacturersCodeList.Except(ErpPlatformMerchantCodeList).ToList();
                if (ExceptList.Count > 0)
                {
                    header.IsSuccess = false;
                    header.Message = string.Format("这些商品编号{0}在ERP中无法找到对应的库存信息", string.Join(",", ExceptList));
                }
                #endregion
                return ErpInventoryList.Concat(ErpInventoryList1).Distinct().ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="pageSize">每页获取条数</param>
        /// <param name="pageNum">获取页码</param>
        /// <returns></returns>
        public List<ErpInventoryList> GetXLMInventory(int pageSize, int pageNum,ref int totalCount)
        {
            try
            {
                DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());
                var ids = getWarehouseIds();
                var sqlwehereids = string.Join(",", ids);
                #region
                var sql = string.Format(@"select top {0} * from(
  (select c.PlatformMerchantCode,b.ProductName,a.BarCode,b.ProductUnit as Unit,a.Inventory 
    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where a.CreateDate > '{1}' and  b.IsEnable = 0 and c.IsEnable = 0 
  ) union (            
select  c.PlatformMerchantCode,b.ProductName,null as BarCode, b.ProductUnit as Unit,a.CanOrderCount as Inventory 
    from XM_InventoryInfo a join XM_Product b on a.PlatformMerchantCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where  b.IsEnable = 0 and c.IsEnable = 0 and  a.WfId in ({3}) and c.PlatformMerchantCode not in(
    select c.PlatformMerchantCode
    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where b.IsEnable = 0 and c.IsEnable = 0
    )
    )) as tb where tb.PlatformMerchantCode not in 
    (
    select top {2} * from (
    (select c.PlatformMerchantCode
    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where a.CreateDate > '{1}' and  b.IsEnable = 0 and c.IsEnable = 0 
  ) union (            
select  c.PlatformMerchantCode
    from XM_InventoryInfo a join XM_Product b on a.PlatformMerchantCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where  b.IsEnable = 0 and c.IsEnable = 0  and a.WfId in ({3}) and c.PlatformMerchantCode not in(
    select c.PlatformMerchantCode
    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
   left join XM_ProductDetails c on c.ProductId = b.Id
    where b.IsEnable = 0 and c.IsEnable = 0)) 
    ) as tb1 order by tb1.PlatformMerchantCode
    ) order by tb.PlatformMerchantCode ", pageSize, date, pageSize * (pageNum - 1), sqlwehereids);//查询库存管理中的物品库存信息
                var dt= SqlDataHelper.GetDatatableBySql(sql);
                var ErpInventoryList = CurUtilManager.ToEntity<ErpInventoryList>(dt);
                #endregion
                totalCount = ErpInventoryList.Distinct().Count();
                return ErpInventoryList.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

//        public List<ErpInventoryList> GetXLMInventory(int pageSize, int pageNum, ref int totalCount)
//        {
//            try
//            {
//                DateTime date = DateTime.Parse(DateTime.Now.ToShortDateString());
//                var sql = string.Format(@"select top {0}  c.PlatformMerchantCode,b.ProductName,a.BarCode,b.ProductUnit as Unit,a.Inventory 
//    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
//   left join XM_ProductDetails c on c.ProductId = b.Id
//    where  a.CreateDate > '{1}' and b.IsEnable = 0 and c.IsEnable = 0 and a.ID not in 
//    (select top {2} a.ID from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode
//     left join XM_ProductDetails c on c.ProductId = b.Id
//    where  a.CreateDate > '{1}' and b.IsEnable = 0 and c.IsEnable = 0 order by a.ID) order by a.ID  ", pageSize, date, pageSize * (pageNum - 1));//查询喜临门当日库存的sql语句
//                var dt = SqlDataHelper.GetDatatableBySql(sql);
//                var ErpInventoryList = CurUtilManager.ToEntity<ErpInventoryList>(dt);
//                var xlmPlatformMerchantCodeList = getXLMInventory();
//                #region
//                var sqlWhere = string.Join("','", xlmPlatformMerchantCodeList);
//                var sql1 = string.Format(@"select * from(
//  (select c.PlatformMerchantCode,b.ProductName,a.BarCode,b.ProductUnit as Unit,a.Inventory 
//    from XM_XLMInventory a join XM_Product b on a.ManufacturersCode = b.ManufacturersCode 
//   left join XM_ProductDetails c on c.ProductId = b.Id
//    where  b.IsEnable = 0 and c.IsEnable = 0 
//  ) union (            
//select  c.PlatformMerchantCode,b.ProductName,null as BarCode, b.ProductUnit as Unit,a.CanOrderCount as Inventory 
//    from XM_InventoryInfo a join XM_Product b on a.PlatformMerchantCode = b.ManufacturersCode 
//   left join XM_ProductDetails c on c.ProductId = b.Id
//    where  b.IsEnable = 0 and c.IsEnable = 0 
//    )) as tb  ", pageSize, sqlWhere, pageSize * (pageNum - 1));//查询库存管理中的物品库存信息
//                var dt1 = SqlDataHelper.GetDatatableBySql(sql1);
//                var ErpInventoryList1 = CurUtilManager.ToEntity<ErpInventoryList>(dt1);
//                #endregion

//                totalCount = ErpInventoryList.Distinct().Count();
//                return ErpInventoryList.ToList();
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

        public bool ValidationSecretKey(RequestInventoryApi requestInventoryApi)
        {
             var SecretKey = requestInventoryApi.SecretKey;
            requestInventoryApi.SecretKey = null;
            var objectJson = JsonConvert.SerializeObject(requestInventoryApi);
            var SecretKey1 = CurUtilManager.MD5Encrypt(string.Format("{0}Hozest88582", objectJson));//获取参数加密的字符串
            if(SecretKey.Equals(SecretKey1))
            {
                return true;
            }else
            {
                return false;
            }
        }
        public void Dispose()
        {
            System.GC.Collect();
        }
    }
}