using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.CustomerManagement; 
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMNick : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// 店铺id
        /// </summary>
        public int nick_id { get; set; }

        /// <summary>
        ///店铺名称
        /// </summary>
        public string nick { get; set; }

        /// <summary>
        /// 平台ID（天猫，京东，唯品会）
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// 店长
        /// </summary>
        public string shopManager { get; set; }

        /// <summary>
        ///是否可用 true 表示可用；false 表示删除
        /// </summary>
        public bool isEnable { get; set; }
         
        /// <summary>
        ///项目id
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createPerson { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string updatePerson { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime createTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public Nullable<System.DateTime> updateTime { get; set; }

        /// <summary>
        ///角色id
        /// </summary>
        public Nullable<int> customerRoleID { get; set; }

        #endregion

        #region CustomerRole Properties
        /// <summary>
        ///  获得角色信息
        /// </summary>
        public CustomerRole customerRole
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerRoleById(Convert.ToInt32(this.customerRoleID));
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.ProjectId != null && this.ProjectId > 0)
                {
                    var nick = IoC.Resolve<IXMProjectService>().GetXMProjectById(this.ProjectId.Value);
                    if (nick != null)
                    {
                        result = nick.ProjectName;
                    }
                }
                return result;
            }

        }
        #endregion
    }
}
