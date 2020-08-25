
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-08-04 09:20:44
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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageApplication
{
    public partial class XMApplicationExchange : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationId
        /// </summary>
        public Nullable<int> ApplicationId { get; set; }

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
        /// 退货数量
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// 出厂价
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the IsOderDetails
        /// </summary>
        public Nullable<int> IsOderDetails { get; set; }

        /// <summary>
        /// Gets or sets the IsNewOderDetails
        /// </summary>
        public Nullable<int> IsNewOderDetails { get; set; }

        /// <summary>
        /// 1为换货 2为退货
        /// </summary>
        public Nullable<int> IsApplication { get; set; }

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

        #endregion
        #region Custom Properties

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string Manufacturers
        {
            get
            {
                string result = "";
                if (this.ApplicationId != null)
                {
                    var item = IoC.Resolve<IXMProductService>().GetXMProductAppId(this.ID, this.PlatformMerchantCode);
                    if (item != null)
                    {
                        result = item.ManufacturersCode;
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
        /// 品牌
        /// </summary>
        public int BrandType
        {
            get
            {
                int result = 0;
                if (this.ApplicationId != null)
                {
                    var item = IoC.Resolve<IXMProductService>().GetXMProductAppId(this.ID, this.PlatformMerchantCode);
                    if (item != null)
                    {
                        result = (int)item.BrandTypeId;
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// 申请类型
        /// </summary>
        public int ApplicaType
        {
            get
            {
                int result = 0;
                if (this.ApplicationId != null)
                {
                    var item = IoC.Resolve<IXMApplicationService>().GetXMApplicationByID(this.ApplicationId.Value);
                    if (item != null)
                    {
                        result = (int)item.ApplicationType;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 退货的货物状态
        /// </summary>
        public int GoodsStatus
        {
            get
            {
                int result = 0;
                if (this.ApplicationId != null)
                {
                    var item = IoC.Resolve<IXMApplicationService>().GetXMApplicationByID(this.ApplicationId.Value);
                    if (item != null)
                    {
                        if (item.GoodsConfirmReturn == true)
                        {
                            result = 3;//已确认退回
                        }
                        else if (item.GoodsConfirmSendOut == true)
                        {
                            result = 2;//已发出
                        }
                        else
                        {
                            result = 1;//未确认发出
                        }

                    }
                }
                return result;
            }
        }

        #endregion
    }
}
