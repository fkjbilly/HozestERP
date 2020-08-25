<%@ Page Language="C#" CodeBehind="LogisticsAgingAdd.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageSystem.LogisticsAgingAdd" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <%--<tr>
                <td style="width: 80px" align="right">
                    线路:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtLine" Width="100%"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td style="width: 80px" align="right">
                    始发省:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtDepartureProvince" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    始发城市:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtDepartureCity" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    途经城市:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtPathway" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    预计到达时效:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtPathwayDate" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    目的省:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtDestinationProvince" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    目的城市:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtDestinationCity" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    预计到达时效:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtDestinationDate" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    南方北方:
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlIsSouth" Width="100%">
                        <asp:ListItem Value="1">南方</asp:ListItem>
                        <asp:ListItem Value="0">北方</asp:ListItem>
                    </asp:DropDownList>
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
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageSystem.LogisticsAgingAdd.Save %>" />
            </td>
        </tr>
    </table>
</asp:Content>
