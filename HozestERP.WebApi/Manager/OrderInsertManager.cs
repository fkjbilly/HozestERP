
using HozestERP.WebApi.Entities;
using HozestERP.WebApi.Message;
using HozestERP.WebApi.SQl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Web;

namespace HozestERP.WebApi.Manager
{
    public  class OrderInsertManager : IDisposable
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

        private Stopwatch _stopwatch;

        private Stopwatch CurStopwatch
        {
            get {
                if (_stopwatch == null)
                {
                    _stopwatch = new Stopwatch();
                }
                return _stopwatch;
            }
        }

        /// <summary>
        /// 使用sql语句插入数据
        /// </summary>
        /// <param name="xmOrderInfoClientList"></param>
        /// <returns></returns>
        public  void InsertXMOrderInfo(List<XMOrderInfoClient> xmOrderInfoClientList, Message.Header header)
        {
            //CurUtilManager.Write(JsonConvert.SerializeObject(xmOrderInfoClientList));
           var errorstr = string.Empty;
            var orderIdList = new List<int>();//存储订单编号和对应插入数据库的ID
            #region 判断订单数据是否正确
            var nodistinctList = xmOrderInfoClientList.Select(m => m.OrderCode).ToList();
            var distinctList = nodistinctList.Distinct().ToList();//获取去重过后的订单编号
            if (distinctList.Count != nodistinctList.Count)
            {
                header.Message = "该批订单信息中有重复的订单号";
                return;
            }
            var errorstrbag = new System.Collections.Concurrent.ConcurrentBag<string>();
            #region 获取跨境商品信息
            var haiPlatformMerchantCodes = new List<string>();
            var haiWarehouse = ConfigurationManager.AppSettings["haiWarehouse"];
            if(!string.IsNullOrWhiteSpace(haiWarehouse))
            {
                var sql1 =  string.Format(@"select distinct p.PlatformMerchantCode
                               from XM_Product s join XM_Product_Combination a on a.ProductId = s.Id 
                               join XM_Combination b on a.CombinationID = b.ID join XM_CombinationDetails p on b.ID = p.ProductId
                               where  a.IsEnabled = 0 and s.IsEnable = 0 and b.IsEnabled = 0 and p.IsEnable = 0 and s.Shipper in ({0}) and p.PlatformTypeId = 508", haiWarehouse);
                var sql2 = "select b.PlatformMerchantCode from XM_Product a join XM_ProductDetails b on a.Id = b.ProductId where a.IsEnable = 0 and a.Shipper in (" + haiWarehouse + ")";
                var DataTable1 = SqlDataHelper.GetDatatableBySql(sql1);
                var DataTable2 = SqlDataHelper.GetDatatableBySql(sql2);
                haiPlatformMerchantCodes = colmunsValue(DataTable1).Concat(colmunsValue(DataTable2)).ToList();
            }
            #endregion
            foreach(var m in xmOrderInfoClientList)
            {
                canInsertOrder(m, errorstrbag, haiPlatformMerchantCodes);
            }
            //xmOrderInfoClientList.AsParallel().ForAll(m =>
            //{
            //    canInsertOrder(m, errorstrbag, haiPlatformMerchantCodes);
            //});
            if (errorstrbag.Count > 0)
            {
                var errorstring = string.Join("。", errorstrbag);
                header.Message = errorstring;
                return;
            }
            #endregion
            try
            {
                var orderCode = xmOrderInfoClientList.Select(m => m.OrderCode).ToList();//所有要覆盖订单的订单号
                #region 将要覆盖的订单的产品信息找出来
                AutoResetEvent resetEvent = new AutoResetEvent(false);//调用空闲线程执行搜素已经导入的嘻呗数据的编号
                var OrderStatus = new List<OrderStatus>();
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(state =>
                {
                    var selectOldOrderSql = "select ID,OrderCode,IsAudit from XM_OrderInfo where IsEnable = 0 and OrderCode in ('" + string.Join("','", orderCode) + "')";
                    var oldorderInfoDataTable = SqlDataHelper.GetDatatableBySql(selectOldOrderSql);
                    OrderStatus = CurUtilManager.ToEntity<OrderStatus>(oldorderInfoDataTable).ToList();//获取推送的订单存入数据库中的数据
                    resetEvent.Set();
                }));
                #endregion
                var nameList = new List<string>() { "ID", "into_erp_type", "XM_OrderInfoProductDetails" };//不需要插入sql语句中的字段
                var allProperty = typeof(XMOrderInfoClient).GetProperties().Where(m => !nameList.Contains(m.Name)).ToDictionary(m => m.Name, m => m.PropertyType);//得到每隔字段名称和字段对应的属性

                #region 将数据插入主表
                var valuesDictionary = new System.Collections.Concurrent.ConcurrentBag<Dictionary<string, object>>();//线程安全的数组,存储每隔实体类中实体类的属性和对应的值
                var CodeAndProduct = new System.Collections.Concurrent.ConcurrentDictionary<string, List<XMOrderInfoProductDetailsClient>>();//存储每个订单号和对应的产品信息
                resetEvent.WaitOne();//等待获取数据库中存在的数据
                resetEvent.Dispose();
                #region
                var updateCode = xmOrderInfoClientList.Where(m => m.into_erp_type == 2).Select(m => m.OrderCode).ToList();//所有要覆盖订单的订单号
                var isAuditCode = OrderStatus.Where(m => m.IsAudit == true && updateCode.Contains(m.OrderCode)).Select(m => m.OrderCode).ToList();//判断需要覆盖的订单中有没有已经审核通过的
                if (isAuditCode.Count > 0)
                {
                    header.Message = string.Format("这些订单号:{0} 已经审核,请到erp中反审核后再覆盖", string.Join(",", isAuditCode));
                    return;
                }
                #endregion
                var oldCode = OrderStatus.Select(m => m.OrderCode).ToList();//已经存入数据库的单号数据
                var newXmOrderInfoClientList = xmOrderInfoClientList.Where(m => (m.into_erp_type == 0 || m.into_erp_type == 1) && !oldCode.Contains(m.OrderCode));//要插入状态的订单过滤掉已存入数据库中的
                var productAllProperty = typeof(XMOrderInfoProductDetailsClient).GetProperties().Where(m => !nameList.Contains(m.Name)).ToDictionary(m => m.Name, m => m.PropertyType);//得到每隔字段名称和字段对应的属性
                var sqlAllProductProperty = string.Join(",", productAllProperty.Keys.ToArray());
                if (newXmOrderInfoClientList.Count() > 0)
                {
                    newXmOrderInfoClientList.AsParallel().ForAll(m =>//得到每个字段和字段对应的值
                    {
                        m.IsEnable = false;
                        m.IsOurOrder = true;
                        m.FinancialAudit = true;
                        //m.IsScalping = true;
                        m.CreateID = 7;
                        m.UpdateID = 7;
                        m.CreateDate = DateTime.Now;
                        m.UpdateDate = DateTime.Now;
                    });
                    foreach(var m in newXmOrderInfoClientList)
                    {
                        m.IsScalping = JudgeIsScalpingOrder(m.OrderCode,m.Remark, m.CustomerServiceRemark);
                        CodeAndProduct.TryAdd(m.OrderCode, m.XM_OrderInfoProductDetails);
                        valuesDictionary.Add(CurUtilManager.GetNameOrValue(nameList, m));
                    }
                    //newXmOrderInfoClientList.AsParallel().ForAll(m =>//得到每个字段和字段对应的值
                    //{
                    //    CodeAndProduct.TryAdd(m.OrderCode, m.XM_OrderInfoProductDetails);
                    //    valuesDictionary.Add(CurUtilManager.GetNameOrValue(nameList, m));
                    //});
                    var valueList = new System.Collections.Concurrent.ConcurrentBag<string>();
                    foreach(var m in valuesDictionary)
                    {
                        valueList.Add(string.Format("( {0} )", CurUtilManager.GetValues(allProperty, m)));
                    }
                    //valuesDictionary.AsParallel().ForAll(m =>//将得到的每个实体类的值拼成sql
                    //{
                    //    valueList.Add(string.Format("( {0} )", CurUtilManager.GetValues(allProperty, m)));
                    //});
                    #region 250条一次保持最高效率
                    var sqlAllProperty = string.Join(",", allProperty.Keys.ToArray());
                    if (valueList.Count > 250)
                    {
                        var valueOrderBy = valueList.OrderBy(m => m);
                        var firstvalue = valueOrderBy.Take(250).ToList();
                        var secondvalue = valueOrderBy.Skip(250).Take(250).ToList();
                        insertOrderInfo(sqlAllProperty, firstvalue);
                        insertOrderInfo(sqlAllProperty, secondvalue);
                    }
                    else if (valueList.Count < 250 && valueList.Count > 0)
                    {
                        var sqlValue = string.Join(",", valueList);
                        var sql = string.Format("insert into XM_OrderInfo ( {0} ) values {1}", sqlAllProperty, sqlValue);//插入主表的sql语句(新增的数据)
                        CurUtilManager.Write(sql);
                        SqlDataHelper.ExcuteBySql(sql);
                    }
                    #endregion
                    #endregion
                    #region 新增的订单的产品信息插入
                    var datatable = db(newXmOrderInfoClientList);
                    orderIdList = this.OrderAndId(datatable).Select(m=>m.Value).ToList();
                    var productValueList = insertProduct(datatable, CodeAndProduct, nameList, sqlAllProductProperty, productAllProperty);
                    #region 250条一次保持最高效率
                    if (productValueList.Count > 250)
                    {
                        var productValueOrderBy = productValueList.OrderBy(m => m).ToList();
                        var pagenum = Math.Ceiling(decimal.Parse(productValueOrderBy.Count.ToString()) / decimal.Parse(250.ToString()));
                        var firstvalue = new List<string>();
                        int i = 0;
                        while (i < pagenum)
                        {
                            firstvalue = productValueOrderBy.Skip(i * 250).Take(250).ToList();
                            insertOrderInfoProduct(sqlAllProductProperty, firstvalue);
                            i++;
                        }
                    }
                    else if (productValueList.Count < 250 && productValueList.Count > 0)
                    {
                        var sqlProductAllValue = string.Join(",", productValueList);
                        var sqlProduct = string.Format("insert into XM_OrderInfoProductDetails ( {0} ) values {1}", sqlAllProductProperty, sqlProductAllValue);//插入订单的sql语句 
                        CurUtilManager.Write(sqlProduct);
                        SqlDataHelper.ExcuteBySql(sqlProduct);
                    }
                    #endregion
                    #endregion
                }
                #region 修改数据库中已经存在的数据
                var canUpdateOrder = OrderStatus.Where(m => updateCode.Contains(m.OrderCode)).ToList();
                if (canUpdateOrder.Count() > 0)
                {
                    var orderInfoIdList = canUpdateOrder.Select(m => m.ID).ToList();
                    var deleteProduct = string.Format("delete XM_OrderInfoProductDetails where OrderInfoID in ({0})", string.Join(",", orderInfoIdList));
                    var canUpdateOrderCode = canUpdateOrder.Select(m => m.OrderCode).ToList();
                    var updatexmOrderInfoClientList = xmOrderInfoClientList.Where(m => m.into_erp_type == 2 && canUpdateOrderCode.Contains(m.OrderCode)).ToList();
                    CodeAndProduct.Clear();
                    foreach(var m in updatexmOrderInfoClientList)
                    {
                        CodeAndProduct.TryAdd(m.OrderCode, m.XM_OrderInfoProductDetails);
                    }
                    //updatexmOrderInfoClientList.AsParallel().ForAll(m =>//得到每个字段和字段对应的值
                    //{
                    //    CodeAndProduct.TryAdd(m.OrderCode, m.XM_OrderInfoProductDetails);
                    //});
                    var updateOrderList = new System.Collections.Concurrent.ConcurrentBag<string>();
                    foreach(var m in updatexmOrderInfoClientList)
                    {
                        updateOrderList.Add(FillUpdateSql(m));
                    }
                    //updatexmOrderInfoClientList.AsParallel().ForAll(m =>
                    //{
                    //    updateOrderList.Add(FillUpdateSql(m));
                    //});
                    var datatable = db(updatexmOrderInfoClientList);
                    var updateproductValueList = insertProduct(datatable, CodeAndProduct, nameList, sqlAllProductProperty, productAllProperty);
                    var sqlupdateProductAllValue = string.Join(",", updateproductValueList);
                    var sqlupdateProduct = string.Format("insert into XM_OrderInfoProductDetails ( {0} ) values {1}", sqlAllProductProperty, sqlupdateProductAllValue);//插入主表的sql语句 
                    var UpdateSql = string.Join(" ", updateOrderList);
                    CurUtilManager.Write(deleteProduct + " " + sqlupdateProduct + " " + UpdateSql);
                    SqlDataHelper.ExcuteBySql(deleteProduct + " " + sqlupdateProduct + " " + UpdateSql);
                }
                #endregion
            }
            catch (Exception ex)//如果有错误则删除插入的数据
            {
                InsertLog.Insert("订单插入接口报错:数据异常", ex);
                header.Message = ex.Message;
                if (orderIdList.Count > 0)
                {
                    var sqlDeleteCode = string.Join(",", orderIdList.ToArray());
                    var sqlProduct = string.Format("delete from XM_OrderInfoProductDetails where OrderInfoID in ({0})", sqlDeleteCode);
                    var sqlOrder = string.Format("delete from XM_OrderInfo where ID in ({0})", sqlDeleteCode);
                    CurUtilManager.Write(sqlProduct + " " + sqlOrder);
                    SqlDataHelper.ExcuteBySql(sqlProduct + " " + sqlOrder);
                }

            }
        }
        /// <summary>
        /// 判断该订单是否刷单   true 是刷单  false 不是刷单
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        public bool JudgeIsScalpingOrder(string ordercode, string remark, string CustomerServiceRemark)
        {

            #region 获取codelist的数据
            var sql1 = string.Format("select * from Sys_CodeList where Deleted = 0 and CodeTypeID =191");
            var dt1 = SqlDataHelper.GetDatatableBySql(sql1);
            var codequery = CurUtilManager.ToEntity<CodeList>(dt1);
            var codeList = codequery.ToList();
            #endregion
            if (remark != null && remark != "" && ordercode != null && ordercode != "")
            {
                //关键字查询
                foreach (CodeList cl in codeList)
                {
                    if (remark.Contains(cl.CodeName))
                    {
                        //var scalping = new XMScalping();
                        //scalping.PlatformTypeId = platformtypeid;
                        //scalping.NickId = nickid;
                        //scalping.Type = 365;//PC端
                        //scalping.OrderCode = ordercode;
                        //scalping.OrderInfoCreateDate = orderInfoCreateDate;
                        //scalping.WantID = wantid;
                        //scalping.ProductName = productname;
                        //scalping.SalePrice = saleprice;
                        //scalping.IsEnable = false;
                        //scalping.IsAbnormal = false;
                        //scalping.CreateID = 7;
                        //scalping.UpdateID = 7;
                        //scalping.CreateDate = DateTime.Now;
                        //scalping.UpdateDate = DateTime.Now;
                        ////保存数据
                        //var allProperty = typeof(XMScalping).GetProperties().ToDictionary(m => m.Name, m => m.PropertyType);
                        //var sqlAllProperty = string.Join(",", allProperty.Keys.ToArray());
                        //var nameList = new List<string>();
                        //var dic = CurUtilManager.GetNameOrValue(nameList, scalping));
                        //var valueList = new List<string>();
                        //valueList.Add(string.Format("( {0} )", CurUtilManager.GetValues(allProperty, dic)));
                        //var sqlValue = string.Join(",", valueList.ToArray());
                        //var sql2 = string.Format("insert into XM_Scalping ( {0} ) values {1}", sqlAllProperty, sqlValue);//插入主表的sql语句(新增的数据)
                        //SqlDataHelper.ExcuteBySql(sql);
                        return true;
                    }
                }
            }
            else if (CustomerServiceRemark != null && CustomerServiceRemark != "" && ordercode != null && ordercode != "")
            {
                foreach (CodeList cl in codeList)
                {
                    if (CustomerServiceRemark.Contains(cl.CodeName))
                    {
                        //var scalping = new XMScalping();
                        //scalping.PlatformTypeId = platformtypeid;
                        //scalping.NickId = nickid;
                        //scalping.Type = 365;//PC端
                        //scalping.OrderCode = ordercode;
                        //scalping.WantID = wantid;
                        //scalping.ProductName = productname;
                        //scalping.SalePrice = saleprice;
                        //scalping.IsEnable = false;
                        //scalping.IsAbnormal = false;
                        //scalping.CreateID = 7;
                        //scalping.UpdateID = 7;
                        //scalping.CreateDate = DateTime.Now;
                        //scalping.UpdateDate = DateTime.Now;
                        //scalping.CreateDate = DateTime.Now;
                        //scalping.UpdateDate = DateTime.Now;
                        ////保存数据
                        //var allProperty = typeof(XMScalping).GetProperties().ToDictionary(m => m.Name, m => m.PropertyType);
                        //var sqlAllProperty = string.Join(",", allProperty.Keys.ToArray());
                        //var nameList = new List<string>();
                        //var dic = CurUtilManager.GetNameOrValue(nameList, scalping));
                        //var valueList = new List<string>();
                        //valueList.Add(string.Format("( {0} )", CurUtilManager.GetValues(allProperty, dic)));
                        //var sqlValue = string.Join(",", valueList.ToArray());
                        //var sql2 = string.Format("insert into XM_Scalping ( {0} ) values {1}", sqlAllProperty, sqlValue);//插入主表的sql语句(新增的数据)
                        //SqlDataHelper.ExcuteBySql(sql);
                        return true;
                    }
                }

            }
            return false;
        }
        /// <summary>
        /// 生成插入产品信息的sql语句中的value部分
        /// </summary>
        public System.Collections.Concurrent.ConcurrentBag<string> insertProduct(DataTable orderInfoDataTable, System.Collections.Concurrent.ConcurrentDictionary<string, List<XMOrderInfoProductDetailsClient>> CodeAndProduct, List<string> nameList, string sqlAllProductProperty, Dictionary<string, Type> productAllProperty)
        {
            var productValueList = new System.Collections.Concurrent.ConcurrentBag<string>();
            var codeOrIdDictionary = new Dictionary<string, int>();
            codeOrIdDictionary = this.OrderAndId(orderInfoDataTable);
            //var IdOrPayPriceDictionary = this.IdAndPrice(orderInfoDataTable);//获取每个订单表id和对应的产品总金额
            var orderProductList = new System.Collections.Concurrent.ConcurrentBag<XMOrderInfoProductDetailsClient>();
            foreach(var m in CodeAndProduct)
            {
                FillProductEntity(codeOrIdDictionary, m, orderProductList);
            };
            //CodeAndProduct.AsParallel().ForAll(m =>
            //{
            //    FillProductEntity(codeOrIdDictionary, m, orderProductList);
            //});
            var productValuesDictionary = new System.Collections.Concurrent.ConcurrentBag<Dictionary<string, object>>();//线程安全的数组,存储每隔实体类中实体类的属性和对应的值

            var orderErpProductList = new System.Collections.Concurrent.ConcurrentBag<XMOrderInfoProductDetailsClient>();//存储根据商品吗转换后erp中的商品信息
            CurUtilManager.Write(JsonConvert.SerializeObject(orderProductList.ToList()));
            var orderandPaydateDictionary = OrderAndPaydate(orderInfoDataTable);
            #region 搜索产品信息
            var platformMerchantCode = orderProductList.Select(m => m.PlatformMerchantCode).Distinct().ToList();
            var ProductDanduList = this.GetXMProductListByPlatFormMerchantCode(platformMerchantCode, 825);//获取单个产品信息
            var ProductZuheList = this.GetXMProductListByzuheCode(platformMerchantCode, 825).Distinct();// 获取组合产品信息

            var productAllList = ProductDanduList.Concat(ProductZuheList);
            #endregion
            foreach (var m in orderProductList)
            {
                setProductNum(m, orderErpProductList, orderandPaydateDictionary, productAllList.ToList());
            }
            CurUtilManager.Write(JsonConvert.SerializeObject(orderErpProductList.ToList()));
            //orderProductList.AsParallel().ForAll(m =>//得到每个字段和字段对应的值
            //{
            //    setProductNum(m, orderErpProductList, orderandPaydateDictionary, productAllList.ToList());
            //});
            #region 平均拆分订单的实付金额
            //var chaifen = orderErpProductList.GroupBy(m => m.OrderInfoID).Select(m => new
            //{
            //    OrderInfoID = m.Key,
            //    PayPrice = IdOrPayPriceDictionary[(int)m.Key],
            //    product = m.Select(s => s)
            //});
            //var orderErpProductList1 = new System.Collections.Concurrent.ConcurrentBag<XMOrderInfoProductDetailsClient>();//存储根据商品吗转换后erp中的商品信息
            //foreach (var elem in chaifen)
            //{
            //    setProductprice(elem.product, elem.PayPrice, (int)elem.OrderInfoID, orderErpProductList1);
            //};
            //CurUtilManager.Write(JsonConvert.SerializeObject(orderErpProductList1.ToList()));
            #endregion
            var orderErpProducGrouptList = orderErpProductList.GroupBy(m => new { m.PlatformMerchantCode, m.OrderInfoID }).Select(m => new XMOrderInfoProductDetailsClient
            { ///根据订单主表id和商品编码和并相同的产品信息
                OrderInfoID = m.Key.OrderInfoID,
                PlatformMerchantCode = m.Key.PlatformMerchantCode,
                TManufacturersCode = m.FirstOrDefault().TManufacturersCode,
                ProductName = m.FirstOrDefault().ProductName,
                Specifications = m.FirstOrDefault().Specifications,
                SpareRemarks = m.FirstOrDefault().SpareRemarks,
                ProductNum = m.Sum(s => s.ProductNum.GetValueOrDefault(1)),
                FactoryPrice = m.FirstOrDefault().FactoryPrice,
                TCostprice = m.FirstOrDefault().TCostprice,
                SalesPrice = m.Sum(s => s.SalesPrice.GetValueOrDefault(0)),
                ISArrivedLibrary = m.FirstOrDefault().ISArrivedLibrary,
                Remarks = m.FirstOrDefault().Remarks,
                CutoffShipDay = m.FirstOrDefault().CutoffShipDay,
                IsAudit = m.FirstOrDefault().IsAudit,
                IsEnable = m.FirstOrDefault().IsEnable,
                CreateID = m.FirstOrDefault().CreateID,
                CreateDate = m.FirstOrDefault().CreateDate,
                UpdateID = m.FirstOrDefault().UpdateID,
                UpdateDate = m.FirstOrDefault().UpdateDate,
                IsExpedited = m.FirstOrDefault().IsExpedited,
                Status = m.FirstOrDefault().Status,
                IsSingleRow = m.FirstOrDefault().IsSingleRow
            });
            CurUtilManager.Write(JsonConvert.SerializeObject(orderErpProducGrouptList.ToList()));
            foreach (var m in orderErpProducGrouptList)//得到每个字段和字段对应的值
            {
                productValuesDictionary.Add(CurUtilManager.GetNameOrValue(nameList, m));
            }
            foreach (var m in productValuesDictionary)
            {
                productValueList.Add(string.Format("( {0} )", CurUtilManager.GetValues(productAllProperty, m)));
            }
            //orderErpProducGrouptList.AsParallel().ForAll(m =>//得到每个字段和字段对应的值
            //{
            //    productValuesDictionary.Add(CurUtilManager.GetNameOrValue(nameList, m));
            //});
            //productValuesDictionary.AsParallel().ForAll(m =>
            //{
            //    productValueList.Add(string.Format("( {0} )", CurUtilManager.GetValues(productAllProperty, m)));
            //});

            return productValueList;
        }
        /// <summary>
        /// 获取已经插入订单主表的数据
        /// </summary>
        /// <returns></returns>
        private DataTable db(IEnumerable<XMOrderInfoClient> newXmOrderInfoClientList)
        {
            var codeList = new System.Collections.Concurrent.ConcurrentBag<string>();
            var insertOrderCode = newXmOrderInfoClientList.Select(m => m.OrderCode).ToList();
            foreach(var m in insertOrderCode)
            {
                codeList.Add("'" + m + "'");
            }
            //insertOrderCode.AsParallel().ForAll(m =>
            //{
            //    codeList.Add("'" + m + "'");
            //});
            var sqlSearchCode = string.Join(",", codeList.ToArray());
            var sqlSearch = string.Format("select * from XM_OrderInfo where IsEnable = 0 and OrderCode in ({0})", sqlSearchCode);//查找到刚刚插入的订单信息
                                                                                                                //CurUtilManager.Write(sqlSearch);
            var orderInfoDataTable = SqlDataHelper.GetDatatableBySql(sqlSearch);
            return orderInfoDataTable;
        }
         /// <summary>
         /// 插入订单表数据
         /// </summary>
         /// <param name="sqlAllProperty"></param>
         /// <param name="sqlValue"></param>
        private void insertOrderInfo(string sqlAllProperty,List<string> valueList)
        {
            var sqlValue = string.Join(",", valueList);
            var sql = string.Format("insert into XM_OrderInfo ( {0} ) values {1}", sqlAllProperty, sqlValue);//插入主表的sql语句(新增的数据)
            SqlDataHelper.ExcuteBySql(sql);
        }
        /// <summary>
        /// 插入订单产品表数据
        /// </summary>
        /// <param name="sqlAllProperty"></param>
        /// <param name="valueList"></param>
        private void insertOrderInfoProduct(string sqlAllProductProperty, List<string> productValueList)
        {
            var sqlProductAllValue = string.Join(",", productValueList);
            var sqlProduct = string.Format("insert into XM_OrderInfoProductDetails ( {0} ) values {1}", sqlAllProductProperty, sqlProductAllValue);//插入主表的sql语句 
            SqlDataHelper.ExcuteBySql(sqlProduct);
        }
        /// <summary>
        /// 生成修改订单主表的sql语句
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public string FillUpdateSql(XMOrderInfoClient client)
        {
           //var entity = orderStatus.Where(m=>m.OrderCode == client.OrderCode).SingleOrDefault()
            var sql = string.Format("update XM_OrderInfo set FullName = '{0}' ,Mobile = '{1}',Province = '{2}',City = '{3}',County = '{4}',DeliveryAddress = '{5}',OrderPromotion = {6}, DistributePrice= {7} ,OrderPrice = {8},ProductPrice= {9},ProductPromotion= {10},ReceivablePrice={11},PayPrice={12} where IsEnable = 0 and OrderCode = '{13}'", client.FullName, client.Mobile, client.Province, client.City, client.County, client.DeliveryAddress,  client.OrderPromotion, client.DistributePrice,client.OrderPrice,client.ProductPrice, client.ProductPromotion,client.ReceivablePrice,client.PayPrice, client.OrderCode);
            return sql;
        }

