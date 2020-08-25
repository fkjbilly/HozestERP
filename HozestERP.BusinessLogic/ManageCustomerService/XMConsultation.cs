
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-07-16 14:53:29
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMConsultation: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public string CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReceptionDate
        /// </summary>
        public Nullable<System.DateTime> ReceptionDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the NoTurnoverType
        /// </summary>
        public string NoTurnoverType { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateReason
        /// </summary>
        public string DateReason { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }

    	/// <summary>
        /// Gets or sets the NoCause
        /// </summary>
        public Nullable<int> NoCause { get; set; }
    
        /// <summary>
        /// 组长点评
        /// </summary>
        public string LeaderComments { get; set; }

        /// <summary>
        /// 跟进等级
        /// </summary>
        public string FollowGrade { get; set; }

        public Nullable<bool> IsOrder { get; set; }

        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Created
        /// </summary>
        public Nullable<System.DateTime> Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updated
        /// </summary>
        public Nullable<System.DateTime> Updated { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion

        /// <summary>
        /// 获取创建人信息
        /// </summary>
        public CustomerInfo CreateName
        {
            get
            {
                if (this.CreatorID != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.CreatorID.Value);
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

        /// <summary>
        /// 不跟进原因
        /// </summary>
        public string NoCauseType
        {
            get
            {
                string result = "";
                if (this.PlatformTypeId.HasValue)
                {
                    var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.NoCause.Value);
                    if (codelist != null)
                    {
                        result = codelist.CodeName;
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
                if (this.NickId != null && this.NickId > 0)
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
        /// 查询聊天记录最大时间
        /// </summary>
        public string ContactTime
        {
            get
            {
                string result = "";
                if (this.Id > 0)
                {
                    var XMConsultationDetails = IoC.Resolve<IXMConsultationDetailsService>().GetXMConsultationDetailsByConid(this.Id);
                    if (XMConsultationDetails != null)
                    {
                        result = XMConsultationDetails.ContactTime.ToString();
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 查询聊天记录最后条记录
        /// </summary>
        public string ContactContent
        {
            get
            {
                string result = "";
                if (this.Id > 0)
                {
                    var XMConsultationDetails = IoC.Resolve<IXMConsultationDetailsService>().GetXMConsultationDetailsByConid(this.Id);
                    if (XMConsultationDetails != null)
                    {
                        result = XMConsultationDetails.ContactContent.ToString();
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 查询聊天记录的总数
        /// </summary>
        public int XMConsultationDetails
        {
            get
            {
                int result = 0;
                if (this.Id > 0)
                {
                    var XMConsultationDetails = IoC.Resolve<IXMConsultationDetailsService>().GetXMConsultationDetailsCount(this.Id);
                    if (XMConsultationDetails != 0)
                    {
                        result = XMConsultationDetails;
                    }
                }
                return result;
            }
        }
    }

}
