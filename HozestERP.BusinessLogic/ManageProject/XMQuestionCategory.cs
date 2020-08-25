
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-04-08 09:48:55
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMQuestionCategory : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ParentId
        /// </summary>
        public Nullable<int> ParentId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryCode
        /// </summary>
        public string CategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

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
        /// Gets or sets the IsDeleted
        /// </summary>
        public Nullable<bool> IsDeleted { get; set; }

        #endregion
        #region Custom Properties
        /// <summary>
        /// 
        /// </summary>
        public XMQuestionCategory ParentCategory
        {
            get
            {
                return IoC.Resolve<IXMQuestionCategoryService>().GetXMQuestionCategoryById(this.ParentId.GetValueOrDefault());
            }
        }

        #endregion
    }
}
