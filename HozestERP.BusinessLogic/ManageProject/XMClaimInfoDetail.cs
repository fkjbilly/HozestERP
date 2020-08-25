
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-07-28 17:30:47
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;


namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMClaimInfoDetail : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ClaimInfoID
        /// </summary>
        public int ClaimInfoID { get; set; }

        /// <summary>
        /// Gets or sets the ClaimTypeID
        /// </summary>
        public int ClaimTypeID { get; set; }

        /// <summary>
        /// 理赔金额
        /// </summary>
        public Nullable<decimal> ClaimAcount { get; set; }

        /// <summary>
        /// 索赔金额
        /// </summary>
        public Nullable<decimal> ClaimReal { get; set; }

        /// <summary>
        /// Gets or sets the IsConfirm
        /// </summary>
        public Nullable<bool> IsConfirm { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmPerson
        /// </summary>
        public Nullable<int> ConfirmPerson { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string ResponsiblePerson { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmDate
        /// </summary>
        public Nullable<System.DateTime> ConfirmDate { get; set; }

        /// <summary>
        /// Gets or sets the Reason
        /// </summary>
        public string Reason { get; set; }

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
        /// 受损情况
        /// </summary>
        public string DamagedCondition { get; set; }

        #endregion
        #region Custom Properties

        public string CodeName
        {
            get
            {
                String CodeName = "";
                var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.ClaimTypeID);
                if (code != null)
                {
                    CodeName = code.CodeName;
                }
                return CodeName;
            }
        }

        public string ConfirmPersonName
        {
            get
            {
                string str = "";
                if (this.ConfirmPerson != null)
                {
                    var customerInfo = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID((int)this.ConfirmPerson);
                    if (customerInfo != null)
                    {
                        str = customerInfo.FullName;
                    }
                }
                return str;
            }
        }

        public string DamagedConditionName
        {
            get
            {
                string str = "";
                if (this.DamagedCondition != null)
                {
                    string[] damagedCondition = this.DamagedCondition.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string id in damagedCondition)
                    {
                        var CodeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(int.Parse(id));
                        if (CodeList != null)
                        {
                            str += str == "" ? CodeList.CodeName : "," + CodeList.CodeName;
                        }
                    }
                }
                return str;
            }
        }

        #endregion
    }
}
