using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Entities
{
    public class ClientProductList
    {
        public List<ClientProduct> clientProduct  { get; set; }
    }
    public class ClientProduct
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
        /// <summary>
        /// Gets or sets the BrandTypeId
        /// </summary>
        public Nullable<int> BrandTypeId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 系列
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// 厂家库存
        /// </summary>
        public Nullable<int> ManufacturersInventory { get; set; }

        /// <summary>
        /// 预警库存数
        /// </summary>
        public Nullable<int> WarningQuantity { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ProductColors { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string ProductUnit { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string ProductWeight { get; set; }
        /// <summary>
        /// 积极
        /// </summary>
        public string ProductVolume { get; set; }

        /// <summary>
        /// 是否赠品
        /// </summary>
        public Nullable<bool> IsPremiums { get; set; }

        /// <summary>
        /// Gets or sets the IsMoveCargo
        /// </summary>
        public Nullable<bool> IsMoveCargo { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

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
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }

    }
}