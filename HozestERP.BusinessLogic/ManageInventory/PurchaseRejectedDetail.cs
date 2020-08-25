using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class PurchaseRejectedDetail
    {
        #region Primitive Properties
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PrId
        /// </summary>
        public int PrId { get; set; }
        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }
        /// <summary>
        /// Gets or sets the SupplierId
        /// </summary>
        public Nullable<int> SupplierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the RejectionProductPrice
        /// </summary>
        public decimal RejectionProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the RejectionCount
        /// </summary>
        public int RejectionCount { get; set; }

        /// <summary>
        /// Gets or sets the RejectionMoney
        /// </summary>
        public decimal RejectionMoney { get; set; }
        /// <summary>
        /// 发出工厂
        /// </summary>
        public string EmitFactory { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }


        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the BillStatus     退回状态   待退回   已退回
        /// </summary>
        public Nullable<int> BillStatus { get; set; }

        #endregion
        #region Custom Properties
        //产品名称
        public string ProductName
        {
            get
            {
                string productName = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        productName = products.ProductName;
                    }
                }
                return productName;
            }
        }

        //产品规格
        public string Specifications
        {
            get
            {
                string specifications = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        specifications = products.Specifications;
                    }
                }
                return specifications;
            }
        }

        //产品单位
        public string ProductUnit
        {
            get
            {
                string productUnit = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        productUnit = products.ProductUnit;
                    }
                }
                return productUnit;
            }
        }

        #endregion

        #region Navigation Properties
        #endregion

    }
}
