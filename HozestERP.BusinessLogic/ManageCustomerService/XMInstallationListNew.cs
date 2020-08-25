using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public class XMInstallationListNew
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the WantID
        /// </summary>
        public string WantID { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the CustomerTel
        /// </summary>
        public string CustomerTel { get; set; }

        /// <summary>
        /// Gets or sets the InstallAddress
        /// </summary>
        public string InstallAddress { get; set; }

        /// <summary>
        /// Gets or sets the ArrangeDate
        /// </summary>
        public Nullable<System.DateTime> ArrangeDate { get; set; }

        /// <summary>
        /// Gets or sets the InstallType
        /// </summary>
        public Nullable<int> InstallType { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> WorkerID { get; set; }

        /// <summary>
        /// Gets or sets the ContactInfo
        /// </summary>
        public string ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the InstallationFee
        /// </summary>
        public Nullable<decimal> InstallationFee { get; set; }

        /// <summary>
        /// Gets or sets the PaymentDate
        /// </summary>
        public Nullable<System.DateTime> PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the IsArrange
        /// </summary>
        public Nullable<bool> IsArrange { get; set; }

        /// <summary>
        /// Gets or sets the IsInstall
        /// </summary>
        public Nullable<bool> IsInstall { get; set; }

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

        public string FullName { get; set; }

        public string WorkerTel { get; set; }

        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickId != null && this.NickId > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(int.Parse(this.NickId.ToString()));
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }

        }

        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var project = IoC.Resolve<IXMProjectService>().GetXMProjectById(int.Parse(this.ProjectId.ToString()));
                    if (project != null)
                    {
                        result = project.ProjectName;
                    }
                }
                return result;
            }
        }

        public string PayDate
        {
            get
            {

                if (!string.IsNullOrEmpty(this.OrderCode))
                {
                    var entity = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(this.OrderCode);
                    if (entity != null)
                    {
                        return entity.PayDate.ToString();
                    }
                    else
                    {
                        return CreateDate.ToString();
                    }
                }

                return null;
            }
        }
    }
}