        /// <summary>
        /// 获取已经插入数据库的数据，返回订单编号和对应的paydate
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public Dictionary<string, string> OrderAndPaydate(DataTable dataTable)
        {
            var dic = new Dictionary<string, string>();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    string orderCode = row["ID"].ToString();
                    string payDate = row["PayDate"].ToString();
                    if(!dic.Keys.Contains(orderCode))
                        dic.Add(orderCode, payDate);
                }
                catch
                {
                }
            }
            return dic;
        }
        /// <summary>
        /// 得到五道传入的商品编码对应的erp产品信息
        /// </summary>
        public void setProductNum(XMOrderInfoProductDetailsClient m, System.Collections.Concurrent.ConcurrentBag<XMOrderInfoProductDetailsClient> orderErpProductList, Dictionary<string, string> dic,List<XMProductNew> productAllList)
        {
            var isZuhe = false;
            var ProductList = productAllList.Where(s => s.PlatformMerchantCode == m.PlatformMerchantCode).Distinct().ToList();
            if(ProductList.Count == 0)//未找到单个产品说明可能是组合产品
            {
                isZuhe = true;
                ProductList = productAllList.Where(s => s.ZUHEPlatformMerchantCode == m.PlatformMerchantCode).Distinct().ToList();
            }
            DateTime payDate = dic.Keys.Contains(m.OrderInfoID.ToString()) ? Convert.ToDateTime(dic[m.OrderInfoID.ToString()]) : DateTime.Now;
            if (ProductList.Count == 0)
            {
                var entity = new XMOrderInfoProductDetailsClient();
                entity.OrderInfoID = m.OrderInfoID;
                entity.PlatformMerchantCode = m.PlatformMerchantCode; //料号（商品编码,对应供应商那边）
                entity.Specifications = "";//尺寸
                entity.FactoryPrice = 0;//出厂价
                entity.ProductName = "无产品";//产品名称
                entity.ProductNum =  0;//井贝的产品数量等于组合套数*每套中的产品数量
                entity.TManufacturersCode = "";
                entity.SalesPrice = 0;
                //entity.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                entity.ISArrivedLibrary = false;
                entity.IsAudit = false;//是否审核
                entity.IsExpedited = false;//是否加急
                entity.IsEnable = false;
                entity.CreateDate = DateTime.Now;
                entity.CreateID = 7;
                entity.UpdateDate = DateTime.Now;
                entity.UpdateID = 7;
                orderErpProductList.Add(entity);
            }
            else
            {
                #region 平摊组合商品的销售价格
                var dicPrice = new Dictionary<string, decimal>();
                var canchild = ProductList.Count;
                if (canchild > 1)
                    zuheproduct(ProductList, m, dicPrice);
                #endregion
                foreach (var elem in ProductList)
                {
                    var entity = new XMOrderInfoProductDetailsClient();
                    entity.OrderInfoID = m.OrderInfoID;
                    entity.PlatformMerchantCode = elem.PlatformMerchantCode; //料号（商品编码,对应供应商那边）
                    entity.Specifications = elem.Specifications;//尺寸
                    entity.FactoryPrice = elem.Costprice;//出厂价
                    entity.ProductName = FilteSQLStr(elem.ProductName);//产品名称
                    entity.ProductNum = elem.count.GetValueOrDefault(1) * m.ProductNum;//井贝的产品数量等于组合套数*每套中的产品数量
                    entity.TManufacturersCode = elem.ManufacturersCode;
                    //entity.SalesPrice = elem.Saleprice * elem.count.GetValueOrDefault(1) * m.ProductNum;
                    entity.SalesPrice = canchild == 1 ? (m.SalesPrice / elem.count.GetValueOrDefault(1)) : (dicPrice.Keys.Contains(elem.PlatformMerchantCode) ? dicPrice[elem.PlatformMerchantCode] : 0);
                    entity.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                    if(isZuhe)
                        entity.SpareRemarks = m.PlatformMerchantCode;//存储每个拆分的子产品对应的组合商品的ID
                    entity.ISArrivedLibrary = false;
                    entity.IsAudit = false;//是否审核
                    entity.IsExpedited = false;//是否加急
                    entity.IsEnable = false;
                    entity.CreateDate = DateTime.Now;
                    entity.CreateID = 7;
                    entity.UpdateDate = DateTime.Now;
                    entity.UpdateID = 7;
                    orderErpProductList.Add(entity);
                }
            }
        }
        /// <summary>
        /// 设置产品的销售价格
        /// </summary>
        /// <param name="ProductList"></param>
        /// <param name="ProductPrice">产品总金额</param>
        /// <param name="orderInfoId"></param>
        /// <param name="orderErpProductList"></param>
        //public void setProductprice(IEnumerable<XMOrderInfoProductDetailsClient> ProductList,decimal PayPrice, int orderInfoId,System.Collections.Concurrent.ConcurrentBag<XMOrderInfoProductDetailsClient> orderErpProductList)
        //{
        //    var dicPrice = new Dictionary<string, decimal>();
        //    var canchild = ProductList.Count();
        //    if (canchild > 1)
        //        zuheproduct(ProductList.ToList(), PayPrice, dicPrice);
        //    foreach (var elem in ProductList)
        //    {
        //        elem.SalesPrice = canchild > 1 ?(dicPrice.Keys.Contains(elem.PlatformMerchantCode) ? dicPrice[elem.PlatformMerchantCode] : 0): PayPrice;
        //        orderErpProductList.Add(elem);
        //    }
        //}

        /// <summary>
        /// 组合商品赋值
        /// </summary>
        /// <param name="SalesPrice">接口传入的组合商品的总价格</param>
        public void zuheproduct(List<XMProductNew> ProductList, XMOrderInfoProductDetailsClient entity, Dictionary<string,decimal> dicPrice)
        {
            var SalesPrice = entity.SalesPrice.GetValueOrDefault(0);//商品五道单个售价
            decimal payPriceI = 0;//组合已赋值付款金额
            var childproduct = ProductList.Select(m => new
            {
                m.PlatformMerchantCode,
                ProductNum = m.count.GetValueOrDefault(1),//组合套装内的数量
                m.Saleprice ,//erp中商品的销售价格
            }).Select(m=>new {
                m.PlatformMerchantCode,
                m.ProductNum,
                Saleprice = m.ProductNum * m.Saleprice
            });
            if (!childproduct.Any(m => m.Saleprice.GetValueOrDefault(0) == 0))//说明有商品的销售价为0
            {
                var sumSalepricePrice = childproduct.Sum(m => m.Saleprice).Value;
                int i = 0,c= childproduct.Count();
                foreach(var elem in childproduct)
                {
                    i++;
                    if (i < c)
                    {
                        var chaifenprice = Math.Round((decimal)((elem.Saleprice / sumSalepricePrice) * SalesPrice / elem.ProductNum), 2);//销售价
                        payPriceI += chaifenprice * elem.ProductNum;
                        dicPrice.Add(elem.PlatformMerchantCode, chaifenprice);
                    }else
                    {
                        var price = Math.Round((SalesPrice - payPriceI) / elem.ProductNum,2);//得到最后一个物品的单价
                        dicPrice.Add(elem.PlatformMerchantCode, price);
                    }
                }
            }
        }
        /// <summary>
        /// 寻找商品表中的商品信息
        /// </summary>
        public List<XMProductNew> GetXMProductListByPlatFormMerchantCode(List<string> PlatFormMerchantCodeList, int PlatformTypeId)
        {
            var sqlwhere = string.Join("','", PlatFormMerchantCodeList);
            var sql = string.Format(@"select a.Id,a.ProductId,a.PlatformTypeId,a.PlatformMerchantCode,a.ProductTypeId,a.PlatformInventory,
                                a.strUrl,a.Images,a.Costprice,a.Saleprice,a.TCostprice,a.TDateTimeStart,a.TDateTimeEnd,a.IsMainPush,
b.BrandTypeId, b.ProductName,b.ManufacturersCode,b.Specifications,b.ManufacturersInventory,b.WarningQuantity,b.ProductColors,
b.ProductUnit,b.IsPremiums,b.IsEnable,b.CreateID,b.CreateDate,b.UpdateID,b.UpdateDate,a.TemporaryManufacturersCode
                               from XM_ProductDetails a join XM_Product b on a.ProductId = b.Id 
                               where  a.IsEnable = 0 and a.PlatformMerchantCode in ('{0}') and a.PlatformTypeId = {1}", sqlwhere, PlatformTypeId);
            //先去找对应平台没有则找通用平台
            //CurUtilManager.Write(sql);
            var dt = SqlDataHelper.GetDatatableBySql(sql);
            var resultArray =  CurUtilManager.ToEntity<XMProductNew>(dt);
            return resultArray.ToList();
        }
//        public List<XMProductNew> GetXMProductListByPlatFormMerchantCode(string PlatFormMerchantCode, int PlatformTypeId)
//        {
//            var sql = string.Format(@"select a.Id,a.ProductId,a.PlatformTypeId,a.PlatformMerchantCode,a.ProductTypeId,a.PlatformInventory,
//                                a.strUrl,a.Images,a.Costprice,a.Saleprice,a.TCostprice,a.TDateTimeStart,a.TDateTimeEnd,a.IsMainPush,
//b.BrandTypeId, b.ProductName,b.ManufacturersCode,b.Specifications,b.ManufacturersInventory,b.WarningQuantity,b.ProductColors,
//b.ProductUnit,b.IsPremiums,b.IsEnable,b.CreateID,b.CreateDate,b.UpdateID,b.UpdateDate,a.TemporaryManufacturersCode
//                               from XM_ProductDetails a join XM_Product b on a.ProductId = b.Id 
//                               where  a.IsEnable = 0 and a.PlatformMerchantCode = '{0}' and a.PlatformTypeId = {1}", PlatFormMerchantCode, PlatformTypeId);
//            //先去找对应平台没有则找通用平台
//            var dt = SqlDataHelper.GetDatatableBySql(sql);
//            var resultArray = CurUtilManager.ToEntity<XMProductNew>(dt);
//            return resultArray.ToList();
//        }
        /// <summary>
        ///寻找组合产品中对应的erp供应商产品
        /// </summary>
        public List<XMProductNew> GetXMProductListByzuheCode(List<string> PlatFormMerchantCodeList, int PlatformTypeId)
        {
            var sqlwhere = string.Join("','", PlatFormMerchantCodeList);
            var sql = string.Format(@"select p.PlatformMerchantCode as ZUHEPlatformMerchantCode, s.Id,a.Count,s.BrandTypeId,s.ProductName,s.ManufacturersCode,s.Specifications,
                                s.ManufacturersInventory,s.WarningQuantity,s.ProductColors,s.ProductUnit,s.IsPremiums, s.IsEnable,
                                s.CreateID, s.CreateDate, s.UpdateID,s.UpdateDate
                               from XM_Product s join XM_Product_Combination a on a.ProductId = s.Id 
                               join XM_Combination b on a.CombinationID = b.ID join XM_CombinationDetails p on b.ID = p.ProductId
                               where  a.IsEnabled = 0 and s.IsEnable = 0 and b.IsEnabled = 0 and p.IsEnable = 0 and p.PlatformMerchantCode in ('{0}') and p.PlatformTypeId = {1}", sqlwhere, PlatformTypeId);
            //CurUtilManager.Write(sql);
            var dt = SqlDataHelper.GetDatatableBySql(sql);
            var resultArray = CurUtilManager.ToEntity<XMProductNew>(dt);
            List<XMProductNew> list = new List<XMProductNew>();
            if (resultArray.ToList() != null && resultArray.ToList().Count > 0)
            {
                foreach (XMProductNew info in resultArray.ToList())
                {
                    var sqldetail =string.Format("select * from XM_ProductDetails where ProductId = {0} and IsEnable = 0", info.Id);
                    //CurUtilManager.Write(sqldetail);
                    var detaildt = SqlDataHelper.GetDatatableBySql(sqldetail);
                    var detail = CurUtilManager.ToEntity<XMProductDetails>(detaildt);
                    var Detail = detail.Where(p => p.PlatformTypeId == PlatformTypeId).ToList();
                    if (Detail != null && Detail.Count() > 0)
                    {
                        XMProductDetails q = Detail[Detail.Count() - 1];
                        info.Id = q.Id;
                        info.ProductId = q.ProductId;
                        info.PlatformTypeId = q.PlatformTypeId;
                         info.PlatformMerchantCode = q.PlatformMerchantCode;
                        info.ProductTypeId = q.ProductTypeId;
                        info.PlatformInventory = q.PlatformInventory;
                        info.strUrl = q.strUrl;
                        info.Images = q.Images;
                        info.Costprice = q.Costprice;
                        info.Saleprice = q.Saleprice;
                        info.TCostprice = q.TCostprice;
                        info.TDateTimeStart = q.TDateTimeStart;
                        info.TDateTimeEnd = q.TDateTimeEnd;
                        info.IsMainPush = q.IsMainPush;
                        info.TManufacturersCode = q.TemporaryManufacturersCode;
                        list.Add(info);
                    }
                }
            }
            return list;
        }

        //public List<XMProductNew> GetXMProductListByzuheCode(string PlatFormMerchantCode, int PlatformTypeId)
        //{
        //    var sql = string.Format(@"select s.Id,a.Count,s.BrandTypeId,s.ProductName,s.ManufacturersCode,s.Specifications,
        //                        s.ManufacturersInventory,s.WarningQuantity,s.ProductColors,s.ProductUnit,s.IsPremiums, s.IsEnable,
        //                        s.CreateID, s.CreateDate, s.UpdateID,s.UpdateDate
        //                       from XM_Product s join XM_Product_Combination a on a.ProductId = s.Id 
        //                       join XM_Combination b on a.CombinationID = b.ID join XM_CombinationDetails p on b.ID = p.ProductId
        //                       where  a.IsEnabled = 0 and s.IsEnable = 0 and b.IsEnabled = 0 and p.IsEnable = 0 and p.PlatformMerchantCode = '{0}' and p.PlatformTypeId = {1}", PlatFormMerchantCode, PlatformTypeId);

        //    var dt = SqlDataHelper.GetDatatableBySql(sql);
        //    var resultArray = CurUtilManager.ToEntity<XMProductNew>(dt);

        //    List<XMProductNew> list = new List<XMProductNew>();
        //    if (resultArray.ToList() != null && resultArray.ToList().Count > 0)
        //    {
        //        foreach (XMProductNew info in resultArray.ToList())
        //        {
        //            var sqldetail = string.Format("select * from XM_ProductDetails where ProductId = {0} and IsEnable = 0", info.Id);
        //            var detaildt = SqlDataHelper.GetDatatableBySql(sqldetail);
        //            var detail = CurUtilManager.ToEntity<XMProductDetails>(detaildt);
        //            var Detail = detail.Where(p => p.PlatformTypeId == PlatformTypeId).ToList();
        //            if (Detail != null && Detail.Count() > 0)
        //            {
        //                XMProductDetails q = Detail[Detail.Count() - 1];
        //                info.Id = q.Id;
        //                info.ProductId = q.ProductId;
        //                info.PlatformTypeId = q.PlatformTypeId;
        //                info.PlatformMerchantCode = q.PlatformMerchantCode;
        //                info.ProductTypeId = q.ProductTypeId;
        //                info.PlatformInventory = q.PlatformInventory;
        //                info.strUrl = q.strUrl;
        //                info.Images = q.Images;
        //                info.Costprice = q.Costprice;
        //                info.Saleprice = q.Saleprice;
        //                info.TCostprice = q.TCostprice;
        //                info.TDateTimeStart = q.TDateTimeStart;
        //                info.TDateTimeEnd = q.TDateTimeEnd;
        //                info.IsMainPush = q.IsMainPush;
        //                info.TManufacturersCode = q.TemporaryManufacturersCode;
        //                list.Add(info);
        //            }
        //        }
        //    }
        //    return list;
        //}

        public void FillProductEntity(Dictionary<string,int> codeOrIdDictionary, KeyValuePair<string, List<XMOrderInfoProductDetailsClient>> IDOrProduct, System.Collections.Concurrent.ConcurrentBag<XMOrderInfoProductDetailsClient> orderProductList)
        {
            if (codeOrIdDictionary.Keys.Contains(IDOrProduct.Key))
            {
                foreach (var element in IDOrProduct.Value)
                {
                    element.OrderInfoID = codeOrIdDictionary[IDOrProduct.Key];
                    orderProductList.Add(element);
                }
            }
        }

        /// <summary>
        /// 获取已经插入数据库的数据，返回订单编号和对应的ID
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public List<string> colmunsValue(DataTable dataTable)
        {
            var list = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    var value = row["PlatformMerchantCode"].ToString();
                    list.Add(value);
                }
                catch
                {
                }
            }
            return list;
        }
        /// <summary>
        /// 获取已经插入数据库的数据，返回订单编号和对应的ID
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public Dictionary<string, int> OrderAndId(DataTable dataTable)
        {
            var dic = new Dictionary<string,int>();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    string orderCode = row["OrderCode"].ToString();
                    int id = int.Parse(row["ID"].ToString());
                    if(!dic.Keys.Contains(orderCode))
                        dic.Add(orderCode, id);
                }
                catch
                {
                }
            }
            return dic;
        }
        /// <summary>
        /// 获取已经插入数据库的数据，返回订单编号和对应的ID
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public Dictionary<int,decimal> IdAndPrice(DataTable dataTable)
        {
            var dic = new Dictionary<int,decimal>();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    int id = int.Parse(row["ID"].ToString());
                    decimal payPrice = decimal.Parse(row["PayPrice"].ToString());
                    if (!dic.Keys.Contains(id))
                        dic.Add(id, payPrice);
                }
                catch
                {
                }
            }
            return dic;
        }
        /// <summary>
        /// 获取数据库中原有的旧数据，返回的ID
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public List<int> Ids(DataTable dataTable)
        {
            var list = new List<int>();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    int id = int.Parse(row["ID"].ToString());
                    list.Add(id);
                }
                catch
                {
                }
            }
            return list;
        }
        /// <summary>
        /// 判断传入的订单数据是否正确
        /// </summary>
        /// <param name="xmOrderInfo">订单实体</param>
        /// <param name="haiids">对应的海关跨境商品的编号</param>
        /// <returns></returns>
        public void canInsertOrder(XMOrderInfoClient xmOrderInfo, System.Collections.Concurrent.ConcurrentBag<string> errorbag, List<string> haiPlatformMerchantCodes)
        {
            StringBuilder sb = new StringBuilder();
            var errorStr = string.Empty;
            var startLength = 0;
            sb.Append(string.Format("订单号是{0}的订单信息:", xmOrderInfo.OrderCode));
            startLength = sb.Length;
         
            if (xmOrderInfo.NickID == -1)//店铺是否为空
                sb.Append("店铺为空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.OrderCode))
                sb.Append("订单编号为空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.OrderStatus))
                sb.Append("订单状态为空!");
            if (xmOrderInfo.PayDate == null)
                sb.Append("付款时间为空!");
            if (xmOrderInfo.CreateDate == null)
                sb.Append("创单时间为空!");
            //if (string.IsNullOrWhiteSpace(xmOrderInfo.RealName))
            //    sb.Append("真实姓名为空!");
            if (xmOrderInfo.ProductPrice.GetValueOrDefault(-1) == -1)
                sb.Append("商品总额为空!");
            //if (xmOrderInfo.DistributePrice.GetValueOrDefault(-1) == -1)
            //    sb.Append("配送费用为空!");
            if (xmOrderInfo.ProductPromotion.GetValueOrDefault(-1) == -1)
                sb.Append("商品促销优惠为空!");
            if (xmOrderInfo.OrderPromotion.GetValueOrDefault(-1) == -1)
                sb.Append("订单促销优惠为空!");
            if (xmOrderInfo.OrderPrice.GetValueOrDefault(-1) == -1)
                sb.Append("订单总额为空!");
            //if (xmOrderInfo.PayPrice.GetValueOrDefault(-1) == -1)
            //    sb.Append("海关金额为空!");
            if (xmOrderInfo.ReceivablePrice.GetValueOrDefault(-1) == -1)
                sb.Append("到账金额为空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.DistributeMethod))
                sb.Append("配送方式空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.FullName))
                sb.Append("收货人姓名为空!");
            xmOrderInfo.FullName = FilteSQLStr(xmOrderInfo.FullName);
            if (string.IsNullOrWhiteSpace(xmOrderInfo.Mobile))
                sb.Append("收货人手机为空!");
            xmOrderInfo.Mobile = FilteSQLStr(xmOrderInfo.Mobile);
            if (string.IsNullOrWhiteSpace(xmOrderInfo.Province))
                sb.Append("收货人省为空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.City))
                sb.Append("收货人城市为空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.County))
                sb.Append("收货人区为空!");
            if (string.IsNullOrWhiteSpace(xmOrderInfo.DeliveryAddress))
                sb.Append("收货人地域为空!");
            xmOrderInfo.DeliveryAddress = FilteSQLStr(xmOrderInfo.DeliveryAddress);
            decimal productPrice = 0;
            var xmOrderInfoProductDetailsList = xmOrderInfo.XM_OrderInfoProductDetails;
            var sb1 = new StringBuilder();
            var PlatformMerchantCodeList = xmOrderInfoProductDetailsList.Select(m => m.PlatformMerchantCode).ToList();
            var disPlatformMerchantCodeList = PlatformMerchantCodeList.Distinct().ToList();
            #region 判断是否有跨境商品
            if(haiPlatformMerchantCodes.Intersect(disPlatformMerchantCodeList).Count() > 0)
            {
                //if (string.IsNullOrWhiteSpace(xmOrderInfo.IdentityCard))
                //    sb.Append("收货人身份证号为空!");
                //if (string.IsNullOrWhiteSpace(xmOrderInfo.PaymentNo))
                //    sb.Append("支付单号为空!");
                //if (string.IsNullOrWhiteSpace(xmOrderInfo.OrderSeqNo))
                //    sb.Append("商家订单交易号为空!");
                //if (string.IsNullOrWhiteSpace(xmOrderInfo.Source))
                //    sb.Append("支付类型编号为空!");
            }
            #endregion
            if (disPlatformMerchantCodeList.Count != PlatformMerchantCodeList.Count)
            {
                sb.Append("商品信息中有多个相同的商品编号!");
            }
            else
            {
                foreach (var xmOrderInfoProductDetails in xmOrderInfoProductDetailsList)
                {
                   // xmOrderInfoProductDetails.ProductName = FilteSQLStr(xmOrderInfoProductDetails.ProductName);
                    if (string.IsNullOrWhiteSpace(xmOrderInfoProductDetails.PlatformMerchantCode))
                        sb1.Append("商品编码为空!");
                    if (xmOrderInfoProductDetails.ProductNum.GetValueOrDefault(-1) == -1)
                        sb1.Append("商品数量为空!");
                    if (xmOrderInfoProductDetails.SalesPrice.GetValueOrDefault(-1) == -1)
                        sb1.Append("商品销售价为空!");
                    if (sb1.Length != 0)//如果有错误
                    {
                        sb.Append(string.Format("商品编号是{0}的:{1}", xmOrderInfoProductDetails.PlatformMerchantCode, sb1.ToString()));
                        sb1.Clear();
                        continue;
                    }
                    productPrice += (decimal)(xmOrderInfoProductDetails.ProductNum * xmOrderInfoProductDetails.SalesPrice);

                }
            }
            //if (xmOrderInfo.ProductPrice != productPrice)
            //{
            //    sb.Append("订单的中的产品总金额不等于产品表中产品累加的总金额!");
            //}
            //if (xmOrderInfo.OrderPrice != productPrice + xmOrderInfo.DistributePrice.GetValueOrDefault(0) + xmOrderInfo.Taxes.GetValueOrDefault(0) - xmOrderInfo.OrderPromotion.GetValueOrDefault(0))
            //{
            //    sb.Append("订单金额不等于商品总价+运费+税费-优惠总金额!");
            //}
            if (sb.Length > startLength)
            {
                errorbag.Add(sb.ToString());
            }
          
        }
        /// <summary>
        /// 过滤不安全的字符串
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public string FilteSQLStr(string Str)
        {
            if (!string.IsNullOrWhiteSpace(Str))
            {
                Str = Str.Replace("'", "");
                Str = Str.Replace("&#039;", "");
                Str = Str.Replace("&#039", "");
                Str = Str.Replace("\"", "");
                Str = Str.Replace("/", "");
                Str = Str.Replace("&", "&amp");
                Str = Str.Replace("<", "&lt");
                Str = Str.Replace(">", "&gt");
                Str = Str.Replace("delete", "");
                Str = Str.Replace("update", "");
                Str = Str.Replace("insert", "");
            }
            return Str;
        }
        public void Dispose()
        {
            System.GC.Collect();
        }
    }
}