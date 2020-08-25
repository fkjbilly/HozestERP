<%@ Page Language="C#" CodeBehind="SocialSecurityFundAdd.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageCustomer.SocialSecurityFundAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td colspan='4'>
                </td>
            </tr>
            <tr>
                <td colspan='4' align="center">
                    <font color='blue' size='3'><b>社保公积金信息</b></font>
                </td>
            </tr>
            <tr>
                <td colspan='4' align="left">
                    <font size='3'><b>
                        <%=Year%>年<%=Month%>月</b></font>
                </td>
            </tr>
            <tr>
                <td colspan='4'>
                    <font color='blue' size='3'><b>个人人信息</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    姓名:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtName" Width="100%" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    部门:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtDepartment" Width="100%" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    管理职级:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtRankManagement" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    岗位:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtPost" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    户籍:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtHouseholdRegister" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    险种:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtInsuranceType" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>养老</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    养老基数:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtPensionBase" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    养老公司部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtPensionCompany" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    养老个人部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtPensionPerson" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>医疗</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    医疗基数:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtMedicalCareBase" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    医疗公司部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtMedicalCareCompany" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    医疗个人部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtMedicalCarePerson" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>失业</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    失业基数:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtUnemploymentBase" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    失业公司部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtUnemploymentCompany" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    失业个人部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtUnemploymentPerson" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>工伤</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    工伤基数:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtInjuryJobBase" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    工伤公司部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtInjuryJobCompany" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>生育</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    生育基数:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtBirthBase" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    生育公司部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtBirthCompany" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>公积金</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    公积金基数:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtAccumulationFundBase" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    公积金公司部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtAccumulationCompany" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    公积金个人部分:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtAccumulationFundPerson" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font color='blue' size='3'><b>合计</b></font>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    公司承担:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtCompanyTotal" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px" align="right">
                    个人承担:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtPersonTotal" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 90px" align="right">
                    总计:
                </td>
                <td align="left" style="width: 150px">
                    <asp:TextBox runat="server" ID="txtTotal" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageCustomer.SocialSecurityFundAdd.Save %>" />
            </td>
        </tr>
    </table>
</asp:Content>
