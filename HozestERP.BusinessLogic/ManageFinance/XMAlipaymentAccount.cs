/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-09-19 13:36:06
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMAlipaymentAccount
    {
        /// <summary>
        /// Gets or sets the ID  订单ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }
        /// <summary>
        /// Gets or sets the PlatFormTypeId
        /// </summary>
        public Nullable<int> PlatFormTypeId { get; set; }
        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// Gets or sets the OrderID
        /// </summary>
        public Nullable<int> OrderID { get; set; }
        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
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
                    var Manufacturersproduce = IoC.Resolve<IXMProductService>().getXMProductByPlatform(int.Parse(this.PlatFormTypeId.ToString()), this.PlatformMerchantCode);
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
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickID != null && this.NickID > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickID.Value);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 项目Id
        /// </summary>
        public string ProjectName
        {
            get
            {
                string projectName = "";
                if (this.NickID.HasValue)
                {
                    var Info = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickID.Value);
                    if (Info != null && Info.ProjectId != null)
                    {
                        var project = IoC.Resolve<XMProjectService>().GetXMProjectById(Info.ProjectId.Value);
                        if (project != null)
                        {
                            projectName = project.ProjectName;
                        }
                    }
                }
                return projectName;
            }
        }

    }
}
