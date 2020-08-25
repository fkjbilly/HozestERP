<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMAdjustFactroyPrice.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMAdjustFactroyPrice" %>

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
                调整出厂价
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 50px">
                平台<font color="red">*</font>
            </td>
            <td style="width: 60px">
                <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="90%" AutoPostBack="true" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 50px">
                <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="95%" Enabled="true">
                    <asp:ListItem Value="1" Text="创单时间"></asp:ListItem>
                    <asp:ListItem Value="2" Text="付款时间"></asp:ListItem>
                    <asp:ListItem Value="3" Text="发货时间"></asp:ListItem>
                    <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 80px">
                <input id="txtPayDateStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 90%;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPayDateStart"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="起始时间不能为空."
                    ValidationGroup="ClientValidationGroup">*</asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                    PopupPosition="TopRight" />
            </td>
            <td style="width: 20px">
                到
            </td>
            <td style="width: 80px; text-align: left">
                <input id="txtPayDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 90%;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPayDateStart"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="创单起始时间不能为空！"
                    ValidationGroup="ClientValidationGroup">*</asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                    PopupPosition="TopRight" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <table>
                    <tr>
                        <td style="width: 8px; height: 8px">
                        </td>
                        <td style="text-align: left">
                            <asp:CheckBox ID="chkByCount" Text="是否限制数量" runat="server" AutoPostBack="true" OnCheckedChanged="chkByCount_Changed" />
                        </td>
                        <td style="text-align: right">
                            数量
                        </td>
                        <td style="width: 8px; height: 8px">
                        </td>
                        <td>
                            <asp:TextBox ID="txtCount" runat="server" Width="90%" />
                        </td>
                        <td style="width: 8px; height: 8px">
                        </td>
                        <td style="width: 125px; text-align: right;">
                            调整后出厂价<font color="red">*</font>
                        </td>
                        <td style="width: 80px; text-align: left">
                            <HozestERP:SimpleTextBox ID="txtAdjustFactroyPrice" runat="server" Text="0" Width="90%"
                                ErrorMessage="调整后出厂价不能为空！" ValidationGroup="ClientValidationGroup" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 24px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="width: 8px; height: 8px">
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
