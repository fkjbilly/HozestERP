<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMWarehouseAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMWarehouseAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="right">
                    省
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlProvince" runat="server" Width="100%" OnSelectedIndexChanged="ddlProvince_Change"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    市
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlCity" runat="server" Width="100%" OnSelectedIndexChanged="ddlCity_Change"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    区（县）:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlCounty" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    主仓：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlMainWareHourese" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    仓库名
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtWarehouseName" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    项目
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    所属店铺
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlNick" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.XMWarehouseAdd.Save %>" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
