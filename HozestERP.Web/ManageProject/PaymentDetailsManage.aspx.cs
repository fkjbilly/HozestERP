using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{ 

    public partial class PaymentDetailsManage : BaseAdministrationPage, IEditPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string typeId = this.ddlDealPaymentTypeId.SelectedValue.Trim();//赔付类型id

                this.PageSetUp(typeId);
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("赔付说明");
            //赔付类型
            this.ddlDealPaymentTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(203, false);
            ddlDealPaymentTypeId.DataSource = codeList;
            ddlDealPaymentTypeId.DataTextField = "CodeName";
            ddlDealPaymentTypeId.DataValueField = "CodeID";
            ddlDealPaymentTypeId.DataBind();  

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


        public string SelectPaymentDetails
        {
            get
            {
                try
                {
                    return (Session["SelectPaymentDetails"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["SelectPaymentDetails"] = value;
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ResultMsg = "";

              string typeId = this.ddlDealPaymentTypeId.SelectedValue.ToString();

              if (typeId == "477")//赠品
              {
                  ResultMsg = "补偿：" + this.txtProductName.Value + "(" + this.txtEditSpecifications.Text.Trim() + ")*" + this.txtProductNum.Text.Trim()+"/";
              }
              else if (typeId == "478")//返现
              {
                  ResultMsg = "补偿：" + this.txtPaymentMoney.Text + "元/";
              }
              else if (typeId == "479")//赠品及返现
              {
                  ResultMsg = "补偿：" + this.txtPaymentMoney.Text + "元/" + this.txtProductName.Value + "(" + this.txtEditSpecifications.Text.Trim() + ")*" + this.txtProductNum.Text.Trim() + "/";
              }

              if (ResultMsg != "")
                {
                    this.SelectPaymentDetails = ResultMsg;
                    this.JsWrite("closewin();"); 
                    this.JsWrite("window.opener.location.reload();");
                }

            }
            catch (Exception err)
            {
                base.ProcessException(err, false);

            }
        }



        protected void ddlDealPaymentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDealPaymentTypeId = (DropDownList)sender;
            string typeId = ddlDealPaymentTypeId.SelectedValue.Trim();//赔付类型id

            this.PageSetUp(typeId);

        } 

        public void PageSetUp(string typeId)
        {

            if (typeId == "477")//赠品
            {
                this.TD1.Visible = false;//赔付金额 DIV 隐藏
                this.TD2.Visible = true;//商品名称信息 DIV 显示
            }
            else if (typeId == "478")//返现
            {
                this.TD1.Visible = true;//赔付金额 DIV 显示
                this.TD2.Visible = false;//商品名称信息 DIV 隐藏
            }
            else if (typeId == "479")//赠品及返现
            {
                this.TD1.Visible = true;//赔付金额 DIV 显示
                this.TD2.Visible = true;//商品名称信息 DIV 显示
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