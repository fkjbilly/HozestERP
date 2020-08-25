
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-01-08 09:34:18
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
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMScalping : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ScalpingApplication
        /// </summary>
        public Nullable<int> ScalpingApplication { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        ///渠道类型
        /// </summary>
        public Nullable<int> Type { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the WantID
        /// </summary>
        public string WantID { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the SalePrice
        /// </summary>
        public Nullable<decimal> SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the Fee
        /// </summary>
        public Nullable<decimal> Fee { get; set; }

        /// <summary>
        /// Gets or sets the Deduction
        /// </summary>
        public Nullable<decimal> Deduction { get; set; }

        /// <summary>
        /// Gets or sets the Leader
        /// </summary>
        public Nullable<int> Leader { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// 是否异常（刷单记录表中的订单号在订单管理中不存在）
        /// </summary>
        public Nullable<bool> IsAbnormal { get; set; }

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
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }

        #endregion
        #region Custom Properties
        //<summary>
        //刷单编号
        //</summary>
        public XMScalpingApplication ScalpingNo
        {
            get
            {
                if (this.ScalpingApplication != null)
                {
                    return IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByScalpingId(this.ScalpingApplication.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public CodeList PlatformTypeName
        {
            get
            {
                if (this.PlatformTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        ///渠道类型
        /// </summary>
        //public CodeList TypeName
        //{
        //    get
        //    {
        //        if (this.Type != null)
        //        {
        //            return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.Type.Value);
        //        }
        //        else
        //        {

        //            return null;
        //        }
        //    }
        //}

        /// <summary>
        /// 店铺名称
        /// </summary>
        public XMNick NickName
        {
            get
            {
                if (this.NickId != null)
                {
                    return IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                }
                else
                {

                    return null;
                }
            }
        }


        /// <summary>
        /// 负责人
        /// </summary>
        //public CustomerInfo LeaderName
        //{
        //    get
        //    {
        //        if (this.Leader != null)
        //        {
        //            return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.Leader.Value);
        //        }
        //        else
        //        {

        //            return null;
        //        }
        //    }
        //}

        #endregion
    }
}