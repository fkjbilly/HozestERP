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


namespace HozestERP.BusinessLogic.ManageBulletin
{

    public partial class Bulletin : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the BulletinID
        /// </summary>
        public int BulletinID { get; set; }

        /// <summary>
        /// Gets or sets the 编号
        /// </summary>
        public string BulletinCode { get; set; }

        /// <summary>
        /// Gets or sets the 标题
        /// </summary>
        public string BulletinTitle { get; set; }

        /// <summary>
        /// Gets or sets the 公告类别
        /// </summary>
        public int BulletinTypeID { get; set; }

        /// <summary>
        /// Gets or sets the 优先级
        /// </summary>
        public int PriorTypeID { get; set; }

        /// <summary>
        /// Gets or sets the 生效日期
        /// </summary>
        public System.DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the 失效日期
        /// </summary>
        public System.DateTime InvalidDate { get; set; }

        /// <summary>
        /// Gets or sets the 发布日期
        /// </summary>
        public System.DateTime ReleasedDate { get; set; }

        /// <summary>
        /// Gets or sets the 状态
        /// </summary>
        public int BulletinStatus { get; set; }

        /// <summary>
        /// Gets or sets the 审批内容
        /// </summary>
        public string Approval { get; set; }

        /// <summary>
        /// Gets or sets the 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the 删除标记
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the 是否生效
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the 排序号
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        public System.DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public int CreatorID { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the SCustomerInfo list
        /// </summary>
        public virtual ICollection<CustomerInfo> SCustomerInfo { get; set; }

        #endregion

        #region Custom Properties

        /// <summary>
        /// 发布人
        /// </summary>
        public CustomerInfo Creator
        {
            get
            {
                return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.CreatorID);
            }
        }

        /// <summary>
        /// 发布人姓名
        /// </summary>
        public string CreatorFullName
        {
            get
            {
                if (this.Creator != null)
                    return this.Creator.FullName;
                return string.Empty;
            }
        }

        /// <summary>
        /// 公告状态
        /// </summary>
        public BulletinStatusEnum BulletinStatuss
        {
            get
            {
                return (BulletinStatusEnum)this.BulletinStatus;
            }
            set
            {
                this.BulletinTypeID = (int)value;
            }
        }

        /// <summary>
        /// 公告类型
        /// </summary>
        public CodeList BulletinType
        {
            get
            {
                return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.BulletinTypeID);
            }
        }

        /// <summary>
        /// 公告类型
        /// </summary>
        public CodeList PriorType
        {
            get
            {
                return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PriorTypeID);
            }
        }

        #endregion
    }
}