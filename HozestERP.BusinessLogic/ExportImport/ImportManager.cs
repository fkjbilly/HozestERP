using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;
using System.Web.Security;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageProductionOrder;
using JdSdk.Domain;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageApplication;

namespace HozestERP.BusinessLogic.ExportImport
{
    /// <summary>
    /// Import manager
    /// </summary>
    public partial class ImportManager : IImportManager
    {
        /// <summary>
        /// 亚马逊订单导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportAmazonOrderDataFromXls(string filePath, ref string paramMessage, string sourceType)
        {
            using (CSVHelper csvhelper = new CSVHelper(filePath))
            {
                int resultCount = 0;
                DataTable dt = null;

                #region
                dt = csvhelper.dt1("OrderReport");
                string a = dt.Columns[0].ColumnName;
                dt.DefaultView.RowFilter = " '亚马逊客户订单号' is not null and (Convert('亚马逊客户订单号', 'System.String')<>'') ";
                dt = dt.DefaultView.ToTable();
                foreach (DataRow row1 in dt.Rows)
                {
                    //获取行数据
                    string OrderCode = row1["\"亚马逊客户订单号\""] == null ? "" : row1["\"亚马逊客户订单号\""].ToString().Trim();
                    string DeliveryCode = row1["\"发货单ID\""] == null ? "" : row1["\"发货单ID\""].ToString().Trim();
                    string OrderStatus = row1["\"状态\""] == null ? "" : row1["\"状态\""].ToString().Trim();
                    string OrderInfoCreateDate = row1["\"订单接收日期\""] == null ? "" : row1["\"订单接收日期\""].ToString().Trim();
                    string OrderUpdateDate = row1["\"接受日期\""] == null ? "" : row1["\"接受日期\""].ToString().Trim();
                    string DeliveryTime = row1["\"发货日期\""] == null ? "" : row1["\"发货日期\""].ToString().Trim();
                    string DistributeCompany = row1["\"配送公司\""] == null ? "" : row1["\"配送公司\""].ToString().Trim();
                    string DistributeCode = row1["\"货运方式代码\""] == null ? "" : row1["\"货运方式代码\""].ToString().Trim();
                    string FullName = row1["\"收货人名\""] == null ? "" : row1["\"收货人名\""].ToString().Trim();
                    string Address1 = row1["\"收货地址第1行\""] == null ? "" : row1["\"收货地址第1行\""].ToString().Trim();
                    string Address2 = row1["\"收货地址第2行\""] == null ? "" : row1["\"收货地址第2行\""].ToString().Trim();
                    string Address3 = row1["\"收货地址第3行\""] == null ? "" : row1["\"收货地址第3行\""].ToString().Trim();
                    string City = row1["\"收货城市\""] == null ? "" : row1["\"收货城市\""].ToString().Trim();
                    string Province = row1["\"收货省\""] == null ? "" : row1["\"收货省\""].ToString().Trim();
                    string Zip = row1["\"收货地邮政编码\""] == null ? "" : row1["\"收货地邮政编码\""].ToString().Trim();
                    string Mobile = row1["\"收货人电话\""] == null ? "" : row1["\"收货人电话\""].ToString().Trim();
                    string ReceivablePrice1 = row1["\"应付金额\""] == null ? "" : row1["\"应付金额\""].ToString().Trim();
                    string ReceivablePrice = ReceivablePrice1.Replace("￥", "").Replace(",", "");
                    string OrderPrice1 = row1["\"成本\""] == null ? "" : row1["\"成本\""].ToString().Trim();
                    string OrderPrice = OrderPrice1.Replace("￥", "").Replace(",", "");
                    string PlatFormMerchant = row1["\"SKU/UPC\""] == null ? "" : row1["\"SKU/UPC\""].ToString().Trim();
                    string ProductNum = row1["\"订购的数量\""] == null ? "" : row1["\"订购的数量\""].ToString().Trim();

                    //根据订单号获取订单信息
                    var OrderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderByOrderCode("(" + DeliveryCode + ")" + OrderCode);

                    //新修改查询已审核的订单详细数据
                    var OrderInfo2 = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderId(OrderInfo.ID).Where(p => p.IsAudit == true).ToList();

                    #region 新增
                    if (OrderInfo == null)
                    {
                        OrderInfo = new XMOrderInfo();

                        OrderInfo.NickID = 1;
                        OrderInfo.PlatformTypeId = 376;
                        if (OrderInfoCreateDate != "")
                        {
                            OrderInfo.OrderInfoCreateDate = DateTime.Parse(OrderInfoCreateDate);
                        }
                        else
                        {
                            OrderInfo.OrderInfoCreateDate = DateTime.Now;
                        }
                        OrderInfo.PayDate = DateTime.Now;

                        //if (DeliveryTime != "")
                        //{
                        //    OrderInfo.DeliveryTime = DateTime.Parse(DeliveryTime);
                        //}
                        //else
                        //{
                        //    OrderInfo.DeliveryTime = DateTime.Parse(OrderInfo.OrderInfoCreateDate.ToString()).AddDays(5);
                        //}
                        //OrderInfo.CompletionTime = DateTime.Parse(OrderInfo.DeliveryTime.ToString()).AddDays(10);

                        if (OrderUpdateDate != "")
                        {
                            OrderInfo.OrderInfoModified = DateTime.Parse(OrderUpdateDate);
                        }
                        OrderInfo.OrderCode = "(" + DeliveryCode + ")" + OrderCode;
                        OrderInfo.OrderStatus = OrderStatus;
                        OrderInfo.FullName = FullName;
                        OrderInfo.Province = Province;
                        OrderInfo.City = City;
                        OrderInfo.DeliveryAddress = Address1 + Address2 + Address3 + "(" + Zip + ")";
                        OrderInfo.Mobile = Mobile;
                        OrderInfo.SourceType = sourceType;//"导入";
                        if (sourceType == "导入")
                        {
                            OrderInfo.FinancialAudit = true;
                        }
                        else
                        {
                            OrderInfo.FinancialAudit = false;
                        }
                        OrderInfo.DistributeMethod = DistributeCompany + "(" + DistributeCode + ")";
                        OrderInfo.OrderPrice = decimal.Parse(OrderPrice);
                        if (OrderInfo.OrderInfoCreateDate > DateTime.Parse("2015-03-01 00:00:00"))
                        {
                            //OrderInfo.IsScalping = IoC.Resolve<IXMOrderInfoService>().JudgeIsScalpingOrder(376, 1, OrderInfo.OrderCode, "", "", "", 0);//判断是否刷单

                        }
                        OrderInfo.IsCashBack = false;//是否返现
                        OrderInfo.IsSentGifts = false;//是否已发赠品 
                        OrderInfo.IsEvaluate = false;//是否赔付
                        OrderInfo.IsOurOrder = true;

                        //OrderyReport.IsHadPlanBill = false;//是否已排单
                        //OrderyReport.IsReDelivery = false;//是否重发
                        //OrderyReport.IsChangeGoods = false;//是否换货
                        //OrderyReport.IsReturnGoods = false;//是否退货
                        OrderInfo.IsEnable = false;

                        if (HozestERPContext.Current.User != null)
                        {
                            OrderInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                            OrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                        }
                        else
                        {
                            string UserName = "admin";
                            List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                            if (customer.Count > 0)
                            {
                                OrderInfo.CreateID = customer[0].CustomerID;
                                OrderInfo.UpdateID = customer[0].CustomerID;
                            }
                        }
                        OrderInfo.CreateDate = DateTime.Now;
                        OrderInfo.UpdateDate = DateTime.Now;

                        OrderInfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                        //京东Id查询产品所有关联信息
                        var ProductList = IoC.Resolve<XMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchant, 376);

                        var OrderyReportProduct = new XMOrderInfoProductDetails();

                        if (ProductList.Count > 0)
                        {
                            OrderyReportProduct.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                            OrderyReportProduct.Specifications = ProductList[0].Specifications;//尺寸
                            OrderyReportProduct.FactoryPrice = ProductList[0].Costprice * Convert.ToInt32(ProductNum);//出厂价
                            OrderyReportProduct.ProductName = ProductList[0].ProductName;//产品名称 
                            OrderyReportProduct.TCostprice = ProductList[0].Costprice;
                            OrderyReportProduct.SalesPrice = ProductList[0].Saleprice;//销售价
                            OrderyReportProduct.TManufacturersCode = ProductList[0].ManufacturersCode;
                        }
                        else
                        {
                            OrderyReportProduct.PlatformMerchantCode = ""; //料号（商品编码）
                            OrderyReportProduct.Specifications = "";//尺寸
                            OrderyReportProduct.FactoryPrice = 0;//出厂价
                            OrderyReportProduct.ProductName = "无产品";
                            OrderyReportProduct.SalesPrice = 0;//销售价
                            OrderyReportProduct.TManufacturersCode = "";
                        }

                        OrderyReportProduct.ProductNum = Convert.ToInt32(ProductNum);

                        if (DeliveryTime != null && DeliveryTime != "" && DeliveryTime != "0001-01-01 00:00:00")
                        {
                            OrderyReportProduct.CutoffShipDay = DateTime.Parse(DeliveryTime.ToString().Trim()).AddDays(+20);//截止发货日 
                        }

                        OrderyReportProduct.IsEnable = false;//是否删除
                        OrderyReportProduct.IsAudit = false;//是否审核
                        OrderyReportProduct.ISArrivedLibrary = false;//是否抵库
                        OrderyReportProduct.IsExpedited = false;//是否加急

                        if (HozestERPContext.Current.User != null)
                        {
                            OrderyReportProduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            OrderyReportProduct.UpdateID = HozestERPContext.Current.User.CustomerID;

                        }
                        else
                        {
                            string UserName = "admin";
                            List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                            if (customer.Count > 0)
                            {
                                OrderyReportProduct.CreateID = customer[0].CustomerID;
                                OrderyReportProduct.UpdateID = customer[0].CustomerID;
                            }
                        }

                        OrderyReportProduct.CreateDate = DateTime.Now;
                        OrderyReportProduct.UpdateDate = DateTime.Now;

                        OrderInfo.XM_OrderInfoProductDetails.Add(OrderyReportProduct);
                        resultCount++;
                        //保存数据
                        IoC.Resolve<XMOrderInfoService>().InsertXMOrderInfo(OrderInfo);
                    }
                    #endregion

                    #region 修改

                    //修改
                    else if (OrderInfo2 == null && OrderInfo != null)
                    {
                        if (OrderUpdateDate != "")
                        {
                            OrderInfo.OrderInfoModified = DateTime.Parse(OrderUpdateDate);
                        }
                        OrderInfo.OrderStatus = OrderStatus;
                        OrderInfo.FullName = FullName;
                        OrderInfo.Province = Province;
                        OrderInfo.City = City;
                        OrderInfo.DeliveryAddress = Address1 + Address2 + Address3 + "(" + Zip + ")";
                        OrderInfo.Mobile = Mobile;
                        OrderInfo.SourceType = sourceType;//"导入";
                        if (sourceType == "导入")
                        {
                            OrderInfo.FinancialAudit = true;
                        }
                        else
                        {
                            OrderInfo.FinancialAudit = false;
                        }
                        OrderInfo.DistributeMethod = DistributeCompany + "(" + DistributeCode + ")";
                        OrderInfo.OrderPrice = decimal.Parse(OrderPrice);

                        if (OrderInfo.OrderInfoCreateDate > DateTime.Parse("2015-03-01 00:00:00"))
                        {
                            //OrderInfo.IsScalping = IoC.Resolve<IXMOrderInfoService>().JudgeIsScalpingOrder(0, 0, OrderInfo.OrderCode, "", "", "", 0);//判断是否刷单
                        }

                        if (HozestERPContext.Current.User != null)
                        {
                            OrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        }
                        else
                        {
                            string UserName = "admin";
                            List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                            if (customer.Count > 0)
                            {
                                OrderInfo.UpdateID = customer[0].CustomerID;
                            }
                        }
                        OrderInfo.UpdateDate = DateTime.Now;

                        //京东Id查询产品所有关联信息
                        var ProductList = IoC.Resolve<XMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchant, 0);
                        //查询订单详情里关联商品信息
                        var OrderyReportProduct = OrderInfo.XM_OrderInfoProductDetails.SingleOrDefault(p => p.PlatformMerchantCode == PlatFormMerchant);

                        if (OrderyReportProduct != null)
                        {

                            if (ProductList.Count > 0)
                            {
                                OrderyReportProduct.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                OrderyReportProduct.Specifications = ProductList[0].Specifications;//尺寸
                                OrderyReportProduct.FactoryPrice = ProductList[0].Costprice * Convert.ToInt32(ProductNum);//出厂价
                                OrderyReportProduct.ProductName = ProductList[0].ProductName;//产品名称 
                                OrderyReportProduct.TCostprice = ProductList[0].Costprice;
                                OrderyReportProduct.SalesPrice = ProductList[0].Saleprice;//销售价
                                OrderyReportProduct.TManufacturersCode = ProductList[0].ManufacturersCode;
                            }
                            else
                            {
                                OrderyReportProduct.PlatformMerchantCode = ""; //料号（商品编码）
                                OrderyReportProduct.Specifications = "";//尺寸
                                OrderyReportProduct.FactoryPrice = 0;//出厂价
                                OrderyReportProduct.ProductName = "无产品";
                                OrderyReportProduct.SalesPrice = 0;//销售价
                                OrderyReportProduct.TManufacturersCode = "";
                            }

                            OrderyReportProduct.PlatformMerchantCode = PlatFormMerchant;//京东Id
                            OrderyReportProduct.ProductNum = Convert.ToInt32(ProductNum);

                            if (DeliveryTime != null && DeliveryTime != "" && DeliveryTime != "0001-01-01 00:00:00")
                            {
                                OrderyReportProduct.CutoffShipDay = DateTime.Parse(DeliveryTime.ToString().Trim()).AddDays(+20);//截止发货日 
                            }

                            if (HozestERPContext.Current.User != null)
                            {
                                OrderyReportProduct.UpdateID = HozestERPContext.Current.User.CustomerID;

                            }
                            else
                            {
                                string UserName = "admin";
                                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                                if (customer.Count > 0)
                                {
                                    OrderyReportProduct.UpdateID = customer[0].CustomerID;
                                }
                            }

                            OrderyReportProduct.UpdateDate = DateTime.Now;
                            resultCount++;

                            //保存数据
                            IoC.Resolve<XMOrderInfoService>().UpdateXMOrderInfo(OrderInfo);
                        }
                        else
                        {
                            OrderyReportProduct = new XMOrderInfoProductDetails();//初始化

                            if (ProductList.Count > 0)
                            {
                                OrderyReportProduct.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                OrderyReportProduct.Specifications = ProductList[0].Specifications;//尺寸
                                OrderyReportProduct.FactoryPrice = ProductList[0].Costprice * Convert.ToInt32(ProductNum);//出厂价
                                OrderyReportProduct.ProductName = ProductList[0].ProductName;//产品名称 
                                OrderyReportProduct.TCostprice = ProductList[0].Costprice;
                                OrderyReportProduct.SalesPrice = ProductList[0].Saleprice;//销售价
                                OrderyReportProduct.TManufacturersCode = ProductList[0].ManufacturersCode;
                            }
                            else
                            {
                                OrderyReportProduct.PlatformMerchantCode = ""; //料号（商品编码）
                                OrderyReportProduct.Specifications = "";//尺寸
                                OrderyReportProduct.FactoryPrice = 0;//出厂价
                                OrderyReportProduct.ProductName = "无产品";
                                OrderyReportProduct.SalesPrice = 0;//销售价
                                OrderyReportProduct.TManufacturersCode = "";
                            }

                            OrderyReportProduct.PlatformMerchantCode = PlatFormMerchant;//京东Id
                            OrderyReportProduct.ProductNum = Convert.ToInt32(ProductNum);

                            if (DeliveryTime != null && DeliveryTime != "" && DeliveryTime != "0001-01-01 00:00:00")
                            {
                                OrderyReportProduct.CutoffShipDay = DateTime.Parse(DeliveryTime.ToString().Trim()).AddDays(+20);//截止发货日 
                            }

                            OrderyReportProduct.IsEnable = false;//是否删除
                            OrderyReportProduct.IsAudit = false;//是否审核
                            OrderyReportProduct.ISArrivedLibrary = false;//是否抵库
                            OrderyReportProduct.IsExpedited = false;//是否加急

                            if (HozestERPContext.Current.User != null)
                            {
                                OrderyReportProduct.CreateID = HozestERPContext.Current.User.CustomerID;
                                OrderyReportProduct.UpdateID = HozestERPContext.Current.User.CustomerID;

                            }
                            else
                            {
                                string UserName = "admin";
                                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                                if (customer.Count > 0)
                                {
                                    OrderyReportProduct.CreateID = customer[0].CustomerID;
                                    OrderyReportProduct.UpdateID = customer[0].CustomerID;
                                }
                            }

                            OrderyReportProduct.CreateDate = DateTime.Now;
                            OrderyReportProduct.UpdateDate = DateTime.Now;
                            OrderInfo.XM_OrderInfoProductDetails.Add(OrderyReportProduct);
                            resultCount++;

                            //保存数据
                            IoC.Resolve<XMOrderInfoService>().UpdateXMOrderInfo(OrderInfo);
                        }
                    }

                    #endregion
                }
                #endregion

                if (dt != null)
                {

                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条。";
                    }
                }
            }
        }

        /// <summary>
        /// 京东、唯品会 、亚马逊、京东众筹 国美金立 订单导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="weekDate"></param>
        /// <param name="PlatformTypeName">平台类型</param>
        /// <param name="paramMessage"></param>
        public void ImportOrderFromXls(string filePath, DateTime weekDate, int PlatformTypeNameId, int NickId, string PlatformTypeName, string FileName, ref string paramMessage, string sourceType)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";

                int resultCount = 0;
                int IsAuditCount = 0;
                DataTable dt = null;

                #region 京东
                if (PlatformTypeName == "京东")
                {
                    if (FileName.Trim() == "京东")
                    {
                        dt = excelHelper.ReadTable("京东");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            //订单详情
                            var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());

                            //产品编码
                            string PlatFormMerchantCode = row1["商品ID"].ToString().Trim();
                            //京东Id查询。
                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 0);
                            //新修改查询已审核的订单详细数据
                            List<XMOrderInfoProductDetails> OrderInfo2 = new List<XMOrderInfoProductDetails>();
                            if (xmorderinfo != null)
                            {
                                OrderInfo2 = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderId(xmorderinfo.ID).Where(p => p.IsAudit == true).ToList();
                            }

                            if (xmorderinfo == null)
                            {
                                #region 新增
                                xmorderinfo = new XMOrderInfo();
                                xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订购数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["订购数量"].ToString().Trim()));
                                DateTime payDate = (row1["付款确认时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款确认时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;

                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }
                                xmorderinfo.WantID = row1["下单帐号"].ToString().Trim();
                                xmorderinfo.FullName = row1["客户姓名"].ToString().Trim();
                                xmorderinfo.Province = "";
                                xmorderinfo.City = "";
                                xmorderinfo.County = "";
                                xmorderinfo.Tel = "";
                                xmorderinfo.DeliveryAddress = row1["客户地址"].ToString().Trim();
                                string Mobile = row1["联系电话"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["联系电话"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }

                                #region 备注
                                string Remarks = row1["商家备注"].ToString().Trim();

                                if (Remarks.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = Remarks;
                                }
                                else
                                {
                                    string suRemarks = Remarks.Substring(Remarks.LastIndexOf("'") + 1).ToLower();// 取号
                                    xmorderinfo.Remark = suRemarks;
                                }
                                #endregion

                                #region 返现、赠品
                                if (Remarks != null && Remarks != "")
                                {
                                    //string CashBackMoney = "";//返现金额
                                    //string BuyerName = row1["收货人姓名"].ToString().Trim();//姓名
                                    //string BuyerAlipayNoS = row1["买家支付宝账号"].ToString().Trim();//收款账号
                                    //string WantNo = row1["买家会员名"].ToString().Trim();//旺旺号
                                    //string OrderCode = row1["订单编号"].ToString().Trim();//订单号  
                                    #region 赠品、返现

                                    //#region 返现
                                    //if (Remarks.IndexOf("返现") > -1)
                                    //{
                                    //    //根据订单号查询 返现信息中是否已经存在 现有订单 
                                    //    var XMCashBackApplicationList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationByOrderCode(OrderCode);

                                    //    if (XMCashBackApplicationList.Count == 0)
                                    //    {
                                    //        string e = Remarks.Substring(Remarks.IndexOf("返现") + 2);
                                    //        int f = e.IndexOf("元/");

                                    //        if (f > -1)
                                    //        {
                                    //            CashBackMoney = e.Substring(0, f);//OrderRemark.Substring(OrderRemark.IndexOf("返现") + 2, OrderRemark.IndexOf("元/") - 2); 
                                    //        }
                                    //        decimal d = 0;

                                    //        if (decimal.TryParse(CashBackMoney, out d))//类型转换
                                    //        {
                                    //            if (CashBackMoney != "" && BuyerName != "" && BuyerAlipayNoS != "")
                                    //            {
                                    //                IoC.Resolve<IXMCashBackApplicationService>().InsertXMCashBackApplication(OrderCode, WantNo, BuyerName, Convert.ToDecimal(CashBackMoney), BuyerAlipayNoS);
                                    //            }
                                    //        }
                                    //    }
                                    //}

                                    //#endregion

                                    //#region 赠品
                                    ////string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    ////string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    ////string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    ////string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    //string PremiumsActivityExplanation = "";//活动说明
                                    //string PremiumsPrdouctName = "";//商品名称
                                    //string PremiumsPlatformMerchantCode = "";//商品编码
                                    //string PremiumsFactoryPrice = "0";//出厂价
                                    //string PremiumsProductNum = "0";//数量
                                    //string Specifications = "";//尺寸    
                                    //int ProductDetaislId = -1;


                                    //if (Remarks.IndexOf("赠品") > -1)
                                    //{
                                    //    //判断赠品申请表中是否已经存在 相同订单号
                                    //    var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode);

                                    //    if (premiumsList.Count == 0)
                                    //    {
                                    //        string s = Remarks.Substring(Remarks.IndexOf("赠品") + 3);
                                    //        int f = s.IndexOf("/");
                                    //        if (f > -1)
                                    //        {
                                    //            PremiumsActivityExplanation = s.Substring(0, f);

                                    //            #region 去除赠品、：、3个字符 （长度等于2）
                                    //            if (f == 2)
                                    //            {
                                    //                PremiumsPrdouctName = s.Substring(0, f);

                                    //                PremiumsProductNum = "1";

                                    //                if (PremiumsPrdouctName != "")
                                    //                {
                                    //                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                    //                    if (xmProductList.Count > 0)
                                    //                    {
                                    //                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                    //                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                    //                        ProductDetaislId = xmProductList[0].Id;
                                    //                    }
                                    //                }

                                    //                decimal d = 0;
                                    //                int INum = 0;
                                    //                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                    //                {
                                    //                    //主表信息
                                    //                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, PremiumsActivityExplanation);
                                    //                    //明细信息
                                    //                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                    //                }
                                    //                PremiumsActivityExplanation = "";//活动说明
                                    //                PremiumsPrdouctName = "";//商品名称
                                    //                PremiumsPlatformMerchantCode = "";//商品编码
                                    //                PremiumsFactoryPrice = "0";//出厂价
                                    //                PremiumsProductNum = "0";//数量
                                    //                Specifications = "";//尺寸    
                                    //                ProductDetaislId = -1;

                                    //            }
                                    //            #endregion
                                    //            #region 字符大于2个字符
                                    //            else if (f > 2)
                                    //            {
                                    //                string[] J = PremiumsActivityExplanation.Split('+');

                                    //                string strNum = "";//数量字符

                                    //                #region 多个赠品
                                    //                if (PremiumsActivityExplanation != "" && J.Length > 1)
                                    //                {
                                    //                    for (int Ji = 0; Ji < J.Length; Ji++)
                                    //                    {
                                    //                        string pe = J[Ji];
                                    //                        string remsub = "";//尺寸+商品名称字符

                                    //                        if (pe != "")
                                    //                        {
                                    //                            #region 尺寸、商品名称
                                    //                            if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                    //                            {
                                    //                                string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                    //                                int b = a1.IndexOf("）");
                                    //                                int c = pe.IndexOf("（");

                                    //                                if (c > -1)
                                    //                                {
                                    //                                    PremiumsPrdouctName = pe.Substring(0, c);
                                    //                                    remsub += PremiumsPrdouctName;
                                    //                                }

                                    //                                if (b > -1)
                                    //                                {
                                    //                                    Specifications = a1.Substring(0, b);
                                    //                                    remsub += "（" + Specifications + "）";
                                    //                                }

                                    //                            }
                                    //                            if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                    //                            {

                                    //                                string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                    //                                int b = a1.IndexOf(")");
                                    //                                int c = pe.IndexOf("(");
                                    //                                if (c > -1)
                                    //                                {
                                    //                                    PremiumsPrdouctName = pe.Substring(0, c);
                                    //                                    remsub += PremiumsPrdouctName;
                                    //                                }
                                    //                                if (b > -1)
                                    //                                {
                                    //                                    Specifications = a1.Substring(0, b);

                                    //                                    remsub += "(" + Specifications + ")";
                                    //                                }

                                    //                            }
                                    //                            #endregion
                                    //                            #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                    //                            int Intd = pe.IndexOf(remsub);
                                    //                            if (Intd > -1)
                                    //                            {
                                    //                                strNum = pe.Substring(remsub.Length).ToLower();
                                    //                            }
                                    //                            if (strNum != "")
                                    //                            {
                                    //                                //数量
                                    //                                if (strNum.IndexOf("*") > -1)
                                    //                                {
                                    //                                    string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                    //                                    PremiumsProductNum = a1;
                                    //                                }
                                    //                                else
                                    //                                {
                                    //                                    PremiumsProductNum = "1";
                                    //                                }
                                    //                            }
                                    //                            else
                                    //                            {

                                    //                                PremiumsProductNum = "1";
                                    //                            }

                                    //                            #endregion

                                    //                            if (PremiumsPrdouctName == "")
                                    //                            {

                                    //                                PremiumsPrdouctName = pe;
                                    //                            }
                                    //                            if (PremiumsPrdouctName != "")
                                    //                            {
                                    //                                var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                    //                                if (PremiumsPrdouctName != "" && Specifications != "")
                                    //                                {
                                    //                                    xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                    //                                }
                                    //                                if (xmProductList.Count > 0)
                                    //                                {
                                    //                                    ProductDetaislId = xmProductList[0].Id;
                                    //                                    PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                    //                                    PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                    //                                }

                                    //                            }


                                    //                            decimal d = 0;
                                    //                            int INum = 0;
                                    //                            if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                    //                            {
                                    //                                //主表信息
                                    //                                int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, PremiumsActivityExplanation);
                                    //                                //明细信息
                                    //                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                    //                            }
                                    //                            //PremiumsActivityExplanation = "";//活动说明
                                    //                            PremiumsPrdouctName = "";//商品名称
                                    //                            PremiumsPlatformMerchantCode = "";//商品编码
                                    //                            PremiumsFactoryPrice = "0";//出厂价
                                    //                            PremiumsProductNum = "0";//数量
                                    //                            Specifications = "";//尺寸    
                                    //                            ProductDetaislId = -1;
                                    //                        }
                                    //                    }

                                    //                }
                                    //                #endregion
                                    //                #region 单个赠品
                                    //                else
                                    //                {

                                    //                    string strNum1 = "";//数量字符
                                    //                    string remsub = "";//尺寸+商品名称字符
                                    //                    string PEl = PremiumsActivityExplanation;
                                    //                    #region 尺寸、商品名称
                                    //                    if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                    //                    {
                                    //                        string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                    //                        int b = a.IndexOf("）");
                                    //                        int c = PEl.IndexOf("（");
                                    //                        if (c > -1)
                                    //                        {
                                    //                            PremiumsPrdouctName = PEl.Substring(0, c);
                                    //                            remsub += PremiumsPrdouctName;
                                    //                        }
                                    //                        if (b > -1)
                                    //                        {
                                    //                            Specifications = a.Substring(0, b);
                                    //                            remsub += "（" + Specifications + "）";
                                    //                        }

                                    //                    }
                                    //                    if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                    //                    {

                                    //                        string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                    //                        int b = a.IndexOf(")");
                                    //                        int c = PEl.IndexOf("(");
                                    //                        if (c > -1)
                                    //                        {
                                    //                            PremiumsPrdouctName = PEl.Substring(0, c);
                                    //                            remsub += PremiumsPrdouctName;
                                    //                        }
                                    //                        if (b > -1)
                                    //                        {
                                    //                            Specifications = a.Substring(0, b);

                                    //                            remsub += "(" + Specifications + ")";
                                    //                        }
                                    //                    }
                                    //                    #endregion

                                    //                    #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                    //                    int Intd = PEl.IndexOf(remsub);
                                    //                    if (Intd > -1)
                                    //                    {
                                    //                        strNum1 = PEl.Substring(remsub.Length).ToLower();
                                    //                    }
                                    //                    if (strNum1 != "")
                                    //                    {
                                    //                        //数量
                                    //                        if (strNum1.IndexOf("*") > -1)
                                    //                        {
                                    //                            string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                    //                            PremiumsProductNum = a;

                                    //                            if (PremiumsPrdouctName == "")
                                    //                            {
                                    //                                PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                    //                            }
                                    //                        }
                                    //                        else
                                    //                        {
                                    //                            PremiumsProductNum = "1";
                                    //                        }
                                    //                    }
                                    //                    else
                                    //                    {
                                    //                        PremiumsProductNum = "1";
                                    //                    }

                                    //                    #endregion
                                    //                    if (PremiumsPrdouctName != "")
                                    //                    {
                                    //                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                    //                        if (PremiumsPrdouctName != "" && Specifications != "")
                                    //                        {
                                    //                            xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                    //                        }
                                    //                        if (xmProductList.Count > 0)
                                    //                        {
                                    //                            ProductDetaislId = xmProductList[0].Id;
                                    //                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                    //                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                    //                        }

                                    //                    }

                                    //                    decimal d = 0;
                                    //                    int INum = 0;
                                    //                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                    //                    {
                                    //                        //主表信息
                                    //                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, PremiumsActivityExplanation);
                                    //                        //明细信息
                                    //                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                    //                    }
                                    //                    PremiumsActivityExplanation = "";//活动说明
                                    //                    PremiumsPrdouctName = "";//商品名称
                                    //                    PremiumsPlatformMerchantCode = "";//商品编码
                                    //                    PremiumsFactoryPrice = "0";//出厂价
                                    //                    PremiumsProductNum = "0";//数量
                                    //                    Specifications = "";//尺寸    
                                    //                    ProductDetaislId = -1;
                                    //                }
                                    //                #endregion
                                    //            }
                                    //            #endregion
                                    //        }
                                    //    }
                                    //}
                                    //#endregion

                                    #endregion
                                }
                                #endregion

                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id 

                                string OrderStatus = row1["订单状态"].ToString().Trim();
                                if (OrderStatus == "锁定")
                                {
                                    xmorderinfo.OrderStatus = "LOCKED";
                                }
                                if (OrderStatus == "等待出库")
                                {
                                    xmorderinfo.OrderStatus = "WAIT_SELLER_STOCK_OUT";
                                }
                                if (OrderStatus == "预售")
                                {
                                    xmorderinfo.OrderStatus = "PRE_SALE";
                                }

                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.IsEnable = false;//是否删除
                                xmorderinfo.IsCashBack = false;//是否返现
                                xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                xmorderinfo.IsEvaluate = false;//是否赔付
                                xmorderinfo.IsOurOrder = true;
                                xmorderinfo.CreateDate = DateTime.Now;
                                xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    xmorderinfopd.SalesPrice = ProductList[0].Saleprice * ProductNumV;
                                }
                                else
                                {
                                    xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = "";//尺寸
                                    xmorderinfopd.FactoryPrice = 0;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                    xmorderinfopd.SalesPrice = 0;
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                //decimal SalesPriceV = Convert.ToDecimal(row1["结算金额"].ToString().Trim());//销售价
                                //xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价

                                xmorderinfo.OrderPrice = Convert.ToDecimal(row1["订单金额"].ToString().Trim());
                                xmorderinfo.PayPrice = Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                xmorderinfo.ReceivablePrice = Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                xmorderinfo.ProductPrice = xmorderinfopd.SalesPrice;

                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.IsAudit = false;//是否审核
                                xmorderinfopd.IsExpedited = false;//是否加急
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                resultCount++;
                                #endregion
                            }
                            else if (xmorderinfo != null && (OrderInfo2 == null || OrderInfo2.Count == 0))
                            {
                                #region 修改

                                //xmorderinfo = new XMOrderInfo();
                                //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订购数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["订购数量"].ToString().Trim()));
                                DateTime payDate = (row1["付款确认时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款确认时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;
                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }
                                xmorderinfo.WantID = row1["下单帐号"].ToString().Trim();
                                xmorderinfo.FullName = row1["客户姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["客户地址"].ToString().Trim();
                                string Mobile = row1["联系电话"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["联系电话"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }

                                #region 备注
                                string Remarks = row1["商家备注"].ToString().Trim();

                                if (Remarks.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = Remarks;
                                }
                                #endregion

                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id

                                string OrderStatus = row1["订单状态"].ToString().Trim();
                                if (OrderStatus == "锁定")
                                {
                                    xmorderinfo.OrderStatus = "LOCKED";
                                }
                                if (OrderStatus == "等待出库")
                                {
                                    xmorderinfo.OrderStatus = "WAIT_SELLER_STOCK_OUT";
                                }
                                if (OrderStatus == "预售")
                                {
                                    xmorderinfo.OrderStatus = "PRE_SALE";
                                }

                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                //订单明细信息
                                var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);
                                if (xmorderinfopdList.Count == 0)
                                {
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                        xmorderinfopd.SalesPrice = ProductList[0].Saleprice * ProductNumV;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = "";//尺寸
                                        xmorderinfopd.FactoryPrice = 0;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                        xmorderinfopd.SalesPrice = 0;
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    //decimal SalesPriceV = Convert.ToDecimal(row1["结算金额"].ToString().Trim());//销售价
                                    //xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价

                                    xmorderinfo.OrderPrice = Convert.ToDecimal(row1["订单金额"].ToString().Trim());
                                    xmorderinfo.PayPrice = Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                    xmorderinfo.ReceivablePrice = Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                    xmorderinfo.ProductPrice += xmorderinfopd.SalesPrice;

                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                }
                                else
                                {
                                    //订单明细修改 
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];
                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.SalesPrice = ProductList[0].Saleprice * ProductNumV;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = "";//尺寸
                                        xmorderinfopd.FactoryPrice = 0;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.SalesPrice = 0;
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    //decimal SalesPriceV = Convert.ToDecimal(row1["结算金额"].ToString().Trim());//销售价
                                    //xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价 
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);
                                }
                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                                //paramMessage += "订单号:" + row1["订单号"].ToString() + ";商品ID:" + row1["商品ID"].ToString() + "已存在" + "\t\n";
                            }
                        }
                        // }
                    }
                    else
                    {
                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }

                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }

                }
                #endregion

                #region 唯品会
                if (PlatformTypeName == "唯品会")
                {
                    #region 唯品会
                    if (FileName.Trim() == "唯品会")
                    {
                        dt = excelHelper.ReadTable("唯品会");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        // dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0) and  Convert(订单号, 'System.String')<>'-'";
                        //注excle行中是"-"表示与上一条信息相同
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            string ProductName = row1["商品名称"].ToString().Trim();

                            if (ProductName.IndexOf("儿童床垫") == -1 && ProductName.IndexOf("青少年床垫") == -1 && ProductName.IndexOf("亲子床垫") == -1 && ProductName.IndexOf("青少年定制床垫") == -1 && ProductName.IndexOf("独立弹簧乳胶可拆卸床垫") == -1)
                            {
                                if (row1["订单号"].ToString().Trim() == "-" && row1["订单状态"].ToString().Trim() == "-" && row1["下单时间"].ToString().Trim() == "-"
                                        && row1["订单变更时间"].ToString().Trim() == "-" && row1["供应商"].ToString().Trim() == "-" && row1["收货时间"].ToString().Trim() == "-"
                                        && row1["收货人"].ToString().Trim() == "-" && row1["收货地址"].ToString().Trim() == "-" && row1["联系电话"].ToString().Trim() == "-")
                                {

                                    int rowcount = dt.Rows.IndexOf(row1);

                                    string orderCode = "";
                                    DateTime payDate = new DateTime();
                                    DateTime OrderInfoModified = new DateTime();
                                    string FullName = "";
                                    string DeliveryAddress = "";
                                    decimal SalesPriceV = 0;//销售价
                                    string Mobile = "";
                                    string Tel = "";
                                    string shsj = "";//收货时间
                                    string fpxx = ""; //发票信息
                                    string Remarks = "";//备注
                                    string OrderStatus = "";

                                    int j = 1;
                                    if (rowcount < 10)
                                    {
                                        j = rowcount;
                                    }
                                    else
                                    {
                                        j = 10;
                                    }
                                    for (int i = 1; i <= j; j++)
                                    {
                                        #region  取相同订单信息
                                        if (dt.Rows[rowcount - i]["订单号"].ToString() == "-" && dt.Rows[rowcount - i]["下单时间"].ToString() == "-" && dt.Rows[rowcount - i]["收货人"].ToString() == "-"
                                            && dt.Rows[rowcount - i]["收货地址"].ToString().Trim() == "-" && dt.Rows[rowcount - i]["联系电话"].ToString().Trim() == "-" && dt.Rows[rowcount - i]["座机号"].ToString().Trim() == "-" && dt.Rows[rowcount - i]["收货时间"].ToString().Trim() == "-"
                                            && dt.Rows[rowcount - i]["发票信息"].ToString().Trim() == "-")
                                        {
                                            if (dt.Rows[rowcount - i - 1]["订单号"].ToString() != "-" && dt.Rows[rowcount - i - 1]["下单时间"].ToString() != "-" && dt.Rows[rowcount - i - 1]["收货人"].ToString() != "-"
                                            && dt.Rows[rowcount - i - 1]["收货地址"].ToString().Trim() != "-" && dt.Rows[rowcount - i - 1]["联系电话"].ToString().Trim() != "-" && dt.Rows[rowcount - i - 1]["座机号"].ToString().Trim() != "-" && dt.Rows[rowcount - i - 1]["收货时间"].ToString().Trim() != "-"
                                            && dt.Rows[rowcount - i - 1]["发票信息"].ToString().Trim() != "-")
                                            {
                                                orderCode = dt.Rows[rowcount - i - 1]["订单号"].ToString();
                                                payDate = (dt.Rows[rowcount - i - 1]["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(dt.Rows[rowcount - i - 1]["下单时间"].ToString().Trim()));
                                                OrderInfoModified = (dt.Rows[rowcount - i - 1]["订单变更时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(dt.Rows[rowcount - i - 1]["订单变更时间"].ToString().Trim()));
                                                FullName = dt.Rows[rowcount - i - 1]["收货人"].ToString();
                                                DeliveryAddress = dt.Rows[rowcount - i - 1]["收货地址"].ToString().Trim();
                                                SalesPriceV = Convert.ToDecimal(dt.Rows[rowcount - i - 1]["发票金额"].ToString().Trim());
                                                Mobile = dt.Rows[rowcount - i - 1]["联系电话"].ToString().Trim();
                                                Tel = dt.Rows[rowcount - i - 1]["座机号"].ToString().Trim();
                                                shsj = dt.Rows[rowcount - i - 1]["收货时间"].ToString().Trim();
                                                fpxx = dt.Rows[rowcount - i - 1]["发票信息"].ToString().Trim();
                                                Remarks = dt.Rows[rowcount - i - 1]["备注"].ToString().Trim();
                                                OrderStatus = dt.Rows[rowcount - i - 1]["订单状态"].ToString().Trim();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            orderCode = dt.Rows[rowcount - 1]["订单号"].ToString();
                                            payDate = (dt.Rows[rowcount - 1]["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(dt.Rows[rowcount - 1]["下单时间"].ToString().Trim()));
                                            OrderInfoModified = (dt.Rows[rowcount - 1]["订单变更时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(dt.Rows[rowcount - 1]["订单变更时间"].ToString().Trim()));
                                            FullName = dt.Rows[rowcount - 1]["收货人"].ToString();
                                            DeliveryAddress = dt.Rows[rowcount - 1]["收货地址"].ToString().Trim();
                                            SalesPriceV = Convert.ToDecimal(dt.Rows[rowcount - 1]["发票金额"].ToString().Trim());
                                            Mobile = dt.Rows[rowcount - 1]["联系电话"].ToString().Trim();
                                            Tel = dt.Rows[rowcount - 1]["座机号"].ToString().Trim();
                                            shsj = dt.Rows[rowcount - 1]["收货时间"].ToString().Trim();
                                            fpxx = dt.Rows[rowcount - 1]["发票信息"].ToString().Trim();
                                            Remarks = dt.Rows[rowcount - 1]["备注"].ToString().Trim();
                                            OrderStatus = dt.Rows[rowcount - 1]["订单状态"].ToString().Trim();
                                            break;
                                        }
                                        #endregion
                                    }
                                    //订单信息
                                    var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(orderCode);
                                    //货号 (商品编码)
                                    string PlatFormMerchantCode = row1["货号"].ToString().Trim();

                                    if (xmorderinfo != null)
                                    {
                                        #region 修改

                                        xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                        xmorderinfo.NickID = NickId;
                                        xmorderinfo.OrderCode = orderCode;
                                        xmorderinfo.PayDate = payDate;
                                        xmorderinfo.OrderInfoCreateDate = payDate;
                                        xmorderinfo.OrderInfoModified = OrderInfoModified;
                                        if (payDate != null)
                                        {
                                            xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                        }

                                        #region 订单状态

                                        if (OrderStatus == "订单已审核")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_AUDITED";//唯品会订单状态
                                        }
                                        if (OrderStatus == "订单已取消")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_CANCEL";//唯品会订单状态
                                        }
                                        if (OrderStatus == "订单已发货")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_SHIP";//唯品会订单状态
                                        }
                                        #endregion

                                        #region 收货人信息
                                        xmorderinfo.FullName = FullName;
                                        xmorderinfo.DeliveryAddress = DeliveryAddress;

                                        if (Mobile.IndexOf("'") == -1)
                                        {
                                            xmorderinfo.Mobile = Mobile;
                                        }
                                        else
                                        {
                                            string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                            xmorderinfo.Mobile = suMobile;
                                        }
                                        xmorderinfo.Tel = Tel;

                                        #endregion

                                        #region 备注
                                        string CustomerServiceRemarkValue = "";

                                        if (Remarks.IndexOf("'") == -1)//没有’
                                        {
                                            CustomerServiceRemarkValue = Remarks;
                                        }
                                        else
                                        {
                                            string suRemarks = Remarks.Substring(Remarks.LastIndexOf("'") + 1).ToLower();// 取'号  
                                            CustomerServiceRemarkValue = suRemarks;
                                        }

                                        #endregion

                                        xmorderinfo.InvoiceHead = fpxx;//发票抬头  
                                        xmorderinfo.InvoicePrice = SalesPriceV;//发票金额 
                                        decimal UnitPrice = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价  

                                        if (fpxx != "")
                                        {
                                            xmorderinfo.CustomerServiceRemark = CustomerServiceRemarkValue + "/收货时间:" + shsj + "/发票信息:" + fpxx + "/发票金额:" + SalesPriceV.ToString();
                                        }
                                        else
                                        {
                                            xmorderinfo.CustomerServiceRemark = CustomerServiceRemarkValue + "/收货时间:" + shsj + "/发票金额:" + SalesPriceV.ToString();
                                        }

                                        xmorderinfo.PayPrice = UnitPrice;

                                        //xmorderinfo.SourceType = "导入";
                                        xmorderinfo.SourceType = sourceType;//"导入";
                                        if (sourceType == "导入")
                                        {
                                            xmorderinfo.FinancialAudit = true;
                                        }
                                        else
                                        {
                                            xmorderinfo.FinancialAudit = false;
                                        }
                                        xmorderinfo.UpdateDate = DateTime.Now;
                                        xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                        #region 明细
                                        //商家编码查询。
                                        var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 0);
                                        int ProductNumV = (row1["数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["数量"].ToString().Trim()));
                                        //订单明细
                                        var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);

                                        if (xmorderinfopdList.Count == 0)
                                        {
                                            #region 新增
                                            //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                            XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                            xmorderinfopd.ProductNum = ProductNumV;
                                            xmorderinfopd.OrderInfoID = xmorderinfo.ID;
                                            if (ProductList.Count > 0)
                                            {
                                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                                xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                                xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称 
                                                xmorderinfopd.TCostprice = ProductList[0].TCostprice;//特供价
                                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                            }
                                            else
                                            {
                                                xmorderinfopd.PlatformMerchantCode = row1["货号"].ToString().Trim();
                                                xmorderinfopd.Specifications = row1["尺寸"].ToString().Trim();//尺寸
                                                xmorderinfopd.FactoryPrice = 0;//出厂价
                                                xmorderinfopd.ProductName = "无产品";
                                                xmorderinfopd.TCostprice = 0;//特供价
                                                xmorderinfopd.TManufacturersCode = "";
                                            }
                                            xmorderinfopd.CutoffShipDay = payDate.AddDays(+20);//截止发货日  
                                            xmorderinfopd.SalesPrice = UnitPrice * ProductNumV;//销售价 
                                            xmorderinfopd.ISArrivedLibrary = false;
                                            xmorderinfopd.IsAudit = false;//是否审核
                                            xmorderinfopd.IsExpedited = false;//是否加急
                                            xmorderinfopd.IsEnable = false;
                                            xmorderinfopd.CreateDate = DateTime.Now;
                                            xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                            xmorderinfopd.UpdateDate = DateTime.Now;
                                            xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;

                                            IoC.Resolve<IXMOrderInfoProductDetailsService>().InsertXMOrderInfoProductDetails(xmorderinfopd);
                                            //xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                            #endregion
                                        }
                                        else
                                        {
                                            #region 修改
                                            XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];
                                            xmorderinfopd.ProductNum = ProductNumV;
                                            if (ProductList.Count > 0)
                                            {
                                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                                xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                                xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称 
                                                xmorderinfopd.TCostprice = ProductList[0].TCostprice;//特供价
                                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                            }
                                            else
                                            {
                                                xmorderinfopd.PlatformMerchantCode = row1["货号"].ToString().Trim();
                                                xmorderinfopd.Specifications = row1["尺寸"].ToString().Trim();//尺寸
                                                xmorderinfopd.FactoryPrice = 0;//出厂价
                                                xmorderinfopd.ProductName = "无产品";
                                                xmorderinfopd.TCostprice = 0;//特供价
                                                xmorderinfopd.TManufacturersCode = "";
                                            }
                                            xmorderinfopd.CutoffShipDay = payDate.AddDays(+20);//截止发货日  
                                            xmorderinfopd.SalesPrice = UnitPrice * ProductNumV;//销售价  
                                            xmorderinfopd.UpdateDate = DateTime.Now;
                                            xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;

                                            IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                            #endregion
                                        }

                                        #endregion

                                        IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                        resultCount++;


                                        #endregion
                                    }
                                }
                                else
                                {

                                    string orderCode = row1["订单号"].ToString().Trim();
                                    //订单信息
                                    var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(orderCode);
                                    //货号 (商品编码)
                                    string Merchantcode = row1["货号"].ToString().Trim();
                                    if (xmorderinfo == null)
                                    {
                                        #region 新增
                                        xmorderinfo = new XMOrderInfo();
                                        //明细对象
                                        xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                        xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                        xmorderinfo.NickID = NickId;

                                        xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                        DateTime payDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                        DateTime OrderInfoModified = (row1["订单变更时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["订单变更时间"].ToString().Trim()));
                                        xmorderinfo.PayDate = payDate;
                                        xmorderinfo.OrderInfoCreateDate = payDate;
                                        xmorderinfo.OrderInfoModified = OrderInfoModified;
                                        if (payDate != null)
                                        {
                                            xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                        }

                                        #region 订单状态
                                        string OrderStatus = row1["订单状态"].ToString().Trim();

                                        if (OrderStatus == "订单已审核")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_AUDITED";//唯品会订单状态
                                        }
                                        if (OrderStatus == "订单已取消")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_CANCEL";//唯品会订单状态
                                        }
                                        if (OrderStatus == "订单已发货")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_SHIP";//唯品会订单状态
                                        }
                                        #endregion

                                        #region 收货人信息
                                        xmorderinfo.FullName = row1["收货人"].ToString().Trim();

                                        xmorderinfo.DeliveryAddress = row1["收货地址"].ToString().Trim();

                                        string Mobile = row1["联系电话"].ToString().Trim();
                                        if (Mobile.IndexOf("'") == -1)
                                        {
                                            xmorderinfo.Mobile = row1["联系电话"].ToString().Trim();
                                        }
                                        else
                                        {
                                            string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                            xmorderinfo.Mobile = suMobile;
                                        }
                                        xmorderinfo.Tel = row1["座机号"].ToString().Trim();

                                        #endregion

                                        #region 备注

                                        string Remarks = row1["备注"].ToString().Trim();//备注

                                        //string strRemarksValue = "";
                                        string CustomerServiceRemarkValue = "";

                                        if (Remarks.IndexOf("'") == -1)//没有’
                                        {
                                            CustomerServiceRemarkValue = Remarks;
                                        }
                                        else
                                        {
                                            string suRemarks = Remarks.Substring(Remarks.LastIndexOf("'") + 1).ToLower();// 取'号 

                                            CustomerServiceRemarkValue = suRemarks;
                                        }

                                        #endregion

                                        xmorderinfo.InvoiceHead = row1["发票信息"].ToString().Trim();//发票抬头

                                        decimal InvoicePriceD = (row1["发票金额"].ToString().Trim() == "" ? 0 : decimal.Parse(row1["发票金额"].ToString().Trim()));

                                        xmorderinfo.InvoicePrice = InvoicePriceD;//发票金额

                                        string shsj = row1["收货时间"].ToString().Trim();//收货时间
                                        string fpxx = row1["发票信息"].ToString().Trim(); //发票信息
                                        decimal SalesPriceV = Convert.ToDecimal(row1["发票金额"].ToString().Trim());//销售价

                                        decimal UnitPrice = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价 

                                        //xmorderinfo.Remark = strRemarksValue;
                                        if (fpxx != "")
                                        {
                                            xmorderinfo.CustomerServiceRemark = CustomerServiceRemarkValue + "/收货时间:" + shsj + "/发票信息:" + fpxx + "/发票金额:" + SalesPriceV.ToString();
                                        }
                                        else
                                        {
                                            xmorderinfo.CustomerServiceRemark = CustomerServiceRemarkValue + "/收货时间:" + shsj + "/发票金额:" + SalesPriceV.ToString();
                                        }
                                        // #endregion

                                        xmorderinfo.PayPrice = UnitPrice;

                                        //xmorderinfo.SourceType = "导入";
                                        xmorderinfo.SourceType = sourceType;//"导入";
                                        if (sourceType == "导入")
                                        {
                                            xmorderinfo.FinancialAudit = true;
                                        }
                                        else
                                        {
                                            xmorderinfo.FinancialAudit = false;
                                        }
                                        xmorderinfo.IsScalping = false;
                                        xmorderinfo.IsEnable = false;//是否删除
                                        xmorderinfo.IsCashBack = false;//是否返现
                                        xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                        xmorderinfo.IsEvaluate = false;//是否赔付
                                        xmorderinfo.IsOurOrder = true;

                                        xmorderinfo.CreateDate = DateTime.Now;
                                        xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfo.UpdateDate = DateTime.Now;
                                        xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                        #region 明细
                                        //商家编码查询。
                                        var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(Merchantcode, 0);

                                        int ProductNumV = (row1["数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["数量"].ToString().Trim()));

                                        XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                        xmorderinfopd.ProductNum = ProductNumV;
                                        if (ProductList.Count > 0)
                                        {
                                            xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                            xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                            xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                            xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称 
                                            xmorderinfopd.TCostprice = ProductList[0].TCostprice;//特供价
                                            xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                        }
                                        else
                                        {
                                            xmorderinfopd.PlatformMerchantCode = row1["货号"].ToString().Trim();
                                            xmorderinfopd.Specifications = row1["尺寸"].ToString().Trim();//尺寸
                                            xmorderinfopd.FactoryPrice = 0;//出厂价
                                            xmorderinfopd.ProductName = "无产品";
                                            xmorderinfopd.TCostprice = 0;//特供价
                                            xmorderinfopd.TManufacturersCode = "";
                                        }
                                        xmorderinfopd.CutoffShipDay = payDate.AddDays(+20);//截止发货日  
                                        xmorderinfopd.SalesPrice = UnitPrice * ProductNumV;//销售价 
                                        xmorderinfopd.ISArrivedLibrary = false;
                                        xmorderinfopd.IsAudit = false;//是否审核
                                        xmorderinfopd.IsExpedited = false;//是否加急
                                        xmorderinfopd.IsEnable = false;
                                        xmorderinfopd.CreateDate = DateTime.Now;
                                        xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfopd.UpdateDate = DateTime.Now;
                                        xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                        #endregion

                                        IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                        resultCount++;

                                        #endregion
                                    }
                                    else
                                    {
                                        #region 修改

                                        xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                        xmorderinfo.NickID = NickId;

                                        xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                        DateTime payDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                        DateTime OrderInfoModified = (row1["订单变更时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["订单变更时间"].ToString().Trim()));
                                        xmorderinfo.PayDate = payDate;
                                        xmorderinfo.OrderInfoCreateDate = payDate;
                                        xmorderinfo.OrderInfoModified = OrderInfoModified;
                                        if (payDate != null)
                                        {
                                            xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                        }

                                        #region 订单状态
                                        string OrderStatus = row1["订单状态"].ToString().Trim();

                                        if (OrderStatus == "订单已审核")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_AUDITED";//唯品会订单状态
                                        }
                                        if (OrderStatus == "订单已取消")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_CANCEL";//唯品会订单状态
                                        }
                                        if (OrderStatus == "订单已发货")
                                        {
                                            xmorderinfo.OrderStatus = "ORDERS_HAVE_SHIP";//唯品会订单状态
                                        }
                                        #endregion

                                        #region 收货人信息
                                        xmorderinfo.FullName = row1["收货人"].ToString().Trim();

                                        xmorderinfo.DeliveryAddress = row1["收货地址"].ToString().Trim();

                                        string Mobile = row1["联系电话"].ToString().Trim();
                                        if (Mobile.IndexOf("'") == -1)
                                        {
                                            xmorderinfo.Mobile = row1["联系电话"].ToString().Trim();
                                        }
                                        else
                                        {
                                            string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                            xmorderinfo.Mobile = suMobile;
                                        }
                                        xmorderinfo.Tel = row1["座机号"].ToString().Trim();

                                        #endregion

                                        #region 备注

                                        string Remarks = row1["备注"].ToString().Trim();//备注

                                        //string strRemarksValue = "";
                                        string CustomerServiceRemarkValue = "";

                                        if (Remarks.IndexOf("'") == -1)//没有’
                                        {
                                            CustomerServiceRemarkValue = Remarks;
                                        }
                                        else
                                        {
                                            string suRemarks = Remarks.Substring(Remarks.LastIndexOf("'") + 1).ToLower();// 取'号 

                                            CustomerServiceRemarkValue = suRemarks;
                                        }

                                        #endregion

                                        xmorderinfo.InvoiceHead = row1["发票信息"].ToString().Trim();//发票抬头

                                        decimal InvoicePriceD = (row1["发票金额"].ToString().Trim() == "" ? 0 : decimal.Parse(row1["发票金额"].ToString().Trim()));

                                        xmorderinfo.InvoicePrice = InvoicePriceD;//发票金额

                                        string shsj = row1["收货时间"].ToString().Trim();//收货时间
                                        string fpxx = row1["发票信息"].ToString().Trim(); //发票信息
                                        decimal SalesPriceV = Convert.ToDecimal(row1["发票金额"].ToString().Trim());//销售价

                                        decimal UnitPrice = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价 

                                        //xmorderinfo.Remark = strRemarksValue;
                                        if (fpxx != "")
                                        {
                                            xmorderinfo.CustomerServiceRemark = CustomerServiceRemarkValue + "/收货时间:" + shsj + "/发票信息:" + fpxx + "/发票金额:" + SalesPriceV.ToString();
                                        }
                                        else
                                        {
                                            xmorderinfo.CustomerServiceRemark = CustomerServiceRemarkValue + "/收货时间:" + shsj + "/发票金额:" + SalesPriceV.ToString();
                                        }
                                        // #endregion

                                        xmorderinfo.PayPrice = UnitPrice;

                                        //xmorderinfo.SourceType = "导入";
                                        xmorderinfo.SourceType = sourceType;//"导入";
                                        if (sourceType == "导入")
                                        {
                                            xmorderinfo.FinancialAudit = true;
                                        }
                                        else
                                        {
                                            xmorderinfo.FinancialAudit = false;
                                        }
                                        xmorderinfo.IsScalping = false;
                                        xmorderinfo.IsEnable = false;//是否删除
                                        xmorderinfo.IsCashBack = false;//是否返现
                                        xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                        xmorderinfo.IsEvaluate = false;//是否赔付

                                        //xmorderinfo.CreateDate = DateTime.Now;
                                        //xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfo.UpdateDate = DateTime.Now;
                                        xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                        #region 明细
                                        //商家编码查询。
                                        var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(Merchantcode, 0);

                                        int ProductNumV = (row1["数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["数量"].ToString().Trim()));

                                        //订单明细
                                        var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, Merchantcode);

                                        if (xmorderinfopdList.Count == 0)
                                        {
                                            #region 新增
                                            //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                            XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                            xmorderinfopd.OrderInfoID = xmorderinfo.ID;
                                            xmorderinfopd.ProductNum = ProductNumV;
                                            if (ProductList.Count > 0)
                                            {
                                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                                xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                                xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称 
                                                xmorderinfopd.TCostprice = ProductList[0].TCostprice;//特供价
                                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                            }
                                            else
                                            {
                                                xmorderinfopd.PlatformMerchantCode = row1["货号"].ToString().Trim();
                                                xmorderinfopd.Specifications = row1["尺寸"].ToString().Trim();//尺寸
                                                xmorderinfopd.FactoryPrice = 0;//出厂价
                                                xmorderinfopd.ProductName = "无产品";
                                                xmorderinfopd.TCostprice = 0;//特供价
                                                xmorderinfopd.TManufacturersCode = "";
                                            }
                                            xmorderinfopd.CutoffShipDay = payDate.AddDays(+20);//截止发货日  
                                            xmorderinfopd.SalesPrice = UnitPrice * ProductNumV;//销售价 
                                            xmorderinfopd.ISArrivedLibrary = false;
                                            xmorderinfopd.IsAudit = false;//是否审核
                                            xmorderinfopd.IsExpedited = false;//是否加急
                                            xmorderinfopd.IsEnable = false;
                                            xmorderinfopd.CreateDate = DateTime.Now;
                                            xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                            xmorderinfopd.UpdateDate = DateTime.Now;
                                            xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;

                                            IoC.Resolve<IXMOrderInfoProductDetailsService>().InsertXMOrderInfoProductDetails(xmorderinfopd);
                                            // xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                            #endregion

                                        }
                                        else
                                        {
                                            #region 修改
                                            XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];
                                            xmorderinfopd.ProductNum = ProductNumV;
                                            if (ProductList.Count > 0)
                                            {
                                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                                xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                                xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称 
                                                xmorderinfopd.TCostprice = ProductList[0].TCostprice;//特供价
                                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                            }
                                            else
                                            {
                                                xmorderinfopd.PlatformMerchantCode = row1["货号"].ToString().Trim();
                                                xmorderinfopd.Specifications = row1["尺寸"].ToString().Trim();//尺寸
                                                xmorderinfopd.FactoryPrice = 0;//出厂价
                                                xmorderinfopd.ProductName = "无产品";
                                                xmorderinfopd.TCostprice = 0;//特供价
                                                xmorderinfopd.TManufacturersCode = "";
                                            }
                                            xmorderinfopd.CutoffShipDay = payDate.AddDays(+20);//截止发货日  
                                            xmorderinfopd.SalesPrice = UnitPrice * ProductNumV;//销售价  
                                            xmorderinfopd.UpdateDate = DateTime.Now;
                                            xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;

                                            IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                            #endregion
                                        }

                                        #endregion

                                        IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                        resultCount++;


                                        #endregion
                                        //paramMessage += "订单号:" + row1["订单号"].ToString() + ";货号:" + row1["货号"].ToString() + "已存在" + "\t\n";
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }
                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }
                }
                #endregion

                #region 亚马逊
                if (PlatformTypeName == "亚马逊")
                {
                    if (FileName.Trim() == "亚马逊")
                    {
                        dt = excelHelper.ReadTable("亚马逊");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            //订单详情
                            var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());

                            //产品编码
                            string PlatFormMerchantCode = row1["产品编码"].ToString().Trim();

                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 376);

                            if (xmorderinfo == null)
                            {
                                #region  新增
                                xmorderinfo = new XMOrderInfo();
                                xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;

                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;

                                //if (payDate != null)
                                //{
                                //    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                //}

                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["单价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (ZP.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = ZP.Substring(ZP.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.OrderStatus = "以接受";//"新";
                                xmorderinfo.IsEnable = false;//是否删除
                                xmorderinfo.IsCashBack = false;//是否返现
                                xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                xmorderinfo.IsEvaluate = false;//是否赔付
                                xmorderinfo.IsOurOrder = true;
                                xmorderinfo.CreateDate = DateTime.Now;
                                xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                }
                                else
                                {

                                    xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                    xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                    xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.IsAudit = false;//是否审核
                                xmorderinfopd.IsExpedited = false;//是否加急
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                xmorderinfo.PayPrice = SalesPriceV * ProductNumV;//已支付金额

                                IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                            else
                            {
                                #region 修改
                                // xmorderinfo = new XMOrderInfo();
                                //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>(); 
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;
                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                //if (payDate != null)
                                //{
                                //    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                //}
                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (CustomerServiceRemark.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = CustomerServiceRemark.Substring(CustomerServiceRemark.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                decimal PayPriceV = xmorderinfo.PayPrice.Value;//之前的支付金额

                                //订单明细
                                var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);

                                if (xmorderinfopdList.Count == 0)
                                {

                                    //订单明细信息
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急 
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;

                                }
                                else
                                {
                                    //订单明细修改 
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];


                                    PayPriceV = xmorderinfo.PayPrice.Value - xmorderinfopd.SalesPrice.Value;//已支付金额=订单已支付总金额-修改之前的产品销售价

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价  
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;//最新已支付金额

                                }

                                xmorderinfo.PayPrice = PayPriceV;

                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                        }
                     
                    }
                    else
                    {

                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }
                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }
                }
                #endregion

                #region 国美
                if (PlatformTypeName == "国美")
                {
                    dt = excelHelper.ReadTable("国美");
                    dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();
                    foreach (DataRow row1 in dt.Rows)
                    {
                        //订单详情
                        var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());

                        //产品编码
                        string PlatFormMerchantCode = row1["产品编码"].ToString().Trim();
                        //京东Id查询。
                        var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 0);

                        if (xmorderinfo == null)
                        {
                            #region  新增
                            xmorderinfo = new XMOrderInfo();
                            xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                            xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                            int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                            DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                            xmorderinfo.PayDate = payDate;

                            DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                            xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;

                            if (payDate != null)
                            {
                                xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                            }

                            xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                            xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                            xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                            xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                            xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                            xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                            //xmorderinfo.SourceType = "导入";
                            xmorderinfo.SourceType = sourceType;//"导入";
                            if (sourceType == "导入")
                            {
                                xmorderinfo.FinancialAudit = true;
                            }
                            else
                            {
                                xmorderinfo.FinancialAudit = false;
                            }
                            xmorderinfo.IsScalping = false;
                            xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                            string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                            string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                            string Mobile = row1["手机"].ToString().Trim();
                            if (Mobile.IndexOf("'") == -1)
                            {
                                xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                            }
                            else
                            {
                                string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                xmorderinfo.Mobile = suMobile;
                            }
                            #region 备注
                            string Remarks = row1["卖家备注"].ToString().Trim();
                            string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                            string CustomerServiceRemark = Remarks + ZPRemarks;

                            if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                            {
                                xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                            }
                            else
                            {
                                string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                xmorderinfo.CustomerServiceRemark = suRemarks;
                            }

                            string ZP = row1["赠品备注"].ToString().Trim();

                            if (ZP != "")
                            {

                                string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                #region 赠品
                                //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                string PremiumsActivityExplanation = "";//活动说明
                                string PremiumsPrdouctName = "";//商品名称
                                string PremiumsPlatformMerchantCode = "";//商品编码
                                string PremiumsFactoryPrice = "0";//出厂价
                                string PremiumsProductNum = "0";//数量
                                string Specifications = "";//尺寸    
                                int ProductDetaislId = -1;


                                if (ZP.IndexOf("赠品") > -1)
                                {
                                    //判断赠品申请表中是否已经存在 相同订单号
                                    var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                    if (premiumsList.Count == 0)
                                    {
                                        string s = ZP.Substring(ZP.IndexOf("赠品") + 3);
                                        int f = s.IndexOf("/");
                                        if (f > -1)
                                        {
                                            PremiumsActivityExplanation = s.Substring(0, f);

                                            #region 去除赠品、：、3个字符 （长度等于2）
                                            if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                    && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                    && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                            {
                                                PremiumsPrdouctName = s.Substring(0, f);

                                                PremiumsProductNum = "1";

                                                if (PremiumsPrdouctName != "")
                                                {
                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                    if (xmProductList.Count > 0)
                                                    {
                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                        ProductDetaislId = xmProductList[0].Id;
                                                    }
                                                }

                                                decimal d = 0;
                                                int INum = 0;
                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                {
                                                    //主表信息
                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false,d*INum, PlatformTypeNameId, NickId);
                                                    //明细信息
                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                }
                                                PremiumsActivityExplanation = "";//活动说明
                                                PremiumsPrdouctName = "";//商品名称
                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                PremiumsFactoryPrice = "0";//出厂价
                                                PremiumsProductNum = "0";//数量
                                                Specifications = "";//尺寸    
                                                ProductDetaislId = -1;

                                            }
                                            #endregion
                                            #region 字符大于2个字符
                                            else if (f > 2)
                                            {
                                                string[] J = PremiumsActivityExplanation.Split('+');

                                                string strNum = "";//数量字符

                                                #region 多个赠品
                                                if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                {
                                                    for (int Ji = 0; Ji < J.Length; Ji++)
                                                    {
                                                        string pe = J[Ji];
                                                        string remsub = "";//尺寸+商品名称字符

                                                        if (pe != "")
                                                        {
                                                            #region 尺寸、商品名称
                                                            if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                            {
                                                                string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                int b = a1.IndexOf("）");
                                                                int c = pe.IndexOf("（");

                                                                if (c > -1)
                                                                {
                                                                    PremiumsPrdouctName = pe.Substring(0, c);
                                                                    remsub += PremiumsPrdouctName;
                                                                }

                                                                if (b > -1)
                                                                {
                                                                    Specifications = a1.Substring(0, b);
                                                                    remsub += "（" + Specifications + "）";
                                                                }

                                                            }
                                                            if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                            {

                                                                string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                int b = a1.IndexOf(")");
                                                                int c = pe.IndexOf("(");
                                                                if (c > -1)
                                                                {
                                                                    PremiumsPrdouctName = pe.Substring(0, c);
                                                                    remsub += PremiumsPrdouctName;
                                                                }
                                                                if (b > -1)
                                                                {
                                                                    Specifications = a1.Substring(0, b);

                                                                    remsub += "(" + Specifications + ")";
                                                                }

                                                            }
                                                            #endregion
                                                            #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                            int Intd = pe.IndexOf(remsub);
                                                            if (Intd > -1)
                                                            {
                                                                strNum = pe.Substring(remsub.Length).ToLower();
                                                            }
                                                            if (strNum != "")
                                                            {
                                                                //数量
                                                                if (strNum.IndexOf("*") > -1)
                                                                {
                                                                    string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                    PremiumsProductNum = a1;
                                                                }
                                                                else
                                                                {
                                                                    PremiumsProductNum = "1";
                                                                }
                                                            }
                                                            else
                                                            {

                                                                PremiumsProductNum = "1";
                                                            }

                                                            #endregion

                                                            if (PremiumsPrdouctName == "")
                                                            {

                                                                PremiumsPrdouctName = pe;
                                                            }
                                                            if (PremiumsPrdouctName != "")
                                                            {
                                                                var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                if (PremiumsPrdouctName != "" && Specifications != "")
                                                                {
                                                                    xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                }
                                                                if (xmProductList.Count > 0)
                                                                {
                                                                    ProductDetaislId = xmProductList[0].Id;
                                                                    PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                    PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                }

                                                            }


                                                            decimal d = 0;
                                                            int INum = 0;
                                                            if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                            {
                                                                //主表信息
                                                                int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                //明细信息
                                                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                            }
                                                            //PremiumsActivityExplanation = "";//活动说明
                                                            PremiumsPrdouctName = "";//商品名称
                                                            PremiumsPlatformMerchantCode = "";//商品编码
                                                            PremiumsFactoryPrice = "0";//出厂价
                                                            PremiumsProductNum = "0";//数量
                                                            Specifications = "";//尺寸    
                                                            ProductDetaislId = -1;
                                                        }
                                                    }

                                                }
                                                #endregion
                                                #region 单个赠品
                                                else
                                                {

                                                    string strNum1 = "";//数量字符
                                                    string remsub = "";//尺寸+商品名称字符
                                                    string PEl = PremiumsActivityExplanation;
                                                    #region 尺寸、商品名称
                                                    if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                    {
                                                        string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                        int b = a.IndexOf("）");
                                                        int c = PEl.IndexOf("（");
                                                        if (c > -1)
                                                        {
                                                            PremiumsPrdouctName = PEl.Substring(0, c);
                                                            remsub += PremiumsPrdouctName;
                                                        }
                                                        if (b > -1)
                                                        {
                                                            Specifications = a.Substring(0, b);
                                                            remsub += "（" + Specifications + "）";
                                                        }

                                                    }
                                                    if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                    {

                                                        string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                        int b = a.IndexOf(")");
                                                        int c = PEl.IndexOf("(");
                                                        if (c > -1)
                                                        {
                                                            PremiumsPrdouctName = PEl.Substring(0, c);
                                                            remsub += PremiumsPrdouctName;
                                                        }
                                                        if (b > -1)
                                                        {
                                                            Specifications = a.Substring(0, b);

                                                            remsub += "(" + Specifications + ")";
                                                        }
                                                    }
                                                    #endregion

                                                    #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                    int Intd = PEl.IndexOf(remsub);
                                                    if (Intd > -1)
                                                    {
                                                        strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                    }
                                                    if (strNum1 != "")
                                                    {
                                                        //数量
                                                        if (strNum1.IndexOf("*") > -1)
                                                        {
                                                            string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                            PremiumsProductNum = a;

                                                            if (PremiumsPrdouctName == "")
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        PremiumsProductNum = "1";
                                                    }

                                                    #endregion
                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (PremiumsPrdouctName != "" && Specifications != "")
                                                        {
                                                            xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                        }
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            ProductDetaislId = xmProductList[0].Id;
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                        }

                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                    }
                                }
                                #endregion

                            }

                            #endregion
                            xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                            xmorderinfo.NickID = NickId;//店铺Id  
                            xmorderinfo.OrderStatus = "新";
                            xmorderinfo.IsEnable = false;//是否删除
                            xmorderinfo.IsCashBack = false;//是否返现
                            xmorderinfo.IsSentGifts = false;//是否已发赠品 
                            xmorderinfo.IsEvaluate = false;//是否赔付
                            xmorderinfo.IsOurOrder = true;
                            xmorderinfo.CreateDate = DateTime.Now;
                            xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                            xmorderinfo.UpdateDate = DateTime.Now;
                            xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                            XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                            xmorderinfopd.ProductNum = ProductNumV;
                            if (ProductList.Count > 0)
                            {
                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                            }
                            else
                            {

                                xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                xmorderinfopd.ProductName = "无产品";
                                xmorderinfopd.TManufacturersCode = "";
                            }
                            xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                            decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                            xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                            xmorderinfopd.ISArrivedLibrary = false;
                            xmorderinfopd.IsAudit = false;//是否审核
                            xmorderinfopd.IsExpedited = false;//是否加急
                            xmorderinfopd.IsEnable = false;
                            xmorderinfopd.CreateDate = DateTime.Now;
                            xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                            xmorderinfopd.UpdateDate = DateTime.Now;
                            xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                            xmorderinfo.PayPrice = SalesPriceV * ProductNumV;//已支付金额

                            IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                            resultCount++;

                            #endregion
                        }
                        else
                        {
                            #region 修改
                            // xmorderinfo = new XMOrderInfo();
                            //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>(); 
                            xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                            int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                            DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                            xmorderinfo.PayDate = payDate;
                            DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                            xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                            if (payDate != null)
                            {
                                xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                            }
                            xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                            xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                            xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                            xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                            xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                            xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                            //xmorderinfo.SourceType = "导入";
                            xmorderinfo.SourceType = sourceType;//"导入";
                            if (sourceType == "导入")
                            {
                                xmorderinfo.FinancialAudit = true;
                            }
                            else
                            {
                                xmorderinfo.FinancialAudit = false;
                            }
                            xmorderinfo.IsScalping = false;
                            xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                            string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                            string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                            string Mobile = row1["手机"].ToString().Trim();
                            if (Mobile.IndexOf("'") == -1)
                            {
                                xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                            }
                            else
                            {
                                string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                xmorderinfo.Mobile = suMobile;
                            }
                            #region 备注
                            string Remarks = row1["卖家备注"].ToString().Trim();
                            string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                            string CustomerServiceRemark = Remarks + ZPRemarks;

                            if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                            {
                                xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                            }
                            else
                            {
                                string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                xmorderinfo.CustomerServiceRemark = suRemarks;
                            }

                            string ZP = row1["赠品备注"].ToString().Trim();

                            if (ZP != "")
                            {

                                string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                #region 赠品
                                //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                string PremiumsActivityExplanation = "";//活动说明
                                string PremiumsPrdouctName = "";//商品名称
                                string PremiumsPlatformMerchantCode = "";//商品编码
                                string PremiumsFactoryPrice = "0";//出厂价
                                string PremiumsProductNum = "0";//数量
                                string Specifications = "";//尺寸    
                                int ProductDetaislId = -1;


                                if (CustomerServiceRemark.IndexOf("赠品") > -1)
                                {
                                    //判断赠品申请表中是否已经存在 相同订单号
                                    var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                    if (premiumsList.Count == 0)
                                    {
                                        string s = CustomerServiceRemark.Substring(CustomerServiceRemark.IndexOf("赠品") + 3);
                                        int f = s.IndexOf("/");
                                        if (f > -1)
                                        {
                                            PremiumsActivityExplanation = s.Substring(0, f);

                                            #region 去除赠品、：、3个字符 （长度等于2）
                                            if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                    && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                    && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                            {
                                                PremiumsPrdouctName = s.Substring(0, f);

                                                PremiumsProductNum = "1";

                                                if (PremiumsPrdouctName != "")
                                                {
                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                    if (xmProductList.Count > 0)
                                                    {
                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                        ProductDetaislId = xmProductList[0].Id;
                                                    }
                                                }

                                                decimal d = 0;
                                                int INum = 0;
                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                {
                                                    //主表信息
                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                    //明细信息
                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                }
                                                PremiumsActivityExplanation = "";//活动说明
                                                PremiumsPrdouctName = "";//商品名称
                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                PremiumsFactoryPrice = "0";//出厂价
                                                PremiumsProductNum = "0";//数量
                                                Specifications = "";//尺寸    
                                                ProductDetaislId = -1;

                                            }
                                            #endregion
                                            #region 字符大于2个字符
                                            else if (f > 2)
                                            {
                                                string[] J = PremiumsActivityExplanation.Split('+');

                                                string strNum = "";//数量字符

                                                #region 多个赠品
                                                if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                {
                                                    for (int Ji = 0; Ji < J.Length; Ji++)
                                                    {
                                                        string pe = J[Ji];
                                                        string remsub = "";//尺寸+商品名称字符

                                                        if (pe != "")
                                                        {
                                                            #region 尺寸、商品名称
                                                            if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                            {
                                                                string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                int b = a1.IndexOf("）");
                                                                int c = pe.IndexOf("（");

                                                                if (c > -1)
                                                                {
                                                                    PremiumsPrdouctName = pe.Substring(0, c);
                                                                    remsub += PremiumsPrdouctName;
                                                                }

                                                                if (b > -1)
                                                                {
                                                                    Specifications = a1.Substring(0, b);
                                                                    remsub += "（" + Specifications + "）";
                                                                }

                                                            }
                                                            if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                            {

                                                                string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                int b = a1.IndexOf(")");
                                                                int c = pe.IndexOf("(");
                                                                if (c > -1)
                                                                {
                                                                    PremiumsPrdouctName = pe.Substring(0, c);
                                                                    remsub += PremiumsPrdouctName;
                                                                }
                                                                if (b > -1)
                                                                {
                                                                    Specifications = a1.Substring(0, b);

                                                                    remsub += "(" + Specifications + ")";
                                                                }

                                                            }
                                                            #endregion
                                                            #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                            int Intd = pe.IndexOf(remsub);
                                                            if (Intd > -1)
                                                            {
                                                                strNum = pe.Substring(remsub.Length).ToLower();
                                                            }
                                                            if (strNum != "")
                                                            {
                                                                //数量
                                                                if (strNum.IndexOf("*") > -1)
                                                                {
                                                                    string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                    PremiumsProductNum = a1;
                                                                }
                                                                else
                                                                {
                                                                    PremiumsProductNum = "1";
                                                                }
                                                            }
                                                            else
                                                            {

                                                                PremiumsProductNum = "1";
                                                            }

                                                            #endregion

                                                            if (PremiumsPrdouctName == "")
                                                            {

                                                                PremiumsPrdouctName = pe;
                                                            }
                                                            if (PremiumsPrdouctName != "")
                                                            {
                                                                var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                if (PremiumsPrdouctName != "" && Specifications != "")
                                                                {
                                                                    xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                }
                                                                if (xmProductList.Count > 0)
                                                                {
                                                                    ProductDetaislId = xmProductList[0].Id;
                                                                    PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                    PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                }

                                                            }


                                                            decimal d = 0;
                                                            int INum = 0;
                                                            if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                            {
                                                                //主表信息
                                                                int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                //明细信息
                                                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                            }
                                                            //PremiumsActivityExplanation = "";//活动说明
                                                            PremiumsPrdouctName = "";//商品名称
                                                            PremiumsPlatformMerchantCode = "";//商品编码
                                                            PremiumsFactoryPrice = "0";//出厂价
                                                            PremiumsProductNum = "0";//数量
                                                            Specifications = "";//尺寸    
                                                            ProductDetaislId = -1;
                                                        }
                                                    }

                                                }
                                                #endregion
                                                #region 单个赠品
                                                else
                                                {

                                                    string strNum1 = "";//数量字符
                                                    string remsub = "";//尺寸+商品名称字符
                                                    string PEl = PremiumsActivityExplanation;
                                                    #region 尺寸、商品名称
                                                    if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                    {
                                                        string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                        int b = a.IndexOf("）");
                                                        int c = PEl.IndexOf("（");
                                                        if (c > -1)
                                                        {
                                                            PremiumsPrdouctName = PEl.Substring(0, c);
                                                            remsub += PremiumsPrdouctName;
                                                        }
                                                        if (b > -1)
                                                        {
                                                            Specifications = a.Substring(0, b);
                                                            remsub += "（" + Specifications + "）";
                                                        }

                                                    }
                                                    if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                    {

                                                        string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                        int b = a.IndexOf(")");
                                                        int c = PEl.IndexOf("(");
                                                        if (c > -1)
                                                        {
                                                            PremiumsPrdouctName = PEl.Substring(0, c);
                                                            remsub += PremiumsPrdouctName;
                                                        }
                                                        if (b > -1)
                                                        {
                                                            Specifications = a.Substring(0, b);

                                                            remsub += "(" + Specifications + ")";
                                                        }
                                                    }
                                                    #endregion

                                                    #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                    int Intd = PEl.IndexOf(remsub);
                                                    if (Intd > -1)
                                                    {
                                                        strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                    }
                                                    if (strNum1 != "")
                                                    {
                                                        //数量
                                                        if (strNum1.IndexOf("*") > -1)
                                                        {
                                                            string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                            PremiumsProductNum = a;

                                                            if (PremiumsPrdouctName == "")
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        PremiumsProductNum = "1";
                                                    }

                                                    #endregion
                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (PremiumsPrdouctName != "" && Specifications != "")
                                                        {
                                                            xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                        }
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            ProductDetaislId = xmProductList[0].Id;
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                        }

                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;
                                                }
                                                #endregion
                                            }
                                            #endregion
                                        }
                                    }
                                }
                                #endregion

                            }

                            #endregion
                            xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                            xmorderinfo.NickID = NickId;//店铺Id  
                            xmorderinfo.UpdateDate = DateTime.Now;
                            xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                            decimal PayPriceV = xmorderinfo.PayPrice.Value;//之前的支付金额

                            //订单明细
                            var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);

                            if (xmorderinfopdList.Count == 0)
                            {

                                //订单明细信息
                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();

                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                }
                                else
                                {
                                    xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                    xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.IsAudit = false;//是否审核
                                xmorderinfopd.IsExpedited = false;//是否加急 
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                PayPriceV += SalesPriceV * ProductNumV;

                            }
                            else
                            {
                                //订单明细修改 
                                XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];

                                PayPriceV = xmorderinfo.PayPrice.Value - xmorderinfopd.SalesPrice.Value;//已支付金额=订单已支付总金额-修改之前的产品销售价

                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                }
                                else
                                {
                                    xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                    xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价  
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                PayPriceV += SalesPriceV * ProductNumV;//最新已支付金额
                            }

                            xmorderinfo.PayPrice = PayPriceV;

                            IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                            resultCount++;

                            #endregion
                        }
                    }
                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            paramMessage = "导入成功";
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                        }
                    }
                }
                #endregion

                #region   京东众筹
                if (PlatformTypeName == "京东众筹")
                {
                    dt = excelHelper.ReadTable("Sheet0");
                    dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();
                    foreach (DataRow row1 in dt.Rows)
                    {
                        //订单详情
                        string PlatformMerchantCode = row1["商品编码"].ToString().Trim();
                        var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());
                        if (xmorderinfo == null)
                        {
                            #region  新增
                            xmorderinfo = new XMOrderInfo();
                            xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
                            xmorderinfo.NickID = NickId;
                            xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                            xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                            xmorderinfo.WantID = row1["支持人"].ToString().Trim();
                            xmorderinfo.OrderPrice = row1["订单金额"].ToString().Trim() != "" ? decimal.Parse(row1["订单金额"].ToString().Trim()) : 0;
                            xmorderinfo.PayPrice = xmorderinfo.OrderPrice;
                            xmorderinfo.FinancialAudit = true;
                            xmorderinfo.OrderInfoCreateDate = row1["下单时间"].ToString().Trim() != "" ? DateTime.Parse(row1["下单时间"].ToString().Trim()) : DateTime.Now;
                            xmorderinfo.PayDate = row1["支付时间"].ToString().Trim() != "" ? DateTime.Parse(row1["支付时间"].ToString().Trim()) : DateTime.Now;
                            string orderStatus = row1["订单状态"].ToString().Trim();
                            if (orderStatus == "支持成功")
                            {
                                xmorderinfo.OrderStatus = "Support_Success";             //支持成功
                            }
                            xmorderinfo.InvoiceHead = row1["发票抬头"].ToString().Trim();
                            xmorderinfo.FullName = row1["收货人"].ToString().Trim();
                            xmorderinfo.Mobile = row1["收货人手机号"].ToString().Trim();
                            xmorderinfo.DeliveryAddress = row1["收货地址"].ToString().Trim();
                            xmorderinfo.DeliveryTime = row1["发货时间"].ToString().Trim() != "" ? DateTime.Parse(row1["发货时间"].ToString().Trim()) : DateTime.Now;
                            xmorderinfo.CompletionTime = row1["完成时间"].ToString().Trim() != "" ? DateTime.Parse(row1["完成时间"].ToString().Trim()) : DateTime.Now;
                            xmorderinfo.Remark = row1["用户备注"].ToString().Trim();
                            xmorderinfo.CustomerServiceRemark = row1["客服备注"].ToString().Trim();
                            xmorderinfo.PayMethod = row1["支付渠道"].ToString().Trim();
                            xmorderinfo.IsAudit = false;
                            xmorderinfo.IsCashBack = false;
                            xmorderinfo.IsAbnormal = false;
                            xmorderinfo.IsEnable = false;
                            xmorderinfo.IsScalping = false;
                            xmorderinfo.IsEvaluate = false;
                            xmorderinfo.IsOurOrder = true;
                            xmorderinfo.CreateDate = DateTime.Now;
                            xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                            xmorderinfo.UpdateDate = DateTime.Now;
                            xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                            string productName = row1["项目名称"].ToString().Trim();          //产品名称
                            string remark = row1["用户备注"].ToString().Trim();                     //客户留言

                            //根据商品编码和平台ID 查询相关产品信息
                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatformMerchantCode, PlatformTypeNameId);
                            //产品存在初始化订单产品详情
                            if (ProductList.Count() > 0)
                            {
                                //新增订单产品明细
                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                xmorderinfopd.ProductName = ProductList[0].ProductName;
                                xmorderinfopd.Specifications = ProductList[0].Specifications;
                                xmorderinfopd.ProductNum = 1;
                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice != null ? ProductList[0].Costprice : 0;
                                xmorderinfopd.TCostprice = ProductList[0].TCostprice != null ? ProductList[0].TCostprice : 0;
                                xmorderinfopd.SalesPrice = ProductList[0].Saleprice != null ? xmorderinfopd.ProductNum * ProductList[0].Saleprice : 0;
                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.Remarks = xmorderinfo.CustomerServiceRemark;
                                xmorderinfopd.IsAudit = false;
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.IsExpedited = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                            }
                            IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                            resultCount++;
                            #endregion
                        }
                        else
                        {
                            #region 修改
                            //根据商品编码和平台ID 查询相关产品信息
                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatformMerchantCode, PlatformTypeNameId);
                            //订单信息修改
                            xmorderinfo.NickID = NickId;
                            xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                            xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                            xmorderinfo.WantID = row1["支持人"].ToString().Trim();
                            xmorderinfo.OrderPrice = row1["订单金额"].ToString().Trim() != "" ? decimal.Parse(row1["订单金额"].ToString().Trim()) : 0;
                            xmorderinfo.PayPrice = xmorderinfo.OrderPrice;
                            xmorderinfo.FinancialAudit = true;
                            xmorderinfo.OrderInfoCreateDate = row1["下单时间"].ToString().Trim() != "" ? DateTime.Parse(row1["下单时间"].ToString().Trim()) : DateTime.Now;
                            xmorderinfo.PayDate = row1["支付时间"].ToString().Trim() != "" ? DateTime.Parse(row1["支付时间"].ToString().Trim()) : DateTime.Now;
                            string orderStatus = row1["订单状态"].ToString().Trim();
                            if (orderStatus == "支持成功")
                            {
                                xmorderinfo.OrderStatus = "Support_Success";             //支持成功
                            }
                            xmorderinfo.InvoiceHead = row1["发票抬头"].ToString().Trim();
                            xmorderinfo.FullName = row1["收货人"].ToString().Trim();
                            xmorderinfo.Mobile = row1["收货人手机号"].ToString().Trim();
                            xmorderinfo.DeliveryAddress = row1["收货地址"].ToString().Trim();
                            xmorderinfo.DeliveryTime = row1["发货时间"].ToString().Trim() != "" ? DateTime.Parse(row1["发货时间"].ToString().Trim()) : DateTime.Now;
                            xmorderinfo.CompletionTime = row1["完成时间"].ToString().Trim() != "" ? DateTime.Parse(row1["完成时间"].ToString().Trim()) : DateTime.Now;
                            xmorderinfo.Remark = row1["用户备注"].ToString().Trim();
                            xmorderinfo.CustomerServiceRemark = row1["客服备注"].ToString().Trim();
                            xmorderinfo.PayMethod = row1["支付渠道"].ToString().Trim();
                            xmorderinfo.IsAudit = false;
                            xmorderinfo.IsCashBack = false;
                            xmorderinfo.IsAbnormal = false;
                            xmorderinfo.IsEnable = false;
                            xmorderinfo.IsScalping = false;
                            xmorderinfo.IsEvaluate = false;
                            xmorderinfo.IsOurOrder = true;
                            xmorderinfo.CreateDate = DateTime.Now;
                            xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                            xmorderinfo.UpdateDate = DateTime.Now;
                            xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                            var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatformMerchantCode);


                            if (xmorderinfopdList.Count == 0 && ProductList.Count() > 0)
                            {
                                //新增订单明细
                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                xmorderinfopd.ProductName = ProductList[0].ProductName;
                                xmorderinfopd.Specifications = ProductList[0].Specifications;
                                xmorderinfopd.ProductNum = 1;
                                xmorderinfopd.FactoryPrice = ProductList[0].Costprice != null ? ProductList[0].Costprice : 0;
                                xmorderinfopd.TCostprice = ProductList[0].TCostprice != null ? ProductList[0].TCostprice : 0;
                                xmorderinfopd.SalesPrice = ProductList[0].Saleprice != null ? xmorderinfopd.ProductNum * ProductList[0].Saleprice : 0;
                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.Remarks = xmorderinfo.CustomerServiceRemark;
                                xmorderinfopd.IsAudit = false;
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.IsExpedited = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                            }
                            else
                            {
                                if (xmorderinfopdList.Count() > 0)
                                {
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];
                                    //修改订单明细
                                    if (ProductList.Count() > 0)
                                    {
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode;
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;
                                        xmorderinfopd.ProductNum = 1;
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice != null ? ProductList[0].Costprice : 0;
                                        xmorderinfopd.TCostprice = ProductList[0].TCostprice != null ? ProductList[0].TCostprice : 0;
                                        xmorderinfopd.SalesPrice = ProductList[0].Saleprice != null ? xmorderinfopd.ProductNum * ProductList[0].Saleprice : 0;
                                    }
                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.Remarks = xmorderinfo.CustomerServiceRemark;
                                    xmorderinfopd.IsAudit = false;
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.IsExpedited = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);
                                }
                            }
                            IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                            resultCount++;
                            #endregion
                        }
                    }
                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            paramMessage = "导入成功";
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
                #endregion

                #region 京东自营-暂时是copy亚马逊的
                if (PlatformTypeName == "京东自营")
                {
                    if (FileName.Trim() == "京东自营")
                    {
                        dt = excelHelper.ReadTable("京东自营");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            //订单详情
                            var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString().Trim());

                            //string ManufacturersCode = row1["产品编码"].ToString().Trim();                  //商品编码
                            //string PlatFormMerchantCode = "";                                                            //商品编码
                            //var product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                            //if (product != null)
                            //{
                            //    var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductIdAndPlatFormId(product.Id, 537);
                            //    if (productDetails != null)
                            //    {
                            //        PlatFormMerchantCode = productDetails.PlatformMerchantCode;
                            //    }
                            //}
                            //京东Id查询。
                            string PlatFormMerchantCode = row1["产品编码"].ToString().Trim();
                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 537);
                            var ProductZuheList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByzuheCode(PlatFormMerchantCode, 537);// 获取组合产品信息

                            if (xmorderinfo == null)
                            {
                                #region  新增
                                xmorderinfo = new XMOrderInfo();
                                xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;

                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;

                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }

                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                xmorderinfo.FinancialAudit = true;
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (ZP.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = ZP.Substring(ZP.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.OrderStatus = "WAIT_SELLER_DELIVERY";//"新";
                                xmorderinfo.IsEnable = false;//是否删除
                                xmorderinfo.IsCashBack = false;//是否返现
                                xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                xmorderinfo.IsEvaluate = false;//是否赔付
                                xmorderinfo.IsOurOrder = true;
                                xmorderinfo.CreateDate = DateTime.Now;
                                xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim()) * ProductNumV;//销售价
                                if (ProductZuheList.Count > 0)
                                {
                                    Dictionary<string, decimal> productPrice = new Dictionary<string, decimal>();
                                    foreach (var elem in ProductZuheList)//拆分组合商品
                                    {
                                        XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                        xmorderinfopd.ProductNum = ProductNumV * elem.count;//单个商品的数量
                                        xmorderinfopd.PlatformMerchantCode = elem.PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = elem.Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = elem.Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = elem.ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = elem.ManufacturersCode;
                                        xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                        xmorderinfopd.SalesPrice = elem.Saleprice * ProductNumV;//销售价
                                        xmorderinfopd.ISArrivedLibrary = false;
                                        xmorderinfopd.IsAudit = false;//是否审核
                                        xmorderinfopd.IsExpedited = false;//是否加急
                                        xmorderinfopd.IsEnable = false;
                                        xmorderinfopd.CreateDate = DateTime.Now;
                                        xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfopd.UpdateDate = DateTime.Now;
                                        xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                    }
                                    #region 拆分订单中的支付金额到该订单中的所有商品
                                    var productList = xmorderinfo.XM_OrderInfoProductDetails;
                                    setProductprice(productList, SalesPriceV, productPrice);
                                    foreach (var elem in xmorderinfo.XM_OrderInfoProductDetails)
                                    {
                                        elem.SalesPrice = productPrice.Keys.Contains(elem.PlatformMerchantCode) ? productPrice[elem.PlatformMerchantCode] : 0;
                                    }
                                    #endregion
                                    xmorderinfo.PayPrice = xmorderinfo.XM_OrderInfoProductDetails.Sum(m=>m.SalesPrice);//已支付金额
                                    IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                    resultCount++;
                                }
                                else
                                {
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    //decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV;//销售价
                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                    xmorderinfo.PayPrice = SalesPriceV;//已支付金额

                                    IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                    resultCount++;
                                }

                                #endregion
                            }
                            else
                            {
                                #region 修改
                                // xmorderinfo = new XMOrderInfo();
                                //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>(); 
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;
                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }
                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                xmorderinfo.FinancialAudit = true;
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (CustomerServiceRemark.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = CustomerServiceRemark.Substring(CustomerServiceRemark.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                decimal PayPriceV = xmorderinfo.PayPrice.Value;//之前的支付金额

                                //订单明细
                                var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);

                                if (xmorderinfopdList.Count == 0)
                                {

                                    //订单明细信息
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急 
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;

                                }
                                else
                                {
                                    //订单明细修改 
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];

                                    PayPriceV = xmorderinfo.PayPrice.Value - xmorderinfopd.SalesPrice.Value;//已支付金额=订单已支付总金额-修改之前的产品销售价

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价  
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;//最新已支付金额
                                }

                                xmorderinfo.PayPrice = PayPriceV;

                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                        }
                        paramMessage = "导入成功";
                    }
                    else
                    {
                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }
                }

                #endregion

                #region 苏宁自营
                if (PlatformTypeName == "苏宁自营")
                {
                    if (FileName.Trim() == "苏宁自营")
                    {
                        dt = excelHelper.ReadTable("苏宁自营");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            //订单详情
                            var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());

                            string ManufacturersCode = row1["产品编码"].ToString().Trim();                  //厂家编码
                            string PlatFormMerchantCode = "";                                                            //商品编码
                            var product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                            if (product != null)
                            {
                                var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductIdAndPlatFormId(product.Id, PlatformTypeNameId);
                                if (productDetails != null)
                                {
                                    PlatFormMerchantCode = productDetails.PlatformMerchantCode;
                                }
                            }
                            //京东Id查询。
                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, PlatformTypeNameId);

                            if (xmorderinfo == null)
                            {
                                #region  新增
                                xmorderinfo = new XMOrderInfo();
                                xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;

                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;

                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }

                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }

                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (ZP.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = ZP.Substring(ZP.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion

                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.OrderStatus = "已付款";//"新";
                                xmorderinfo.IsEnable = false;//是否删除
                                xmorderinfo.IsCashBack = false;//是否返现
                                xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                xmorderinfo.IsEvaluate = false;//是否赔付
                                xmorderinfo.IsOurOrder = true;
                                xmorderinfo.CreateDate = DateTime.Now;
                                xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                }
                                else
                                {
                                    xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                    xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                    xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.IsAudit = false;//是否审核
                                xmorderinfopd.IsExpedited = false;//是否加急
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                xmorderinfo.PayPrice = SalesPriceV * ProductNumV;//已支付金额

                                IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                            else
                            {
                                #region 修改
                                // xmorderinfo = new XMOrderInfo();
                                //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>(); 
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;
                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }
                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价

                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (CustomerServiceRemark.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = CustomerServiceRemark.Substring(CustomerServiceRemark.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                decimal PayPriceV = xmorderinfo.PayPrice.Value;//之前的支付金额

                                //订单明细
                                var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);

                                if (xmorderinfopdList.Count == 0)
                                {
                                    //订单明细信息
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急 
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;

                                }
                                else
                                {
                                    //订单明细修改 
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];

                                    PayPriceV = xmorderinfo.PayPrice.Value - xmorderinfopd.SalesPrice.Value;//已支付金额=订单已支付总金额-修改之前的产品销售价

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价  
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;//最新已支付金额
                                }

                                xmorderinfo.PayPrice = PayPriceV;

                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                        }
                    }
                    else
                    {
                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }
                }
                #endregion

                #region 小红书
                if (PlatformTypeName == "小红书")
                {
                    if (!string.IsNullOrEmpty(FileName.Trim()))
                    {
                        var XMOrderInfoService = IoC.Resolve<IXMOrderInfoService>();
                        var XMOrderInfoProductDetailsService = IoC.Resolve<IXMOrderInfoProductDetailsService>();
                        var XMProductDetailsService = IoC.Resolve<IXMProductDetailsService>();

                        dt = excelHelper.ReadTable("Sheet1");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        //var query = from p in dt.AsEnumerable()
                        //            group p by p.Field<string>("订单号") into g
                        //            select new 
                        //            {
                        //                key=g.Key,
                        //                //price = g.Sum(p =>decimal.Parse(p.Field<string>("sku单价"))),
                        //                price = g.Sum(p => decimal.Parse(p.Field<double>("单价").ToString())),
                        //                realPrice = g.Sum(p => decimal.Parse(p.Field<double>("实付总计").ToString())),
                        //                orderPrice = g.Sum(p => decimal.Parse(p.Field<double>("应收").ToString())),
                        //                salePrice = g.Sum(p => decimal.Parse(p.Field<double>("销售金额").ToString())),
                        //                //xhsCost = g.Sum(p => decimal.Parse(p.Field<string>("小红书承担优惠"))),
                        //                xhsCost =0,
                        //                //disCount = g.Sum(p =>decimal.Parse(p.Field<string>("小红书承担优惠"))) + g.Sum(p =>decimal.Parse(p.Field<string>("商家承担优惠"))),
                        //                disCount = g.Sum(p => decimal.Parse(p.Field<double>("应收").ToString())) - g.Sum(p => decimal.Parse(p.Field<double>("实付总计").ToString())),//促销优惠
                        //            };
                   

                        var query1 = from p in dt.AsEnumerable()
                                    group p by p.Field<string>("订单号") into g
                                    select new
                                    {
                                        key = g.Key,
                                        SkuSalePrice = g.Sum(p => decimal.Parse(p.Field<string>("sku实付单价"))),
                                        SkuPrice = g.Sum(p => decimal.Parse(p.Field<string>("sku单价"))),
                                        number = g.Sum(p => decimal.Parse(p.Field<string>("sku数量"))),
                                        xhsCost = g.Sum(p => decimal.Parse(p.Field<string>("小红书承担优惠"))),
                                        sjCos = g.Sum(p => decimal.Parse(p.Field<string>("商家承担优惠"))),
                                    };
                        var query2 = from q in query1.AsEnumerable()
                                     select new
                                     {
                                         q.key,
                                         price = q.SkuPrice,
                                         //realPrice = q.SkuSalePrice * q.number - q.sjCos - q.xhsCost,//已支付金额
                                         realPrice = q.SkuSalePrice * q.number,//已支付金额
                                         orderPrice = q.SkuPrice * q.number, //商品总额
                                         salePrice = q.SkuSalePrice * q.number,//订单总额
                                         disCount = q.sjCos + q.xhsCost,
                                         ReceivablePrice = q.SkuSalePrice * q.number + q.xhsCost//到帐金额
                                     };

                        try
                        {
                            //事务
                            using (TransactionScope scope = new TransactionScope())
                            {
                                foreach (var item in query2)
                                {
                                    XMOrderInfo entity = XMOrderInfoService.GetXMOrderInfoByOrderCode(item.key);
                                    if(entity!=null)
                                    {
                                        throw new Exception("订单号" + item.key + "已存在,导入失败，请重新调整数据");
                                    }
                                    DataRow[] drs = dt.Select("订单号='" + item.key + "'");
                                    XMOrderInfo modelOrder = new XMOrderInfo();
                                    modelOrder.NickID = NickId;
                                    modelOrder.PlatformTypeId = PlatformTypeNameId;
                                    modelOrder.OrderInfoCreateDate = DateTime.Parse(drs[0]["订单创建时间"].ToString());
                                    modelOrder.DeliveryTime = null;
                                    modelOrder.PayDate = DateTime.Parse(drs[0]["订单创建时间"].ToString());
                                    modelOrder.CompletionTime = null;
                                    modelOrder.OrderInfoModified = null;
                                    modelOrder.OrderCode = item.key;
                                    //订单状态(通用) 已付款
                                    modelOrder.OrderStatus = "已付款";
                                    modelOrder.WantID = "";
                                    modelOrder.BuyerName = "";
                                    modelOrder.BuyerMobile = "";
                                    modelOrder.BuyerPhone = "";
                                    modelOrder.BuyerAddress = "";
                                    modelOrder.BuyerE_mail = "";
                                    modelOrder.FullName = drs[0]["收件人姓名"].ToString();
                                    modelOrder.Province = drs[0]["省"].ToString();
                                    modelOrder.City = drs[0]["市"].ToString();
                                    modelOrder.County = drs[0]["区"].ToString();
                                    modelOrder.DeliveryAddress = drs[0]["收件人地址"].ToString();
                                    modelOrder.DeliveryAddressSpare = "";
                                    modelOrder.Mobile = drs[0]["收件人电话"].ToString();
                                    modelOrder.Tel = "";
                                    modelOrder.SourceType = sourceType;
                                    modelOrder.CustomerServiceRemark = "";
                                    modelOrder.Remark = "";
                                    modelOrder.BelongsServiceId = null;
                                    modelOrder.ForService = "";
                                    modelOrder.IsInvoiced = null;
                                    modelOrder.InvoiceNo = "";
                                    modelOrder.InvoiceHead = "";
                                    modelOrder.PayMethod = "";
                                    modelOrder.InvoicePrice = 0;
                                    modelOrder.DistributeMethod = "";
                                    modelOrder.DistributePrice = 0;
                                    modelOrder.IsDistributed = null;
                                    modelOrder.FinancialAudit = true;
                                    modelOrder.SupportPrice = 0;
                                    //modelOrder.ProductWeight = decimal.Parse(drs[0]["订单总净重(g)"].ToString()) ;
                                    modelOrder.ProductWeight =decimal.Parse(drs[0]["订单总净重(g)"].ToString()) * 1000;
                                    modelOrder.Taxes = 0;
                                    modelOrder.Discount = 0;
                                    modelOrder.ProductPromotion = item.disCount;//促销优惠
                                    modelOrder.OrderPromotion = 0;
                                    modelOrder.OrderPrice = item.salePrice;//订单总额=销售金额
                                    modelOrder.ReceivablePrice = item.ReceivablePrice;//订单到账金额 = 订单总额-商家承担优惠
                                    modelOrder.PayPrice = item.realPrice;//订单已支付金额=实付总计
                                    modelOrder.ProductPrice = item.orderPrice; //订单商品总额=应收
                                    modelOrder.IsScalping = null;
                                    modelOrder.IsCashBack = null;
                                    modelOrder.IsSentGifts = null;
                                    modelOrder.IsEvaluate = null;
                                    modelOrder.IsAudit = null;
                                    modelOrder.IsOurOrder = true;
                                    modelOrder.IsEnable = false;
                                    modelOrder.CreateID = HozestERPContext.Current.User.CustomerID;
                                    modelOrder.CreateDate = DateTime.Now;
                                    modelOrder.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    modelOrder.UpdateDate = DateTime.Now;

                                    XMOrderInfoService.InsertXMOrderInfo(modelOrder);

                                    foreach (DataRow row in drs)
                                    {
                                        string TManufacturersCode = "";
                                        XMProductDetails entity_ProductDetails = null;
                                        //var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(row["sku条码"].ToString(), 765);
                                        var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(row["sku条码"].ToString(), 765);
                                        if (ProductList.Count > 0)
                                        {
                                            TManufacturersCode = ProductList[0].ManufacturersCode;
                                            entity_ProductDetails = XMProductDetailsService.GetXMProductDetailsById(ProductList[0].Id);

                                        }
                                        else
                                        {

                                            //Common.Utils.CommonHelper.MessageShow(this., "订单号 " + item.key + " 找不到对应商品,导入失败");
                                            //continue;
                                           throw new Exception("订单号 " + item.key+" 找不到对应商品,导入失败");
                                        }

                                        XMOrderInfoProductDetails model = new XMOrderInfoProductDetails();
                                        model.OrderInfoID = modelOrder.ID;
                                        model.PlatformMerchantCode = row["sku条码"].ToString();
                                        model.TManufacturersCode = TManufacturersCode;
                                        model.ProductName = row["sku名称"].ToString().Length > 50 ? row["sku名称"].ToString() .Substring(0,50): row["sku名称"].ToString();
                                        model.Specifications = row["sku规格"].ToString();
                                        model.SpareRemarks = "";
                                        model.ProductNum = int.Parse(row["sku数量"].ToString());
                                        model.FactoryPrice = entity_ProductDetails == null ? 0 : entity_ProductDetails.Costprice* int.Parse(row["sku数量"].ToString());
                                        model.TCostprice = entity_ProductDetails == null ? 0 : entity_ProductDetails.TCostprice* int.Parse(row["sku数量"].ToString());
                                        model.SalesPrice = decimal.Parse(row["sku实付单价"].ToString())* int.Parse(row["sku数量"].ToString());
                                        model.ISArrivedLibrary = null;
                                        model.Remarks = "";
                                        model.CutoffShipDay = null;
                                        model.IsAudit = null;
                                        model.IsEnable = false;
                                        model.CreateID = HozestERPContext.Current.User.CustomerID;
                                        model.CreateDate = DateTime.Now;
                                        model.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        model.UpdateDate = DateTime.Now;
                                        model.IsExpedited = null;
                                        model.Status = "";
                                        model.IsSingleRow = null;
                                        XMOrderInfoProductDetailsService.InsertXMOrderInfoProductDetails(model);
                                    }

                                    resultCount++;
                                }

                                scope.Complete();
                            }
                            paramMessage = "导入成功";
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }

                    }
                }
                #endregion

                #region 贝贝网
                if (PlatformTypeName == "贝贝网")
                {
                    if (FileName.Trim() == "贝贝网")
                    {
                        var XMOrderInfoService = IoC.Resolve<IXMOrderInfoService>();
                        var XMOrderInfoProductDetailsService = IoC.Resolve<IXMOrderInfoProductDetailsService>();

                        dt = excelHelper.ReadTable("贝贝网");
                        dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        var query = from p in dt.AsEnumerable()
                                    group p by p.Field<string>("订单编号") into g
                                    select new
                                    {
                                        key = g.Key,
                                    };

                        //事务
                        using (TransactionScope scope = new TransactionScope())
                        {
                            foreach (var item in query)
                            {
                                XMOrderInfo entity = XMOrderInfoService.GetXMOrderInfoByOrderCode(item.key);
                                if (entity != null)
                                {
                                    throw new Exception("订单号" + item.key + "已存在,导入失败，请重新调整数据");
                                }

                                DataRow[] drs = dt.Select("订单编号='" + item.key + "'");

                                XMOrderInfo modelOrder = new XMOrderInfo();
                                modelOrder.NickID = NickId;
                                modelOrder.PlatformTypeId = PlatformTypeNameId;
                                modelOrder.OrderInfoCreateDate = DateTime.Parse(drs[0][" 下单时间"].ToString());
                                modelOrder.DeliveryTime = DateTime.Parse(drs[0]["发货时间"].ToString());
                                modelOrder.PayDate = DateTime.Parse(drs[0]["支付时间"].ToString());
                                modelOrder.CompletionTime = null;
                                modelOrder.OrderInfoModified = null;
                                modelOrder.OrderCode = item.key;
                                //订单状态(通用) 已付款
                                modelOrder.OrderStatus = "已付款";
                                modelOrder.WantID = "";
                                modelOrder.BuyerName = "";
                                modelOrder.BuyerMobile = "";
                                modelOrder.BuyerPhone = "";
                                modelOrder.BuyerAddress = "";
                                modelOrder.BuyerE_mail = "";
                                modelOrder.FullName = drs[0]["收件人"].ToString();
                                modelOrder.Province = "";
                                modelOrder.City = "";
                                modelOrder.County = "";
                                modelOrder.DeliveryAddress = drs[0]["收件地址"].ToString();
                                modelOrder.DeliveryAddressSpare = "";
                                modelOrder.Mobile = drs[0]["收件人手机"].ToString();
                                modelOrder.Tel = "";
                                modelOrder.SourceType = sourceType;
                                modelOrder.CustomerServiceRemark = "";
                                modelOrder.Remark = drs[0]["买家备注"].ToString();
                                modelOrder.BelongsServiceId = null;
                                modelOrder.ForService = "";
                                modelOrder.IsInvoiced = null;
                                modelOrder.InvoiceNo = "";
                                modelOrder.InvoiceHead = "";
                                modelOrder.PayMethod = "";
                                modelOrder.InvoicePrice = 0;
                                modelOrder.DistributeMethod = "";
                                modelOrder.DistributePrice = 0;
                                modelOrder.IsDistributed = null;
                                modelOrder.FinancialAudit = null;
                                modelOrder.SupportPrice = 0;
                                modelOrder.ProductWeight = 0;
                                modelOrder.Taxes = 0;
                                modelOrder.Discount = 0;
                                modelOrder.ProductPromotion = decimal.Parse(drs[0]["平台促销抵扣"].ToString()); ;
                                modelOrder.OrderPromotion = 0;
                                modelOrder.OrderPrice =decimal.Parse(drs[0]["订单金额"].ToString());
                                modelOrder.ReceivablePrice = decimal.Parse(drs[0]["成交价"].ToString()); ;
                                modelOrder.PayPrice = decimal.Parse(drs[0]["用户实付费用"].ToString()); ;
                                modelOrder.IsScalping = null;
                                modelOrder.IsCashBack = null;
                                modelOrder.IsSentGifts = null;
                                modelOrder.IsEvaluate = null;
                                modelOrder.IsAudit = null;
                                modelOrder.IsOurOrder = true;
                                modelOrder.IsEnable = false;
                                modelOrder.CreateID = HozestERPContext.Current.User.CustomerID;
                                modelOrder.CreateDate = DateTime.Now;
                                modelOrder.UpdateID = HozestERPContext.Current.User.CustomerID;
                                modelOrder.UpdateDate = DateTime.Now;

                                XMOrderInfoService.InsertXMOrderInfo(modelOrder);

                                foreach (DataRow row in drs)
                                {
                                    string TManufacturersCode = "";
                                    var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(row["商品编码"].ToString(), 767);
                                    if (ProductList.Count > 0)
                                    {
                                        TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }

                                    XMOrderInfoProductDetails model = new XMOrderInfoProductDetails();
                                    model.OrderInfoID = modelOrder.ID;
                                    model.PlatformMerchantCode = row["商品编码"].ToString();
                                    model.TManufacturersCode = TManufacturersCode;
                                    model.ProductName = row["商品名称"].ToString();
                                    model.Specifications = "";
                                    model.SpareRemarks = "";
                                    model.ProductNum = int.Parse(row["数量"].ToString());
                                    model.FactoryPrice = 0;
                                    model.TCostprice = 0;
                                    model.SalesPrice = 0;
                                    model.ISArrivedLibrary = null;
                                    model.Remarks = "";
                                    model.CutoffShipDay = null;
                                    model.IsAudit = null;
                                    model.IsEnable = false;
                                    model.CreateID = HozestERPContext.Current.User.CustomerID;
                                    model.CreateDate = DateTime.Now;
                                    model.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    model.UpdateDate = DateTime.Now;
                                    model.IsExpedited = null;
                                    model.Status = "";
                                    model.IsSingleRow = null;
                                    XMOrderInfoProductDetailsService.InsertXMOrderInfoProductDetails(model);
                                }

                                resultCount++;
                            }

                            scope.Complete();
                        }
                        paramMessage = "导入成功";
                    }
                    else
                    {
                        paramMessage = "工作表名称必须是贝贝网";
                    }
                }
                #endregion

                #region 拼多多
                if (PlatformTypeName == "拼多多")
                {
                    if (FileName.Trim() == "拼多多")
                    {
                        dt = excelHelper.ReadTable("拼多多");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            //订单详情
                            var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());

                            //产品编码
                            string PlatFormMerchantCode = row1["产品编码"].ToString().Trim();

                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 824);

                            if (xmorderinfo == null)
                            {
                                #region  新增
                                xmorderinfo = new XMOrderInfo();
                                xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();

                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;

                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;

                                //if (payDate != null)
                                //{
                                //    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                //}

                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.OrderStatus = "已付款";
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["单价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (ZP.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = ZP.Substring(ZP.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.OrderStatus = "以接受";//"新";
                                xmorderinfo.IsEnable = false;//是否删除
                                xmorderinfo.IsCashBack = false;//是否返现
                                xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                xmorderinfo.IsEvaluate = false;//是否赔付
                                xmorderinfo.IsOurOrder = true;
                                xmorderinfo.CreateDate = DateTime.Now;
                                xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                }
                                else
                                {

                                    xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                    xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                    xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.IsAudit = false;//是否审核
                                xmorderinfopd.IsExpedited = false;//是否加急
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                xmorderinfo.PayPrice = SalesPriceV * ProductNumV;//已支付金额

                                IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                            else
                            {
                                #region 修改
                                // xmorderinfo = new XMOrderInfo();
                                //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>(); 
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订货数"].ToString().Trim() == "" ? 1 : int.Parse(row1["订货数"].ToString().Trim()));
                                DateTime payDate = (row1["付款时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;
                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                //if (payDate != null)
                                //{
                                //    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                //}
                                xmorderinfo.WantID = row1["会员名称"].ToString().Trim();
                                xmorderinfo.FullName = row1["收货人姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["地址"].ToString().Trim();
                                xmorderinfo.Province = row1["所在省"].ToString().Trim();//收货人省
                                xmorderinfo.City = row1["所在市"].ToString().Trim();//收货人市
                                xmorderinfo.County = row1["所在县（区）"].ToString().Trim();//收货人区
                                //xmorderinfo.SourceType = "导入";
                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.OrderPrice = decimal.Parse(row1["供货价"].ToString().Trim());

                                string OrderSpecifications = row1["尺寸"].ToString().Trim();//尺寸
                                string OrderFactoryPrice = row1["供货价"].ToString().Trim();//供货价


                                string Mobile = row1["手机"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["手机"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }
                                #region 备注
                                string Remarks = row1["卖家备注"].ToString().Trim();
                                string ZPRemarks = "/" + row1["赠品备注"].ToString().Trim() + "/";

                                string CustomerServiceRemark = Remarks + ZPRemarks;

                                if (CustomerServiceRemark.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = CustomerServiceRemark;
                                }
                                else
                                {
                                    string suRemarks = CustomerServiceRemark.Substring(CustomerServiceRemark.LastIndexOf("'") + 1).ToLower();// 取'号 
                                    xmorderinfo.CustomerServiceRemark = suRemarks;
                                }

                                string ZP = row1["赠品备注"].ToString().Trim();

                                if (ZP != "")
                                {

                                    string WantNo = row1["会员名称"].ToString().Trim();//旺旺号
                                    string OrderCode = row1["订单号"].ToString().Trim();//订单号  

                                    #region 赠品
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                    //string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                    //string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                    string PremiumsActivityExplanation = "";//活动说明
                                    string PremiumsPrdouctName = "";//商品名称
                                    string PremiumsPlatformMerchantCode = "";//商品编码
                                    string PremiumsFactoryPrice = "0";//出厂价
                                    string PremiumsProductNum = "0";//数量
                                    string Specifications = "";//尺寸    
                                    int ProductDetaislId = -1;


                                    if (CustomerServiceRemark.IndexOf("赠品") > -1)
                                    {
                                        //判断赠品申请表中是否已经存在 相同订单号
                                        var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, -1);

                                        if (premiumsList.Count == 0)
                                        {
                                            string s = CustomerServiceRemark.Substring(CustomerServiceRemark.IndexOf("赠品") + 3);
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                PremiumsActivityExplanation = s.Substring(0, f);

                                                #region 去除赠品、：、3个字符 （长度等于2）
                                                if ((PremiumsActivityExplanation.IndexOf("（") == -1 && PremiumsActivityExplanation.IndexOf("）") == -1)
                        && (PremiumsActivityExplanation.IndexOf("(") == -1 && PremiumsActivityExplanation.IndexOf(")") == -1)
                        && PremiumsActivityExplanation.IndexOf("+") == -1 && PremiumsActivityExplanation.IndexOf("*") == -1)
                                                {
                                                    PremiumsPrdouctName = s.Substring(0, f);

                                                    PremiumsProductNum = "1";

                                                    if (PremiumsPrdouctName != "")
                                                    {
                                                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                        if (xmProductList.Count > 0)
                                                        {
                                                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            ProductDetaislId = xmProductList[0].Id;
                                                        }
                                                    }

                                                    decimal d = 0;
                                                    int INum = 0;
                                                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                    {
                                                        //主表信息
                                                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                        //明细信息
                                                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                    }
                                                    PremiumsActivityExplanation = "";//活动说明
                                                    PremiumsPrdouctName = "";//商品名称
                                                    PremiumsPlatformMerchantCode = "";//商品编码
                                                    PremiumsFactoryPrice = "0";//出厂价
                                                    PremiumsProductNum = "0";//数量
                                                    Specifications = "";//尺寸    
                                                    ProductDetaislId = -1;

                                                }
                                                #endregion
                                                #region 字符大于2个字符
                                                else if (f > 2)
                                                {
                                                    string[] J = PremiumsActivityExplanation.Split('+');

                                                    string strNum = "";//数量字符

                                                    #region 多个赠品
                                                    if (PremiumsActivityExplanation != "" && J.Length > 1)
                                                    {
                                                        for (int Ji = 0; Ji < J.Length; Ji++)
                                                        {
                                                            string pe = J[Ji];
                                                            string remsub = "";//尺寸+商品名称字符

                                                            if (pe != "")
                                                            {
                                                                #region 尺寸、商品名称
                                                                if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                                                {
                                                                    string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                                                    int b = a1.IndexOf("）");
                                                                    int c = pe.IndexOf("（");

                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }

                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);
                                                                        remsub += "（" + Specifications + "）";
                                                                    }

                                                                }
                                                                if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                                                {

                                                                    string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                                                    int b = a1.IndexOf(")");
                                                                    int c = pe.IndexOf("(");
                                                                    if (c > -1)
                                                                    {
                                                                        PremiumsPrdouctName = pe.Substring(0, c);
                                                                        remsub += PremiumsPrdouctName;
                                                                    }
                                                                    if (b > -1)
                                                                    {
                                                                        Specifications = a1.Substring(0, b);

                                                                        remsub += "(" + Specifications + ")";
                                                                    }

                                                                }
                                                                #endregion
                                                                #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                                int Intd = pe.IndexOf(remsub);
                                                                if (Intd > -1)
                                                                {
                                                                    strNum = pe.Substring(remsub.Length).ToLower();
                                                                }
                                                                if (strNum != "")
                                                                {
                                                                    //数量
                                                                    if (strNum.IndexOf("*") > -1)
                                                                    {
                                                                        string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                                                        PremiumsProductNum = a1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PremiumsProductNum = "1";
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    PremiumsProductNum = "1";
                                                                }

                                                                #endregion

                                                                if (PremiumsPrdouctName == "")
                                                                {

                                                                    PremiumsPrdouctName = pe;
                                                                }
                                                                if (PremiumsPrdouctName != "")
                                                                {
                                                                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                                    if (PremiumsPrdouctName != "" && Specifications != "")
                                                                    {
                                                                        xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                                    }
                                                                    if (xmProductList.Count > 0)
                                                                    {
                                                                        ProductDetaislId = xmProductList[0].Id;
                                                                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                                    }

                                                                }


                                                                decimal d = 0;
                                                                int INum = 0;
                                                                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                                {
                                                                    //主表信息
                                                                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                                    //明细信息
                                                                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                                }
                                                                //PremiumsActivityExplanation = "";//活动说明
                                                                PremiumsPrdouctName = "";//商品名称
                                                                PremiumsPlatformMerchantCode = "";//商品编码
                                                                PremiumsFactoryPrice = "0";//出厂价
                                                                PremiumsProductNum = "0";//数量
                                                                Specifications = "";//尺寸    
                                                                ProductDetaislId = -1;
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region 单个赠品
                                                    else
                                                    {

                                                        string strNum1 = "";//数量字符
                                                        string remsub = "";//尺寸+商品名称字符
                                                        string PEl = PremiumsActivityExplanation;
                                                        #region 尺寸、商品名称
                                                        if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                                        {
                                                            string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                                            int b = a.IndexOf("）");
                                                            int c = PEl.IndexOf("（");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);
                                                                remsub += "（" + Specifications + "）";
                                                            }

                                                        }
                                                        if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                                        {

                                                            string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                                            int b = a.IndexOf(")");
                                                            int c = PEl.IndexOf("(");
                                                            if (c > -1)
                                                            {
                                                                PremiumsPrdouctName = PEl.Substring(0, c);
                                                                remsub += PremiumsPrdouctName;
                                                            }
                                                            if (b > -1)
                                                            {
                                                                Specifications = a.Substring(0, b);

                                                                remsub += "(" + Specifications + ")";
                                                            }
                                                        }
                                                        #endregion

                                                        #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                                        int Intd = PEl.IndexOf(remsub);
                                                        if (Intd > -1)
                                                        {
                                                            strNum1 = PEl.Substring(remsub.Length).ToLower();
                                                        }
                                                        if (strNum1 != "")
                                                        {
                                                            //数量
                                                            if (strNum1.IndexOf("*") > -1)
                                                            {
                                                                string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                                                PremiumsProductNum = a;

                                                                if (PremiumsPrdouctName == "")
                                                                {
                                                                    PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PremiumsProductNum = "1";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PremiumsProductNum = "1";
                                                        }

                                                        #endregion
                                                        if (PremiumsPrdouctName != "")
                                                        {
                                                            var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                                            if (PremiumsPrdouctName != "" && Specifications != "")
                                                            {
                                                                xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                                            }
                                                            if (xmProductList.Count > 0)
                                                            {
                                                                ProductDetaislId = xmProductList[0].Id;
                                                                PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                                                PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                                            }

                                                        }

                                                        decimal d = 0;
                                                        int INum = 0;
                                                        if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                                        {
                                                            //主表信息
                                                            int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, Convert.ToInt32(StatusEnum.ChildPremiums), PremiumsActivityExplanation, false, d * INum, PlatformTypeNameId, NickId);
                                                            //明细信息
                                                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                                        }
                                                        PremiumsActivityExplanation = "";//活动说明
                                                        PremiumsPrdouctName = "";//商品名称
                                                        PremiumsPlatformMerchantCode = "";//商品编码
                                                        PremiumsFactoryPrice = "0";//出厂价
                                                        PremiumsProductNum = "0";//数量
                                                        Specifications = "";//尺寸    
                                                        ProductDetaislId = -1;
                                                    }
                                                    #endregion
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion

                                }

                                #endregion
                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id  
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                decimal PayPriceV = xmorderinfo.PayPrice.Value;//之前的支付金额

                                //订单明细
                                var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);

                                if (xmorderinfopdList.Count == 0)
                                {

                                    //订单明细信息
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价
                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急 
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;

                                }
                                else
                                {
                                    //订单明细修改 
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];


                                    PayPriceV = xmorderinfo.PayPrice.Value - xmorderinfopd.SalesPrice.Value;//已支付金额=订单已支付总金额-修改之前的产品销售价

                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ""; //料号（商品编码）
                                        xmorderinfopd.Specifications = OrderSpecifications;//尺寸
                                        xmorderinfopd.FactoryPrice = Convert.ToDecimal(OrderFactoryPrice) * ProductNumV; ;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价
                                    xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价  
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);

                                    PayPriceV += SalesPriceV * ProductNumV;//最新已支付金额

                                }

                                xmorderinfo.PayPrice = PayPriceV;

                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                            }
                        }

                    }
                    else
                    {

                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }
                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }
                }
                #endregion

                #region 通用
                if (PlatformTypeName == "通用" )
                {
                    //通用模版
                    if (FileName.Trim() == "通用模版")
                    {
                        dt = excelHelper.ReadTable("通用");
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        foreach (DataRow row1 in dt.Rows)
                        {
                            //订单详情
                            var xmorderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString());

                            //产品编码
                            string PlatFormMerchantCode = row1["商品ID"].ToString().Trim();
                            //京东Id查询。
                            var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(PlatFormMerchantCode, 0);
                            //新修改查询已审核的订单详细数据
                            List<XMOrderInfoProductDetails> OrderInfo2 = new List<XMOrderInfoProductDetails>();
                            if (xmorderinfo != null)
                            {
                                OrderInfo2 = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderId(xmorderinfo.ID).Where(p => p.IsAudit == true).ToList();
                            }

                            if (xmorderinfo == null)
                            {
                                #region 新增
                                xmorderinfo = new XMOrderInfo();
                                xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订购数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["订购数量"].ToString().Trim()));
                                DateTime payDate = (row1["付款确认时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款确认时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;

                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }
                                xmorderinfo.WantID = row1["下单帐号"].ToString().Trim();
                                xmorderinfo.FullName = row1["客户姓名"].ToString().Trim();
                                xmorderinfo.Province = "";
                                xmorderinfo.City = "";
                                xmorderinfo.County = "";
                                xmorderinfo.Tel = "";
                                xmorderinfo.DeliveryAddress = row1["客户地址"].ToString().Trim();
                                xmorderinfo.Province= row1["省"].ToString().Trim();
                                xmorderinfo.City= row1["市"].ToString().Trim();
                                xmorderinfo.County= row1["区"].ToString().Trim();
                                string Mobile = row1["联系电话"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["联系电话"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }

                                #region 备注
                                string Remarks = row1["商家备注"].ToString().Trim();

                                if (Remarks.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = Remarks;
                                }
                                else
                                {
                                    string suRemarks = Remarks.Substring(Remarks.LastIndexOf("'") + 1).ToLower();// 取号
                                    xmorderinfo.Remark = suRemarks;
                                }
                                #endregion

                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id 

                                xmorderinfo.OrderStatus = row1["订单状态"].ToString().Trim();

                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.IsEnable = false;//是否删除
                                xmorderinfo.IsCashBack = false;//是否返现
                                xmorderinfo.IsSentGifts = false;//是否已发赠品 
                                xmorderinfo.IsEvaluate = false;//是否赔付
                                xmorderinfo.IsOurOrder = true;
                                xmorderinfo.CreateDate = DateTime.Now;
                                xmorderinfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                xmorderinfopd.ProductNum = ProductNumV;
                                if (ProductList.Count > 0)
                                {
                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                    xmorderinfopd.SalesPrice = ProductList[0].Saleprice * ProductNumV;
                                }
                                else
                                {
                                    xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                    xmorderinfopd.Specifications = "";//尺寸
                                    xmorderinfopd.FactoryPrice = 0;//出厂价
                                    xmorderinfopd.ProductName = "无产品";
                                    xmorderinfopd.TManufacturersCode = "";
                                    xmorderinfopd.SalesPrice = 0;
                                }
                                xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                //decimal SalesPriceV = Convert.ToDecimal(row1["结算金额"].ToString().Trim());//销售价
                                //xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价

                                xmorderinfo.OrderPrice = Convert.ToDecimal(row1["订单金额"].ToString().Trim());
                                xmorderinfo.PayPrice = Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                xmorderinfo.ReceivablePrice = Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                xmorderinfo.ProductPrice = xmorderinfopd.SalesPrice;

                                xmorderinfopd.ISArrivedLibrary = false;
                                xmorderinfopd.IsAudit = false;//是否审核
                                xmorderinfopd.IsExpedited = false;//是否加急
                                xmorderinfopd.IsEnable = false;
                                xmorderinfopd.CreateDate = DateTime.Now;
                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfopd.UpdateDate = DateTime.Now;
                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xmorderinfo);
                                resultCount++;
                                #endregion
                            }
                            else if (xmorderinfo != null && (OrderInfo2 == null || OrderInfo2.Count == 0))
                            {
                                #region 修改

                                //xmorderinfo = new XMOrderInfo();
                                //xmorderinfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
                                xmorderinfo.OrderCode = row1["订单号"].ToString().Trim();
                                int ProductNumV = (row1["订购数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["订购数量"].ToString().Trim()));
                                DateTime payDate = (row1["付款确认时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["付款确认时间"].ToString().Trim()));
                                xmorderinfo.PayDate = payDate;
                                DateTime OrderInfoCreateDate = (row1["下单时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["下单时间"].ToString().Trim()));
                                xmorderinfo.OrderInfoCreateDate = OrderInfoCreateDate;
                                if (payDate != null)
                                {
                                    xmorderinfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                }
                                xmorderinfo.WantID = row1["下单帐号"].ToString().Trim();
                                xmorderinfo.FullName = row1["客户姓名"].ToString().Trim();
                                xmorderinfo.DeliveryAddress = row1["客户地址"].ToString().Trim();
                                xmorderinfo.Province = row1["省"].ToString().Trim();
                                xmorderinfo.City = row1["市"].ToString().Trim();
                                xmorderinfo.County = row1["区"].ToString().Trim();
                                string Mobile = row1["联系电话"].ToString().Trim();
                                if (Mobile.IndexOf("'") == -1)
                                {
                                    xmorderinfo.Mobile = row1["联系电话"].ToString().Trim();
                                }
                                else
                                {
                                    string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                    xmorderinfo.Mobile = suMobile;
                                }

                                #region 备注
                                string Remarks = row1["商家备注"].ToString().Trim();

                                if (Remarks.IndexOf("'") == -1)//没有’
                                {
                                    xmorderinfo.CustomerServiceRemark = Remarks;
                                }
                                #endregion

                                xmorderinfo.PlatformTypeId = PlatformTypeNameId;
                                xmorderinfo.NickID = NickId;//店铺Id

                                xmorderinfo.OrderStatus = row1["订单状态"].ToString().Trim();

                                xmorderinfo.SourceType = sourceType;//"导入";
                                if (sourceType == "导入")
                                {
                                    xmorderinfo.FinancialAudit = true;
                                }
                                else
                                {
                                    xmorderinfo.FinancialAudit = false;
                                }
                                xmorderinfo.IsScalping = false;
                                xmorderinfo.UpdateDate = DateTime.Now;
                                xmorderinfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                //订单明细信息
                                var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xmorderinfo.ID, PlatFormMerchantCode);
                                if (xmorderinfopdList.Count == 0)
                                {
                                    XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                        xmorderinfopd.SalesPrice = ProductList[0].Saleprice * ProductNumV;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = "";//尺寸
                                        xmorderinfopd.FactoryPrice = 0;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.TManufacturersCode = "";
                                        xmorderinfopd.SalesPrice = 0;
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    //decimal SalesPriceV = Convert.ToDecimal(row1["结算金额"].ToString().Trim());//销售价
                                    //xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价

                                    xmorderinfo.OrderPrice = xmorderinfo.OrderPrice + Convert.ToDecimal(row1["订单金额"].ToString().Trim());
                                    xmorderinfo.PayPrice = xmorderinfo.PayPrice + Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                    xmorderinfo.ReceivablePrice = xmorderinfo.ReceivablePrice + Convert.ToDecimal(row1["结算金额"].ToString().Trim());
                                    xmorderinfo.ProductPrice += xmorderinfopd.SalesPrice;

                                    xmorderinfopd.ISArrivedLibrary = false;
                                    xmorderinfopd.IsAudit = false;//是否审核
                                    xmorderinfopd.IsExpedited = false;//是否加急
                                    xmorderinfopd.IsEnable = false;
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                }
                                else
                                {
                                    //订单明细修改 
                                    XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];
                                    xmorderinfopd.ProductNum = ProductNumV;
                                    if (ProductList.Count > 0)
                                    {
                                        xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                        xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                        xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                        xmorderinfopd.SalesPrice = ProductList[0].Saleprice * ProductNumV;
                                    }
                                    else
                                    {
                                        xmorderinfopd.PlatformMerchantCode = PlatFormMerchantCode; //料号（商品编码）
                                        xmorderinfopd.Specifications = "";//尺寸
                                        xmorderinfopd.FactoryPrice = 0;//出厂价
                                        xmorderinfopd.ProductName = "无产品";
                                        xmorderinfopd.SalesPrice = 0;
                                    }
                                    xmorderinfopd.CutoffShipDay = payDate.AddDays(+15);//截止发货日 
                                    //decimal SalesPriceV = Convert.ToDecimal(row1["结算金额"].ToString().Trim());//销售价
                                    //xmorderinfopd.SalesPrice = SalesPriceV * ProductNumV;//销售价 
                                    xmorderinfopd.CreateDate = DateTime.Now;
                                    xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmorderinfopd.UpdateDate = DateTime.Now;
                                    xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);
                                }
                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xmorderinfo);
                                resultCount++;

                                #endregion
                                //paramMessage += "订单号:" + row1["订单号"].ToString() + ";商品ID:" + row1["商品ID"].ToString() + "已存在" + "\t\n";
                            }
                        }
                        // }
                    }
                    else
                    {
                        paramMessage = PlatformTypeName + "平台文件名称有误！";
                    }

                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }

                }
                #endregion
            }
        }
        /// <summary>
        /// 计算每个产品对应的销售价格
        /// </summary>
        /// <param name="ProductList"></param>
        /// <param name="SalePrice">组合商品总价</param>
        /// <param name="productPrice"></param>
        public void setProductprice(IEnumerable<XMOrderInfoProductDetails> ProductList, decimal SalePrice, Dictionary<string, decimal> productPrice)
        {
            var newProductList = ProductList.ToList();

            if (newProductList.Count() > 1)
            {
                decimal payPriceI = 0;//组合已赋值付款金额
                var childproduct = newProductList.Select(m => new
                {
                    m.PlatformMerchantCode,
                    m.ProductNum,
                    m.SalesPrice,//该商品的销售价（单价乘数量）
                });
                if (!childproduct.Any(m => m.SalesPrice.GetValueOrDefault(0) == 0))//说明有商品的销售价为0
                {
                    var dic = childproduct.Select(m => new
                    {
                        m.PlatformMerchantCode,
                        m.ProductNum,
                        m.SalesPrice//获取所有组合的子商品的对应总价
                    });
                    var sumFactoryPrice = dic.Sum(m => m.SalesPrice).Value;
                    int i = 0, c = dic.Count();
                    foreach (var elem in dic)
                    {
                        i++;
                        if (i < c)
                        {
                            var chaifenprice = Math.Round(((decimal)elem.SalesPrice / sumFactoryPrice) * SalePrice / elem.ProductNum.GetValueOrDefault(1), 2);//单个商品的销售总价除以组合商品的销售总价乘以该次销售的总价，得到该商品的本次销售价
                            payPriceI += chaifenprice * elem.ProductNum.GetValueOrDefault(1);
                            productPrice.Add(elem.PlatformMerchantCode, chaifenprice);
                        }
                        else
                        {
                            var price = Math.Round((SalePrice - payPriceI) / elem.ProductNum.GetValueOrDefault(1), 2);//得到最后一个物品的单价
                            productPrice.Add(elem.PlatformMerchantCode, price);
                        }
                    }
                }
            }
            else if (newProductList.Count() == 1)
            {
                var entity = newProductList[0];
                productPrice.Add(entity.PlatformMerchantCode, (decimal)(SalePrice / entity.ProductNum.GetValueOrDefault(1)));
            }
        }
        /// <summary>
        /// 天猫
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="filePath2"></param>
        /// <param name="weekDate"></param>
        /// <param name="PlatformTypeNameId"></param>
        /// <param name="NickId"></param>
        /// <param name="PlatformTypeName"></param>
        /// <param name="FileName"></param>
        /// <param name="FileName2"></param>
        /// <param name="paramMessage"></param>
        public void ImportOrderFromXlsTM(string filePath1, string filePath2, DateTime weekDate, int PlatformTypeNameId, int NickId, string PlatformTypeName, string FileName1, string FileName2, ref string paramMessage, string sourceType)
        {
            if (filePath1 != "" && filePath2 != "")
            {
                int count = 0;

                int resultCount = 0;
                for (int i = 1; i < 3; i++)
                {
                    //导入的文件地址
                    string filePath = "";
                    if (i == 1)
                    {
                        filePath = filePath1;
                    }
                    else if (i == 2)
                    {
                        filePath = filePath2;
                    }
                    string FileName = "天猫" + i;

                    using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                    {
                        excelHelper.Hdr = "YES";
                        excelHelper.Imex = "1";

                        DataTable dt = null;

                        #region 天猫
                        if (PlatformTypeName == "天猫" || PlatformTypeName == "集市店")
                        {
                            #region 天猫1
                            if (FileName == "天猫1")
                            {
                                dt = excelHelper.ReadTable("天猫1");
                                dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                                dt.DefaultView.RowFilter = "商家编码 is not null and (Convert(商家编码, 'System.String')<>'' or Convert(商家编码, 'System.Int32')>0)";
                                dt = dt.DefaultView.ToTable();

                                foreach (DataRow row1 in dt.Rows)
                                {
                                    //根据订单编号查询
                                    var xMOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单编号"].ToString().Trim());
                                    //商家编码
                                    string Merchantcode = row1["商家编码"].ToString().Trim();
                                    //商家编码查询。
                                    var ProductList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMProductListByPlatFormMerchantCode(Merchantcode, 0);

                                    if (xMOrderInfo == null)
                                    {
                                        #region 订单新增
                                        xMOrderInfo = new XMOrderInfo();
                                        xMOrderInfo.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
                                        xMOrderInfo.OrderCode = row1["订单编号"].ToString().Trim(); // 
                                        int ProductNumV = (row1["购买数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["购买数量"].ToString().Trim()));

                                        xMOrderInfo.PlatformTypeId = PlatformTypeNameId;
                                        xMOrderInfo.NickID = NickId;
                                        string OrderStatus = row1["订单状态"].ToString().Trim();
                                        if (OrderStatus == "买家已付款，等待卖家发货")
                                        {
                                            xMOrderInfo.OrderStatus = "WAIT_SELLER_SEND_GOODS";
                                        }
                                        if (OrderStatus == "交易成功")
                                        {
                                            xMOrderInfo.OrderStatus = "TRADE_FINISHED";
                                        }
                                        xMOrderInfo.WantID = "";
                                        xMOrderInfo.FullName = "";
                                        xMOrderInfo.IsOurOrder = true;
                                        xMOrderInfo.IsEnable = false;//是否删除
                                        xMOrderInfo.IsCashBack = false;//是否返现
                                        xMOrderInfo.IsSentGifts = false;//是否已发赠品 
                                        xMOrderInfo.IsEvaluate = false;//是否赔付
                                        xMOrderInfo.SourceType = sourceType;//"导入";
                                        if (sourceType == "导入")
                                        {
                                            xMOrderInfo.FinancialAudit = true;
                                        }
                                        else
                                        {
                                            xMOrderInfo.FinancialAudit = false;
                                        }

                                        xMOrderInfo.IsScalping = false;

                                        xMOrderInfo.CreateDate = DateTime.Now;
                                        xMOrderInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xMOrderInfo.UpdateDate = DateTime.Now;
                                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                        #region 订单明细新增
                                        XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();
                                        //xmorderinfopd.PlatformMerchantCode = row1["商家编码"].ToString().Trim();//料号(商品编码)
                                        xmorderinfopd.ProductNum = ProductNumV;
                                        if (ProductList.Count > 0)
                                        {
                                            xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                            xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                            xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                            xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                            xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                        }
                                        else
                                        {
                                            xmorderinfopd.PlatformMerchantCode = Merchantcode;
                                            xmorderinfopd.Specifications = "";//尺寸
                                            xmorderinfopd.FactoryPrice = 0;//出厂价
                                            xmorderinfopd.ProductName = "无产品";
                                            xmorderinfopd.TManufacturersCode = "";
                                        }
                                        xmorderinfopd.ISArrivedLibrary = false;
                                        xmorderinfopd.IsAudit = false;//是否审核
                                        xmorderinfopd.IsExpedited = false;//是否加急
                                        xmorderinfopd.IsEnable = false;
                                        xmorderinfopd.CreateDate = DateTime.Now;
                                        xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xmorderinfopd.UpdateDate = DateTime.Now;
                                        xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xMOrderInfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);

                                        #endregion

                                        IoC.Resolve<IXMOrderInfoService>().InsertXMOrderInfo(xMOrderInfo);

                                        #endregion

                                        resultCount++;
                                    }
                                    else if (xMOrderInfo != null)
                                    {
                                        //新修改查询已审核的订单详细数据
                                        var OrderInfo2 = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderId(xMOrderInfo.ID);
                                        if (OrderInfo2 != null && OrderInfo2.Count > 0)
                                        {
                                            OrderInfo2 = OrderInfo2.Where(p => p.IsAudit == true).ToList();
                                        }

                                        if (OrderInfo2 == null)
                                        {
                                            #region 订单修改
                                            int ProductNumV = (row1["购买数量"].ToString().Trim() == "" ? 1 : int.Parse(row1["购买数量"].ToString().Trim()));
                                            xMOrderInfo.OrderCode = row1["订单编号"].ToString().Trim(); //
                                            string OrderStatus = row1["订单状态"].ToString().Trim();
                                            if (OrderStatus == "买家已付款，等待卖家发货")
                                            {
                                                xMOrderInfo.OrderStatus = "WAIT_SELLER_SEND_GOODS";
                                            }
                                            if (OrderStatus == "交易成功")
                                            {
                                                xMOrderInfo.OrderStatus = "TRADE_FINISHED";
                                            }

                                            xMOrderInfo.SourceType = sourceType;//"导入";
                                            if (sourceType == "导入")
                                            {
                                                xMOrderInfo.FinancialAudit = true;
                                            }
                                            else
                                            {
                                                xMOrderInfo.FinancialAudit = false;
                                            }
                                            xMOrderInfo.UpdateDate = DateTime.Now;
                                            xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                            //订单明细
                                            var xmorderinfopdList = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByPlatformMerchantCode(xMOrderInfo.ID, Merchantcode);
                                            #region 订单明细
                                            if (xmorderinfopdList.Count == 0)
                                            {
                                                #region 新增
                                                //订单明细信息
                                                XMOrderInfoProductDetails xmorderinfopd = new XMOrderInfoProductDetails();

                                                xmorderinfopd.ProductNum = ProductNumV;
                                                if (ProductList.Count > 0)
                                                {
                                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                                }
                                                else
                                                {
                                                    xmorderinfopd.PlatformMerchantCode = Merchantcode; //料号（商品编码）
                                                    xmorderinfopd.Specifications = "";//尺寸
                                                    xmorderinfopd.FactoryPrice = 0; ;//出厂价
                                                    xmorderinfopd.ProductName = "无产品";
                                                    xmorderinfopd.TManufacturersCode = "";
                                                }

                                                xmorderinfopd.ISArrivedLibrary = false;
                                                xmorderinfopd.IsAudit = false;//是否审核
                                                xmorderinfopd.IsExpedited = false;//是否加急
                                                xmorderinfopd.IsEnable = false;
                                                xmorderinfopd.CreateDate = DateTime.Now;
                                                xmorderinfopd.CreateID = HozestERPContext.Current.User.CustomerID;
                                                xmorderinfopd.UpdateDate = DateTime.Now;
                                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                xMOrderInfo.XM_OrderInfoProductDetails.Add(xmorderinfopd);
                                                #endregion
                                            }
                                            else
                                            {
                                                #region  修改
                                                //订单明细修改 
                                                XMOrderInfoProductDetails xmorderinfopd = xmorderinfopdList[0];
                                                xmorderinfopd.ProductNum = ProductNumV;
                                                if (ProductList.Count > 0)
                                                {
                                                    xmorderinfopd.PlatformMerchantCode = ProductList[0].PlatformMerchantCode; //料号（商品编码）
                                                    xmorderinfopd.Specifications = ProductList[0].Specifications;//尺寸
                                                    xmorderinfopd.FactoryPrice = ProductList[0].Costprice * ProductNumV;//出厂价
                                                    xmorderinfopd.ProductName = ProductList[0].ProductName;//产品名称
                                                    xmorderinfopd.TManufacturersCode = ProductList[0].ManufacturersCode;
                                                }
                                                else
                                                {
                                                    xmorderinfopd.PlatformMerchantCode = Merchantcode; //料号（商品编码）
                                                    xmorderinfopd.Specifications = "";//尺寸
                                                    xmorderinfopd.FactoryPrice = 0; ;//出厂价
                                                    xmorderinfopd.ProductName = "无产品";
                                                    xmorderinfopd.TManufacturersCode = "";
                                                }
                                                //decimal SalesPriceV = Convert.ToDecimal(row1["单价"].ToString().Trim());//销售价 
                                                // xmorderinfopd.SalesPrice = xmorderinfopd.SalesPrice == null ? 0 : xmorderinfopd.SalesPrice.Value * ProductNumV;//销售价  
                                                xmorderinfopd.UpdateDate = DateTime.Now;
                                                xmorderinfopd.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                IoC.Resolve<IXMOrderInfoProductDetailsService>().UpdateXMOrderInfoProductDetails(xmorderinfopd);
                                                #endregion
                                            }
                                            #endregion

                                            #endregion

                                            IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfo);
                                            resultCount++;
                                        }
                                    }
                                }

                                count = dt.Rows.Count;
                            }
                            #endregion
                            else if (FileName == "天猫2")
                            {
                                #region 天猫2
                                dt = excelHelper.ReadTable("天猫2");
                                dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                                dt = dt.DefaultView.ToTable();

                                foreach (DataRow row1 in dt.Rows)
                                {
                                    var xMOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单编号"].ToString());
                                    //新修改查询已审核的订单详细数据
                                    var OrderInfo2 = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderId(xMOrderInfo.ID).Where(p => p.IsAudit == true).ToList();
                                    //新增
                                    if (xMOrderInfo != null && OrderInfo2.Count == 0)
                                    {
                                        xMOrderInfo.OrderCode = row1["订单编号"].ToString().Trim();
                                        xMOrderInfo.WantID = row1["买家会员名"].ToString().Trim();
                                        decimal SalesPriceV = Convert.ToDecimal(row1["买家实际支付金额"].ToString().Trim());//客单价 
                                        decimal ReceivablePriceV = Convert.ToDecimal(row1["买家应付货款"].ToString().Trim());//买家应付货款 
                                        decimal OrderPriceV = Convert.ToDecimal(row1["总金额"].ToString().Trim());//买家应付货款 
                                        //xMOrderInfo.SalesPrice = xMOrderInfo.ProductNum == null ? 1 : xMOrderInfo.ProductNum.Value * SalesPriceV;
                                        xMOrderInfo.FullName = row1["收货人姓名"].ToString().Trim();
                                        xMOrderInfo.DeliveryAddress = row1["收货地址 "].ToString().Trim();
                                        xMOrderInfo.Tel = row1["联系电话 "].ToString().Trim();
                                        xMOrderInfo.OrderPrice = OrderPriceV;
                                        xMOrderInfo.ReceivablePrice = ReceivablePriceV;
                                        xMOrderInfo.PayPrice = SalesPriceV;
                                        string Mobile = row1["联系手机"].ToString().Trim();
                                        if (Mobile.IndexOf("'") == -1)
                                        {
                                            xMOrderInfo.Mobile = row1["联系手机"].ToString().Trim();
                                        }
                                        else
                                        {
                                            string suMobile = Mobile.Substring(Mobile.LastIndexOf("'") + 1).ToLower();
                                            xMOrderInfo.Mobile = suMobile;
                                        }

                                        #region 备注
                                        string Remarks = row1["订单备注"].ToString().Trim();

                                        if (Remarks.IndexOf("'") == -1)//没有’
                                        {
                                            xMOrderInfo.CustomerServiceRemark = Remarks;
                                        }
                                        else
                                        {
                                            string suRemarks = Remarks.Substring(Remarks.LastIndexOf("'") + 1).ToLower();// 取'号 

                                            xMOrderInfo.CustomerServiceRemark = suRemarks;
                                        }
                                        #endregion

                                        #region 返现、赠品
                                        if (Remarks != null && Remarks != "")
                                        {
                                            //string CashBackMoney = "";//返现金额
                                            string BuyerName = row1["收货人姓名"].ToString().Trim();//姓名
                                            string BuyerAlipayNoS = row1["买家支付宝账号"].ToString().Trim();//收款账号
                                            string WantNo = row1["买家会员名"].ToString().Trim();//旺旺号
                                            string OrderCode = row1["订单编号"].ToString().Trim();//订单号  

                                            #region 赠品、返现

                                            //#region 返现
                                            //if (Remarks.IndexOf("返现") > -1)
                                            //{
                                            //    //根据订单号查询 返现信息中是否已经存在 现有订单 
                                            //    var XMCashBackApplicationList = IoC.Resolve<IXMCashBackApplicationService>().GetXMCashBackApplicationByOrderCode(OrderCode);

                                            //    if (XMCashBackApplicationList.Count == 0)
                                            //    {
                                            //        string e = Remarks.Substring(Remarks.IndexOf("返现") + 2);
                                            //        int f = e.IndexOf("元/");

                                            //        if (f > -1)
                                            //        {
                                            //            CashBackMoney = e.Substring(0, f);//OrderRemark.Substring(OrderRemark.IndexOf("返现") + 2, OrderRemark.IndexOf("元/") - 2); 
                                            //        }
                                            //        decimal d = 0;

                                            //        if (decimal.TryParse(CashBackMoney, out d))//类型转换
                                            //        {
                                            //            if (CashBackMoney != "" && BuyerName != "" && BuyerAlipayNoS != "")
                                            //            {
                                            //                IoC.Resolve<IXMCashBackApplicationService>().InsertXMCashBackApplication(OrderCode, WantNo, BuyerName, Convert.ToDecimal(CashBackMoney), BuyerAlipayNoS);
                                            //            }
                                            //        }
                                            //    }
                                            //}

                                            //#endregion

                                            //#region 赠品
                                            ////string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转郝晋平，18302105960/等通知//赠品：枕头/返现50//金佩微/已提单，刘娟秀/2.26在线联系可以发";
                                            ////string str = "万家物流/2月25日当天发/小城/日日顺送货上门//万家扬州自提，无服务商转陈万琴，4008557777//赠品：床笠（1.8）//牟宣岳/已提单，刘娟秀";
                                            ////string str = "万家物流/能发就发/小城/日日顺送货上门/上海整车/万家送货至闵行区昆阳路59号，蔡进周转汪丽昊  ，18302105960//赠品：枕头*2//傅秀珍/已提单，刘娟秀";
                                            ////string str = "万家物流/能发就发/小城/日日顺送货上门//万家送货至苏州市吴中区碧波街吴忠商城16栋B03，陈小琴转吴先生，15162452196//赠品：床笠（1.5）*2+枕头//牟宣岳/已提单，徐文辉";
                                            //string PremiumsActivityExplanation = "";//活动说明
                                            //string PremiumsPrdouctName = "";//商品名称
                                            //string PremiumsPlatformMerchantCode = "";//商品编码
                                            //string PremiumsFactoryPrice = "0";//出厂价
                                            //string PremiumsProductNum = "0";//数量
                                            //string Specifications = "";//尺寸    
                                            //int ProductDetaislId = -1;


                                            //if (Remarks.IndexOf("赠品") > -1)
                                            //{
                                            //    //判断赠品申请表中是否已经存在 相同订单号
                                            //    var premiumsList = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode);

                                            //    if (premiumsList.Count == 0)
                                            //    {
                                            //        string s = Remarks.Substring(Remarks.IndexOf("赠品") + 3);
                                            //        int f = s.IndexOf("/");
                                            //        if (f > -1)
                                            //        {
                                            //            PremiumsActivityExplanation = s.Substring(0, f);

                                            //            #region 去除赠品、：、3个字符 （长度等于2）
                                            //            if (f == 2)
                                            //            {
                                            //                PremiumsPrdouctName = s.Substring(0, f);

                                            //                PremiumsProductNum = "1";

                                            //                if (PremiumsPrdouctName != "")
                                            //                {
                                            //                    var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                            //                    if (xmProductList.Count > 0)
                                            //                    {
                                            //                        PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                            //                        PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                            //                        ProductDetaislId = xmProductList[0].Id;
                                            //                    }
                                            //                }

                                            //                decimal d = 0;
                                            //                int INum = 0;
                                            //                if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                            //                {
                                            //                    //主表信息
                                            //                    int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, PremiumsActivityExplanation);
                                            //                    //明细信息
                                            //                    IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                            //                }
                                            //                PremiumsActivityExplanation = "";//活动说明
                                            //                PremiumsPrdouctName = "";//商品名称
                                            //                PremiumsPlatformMerchantCode = "";//商品编码
                                            //                PremiumsFactoryPrice = "0";//出厂价
                                            //                PremiumsProductNum = "0";//数量
                                            //                Specifications = "";//尺寸    
                                            //                ProductDetaislId = -1;

                                            //            }
                                            //            #endregion
                                            //            #region 字符大于2个字符
                                            //            else if (f > 2)
                                            //            {
                                            //                string[] J = PremiumsActivityExplanation.Split('+');

                                            //                string strNum = "";//数量字符

                                            //                #region 多个赠品
                                            //                if (PremiumsActivityExplanation != "" && J.Length > 1)
                                            //                {
                                            //                    for (int Ji = 0; Ji < J.Length; Ji++)
                                            //                    {
                                            //                        string pe = J[Ji];
                                            //                        string remsub = "";//尺寸+商品名称字符

                                            //                        if (pe != "")
                                            //                        {
                                            //                            #region 尺寸、商品名称
                                            //                            if (pe.IndexOf("（") > -1 && pe.IndexOf("）") > -1)
                                            //                            {
                                            //                                string a1 = pe.Substring(pe.IndexOf("（") + 1);
                                            //                                int b = a1.IndexOf("）");
                                            //                                int c = pe.IndexOf("（");

                                            //                                if (c > -1)
                                            //                                {
                                            //                                    PremiumsPrdouctName = pe.Substring(0, c);
                                            //                                    remsub += PremiumsPrdouctName;
                                            //                                }

                                            //                                if (b > -1)
                                            //                                {
                                            //                                    Specifications = a1.Substring(0, b);
                                            //                                    remsub += "（" + Specifications + "）";
                                            //                                }

                                            //                            }
                                            //                            if (pe.IndexOf("(") > -1 && pe.IndexOf(")") > -1)
                                            //                            {

                                            //                                string a1 = pe.Substring(pe.IndexOf("(") + 1);
                                            //                                int b = a1.IndexOf(")");
                                            //                                int c = pe.IndexOf("(");
                                            //                                if (c > -1)
                                            //                                {
                                            //                                    PremiumsPrdouctName = pe.Substring(0, c);
                                            //                                    remsub += PremiumsPrdouctName;
                                            //                                }
                                            //                                if (b > -1)
                                            //                                {
                                            //                                    Specifications = a1.Substring(0, b);

                                            //                                    remsub += "(" + Specifications + ")";
                                            //                                }

                                            //                            }
                                            //                            #endregion
                                            //                            #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                            //                            int Intd = pe.IndexOf(remsub);
                                            //                            if (Intd > -1)
                                            //                            {
                                            //                                strNum = pe.Substring(remsub.Length).ToLower();
                                            //                            }
                                            //                            if (strNum != "")
                                            //                            {
                                            //                                //数量
                                            //                                if (strNum.IndexOf("*") > -1)
                                            //                                {
                                            //                                    string a1 = strNum.Substring(strNum.IndexOf("*") + 1);
                                            //                                    PremiumsProductNum = a1;
                                            //                                }
                                            //                                else
                                            //                                {
                                            //                                    PremiumsProductNum = "1";
                                            //                                }
                                            //                            }
                                            //                            else
                                            //                            {

                                            //                                PremiumsProductNum = "1";
                                            //                            }

                                            //                            #endregion

                                            //                            if (PremiumsPrdouctName == "")
                                            //                            {

                                            //                                PremiumsPrdouctName = pe;
                                            //                            }
                                            //                            if (PremiumsPrdouctName != "")
                                            //                            {
                                            //                                var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                            //                                if (PremiumsPrdouctName != "" && Specifications != "")
                                            //                                {
                                            //                                    xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                            //                                }
                                            //                                if (xmProductList.Count > 0)
                                            //                                {
                                            //                                    ProductDetaislId = xmProductList[0].Id;
                                            //                                    PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                            //                                    PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                            //                                }

                                            //                            }


                                            //                            decimal d = 0;
                                            //                            int INum = 0;
                                            //                            if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                            //                            {
                                            //                                //主表信息
                                            //                                int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, PremiumsActivityExplanation);
                                            //                                //明细信息
                                            //                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                            //                            }
                                            //                            //PremiumsActivityExplanation = "";//活动说明
                                            //                            PremiumsPrdouctName = "";//商品名称
                                            //                            PremiumsPlatformMerchantCode = "";//商品编码
                                            //                            PremiumsFactoryPrice = "0";//出厂价
                                            //                            PremiumsProductNum = "0";//数量
                                            //                            Specifications = "";//尺寸    
                                            //                            ProductDetaislId = -1;
                                            //                        }
                                            //                    }

                                            //                }
                                            //                #endregion
                                            //                #region 单个赠品
                                            //                else
                                            //                {

                                            //                    string strNum1 = "";//数量字符
                                            //                    string remsub = "";//尺寸+商品名称字符
                                            //                    string PEl = PremiumsActivityExplanation;
                                            //                    #region 尺寸、商品名称
                                            //                    if (PEl.IndexOf("（") > -1 && PEl.IndexOf("）") > -1)
                                            //                    {
                                            //                        string a = PEl.Substring(PEl.IndexOf("（") + 1);
                                            //                        int b = a.IndexOf("）");
                                            //                        int c = PEl.IndexOf("（");
                                            //                        if (c > -1)
                                            //                        {
                                            //                            PremiumsPrdouctName = PEl.Substring(0, c);
                                            //                            remsub += PremiumsPrdouctName;
                                            //                        }
                                            //                        if (b > -1)
                                            //                        {
                                            //                            Specifications = a.Substring(0, b);
                                            //                            remsub += "（" + Specifications + "）";
                                            //                        }

                                            //                    }
                                            //                    if (PEl.IndexOf("(") > -1 && PEl.IndexOf(")") > -1)
                                            //                    {

                                            //                        string a = PEl.Substring(PEl.IndexOf("(") + 1);
                                            //                        int b = a.IndexOf(")");
                                            //                        int c = PEl.IndexOf("(");
                                            //                        if (c > -1)
                                            //                        {
                                            //                            PremiumsPrdouctName = PEl.Substring(0, c);
                                            //                            remsub += PremiumsPrdouctName;
                                            //                        }
                                            //                        if (b > -1)
                                            //                        {
                                            //                            Specifications = a.Substring(0, b);

                                            //                            remsub += "(" + Specifications + ")";
                                            //                        }
                                            //                    }
                                            //                    #endregion

                                            //                    #region 去除产品名称 + 尺寸 在余下的字符中取数量

                                            //                    int Intd = PEl.IndexOf(remsub);
                                            //                    if (Intd > -1)
                                            //                    {
                                            //                        strNum1 = PEl.Substring(remsub.Length).ToLower();
                                            //                    }
                                            //                    if (strNum1 != "")
                                            //                    {
                                            //                        //数量
                                            //                        if (strNum1.IndexOf("*") > -1)
                                            //                        {
                                            //                            string a = strNum1.Substring(strNum1.IndexOf("*") + 1);
                                            //                            PremiumsProductNum = a;

                                            //                            if (PremiumsPrdouctName == "")
                                            //                            {
                                            //                                PremiumsPrdouctName = PEl.Substring(0, PEl.IndexOf("*"));
                                            //                            }
                                            //                        }
                                            //                        else
                                            //                        {
                                            //                            PremiumsProductNum = "1";
                                            //                        }
                                            //                    }
                                            //                    else
                                            //                    {
                                            //                        PremiumsProductNum = "1";
                                            //                    }

                                            //                    #endregion
                                            //                    if (PremiumsPrdouctName != "")
                                            //                    {
                                            //                        var xmProductList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByProductName(PremiumsPrdouctName);
                                            //                        if (PremiumsPrdouctName != "" && Specifications != "")
                                            //                        {
                                            //                            xmProductList = xmProductList.Where(p => p.Specifications.Contains(Specifications)).ToList();
                                            //                        }
                                            //                        if (xmProductList.Count > 0)
                                            //                        {
                                            //                            ProductDetaislId = xmProductList[0].Id;
                                            //                            PremiumsPlatformMerchantCode = xmProductList[0].ManufacturersCode;
                                            //                            PremiumsFactoryPrice = xmProductList[0].Costprice != null ? xmProductList[0].Costprice.Value.ToString() : "0";
                                            //                        }

                                            //                    }

                                            //                    decimal d = 0;
                                            //                    int INum = 0;
                                            //                    if (decimal.TryParse(PremiumsFactoryPrice, out d) && int.TryParse(PremiumsProductNum, out INum))//类型转换
                                            //                    {
                                            //                        //主表信息
                                            //                        int Id = IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(OrderCode, WantNo, PremiumsActivityExplanation);
                                            //                        //明细信息
                                            //                        IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(Id, ProductDetaislId, PremiumsPlatformMerchantCode, PremiumsPrdouctName, d, INum);
                                            //                    }
                                            //                    PremiumsActivityExplanation = "";//活动说明
                                            //                    PremiumsPrdouctName = "";//商品名称
                                            //                    PremiumsPlatformMerchantCode = "";//商品编码
                                            //                    PremiumsFactoryPrice = "0";//出厂价
                                            //                    PremiumsProductNum = "0";//数量
                                            //                    Specifications = "";//尺寸    
                                            //                    ProductDetaislId = -1;
                                            //                }
                                            //                #endregion
                                            //            }
                                            //            #endregion
                                            //        }
                                            //    }
                                            //}
                                            //#endregion

                                            #endregion
                                        }
                                        #endregion

                                        DateTime OrderInfoCreateDate = (row1["订单创建时间"].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["订单创建时间"].ToString().Trim()));
                                        xMOrderInfo.OrderInfoCreateDate = OrderInfoCreateDate;

                                        DateTime payDate = (row1["订单付款时间 "].ToString().Trim() == "" ? DateTime.Now : DateTime.Parse(row1["订单付款时间 "].ToString().Trim()));
                                        xMOrderInfo.PayDate = payDate;

                                        if (payDate != null)
                                        {
                                            xMOrderInfo.DeliveryTime = DateTime.Parse(payDate.ToString().Trim()).AddDays(+20);//截止发货日 
                                        }

                                        //xMOrderInfo.SourceType = "导入";
                                        //xMOrderInfo.IsScalping = false;
                                        xMOrderInfo.SourceType = sourceType;//"导入";
                                        if (sourceType == "导入")
                                        {
                                            xMOrderInfo.FinancialAudit = true;
                                        }
                                        else
                                        {
                                            xMOrderInfo.FinancialAudit = false;
                                        }
                                        xMOrderInfo.UpdateDate = DateTime.Now;
                                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;

                                        IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfo);
                                        resultCount++;
                                    }
                                }
                                count += dt.Rows.Count;
                                #endregion
                            }
                            else
                            {
                                paramMessage = PlatformTypeName + "平台文件名称有误！";
                            }

                        }

                        #endregion
                    }
                }

                if (count > 0)
                {

                    if (resultCount == count)
                    {
                        paramMessage = "导入成功";
                    }
                    else
                    {
                        paramMessage += "应该导入" + count + "条，实际导入" + resultCount + "条";
                    }
                }
            }
        }

        /// <summary>
        /// 导入物流费用
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportLogisticsCostData(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                foreach (DataRow row1 in dt.Rows)
                {
                    string OrderCode = row1["销售订单号"].ToString().Trim();
                    string LogisticsNumber = row1["物流单号"].ToString().Trim();
                    string LogisticsCost = row1["物流费总"].ToString().Trim();
                    decimal cost = !string.IsNullOrEmpty(LogisticsCost) ? decimal.Parse(LogisticsCost) : 0;
                    if (!string.IsNullOrEmpty(LogisticsNumber))
                    {
                        //根据物流单号查询记录
                        var Info = IoC.Resolve<XMDeliveryService>().GetXMDeliveryListByLogisticsNumber(LogisticsNumber);
                        if (Info != null && Info.Count > 0)
                        {
                            //遍历循环所有记录
                            foreach (var parm in Info)
                            {
                                parm.Price = cost;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateId = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<XMDeliveryService>().UpdateXMDelivery(parm);
                            }
                            resultCount++;
                        }
                    }
                }

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }

        public void ImportReturnedLogisticsFee(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                foreach (DataRow row1 in dt.Rows)
                {
                    string applicationNo = row1["申请单号"].ToString().Trim();
                    string LogisticsFee = row1["物流费用"].ToString().Trim();
                    decimal fee = string.IsNullOrEmpty(LogisticsFee) ? 0 : decimal.Parse(LogisticsFee);

                    if (!string.IsNullOrEmpty(applicationNo))
                    {
                        var Info = IoC.Resolve<IXMApplicationService>().GetXMApplicationListByApplicationNo(applicationNo);
                        if (Info != null && Info.Count > 0)
                        {
                            foreach (var parm in Info)
                            {
                                parm.LogisticsCost = fee;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMApplicationService>().UpdateXMApplication(parm);
                            }
                            resultCount++;
                        }
                    }
                }

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }

        public void ImportPurchaseLogisticsFee(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                foreach (DataRow row1 in dt.Rows)
                {
                    string purchaseNo = row1["采购单号"].ToString().Trim();
                    string LogisticsFee = row1["物流费用"].ToString().Trim();
                    decimal fee = string.IsNullOrEmpty(LogisticsFee) ? 0 : decimal.Parse(LogisticsFee);

                    if (!string.IsNullOrEmpty(purchaseNo))
                    {
                        var list = IoC.Resolve<IXMPurchaseService>().GetXMPurchaseBypurChaseCode(purchaseNo);
                        if (list != null && list.Count > 0)
                        {
                            foreach (var parm in list)
                            {
                                parm.LogisticsFee = fee;
                                parm.UpdateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMPurchaseService>().UpdateXMPurchase(parm);
                            }
                            resultCount++;
                        }
                    }
                }
                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }

        public void ImportLogisticsCost(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                DateTime now = DateTime.Now;
                foreach (DataRow row1 in dt.Rows)
                {
                    string purchaseNo = row1["物流单号"].ToString().Trim();
                    string LogisticsFee = row1["费用"].ToString().Trim();
                    decimal fee = string.IsNullOrEmpty(LogisticsFee) ? 0 : decimal.Parse(LogisticsFee);

                    if (!string.IsNullOrEmpty(purchaseNo))
                    {
                        var xmLogisticsCost = IoC.Resolve<IXMLogisticsCostService>().GetXMLogisticsCostByLogisticsNumber(purchaseNo);

                        if (xmLogisticsCost == null)
                        {
                            var DeliveryList = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryByLogisticsNumber(purchaseNo);
                            if (DeliveryList != null)
                            {
                                XMLogisticsCost entity = new XMLogisticsCost();
                                entity.LogisticsNumber = DeliveryList.LogisticsNumber;
                                entity.ModuleName = "1"; //1 发货单 2 采购订单 3退换货管理 4 京东自营退货单
                                entity.ModuleID = DeliveryList.Id;
                                entity.Fee = fee;
                                entity.ReconciliationTime = now;
                                entity.CreateID = HozestERPContext.Current.User.CustomerID;
                                entity.CreateDate = now;
                                entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                                entity.UpdateDate = now;
                                IoC.Resolve<IXMLogisticsCostService>().InsertXMLogisticsCost(entity);

                            }
                            else
                            {
                                var purchaseList = IoC.Resolve<IXMPurchaseService>().GetXMPurchaseBypurChaseCode(purchaseNo);
                                if (purchaseList != null && purchaseList.Count > 0)
                                {
                                    XMLogisticsCost entity = new XMLogisticsCost();
                                    entity.LogisticsNumber = purchaseList[0].PurchaseNumber;
                                    entity.ModuleName = "2"; //1 发货单 2 采购订单 3退换货管理 4 京东自营退货单
                                    entity.ModuleID = purchaseList[0].Id;
                                    entity.Fee = fee;
                                    entity.ReconciliationTime = now;
                                    entity.CreateID = HozestERPContext.Current.User.CustomerID;
                                    entity.CreateDate = now;
                                    entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    entity.UpdateDate = now;
                                    IoC.Resolve<IXMLogisticsCostService>().InsertXMLogisticsCost(entity);
                                }
                                else
                                {
                                    var applicationList = IoC.Resolve<IXMApplicationService>().GetXMApplicationListByApplicationNo(purchaseNo);
                                    if (applicationList != null && applicationList.Count > 0)
                                    {
                                        XMLogisticsCost entity = new XMLogisticsCost();
                                        entity.LogisticsNumber = applicationList[0].ApplicationNo;
                                        entity.ModuleName = "3"; //1 发货单 2 采购订单 3退换货管理 4 京东自营退货单
                                        entity.ModuleID = applicationList[0].ID;
                                        entity.Fee = fee;
                                        entity.ReconciliationTime = now;
                                        entity.CreateID = HozestERPContext.Current.User.CustomerID;
                                        entity.CreateDate = now;
                                        entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        entity.UpdateDate = now;
                                        IoC.Resolve<IXMLogisticsCostService>().InsertXMLogisticsCost(entity);
                                    }
                                    else
                                    {
                                        var xmJDSaleRejected = IoC.Resolve<IXMJDSaleRejectedService>().GetXMJDSaleRejectedByRef(purchaseNo);
                                        if (xmJDSaleRejected != null)
                                        {
                                            XMLogisticsCost entity = new XMLogisticsCost();
                                            entity.LogisticsNumber = xmJDSaleRejected.Ref;
                                            entity.ModuleName = "4"; //1 发货单 2 采购订单 3退换货管理 4 京东自营退货单
                                            entity.ModuleID = xmJDSaleRejected.Id;
                                            entity.Fee = fee;
                                            entity.ReconciliationTime = now;
                                            entity.CreateID = HozestERPContext.Current.User.CustomerID;
                                            entity.CreateDate = now;
                                            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            entity.UpdateDate = now;
                                            IoC.Resolve<IXMLogisticsCostService>().InsertXMLogisticsCost(entity);
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            paramMessage = paramMessage + "单号：" + purchaseNo + "已存在;";
                            //xmLogisticsCost.Fee = fee;
                            //xmLogisticsCost.UpdateDate = now;
                            //xmLogisticsCost.UpdateID = HozestERPContext.Current.User.CustomerID;
                            //IoC.Resolve<IXMLogisticsCostService>().UpdateXMLogisticsCost(xmLogisticsCost);
                        }


                        resultCount++;
                    }
                }

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }

        public void ImportJdSaleLogisticsFee(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                string error = string.Empty;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                foreach (DataRow row1 in dt.Rows)
                {
                    string refNo = row1["退货单号"].ToString().Trim();
                    string refType= row1["退货类型"].ToString().Trim();
                    string LogisticsFee = row1["运费"].ToString().Trim();
                    decimal fee = string.IsNullOrEmpty(LogisticsFee) ? 0 : decimal.Parse(LogisticsFee);

                    if(fee<=0)
                    {
                        error = error + "退回单号：" + refNo + " 导入运费异常；";
                        continue;
                    }

                    var codeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeIDAndCodeName(230, refType);

                    int ReturnCategoryID = codeList.Count > 0 ? codeList[0].CodeID : -1;

                    if (!string.IsNullOrEmpty(refNo))
                    {
                        var entity = IoC.Resolve<IXMJDSaleRejectedService>().GetXMJDSaleRejectedByRefAndReturnCategoryID(refNo, ReturnCategoryID);
                        if(entity!=null)
                        {
                            entity.LogisticsFee = fee;
                            entity.UpdateDate = DateTime.Now;
                            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                            IoC.Resolve<IXMJDSaleRejectedService>().UpdateXMJDSaleRejected(entity);
                            resultCount++;
                        }
                        
                    }
                }
                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！"+error;
                    }
                }
            }
        }

        /// <summary>
        /// 导入快递账单
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="expressID"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void ImportExpressList(string filePath, ref string paramMessage, int expressID, int year, int month)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                foreach (DataRow row1 in dt.Rows)
                {
                    string number = row1["单号"].ToString().Trim();
                    string weight = row1["重量"].ToString().Trim();
                    string sf = row1["省份"].ToString().Trim();      //省份
                    string cost = row1["单件计"].ToString().Trim();        //费用
                    if (!string.IsNullOrEmpty(number))
                    {
                        //根据物流单号查询数据
                        var list = IoC.Resolve<IXMExpressListManagementService>().GetXMExpressListManagementByParm(expressID, number, year, month);
                        if (list != null)
                        {
                            //查询后数据存在  更新数据
                            list.Weight = !string.IsNullOrEmpty(weight) ? decimal.Parse(weight) : 0;
                            list.Cost = !string.IsNullOrEmpty(cost) ? decimal.Parse(cost) : 0;
                            list.UpdateDate = DateTime.Now;
                            list.UpdateID = HozestERPContext.Current.User.CustomerID;
                            IoC.Resolve<IXMExpressListManagementService>().UpdateXMExpressListManagement(list);
                        }
                        else
                        {
                            //查询后无数据 添加新数据
                            XMExpressListManagement Info = new XMExpressListManagement();
                            Info.Year = year;
                            Info.Month = month;
                            Info.ExpressID = expressID;
                            Info.Number = number;
                            Info.Weight = !string.IsNullOrEmpty(weight) ? decimal.Parse(weight) : 0;
                            string[] Citytype = { "省", "壮族自治区", "回族自治区", "维吾尔自治区", "特别行政区", "自治区", "市" };
                            if (!string.IsNullOrEmpty(sf))
                            {
                                for (int i = 0; i < Citytype.Length; i++)
                                {
                                    bool isExsist = sf.Contains(Citytype[i].ToString());
                                    if (isExsist)
                                    {
                                        string city = sf.Substring(0, sf.IndexOf(Citytype[i].ToString()));
                                        var cityInfo = IoC.Resolve<IAreaCodeService>().GetAreaByCity(city);
                                        if (cityInfo != null)
                                        {
                                            Info.ProvinceID = cityInfo.NumberID;
                                        }
                                        break;
                                    }
                                }
                            }
                            Info.Cost = !string.IsNullOrEmpty(cost) ? decimal.Parse(cost) : 0;
                            Info.UpdateID = Info.CreateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = Info.CreateDate = DateTime.Now;
                            Info.IsEnable = false;
                            IoC.Resolve<IXMExpressListManagementService>().InsertXMExpressListManagement(Info);
                        }
                    }
                    resultCount++;
                }

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }

        /// <summary>
        /// 导入物流单号
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="weekDate"></param>
        /// <param name="PlatformTypeNameId"></param>
        /// <param name="FileName"></param>
        /// <param name="paramMessage"></param>
        public void ImportLogisticsNumberDataFromXls(string filePath, DateTime weekDate, int DeliveryTypeId, string DeliveryTypeIdName, ref string paramMessage, int xMProjectID, int WarehousesID)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;

                dt = excelHelper.ReadTable("发货单");
                dt.DefaultView.RowFilter = "销售订单号 is not null and (Convert(销售订单号, 'System.String')<>'' or Convert(销售订单号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                foreach (DataRow row1 in dt.Rows)
                {
                    string OrderCode = row1["销售订单号"].ToString().Trim();
                    string LogisticsNumber = row1["物流单号"].ToString().Trim();
                    string LogisticsCompany = row1["物流公司"].ToString().Trim();
                    string ManufacturersCode = row1["产品编码"].ToString().Trim();
                    string Shop = "";
                    string LogisticsCode = "";
                    int PlatformTypeId = 0;
                    int LogisticsId = 0;
                    string msg = "订单号：";
                    string errMessage = "";
                    bool isInventLess = false;
                    List<XMDelivery> list = new List<XMDelivery>();
                    string order = OrderCode;

                    if (OrderCode == "" || ManufacturersCode == "")
                    {
                        paramMessage += "销售订单号：" + OrderCode + "，产品编码为空！\r";
                        continue;
                    }

                    if (xMProjectID == 2)//喜临门
                    {
                        msg = "发货单号：";
                        list = IoC.Resolve<IXMDeliveryService>().GetXMOrderInfoListByDeliveryNumber(OrderCode);
                        if (list != null && list.Count > 0)
                        {
                            order = list[0].OrderCode;
                        }
                        else
                        {
                            paramMessage += msg + OrderCode + "，的发货单不存在！\r";
                            continue;
                        }
                    }
                    else
                    {
                        list = IoC.Resolve<IXMDeliveryService>().GetXMOrderInfoListByCode(order, ManufacturersCode);
                        if (list == null || list.Count == 0)
                        {
                            paramMessage += msg + OrderCode + ",产品编码：" + ManufacturersCode + "的发货单不存在！\r";
                            continue;
                        }
                    }

                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(order);
                    if (OrderInfo != null)
                    {
                        Shop = OrderInfo.PlatformName;
                        PlatformTypeId = (int)OrderInfo.PlatformTypeId;
                    }
                    else
                    {
                        paramMessage += "订单号：" + order + "的记录不存在！\r";
                        continue;
                    }

                    #region  发货单类型：正常订单

                    #region 各平台物流名称规范
                    if (!string.IsNullOrEmpty(LogisticsCompany))
                    {
                        if (LogisticsCompany == "佳吉物流" || LogisticsCompany.IndexOf("佳吉") != -1)
                        {
                            LogisticsCompany = "佳吉快运";
                        }
                        if (LogisticsCompany == "九谦" || LogisticsCompany.IndexOf("九谦") != -1)
                        {
                            LogisticsCompany = "厂家自送";
                        }
                        if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                        {
                            LogisticsCompany = "厂家自送";
                        }
                        if (LogisticsCompany == "顺丰" || LogisticsCompany.IndexOf("顺丰") != -1)
                        {
                            LogisticsCompany = "顺丰速运";
                        }

                        if (Shop == "京东")
                        {
                            if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                            {
                                LogisticsCompany = "厂家自送";
                            }
                            if (LogisticsCompany == "顺丰" || LogisticsCompany.IndexOf("顺丰") != -1)
                            {
                                LogisticsCompany = "顺丰快递";
                            }
                        }
                        else if (Shop == "天猫")
                        {
                            if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                            {
                                LogisticsCompany = "其他";
                            }
                            if (LogisticsCompany == "佳吉快运" || LogisticsCompany.IndexOf("佳吉") != -1)
                            {
                                LogisticsCompany = "其他";
                            }
                        }
                        else if (Shop == "苏宁易购")
                        {
                            if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                            {
                                LogisticsCompany = "其他";
                            }
                        }
                        else if (Shop == "一号店")
                        {
                            if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                            {
                                LogisticsCompany = "其他";
                            }
                        }

                        //物流公司信息
                        List<XMCompanyCustom> xMCompanyCustomList = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomList();//.GetXMCompanyCustomByNickIdAndPlatformTypeId(1, PlatformTypeId);
                        if (xMCompanyCustomList != null && xMCompanyCustomList.Count > 0)
                        {
                            foreach (XMCompanyCustom info in xMCompanyCustomList)
                            {
                                if (info.LogisticsName.Contains(LogisticsCompany)
                                    || LogisticsCompany.Contains(info.LogisticsName)
                                    || (info.LogisticsName.Length > 1 && LogisticsCompany.Contains(info.LogisticsName.Substring(0, 2)))
                                    //|| (info.LogisticsName.Length > 3 && LogisticsCompany.Contains(info.LogisticsName.Substring(2, 2)))
                                    )
                                {
                                    LogisticsId = info.LogisticsId == null ? 0 : int.Parse(info.LogisticsId);
                                    LogisticsCode = info.CompanyCode == null ? "" : info.CompanyCode;
                                    break;
                                }
                            }
                        }
                    }
                    #endregion

                    if (LogisticsId != 0)
                    {
                        if (xMProjectID == 5 && WarehousesID == 65)      //曲美北京赠品仓  更新发货单状态 更新出库单状态更新库存
                        {

                            //更新对应出库单状态 更新库存
                            var saleDelivery = IoC.Resolve<XMSaleDeliveryService>().GetXMSaleDeliveryListByParm(list[0].Id);
                            if (saleDelivery != null && saleDelivery.Count > 0)
                            {
                                //判断库存
                                List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
                                foreach (var parm in saleDelivery)
                                {
                                    var saleDeliveryDetail = IoC.Resolve<XMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsBySaleDeliveryID(parm.Id);
                                    if (saleDeliveryDetail != null && saleDeliveryDetail.Count > 0)
                                    {
                                        foreach (XMSaleDeliveryProductDetails p in saleDeliveryDetail)
                                        {
                                            SaleDeliveryProduct list2 = new SaleDeliveryProduct();
                                            list2.pcode = p.PlatformMerchantCode;
                                            list2.saleDeliveryCount = p.SaleCount.Value;
                                            list2.wareHoueseID = parm.WareHouseId;
                                            List.Add(list2);
                                        }
                                    }
                                }
                                if (List != null && List.Count > 0)
                                {
                                    var List2 = from l in List
                                                group l by new { l.pcode, l.wareHoueseID } into g
                                                select new
                                                {
                                                    pcode = g.Key.pcode,
                                                    wareHoueseID = g.Key.wareHoueseID,
                                                    saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                                };

                                    if (List2 != null && List2.Count() > 0)
                                    {
                                        foreach (var parm in List2)
                                        {
                                            var inventInfo = IoC.Resolve<XMInventoryInfoService>().GetXMInventoryInfoByParm(parm.pcode, parm.wareHoueseID);
                                            if (inventInfo == null)
                                            {
                                                isInventLess = true;      //库存不足
                                                errMessage = errMessage + parm.pcode + ";";
                                                break;
                                            }
                                            else
                                            {
                                                if (inventInfo.StockNumber == null)
                                                {
                                                    isInventLess = true;      //库存不足
                                                    errMessage = errMessage + parm.pcode + ";";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
                                                    {
                                                        isInventLess = true;      //库存不足
                                                        errMessage = errMessage + parm.pcode + ";";
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (isInventLess)
                                {
                                    paramMessage += "商品编码为：" + errMessage + "库存不足，无法出库！";
                                    break;
                                }

                                foreach (var parm in saleDelivery)
                                {
                                    using (TransactionScope scope = new TransactionScope())
                                    {
                                        parm.BillStatus = 1000;
                                        parm.UpdateDate = DateTime.Now;
                                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        IoC.Resolve<XMSaleDeliveryService>().UpdateXMSaleDelivery(parm);
                                        //更新库存
                                        var deliveryProductDetails = IoC.Resolve<XMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsBySaleDeliveryID(parm.Id);
                                        if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                                        {
                                            foreach (XMSaleDeliveryProductDetails p in deliveryProductDetails)
                                            {
                                                string code = p.PlatformMerchantCode;//商品编码
                                                int wfID = parm.WareHouseId;//出库仓库ID
                                                var InventoryInfo = IoC.Resolve<XMInventoryInfoService>().GetXMInventoryInfoByParm(code, wfID);
                                                if (InventoryInfo != null)//商品编码为code的产品在库存表中已经存在 更新库存数量
                                                {
                                                    InventoryInfo.StockNumber = InventoryInfo.StockNumber - p.SaleCount;//库存减掉出库量
                                                    InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                                    InventoryInfo.UpdateDate = DateTime.Now;
                                                    InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    IoC.Resolve<XMInventoryInfoService>().UpdateXMInventoryInfo(InventoryInfo);
                                                }
                                                //更新库存总账主表数据   从表添加一条记录
                                                UpdateInventoryLederInfo(wfID, p);
                                            }
                                        }
                                        scope.Complete();
                                    }
                                }
                            }
                            if (!isInventLess)
                            {
                                if (DeliveryTypeId == 481 || DeliveryTypeId == 722)
                                {
                                    if (list[0].IsDelivery == true)
                                    {
                                        paramMessage += msg + OrderCode + ",产品编码：" + ManufacturersCode + "的发货单已存在物流信息！\r";
                                        continue;
                                    }
                                }

                                list[0].IsDelivery = true;
                                list[0].LogisticsNumber = LogisticsNumber;
                                list[0].LogisticsId = LogisticsId;
                                list[0].LogisticsCode = LogisticsCode;
                                list[0].Price = 0;
                                list[0].UpdateDate = DateTime.Now;
                                list[0].UpdateId = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(list[0]);
                                //亚马逊导入物流单号更新订单发货时间
                                var orderlist = IoC.Resolve<XMOrderInfoService>().GetXMOrderInfoByOrderCode(order);
                                if (orderlist.PlatformTypeId == 376)
                                {
                                    orderlist.DeliveryTime = DateTime.Now;
                                    IoC.Resolve<XMOrderInfoService>().UpdateXMOrderInfo(orderlist);
                                }
                                resultCount++;
                            }
                        }
                        else //其他项目仓库不更新库存
                        {
                            if (DeliveryTypeId == 481 || DeliveryTypeId == 722)
                            {
                                if (list[0].IsDelivery == true)
                                {
                                    paramMessage += msg + OrderCode + ",产品编码：" + ManufacturersCode + "的发货单已存在物流信息！\r";
                                    continue;
                                }
                            }

                            list[0].IsDelivery = true;
                            list[0].LogisticsNumber = LogisticsNumber;
                            list[0].LogisticsId = LogisticsId;
                            list[0].LogisticsCode = LogisticsCode;
                            list[0].Price = 0;
                            list[0].UpdateDate = DateTime.Now;
                            list[0].UpdateId = HozestERPContext.Current.User.CustomerID;
                            IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(list[0]);
                            //亚马逊导入物流单号更新订单发货时间
                            var orderlist = IoC.Resolve<XMOrderInfoService>().GetXMOrderInfoByOrderCode(order);
                            if (orderlist.PlatformTypeId == 376)
                            {
                                orderlist.DeliveryTime = DateTime.Now;
                                IoC.Resolve<XMOrderInfoService>().UpdateXMOrderInfo(orderlist);
                            }
                            resultCount++;
                        }
                    }
                    else
                    {
                        paramMessage += msg + OrderCode + ",产品编码：" + ManufacturersCode + "的物流公司有误，无法找到！\r";
                    }

                    #endregion

                    #region 已注释——天猫
                    //else if (PlatformType == "天猫")
                    //{
                    //    string LogisticsId = "";
                    //    if (Remarks != null && Remarks != "" && Remarks.Length > 2)
                    //    {
                    //        string RemarkStr = Remarks.Substring(0, 2);
                    //        string LogisticsStr = "";
                    //        if (RemarkStr == "万家")
                    //        {
                    //            LogisticsStr = "其他";
                    //        }
                    //        else
                    //        {
                    //            LogisticsStr = RemarkStr;
                    //        }
                    //        var xMCompanyCustom = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticsName(LogisticsStr, 250);
                    //        if (xMCompanyCustom != null)
                    //        {
                    //            LogisticsId = xMCompanyCustom.LogisticsId;
                    //        }
                    //    }
                    //    if (LogisticsId != "")
                    //    {
                    //        //订单号、商品编码查询
                    //        var deliveryinfo = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryByOrderCodeandPartNo(OrderCode, PartNo);
                    //        //订单号查询订单信息
                    //        //var orderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(OrderCode);
                    //        if (deliveryinfo != null)
                    //        {
                    //            deliveryinfo.LogisticsId = int.Parse(LogisticsId);//物流公司id
                    //            deliveryinfo.LogisticsNumber = LogisticsNumber;//物流单号
                    //            //deliveryinfo.Price = Price == "" ? 0 : decimal.Parse(Price);//运费
                    //            deliveryinfo.Price = orderinfo.DistributePrice;//运费
                    //            deliveryinfo.UpdateId = HozestERPContext.Current.User.CustomerID;
                    //            deliveryinfo.UpdateDate = DateTime.Now;
                    //            IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(deliveryinfo);
                    //            //操作记录
                    //            int UpsatorID = 0;
                    //            if (HozestERPContext.Current.User != null)
                    //            {
                    //                UpsatorID = HozestERPContext.Current.User.CustomerID;

                    //            }
                    //            else
                    //            {
                    //                string UserName = "admin";
                    //                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                    //                if (customer.Count > 0)
                    //                {
                    //                    UpsatorID = customer[0].CustomerID;
                    //                }
                    //            }

                    //            XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                    //            record.OrderInfoId = orderinfo.ID;
                    //            record.PropertyName = "DeliveryNumber";
                    //            record.OldValue = "";
                    //            record.NewValue = deliveryinfo.DeliveryNumber;
                    //            record.UpdatorID = UpsatorID;
                    //            record.UpdateTime = DateTime.Now;
                    //            IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);
                    //            resultCount++;
                    //        }
                    //        else
                    //        {
                    //            paramMessage += "订单号:" + OrderCode + "不存在或产品名称、尺寸、商品编码有误！" + "\t\n";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        paramMessage += "订单号:" + row1["订单号"].ToString() + "物流公司有误！" + "\t\n";
                    //    }

                    //}
                    //else
                    //{
                    //    paramMessage += PlatformType + "平台订单请手动操作, 订单号：" + row1["订单号"].ToString() + "\t\n";
                    //}

                    #endregion

                    #region 已注释——发货单类型：赠品（未完成）
                    //else if (DeliveryTypeIdName == "赠品") {
                    //    string LogisticsId = "";
                    //    if (Remarks != null && Remarks != "" && Remarks.Length > 2)
                    //    {
                    //        //默认使用京东平台物流信息
                    //        var xMCompanyCustom = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticsName(Remarks, 251);
                    //        if (xMCompanyCustom != null)
                    //        { 
                    //            LogisticsId = xMCompanyCustom.LogisticsId;
                    //        }
                    //    }

                    //    if (LogisticsId != "")
                    //    {
                    //        //订单号、
                    //        var deliveryinfo = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryByOrderCodeandPartNo(OrderCode, PartNo); 

                    //        if (deliveryinfo != null)
                    //        {
                    //               decimal d = 0;

                    //            deliveryinfo.LogisticsId = int.Parse(LogisticsId);//物流公司id
                    //            deliveryinfo.LogisticsNumber = LogisticsNumber;//物流单号  
                    //            if (decimal.TryParse(Price, out d))//类型转换
                    //            {
                    //                deliveryinfo.Price = Convert.ToDecimal(Price);//运费
                    //            }
                    //            else {
                    //                deliveryinfo.Price = 0;
                    //            }
                    //            deliveryinfo.UpdateId = HozestERPContext.Current.User.CustomerID;
                    //            deliveryinfo.UpdateDate = DateTime.Now;
                    //            IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(deliveryinfo);

                    //        }
                    //        else
                    //        {
                    //            paramMessage += "订单号:" + OrderCode + "不存在或产品名称、尺寸、商品编码有误！" + "\t\n";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        paramMessage += "订单号:" + row1["订单号"].ToString() + "物流公司有误！" + "\t\n";
                    //    }
                    //}
                    #endregion

                    //库存不足 退出循环
                    if (isInventLess)
                    {
                        break;
                    }
                }

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }

        /// <summary>
        /// 插入库存帐明细
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleDeliveryProductDetails info)
        {
            var inventoryLeder = IoC.Resolve<XMInventoryLedgerService>().GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.SaleCount;
                inventoryLeder.OutPrice = CalculateProductPrice(wareHousesId, info, 1002);
                inventoryLeder.OutMoney = inventoryLeder.OutPrice * inventoryLeder.OutCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                IoC.Resolve<XMInventoryLedgerService>().UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.OutCount = info.SaleCount;
                inventoryLederInfo.OutPrice = info.ProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = info.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                IoC.Resolve<XMInventoryLedgerService>().InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(出库)
            var inventoryLederDetail = IoC.Resolve<XMInventoryLedgerDetailService>().GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.OutCount = info.SaleCount;
            details.OutPrice = info.ProductPrice;
            details.OutMoney = info.SaleCount * info.ProductPrice;
            details.InCount = 0;
            details.InPrice = price;
            details.InMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount - details.OutCount;
            }
            else
            {
                details.BalanceCount = 0;
            }
            details.BalancePrice = info.ProductPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var saleDeliveryInfo = IoC.Resolve<XMSaleDeliveryService>().GetXMSaleDeliveryById(info.SaleDeliveryId);
            if (saleDeliveryInfo != null)
            {
                details.RefNumber = saleDeliveryInfo.Ref;
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1002;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            IoC.Resolve<XMInventoryLedgerDetailService>().InsertXMInventoryLedgerDetail(details);
        }

        //根据状态平均算出销售单价  (状态出库  入库   在途)
        private decimal CalculateProductPrice(int wareHousesId, XMSaleDeliveryProductDetails info, int satatus)
        {
            int count = 0;
            decimal money = 0;
            //int refType = 1002;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            decimal price = 0;
            var inventoryLederDetail = IoC.Resolve<XMInventoryLedgerDetailService>().GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode, satatus);
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                foreach (XMInventoryLedgerDetail Info in inventoryLederDetail)
                {
                    count = count + Info.OutCount.Value;
                    money = money + Info.OutPrice.Value * Info.OutCount.Value;
                }
            }
            count = count + info.SaleCount.Value;
            money = money + info.ProductPrice.Value * info.SaleCount.Value;
            price = money / count;
            return price;
        }

        /// <summary>
        /// 导入刷单记录
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="weekDate"></param>
        /// <param name="FileName"></param>
        /// <param name="paramMessage"></param>
        public void ImportScalpingRecordXls(string filePath, DateTime weekDate, string FileName, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                int TMInsertCount = 0;
                int TMUpdateCount = 0;

                int JDInsertCount = 0;
                int JDUpdateCount = 0;

                int TMCDInsertCount = 0;
                int TMCDUpdateCount = 0;

                int VPHInsertCount = 0;
                int VPHUpdateCount = 0;

                int YHDInsertCount = 0;
                int YHDUpdateCount = 0;

                int SuningInsertCount = 0;
                int SuningUpdateCount = 0;

                //同步个平台 返回的记录条数 
                int count = 0;

                if (FileName.Trim() == "刷单")
                {
                    dt = excelHelper.ReadTable("Sheet1");
                    //dt.DefaultView.RowFilter = "刷单单号 is not null and (Convert(刷单单号, 'System.String')<>'' or Convert(刷单单号, 'System.Int32')>0)";
                    dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();


                    foreach (DataRow row1 in dt.Rows)
                    {
                        var XMOrderInfoAppList = IoC.Resolve<IXMOrderInfoAppService>().GetXMOrderInfoAppList();
                        List<XMOrderInfoApp> xMorderInfoApp = new List<XMOrderInfoApp>();
                        //XMOrderInfoApp xMorderInfoAppNew;
                        //根据刷单单号查询  刷单信息
                        var XMScalpingApplicationList = IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByEqualsScalpingCode(row1["刷单单号"].ToString().Trim());

                        if (XMScalpingApplicationList.Count > 0)
                        {

                            xMorderInfoApp = XMOrderInfoAppList.Where(q => q.PlatformTypeId == XMScalpingApplicationList[0].PlatformTypeId && q.NickId == XMScalpingApplicationList[0].NickId).ToList();

                        }
                        var xMOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(row1["订单号"].ToString().Trim());

                        if (xMOrderInfo == null)
                        {
                            #region 各平台订单号同步
                            for (int i = 0; i < xMorderInfoApp.Count; i++)
                            {
                                //京东
                                if (xMorderInfoApp[i].PlatformTypeId == 251 || xMorderInfoApp[i].PlatformTypeId == 382)//|| xMorderInfoApp[i].PlatformTypeId == 310)
                                {

                                    HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                    HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(row1["订单号"].ToString().Trim(), xMorderInfoApp[i].AppKey, xMorderInfoApp[i].AppSecret, xMorderInfoApp[i].ServerUrl, xMorderInfoApp[i].AccessToken);

                                    if (orderInfo != null)
                                    {
                                        IoC.Resolve<IXMOrderInfoAPIService>().getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoApp[i]);
                                    }
                                }
                                //天猫
                                else if (xMorderInfoApp[i].PlatformTypeId == 250 || xMorderInfoApp[i].PlatformTypeId == 381)
                                {
                                    Trade trade = IoC.Resolve<IXMOrderInfoAPIService>().GetTrade(Convert.ToInt64(row1["订单号"].ToString().Trim()), xMorderInfoApp[i]);

                                    if (trade != null)
                                    {
                                        if (xMorderInfoApp[i].PlatformTypeId == 250)
                                        {
                                            IoC.Resolve<IXMOrderInfoAPIService>().getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoApp[i]);
                                        }
                                        else if (xMorderInfoApp[i].PlatformTypeId == 381)
                                        {
                                            IoC.Resolve<IXMOrderInfoAPIService>().getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoApp[i]);
                                        }


                                    }
                                }
                                //一号店
                                else if (xMorderInfoApp[i].PlatformTypeId == 375)
                                {
                                    IoC.Resolve<IXMOrderInfoAPIService>().getOrderYHD(row1["订单号"].ToString().Trim(), ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoApp[i]);
                                }
                                //苏宁易购
                                else if (xMorderInfoApp[i].PlatformTypeId == 383)
                                {
                                    IoC.Resolve<IXMOrderInfoAPIService>().getOrderSuning(row1["订单号"].ToString().Trim(), ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoApp[i]);
                                }

                            }

                            if (xMorderInfoApp.Count > 0 && xMorderInfoApp[0].PlatformTypeId == 259)
                            {

                                string payDateStart = Convert.ToDateTime(DateTime.Now).AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");
                                string payDateEnd = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
                                IoC.Resolve<IXMOrderInfoAPIService>().getOrderVPH(payDateStart, payDateEnd, row1["订单号"].ToString().Trim(), ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoApp[0]);
                            }
                            #endregion

                            //同步个平台 返回的记录条数 
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;

                        }
                        else
                        {
                            count = 1;
                        }
                        string ScalpingNo = row1["刷单单号"].ToString().Trim();//刷单单号
                        int ScalpingApplication = 0;//刷单单号Id
                        int PlatformTypeId = 0;//平台类型Id
                        int NickId = 0; //店铺Id
                        string OrderCode = row1["订单号"].ToString().Trim();//订单号
                        string ProductName = "";//产品名称
                        string WantID = row1["旺旺ID"].ToString().Trim(); //旺旺Id
                        decimal SalesPriceV = Convert.ToDecimal(row1["刷拍金额"].ToString().Trim());//销售价
                        decimal Fee = Convert.ToDecimal(row1["佣金"].ToString().Trim());

                        //根据刷单单号查询  刷单信息
                        // var XMScalpingApplicationList = IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByEqualsScalpingCode(row1["刷单单号"].ToString());

                        if (XMScalpingApplicationList.Count > 0 && row1["刷单单号"].ToString().Trim() != "")
                        {
                            ScalpingApplication = XMScalpingApplicationList[0].ScalpingId;
                            PlatformTypeId = XMScalpingApplicationList[0].PlatformTypeId;
                            NickId = XMScalpingApplicationList[0].NickId.Value;

                        }
                        if (xMOrderInfo != null && row1["刷单单号"].ToString().Trim() == "")
                        {
                            ScalpingApplication = 0;
                            PlatformTypeId = int.Parse(xMOrderInfo.PlatformTypeId.ToString());
                            NickId = int.Parse(xMOrderInfo.NickID.ToString());

                        }
                        var xMOrderInfoProductDetails = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderCode(row1["订单号"].ToString().Trim());
                        if (xMOrderInfoProductDetails.Count > 0)
                        {
                            ProductName = xMOrderInfoProductDetails[0].ProductName;
                        }

                        var xmScalpingList = IoC.Resolve<IXMScalpingService>().GetXMScalpingByOrderCode(row1["订单号"].ToString().Trim());

                        #region 根据店铺Id查询项目  再根据项目Id、平台类型Id查询扣点

                        int ProjectId = 0;
                        //根据店铺Id查询  取项目Id
                        var XMNick = IoC.Resolve<IXMNickService>().GetXMNickByID(NickId);
                        if (XMNick != null)
                        {
                            if (XMNick.ProjectId != null)
                            {
                                ProjectId = XMNick.ProjectId.Value;
                            }
                        }
                        //根据项目Id 平台类型查询 扣点 
                        var xMDeductionSetUp = IoC.Resolve<IXMDeductionSetUpService>().GetXMDeductionSetUpByProjectAndPlatformTypeId(ProjectId, 475, PlatformTypeId);


                        // 修改订单表是否刷单状态 （订单存在IsScalping=true） 并判断订单是否存在
                        var xMOrderInfoNow = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(OrderCode);


                        #endregion
                        if (xMDeductionSetUp != null)
                        {
                            #region 新增
                            if (xmScalpingList.Count == 0)
                            {
                                XMScalping xMScalping = new XMScalping();
                                xMScalping.ScalpingApplication = ScalpingApplication;
                                xMScalping.PlatformTypeId = PlatformTypeId;
                                xMScalping.NickId = NickId;
                                xMScalping.OrderCode = OrderCode;
                                xMScalping.WantID = WantID;
                                if (ProductName != "")
                                {
                                    xMScalping.ProductName = ProductName;
                                }

                                //计算扣点
                                if (xMDeductionSetUp.Deduction != null)
                                {
                                    decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

                                    xMScalping.Deduction = SalesPriceV * DeductionD;//扣点
                                }
                                else
                                {
                                    xMScalping.Deduction = 0;//扣点
                                }
                                xMScalping.SalePrice = SalesPriceV;
                                xMScalping.Fee = Fee;
                                xMScalping.IsEnable = false;
                                xMScalping.CreateID = HozestERPContext.Current.User.CustomerID;
                                xMScalping.CreateDate = DateTime.Now;
                                xMScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xMScalping.UpdateDate = DateTime.Now;

                                if (xMOrderInfoNow != null)
                                {
                                    if (xMOrderInfoNow.NickID == NickId && xMOrderInfoNow.PlatformTypeId == PlatformTypeId)
                                    {
                                        if (count == 0)
                                        {
                                            xMScalping.IsAbnormal = true;
                                        }
                                        else
                                        {

                                            xMScalping.IsAbnormal = false;
                                            #region 修改订单表是否刷单状态 （订单存在IsScalping=true）
                                            if (xMOrderInfoNow != null)
                                            {
                                                xMOrderInfoNow.IsScalping = true;
                                                xMOrderInfoNow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                xMOrderInfoNow.UpdateDate = DateTime.Now;
                                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfoNow);
                                            }
                                            #endregion
                                        }

                                    }
                                    else
                                    {

                                        xMScalping.IsAbnormal = true;
                                    }
                                }
                                else
                                {
                                    xMScalping.IsAbnormal = true;
                                }
                                IoC.Resolve<IXMScalpingService>().InsertXMScalping(xMScalping);
                                resultCount++;
                            }
                            #endregion

                            #region 修改
                            else
                            {
                                XMScalping xmScalping = new XMScalping();
                                for (int i = 0; i < xmScalpingList.Count; i++)
                                {
                                    xmScalping = xmScalpingList[i];

                                    //刷单记录是null 
                                    if (xmScalping.ScalpingApplication == null)
                                    {
                                        #region  刷单表中订单号存在 ，未分配刷单单号
                                        xmScalping.ScalpingApplication = ScalpingApplication;
                                        xmScalping.PlatformTypeId = PlatformTypeId;
                                        xmScalping.NickId = NickId;
                                        xmScalping.OrderCode = OrderCode;
                                        xmScalping.WantID = WantID;

                                        if (ProductName != "")
                                        {
                                            xmScalping.ProductName = ProductName;
                                        }
                                        //if (row1["刷单单号"].ToString() != "")
                                        //{
                                        //计算扣点
                                        if (xMDeductionSetUp.Deduction != null)
                                        {
                                            decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

                                            xmScalping.Deduction = SalesPriceV * DeductionD;//扣点
                                        }
                                        else
                                        {
                                            xmScalping.Deduction = 0;//扣点
                                        }
                                        //}
                                        //else
                                        //{
                                        //    xmScalping.Deduction = 0;//扣点
                                        //}
                                        xmScalping.SalePrice = SalesPriceV;
                                        xmScalping.Fee = Fee;

                                        if (xmScalping.NickId == NickId && xmScalping.PlatformTypeId == PlatformTypeId)
                                        {
                                            if (count == 0)
                                            {
                                                xmScalping.IsAbnormal = true;
                                            }
                                            else
                                            {

                                                xmScalping.IsAbnormal = false;
                                                #region 修改订单表是否刷单状态 （订单存在IsScalping=true）
                                                if (xMOrderInfoNow != null)
                                                {
                                                    xMOrderInfoNow.IsScalping = true;
                                                    xMOrderInfoNow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    xMOrderInfoNow.UpdateDate = DateTime.Now;
                                                    IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfoNow);
                                                }
                                                #endregion
                                            }

                                        }
                                        else
                                        {
                                            xmScalping.IsAbnormal = true;
                                        }

                                        xmScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xmScalping.UpdateDate = DateTime.Now;
                                        IoC.Resolve<IXMScalpingService>().UpdateXMScalping(xmScalping);
                                        resultCount++;

                                        #endregion

                                    }
                                    else
                                    {
                                        //已分配刷单单号的销售金额
                                        decimal SalePrice = xmScalping.SalePrice.Value;

                                        //根据刷单Id、订单号查询 是否数据已存在
                                        var xmScalpingByList = IoC.Resolve<IXMScalpingService>().GetXMScalpingList(ScalpingApplication, row1["订单号"].ToString().Trim());

                                        if (xmScalpingByList.Count == 0)
                                        {
                                            #region 新增
                                            //订单已支付金额
                                            decimal PayPrice = 0;
                                            if (xMOrderInfoNow != null)
                                            {
                                                PayPrice = xMOrderInfoNow.PayPrice.Value;
                                            }

                                            //刷拍总金额
                                            decimal ScalpingSalePrice = SalePrice + SalesPriceV;

                                            if (ScalpingSalePrice <= PayPrice)
                                            {

                                                XMScalping xmScalpingNew = new XMScalping();

                                                xmScalpingNew.ScalpingApplication = ScalpingApplication;
                                                xmScalpingNew.PlatformTypeId = PlatformTypeId;
                                                xmScalpingNew.NickId = NickId;
                                                xmScalpingNew.OrderCode = OrderCode;
                                                xmScalpingNew.WantID = WantID;

                                                if (ProductName != "")
                                                {
                                                    xmScalpingNew.ProductName = ProductName;
                                                }
                                                //if (row1["刷单单号"].ToString() != "")
                                                //{
                                                //计算扣点
                                                if (xMDeductionSetUp.Deduction != null)
                                                {
                                                    decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

                                                    xmScalpingNew.Deduction = SalesPriceV * DeductionD;//扣点
                                                }
                                                else
                                                {
                                                    xmScalpingNew.Deduction = 0;//扣点
                                                }
                                                //}
                                                //else
                                                //{
                                                //    xmScalping.Deduction = 0;//扣点
                                                //}
                                                xmScalpingNew.SalePrice = SalesPriceV;
                                                xmScalpingNew.Fee = Fee;
                                                xmScalpingNew.IsEnable = false;

                                                if (xmScalpingNew.NickId == NickId && xmScalpingNew.PlatformTypeId == PlatformTypeId)
                                                {
                                                    if (count == 0)
                                                    {
                                                        xmScalpingNew.IsAbnormal = true;
                                                    }
                                                    else
                                                    {

                                                        xmScalpingNew.IsAbnormal = false;
                                                        #region 修改订单表是否刷单状态 （订单存在IsScalping=true）
                                                        if (xMOrderInfoNow != null)
                                                        {
                                                            xMOrderInfoNow.IsScalping = true;
                                                            xMOrderInfoNow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                            xMOrderInfoNow.UpdateDate = DateTime.Now;
                                                            IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfoNow);
                                                        }
                                                        #endregion
                                                    }

                                                }
                                                else
                                                {
                                                    xmScalpingNew.IsAbnormal = true;
                                                }

                                                xmScalpingNew.CreateID = HozestERPContext.Current.User.CustomerID;
                                                xmScalpingNew.CreateDate = DateTime.Now;
                                                xmScalpingNew.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                xmScalpingNew.UpdateDate = DateTime.Now;
                                                IoC.Resolve<IXMScalpingService>().InsertXMScalping(xmScalpingNew);
                                                resultCount++;

                                            }
                                            else
                                            {

                                                paramMessage += "订单号:" + OrderCode + "的刷单销售额大于订单已支付总额" + "\t\n";
                                            }

                                            #endregion
                                        }
                                        else
                                        {
                                            paramMessage += "订单号:" + OrderCode + "不可分配相同的刷单单号" + "\t\n";
                                        }
                                    }
                                    //else
                                    //{
                                    //    paramMessage += "订单号:" + OrderCode + "已分配刷单单号" + "\t\n";
                                    //}


                                }

                            }
                            #endregion
                        }
                        else
                        {
                            paramMessage += "请设置平台扣点." + "\t\n";
                        }
                    }
                    //}
                }
                else
                {
                    paramMessage = FileName.Trim() + "文件名称有误！";
                }

                if (dt != null)
                {

                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                    }
                }
            }
        }

        /// <summary>
        /// 客服导入同步订单
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="Plattype">平台ID</param>
        /// <param name="paramNickID">店铺ID</param>
        /// <returns></returns>
        public int GetOrder(string OrderCode, int Plattype, int paramNickID)
        {
            int TMInsertCount = 0;
            int TMUpdateCount = 0;

            int JDInsertCount = 0;
            int JDUpdateCount = 0;

            int TMCDInsertCount = 0;
            int TMCDUpdateCount = 0;

            int VPHInsertCount = 0;
            int VPHUpdateCount = 0;

            int YHDInsertCount = 0;
            int YHDUpdateCount = 0;

            int SuningInsertCount = 0;
            int SuningUpdateCount = 0;

            //同步个平台 返回的记录条数 
            int count = 0;
            var XMOrderInfoAppList = IoC.Resolve<IXMOrderInfoAppService>().GetXMOrderInfoAppList();
            List<XMOrderInfoApp> xMorderInfoApp = new List<XMOrderInfoApp>();

            xMorderInfoApp = XMOrderInfoAppList.Where(q => q.PlatformTypeId == Plattype && q.NickId == paramNickID).ToList();

            #region 各平台订单号同步
            for (int i = 0; i < xMorderInfoApp.Count; i++)
            {
                //京东
                if (xMorderInfoApp[i].PlatformTypeId == 251 || xMorderInfoApp[i].PlatformTypeId == 382)//|| xMorderInfoApp[i].PlatformTypeId == 310)
                {

                    HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                    HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(OrderCode, xMorderInfoApp[i].AppKey, xMorderInfoApp[i].AppSecret, xMorderInfoApp[i].ServerUrl, xMorderInfoApp[i].AccessToken);

                    if (orderInfo != null)
                    {
                        IoC.Resolve<IXMOrderInfoAPIService>().getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoApp[i]);
                    }
                }
                //天猫
                else if (xMorderInfoApp[i].PlatformTypeId == 250 || xMorderInfoApp[i].PlatformTypeId == 381)
                {
                    Trade trade = IoC.Resolve<IXMOrderInfoAPIService>().GetTrade(Convert.ToInt64(OrderCode), xMorderInfoApp[i]);

                    if (trade != null)
                    {
                        if (xMorderInfoApp[i].PlatformTypeId == 250)
                        {
                            IoC.Resolve<IXMOrderInfoAPIService>().getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoApp[i]);
                        }
                        else if (xMorderInfoApp[i].PlatformTypeId == 381)
                        {
                            IoC.Resolve<IXMOrderInfoAPIService>().getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoApp[i]);
                        }


                    }
                }
                //一号店
                else if (xMorderInfoApp[i].PlatformTypeId == 375)
                {
                    IoC.Resolve<IXMOrderInfoAPIService>().getOrderYHD(OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoApp[i]);
                }
                //苏宁易购
                else if (xMorderInfoApp[i].PlatformTypeId == 383)
                {
                    IoC.Resolve<IXMOrderInfoAPIService>().getOrderSuning(OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoApp[i]);
                }

            }

            if (xMorderInfoApp.Count > 0 && xMorderInfoApp[0].PlatformTypeId == 259)
            {

                string payDateStart = Convert.ToDateTime(DateTime.Now).AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");
                string payDateEnd = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
                IoC.Resolve<IXMOrderInfoAPIService>().getOrderVPH(payDateStart, payDateEnd, OrderCode.ToString().Trim(), ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoApp[0]);
            }
            #endregion

            //同步个平台 返回的记录条数 
            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;

            return count;
        }

        /// <summary>
        /// 天猫（超级店长，赤兔），京东客服归属导入
        /// </summary>
        /// <param name="NickName"></param>
        /// <param name="PlatformTypeNameId"></param>
        /// <param name="NickId"></param>
        /// <param name="OrderCodeCellNum"></param>
        /// <param name="WangNoIDNum"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ImportPreOrderFromXlsKF(string NickName, int PlatformTypeNameId, int NickId, int OrderCodeCellNum, int WangNoIDNum, DataTable dt, bool IsAddNickName)
        {
            string WangNoList = "";//查找不到的旺旺号
            string OrderCodeList = "";//查找不到的订单号
            int count = 0;
            int resultCount = 0;
            count = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XMOrderInfo info = new XMOrderInfo();
                int WangNoID = 0;
                string OrderCode = dt.Rows[i][OrderCodeCellNum].ToString();
                info = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(OrderCode);
                if (info != null)
                {
                    string WangNoName = dt.Rows[i][WangNoIDNum].ToString();
                    if (IsAddNickName)
                        WangNoName = NickName + ":" + dt.Rows[i][WangNoIDNum].ToString();
                    if (IoC.Resolve<IXMWangNoService>().GetXMWangNoByName(WangNoName) != null)
                    {
                        WangNoID = (IoC.Resolve<IXMWangNoService>().GetXMWangNoByName(WangNoName)).ID;
                        resultCount++;
                        info.BelongsServiceId = WangNoID;
                        IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(info);
                    }
                    else
                    {
                        if (WangNoList == "")
                        {
                            WangNoList = WangNoName;
                        }
                        else if (WangNoList.IndexOf(WangNoName) == -1)
                        {
                            WangNoList = WangNoList + "；" + WangNoName;
                        }
                    }
                }
                else
                {
                    int returnCount = GetOrder(OrderCode, PlatformTypeNameId, NickId);
                    if (returnCount > 0)
                    {
                        info = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(OrderCode);
                        if (info != null)
                        {
                            string WangNoName = dt.Rows[i][WangNoIDNum].ToString();
                            if (IsAddNickName)
                                WangNoName = NickName + ":" + dt.Rows[i][WangNoIDNum].ToString();
                            if (IoC.Resolve<IXMWangNoService>().GetXMWangNoByName(WangNoName) != null)
                            {
                                WangNoID = (IoC.Resolve<IXMWangNoService>().GetXMWangNoByName(WangNoName)).ID;
                                resultCount++;
                                info.BelongsServiceId = WangNoID;
                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(info);
                            }
                            else
                            {
                                if (WangNoList == "")
                                {
                                    WangNoList = WangNoName;
                                }
                                else if (WangNoList.IndexOf(WangNoName) == -1)
                                {
                                    WangNoList = WangNoList + "；" + WangNoName;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (OrderCodeList == "")
                        {
                            OrderCodeList = OrderCode;
                        }
                        else
                        {
                            OrderCodeList = OrderCodeList + "；" + OrderCode;
                        }
                    }
                }
            }

            string paramMessage = "";

            if (WangNoList == "" && OrderCodeList == "")
            {
                paramMessage = "导入成功";
            }
            else
            {
                paramMessage += "应该导入" + count + "条，实际导入" + resultCount + "条\n";
                if (!string.IsNullOrEmpty(OrderCodeList))
                {
                    paramMessage += "失败原因，可能为以下订单号在数据库中不存在：\n" + OrderCodeList;
                }
                if (!string.IsNullOrEmpty(WangNoList))
                {
                    paramMessage += "\n以下旺旺号在数据库中不存在：\n" + WangNoList;
                }

            }

            return paramMessage;
        }

        /// <summary>
        /// 天猫
        /// </summary>
        public string ImportPreOrderFromXlsTM(string filePath, string NickName, string FileName, string type, int PlatformTypeNameId, int NickId)
        {
            string paramMessage = "";

            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    DataTable dt = null;
                    dt = excelHelper.ReadTable("Sheet1");

                    #region 京东
                    if (type == "1")
                    {
                        dt.DefaultView.RowFilter = "所属订单编号 is not null and (Convert(所属订单编号, 'System.String')<>'' or Convert(所属订单编号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();
                        paramMessage = ImportPreOrderFromXlsKF(NickName, PlatformTypeNameId, NickId, 4, 2, dt, false);
                    }
                    #endregion
                    #region 超级店长旧
                    if (type == "2")
                    {
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();
                        paramMessage = ImportPreOrderFromXlsKF(NickName, PlatformTypeNameId, NickId, 2, 0, dt, false);
                    }
                    #endregion

                    #region 赤兔
                    if (type == "3")
                    {
                        dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();
                        paramMessage = ImportPreOrderFromXlsKF(NickName, PlatformTypeNameId, NickId, 0, 7, dt, true);
                    }
                    #endregion.
                    #region 超级店长新
                    if (type == "4")
                    {
                        dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();
                        paramMessage = ImportPreOrderFromXlsKF(NickName, PlatformTypeNameId, NickId, 1, 0, dt, true);
                    }
                    #endregion
                }
            }
            return paramMessage;
        }

        /// <summary>
        /// 导入发货
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportImportDeliver(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;

                #region 导入发货单
                dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                int DeliveryTypeId = 0;
                List<CodeList> list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(204, false);
                foreach (CodeList info in list)
                {
                    if (info.CodeName == "正常")
                    {
                        DeliveryTypeId = info.CodeID;
                        break;
                    }
                }

                //using (TransactionScope scope = new TransactionScope())
                //{
                    foreach (DataRow row1 in dt.Rows)
                    {
                        string DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号
                        string OrderCode = row1["订单号"].ToString().Trim();
                        string LogisticsNumber = row1["物流单号"].ToString().Trim();
                        string LogisticsCompany = row1["物流公司"].ToString().Trim();
                        string Price = row1["运费"].ToString().Trim() == "" ? "0" : row1["运费"].ToString().Trim();
                        string ManufacturersCode = row1["产品编码"].ToString().Trim();
                        string Count = row1["订货数"].ToString().Trim() == "" ? "0" : row1["订货数"].ToString().Trim();
                        string PrdouctName = "";
                        string Specifications = "";
                        string Shop = "";
                        string LogisticsName = "";
                        string LogisticsCode = "";
                        int LogisticsId = 0;
                        int PlatformTypeId = 0;

                        #region 根据订单号确定平台
                        var xMOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoListByOrderEqs(OrderCode);
                        if (xMOrderInfo != null && xMOrderInfo.Count > 0)
                        {
                            if (xMOrderInfo[0].PlatformTypeId == 251 || xMOrderInfo[0].PlatformTypeId == 382)
                            {
                                Shop = "京东";
                                PlatformTypeId = 251;
                            }
                            else if (xMOrderInfo[0].PlatformTypeId == 250 || xMOrderInfo[0].PlatformTypeId == 381)
                            {
                                Shop = "天猫";
                                PlatformTypeId = 250;
                            }
                            else if (xMOrderInfo[0].PlatformTypeId == 383)
                            {
                                Shop = "苏宁易购";
                                PlatformTypeId = 383;
                            }
                            else if (xMOrderInfo[0].PlatformTypeId == 375)
                            {
                                Shop = "一号店";
                                PlatformTypeId = 375;
                            }
                            else if (xMOrderInfo[0].PlatformTypeId == 259)
                            {
                                Shop = "唯品会";
                                PlatformTypeId = 259;
                            }
                            else
                            {
                                paramMessage += "订单：" + xMOrderInfo[0].OrderCode.ToString() + "，该订单的平台发货功能还未开发！\r";
                                break;
                            }
                        }
                        else
                        {
                            paramMessage += "订单：" + OrderCode + "，在订单表中不存在！\r";
                            break;
                        }
                        #endregion

                        #region 各平台物流名称规范
                        if (!string.IsNullOrEmpty(LogisticsCompany))
                        {
                            if (LogisticsCompany == "佳吉物流")
                            {
                                LogisticsCompany = "佳吉快运";
                            }

                            if (Shop == "京东")
                            {
                                if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                                {
                                    LogisticsCompany = "厂家自送";
                                }
                                if (LogisticsCompany == "九谦" || LogisticsCompany.IndexOf("九谦") != -1)
                                {
                                    LogisticsCompany = "厂家自送";
                                }
                                if (LogisticsCompany == "顺丰" || LogisticsCompany.IndexOf("顺丰") != -1)
                                {
                                    LogisticsCompany = "顺丰快递";
                                }
                            }
                            else if (Shop == "天猫")
                            {
                                if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                                {
                                    LogisticsCompany = "其他";
                                }
                                if (LogisticsCompany == "佳吉快运")
                                {
                                    LogisticsCompany = "其他";
                                }
                                if (LogisticsCompany == "顺丰" || LogisticsCompany.IndexOf("顺丰") != -1)
                                {
                                    LogisticsCompany = "顺丰速运";
                                }
                            }
                            else if (Shop == "苏宁易购")
                            {
                                if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                                {
                                    LogisticsCompany = "其他";
                                }
                            }
                            else if (Shop == "一号店")
                            {
                                if (LogisticsCompany == "万家" || LogisticsCompany.IndexOf("万家") != -1)
                                {
                                    LogisticsCompany = "其他";
                                }
                            }

                            //物流公司信息
                            List<XMCompanyCustom> xMCompanyCustomList = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByNickIdAndPlatformTypeId(1, PlatformTypeId);
                            if (xMCompanyCustomList != null && xMCompanyCustomList.Count > 0)
                            {
                                foreach (XMCompanyCustom info in xMCompanyCustomList)
                                {
                                    if (info.LogisticsName.IndexOf(LogisticsCompany) != -1)
                                    {
                                        LogisticsId = info.LogisticsId == null ? 0 : int.Parse(info.LogisticsId);
                                        if (LogisticsId == 1)
                                        {
                                            LogisticsId = 2170;
                                        }
                                        if (LogisticsId == 500) //中通速递
                                        {
                                            LogisticsId = 1499;
                                        }
                                        LogisticsCode = info.CompanyCode == null ? "" : info.CompanyCode;
                                        LogisticsName = info.LogisticsName == null ? "" : info.LogisticsName;
                                        break;
                                    }
                                }
                            }
                        }
                        #endregion

                        int ProjectID = 0;
                        var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(OrderCode);
                        if (OrderInfo != null)
                        {
                            var Nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)OrderInfo.NickID);
                            if (Nick != null)
                            {
                                ProjectID = (int)Nick.ProjectId;
                            }
                        }

                        var DeliveryList = IoC.Resolve<IXMDeliveryService>().GetXMOrderInfoListByCode(OrderCode, ManufacturersCode);
                        if (ProjectID == 2 || ProjectID == 25)//喜临门或智曼
                        {
                            if (DeliveryList != null && DeliveryList.Count > 0)
                            {
                                DeliveryList[0].LogisticsNumber = LogisticsNumber;
                                DeliveryList[0].LogisticsId = LogisticsId;
                                DeliveryList[0].LogisticsCode = LogisticsCode;
                                DeliveryList[0].Price = decimal.Parse(Price);
                                DeliveryList[0].UpdateDate = DateTime.Now;
                                DeliveryList[0].UpdateId = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(DeliveryList[0]);

                                //连接接口，改订单状态
                                string Msg = IoC.Resolve<XMDeliveryImportDeliver>().XMDelivery_ImportDeliver(Shop, DeliveryList[0], LogisticsName);
                                if (Msg == "")
                                {
                                    resultCount++;
                                }
                                else
                                {
                                    paramMessage += Msg;
                                }
                            }
                            else
                            {
                                paramMessage += "订单：" + OrderCode.ToString() + "的发货单不存在，或发货单中商品不存在！\r";
                            }
                        }
                        else
                        {
                            XMDelivery Info = new XMDelivery();
                            if (DeliveryList != null && DeliveryList.Count > 0)
                            {
                                Info = DeliveryList[0];
                            }
                            else
                            {
                                var LogisticsNumberList = IoC.Resolve<IXMDeliveryService>().GetXMOrderInfoListByCode(OrderCode, "-1");
                                if (LogisticsNumberList != null && LogisticsNumberList.Count > 0)
                                {
                                    XMDeliveryDetails Logistics = new XMDeliveryDetails();
                                    Logistics.DeliveryId = LogisticsNumberList[0].Id;
                                    Logistics.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
                                    Logistics.OrderNo = OrderCode;
                                    var Product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                                    if (Product != null)
                                    {
                                        Logistics.ProductlId = Product.Id;
                                        PrdouctName = Product.ProductName;
                                        Specifications = Product.Specifications;
                                        var ProductDetailList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Product.Id);
                                        var ProductDetail = ProductDetailList.Where(x => x.PlatformTypeId == OrderInfo.PlatformTypeId);
                                        if (ProductDetail != null && ProductDetail.Count() > 0)
                                        {
                                            Logistics.PlatformMerchantCode = (ProductDetail.ToList())[0].PlatformMerchantCode;
                                        }
                                    }
                                    Logistics.PrdouctName = PrdouctName;
                                    Logistics.Specifications = Specifications;
                                    Logistics.ProductNum = int.Parse(Count);
                                    Logistics.IsEnabled = false;
                                    Logistics.CreateDate = DateTime.Now;
                                    Logistics.CreateID = HozestERPContext.Current.User.CustomerID;
                                    Logistics.UpdateDate = DateTime.Now;
                                    Logistics.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(Logistics);

                                    Info = LogisticsNumberList[0];
                                }
                                else
                                {
                                    XMDelivery one = new XMDelivery();
                                    one.DeliveryTypeId = DeliveryTypeId;
                                    one.DeliveryNumber = DeliveryNumber;
                                    one.OrderCode = OrderCode;
                                    one.LogisticsNumber = LogisticsNumber;
                                    one.LogisticsId = LogisticsId;
                                    one.LogisticsCode = LogisticsCode;
                                    one.Price = decimal.Parse(Price);
                                    one.IsDelivery = false;// true;

                                    //有无备用地址
                                    var exist = IoC.Resolve<IXMSpareAddressService>().GetXMSpareAddressByOrderCodeManufacturersCode(OrderCode, ManufacturersCode);
                                    if (exist != null)
                                    {
                                        one.FullName = exist.FullName;
                                        one.Mobile = exist.Mobile;
                                        one.Tel = exist.Tel;
                                        one.Province = exist.Province;
                                        one.City = exist.City;
                                        one.County = exist.County;
                                        one.DeliveryAddress = exist.DeliveryAddress;
                                    }
                                    else
                                    {
                                        if (OrderInfo != null)
                                        {
                                            one.FullName = OrderInfo.FullName;
                                            one.Mobile = OrderInfo.Mobile;
                                            one.Tel = OrderInfo.Tel;
                                            one.Province = OrderInfo.Province;
                                            one.City = OrderInfo.City;
                                            one.County = OrderInfo.County;
                                            one.DeliveryAddress = OrderInfo.DeliveryAddress;
                                        }
                                    }

                                    one.CreateDate = DateTime.Now;
                                    one.CreateId = HozestERPContext.Current.User.CustomerID;
                                    one.UpdateDate = DateTime.Now;
                                    one.UpdateId = HozestERPContext.Current.User.CustomerID;
                                    one.PrintBatch = 0;
                                    one.PrintQuantity = 0;
                                    one.IsEnabled = false;
                                    IoC.Resolve<IXMDeliveryService>().InsertXMDelivery(one);

                                    XMDeliveryDetails detail = new XMDeliveryDetails();
                                    detail.DeliveryId = one.Id;
                                    detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
                                    detail.OrderNo = OrderCode;
                                    var product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                                    if (product != null)
                                    {
                                        detail.ProductlId = product.Id;
                                        PrdouctName = product.ProductName;
                                        Specifications = product.Specifications;
                                        var ProductDetailList = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(product.Id);
                                        var ProductDetail = ProductDetailList.Where(x => x.PlatformTypeId == OrderInfo.PlatformTypeId);
                                        if (ProductDetail != null && ProductDetail.Count() > 0)
                                        {
                                            detail.PlatformMerchantCode = (ProductDetail.ToList())[0].PlatformMerchantCode;
                                        }
                                    }
                                    detail.PrdouctName = PrdouctName;
                                    detail.Specifications = Specifications;
                                    detail.ProductNum = int.Parse(Count);
                                    detail.IsEnabled = false;
                                    detail.CreateDate = DateTime.Now;
                                    detail.CreateID = HozestERPContext.Current.User.CustomerID;
                                    detail.UpdateDate = DateTime.Now;
                                    detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);

                                    Info = one;
                                }
                            }

                            //连接接口，改订单状态
                            string msg = IoC.Resolve<XMDeliveryImportDeliver>().XMDelivery_ImportDeliver(Shop, Info, LogisticsName);
                            if (msg == "")
                            {
                                resultCount++;
                            }
                            else
                            {
                                paramMessage += msg;
                            }
                        }
                        //scope.Complete();
                    }

                //    scope.Complete();
                //}                  
                #endregion

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        if (paramMessage == "")
                        {
                            paramMessage = "导入成功！";
                        }
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条。";
                    }
                }
            }
        }

        /// <summary>
        /// 亚马逊对账导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportImportReconciliation(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;

                    #region 亚马逊对账导入
                    dt = excelHelper.ReadTable("Sheet1");
                    dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string OrderCode = row1["订单号"].ToString().Trim();
                            string Paymoney = row1["订单金额"].ToString().Trim();
                            if (!string.IsNullOrEmpty(OrderCode))
                            {
                                XMOrderInfo Info = IoC.Resolve<XMOrderInfoService>().GetXMOrderInfoByOrderCode(OrderCode);
                                if (Info != null)
                                {
                                    Info.CompletionTime = DateTime.Now;
                                    Info.PayPrice = Paymoney == "" ? 0 : decimal.Parse(Paymoney);
                                    Info.ReceivablePrice = Paymoney == "" ? 0 : decimal.Parse(Paymoney);
                                    Info.OrderStatus = "已完成";
                                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    Info.UpdateDate = DateTime.Now;
                                    IoC.Resolve<XMOrderInfoService>().UpdateXMOrderInfo(Info);
                                    resultCount++;
                                }
                                else
                                {
                                    paramMessage += "订单：" + OrderCode + "不存在！\r";
                                }
                            }
                            scope.Complete();
                        }
                    }

                    #endregion

                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 人员薪资导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportImportCustomerSalary(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    int no = 0;
                    DataTable Dt = null;
                    DataTable dt = new DataTable();

                    #region 人员薪资导入
                    Dt = excelHelper.ReadTable("表11工资明细");

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (no == 0)
                        {
                            for (int j = 0; j < Dt.Columns.Count; j++)
                            {
                                dt.Columns.Add(new DataColumn(Dt.Rows[i].ItemArray[j].ToString(), typeof(string)));
                            }
                        }
                        else
                        {
                            DataRow tempRow = dt.NewRow();
                            for (int j = 0; j < Dt.Columns.Count; j++)
                            {
                                tempRow[dt.Columns[j].ColumnName] = Dt.Rows[i].ItemArray[j];
                            }
                            dt.Rows.Add(tempRow);
                        }
                        no++;
                    }
                    dt.DefaultView.RowFilter = "身份证号码 is not null and (Convert(身份证号码, 'System.String')<>'' or Convert(身份证号码, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string IDNumber = row1["身份证号码"].ToString().Trim();
                            string Year = row1["年份"].ToString().Trim();
                            string Month = row1["月份"].ToString().Trim();

                            string BasePay = row1["基本工资"].ToString().Trim();
                            string MeritPay = row1["绩效工资"].ToString().Trim();
                            string PerformanceRoyalty = row1["业绩提成"].ToString().Trim();
                            string Reward = row1["奖励"].ToString().Trim();
                            string Subsidies = row1["补贴"].ToString().Trim();
                            string BasePayDebit = row1["基本工资及其它扣款"].ToString().Trim();
                            string AbsenceDutyDebit = row1["因缺勤的绩效扣款"].ToString().Trim();
                            string PerformanceCoefficient = row1["绩效系数"].ToString().Trim();
                            string RealPerformance = row1["实发绩效"].ToString().Trim();
                            string Replenishment = row1["补款"].ToString().Trim();
                            string Debit = row1["扣款"].ToString().Trim();
                            string ShouldSalary = row1["应发工资"].ToString().Trim();
                            string Pension = row1["养老"].ToString().Trim();
                            string MedicalCare = row1["医疗"].ToString().Trim();
                            string Unemployment = row1["失业"].ToString().Trim();
                            string AccumulationFund = row1["公积金"].ToString().Trim();
                            string SocialSecurityTotal = row1["社保公积金总额"].ToString().Trim();
                            string CommunicationFee = row1["通讯费"].ToString().Trim();
                            string IndividualIncomeTax = row1["个人所得税"].ToString().Trim();
                            string FinanceCharge = row1["财务扣款"].ToString().Trim();
                            string RealSalary = row1["实发工资"].ToString().Trim();

                            if (!string.IsNullOrEmpty(IDNumber) && !string.IsNullOrEmpty(Year) && !string.IsNullOrEmpty(Month))
                            {
                                List<CustomerSalaryAll> list = IoC.Resolve<CustomerSalaryService>().GetCustomerSalaryListByIDNumber(IDNumber, int.Parse(Year), int.Parse(Month));
                                if (!(list != null && list.Count > 0))
                                {
                                    CustomerSalary one = new CustomerSalary();
                                    var CustomerInfo = IoC.Resolve<CustomerInfoService>().GetCustomerInfoByIDNumber(IDNumber);
                                    if (CustomerInfo != null)
                                    {
                                        one.CustomerInfoID = CustomerInfo.CustomerID;
                                    }
                                    else
                                    {
                                        paramMessage += "身份证号码：" + IDNumber + "不存在！\r";
                                        continue;
                                    }
                                    one.Year = int.Parse(Year);
                                    one.Month = int.Parse(Month);
                                    one.BasePay = decimal.Parse(BasePay == "" ? "0" : BasePay);
                                    one.MeritPay = decimal.Parse(MeritPay == "" ? "0" : MeritPay);
                                    one.PerformanceRoyalty = decimal.Parse(PerformanceRoyalty == "" ? "0" : PerformanceRoyalty);
                                    one.Reward = decimal.Parse(Reward == "" ? "0" : Reward);
                                    one.Subsidies = decimal.Parse(Subsidies == "" ? "0" : Subsidies);
                                    one.BasePayDebit = decimal.Parse(BasePayDebit == "" ? "0" : BasePayDebit);
                                    one.AbsenceDutyDebit = decimal.Parse(AbsenceDutyDebit == "" ? "0" : AbsenceDutyDebit);
                                    one.PerformanceCoefficient = decimal.Parse(PerformanceCoefficient == "" ? "0" : PerformanceCoefficient);
                                    one.RealPerformance = decimal.Parse(RealPerformance == "" ? "0" : RealPerformance);
                                    one.Replenishment = decimal.Parse(Replenishment == "" ? "0" : Replenishment);
                                    one.Debit = decimal.Parse(Debit == "" ? "0" : Debit);
                                    one.ShouldSalary = decimal.Parse(ShouldSalary == "" ? "0" : ShouldSalary);
                                    one.Pension = decimal.Parse(Pension == "" ? "0" : Pension);
                                    one.MedicalCare = decimal.Parse(MedicalCare == "" ? "0" : MedicalCare);
                                    one.Unemployment = decimal.Parse(Unemployment == "" ? "0" : Unemployment);
                                    one.AccumulationFund = decimal.Parse(AccumulationFund == "" ? "0" : AccumulationFund);
                                    one.SocialSecurityTotal = decimal.Parse(SocialSecurityTotal == "" ? "0" : SocialSecurityTotal);
                                    one.CommunicationFee = decimal.Parse(CommunicationFee == "" ? "0" : CommunicationFee);
                                    one.IndividualIncomeTax = decimal.Parse(IndividualIncomeTax == "" ? "0" : IndividualIncomeTax);
                                    one.FinanceCharge = decimal.Parse(FinanceCharge == "" ? "0" : FinanceCharge);
                                    one.RealSalary = decimal.Parse(RealSalary == "" ? "0" : RealSalary);
                                    one.Creator = HozestERPContext.Current.User.CustomerID;
                                    one.CreateDate = DateTime.Now;
                                    one.Updater = HozestERPContext.Current.User.CustomerID;
                                    one.UpdateDate = DateTime.Now;
                                    IoC.Resolve<CustomerSalaryService>().InsertCustomerSalary(one);
                                    resultCount++;
                                }
                                else
                                {
                                    paramMessage += "姓名：" + list[0].FullName + "，身份证号码：" + IDNumber + "，该月份薪资数据已存在！\r";
                                }
                            }
                            scope.Complete();
                        }
                    }

                    #endregion

                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 社保公积金
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportSocialSecurityFund(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    int no = 0;
                    DataTable Dt = null;
                    DataTable dt = new DataTable();

                    #region 人员薪资导入
                    Dt = excelHelper.ReadTable("Sheet1");

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (no == 0)
                        {
                            for (int j = 0; j < Dt.Columns.Count; j++)
                            {
                                dt.Columns.Add(new DataColumn(Dt.Rows[i].ItemArray[j].ToString(), typeof(string)));
                            }
                        }
                        else
                        {
                            DataRow tempRow = dt.NewRow();
                            for (int j = 0; j < Dt.Columns.Count; j++)
                            {
                                tempRow[dt.Columns[j].ColumnName] = Dt.Rows[i].ItemArray[j];
                            }
                            dt.Rows.Add(tempRow);
                        }
                        no++;
                    }

                    dt.DefaultView.RowFilter = "身份证号码 is not null and (Convert(身份证号码, 'System.String')<>'' or Convert(身份证号码, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string No = row1["序号"].ToString().Trim();
                            string IDNumber = row1["身份证号码"].ToString().Trim();
                            string Name = row1["姓名"].ToString().Trim();
                            string Deparment = row1["部门"].ToString().Trim();
                            string Year = row1["年份"].ToString().Trim();
                            string Month = row1["月份"].ToString().Trim();
                            string RankManagement = row1["管理职级"].ToString().Trim();
                            string Post = row1["岗位"].ToString().Trim();
                            string HouseholdRegister = row1["户籍"].ToString().Trim();
                            string InsuranceType = row1["险种"].ToString().Trim();
                            string PensionBase = row1["养老基数"].ToString().Trim();
                            string PensionCompany = row1["养老公司部分"].ToString().Trim();
                            string PensionPerson = row1["养老个人部分"].ToString().Trim();
                            string MedicalCareBase = row1["医疗基数"].ToString().Trim();
                            string MedicalCareCompany = row1["医疗公司部分"].ToString().Trim();
                            string MedicalCarePerson = row1["医疗个人部分"].ToString().Trim();
                            string UnemploymentBase = row1["失业基数"].ToString().Trim();
                            string UnemploymentCompany = row1["失业公司部分"].ToString().Trim();
                            string UnemploymentPerson = row1["失业个人部分"].ToString().Trim();
                            string InjuryJobBase = row1["工伤基数"].ToString().Trim();
                            string InjuryJobCompany = row1["工伤公司部分"].ToString().Trim();
                            string BirthBase = row1["生育基数"].ToString().Trim();
                            string BirthCompany = row1["生育公司部分"].ToString().Trim();
                            string AccumulationFundBase = row1["公积金基数"].ToString().Trim();
                            string AccumulationCompany = row1["公积金公司部分"].ToString().Trim();
                            string AccumulationFundPerson = row1["公积金个人部分"].ToString().Trim();
                            string CompanyTotal = row1["公司承担"].ToString().Trim();
                            string PersonTotal = row1["个人承担"].ToString().Trim();
                            string Total = row1["总计"].ToString().Trim();

                            int ToInt = 0;
                            if (int.TryParse(Year, out ToInt) == false || int.TryParse(Month, out ToInt) == false)
                            {
                                paramMessage += "姓名：" + Name + "，身份证：" + IDNumber + "，的年月数据类型错误！\r";
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(IDNumber))
                                {
                                    var Info = IoC.Resolve<ISocialSecurityFundService>().GetCustomerInfoByIDNumber(IDNumber);
                                    if (Info != null && Info.Count > 1)
                                    {
                                        paramMessage += "数据库中与身份证：" + IDNumber + "，匹配的员工记录有多条！具体如下:\r";
                                        foreach (CustomerInfo info in Info)
                                        {
                                            paramMessage += "姓名：" + info.FullName + ",身份证：" + IDNumber + "！\r";
                                        }
                                    }
                                    else if (Info != null && Info.Count > 0)
                                    {
                                        var one = IoC.Resolve<ISocialSecurityFundService>().GetListByYearMonthCustomerInfoID(int.Parse(Year), int.Parse(Month), Info[0].CustomerID);
                                        if (one != null)
                                        {
                                            one.RankManagement = RankManagement;
                                            one.Post = Post;
                                            one.HouseholdRegister = HouseholdRegister;
                                            one.InsuranceType = InsuranceType;
                                            one.PensionBase = decimal.Parse(PensionBase == "" ? "0" : PensionBase.ToString());
                                            one.PensionCompany = decimal.Parse(PensionCompany == "" ? "0" : PensionCompany.ToString());
                                            one.PensionPerson = decimal.Parse(PensionPerson == "" ? "0" : PensionPerson.ToString());
                                            one.MedicalCareBase = decimal.Parse(MedicalCareBase == "" ? "0" : MedicalCareBase.ToString());
                                            one.MedicalCareCompany = decimal.Parse(MedicalCareCompany == "" ? "0" : MedicalCareCompany.ToString());
                                            one.MedicalCarePerson = decimal.Parse(MedicalCarePerson == "" ? "0" : MedicalCarePerson.ToString());
                                            one.UnemploymentBase = decimal.Parse(UnemploymentBase == "" ? "0" : UnemploymentBase.ToString());
                                            one.UnemploymentCompany = decimal.Parse(UnemploymentCompany == "" ? "0" : UnemploymentCompany.ToString());
                                            one.UnemploymentPerson = decimal.Parse(UnemploymentPerson == "" ? "0" : UnemploymentPerson.ToString());
                                            one.InjuryJobBase = decimal.Parse(InjuryJobBase == "" ? "0" : InjuryJobBase.ToString());
                                            one.InjuryJobCompany = decimal.Parse(InjuryJobCompany == "" ? "0" : InjuryJobCompany.ToString());
                                            one.BirthBase = decimal.Parse(BirthBase == "" ? "0" : BirthBase.ToString());
                                            one.BirthCompany = decimal.Parse(BirthCompany == "" ? "0" : BirthCompany.ToString());
                                            one.AccumulationFundBase = decimal.Parse(AccumulationFundBase == "" ? "0" : AccumulationFundBase.ToString());
                                            one.AccumulationCompany = decimal.Parse(AccumulationCompany == "" ? "0" : AccumulationCompany.ToString());
                                            one.AccumulationFundPerson = decimal.Parse(AccumulationFundPerson == "" ? "0" : AccumulationFundPerson.ToString());
                                            one.CompanyTotal = decimal.Parse(CompanyTotal == "" ? "0" : CompanyTotal.ToString());
                                            one.PersonTotal = decimal.Parse(PersonTotal == "" ? "0" : PersonTotal.ToString());
                                            one.Total = decimal.Parse(Total == "" ? "0" : Total.ToString());
                                            one.Updater = HozestERPContext.Current.User.CustomerID;
                                            one.UpdateDate = DateTime.Now;
                                            IoC.Resolve<ISocialSecurityFundService>().UpdateSocialSecurityFund(one);
                                        }
                                        else
                                        {
                                            SocialSecurityFund One = new SocialSecurityFund();
                                            One.CustomerInfoID = Info[0].CustomerID;
                                            One.Year = int.Parse(Year == "" ? "0" : Year.ToString());
                                            One.Month = int.Parse(Month == "" ? "0" : Month.ToString());
                                            One.RankManagement = RankManagement;
                                            One.Post = Post;
                                            One.HouseholdRegister = HouseholdRegister;
                                            One.InsuranceType = InsuranceType;
                                            One.PensionBase = decimal.Parse(PensionBase == "" ? "0" : PensionBase.ToString());
                                            One.PensionCompany = decimal.Parse(PensionCompany == "" ? "0" : PensionCompany.ToString());
                                            One.PensionPerson = decimal.Parse(PensionPerson == "" ? "0" : PensionPerson.ToString());
                                            One.MedicalCareBase = decimal.Parse(MedicalCareBase == "" ? "0" : MedicalCareBase.ToString());
                                            One.MedicalCareCompany = decimal.Parse(MedicalCareCompany == "" ? "0" : MedicalCareCompany.ToString());
                                            One.MedicalCarePerson = decimal.Parse(MedicalCarePerson == "" ? "0" : MedicalCarePerson.ToString());
                                            One.UnemploymentBase = decimal.Parse(UnemploymentBase == "" ? "0" : UnemploymentBase.ToString());
                                            One.UnemploymentCompany = decimal.Parse(UnemploymentCompany == "" ? "0" : UnemploymentCompany.ToString());
                                            One.UnemploymentPerson = decimal.Parse(UnemploymentPerson == "" ? "0" : UnemploymentPerson.ToString());
                                            One.InjuryJobBase = decimal.Parse(InjuryJobBase == "" ? "0" : InjuryJobBase.ToString());
                                            One.InjuryJobCompany = decimal.Parse(InjuryJobCompany == "" ? "0" : InjuryJobCompany.ToString());
                                            One.BirthBase = decimal.Parse(BirthBase == "" ? "0" : BirthBase.ToString());
                                            One.BirthCompany = decimal.Parse(BirthCompany == "" ? "0" : BirthCompany.ToString());
                                            One.AccumulationFundBase = decimal.Parse(AccumulationFundBase == "" ? "0" : AccumulationFundBase.ToString());
                                            One.AccumulationCompany = decimal.Parse(AccumulationCompany == "" ? "0" : AccumulationCompany.ToString());
                                            One.AccumulationFundPerson = decimal.Parse(AccumulationFundPerson == "" ? "0" : AccumulationFundPerson.ToString());
                                            One.CompanyTotal = decimal.Parse(CompanyTotal == "" ? "0" : CompanyTotal.ToString());
                                            One.PersonTotal = decimal.Parse(PersonTotal == "" ? "0" : PersonTotal.ToString());
                                            One.Total = decimal.Parse(Total == "" ? "0" : Total.ToString());
                                            One.IsEnabled = false;
                                            One.Creator = HozestERPContext.Current.User.CustomerID;
                                            One.CreateDate = DateTime.Now;
                                            One.Updater = HozestERPContext.Current.User.CustomerID;
                                            One.UpdateDate = DateTime.Now;
                                            IoC.Resolve<ISocialSecurityFundService>().InsertSocialSecurityFund(One);
                                        }
                                        resultCount++;
                                    }
                                    else
                                    {
                                        paramMessage += "数据库中找不到与姓名：" + Name + "，身份证：" + IDNumber + "，匹配的员工记录！\r";
                                    }
                                }
                                else
                                {
                                    paramMessage += "身份证，年份，月份信息不能为空！\r";
                                }
                            }
                            scope.Complete();
                        }
                    }

                    #endregion

                    if (dt != null)
                    {
                        int TotalCount = dt.Rows.Count;
                        if (resultCount == TotalCount)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + TotalCount + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// B2B导入发货
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportBusinessDataB2B(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;

                    #region B2B导入发货
                    dt = excelHelper.ReadTable("Sheet1");
                    dt.DefaultView.RowFilter = "合同编号 is not null and (Convert(合同编号, 'System.String')<>'' or Convert(合同编号, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string ContractNumber = row1["合同编号"].ToString().Trim();
                            string ContractAmount = row1["合同金额"].ToString().Trim();
                            string ClientCompany = row1["客户公司"].ToString().Trim();
                            string DomainName = row1["域名"].ToString().Trim();
                            string BusinessTypeName = row1["业务类型"].ToString().Trim();
                            string SubmitDate = row1["提交时间"].ToString().Trim();
                            string SubmitLimit = row1["提交年限"].ToString().Trim();
                            string Receivables = row1["收款"].ToString().Trim();
                            string Cost = row1["成本"].ToString().Trim();
                            string BelongingName = row1["归属人"].ToString().Trim();
                            string Remark1 = row1["备注1"].ToString().Trim();
                            string Remark2 = row1["备注2"].ToString().Trim();
                            string PayPerson = row1["打款人"].ToString().Trim();
                            Receivables = Receivables == "0" ? "" : Receivables;
                            Cost = Cost == "0" ? "" : Cost;

                            if (!string.IsNullOrEmpty(ContractNumber))
                            {
                                XMBusinessData data = new XMBusinessData();
                                var list = IoC.Resolve<XMBusinessDataService>().GetXMBusinessDataListByContractNumber(ContractNumber);
                                if (list != null && list.Count > 0)
                                {
                                    data = list[0];
                                    //    if (!string.IsNullOrEmpty(Receivables))
                                    //    {
                                    //        data.ActualAmount = data.ActualAmount + decimal.Parse(Receivables);
                                    //    }
                                    //    data.Updater = HozestERPContext.Current.User.CustomerID;
                                    //    data.UpdateDate = DateTime.Now;
                                    //    IoC.Resolve<XMBusinessDataService>().UpdateXMBusinessData(data);
                                }
                                else
                                {
                                    data.ContractNumber = ContractNumber;
                                    data.ContractAmount = decimal.Parse(ContractAmount == "" ? "0" : ContractAmount);
                                    data.ClientCompany = ClientCompany;
                                    data.PayPerson = PayPerson;
                                    data.SubmitLimit = SubmitLimit == "" ? "0" : SubmitLimit;
                                    data.SubmitDate = DateTime.Parse(SubmitDate == "" ? null : SubmitDate);
                                    //if (!string.IsNullOrEmpty(Receivables))
                                    //{
                                    //    data.ActualAmount = decimal.Parse(Receivables);
                                    //}
                                    //else
                                    //{
                                    data.ActualAmount = 0;
                                    //}
                                    data.BelongingDepID = 297;
                                    data.IsEnabled = false;
                                    data.Creator = HozestERPContext.Current.User.CustomerID;
                                    data.CreateDate = DateTime.Now;
                                    data.Updater = HozestERPContext.Current.User.CustomerID;
                                    data.UpdateDate = DateTime.Now;
                                    IoC.Resolve<XMBusinessDataService>().InsertXMBusinessData(data);
                                }

                                XMBusinessDataDetail detail = new XMBusinessDataDetail();
                                detail.BusinessDataID = data.ID;
                                detail.DomainName = DomainName;
                                var TypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(215);
                                if (TypeList != null && TypeList.Count > 0)
                                {
                                    foreach (CodeList info in TypeList)
                                    {
                                        if (info.CodeName.Contains(BusinessTypeName))
                                        {
                                            detail.BusinessType = info.CodeID;
                                            break;
                                        }
                                    }
                                }
                                detail.BelongingName = BelongingName;
                                detail.Remark1 = Remark1;
                                detail.Remark2 = Remark2;
                                detail.IsEnabled = false;
                                detail.Creator = HozestERPContext.Current.User.CustomerID;
                                detail.CreateDate = DateTime.Now;
                                detail.Updater = HozestERPContext.Current.User.CustomerID;
                                detail.UpdateDate = DateTime.Now;
                                var AmountTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(214);
                                if (!string.IsNullOrEmpty(Receivables) || !string.IsNullOrEmpty(Cost))
                                {
                                    if (!string.IsNullOrEmpty(Receivables))
                                    {
                                        detail.AmountType = AmountTypeList[1].CodeID;//收款
                                        detail.Amount = decimal.Parse(Receivables);
                                        detail.FinancialStatus = false;
                                        IoC.Resolve<XMBusinessDataDetailService>().InsertXMBusinessDataDetail(detail);
                                    }
                                    if (!string.IsNullOrEmpty(Cost))
                                    {
                                        XMBusinessDataDetail Detail = new XMBusinessDataDetail();
                                        Detail.BusinessType = detail.BusinessType;
                                        Detail.BelongingName = detail.BelongingName.Replace("，", ",");
                                        Detail.Remark1 = detail.Remark1;
                                        Detail.Remark2 = detail.Remark2;
                                        Detail.IsEnabled = detail.IsEnabled;
                                        Detail.Creator = detail.Creator;
                                        Detail.CreateDate = detail.CreateDate;
                                        Detail.Updater = detail.Updater;
                                        Detail.UpdateDate = detail.UpdateDate;
                                        Detail.BusinessDataID = detail.BusinessDataID;
                                        Detail.DomainName = detail.DomainName;
                                        Detail.AmountType = AmountTypeList[0].CodeID;//支付
                                        Detail.Amount = decimal.Parse(Cost);
                                        Detail.FinancialStatus = true;
                                        Detail.AuditDate = DateTime.Now;
                                        IoC.Resolve<XMBusinessDataDetailService>().InsertXMBusinessDataDetail(Detail);
                                    }
                                }
                                else
                                {
                                    XMBusinessDataDetail Detail = new XMBusinessDataDetail();
                                    Detail.BusinessType = detail.BusinessType;
                                    Detail.BelongingName = detail.BelongingName.Replace("，", ",");
                                    Detail.Remark1 = detail.Remark1;
                                    Detail.Remark2 = detail.Remark2;
                                    Detail.IsEnabled = detail.IsEnabled;
                                    Detail.Creator = detail.Creator;
                                    Detail.CreateDate = detail.CreateDate;
                                    Detail.Updater = detail.Updater;
                                    Detail.UpdateDate = detail.UpdateDate;
                                    Detail.BusinessDataID = detail.BusinessDataID;
                                    Detail.DomainName = detail.DomainName;
                                    Detail.AmountType = AmountTypeList[3].CodeID;//赠送
                                    Detail.Amount = 0;
                                    Detail.FinancialStatus = true;
                                    Detail.AuditDate = DateTime.Now;
                                    IoC.Resolve<XMBusinessDataDetailService>().InsertXMBusinessDataDetail(Detail);
                                }

                                resultCount++;
                            }
                            else
                            {
                                paramMessage += "合同编号：不能为空！\r";
                            }

                            scope.Complete();
                        }
                    }

                    #endregion

                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 产品导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportProductList(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;

                    #region 产品导入
                    dt = excelHelper.ReadTable("Sheet1");
                    dt.DefaultView.RowFilter = "厂家编码 is not null and (Convert(厂家编码, 'System.String')<>'' or Convert(厂家编码, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    var suppliersList = IoC.Resolve<IXMSuppliersService>().GetXMSuppliersList().ToDictionary(m=>m.SupplierName, m=>m.Id);

                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            //主表
                            int a = 0;
                            decimal b = 0;
                            DateTime d = DateTime.Now;
                            int ProductID = 0;
                            string BrandType = row1["品牌"].ToString().Trim();
                            int BrandTypeId = 0;
                            string ProductName = row1["产品名称"].ToString().Trim();
                            string ManufacturersCode = row1["厂家编码"].ToString().Trim();
                            string Specifications = row1["尺寸"].ToString().Trim();
                            string Series = row1["系列"].ToString().Trim();
                            string ManufacturersInventory = row1["厂家库存"].ToString().Trim();
                            string WarningQuantity = row1["预警库存数"].ToString().Trim();
                            if (WarningQuantity == "")
                            {
                                WarningQuantity = "0";
                            }
                            int IntManufacturersInventory = 0;
                            int IntWarningQuantity = 0;
                            string ProductColors = row1["颜色"].ToString().Trim();
                            string ProductUnit = row1["计量单位"].ToString().Trim();
                            string ProductWeight = row1["体重"].ToString().Trim();
                            string ProductVolume = row1["体积"].ToString().Trim();
                            string IsPremiums = row1["是否赠品"].ToString().Trim();
                            string Shipper = row1["发货方"].ToString().Trim();
                            int IntShipper = 0;
                            string SuppliersName = row1["供应商"] == null ? string.Empty : row1["供应商"].ToString().Trim();
                            int SuppliersID = suppliersList.Keys.Contains(SuppliersName) ? suppliersList[SuppliersName] : -1;
                            if (SuppliersID == -1)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',系统中没有对应的供应商！\r";
                                continue;
                            }
                            //从表
                            string PlatformType = row1["平台类型"].ToString().Trim();
                            int PlatformTypeId = 0;
                            string PlatformMerchantCode = row1["商品编码"].ToString().Trim();
                            string Color = row1["颜色"].ToString().Trim();
                            string ProductType = row1["产品类型"].ToString().Trim();
                            int ProductTypeId = 0;
                            string PlatformInventory = row1["平台库存"].ToString().Trim();
                            int IntPlatformInventory = 0;
                            string strUrl = row1["链接"].ToString().Trim();
                            string Costprice = row1["出厂价"].ToString().Trim();
                            string Saleprice = row1["销售价"].ToString().Trim();
                            string TCostprice = row1["特供价"].ToString().Trim();
                            decimal decimalCostprice = 0;
                            decimal decimalSaleprice = 0;
                            decimal decimalTCostprice = 0;
                            string TDateTimeStart = row1["开始日期"].ToString().Trim();
                            string TDateTimeEnd = row1["结束日期"].ToString().Trim();
                            string IsMainPush = row1["主推"].ToString().Trim();
                          
                            #region 主表长度限制
                            if (ProductName.Length > 20)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',产品名称的字符长度不能大于20个！\r";
                                continue;
                            }
                            if (ManufacturersCode.Length > 50)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',厂家编码的字符长度不能大于50个！\r";
                                continue;
                            }
                            if (Specifications.Length > 20)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',尺寸的字符长度不能大于20个！\r";
                                continue;
                            }
                            if (ManufacturersInventory.Length > 8)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',厂家库存的字符长度不能大于8个！\r";
                                continue;
                            }
                            if (WarningQuantity.Length > 8)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',预警库存数的字符长度不能大于8个！\r";
                                continue;
                            }
                            if (ProductColors.Length > 20)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',产品颜色的字符长度不能大于20个！\r";
                                continue;
                            }
                            if (ProductUnit.Length > 5)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',计量单位的字符长度不能大于5个！\r";
                                continue;
                            }
                            if (ProductWeight.Length > 5)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',体重的字符长度不能大于5个！\r";
                                continue;
                            }
                            if (ProductVolume.Length > 5)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',体积的字符长度不能大于5个！\r";
                                continue;
                            }
                            #endregion

                            #region 主表数据限制
                            if (ProductName == "")
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',产品名称不能为空！\r";
                                continue;
                            }
                            if (ManufacturersCode == "")
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',厂家编码不能为空！\r";
                                continue;
                            }
                            if (Specifications == "")
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',尺寸不能为空！\r";
                                continue;
                            }
                            if (ManufacturersInventory == "")
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',厂家库存不能为空！\r";
                                continue;
                            }
                            # endregion

                            #region 从表长度限制
                            if (Color.Length > 10)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',颜色的字符长度不能大于10个！\r";
                                continue;
                            }
                            if (PlatformInventory.Length > 20)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',平台库存的字符长度不能大于20个！\r";
                                continue;
                            }
                            if (TCostprice.Length > 8)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',特供价的字符长度不能大于8个！\r";
                                continue;
                            }
                            #endregion

                            #region 数据类型判断

                            var ShipperList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(226);//发货方
                            if (ShipperList.Count > 0)
                            {
                                IntShipper = ShipperList[0].CodeID;//默认第一个
                                foreach (CodeList Info in ShipperList)
                                {
                                    if (Shipper == Info.CodeName)
                                    {
                                        IntShipper = Info.CodeID;
                                        break;
                                    }
                                }
                            }

                            var BrandTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(187);
                            if (BrandTypeList.Count > 0)
                            {
                                foreach (CodeList Info in BrandTypeList)
                                {
                                    if (BrandType == Info.CodeName)
                                    {
                                        BrandTypeId = Info.CodeID;
                                        break;
                                    }
                                }
                            }
                            if (BrandTypeId == 0)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',品牌名称不正确！\r";
                                continue;
                            }

                            if (int.TryParse(ManufacturersInventory, out a) == false)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',厂家库存数据类型不正确！\r";
                                continue;
                            }
                            int.TryParse(ManufacturersInventory, out IntManufacturersInventory);

                            if (int.TryParse(WarningQuantity, out a) == false)
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',预警库存数数据类型不正确！\r";
                                continue;
                            }
                            int.TryParse(WarningQuantity, out IntWarningQuantity);

                            if (IsPremiums != "是" && IsPremiums != "否")
                            {
                                paramMessage += "厂家编码：'" + ManufacturersCode + "',是否赠品数据类型不正确！\r";
                                continue;
                            }


                            var PlatformTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(182);
                            if (PlatformTypeList.Count > 0)
                            {
                                foreach (CodeList Info in PlatformTypeList)
                                {
                                    if (PlatformType == Info.CodeName)
                                    {
                                        PlatformTypeId = Info.CodeID;
                                        break;
                                    }
                                }
                            }
                            if (PlatformTypeId == 0)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',平台类型名称不正确！\r";
                                continue;
                            }

                            var ProductTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(188);
                            if (ProductTypeList.Count > 0)
                            {
                                foreach (CodeList Info in ProductTypeList)
                                {
                                    if (ProductType == Info.CodeName)
                                    {
                                        ProductTypeId = Info.CodeID;
                                        break;
                                    }
                                }
                            }
                            if (ProductTypeId == 0)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',产品类型名称不正确！\r";
                                continue;
                            }

                            if (int.TryParse(PlatformInventory, out a) == false)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',平台库存数数据类型不正确！\r";
                                continue;
                            }
                            int.TryParse(PlatformInventory, out IntPlatformInventory);

                            if (decimal.TryParse(Costprice, out b) == false)
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',出厂价数据类型不正确！\r";
                                continue;
                            }
                            decimal.TryParse(Costprice, out decimalCostprice);

                            if (Saleprice != "")
                            {
                                if (decimal.TryParse(Saleprice, out b) == false)
                                {
                                    paramMessage += "商品编码：'" + PlatformMerchantCode + "',销售价数据类型不正确！\r";
                                    continue;
                                }
                                decimal.TryParse(Saleprice, out decimalSaleprice);
                            }

                            if (TCostprice != "")
                            {
                                if (decimal.TryParse(TCostprice, out b) == false)
                                {
                                    paramMessage += "商品编码：'" + PlatformMerchantCode + "',特供价数据类型不正确！\r";
                                    continue;
                                }
                                decimal.TryParse(TCostprice, out decimalTCostprice);
                            }

                            if (IsMainPush != "是" && IsMainPush != "否")
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',是否主推数据类型不正确！\r";
                                continue;
                            }

                            if (TDateTimeStart != "")
                            {
                                if (DateTime.TryParse(TDateTimeStart, out d) == false)
                                {
                                    paramMessage += "商品编码：'" + PlatformMerchantCode + "',开始日期数据类型不正确！\r";
                                    continue;
                                }
                            }

                            if (TDateTimeEnd != "")
                            {
                                if (DateTime.TryParse(TDateTimeEnd, out d) == false)
                                {
                                    paramMessage += "商品编码：'" + PlatformMerchantCode + "',结束日期数据类型不正确！\r";
                                    continue;
                                }
                            }
                            #endregion

                            var product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                            if (product == null)
                            {
                                //var ProductList = IoC.Resolve<IXMProductService>().getXMProductListByEqusManufacturersCode(ManufacturersCode);
                                //if (ProductList.Count > 0)
                                //{
                                //    paramMessage += "厂家编码：'" + ManufacturersCode + "',该厂家编码已存在！\r";
                                //    continue;
                                //}
                                XMProduct ProductNew = new XMProduct();
                                ProductNew.BrandTypeId = BrandTypeId;
                                ProductNew.ProductName = ProductName;
                                ProductNew.ManufacturersCode = ManufacturersCode;
                                ProductNew.Specifications = Specifications;
                                ProductNew.ManufacturersInventory = IntManufacturersInventory;
                                ProductNew.WarningQuantity = IntWarningQuantity;
                                ProductNew.Series = Series;
                                ProductNew.ProductColors = ProductColors;
                                ProductNew.ProductUnit = ProductUnit;
                                ProductNew.ProductWeight = ProductWeight;
                                ProductNew.ProductVolume = ProductVolume;
                                ProductNew.Shipper = IntShipper;
                                ProductNew.IsPremiums = IsPremiums == "是" ? true : false;
                                ProductNew.IsEnable = false;//默认可用
                                ProductNew.CreateID = HozestERPContext.Current.User.CustomerID;
                                ProductNew.CreateDate = DateTime.Now;
                                ProductNew.UpdateID = HozestERPContext.Current.User.CustomerID;
                                ProductNew.UpdateDate = DateTime.Now;
                                ProductNew.SuppliersID = SuppliersID;
                                //新增产品
                                IoC.Resolve<IXMProductService>().InsertXMProduct(ProductNew);
                                ProductID = ProductNew.Id;
                            }
                            else
                            {
                                ProductID = product.Id;
                            }

                            var productDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(PlatformMerchantCode, PlatformTypeId, Color);
                            if (productDetail.Count == 0)
                            {
                                var productdetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(PlatformMerchantCode, -1, "");
                                if (productdetail.Count > 0)
                                {
                                    paramMessage += "商品编码：'" + PlatformMerchantCode + "',该商品编码已存在！\r";
                                    continue;
                                }
                                XMProductDetails xMProductDetailsNew = new XMProductDetails();
                                xMProductDetailsNew.ProductId = ProductID;
                                xMProductDetailsNew.PlatformTypeId = PlatformTypeId;
                                xMProductDetailsNew.PlatformMerchantCode = PlatformMerchantCode;
                                xMProductDetailsNew.ProductTypeId = ProductTypeId;
                                xMProductDetailsNew.PlatformInventory = IntPlatformInventory;
                                xMProductDetailsNew.Color = Color;
                                xMProductDetailsNew.strUrl = strUrl;
                                xMProductDetailsNew.Costprice = decimalCostprice;
                                xMProductDetailsNew.Saleprice = decimalSaleprice;
                                xMProductDetailsNew.TCostprice = decimalTCostprice;
                                if (TDateTimeStart != "")
                                {
                                    xMProductDetailsNew.TDateTimeStart = Convert.ToDateTime(TDateTimeStart);
                                }
                                if (TDateTimeEnd != "")
                                {
                                    xMProductDetailsNew.TDateTimeEnd = Convert.ToDateTime(TDateTimeEnd).AddDays(+1).AddMinutes(-1);
                                }
                                xMProductDetailsNew.IsMainPush = IsMainPush == "是" ? true : false;
                                xMProductDetailsNew.IsEnable = false;
                                xMProductDetailsNew.CreateID = HozestERPContext.Current.User.CustomerID;
                                xMProductDetailsNew.CreateDate = DateTime.Now;
                                xMProductDetailsNew.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xMProductDetailsNew.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMProductDetailsService>().InsertXMProductDetails(xMProductDetailsNew);

                                resultCount++;
                            }
                            else
                            {
                                paramMessage += "商品编码：'" + PlatformMerchantCode + "',该平台的该颜色的商品编码已存在！\r";
                                continue;
                            }
                            scope.Complete();
                        }
                    }

                    #endregion

                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }

        public void ImportFinancialCost(string filePath, ref string paramMessage, int projectID, int depID, int year)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";

                    DataTable dt = null;

                    #region 预算数据导入
                    dt = excelHelper.ReadTable("字段预算录入");
                    dt = dt.DefaultView.ToTable();

                    //项目导入
                    if (projectID != 0)
                    {
                        int resultCount = 0;
                        foreach (DataRow row1 in dt.Rows)
                        {
                            using (TransactionScope scope = new TransactionScope())
                            {
                                string fID = row1["字段ID"].ToString().Trim();
                                string filename = row1["项目"].ToString().Trim();
                                string onemonthcost = row1["1月份"].ToString().Trim();
                                string twomonthcost = row1["2月份"].ToString().Trim();
                                string threemonthcost = row1["3月份"].ToString().Trim();
                                string fourmonthcost = row1["4月份"].ToString().Trim();
                                string fivemonthcost = row1["5月份"].ToString().Trim();
                                string sixmonthcost = row1["6月份"].ToString().Trim();
                                string sevenmonthcost = row1["7月份"].ToString().Trim();
                                string eightmonthcost = row1["8月份"].ToString().Trim();
                                string ninemonthcost = row1["9月份"].ToString().Trim();
                                string tenmonthcost = row1["10月份"].ToString().Trim();
                                string elvenmonthcost = row1["11月份"].ToString().Trim();
                                string tewlvemonthcost = row1["12月份"].ToString().Trim();
                                //查询当前年份字段数据是否存在，不存在新增，存再更新
                                var cost = IoC.Resolve<IXMProjectCostDetailService>().GetXMProjectCostDataByParm(int.Parse(fID), projectID, year);
                                //更新数据
                                if (cost != null)
                                {
                                    cost.OneMonthCost = onemonthcost != "" ? decimal.Parse(onemonthcost) : 0;
                                    cost.TwoMonthCost = twomonthcost != "" ? decimal.Parse(twomonthcost) : 0;
                                    cost.ThreeMonthCost = threemonthcost != "" ? decimal.Parse(threemonthcost) : 0;
                                    cost.FourMonthCost = fourmonthcost != "" ? decimal.Parse(fourmonthcost) : 0;
                                    cost.FiveMonthCost = fivemonthcost != "" ? decimal.Parse(fivemonthcost) : 0;
                                    cost.SixMonthCost = sixmonthcost != "" ? decimal.Parse(sixmonthcost) : 0;
                                    cost.SevenMonthCost = sevenmonthcost != "" ? decimal.Parse(sevenmonthcost) : 0;
                                    cost.EightMonthCost = eightmonthcost != "" ? decimal.Parse(eightmonthcost) : 0;
                                    cost.NineMonthCost = ninemonthcost != "" ? decimal.Parse(ninemonthcost) : 0;
                                    cost.TenMonthCost = tenmonthcost != "" ? decimal.Parse(tenmonthcost) : 0;
                                    cost.ElevenMonthCost = elvenmonthcost != "" ? decimal.Parse(elvenmonthcost) : 0;
                                    cost.TwelMonthCost = tewlvemonthcost != "" ? decimal.Parse(tewlvemonthcost) : 0;
                                    cost.UpdateDate = DateTime.Now;
                                    cost.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMProjectCostDetailService>().UpdateXMProjectCostDetail(cost);
                                    resultCount++;
                                }
                                else                                                                                                                 //为null新增数据
                                {
                                    XMProjectCostDetail detail = new XMProjectCostDetail();
                                    detail.FinancialFieldID = int.Parse(fID);
                                    detail.ProjectId = projectID;
                                    detail.Year = year;
                                    detail.OneMonthCost = onemonthcost != "" ? decimal.Parse(onemonthcost) : 0;
                                    detail.TwoMonthCost = twomonthcost != "" ? decimal.Parse(twomonthcost) : 0;
                                    detail.ThreeMonthCost = threemonthcost != "" ? decimal.Parse(threemonthcost) : 0;
                                    detail.FourMonthCost = fourmonthcost != "" ? decimal.Parse(fourmonthcost) : 0;
                                    detail.FiveMonthCost = fivemonthcost != "" ? decimal.Parse(fivemonthcost) : 0;
                                    detail.SixMonthCost = sixmonthcost != "" ? decimal.Parse(sixmonthcost) : 0;
                                    detail.SevenMonthCost = sevenmonthcost != "" ? decimal.Parse(sevenmonthcost) : 0;
                                    detail.EightMonthCost = eightmonthcost != "" ? decimal.Parse(eightmonthcost) : 0;
                                    detail.NineMonthCost = ninemonthcost != "" ? decimal.Parse(ninemonthcost) : 0;
                                    detail.TenMonthCost = tenmonthcost != "" ? decimal.Parse(tenmonthcost) : 0;
                                    detail.ElevenMonthCost = elvenmonthcost != "" ? decimal.Parse(elvenmonthcost) : 0;
                                    detail.TwelMonthCost = tewlvemonthcost != "" ? decimal.Parse(tewlvemonthcost) : 0;
                                    detail.CreateDate = DateTime.Now;
                                    detail.CreateID = HozestERPContext.Current.User.CustomerID;
                                    detail.UpdateDate = DateTime.Now;
                                    detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMProjectCostDetailService>().InsertXMProjectCostDetail(detail);
                                    resultCount++;
                                }
                                scope.Complete();
                            }
                        }
                        if (dt != null)
                        {
                            if (resultCount == dt.Rows.Count)
                            {
                                if (paramMessage == "")
                                {
                                    paramMessage = "导入成功！";
                                }
                            }
                            else
                            {
                                paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                            }
                        }
                    }

                    //导入B2B或B2C数据
                    if (depID != 0)
                    {
                        int resultCount = 0;
                        foreach (DataRow row1 in dt.Rows)
                        {
                            using (TransactionScope scope = new TransactionScope())
                            {
                                string fID = row1["字段ID"].ToString().Trim();
                                string filename = row1["项目"].ToString().Trim();
                                string onemonthcost = row1["1月份"].ToString().Trim();
                                string twomonthcost = row1["2月份"].ToString().Trim();
                                string threemonthcost = row1["3月份"].ToString().Trim();
                                string fourmonthcost = row1["4月份"].ToString().Trim();
                                string fivemonthcost = row1["5月份"].ToString().Trim();
                                string sixmonthcost = row1["6月份"].ToString().Trim();
                                string sevenmonthcost = row1["7月份"].ToString().Trim();
                                string eightmonthcost = row1["8月份"].ToString().Trim();
                                string ninemonthcost = row1["9月份"].ToString().Trim();
                                string tenmonthcost = row1["10月份"].ToString().Trim();
                                string elvenmonthcost = row1["11月份"].ToString().Trim();
                                string tewlvemonthcost = row1["12月份"].ToString().Trim();
                                //查询当前年份字段数据是否存在，不存在新增，存再更新
                                var cost = IoC.Resolve<IXMOtherCostDetailService>().GetXMOtherCostDataByParm(int.Parse(fID), depID, year);
                                //更新数据
                                if (cost != null)
                                {
                                    cost.OneMonthCost = onemonthcost != "" ? decimal.Parse(onemonthcost) : 0;
                                    cost.TwoMonthCost = twomonthcost != "" ? decimal.Parse(twomonthcost) : 0;
                                    cost.ThreeMonthCost = threemonthcost != "" ? decimal.Parse(threemonthcost) : 0;
                                    cost.FourMonthCost = fourmonthcost != "" ? decimal.Parse(fourmonthcost) : 0;
                                    cost.FiveMonthCost = fivemonthcost != "" ? decimal.Parse(fivemonthcost) : 0;
                                    cost.SixMonthCost = sixmonthcost != "" ? decimal.Parse(sixmonthcost) : 0;
                                    cost.SevenMonthCost = sevenmonthcost != "" ? decimal.Parse(sevenmonthcost) : 0;
                                    cost.EightMonthCost = eightmonthcost != "" ? decimal.Parse(eightmonthcost) : 0;
                                    cost.NineMonthCost = ninemonthcost != "" ? decimal.Parse(ninemonthcost) : 0;
                                    cost.TenMonthCost = tenmonthcost != "" ? decimal.Parse(tenmonthcost) : 0;
                                    cost.ElevenMonthCost = elvenmonthcost != "" ? decimal.Parse(elvenmonthcost) : 0;
                                    cost.TwelMonthCost = tewlvemonthcost != "" ? decimal.Parse(tewlvemonthcost) : 0;
                                    cost.UpdateDate = DateTime.Now;
                                    cost.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOtherCostDetailService>().UpdateXMOtherCostDetail(cost);
                                    resultCount++;
                                }
                                else                                                                                                                 //为null新增数据
                                {
                                    XMOtherCostDetail detail = new XMOtherCostDetail();
                                    detail.FinancialFieldID = int.Parse(fID);
                                    detail.DepartmentID = depID;
                                    detail.Year = year;
                                    detail.OneMonthCost = onemonthcost != "" ? decimal.Parse(onemonthcost) : 0;
                                    detail.TwoMonthCost = twomonthcost != "" ? decimal.Parse(twomonthcost) : 0;
                                    detail.ThreeMonthCost = threemonthcost != "" ? decimal.Parse(threemonthcost) : 0;
                                    detail.FourMonthCost = fourmonthcost != "" ? decimal.Parse(fourmonthcost) : 0;
                                    detail.FiveMonthCost = fivemonthcost != "" ? decimal.Parse(fivemonthcost) : 0;
                                    detail.SixMonthCost = sixmonthcost != "" ? decimal.Parse(sixmonthcost) : 0;
                                    detail.SevenMonthCost = sevenmonthcost != "" ? decimal.Parse(sevenmonthcost) : 0;
                                    detail.EightMonthCost = eightmonthcost != "" ? decimal.Parse(eightmonthcost) : 0;
                                    detail.NineMonthCost = ninemonthcost != "" ? decimal.Parse(ninemonthcost) : 0;
                                    detail.TenMonthCost = tenmonthcost != "" ? decimal.Parse(tenmonthcost) : 0;
                                    detail.ElevenMonthCost = elvenmonthcost != "" ? decimal.Parse(elvenmonthcost) : 0;
                                    detail.TwelMonthCost = tewlvemonthcost != "" ? decimal.Parse(tewlvemonthcost) : 0;
                                    detail.CreateDate = DateTime.Now;
                                    detail.CreateID = HozestERPContext.Current.User.CustomerID;
                                    detail.UpdateDate = DateTime.Now;
                                    detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    IoC.Resolve<IXMOtherCostDetailService>().InsertXMOtherCostDetail(detail);
                                    resultCount++;
                                }
                                scope.Complete();
                            }
                        }
                        if (dt != null)
                        {
                            if (resultCount == dt.Rows.Count)
                            {
                                if (paramMessage == "")
                                {
                                    paramMessage = "导入成功！";
                                }
                            }
                            else
                            {
                                paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                            }
                        }
                    }
                }
                    #endregion
            }
        }

        /// <summary>
        /// 物流时效导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportLogisticsAging(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;
                    DataTable Dt = null;

                    #region 物流时效导入
                    dt = excelHelper.ReadTable("南方");
                    dt.DefaultView.RowFilter = "线路 is not null and (Convert(线路, 'System.String')<>'' or Convert(线路, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    Dt = excelHelper.ReadTable("北方");
                    Dt.DefaultView.RowFilter = "线路 is not null and (Convert(线路, 'System.String')<>'' or Convert(线路, 'System.Int32')>0)";
                    Dt = Dt.DefaultView.ToTable();

                    #region 南方
                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string Line = row1["线路"].ToString().Trim();
                            string DepartureProvince = row1["始发省"].ToString().Trim();
                            string DepartureCity = row1["始发城市"].ToString().Trim();
                            string Pathway = row1["途径地"].ToString().Trim() == "无" ? "" : row1["途径地"].ToString().Trim();
                            string PathwayDate = row1["预计到达时效1"].ToString().Trim();
                            string DestinationProvince = row1["目的省"].ToString().Trim();
                            string DestinationCity = row1["目的市"].ToString().Trim();
                            string DestinationDate = row1["预计到达时效2"].ToString().Trim();

                            int ToInt = 0;
                            if ((Pathway != "" && int.TryParse(PathwayDate, out ToInt) == false) || int.TryParse(DestinationDate, out ToInt) == false)
                            {
                                paramMessage += "始发城市：" + DepartureCity + ",途径城市：" + Pathway + ",目的城市:" + DestinationCity + ",的预计到达时间必须为整数！\r\n";
                            }
                            else if (DepartureProvince == "" || DepartureCity == "" || DestinationProvince == ""
                                || DestinationCity == "" || DestinationDate == "")
                            {
                                paramMessage += "始发城市：" + DepartureCity + ",途径城市：" + Pathway + ",目的城市:" + DestinationCity + ",数据不能为空，请先填写数据！\r\n";
                            }
                            else
                            {
                                List<LogisticsAging> list = new List<LogisticsAging>();
                                list = IoC.Resolve<ILogisticsAgingService>().GetLogisticsAgingListByParam(DepartureCity, DestinationCity, "-1");

                                if (list != null && list.Count > 0)
                                {
                                    LogisticsAging Info = list[0];
                                    Info.Line = Line;
                                    Info.DepartureProvince = DepartureProvince;
                                    Info.DepartureCity = DepartureCity;
                                    if (Pathway != "")
                                    {
                                        Info.Pathway = Pathway;
                                        Info.PathwayDate = int.Parse(PathwayDate);
                                    }
                                    else
                                    {
                                        Info.Pathway = "";
                                        Info.PathwayDate = null;
                                    }
                                    Info.DestinationProvince = DestinationProvince;
                                    Info.DestinationCity = DestinationCity;
                                    Info.DestinationDate = int.Parse(DestinationDate);
                                    Info.IsSouth = true;//南方
                                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    Info.UpdateTime = DateTime.Now;
                                    IoC.Resolve<ILogisticsAgingService>().UpdateLogisticsAging(Info);
                                }
                                else
                                {
                                    LogisticsAging Info = new LogisticsAging();
                                    Info.Line = Line;
                                    Info.DepartureProvince = DepartureProvince;
                                    Info.DepartureCity = DepartureCity;
                                    if (Pathway != "")
                                    {
                                        Info.Pathway = Pathway;
                                        Info.PathwayDate = int.Parse(PathwayDate);
                                    }
                                    else
                                    {
                                        Info.Pathway = "";
                                        Info.PathwayDate = null;
                                    }
                                    Info.DestinationProvince = DestinationProvince;
                                    Info.DestinationCity = DestinationCity;
                                    Info.DestinationDate = int.Parse(DestinationDate);
                                    Info.IsSouth = true;//南方
                                    Info.IsEnabled = false;
                                    Info.CreatorID = HozestERPContext.Current.User.CustomerID;
                                    Info.CreateTime = DateTime.Now;
                                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    Info.UpdateTime = DateTime.Now;
                                    IoC.Resolve<ILogisticsAgingService>().InsertLogisticsAging(Info);
                                }
                                resultCount++;
                            }
                            scope.Complete();
                        }
                    }
                    #endregion

                    #region 北方
                    foreach (DataRow row1 in Dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string Line = row1["线路"].ToString().Trim();
                            string DepartureProvince = row1["始发省"].ToString().Trim();
                            string DepartureCity = row1["始发城市"].ToString().Trim();
                            string Pathway = row1["途径地"].ToString().Trim() == "无" ? "" : row1["途径地"].ToString().Trim();
                            string PathwayDate = row1["预计到达时效1"].ToString().Trim();
                            string DestinationProvince = row1["目的省"].ToString().Trim();
                            string DestinationCity = row1["目的市"].ToString().Trim();
                            string DestinationDate = row1["预计到达时效2"].ToString().Trim();

                            int ToInt = 0;
                            if ((Pathway != "" && int.TryParse(PathwayDate, out ToInt) == false) || int.TryParse(DestinationDate, out ToInt) == false)
                            {
                                paramMessage += "始发城市：" + DepartureCity + ",途径城市：" + Pathway + ",目的城市:" + DestinationCity + ",的预计到达时间必须为整数！\r\n";
                            }
                            else if (DepartureProvince == "" || DepartureCity == "" || DestinationProvince == ""
                                || DestinationCity == "" || DestinationDate == "")
                            {
                                paramMessage += "始发城市：" + DepartureCity + ",途径城市：" + Pathway + ",目的城市:" + DestinationCity + ",数据不能为空，请先填写数据！\r\n";
                            }
                            else
                            {
                                List<LogisticsAging> list = new List<LogisticsAging>();
                                list = IoC.Resolve<ILogisticsAgingService>().GetLogisticsAgingListByParam(DepartureCity, DestinationCity, "-1");

                                if (list != null && list.Count > 0)
                                {
                                    LogisticsAging Info = list[0];
                                    Info.Line = Line;
                                    Info.DepartureProvince = DepartureProvince;
                                    Info.DepartureCity = DepartureCity;
                                    if (Pathway != "")
                                    {
                                        Info.Pathway = Pathway;
                                        Info.PathwayDate = int.Parse(PathwayDate);
                                    }
                                    else
                                    {
                                        Info.Pathway = "";
                                        Info.PathwayDate = null;
                                    }
                                    Info.DestinationProvince = DestinationProvince;
                                    Info.DestinationCity = DestinationCity;
                                    Info.DestinationDate = int.Parse(DestinationDate);
                                    Info.IsSouth = false;//北方
                                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    Info.UpdateTime = DateTime.Now;
                                    IoC.Resolve<ILogisticsAgingService>().UpdateLogisticsAging(Info);
                                }
                                else
                                {
                                    LogisticsAging Info = new LogisticsAging();
                                    Info.Line = Line;
                                    Info.DepartureProvince = DepartureProvince;
                                    Info.DepartureCity = DepartureCity;
                                    if (Pathway != "")
                                    {
                                        Info.Pathway = Pathway;
                                        Info.PathwayDate = int.Parse(PathwayDate);
                                    }
                                    else
                                    {
                                        Info.Pathway = "";
                                        Info.PathwayDate = null;
                                    }
                                    Info.DestinationProvince = DestinationProvince;
                                    Info.DestinationCity = DestinationCity;
                                    Info.DestinationDate = int.Parse(DestinationDate);
                                    Info.IsSouth = false;//北方
                                    Info.IsEnabled = false;
                                    Info.CreatorID = HozestERPContext.Current.User.CustomerID;
                                    Info.CreateTime = DateTime.Now;
                                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    Info.UpdateTime = DateTime.Now;
                                    IoC.Resolve<ILogisticsAgingService>().InsertLogisticsAging(Info);
                                }
                                resultCount++;
                            }
                            scope.Complete();
                        }
                    }
                    #endregion

                    #endregion

                    if (dt != null)
                    {
                        if (resultCount == (dt.Rows.Count + Dt.Rows.Count))
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + (dt.Rows.Count + Dt.Rows.Count) + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 导入京东自营日销量数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="NickId"></param>
        public void ImportDailySaleProductList(string filePath, ref string paramMessage, int NickId, string begin)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    int resultCount = 0;
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    DataTable dt = null;
                    #region   京东自营日销量导入
                    if (NickId == 29)                    //京东自营导入
                    {
                        dt = excelHelper.ReadTable("附表一");
                        dt.DefaultView.RowFilter = "商品编号 is not null and (Convert(商品编号, 'System.String')<>'' or Convert(商品编号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();
                        foreach (DataRow row1 in dt.Rows)
                        {
                            using (TransactionScope scope = new TransactionScope())
                            {
                                int productId = 5;
                                string manufacturersCode = "";                                             //厂家编码
                                string sqID = row1["商品编号"].ToString().Trim();       //京东自营sqID
                                string productName = row1["商品名称"].ToString().Trim();
                                string OrderQuantity = row1["下单量"].ToString().Trim() == "" ? "0" : row1["下单量"].ToString().Trim();
                                string MerchandiseViewCount = row1["商品浏览量"].ToString().Trim() == "" ? "0" : row1["商品浏览量"].ToString().Trim();
                                string VisitorNumber = row1["访客数"].ToString().Trim() == "" ? "0" : row1["访客数"].ToString().Trim();
                                string ConversionRate = row1["下单转换率"].ToString().Trim() == "" ? "0" : row1["下单转换率"].ToString().Trim();
                                string CumulativeAttention = row1["累计关注量"].ToString().Trim() == "" ? "0" : row1["累计关注量"].ToString().Trim();
                                string AddCartCount = row1["加入购物车量"].ToString().Trim() == "" ? "0" : row1["加入购物车量"].ToString().Trim();
                                string CartConversionRate = row1["购物车转换率"].ToString().Trim() == "" ? "0" : row1["购物车转换率"].ToString().Trim();
                                string EvaluationQuantity = row1["评价数量"].ToString().Trim() == "" ? "0" : row1["评价数量"].ToString().Trim();
                                string PraiseQuantity = row1["好评数量"].ToString().Trim() == "" ? "0" : row1["好评数量"].ToString().Trim();
                                string PraiseRate = row1["好评率"].ToString().Trim() == "" ? "0" : row1["好评率"].ToString().Trim();
                                string FlowRate = row1["站内流量比"].ToString().Trim() == "" ? "0" : row1["站内流量比"].ToString().Trim();
                                string ExterFlowRate = row1["站外流量比"].ToString().Trim() == "" ? "0" : row1["站外流量比"].ToString().Trim();
                                int ToInt = 0;
                                decimal Todecimal = 0;
                                var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(sqID, 537, "");
                                if (productDetails != null && productDetails.Count > 0)
                                {
                                    manufacturersCode = productDetails[0].ManufacturersCode;
                                    productId = productDetails[0].ProductId.Value;
                                }
                                if (int.TryParse(OrderQuantity, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "下单量：" + "必须为整数！\r\n";
                                }
                                else if (int.TryParse(MerchandiseViewCount, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "商品浏览量：" + "必须为整数！\r\n";
                                }
                                else if (int.TryParse(VisitorNumber, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "访客数：" + "必须为整数！\r\n";
                                }
                                else if (int.TryParse(CumulativeAttention, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "累计关注量：" + "必须为整数！\r\n";
                                }
                                else if (int.TryParse(AddCartCount, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "加入购物车量：" + "必须为整数！\r\n";
                                }
                                else if (int.TryParse(EvaluationQuantity, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "评价数量：" + "必须为整数！\r\n";
                                }
                                else if (int.TryParse(PraiseQuantity, out ToInt) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "好评数量：" + "必须为整数！\r\n";
                                }
                                if (decimal.TryParse(ConversionRate, out Todecimal) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "下单转换率：" + "必须为数字！\r\n";
                                }
                                else if (decimal.TryParse(CartConversionRate, out Todecimal) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "购物车转换率：" + "必须为数字！\r\n";
                                }
                                else if (decimal.TryParse(PraiseRate, out Todecimal) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "好评率：" + "必须为数字！\r\n";
                                }
                                else if (decimal.TryParse(FlowRate, out Todecimal) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "站内流量比：" + "必须为数字！\r\n";
                                }
                                else if (decimal.TryParse(ExterFlowRate, out Todecimal) == false)
                                {
                                    paramMessage += "商品编码为：" + manufacturersCode + "站外流量比：" + "必须为数字！\r\n";
                                }
                                if (string.IsNullOrEmpty(paramMessage))     //数据合法  导入数据
                                {
                                    //判断当前日期是否已经到过
                                    var dailySaleInfo = IoC.Resolve<IXMDailySaleInfoService>().GetXMDailySaleInfoByPlatformMerchantCodeAndDate(manufacturersCode, Convert.ToDateTime(begin));
                                    if (dailySaleInfo == null)     //如果不存在  导入数据
                                    {
                                        XMDailySaleInfo Info = new XMDailySaleInfo();
                                        Info.ProductId = productId;
                                        Info.PlatformMerchantCode = manufacturersCode;
                                        Info.OrderQuantity = int.Parse(OrderQuantity);
                                        Info.MerchandiseViewCount = int.Parse(MerchandiseViewCount);
                                        Info.VisitorNumber = int.Parse(VisitorNumber);
                                        Info.ConversionRate = decimal.Parse(ConversionRate) * 100;
                                        Info.CumulativeAttention = int.Parse(CumulativeAttention);
                                        Info.AddCartCount = int.Parse(AddCartCount);
                                        Info.CartConversionRate = decimal.Parse(CartConversionRate) * 100;
                                        Info.EvaluationQuantity = int.Parse(EvaluationQuantity);
                                        Info.PraiseQuantity = int.Parse(PraiseQuantity);
                                        Info.PraiseRate = decimal.Parse(PraiseRate) * 100;
                                        Info.FlowRate = decimal.Parse(FlowRate) * 100;
                                        Info.ExterFlowRate = decimal.Parse(ExterFlowRate) * 100;
                                        Info.CreateDate = !string.IsNullOrEmpty(begin) ? Convert.ToDateTime(begin) : Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                                        Info.CreateID = HozestERPContext.Current.User.CustomerID;
                                        Info.UpdateDate = DateTime.Now;
                                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        Info.NickId = NickId;
                                        var project = IoC.Resolve<IXMNickService>().GetXMNickByID(NickId);
                                        if (project != null)
                                        {
                                            Info.ProjectId = project.ProjectId.Value;
                                        }
                                        Info.IsEnable = false;
                                        IoC.Resolve<IXMDailySaleInfoService>().InsertXMDailySaleInfo(Info);
                                    }
                                    else               //数据存在   更新
                                    {
                                        dailySaleInfo.OrderQuantity = int.Parse(OrderQuantity);
                                        dailySaleInfo.MerchandiseViewCount = int.Parse(MerchandiseViewCount);
                                        dailySaleInfo.VisitorNumber = int.Parse(VisitorNumber);
                                        dailySaleInfo.ConversionRate = decimal.Parse(ConversionRate) * 100;
                                        dailySaleInfo.CumulativeAttention = int.Parse(CumulativeAttention);
                                        dailySaleInfo.AddCartCount = int.Parse(AddCartCount);
                                        dailySaleInfo.CartConversionRate = decimal.Parse(CartConversionRate) * 100;
                                        dailySaleInfo.EvaluationQuantity = int.Parse(EvaluationQuantity);
                                        dailySaleInfo.PraiseQuantity = int.Parse(PraiseQuantity);
                                        dailySaleInfo.PraiseRate = decimal.Parse(PraiseRate) * 100;
                                        dailySaleInfo.FlowRate = decimal.Parse(FlowRate) * 100;
                                        dailySaleInfo.ExterFlowRate = decimal.Parse(ExterFlowRate) * 100;
                                        dailySaleInfo.UpdateDate = DateTime.Now;
                                        dailySaleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        IoC.Resolve<IXMDailySaleInfoService>().UpdateXMDailySaleInfo(dailySaleInfo);
                                    }
                                }
                                resultCount++;
                                scope.Complete();
                            }
                        }

                        if (dt != null)
                        {
                            if (resultCount == dt.Rows.Count)
                            {
                                if (paramMessage == "")
                                {
                                    paramMessage = "导入成功！";
                                }
                            }
                            else
                            {
                                paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="PlatformTypeId"></param>
        public void ImportAlipaymentData(string filePath, ref string paramMessage, int PlatformTypeId, string fieldName)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    int resultCount = 0;
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    DataTable dt = null;
                    dt = excelHelper.ReadTable("Sheet1");
                    dt.DefaultView.RowFilter = fieldName + " is not null and (Convert(" + fieldName + ", 'System.String')<>'' or Convert(" + fieldName + ", 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();
                    List<string> OrderCodeList = new List<string>();
                    List<XMAlipaymentAccount> List = new List<XMAlipaymentAccount>();
                    //循环获取所有订单号列表
                    foreach (DataRow row1 in dt.Rows)
                    {
                        if (PlatformTypeId == 259)    //唯品会
                        {
                            string ordercode = row1["SO"].ToString().Trim();    //唯品会订单号
                            if (!string.IsNullOrEmpty(ordercode) && !OrderCodeList.Contains(ordercode))
                            {
                                OrderCodeList.Add(ordercode);
                            }
                        }
                        else if (PlatformTypeId == 251)    //京东
                        {
                            string ordercode = row1["订单编号"].ToString().Trim();    //京东订单号
                            if (!string.IsNullOrEmpty(ordercode) && !OrderCodeList.Contains(ordercode))
                            {
                                OrderCodeList.Add(ordercode);
                            }
                        }
                        else if (PlatformTypeId == 383)    //苏宁易购
                        {
                            string ordercode = row1["订单号"].ToString().Trim();    //苏宁易购订单号
                            if (!string.IsNullOrEmpty(ordercode) && !OrderCodeList.Contains(ordercode))
                            {
                                OrderCodeList.Add(ordercode);
                            }
                        }
                        else if (PlatformTypeId == 250)   //天猫
                        {
                            string ordercode = "";
                            ordercode = row1["商户订单号"].ToString().Trim();    //天猫订单号
                            int index = ordercode.IndexOf("P");
                            if (index >= 0)
                            {
                                ordercode = ordercode.Substring(index + 1);
                            }
                            if (!string.IsNullOrEmpty(ordercode) && !OrderCodeList.Contains(ordercode))
                            {
                                OrderCodeList.Add(ordercode);
                            }
                        }
                    }

                    if (System.Web.HttpContext.Current.Session["AlipaymentData"] == null)
                    {
                        if (OrderCodeList.Count > 0)
                        {
                            foreach (string ordercode in OrderCodeList)
                            {
                                if (!string.IsNullOrEmpty(ordercode))
                                {
                                    var XMAlipaymentAccount = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderCode2(ordercode);
                                    if (XMAlipaymentAccount != null && XMAlipaymentAccount.Count > 0)
                                    {
                                        foreach (XMAlipaymentAccount Info in XMAlipaymentAccount)
                                        {
                                            List.Add(Info);
                                        }
                                    }
                                }
                            }
                        }
                        System.Web.HttpContext.Current.Session["AlipaymentData"] = List;
                    }
                    else
                    {
                        var AlipaymentData = System.Web.HttpContext.Current.Session["AlipaymentData"] as List<XMAlipaymentAccount>;
                        if (OrderCodeList.Count > 0)
                        {
                            foreach (string ordercode in OrderCodeList)
                            {
                                bool isExsit = false;
                                if (AlipaymentData != null && AlipaymentData.Count > 0)
                                {
                                    foreach (XMAlipaymentAccount p in AlipaymentData)
                                    {
                                        if (ordercode == p.OrderCode)
                                        {
                                            isExsit = true;            //该订单已经存在
                                        }
                                    }
                                }
                                if (!isExsit)    //不存在
                                {
                                    if (!string.IsNullOrEmpty(ordercode))
                                    {
                                        var XMAlipaymentAccount = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderCode2(ordercode);
                                        if (XMAlipaymentAccount != null && XMAlipaymentAccount.Count > 0)
                                        {
                                            foreach (XMAlipaymentAccount Info in XMAlipaymentAccount)
                                            {
                                                AlipaymentData.Add(Info);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        System.Web.HttpContext.Current.Session["AlipaymentData"] = AlipaymentData;
                    }
                    paramMessage = "导入成功！";
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportJDRealTimeInventory(string filePath, ref string paramMessage, int nickId)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    DataTable dt = null;
                    #region   京东自营销量导入
                    if (nickId == 29)                    //京东自营导入
                    {
                        dt = excelHelper.ReadTable("Sheet1");
                        dt.DefaultView.RowFilter = "商品编号 is not null and (Convert(商品编号, 'System.String')<>'' or Convert(商品编号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();
                        //根据店铺查询对应仓库列表
                        var wareHouses = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseListByNickID(nickId);
                        if (wareHouses != null && wareHouses.Count > 0)
                        {
                            //遍历所有仓库
                            foreach (XMWareHouses Info in wareHouses)
                            {
                                foreach (DataRow row1 in dt.Rows)
                                {
                                    int productId = 1;
                                    string manufacturersCode = "";      //厂家编码
                                    int InventoryCount = (row1[Info.CityName + "库存"].ToString().Trim() == "" || row1[Info.CityName + "库存"].ToString().Trim() == "-") ? 0 : int.Parse(row1[Info.CityName + "库存"].ToString().Trim());      //库存
                                    string sqID = row1["商品编号"].ToString().Trim();    //京东自营sqID
                                    if (sqID == "合计")
                                    {
                                        return;
                                    }
                                    //根据京东自营SPID 查询产品信息
                                    var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(sqID, 537, "");
                                    if (productDetails != null && productDetails.Count > 0)
                                    {
                                        manufacturersCode = productDetails[0].ManufacturersCode;
                                        productId = productDetails[0].ProductId.Value;
                                    }
                                    if (manufacturersCode != "")
                                    {
                                        var jdRealTimeIncentoryInfo = IoC.Resolve<IXMJDRealTimeInventoryService>().GetXMJDRealTimeInventoryParm(manufacturersCode, Info.Id);
                                        if (jdRealTimeIncentoryInfo != null)    //数据已经存在 更新覆盖元数据
                                        {
                                            jdRealTimeIncentoryInfo.RealTimeInventory = InventoryCount;
                                            jdRealTimeIncentoryInfo.UpdateDate = DateTime.Now;
                                            jdRealTimeIncentoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            IoC.Resolve<IXMJDRealTimeInventoryService>().UpdateXMJDRealTimeInventory(jdRealTimeIncentoryInfo);
                                        }
                                        else
                                        {
                                            XMJDRealTimeInventory jdInventory = new XMJDRealTimeInventory();
                                            jdInventory.PlatformMerchantCode = manufacturersCode;
                                            jdInventory.WfId = Info.Id;
                                            jdInventory.ProductId = productId;
                                            jdInventory.RealTimeInventory = InventoryCount;
                                            jdInventory.CreateDate = jdInventory.UpdateDate = DateTime.Now;
                                            jdInventory.CreateID = jdInventory.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            jdInventory.IsEnable = false;
                                            IoC.Resolve<IXMJDRealTimeInventoryService>().InsertXMJDRealTimeInventory(jdInventory);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// 根据店铺获取仓库列表  导入各个仓库销量数据(京东自营)
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        /// <param name="NickId"></param>
        public void ImportSaleDeliveryList(string filePath, ref string paramMessage, int NickId, string begin)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    DataTable dt = null;
                    #region   京东自营销量导入
                    if (NickId == 29)                    //京东自营导入
                    {
                        dt = excelHelper.ReadTable("Sheet1");
                        dt.DefaultView.RowFilter = "商品编号 is not null and (Convert(商品编号, 'System.String')<>'' or Convert(商品编号, 'System.Int32')>0)";
                        dt = dt.DefaultView.ToTable();

                        DateTime date = DateTime.Now;
                        if (begin != "")
                        {
                            if (begin == "" || !DateTime.TryParse(begin, out date))
                            {
                                return;
                            }
                        }
                        //根据店铺查询对应仓库列表
                        var wareHouses = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseListByNickID(NickId);
                        if (wareHouses != null && wareHouses.Count > 0)
                        {
                            //遍历所有仓库
                            foreach (XMWareHouses Info in wareHouses)
                            {
                                if (Info.Name == "成都京东仓") 
                                {
                                    string aa = "";
                                }
                                bool isOK = false;
                                int totalCount = 0;  //仓库商品销量总量
                                int saleDeliveryID = 0;
                                int i = 0;
                                decimal totalMoney = 0;
                                foreach (DataRow row1 in dt.Rows)
                                {
                                    string manufacturersCode = "";      //厂家编码
                                    int saleCount = (row1[Info.Name + "出库销量"].ToString().Trim() == "" || row1[Info.Name + "出库销量"].ToString().Trim() == "-") ? 0 : int.Parse(row1[Info.Name + "出库销量"].ToString().Trim());      //出库销量
                                    if (saleCount > 0)
                                    {
                                        totalCount += saleCount;
                                    }
                                    string sqID = row1["商品编号"].ToString().Trim();    //京东自营sqID
                                    if (sqID == "合计")
                                    {
                                        return;
                                    }
                                    //根据京东自营SPID 查询产品信息
                                    var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(sqID, 537, "");
                                    if (productDetails != null && productDetails.Count > 0)
                                    {
                                        manufacturersCode = productDetails[0].ManufacturersCode;
                                    }
                                    if (manufacturersCode != "")
                                    {
                                        var InventoryInfo = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoByParm(manufacturersCode, Info.Id);
                                        if (Info.ParentID != 0)                  //表示为微型仓库     销量算到主仓去
                                        {
                                            if ((InventoryInfo == null && saleCount > 0) || (InventoryInfo != null && InventoryInfo.StockNumber > 0 && saleCount > 0 && InventoryInfo.StockNumber < saleCount))          //微型仓库存不足
                                            {
                                                int remainderCount = saleCount - (InventoryInfo == null ? 0 : InventoryInfo.StockNumber.Value);            //剩余数量
                                                var MainInventoryInfo = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoByParm(manufacturersCode, Info.ParentID.Value);
                                                if (MainInventoryInfo == null || (MainInventoryInfo != null && MainInventoryInfo.StockNumber < remainderCount))
                                                {
                                                    isOK = true;
                                                    paramMessage += "微型仓产品全部出库，但主仓库【" + Info.Name + "】商品编码为" + manufacturersCode + "的产品库存不足， 无法扣除剩余销量，请及时补货！";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((InventoryInfo == null && saleCount > 0) || (InventoryInfo != null && saleCount > 0 && InventoryInfo.StockNumber < saleCount))
                                            {
                                                isOK = true;
                                                paramMessage += "仓库【" + Info.Name + "】商品编码为" + manufacturersCode + "的产品库存不足，请及时补货！";
                                            }
                                        }
                                    }
                                }
                                if (isOK)
                                {
                                    continue;
                                }
                                var saleDelviery = IoC.Resolve<IXMSaleDeliveryService>().GetXMSaleDeliveryByParm(begin, Info.Id);
                                if (saleDelviery == null)             //导入数据新增
                                {
                                    if (totalCount > 0)
                                    {
                                        //插入主表
                                        XMSaleDelivery saleDelivery = new XMSaleDelivery();
                                        saleDelivery.Ref = AutoSaleDeliveryNumber();
                                        saleDelivery.SaleInfoId = 0;        //导入数据与销售订单无关
                                        saleDelivery.OrderInfoID = 0;     //导入数据与订单无关
                                        saleDelivery.WareHouseId = Info.Id;         //仓库ID
                                        saleDelivery.BillStatus = 1000;  //状态默认为已出库
                                        saleDelivery.ReceivingType = 701;    //默认为 支付宝
                                        saleDelivery.SaleMoney = 0;         //该值需要计算
                                        saleDelivery.CreateID = saleDelivery.BizUserId = HozestERPContext.Current.User.CustomerID;
                                        saleDelivery.CreateDate = saleDelivery.BizDt = !string.IsNullOrEmpty(begin) ? Convert.ToDateTime(begin) : Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                                        saleDelivery.IsEnable = false;
                                        saleDelivery.IsAudit = true;
                                        IoC.Resolve<IXMSaleDeliveryService>().InsertXMSaleDelivery(saleDelivery);
                                        saleDeliveryID = saleDelivery.Id;
                                    }
                                    foreach (DataRow row1 in dt.Rows)
                                    {
                                        int productId = 5;
                                        string manufacturersCode = "";      //厂家编码
                                        string sqID = row1["商品编号"].ToString().Trim();    //京东自营sqID
                                        decimal saleMoney = 0;                                        //商品价格
                                        if (sqID == "合计")
                                        {
                                            return;
                                        }
                                        //根据京东自营SPID 查询产品信息
                                        var productDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(sqID, 537, "");
                                        if (productDetails != null && productDetails.Count > 0)
                                        {
                                            manufacturersCode = productDetails[0].ManufacturersCode;                   //商品厂家编码
                                            productId = productDetails[0].ProductId.Value;                                        //产品主键ID
                                            saleMoney = productDetails[0].Saleprice.Value;                                        //商品库商品销售价格
                                        }
                                        int saleCount = (row1[Info.Name + "出库销量"].ToString().Trim() == "" || row1[Info.Name + "出库销量"].ToString().Trim() == "-") ? 0 : int.Parse(row1[Info.Name + "出库销量"].ToString().Trim());      //出库销量
                                        int inventoryCount = (row1[Info.Name + "库存"].ToString().Trim() == "" || row1[Info.Name + "库存"].ToString().Trim() == "-") ? 0 : int.Parse(row1[Info.Name + "库存"].ToString().Trim());  //库存
                                        int kCount = (row1[Info.Name + "可订购"].ToString().Trim() == "" || row1[Info.Name + "可订购"].ToString().Trim() == "-") ? 0 : int.Parse(row1[Info.Name + "可订购"].ToString().Trim());         // 可定购数量
                                        totalMoney += saleMoney * saleCount;

                                        if (manufacturersCode != "")
                                        {
                                            var InventoryInfo = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoByParm(manufacturersCode, Info.Id);
                                            if (Info.ParentID != 0)                  //表示为微型仓库     销量算到主仓去
                                            {
                                                if (InventoryInfo != null && InventoryInfo.StockNumber > 0 && saleCount > 0 && InventoryInfo.StockNumber > saleCount)    //子仓库存足够  扣掉
                                                {
                                                    InventoryInfo.StockNumber = InventoryInfo.StockNumber - saleCount;
                                                    InventoryInfo.CanOrderCount = kCount;
                                                    InventoryInfo.UpdateDate = DateTime.Now;
                                                    InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(InventoryInfo);
                                                }
                                                if (InventoryInfo != null && InventoryInfo.StockNumber > 0 && saleCount > 0 && InventoryInfo.StockNumber < saleCount)    //子仓库存存在 但不够(子仓库存扣掉，剩余用主仓口)
                                                {
                                                    int remainderCount = saleCount - InventoryInfo.StockNumber.Value;            //剩余数量
                                                    var MainInventoryInfo = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoByParm(manufacturersCode, Info.ParentID.Value);
                                                    if (MainInventoryInfo != null && MainInventoryInfo.StockNumber > 0 && MainInventoryInfo.StockNumber > remainderCount)
                                                    {
                                                        //扣掉子仓数量
                                                        InventoryInfo.StockNumber = 0;
                                                        InventoryInfo.CanOrderCount = kCount;
                                                        InventoryInfo.UpdateDate = DateTime.Now;
                                                        InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(InventoryInfo);
                                                        //剩余数量用主仓扣除
                                                        MainInventoryInfo.StockNumber = MainInventoryInfo.StockNumber - remainderCount;
                                                        MainInventoryInfo.CanOrderCount = kCount;
                                                        MainInventoryInfo.UpdateDate = DateTime.Now;
                                                        MainInventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(MainInventoryInfo);
                                                    }
                                                }
                                                if (InventoryInfo == null || (InventoryInfo != null && saleCount > 0 && InventoryInfo.StockNumber == 0))      //子仓没有库存  从主仓扣除
                                                {
                                                    var MainInventoryInfo = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoByParm(manufacturersCode, Info.ParentID.Value);
                                                    if (MainInventoryInfo != null && MainInventoryInfo.StockNumber > saleCount)
                                                    {
                                                        MainInventoryInfo.StockNumber = MainInventoryInfo.StockNumber - saleCount;
                                                        MainInventoryInfo.CanOrderCount = kCount;
                                                        MainInventoryInfo.UpdateDate = DateTime.Now;
                                                        MainInventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                        IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(MainInventoryInfo);
                                                    }
                                                }
                                            }
                                            else                //为主仓数据
                                            {
                                                if (InventoryInfo != null && saleCount > 0 && InventoryInfo.StockNumber > saleCount)         // 产品库存已存在 更新  
                                                {
                                                    InventoryInfo.StockNumber = InventoryInfo.StockNumber - saleCount;
                                                    InventoryInfo.CanOrderCount = kCount;
                                                    InventoryInfo.UpdateDate = DateTime.Now;
                                                    InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                    IoC.Resolve<IXMInventoryInfoService>().UpdateXMInventoryInfo(InventoryInfo);
                                                }
                                            }
                                        }

                                        if (saleCount > 0)
                                        {
                                            //导入销售出库单插入从表数据
                                            XMSaleDeliveryProductDetails details = new XMSaleDeliveryProductDetails();
                                            details.SaleDeliveryId = saleDeliveryID;
                                            details.ProductId = productId;
                                            details.PlatformMerchantCode = manufacturersCode;     //商品厂家编码
                                            details.SaleCount = saleCount;
                                            details.ProductPrice = saleMoney;
                                            details.ProductMoney = saleCount * saleMoney;
                                            details.CreateDate = details.UpdateDate = !string.IsNullOrEmpty(begin) ? Convert.ToDateTime(begin) : Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                                            details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            details.IsEnable = false;
                                            IoC.Resolve<IXMSaleDeliveryProductDetailsService>().InsertXMSaleDeliveryProductDetails(details);
                                        }
                                        i++;
                                        if (i == dt.Rows.Count)     //商品遍历到最后一个  更新主表销售总金额
                                        {
                                            var saleDe = IoC.Resolve<IXMSaleDeliveryService>().GetXMSaleDeliveryById(saleDeliveryID);
                                            if (saleDe != null)
                                            {
                                                saleDe.SaleMoney = totalMoney;
                                                IoC.Resolve<IXMSaleDeliveryService>().UpdateXMSaleDelivery(saleDe);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    paramMessage += "当天仓库名为【" + Info.Name + "】销售数据已经存在，请确认后再次上传！\r\n";
                                }
                            }
                        }
                        else
                        {
                            paramMessage += "该店铺下的仓库不存在！\r\n";
                        }
                    }
                    if (paramMessage == "")
                    {
                        paramMessage = "导入成功！";
                    }
                    #endregion

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string AutoSaleDeliveryNumber()
        {
            string SaleDeliveryCode = "";       //自动生成销售出货单号
            int number = 1;
            var saleDelivery = IoC.Resolve<IXMSaleDeliveryService>().GetXMSaleDeliveryList();
            if (saleDelivery != null && saleDelivery.Count > 0)
            {
                number = saleDelivery[0].Id + 1;
            }
            SaleDeliveryCode = "CK" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return SaleDeliveryCode;
        }

        /// <summary>
        /// 运单承运商导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportVPHLogistics(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;

                    dt = excelHelper.ReadTable("import_file_template");
                    dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();

                    foreach (DataRow row1 in dt.Rows)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string OrderCode = row1["订单号"].ToString().Trim();
                            string LogisticsNumber = row1["运单号"].ToString().Trim();
                            string LogisticsCompany = row1["承运商"].ToString().Trim();

                            var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(OrderCode);
                            if (OrderInfo != null)
                            {
                                var list = IoC.Resolve<IXMLogisticsInfoService>().GetXMLogisticsInfoListByOrderInfoID(OrderInfo.ID);
                                if (list != null && list.Count > 0)
                                {
                                    foreach (XMLogisticsInfo Info in list)
                                    {
                                        Info.LogisticsNumber = LogisticsNumber;
                                        Info.LogisticsCompany = LogisticsCompany;
                                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        Info.UpdateTime = DateTime.Now;
                                        IoC.Resolve<IXMLogisticsInfoService>().UpdateXMLogisticsInfo(Info);
                                    }
                                    resultCount++;
                                }
                                else
                                {
                                    paramMessage += "订单号：" + OrderCode + "的物流信息还未生成过！\r\n";
                                }
                            }
                            else
                            {
                                paramMessage += "订单号：" + OrderCode + "的订单不存在！\r\n";
                            }
                            scope.Complete();
                        }
                    }

                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 喜临门库存导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportXLMInventory(string filePath, ref string paramMessage)
        {
            if (filePath != "")
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    List<XMXLMInventory> List = new List<XMXLMInventory>();

                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;
                    dt = excelHelper.ReadTable("Sheet1");
                    dt.DefaultView.RowFilter = "仓库 is not null and (Convert(仓库, 'System.String')<>'' or Convert(仓库, 'System.Int32')>0)";
                    dt = dt.DefaultView.ToTable();
                    using (TransactionScope scope = new TransactionScope())
                    {
                        foreach (DataRow row1 in dt.Rows)
                        {
                            int WarehouseID = 0;
                            string WarehouseName = row1["仓库"].ToString().Trim();
                            string ManufacturersCode = row1["规格代码"].ToString().Trim();
                            string ProductName = row1["商品名称"].ToString().Trim();
                            string Specifications = row1["规格名称"].ToString().Trim();
                            //string Type = row1["物资类别"].ToString().Trim();
                            //string BarCode = row1["条形码"].ToString().Trim();
                            //string Unit = row1["单位"].ToString().Trim();
                            string Inventory = row1["可用数"].ToString().Trim() == "" ? "0" : row1["可用数"].ToString().Trim();

                            if (WarehouseName.IndexOf("棉花仓") != -1)
                            {
                                WarehouseID = 693;//南方仓库
                            }
                            else if (WarehouseName.IndexOf("总部仓") != -1)
                            {
                                WarehouseID = 693;//南方仓库
                            }
                            else if (WarehouseName.IndexOf("EBD香河成品仓库") != -1)
                            {
                                WarehouseID = 694;//北方仓库
                            }
                            else if (WarehouseName.IndexOf("EBD成都成品仓库") != -1)
                            {
                                WarehouseID = 695;//成都仓库
                            }
                            else if (WarehouseName.IndexOf("EBD佛山成品仓库") != -1)
                            {
                                WarehouseID = 759;//TP佛山成品仓库
                            }

                            if (ManufacturersCode == "合计")
                            {
                                paramMessage += "合计不能作为产品编码！";
                                scope.Complete();
                                continue;
                            }

                            //var list = IoC.Resolve<IXMXLMInventoryService>().GetXMXLMInventoryListByParm(WarehouseID, ManufacturersCode, "");
                            var Exist = List.Find(x => x.WarehouseID == WarehouseID && x.ManufacturersCode == ManufacturersCode);
                            if (Exist != null)
                            {
                                //XMXLMInventory Info = Exist;
                                //Info.WarehouseID = WarehouseID;
                                Exist.ProductName = ProductName;
                                Exist.Specifications = Specifications;
                                //Info.Type = Type;
                                //Info.BarCode = BarCode;
                                //Info.Unit = Unit;
                                Exist.Inventory += int.Parse(Inventory);
                                //IoC.Resolve<IXMXLMInventoryService>().UpdateXMXLMInventory(Info);
                                resultCount++;
                            }
                            else
                            {
                                XMXLMInventory Info = new XMXLMInventory();
                                Info.WarehouseID = WarehouseID;
                                Info.ManufacturersCode = ManufacturersCode;
                                Info.ProductName = ProductName;
                                Info.Specifications = Specifications;
                                //Info.Type = Type;
                                //Info.BarCode = BarCode;
                                //Info.Unit = Unit;
                                Info.Inventory = int.Parse(Inventory);
                                Info.CreateDate = DateTime.Now;
                                Info.CreateID = HozestERPContext.Current.User.CustomerID;
                                List.Add(Info);
                                //IoC.Resolve<IXMXLMInventoryService>().InsertXMXLMInventory(Info);
                                resultCount++;
                            }
                        }
                        foreach (var Info in List)
                        {
                            var list = IoC.Resolve<IXMXLMInventoryService>().GetXMXLMInventoryListByParm((int)Info.WarehouseID, Info.ManufacturersCode, "");
                            if (list != null && list.Count > 0)
                            {
                                XMXLMInventory info = list[0];
                                info.Inventory = Info.Inventory;
                                IoC.Resolve<IXMXLMInventoryService>().UpdateXMXLMInventory(info);
                            }
                            else
                            {
                                IoC.Resolve<IXMXLMInventoryService>().InsertXMXLMInventory(Info);
                            }
                        }
                        scope.Complete();
                    }

                    if (dt != null)
                    {
                        if (resultCount == dt.Rows.Count)
                        {
                            if (paramMessage == "")
                            {
                                paramMessage = "导入成功！";
                            }
                        }
                        else
                        {
                            paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 9.9大礼包导入赠品
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportBigGiftPacksDataFromXls(string filePath, ref string paramMessage, string platNum)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;

                dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();
                foreach (DataRow row1 in dt.Rows)
                {
                    int a = 0;
                    string OrderCode = row1["订单号"].ToString().Trim();
                    string ProductNum = row1["数量"].ToString().Trim();
                    var OrderInfoList = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(OrderCode);
                    if (OrderInfoList != null)
                    {
                        XMPremiums XMPremium = new XMPremiums();
                        XMPremium.OrderCode = OrderCode;//订单号
                        XMPremium.WantId = OrderInfoList.WantID;
                        XMPremium.IsEvaluation = true;
                        XMPremium.EvaluationDate = XMPremium.ManagerTime = DateTime.Now;
                        XMPremium.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                        //XMPremium.ActivityExplanation = "床笠(1.8)*1+记忆枕*1+乳胶枕*1";
                        if (platNum == "1")
                        {
                            XMPremium.ActivityExplanation = "乳胶枕*1";
                        }
                        else if (platNum == "2")
                        {
                            XMPremium.ActivityExplanation = "床笠1.8*1+乳胶枕*1";
                        }
                        XMPremium.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                        XMPremium.ManagerPeople = XMPremium.EvaluationID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.PremiumsTypeId = 11;//申请类型
                        XMPremium.IsEnable = false;
                        XMPremium.IsSingleRow = false;
                        XMPremium.CreatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.CreateTime = DateTime.Now;
                        XMPremium.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.UpdateTime = DateTime.Now;
                        IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(XMPremium);

                        //string[] ManufacturersCodeList = { "1089882558", "1076421242", "1533011448" };//床笠1.8，记忆枕，乳胶枕
                        if (platNum == "1")
                        {
                            string[] ManufacturersCodeList = { "1533011448" };//乳胶枕
                            foreach (var ManufacturersCode in ManufacturersCodeList)
                            {
                                XMPremiumsDetails one = new XMPremiumsDetails();
                                one.PremiumsId = XMPremium.Id;
                                var Product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                                if (Product != null)
                                {
                                    one.ProductDetaislId = Product.Id;
                                    var ProductDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Product.Id);
                                    var productDetails1 = ProductDetails.Where(x => x.PlatformTypeId == 251).ToList();//京东
                                    if (productDetails1 != null && productDetails1.Count > 0)
                                    {
                                        one.PlatformMerchantCode = productDetails1[0].PlatformMerchantCode;
                                        one.FactoryPrice = productDetails1[0].Costprice;
                                    }
                                    else
                                    {
                                        var productDetails2 = ProductDetails.Where(x => x.PlatformTypeId == 508).ToList();//通用
                                        if (productDetails2 != null && productDetails2.Count > 0)
                                        {
                                            one.PlatformMerchantCode = productDetails2[0].PlatformMerchantCode;
                                            one.FactoryPrice = productDetails2[0].Costprice;
                                        }
                                    }
                                    one.PrdouctName = Product.ProductName;
                                    one.Shipper = Product.Shipper;
                                }
                                one.ProductNum = 1;
                                one.IsEnable = false;
                                one.CreateID = one.UpdateID = HozestERPContext.Current.User.CustomerID;
                                one.CreateDate = one.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(one);
                            }
                        }
                        else if (platNum == "2")
                        {
                            string[] ManufacturersCodeList = { "1089882558", "1533011448" };///床笠1.8，乳胶枕
                            foreach (var ManufacturersCode in ManufacturersCodeList)
                            {
                                XMPremiumsDetails one = new XMPremiumsDetails();
                                one.PremiumsId = XMPremium.Id;
                                var Product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                                if (Product != null)
                                {
                                    one.ProductDetaislId = Product.Id;
                                    var ProductDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Product.Id);
                                    var productDetails1 = ProductDetails.Where(x => x.PlatformTypeId == 251).ToList();//京东
                                    if (productDetails1 != null && productDetails1.Count > 0)
                                    {
                                        one.PlatformMerchantCode = productDetails1[0].PlatformMerchantCode;
                                        one.FactoryPrice = productDetails1[0].Costprice;
                                    }
                                    else
                                    {
                                        var productDetails2 = ProductDetails.Where(x => x.PlatformTypeId == 508).ToList();//通用
                                        if (productDetails2 != null && productDetails2.Count > 0)
                                        {
                                            one.PlatformMerchantCode = productDetails2[0].PlatformMerchantCode;
                                            one.FactoryPrice = productDetails2[0].Costprice;
                                        }
                                    }
                                    one.PrdouctName = Product.ProductName;
                                    one.Shipper = Product.Shipper;
                                }
                                one.ProductNum = 1;
                                one.IsEnable = false;
                                one.CreateID = one.UpdateID = HozestERPContext.Current.User.CustomerID;
                                one.CreateDate = one.UpdateDate = DateTime.Now;
                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(one);
                            }
                        }

                        resultCount++;
                    }
                }

                if (dt != null)
                {
                    paramMessage = "导入成功！实际导入" + resultCount + "条！";
                }
            }
        }

        /// <summary>
        /// 导入赠品
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportPremiumsDataFromXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;

                dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();
                foreach (DataRow row1 in dt.Rows)
                {
                    int a = 0;
                    string OrderCode = row1["订单号"].ToString().Trim();
                    string paramManufacturersCode = row1["商品编码"].ToString().Trim();
                    string ProductNum = row1["数量"].ToString().Trim();
                    var OrderInfoList = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(OrderCode);
                    if (OrderInfoList != null)
                    {
                        var searchXMPremium = IoC.Resolve<IXMPremiumsService>().GetXMPremiumsListByOrderCode(OrderCode, 11);
                        if (searchXMPremium.Count == 0)
                        {
                            XMPremiums XMPremium = new XMPremiums();
                            XMPremium.OrderCode = OrderCode;//订单号
                            XMPremium.WantId = OrderInfoList.WantID;
                            XMPremium.IsEvaluation = true;
                            XMPremium.EvaluationDate = XMPremium.ManagerTime = DateTime.Now;
                            XMPremium.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                            XMPremium.ActivityExplanation = paramManufacturersCode + "*" + ProductNum;
                            XMPremium.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                            XMPremium.ManagerPeople = XMPremium.EvaluationID = HozestERPContext.Current.User.CustomerID;
                            XMPremium.PremiumsTypeId = 11;//申请类型
                            XMPremium.IsEnable = false;
                            XMPremium.IsSingleRow = false;
                            XMPremium.CreatorID = HozestERPContext.Current.User.CustomerID;
                            XMPremium.CreateTime = DateTime.Now;
                            XMPremium.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            XMPremium.UpdateTime = DateTime.Now;
                            IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(XMPremium);

                            XMPremiumsDetails one = new XMPremiumsDetails();
                            one.PremiumsId = XMPremium.Id;
                            var Product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(paramManufacturersCode);
                            if (Product != null)
                            {
                                one.ProductDetaislId = Product.Id;
                                var ProductDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsListByProductId(Product.Id);
                                var productDetails1 = ProductDetails.Where(x => x.PlatformTypeId == OrderInfoList.PlatformTypeId).ToList();//对应平台
                                if (productDetails1 != null && productDetails1.Count > 0)
                                {
                                    one.PlatformMerchantCode = productDetails1[0].PlatformMerchantCode;
                                    one.FactoryPrice = productDetails1[0].Costprice;
                                }
                                else
                                {
                                    var productDetails2 = ProductDetails.Where(x => x.PlatformTypeId == 508).ToList();//通用
                                    if (productDetails2 != null && productDetails2.Count > 0)
                                    {
                                        one.PlatformMerchantCode = productDetails2[0].PlatformMerchantCode;
                                        one.FactoryPrice = productDetails2[0].Costprice;
                                    }
                                }
                                one.PrdouctName = Product.ProductName;
                                one.Shipper = Product.Shipper;
                            }
                            one.ProductNum = int.Parse(ProductNum);
                            one.IsEnable = false;
                            one.CreateID = one.UpdateID = HozestERPContext.Current.User.CustomerID;
                            one.CreateDate = one.UpdateDate = DateTime.Now;
                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(one);



                            resultCount++;
                        }
                        else
                        {
                            paramMessage = OrderCode + "该订单赠品已增加，请删除后继续导入！";
                            return;
                        }
                    }
                    
                }
                if (dt != null)
                {
                    paramMessage = "导入成功！实际导入" + resultCount + "条！";
                }
            }
        }

        /// <summary>
        /// 无订单赠品导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportNoOrderFromXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;

                dt = excelHelper.ReadTable("无订单赠品");
                dt.DefaultView.RowFilter = "手机 is not null and (Convert(手机, 'System.String')<>'' or Convert(手机, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                List<XMPremiumsDetails> DetailsList = new List<XMPremiumsDetails>();
                List<XMSpareAddress> SpareAddressList = new List<XMSpareAddress>();

                int no = 1;
                foreach (DataRow row1 in dt.Rows)
                {
                    int a = 0;
                    int Id = 0;
                    string PlatformMerchantCode = row1["商品编码"].ToString().Trim();//自营订单号
                    string Count = row1["数量"].ToString().Trim();
                    string FullName = row1["姓名"].ToString().Trim();
                    string Mobile = row1["手机"].ToString().Trim();
                    string Province = row1["省"].ToString().Trim();
                    string City = row1["市"].ToString().Trim();
                    string County = row1["区"].ToString().Trim();
                    string DeliveryAddress = row1["地址"].ToString().Trim();

                    if (Mobile == "" || PlatformMerchantCode == "" || Count == "")
                    {
                        paramMessage += "手机号：" + Mobile + "的记录，商品编码或数量为空！\r";
                        continue;
                    }
                    else
                    {
                        if (!int.TryParse(Count, out a))
                        {
                            paramMessage += "手机号：" + Mobile + "的记录，数量不为整数！\r";
                            continue;
                        }
                        if (DeliveryAddress == "")
                        {
                            paramMessage += "手机号：" + Mobile + "的记录，地址为空！\r";
                            continue;
                        }
                    }

                    var Product = IoC.Resolve<IXMProductService>().getXMProductListByPlatformMerchantCode(PlatformMerchantCode);
                    var ProductDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(PlatformMerchantCode);
                    if (Product == null || Product.Count == 0 || ProductDetails == null || ProductDetails.Count == 0)
                    {
                        paramMessage += "手机号：" + Mobile + "的记录，该商品编码不存在！\r";
                        continue;
                    }

                    var Exist = SpareAddressList.Where(x => x.Mobile == Mobile).ToList();
                    if (Exist != null && Exist.Count > 0)
                    {
                        Id = (int)Exist[0].OtherID;
                        var exist = DetailsList.Where(x => x.PlatformMerchantCode == PlatformMerchantCode && x.PremiumsId == Id).ToList();
                        if (exist != null && exist.Count > 0)
                        {
                            exist[0].ProductNum += int.Parse(Count);
                            continue;
                        }
                    }
                    else
                    {
                        Id = no;
                        XMSpareAddress Info = new XMSpareAddress();
                        Info.OtherID = no;
                        Info.TypeID = 711;//赠品
                        Info.FullName = FullName;
                        Info.Mobile = Mobile;
                        Info.Tel = "";
                        Info.Province = Province;
                        Info.City = City;
                        Info.County = County;
                        Info.DeliveryAddress = DeliveryAddress;
                        SpareAddressList.Add(Info);
                        no++;
                    }

                    XMPremiumsDetails info = new XMPremiumsDetails();
                    info.PremiumsId = Id;
                    info.ProductDetaislId = Product[0].Id;
                    info.PlatformMerchantCode = PlatformMerchantCode;
                    info.PrdouctName = Product[0].ProductName;
                    info.ProductNum = int.Parse(Count);
                    info.FactoryPrice = ProductDetails[0].Costprice;
                    info.Shipper = Product[0].Shipper;
                    DetailsList.Add(info);
                }

                if (!string.IsNullOrEmpty(paramMessage))
                {
                    return;
                }

                var list = IoC.Resolve<IXMSpareAddressService>().GetXMSpareAddressNoOrder();
                foreach (var Item in SpareAddressList)
                {
                    var premiumsDetailsList = DetailsList.Where(x => x.PremiumsId == Item.OtherID).ToList();
                    var Exist = list.Where(x => x.Mobile == Item.Mobile && x.DeliveryAddress == Item.DeliveryAddress).ToList();
                    if (Exist != null && Exist.Count() > 0)
                    {
                        var PremiumsDetailsList = IoC.Resolve<IXMPremiumsDetailsService>().GetXMPremiumsDetailsListByPremiumsId((int)Exist[0].OtherID);
                        //var premiumsDetailsList = DetailsList.Where(x => x.PremiumsId == Item.OtherID).ToList();
                        foreach (var item in premiumsDetailsList)
                        {
                            var exist = PremiumsDetailsList.Where(x => x.PlatformMerchantCode == item.PlatformMerchantCode).ToList();
                            if (exist != null && exist.Count() > 0)
                            {
                                exist[0].ProductNum = item.ProductNum;
                                exist[0].UpdateDate = DateTime.Now;
                                exist[0].UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMPremiumsDetailsService>().UpdateXMPremiumsDetails(exist[0]);

                                resultCount++;
                            }
                            else
                            {
                                item.PremiumsId = (int)Exist[0].OtherID;
                                item.IsEnable = false;
                                item.CreateDate = item.UpdateDate = DateTime.Now;
                                item.CreateID = item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(item);

                                resultCount++;
                            }
                        }
                    }
                    else
                    {
                        string p = "";
                        XMPremiums XMPremium = new XMPremiums();
                        XMPremium.OrderCode = "NoOrder" + DateTime.Now.ToString("yyMMddHHmmssfff"); ;//订单号
                        XMPremium.NoOrderNickId = 29;//现在只有喜临门使用，默认店铺ID是喜临门京东自营
                        XMPremium.WantId = "";
                        XMPremium.IsEvaluation = true;
                        XMPremium.EvaluationDate = XMPremium.ManagerTime = DateTime.Now;
                        XMPremium.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                        //XMPremium.ActivityExplanation = "床笠(1.8)*1+记忆枕*1+乳胶枕*1";
                        XMPremium.ManagerStatus = Convert.ToInt32(StatusEnum.AlreadyCheck);
                        XMPremium.ManagerPeople = XMPremium.EvaluationID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.PremiumsTypeId = Convert.ToInt32(StatusEnum.ChildPremiums);//申请类型
                        XMPremium.IsEnable = false;
                        XMPremium.IsSingleRow = false;
                        XMPremium.PremiumsStatus = Convert.ToInt32(StatusEnum.PremiumsNoHair);
                        XMPremium.CreatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.CreateTime = DateTime.Now;
                        XMPremium.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        XMPremium.UpdateTime = DateTime.Now;
                        IoC.Resolve<IXMPremiumsService>().InsertXMPremiums(XMPremium);

                        foreach (var item in premiumsDetailsList)
                        {
                            item.PremiumsId = XMPremium.Id;
                            item.IsEnable = false;
                            item.CreateDate = item.UpdateDate = DateTime.Now;
                            item.CreateID = item.UpdateID = HozestERPContext.Current.User.CustomerID;
                            IoC.Resolve<IXMPremiumsDetailsService>().InsertXMPremiumsDetails(item);

                            if (item.Specifications != "")
                            {
                                p += item.PrdouctName + "(" + item.Specifications + ")" + "*" + item.ProductNum + "+";
                            }
                            else
                            {
                                p += item.PrdouctName + "*" + item.ProductNum + "+";
                            }

                            resultCount++;
                        }
                        if (p.Length > 0)
                        {
                            p = p.Substring(0, p.Length - 1);
                        }

                        XMPremium.ActivityExplanation = p;
                        IoC.Resolve<IXMPremiumsService>().UpdateXMPremiums(XMPremium);

                        Item.OtherID = XMPremium.Id;
                        Item.IsEnable = false;
                        Item.CreateDate = Item.UpdateDate = DateTime.Now;
                        Item.CreateID = Item.UpdateID = HozestERPContext.Current.User.CustomerID;
                        IoC.Resolve<IXMSpareAddressService>().InsertXMSpareAddress(Item);
                    }
                }

                if (dt != null)
                {
                    if (resultCount == dt.Rows.Count)
                    {
                        paramMessage = "导入成功！";
                    }
                    else
                    {
                        paramMessage += "应该导入" + dt.Rows.Count + "条，实际导入" + resultCount + "条！";
                    }
                }
            }
        }


        /// <summary>
        /// 导入京东自营采购订单
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportJDSelfPurchaseSupportFromXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {

                excelHelper.Hdr = "NO";//列名当数据读取，强制列为文本类型
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                //Hdr = "NO"的时候列名会变成F1,F2,F3....这些，需要把第一行对应列的值作为列名
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        dt.Columns[col].ColumnName = dr[col].ToString();
                    }
                }
                dt.Rows[0].Delete(); //删除第一列
                dt.AcceptChanges();
                string errMessage = "厂家编码：";
                dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                bool mIsExsit = true;    //厂家编码是否存在
                //遍历搜有记录 判断厂家编码是否存在 如果不存在无法导入
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string platformMerchantCode = dt.Rows[i]["规格代码"].ToString().Trim();//厂家编码
                    if (!string.IsNullOrEmpty(platformMerchantCode))
                    {
                        var product = IoC.Resolve<XMProductService>().getXMProductByManufacturersCode(platformMerchantCode);
                        if (product == null)
                        {
                            mIsExsit = false;
                            errMessage += platformMerchantCode + ",";
                        }
                    }
                }
                if (!mIsExsit)
                {
                    paramMessage += errMessage + "不存在，请修改后导入！\r";
                    return;
                }

                List<XMPurchase> PurchaseInfo = new List<XMPurchase>();
                //获取所有的采购单号
                List<string> purchaes = new List<string>();
                #region   生成采购订单主表数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool isExsit = false;
                    string purchaseNumber = dt.Rows[i]["订单编号"].ToString().Trim();//采购单号
                    string emitFactory = dt.Rows[i]["发出工厂"].ToString().Trim();   //发出工厂
                    string buyerName = dt.Rows[i]["买家会员名"].ToString().Trim();  //买家会员名
                    string resvier = dt.Rows[i]["收件人"].ToString().Trim();      //收件人
                    string mobile = dt.Rows[i]["收件人手机"].ToString().Trim();  //收件人手机
                    string address = dt.Rows[i]["收货地址"].ToString().Trim();    //收货地址
                    string payDate = dt.Rows[i]["支付时间"].ToString().Trim();   //支付时间
                    string createDate = dt.Rows[i]["创建时间"].ToString().Trim();  //创建时间
                    string sellerRemarks = dt.Rows[i]["卖家备注"].ToString().Trim();   //卖家备注
                    string buyerRemarks = dt.Rows[i]["买家留言"].ToString().Trim();  //买家留言
                    string Freight = dt.Rows[i]["运费"].ToString().Trim();     //运费
                    string platformMerchantCode = dt.Rows[i]["规格代码"].ToString().Trim();//厂家编码
                    DateTime date = new DateTime();
                    decimal freight = 0;
                    if (string.IsNullOrEmpty(purchaseNumber))
                    {
                        paramMessage += "采购单号不能为空！\r";
                        continue;
                    }
                    if (string.IsNullOrEmpty(address))
                    {
                        paramMessage += "收货地址不能为空！\r";
                        continue;
                    }
                    if (string.IsNullOrEmpty(platformMerchantCode))
                    {
                        paramMessage += "规格代码不能为空！\r";
                        continue;
                    }
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        string purchaseNumber2 = dt.Rows[j]["订单编号"].ToString().Trim();//采购单号
                        string address2 = dt.Rows[j]["收货地址"].ToString().Trim();    //收货地址
                        string platformMerchantCode2 = dt.Rows[j]["规格代码"].ToString().Trim();//厂家编码
                        if (purchaseNumber == purchaseNumber2 && address.Contains(address2) && platformMerchantCode == platformMerchantCode2)      //判断文件中是否存在重复记录
                        {
                            isExsit = true;
                            paramMessage += "采购单号为" + purchaseNumber + "交货地址为" + address + "的商品订单已经存在导入失败；";
                            break;
                        }
                    }

                    if (isExsit)
                    {
                        continue;
                    }

                    if (!purchaes.Contains(purchaseNumber))
                    {
                        purchaes.Add(purchaseNumber);
                        var puchases = IoC.Resolve<XMPurchaseService>().GetXMPurchaseBypurChaseCode(purchaseNumber);
                        if (puchases != null && puchases.Count > 0)       //采购单已经存在 更新
                        {
                            if (!string.IsNullOrEmpty(emitFactory))
                            {
                                puchases[0].EmitFactory = emitFactory;
                            }
                            if (!string.IsNullOrEmpty(buyerName))
                            {
                                puchases[0].BuyMember = buyerName;
                            }
                            if (!string.IsNullOrEmpty(resvier))
                            {
                                puchases[0].Receiver = resvier;
                            }
                            if (!string.IsNullOrEmpty(mobile))
                            {
                                puchases[0].ReceiverMobile = mobile;
                            }
                            if (!string.IsNullOrEmpty(address))
                            {
                                puchases[0].DealAddress = address;
                            }
                            if (!string.IsNullOrEmpty(payDate))
                            {
                                if (DateTime.TryParse(payDate, out date))
                                {
                                    puchases[0].PayDate = Convert.ToDateTime(payDate);
                                }
                            }
                            if (!string.IsNullOrEmpty(createDate))
                            {
                                if (DateTime.TryParse(createDate, out date))
                                {
                                    puchases[0].Date_Created = Convert.ToDateTime(createDate);
                                }
                            }
                            if (!string.IsNullOrEmpty(sellerRemarks))
                            {
                                puchases[0].SellerRemarks = sellerRemarks;
                            }
                            if (!string.IsNullOrEmpty(buyerRemarks))
                            {
                                puchases[0].BuyerRemarks = buyerRemarks;
                            }
                            if (!string.IsNullOrEmpty(Freight))
                            {
                                if (decimal.TryParse(Freight, out freight))
                                {
                                    puchases[0].Freight = decimal.Parse(Freight);
                                }
                            }
                            IoC.Resolve<XMPurchaseService>().UpdateXMPurchase(puchases[0]);
                            PurchaseInfo.Add(puchases[0]);
                        }
                        else
                        {
                            DateTime dateTime = new DateTime();
                            XMPurchase Info = new XMPurchase();
                            Info.PurchaseNumber = purchaseNumber;
                            Info.SupplierId = 1;
                            Info.BizUserId = Info.InputUserId = HozestERPContext.Current.User.CustomerID;
                            if (!string.IsNullOrEmpty(createDate) && DateTime.TryParse(createDate, out dateTime))
                            {
                                Info.PurchaseDate = DateTime.Parse(createDate);
                            }
                            Info.Date_Created = Info.UpdateDate = DateTime.Now;
                            Info.BillStatus = 0;    //待入库
                            Info.ProductsMoney = 0;
                            Info.PaymentType = 700;//现金付款
                            Info.DealDate = DateTime.Now;
                            Info.IsEnable = false;
                            Info.IsAudit = true;
                            Info.FinancialStatus = false;
                            if (!string.IsNullOrEmpty(emitFactory))
                            {
                                Info.EmitFactory = emitFactory;
                            }
                            if (!string.IsNullOrEmpty(buyerName))
                            {
                                Info.BuyMember = buyerName;
                            }
                            if (!string.IsNullOrEmpty(resvier))
                            {
                                Info.Receiver = resvier;
                            }
                            if (!string.IsNullOrEmpty(mobile))
                            {
                                Info.ReceiverMobile = mobile;
                            }
                            if (!string.IsNullOrEmpty(address))
                            {
                                Info.DealAddress = address;
                            }
                            if (!string.IsNullOrEmpty(payDate))
                            {
                                if (DateTime.TryParse(payDate, out date))
                                {
                                    Info.PayDate = Convert.ToDateTime(payDate);
                                }
                                else
                                {
                                    Info.PayDate = DateTime.Now;
                                }
                            }
                            if (!string.IsNullOrEmpty(createDate))
                            {
                                if (DateTime.TryParse(createDate, out date))
                                {
                                    Info.PurchaseDate = Info.Date_Created = Convert.ToDateTime(createDate);
                                }
                                else
                                {
                                    Info.PurchaseDate = Info.Date_Created = DateTime.Now;
                                }
                            }
                            else
                            {
                                Info.PurchaseDate = Info.Date_Created = DateTime.Now;
                            }
                            if (!string.IsNullOrEmpty(sellerRemarks))
                            {
                                Info.SellerRemarks = sellerRemarks;
                            }
                            if (!string.IsNullOrEmpty(buyerRemarks))
                            {
                                Info.BuyerRemarks = buyerRemarks;
                            }
                            if (!string.IsNullOrEmpty(Freight))
                            {
                                if (decimal.TryParse(Freight, out freight))
                                {
                                    Info.Freight = decimal.Parse(Freight);
                                }
                            }
                            IoC.Resolve<XMPurchaseService>().InsertXMPurchase(Info);
                            PurchaseInfo.Add(Info);
                        }

                    }
                }
                #endregion

                #region     生成采购订单产品详情从表
                if (PurchaseInfo.Count > 0)
                {
                    foreach (XMPurchase parm in PurchaseInfo)
                    {
                        decimal totalAcount = 0;     //总金额
                        var purchaseDetails = IoC.Resolve<XMPurchaseProductDetailsService>().GetXMPurchaseProductDetailsByPurchaseID(parm.Id);
                        if (purchaseDetails != null && purchaseDetails.Count > 0)    //已存在  更新
                        {
                            foreach (DataRow row1 in dt.Rows)
                            {
                                string purchaseNumber = row1["订单编号"].ToString().Trim();//采购单号
                                string count = row1["数量"].ToString().Trim();//数量
                                string platformMerchantCode = row1["规格代码"].ToString().Trim();//厂家编码
                                string productPrice = row1["商品单价"].ToString().Trim();               //商品单价 
                                int a = 0;
                                decimal b = 0;
                                if (string.IsNullOrEmpty(count) || int.TryParse(count, out a) == false)
                                {
                                    paramMessage += "商品数量：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(platformMerchantCode))
                                {
                                    paramMessage += "商品厂家编码：'" + count + "'不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(productPrice) || decimal.TryParse(productPrice, out b) == false)
                                {
                                    paramMessage += "商品单价：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (parm.PurchaseNumber == purchaseNumber)
                                {
                                    foreach (XMPurchaseProductDetails f in purchaseDetails)
                                    {
                                        if (platformMerchantCode == f.PlatformMerchantCode)
                                        {
                                            f.ProductCount = int.Parse(count);
                                            f.ProductPrice = decimal.Parse(productPrice);
                                            f.ProductMoney = int.Parse(count) * decimal.Parse(productPrice);
                                            totalAcount += f.ProductMoney;
                                            f.UpdateDate = DateTime.Now;
                                            f.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            IoC.Resolve<XMPurchaseProductDetailsService>().UpdateXMPurchaseProductDetails(f);
                                        }
                                    }
                                }
                            }
                            //更新应收账款 应收金额数据
                            var replypayment = IoC.Resolve<XMPaymentApplyService>().GetXMPaymentApplyByPurchaseID(parm.Id);
                            if (replypayment != null)
                            {
                                replypayment.PayAmounts = totalAcount;
                                replypayment.UpdateDate = DateTime.Now;
                                replypayment.UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<XMPaymentApplyService>().UpdateXMPaymentApply(replypayment);
                            }
                        }
                        else
                        {
                            foreach (DataRow row1 in dt.Rows)
                            {
                                string purchaseNumber = row1["订单编号"].ToString().Trim();//采购单号
                                string count = row1["数量"].ToString().Trim();//数量
                                string platformMerchantCode = row1["规格代码"].ToString().Trim();//厂家编码
                                string productPrice = row1["商品单价"].ToString().Trim();               //商品单价 
                                int a = 0;
                                decimal b = 0;

                                if (string.IsNullOrEmpty(count) || int.TryParse(count, out a) == false)
                                {
                                    paramMessage += "商品数量：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(platformMerchantCode))
                                {
                                    paramMessage += "商品厂家编码：'" + count + "'不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(productPrice) || decimal.TryParse(productPrice, out b) == false)
                                {
                                    paramMessage += "商品单价：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }

                                if (parm.PurchaseNumber == purchaseNumber)
                                {
                                    if (int.Parse(count) > 0)
                                    {
                                        XMPurchaseProductDetails details = new XMPurchaseProductDetails();
                                        if (!string.IsNullOrEmpty(platformMerchantCode))
                                        {
                                            details.PlatformMerchantCode = platformMerchantCode;
                                        }
                                        details.PurchaseId = parm.Id;
                                        var Products = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(platformMerchantCode);
                                        if (Products != null)
                                        {
                                            details.ProductId = Products.Id;
                                        }
                                        details.ProductCount = int.Parse(count);
                                        details.ProductPrice = decimal.Parse(productPrice);
                                        details.ProductMoney = int.Parse(count) * decimal.Parse(productPrice);
                                        totalAcount += int.Parse(count) * decimal.Parse(productPrice);
                                        details.CreateDate = details.UpdateDate = DateTime.Now;
                                        details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        details.IsEnable = false;
                                        details.PlatformTypeId = 537;//京东自营
                                        IoC.Resolve<IXMPurchaseProductDetailsService>().InsertXMPurchaseProductDetails(details);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }

                        #region   自动生成应付账款

                        var Payments = IoC.Resolve<XMPaymentApplyService>().GetXMPaymentApplyByPurchaseID(parm.Id);
                        if (Payments == null)
                        {
                            XMPaymentApply PaymentApply = new XMPaymentApply();
                            PaymentApply.PurchaseID = parm.Id;
                            PaymentApply.PayAmounts = totalAcount;
                            PaymentApply.PayMode = parm.PaymentType.Value;
                            PaymentApply.SupplierID = parm.SupplierId;
                            PaymentApply.RequstDate = DateTime.Now;
                            PaymentApply.UserDate = parm.PurchaseDate;
                            PaymentApply.ApplicantID = HozestERPContext.Current.User.CustomerID;
                            PaymentApply.UpdateDate = DateTime.Now;
                            PaymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
                            PaymentApply.IsAudit = true;
                            PaymentApply.FinancialStatus = true;
                            PaymentApply.IsAuditPerson = PaymentApply.FinancialStatusPerson = HozestERPContext.Current.User.CustomerID;
                            PaymentApply.IsAuditDate = PaymentApply.FinancialStatusDate = DateTime.Now;
                            PaymentApply.FinancialConfirm = false;
                            PaymentApply.IsEnable = false;
                            IoC.Resolve<IXMPaymentApplyService>().InsertXMPaymentApply(PaymentApply);
                        }

                        #endregion

                        parm.ProductsMoney = totalAcount;
                        parm.UpdateDate = DateTime.Now;
                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                        IoC.Resolve<XMPurchaseService>().UpdateXMPurchase(parm);

                        resultCount++;
                    }
                }
                #endregion

                if (dt != null)
                {
                    paramMessage += "导入成功！实际导入" + resultCount + "条！";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportProductionNumberFromXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "订单号 is not null and (Convert(订单号, 'System.String')<>'' or Convert(订单号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();
                foreach (DataRow row1 in dt.Rows)
                {
                    string orderCode = row1["订单号"].ToString().Trim();//订单号
                    string productionNumber = row1["生产单号"].ToString().Trim();//生产单号
                    string storageDate = row1["预计入库时间"].ToString().Trim();  //预计入库时间
                    string manufacturersCode = row1["产品编码"].ToString().Trim();     //厂家编码
                    if (string.IsNullOrEmpty(orderCode))
                    {
                        paramMessage += "订单号不能为空！\r";
                        continue;
                    }
                    if (string.IsNullOrEmpty(storageDate))
                    {
                        paramMessage += "订单号为" + orderCode + "预计入库时间不能为空！\r";
                        continue;
                    }
                    if (string.IsNullOrEmpty(manufacturersCode))
                    {
                        paramMessage += "厂家编码不能为空！\r";
                        continue;
                    }
                    DateTime date = new DateTime();
                    if (!DateTime.TryParse(storageDate, out date))
                    {
                        paramMessage += "订单号为" + orderCode + "预计入库时间格式不正确！\r";
                        continue;
                    }

                    var productionOrders = IoC.Resolve<XMProductionOrderService>().GetXMProductionOrderInfoByOrderCode(orderCode);
                    if (productionOrders != null)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            productionOrders.ProductionNumber = productionNumber;
                            productionOrders.EstimateStorageDate = Convert.ToDateTime(storageDate);
                            productionOrders.UpdateID = HozestERPContext.Current.User.CustomerID;
                            productionOrders.UpdateDate = DateTime.Now;
                            IoC.Resolve<XMProductionOrderService>().UpdateXMProductionOrder(productionOrders);
                            var productionOrderDetails = IoC.Resolve<XMProductionOrderDetailsService>().GetXMProductionOrderDetailsListByProductionOrderID(productionOrders.Id);
                            if (productionOrderDetails != null && productionOrderDetails.Count > 0)
                            {
                                foreach (XMProductionOrderDetails p in productionOrderDetails)
                                {
                                    if (manufacturersCode == p.ManufacturersCode)
                                    {
                                        //更新
                                        p.ProductionNumber = productionNumber;
                                        p.EstimateStorageDate = Convert.ToDateTime(storageDate);
                                        p.UpdateDate = DateTime.Now;
                                        p.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        IoC.Resolve<XMProductionOrderDetailsService>().UpdateXMProductionOrderDetails(p);
                                    }
                                }
                            }
                            scope.Complete();
                        }
                    }
                    resultCount++;
                }
                if (dt != null)
                {
                    paramMessage += "导入成功！实际导入" + resultCount + "条！";
                }
            }
        }


        /// <summary>
        /// 导入京东自营采购入库单
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportJDSelfSupportFromXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                List<XMStorage> storageInfo = new List<XMStorage>();
                //获取单所有的入库号
                List<string> storages = new List<string>();
                #region   生成采购入库订单主表数据
                foreach (DataRow row1 in dt.Rows)
                {
                    DateTime date = new DateTime();
                    string storageNumber = row1["订单编号"].ToString().Trim();//入库单号
                    string address = row1["收货地址"].ToString().Trim();    //收货地址
                    string storageDate = row1["入库时间"].ToString().Trim();  //入库时间
                    string storageWareHoueseName = row1["入库仓库"].ToString().Trim();  //入库仓库
                    string ManufacturersCode = row1["规格代码"].ToString().Trim();     //厂家编码
                    string count = row1["入库数量"].ToString().Trim();//入库数量
                    if (string.IsNullOrEmpty(storageNumber))
                    {
                        paramMessage += "入库单号不能为空！\r";
                        continue;
                    }

                    if (!storages.Contains(storageNumber))
                    {
                        ImportPurchase importPurchase = IoC.Resolve<IXMPurchaseService>().GetDetail(storageNumber, ManufacturersCode);
                        //ImportStorage importStorage = IoC.Resolve<IXMStorageService>().GetDetail(storageNumber, ManufacturersCode);
                        int count1 = string.IsNullOrEmpty(count) ? 0 : int.Parse(count);
                        if(importPurchase.ProductCount> count1)
                        {
                            DateTime now = DateTime.Now;
                            int userID = HozestERPContext.Current.User.CustomerID;
                            var warehouse = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseByWareHousesName(storageWareHoueseName);
                            var nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)warehouse[0].NickId);
                            var product = IoC.Resolve<IXMProductService>().GetXMProductListByCode(ManufacturersCode, nick.PlatformTypeId);
                            var jdSaleRejectedentityList = IoC.Resolve<IXMJDSaleRejectedService>().GetXMJDSaleRejectedBySaleRejectCode(storageNumber);
                            XMJDSaleRejected xmJDSaleRejected = null;
                            if (jdSaleRejectedentityList.Count<=0)
                            {
                                xmJDSaleRejected = new XMJDSaleRejected();
                                xmJDSaleRejected.Ref = storageNumber;
                                xmJDSaleRejected.ReturnMoney = 0;
                                xmJDSaleRejected.ReturnCategoryID = 715;
                                xmJDSaleRejected.BizUserId = userID;
                                xmJDSaleRejected.BizDt = now;
                                xmJDSaleRejected.CreateID = userID;
                                xmJDSaleRejected.CreateDate = now;
                                xmJDSaleRejected.UpdateID = userID;
                                xmJDSaleRejected.UpdateDate = now;
                                xmJDSaleRejected.IsEnable = false;
                                xmJDSaleRejected.NickId = nick.nick_id;
                                xmJDSaleRejected.Note = "采购单号，入库仓库";
                                IoC.Resolve<IXMJDSaleRejectedService>().InsertXMJDSaleRejected(xmJDSaleRejected);
                            }
                            else
                            {
                                xmJDSaleRejected = jdSaleRejectedentityList[0];
                            }

                            XMJDSaleRejectedProductDetail xmJDSaleRejectedProductDetail = new XMJDSaleRejectedProductDetail();
                            xmJDSaleRejectedProductDetail.JDRejectedID = xmJDSaleRejected.Id;
                            xmJDSaleRejectedProductDetail.ProductId = product[0].Id;
                            xmJDSaleRejectedProductDetail.PlatformMerchantCode = product[0].PlatformMerchantCode;
                            xmJDSaleRejectedProductDetail.RejectionCount = importPurchase.ProductCount - count1;
                            xmJDSaleRejectedProductDetail.CreateID = userID;
                            xmJDSaleRejectedProductDetail.CreateDate = now;
                            xmJDSaleRejectedProductDetail.UpdateID = userID;
                            xmJDSaleRejectedProductDetail.UpdateDate = now;
                            xmJDSaleRejectedProductDetail.IsEnable = false;
                            xmJDSaleRejectedProductDetail.JDIsConfirm = false;
                            xmJDSaleRejectedProductDetail.XBIsConfirm = false;
                            xmJDSaleRejectedProductDetail.XLMIsConfirm = false;
                            IoC.Resolve<IXMJDSaleRejectedProductDetailService>().InsertXMJDSaleRejectedProductDetail(xmJDSaleRejectedProductDetail);

                        }
                        storages.Add(storageNumber);
                        var storagesInfo = IoC.Resolve<XMStorageService>().GetXMStorageByRef(storageNumber);
                        if (storagesInfo != null && storagesInfo.Count > 0)     //已经存在该采购入库单  再次导入覆盖更新内容
                        {
                            //更新数据
                            storageInfo.Add(storagesInfo[0]);
                        }
                        else
                        {
                            var purchases = IoC.Resolve<XMPurchaseService>().GetXMPurchaseBypurChaseCode(storageNumber);
                            XMStorage Info = new XMStorage();
                            Info.Ref = storageNumber;
                            Info.SupplierId = 1;
                            if (purchases != null && purchases.Count > 0)
                            {
                                Info.PurchaseId = purchases[0].Id;
                            }
                            else 
                            {
                                paramMessage = "采购订单" + storageNumber + "不存在！";
                                return;
                            }
                            //获取入库仓库ID
                            var wareHoures = IoC.Resolve<XMWareHousesService>().GetXMWarehouseByWareHousesName(storageWareHoueseName);
                            if (wareHoures != null && wareHoures.Count > 0)
                            {
                                Info.WareHouseId = wareHoures[0].Id;
                            }
                            else
                            {
                                paramMessage += "入库单号为" + storageNumber + "的入库仓库不存在！\r";
                                continue;
                            }
                            Info.BizUserId = Info.CreateID = HozestERPContext.Current.User.CustomerID;
                            Info.BizDt = Info.CreateDate = Info.UpdateDate = DateTime.Now;
                            Info.BillStatus = 0;    //待入库
                            Info.ProductsMoney = 0;
                            Info.PaymentType = 700;//现金付款
                            if (!string.IsNullOrEmpty(storageDate) && DateTime.TryParse(storageDate, out date))
                            {
                                Info.StorageDate = Convert.ToDateTime(storageDate);
                            }
                            else
                            {
                                Info.StorageDate = DateTime.Now;
                            }
                            Info.IsEnable = false;
                            Info.IsAudit = true;
                            IoC.Resolve<XMStorageService>().InsertXMStorage(Info);
                            storageInfo.Add(Info);
                        }
                    }
                }
                #endregion

                #region  生成采购入库单产品详情从表

                if (storageInfo.Count() > 0)
                {
                    foreach (XMStorage parm in storageInfo)
                    {
                        decimal totalAcount = 0;     //总金额

                        var storageDetails = IoC.Resolve<XMStorageProductDetailsService>().GetXMStorageProductDetailsByStorageID(parm.Id);
                        if (storageDetails != null && storageDetails.Count > 0)           //已导入过 数据已经存在  再次导入 更新数据
                        {
                            List<StorageProductDetailInfos> Lists = new List<StorageProductDetailInfos>();
                            //删除原来的数据 从新插入新数据
                            foreach (XMStorageProductDetails s in storageDetails)
                            {
                                s.IsEnable = true;
                                s.UpdateDate = DateTime.Now;
                                s.UpdateID = HozestERPContext.Current.User.CustomerID;
                                IoC.Resolve<XMStorageProductDetailsService>().UpdateXMStorageProductDetails(s);
                            }
                            //循环插入入库单产品详情
                            foreach (DataRow row1 in dt.Rows)
                            {
                                string storageNumber = row1["订单编号"].ToString().Trim();//采购入库单单号
                                string count = row1["入库数量"].ToString().Trim();//入库数量
                                string purchaseCount = row1["数量"].ToString().Trim();//采购数量
                                string productPrice = row1["商品单价"].ToString().Trim();               //采购价格 
                                string ManufacturersCode = row1["规格代码"].ToString().Trim();     //厂家编码
                                int a = 0;
                                int c = 0;
                                decimal b = 0;
                               
                                if (string.IsNullOrEmpty(count) || int.TryParse(count, out a) == false)
                                {
                                    paramMessage += "入库数量：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(purchaseCount) || int.TryParse(purchaseCount, out c) == false)
                                {
                                    paramMessage += "采购数量：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (int.Parse(purchaseCount) - int.Parse(count) < 0)
                                {
                                    paramMessage += "入库单号为：'" + storageNumber + "的订单入库量不能大于采购量！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(ManufacturersCode))
                                {
                                    paramMessage += "厂家编码：'" + ManufacturersCode + "'不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(productPrice) || decimal.TryParse(productPrice, out b) == false)
                                {
                                    paramMessage += "商品单价：'" + productPrice + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                //判断采购单中是否有这个商品
                                var purchases = IoC.Resolve<XMPurchaseService>().GetXMPurchaseBypurChaseCode(storageNumber);
                                if (purchases.Count > 0)
                                {
                                    var purchasesDetails = IoC.Resolve<XMPurchaseProductDetailsService>().GetXMPurchaseProductDetailsByPurchaseID(purchases[0].Id);
                                    purchasesDetails = purchasesDetails.Where(p => p.PlatformMerchantCode.Equals(ManufacturersCode)).ToList();
                                    if (purchasesDetails.Count == 0)
                                    {
                                        paramMessage += "采购单" + storageNumber + "中采购商品" + ManufacturersCode + "不存在！";
                                        return;
                                    }
                                }
                                if (parm.Ref == storageNumber)
                                {
                                    XMStorageProductDetails details = new XMStorageProductDetails();
                                    details.PlatformMerchantCode = ManufacturersCode;
                                    details.StorageId = parm.Id;
                                    var Products = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                                    if (Products != null)
                                    {
                                        details.ProductId = Products.Id;
                                    }
                                    details.ProductsCount = int.Parse(count);
                                    details.ProductsPrice = decimal.Parse(productPrice);
                                    details.ProductsMoney = int.Parse(count) * decimal.Parse(productPrice);
                                    totalAcount += int.Parse(count) * decimal.Parse(productPrice);
                                    details.CreateDate = details.UpdateDate = DateTime.Now;
                                    details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    details.IsEnable = false;
                                    IoC.Resolve<IXMStorageProductDetailsService>().InsertXMStorageProductDetails(details);

                                    StorageProductDetailInfos storageDeatail = new StorageProductDetailInfos();
                                    storageDeatail.refNumber = storageNumber;
                                    storageDeatail.ManufacturersCode = ManufacturersCode;
                                    storageDeatail.purcahseCount = int.Parse(purchaseCount);
                                    storageDeatail.storageCount = int.Parse(count);
                                    storageDeatail.puchasePrice = decimal.Parse(productPrice);
                                    Lists.Add(storageDeatail);
                                }
                            }
                            parm.ProductsMoney = totalAcount;
                            parm.UpdateDate = DateTime.Now;
                            parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                            IoC.Resolve<XMStorageService>().UpdateXMStorage(parm);

                            //新增采购退货单数据
                            //AutoInsertPurchaseRejectedData(Lists, parm.Ref);
                        }
                        else
                        {
                            List<StorageProductDetailInfos> Lists = new List<StorageProductDetailInfos>();
                            //循环插入入库单产品详情
                            foreach (DataRow row1 in dt.Rows)
                            {
                                string storageNumber = row1["订单编号"].ToString().Trim();//采购入库单单号
                                string count = row1["入库数量"].ToString().Trim();//入库数量
                                string purchaseCount = row1["数量"].ToString().Trim();//采购数量
                                string productPrice = row1["商品单价"].ToString().Trim();               //采购价格 
                                string ManufacturersCode = row1["规格代码"].ToString().Trim();     //厂家编码
                                int a = 0;
                                int c = 0;
                                decimal b = 0;
                                
                                if (string.IsNullOrEmpty(count) || int.TryParse(count, out a) == false)
                                {
                                    paramMessage += "入库数量：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(purchaseCount) || int.TryParse(purchaseCount, out c) == false)
                                {
                                    paramMessage += "采购数量：'" + count + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                if (int.Parse(purchaseCount) - int.Parse(count) < 0)
                                {
                                    paramMessage += "入库单号为：'" + storageNumber + "的订单入库量不能大于采购量！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(ManufacturersCode))
                                {
                                    paramMessage += "厂家编码：'" + ManufacturersCode + "'不能为空！\r";
                                    continue;
                                }
                                if (string.IsNullOrEmpty(productPrice) || decimal.TryParse(productPrice, out b) == false)
                                {
                                    paramMessage += "商品单价：'" + productPrice + "'数据类型不正确或不能为空！\r";
                                    continue;
                                }
                                //判断采购单是否存在以及采购单中是否有这个商品
                                var purchases = IoC.Resolve<XMPurchaseService>().GetXMPurchaseBypurChaseCode(storageNumber);
                                if (purchases.Count > 0)
                                {
                                    var purchasesDetails = IoC.Resolve<XMPurchaseProductDetailsService>().GetXMPurchaseProductDetailsByPurchaseID(purchases[0].Id);
                                    purchasesDetails = purchasesDetails.Where(p => p.PlatformMerchantCode.Equals(ManufacturersCode)).ToList();
                                    if (purchasesDetails.Count == 0)
                                    {
                                        paramMessage = "采购单" + storageNumber + "中采购商品" + ManufacturersCode + "不存在！";
                                        return;
                                    }
                                }
                                if (parm.Ref == storageNumber)
                                {
                                    XMStorageProductDetails details = new XMStorageProductDetails();
                                    details.PlatformMerchantCode = ManufacturersCode;
                                    details.StorageId = parm.Id;
                                    var Products = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                                    if (Products != null)
                                    {
                                        details.ProductId = Products.Id;
                                    }
                                    details.ProductsCount = int.Parse(count);
                                    details.ProductsPrice = decimal.Parse(productPrice);
                                    details.ProductsMoney = int.Parse(count) * decimal.Parse(productPrice);
                                    totalAcount += int.Parse(count) * decimal.Parse(productPrice);
                                    details.CreateDate = details.UpdateDate = DateTime.Now;
                                    details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    details.IsEnable = false;
                                    IoC.Resolve<IXMStorageProductDetailsService>().InsertXMStorageProductDetails(details);
                                    StorageProductDetailInfos storageDeatail = new StorageProductDetailInfos();
                                    storageDeatail.refNumber = storageNumber;
                                    storageDeatail.ManufacturersCode = ManufacturersCode;
                                    storageDeatail.purcahseCount = int.Parse(purchaseCount);
                                    storageDeatail.storageCount = int.Parse(count);
                                    storageDeatail.puchasePrice = decimal.Parse(productPrice);
                                    Lists.Add(storageDeatail);
                                }
                            }
                            //新增采购退货单数据
                            //AutoInsertPurchaseRejectedData(Lists, parm.Ref);
                        }
                        parm.ProductsMoney = totalAcount;
                        parm.UpdateDate = DateTime.Now;
                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                        IoC.Resolve<XMStorageService>().UpdateXMStorage(parm);
                        resultCount++;
                    }
                }
                #endregion

                if (dt != null)
                {
                    paramMessage += "导入成功！实际导入" + resultCount + "条！";
                }
            }
        }

        /// <summary>
        /// 订单归属客服导入
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="paramMessage">返回结果</param>
        public void ImportOrderAscriptionFormXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";
                int resultCount = 0;
                DataTable dt = null;
                dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "订单编号 is not null and (Convert(订单编号, 'System.String')<>'' or Convert(订单编号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();
                foreach (DataRow datarow in dt.Rows)
                {
                    string paramOrderCode = datarow["订单编号"].ToString().Trim();
                    string paramCustomerService = datarow["客服"].ToString().Trim();
                    XMOrderInfo paramOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(paramOrderCode);
                    List<CustomerInfo> CustomerInfoList = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoListInSearch(-1, paramCustomerService, -1, false);
                    if (CustomerInfoList.Count > 0)
                    {
                        if (paramOrderInfo != null)
                        {
                            paramOrderInfo.BelongsServiceId = CustomerInfoList[0].CustomerID;
                            IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(paramOrderInfo);
                            resultCount++;
                        }
                    }
                }
                if (dt != null)
                {
                    paramMessage += "导入成功！应导入" + dt.Rows.Count + "条实际导入" + resultCount + "条！";
                }
            }
        }

        /// <summary>
        /// 物流干线费用导入
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="paramMessage">返回结果</param>
        public void ImportLogisticsFeeMainXls(string filePath, ref string paramMessage)
        {
            var CodeService = IoC.Resolve<ICodeService>();
            var XMProjectService = IoC.Resolve<IXMProjectService>();
            var XMLogisticsFeeMainService = IoC.Resolve<IXMLogisticsFeeMainService>();
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                try
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "1";
                    int resultCount = 0;
                    DataTable dt = null;
                    dt = excelHelper.ReadTable("Sheet1");

                    foreach (DataRow datarow in dt.Rows)
                    {
                        string projectName = datarow["项目"].ToString().Trim();
                        string wareHouse = datarow["发货仓"].ToString().Trim();
                        string province = datarow["省"].ToString().Trim();
                        string city = datarow["市"].ToString().Trim();
                        string area = datarow["地区"].ToString().Trim();
                        string logisticeCompany = datarow["快递公司"].ToString().Trim();
                        string fee = datarow["费用"].ToString().Trim();

                        XMProject entity_xmProject = XMProjectService.GetXMProjectByName(projectName);
                        if (entity_xmProject == null)
                        {
                            throw new Exception("项目 " + projectName + " 找不到匹配项，请调整后重试");
                        }

                        List<CodeList> codeList = CodeService.GetCodeListInfoByCodeTypeIDAndCodeName(227, wareHouse);
                        if (codeList.Count <= 0)
                        {
                            throw new Exception("发货仓 " + wareHouse + " 找不到匹配项，请调整后重试");
                        }

                        List<CodeList> codeList_1 = CodeService.GetCodeListInfoByCodeTypeIDAndCodeName(243, logisticeCompany);
                        if (codeList_1.Count <= 0)
                        {
                            throw new Exception("快递公司 " + logisticeCompany + " 找不到匹配项，请调整后重试");
                        }

                        decimal logisticsFee = 0;
                        decimal.TryParse(fee, out logisticsFee);

                        int wareHouseID = codeList[0].CodeID;
                        int logisticsID = codeList_1[0].CodeID;
                        XMLogisticsFeeMain entity = XMLogisticsFeeMainService.getSingle(a => a.ProjectID == entity_xmProject.Id
                         && a.WareHouseID == wareHouseID && a.Province == province && a.City == city && a.Area == area
                         && a.LogisticsID == logisticsID);

                        if (entity != null)
                        {
                            continue;
                        }

                        XMLogisticsFeeMainService.InsertXMLogisticsFeeMain(new XMLogisticsFeeMain()
                        {
                            ProjectID = entity_xmProject.Id,
                            WareHouseID = wareHouseID,
                            Province = province,
                            City = city,
                            Area = area,
                            LogisticsID = logisticsID,
                            Fee = logisticsFee,
                        }, false);

                        resultCount++;
                    }

                    if (resultCount !=0)
                    {
                        XMLogisticsFeeMainService.saveChanges();
                    }

                    paramMessage = "导入成功！应导入" + dt.Rows.Count + "条实际导入" + resultCount + "条！";
                }
                catch(Exception ex)
                {
                    paramMessage = ex.Message;
                }

            }
        }

        /// <summary>
        /// 理赔管路页面数据导入
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="paramMessage"></param>
        public void ImportClaimInfoXls(string filePath, ref string paramMessage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                var XMClaimInfoService = IoC.Resolve<IXMClaimInfoService>();
                var XMClaimInfoDetailService = IoC.Resolve<IXMClaimInfoDetailService>();

                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";

                //int resultCount = 0;

                DataTable dt= excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "物流单号 is not null and (Convert(物流单号, 'System.String')<>'' or Convert(物流单号, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                var query = from p in dt.AsEnumerable()
                            group p by p.Field<string>("物流单号") into g
                            select new
                            {
                                key=g.Key,
                                claimMoney=g.Sum(p=> p.Field<double>("索赔金额"))
                            };

                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach(var item in query)
                    {
                        XMClaimInfo entity_ClaimInfo = XMClaimInfoService.GetXMClaimInfoByLogisticsNumber(item.key);
                        if(entity_ClaimInfo==null)
                        {
                            throw new Exception("物流单号: " + item.key + " 记录不存在，请重新核对数据");
                        }
                        List<XMClaimInfoDetail> list_ClaimInfoDetail = XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(entity_ClaimInfo.Id);
                        if(list_ClaimInfoDetail.Count<=0)
                        {
                            throw new Exception("字数据不存在，请联系管理员");
                        }

                        XMClaimInfoDetail entity_ClaimInfoDetail = list_ClaimInfoDetail[0];
                        entity_ClaimInfoDetail.ClaimReal = Convert.ToDecimal(item.claimMoney);
                        entity_ClaimInfoDetail.IsConfirm = true;

                        XMClaimInfoDetailService.UpdateXMClaimInfoDetail(entity_ClaimInfoDetail);
                    }

                    scope.Complete();
                }

                paramMessage = "导入成功";
            }
        }

        public void ImportFactoryPriceXls(string filePath, ref string paramMessage)
        {
            var XMProductDetailsService = IoC.Resolve<IXMProductDetailsService>();

            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";

                DataTable dt = excelHelper.ReadTable("Sheet1");
                dt.DefaultView.RowFilter = "厂家编码 is not null and (Convert(厂家编码, 'System.String')<>'' or Convert(厂家编码, 'System.Int32')>0)";
                dt = dt.DefaultView.ToTable();

                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (DataRow row1 in dt.Rows)
                    {
                        string ManufacturersCode = row1["厂家编码"].ToString().Trim();
                        decimal price = decimal.Parse(row1["出厂价"].ToString().Trim());

                        var product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                        if (product != null)
                        {
                            List<XMProductDetails> list = XMProductDetailsService.GetXMProductDetailsListByProductId(product.Id);
                            foreach (var item in list)
                            {
                                decimal newSalePrice = (price * (decimal)item.Saleprice) / (decimal)item.Costprice;
                                item.Costprice = price;
                                item.Saleprice = Convert.ToDecimal((int)(newSalePrice + (decimal)0.5));
                                XMProductDetailsService.UpdateXMProductDetails(item);
                            }
                        }
                        else
                        {
                            throw new Exception("厂家编码：" + ManufacturersCode + "不存在！");
                        }

                    }
                    scope.Complete();
                }

            }
            paramMessage = "导入成功";
        }

        /// <summary>
        ///根据采购单和采购入库单对比自动生成采购退货单     如 采购数量 大于采购入库数量       被拒件（采购数量-采购入库数量 ）
        /// </summary>
        public void AutoInsertPurchaseRejectedData(List<StorageProductDetailInfos> list, string refNumber)
        {
            var PurchaseRejecteds = IoC.Resolve<XMPurchaseRejectedService>().GetXMPurchaseRejectedsByRef(refNumber);
            if (PurchaseRejecteds == null)
            {
                List<XMPurchaseRejectedProductDetails> PurchaseRejectedList = new List<XMPurchaseRejectedProductDetails>();
                if (list != null && list.Count > 0)
                {
                    foreach (StorageProductDetailInfos Info in list)
                    {
                        int ccCount = Info.purcahseCount - Info.storageCount;
                        if (ccCount > 0)
                        {
                            //生成采购退货单
                            XMPurchaseRejectedProductDetails detaisl = new XMPurchaseRejectedProductDetails();
                            var products = IoC.Resolve<XMProductService>().getXMProductByManufacturersCode(Info.ManufacturersCode);
                            if (products != null)
                            {
                                detaisl.ProductId = products.Id;
                            }
                            detaisl.PlatformMerchantCode = Info.ManufacturersCode;
                            detaisl.RejectionCount = ccCount;    //残次件数量
                            detaisl.RejectionProductPrice = Info.puchasePrice;
                            detaisl.RejectionMoney = ccCount * Info.puchasePrice;
                            detaisl.CreateDate = detaisl.UpdateDate = DateTime.Now;
                            detaisl.CreateID = detaisl.UpdateID = HozestERPContext.Current.User.CustomerID;
                            detaisl.IsEnable = false;
                            detaisl.BillStatus = 0;    //默认为待退回
                            PurchaseRejectedList.Add(detaisl);
                        }
                    }
                }

                //自动生成采购退货单主表及从表数据
                if (PurchaseRejectedList.Count > 0)
                {
                    //生成采购退货单主表
                    XMPurchaseRejected d = new XMPurchaseRejected();
                    d.Ref = refNumber;
                    var purchaseInfo2 = IoC.Resolve<XMPurchaseService>().GetXMPurchaseBypurChaseCode(refNumber);
                    if (purchaseInfo2 != null && purchaseInfo2.Count > 0)
                    {
                        d.MId = purchaseInfo2[0].Id;
                        d.EmitFactory = purchaseInfo2[0].EmitFactory;   //发出工厂
                    }
                    d.SupplierId = 1;
                    d.BizUserId = HozestERPContext.Current.User.CustomerID;
                    d.BizDt = DateTime.Now;
                    d.BillStatus = 0;       //状态 待退货
                    d.RejectionMoney = PurchaseRejectedList.Sum(p => p.RejectionMoney);
                    d.ReceivingType = 700;
                    d.CreateDate = d.UpdateDate = DateTime.Now;
                    d.CreateID = d.UpdateID = HozestERPContext.Current.User.CustomerID;
                    d.IsEnable = false;
                    d.IsAudit = true;
                    d.IsStoraged = false;

                    IoC.Resolve<XMPurchaseRejectedService>().InsertXMPurchaseRejected(d);

                    //生成采购退货单明细表
                    foreach (XMPurchaseRejectedProductDetails p in PurchaseRejectedList)
                    {
                        p.PrId = d.Id;
                        IoC.Resolve<XMPurchaseRejectedProductDetailsService>().InsertXMPurchaseRejectedProductDetails(p);
                    }
                }
            }
        }

        public void ImportBillsXls(string filePath,int SuppliersId,ref string paramMessage)
        {
            var XMProductDetailsService = IoC.Resolve<IXMProductDetailsService>();

            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "1";

                DataTable dt = excelHelper.ReadTable("Sheet1");
                #region 判断excel中是否有错误数据
                dt.DefaultView.RowFilter = "发货单号 is null or 商品编码 is null or 数量 is null or 价格 is null ";
                DataTable dtNUll = dt.DefaultView.ToTable();
                if (dtNUll.Rows.Count > 0)
                {
                    paramMessage = "发货单号,商品编码,数量,价格这四列为必填，不能为空";
                    return;
                }

                dt.DefaultView.RowFilter = "Convert(发货单号, 'System.String') = '" + string.Empty + "' or Convert(发货单号, 'System.String') = 'NULL' or Convert(商品编码, 'System.String') = '" + string.Empty + "' or Convert(商品编码, 'System.String') = 'NULL' or Convert(数量, 'System.String') = '" + string.Empty + "' or Convert(数量, 'System.String') = 'NULL' or Convert(价格, 'System.String') = '" + string.Empty + "' or Convert(价格, 'System.String') = 'NULL'";
                dtNUll = dt.DefaultView.ToTable();
                if (dtNUll.Rows.Count > 0)
                {
                    paramMessage = "发货单号,商品编码,价格,数量有''值或者NULL值";
                    return;
                }
                dt.DefaultView.RowFilter = "Convert(数量, 'System.Int32') <= 0 or Convert(价格, 'System.Decimal') <= 0";
                dtNUll = dt.DefaultView.ToTable();
                if (dtNUll.Rows.Count > 0)
                {
                    paramMessage = "价格或者数量中有小于等于0的值";
                    return;
                }
                #endregion
                dt.DefaultView.RowFilter = "发货单号 is not null and Convert(发货单号, 'System.String')<>'' and 商品编码 is not null and Convert(商品编码, 'System.String') <> '' and 数量 is not null and Convert(数量, 'System.Int32') > 0 and 价格 is not null and Convert(价格, 'System.Decimal') > 0";
                dt = dt.DefaultView.ToTable();
                using (TransactionScope scope = new TransactionScope())
                {
                    var xmBillsList = new List<XMBills>();
                    foreach (DataRow row1 in dt.Rows)
                    {
                        string DeliveryNumber = row1["发货单号"].ToString().Trim();
                        string PlatformMerchantCode = row1["商品编码"].ToString().Trim();
                        int ProductNum = int.Parse(row1["数量"].ToString().Trim());
                        decimal Price = decimal.Parse(row1["价格"].ToString().Trim());
                       
                        var entity = new XMBills()
                        {
                            DeliveryNumber = DeliveryNumber,
                            PlatformMerchantCode = PlatformMerchantCode,
                            ProductNum = ProductNum,
                            Price = Price,
                            SuppliersID = SuppliersId,
                            VerificationStatus = Convert.ToString((int)status.未核销),
                            CreatebyName = HozestERPContext.Current.User.Username,
                            CreateDate = DateTime.Now
                        };
                        xmBillsList.Add(entity);
                    }
                    IoC.Resolve<XMBillsService>().InsertXMBills(xmBillsList);
                    scope.Complete();
                }

            }
            paramMessage = "导入成功";
        }

    }

    public class StorageProductDetailInfos
    {
        public string refNumber;    //入库单号
        public string ManufacturersCode;   //商品厂家编码
        public int purcahseCount;   // 采购数量
        public int storageCount;  //实收数量
        public decimal puchasePrice;  //采购单价
    }
}
