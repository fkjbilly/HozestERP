
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-10-27 11:05:03
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMExpressListManagement : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the Month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the ExpressID
        /// </summary>
        public int ExpressID { get; set; }

        /// <summary>
        /// Gets or sets the Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the Weight
        /// </summary>
        public Nullable<decimal> Weight { get; set; }

        /// <summary>
        /// Gets or sets the ProvinceID
        /// </summary>
        public string ProvinceID { get; set; }

        /// <summary>
        /// Gets or sets the Cost
        /// </summary>
        public Nullable<decimal> Cost { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties

        //省份
        public string ProvinceName
        {
            get
            {
                string value = "";
                if (this.ProvinceID != null)
                {
                    var areaCode = IoC.Resolve<IAreaCodeService>().GetAreaByNumberID(this.ProvinceID);
                    if (areaCode != null)
                    {
                        value = areaCode.City;
                    }
                }
                return value;
            }
        }

        //快递公司
        public string ExpressName
        {
            get
            {
                string value = "";
                if (this.ExpressID != null)
                {
                    var Info = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(this.ExpressID.ToString());//快递公司
                    if (Info != null)
                    {
                        value = Info.LogisticsName;
                    }
                }
                return value;
            }
        }

        //平台
        public string PlatformTypeName
        {
            get
            {
                string PlatformTypeName = "";
                var Info = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(this.ExpressID.ToString());//快递公司
                if (Info != null)
                {
                    var platFormTypeList = IoC.Resolve<ICodeService>().GetCodeList(Info.PlatformTypeId.Value);
                    if (platFormTypeList.Count > 0)
                    {
                        PlatformTypeName = platFormTypeList[0].CodeName;
                    }
                }
                return PlatformTypeName;
            }
        }

        #endregion
    }
}
