
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-12-08 13:14:09
** 修改人:
** 修改日期:
** 描 述: 
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
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class ManagementFeeStatistics
    {

    }

    public class HighChart
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public decimal Value { get; set; }
    }

    public class OperatingCostData
    {
        public string Date { get; set; }
        public string ProjectId { get; set; }//项目Id
        public decimal CountMoneySum1 { get; set; }//营业收入
        public decimal CountReturnMoneySum { get; set; }//退款金额
        public decimal CountMoneySum4 { get; set; }//进货成本
        public decimal CountReturnCostSum { get; set; }//退货成本
        public decimal CountMoneySum24 { get; set; }//赠品成本  
        public decimal CountMoneySum7 { get; set; }//刷拍成本
        public decimal CountMoneySum8 { get; set; }//返现成本 
        public decimal CountMoneySumFEE { get; set; }//广告费用
        public decimal CountMoneySum6 { get; set; }//运费
        public decimal YYCBMonthMoney { get; set; }//营业成本
        public decimal CountMoneySum5 { get; set; }//平台成本费用
        public decimal MLMonthMoney { get; set; }//毛利
        public decimal ZZSMonthMoney { get; set; }//增值税
        public decimal ManagementFee { get; set; }//管理费用
        public decimal CountMoneySum55 { get; set; }//平台成本费用
        public decimal CountMoneySum21 { get; set; }//广告费补贴
        public decimal YYSJMonthMoney { get; set; }//营业税金及附加
        public decimal SQLRMonthMoney { get; set; }//税前利润
        public decimal ZJRGMonthMoney { get; set; }//直接人工
    }

    public class CWProfitModel
    {
        public decimal OperatingPerformance { get; set; }//营业业绩额
        public decimal BusinessIncome { get; set; }//营业收入
        public decimal ReturnMoney { get; set; }//退款金额
        public decimal PurchaseCost { get; set; }//进货成本
        public decimal ReturnCost { get; set; }//退货成本
        public decimal PremiumsCost { get; set; }//赠品成本  
        public decimal TakeBrush { get; set; }//刷拍成本
        public decimal Cashback { get; set; }//返现成本 
        public decimal AdvertisementFEE { get; set; }//广告费用
        public decimal PlatformFee { get; set; }//平台成本费用
        public decimal Freight { get; set; }//运费
        public decimal ZZSMoney { get; set; }//增值税
        public decimal YYCBMoney { get; set; }//营业成本
        public decimal MLMoney { get; set; }//毛利
        public decimal CountMoneySum1 { get; set; }// 运营部门人员工资
        public decimal CountMoneySum2 { get; set; }// 运营部门人员社保
        public decimal CountMoneySum3 { get; set; }//运营部门人员奖金
        public decimal CountMoneySum4 { get; set; }//运营部门销售奖金
        public decimal CountMoneySum5 { get; set; }//差旅费
        public decimal CountMoneySum6 { get; set; }//办公费用
        public decimal CountMoneySum7 { get; set; }//其他费用
        public decimal CountMoneySum8 { get; set; }//固定资产折旧
        public decimal CountMoneySum9 { get; set; }// 摊销费用
        public decimal CountMoneySum10 { get; set; }//广告费补贴
        public decimal ZJRGMoney { get; set; } //直接人工
        public decimal YYFYMoney { get; set; } //营业费用
        public decimal YYSJMoney { get; set; } //营业税金及附加
        public decimal SQLRMoney { get; set; } //税前利润
        public decimal Wages { get; set; } //工资
        public decimal SocialSecurity { get; set; } //社保
        public decimal Bonus { get; set; } //奖金
        public decimal Subsidy { get; set; } //补贴
        public decimal SalesIncentive { get; set; } //销售激励
        public decimal WelfareFunds { get; set; } //福利费
        public decimal MarketFees { get; set; } //市场费
        public decimal ServerRentalFee { get; set; } //服务器租赁费
        public decimal IncomeTax { get; set; } //所得税
        public decimal DirectSellingNetProfit { get; set; } //直销净利润
        public decimal ServiceIncome { get; set; } //服务收入
    }

    public class ProductSalesData
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public Nullable<int> OrderInfoID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// Gets or sets the ProjectID
        /// </summary>
        public Nullable<int> ProjectID { get; set; }

        /// <summary>
        /// Gets or sets the FactoryPrice
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }

        public int? Count { get; set; }

        public string CountProportion { get; set; }

        public string Table { get; set; }

        public string Manufacturers { get; set; }

        public string Cost { get; set; }

        public string DeliveryAddress { get; set; }

        public int ApplicaType { get; set; }

        public int GoodsStatus { get; set; }

        public string OrderCode { get; set; }//订单号

        public string WantID { get; set; }//网名

        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }//下单时间

        public Nullable<System.DateTime> PayDate { get; set; }//付款时间

        public string BuyerMobile { get; set; }//手机号

        public string Province { get; set; }//省

        public string City { get; set; }//市

        /// <summary>
        /// 申请类型
        /// </summary>
        public string ApplicaTypeName
        {
            get
            {
                string result = "";
                if (this.ApplicaType != null)
                {
                    if (this.ApplicaType == 5)
                    {
                        result = "先退货后退款";
                    }
                    else if (this.ApplicaType == 6)
                    {
                        result = "换货";
                    }
                    else if (this.ApplicaType == 7)
                    {
                        result = "先退款后退货";
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 退货的货物状态
        /// </summary>
        public string GoodsStatusName
        {
            get
            {
                string result = "";
                if (this.GoodsStatus != null)
                {
                    if (this.GoodsStatus == 1)
                    {
                        result = "未确认发出";
                    }
                    else if (this.GoodsStatus == 2)
                    {
                        result = "已发出";
                    }
                    else if (this.GoodsStatus == 3)
                    {
                        result = "已确认退回";
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickID != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)this.NickID);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.ProjectID != null)
                {
                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById((int)this.ProjectID);
                    if (project != null)
                    {
                        result = project.ProjectName;
                    }
                }
                return result;
            }
        }
    }

    public class JDSelfModel
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WareHousesID { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleCount { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int RejectedCount { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int InventoryCount { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandType
        {
            get
            {
                string result = "";
                if (this.PlatformMerchantCode != null)
                {
                    var item = IoC.Resolve<IXMProductService>().getXMProductListByPlatformMerchantCode(this.PlatformMerchantCode);
                    if (item != null && item.Count > 0)
                    {
                        result = item[0].BrandTypeId.ToString();
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }
    }
}
