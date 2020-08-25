using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.Modules
{
    public partial class DateTimePicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Value
        {
            get
            {
                return txtDateTime.Value;
            }
            set
            {
                txtDateTime.Value = value;
            }
        }
    }
}