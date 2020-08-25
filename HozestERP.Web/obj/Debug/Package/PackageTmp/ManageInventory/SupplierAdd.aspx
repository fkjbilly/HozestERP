<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SupplierAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.SupplierAdd" %>

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
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px; font-weight: bold; font-size: small">
                新增供应商
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                供应商编码
            </td>
            <td style="width: 260px">
                <font color="red">保存后自动生成</font>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                供应商名称<font color="red">*</font>
            </td>
            <td style="width: 260px" colspan="2">
                <HozestERP:SimpleTextBox ID="txtSupplierName" runat="server" Width="200px" Text=""
                    ErrorMessage="供应商名称不能为空." ValidationGroup="ClientValidationGroup" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                联系人
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtContacter" runat="server" Width="80%"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                联系电话
            </td>
            <td style="width: 260px" colspan="2">
                <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                联系人QQ
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtQQ" runat="server" Width="80%"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                联系人手机
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                开户行
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtBankName" runat="server" Text="" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                开户行账号
            </td>
            <td style="width: 260px" colspan="2">
                <asp:TextBox ID="txtBankAcount" runat="server" Text="" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                税号
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtTaxNum" runat="server" Text="" Width="80%"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                传真
            </td>
            <td style="width: 260px" colspan="2">
                <asp:TextBox ID="txtFax" runat="server" Text="" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                地址
            </td>
            <td style="width: 260px" colspan="5">
                <HozestERP:SimpleTextBox ID="txtAddress" runat="server" Text="" Width="80%" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                备注
            </td>
            <td style="width: 260px" colspan="5">
                <asp:TextBox ID="txtNote" runat="server" Text="" Width="80%" TextMode="MultiLine"
                    Height="60px"></asp:TextBox>
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.SupplierAdd.Save %>" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
