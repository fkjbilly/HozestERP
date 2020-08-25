
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
    public partial class XMDataAnalysy : BaseEntity
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<int> PlatformTypeId { get; set; }
        public Nullable<int> NickId { get; set; }
        public string CustomerID { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public string NoTurnoverType { get; set; }
        public int NoTurnoverTypeCount { get; set; }
        public string FollowGrade { get; set; }
        public Nullable<int> CreatorID { get; set; }
        public int ConsultationCount { get; set; }
        public int DealCount { get; set; }
        public int CompleteCount { get; set; }
        public int DealPeopleCount { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal TotalRate { get; set; }
        public decimal CompleteRate { get; set; }
        public decimal ReturnRate { get; set; }
        public decimal DealTotal { get; set; }
        public decimal TimeEfficiency { get; set; }
        public int RealReturnCount { get; set; }
        public int ReturnTotal { get; set; }
        public string DetailTab { get; set; }
        public int FollowCount { get; set; }
        public Nullable<int> QuestionType { get; set; }
        public int QuestionLevel { get; set; }
        public int ApplicationType { get; set; }
        public int Status { get; set; }
        public int ResultsId { get; set; }
        public bool IsReturns { get; set; }
        public string DateReason { get; set; }
        public int ApplicationReturnCount { get; set; }
        public int ProcessingCount { get; set; }
        public Nullable<System.DateTime> LastModifyTime { get; set; }
        public Nullable<System.DateTime> OrdersTime { get; set; }
        public decimal OrderAmount { get; set; }
        public string ParentQuestionTypeName { get; set; }
        public string ApplicationTypeName
        {
            get
            {
                if (this.ApplicationType != null)
                {
                    if (this.ApplicationType == 4)
                    {
                        return "未发货退款";
                    }
                    else if (this.ApplicationType == 5)
                    {
                        return "先退货后退款";
                    }
                    else if (this.ApplicationType == 6)
                    {
                        return "换货";
                    }
                    else if (this.ApplicationType == 7)
                    {
                        return "先退款后退货";
                    }
                    else if (this.ApplicationType == 8)
                    {
                        return "退运费";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
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
        /// 查询聊天记录的总数
        /// </summary>
        public int XMConsultationDetails
        {
            get
            {
                int result = 0;
                if (this.ID > 0)
                {
                    var XMConsultationDetails = IoC.Resolve<IXMConsultationDetailsService>().GetXMConsultationDetailsCount(this.ID);
                    if (XMConsultationDetails != 0)
                    {
                        result = XMConsultationDetails;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 组别
        /// </summary>
        public string Group
        {
            get
            {
                if (this.CreateName != null)
                {
                    return IoC.Resolve<IXMConsultationService>().GetDepName(this.CreateName.DepartmentID);
                }
                else
                {
                    return null;
                }
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
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.QuestionLevel);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 问题类型
        /// </summary> 
        public CodeList QuestionTypeName
        {
            get
            {
                if (this.QuestionType != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.QuestionType);
                }
                else
                {
                    return null;
                }
            }
        }

        public string QuestionCategoryName
        {
            get
            {
                string categoryName = "";
                if (this.QuestionType != null)
                {
                    var category = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById((int)this.QuestionType);
                    if (category != null)
                    {
                        categoryName = category.CategoryName;
                    }
                }
                return categoryName;
            }
        }
        //父节点ID
        public int ParentQuestionType
        {
            get
            {
                int pId = 0;
                if (this.QuestionType != null)
                {
                    var category = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById((int)this.QuestionType);
                    if (category != null)
                    {
                        pId = category.ParentId.Value;
                    }
                }
                return pId;
            }
        }
        ////父节点名称
        //public string ParentQuestionTypeName
        //{
        //    get
        //    {
        //        string pname = string.Empty;
        //        if (this.QuestionType != null)
        //        {
        //            var category = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById((int)this.QuestionType);
        //            if (category != null)
        //            {
        //                int pid = category.ParentId.Value;
        //                var pCategory = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById(pid);
        //                if (pCategory != null)
        //                {
        //                    pname = pCategory.CategoryName;
        //                }
        //            }
        //        }
        //        return pname;
        //    }
        //}
    }

}
