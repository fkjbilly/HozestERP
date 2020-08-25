
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-03-27 13:44:36
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMJDRealTimeInventory : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the WfId
        /// </summary>
        public int WfId { get; set; }

        /// <summary>
        /// Gets or sets the RealTimeInventory
        /// </summary>
        public int RealTimeInventory { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandTypeCodeName
        {
            get
            {
                string result = "";
                if (ProductId != null)
                {
                    var products = IoC.Resolve<XMProductService>().GetXMProductById(ProductId.Value);
                    if (products != null)
                    {
                        if (products.BrandTypeId != null)
                        {
                            var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(products.BrandTypeId.Value);
                            if (list != null)
                            {
                                result = list.CodeName;
                            }
                        }
                    }
                }
                return result;
            }
        }


        public string WfName
        {
            get
            {
                string wfname = "";
                if (WfId != null)
                {
                    var wf = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(WfId);
                    if (wf != null)
                    {
                        wfname = wf.Name;
                    }
                }
                return wfname;
            }
        }
        //获取商品名称
        public string ProductName
        {
            get
            {
                string productName = "";
                if (ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (product != null)
                    {
                        productName = product.ProductName;
                    }
                }
                return productName;
            }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specifications
        {
            get
            {
                string specifications = "";
                if (ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(ProductId.Value);
                    if (product != null)
                    {
                        specifications = product.Specifications;
                    }
                }
                return specifications;
            }
        }

        //获取所属店铺ID
        public int NickID
        {
            get
            {
                int nickId = 0;
                if (WfId != null)
                {
                    var wf = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(WfId);
                    if (wf != null && wf.NickId != null)
                    {
                        nickId = wf.NickId.Value;
                    }
                }
                return nickId;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            get
            {
                string nickname = "";
                if (WfId != null)
                {
                    var wf = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(WfId);
                    if (wf != null && wf.NickId != null)
                    {
                        var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(wf.NickId.Value);
                        if (nick != null)
                        {
                            nickname = nick.nick;
                        }
                    }
                }
                return nickname;
            }
        }
        #endregion
    }
}
