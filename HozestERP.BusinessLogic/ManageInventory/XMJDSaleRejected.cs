
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-08-10 10:40:24
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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Codes;
using System.Linq;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMJDSaleRejected : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// 备件单号
        /// </summary>
        public string PrepareRef { get; set; }

        /// <summary>
        /// Gets or sets the ReturnMoney
        /// </summary>
        public Nullable<decimal> LogisticsFee { get; set; }

        /// <summary>
        /// Gets or sets the ReturnMoney
        /// </summary>
        public Nullable<decimal> ReturnMoney { get; set; }

        /// <summary>
        /// Gets or sets the ReturnCategoryID
        /// </summary>
        public Nullable<int> ReturnCategoryID { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// 退回工厂ID
        /// </summary>
        public Nullable<int> FactoryID { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

      

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
        /// 
        /// </summary>
        public Nullable<int> NickId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }

        #endregion
        #region Custom Properties
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            get
            {
                string nickName = "";
                if (this.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(NickId.Value);
                    if (nick != null)
                    {
                        nickName = nick.nick;
                    }
                }
                return nickName;
            }
        }

        public string FactoryName
        {
            get
            {
                string FactoryName = "";
                if(FactoryID!=null)
                {
                    var CodeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)FactoryID);
                    if(CodeList != null)
                    {
                        FactoryName = CodeList.CodeName;
                    }
                }
                return FactoryName;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnCategoryName
        {
            get
            {
                string returnCategoryName = "";
                if (this.ReturnCategoryID != null)
                {
                    var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.ReturnCategoryID.Value);
                    if (code != null)
                    {
                        returnCategoryName = code.CodeName;
                    }
                }
                return returnCategoryName;
            }
        }

        public DateTime? JDConfirmDate
        {
            get
            {
                DateTime? time = null;
                if(XM_JDSaleRejectedProductDetail.Count>0)
                {
                    time = XM_JDSaleRejectedProductDetail.OrderByDescending(a => a.JDConfirmDate).First().JDConfirmDate;
                }
                return time;
            }
        }

        public DateTime? XLMConfirmDate
        {
            get
            {
                DateTime? time = null;
                if (XM_JDSaleRejectedProductDetail.Count > 0)
                {
                    time = XM_JDSaleRejectedProductDetail.OrderByDescending(a => a.XLMConfirmDate).First().XLMConfirmDate;
                }
                return time;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_JDSaleRejectedProductDetail list
        /// </summary>
        public virtual ICollection<XMJDSaleRejectedProductDetail> XM_JDSaleRejectedProductDetail { get; set; }

        #endregion
    }
}
