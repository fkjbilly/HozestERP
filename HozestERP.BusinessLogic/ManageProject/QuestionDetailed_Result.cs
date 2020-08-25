using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class QuestionDetailed_Result : BaseEntity
    {
        #region 主表

        /// <summary>
        /// 问题反馈Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrderNO
        /// </summary>
        public string OrderNO { get; set; }

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
        /// Gets or sets the Buyer
        /// </summary>
        public string Buyer { get; set; }


        /// <summary>
        /// Gets or sets the RefundLogisticsNo
        /// </summary>
        public string RefundLogisticsNo { get; set; }

        /// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }


        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<int> Status { get; set; }


        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<bool> QIsEnable { get; set; }


        #endregion

        #region 明细

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
        public Nullable<bool> QDIsEnable { get; set; }

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
        /// <summary>
        /// 问题类型名称
        /// </summary>
        public string QuestionTypeName { get; set; }

        #endregion


        #region 订单信息

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OredrInfoID { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string DeliveryAddress { get; set; }

        //商品

        //件数

        /// <summary>
        /// 金额
        /// </summary>
        public Nullable<decimal> OrderPrice { get; set; }


        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> OdIsEnable { get; set; }



        /// <summary>
        ///项目id
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        #endregion



        ///// <summary>
        ///// 最近联系时间
        ///// </summary>
        //public Nullable<System.DateTime> ContactTime { get; set; }

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
                return result;
            }

        }


        /// <summary>
        /// 问题类型名称
        /// </summary>
        public string QuestionCategoryName
        {
            get
            {
                string result = "";
                if (this.QuestionTypeID != null && this.QuestionTypeID > 0)
                {
                    var category = IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById(this.QuestionTypeID.Value);
                    if (category != null)
                    {
                        result = category.CategoryName;
                    }
                }
                return result;
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
                return result;
            }
        }

        /// <summary>
        /// 客服
        /// </summary>
        public CustomerInfo SrvBeforeCustomer
        {
            get
            {
                return IoC.Resolve<CustomerInfoService>().GetCustomerInfoByID(this.SrvBeforeCustomerID.GetValueOrDefault(0));
            }
        }

        /// <summary>
        /// 售后
        /// </summary>
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

        #endregion

    }
}
