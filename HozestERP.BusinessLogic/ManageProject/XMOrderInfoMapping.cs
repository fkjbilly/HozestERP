using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMOrderInfoMapping : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the WantID
        /// </summary>
        public string WantID { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }


        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ProductUnit
        /// </summary>
        public string ProductUnit { get; set; }

        /// <summary>
        /// Gets or sets the Count
        /// </summary>
        public Nullable<int> Count { get; set; }

        /// <summary>
        /// Gets or sets the UnitPrice
        /// </summary>
        public Nullable<decimal> UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
        /// <summary>
        /// 已支付费用
        /// </summary>
        public Nullable<decimal> PayPrice { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public string OfflinePlatformName { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public string OfflineNickName { get; set; }

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

        public int ProjectId
        {
            get
            {
                if (this.NickID != null)
                {
                    var Nick = IoC.Resolve<IXMNickService>().GetXMNickByID((int)this.NickID);
                    if (Nick != null)
                    {
                        return (int)Nick.ProjectId;
                    }
                    return -1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName
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

        #endregion

    }
}
