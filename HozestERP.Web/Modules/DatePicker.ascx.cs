using System;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Profile;
using AjaxControlToolkit;

namespace HozestERP.Web.Modules
{
    public partial class DatePicker : BaseAdministrationUserControl
    {
        #region Properties
        public bool ShowTime
        {
            get
            {
                return Convert.ToBoolean(ViewState["ShowTime"]);
            }
            set
            {
                ViewState["ShowTime"] = value;
            }
        }

        public CalendarExtender AjaxCalendar
        {
            get
            {
                return this.ajaxCalendar;
            }
        }

        public TextBox ctlDateTime
        {
            get
            {
                return this.txtDateTime;
            }
        }

        public DateTime? SelectedDate
        {
            get
            {
                DateTime inputDate;
                if (!DateTime.TryParse(txtDateTime.Text, out inputDate))
                {
                    return null;
                }
                return inputDate;
            }
            set
            {
                if (value.ToString().Equals("0001-01-01 00:00:00"))
                {
                    ajaxCalendar.SelectedDate = DateTime.Now;
                }
                else
                {
                    ajaxCalendar.SelectedDate = value;
                }
            }
        }

        public string Format
        {
            get
            {
                return ajaxCalendar.Format;
            }
            set
            {
                ajaxCalendar.Format = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtDateTime.Width;
            }
            set
            {
                txtDateTime.Width = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return txtDateTime.ValidationGroup;
            }
            set
            {
                this.txtDateTime.ValidationGroup = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.txtDateTime.Enabled;
            }
            set
            {
                this.txtDateTime.Enabled = value;
            }
        }
        #endregion
    }
}