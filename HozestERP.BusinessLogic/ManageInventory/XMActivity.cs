
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-07-14 10:23:16
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
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMActivity : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ActivityDate
        /// </summary>
        public DateTime ActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ActivityTypeID
        /// </summary>
        public int ActivityTypeID { get; set; }
        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }

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
        /// 店铺
        /// </summary>
        public Nullable<int> NickId { get; set; }
        /// <summary>
        /// 项目  如果无店铺 使用项目
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            get
            {
                string projectName = "";
                if (this.ProjectId != null)
                {
                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById(this.ProjectId.Value);
                    if (project != null)
                    {
                        projectName = project.ProjectName;
                    }
                }
                return projectName;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            get
            {
                string nickName = "";
                if (this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (nick != null)
                    {
                        nickName = nick.nick;
                    }
                }
                return nickName;
            }
        }

        public string ActivityTypeName
        {
            get
            {
                string activityTypeName = "";
                if (this.ActivityTypeID != null)
                {
                    var activityTypes = IoC.Resolve<IXMActivityTypeService>().GetXMActivityTypeById(this.ActivityTypeID);
                    if (activityTypes != null)
                    {
                        activityTypeName = activityTypes.ActivityName;
                    }
                }
                return activityTypeName;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get
            {
                string productName = "";
                if (this.ProductId != null)
                {
                    var product = IoC.Resolve<IXMProductService>().GetXMProductById(this.ProductId);
                    if (product != null)
                    {
                        productName = product.ProductName;
                    }
                }
                return productName;
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateName
        {
            get
            {
                string CreateName = "";
                if (this.CreateID != null)
                {
                    var customers = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.CreateID.Value);
                    if (customers != null)
                    {
                        CreateName = customers.FullName;
                    }
                }
                return CreateName;
            }
        }

        #endregion
    }
}
