using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMBackProductDetails : BaseEntity
    {
        /// <summary>
        /// 申请单号
        /// </summary>
        public string ApplicationNo { get; set; }

        /// <summary>
        /// 申请类型 4 未发货退款,5 先退货后退款,6 换货,9 售后,10 售中,8 退运费,7 先退款后退货
        /// </summary>
        public Nullable<int> ApplicationType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 平台id
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public Nullable<decimal> Amount { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 退换货数量
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// 订单id
        /// </summary>
        public Nullable<int> OrderInfoID { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickId != 0 && this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode
        {
            get
            {
                string result = "";
                if (this.PlatformMerchantCode != "")
                {

                    var Manufacturersproduce = IoC.Resolve<IXMProductService>().getXMProductByPlatform(int.Parse(this.PlatformTypeId.ToString()), this.PlatformMerchantCode);
                    if (Manufacturersproduce != null)
                    {
                        result = Manufacturersproduce.ManufacturersCode;
                    }
                    return result;
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformType
        {
            get
            {
                string result = "";
                if (this.PlatformTypeId.HasValue)
                {
                    var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                    if (codelist != null)
                    {
                        result = codelist.CodeName;
                    }
                }
                return result;
            }
        }
    }
}
