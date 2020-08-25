<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMAdjustPurchasePrice.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMAdjustPurchasePrice" %>

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
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 50px; font-weight: bold; font-size: large">
                调整采购价
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
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
            <td style="width: 50px">
                平台<font color="red">*</font>
            </td>
            <td style="width: 60px">
                <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="90%" AutoPostBack="true" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 50px">
                采购时间
            </td>
            <td style="width: 80px">
                <input id="txtPayDateStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 90%;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPayDateStart"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="起始时间不能为空！"
                    ValidationGroup="ClientValidationGroup">*</asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                    PopupPosition="TopRight" />
            </td>
            <td style="width: 20px">
                到
            </td>
            <td style="width: 80px">
                <input id="txtPayDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 90%;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPayDateStart"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="结束时间不能为空！"
                    ValidationGroup="ClientValidationGroup">*</asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                    PopupPosition="TopRight" />
            </td>
            <td style="width: 10px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 50px">
                调整后采购价<font color="red">*</font>
            </td>
            <td style="width: 60px">
                <HozestERP:SimpleTextBox ID="txtAdjustPurchasePrice" runat="server" Text="0" Width="80%"
                    ErrorMessage="调整后采购价不能为空！" ValidationGroup="ClientValidationGroup" />
            </td>
            <td colspan="6" style="text-align: right">
            </td>
        </tr>
        <tr>
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
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 50px">
            </td>
            <td style="width: 60px">
            </td>
            <td colspan="6" style="text-align: right;">
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    SkinID="button4" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>
