
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMQuestion : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrderNO
        /// </summary>
        public string OrderNO { get; set; }

        /// <summary>
        /// Gets or sets the LogisticsNo
        /// </summary>
        public string LogisticsNo { get; set; }

        /// <summary>
        /// Gets or sets the EmergencyDegree
        /// </summary>
        public Nullable<int> EmergencyDegree { get; set; }

        /// <summary>
        /// Gets or sets the PlatformID
        /// </summary>
        public Nullable<int> PlatformID { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<int> Status { get; set; }

        /// <summary>
        /// Gets or sets the Buyer
        /// </summary>
        public string Buyer { get; set; } 

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the RefundLogisticsNo
        /// </summary>
        public string RefundLogisticsNo { get; set; }

        /// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the CreateByID
        /// </summary>
        public Nullable<int> CreateByID { get; set; }

        /// <summary>
        /// Gets or sets the LastModifyTime
        /// </summary>
        public Nullable<System.DateTime> LastModifyTime { get; set; }

        /// <summary>
        /// Gets or sets the LastModifyByID
        /// </summary>
        public Nullable<int> LastModifyByID { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// 是否解决
        /// </summary>
        public Nullable<bool> IsSolve { get; set; }

        /// <summary>
        /// 问题等级
        /// </summary>
        public Nullable<int> QuestionLevel { get; set; }


        #endregion

        #region Custom Properties

        /// <summary>
        /// 订单处理状态
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return CommonHelper.GetDescription((QuestionStatusEnum)this.Status.GetValueOrDefault(0));
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
                if (this.OrderNO != null && this.OrderNO.Length > 1 && this.OrderNO.StartsWith("SO"))
                {
                    var Info = IoC.Resolve<IXMSaleInfoService>().GetXMSaleInfoListByRef(this.OrderNO);
                    if (Info != null && Info.Count>0)
                    {
                        result = Info[0].ProjectName;
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 问题等级
        /// </summary> 
        public CodeList QuestionLevelName
        {
            get
            {
                if (this.QuestionLevel != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.QuestionLevel.Value);
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
                if (this.PlatformID.HasValue)
                {
                    var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformID.Value);
                    if (codelist != null)
                    {
                        result = codelist.CodeName;
                    }
                }
                if (this.OrderNO != null && this.OrderNO.Length > 1 && this.OrderNO.StartsWith("SO"))
                {
                    var Info = IoC.Resolve<IXMSaleInfoService>().GetXMSaleInfoListByRef(this.OrderNO);
                    if (Info != null && Info.Count > 0)
                    {
                        result = "线下";
                    }
                }
                return result;
            }
        }
         
        #endregion
        #region Navigation Properties
        /// <summary>
        /// Gets or sets the XM_QuestionDetail list
        /// </summary>
        public virtual ICollection<XMQuestionDetail> XM_QuestionDetail { get; set; }
       
        #endregion


    }
}