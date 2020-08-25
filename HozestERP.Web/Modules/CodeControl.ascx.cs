using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;

namespace HozestERP.Web.Modules
{
    public partial class CodeControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(this.CodeType, false);

           // var newList = codeList.Where(p => p.CodeName != "整合部").ToList();

            this.ddlCodeList.DataSource = codeList;
            this.ddlCodeList.DataTextField = "CodeName";
            this.ddlCodeList.DataValueField = "CodeID";
            this.ddlCodeList.DataBind();
            if (this.EmptyValue)
            {
                this.ddlCodeList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            if (this.WhetherMandatory)
            {
                this.ddlCodeList.Items.Insert(0, new ListItem("", "0"));
            }
            base.OnInit(e);
        }

        [DefaultValue(false)]
        public bool EmptyValue
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool WhetherMandatory
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public int CodeType
        {
            get;
            set;
        }

        public Unit Width
        {
            get
            {
                return ddlCodeList.Width;
            }
            set
            {
                ddlCodeList.Width = value;
            }
        }

        public int SelectedValue
        {
            get
            {
                int codeID = 0;
                int.TryParse(this.ddlCodeList.SelectedValue, out codeID);
                return codeID;
            }
            set
            {
                CommonHelper.SelectListItem(this.ddlCodeList, value);
            }
        }

        public string text
        {
            get
            {
                string codetxt = string.Empty;
                return ddlCodeList.SelectedItem.Text;
            }
            set
            {
                CommonHelper.SelectListItem(this.ddlCodeList, value);
            }
        }


        public string ValidationGroup
        {
            get
            {
                return ddlCodeList.ValidationGroup;
            }
            set
            {
                this.ddlCodeList.ValidationGroup = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return ddlCodeList.Enabled;
            }
            set
            {
                ddlCodeList.Enabled = value;
            }
        }

    }
}