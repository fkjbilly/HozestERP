using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{  
    public partial class AdvanceApplicationFinanceOk : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("财务确认");

        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }
        #endregion


        public string SessionPageID
        {
            get
            {
                return CommonHelper.QueryString("SessionPageID");
            }
        }


        public string SelectFinanceOkId
        {
            get
            {
                try
                {
                    return (Session["SessionFinanceOkId"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["SessionFinanceOkId"] = value;
            }
        }


        public string SelectPayTypeId
        {
            get
            {
                try
                {
                    return (Session["SessionPayTypeId"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["SessionPayTypeId"] = value;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var txtFinanceOk = this.txtFinanceOk.SelectSingleCustomer.CustomerID; 
                if (txtFinanceOk != 0)
                {
                    this.SelectFinanceOkId = txtFinanceOk.ToString();
                    this.SelectPayTypeId = this.ccPayTypeId.SelectedValue.ToString();

                    this.JsWrite("closewin();");

                } 

            }
            catch (Exception err)
            {
                base.ProcessException(err, false);

            }
        } 
        #region public void JsWrite(string paramAction)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "JS", paramAction, true);
        }
        #endregion

       

    }
}