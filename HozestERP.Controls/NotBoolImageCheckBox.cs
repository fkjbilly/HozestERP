using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Controls
{
    public class NotBoolImageCheckBox : DropDownList
    {
        protected override void Render(HtmlTextWriter output)
        {
            string value = this.SelectedValue.ToString();
            var image = new Image();
            image.ID = this.ClientID + "_Image";
            image.AlternateText = value;
            if (!this.ShowCheckBox)
            {
                base.Style.Add("display", "none");
            }
            if (value == "1")
            {
                image.ImageUrl = this.ImageChecked;
            }
            else if (value == "0")
            {
                image.ImageUrl = this.ImageUnchecked;
            }
            else if (value == "2")
            {
                image.ImageUrl = this.ImagePartChecked;
            }
            image.RenderControl(output);
            base.Render(output);
        }

        [Bindable(true), DefaultValue(0), Description("Specifies Image for the Checked Image"), Category("Appearance")]
        public string ImageChecked
        {
            get
            {
                string str = (string)this.ViewState["ImageChecked"];
                if (str == null)
                {
                    return "~/images/checked.gif";
                }
                return str;
            }
            set
            {
                this.ViewState["ImageChecked"] = value;
            }
        }

        [Bindable(true), DefaultValue(0), Description("Specifies Image for the Checked Image"), Category("Appearance")]
        public string ImagePartChecked
        {
            get
            {
                string str = (string)this.ViewState["ImagePartChecked"];
                if (str == null)
                {
                    return "~/images/help-s.png";
                }
                return str;
            }
            set
            {
                this.ViewState["ImagePartChecked"] = value;
            }
        }

        [Category("Appearance"), Description("Specifies Image for the Checked Image"), Bindable(true), DefaultValue(0)]
        public string ImageUnchecked
        {
            get
            {
                string str = (string)this.ViewState["ImageUnchecked"];
                if (str == null)
                {
                    return "~/images/unchecked.gif";
                }
                return str;
            }
            set
            {
                this.ViewState["ImageUnchecked"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(0), Description("Show or hide the checkbox")]
        public bool ShowCheckBox
        {
            get
            {
                if (this.ViewState["ShowCheckBox"] == null)
                {
                    return false;
                }
                return (bool)this.ViewState["ShowCheckBox"];
            }
            set
            {
                this.ViewState["ShowCheckBox"] = value;
            }
        }

        [Category("Appearance"), Description("Specifies Image for the Checked Image"), Bindable(true), DefaultValue(0)]
        public override string SelectedValue
        {
            get
            {
                string str = (string)this.ViewState["SelectedValue"];
                return str;
            }
            set
            {
                this.ViewState["SelectedValue"] = value;
            }
        }
    }
}