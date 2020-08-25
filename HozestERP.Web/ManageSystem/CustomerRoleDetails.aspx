<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="CustomerRoleDetails.aspx.cs" Inherits="HozestERP.Web.ManageSystem.CustomerRoleDetails" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px;">
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
                父角色:
            </td>
            <td>
                <asp:DropDownList ID="ddlParentCustomerRole" runat="server" Width="200">
                </asp:DropDownList>
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td>
            </td>
        </tr>
         <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px;">
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
                名称:
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtName" runat="server" ErrorMessage="名称不能为空." Width="99%"
                    PopupPosition="BottomRight" ValidationGroup="RoleGroup" />
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Text="发布" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px;">
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
                说明
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="100%"
                    Height="40px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px;">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增节点" SkinID="button4"   ValidationGroup="RoleGroup"  onclick="btnAdd_Click"  />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="RoleGroup" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
