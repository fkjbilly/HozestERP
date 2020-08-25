<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMPaymentRequest.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMPaymentRequest" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px; font-weight: bold; font-size: large" colspan="9">
                付款申请单
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px" colspan="10">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                申请部门：
            </td>
            <td style="width: 260px">
                <asp:Literal ID="ltRequstDepartment" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 180px">
                申请日期： <font color="red">*</font>
            </td>
            <td style="width: 260px">
                <input id="dpLogDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 80%;" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                合同编号：
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                请款原因 :
            </td>
            <td style="width: 260px" colspan="7">
                <asp:TextBox ID="txtNote" runat="server" Text="" Width="92.5%" TextMode="MultiLine"
                    Height="60px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                付款金额 :
            </td>
            <td style="width: 160px" colspan="4">
                <asp:TextBox ID="ltPayMoney" runat="server" Width="98%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                付款方式：
            </td>
            <td style="width: 260px">
                <asp:DropDownList ID="ddlPayType" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                用款日期 :
            </td>
            <td style="width: 260px">
                <input id="dpUserDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 80%;" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px">
                收款单位 :
            </td>
            <td style="width: 60px">
                <asp:DropDownList ID="ddlSupplierList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                银行账号 :
            </td>
            <td style="width: 160px" colspan="4">
                <asp:TextBox ID="txtBankAcount" runat="server" Text="" Width="98%"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                申请人 :
            </td>
            <td style="width: 260px" colspan="4">
                <asp:Literal ID="ltRequester" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                财务审核
            </td>
            <td style="width: 260px">
                <asp:Literal ID="ltFinancialStatus" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                财务是否审核
            </td>
            <td style="width: 260px">
                <asp:CheckBox ID="ckbFinanceIsAudit" runat="server" Enabled="false" />
            </td>
            <td style="width: 200px">
                财务审核时间
            </td>
            <td style="width: 260px">
                <asp:Literal ID="ltFinanceIaAuditDate" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                公司审核
            </td>
            <td style="width: 260px">
                <asp:Literal ID="ltIsaudit" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 180px">
                公司是否审核
            </td>
            <td style="width: 260px">
                <asp:CheckBox ID="ckbManagerIsAudit" runat="server" Enabled="false" />
            </td>
            <td style="width: 200px">
                公司审核时间
            </td>
            <td style="width: 260px">
                <asp:Literal ID="ltIsAuditDate" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                财务确认
            </td>
            <td style="width: 260px">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 160px">
                财务是否确认
            </td>
            <td style="width: 260px">
                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" />
            </td>
            <td style="width: 200px">
                财务确认时间
            </td>
            <td style="width: 260px">
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPaymentRequest.Save %>" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnFinanceIsAudit1" SkinID="button4" runat="server" Text="财务审核" OnClick="btnFinanceIsAudit1_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.FinanceIsAudit %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnFinanceIsAuditNO1" SkinID="button4" runat="server" Text="财务反审核"
                    OnClick="btnFinanceIsAuditNO1_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.FinanceIsAuditNO %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnIsAudit1" SkinID="button4" runat="server" Text="公司审核" OnClick="btnIsAudit1_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.IsAudit %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnIsAuditNO1" SkinID="button4" runat="server" Text="公司反审核" OnClick="btnIsAuditNO1_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.IsAudit %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="hidBtnFinanceOkF1" runat="server" SkinID="button4" Text="财务确认" ToolTip="财务确认"
                    OnClick="hidBtnFinanceOkF1_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.FinanceOkF %>" />
            </td>
        </tr>
    </table>
</asp:Content>
