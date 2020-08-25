<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="InventoryAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.InventoryAdd" %>

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
                <td style="width: 140px" align="right">
                    产品名称
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lbProductName" runat="server"></asp:Label>
                </td>
                <td style="width: 140px" align="right">
                    入库仓库
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Literal ID="lbWareHoures" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    库存数量
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Literal ID="lbStorageCount" runat="server"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                    警戒值
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtWarningCount" runat="server" Text="0"></asp:TextBox>
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
