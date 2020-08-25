using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomer
{
    public partial class CustomerInfoDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CustomerID <= 0)
                return;
            this.PBase.AutoLoad.Url = "CustomerInfoDetailBase.aspx?CustomerID=" + this.CustomerID;
            this.PAvatar.AutoLoad.Url = "CustomerInfoDetailAvatar.aspx?CustomerID=" + this.CustomerID;
            this.PAccount.AutoLoad.Url = "CustomerInfoAccount.aspx?CustomerID=" + this.CustomerID;
            this.PPassWord.AutoLoad.Url = "CustomerInfoSet.aspx?CustomerID=" + this.CustomerID;
        }

        public int CustomerID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }
    }
}