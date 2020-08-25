using System;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;
namespace HozestERP.Web.ManageFinance
{
    public partial class XMPaymentRequest : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initData();
                BindGrid(this.PaymentRequestID);
            }
        }

        private void initData()
        {
            //绑定收款单位
            var suppliers = base.XMSuppliersService.GetXMSuppliersListDirect();
            ddlSupplierList.Items.Clear();
            ddlSupplierList.DataSource = suppliers;
            ddlSupplierList.DataTextField = "SupplierName";
            ddlSupplierList.DataValueField = "Id";
            ddlSupplierList.DataBind();
            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayType.DataSource = codeList;
            this.ddlPayType.DataTextField = "CodeName";
            this.ddlPayType.DataValueField = "CodeID";
            this.ddlPayType.DataBind();
        }

        private void BindGrid(int paymentRequestID)
        {
            var paymentRequest = base.XMPaymentApplyService.GetXMPaymentApplyById(paymentRequestID);
            if (paymentRequest != null)
            {
                //获取付款申请人信息
                var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(paymentRequest.ApplicantID.Value);
                if (customerInfo != null)
                {
                    ltRequstDepartment.Text = customerInfo.DepartmentName;
                    ltRequester.Text = customerInfo.FullName;
                }
                dpLogDate.Value = paymentRequest.RequstDate.Value.ToShortDateString();
                txtNote.Text = paymentRequest.RequestFundsReason;
                ltPayMoney.Text = "人民币（大写）" + CmycurD(paymentRequest.PayAmounts) + "   ￥：" + paymentRequest.PayAmounts.ToString();
                ltPayMoney.Enabled = false;
                ddlPayType.SelectedValue = paymentRequest.PayMode.ToString();
                dpUserDate.Value = paymentRequest.UserDate.Value.ToShortDateString();
                ddlSupplierList.SelectedValue = paymentRequest.SupplierID.ToString();
                txtBankAcount.Text = paymentRequest.BankAcount;
                if (paymentRequest.IsAuditPerson != null)
                {
                    var auditInfo = base.CustomerInfoService.GetCustomerInfoByID(paymentRequest.IsAuditPerson.Value);
                    if (auditInfo != null)
                    {
                        ltIsaudit.Text = auditInfo.FullName;
                    }
                }
                ckbManagerIsAudit.Checked = paymentRequest.IsAudit.Value;
                CheckBox1.Checked = paymentRequest.FinancialConfirm.Value;
                ltIsAuditDate.Text = paymentRequest.IsAuditDate.ToString();
                if (paymentRequest.FinancialStatusPerson != null)
                {
                    var FinancialStatusInfo = base.CustomerInfoService.GetCustomerInfoByID(paymentRequest.FinancialStatusPerson.Value);
                    if (FinancialStatusInfo != null)
                    {
                        ltFinancialStatus.Text = FinancialStatusInfo.FullName;
                    }
                }

                if (paymentRequest.ConfirmPerson != null)
                {
                    var FinancialConfirmInfo = base.CustomerInfoService.GetCustomerInfoByID(paymentRequest.ConfirmPerson.Value);
                    if (FinancialConfirmInfo != null)
                    {
                        Literal1.Text = FinancialConfirmInfo.FullName;
                    }
                }
                Literal2.Text = paymentRequest.ConfirmDate.ToString();
                ckbFinanceIsAudit.Checked = paymentRequest.FinancialStatus.Value;
                ltFinanceIaAuditDate.Text = paymentRequest.FinancialStatusDate.ToString();
            }
        }


        /// <summary>
        /// 转换人民币大小金额
        /// </summary>
        /// <param name="num">金额</param>
        /// <returns>返回大写形式</returns>
        public string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字
            string str3 = "";    //从原num值中取出的值
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式
            j = str4.Length;      //找出最高位
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分

            //循环取出每一位需要转换的值
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);      //转换为数字
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.PaymentRequestID !=0)
            {
                XMPaymentApply payment = base.XMPaymentApplyService.GetXMPaymentApplyById(this.PaymentRequestID);
                if ((bool)payment.IsAudit || (bool)payment.FinancialStatus)
                {
                    base.ShowMessage("申请单已审核，不能修改！");
                    return;
                }
                payment.ContractNumber = txtNumber.Text.Trim();
                payment.RequestFundsReason = txtNote.Text.Trim();
                payment.PayMode = int.Parse(ddlPayType.SelectedValue);
                payment.SupplierID = ddlSupplierList.SelectedValue != "" ? int.Parse(ddlSupplierList.SelectedValue) : 1;
                payment.BankAcount = txtBankAcount.Text.Trim();
                payment.UpdateID = HozestERPContext.Current.User.CustomerID;
                payment.UpdateDate = DateTime.Now;
                base.XMPaymentApplyService.UpdateXMPaymentApply(payment);
                base.ShowMessage("操作成功！");
                BindGrid(payment.Id);
            }
            else
            {
                XMPaymentApply xmPaymentApply = new XMPaymentApply();
                decimal payAmounts = 0;
                decimal.TryParse(ltPayMoney.Text,out payAmounts);
                xmPaymentApply.PayAmounts = payAmounts;
                xmPaymentApply.PayMode = int.Parse(ddlPayType.SelectedValue); ;
                xmPaymentApply.SupplierID = ddlSupplierList.SelectedValue != "" ? int.Parse(ddlSupplierList.SelectedValue) : 1;
                xmPaymentApply.RequstDate = DateTime.Now;
                xmPaymentApply.UserDate = DateTime.Now;
                xmPaymentApply.IsAudit = false;
                xmPaymentApply.FinancialStatus = false;
                xmPaymentApply.ApplicantID = HozestERPContext.Current.User.CustomerID;
                xmPaymentApply.UpdateDate = DateTime.Now;
                xmPaymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
                xmPaymentApply.IsEnable = false;
                xmPaymentApply.FinancialConfirm = false;
                XMPaymentApplyService.InsertXMPaymentApply(xmPaymentApply);
                base.ShowMessage("操作成功！");
                BindGrid(xmPaymentApply.Id);
            }
        }

        /// <summary>
        /// 公司审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit1_Click(object sender, EventArgs e)
        {
            var payment = base.XMPaymentApplyService.GetXMPaymentApplyById(this.PaymentRequestID);
            if (payment != null)
            {
                if (payment.FinancialStatus.Value)
                {
                    payment.IsAudit = true;
                    payment.IsAuditDate = DateTime.Now;
                    payment.IsAuditPerson = HozestERPContext.Current.User.CustomerID;
                    base.XMPaymentApplyService.UpdateXMPaymentApply(payment);
                }
                else
                {
                    base.ShowMessage("财务未审核通过，无法公司审核！");
                    return;
                }
            }
            base.ShowMessage("操作成功！");
            BindGrid(payment.Id);
        }

        /// <summary>
        /// 公司反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditNO1_Click(object sender, EventArgs e)
        {
            var payment = base.XMPaymentApplyService.GetXMPaymentApplyById(this.PaymentRequestID);
            if (payment != null)
            {
                if (payment.FinancialStatus.Value)
                {
                    payment.IsAudit = false;
                    payment.IsAuditDate = DateTime.Now;
                    payment.IsAuditPerson = HozestERPContext.Current.User.CustomerID;
                    base.XMPaymentApplyService.UpdateXMPaymentApply(payment);
                }
                else
                {
                    base.ShowMessage("财务未审核通过，无法公司反审核！");
                    return;
                }
            }
            base.ShowMessage("操作成功！");
            BindGrid(payment.Id);
        }

        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceIsAudit1_Click(object sender, EventArgs e)
        {
            var payment = base.XMPaymentApplyService.GetXMPaymentApplyById(this.PaymentRequestID);
            if (payment != null)
            {
                payment.FinancialStatus = true;
                payment.FinancialStatusDate = DateTime.Now;
                payment.FinancialStatusPerson = HozestERPContext.Current.User.CustomerID;
                base.XMPaymentApplyService.UpdateXMPaymentApply(payment);
            }
            base.ShowMessage("操作成功！");
            BindGrid(payment.Id);
        }


        /// <summary>
        /// 财务反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceIsAuditNO1_Click(object sender, EventArgs e)
        {
            var payment = base.XMPaymentApplyService.GetXMPaymentApplyById(this.PaymentRequestID);
            if (payment != null)
            {
                payment.FinancialStatus = false;
                payment.FinancialStatusDate = DateTime.Now;
                payment.FinancialStatusPerson = HozestERPContext.Current.User.CustomerID;
                base.XMPaymentApplyService.UpdateXMPaymentApply(payment);
            }
            base.ShowMessage("操作成功！");
            BindGrid(payment.Id);
        }

        /// <summary>
        /// 财务确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hidBtnFinanceOkF1_Click(object sender, EventArgs e)
        {
            var payment = base.XMPaymentApplyService.GetXMPaymentApplyById(this.PaymentRequestID);
            if (payment != null)
            {
                if (payment.IsAudit.Value)
                {
                    payment.FinancialConfirm = true;
                    payment.ConfirmDate = DateTime.Now;
                    payment.ConfirmPerson = HozestERPContext.Current.User.CustomerID;
                    base.XMPaymentApplyService.UpdateXMPaymentApply(payment);
                }
                else
                {
                    base.ShowMessage("公司未审核通过，无法财务确认！");
                    return;
                }
            }
            base.ShowMessage("操作成功！");
            BindGrid(payment.Id);
        }

        public int PaymentRequestID
        {
            get
            {
                return CommonHelper.QueryStringInt("PaymentRequestID");
            }
        }



        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
    }
}