using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
//using Microsoft.Office.Interop.Word;
using Aspose.Words;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ExportImport;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.ExportImport
{
    public partial class ExportManager : IExportManager
    {
        #region IExportManager 成员
        /// <summary>
        /// 日日顺导出订单数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderInfos"></param>
        /// <param name="projectID"></param>
        public void ExportRiRiShunXMOrderInfoToXls(string filePath, List<XMOrderInfo> orderInfos, int projectID)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("商户编码", "nvarchar(50)");
                tableDefinition.Add("销售金额", "nvarchar(150)");
                tableDefinition.Add("提货联系人", "nvarchar(50)");
                tableDefinition.Add("提货电话", "nvarchar(50)");
                tableDefinition.Add("提货省", "nvarchar(50)");
                tableDefinition.Add("提货市", "nvarchar(50)");
                tableDefinition.Add("提货区", "nvarchar(50)");
                tableDefinition.Add("提货详细地址", "nvarchar(200)");
                tableDefinition.Add("客户姓名", "nvarchar(50)");
                tableDefinition.Add("客户手机", "nvarchar(50)");
                tableDefinition.Add("客户电话", "nvarchar(50)");
                tableDefinition.Add("客户省", "nvarchar(50)");
                tableDefinition.Add("客户市", "nvarchar(255)");
                tableDefinition.Add("客户区", "nvarchar(50)");
                tableDefinition.Add("客户详细地址", "nvarchar(50)");
                tableDefinition.Add("要求服务日期", "nvarchar(50)");
                tableDefinition.Add("要求服务类型", "nvarchar(50)");
                tableDefinition.Add("要求服务信息描述", "ntext");
                tableDefinition.Add("产品总重量", "nvarchar(50)");
                tableDefinition.Add("产品总体积", "nvarchar(50)");
                tableDefinition.Add("产品小类", "nvarchar(50)");
                tableDefinition.Add("单位数量", "nvarchar(50)");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                tableDefinition.Add("产品描述", "ntext");
                tableDefinition.Add("产品数量", "nvarchar(20)");
                tableDefinition.Add("产品包件数", "nvarchar(50)");
                tableDefinition.Add("网点编码", "nvarchar(50)");
                tableDefinition.Add("订单来源", "nvarchar(50)");
                tableDefinition.Add("天猫单号", "nvarchar(50)");
                tableDefinition.Add("菜鸟单号", "nvarchar(50)");
                tableDefinition.Add("TB服务商", "nvarchar(50)");
                tableDefinition.Add("核销次数", "nvarchar(20)");
                excelHelper.WriteTable("日日顺订单", tableDefinition);
                foreach (var orderInfo in orderInfos)
                {
                    //订单信息
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        int PlatformTypeId = orderInfo.PlatformTypeId == null ? -1 : orderInfo.PlatformTypeId.Value;
                        List<CodeList> codeList = IoC.Resolve<ICodeService>().GetCodeList(PlatformTypeId);
                        string PlatformType = "";
                        if (codeList.Count > 0)
                        {
                            PlatformType = codeList[0].CodeName;         //平台类型 
                        }
                        string value = "";
                        string Invoices = orderInfo.IsInvoiced == null ? "否" : orderInfo.IsInvoiced == true ? "是" : "否";
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            sb = new StringBuilder();
                            sb.Append("INSERT INTO [日日顺订单] (订单号,商户编码,销售金额, 提货联系人, 提货电话, 提货省,提货市,提货区,提货详细地址,客户姓名, 客户手机, 客户电话, 客户省,客户市,客户区,客户详细地址,要求服务日期, 要求服务类型,要求服务信息描述,产品总重量,  产品总体积, 产品小类, 单位数量, 产品编码,产品描述, 产品数量,产品包件数,网点编码,订单来源,天猫单号,菜鸟单号,TB服务商,核销次数) VALUES (");

                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            sb.Append("'"); sb.Append("20014538"); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.SalesPrice.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.FullName); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Mobile == null ? "" : orderInfo.Mobile); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Tel == null || orderInfo.Tel == "" ? "" : orderInfo.Mobile); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Province == null ? value : orderInfo.Province); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.City == null ? value : orderInfo.City); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.County == null ? value : orderInfo.County); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.DeliveryAddress); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.PlatformMerchantCode == null ? "" : xmpd.PlatformMerchantCode); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductName == null ? "" : xmpd.ProductName); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductNum == null ? "" : xmpd.ProductNum.Value.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductNum == null ? "" : xmpd.ProductNum.Value.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            if (PlatformTypeId == 250 || PlatformTypeId == 251)
                            {
                                sb.Append("'"); sb.Append(PlatformType); sb.Append("',");
                            }
                            else
                            {
                                sb.Append("'"); sb.Append("其他"); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(PlatformTypeId == 250 ? orderInfo.OrderCode : ""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(1); sb.Append("'");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 唯品会导出订单数据
        /// </summary>
        public void ExportXMOrderInfoToXlsOfVPH(string filePath, List<XMOrderInfo> orderInfos, int projectID, bool IsAiPu, bool IsYingYi)
        {
            if (IsAiPu)
            {
                AiPuOrderInfoToXls(filePath, orderInfos);
                return;
            }

            if (IsYingYi)
            {
                YingYiOrderInfoToXls(filePath, orderInfos);
                return;
            }

            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货时间", "nvarchar(100)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("会员名称", "nvarchar(150)");
                tableDefinition.Add("网店名称", "nvarchar(200)");
                tableDefinition.Add("下单时间", "nvarchar(100)");
                tableDefinition.Add("付款时间", "nvarchar(100)");
                tableDefinition.Add("产品", "nvarchar(150)");
                tableDefinition.Add("尺寸", "nvarchar(50)");
                tableDefinition.Add("订货数", "int");
                tableDefinition.Add("收货人姓名", "nvarchar(50)");
                tableDefinition.Add("所在省", "nvarchar(50)");
                tableDefinition.Add("所在市", "nvarchar(50)");
                tableDefinition.Add("所在县（区）", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(255)");
                tableDefinition.Add("邮编编码", "nvarchar(50)");
                tableDefinition.Add("固定电话", "nvarchar(50)");
                tableDefinition.Add("手机", "nvarchar(50)");
                tableDefinition.Add("卖家备注", "ntext");
                tableDefinition.Add("赠品备注", "ntext");
                tableDefinition.Add("买家备注", "ntext");
                tableDefinition.Add("是否开发票", "nvarchar(50)");
                tableDefinition.Add("发票类型", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "ntext");
                tableDefinition.Add("运费", "nvarchar(50)");
                tableDefinition.Add("物流单号", "nvarchar(100)");
                tableDefinition.Add("类型", "nvarchar(50)");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("供货价", "nvarchar(50)");
                tableDefinition.Add("特供价", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                excelHelper.WriteTable("订单", tableDefinition);
                foreach (var orderInfo in orderInfos)
                {
                    //订单信息
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        int PlatformTypeId = orderInfo.PlatformTypeId == null ? -1 : orderInfo.PlatformTypeId.Value;
                        List<CodeList> codeList = IoC.Resolve<ICodeService>().GetCodeList(PlatformTypeId);
                        string PlatformType = "";
                        if (codeList.Count > 0)
                        {
                            PlatformType = codeList[0].CodeName;
                        }
                        string value = "";
                        string Invoices = orderInfo.IsInvoiced == null ? "否" : orderInfo.IsInvoiced == true ? "是" : "否";

                        string yb = "";
                        string deadd = "";
                        if (orderInfo.DeliveryAddress != null && orderInfo.DeliveryAddress != "")
                        {
                            string ybstr = orderInfo.DeliveryAddress.Substring(orderInfo.DeliveryAddress.Length - 8);
                            string ybs = ybstr.Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "");

                            int i;
                            if (ybs.Length == 6)
                            {
                                if (!int.TryParse(ybs, out i))
                                {
                                    deadd = orderInfo.DeliveryAddress;
                                }
                                else
                                {
                                    yb = ybs;
                                    deadd = orderInfo.DeliveryAddress.Replace(ybstr, "");
                                }
                            }
                            else
                            {
                                deadd = orderInfo.DeliveryAddress;
                            }
                        }
                        string dastr = "";
                        string daRL = "";

                        if (orderInfo.Province != null && orderInfo.Province != "" && deadd != "")
                        {
                            if (orderInfo.City != null)
                            {
                                dastr = orderInfo.Province.ToString() + orderInfo.City.ToString();
                            }

                            if (orderInfo.County != null)
                            {
                                dastr = dastr + orderInfo.County.ToString();
                            }

                            if (dastr != "")
                            {
                                daRL = deadd.Replace(dastr, "");
                            }
                        }
                        else
                        {
                            daRL = deadd.Trim();
                        }

                        int no = 0;
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            sb = new StringBuilder();
                            sb.Append("INSERT INTO [订单] ( 发货时间,订单号,会员名称, 网店名称, 下单时间, 付款时间,产品,尺寸,订货数,收货人姓名, 所在省, 所在市, 所在县（区）,地址,邮编编码,固定电话,手机, 卖家备注,赠品备注,买家备注,  是否开发票, 发票类型, 发票抬头, 运费,物流单号, 类型,产品编码,单价,供货价,特供价,店铺) VALUES (");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.WantID == null ? value : orderInfo.WantID); sb.Append("',");
                            if (OrderInfo.NickID != null && OrderInfo.NickID != 0)
                            {
                                if (projectID == 2)
                                {
                                    string nickName = "城市爱情旗舰店";
                                    sb.Append("'"); sb.Append(nickName); sb.Append("',");
                                }
                                else
                                {
                                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(int.Parse(OrderInfo.NickID.ToString()));
                                    if (nick != null)
                                    {
                                        sb.Append("'"); sb.Append(nick.nick); sb.Append("',");
                                    }
                                    else
                                    {
                                        sb.Append("'"); sb.Append(""); sb.Append("',");
                                    }
                                }
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(orderInfo.OrderInfoCreateDate == null ? value : orderInfo.OrderInfoCreateDate.Value.ToString("yyyy/M/dd HH:mm:ss")); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.PayDate == null ? value : orderInfo.PayDate.Value.ToString("yyyy/M/dd HH:mm:ss")); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductName == null ? value : xmpd.ProductName); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.Specifications == null ? value : xmpd.Specifications); sb.Append("',");
                            sb.Append(""); sb.Append(xmpd.ProductNum == null ? 0 : xmpd.ProductNum); sb.Append(",");
                            sb.Append("'"); sb.Append(orderInfo.FullName == null ? value : orderInfo.FullName); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Province == null ? value : orderInfo.Province); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.City == null ? value : orderInfo.City); sb.Append("',");
                            if (orderInfo.Province == "北京" || orderInfo.Province == "天津" || orderInfo.Province == "上海" || orderInfo.Province == "重庆")
                            {
                                sb.Append("'"); sb.Append("',");
                                if (orderInfo.County != null)
                                {
                                    daRL = daRL.Insert(0, orderInfo.County);
                                }
                                sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : daRL.Trim().Replace("'", "")); sb.Append("',");
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(orderInfo.County == null ? value : orderInfo.County); sb.Append("',");
                                sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : daRL.Trim().Replace("'", "")); sb.Append("',");
                            }

                            sb.Append("'"); sb.Append(yb); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Tel == null ? value : orderInfo.Tel); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Mobile == null ? value : orderInfo.Mobile); sb.Append("',");
                            string sellerremark = "";
                            string giveremark = "";
                            if (orderInfo.CustomerServiceRemark.IndexOf("//赠品") > -1)
                            {
                                //有赠品备注
                                sellerremark = orderInfo.CustomerServiceRemark.Substring(0, orderInfo.CustomerServiceRemark.IndexOf("//赠品"));
                                if (!string.IsNullOrEmpty(sellerremark))
                                {
                                    giveremark = orderInfo.CustomerServiceRemark.Replace(sellerremark, "");
                                }
                                else
                                {
                                    giveremark = orderInfo.CustomerServiceRemark;
                                }
                            }
                            else
                            {
                                //无赠品备注
                                sellerremark = orderInfo.CustomerServiceRemark;
                            }
                            sb.Append("'"); sb.Append(sellerremark); sb.Append("',");
                            sb.Append("'"); sb.Append(giveremark); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.IsInvoiced == null ? value : Invoices); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");

                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                if (xmpd.PlatformMerchantCode.Length > 2 && xmpd.PlatformMerchantCode.Substring(0, 2) != "CM")
                                {
                                    continue;
                                }

                                var productdetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(xmpd.PlatformMerchantCode).FirstOrDefault();
                                if (productdetail != null && productdetail.ProductId != null)
                                {
                                    bool IsTManufacturersCode = false;
                                    if (productdetail.TDateTimeStart != null && productdetail.TDateTimeEnd != null)
                                    {
                                        if (OrderInfo.OrderInfoCreateDate >= productdetail.TDateTimeStart && OrderInfo.OrderInfoCreateDate < productdetail.TDateTimeEnd)
                                        {
                                            IsTManufacturersCode = true;
                                            sb.Append("'"); sb.Append(productdetail.TemporaryManufacturersCode == null ? value : productdetail.TemporaryManufacturersCode); sb.Append("',");
                                        }
                                    }
                                    if (!IsTManufacturersCode)
                                    {
                                        var product = IoC.Resolve<IXMProductService>().GetXMProductById(int.Parse(productdetail.ProductId.ToString()));
                                        if (product != null)
                                        {
                                            sb.Append("'"); sb.Append(product.ManufacturersCode == null ? value : product.ManufacturersCode); sb.Append("',");
                                        }
                                        else
                                        {
                                            sb.Append("'"); sb.Append(""); sb.Append("',");
                                        }
                                    }
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(""); sb.Append("',");
                                }
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }
                            if (no == 0)
                            {
                                sb.Append("'"); sb.Append(xmpd.SalesPrice == null ? 0 : xmpd.SalesPrice); sb.Append("',");
                                no++;
                            }
                            else
                            {
                                sb.Append("'"); sb.Append("0"); sb.Append("',");
                            }
                            //sb.Append("'"); sb.Append(xmpd.TCostprice == null ? 0 : xmpd.TCostprice); sb.Append("',");

                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                var product = IoC.Resolve<XMOrderInfoAPIService>().GetXMProductListByMerchantcode(xmpd.PlatformMerchantCode);
                                if (product.Count > 0)
                                {

                                    sb.Append('"'); sb.Append(product[0].Costprice == null ? 0 : product[0].Costprice); sb.Append("\",");
                                    sb.Append("'"); sb.Append(product[0].TCostprice == null ? 0 : product[0].TCostprice); sb.Append("',");
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(0); sb.Append("',");
                                    sb.Append("'"); sb.Append(0); sb.Append("',");
                                }

                            }
                            else
                            {
                                sb.Append('"'); sb.Append(0); sb.Append("\",");
                                sb.Append("'"); sb.Append(0); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(PlatformType); sb.Append("'");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 永益饰佳导出订单数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderInfos"></param>
        public void YingYiOrderInfoToXls(string filePath, List<XMOrderInfo> orderInfos)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "nvarchar(50)");
                tableDefinition.Add("订单日期", "nvarchar(50)");
                tableDefinition.Add("订单编号", "nvarchar(50)");
                tableDefinition.Add("系列", "nvarchar(50)");
                tableDefinition.Add("购买家具代号", "nvarchar(50)");
                tableDefinition.Add("购买家具品名", "nvarchar(50)");
                tableDefinition.Add("数量", "int");
                tableDefinition.Add("网络销售价", "nvarchar(50)");
                tableDefinition.Add("客户姓名", "nvarchar(50)");
                tableDefinition.Add("ID", "nvarchar(50)");
                tableDefinition.Add("客户地址", "nvarchar(255)");
                tableDefinition.Add("联系电话", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(50)");
                excelHelper.WriteTable("订单", tableDefinition);
                //序号
                int zIndex = 1;

                foreach (var orderInfo in orderInfos)
                {
                    //订单信息
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        string value = "";
                        StringBuilder sb = new StringBuilder();
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            decimal salePrice = xmpd.SalesPrice == null ? 0 : xmpd.SalesPrice.Value;
                            sb = new StringBuilder();
                            sb.Append("INSERT INTO [订单] (序号, 订单日期, 订单编号, 系列, 购买家具代号, 购买家具品名, 数量, 网络销售价, 客户姓名, ID, 客户地址, 联系电话, 备注) VALUES (");
                            sb.Append("'"); sb.Append(zIndex.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderInfoCreateDate == null ? value : orderInfo.OrderInfoCreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                var productdetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(xmpd.PlatformMerchantCode).FirstOrDefault();
                                if (productdetail != null && productdetail.ProductId != null)
                                {

                                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(int.Parse(productdetail.ProductId.ToString()));
                                    if (product != null)
                                    {
                                        sb.Append("'"); sb.Append(product.Series == null ? value : product.Series); sb.Append("',");
                                        sb.Append("'"); sb.Append(product.ManufacturersCode == null ? value : product.ManufacturersCode); sb.Append("',");
                                        sb.Append("'"); sb.Append(product.ProductName == null ? value : product.ProductName); sb.Append("',");
                                    }
                                    else
                                    {
                                        sb.Append("'"); sb.Append(""); sb.Append("',");
                                        sb.Append("'"); sb.Append(""); sb.Append("',");
                                        sb.Append("'"); sb.Append(""); sb.Append("',");
                                    }
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(""); sb.Append("',");
                                    sb.Append("'"); sb.Append(""); sb.Append("',");
                                    sb.Append("'"); sb.Append(""); sb.Append("',");
                                }
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(xmpd.ProductNum == null ? 0 : xmpd.ProductNum); sb.Append("',");
                            sb.Append("'"); sb.Append(salePrice); sb.Append("',");
                            sb.Append("'"); sb.Append(OrderInfo.FullName == null ? "" : OrderInfo.FullName); sb.Append("',");
                            sb.Append("'"); sb.Append(OrderInfo.WantID == null ? "" : OrderInfo.WantID); sb.Append("',");
                            if (orderInfo.DeliveryAddress.IndexOf(orderInfo.Province) != -1)
                            {
                                sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : orderInfo.DeliveryAddress); sb.Append("',");
                            }
                            else
                            {
                                if (orderInfo.Province == "北京" || orderInfo.Province == "天津" || orderInfo.Province == "上海" || orderInfo.Province == "重庆")
                                {
                                    sb.Append("'"); sb.Append(orderInfo.City + orderInfo.County + orderInfo.DeliveryAddress); sb.Append("',");
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(orderInfo.Province + orderInfo.City + orderInfo.County + orderInfo.DeliveryAddress); sb.Append("',");
                                }
                            }
                            string Contact = (orderInfo.Mobile == null ? value : orderInfo.Mobile);
                            if (Contact == "")
                            {
                                Contact = (orderInfo.Tel == null ? value : orderInfo.Tel);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(orderInfo.Tel))
                                {
                                    Contact = Contact + "," + (orderInfo.Tel == null ? value : orderInfo.Tel);
                                }
                            }
                            sb.Append("'"); sb.Append(Contact); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.CustomerServiceRemark == null ? value : orderInfo.CustomerServiceRemark); sb.Append("'");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                            zIndex++;
                        }
                    }
                }
            }
        }

        protected string GetOrderStatus(string OrderStatus, string platformtypeid)
        {
            var codeTypeInfo = IoC.Resolve<CodeTypeService>().GetCodeTypeByPlatFormTypeId(platformtypeid).SingleOrDefault();
            if (codeTypeInfo != null)
            {
                var codeList = IoC.Resolve<CodeService>().GetCodeListInfoByCodeTypeID(codeTypeInfo.CodeTypeID);
                var Setting = codeList.FirstOrDefault(p => p.CodeNO.Equals(OrderStatus));
                if (Setting != null)
                {
                    return Setting.CodeName;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 艾谱导出订单数据
        /// </summary>
        public void AiPuOrderInfoToXls(string filePath, List<XMOrderInfo> orderInfos)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                //订单主表导入模板
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("订单编号", "nvarchar(50)");
                tableDefinition.Add("买家会员名", "nvarchar(50)");
                tableDefinition.Add("运费", "nvarchar(50)");
                tableDefinition.Add("成本", "nvarchar(50)");
                tableDefinition.Add("订单状态", "nvarchar(50)");
                tableDefinition.Add("买家留言", "nvarchar(50)");
                tableDefinition.Add("收货人", "nvarchar(50)");
                tableDefinition.Add("收货地址", "nvarchar(50)");
                tableDefinition.Add("联系电话", "nvarchar(50)");
                tableDefinition.Add("联系手机", "nvarchar(50)");
                tableDefinition.Add("订单创建时间", "nvarchar(50)");
                tableDefinition.Add("订单付款时间", "nvarchar(50)");
                tableDefinition.Add("物流单号", "nvarchar(50)");
                tableDefinition.Add("物流公司", "nvarchar(50)");
                tableDefinition.Add("卖家备注", "nvarchar(50)");
                tableDefinition.Add("店铺名称", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "nvarchar(50)");
                tableDefinition.Add("是否手机订单", "nvarchar(50)");
                tableDefinition.Add("是否货到付款", "nvarchar(50)");
                tableDefinition.Add("支付方式", "nvarchar(50)");
                tableDefinition.Add("支付交易号", "nvarchar(50)");
                tableDefinition.Add("真实姓名", "nvarchar(50)");
                tableDefinition.Add("身份证号", "nvarchar(50)");
                excelHelper.WriteTable("订单主表导入模板", tableDefinition);
                foreach (var orderInfo in orderInfos)
                {
                    //订单信息
                    StringBuilder sb = new StringBuilder();
                    int PlatformTypeId = orderInfo.PlatformTypeId == null ? -1 : orderInfo.PlatformTypeId.Value;
                    List<CodeList> codeList = IoC.Resolve<ICodeService>().GetCodeList(PlatformTypeId);
                    string PlatformType = "";
                    if (codeList.Count > 0)
                    {
                        PlatformType = codeList[0].CodeName;
                    }
                    string value = "";
                    string Invoices = orderInfo.IsInvoiced == null ? "否" : orderInfo.IsInvoiced == true ? "是" : "否";
                    sb.Append("INSERT INTO [订单主表导入模板] (订单编号, 买家会员名, 运费, 成本, 订单状态, 买家留言, 收货人, 收货地址, 联系电话, 联系手机, 订单创建时间, 订单付款时间, 物流单号, 物流公司, 卖家备注, 店铺名称, 发票抬头, 是否手机订单,是否货到付款,支付方式,支付交易号,真实姓名,身份证号) VALUES (");
                    sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");   //订单编号
                    sb.Append("'"); sb.Append(orderInfo.WantID == null ? value : orderInfo.WantID); sb.Append("',");   //买家会员名
                    sb.Append("'"); sb.Append(""); sb.Append("',");   // 运费
                    decimal costPrice = 0;
                    var orderInfoProductDetail = IoC.Resolve<XMOrderInfoProductDetailsService>().GetXMOrderInfoProductDetailsListByOrderId(orderInfo.ID);
                    if (orderInfoProductDetail != null && orderInfoProductDetail.Count > 0)
                    {
                        foreach (XMOrderInfoProductDetails info in orderInfoProductDetail)
                        {
                            if (info.TCostprice == null)
                            {
                                costPrice += 0;
                            }
                            else
                            {
                                costPrice += info.TCostprice.Value;
                            }
                        }
                    }
                    sb.Append("'"); sb.Append(costPrice); sb.Append("',");    //成本
                    //获取订单状态
                    string orderStatus = orderInfo.OrderStatus == null ? value : GetOrderStatus(orderInfo.OrderStatus, PlatformTypeId.ToString());    //订单状态
                    sb.Append("'"); sb.Append(orderStatus); sb.Append("',");
                    sb.Append("'"); sb.Append(orderInfo.Remark == null ? value : orderInfo.Remark); sb.Append("',");    //买家留言
                    sb.Append("'"); sb.Append(orderInfo.FullName == null ? value : orderInfo.FullName); sb.Append("',");  //收货人
                    sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : orderInfo.DeliveryAddress); sb.Append("',");   //收货地址
                    sb.Append("'"); sb.Append(orderInfo.Tel == null ? value : orderInfo.Tel); sb.Append("',");    //联系电话
                    sb.Append("'"); sb.Append(orderInfo.Mobile == null ? value : orderInfo.Mobile); sb.Append("',");   //联系手机
                    sb.Append("'"); sb.Append(orderInfo.OrderInfoCreateDate == null ? value : orderInfo.OrderInfoCreateDate.Value.ToString()); sb.Append("',"); //订单创建时间
                    sb.Append("'"); sb.Append(orderInfo.PayDate == null ? value : orderInfo.PayDate.Value.ToString()); sb.Append("',");     //订单付款时间
                    sb.Append("'"); sb.Append(""); sb.Append("',");    //物流单号
                    sb.Append("'"); sb.Append(""); sb.Append("',");    //物流公司
                    sb.Append("'"); sb.Append(orderInfo.CustomerServiceRemark == null ? value : orderInfo.CustomerServiceRemark); sb.Append("',");    //卖家备注
                    if (orderInfo.NickID != null && orderInfo.NickID != 0)
                    {
                        var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(int.Parse(orderInfo.NickID.ToString()));
                        if (nick != null)
                        {
                            sb.Append("'"); sb.Append(nick.nick); sb.Append("',");
                        }
                        else
                        {
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                        }
                    }
                    else
                    {
                        sb.Append("'"); sb.Append(""); sb.Append("',");
                    }                 //店铺名称
                    sb.Append("'"); sb.Append(orderInfo.InvoiceHead == null ? value : orderInfo.InvoiceHead); sb.Append("',");   //发票抬头
                    sb.Append("'"); sb.Append(""); sb.Append("',");     //是否手机订单
                    sb.Append("'"); sb.Append(""); sb.Append("',");     //是否货到付款
                    string payMethod = IoC.Resolve<XMOrderInfoService>().ReturnPayMethod(orderInfo.PayMethod == null ? value : orderInfo.PayMethod);
                    sb.Append("'"); sb.Append(payMethod); sb.Append("',");     //支付方式
                    sb.Append("'"); sb.Append(""); sb.Append("',");    //支付交易号
                    sb.Append("'"); sb.Append(orderInfo.FullName == null ? value : orderInfo.FullName); sb.Append("',");    //真实姓名
                    sb.Append("'"); sb.Append(""); sb.Append("'");    //身份证号
                    sb.Append(")");
                    excelHelper.ExecuteCommand(sb.ToString());
                }

                //订单明细导入模板
                Dictionary<string, string> tableDefinition2 = new Dictionary<string, string>();
                tableDefinition2.Add("订单编号", "nvarchar(50)");
                tableDefinition2.Add("标题", "nvarchar(50)");
                tableDefinition2.Add("成本", "nvarchar(50)");
                tableDefinition2.Add("购买数量", "nvarchar(50)");
                tableDefinition2.Add("商品代码", "nvarchar(50)");
                tableDefinition2.Add("规格名称", "nvarchar(50)");
                tableDefinition2.Add("备注", "nvarchar(50)");
                excelHelper.WriteTable("订单明细导入模板", tableDefinition2);

                foreach (var orderInfo in orderInfos)
                {
                    string value = "";
                    var OrderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            sb = new StringBuilder();
                            sb.Append("INSERT INTO [订单明细导入模板] (订单编号, 标题, 成本, 购买数量, 商品代码, 规格名称, 备注) VALUES (");
                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductName == null ? value : xmpd.ProductName); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.TCostprice == null ? 0 : xmpd.TCostprice); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductNum == null ? 0 : xmpd.ProductNum); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.TManufacturersCode == null ? value : xmpd.TManufacturersCode); sb.Append("',");
                            //根据编码获取产品规格名称
                            var productDetails = IoC.Resolve<XMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(xmpd.PlatformMerchantCode, orderInfo.PlatformTypeId.Value, "");
                            if (productDetails != null && productDetails.Count > 0)
                            {
                                sb.Append("'"); sb.Append(productDetails[0].Color == null ? value : productDetails[0].Color); sb.Append("',");
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(xmpd.Remarks == null ? value : xmpd.Remarks); sb.Append("'");    //备注
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());

                        }
                    }
                }


                //和众爱普总表
                Dictionary<string, string> tableDefinition3 = new Dictionary<string, string>();
                tableDefinition3.Add("店铺", "nvarchar(50)");
                tableDefinition3.Add("提单日期", "nvarchar(50)");
                tableDefinition3.Add("订单编号", "nvarchar(50)");
                tableDefinition3.Add("买家会员名", "nvarchar(50)");
                tableDefinition3.Add("型号", "nvarchar(50)");
                tableDefinition3.Add("商品代码", "nvarchar(50)");
                tableDefinition3.Add("数量", "nvarchar(50)");
                tableDefinition3.Add("支付金额", "nvarchar(50)");
                tableDefinition3.Add("成本", "nvarchar(50)");
                tableDefinition3.Add("收货人", "nvarchar(50)");
                tableDefinition3.Add("收货地址", "nvarchar(50)");
                tableDefinition3.Add("联系电话", "nvarchar(50)");
                tableDefinition3.Add("联系手机", "nvarchar(50)");
                tableDefinition3.Add("物流单号", "nvarchar(50)");
                tableDefinition3.Add("物流公司", "nvarchar(50)");
                excelHelper.WriteTable("和众艾谱总表", tableDefinition3);
                foreach (var orderInfo in orderInfos)
                {
                    string value = "";
                    var OrderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            sb = new StringBuilder();
                            sb.Append("INSERT INTO [和众艾谱总表] (店铺, 提单日期, 订单编号, 买家会员名, 型号, 商品代码, 数量,支付金额,成本,收货人,收货地址,联系电话,联系手机,物流单号,物流公司) VALUES (");
                            sb.Append("'"); sb.Append(orderInfo.NickName); sb.Append("',");
                            sb.Append("'"); sb.Append(DateTime.Now.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.WantID == null ? value : orderInfo.WantID); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.Specifications == null ? value : xmpd.Specifications); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.PlatformMerchantCode == null ? value : xmpd.PlatformMerchantCode); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductNum == null ? value : xmpd.ProductNum.Value.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.SalesPrice == null ? value : xmpd.SalesPrice.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.TCostprice == null ? value : xmpd.TCostprice.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.FullName == null ? value : orderInfo.FullName.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : orderInfo.DeliveryAddress.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Tel == null ? value : orderInfo.Tel); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Mobile == null ? value : orderInfo.Mobile); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");    //物流单号
                            sb.Append("'"); sb.Append(""); sb.Append("'");    //物流公司
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Export XMOrderInfo to XLS(导出订单数据)
        /// </summary>
        /// <param name="filePath">File path to use</param>
        public void ExportXMOrderInfoToXls(string filePath, List<XMOrderInfo> orderInfos, int projectID, bool IsAiPu, bool IsYingYi)
        {
            if (IsAiPu)
            {
                AiPuOrderInfoToXls(filePath, orderInfos);
                return;
            }

            if (IsYingYi)
            {
                YingYiOrderInfoToXls(filePath, orderInfos);
                return;
            }

            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货时间", "nvarchar(100)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("会员名称", "nvarchar(150)");
                tableDefinition.Add("网店名称", "nvarchar(200)");
                tableDefinition.Add("下单时间", "nvarchar(100)");
                tableDefinition.Add("付款时间", "nvarchar(100)");
                tableDefinition.Add("产品", "nvarchar(150)");
                tableDefinition.Add("尺寸", "nvarchar(50)");
                tableDefinition.Add("订货数", "int");
                tableDefinition.Add("收货人姓名", "nvarchar(50)");
                tableDefinition.Add("所在省", "nvarchar(50)");
                tableDefinition.Add("所在市", "nvarchar(50)");
                tableDefinition.Add("所在县（区）", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(255)");
                tableDefinition.Add("邮编编码", "nvarchar(50)");
                tableDefinition.Add("固定电话", "nvarchar(50)");
                tableDefinition.Add("手机", "nvarchar(50)");
                tableDefinition.Add("卖家备注", "ntext");
                tableDefinition.Add("赠品备注", "ntext");
                tableDefinition.Add("买家备注", "ntext");
                tableDefinition.Add("是否开发票", "nvarchar(50)");
                tableDefinition.Add("发票类型", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "ntext");
                tableDefinition.Add("运费", "nvarchar(50)");
                tableDefinition.Add("物流单号", "nvarchar(100)");
                tableDefinition.Add("类型", "nvarchar(50)");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("供货价", "nvarchar(50)");
                tableDefinition.Add("特供价", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                excelHelper.WriteTable("订单", tableDefinition);

                foreach (var orderInfo in orderInfos)
                {
                    //订单信息
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        #region 地址、邮编处理
                        int PlatformTypeId = orderInfo.PlatformTypeId == null ? -1 : orderInfo.PlatformTypeId.Value;
                        List<CodeList> codeList = IoC.Resolve<ICodeService>().GetCodeList(PlatformTypeId);
                        string PlatformType = "";
                        if (codeList.Count > 0)
                        {
                            PlatformType = codeList[0].CodeName;
                        }
                        string value = "";
                        string Invoices = orderInfo.IsInvoiced == null ? "否" : orderInfo.IsInvoiced == true ? "是" : "否";

                        string yb = "";
                        string deadd = "";
                        if (orderInfo.DeliveryAddress != null && orderInfo.DeliveryAddress != "")
                        {
                            if (orderInfo.DeliveryAddress.Length > 8)
                            {
                                string ybstr = orderInfo.DeliveryAddress.Substring(orderInfo.DeliveryAddress.Length - 8);

                                string ybs = ybstr.Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "");

                                int i;
                                if (ybs.Length == 6)
                                {

                                    if (!int.TryParse(ybs, out i))
                                    {
                                        deadd = orderInfo.DeliveryAddress;
                                    }
                                    else
                                    {

                                        yb = ybs;
                                        deadd = orderInfo.DeliveryAddress.Replace(ybstr, "");
                                    }
                                }
                                else
                                {
                                    deadd = orderInfo.DeliveryAddress;
                                }
                            }
                            else
                            {
                                deadd = orderInfo.DeliveryAddress;
                            }

                        }

                        string dastr = "";
                        string daRL = "";

                        if (orderInfo.Province != null && orderInfo.Province != "" && deadd != "")
                        {
                            if (orderInfo.City != null)
                            {
                                dastr = orderInfo.Province.ToString() + orderInfo.City.ToString();
                            }

                            if (orderInfo.County != null)
                            {
                                dastr = dastr + orderInfo.County.ToString();
                            }

                            if (dastr != "")
                            {
                                daRL = deadd.Replace(dastr, "");
                            }
                        }
                        else
                        {
                            daRL = deadd.Trim();
                        }



                        #endregion
                        int no = 0;
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            sb = new StringBuilder();
                            if (OrderInfo.PlatformTypeId == 259 && xmpd.PlatformMerchantCode.Length > 2 && xmpd.PlatformMerchantCode.Substring(0, 2) != "CM")
                            {
                                continue;
                            }
                            sb.Append("INSERT INTO [订单] ( 发货时间,订单号,会员名称, 网店名称, 下单时间, 付款时间,产品,尺寸,订货数,收货人姓名, 所在省, 所在市, 所在县（区）,地址,邮编编码,固定电话,手机, 卖家备注,赠品备注,买家备注,  是否开发票, 发票类型, 发票抬头, 运费,物流单号, 类型,产品编码,单价,供货价,特供价,店铺) VALUES (");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.WantID == null ? value : orderInfo.WantID); sb.Append("',");
                            if (OrderInfo.NickID != null && OrderInfo.NickID != 0)
                            {
                                if (projectID == 2)
                                {
                                    string nickName = "城市爱情旗舰店";
                                    sb.Append("'"); sb.Append(nickName); sb.Append("',");
                                }
                                else
                                {
                                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(int.Parse(OrderInfo.NickID.ToString()));
                                    if (nick != null)
                                    {
                                        sb.Append("'"); sb.Append(nick.nick); sb.Append("',");
                                    }
                                    else
                                    {
                                        sb.Append("'"); sb.Append(""); sb.Append("',");
                                    }
                                }
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(orderInfo.OrderInfoCreateDate == null ? value : orderInfo.OrderInfoCreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.PayDate == null ? value : orderInfo.PayDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.ProductName == null ? value : xmpd.ProductName); sb.Append("',");
                            sb.Append("'"); sb.Append(xmpd.Specifications == null ? value : xmpd.Specifications); sb.Append("',");
                            sb.Append(""); sb.Append(xmpd.ProductNum == null ? 0 : xmpd.ProductNum); sb.Append(",");
                            sb.Append("'"); sb.Append(orderInfo.FullName == null ? value : orderInfo.FullName); sb.Append("',");
                            sb.Append("'"); ; sb.Append(orderInfo.Province == null ? value : orderInfo.Province); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.City == null ? value : orderInfo.City); sb.Append("',");
                            if (orderInfo.Province == "北京" || orderInfo.Province == "天津" || orderInfo.Province == "上海" || orderInfo.Province == "重庆")
                            {
                                sb.Append("'"); sb.Append("',");
                                if (orderInfo.County != null && !daRL.Contains(orderInfo.County))
                                {
                                    daRL = daRL.Insert(0, orderInfo.County);
                                }
                                sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : daRL.Trim().Replace("'", "")); sb.Append("',");
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(orderInfo.County == null ? value : orderInfo.County); sb.Append("',");
                                sb.Append("'"); sb.Append(orderInfo.DeliveryAddress == null ? value : daRL.Trim().Replace("'", "")); sb.Append("',");
                            }
                            sb.Append("'"); sb.Append(yb); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Tel == null ? value : orderInfo.Tel); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.Mobile == null ? value : orderInfo.Mobile); sb.Append("',");
                            string sellerremark = "";
                            string giveremark = "";
                            if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.IndexOf("//赠品") > -1)
                            {
                                //有赠品备注
                                sellerremark = orderInfo.CustomerServiceRemark.Substring(0, orderInfo.CustomerServiceRemark.IndexOf("//赠品"));
                                if (!string.IsNullOrEmpty(sellerremark))
                                {
                                    giveremark = orderInfo.CustomerServiceRemark.Replace(sellerremark, "");
                                }
                                else
                                {
                                    giveremark = orderInfo.CustomerServiceRemark;
                                }
                            }
                            else
                            {
                                //无赠品备注
                                sellerremark = orderInfo.CustomerServiceRemark;
                            }
                            sb.Append("'"); sb.Append(sellerremark); sb.Append("',");
                            sb.Append("'"); sb.Append(giveremark); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.IsInvoiced == null ? value : Invoices); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                var productdetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(xmpd.PlatformMerchantCode).FirstOrDefault();
                                if (productdetail != null && productdetail.ProductId != null)
                                {
                                    bool IsTManufacturersCode = false;
                                    if (productdetail.TDateTimeStart != null && productdetail.TDateTimeEnd != null)
                                    {
                                        if (OrderInfo.OrderInfoCreateDate >= productdetail.TDateTimeStart && OrderInfo.OrderInfoCreateDate < productdetail.TDateTimeEnd)
                                        {
                                            IsTManufacturersCode = true;
                                            sb.Append("'"); sb.Append(productdetail.TemporaryManufacturersCode == null ? value : productdetail.TemporaryManufacturersCode); sb.Append("',");
                                        }
                                    }

                                    if (!IsTManufacturersCode)
                                    {
                                        var product = IoC.Resolve<IXMProductService>().GetXMProductById(int.Parse(productdetail.ProductId.ToString()));
                                        if (product != null)
                                        {
                                            sb.Append("'"); sb.Append(product.ManufacturersCode == null ? value : product.ManufacturersCode); sb.Append("',");
                                        }
                                        else
                                        {
                                            sb.Append("'"); sb.Append(""); sb.Append("',");
                                        }
                                    }
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(""); sb.Append("',");
                                }
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }

                            if (no == 0)
                            {
                                sb.Append("'"); sb.Append(orderInfo.PayPrice == null ? 0 : orderInfo.PayPrice); sb.Append("',");
                                no++;
                            }
                            else
                            {
                                sb.Append("'"); sb.Append("0"); sb.Append("',");
                            }
                            //sb.Append("'"); sb.Append(xmpd.TCostprice == null ? 0 : xmpd.TCostprice); sb.Append("',");

                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                var product = IoC.Resolve<XMOrderInfoAPIService>().GetXMProductListByMerchantcode(xmpd.PlatformMerchantCode);
                                if (product.Count > 0)
                                {

                                    sb.Append('"'); sb.Append(product[0].Costprice == null ? 0 : product[0].Costprice); sb.Append("\",");
                                    sb.Append("'"); sb.Append(product[0].TCostprice == null ? 0 : product[0].TCostprice); sb.Append("',");
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(0); sb.Append("',");
                                    sb.Append("'"); sb.Append(0); sb.Append("',");
                                }
                            }
                            else
                            {
                                sb.Append('"'); sb.Append(0); sb.Append("\",");
                                sb.Append("'"); sb.Append(0); sb.Append("',");

                            }
                            sb.Append("'"); sb.Append(PlatformType); sb.Append("'");
                            //sb.Append('"'); sb.Append(contract.RenewalId.HasValue ? "是" : "否"); sb.Append("\"");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导出日销数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="XMDailySaleInfos"></param>
        public void ExportDaliySaleToXls(string filePath, List<XMDailySaleInfo> XMDailySaleInfos)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("厂家编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(100)");
                tableDefinition.Add("销售日期", "nvarchar(100)");
                tableDefinition.Add("下单量", "int");
                tableDefinition.Add("浏览量", "int");
                tableDefinition.Add("访客数", "int");
                tableDefinition.Add("下单转换率", "nvarchar(50)");
                tableDefinition.Add("累计关注量", "int");
                tableDefinition.Add("加入购物车量", "int");
                tableDefinition.Add("购物车转换率", "nvarchar(50)");
                tableDefinition.Add("评价数量", "int");
                tableDefinition.Add("好评数量", "int");
                tableDefinition.Add("好评率", "nvarchar(50)");
                tableDefinition.Add("站内流量比", "nvarchar(50)");
                tableDefinition.Add("站外流量比", "nvarchar(50)");
                excelHelper.WriteTable("日销管理", tableDefinition);
                StringBuilder sb = new StringBuilder();
                foreach (var XMDailySaleInfo in XMDailySaleInfos)
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO [日销管理] (厂家编码,商品名称,销售日期,下单量,浏览量,访客数,下单转换率,累计关注量,加入购物车量,购物车转换率,评价数量,好评数量,好评率,站内流量比,站外流量比) VALUES (");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.PlatformMerchantCode == null ? "" : XMDailySaleInfo.PlatformMerchantCode); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.ProductName == null ? "" : XMDailySaleInfo.ProductName); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.CreateDate == null ? "" : XMDailySaleInfo.CreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.OrderQuantity == null ? 0 : XMDailySaleInfo.OrderQuantity); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.MerchandiseViewCount == null ? 0 : XMDailySaleInfo.MerchandiseViewCount); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.VisitorNumber == null ? 0 : XMDailySaleInfo.VisitorNumber); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.ConversionRate == null ? 0 : XMDailySaleInfo.ConversionRate); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.CumulativeAttention == null ? 0 : XMDailySaleInfo.CumulativeAttention); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.AddCartCount == null ? 0 : XMDailySaleInfo.AddCartCount); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.CartConversionRate == null ? 0 : XMDailySaleInfo.ConversionRate); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.EvaluationQuantity == null ? 0 : XMDailySaleInfo.CumulativeAttention); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.PraiseQuantity == null ? 0 : XMDailySaleInfo.AddCartCount); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.PraiseRate == null ? 0 : XMDailySaleInfo.ConversionRate); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.FlowRate == null ? 0 : XMDailySaleInfo.FlowRate); sb.Append("',");
                    sb.Append("'"); sb.Append(XMDailySaleInfo.ExterFlowRate == null ? 0 : XMDailySaleInfo.ExterFlowRate); sb.Append("'");
                    sb.Append(")");
                    excelHelper.ExecuteCommand(sb.ToString());
                }

            }
        }

        /// <summary>
        /// Export XMOrderInfo to XLS(导出曲美订单数据)
        /// </summary>
        /// <param name="filePath">File path to use</param>
        public void ExportXMOrderInfoToXlsQM(string filePath, List<XMOrderInfo> orderInfos, int projectID, bool IsAiPu, bool IsYingYi)
        {
            if (IsAiPu)
            {
                AiPuOrderInfoToXls(filePath, orderInfos);
                return;
            }

            if (IsYingYi)
            {
                YingYiOrderInfoToXls(filePath, orderInfos);
                return;
            }

            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货时间", "nvarchar(100)");
                tableDefinition.Add("外部订单号", "nvarchar(50)");
                tableDefinition.Add("淘宝ID", "nvarchar(150)");
                tableDefinition.Add("下单时间", "nvarchar(100)");
                tableDefinition.Add("付款时间", "nvarchar(100)");
                tableDefinition.Add("产品名称", "nvarchar(150)");
                tableDefinition.Add("尺寸", "nvarchar(50)");
                tableDefinition.Add("数量", "int");
                tableDefinition.Add("客户姓名", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(255)");
                tableDefinition.Add("联系方式", "nvarchar(50)");
                tableDefinition.Add("卖家备注", "ntext");
                tableDefinition.Add("赠品备注", "ntext");
                tableDefinition.Add("买家备注", "ntext");
                tableDefinition.Add("是否开发票", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "ntext");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("供货价", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("订单编号", "nvarchar(50)");
                excelHelper.WriteTable("订单", tableDefinition);

                foreach (var orderInfo in orderInfos)
                {
                    //订单信息
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(orderInfo.ID);
                    if (OrderInfo.XM_OrderInfoProductDetails != null && OrderInfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        #region 地址、邮编处理
                        int PlatformTypeId = orderInfo.PlatformTypeId == null ? -1 : orderInfo.PlatformTypeId.Value;
                        List<CodeList> codeList = IoC.Resolve<ICodeService>().GetCodeList(PlatformTypeId);
                        string PlatformType = "";
                        if (codeList.Count > 0)
                        {
                            PlatformType = codeList[0].CodeName;
                        }
                        string value = "";
                        string Invoices = orderInfo.IsInvoiced == null ? "否" : orderInfo.IsInvoiced == true ? "是" : "否";

                        string yb = "";
                        string deadd = "";
                        if (orderInfo.DeliveryAddress != null && orderInfo.DeliveryAddress != "")
                        {
                            if (orderInfo.DeliveryAddress.Length > 8)
                            {
                                string ybstr = orderInfo.DeliveryAddress.Substring(orderInfo.DeliveryAddress.Length - 8);
                                string ybs = ybstr.Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "");

                                int i;
                                if (ybs.Length == 6)
                                {
                                    if (!int.TryParse(ybs, out i))
                                    {
                                        deadd = orderInfo.DeliveryAddress;
                                    }
                                    else
                                    {
                                        yb = ybs;
                                        deadd = orderInfo.DeliveryAddress.Replace(ybstr, "");
                                    }
                                }
                                else
                                {
                                    deadd = orderInfo.DeliveryAddress;
                                }
                            }
                            else
                            {
                                deadd = orderInfo.DeliveryAddress;
                            }
                        }

                        string dastr = "";
                        string daRL = "";

                        if (orderInfo.Province != null && orderInfo.Province != "" && deadd != "")
                        {
                            if (orderInfo.City != null)
                            {
                                dastr = orderInfo.Province.ToString() + orderInfo.City.ToString();
                            }

                            if (orderInfo.County != null)
                            {
                                dastr = dastr + orderInfo.County.ToString();
                            }

                            if (dastr != "")
                            {
                                daRL = deadd.Replace(dastr, "");
                            }
                        }
                        else
                        {
                            daRL = deadd.Trim();
                        }

                        #endregion
                        int no = 0;
                        int No = 0;
                        foreach (XMOrderInfoProductDetails xmpd in OrderInfo.XM_OrderInfoProductDetails)
                        {
                            sb = new StringBuilder();
                            sb.Append("INSERT INTO [订单] (发货时间,外部订单号,淘宝ID,下单时间,付款时间,产品名称,尺寸,数量,客户姓名,地址,联系方式,卖家备注,赠品备注,买家备注,是否开发票,发票抬头,产品编码,单价,供货价,店铺,订单编号) VALUES (");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderCode == null ? value : orderInfo.OrderCode); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.WantID == null ? value : orderInfo.WantID); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.OrderInfoCreateDate == null ? value : orderInfo.OrderInfoCreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.PayDate == null ? value : orderInfo.PayDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("',");
                            #region 曲美产品的系列当成产品名称
                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                var product = new XMProduct();
                                var productdetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(xmpd.PlatformMerchantCode).FirstOrDefault();
                                if (productdetail != null)
                                {
                                    product = IoC.Resolve<IXMProductService>().GetXMProductById(int.Parse(productdetail.ProductId.ToString()));
                                }
                                if (product != null)
                                {
                                    if (product.Series != string.Empty && product.Series != null)
                                    {
                                        sb.Append("'"); sb.Append(product.Series); sb.Append("',");
                                    }
                                    else
                                    {
                                        sb.Append("'"); sb.Append(xmpd.ProductName == null ? value : xmpd.ProductName); sb.Append("',");
                                    }
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(xmpd.ProductName == null ? value : xmpd.ProductName); sb.Append("',");
                                }
                            }
                            #endregion
                            sb.Append("'"); sb.Append(xmpd.Specifications == null ? value : xmpd.Specifications); sb.Append("',");
                            sb.Append(""); sb.Append(xmpd.ProductNum == null ? 0 : xmpd.ProductNum); sb.Append(",");
                            string transferAddress = string.Empty;
                            string phone = string.Empty;
                            //中转 
                            if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.IndexOf("转") > -1)
                            {
                                string[] parm = orderInfo.CustomerServiceRemark.Split('，');
                                if (parm.Count() >= 6)
                                {
                                    string logisticsName = parm[0].IndexOf("/") > 0 ? parm[0].Substring(0, parm[0].IndexOf("/")) : "";    //物流公司
                                    string movingCompany = parm[1];
                                    string detail = parm[2];
                                    transferAddress = parm[3];                                                                      //中转公司地址
                                    string s = parm[4];                                                                                  //谁转谁                                  
                                    phone = parm[5].IndexOf("/") > 0 ? parm[5].Substring(0, parm[5].IndexOf("/")) : parm[5];                                                                                   //中转公司电话
                                    sb.Append("'");
                                    sb.Append(orderInfo.FullName == null ? value + "(" + logisticsName + "客户自提" + ")" : s + "(" + logisticsName + "客户自提" + ")");
                                    sb.Append("',");
                                }
                                else
                                {
                                    sb.Append("'");
                                    sb.Append(orderInfo.FullName == null ? value : orderInfo.FullName);
                                    sb.Append("',");
                                }
                            }
                            else                                    //直送
                            {
                                if (!string.IsNullOrEmpty(orderInfo.CustomerServiceRemark) && orderInfo.CustomerServiceRemark.IndexOf("///") > -1)
                                {
                                    string str = orderInfo.CustomerServiceRemark.Remove(0, orderInfo.CustomerServiceRemark.IndexOf("///") + 3);

                                    int index = str.IndexOf("/");
                                    string logisticsName = orderInfo.CustomerServiceRemark.IndexOf("/") > 0 ? orderInfo.CustomerServiceRemark.Substring(0, orderInfo.CustomerServiceRemark.IndexOf("/")) : "";       //获取物流公司名称
                                    string description = index > 0 ? str.Substring(0, index) : str;
                                    sb.Append("'"); sb.Append(orderInfo.FullName == null ? value + "(" + logisticsName + description + ")" : orderInfo.FullName + "(" + logisticsName + description + ")"); sb.Append("',");
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(orderInfo.FullName); sb.Append("',");
                                }
                            }

                            if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.IndexOf("转") > -1)           //中转
                            {
                                sb.Append("'"); sb.Append(transferAddress); sb.Append("',");
                                sb.Append("'"); sb.Append(phone); sb.Append("',");
                            }
                            else
                            {
                                if (orderInfo.DeliveryAddress.Contains(orderInfo.Province + orderInfo.City + orderInfo.County))//判断地址里面是否已包含省市区
                                {
                                    sb.Append("'"); sb.Append(orderInfo.DeliveryAddress); sb.Append("',");//包含省市区就去地址字段
                                }

                                else
                                {
                                    sb.Append("'"); sb.Append(orderInfo.Province + orderInfo.City + orderInfo.County + orderInfo.DeliveryAddress); sb.Append("',");//不包含省市区，把省市区加上
                                }
                                sb.Append("'"); sb.Append(orderInfo.Mobile == null ? value : orderInfo.Mobile); sb.Append("',");
                            }

                            string sellerremark = "";
                            string giveremark = "";
                            if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.IndexOf("//赠品") > -1)
                            {
                                //有赠品备注
                                sellerremark = orderInfo.CustomerServiceRemark.Substring(0, orderInfo.CustomerServiceRemark.IndexOf("//赠品"));
                                if (!string.IsNullOrEmpty(sellerremark))
                                {
                                    giveremark = orderInfo.CustomerServiceRemark.Replace(sellerremark, "");
                                }
                                else
                                {
                                    giveremark = orderInfo.CustomerServiceRemark;
                                }
                            }
                            else
                            {
                                //无赠品备注
                                sellerremark = orderInfo.CustomerServiceRemark;
                            }
                            sb.Append("'"); sb.Append(sellerremark); sb.Append("',");

                            if (No == 0)//一个订单只有一份赠品信息
                            {
                                sb.Append("'"); sb.Append(giveremark); sb.Append("',");
                                No++;
                            }
                            else
                            {
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }

                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(orderInfo.IsInvoiced == null ? value : Invoices); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            //if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            //{
                            //    var productdetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(xmpd.PlatformMerchantCode).FirstOrDefault();
                            //    if (productdetail != null && productdetail.ProductId != null)
                            //    {
                            //        bool IsTManufacturersCode = false;
                            //        if (productdetail.TDateTimeStart != null && productdetail.TDateTimeEnd != null)
                            //        {
                            //            if (OrderInfo.OrderInfoCreateDate >= productdetail.TDateTimeStart && OrderInfo.OrderInfoCreateDate < productdetail.TDateTimeEnd)
                            //            {
                            //                IsTManufacturersCode = true;
                            //                sb.Append("'"); sb.Append(productdetail.TemporaryManufacturersCode == null ? value : productdetail.TemporaryManufacturersCode); sb.Append("',");
                            //            }
                            //        }
                            //        if (!IsTManufacturersCode)
                            //        {
                            //            var product = IoC.Resolve<IXMProductService>().GetXMProductById(int.Parse(productdetail.ProductId.ToString()));
                            //            if (product != null)
                            //            {
                            //                sb.Append("'"); sb.Append(product.ManufacturersCode == null ? value : product.ManufacturersCode); sb.Append("',");
                            //            }
                            //            else
                            //            {
                            //                sb.Append("'"); sb.Append(""); sb.Append("',");
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        sb.Append("'"); sb.Append(""); sb.Append("',");
                            //    }
                            //}
                            //else
                            //{
                            //    sb.Append("'"); sb.Append(""); sb.Append("',");
                            //}
                            sb.Append("'"); sb.Append(xmpd.TManufacturersCode == null ? "订单无产品编码" : xmpd.TManufacturersCode); sb.Append("',");
                            if (no == 0)
                            {
                                sb.Append("'"); sb.Append(orderInfo.PayPrice == null ? 0 : orderInfo.PayPrice); sb.Append("',");
                                no++;
                            }
                            else
                            {
                                sb.Append("'"); sb.Append("0"); sb.Append("',");
                            }
                            //sb.Append("'"); sb.Append(xmpd.TCostprice == null ? 0 : xmpd.TCostprice); sb.Append("',");

                            if (xmpd.PlatformMerchantCode != "" && xmpd.PlatformMerchantCode != null)
                            {
                                var product = IoC.Resolve<XMOrderInfoAPIService>().GetXMProductListByMerchantcode(xmpd.PlatformMerchantCode);
                                if (product.Count > 0)
                                {

                                    sb.Append('"'); sb.Append(product[0].Costprice == null ? 0 : product[0].Costprice); sb.Append("\",");
                                }
                                else
                                {
                                    sb.Append("'"); sb.Append(0); sb.Append("',");
                                }
                            }
                            else
                            {
                                sb.Append('"'); sb.Append(0); sb.Append("\",");

                            }
                            sb.Append("'"); sb.Append(PlatformType); sb.Append("',");
                            sb.Append('"'); sb.Append(""); sb.Append('"');
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 导出发货清单excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public DataTable ExportPostList(List<XMDeliveryNew> list)
        {

                var db = new DataTable("table1");
                DataColumn dc1 = new DataColumn("发货单号", Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("订单编号", Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("买家会员名", Type.GetType("System.String"));
                DataColumn dc4 = new DataColumn("收件人", Type.GetType("System.String"));
                DataColumn dc5 = new DataColumn("收件人手机", Type.GetType("System.String"));
                DataColumn dc6 = new DataColumn("收货地址", Type.GetType("System.String"));
                DataColumn dc7 = new DataColumn("商品名称", Type.GetType("System.String"));
                DataColumn dc8 = new DataColumn("厂家编码", Type.GetType("System.String"));
                DataColumn dc9 = new DataColumn("规格型号", Type.GetType("System.String"));
                DataColumn dc10 = new DataColumn("数量", Type.GetType("System.Int64"));
                DataColumn dc11 = new DataColumn("支付时间", Type.GetType("System.DateTime"));
                DataColumn dc12 = new DataColumn("创建时间", Type.GetType("System.DateTime"));
                DataColumn dc13 = new DataColumn("卖家备注", Type.GetType("System.String"));
                DataColumn dc14 = new DataColumn("买家留言", Type.GetType("System.String"));
                DataColumn dc15 = new DataColumn("运费", Type.GetType("System.Decimal"));
                DataColumn dc16 = new DataColumn("店铺名称", Type.GetType("System.String"));
                DataColumn dc17 = new DataColumn("承运公司", Type.GetType("System.String"));
                DataColumn dc18 = new DataColumn("承运单号", Type.GetType("System.String"));
                db.Columns.Add(dc1);
                db.Columns.Add(dc2);
                db.Columns.Add(dc3);
                db.Columns.Add(dc4);
                db.Columns.Add(dc5);
                db.Columns.Add(dc6);
                db.Columns.Add(dc7);
                db.Columns.Add(dc8);
                db.Columns.Add(dc9);
                db.Columns.Add(dc10);
                db.Columns.Add(dc11);
                db.Columns.Add(dc12);
                db.Columns.Add(dc13);
                db.Columns.Add(dc14);
                db.Columns.Add(dc15);
                db.Columns.Add(dc16);
                db.Columns.Add(dc17);
                db.Columns.Add(dc18);
                var value = "";
                foreach (var detail in list)
                {
                    DataRow dr = db.NewRow();
                    dr["发货单号"] = detail.DeliveryNumber;
                    dr["订单编号"] = detail.OrderCode == null ? value : detail.OrderCode;
                    dr["买家会员名"] = detail.WantID == null ? value : detail.WantID.Replace("'", "");
                    dr["收件人"] = detail.FullName == null ? value : detail.FullName.Replace("'", "");
                    dr["收件人手机"] = detail.Mobile == null ? value : detail.Mobile.Replace("'", "");
                    dr["收货地址"] = detail.DeliveryAddress.Replace("'", "");
                    dr["商品名称"] = detail.ProductName == null ? value : detail.ProductName.Replace("'", "");
                    dr["厂家编码"] = detail.PlatformMerchantCode == null ? value : detail.PlatformMerchantCode.Replace("'", "");
                    dr["规格型号"] = detail.Specifications == null ? value : detail.Specifications.Replace("'", "");
                    dr["数量"] = detail.ProductNum == null ? 0 : (int)detail.ProductNum;
                    dr["支付时间"] = detail.PayDate == null ? DateTime.Now : detail.PayDate.Value;
                    dr["创建时间"] = detail.OrderInfoCreateDate == null ? DateTime.Now : detail.OrderInfoCreateDate.Value;
                    dr["卖家备注"] = detail.CustomerServiceRemark == null ? value : detail.CustomerServiceRemark.Replace("'", "").Length > 250 ? detail.CustomerServiceRemark.Replace("'", "").Substring(0, 250) : detail.CustomerServiceRemark.Replace("'", "");
                    dr["买家留言"] = detail.orderRemark == null ? value : detail.orderRemark.Replace("'", "");
                    dr["运费"] = detail.DistributePrice == null ? 0 : (decimal)detail.DistributePrice;
                    dr["店铺名称"] = detail.NickName.Replace("'", "");
                    dr["承运公司"] = detail.LogisticsCompany == null ? value : detail.LogisticsCompany.Replace("'", "");
                    dr["承运单号"] = detail.LogisticsNumber == null ? value : detail.LogisticsNumber.Replace("'", "");
                    db.Rows.Add(dr);
                }
            return db;
        }
        /// <summary>
        /// 导出发货清单excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public void ExportPostList(string filePath, List<XMDeliveryNew> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                //订单信息
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货单号", "nvarchar(50)");
                tableDefinition.Add("订单编号", "nvarchar(50)");
                tableDefinition.Add("买家会员名", "nvarchar(150)");
                tableDefinition.Add("收件人", "nvarchar(150)");
                tableDefinition.Add("收件人手机", "nvarchar(50)");
                tableDefinition.Add("收货地址", "nvarchar(100)");
                tableDefinition.Add("商品名称", "nvarchar(100)");
                tableDefinition.Add("厂家编码", "nvarchar(50)");
                tableDefinition.Add("规格型号", "nvarchar(200)");
                tableDefinition.Add("数量", "int");
                tableDefinition.Add("支付时间", "nvarchar(50)");
                tableDefinition.Add("创建时间", "nvarchar(50)");
                tableDefinition.Add("卖家备注", "nvarchar(250)");
                tableDefinition.Add("买家留言", "nvarchar(250)");
                tableDefinition.Add("运费", "nvarchar(50)");
                tableDefinition.Add("店铺名称", "nvarchar(100)");
                tableDefinition.Add("承运公司", "nvarchar(100)");
                tableDefinition.Add("承运单号", "nvarchar(50)");
                excelHelper.WriteTable("Sheet1", tableDefinition);

                List<string> OrderCodeList = new List<string>();
                List<string> deliveryNumberList = new List<string>();
                List<string> DeliveryNumberList = list.Select(x => x.DeliveryNumber).ToList();

                var value = "";
                foreach (var detail in list)
                {
                    StringBuilder st = new StringBuilder();
                    //订单SHEET数据
                    st.Append("INSERT INTO [Sheet1] (发货单号,订单编号, 买家会员名, 收件人, 收件人手机, 收货地址, 商品名称, 厂家编码, 规格型号,数量, 支付时间, 创建时间, 卖家备注, 买家留言, 运费, 店铺名称,承运公司,承运单号) VALUES (");
                    int ProductNum = detail.ProductNum == null ? 0 : (int)detail.ProductNum;
                    decimal DistributePrice = detail.DistributePrice == null ? 0 : (decimal)detail.DistributePrice;
                    st.Append("'"); st.Append(detail.DeliveryNumber); st.Append("',");
                    st.Append("'"); st.Append(detail.OrderCode == null ? value : detail.OrderCode); st.Append("',");
                    st.Append("'"); st.Append(detail.WantID == null ? value : detail.WantID.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.FullName == null ? value : detail.FullName.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.Mobile == null ? value : detail.Mobile.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.DeliveryAddress.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.ProductName == null ? value : detail.ProductName.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.PlatformMerchantCode == null ? value : detail.PlatformMerchantCode.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.Specifications == null ? value : detail.Specifications.Replace("'", "")); st.Append("',");
                    st.Append(""); st.Append(ProductNum); st.Append(",");
                    st.Append("'"); st.Append(detail.PayDate == null ? "" : detail.PayDate.Value.ToString("yyyy/M/d HH:mm:ss")); st.Append("',");
                    st.Append("'"); st.Append(detail.OrderInfoCreateDate == null ? "" : detail.OrderInfoCreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); st.Append("',");
                    st.Append("'"); st.Append(detail.CustomerServiceRemark == null ? value : detail.CustomerServiceRemark.Replace("'", "").Length>250? detail.CustomerServiceRemark.Replace("'", "").Substring(0,250): detail.CustomerServiceRemark.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.orderRemark == null ? value : detail.orderRemark.Replace("'", "")); st.Append("',");
                    st.Append(""); st.Append(DistributePrice); st.Append(",");
                    st.Append("'"); st.Append(detail.NickName.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.LogisticsCompany == null ? value : detail.LogisticsCompany.Replace("'", "")); st.Append("',");
                    st.Append("'"); st.Append(detail.LogisticsNumber == null ? value : detail.LogisticsNumber.Replace("'", "")); st.Append("'");
                    st.Append(")");
                    excelHelper.ExecuteCommand(st.ToString());
                }
            }
        }
        /// <summary>
        /// 导出发货清单excel（迪士尼）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public DataTable ExportPostListFromNSN(List<XMDeliveryNew> list)
        {
            var db = new DataTable("table1");
            var XMOrderInfoService = IoC.Resolve<XMOrderInfoService>();
            DataColumn dc1 = new DataColumn("订单号", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("下单时间", Type.GetType("System.DateTime"));
            DataColumn dc3 = new DataColumn("付款时间", Type.GetType("System.DateTime"));
            DataColumn dc4 = new DataColumn("交易类型", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("备注", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("买家留言", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("总金额", Type.GetType("System.Decimal"));
            DataColumn dc8 = new DataColumn("运费", Type.GetType("System.Decimal"));
            DataColumn dc9 = new DataColumn("实付总额", Type.GetType("System.Decimal"));
            DataColumn dc10 = new DataColumn("收货人姓名", Type.GetType("System.String"));
            DataColumn dc11 = new DataColumn("手机", Type.GetType("System.String"));
            DataColumn dc12 = new DataColumn("固话", Type.GetType("System.String"));
            DataColumn dc13 = new DataColumn("地址", Type.GetType("System.String"));
            DataColumn dc14 = new DataColumn("邮编", Type.GetType("System.String"));
            DataColumn dc15 = new DataColumn("电子邮箱", Type.GetType("System.String"));
            DataColumn dc16 = new DataColumn("商品编码", Type.GetType("System.String"));
            DataColumn dc17 = new DataColumn("商品名称", Type.GetType("System.String"));
            DataColumn dc18 = new DataColumn("规格名称", Type.GetType("System.String"));
            DataColumn dc19 = new DataColumn("数量", Type.GetType("System.Int64"));
            DataColumn dc20 = new DataColumn("单价", Type.GetType("System.Decimal"));
            DataColumn dc21 = new DataColumn("实付", Type.GetType("System.Decimal"));
            db.Columns.Add(dc1);
            db.Columns.Add(dc2);
            db.Columns.Add(dc3);
            db.Columns.Add(dc4);
            db.Columns.Add(dc5);
            db.Columns.Add(dc6);
            db.Columns.Add(dc7);
            db.Columns.Add(dc8);
            db.Columns.Add(dc9);
            db.Columns.Add(dc10);
            db.Columns.Add(dc11);
            db.Columns.Add(dc12);
            db.Columns.Add(dc13);
            db.Columns.Add(dc14);
            db.Columns.Add(dc15);
            db.Columns.Add(dc16);
            db.Columns.Add(dc17);
            db.Columns.Add(dc18);
            db.Columns.Add(dc19);
            db.Columns.Add(dc20);
            db.Columns.Add(dc21);
            foreach (var detail in list)
            {
                XMOrderInfo entity = XMOrderInfoService.GetXMOrderInfoByOrderCode(detail.OrderCode);

                StringBuilder st = new StringBuilder();

                if (entity != null)
                {
                    foreach (var item in entity.XM_OrderInfoProductDetails)
                    {
                        DataRow dr = db.NewRow();
                        dr["订单号"] = detail.OrderCode;
                        dr["下单时间"] = entity.CreateDate == null ? DateTime.Now : entity.CreateDate.Value;
                        dr["付款时间"] = entity.PayDate == null ? DateTime.Now : entity.PayDate.Value;
                        dr["交易类型"] = "线上订单";
                        dr["备注"] = entity.CustomerServiceRemark;
                        dr["买家留言"] = entity.Remark;
                        dr["总金额"] = entity.OrderPrice == null ? 0 : entity.OrderPrice;
                        dr["运费"] = 0;
                        dr["实付总额"] = entity.PayPrice == null ? 0 : entity.PayPrice;
                        dr["收货人姓名"] = entity.FullName;
                        dr["手机"] = entity.Mobile;
                        dr["固话"] = entity.Tel;
                        dr["地址"] = entity.DeliveryAddress;
                        dr["邮编"] = "";
                        dr["电子邮箱"] = "";
                        dr["商品编码"] = item.PlatformMerchantCode;
                        dr["商品名称"] = item.ProductName;
                        dr["规格名称"] = item.Specifications;
                        dr["数量"] = item.ProductNum == null ? 0 : item.ProductNum.GetValueOrDefault(0);
                        decimal salePrice = item.SalesPrice == null ? 0 : (decimal)item.SalesPrice.GetValueOrDefault(0);
                        dr["单价"] = item.ProductNum == null ? 0 : salePrice / item.ProductNum.GetValueOrDefault(1);
                        dr["实付"] = salePrice;
                        db.Rows.Add(dr);
                    }
                }
            }
            return db;
        }
        /// <summary>
        /// 导出发货清单excel（迪士尼）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public void ExportPostListFromNSN(string filePath, List<XMDeliveryNew> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                var XMOrderInfoService = IoC.Resolve<XMOrderInfoService>();

                //订单信息
                Dictionary <string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("下单时间", "nvarchar(50)");
                tableDefinition.Add("付款时间", "nvarchar(50)");
                tableDefinition.Add("交易类型", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(150)");
                tableDefinition.Add("买家留言", "nvarchar(150)");
                tableDefinition.Add("总金额", "nvarchar(50)");
                tableDefinition.Add("运费", "nvarchar(50)");
                tableDefinition.Add("实付总额", "nvarchar(50)");
                tableDefinition.Add("收货人姓名", "nvarchar(50)");
                tableDefinition.Add("手机", "nvarchar(50)");
                tableDefinition.Add("固话", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(50)");
                tableDefinition.Add("邮编", "nvarchar(50)");
                tableDefinition.Add("电子邮箱", "nvarchar(50)");
                tableDefinition.Add("商品编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("规格名称", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("实付", "nvarchar(50)");
                excelHelper.WriteTable("Sheet1", tableDefinition);
                try
                {
                    foreach (var detail in list)
                    {
                        XMOrderInfo entity = XMOrderInfoService.GetXMOrderInfoByOrderCode(detail.OrderCode);

                        StringBuilder st = new StringBuilder();
                      
                        if (entity != null)
                        {
                            foreach (var item in entity.XM_OrderInfoProductDetails)
                            {
                                st.Append("INSERT INTO [Sheet1] (订单号,下单时间, 付款时间, 交易类型, 备注, 买家留言, 总金额, 运费, 实付总额,收货人姓名, 手机, 固话, 地址, 邮编, 电子邮箱,商品编码,商品名称,规格名称,数量,单价,实付) VALUES (");
                                st.Append("'"); st.Append(detail.OrderCode); st.Append("',");
                                st.Append("'"); st.Append(entity.CreateDate == null ? "" : entity.CreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); st.Append("',");
                                st.Append("'"); st.Append(entity.PayDate == null ? "" : entity.PayDate.Value.ToString("yyyy/M/d HH:mm:ss")); st.Append("',");
                                st.Append("'"); st.Append("线上订单"); st.Append("',");
                                st.Append("'"); st.Append(entity.CustomerServiceRemark); st.Append("',");
                                st.Append("'"); st.Append(entity.Remark); st.Append("',");
                                st.Append("'"); st.Append(entity.OrderPrice == null ? 0 : entity.OrderPrice); st.Append("',");
                                st.Append("'"); st.Append(0); st.Append("',");
                                st.Append("'"); st.Append(entity.PayPrice == null ? 0 : entity.PayPrice); st.Append("',");
                                st.Append("'"); st.Append(entity.FullName); st.Append("',");
                                st.Append("'"); st.Append(entity.Mobile); st.Append("',");
                                st.Append("'"); st.Append(entity.Tel); st.Append("',");
                                st.Append("'"); st.Append(entity.DeliveryAddress); st.Append("',");
                                st.Append("'"); st.Append(""); st.Append("',");
                                st.Append("'"); st.Append(""); st.Append("',");
                                st.Append("'"); st.Append(item.PlatformMerchantCode); st.Append("',");
                                st.Append("'"); st.Append(item.ProductName); st.Append("',");
                                st.Append("'"); st.Append(item.Specifications); st.Append("',");
                                st.Append("'"); st.Append(item.ProductNum == null ? 0 : item.ProductNum.GetValueOrDefault(0)); st.Append("',");
                                decimal salePrice = item.SalesPrice == null ? 0 : (decimal)item.SalesPrice.GetValueOrDefault(0);
                                st.Append("'"); st.Append(item.ProductNum == null ? 0 : salePrice / item.ProductNum.GetValueOrDefault(1)); st.Append("',");
                                st.Append("'"); st.Append(salePrice); st.Append("'");
                                st.Append(")");
                                excelHelper.ExecuteCommand(st.ToString());
                                st.Clear();
                            }
                        }
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void ExportPostListFromInstallation(string filePath, List<XMInstallationListNew> installationList)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("买家ID", "nvarchar(50)");
                tableDefinition.Add("订单编号", "nvarchar(50)");
                tableDefinition.Add("项目", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("下单时间", "nvarchar(150)");
                tableDefinition.Add("客户姓名", "nvarchar(50)");
                tableDefinition.Add("客户电话", "nvarchar(50)");
                tableDefinition.Add("师傅姓名", "nvarchar(50)");
                tableDefinition.Add("师傅电话", "nvarchar(50)");
                tableDefinition.Add("是否安排", "nvarchar(50)");
                tableDefinition.Add("是否安装", "nvarchar(50)");

                excelHelper.WriteTable("Sheet1", tableDefinition);

                foreach (var detail in installationList)
                {
                    StringBuilder st = new StringBuilder();
                    st.Append("INSERT INTO [Sheet1] (买家ID,订单编号, 项目, 店铺, 下单时间, 客户姓名, 客户电话, 师傅姓名, 师傅电话,是否安排, 是否安装) VALUES (");

                    st.Append("'"); st.Append(detail.WantID); st.Append("',");
                    st.Append("'"); st.Append(detail.OrderCode); st.Append("',");
                    st.Append("'"); st.Append(detail.ProjectName); st.Append("',");
                    st.Append("'"); st.Append(detail.NickName); st.Append("',");
                    st.Append("'"); st.Append(detail.PayDate); st.Append("',");
                    st.Append("'"); st.Append(detail.CustomerName); st.Append("',");
                    st.Append("'"); st.Append(detail.CustomerTel); st.Append("',");
                    st.Append("'"); st.Append(detail.FullName); st.Append("',");
                    st.Append("'"); st.Append(detail.WorkerTel); st.Append("',");
                    st.Append("'"); st.Append(detail.IsArrange==true?"是":"否"); st.Append("',");
                    st.Append("'"); st.Append(detail.IsInstall == true ? "是" : "否"); st.Append("'");
                    st.Append(")");
                    excelHelper.ExecuteCommand(st.ToString());
                }
            }
        }
        public DataTable ExportPostListFromZM(List<XMDeliveryNew> list)
        {
            var db = new DataTable("table1");
            DataColumn dc1 = new DataColumn("序号", Type.GetType("System.Int64"));
            DataColumn dc2 = new DataColumn("日期", Type.GetType("System.DateTime"));
            DataColumn dc3 = new DataColumn("厂家型号", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("和众产品名称", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("数量", Type.GetType("System.Int64"));
            DataColumn dc6 = new DataColumn("平台订单号", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("客户姓名", Type.GetType("System.String"));
            DataColumn dc8 = new DataColumn("联系电话", Type.GetType("System.String"));
            DataColumn dc9 = new DataColumn("客户地址", Type.GetType("System.String"));
            DataColumn dc10 = new DataColumn("快递公司", Type.GetType("System.String"));
            DataColumn dc11 = new DataColumn("备注", Type.GetType("System.String"));
            db.Columns.Add(dc1);
            db.Columns.Add(dc2);
            db.Columns.Add(dc3);
            db.Columns.Add(dc4);
            db.Columns.Add(dc5);
            db.Columns.Add(dc6);
            db.Columns.Add(dc7);
            db.Columns.Add(dc8);
            db.Columns.Add(dc9);
            db.Columns.Add(dc10);
            db.Columns.Add(dc11);
            //序号
            int zIndex = 1;
            foreach (var detail in list)
            {
                DataRow dr = db.NewRow();
                dr["序号"] = zIndex;
                dr["日期"] = detail.CreateDate == null ? DateTime.Now : detail.CreateDate.Value;
                dr["厂家型号"] = detail.Specifications;
                dr["和众产品名称"] = detail.ProductName;
                dr["数量"] = detail.ProductNum == null ? 0 : detail.ProductNum;
                dr["平台订单号"] = detail.OrderCode;
                dr["客户姓名"] = detail.FullName;
                dr["联系电话"] = detail.Mobile;
                dr["客户地址"] = detail.DeliveryAddress;
                string logisticsId = detail.LogisticsId == null ? "0" : detail.LogisticsId.ToString();
                var LogisticsCompany = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(logisticsId);
                if (LogisticsCompany != null)
                {
                    dr["快递公司"] = LogisticsCompany.LogisticsName;
                }
                else
                {
                    dr["快递公司"] = "";
                }
                dr["备注"] = detail.OrderRemarks;
                db.Rows.Add(dr);
                zIndex++;
            }
            return db;
        }
        public void ExportPostListFromZM(string filePath, List<XMDeliveryNew> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                //订单信息
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "int");
                tableDefinition.Add("日期", "nvarchar(50)");
                tableDefinition.Add("厂家型号", "nvarchar(50)");
                tableDefinition.Add("和众产品名称", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("平台订单号", "nvarchar(50)");
                tableDefinition.Add("客户姓名", "nvarchar(50)");
                tableDefinition.Add("联系电话", "nvarchar(50)");
                tableDefinition.Add("客户地址", "nvarchar(150)");
                tableDefinition.Add("快递公司", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(150)");
                excelHelper.WriteTable("Sheet1", tableDefinition);

                //序号
                int zIndex = 1;

                foreach (var item in list)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [Sheet1] (序号,日期, 厂家型号, 和众产品名称, 数量, 平台订单号, 客户姓名, 联系电话, 客户地址,快递公司, 备注) VALUES (");
                    sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.CreateDate == null ? "" : item.CreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.Specifications); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.ProductName); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.ProductNum == null ? 0 : item.ProductNum); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.OrderCode); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.FullName); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.Mobile); sb.Append("\",");
                    sb.Append('"'); sb.Append(item.DeliveryAddress); sb.Append("\",");
                    string logisticsId = item.LogisticsId == null ? "0" : item.LogisticsId.ToString();
                    var LogisticsCompany = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(logisticsId);
                    if (LogisticsCompany != null)
                    {
                        sb.Append('"'); sb.Append(LogisticsCompany.LogisticsName); sb.Append("\",");
                    }
                    else
                    {
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                    }
                    sb.Append('"'); sb.Append(item.OrderRemarks); sb.Append("\"");
                    sb.Append(")");
                    excelHelper.ExecuteCommand(sb.ToString());
                    zIndex++;
                }
            }
        }
        public DataTable ExportPostListFromQM( List<XMDeliveryNew> list)
        {
            var db = new DataTable("table1");
            DataColumn dc1 = new DataColumn("发货时间", Type.GetType("System.DateTime"));
            DataColumn dc2 = new DataColumn("外部订单号", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("淘宝ID", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("下单时间", Type.GetType("System.DateTime"));
            DataColumn dc5 = new DataColumn("付款时间", Type.GetType("System.DateTime"));
            DataColumn dc6 = new DataColumn("产品名称", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("尺寸", Type.GetType("System.String"));
            DataColumn dc8 = new DataColumn("数量", Type.GetType("System.Int64"));
            DataColumn dc9 = new DataColumn("客户姓名", Type.GetType("System.String"));
            DataColumn dc10 = new DataColumn("地址", Type.GetType("System.String"));
            DataColumn dc11 = new DataColumn("联系方式", Type.GetType("System.String"));
            DataColumn dc12 = new DataColumn("卖家备注", Type.GetType("System.String"));
            DataColumn dc13 = new DataColumn("赠品备注", Type.GetType("System.String"));
            DataColumn dc14 = new DataColumn("买家备注", Type.GetType("System.String"));
            DataColumn dc15 = new DataColumn("是否开发票", Type.GetType("System.String"));
            DataColumn dc16 = new DataColumn("发票抬头", Type.GetType("System.String"));
            DataColumn dc17 = new DataColumn("产品编码", Type.GetType("System.String"));
            DataColumn dc18 = new DataColumn("单价", Type.GetType("System.Decimal"));
            DataColumn dc19 = new DataColumn("供货价", Type.GetType("System.Decimal"));
            DataColumn dc20 = new DataColumn("店铺", Type.GetType("System.String"));
            DataColumn dc21 = new DataColumn("订单编号", Type.GetType("System.String"));
            db.Columns.Add(dc1);
            db.Columns.Add(dc2);
            db.Columns.Add(dc3);
            db.Columns.Add(dc4);
            db.Columns.Add(dc5);
            db.Columns.Add(dc6);
            db.Columns.Add(dc7);
            db.Columns.Add(dc8);
            db.Columns.Add(dc9);
            db.Columns.Add(dc10);
            db.Columns.Add(dc11);
            db.Columns.Add(dc12);
            db.Columns.Add(dc13);
            db.Columns.Add(dc14);
            db.Columns.Add(dc15);
            db.Columns.Add(dc16);
            db.Columns.Add(dc17);
            db.Columns.Add(dc18);
            db.Columns.Add(dc19);
            db.Columns.Add(dc20);
            db.Columns.Add(dc21);
            foreach (var item in list)
            {
                var orderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(item.OrderCode);
                if (orderInfo != null)
                {
                    DataRow dr = db.NewRow();
                    dr["发货时间"] = orderInfo.DeliveryTime == null ? DateTime.Now: orderInfo.DeliveryTime.Value;
                    dr["外部订单号"] = orderInfo.OrderCode;
                    dr["淘宝ID"] = orderInfo.WantID;
                    dr["下单时间"] = orderInfo.OrderInfoCreateDate == null ? DateTime.Now : orderInfo.OrderInfoCreateDate.Value;
                    dr["付款时间"] = orderInfo.PayDate == null ? DateTime.Now : orderInfo.PayDate.Value;
                    dr["产品名称"] = item.ProductName;
                    dr["尺寸"] = item.Specifications;
                    dr["数量"] = item.ProductNum == null ? 0 : item.ProductNum;
                    dr["客户姓名"] = item.FullName;
                    dr["地址"] = item.DeliveryAddress;
                    dr["联系方式"] = item.Mobile;
                    if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.Length > 250)
                    {
                        dr["卖家备注"] = orderInfo.CustomerServiceRemark.Substring(0, 250);
                    }
                    else
                    {
                        dr["卖家备注"] = orderInfo.CustomerServiceRemark;
                    }
                    dr["赠品备注"] = "";
                    if (orderInfo.Remark != null && orderInfo.Remark.Length > 250)
                    {
                        dr["买家备注"] = orderInfo.Remark.Substring(0, 250);
                    }
                    else
                    {
                        dr["买家备注"] = orderInfo.Remark;
                    }
                    if (!string.IsNullOrEmpty(orderInfo.InvoiceHead))
                    {
                        dr["是否开发票"] = "是";
                        dr["发票抬头"] = orderInfo.InvoiceHead;
                    }
                    else
                    {
                        dr["是否开发票"] = "否";
                        dr["发票抬头"] = "";
                    }
                    int nickID = item.NickID == null ? 0 : (int)item.NickID;
                    var nickEntity = IoC.Resolve<IXMNickService>().GetXMNickByID(nickID);
                    if (nickEntity != null)
                    {
                        var productDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(item.PlatformMerchantCode, (int)nickEntity.PlatformTypeId, "");
                        if (productDetail.Count > 0)
                        {
                            var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)productDetail[0].ProductId);
                            dr["产品编码"] = product.ManufacturersCode;
                            dr["单价"] = productDetail[0].Saleprice == null ? 0 : productDetail[0].Saleprice;
                            dr["供货价"] = productDetail[0].Costprice == null ? 0 : productDetail[0].Costprice;
                        }
                        else
                        {
                            dr["产品编码"] = "";
                            dr["单价"] = 0;
                            dr["供货价"] = 0;
                        }
                    }
                    else
                    {
                        dr["产品编码"] = "";
                        dr["单价"] = 0;
                        dr["供货价"] = 0;
                    }
                    dr["店铺"] = item.NickName;
                    dr["订单编号"] = "";
                    db.Rows.Add(dr);
                }

            }
            return db;
        }
        public void ExportPostListFromQM(string filePath, List<XMDeliveryNew> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                //订单信息
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货时间", "nvarchar(50)");
                tableDefinition.Add("外部订单号", "nvarchar(50)");
                tableDefinition.Add("淘宝ID", "nvarchar(50)");
                tableDefinition.Add("下单时间", "nvarchar(50)");
                tableDefinition.Add("付款时间", "nvarchar(50)");
                tableDefinition.Add("产品名称", "nvarchar(50)");
                tableDefinition.Add("尺寸", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("客户姓名", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(50)");
                tableDefinition.Add("联系方式", "nvarchar(50)");
                tableDefinition.Add("卖家备注", "nvarchar(250)");
                tableDefinition.Add("赠品备注", "nvarchar(250)");
                tableDefinition.Add("买家备注", "nvarchar(250)");
                tableDefinition.Add("是否开发票", "nvarchar(10)");
                tableDefinition.Add("发票抬头", "nvarchar(150)");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("供货价", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("订单编号", "nvarchar(50)");
                excelHelper.WriteTable("Sheet1", tableDefinition);

                foreach (var item in list)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [Sheet1] (发货时间,外部订单号, 淘宝ID, 下单时间, 付款时间, 产品名称, 尺寸, 数量, 客户姓名,地址, 联系方式,卖家备注,赠品备注,买家备注,是否开发票,发票抬头,产品编码,单价,供货价,店铺,订单编号) VALUES (");

                    var orderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(item.OrderCode);
                    if(orderInfo!=null)
                    {
                        sb.Append('"'); sb.Append(orderInfo.DeliveryTime==null?"": orderInfo.DeliveryTime.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.WantID); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.OrderInfoCreateDate==null?"": orderInfo.OrderInfoCreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.PayDate==null?"": orderInfo.PayDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProductNum==null?0: item.ProductNum); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.FullName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.DeliveryAddress); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Mobile); sb.Append("\",");
                        if(orderInfo.CustomerServiceRemark!=null&&orderInfo.CustomerServiceRemark.Length>250)
                        {
                            sb.Append('"'); sb.Append(orderInfo.CustomerServiceRemark.Substring(0, 250)); sb.Append("\",");
                            //sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(orderInfo.CustomerServiceRemark); sb.Append("\",");
                            //sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        if(orderInfo.Remark!=null&&orderInfo.Remark.Length>250)
                        {
                            sb.Append('"'); sb.Append(orderInfo.Remark.Substring(0, 250)); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(orderInfo.Remark); sb.Append("\",");
                        }
                        if(!string.IsNullOrEmpty(orderInfo.InvoiceHead))
                        {
                            sb.Append('"'); sb.Append("是"); sb.Append("\",");
                            sb.Append('"'); sb.Append(orderInfo.InvoiceHead); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append("否"); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        int nickID = item.NickID == null ? 0 : (int)item.NickID;
                        var nickEntity = IoC.Resolve<IXMNickService>().GetXMNickByID(nickID);
                        if(nickEntity!=null)
                        {
                            var productDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(item.PlatformMerchantCode, (int)nickEntity.PlatformTypeId, "");
                            if(productDetail.Count>0)
                            {
                                var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)productDetail[0].ProductId);
                                sb.Append('"'); sb.Append(product.ManufacturersCode); sb.Append("\",");
                                sb.Append('"'); sb.Append(productDetail[0].Saleprice==null?0: productDetail[0].Saleprice); sb.Append("\",");
                                sb.Append('"'); sb.Append(productDetail[0].Costprice==null?0: productDetail[0].Costprice); sb.Append("\",");
                            }
                            else
                            {
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                            }
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(item.NickName); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                    }

                }
            }
        }
        public DataTable ExportPostListFromLYS( List<XMDeliveryNew> list)
        {
            var db = new DataTable("table1");
            DataColumn dc1 = new DataColumn("发货时间", Type.GetType("System.DateTime"));
            DataColumn dc2 = new DataColumn("订单号", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("会员名称", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("网店名称", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("下单时间", Type.GetType("System.DateTime"));
            DataColumn dc6 = new DataColumn("付款时间", Type.GetType("System.DateTime"));
            DataColumn dc7 = new DataColumn("产品", Type.GetType("System.String"));
            DataColumn dc8 = new DataColumn("尺寸", Type.GetType("System.String"));
            DataColumn dc9 = new DataColumn("订货数", Type.GetType("System.Int64"));
            DataColumn dc10 = new DataColumn("收货人姓名", Type.GetType("System.String"));
            DataColumn dc11 = new DataColumn("所在省", Type.GetType("System.String"));
            DataColumn dc12 = new DataColumn("所在市", Type.GetType("System.String"));
            DataColumn dc13 = new DataColumn("所在县", Type.GetType("System.String"));
            DataColumn dc14 = new DataColumn("地址", Type.GetType("System.String"));
            DataColumn dc15 = new DataColumn("邮编编码", Type.GetType("System.String"));
            DataColumn dc16 = new DataColumn("固定电话", Type.GetType("System.String"));
            DataColumn dc17 = new DataColumn("手机", Type.GetType("System.String"));
            DataColumn dc18 = new DataColumn("卖家备注", Type.GetType("System.String"));
            DataColumn dc19 = new DataColumn("赠品备注", Type.GetType("System.String"));
            DataColumn dc20 = new DataColumn("买家备注", Type.GetType("System.String"));
            DataColumn dc21 = new DataColumn("是否开发票", Type.GetType("System.String"));
            DataColumn dc22 = new DataColumn("发票类型", Type.GetType("System.String"));
            DataColumn dc23 = new DataColumn("发票抬头", Type.GetType("System.String"));
            DataColumn dc24 = new DataColumn("运费", Type.GetType("System.Decimal"));
            DataColumn dc25 = new DataColumn("物流单号", Type.GetType("System.String"));
            DataColumn dc26 = new DataColumn("类型", Type.GetType("System.String"));
            DataColumn dc27 = new DataColumn("产品编码", Type.GetType("System.String"));
            DataColumn dc28 = new DataColumn("单价", Type.GetType("System.Decimal"));
            DataColumn dc29 = new DataColumn("供货价", Type.GetType("System.Decimal"));
            DataColumn dc30 = new DataColumn("特供价", Type.GetType("System.Decimal"));
            DataColumn dc31 = new DataColumn("店铺", Type.GetType("System.String"));
            db.Columns.Add(dc1);
            db.Columns.Add(dc2);
            db.Columns.Add(dc3);
            db.Columns.Add(dc4);
            db.Columns.Add(dc5);
            db.Columns.Add(dc6);
            db.Columns.Add(dc7);
            db.Columns.Add(dc8);
            db.Columns.Add(dc9);
            db.Columns.Add(dc10);
            db.Columns.Add(dc11);
            db.Columns.Add(dc12);
            db.Columns.Add(dc13);
            db.Columns.Add(dc14);
            db.Columns.Add(dc15);
            db.Columns.Add(dc16);
            db.Columns.Add(dc17);
            db.Columns.Add(dc18);
            db.Columns.Add(dc19);
            db.Columns.Add(dc20);
            db.Columns.Add(dc21);
            db.Columns.Add(dc22);
            db.Columns.Add(dc23);
            db.Columns.Add(dc24);
            db.Columns.Add(dc25);
            db.Columns.Add(dc26);
            db.Columns.Add(dc27);
            db.Columns.Add(dc28);
            db.Columns.Add(dc29);
            db.Columns.Add(dc30);
            db.Columns.Add(dc31);
            foreach (var item in list)
            {
                var orderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(item.OrderCode);
                if (orderInfo != null)
                {
                    DataRow dr = db.NewRow();
                    dr["发货时间"] = orderInfo.DeliveryTime == null ? DateTime.Now : orderInfo.DeliveryTime.Value;
                    dr["订单号"] = orderInfo.OrderCode;
                    dr["会员名称"] = orderInfo.WantID;
                    dr["网店名称"] = "";
                    dr["下单时间"] = orderInfo.OrderInfoCreateDate == null ? DateTime.Now : orderInfo.OrderInfoCreateDate.Value;
                    dr["付款时间"] = orderInfo.PayDate == null ? DateTime.Now : orderInfo.PayDate.Value;
                    dr["产品"] = item.ProductName;
                    dr["尺寸"] = item.Specifications;
                    dr["订货数"] = item.ProductNum == null ? 0 : item.ProductNum;
                    dr["收货人姓名"] = item.FullName;
                    dr["所在省"] = item.Province;
                    dr["所在市"] = item.City;
                    dr["所在县"] = item.County;
                    dr["地址"] = item.DeliveryAddress;
                    dr["邮编编码"] = "";
                    dr["固定电话"] = orderInfo.Tel;
                    dr["手机"] = orderInfo.Mobile;
                    if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.Length > 250)
                    {
                        dr["卖家备注"] = orderInfo.CustomerServiceRemark.Substring(0, 250);
                    }
                    else
                    {
                        dr["卖家备注"] = orderInfo.CustomerServiceRemark;
                    }
                    dr["赠品备注"] = "";
                    if (orderInfo.Remark != null && orderInfo.Remark.Length > 250)
                    {
                        dr["买家备注"] = orderInfo.Remark.Substring(0, 250);
                    }
                    else
                    {
                        dr["买家备注"] = orderInfo.Remark;
                    }
                    if (!string.IsNullOrEmpty(orderInfo.InvoiceHead))
                    {
                        dr["是否开发票"] = "是";
                        dr["发票类型"] = "";
                        dr["发票抬头"] = orderInfo.InvoiceHead;
                    }
                    else
                    {
                        dr["是否开发票"] = "否";
                        dr["发票类型"] = "";
                        dr["发票抬头"] = "";
                    }
                    dr["运费"] = 0;
                    dr["物流单号"] = item.LogisticsNumber;
                    dr["类型"] = "";
                    int nickID = item.NickID == null ? 0 : (int)item.NickID;
                    var nickEntity = IoC.Resolve<IXMNickService>().GetXMNickByID(nickID);
                    if (nickEntity != null)
                    {
                        var productDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(item.PlatformMerchantCode, (int)nickEntity.PlatformTypeId, "");
                        if (productDetail.Count > 0)
                        {
                            var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)productDetail[0].ProductId);
                            dr["产品编码"] = product.ManufacturersCode;
                            dr["单价"] = productDetail[0].Saleprice == null ? 0 : productDetail[0].Saleprice;
                            dr["供货价"] = productDetail[0].Costprice == null ? 0 : productDetail[0].Costprice;
                            dr["特供价"] = productDetail[0].TCostprice == null ? 0 : productDetail[0].TCostprice;
                        }
                        else
                        {
                            dr["产品编码"] = "";
                            dr["单价"] = 0;
                            dr["供货价"] = 0;
                            dr["特供价"] = 0;
                        }
                    }
                    else
                    {
                        dr["产品编码"] = "";
                        dr["单价"] = 0;
                        dr["供货价"] = 0;
                        dr["特供价"] = 0;
                    }
                   dr["店铺"] = item.NickName;
                   db.Rows.Add(dr);
                }

            }
            return db;
        }
        public void ExportPostListFromLYS(string filePath, List<XMDeliveryNew> list)
        {
            using (ExcelHelper excelHelper1 = new ExcelHelper(filePath))
            {
                excelHelper1.Hdr = "YES";
                excelHelper1.Imex = "0";

                //订单信息
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货时间", "nvarchar(50)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("会员名称", "nvarchar(50)");
                tableDefinition.Add("网店名称", "nvarchar(50)");
                tableDefinition.Add("下单时间", "nvarchar(50)");
                tableDefinition.Add("付款时间", "nvarchar(50)");
                tableDefinition.Add("产品", "nvarchar(50)");
                tableDefinition.Add("尺寸", "nvarchar(50)");
                tableDefinition.Add("订货数", "nvarchar(50)");
                tableDefinition.Add("收货人姓名", "nvarchar(50)");
                tableDefinition.Add("所在省", "nvarchar(50)");
                tableDefinition.Add("所在市", "nvarchar(50)");
                tableDefinition.Add("所在县", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(50)");
                tableDefinition.Add("邮编编码", "nvarchar(250)");
                tableDefinition.Add("固定电话", "nvarchar(250)");
                tableDefinition.Add("手机", "nvarchar(250)");
                tableDefinition.Add("卖家备注", "nvarchar(10)");
                tableDefinition.Add("赠品备注", "nvarchar(150)");
                tableDefinition.Add("买家备注", "nvarchar(50)");
                tableDefinition.Add("是否开发票", "nvarchar(50)");
                tableDefinition.Add("发票类型", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "nvarchar(50)");
                tableDefinition.Add("运费", "nvarchar(50)");
                tableDefinition.Add("物流单号", "nvarchar(50)");
                tableDefinition.Add("类型", "nvarchar(50)");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("供货价", "nvarchar(50)");
                tableDefinition.Add("特供价", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                excelHelper1.WriteTable("Sheet1", tableDefinition);

                foreach (var item in list)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [Sheet1] (发货时间,订单号, 会员名称, 网店名称, 下单时间, 付款时间,产品, 尺寸, 订货数, 收货人姓名,所在省,所在市,所在县,地址, 邮编编码,固定电话,手机,卖家备注,赠品备注,买家备注,是否开发票,发票类型,发票抬头,运费,物流单号,类型,产品编码,单价,供货价,特供价,店铺) VALUES (");

                    var orderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(item.OrderCode);
                    if(orderInfo!=null)
                    {
                        sb.Append('"'); sb.Append(orderInfo.DeliveryTime == null ? "" : orderInfo.DeliveryTime.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.WantID); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.OrderInfoCreateDate == null ? "" : orderInfo.OrderInfoCreateDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.PayDate == null ? "" : orderInfo.PayDate.Value.ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProductNum == null ? 0 : item.ProductNum); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.FullName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Province); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.City); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.County); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.DeliveryAddress); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.Tel); sb.Append("\",");
                        sb.Append('"'); sb.Append(orderInfo.Mobile); sb.Append("\",");
                        if (orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark.Length > 250)
                        {
                            sb.Append('"'); sb.Append(orderInfo.CustomerServiceRemark.Substring(0, 250)); sb.Append("\",");
                            //sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(orderInfo.CustomerServiceRemark); sb.Append("\",");
                            //sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        if (orderInfo.Remark != null && orderInfo.Remark.Length > 250)
                        {
                            sb.Append('"'); sb.Append(orderInfo.Remark.Substring(0, 250)); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(orderInfo.Remark); sb.Append("\",");
                        }
                        if (!string.IsNullOrEmpty(orderInfo.InvoiceHead))
                        {
                            sb.Append('"'); sb.Append("是"); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(orderInfo.InvoiceHead); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append("否"); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.LogisticsNumber); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");

                        int nickID = item.NickID == null ? 0 : (int)item.NickID;
                        var nickEntity = IoC.Resolve<IXMNickService>().GetXMNickByID(nickID);
                        if (nickEntity != null)
                        {
                            var productDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(item.PlatformMerchantCode, (int)nickEntity.PlatformTypeId, "");
                            if (productDetail.Count > 0)
                            {
                                var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)productDetail[0].ProductId);
                                sb.Append('"'); sb.Append(product.ManufacturersCode); sb.Append("\",");
                                sb.Append('"'); sb.Append(productDetail[0].Saleprice == null ? 0 : productDetail[0].Saleprice); sb.Append("\",");
                                sb.Append('"'); sb.Append(productDetail[0].Costprice == null ? 0 : productDetail[0].Costprice); sb.Append("\",");
                                sb.Append('"'); sb.Append(productDetail[0].TCostprice == null ? 0 : productDetail[0].TCostprice); sb.Append("\",");
                            }
                            else
                            {
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                                sb.Append('"'); sb.Append(""); sb.Append("\",");
                            }
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(item.NickName); sb.Append("\"");
                        sb.Append(")");
                        excelHelper1.ExecuteCommand(sb.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 导出采购明细表 excel     （进销存系统）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public void ExportPurchaseDetail(string filePath, List<PurchaseDetail> orderLists)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                //采购单明细
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "int");
                tableDefinition.Add("采购时间", "nvarchar(50)");
                tableDefinition.Add("采购单号", "nvarchar(50)");
                tableDefinition.Add("入库单号", "nvarchar(50)");
                tableDefinition.Add("商品编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("单位", "nvarchar(50)");
                tableDefinition.Add("仓库", "nvarchar(255)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("采购金额", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(255)");
                excelHelper.WriteTable("采购明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (orderLists != null && orderLists.Count > 0)
                {
                    foreach (var one in orderLists)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [采购明细表] (序号,采购时间, 采购单号, 入库单号, 商品编码, 商品名称, 单位, 仓库, 数量,单价, 采购金额, 备注) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PurchaseDate == null ? "" : one.PurchaseDate.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PurchaseNumber == null ? "" : one.PurchaseNumber); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Ref == null ? "" : one.Ref.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PlatformMerchantCode == null ? "" : one.PlatformMerchantCode); sb.Append("\",");

                        sb.Append('"'); sb.Append(one.ProductName == null ? "" : one.ProductName.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductUnit == null ? "" : one.ProductUnit); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.WareHouseName == null ? "" : one.WareHouseName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductsCount == null ? "" : one.ProductsCount.ToString()); sb.Append("\",");

                        sb.Append('"'); sb.Append(one.ProductsPrice == null ? "" : one.ProductsPrice.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductsMoney == null ? "" : one.ProductsMoney.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.BillMemo == null ? "" : one.BillMemo.ToString()); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        #region
        /// <summary>
        /// 采购退货单产品明细导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportPurchaseRejectedDetail(string filePath, List<PurchaseRejectedDetail> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                //退货单明细
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "int");
                tableDefinition.Add("退货单号", "nvarchar(50)");
                tableDefinition.Add("商品编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("尺寸规格", "nvarchar(50)");
                tableDefinition.Add("退货单价", "nvarchar(50)");
                tableDefinition.Add("退货数量", "nvarchar(50)");
                tableDefinition.Add("总金额", "nvarchar(255)");
                tableDefinition.Add("供应商", "nvarchar(50)");
                tableDefinition.Add("发出工厂", "nvarchar(50)");
                tableDefinition.Add("退回状态", "nvarchar(255)");
                excelHelper.WriteTable("采购退货表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [采购退货表] (序号,退货单号, 商品编码, 商品名称, 尺寸规格, 退货单价, 退货数量, 总金额, 供应商, 发出工厂, 退回状态) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Ref == null ? "" : one.Ref); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PlatformMerchantCode == null ? "" : one.PlatformMerchantCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductName == null ? "" : one.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Specifications == null ? "" : one.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.RejectionProductPrice.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.RejectionCount.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.RejectionMoney.ToString()); sb.Append("\",");
                        string supplierName = "";
                        if (one.SupplierId != null)
                        {
                            var supplier = IoC.Resolve<XMSuppliersService>().GetXMSuppliersById(one.SupplierId.Value);
                            if (supplier != null)
                            {
                                supplierName = supplier.SupplierName;
                            }
                        }
                        sb.Append('"'); sb.Append(supplierName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.EmitFactory); sb.Append("\",");
                        sb.Append('"'); sb.Append((one.BillStatus == null || one.BillStatus == 0) ? "待退回" : "已退回"); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;

                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 导出财务数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportInvoiceInfoToXls(string filePath, List<XMInvoiceInfo> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("项目", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("发票编号", "nvarchar(50)");
                tableDefinition.Add("发票类型", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "nvarchar(50)");
                tableDefinition.Add("税号", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(100)");
                tableDefinition.Add("电话", "nvarchar(50)");
                tableDefinition.Add("开户行", "nvarchar(50)");
                tableDefinition.Add("账号", "nvarchar(50)");
                tableDefinition.Add("发票状态", "nvarchar(50)");
                tableDefinition.Add("产品名称", "nvarchar(50)");
                tableDefinition.Add("单位", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("总价", "nvarchar(50)");
                tableDefinition.Add("是否废弃", "nvarchar(50)");
                tableDefinition.Add("是否开票", "nvarchar(255)");
                tableDefinition.Add("是否排单", "nvarchar(50)");
                tableDefinition.Add("是否发货", "nvarchar(50)");
                excelHelper.WriteTable("发票明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        var info = IoC.Resolve<IXMInvoiceInfoDetailService>().GetXMInvoiceInfoDetailListByInvoiceInfoID(one.ID);
                        if (info != null && info.Count > 0)
                        {
                            foreach (var parm in info)
                            {
                                string nicks = "";
                                string projectName = "";
                                StringBuilder sb = new StringBuilder();
                                sb.Append("INSERT INTO [发票明细表] (订单号,项目,店铺,发票编号,发票类型,发票抬头,税号,地址,电话,开户行,账号,发票状态,产品名称,单位,数量, 单价,总价,是否废弃,是否开票,是否排单,是否发货) VALUES (");
                                sb.Append('"'); sb.Append(one.OrderCode == null ? "" : one.OrderCode); sb.Append("\",");
                                if (one.OrderCode != null)
                                {
                                    var orderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderByOrderCode2(one.OrderCode);
                                    if (orderInfo != null && orderInfo.Count > 0)
                                    {
                                        var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(orderInfo[0].NickID.Value);
                                        if (nick != null)
                                        {
                                            nicks = nick.nick;
                                            projectName = nick.ProjectName;
                                        }
                                    }
                                }
                                sb.Append('"'); sb.Append(projectName); sb.Append("\",");
                                sb.Append('"'); sb.Append(nicks); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.InvoiceNo == null ? "" : one.InvoiceNo); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.InvoiceTypeName); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.InvoiceHeader == null ? "" : one.InvoiceHeader); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.DutyParagraph == null ? "" : one.DutyParagraph); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.Address == null ? "" : one.Address); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.Tel == null ? "" : one.Tel); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.BankAccount == null ? "" : one.BankAccount); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.AccountNumber == null ? "" : one.AccountNumber); sb.Append("\",");

                                string InvoiceStatus = "";
                                if (one.InvoiceStatus != null)
                                {
                                    var Info = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(233);
                                    foreach (var a in Info)
                                    {
                                        if (a.CodeID == one.InvoiceStatus)
                                        {
                                            InvoiceStatus = a.CodeName;
                                            break;
                                        }
                                    }
                                }
                                sb.Append('"'); sb.Append(InvoiceStatus); sb.Append("\",");
                                sb.Append('"'); sb.Append(parm.ProductName); sb.Append("\",");
                                sb.Append('"'); sb.Append(parm.ProductUnit); sb.Append("\",");
                                sb.Append('"'); sb.Append(parm.Count); sb.Append("\",");
                                sb.Append('"'); sb.Append(parm.UnitPrice); sb.Append("\",");
                                sb.Append('"'); sb.Append(parm.Amount); sb.Append("\",");
                                sb.Append('"'); sb.Append((one.IsScrap == null || !one.IsScrap.Value) ? "否" : "是"); sb.Append("\",");
                                sb.Append('"'); sb.Append((one.IsBilling == null || !one.IsBilling.Value) ? "否" : "是"); sb.Append("\",");
                                sb.Append('"'); sb.Append((one.IsSingleRow == null || !one.IsSingleRow.Value) ? "否" : "是"); sb.Append("\",");
                                sb.Append('"'); sb.Append(!one.IsDelivery ? "否" : "是"); sb.Append("\"");
                                sb.Append(")");
                                excelHelper.ExecuteCommand(sb.ToString());
                                zIndex++;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 电子发票数据导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportDzfpInfoToXls(string filePath, List<XMInvoiceInfo> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("平台", "nvarchar(50)");
                tableDefinition.Add("订单编号", "nvarchar(50)");
                tableDefinition.Add("付款时间", "nvarchar(50)");
                tableDefinition.Add("货物名称", "nvarchar(50)");
                tableDefinition.Add("型号", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("单位", "nvarchar(50)");
                tableDefinition.Add("总金额", "nvarchar(100)");
                tableDefinition.Add("税率", "nvarchar(50)");
                tableDefinition.Add("收货人", "nvarchar(50)");
                tableDefinition.Add("发票抬头", "nvarchar(50)");
                tableDefinition.Add("税号", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(50)");
                tableDefinition.Add("手机号码", "nvarchar(50)");
                tableDefinition.Add("邮箱地址", "nvarchar(50)");
                tableDefinition.Add("普通发票红票对应正数发票代码", "nvarchar(50)");
                tableDefinition.Add("普通发票红票对应正数发票号码", "nvarchar(50)");
                tableDefinition.Add("税收分类编码", "nvarchar(50)");
                tableDefinition.Add("是否享受税收优惠政策", "nvarchar(255)");
                tableDefinition.Add("享受税收优惠政策内容", "nvarchar(50)");
                excelHelper.WriteTable("电子发票明细表", tableDefinition);
                //序号
                int zIndex = 1;

                var CodeList = IoC.Resolve<CodeService>().GetCodeListInfoByCodeTypeID(187);

                foreach (var item in list)
                {
                    var XMInvoiceInfoDetail = IoC.Resolve<XMInvoiceInfoDetailService>().GetXMInvoiceInfoDetailListByInvoiceInfoID(item.ID);
                    if (XMInvoiceInfoDetail.Count <= 0)
                    {
                        throw new Exception("订单号："+ item.OrderCode + "发票详情不存在！");
                    }

                    var OrderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderByOrderCode(item.OrderCode);
                    if (OrderInfo == null)
                    {
                        throw new Exception("订单号：" + item.OrderCode + " 不存在！");
                    }

                    foreach (var entity in XMInvoiceInfoDetail)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [电子发票明细表] (平台,订单编号,付款时间,货物名称,型号,数量,单位,总金额,税率,收货人,发票抬头,税号,备注,手机号码,邮箱地址, 普通发票红票对应正数发票代码,普通发票红票对应正数发票号码,税收分类编码,是否享受税收优惠政策,享受税收优惠政策内容) VALUES (");
                        sb.Append('"'); sb.Append(OrderInfo.PlatformName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.OrderCode == null ? "" : item.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfo.PayDate == null ? "" : ((DateTime)OrderInfo.PayDate).ToString("yyyy/M/d HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(string.IsNullOrEmpty(entity.ProductName) ? "" : entity.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(string.IsNullOrEmpty(entity.Specifications) ? "" : entity.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(entity.Count==null ? "" : entity.Count.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(string.IsNullOrEmpty(entity.ProductUnit) ? "" : entity.ProductUnit); sb.Append("\",");
                        sb.Append('"'); sb.Append(entity.Amount == null ? "" : entity.Amount.ToString()); sb.Append("\",");
                        //税率
                        sb.Append('"'); sb.Append("0.13"); sb.Append("\",");

                        sb.Append('"'); sb.Append(string.IsNullOrEmpty(OrderInfo.FullName) ? "" : OrderInfo.FullName); sb.Append("\",");
                        //没有勾选公司
                        if(item.InvoiceType==719&&string.IsNullOrEmpty(item.DutyParagraph))
                        {
                            sb.Append('"'); sb.Append(string.IsNullOrEmpty(item.InvoiceHeader) ? "" : item.InvoiceHeader); sb.Append("\",");
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(string.IsNullOrEmpty(item.InvoiceHeader) ? "" : item.InvoiceHeader); sb.Append("\",");
                            sb.Append('"'); sb.Append(string.IsNullOrEmpty(item.DutyParagraph)?"": item.DutyParagraph); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(OrderInfo.PlatformName+item.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(string.IsNullOrEmpty(OrderInfo.Mobile)?"": OrderInfo.Mobile); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");

                        bool flag = false;

                        foreach(var CodeEntity in CodeList)
                        {
                            if(entity.ProductName.Contains(CodeEntity.CodeName))
                            {
                                flag = true;
                                int length = CodeEntity.CodeName.Length;
                                string ProductTypeName = entity.ProductName.Substring(length, entity.ProductName.Length - length);
                                var CodeLists = IoC.Resolve<CodeService>().GetCodeListInfoByCodeTypeIDAndCodeName(188, ProductTypeName);
                                if(CodeLists.Count>0)
                                {
                                    sb.Append('"'); sb.Append(CodeLists[0].CodeNO); sb.Append("\",");
                                }
                                else
                                {
                                    sb.Append('"'); sb.Append(""); sb.Append("\",");
                                }
                                break;
                            }
                        }

                        if(!flag)
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append("0"); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }

                }
            }
        }

        /// <summary>
        /// 入库单信息导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void StorageInfoToXls(string filePath, List<XMStorage> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("入库单号", "nvarchar(50)");
                tableDefinition.Add("采购单号", "nvarchar(50)");
                tableDefinition.Add("所属仓库", "nvarchar(50)");
                tableDefinition.Add("供应商", "nvarchar(50)");
                tableDefinition.Add("金额", "nvarchar(50)");
                tableDefinition.Add("业务员", "nvarchar(50)");
                tableDefinition.Add("业务时间", "nvarchar(50)");
                tableDefinition.Add("录单人", "nvarchar(50)");
                tableDefinition.Add("审核状态", "nvarchar(50)");
                tableDefinition.Add("状态", "nvarchar(50)");
                excelHelper.WriteTable("采购入库明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [采购入库明细表] (入库单号,采购单号,所属仓库,供应商, 金额, 业务员, 业务时间, 录单人, 审核状态, 状态) VALUES (");
                        sb.Append('"'); sb.Append(one.Ref == null ? "" : one.Ref); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PurChaseNumber == null ? "" : one.PurChaseNumber); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.WareHouseName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.SuppliersName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductsMoney == null ? 0 : one.ProductsMoney); sb.Append("\",");
                        string bizUserName = "";
                        string createName = "";
                        string storageStatus = "";
                        if (one.BizUserId != null)
                        {
                            var customers = IoC.Resolve<CustomerInfoService>().GetCustomerInfoByID(one.BizUserId.Value);
                            if (customers != null)
                            {
                                bizUserName = customers.FullName;
                            }
                        }
                        if (one.CreateID != null)
                        {
                            var customers = IoC.Resolve<CustomerInfoService>().GetCustomerInfoByID(one.CreateID.Value);
                            if (customers != null)
                            {
                                createName = customers.FullName;
                            }
                        }
                        bool isAudit = one.IsAudit == null ? false : one.IsAudit.Value;
                        if (one.BillStatus == null || (one.BillStatus != null && one.BillStatus == 0))
                        {
                            storageStatus = "待入库";
                        }
                        if (one.BillStatus != null && one.BillStatus == 1000)
                        {
                            storageStatus = "已入库";
                        }
                        sb.Append('"'); sb.Append(bizUserName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.BizDt == null ? DateTime.Now.ToString() : one.BizDt.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(createName); sb.Append("\",");
                        sb.Append('"'); sb.Append(isAudit ? "审核通过" : "未审核"); sb.Append("\",");
                        sb.Append('"'); sb.Append(storageStatus); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;

                    }
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void MonthInventoryStatisticsInfoToXls(string filePath, List<XMInventoryInfoStatistics> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("年份", "nvarchar(50)");
                tableDefinition.Add("月份", "nvarchar(50)");
                tableDefinition.Add("商品编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("规格型号", "nvarchar(50)");
                tableDefinition.Add("所属仓库", "nvarchar(50)");
                tableDefinition.Add("期初数量", "nvarchar(50)");
                tableDefinition.Add("期初金额", "nvarchar(50)");
                tableDefinition.Add("采购入库数量", "nvarchar(50)");
                tableDefinition.Add("采购入库金额", "nvarchar(50)");
                tableDefinition.Add("出库数量", "nvarchar(50)");
                tableDefinition.Add("出库金额", "nvarchar(50)");
                tableDefinition.Add("库存数量", "nvarchar(50)");
                tableDefinition.Add("库存金额", "nvarchar(50)");
                excelHelper.WriteTable("月库存明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [月库存明细表] (年份,月份,商品编码,商品名称, 规格型号, 所属仓库, 期初数量, 期初金额, 采购入库数量, 采购入库金额, 出库数量,出库金额,库存数量,库存金额) VALUES (");
                        sb.Append('"'); sb.Append(one.Year == null ? "" : one.Year.Value.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Month == null ? "" : one.Month.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ManufacturersCode == null ? "" : one.ManufacturersCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductName == null ? "" : one.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Specifications == null ? "" : one.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.WareHouseName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.InitialCount == null ? "" : one.InitialCount.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.InitialMoney == null ? "" : one.InitialMoney.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.StorageCount == null ? "" : one.StorageCount.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.StorageMoney == null ? "" : one.StorageMoney.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.DeliveryCount == null ? "" : one.DeliveryCount.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.DeliveryMoney == null ? "" : one.DeliveryMoney.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.InventoryCount == null ? "" : one.InventoryCount.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.InventoryMoney == null ? "" : one.InventoryMoney.ToString()); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// 导出京东自营应采购量统计表
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportJDPurchaseProposalToXls(string filePath, List<PuchaseStrategyInfo> list, List<string> WareHouseNameList, List<string> PlatformMerchantCodeList)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("供应商简码", "nvarchar(50)");
                tableDefinition.Add("账期", "nvarchar(50)");
                tableDefinition.Add("商品编号", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("商品规格", "nvarchar(50)");
                tableDefinition.Add("单价", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(50)");
                tableDefinition.Add("订单属性", "nvarchar(50)");
                tableDefinition.Add("返利属性", "nvarchar(50)");
                if (WareHouseNameList != null && WareHouseNameList.Count > 0)
                {
                    foreach (string cityName in WareHouseNameList)
                    {
                        string wfName = "";
                        int index = cityName.IndexOf("京东仓");
                        if (index >= 0)
                        {
                            wfName = cityName.Remove(index);
                        }
                        if (!string.IsNullOrEmpty(wfName))
                        {
                            tableDefinition.Add(wfName, "nvarchar(50)");
                        }
                    }
                }
                excelHelper.WriteTable("京东全国出库表", tableDefinition);

                if (PlatformMerchantCodeList != null && PlatformMerchantCodeList.Count > 0)
                {
                    foreach (var one in PlatformMerchantCodeList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [京东全国出库表] (供应商简码,账期,商品编号, 商品名称,商品规格, 单价, 备注, 订单属性, 返利属性");
                        if (WareHouseNameList != null && WareHouseNameList.Count > 0)
                        {
                            foreach (string cityName in WareHouseNameList)
                            {
                                string wfName = "";
                                int index = cityName.IndexOf("京东仓");
                                if (index >= 0)
                                {
                                    wfName = cityName.Remove(index);
                                }
                                if (!string.IsNullOrEmpty(wfName))
                                {
                                    sb.Append(",");
                                    sb.Append(wfName);
                                }
                            }
                        }
                        sb.Append(") VALUES (");
                        sb.Append('"'); sb.Append("hozest"); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(one); sb.Append("\",");
                        string productName = "";
                        string specifications = "";
                        var products = IoC.Resolve<XMProductService>().getXMProductByManufacturersCode(one);
                        if (products != null)
                        {
                            productName = products.ProductName;
                            specifications = products.Specifications;
                        }
                        sb.Append('"'); sb.Append(productName); sb.Append("\",");
                        sb.Append('"'); sb.Append(specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        if (WareHouseNameList != null && WareHouseNameList.Count > 0)
                        {
                            for (int i = 0; i <= WareHouseNameList.Count - 1; i++)
                            {
                                string wfName = "";
                                int index = WareHouseNameList[i].IndexOf("京东仓");
                                if (index >= 0)
                                {
                                    wfName = WareHouseNameList[i].Remove(index);
                                }
                                if (!string.IsNullOrEmpty(wfName))
                                {
                                    int count = 0;
                                    //处理除最后一个元素
                                    if (list != null && list.Count > 0)
                                    {
                                        foreach (PuchaseStrategyInfo parm in list)
                                        {
                                            if (one == parm.PlatformMerchantCode && WareHouseNameList[i] == parm.WfName)
                                            {
                                                var xmJDRealTimeInventory = IoC.Resolve<IXMJDRealTimeInventoryService>().GetXMJDRealTimeInventoryParm(parm.PlatformMerchantCode, parm.WfId);
                                                if (xmJDRealTimeInventory != null)
                                                {
                                                    count = parm.ForecastNumber.Value - xmJDRealTimeInventory.RealTimeInventory;     //实际应采购数量= 预测采购数量-京东实时库存
                                                }
                                                else
                                                {
                                                    count = parm.RealityNumber.Value;
                                                }
                                            }
                                        }
                                    }
                                    if (i == WareHouseNameList.Count - 1)    //最后一个
                                    {
                                        if (count > 0)
                                        {
                                            sb.Append('"'); sb.Append(count); sb.Append("\"");
                                        }
                                        else
                                        {
                                            sb.Append('"'); sb.Append(""); sb.Append("\"");
                                        }
                                    }
                                    else
                                    {
                                        if (count > 0)
                                        {
                                            sb.Append('"'); sb.Append(count); sb.Append("\",");
                                        }
                                        else
                                        {
                                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                                        }
                                    }
                                }
                            }
                        }
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 导出客服归属订单数据统计
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportCustomerSaleAnalysisToXls(string filePath, List<XMCustomerSaleAcountAnalysis> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "nvarchar(50)");
                tableDefinition.Add("客服小组", "nvarchar(50)");
                tableDefinition.Add("姓名", "nvarchar(50)");
                tableDefinition.Add("成交量", "nvarchar(50)");
                tableDefinition.Add("成交金额", "nvarchar(50)");
                excelHelper.WriteTable("客服销售额明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [客服销售额明细表] (序号,客服小组,姓名, 成交量, 成交金额) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Group); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Name); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.DealCount); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.DealMoney); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportAlipaymentDataToXls(string filePath, List<XMAlipaymentAccount> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "nvarchar(50)");
                tableDefinition.Add("项目", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("厂家编码", "nvarchar(50)");
                tableDefinition.Add("规格", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                excelHelper.WriteTable("支付宝订单产品明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [支付宝订单产品明细表] (序号,项目,店铺, 订单号, 商品名称, 厂家编码, 规格, 数量) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProjectName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.NickName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ManufacturersCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductNum); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportScalpingInfoToXls(string filePath, List<XMScalping> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "nvarchar(50)");
                tableDefinition.Add("刷单单号", "nvarchar(50)");
                tableDefinition.Add("平台", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("创单时间", "nvarchar(50)");
                tableDefinition.Add("旺旺号", "nvarchar(50)");
                tableDefinition.Add("商品", "nvarchar(50)");
                tableDefinition.Add("销售价", "nvarchar(50)");
                tableDefinition.Add("佣金", "nvarchar(50)");
                tableDefinition.Add("扣点", "nvarchar(50)");
                excelHelper.WriteTable("刷单表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [刷单表] (序号,刷单单号,平台, 店铺, 订单号, 创单时间, 旺旺号, 商品, 销售价, 佣金,扣点) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        if (one.ScalpingNo != null)
                        {
                            sb.Append('"'); sb.Append(one.ScalpingNo.ScalpingCode); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        if (one.PlatformTypeName != null)
                        {
                            sb.Append('"'); sb.Append(one.PlatformTypeName.CodeName); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        if (one.NickName != null)
                        {
                            sb.Append('"'); sb.Append(one.NickName.nick); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(one.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.OrderInfoCreateDate); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.WantID); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.SalePrice); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Fee); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Deduction); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;

                    }
                }
            }
        }

        /// <summary>
        /// 导出库存信息（进销存系统）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void InventoryInfoToXls(string filePath, List<XMInventoryInfo> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "nvarchar(50)");
                tableDefinition.Add("商品编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("规格型号", "nvarchar(50)");
                tableDefinition.Add("所在仓库", "nvarchar(50)");
                tableDefinition.Add("城市", "nvarchar(50)");
                tableDefinition.Add("库存数量", "nvarchar(50)");
                tableDefinition.Add("可订购数量", "nvarchar(50)");
                tableDefinition.Add("库存警戒值", "nvarchar(50)");
                tableDefinition.Add("销售状态", "nvarchar(50)");
                tableDefinition.Add("入仓量", "nvarchar(50)");
                excelHelper.WriteTable("库存明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (list != null && list.Count > 0)
                {
                    foreach (var one in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [库存明细表] (序号,商品编码,商品名称, 规格型号, 所在仓库, 城市, 库存数量, 可订购数量, 库存警戒值, 销售状态,入仓量) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PlatformMerchantCode == null ? "" : one.PlatformMerchantCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.WfName); sb.Append("\",");
                        sb.Append('"'); sb.Append(getCityName(one.WfId.ToString())); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.StockNumber == null ? 0 : one.StockNumber); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.CanOrderCount == null ? 0 : one.CanOrderCount); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.WarningValue == null ? 0 : one.WarningValue); sb.Append("\",");
                        string saleStatus = "";
                        if (one.SaleStatus != null)
                        {
                            switch (one.SaleStatus)
                            {
                                case 1000:
                                    saleStatus = "滞销";
                                    break;
                                case 1001:
                                    saleStatus = "脱销";
                                    break;
                                case 1002:
                                    saleStatus = "无销量无库存";
                                    break;
                            }
                        }
                        sb.Append('"'); sb.Append(saleStatus); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.CanStorageCount == null ? 0 : one.CanStorageCount); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// 根据仓库ID 查询所在城市
        /// </summary>
        /// <param name="wfID"></param>
        /// <returns></returns>
        public string getCityName(string wfID)
        {
            string cityName = "";
            var wareHourses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(int.Parse(wfID));
            if (wareHourses != null && wareHourses.CityId != null && wareHourses.CityId != "")
            {
                cityName = getCityNameByCityID(wareHourses.CityId);
            }
            return cityName;
        }

        /// <summary>
        /// 根据cityID  查询城市名称
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public string getCityNameByCityID(string cityID)
        {
            string cityName = "";
            string ProvinceId = "";
            if (cityID != "" && cityID.Length > 0)
            {
                ProvinceId = cityID.Substring(0, 6);
            }
            var Province = IoC.Resolve<XMWareHousesService>().GetProvinceByProvinceId(ProvinceId);
            if (Province != null && (Province.City == "北京" || Province.City == "上海" || Province.City == "重庆" || Province.City == "天津"))
            {
                cityName = Province.City;
            }
            else
            {
                if (cityID != "" && cityID.Length == 9)         //城市
                {
                    var info = IoC.Resolve<XMWareHousesService>().GetCityInfoByCityId(cityID, 3);
                    if (info != null)
                    {
                        cityName = info.City;
                    }
                }
                if (cityID != "" && cityID.Length == 12)      //县区
                {
                    var info = IoC.Resolve<XMWareHousesService>().GetCityInfoByCityId(cityID, 4);
                    if (info != null)
                    {
                        cityName = info.City;
                    }
                }
            }
            return cityName;
        }

        /// <summary>
        /// 导出每月销量明细    （进销存系统）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="saleDelvieryList"></param>
        public void ExportSaleDeliveryDetail(string filePath, List<XMSaleDelivery> saleDelvieryList)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("订单类型", "nvarchar(50)");
                tableDefinition.Add("店铺名称", "nvarchar(50)");
                tableDefinition.Add("旺旺号", "nvarchar(50)");
                tableDefinition.Add("商品编码", "nvarchar(50)");
                tableDefinition.Add("商品名称", "nvarchar(50)");
                tableDefinition.Add("规格型号", "nvarchar(50)");
                tableDefinition.Add("销售单号", "nvarchar(50)");
                tableDefinition.Add("客户名", "nvarchar(50)");
                tableDefinition.Add("客户电话", "nvarchar(50)");
                tableDefinition.Add("客户地址", "nvarchar(50)");
                tableDefinition.Add("销售数量", "nvarchar(50)");
                tableDefinition.Add("销售单价", "nvarchar(50)");
                tableDefinition.Add("销售金额", "nvarchar(50)");
                tableDefinition.Add("出库时间", "nvarchar(50)");
                tableDefinition.Add("支付方式", "nvarchar(50)");
                tableDefinition.Add("业务人", "nvarchar(255)");
                tableDefinition.Add("备注", "nvarchar(255)");
                excelHelper.WriteTable("销售明细表", tableDefinition);
                //序号
                int zIndex = 1;
                if (saleDelvieryList != null && saleDelvieryList.Count > 0)
                {
                    foreach (var one in saleDelvieryList)
                    {
                        string orderType = "线下";    //订单类型
                        string nickName = "";
                        string wangwang = "";    //旺旺号
                        string UserName = "";
                        string Tel = "";
                        string Address = "";
                        var saleDelvieryDetail = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsBySaleDeliveryID(one.Id);
                        var saleInfo = IoC.Resolve<IXMSaleInfoService>().GetXMSaleInfoById(one.SaleInfoId);
                        if (saleDelvieryDetail != null && saleDelvieryDetail.Count > 0)
                        {
                            foreach (XMSaleDeliveryProductDetails Info in saleDelvieryDetail)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("INSERT INTO [销售明细表] (订单类型,店铺名称,旺旺号,商品编码,商品名称, 规格型号, 销售单号, 客户名, 客户电话, 客户地址, 销售数量, 销售单价,销售金额, 出库时间, 支付方式,业务人,备注) VALUES (");
                                if (saleInfo == null)            //从线上订单生成的出库单
                                {
                                    if (one.OrderInfoID != 0)
                                    {
                                        string orderCode = one.SaleRef;
                                        if (!string.IsNullOrEmpty(orderCode))
                                        {
                                            var orderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderByOrderCode(orderCode);
                                            if (orderInfo != null)
                                            {
                                                orderType = "线上";
                                                nickName = orderInfo.NickName;
                                                wangwang = orderInfo.WantID;
                                                UserName = orderInfo.FullName;
                                                Tel = orderInfo.Mobile;
                                                Address = orderInfo.DeliveryAddress;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    UserName = saleInfo.CustomerName;
                                    Tel = saleInfo.Tel;
                                    Address = saleInfo.SaleAddress;
                                }
                                sb.Append('"'); sb.Append(orderType); sb.Append("\",");
                                sb.Append('"'); sb.Append(nickName); sb.Append("\",");
                                sb.Append('"'); sb.Append(wangwang); sb.Append("\",");
                                sb.Append('"'); sb.Append(Info.PlatformMerchantCode); sb.Append("\",");
                                sb.Append('"'); sb.Append(Info.ProductName == null ? "" : Info.ProductName); sb.Append("\",");
                                sb.Append('"'); sb.Append(Info.Specifications == null ? "" : Info.Specifications); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.SaleRef == null ? "" : one.SaleRef); sb.Append("\",");

                                sb.Append('"'); sb.Append(UserName); sb.Append("\",");
                                sb.Append('"'); sb.Append(Tel); sb.Append("\",");
                                sb.Append('"'); sb.Append(Address); sb.Append("\",");
                                sb.Append('"'); sb.Append(Info.SaleCount == null ? "" : Info.SaleCount.ToString()); sb.Append("\",");
                                sb.Append('"'); sb.Append(Info.ProductPrice == null ? "" : Info.ProductPrice.ToString()); sb.Append("\",");
                                sb.Append('"'); sb.Append(Info.ProductMoney == null ? "" : Info.ProductMoney.ToString()); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.UpdateDate == null ? "" : one.UpdateDate.ToString()); sb.Append("\",");
                                sb.Append('"'); sb.Append(one.PayType); sb.Append("\",");
                                if (one.BizUserId != null)
                                {
                                    var customer = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(one.BizUserId.Value);
                                    sb.Append('"'); sb.Append(customer == null ? "" : customer.FullName); sb.Append("\",");
                                }
                                sb.Append('"'); sb.Append(one.Remarks == null ? "" : one.Remarks); sb.Append("\"");
                                sb.Append(")");
                                excelHelper.ExecuteCommand(sb.ToString());
                                zIndex++;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导出资金流水
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="financialCapitalList"></param>
        public void ExportFinancialCapitalFlowToXls(string filePath, List<XMFinancialCapitalFlow> financialCapitalList)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "int");
                tableDefinition.Add("日期", "nvarchar(50)");
                tableDefinition.Add("收入支出", "nvarchar(50)");
                tableDefinition.Add("摘要", "nvarchar(50)");
                tableDefinition.Add("交款人报销人", "nvarchar(50)");
                tableDefinition.Add("收款类别", "nvarchar(50)");
                tableDefinition.Add("对应预算科目", "nvarchar(50)");
                tableDefinition.Add("部门", "nvarchar(50)");
                tableDefinition.Add("项目", "nvarchar(50)");
                tableDefinition.Add("金额", "nvarchar(50)");
                tableDefinition.Add("收款支付方式", "nvarchar(50)");
                tableDefinition.Add("备注", "nvarchar(255)");
                excelHelper.WriteTable("资金流水表", tableDefinition);
                //序号
                int zIndex = 1;
                if (financialCapitalList != null && financialCapitalList.Count > 0)
                {
                    foreach (var one in financialCapitalList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [资金流水表] (序号,日期, 收入支出, 摘要, 交款人报销人, 收款类别, 对应预算科目, 部门, 项目,金额, 收款支付方式, 备注) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Date == null ? "" : one.Date.Value.ToString("yyyy-MM-dd")); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.IsIncome == null ? "" : one.IsIncome == true ? "收入" : "支出"); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Abstract == null ? "" : one.Abstract); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.AssociatedPerson == null ? "" : one.AssociatedPerson); sb.Append("\",");

                        sb.Append('"'); sb.Append(one.ReceivablesTypeName == null ? "" : one.ReceivablesTypeName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.BudgetTypeName == null ? "" : one.BudgetTypeName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.DepartmentIDName == null ? "" : one.DepartmentIDName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.ProjectName == null ? "" : one.ProjectName); sb.Append("\",");

                        sb.Append('"'); sb.Append(one.Amount == null ? "" : one.Amount.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.PaymentCollectionTypeName == null ? "" : one.PaymentCollectionTypeName); sb.Append("\",");
                        sb.Append('"'); sb.Append(one.Remark == null ? "" : one.Remark.ToString()); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        public void ExportQuestionDetailToXls(string filePath, List<QuestionDetailed_Result> questionDetailedList)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("序号", "int");
                tableDefinition.Add("平台", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("用户ID", "nvarchar(50)");
                tableDefinition.Add("联系人", "nvarchar(50)");
                tableDefinition.Add("电话", "nvarchar(50)");
                tableDefinition.Add("地址", "nvarchar(255)");
                tableDefinition.Add("产品", "nvarchar(50)");
                tableDefinition.Add("件数", "nvarchar(50)");
                tableDefinition.Add("金额", "nvarchar(255)");
                tableDefinition.Add("问题类型", "nvarchar(50)");
                tableDefinition.Add("问题等级", "nvarchar(50)");
                tableDefinition.Add("是否要退货", "nvarchar(50)");
                tableDefinition.Add("具体原因", "nvarchar(255)");
                tableDefinition.Add("处理人", "nvarchar(50)");
                tableDefinition.Add("最近联系时间", "nvarchar(50)");
                tableDefinition.Add("联系内容", "nvarchar(255)");
                tableDefinition.Add("处理结果", "nvarchar(255)");
                tableDefinition.Add("处理结果说明", "nvarchar(255)");
                excelHelper.WriteTable("问题处理", tableDefinition);
                //序号
                int zIndex = 1;
                foreach (var questionDetailed in questionDetailedList)
                {
                    StringBuilder sb = new StringBuilder();

                    var xMCommunicationRecordList = IoC.Resolve<IXMCommunicationRecordService>().GetXMCommunicationRecordListByQuestionID(questionDetailed.ID);
                    //产品信息
                    var OrderProductDetails = IoC.Resolve<IXMOrderInfoProductDetailsService>().GetProductNameNum(questionDetailed.OredrInfoID);
                    sb.Append("INSERT INTO [问题处理] (序号,平台, 店铺, 订单号, 用户ID,联系人,电话,地址,产品, 件数, 金额, 问题类型, 问题等级, 是否要退货,具体原因,处理人,最近联系时间,联系内容,处理结果,处理结果说明) VALUES (");
                    sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.PlatformType == null ? "" : questionDetailed.PlatformType); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.NickName == null ? "" : questionDetailed.NickName); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.OrderNO == null ? "" : questionDetailed.OrderNO); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.Buyer == null ? "" : questionDetailed.Buyer); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.FullName == null ? "" : questionDetailed.FullName); sb.Append("\",");
                    #region 联系电话
                    string TM = "";
                    if (questionDetailed.Mobile != null && questionDetailed.Mobile != "" && questionDetailed.Tel != null && questionDetailed.Tel != "")
                    {
                        TM = questionDetailed.Mobile + "," + questionDetailed.Tel;

                        sb.Append('"'); sb.Append(TM); sb.Append("\",");
                    }
                    else if (questionDetailed.Mobile != null && questionDetailed.Mobile != "" && (questionDetailed.Tel == null || questionDetailed.Tel == ""))
                    {
                        TM = questionDetailed.Mobile;
                        sb.Append('"'); sb.Append(TM); sb.Append("\",");
                    }
                    else if ((questionDetailed.Mobile == null || questionDetailed.Mobile == "") && questionDetailed.Tel != null && questionDetailed.Tel != "")
                    {
                        TM = questionDetailed.Tel;
                        sb.Append('"'); sb.Append(TM); sb.Append("\",");
                    }
                    else
                    {
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                    }
                    #endregion
                    sb.Append('"'); sb.Append(questionDetailed.DeliveryAddress == null ? "" : questionDetailed.DeliveryAddress); sb.Append("\",");

                    //产品、数量 
                    if (OrderProductDetails.Count > 0)
                    {
                        //产品名称
                        //List<string> OrderProductName = OrderProductDetails.Select(p => p.ProductName).ToList();
                        //string ProductNameStr = string.Join(",", OrderProductName);
                        string ProductNameStr = "";
                        int OrderProductSum = 0;
                        foreach (SimpleInfoProductDetail info in OrderProductDetails)
                        {
                            if (info.ProductName != null && info.ProductName != "")
                            {
                                ProductNameStr += info.ProductName + ",";
                            }
                            if (info.ProductNum != null)
                            {
                                OrderProductSum = OrderProductSum + info.ProductNum.Value;
                            }
                        }
                        if (ProductNameStr != "" && ProductNameStr.Length > 0)
                        {
                            sb.Append('"'); sb.Append(ProductNameStr.Substring(0, ProductNameStr.Length - 1)); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }
                        //数量
                        sb.Append('"'); sb.Append(OrderProductSum); sb.Append("\",");
                    }
                    else
                    {
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                    }

                    sb.Append('"'); sb.Append(questionDetailed.OrderPrice == null ? "" : questionDetailed.OrderPrice.Value.ToString()); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.QuestionCategoryName); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.QuestionLevel == null ? "" : questionDetailed.QuestionLevelName.CodeName); sb.Append("\",");

                    string vl = "";
                    if (questionDetailed.IsReturns != null)
                    {
                        vl = questionDetailed.IsReturns.Value ? "是" : "否";
                    }
                    sb.Append('"'); sb.Append(vl); sb.Append("\",");
                    if (questionDetailed.Description != null)
                    {
                        if (questionDetailed.Description.Length > 255)
                        {
                            questionDetailed.Description.Substring(0, 250);
                        }
                    }
                    sb.Append('"'); sb.Append(questionDetailed.Description == null ? "" : questionDetailed.Description); sb.Append("\",");
                    //处理人 
                    sb.Append('"'); sb.Append(questionDetailed.SrvAfterCustomer == null ? "" : questionDetailed.SrvAfterCustomer.FullName); sb.Append("\",");
                    //最近联系时间,联系内容

                    if (xMCommunicationRecordList.Count > 0)
                    {
                        sb.Append('"'); sb.Append(xMCommunicationRecordList[0].ContactTime.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        if (xMCommunicationRecordList[0].ContactContent.Length > 250)
                        {
                            xMCommunicationRecordList[0].ContactContent = xMCommunicationRecordList[0].ContactContent.Substring(0, 240);
                        }
                        sb.Append('"'); sb.Append(xMCommunicationRecordList[0].ContactContent); sb.Append("\",");
                    }
                    else
                    {
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                        sb.Append('"'); sb.Append(""); sb.Append("\",");
                    }
                    //处理结果
                    if (questionDetailed.ResultMsg != null)
                    {
                        if (questionDetailed.ResultMsg.Length > 255)
                        {
                            questionDetailed.ResultMsg.Substring(0, 250);
                        }
                    }
                    sb.Append('"'); sb.Append(questionDetailed.ResultsType == null ? "" : questionDetailed.ResultsType.CodeName); sb.Append("\",");
                    sb.Append('"'); sb.Append(questionDetailed.ResultMsg == null ? "" : questionDetailed.ResultMsg); sb.Append("\"");
                    sb.Append(")");
                    excelHelper.ExecuteCommand(sb.ToString());

                    zIndex++;
                }
            }
        }

        /// <summary>
        /// 导出销售明细
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="xmOrderInfoList">订单明细</param>
        /// <param name="OrderInfoSalesDetailsList">根据订单号去掉重复订单集合</param>
        /// <param name="ProductSalesDetailsList">产品统计</param>
        /// <param name="XMCashBackApplicationDetailsList">返现集合</param>
        /// <param name="XMScalpingDetailsList">刷单记录集合</param>
        /// <param name="BackProductDetails">退货商品集合</param>
        public void ExportOrderInfoSalesDetailsXls(string filePath, List<OrderInfoSalesDetails> xmOrderInfoList, List<OrderInfoSalesDetails> OrderInfoSalesDetailsList, List<OrderInfoSalesDetails> ProductSalesDetailsList, List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList, List<OrderInfoSalesDetails> XMScalpingDetailsList, List<OrderInfoSalesDetails> XMOrderInfoAndPremiumsDetailsList, List<XMApplication> xmApplication, List<XMBackProductDetails> BackProductDetails)
        {
            #region 订单明细
            if (xmOrderInfoList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("项目名称", "nvarchar(50)");
                    tableDefinition.Add("平台名称", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("网名", "nvarchar(50)");
                    tableDefinition.Add("创单时间", "nvarchar(50)");
                    tableDefinition.Add("付款时间", "nvarchar(50)");
                    tableDefinition.Add("发货时间", "nvarchar(50)");
                    tableDefinition.Add("交易完成时间", "nvarchar(50)");
                    tableDefinition.Add("姓名", "nvarchar(50)");
                    tableDefinition.Add("手机", "nvarchar(50)");
                    tableDefinition.Add("电话", "nvarchar(50)");
                    tableDefinition.Add("运费", "numeric(18, 2)");
                    tableDefinition.Add("应收金额", "numeric(18, 2)");
                    tableDefinition.Add("已支付金额", "numeric(18, 2)");
                    excelHelper.WriteTable("订单明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in xmOrderInfoList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [订单明细] (序号, 项目名称, 平台名称, 店铺名称, 订单号, 网名, 创单时间, 付款时间, 发货时间, 交易完成时间, 姓名, 手机, 电话, 运费, 应收金额, 已支付金额) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.ProjectName == null ? "" : OrderInfoSalesDetails.ProjectName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.PlatformTypeName == null ? "" : OrderInfoSalesDetails.PlatformTypeName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.OrderCode == null ? "" : OrderInfoSalesDetails.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.WantID == null ? "" : OrderInfoSalesDetails.WantID); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.OrderInfoCreateDate == null ? "" : OrderInfoSalesDetails.OrderInfoCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.PayDate == null ? "" : OrderInfoSalesDetails.PayDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.DeliveryTime == null ? "" : OrderInfoSalesDetails.DeliveryTime.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.CompletionTime == null ? "" : OrderInfoSalesDetails.CompletionTime.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.FullName == null ? "" : OrderInfoSalesDetails.FullName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.Mobile == null ? "" : OrderInfoSalesDetails.Mobile); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.Tel == null ? "" : OrderInfoSalesDetails.Tel); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.DistributePrice == null ? 0 : OrderInfoSalesDetails.DistributePrice.Value); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.ReceivablePrice == null ? 0 : OrderInfoSalesDetails.ReceivablePrice.Value); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.PayPrice == null ? 0 : OrderInfoSalesDetails.PayPrice.Value); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 产品明细
            if (OrderInfoSalesDetailsList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("店铺", "nvarchar(50)");
                    tableDefinition.Add("创单时间", "nvarchar(50)");
                    tableDefinition.Add("付款时间", "nvarchar(50)");
                    tableDefinition.Add("发货时间", "nvarchar(50)");
                    tableDefinition.Add("交易完成时间", "nvarchar(50)");
                    tableDefinition.Add("平台名称", "nvarchar(50)");
                    tableDefinition.Add("订单编号", "nvarchar(50)");
                    tableDefinition.Add("品牌", "nvarchar(50)");
                    tableDefinition.Add("产品名称", "nvarchar(50)");
                    tableDefinition.Add("厂家编码", "nvarchar(50)");
                    tableDefinition.Add("尺寸", "nvarchar(50)");
                    tableDefinition.Add("进货单价", "numeric(18, 4)");
                    tableDefinition.Add("订单数量", "numeric(18, 0)");
                    tableDefinition.Add("进货总额", "numeric(18, 4)");
                    tableDefinition.Add("已支付金额", "numeric(18, 4)");
                    excelHelper.WriteTable("产品明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in OrderInfoSalesDetailsList)
                    {
                        StringBuilder sb = new StringBuilder();
                        decimal factoryPrice = 0;
                        int productNum = 0;
                        sb.Append("INSERT INTO [产品明细] (序号,店铺, 创单时间, 付款时间, 发货时间, 交易完成时间, 平台名称, 订单编号, 品牌, 产品名称, 厂家编码, 尺寸,进货单价, 订单数量, 进货总额, 已支付金额) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.OrderInfoCreateDate == null ? "" : OrderInfoSalesDetails.OrderInfoCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.PayDate == null ? "" : OrderInfoSalesDetails.PayDate.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.DeliveryTime == null ? "" : OrderInfoSalesDetails.DeliveryTime.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.CompletionTime == null ? "" : OrderInfoSalesDetails.CompletionTime.Value.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.PlatformTypeName == null ? "" : OrderInfoSalesDetails.PlatformTypeName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.OrderCode == null ? "" : OrderInfoSalesDetails.OrderCode); sb.Append("\",");

                        string ManufacturersCode = OrderInfoSalesDetails.ManufacturersCode == null ? "" : OrderInfoSalesDetails.ManufacturersCode;
                        var Product = IoC.Resolve<IXMProductService>().getXMProductByManufacturersCode(ManufacturersCode);
                        if (Product != null)
                        {
                            sb.Append('"'); sb.Append(Product.BrandTypeCodeName); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.ProductName == null ? "" : OrderInfoSalesDetails.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(ManufacturersCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.Specifications == null ? "" : OrderInfoSalesDetails.Specifications); sb.Append("\",");
                        if (OrderInfoSalesDetails.FactoryPrice == null)
                        {
                            factoryPrice = 0;
                        }
                        else
                        {
                            factoryPrice = OrderInfoSalesDetails.FactoryPrice.Value;
                        }
                        if (OrderInfoSalesDetails.ProductNum == null)
                        {
                            productNum = 0;
                        }
                        else
                        {
                            productNum = OrderInfoSalesDetails.ProductNum.Value;
                        }
                        if (productNum > 0)
                        {
                            sb.Append('"'); sb.Append(factoryPrice / productNum); sb.Append("\",");
                        }
                        else 
                        {
                            sb.Append('"'); sb.Append('0'); sb.Append("\",");
                        }
                        sb.Append('"'); sb.Append(productNum); sb.Append("\",");
                        if (productNum > 0)
                        {
                            sb.Append('"'); sb.Append((factoryPrice / productNum) * productNum); sb.Append("\",");
                        }
                        else
                        {
                            sb.Append('"'); sb.Append('0'); sb.Append("\",");
                        }
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.SalesPrice == null ? 0 : OrderInfoSalesDetails.SalesPrice.Value); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 产品统计
            if (ProductSalesDetailsList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("产品名称", "nvarchar(50)");
                    tableDefinition.Add("平均单价", "nvarchar(50)");
                    tableDefinition.Add("订购数量", "numeric(18, 0)");
                    tableDefinition.Add("出厂总价", "numeric(18, 4)");
                    excelHelper.WriteTable("产品统计", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in ProductSalesDetailsList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [产品统计] (序号,产品名称, 平均单价,订购数量,出厂总价) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.ProductName == null ? "" : OrderInfoSalesDetails.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.AvgFactoryPrice == null ? 0 : OrderInfoSalesDetails.AvgFactoryPrice.Value); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.ProductNum == null ? 0 : OrderInfoSalesDetails.ProductNum.Value); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoSalesDetails.PayPrice == null ? 0 : OrderInfoSalesDetails.PayPrice.Value); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 返现明细
            if (XMCashBackApplicationDetailsList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("项目", "nvarchar(50)");
                    tableDefinition.Add("店铺", "nvarchar(50)");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("旺旺号", "nvarchar(50)");
                    tableDefinition.Add("姓名", "nvarchar(50)");
                    tableDefinition.Add("收款账号", "nvarchar(200)");
                    tableDefinition.Add("返现金额", "numeric(18, 4)");
                    excelHelper.WriteTable("返现明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var CashBackApplicationDetails in XMCashBackApplicationDetailsList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [返现明细] (序号,项目,店铺,订单号, 旺旺号,姓名,收款账号, 返现金额) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.ProjectName == null ? "" : CashBackApplicationDetails.ProjectName); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.NickName == null ? "" : CashBackApplicationDetails.NickName); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.OrderCode == null ? "" : CashBackApplicationDetails.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.XMCashBackApplicationWantNo == null ? "" : CashBackApplicationDetails.XMCashBackApplicationWantNo); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.BuyerName == null ? "" : CashBackApplicationDetails.BuyerName); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.BuyerAlipayNo == null ? "" : CashBackApplicationDetails.BuyerAlipayNo); sb.Append("\",");
                        sb.Append('"'); sb.Append(CashBackApplicationDetails.CashBackMoney == null ? 0 : CashBackApplicationDetails.CashBackMoney.Value); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 刷单明细
            if (XMScalpingDetailsList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("旺旺号", "nvarchar(50)");
                    tableDefinition.Add("商品名称", "nvarchar(50)");
                    tableDefinition.Add("销售价", "numeric(18, 4)");
                    tableDefinition.Add("佣金", "numeric(18, 4)");
                    tableDefinition.Add("扣点", "numeric(18, 4)");
                    excelHelper.WriteTable("刷单明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var ScalpingDetails in XMScalpingDetailsList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [刷单明细] (序号,订单号, 旺旺号,商品名称,销售价, 佣金,扣点) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(ScalpingDetails.OrderCode == null ? "" : ScalpingDetails.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(ScalpingDetails.WantID == null ? "" : ScalpingDetails.WantID); sb.Append("\",");
                        sb.Append('"'); sb.Append(ScalpingDetails.ProductName == null ? "" : ScalpingDetails.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(ScalpingDetails.SalesPrice == null ? 0 : ScalpingDetails.SalesPrice.Value); sb.Append("\",");
                        sb.Append('"'); sb.Append(ScalpingDetails.Fee == null ? 0 : ScalpingDetails.Fee.Value); sb.Append("\",");
                        sb.Append('"'); sb.Append(ScalpingDetails.Deduction == null ? 0 : ScalpingDetails.Deduction.Value); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 赠品明细
            if (XMOrderInfoAndPremiumsDetailsList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("旺旺Id", "nvarchar(50)");
                    tableDefinition.Add("商品名称", "nvarchar(50)");
                    tableDefinition.Add("商品编码", "nvarchar(50)");
                    tableDefinition.Add("单价", "numeric(18, 4)");
                    tableDefinition.Add("数量", "numeric(18, 0)");
                    tableDefinition.Add("总金额", "numeric(18, 4)");
                    excelHelper.WriteTable("赠品明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoAndPremiums in XMOrderInfoAndPremiumsDetailsList)
                    {
                        StringBuilder sb = new StringBuilder();
                        decimal price = 0;
                        int productNum = 0;
                        sb.Append("INSERT INTO [赠品明细] (序号,订单号, 旺旺Id,商品名称,商品编码, 单价,数量,总金额) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.OrderCode == null ? "" : OrderInfoAndPremiums.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.WantID == null ? "" : OrderInfoAndPremiums.WantID); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.ProductName == null ? "" : OrderInfoAndPremiums.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.PlatformMerchantCode == null ? "" : OrderInfoAndPremiums.PlatformMerchantCode); sb.Append("\",");
                        if (OrderInfoAndPremiums.FactoryPrice == null)
                        {
                            price = 0;
                        }
                        else
                        {
                            price = OrderInfoAndPremiums.FactoryPrice.Value;
                        }
                        sb.Append('"'); sb.Append(price); sb.Append("\",");
                        if (OrderInfoAndPremiums.ProductNum == null)
                        {
                            productNum = 0;
                        }
                        else
                        {
                            productNum = OrderInfoAndPremiums.ProductNum.Value;
                        }
                        sb.Append('"'); sb.Append(productNum); sb.Append("\",");
                        sb.Append('"'); sb.Append(price * productNum); sb.Append("\"");

                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 退款金额明细
            if (xmApplication.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("申请单号", "nvarchar(50)");
                    tableDefinition.Add("申请时间", "nvarchar(50)");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺", "nvarchar(50)");
                    tableDefinition.Add("申请类型", "nvarchar(50)");
                    tableDefinition.Add("退款金额", "nvarchar(50)");
                    tableDefinition.Add("补价订单号", "nvarchar(50)");
                    tableDefinition.Add("入仓时间", "nvarchar(50)");
                    tableDefinition.Add("完成时间", "nvarchar(50)");
                    excelHelper.WriteTable("退款金额明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoAndPremiums in xmApplication)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [退款金额明细] (序号,申请单号, 申请时间,订单号,平台, 店铺,申请类型,退款金额,补价订单号,入仓时间,完成时间) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.ApplicationNo == null ? "" : OrderInfoAndPremiums.ApplicationNo); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.CreateDate == null ? "" : OrderInfoAndPremiums.CreateDate.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.OrderCode == null ? "" : OrderInfoAndPremiums.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.PlatformType == null ? "" : OrderInfoAndPremiums.PlatformType); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.NickName == null ? "" : OrderInfoAndPremiums.NickName); sb.Append("\",");
                        var typecon = "";
                        if (OrderInfoAndPremiums.ApplicationType == 4)
                        {
                            typecon = "未发货退款";
                        }
                        else if (OrderInfoAndPremiums.ApplicationType == 5)
                        {
                            typecon = "先退货后退款";
                        }
                        else if (OrderInfoAndPremiums.ApplicationType == 6)
                        {
                            typecon = "换货";
                        }
                        else if (OrderInfoAndPremiums.ApplicationType == 9)
                        {
                            typecon = "售后";
                        }
                        else if (OrderInfoAndPremiums.ApplicationType == 10)
                        {
                            typecon = "售中";
                        }
                        else if (OrderInfoAndPremiums.ApplicationType == 8)
                        {
                            typecon = "退运费";
                        }
                        else if (OrderInfoAndPremiums.ApplicationType == 7)
                        {
                            typecon = "先退款后退货";
                        }
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.ApplicationType == null ? "" : typecon); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.Amount == 0 ? 0 : OrderInfoAndPremiums.Amount); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.ReservepriceOrder == null ? "" : OrderInfoAndPremiums.ReservepriceOrder); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.ReturnTime == null ? "" : OrderInfoAndPremiums.ReturnTime.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(OrderInfoAndPremiums.FinishTime == null ? "" : OrderInfoAndPremiums.FinishTime.ToString()); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 退货明细
            if (BackProductDetails.Count() > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("申请单号", "nvarchar(50)");
                    tableDefinition.Add("申请类型", "nvarchar(50)");
                    tableDefinition.Add("申请时间", "nvarchar(50)");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺", "nvarchar(50)");
                    tableDefinition.Add("退款金额", "nvarchar(50)");
                    tableDefinition.Add("商品编码", "nvarchar(50)");
                    tableDefinition.Add("厂家编码", "nvarchar(50)");
                    tableDefinition.Add("商品名称", "nvarchar(50)");
                    tableDefinition.Add("尺寸", "nvarchar(50)");
                    tableDefinition.Add("退换货数量", "int");
                    tableDefinition.Add("成本", "numeric(18, 2)");
                    excelHelper.WriteTable("退货明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var BackProduct in BackProductDetails)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [退货明细] (序号,申请单号,申请类型,申请时间,订单号,平台,店铺,退款金额,商品编码,厂家编码,商品名称,尺寸,退换货数量,成本) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.ApplicationNo == null ? "" : BackProduct.ApplicationNo); sb.Append("\",");
                        var typecon = "";
                        if (BackProduct.ApplicationType == 4)
                        {
                            typecon = "未发货退款";
                        }
                        else if (BackProduct.ApplicationType == 5)
                        {
                            typecon = "先退货后退款";
                        }
                        else if (BackProduct.ApplicationType == 6)
                        {
                            typecon = "换货";
                        }
                        else if (BackProduct.ApplicationType == 9)
                        {
                            typecon = "售后";
                        }
                        else if (BackProduct.ApplicationType == 10)
                        {
                            typecon = "售中";
                        }
                        else if (BackProduct.ApplicationType == 8)
                        {
                            typecon = "退运费";
                        }
                        else if (BackProduct.ApplicationType == 7)
                        {
                            typecon = "先退款后退货";
                        }
                        sb.Append('"'); sb.Append(BackProduct.ApplicationType == null ? "" : typecon); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.CreateDate == null ? "" : BackProduct.CreateDate.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.OrderCode == null ? "" : BackProduct.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.PlatformType == null ? "" : BackProduct.PlatformType); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.NickName == null ? "" : BackProduct.NickName); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.Amount == 0 ? 0 : BackProduct.Amount); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.PlatformMerchantCode == null ? "" : BackProduct.PlatformMerchantCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.ManufacturersCode == null ? "" : BackProduct.ManufacturersCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.ProductName == null ? "" : BackProduct.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.Specifications == null ? "" : BackProduct.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.ProductNum); sb.Append("\",");
                        sb.Append('"'); sb.Append(BackProduct.FactoryPrice == 0 ? 0 : BackProduct.FactoryPrice); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出售前客服薪资
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public void ExportPreServiceSalaryXls(string filePath, List<XMPreSalesSalary> ExportXMPreSalesSalaryList)
        {
            #region 订单明细
            if (ExportXMPreSalesSalaryList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("级别", "nvarchar(50)");
                    tableDefinition.Add("旺旺号", "nvarchar(50)");
                    tableDefinition.Add("实际销售额", "nvarchar(50)");
                    tableDefinition.Add("总销售金额", "nvarchar(50)");
                    tableDefinition.Add("排名系数", "nvarchar(50)");
                    tableDefinition.Add("提成", "nvarchar(50)");
                    tableDefinition.Add("总销售提成", "nvarchar(50)");
                    tableDefinition.Add("底薪", "nvarchar(50)");
                    tableDefinition.Add("合计", "nvarchar(50)");
                    excelHelper.WriteTable("售前薪资表", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in ExportXMPreSalesSalaryList)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [售前薪资表] (序号, 组别, 客服, 级别, 旺旺号, 实际销售额, 总销售金额, 排名系数, 提成, 总销售提成, 底薪, 合计) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Group == null ? "" : OrderInfoSalesDetails.Group); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Name == null ? "" : OrderInfoSalesDetails.Name); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.RankName == null ? "" : OrderInfoSalesDetails.RankName); st.Append("\",");
                        if (OrderInfoSalesDetails.tabWangNoList.Count > 0)
                        {
                            for (int i = 0; i < OrderInfoSalesDetails.tabWangNoList.Count; i++)
                            {
                                StringBuilder sb = new StringBuilder();
                                if (i == 0)
                                {
                                    sb = new StringBuilder(st.ToString());
                                }
                                else
                                {
                                    sb = new StringBuilder("INSERT INTO [售前薪资表] (序号, 组别, 客服, 级别, 旺旺号, 实际销售额, 总销售金额, 排名系数, 提成, 总销售提成, 底薪, 合计) VALUES (\"\",\"\",\"\",\"\",");
                                }
                                sb.Append('"'); sb.Append(OrderInfoSalesDetails.tabWangNoList[i].WangNo == null ? "" : OrderInfoSalesDetails.tabWangNoList[i].WangNo); sb.Append("\",");
                                sb.Append('"'); sb.Append(OrderInfoSalesDetails.tabWangNoList[i].TotalMoney == null ? "" : OrderInfoSalesDetails.tabWangNoList[i].TotalMoney.ToString()); sb.Append("\",");
                                if (i == 0)//OrderInfoSalesDetails.tabWangNoList.Count - 1)
                                {
                                    sb.Append('"'); sb.Append(OrderInfoSalesDetails.TotalMoney == null ? "" : OrderInfoSalesDetails.TotalMoney.ToString()); sb.Append("\",");
                                }
                                else
                                {
                                    sb.Append('"'); sb.Append(""); sb.Append("\",");
                                }

                                sb.Append('"'); sb.Append(OrderInfoSalesDetails.tabWangNoList[i].RankCoefficient == null ? "" : ((float)(OrderInfoSalesDetails.tabWangNoList[i].RankCoefficient * 100)).ToString() + "%"); sb.Append("\",");
                                sb.Append('"'); sb.Append(OrderInfoSalesDetails.tabWangNoList[i].Commission == null ? "" : OrderInfoSalesDetails.tabWangNoList[i].Commission.ToString()); sb.Append("\",");
                                if (i == 0)//OrderInfoSalesDetails.tabWangNoList.Count - 1)
                                {
                                    sb.Append('"'); sb.Append(OrderInfoSalesDetails.TotalCommission == null ? "" : OrderInfoSalesDetails.TotalCommission.ToString()); sb.Append("\",");
                                }
                                else
                                {
                                    sb.Append('"'); sb.Append(""); sb.Append("\",");
                                }
                                if (i == 0)//OrderInfoSalesDetails.tabWangNoList.Count - 1)
                                {
                                    sb.Append('"'); sb.Append(OrderInfoSalesDetails.BasicSalary == null ? "" : OrderInfoSalesDetails.BasicSalary.ToString()); sb.Append("\",");
                                    sb.Append('"'); sb.Append(OrderInfoSalesDetails.Total == null ? 0 : OrderInfoSalesDetails.Total); sb.Append("\"");
                                }
                                else
                                {
                                    sb.Append('"'); sb.Append(""); sb.Append("\",");
                                    sb.Append('"'); sb.Append(""); sb.Append("\"");
                                }
                                sb.Append(")");
                                excelHelper.ExecuteCommand(sb.ToString());
                                //zIndex++;
                            }
                            zIndex++;
                        }
                        else
                        {
                            st.Append('"'); st.Append(""); st.Append("\",");
                            st.Append('"'); st.Append(""); st.Append("\",");
                            st.Append('"'); st.Append(""); st.Append("\",");
                            st.Append('"'); st.Append(""); st.Append("\",");
                            st.Append('"'); st.Append(""); st.Append("\",");
                            st.Append('"'); st.Append(""); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.BasicSalary == null ? "" : OrderInfoSalesDetails.BasicSalary.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.Total == null ? 0 : OrderInfoSalesDetails.Total); st.Append("\"");
                            st.Append(")");
                            excelHelper.ExecuteCommand(st.ToString());
                            zIndex++;
                        }
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 导出售后客服薪资
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public void ExportAfterSalesSalaryXls(string filePath, List<XMCustomerServiceKPI> ExportAfterSalesSalaryList)
        {
            #region 订单明细
            if (ExportAfterSalesSalaryList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("级别", "nvarchar(50)");
                    tableDefinition.Add("KPI数据", "nvarchar(50)");
                    tableDefinition.Add("奖金基数", "nvarchar(50)");
                    tableDefinition.Add("奖金系数", "nvarchar(50)");
                    tableDefinition.Add("实际奖金", "nvarchar(50)");
                    tableDefinition.Add("底薪", "nvarchar(50)");
                    tableDefinition.Add("合计", "nvarchar(50)");
                    excelHelper.WriteTable("售后薪资表", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in ExportAfterSalesSalaryList)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [售后薪资表] (序号, 组别, 客服, 级别, KPI数据, 奖金基数, 奖金系数, 实际奖金, 底薪, 合计) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Group == null ? "" : OrderInfoSalesDetails.Group); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Name == null ? "" : OrderInfoSalesDetails.Name); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.RankName == null ? "" : OrderInfoSalesDetails.RankName); st.Append("\",");

                        st.Append('"'); st.Append(OrderInfoSalesDetails.KPIScore == null ? "" : OrderInfoSalesDetails.KPIScore); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.BonusBase == 0 ? 0 : OrderInfoSalesDetails.BonusBase); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Percent == null ? "" : OrderInfoSalesDetails.Percent); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.RealBonus == null ? "" : OrderInfoSalesDetails.RealBonus); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.BasicSalary == null ? "" : OrderInfoSalesDetails.BasicSalary.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Total == 0 ? 0 : OrderInfoSalesDetails.Total); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 导出咨询跟进
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orderLists"></param>
        public void ExportConsultationXls(string filePath, List<XMConsultation> ExportAfterSalesSalaryList)
        {
            #region 导出咨询跟进
            if (ExportAfterSalesSalaryList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("顾客ID", "nvarchar(50)");
                    tableDefinition.Add("接待日期", "nvarchar(50)");
                    tableDefinition.Add("是否下单", "nvarchar(50)");
                    tableDefinition.Add("订单单号", "nvarchar(50)");
                    tableDefinition.Add("未成交类型", "nvarchar(50)");
                    tableDefinition.Add("厂家编码", "nvarchar(50)");
                    tableDefinition.Add("当日未成交原因", "nvarchar(255)");
                    tableDefinition.Add("接待客服", "nvarchar(50)");
                    tableDefinition.Add("跟进等级", "nvarchar(50)");
                    tableDefinition.Add("最近跟进日期", "nvarchar(50)");
                    tableDefinition.Add("最近跟进内容", "nvarchar(255)");
                    tableDefinition.Add("跟进总次数", "numeric(18, 0)");
                    tableDefinition.Add("不跟进原因", "nvarchar(50)");
                    tableDefinition.Add("组长点评", "nvarchar(255)");
                    excelHelper.WriteTable("咨询跟进表", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in ExportAfterSalesSalaryList)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [咨询跟进表] (序号, 平台, 店铺名称, 顾客ID, 接待日期, 是否下单, 订单单号, 未成交类型, 厂家编码, 当日未成交原因, 接待客服, 跟进等级, 最近跟进日期, 最近跟进内容, 跟进总次数, 不跟进原因, 组长点评) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PlatformType == null ? "" : OrderInfoSalesDetails.PlatformType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CustomerID == null ? "" : OrderInfoSalesDetails.CustomerID); st.Append("\",");

                        st.Append('"'); st.Append(OrderInfoSalesDetails.ReceptionDate == null ? "" : OrderInfoSalesDetails.ReceptionDate.ToString()); st.Append("\",");

                        st.Append('"'); st.Append(OrderInfoSalesDetails.IsOrder == null ? "否" : (OrderInfoSalesDetails.IsOrder == false ? "否" : "是")); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.OrderCode == null ? "" : (OrderInfoSalesDetails.OrderCode == "" ? "" : OrderInfoSalesDetails.OrderCode)); st.Append("\",");

                        st.Append('"'); st.Append(OrderInfoSalesDetails.NoTurnoverType == null ? "" : OrderInfoSalesDetails.NoTurnoverType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ManufacturersCode == null ? "" : OrderInfoSalesDetails.ManufacturersCode); st.Append("\",");
                        if (OrderInfoSalesDetails.DateReason != null)
                        {
                            if (OrderInfoSalesDetails.DateReason.Length > 255)
                            {
                                OrderInfoSalesDetails.DateReason.Substring(0, 250);
                            }
                        }
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DateReason == null ? "" : OrderInfoSalesDetails.DateReason); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreateName == null ? "" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.FollowGrade == null ? "" : OrderInfoSalesDetails.FollowGrade.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ContactTime == null ? "" : OrderInfoSalesDetails.ContactTime); st.Append("\",");
                        if (OrderInfoSalesDetails.ContactContent != null)
                        {
                            if (OrderInfoSalesDetails.ContactContent.Length > 255)
                            {
                                OrderInfoSalesDetails.ContactContent.Substring(0, 250);
                            }
                        }
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ContactContent == null ? "" : OrderInfoSalesDetails.ContactContent); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.XMConsultationDetails == 0 ? 0 : OrderInfoSalesDetails.XMConsultationDetails); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NoCauseType == null ? "" : OrderInfoSalesDetails.NoCauseType); st.Append("\",");
                        if (OrderInfoSalesDetails.LeaderComments != null)
                        {
                            if (OrderInfoSalesDetails.LeaderComments.Length > 255)
                            {
                                OrderInfoSalesDetails.LeaderComments.Substring(0, 250);
                            }
                        }
                        st.Append('"'); st.Append(OrderInfoSalesDetails.LeaderComments == null ? "" : OrderInfoSalesDetails.LeaderComments); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 赠品导出
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ExportXMPremiumsList"></param>
        public void ExportPremiumsXls(string filePath, List<XMPremiums> ExportXMPremiumsList)
        {
            #region 订单明细
            if (ExportXMPremiumsList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("旺旺号", "nvarchar(50)");
                    tableDefinition.Add("姓名", "nvarchar(50)");
                    tableDefinition.Add("地址", "nvarchar(250)");
                    tableDefinition.Add("电话", "nvarchar(250)");
                    tableDefinition.Add("活动说明", "nvarchar(50)");
                    tableDefinition.Add("申请类型", "nvarchar(50)");
                    tableDefinition.Add("创单时间", "nvarchar(50)");
                    tableDefinition.Add("商品名称", "nvarchar(50)");
                    tableDefinition.Add("商品编码", "nvarchar(50)");
                    tableDefinition.Add("尺寸", "nvarchar(50)");
                    tableDefinition.Add("出厂价", "nvarchar(50)");
                    tableDefinition.Add("发货方", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    excelHelper.WriteTable("赠品信息表", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var Premiums in ExportXMPremiumsList)
                    {
                        var list = IoC.Resolve<IXMPremiumsDetailsService>().GetXMPremiumsDetailsListByPremiumsId((int)Premiums.Id);
                        var Order = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Premiums.OrderCode);
                        var SpareAddress = IoC.Resolve<IXMSpareAddressService>().GetXMSpareAddressByParm(Premiums.Id, 711);
                        string PremiumsType = "";
                        string shipper = "";
                        //if (!string.IsNullOrEmpty(OrderInfoSalesDetails.CustomerServiceRemark) && OrderInfoSalesDetails.CustomerServiceRemark.Contains("//QM"))
                        //{
                        //    shipper = "曲美";
                        //}
                        //else
                        //{
                        //    shipper = "和众";
                        //}
                        if (Premiums.PremiumsTypeId != null)
                        {
                            if (Premiums.PremiumsTypeId == Convert.ToInt32(StatusEnum.ChildPremiums))
                            {
                                PremiumsType = "赠品";
                            }
                            else if (Premiums.PremiumsTypeId == Convert.ToInt32(StatusEnum.ChildPayment))
                            {
                                PremiumsType = "赔付";
                            }
                        }
                        if (list != null && list.Count > 0)
                        {
                            foreach (var info in list)
                            {
                                shipper = info.ShipperName;
                                string specifications = "";
                                if (info.ProductDetaislId != null && info.ProductDetaislId != -1)
                                {
                                    var two = IoC.Resolve<IXMProductService>().GetXMProductById((int)info.ProductDetaislId);
                                    if (two != null)
                                    {
                                        specifications = two.Specifications;
                                    }
                                }
                                StringBuilder st = new StringBuilder();
                                st.Append("INSERT INTO [赠品信息表] (序号, 订单号, 旺旺号, 姓名, 地址, 电话, 活动说明, 申请类型, 创单时间, 商品名称, 商品编码, 尺寸, 出厂价, 发货方, 数量) VALUES (");
                                st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                                st.Append('"'); st.Append(Premiums.OrderCode == null ? "" : Premiums.OrderCode); st.Append("\",");
                                st.Append('"'); st.Append(Premiums.WantId == null ? "" : Premiums.WantId); st.Append("\",");

                                if (SpareAddress == null)
                                {
                                    st.Append('"'); st.Append(Order.FullName == null ? "" : Order.FullName); st.Append("\",");
                                    st.Append('"'); st.Append(Order.DeliveryAddress == null ? "" : Order.DeliveryAddress); st.Append("\",");
                                    st.Append('"'); st.Append(Order.Mobile == null ? "" : Order.Mobile); st.Append("\",");
                                }
                                else
                                {
                                    st.Append('"'); st.Append(SpareAddress.FullName == null ? "" : SpareAddress.FullName); st.Append("\",");
                                    st.Append('"'); st.Append(SpareAddress.DeliveryAddress == null ? "" : SpareAddress.DeliveryAddress); st.Append("\",");
                                    st.Append('"'); st.Append(SpareAddress.Mobile == null ? "" : SpareAddress.Mobile); st.Append("\",");
                                }

                                st.Append('"'); st.Append(Premiums.ActivityExplanation == null ? "" : Premiums.ActivityExplanation); st.Append("\",");
                                st.Append('"'); st.Append(PremiumsType); st.Append("\",");
                                st.Append('"'); st.Append(Premiums.CreateTime.ToString() == null ? "" : Premiums.CreateTime.ToString()); st.Append("\",");
                                st.Append('"'); st.Append(info.PrdouctName == null ? "" : info.PrdouctName); st.Append("\",");
                                st.Append('"'); st.Append(info.PlatformMerchantCode == null ? "" : info.PlatformMerchantCode); st.Append("\",");
                                st.Append('"'); st.Append(specifications); st.Append("\",");
                                st.Append('"'); st.Append(info.FactoryPrice == null ? 0 : info.FactoryPrice); st.Append("\",");
                                st.Append('"'); st.Append(shipper); st.Append("\",");
                                st.Append('"'); st.Append(info.ProductNum == null ? 0 : info.ProductNum); st.Append("\"");
                                st.Append(")");
                                excelHelper.ExecuteCommand(st.ToString());
                                zIndex++;
                            }
                        }
                        else
                        {
                            StringBuilder st = new StringBuilder();
                            st.Append("INSERT INTO [赠品信息表] (序号, 订单号, 旺旺号,姓名,地址,电话, 活动说明, 申请类型, 创单时间, 商品名称, 商品编码, 尺寸, 出厂价, 发货方, 数量) VALUES (");
                            st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(Premiums.OrderCode == null ? "" : Premiums.OrderCode); st.Append("\",");
                            st.Append('"'); st.Append(Premiums.WantId == null ? "" : Premiums.WantId); st.Append("\",");

                            if (SpareAddress == null)
                            {
                                st.Append('"'); st.Append(Order.FullName == null ? "" : Order.FullName); st.Append("\",");
                                st.Append('"'); st.Append(Order.DeliveryAddress == null ? "" : Order.DeliveryAddress); st.Append("\",");
                                st.Append('"'); st.Append(Order.Mobile == null ? "" : Order.Mobile); st.Append("\",");
                            }
                            else
                            {
                                st.Append('"'); st.Append(SpareAddress.FullName == null ? "" : SpareAddress.FullName); st.Append("\",");
                                st.Append('"'); st.Append(SpareAddress.DeliveryAddress == null ? "" : SpareAddress.DeliveryAddress); st.Append("\",");
                                st.Append('"'); st.Append(SpareAddress.Mobile == null ? "" : SpareAddress.Mobile); st.Append("\",");
                            }

                            st.Append('"'); st.Append(Premiums.ActivityExplanation == null ? "" : Premiums.ActivityExplanation); st.Append("\",");
                            st.Append('"'); st.Append(PremiumsType); st.Append("\",");
                            st.Append('"'); st.Append(Premiums.CreateTime.ToString() == null ? "" : Premiums.CreateTime.ToString()); st.Append("\",");
                            st.Append('"'); st.Append("-"); st.Append("\",");
                            st.Append('"'); st.Append("-"); st.Append("\",");
                            st.Append('"'); st.Append("无产品"); st.Append("\",");
                            st.Append('"'); st.Append(shipper); st.Append("\",");
                            st.Append('"'); st.Append("-"); st.Append("\",");
                            st.Append('"'); st.Append("-"); st.Append("\"");
                            st.Append(")");
                            excelHelper.ExecuteCommand(st.ToString());
                            zIndex++;
                        }
                    }
                }
            }

            #endregion
        }

        public void ExportClaimFormDocx(string filePath, int ID)
        {
            string ClaimFormPath = filePath.Substring(0, filePath.IndexOf("Upload") + 6);
            string tmppath = ClaimFormPath + "\\ClaimFormTemplate.dotx";
            Aspose.Words.Document oDoc = new Aspose.Words.Document(tmppath); //载入模板

            //声明书签数组  
            string[] oBookMark = new string[55];
            //赋值书签名  
            oBookMark[0] = "ConsignorName";
            oBookMark[1] = "BeginDate";
            oBookMark[2] = "CompanyName";
            oBookMark[3] = "CompanyName2";
            oBookMark[4] = "LogisticsNumber";
            oBookMark[5] = "GoodsName";
            oBookMark[6] = "Count";
            oBookMark[7] = "InsuredAmount";
            oBookMark[8] = "BeginPlace";
            oBookMark[9] = "EndPlace";
            oBookMark[10] = "EndDate";
            oBookMark[11] = "Amount";
            oBookMark[12] = "BrokenStatus1";
            oBookMark[13] = "BrokenStatus2";
            oBookMark[14] = "BrokenStatus3";
            oBookMark[15] = "BrokenStatus4";
            oBookMark[16] = "BrokenStatus5";
            oBookMark[17] = "BrokenStatus6";
            oBookMark[18] = "BrokenStatus7";
            oBookMark[19] = "BrokenPieces";
            oBookMark[20] = "ProductName1"; oBookMark[21] = "Model1"; oBookMark[22] = "ProductValue1"; oBookMark[23] = "Description1"; oBookMark[24] = "Amount1";
            oBookMark[25] = "ProductName2"; oBookMark[26] = "Model2"; oBookMark[27] = "ProductValue2"; oBookMark[28] = "Description2"; oBookMark[29] = "Amount2";
            oBookMark[30] = "ProductName3"; oBookMark[31] = "Model3"; oBookMark[32] = "ProductValue3"; oBookMark[33] = "Description3"; oBookMark[34] = "Amount3";
            oBookMark[35] = "ProductName4"; oBookMark[36] = "Model4"; oBookMark[37] = "ProductValue4"; oBookMark[38] = "Description4"; oBookMark[39] = "Amount4";
            oBookMark[40] = "ProductName5"; oBookMark[41] = "Model5"; oBookMark[42] = "ProductValue5"; oBookMark[43] = "Description5"; oBookMark[44] = "Amount5";
            oBookMark[45] = "ProductName6"; oBookMark[46] = "Model6"; oBookMark[47] = "ProductValue6"; oBookMark[48] = "Description6"; oBookMark[49] = "Amount6";
            oBookMark[50] = "ProductName7"; oBookMark[51] = "Model7"; oBookMark[52] = "ProductValue7"; oBookMark[53] = "Description7"; oBookMark[54] = "Amount7";

            //赋值任意数据到书签的位置
            //索赔单信息
            var info = IoC.Resolve<IXMClaimFormService>().GetXMClaimFormByID(ID);
            string[] list = info.BrokenStatus.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (list != null && list.Count() > 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i] == "1")
                    {
                        oDoc.Range.Bookmarks[oBookMark[12]].Text = "√";
                    }
                    if (list[i] == "2")
                    {
                        oDoc.Range.Bookmarks[oBookMark[13]].Text = "√";
                    }
                    if (list[i] == "3")
                    {
                        oDoc.Range.Bookmarks[oBookMark[14]].Text = "√";
                    }
                    if (list[i] == "4")
                    {
                        oDoc.Range.Bookmarks[oBookMark[15]].Text = "√";
                    }
                    if (list[i] == "5")
                    {
                        oDoc.Range.Bookmarks[oBookMark[16]].Text = "√";
                    }
                    if (list[i] == "6")
                    {
                        oDoc.Range.Bookmarks[oBookMark[17]].Text = "√";
                    }
                    if (list[i] == "7")
                    {
                        oDoc.Range.Bookmarks[oBookMark[18]].Text = "√";
                    }
                }
            }

            oDoc.Range.Bookmarks[oBookMark[0]].Text = info.ConsignorName;
            oDoc.Range.Bookmarks[oBookMark[1]].Text = ((DateTime)info.BeginDate).ToString("yyyy年MM月dd日");
            oDoc.Range.Bookmarks[oBookMark[2]].Text = info.CompanyName;
            oDoc.Range.Bookmarks[oBookMark[3]].Text = info.CompanyName;
            oDoc.Range.Bookmarks[oBookMark[4]].Text = info.LogisticsNumber;
            oDoc.Range.Bookmarks[oBookMark[5]].Text = info.GoodsName;
            oDoc.Range.Bookmarks[oBookMark[6]].Text = info.Count.ToString();
            oDoc.Range.Bookmarks[oBookMark[7]].Text = info.InsuredAmount.ToString();
            oDoc.Range.Bookmarks[oBookMark[8]].Text = info.BeginPlace;
            oDoc.Range.Bookmarks[oBookMark[9]].Text = info.EndPlace;
            oDoc.Range.Bookmarks[oBookMark[10]].Text = ((DateTime)info.EndDate).ToString("yyyy年MM月dd日");
            oDoc.Range.Bookmarks[oBookMark[11]].Text = info.Amount.ToString();
            oDoc.Range.Bookmarks[oBookMark[19]].Text = info.BrokenPieces.ToString();

            var DetailList = IoC.Resolve<IXMClaimFormDetailService>().GetXMClaimFormDetailListByClaimFormID(ID);
            if (DetailList != null && DetailList.Count > 0)
            {
                int no = 20;
                for (int i = 0; i < DetailList.Count; i++)
                {
                    oDoc.Range.Bookmarks[oBookMark[no]].Text = DetailList[i].ProductName;
                    oDoc.Range.Bookmarks[oBookMark[no + 1]].Text = DetailList[i].Model;
                    oDoc.Range.Bookmarks[oBookMark[no + 2]].Text = DetailList[i].ProductValue;
                    oDoc.Range.Bookmarks[oBookMark[no + 3]].Text = DetailList[i].Description;
                    oDoc.Range.Bookmarks[oBookMark[no + 4]].Text = DetailList[i].Amount.ToString();
                    no = no + 5;
                }
            }

            oDoc.Save(filePath, SaveFormat.Doc);//直接保存文件
        }

        public void ExportClaimInfoDocx(string filePath, int id)
        {
            var XMClaimInfoService = IoC.Resolve<IXMClaimInfoService>();
            var XMClaimInfoDetailService = IoC.Resolve<IXMClaimInfoDetailService>();
            var XMClaimInfoProductDetailsService = IoC.Resolve<IXMClaimInfoProductDetailsService>();
            var XMDeliveryService = IoC.Resolve<IXMDeliveryService>();
            var XMOrderInfoService = IoC.Resolve<IXMOrderInfoService>();

            string ClaimFormPath = filePath.Substring(0, filePath.IndexOf("Upload") + 6);
            string tmppath = ClaimFormPath + "\\ClaimInfoTemplate.dot";

            //声明书签数组  
            string[] oBookMark = new string[46];
            //赋值书签名  
            oBookMark[0] = "year";
            oBookMark[1] = "month";
            oBookMark[2] = "day";
            oBookMark[3] = "numbers";
            oBookMark[4] = "productName";
            oBookMark[5] = "num";
            oBookMark[6] = "supportMoney";
            oBookMark[7] = "beginPlace";
            oBookMark[8] = "endPlace";
            oBookMark[9] = "month1";
            oBookMark[10] = "day1";
            oBookMark[11] = "num1";
            oBookMark[12] = "Status1";
            oBookMark[13] = "Status2";
            oBookMark[14] = "Status3";
            oBookMark[15] = "Status4";
            oBookMark[16] = "Status5";
            oBookMark[17] = "Status6";
            oBookMark[18] = "Status7";
            oBookMark[19] = "claimMoney";
            oBookMark[20] = "damagedProductName1"; oBookMark[21] = "damagedModel1"; oBookMark[22] = "damagedProductValue1"; oBookMark[23] = "damagedDescription1"; oBookMark[24] = "damagedAmount1";
            oBookMark[25] = "damagedProductName2"; oBookMark[26] = "damagedModel2"; oBookMark[27] = "damagedProductValue2"; oBookMark[28] = "damagedDescription2"; oBookMark[29] = "damagedAmount2";
            oBookMark[30] = "damagedProductName3"; oBookMark[31] = "damagedModel3"; oBookMark[32] = "damagedProductValue3"; oBookMark[33] = "damagedDescription3"; oBookMark[34] = "damagedAmount3";
            oBookMark[35] = "damagedProductName4"; oBookMark[36] = "damagedModel4"; oBookMark[37] = "damagedProductValue4"; oBookMark[38] = "damagedDescription4"; oBookMark[39] = "damagedAmount4";
            oBookMark[40] = "damagedProductName5"; oBookMark[41] = "damagedModel5"; oBookMark[42] = "damagedProductValue5"; oBookMark[43] = "damagedDescription5"; oBookMark[44] = "damagedAmount5";
            oBookMark[45] = "nowTime";


            Aspose.Words.Document oDoc = new Aspose.Words.Document(tmppath); //载入模板
            XMClaimInfo entity_ClaimInfo = XMClaimInfoService.GetXMClaimInfoById(id);
            List<XMDelivery> entity_Delivery = XMDeliveryService.GetXMDeliveryListByLogisticsNumber(entity_ClaimInfo.LogisticsNumber);

            if (entity_Delivery.Count > 0)
            {
                DateTime time = (DateTime)entity_Delivery[0].PrintDateTime;
                oDoc.Range.Bookmarks[oBookMark[0]].Text = time.Year.ToString();
                oDoc.Range.Bookmarks[oBookMark[1]].Text = time.Month.ToString();
                oDoc.Range.Bookmarks[oBookMark[2]].Text = time.Day.ToString();
                oDoc.Range.Bookmarks[oBookMark[3]].Text = entity_ClaimInfo.LogisticsNumber;

                string productName = string.Empty;
                List<XMDeliveryDetails> list_DeliveryDetails = entity_Delivery[0].XM_Delivery_Details.ToList();
                foreach (var item in list_DeliveryDetails)
                {
                    productName = productName + item.PrdouctName + ",";
                }
                oDoc.Range.Bookmarks[oBookMark[4]].Text = string.IsNullOrEmpty(productName) ? "" : productName.Substring(0, productName.Length - 1);
                oDoc.Range.Bookmarks[oBookMark[5]].Text = list_DeliveryDetails.Count > 0 ? list_DeliveryDetails.Sum(a => a.ProductNum).ToString() : "";
                oDoc.Range.Bookmarks[oBookMark[7]].Text = list_DeliveryDetails.Count > 0 ? list_DeliveryDetails[0].WarehouseName : "";
                oDoc.Range.Bookmarks[oBookMark[8]].Text = entity_Delivery[0].DeliveryAddress;

                XMOrderInfo entity_OredrInfo = XMOrderInfoService.GetXMOrderByOrderCode(entity_Delivery[0].OrderCode);
                if(entity_OredrInfo!=null)
                {
                    oDoc.Range.Bookmarks[oBookMark[6]].Text = ((decimal)entity_OredrInfo.OrderPrice).ToString();
                }
                else
                {
                    oDoc.Range.Bookmarks[oBookMark[6]].Text = "";
                }
            }

            oDoc.Range.Bookmarks[oBookMark[9]].Text = "";
            oDoc.Range.Bookmarks[oBookMark[10]].Text = "";

            List<XMClaimInfoProductDetails> list_ClaimInfoProductDetails = XMClaimInfoProductDetailsService.GetXMClaimInfoProductDetailsListByClaimInfoID(id);
            oDoc.Range.Bookmarks[oBookMark[11]].Text = list_ClaimInfoProductDetails.Count > 0 ? list_ClaimInfoProductDetails.Sum(a => a.ProductNum).ToString() : "";

            List<XMClaimInfoDetail> entity_ClaimInfoDetail = XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(id);
            if(entity_ClaimInfoDetail.Count>0)
            {
                if (!string.IsNullOrEmpty(entity_ClaimInfoDetail[0].DamagedCondition))
                {
                    string[] conditions = entity_ClaimInfoDetail[0].DamagedCondition.Split(',');
                    foreach (string item in conditions)
                    {
                        switch (item)
                        {
                            case "750":
                                oDoc.Range.Bookmarks[oBookMark[12]].Text = "√";
                                break;
                            case "751":
                                oDoc.Range.Bookmarks[oBookMark[13]].Text = "√";
                                break;
                            case "752":
                                oDoc.Range.Bookmarks[oBookMark[14]].Text = "√";
                                break;
                            case "753":
                                oDoc.Range.Bookmarks[oBookMark[15]].Text = "√";
                                break;
                            case "754":
                                oDoc.Range.Bookmarks[oBookMark[16]].Text = "√";
                                break;
                            case "772":
                                oDoc.Range.Bookmarks[oBookMark[17]].Text = "√";
                                break;
                            case "773":
                                oDoc.Range.Bookmarks[oBookMark[18]].Text = "√";
                                break;
                        }
                    }
                }
                oDoc.Range.Bookmarks[oBookMark[19]].Text = entity_ClaimInfoDetail[0].ClaimAcount.ToString();
            }

            if (list_ClaimInfoProductDetails.Count > 0)
            {
                int i = 20;
                foreach (var item in list_ClaimInfoProductDetails)
                {
                    oDoc.Range.Bookmarks[oBookMark[i]].Text = item.PrdouctName;
                    oDoc.Range.Bookmarks[oBookMark[i + 1]].Text = item.Specifications;
                    oDoc.Range.Bookmarks[oBookMark[i + 2]].Text = "";
                    oDoc.Range.Bookmarks[oBookMark[i + 3]].Text = "";
                    oDoc.Range.Bookmarks[oBookMark[i + 4]].Text = "";
                    i = i + 5;
                }
            }

            DateTime now = DateTime.Now;
            oDoc.Range.Bookmarks[oBookMark[45]].Text = now.Year + "/" + now.Month + "/" + now.Day;


            oDoc.Save(filePath, SaveFormat.Doc);//直接保存文件


        }

        /// <summary>
        /// 导出销售数据分析
        /// </summary>
        public void ExportDataAnalysisXls(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal)
        {
            #region 导出销售数据分析-详细
            if (DataAnalysyAll.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    //tableDefinition.Add("接待日期", "nvarchar(50)");
                    tableDefinition.Add("咨询量", "nvarchar(50)");
                    tableDefinition.Add("成交量", "nvarchar(50)");
                    tableDefinition.Add("成交人数", "nvarchar(50)");
                    tableDefinition.Add("转化率", "nvarchar(255)");
                    tableDefinition.Add("成交金额", "nvarchar(50)");
                    excelHelper.WriteTable("销售数据分析-详细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyAll)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [销售数据分析-详细] (序号, 平台, 店铺名称, 组别, 客服, 咨询量, 成交量, 成交人数, 转化率, 成交金额) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PlatformType == null ? "" : OrderInfoSalesDetails.PlatformType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.DepartmentName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        //st.Append('"'); st.Append(OrderInfoSalesDetails.ReceptionDate == null ? "" : OrderInfoSalesDetails.ReceptionDate.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ConsultationCount == null ? "" : OrderInfoSalesDetails.ConsultationCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealPeopleCount == null ? "" : OrderInfoSalesDetails.DealPeopleCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ConversionRate == null ? "" : (Math.Round(OrderInfoSalesDetails.ConversionRate * 100, 2).ToString() + "%")); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealTotal == null ? "" : OrderInfoSalesDetails.DealTotal.ToString()); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 导出销售数据分析-汇总
            if (DataAnalysyTotal.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("咨询量", "nvarchar(50)");
                    tableDefinition.Add("成交量", "nvarchar(50)");
                    tableDefinition.Add("成交人数", "nvarchar(50)");
                    tableDefinition.Add("转化率", "nvarchar(255)");
                    tableDefinition.Add("成交金额", "nvarchar(50)");
                    excelHelper.WriteTable("销售数据分析-汇总", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyTotal)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [销售数据分析-汇总] (序号, 组别, 客服, 咨询量, 成交量, 成交人数, 转化率, 成交金额) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.DepartmentName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ConsultationCount == null ? "" : OrderInfoSalesDetails.ConsultationCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealPeopleCount == null ? "" : OrderInfoSalesDetails.DealPeopleCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ConversionRate == null ? "" : (Math.Round(OrderInfoSalesDetails.ConversionRate * 100, 2).ToString() + "%")); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealTotal == null ? "" : OrderInfoSalesDetails.DealTotal.ToString()); st.Append("\"");

                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出未成交数据分析
        /// </summary>
        public void ExportDataAnalysisXlsNoDeal(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal)
        {
            #region 导出未成交数据分析-详细
            if (DataAnalysyAll.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("未成交类型", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    //tableDefinition.Add("跟进次数", "nvarchar(50)");
                    //tableDefinition.Add("未成交数量", "nvarchar(50)");
                    tableDefinition.Add("未成交原因", "nvarchar(50)");
                    excelHelper.WriteTable("未成交数据分析-详细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyAll)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [未成交数据分析-详细] (序号, 未成交类型, 平台, 店铺名称, 组别, 客服, 未成交原因) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NoTurnoverType == null ? "" : OrderInfoSalesDetails.NoTurnoverType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PlatformType == null ? "" : OrderInfoSalesDetails.PlatformType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.DepartmentName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        //st.Append('"'); st.Append(OrderInfoSalesDetails.FollowCount == null ? "" : OrderInfoSalesDetails.FollowCount.ToString()); st.Append("\",");
                        //st.Append('"'); st.Append(OrderInfoSalesDetails.NoTurnoverTypeCount == null ? "" : OrderInfoSalesDetails.NoTurnoverTypeCount.ToString()); st.Append("\"");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DateReason == null ? "" : OrderInfoSalesDetails.DateReason); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 导出未成交数据分析-汇总
            if (DataAnalysyTotal.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("未成交类型", "nvarchar(50)");
                    tableDefinition.Add("未成交数量", "nvarchar(50)");
                    excelHelper.WriteTable("未成交数据分析-汇总", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyTotal)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [未成交数据分析-汇总] (序号, 未成交类型, 未成交数量) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NoTurnoverType == null ? "" : OrderInfoSalesDetails.NoTurnoverType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NoTurnoverTypeCount == null ? "" : OrderInfoSalesDetails.NoTurnoverTypeCount.ToString()); st.Append("\"");

                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出问题数据分析-客服
        /// </summary>
        public void ExportDataAnalysisXlsQuestion(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal)
        {
            #region 导出问题数据分析-详细
            if (DataAnalysyAll.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("问题类型", "nvarchar(50)");
                    tableDefinition.Add("问题等级", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    excelHelper.WriteTable("问题数据分析-客服-详细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyAll)
                    {
                        string QuestionLevelName = OrderInfoSalesDetails.QuestionLevelName == null ? "" : OrderInfoSalesDetails.QuestionLevelName.CodeName;
                        string QuestionTypeName = OrderInfoSalesDetails.ParentQuestionTypeName;

                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [问题数据分析-客服-详细] (序号, 平台, 店铺名称, 问题类型, 问题等级, 客服, 数量) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PlatformType == null ? "" : OrderInfoSalesDetails.PlatformType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(QuestionTypeName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.QuestionLevelName == null ? "" : QuestionLevelName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == 0 ? "未接单" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 导出未成交数据分析-汇总
            if (DataAnalysyTotal.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    tableDefinition.Add("完成率", "nvarchar(50)");
                    tableDefinition.Add("时效（小时）", "nvarchar(50)");
                    tableDefinition.Add("退货挽回率", "nvarchar(50)");
                    excelHelper.WriteTable("问题数据分析-客服-汇总", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyTotal)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [问题数据分析-客服-汇总] (序号, 组别, 客服, 数量, 完成率, 时效（小时）, 退货挽回率) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == 0 ? "" : OrderInfoSalesDetails.CreateName.DepartmentName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == 0 ? "未接单" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CompleteRate == null ? "" : (OrderInfoSalesDetails.CompleteRate * 100).ToString() + "%"); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.TimeEfficiency == null ? "" : OrderInfoSalesDetails.TimeEfficiency.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ReturnRate == null ? "" : (OrderInfoSalesDetails.ReturnRate * 100).ToString() + "%"); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出退换货数据分析-客服
        /// </summary>
        public void ExportDataAnalysisXlsApplication(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal)
        {
            #region 导出问题数据分析-详细
            if (DataAnalysyAll.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("退换货类型", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    excelHelper.WriteTable("退换货数据分析-客服-详细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyAll)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [退换货数据分析-客服-详细] (序号, 平台, 店铺名称, 退换货类型, 客服, 数量) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PlatformType == null ? "" : OrderInfoSalesDetails.PlatformType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ApplicationType == null ? "" : OrderInfoSalesDetails.ApplicationTypeName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 导出未成交数据分析-汇总
            if (DataAnalysyTotal.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("组别", "nvarchar(50)");
                    tableDefinition.Add("客服", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    excelHelper.WriteTable("退换货数据分析-客服-汇总", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyTotal)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [退换货数据分析-客服-汇总] (序号, 组别, 客服, 数量) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.DepartmentName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.CreatorID == null ? "" : OrderInfoSalesDetails.CreateName.FullName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出问题数据分析-问题类型
        /// </summary>
        public void ExportDataAnalysisXlsQuestionType(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal, int nick_id)
        {
            #region 导出问题数据分析-详细
            if (DataAnalysyAll.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    if (nick_id != -1)                   //选择店铺
                    {
                        tableDefinition.Add("序号", "nvarchar(50)");
                        tableDefinition.Add("店铺", "nvarchar(50)");
                        tableDefinition.Add("问题类型", "nvarchar(50)");
                        tableDefinition.Add("数量", "nvarchar(50)");
                        tableDefinition.Add("该问题类型占比", "nvarchar(50)");
                        excelHelper.WriteTable("问题数据分析-问题类型-详细", tableDefinition);
                    }
                    else if (nick_id == -1)     //未选择店铺
                    {
                        tableDefinition.Add("序号", "nvarchar(50)");
                        tableDefinition.Add("问题类型", "nvarchar(50)");
                        tableDefinition.Add("数量", "nvarchar(50)");
                        tableDefinition.Add("该问题类型占比", "nvarchar(50)");
                        excelHelper.WriteTable("问题数据分析-问题类型-详细", tableDefinition);
                    }
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyAll)
                    {
                        string QuestionLevelName = OrderInfoSalesDetails.QuestionLevelName == null ? "" : OrderInfoSalesDetails.QuestionLevelName.CodeName;
                        string QuestionTypeName = OrderInfoSalesDetails.QuestionCategoryName == null ? "" : OrderInfoSalesDetails.QuestionCategoryName;
                        StringBuilder st = new StringBuilder();
                        if (nick_id != -1)                   //选择店铺
                        {
                            st.Append("INSERT INTO [问题数据分析-问题类型-详细] (序号,店铺, 问题类型, 数量, 该问题类型占比) VALUES (");
                            st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.NickName); st.Append("\",");
                            st.Append('"'); st.Append(QuestionTypeName); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.TotalRate == null ? "" : (Math.Round(OrderInfoSalesDetails.TotalRate * 100, 2)).ToString() + "%"); st.Append("\"");
                            st.Append(")");
                        }
                        else if (nick_id == -1)     //未选择店铺
                        {
                            st.Append("INSERT INTO [问题数据分析-问题类型-详细] (序号, 问题类型, 数量, 该问题类型占比) VALUES (");
                            st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(QuestionTypeName); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(OrderInfoSalesDetails.TotalRate == null ? "" : (Math.Round(OrderInfoSalesDetails.TotalRate * 100, 2)).ToString() + "%"); st.Append("\"");
                            st.Append(")");
                        }
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            //#region 导出未成交数据分析-汇总
            //if (DataAnalysyTotal.Count > 0)
            //{
            //    using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            //    {
            //        excelHelper.Hdr = "YES";
            //        excelHelper.Imex = "0";
            //        Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
            //        tableDefinition.Add("序号", "nvarchar(50)");
            //        tableDefinition.Add("问题类型", "nvarchar(50)");
            //        tableDefinition.Add("数量", "nvarchar(50)");
            //        excelHelper.WriteTable("问题数据分析-问题类型-汇总", tableDefinition);
            //        //序号
            //        int zIndex = 1;
            //        foreach (var OrderInfoSalesDetails in DataAnalysyTotal)
            //        {
            //            StringBuilder st = new StringBuilder();
            //            st.Append("INSERT INTO [问题数据分析-问题类型-汇总] (序号, 问题类型, 数量) VALUES (");
            //            st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
            //            st.Append('"'); st.Append(OrderInfoSalesDetails.QuestionType == null ? "" : OrderInfoSalesDetails.QuestionTypeName.CodeName); st.Append("\",");
            //            st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\"");
            //            st.Append(")");
            //            excelHelper.ExecuteCommand(st.ToString());
            //            zIndex++;
            //        }
            //    }
            //}
            //#endregion
        }

        /// <summary>
        /// 导出退换货数据分析-退换货类型
        /// </summary>
        public void ExportDataAnalysisXlsApplicationType(string filePath, List<XMDataAnalysy> DataAnalysyAll, List<XMDataAnalysy> DataAnalysyTotal)
        {
            #region 导出问题数据分析-详细
            if (DataAnalysyAll.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("平台", "nvarchar(50)");
                    tableDefinition.Add("店铺名称", "nvarchar(50)");
                    tableDefinition.Add("退换货类型", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    tableDefinition.Add("该退换货类型占比", "nvarchar(50)");
                    excelHelper.WriteTable("退换货数据分析-退换货类型-详细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyAll)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [退换货数据分析-退换货类型-详细] (序号, 平台, 店铺名称, 退换货类型, 数量, 该退换货类型占比) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PlatformType == null ? "" : OrderInfoSalesDetails.PlatformType); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ApplicationType == null ? "" : OrderInfoSalesDetails.ApplicationTypeName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.TotalRate == null ? "" : (Math.Round(OrderInfoSalesDetails.TotalRate * 100, 2)).ToString() + "%"); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }

            #endregion

            #region 导出未成交数据分析-汇总
            if (DataAnalysyTotal.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("退换货类型", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    excelHelper.WriteTable("退换货数据分析-退换货类型-汇总", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in DataAnalysyTotal)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [退换货数据分析-退换货类型-汇总] (序号, 退换货类型, 数量) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ApplicationTypeName == null ? "" : OrderInfoSalesDetails.ApplicationTypeName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.DealCount == null ? "" : OrderInfoSalesDetails.DealCount.ToString()); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出产品销量统计
        /// </summary>
        public void ExportProductSalesXls(string filePath, IEnumerable<ProductSalesData> ProductSalesList)
        {
            #region 导出销量统计
            if (ProductSalesList.Count() > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("产品名称", "nvarchar(50)");
                    tableDefinition.Add("厂家编码", "nvarchar(50)");
                    tableDefinition.Add("尺寸", "nvarchar(50)");
                    tableDefinition.Add("出厂价", "nvarchar(50)");
                    tableDefinition.Add("件数", "nvarchar(50)");
                    tableDefinition.Add("销售成本", "nvarchar(50)");
                    excelHelper.WriteTable("导出销量统计", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in ProductSalesList)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [导出销量统计] (序号, 产品名称, 厂家编码, 尺寸, 出厂价, 件数, 销售成本) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ProductName == null ? "" : OrderInfoSalesDetails.ProductName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Manufacturers == null ? "" : OrderInfoSalesDetails.Manufacturers); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Specifications == null ? "" : OrderInfoSalesDetails.Specifications); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.FactoryPrice == null ? 0 : OrderInfoSalesDetails.FactoryPrice); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ProductNum == null ? 0 : OrderInfoSalesDetails.ProductNum); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.FactoryPrice * OrderInfoSalesDetails.ProductNum); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出产品销量统计未发货
        /// </summary>
        public void ExportProductSalesNotDeliXls(string filePath, IEnumerable<ProductSalesData> ProductSalesList)
        {
            #region 导出产品销量统计未发货
            if (ProductSalesList.Count() > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("产品名称", "nvarchar(50)");
                    tableDefinition.Add("厂家编码", "nvarchar(50)");
                    tableDefinition.Add("尺寸", "nvarchar(50)");
                    tableDefinition.Add("件数", "nvarchar(50)");
                    tableDefinition.Add("省", "nvarchar(50)");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("网店名称", "nvarchar(50)");
                    tableDefinition.Add("下单时间", "nvarchar(50)");
                    tableDefinition.Add("付款时间", "nvarchar(50)");
                    tableDefinition.Add("所在省", "nvarchar(50)");
                    tableDefinition.Add("手机号", "nvarchar(50)");
                    excelHelper.WriteTable("统计未发货", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var OrderInfoSalesDetails in ProductSalesList)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [统计未发货] (序号,产品名称,厂家编码,尺寸,件数,省,订单号,网店名称,下单时间,付款时间,所在省,手机号) VALUES (");
                        st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ProductName == null ? "" : OrderInfoSalesDetails.ProductName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Manufacturers == null ? "" : OrderInfoSalesDetails.Manufacturers); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Specifications == null ? "" : OrderInfoSalesDetails.Specifications); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.ProductNum == null ? 0 : OrderInfoSalesDetails.ProductNum); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Province == null ? "" : OrderInfoSalesDetails.Province); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.OrderCode == null ? "" : OrderInfoSalesDetails.OrderCode); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.NickName == null ? "" : OrderInfoSalesDetails.NickName); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.OrderInfoCreateDate == null ? "" : OrderInfoSalesDetails.OrderInfoCreateDate.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.PayDate == null ? "" : OrderInfoSalesDetails.PayDate.ToString()); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.Province == null ? "" : OrderInfoSalesDetails.Province); st.Append("\",");
                        st.Append('"'); st.Append(OrderInfoSalesDetails.BuyerMobile == null ? "" : OrderInfoSalesDetails.BuyerMobile); st.Append("\"");
                        st.Append(")");
                        excelHelper.ExecuteCommand(st.ToString());
                        zIndex++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出项目资金变动
        /// </summary>
        public void ExportProjectCapitalChangesXls(string filePath, List<string> ExportList)
        {
            #region 导出项目资金变动
            if (ExportList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("项目", "nvarchar(50)");
                    tableDefinition.Add("发生额", "nvarchar(50)");
                    tableDefinition.Add("累计", "nvarchar(50)");
                    excelHelper.WriteTable("项目资金变动", tableDefinition);
                    //序号
                    int zIndex = 1;
                    int no = 1;
                    int num = 0;
                    StringBuilder st = new StringBuilder();
                    foreach (var info in ExportList)
                    {
                        if (num > 2 && (ExportList[num - 3] == "经营活动资金流入" || ExportList[num - 3] == "经营活动资金流出"))
                        {
                            excelHelper.ExecuteCommand("INSERT INTO [项目资金变动] (序号, 项目, 发生额, 累计) VALUES ('','','','')");
                        }

                        if (no == 1)
                        {
                            no++;
                            st = new StringBuilder();
                            st.Append("INSERT INTO [项目资金变动] (序号, 项目, 发生额, 累计) VALUES (");
                            st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\",");
                        }
                        else if (no == 2)
                        {
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\",");
                            no++;
                        }
                        else
                        {
                            no = 1;
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\"");
                            st.Append(")");
                            excelHelper.ExecuteCommand(st.ToString());
                            zIndex++;
                        }
                        num++;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 导出资金盘存
        /// </summary>
        public void ExportCapitalInventoryXls(string filePath, List<string> ExportList)
        {
            #region 导出资金盘存
            if (ExportList.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "nvarchar(50)");
                    tableDefinition.Add("名称", "nvarchar(50)");
                    tableDefinition.Add("期初余额", "nvarchar(50)");
                    tableDefinition.Add("收入", "nvarchar(50)");
                    tableDefinition.Add("支出", "nvarchar(50)");
                    tableDefinition.Add("期末余额", "nvarchar(50)");
                    excelHelper.WriteTable("资金盘存", tableDefinition);
                    //序号
                    int zIndex = 1;
                    int no = 1;
                    StringBuilder st = new StringBuilder();
                    foreach (var info in ExportList)
                    {
                        if (no == 1)
                        {
                            no++;
                            st = new StringBuilder();
                            st.Append("INSERT INTO [资金盘存] (序号, 名称, 期初余额, 收入, 支出, 期末余额) VALUES (");
                            st.Append('"'); st.Append(zIndex.ToString()); st.Append("\",");
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\",");
                        }
                        else if (no == 2)
                        {
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\",");
                            no++;
                        }
                        else if (no == 3)
                        {
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\",");
                            no++;
                        }
                        else if (no == 4)
                        {
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\",");
                            no++;
                        }
                        else
                        {
                            no = 1;
                            st.Append('"'); st.Append(info == null ? "" : info); st.Append("\"");
                            st.Append(")");
                            excelHelper.ExecuteCommand(st.ToString());
                            zIndex++;
                        }
                    }
                }
            }
            #endregion
        }

        #endregion

        //根据项目ID 和 部门ID 查询字段 自动导出预算录入模板
        public void ExportFinancialFieldCostExcel(string filePath, int projectID, int depID)
        {
            if (projectID != 0)
            {
                string includefields = "";
                var fields = IoC.Resolve<IXMIncludeFieldsService>().GetXMIncludeFieldsListByProjectID(projectID);
                if (fields != null && fields.Fields != null)
                {
                    includefields = fields.Fields;
                }
                string[] parm = includefields.Split(',');
                string pID = "";              //父节点ID
                string cID = "";              //子节点ID
                if (parm != null && parm.Count() > 0)
                {
                    foreach (string id in parm)
                    {
                        var f = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(id));
                        if (f != null)
                        {
                            if (f.ParentID == 0)
                            {
                                pID += f.Id + ",";
                            }
                            else
                            {
                                cID += f.Id + ",";
                            }
                        }
                    }
                }
                if (pID != "" && pID.Length > 0)
                {
                    pID = pID.Substring(0, pID.Length - 1);
                }
                if (cID != "" && cID.Length > 0)
                {
                    cID = cID.Substring(0, cID.Length - 1);
                }
                string[] p = pID.Split(',');
                string[] c = cID.Split(',');
                if (p != null && p.Length > 0)
                {
                    using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                    {
                        excelHelper.Hdr = "YES";
                        excelHelper.Imex = "0";
                        Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                        tableDefinition.Add("字段ID", "nvarchar(50)");
                        tableDefinition.Add("项目", "nvarchar(50)");
                        tableDefinition.Add("1月份", "nvarchar(50)");
                        tableDefinition.Add("2月份", "nvarchar(50)");
                        tableDefinition.Add("3月份", "nvarchar(50)");
                        tableDefinition.Add("4月份", "nvarchar(50)");
                        tableDefinition.Add("5月份", "nvarchar(50)");
                        tableDefinition.Add("6月份", "nvarchar(50)");
                        tableDefinition.Add("7月份", "nvarchar(50)");
                        tableDefinition.Add("8月份", "nvarchar(50)");
                        tableDefinition.Add("9月份", "nvarchar(50)");
                        tableDefinition.Add("10月份", "nvarchar(50)");
                        tableDefinition.Add("11月份", "nvarchar(50)");
                        tableDefinition.Add("12月份", "nvarchar(50)");
                        excelHelper.WriteTable("字段预算录入", tableDefinition);

                        for (int j = 0; j < p.Count(); j++)
                        {
                            StringBuilder st = new StringBuilder();
                            var f = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(p[j]));
                            st.Append("INSERT INTO [字段预算录入] (字段ID,项目, 1月份,2月份,3月份, 4月份, 5月份, 6月份,7月份,8月份, 9月份, 10月份, 11月份,12月份) VALUES (");
                            st.Append('"'); st.Append(p[j]); st.Append("\",");
                            if (f != null)
                            {
                                st.Append('"'); st.Append(f.FieldName); st.Append("\",");
                            }
                            for (int i = 1; i <= 11; i++)
                            {
                                st.Append('"'); st.Append(""); st.Append("\",");
                            }
                            st.Append('"'); st.Append(""); st.Append("\"");
                            st.Append(")");
                            excelHelper.ExecuteCommand(st.ToString());


                            string newStr = string.Empty;
                            var f1 = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldByParentID(int.Parse(p[j]));
                            if (f1 != null)
                            {
                                foreach (XMFinancialField q in f1)
                                {
                                    newStr += q.Id + ",";
                                }
                            }
                            if (!string.IsNullOrEmpty(newStr) && newStr.Length > 0)
                            {
                                newStr = newStr.Substring(0, newStr.Length - 1);
                            }
                            foreach (string childID in c)
                            {
                                StringBuilder st2 = new StringBuilder();
                                foreach (string str1 in newStr.Split(','))
                                {
                                    if (childID == str1)               //存在该子节点
                                    {
                                        st2.Append("INSERT INTO [字段预算录入] (字段ID,项目, 1月份,2月份,3月份, 4月份, 5月份, 6月份,7月份,8月份, 9月份, 10月份, 11月份,12月份) VALUES (");
                                        var childf = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(childID));
                                        st2.Append('"'); st2.Append(childID); st2.Append("\",");
                                        if (childf != null)
                                        {
                                            st2.Append('"'); st2.Append(childf.FieldName); st2.Append("\",");
                                        }
                                        for (int i = 1; i <= 11; i++)
                                        {
                                            st2.Append('"'); st2.Append(""); st2.Append("\",");
                                        }
                                        st2.Append('"'); st2.Append(""); st2.Append("\"");
                                        st2.Append(")");
                                        excelHelper.ExecuteCommand(st2.ToString());
                                    }
                                }
                            }

                        }
                    }

                }

            }

            if (depID != 0)
            {
                string includefields = "";
                var fields = IoC.Resolve<IXMIncludeFieldsService>().GetXMIncludeFieldsListByDepartmentID(depID);
                if (fields != null && fields.Fields != null)
                {
                    includefields = fields.Fields;
                }
                string[] parm = includefields.Split(',');
                string pID = "";              //父节点ID
                string cID = "";              //子节点ID
                if (parm != null && parm.Count() > 0)
                {
                    foreach (string id in parm)
                    {
                        var f = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(id));
                        if (f != null)
                        {
                            if (f.ParentID == 0)
                            {
                                pID += f.Id + ",";
                            }
                            else
                            {
                                cID += f.Id + ",";
                            }
                        }
                    }
                }
                if (pID != "" && pID.Length > 0)
                {
                    pID = pID.Substring(0, pID.Length - 1);
                }
                if (cID != "" && cID.Length > 0)
                {
                    cID = cID.Substring(0, cID.Length - 1);
                }
                string[] p = pID.Split(',');
                string[] c = cID.Split(',');
                if (p != null && p.Length > 0)
                {
                    using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                    {
                        excelHelper.Hdr = "YES";
                        excelHelper.Imex = "0";
                        Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                        tableDefinition.Add("字段ID", "nvarchar(50)");
                        tableDefinition.Add("项目", "nvarchar(50)");
                        tableDefinition.Add("1月份", "nvarchar(50)");
                        tableDefinition.Add("2月份", "nvarchar(50)");
                        tableDefinition.Add("3月份", "nvarchar(50)");
                        tableDefinition.Add("4月份", "nvarchar(50)");
                        tableDefinition.Add("5月份", "nvarchar(50)");
                        tableDefinition.Add("6月份", "nvarchar(50)");
                        tableDefinition.Add("7月份", "nvarchar(50)");
                        tableDefinition.Add("8月份", "nvarchar(50)");
                        tableDefinition.Add("9月份", "nvarchar(50)");
                        tableDefinition.Add("10月份", "nvarchar(50)");
                        tableDefinition.Add("11月份", "nvarchar(50)");
                        tableDefinition.Add("12月份", "nvarchar(50)");
                        excelHelper.WriteTable("字段预算录入", tableDefinition);

                        for (int j = 0; j < p.Count(); j++)
                        {
                            StringBuilder st = new StringBuilder();
                            var f = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(p[j]));
                            st.Append("INSERT INTO [字段预算录入] (字段ID,项目, 1月份,2月份,3月份, 4月份, 5月份, 6月份,7月份,8月份, 9月份, 10月份, 11月份,12月份) VALUES (");
                            st.Append('"'); st.Append(p[j]); st.Append("\",");
                            if (f != null)
                            {
                                st.Append('"'); st.Append(f.FieldName); st.Append("\",");
                            }
                            for (int i = 1; i <= 11; i++)
                            {
                                st.Append('"'); st.Append(""); st.Append("\",");
                            }
                            st.Append('"'); st.Append(""); st.Append("\"");
                            st.Append(")");
                            excelHelper.ExecuteCommand(st.ToString());


                            string newStr = string.Empty;
                            var f1 = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldByParentID(int.Parse(p[j]));
                            if (f1 != null)
                            {
                                foreach (XMFinancialField q in f1)
                                {
                                    newStr += q.Id + ",";
                                }
                            }
                            if (!string.IsNullOrEmpty(newStr) && newStr.Length > 0)
                            {
                                newStr = newStr.Substring(0, newStr.Length - 1);
                            }
                            foreach (string childID in c)
                            {
                                StringBuilder st2 = new StringBuilder();
                                foreach (string str1 in newStr.Split(','))
                                {
                                    if (childID == str1)               //存在该子节点
                                    {
                                        st2.Append("INSERT INTO [字段预算录入] (字段ID,项目, 1月份,2月份,3月份, 4月份, 5月份, 6月份,7月份,8月份, 9月份, 10月份, 11月份,12月份) VALUES (");
                                        var childf = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(childID));
                                        st2.Append('"'); st2.Append(childID); st2.Append("\",");
                                        if (childf != null)
                                        {
                                            st2.Append('"'); st2.Append(childf.FieldName); st2.Append("\",");
                                        }
                                        for (int i = 1; i <= 11; i++)
                                        {
                                            st2.Append('"'); st2.Append(""); st2.Append("\",");
                                        }
                                        st2.Append('"'); st2.Append(""); st2.Append("\"");
                                        st2.Append(")");
                                        excelHelper.ExecuteCommand(st2.ToString());
                                    }
                                }
                            }

                        }
                    }

                }
            }
        }

        //唯品会物流导出
        public void ExportVPHLogisticsToXls(string filePath, List<XMLogisticsInfo> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("唯品会订单号", "nvarchar(50)");
                tableDefinition.Add("承运商名称", "nvarchar(50)");
                tableDefinition.Add("运单号", "nvarchar(50)");
                tableDefinition.Add("跟踪状态", "nvarchar(50)");
                tableDefinition.Add("状态发生时间", "nvarchar(50)");
                tableDefinition.Add("操作人", "nvarchar(50)");
                tableDefinition.Add("当前位置", "nvarchar(50)");
                tableDefinition.Add("签收人", "nvarchar(50)");
                tableDefinition.Add("描述", "nvarchar(50)");
                //tableDefinition.Add(" ", "nvarchar(50)");
                //tableDefinition.Add("说明：", "nvarchar(50)");
                //tableDefinition.Add("1、黄色部分为必填项", "nvarchar(50)");
                excelHelper.WriteTable("运输单跟踪表", tableDefinition);

                foreach (XMLogisticsInfo Info in list)
                {
                    StringBuilder st = new StringBuilder();
                    st.Append("INSERT INTO [运输单跟踪表] (唯品会订单号, 承运商名称, 运单号, 跟踪状态, 状态发生时间, 操作人, 当前位置, 签收人, 描述) VALUES (");
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(Info.OrderInfoID);
                    st.Append("'"); st.Append(OrderInfo.OrderCode); st.Append("',");
                    st.Append("'"); st.Append(Info.LogisticsCompany); st.Append("',");
                    st.Append("'"); st.Append(Info.LogisticsNumber); st.Append("',");
                    st.Append("'"); st.Append(Info.Note.IndexOf("草签") != -1 ? "完成" : "在途"); st.Append("',");
                    st.Append("'"); st.Append(((DateTime)Info.CreateDate).ToString("yyyy-MM-dd HH:mm:ss")); st.Append("',");
                    st.Append("'"); st.Append(Info.LogisticsCompany); st.Append("',");
                    st.Append("'"); st.Append(""); st.Append("',");
                    st.Append("'"); st.Append(Info.Note.IndexOf("草签") != -1 ? "草签" : ""); st.Append("',");
                    st.Append("'"); st.Append(Info.Note); st.Append("'");
                    //st.Append("'"); st.Append(""); st.Append("',");
                    //st.Append("'"); st.Append(""); st.Append("',");
                    //st.Append("'"); st.Append(""); st.Append("'");
                    st.Append(")");
                    excelHelper.ExecuteCommand(st.ToString());

                    Info.IsExport = true;
                    Info.UpdateTime = DateTime.Now;
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    IoC.Resolve<IXMLogisticsInfoService>().UpdateXMLogisticsInfo(Info);
                }
            }
        }

        //手动发货导出
        public void DeliverExportList(string filePath, List<XMDeliveryNew> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                //订单信息
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("发货单号", "nvarchar(50)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("平台", "nvarchar(150)");
                tableDefinition.Add("姓名", "nvarchar(150)");
                tableDefinition.Add("旺旺号", "nvarchar(150)");
                tableDefinition.Add("物流单号", "nvarchar(50)");
                tableDefinition.Add("物流公司", "nvarchar(50)");
                tableDefinition.Add("买家备注", "nvarchar(200)");
                tableDefinition.Add("卖家备注", "nvarchar(200)");
                tableDefinition.Add("产品编码", "nvarchar(50)");
                excelHelper.WriteTable("手动发货", tableDefinition);

                foreach (XMDeliveryNew Info in list)
                {
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Info.OrderCode);
                    if (OrderInfo != null)
                    {
                        StringBuilder st = new StringBuilder();
                        st.Append("INSERT INTO [手动发货] (发货单号, 订单号, 平台, 姓名, 旺旺号, 物流单号, 物流公司, 买家备注, 卖家备注, 产品编码) VALUES (");
                        st.Append("'"); st.Append(Info.DeliveryNumber); st.Append("',");
                        st.Append("'"); st.Append(Info.OrderCode); st.Append("',");
                        st.Append("'"); st.Append(OrderInfo.PlatformName); st.Append("',");
                        st.Append("'"); st.Append(Info.FullName); st.Append("',");
                        st.Append("'"); st.Append(OrderInfo.WantID); st.Append("',");
                        st.Append("'"); st.Append(Info.LogisticsNumber); st.Append("',");
                        st.Append("'"); st.Append(Info.LogisticsCompany); st.Append("',");
                        st.Append("'"); 
                        if(OrderInfo.Remark!=null&& OrderInfo.Remark.Length>200)
                        {
                            st.Append(OrderInfo.Remark.Substring(0, 200));
                        }
                        else
                        {
                            st.Append(OrderInfo.Remark);
                        }
                        st.Append("',");

                        st.Append("'");
                        if (OrderInfo.CustomerServiceRemark != null && OrderInfo.CustomerServiceRemark.Length > 3)
                        {
                            st.Append(OrderInfo.CustomerServiceRemark.Substring(0, 4));
                        }
                        else
                        {
                            st.Append(OrderInfo.CustomerServiceRemark);
                        }
                        st.Append("',");

                        //var Details = IoC.Resolve<IXMDeliveryDetailsService>().GetXMDeliveryDetailsByDeliveryId(Info.Id);
                        //if (Details != null && Details.Count > 0)
                        //{
                        //    foreach (var item in Details)
                        //    {
                                var ProductDetails = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(Info.PlatformMerchantCode);
                                if (ProductDetails != null && ProductDetails.Count > 0)
                                {
                                    var Product = IoC.Resolve<IXMProductService>().GetXMProductById((int)ProductDetails[0].ProductId);
                                    if (Product != null)
                                    {
                                        string str = "'" + Product.ManufacturersCode + "')";
                                        excelHelper.ExecuteCommand(st.ToString() + str);
                                    }
                                }
                        //    }
                        //}
                        //st.Append(")");
                        //excelHelper.ExecuteCommand(st.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="expressListManagement"></param>
        public void ExportExpressList(string filePath, List<XMNewExpressListManage> expressListManagement)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("年份", "nvarchar(50)");
                tableDefinition.Add("月份", "nvarchar(50)");
                tableDefinition.Add("单号", "nvarchar(50)");
                tableDefinition.Add("快递公司", "nvarchar(50)");
                tableDefinition.Add("平台", "nvarchar(50)");
                tableDefinition.Add("费用", "nvarchar(50)");
                excelHelper.WriteTable("快递账单", tableDefinition);
                foreach (var Info in expressListManagement)
                {
                    string expressName = "";
                    string platformName = "";
                    var LogisticCompany = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(Info.ExpressID.ToString());//快递公司
                    if (LogisticCompany != null)
                    {
                        expressName = LogisticCompany.LogisticsName;
                        var platFormTypeList = IoC.Resolve<ICodeService>().GetCodeList(LogisticCompany.PlatformTypeId.Value);
                        if (platFormTypeList.Count > 0)
                        {
                            platformName = platFormTypeList[0].CodeName;
                        }
                    }
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [快递账单] (年份, 月份, 单号,快递公司,平台, 费用) VALUES (");
                    sb.Append("'"); sb.Append(Info.Year); sb.Append("',");
                    sb.Append("'"); sb.Append(Info.Month); sb.Append("',");
                    sb.Append("'"); sb.Append(Info.Number); sb.Append("',");
                    sb.Append("'"); sb.Append(expressName); sb.Append("',");
                    sb.Append("'"); sb.Append(platformName); sb.Append("',");
                    sb.Append("'"); sb.Append(Info.Cost); sb.Append("'");
                    sb.Append(")");
                    excelHelper.ExecuteCommand(sb.ToString());
                }
            }
        }
        /// <summary>
        /// 导出快递账单信息excel表格
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="expressListManage"></param>
        public void ExpressListManage(string filePath, List<XMExpressListManagement> expressListManage)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("部门", "nvarchar(50)");
                tableDefinition.Add("项目", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("单号", "nvarchar(50)");
                tableDefinition.Add("寄件时间", "nvarchar(50)");
                tableDefinition.Add("寄件人", "nvarchar(50)");
                tableDefinition.Add("收件人", "nvarchar(50)");
                tableDefinition.Add("收件地址", "nvarchar(50)");
                tableDefinition.Add("联系电话", "nvarchar(50)");
                tableDefinition.Add("价格", "nvarchar(50)");
                excelHelper.WriteTable("快递账单", tableDefinition);
                foreach (var Info in expressListManage)
                {
                    string departmentName = "";
                    string projectName = "";
                    string nickName = "";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [快递账单] (部门,项目,店铺,单号,寄件时间,寄件人,收件人,收件地址,联系电话,价格) VALUES (");
                    if (!string.IsNullOrEmpty(Info.Number))
                    {
                        var deliveryInfo = IoC.Resolve<XMDeliveryService>().GetXMDeliveryListByLogisticsNumber(Info.Number);
                        if (deliveryInfo != null && deliveryInfo.Count > 0)    //查询发货单 该物流单号存在
                        {
                            string ordercode = "";
                            if (deliveryInfo[0].OrderCode != null) 
                            {
                                ordercode = deliveryInfo[0].OrderCode;
                            }
                            if (!ordercode.Contains("NoOrder"))      //未包含NoOrder字样 为正常订单
                            {
                                var orderInfo = IoC.Resolve<XMOrderInfoService>().GetXMOrderByOrderCode2(ordercode);
                                if (orderInfo != null && orderInfo.Count > 0)
                                {
                                    if (orderInfo[0].NickID != null)
                                    {
                                        var nicks = IoC.Resolve<XMNickService>().GetXMNickByID(int.Parse(orderInfo[0].NickID.ToString()));
                                        if (nicks != null)
                                        {
                                            if (nicks.nick != null)
                                                nickName = nicks.nick;
                                            if (nicks.ProjectName != null)
                                                projectName = nicks.ProjectName;
                                            var projectInfo = IoC.Resolve<XMProjectService>().GetXMProjectById(int.Parse(nicks.ProjectId.ToString()));
                                            if (projectInfo != null)
                                            {
                                                var enterprises = IoC.Resolve<EnterpriseService>().GetDepartmentById(int.Parse(projectInfo.DepartmentID.ToString()));
                                                if (enterprises != null)
                                                {
                                                    if (enterprises.DepName != null)
                                                        departmentName = enterprises.DepName;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //无订单的情况
                                var paramXMPremiumsList = IoC.Resolve<XMPremiumsService>().GetXMPremiumsListByOrderCode(deliveryInfo[0].OrderCode, -1);
                                if (paramXMPremiumsList != null && paramXMPremiumsList.Count > 0)
                                {
                                    var nicks = IoC.Resolve<XMNickService>().GetXMNickByID(int.Parse(paramXMPremiumsList[0].NoOrderNickId.ToString()));
                                    if (nicks != null)
                                    {
                                        if (nicks.nick != null)
                                            nickName = nicks.nick;
                                        if (nicks.ProjectName != null)
                                            projectName = nicks.ProjectName;
                                        var projectInfo = IoC.Resolve<XMProjectService>().GetXMProjectById(int.Parse(nicks.ProjectId.ToString()));
                                        if (projectInfo != null)
                                        {
                                            var enterprises = IoC.Resolve<EnterpriseService>().GetDepartmentById(int.Parse(projectInfo.DepartmentID.ToString()));
                                            if (enterprises != null)
                                            {
                                                if (enterprises.DepName != null)
                                                    departmentName = enterprises.DepName;
                                            }
                                        }
                                    }
                                }
                            }
                            sb.Append("'"); sb.Append(departmentName); sb.Append("',");
                            sb.Append("'"); sb.Append(projectName); sb.Append("',");
                            sb.Append("'"); sb.Append(nickName); sb.Append("',");
                            sb.Append("'"); sb.Append(deliveryInfo[0].LogisticsNumber != null ? deliveryInfo[0].LogisticsNumber : ""); sb.Append("',");
                            sb.Append("'"); sb.Append(deliveryInfo[0].PrintDateTime != null ? deliveryInfo[0].PrintDateTime.ToString() : ""); sb.Append("',");
                            sb.Append("'"); sb.Append(""); sb.Append("',");
                            sb.Append("'"); sb.Append(deliveryInfo[0].FullName != null ? deliveryInfo[0].FullName : ""); sb.Append("',");
                            sb.Append("'"); sb.Append(deliveryInfo[0].DeliveryAddress != null ? deliveryInfo[0].DeliveryAddress : ""); sb.Append("',");
                            sb.Append("'"); sb.Append(deliveryInfo[0].Mobile != null ? deliveryInfo[0].Mobile : ""); sb.Append("',");

                        }
                        else
                        {
                            //发货单中不存在 去快递管理数据中查询
                            var expressInfo = IoC.Resolve<XMExpressManagementService>().GetXMExpressManagementListByCourierNumber(Info.Number);
                            if (expressInfo != null && expressInfo.Count > 0)     //查询快递单号 该物流单号存在
                            {
                                if (expressInfo[0].DepartmentID != null)
                                {
                                    var enterprises = IoC.Resolve<EnterpriseService>().GetDepartmentById(expressInfo[0].DepartmentID.Value);
                                    if (enterprises != null)
                                    {
                                        if (enterprises.DepName != null)
                                        departmentName = enterprises.DepName;
                                    }
                                }
                                sb.Append("'"); sb.Append(departmentName); sb.Append("',");
                                sb.Append("'"); sb.Append(projectName); sb.Append("',");
                                sb.Append("'"); sb.Append(nickName); sb.Append("',");
                                sb.Append("'"); sb.Append(expressInfo[0].CourierNumber != null ? expressInfo[0].CourierNumber : ""); sb.Append("',");
                                sb.Append("'"); sb.Append(expressInfo[0].SendDate != null ? expressInfo[0].SendDate.ToString() : ""); sb.Append("',");
                                sb.Append("'"); sb.Append(expressInfo[0].SenderName != null ? expressInfo[0].SenderName : ""); sb.Append("',");
                                sb.Append("'"); sb.Append(expressInfo[0].ReceivingName != null ? expressInfo[0].ReceivingName : ""); sb.Append("',");
                                sb.Append("'"); sb.Append(expressInfo[0].Address != null ? expressInfo[0].Address : ""); sb.Append("',");
                                sb.Append("'"); sb.Append(expressInfo[0].ReceivingTel != null ? expressInfo[0].ReceivingTel : ""); sb.Append("',");
                            }
                            else                                        //发货单和快递单管理中都不存在   
                            {
                                sb.Append("'"); sb.Append(departmentName); sb.Append("',");
                                sb.Append("'"); sb.Append(projectName); sb.Append("',");
                                sb.Append("'"); sb.Append(nickName); sb.Append("',");
                                sb.Append("'"); sb.Append(Info.Number); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                                sb.Append("'"); sb.Append(""); sb.Append("',");
                            }
                        }
                    }

                    sb.Append("'"); sb.Append(Info.Cost == null ? 0 : Info.Cost); sb.Append("'");
                    sb.Append(")");
                    excelHelper.ExecuteCommand(sb.ToString());
                }
            }
        }

        /// <summary>
        /// 理赔管理导出数据
        /// </summary>
        public void ExportClaimInfoToXls(string filePath, List<XMClaimInfo> list)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("理赔确认日期", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("订单号", "nvarchar(50)");
                tableDefinition.Add("物流单号", "nvarchar(50)");
                tableDefinition.Add("产品名称", "nvarchar(50)");
                tableDefinition.Add("数量", "nvarchar(50)");
                tableDefinition.Add("订单金额", "nvarchar(50)");
                tableDefinition.Add("理赔金额", "nvarchar(50)");
                tableDefinition.Add("原因", "nvarchar(50)");
                tableDefinition.Add("货物处理方式", "nvarchar(50)");
                tableDefinition.Add("理赔方", "nvarchar(50)");
                tableDefinition.Add("受损情况", "nvarchar(50)");

                excelHelper.WriteTable("Sheet1", tableDefinition);

                foreach (var Info in list)
                {
                    int no = 1;
                    string ProjectName = "";
                    string NickName = "";
                    string ProductStr = "";
                    int TotalCount = 0;
                    decimal PayPrice = 0;

                    if (Info.NickId != null)
                    {
                        var nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)Info.NickId);
                        if (nick != null)
                        {
                            ProjectName = nick.ProjectName.ToString();
                            NickName = nick.nick.ToString();
                        }
                    }

                    var ProductDetails = IoC.Resolve<IXMClaimInfoProductDetailsService>().GetXMClaimInfoProductDetailsListByClaimInfoID(Info.Id);
                    if (ProductDetails != null && ProductDetails.Count > 0)
                    {
                        foreach (var product in ProductDetails)
                        {
                            ProductStr += product.PrdouctName + "*" + product.ProductNum + ",";
                            TotalCount += (int)product.ProductNum;
                        }
                        if (ProductStr != "")
                        {
                            ProductStr = ProductStr.Substring(0, ProductStr.Length - 1);
                        }
                    }

                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Info.OrderCode);
                    if (OrderInfo != null)
                    {
                        PayPrice = OrderInfo.PayPrice == null ? 0 : (decimal)OrderInfo.PayPrice;
                    }

                    //订单信息
                    var DetailList = IoC.Resolve<IXMClaimInfoDetailService>().GetXMClaimInfoDetailListByClaimInfoID(Info.Id);
                    if (DetailList != null && DetailList.Count > 0)
                    {
                        foreach (var detail in DetailList)
                        {
                            StringBuilder sb = new StringBuilder();
                            string value = "";
                            sb.Append("INSERT INTO [Sheet1] (理赔确认日期, 店铺, 订单号, 物流单号, 产品名称, 数量, 订单金额, 理赔金额, 原因, 货物处理方式, 理赔方, 受损情况) VALUES (");

                            sb.Append("'"); sb.Append(detail.ConfirmDate == null ? value : ((DateTime)detail.ConfirmDate).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("',");
                            if (no == 1)
                            {
                                sb.Append("'"); sb.Append(NickName); sb.Append("',");
                                sb.Append("'"); sb.Append(Info.OrderCode == null ? value : Info.OrderCode); sb.Append("',");
                                sb.Append("'"); sb.Append(Info.LogisticsNumber == null ? value : Info.LogisticsNumber); sb.Append("',");
                                sb.Append("'"); sb.Append(ProductStr); sb.Append("',");
                                sb.Append("'"); sb.Append(TotalCount); sb.Append("',");
                                sb.Append("'"); sb.Append(PayPrice); sb.Append("',");
                            }
                            else
                            {
                                sb.Append("'','','','','','',");
                            }
                            sb.Append("'"); sb.Append(detail.ClaimAcount == null ? "0" : detail.ClaimAcount.ToString()); sb.Append("',");
                            sb.Append("'"); sb.Append(detail.Reason == null ? value : detail.Reason); sb.Append("',");
                            if (no == 1)
                            {
                                sb.Append("'"); sb.Append(Info.IsReturn == true ? "退货" : "不退货"); sb.Append("',");
                            }
                            else
                            {
                                sb.Append("'',");
                            }
                            sb.Append("'"); sb.Append(detail.CodeName); sb.Append("',");
                            sb.Append("'"); sb.Append(detail.DamagedConditionName); sb.Append("'");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());

                            no++;
                        }
                    }
                }
            }
        }

        //发出商品库存
        public void DeliveryProductInventoryExportList(string filePath, List<XMDeliveryProductInventory> list, string ProjectName)
        {
            using (ExcelHelper excelHelper = new ExcelHelper(filePath))
            {
                excelHelper.Hdr = "YES";
                excelHelper.Imex = "0";

                //订单信息
                Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                tableDefinition.Add("项目", "nvarchar(50)");
                tableDefinition.Add("店铺", "nvarchar(50)");
                tableDefinition.Add("时间", "nvarchar(50)");
                tableDefinition.Add("厂家编码", "nvarchar(50)");
                tableDefinition.Add("产品名称", "nvarchar(50)");
                tableDefinition.Add("尺寸", "nvarchar(50)");
                tableDefinition.Add("剩余库存", "nvarchar(50)");
                tableDefinition.Add("入库数量", "nvarchar(50)");
                tableDefinition.Add("入库金额", "nvarchar(50)");
                tableDefinition.Add("出库数量", "nvarchar(50)");
                tableDefinition.Add("出库金额", "nvarchar(50)");
                tableDefinition.Add("库存数量", "nvarchar(50)");
                tableDefinition.Add("库存金额", "nvarchar(50)");
                excelHelper.WriteTable("发出商品库存", tableDefinition);

                foreach (XMDeliveryProductInventory Info in list)
                {
                    StringBuilder st = new StringBuilder();
                    st.Append("INSERT INTO [发出商品库存] (项目, 店铺, 时间, 厂家编码, 产品名称, 尺寸,剩余库存, 入库数量, 入库金额, 出库数量, 出库金额, 库存数量, 库存金额) VALUES (");
                    st.Append("'"); st.Append(Info.ProjectId == -1 ? ProjectName : Info.ProjectName); st.Append("',");
                    st.Append("'"); st.Append(Info.NickName); st.Append("',");
                    st.Append("'"); st.Append(Info.Year.ToString() + "年" + Info.Month.ToString() + "月"); st.Append("',");
                    st.Append("'"); st.Append(Info.ManufacturersCode == null ? "" : Info.ManufacturersCode); st.Append("',");
                    st.Append("'"); st.Append(Info.ProductName); st.Append("',");
                    st.Append("'"); st.Append(Info.Specifications); st.Append("',");
                    st.Append("'"); st.Append(Info.SurplusInventory); st.Append("',");
                    st.Append("'"); st.Append(Info.StorageCount); st.Append("',");
                    st.Append("'"); st.Append(Info.StorageAmount); st.Append("',");
                    st.Append("'"); st.Append(Info.DeliveryCount); st.Append("',");
                    st.Append("'"); st.Append(Info.DeliveryAmount); st.Append("',");
                    st.Append("'"); st.Append(Info.InventoryCount); st.Append("',");
                    st.Append("'"); st.Append(Info.InventoryAmount); st.Append("'");
                    st.Append(")");
                    excelHelper.ExecuteCommand(st.ToString());
                }
            }
        }

        /// <summary>
        /// 导出京东自营退货单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public void ExportJDSaleRejectedExcel(string filePath, List<XMJDSaleRejectedExport> list)
        {
            if (list.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("退货单号", "nvarchar(50)");
                    tableDefinition.Add("项目", "nvarchar(50)");
                    tableDefinition.Add("店铺", "nvarchar(50)");
                    tableDefinition.Add("业务时间", "nvarchar(50)");
                    tableDefinition.Add("退货类型", "nvarchar(50)");
                    tableDefinition.Add("备注", "nvarchar(50)");
                    tableDefinition.Add("厂家编码", "nvarchar(50)");
                    tableDefinition.Add("商品名称", "nvarchar(50)");
                    tableDefinition.Add("尺寸规格", "nvarchar(50)");
                    tableDefinition.Add("退货数量", "numeric(18, 0)");
                    tableDefinition.Add("退货单价", "numeric(18, 4)");
                    tableDefinition.Add("退货金额", "numeric(18, 4)");
                    tableDefinition.Add("京东确认", "nvarchar(50)");
                    tableDefinition.Add("新邦确认", "nvarchar(50)");
                    tableDefinition.Add("喜临门确认", "nvarchar(50)");
                    excelHelper.WriteTable("京东自营退货单明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var item in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [京东自营退货单明细] (序号,退货单号, 项目,店铺,业务时间,退货类型,备注,厂家编码,商品名称,尺寸规格,退货数量,退货单价,退货金额,京东确认,新邦确认,喜临门确认) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Ref); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProjectName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.NickName); sb.Append("\",");
                        DateTime time = (DateTime)(item.Time);
                        sb.Append('"'); sb.Append(time == null?"": time.ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        //item.Time.ToString("yyyy-MM-dd HH:mm:ss")
                        sb.Append('"'); sb.Append(item.ReturnCategoryName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Note); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.PlatformMerchantCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProductName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.Specifications); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.RejectionCount==null?0: item.RejectionCount); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.RejectionPrice==null?0: item.RejectionPrice); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.RejectionMoney==null?0: item.RejectionMoney); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.JDIsConfirm==true? "是" : "否"); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.XBIsConfirm==true? "是" : "否"); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.XLMIsConfirm==true? "是" : "否"); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// 导出带物流费用的订单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportOrderInfoWithLogisticsFeeExcel(string filePath, List<XMOrderInfo> list)
        {
            var XMLogisticsFeeDetailService = IoC.Resolve<IXMLogisticsFeeDetailService>();
            var XMOrderInfoProductDetailsService = IoC.Resolve<IXMOrderInfoProductDetailsService>();
            if (list.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("发货时间", "nvarchar(50)");
                    tableDefinition.Add("订单编号", "nvarchar(50)");
                    tableDefinition.Add("店铺", "nvarchar(50)");
                    tableDefinition.Add("下单时间", "nvarchar(50)");
                    tableDefinition.Add("付款时间", "nvarchar(50)");
                    tableDefinition.Add("产品名称", "nvarchar(50)");
                    tableDefinition.Add("尺寸", "nvarchar(50)");
                    tableDefinition.Add("数量", "nvarchar(50)");
                    tableDefinition.Add("客户姓名", "nvarchar(50)");
                    tableDefinition.Add("地址", "nvarchar(50)");
                    tableDefinition.Add("联系方式", "nvarchar(50)");
                    tableDefinition.Add("物流费用", "numeric(18, 2)");
                    excelHelper.WriteTable("订单物流费用", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var item in list)
                    {
                        decimal fee = XMLogisticsFeeDetailService.getLogisticsFeeTotal(item.ID);
                        List<XMOrderInfoProductDetails> list_OrderInfoProductDetails = XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(item.ID);
                        foreach (var entity in list_OrderInfoProductDetails)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("INSERT INTO [订单物流费用] (序号,发货时间, 订单编号,店铺,下单时间,付款时间,产品名称,尺寸,数量,客户姓名,地址,联系方式,物流费用) VALUES (");
                            sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.DeliveryTime); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.OrderCode); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.NickName); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.OrderInfoCreateDate); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.PayDate); sb.Append("\",");
                            sb.Append('"'); sb.Append(entity.ProductName); sb.Append("\",");
                            sb.Append('"'); sb.Append(entity.Specifications); sb.Append("\",");
                            sb.Append('"'); sb.Append(entity.ProductNum); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.FullName); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.DeliveryAddress); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.Mobile); sb.Append("\",");
                            sb.Append('"'); sb.Append(fee); sb.Append("\"");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                            zIndex++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导出物流对账明细
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportLogisticsStatistics(string filePath, List<XMLogisticsProject> list)
        {
            list = list.OrderBy(a => a.DepID).ThenByDescending(a => a.ProjectID).ToList();

            if (list.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("部门名称", "nvarchar(50)");
                    tableDefinition.Add("项目名称", "nvarchar(50)");
                    tableDefinition.Add("包裹数量", "nvarchar(50)");
                    excelHelper.WriteTable("物流对账明细", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var item in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [物流对账明细] (序号,部门名称, 项目名称,包裹数量) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.DepName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.ProjectName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.PackageNum); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        public void ExportCashBackExcel(string filePath, List<XMCashBackApplication> list)
        {
            if (list.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("订单号", "nvarchar(50)");
                    tableDefinition.Add("旺旺号", "nvarchar(50)");
                    tableDefinition.Add("姓名", "nvarchar(50)");
                    tableDefinition.Add("申请类型", "nvarchar(50)");
                    tableDefinition.Add("收款账号", "nvarchar(50)");
                    tableDefinition.Add("赔付方", "nvarchar(50)");
                    tableDefinition.Add("金额", "nvarchar(50)");
                    tableDefinition.Add("创建时间", "nvarchar(50)");
                    tableDefinition.Add("返现状态", "nvarchar(50)");
                    tableDefinition.Add("项目审核", "nvarchar(50)");
                    tableDefinition.Add("财务审核", "nvarchar(50)");
                    tableDefinition.Add("更新时间", "nvarchar(50)");
                    excelHelper.WriteTable("返现信息", tableDefinition);
                    //序号
                    int zIndex = 1;
                    foreach (var item in list)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO [返现信息] (序号,订单号, 旺旺号,姓名,申请类型,收款账号,赔付方,金额,创建时间,返现状态,项目审核,财务审核,更新时间) VALUES (");
                        sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.OrderCode==null?"": item.OrderCode); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.WantNo==null?"": item.WantNo); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.BuyerName==null?"": item.BuyerName); sb.Append("\",");

                        if(item.ApplicationTypeId!=null)
                        {
                            if (item.ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildCashBack))
                            {
                                sb.Append('"'); sb.Append("返现"); sb.Append("\",");
                            }
                            else if(item.ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment))
                            {
                                sb.Append('"'); sb.Append("赔付"); sb.Append("\",");
                            }
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(item.BuyerAlipayNo == null ? "" : item.BuyerAlipayNo); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.PaymentPersonName == null ? "" : item.PaymentPersonName); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.CashBackMoney == null ? "" : item.CashBackMoney.ToString()); sb.Append("\",");
                        sb.Append('"'); sb.Append(item.CreateTime == null ? "" : ((DateTime)item.CreateTime).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");

                        if(item.CashBackStatus!=null)
                        {
                            if(item.CashBackStatus== Convert.ToInt32(StatusEnum.NotCashBack))
                            {
                                sb.Append('"'); sb.Append("未返现"); sb.Append("\",");
                            }
                            else if(item.CashBackStatus == Convert.ToInt32(StatusEnum.AlreadyCashBack))
                            {
                                sb.Append('"'); sb.Append("已返现"); sb.Append("\",");
                            }
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        if (item.ManagerStatus != null)
                        {
                            if(item.ManagerStatus== Convert.ToInt32(StatusEnum.NotCheck))
                            {
                                sb.Append('"'); sb.Append("未审核"); sb.Append("\",");
                            }
                            else if(item.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                            {
                                sb.Append('"'); sb.Append("已审核"); sb.Append("\",");
                            }
                        }
                        else
                        {
                            sb.Append('"'); sb.Append(""); sb.Append("\",");
                        }

                        if(item.FinanceIsAudit!=null)
                        {
                            if((bool)item.FinanceIsAudit)
                            {
                                sb.Append('"'); sb.Append("已审核"); sb.Append("\",");
                            }
                            else if(!(bool)item.FinanceIsAudit)
                            {
                                sb.Append('"'); sb.Append("未审核"); sb.Append("\",");
                            }
                        }
                        else
                        {
                            sb.Append('"'); sb.Append("未审核"); sb.Append("\",");
                        }

                        sb.Append('"'); sb.Append(item.UpdateTime!=null?"":((DateTime)item.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\"");
                        sb.Append(")");
                        excelHelper.ExecuteCommand(sb.ToString());
                        zIndex++;
                    }
                }
            }
        }

        public void ExportProductExcel(string filePath, List<XMProduct> list)
        {
            var XMProductDetailsService = IoC.Resolve<IXMProductDetailsService>();
            var CodeService = IoC.Resolve<ICodeService>();

            if (list.Count>0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("品牌", "nvarchar(250)");
                    tableDefinition.Add("发货方", "nvarchar(250)");
                    tableDefinition.Add("产品名称", "nvarchar(250)");
                    tableDefinition.Add("厂家编码", "nvarchar(250)");
                    tableDefinition.Add("尺寸", "nvarchar(250)");
                    tableDefinition.Add("系列", "nvarchar(250)");
                    tableDefinition.Add("厂家库存", "nvarchar(250)");
                    tableDefinition.Add("预警库存数", "nvarchar(250)");
                    tableDefinition.Add("颜色", "nvarchar(250)");
                    tableDefinition.Add("计量单位", "nvarchar(250)");
                    tableDefinition.Add("体重", "nvarchar(250)");
                    tableDefinition.Add("体积", "nvarchar(250)");
                    tableDefinition.Add("是否赠品", "nvarchar(250)");
                    tableDefinition.Add("平台类型", "nvarchar(250)");
                    tableDefinition.Add("商品编码", "nvarchar(250)");
                    tableDefinition.Add("明细颜色", "nvarchar(250)");
                    tableDefinition.Add("产品类型", "nvarchar(250)");
                    tableDefinition.Add("平台库存", "nvarchar(250)");
                    tableDefinition.Add("链接", "nvarchar(250)");
                    tableDefinition.Add("出厂价", "nvarchar(250)");
                    tableDefinition.Add("销售价", "nvarchar(250)");
                    tableDefinition.Add("特供价", "nvarchar(250)");
                    tableDefinition.Add("开始日期", "nvarchar(250)");
                    tableDefinition.Add("结束日期", "nvarchar(250)");
                    tableDefinition.Add("主推", "nvarchar(250)");
                    excelHelper.WriteTable("商品列表", tableDefinition);
                    //序号
                    int zIndex = 1;
                    int test = 1;
                    foreach(var item in list)
                    {
                        List<XMProductDetails> list_ProductDetails = XMProductDetailsService.GetXMProductDetailsListByProductId(item.Id);
                        CodeList entity_CodeList = CodeService.GetCodeListInfoByCodeID((int)item.BrandTypeId);

                        if(test==274)
                        {
                            int i = 0;
                        }

                        try
                        {
                            foreach (var entity in list_ProductDetails)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("INSERT INTO [商品列表] (序号,品牌,发货方,产品名称,厂家编码,尺寸,系列,厂家库存,预警库存数,颜色,计量单位,体重,体积,是否赠品,平台类型,商品编码,明细颜色,产品类型,平台库存,链接,出厂价,销售价,特供价,开始日期,结束日期,主推) VALUES (");
                                sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity_CodeList == null ? "" : entity_CodeList.CodeName); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ShipperName == null ? "" : item.ShipperName); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ProductName == null ? "" : item.ProductName); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ManufacturersCode == null ? "" : item.ManufacturersCode); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.Specifications == null ? "" : item.Specifications); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.Series == null ? "" : item.Series); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ManufacturersInventory == null ? 0 : item.ManufacturersInventory); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.WarningQuantity == null ? 0 : item.WarningQuantity); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ProductColors == null ? "" : item.ProductColors); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ProductUnit == null ? "" : item.ProductUnit); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ProductWeight == null ? "" : item.ProductWeight); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.ProductVolume == null ? "" : item.ProductVolume); sb.Append("\",");
                                sb.Append('"'); sb.Append(item.IsPremiums == null ? "否" : (bool)item.IsPremiums ? "是" : "否"); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.PlatformTypeName.CodeName); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.PlatformMerchantCode); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.Color==null?"": entity.Color); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.ProductTypeCodeName==null?"": entity.ProductTypeCodeName.CodeName); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? 0 : entity.PlatformInventory == null ? 0 : entity.PlatformInventory); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.strUrl.Length > 250 ? entity.strUrl.Substring(0, 250) : entity.strUrl); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? 0 : entity.Costprice == null ? 0 : entity.Costprice); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? 0 : entity.Saleprice == null ? 0 : entity.Saleprice); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? 0 : entity.TCostprice == null ? 0 : entity.TCostprice); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.TDateTimeStart == null ? "" : ((DateTime)entity.TDateTimeStart).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "" : entity.TDateTimeEnd == null ? "" : ((DateTime)entity.TDateTimeEnd).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                                sb.Append('"'); sb.Append(entity == null ? "否" : entity.IsMainPush == null ? "否" : (bool)entity.IsMainPush ? "是" : "否"); sb.Append("\"");
                                sb.Append(")");
                                excelHelper.ExecuteCommand(sb.ToString());
                                zIndex++;
                            }
                        }
                        catch(Exception ex)
                        {
                            throw new Exception(test.ToString());
                        }

                        test++;

                        //foreach(var entity in list_ProductDetails)
                        //{
                        //    StringBuilder sb = new StringBuilder();
                        //    sb.Append("INSERT INTO [商品列表] (序号,品牌,发货方,产品名称,厂家编码,尺寸,系列,厂家库存,预警库存数,颜色,计量单位,体重,体积,是否赠品,平台类型,商品编码,明细颜色,产品类型,平台库存,链接,出厂价,销售价,特供价,开始日期,结束日期,主推) VALUES (");
                        //    sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity_CodeList == null ? "" : entity_CodeList.CodeName); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ShipperName==null?"": item.ShipperName); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ProductName==null?"": item.ProductName); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ManufacturersCode==null?"": item.ManufacturersCode); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.Specifications==null?"": item.Specifications); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.Series==null?"": item.Series); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ManufacturersInventory == null ? 0 : item.ManufacturersInventory); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.WarningQuantity == null ? 0 : item.WarningQuantity); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ProductColors==null?"": item.ProductColors); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ProductUnit==null?"": item.ProductUnit); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ProductWeight==null?"": item.ProductWeight); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.ProductVolume==null?"": item.ProductVolume); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(item.IsPremiums == null ? "否" : (bool)item.IsPremiums ? "是" : "否"); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.PlatformTypeName.CodeName); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.PlatformMerchantCode); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.Color); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.ProductTypeCodeName.CodeName); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? 0 : entity.PlatformInventory == null ? 0 : entity.PlatformInventory); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.strUrl.Length>250? entity.strUrl.Substring(0,250): entity.strUrl); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? 0 : entity.Costprice == null ? 0 : entity.Costprice); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? 0 : entity.Saleprice == null ? 0 : entity.Saleprice); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? 0 : entity.TCostprice == null ? 0 : entity.TCostprice); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.TDateTimeStart == null ? "" : ((DateTime)entity.TDateTimeStart).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "" : entity.TDateTimeEnd == null ? "" : ((DateTime)entity.TDateTimeEnd).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\",");
                        //    sb.Append('"'); sb.Append(entity == null ? "否" : entity.IsMainPush == null ? "否" : (bool)entity.IsMainPush ? "是" : "否"); sb.Append("\"");
                        //    sb.Append(")");
                        //    excelHelper.ExecuteCommand(sb.ToString());
                        //    zIndex++;
                        //}
                    }
                }
            }
        }
        /// <summary>
        /// 导出账单信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public void ExportXMBills(string filePath, List<XMBills> list)
        {
            var XMProductDetailsService = IoC.Resolve<IXMProductDetailsService>();
            var CodeService = IoC.Resolve<ICodeService>();
            var SuppliersService = IoC.Resolve<IXMSuppliersService>();
            var statusDic = CodeService.GetCodeListInfoByCodeTypeID(247).ToDictionary(m=>m.CodeNO,m=>m.CodeName);
            var suppliersDic = SuppliersService.GetXMSuppliersList().ToDictionary(m=>m.Id,m=>m.SupplierName);
            if (list.Count > 0)
            {
                using (ExcelHelper excelHelper = new ExcelHelper(filePath))
                {
                    excelHelper.Hdr = "YES";
                    excelHelper.Imex = "0";
                    Dictionary<string, string> tableDefinition = new Dictionary<string, string>();
                    tableDefinition.Add("序号", "int");
                    tableDefinition.Add("发货单号", "nvarchar(250)");
                    tableDefinition.Add("商品编码", "nvarchar(250)");
                    tableDefinition.Add("数量", "nvarchar(250)");
                    tableDefinition.Add("价格", "nvarchar(250)");
                    tableDefinition.Add("供应商", "nvarchar(250)");
                    tableDefinition.Add("核销状态", "nvarchar(250)");
                    tableDefinition.Add("导入日期", "nvarchar(250)");;
                    excelHelper.WriteTable("账单", tableDefinition);
                    //序号
                    int zIndex = 1;
                    int test = 1;
                    foreach (var item in list)
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("INSERT INTO [账单] (序号,发货单号,商品编码,数量,价格,供应商,核销状态,导入日期) VALUES (");
                            sb.Append('"'); sb.Append(zIndex); sb.Append("\",");
                            sb.Append('"'); sb.Append(string.IsNullOrWhiteSpace(item.DeliveryNumber) ? "" : item.DeliveryNumber); sb.Append("\",");
                            sb.Append('"'); sb.Append(string.IsNullOrWhiteSpace(item.PlatformMerchantCode) ? "" : item.PlatformMerchantCode); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.ProductNum == null ? 0 : item.ProductNum); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.Price == null ? 0 : item.Price); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.SuppliersID == null ? "" : suppliersDic[item.SuppliersID.GetValueOrDefault(0)]); sb.Append("\",");
                            sb.Append('"'); sb.Append(string.IsNullOrWhiteSpace(item.VerificationStatus) ? "" : statusDic[item.VerificationStatus]); sb.Append("\",");
                            sb.Append('"'); sb.Append(item.CreateDate == null ? "" : item.CreateDate.GetValueOrDefault(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss")); sb.Append("\"");
                            sb.Append(")");
                            excelHelper.ExecuteCommand(sb.ToString());
                            zIndex++;
                            
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        test++;
                    }
                }
            }
        }
    }
}
