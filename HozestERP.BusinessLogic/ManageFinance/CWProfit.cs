
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-06-02 15:24:28
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class CWProfit : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the FinancialFieldId
        /// </summary>
        public Nullable<int> FinancialFieldId { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// Gets or sets the Department
        /// </summary>
        public Nullable<int> DepartmentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the YearStr
        /// </summary>
        public string YearStr { get; set; }

        /// <summary>
        /// Gets or sets the MonthStr
        /// </summary>
        public string MonthStr { get; set; }

        /// <summary>
        /// Gets or sets the CountMoney
        /// </summary>
        public Nullable<decimal> CountMoney { get; set; }


        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDateTime
        /// </summary>
        public Nullable<System.DateTime> CreateDateTime { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateDateTime { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 项目说明
        /// </summary>
        public string ProjectExplanation
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var project = IoC.Resolve<ICWProjectService>().GetCWProjectById(this.ProjectId.Value);
                    if (project != null)
                    {
                        result = project.ProjectExplanation;
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
        /// 平台名称
        /// </summary>
        //public string PlatformName
        //{
        //    get
        //    {
        //        string result = "";
        //        if (this.PlatformTypeId.HasValue)
        //        {
        //            var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
        //            if (codelist != null)
        //            {
        //                result = codelist.CodeName;
        //            }
        //        }
        //        return result;
        //    }
        //}

        #endregion
    }
}
