using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{ 
    public partial class XMPremiumsDistribution : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (this.ExplanationId == 1) {

                //    this.lblExplanation.Text = "财务未通过说明:";
                //}
                //else if (this.ExplanationId == 2)
                //{

                //    this.lblExplanation.Text = "总监未通过说明:";
                //}
                //else {
                //    this.lblExplanation.Text = "说明:";
                //}
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("未通过说明");

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


        public string SelectPremiumsExplanation
        {
            get
            {
                try
                {
                    return (Session["SelectPremiumsExplanation"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["SelectPremiumsExplanation"] = value;
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var txtExplanation = this.txtExplanation.Text.Trim();
                if (txtExplanation != "")
                {
                    this.SelectPremiumsExplanation = txtExplanation.ToString();
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

        /// <summary>
        /// 财务未通过说明：1;总监未通过说明：2;
        /// </summary>
        //public int ExplanationId
        //{
        //    get
        //    {
        //        return CommonHelper.QueryStringInt("ExplanationId");
        //    }
        //}

    }
}