<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMActivityTypeAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMActivityTypeAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                活动名称<font color="red">*</font>
            </td>
            <td style="width: 260px">
                <HozestERP:SimpleTextBox ID="txtActivityTypeName" runat="server" Width="200px" Text=""
                    ErrorMessage="活动类型名称不能为空." ValidationGroup="ClientValidationGroup" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                &nbsp;
            </td>
            <td style="width: 260px">
                &nbsp;
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
                    Visible="<%$CRMIsActionAllowed:ManageInventory.XMActivityTypeAdd.Save %>" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
