
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMQuestionDetail : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        public int QuestionID { get; set; }

        /// <summary>
        /// 客服
        /// </summary>
        public Nullable<int> SrvBeforeCustomerID { get; set; }

        /// <summary>
        /// 售后
        /// </summary>
        public Nullable<int> SrvAfterCustomerID { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 处理结果说明
        /// </summary>
        public string ResultMsg { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<int> Status { get; set; }

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
        /// Gets or sets the QuestionTypeID
        /// </summary>
        public Nullable<int> QuestionTypeID { get; set; }

        /// <summary>
        /// 接单时间
        /// </summary>
        public Nullable<System.DateTime> OrdersTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// 是否退货
        /// </summary>
        public Nullable<bool> IsReturns { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        public Nullable<int> ResultsId { get; set; }

        /// <summary>
        /// 问题等级
        /// </summary>
        public Nullable<int> QuestionLevel { get; set; }


        #endregion

        #region Custom Properties

        public CustomerInfo SrvBeforeCustomer
        {
            get
            {
                return IoC.Resolve<CustomerInfoService>().GetCustomerInfoByID(this.SrvBeforeCustomerID.GetValueOrDefault(0));
            }
        }

        public CustomerInfo SrvAfterCustomer
        {
            get
            {
                return IoC.Resolve<CustomerInfoService>().GetCustomerInfoByID(this.SrvAfterCustomerID.GetValueOrDefault(0));
            }
        }

        /// <summary>
        /// 问题类型
        /// </summary> 
        public CodeList QuestionType
        {
            get
            {
                if (this.QuestionTypeID != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.QuestionTypeID.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        public int NickID
        {
            get
            {
                int nick_id = 0;
                if (QuestionID != null)
                {
                    var info = IoC.Resolve<IXMQuestionService>().GetById(this.QuestionID);
                    if (info != null)
                    {
                        nick_id = info.NickID.Value;
                    }
                }
                return nick_id;
            }
        }
        /// <summary>
        /// 问题类型名称
        /// </summary> 
        public string QuestionCategoryType
        {
            get
            {
                string categoryName = "";
                if (this.QuestionTypeID != null)
                {
                    var category = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById(this.QuestionTypeID.Value);
                    if (category != null)
                    {
                        categoryName = category.CategoryName;
                    }
                }
                return categoryName;
            }
        }

        public int ParentQuestionType
        {
            get
            {
                int pId = 0;
                if (this.QuestionType != null)
                {
                    var category = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById(this.QuestionTypeID.Value);
                    if (category != null)
                    {
                        pId = category.ParentId.Value;
                    }
                }
                return pId;
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
        /// 问题处理状态
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return CommonHelper.GetDescription((QuestionStatusEnum)this.Status.GetValueOrDefault(0));
            }
        }

        /// <summary>
        /// 处理结果
        /// </summary>
        public CodeList ResultsType
        {
            get
            {
                if (this.ResultsId != null)
                {
                    return IoC.Resolve<CodeService>().GetCodeListInfoByCodeID(this.ResultsId.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_Question
        /// </summary>
        public virtual XMQuestion XM_Question { get; set; }

        #endregion

    }
}