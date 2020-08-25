<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEditNoUpdatePanel.Master"
    AutoEventWireup="true" CodeBehind="NotesDetails.aspx.cs" Inherits="HozestERP.Web.ManageSystem.NotesDetails" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEditNoUpdatePanel.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta content="IE=7" http-equiv="X-UA-Compatible" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px;">
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 200px;">
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">   标题:
            </td>
            <td colspan="5">
                <CRM:SimpleTextBox ID="txtTitle" runat="server" ErrorMessage="标题不能为空." Width="99%"
                    PopupPosition="BottomRight" ValidationGroup="NotesGroup" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                发布时间:
            </td>
            <td style="width: 200px;">
                <CRM:DatePicker ID="txtDateTime" runat="server" Format="yyyy-MM-dd"></CRM:DatePicker>
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                发布者:
            </td>
            <td style="width: 200px;">
                <CRM:SimpleTextBox ID="txtPromulgator" runat="server" ErrorMessage="发布者不能为空." PopupPosition="BottomRight"  ValidationGroup="NotesGroup" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                启用时间:
            </td>
            <td style="width: 200px;">
                <CRM:DatePicker ID="txtStartTime" runat="server"  Format="yyyy-MM-dd"></CRM:DatePicker>
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td colspan="2">
                <asp:CheckBox ID="chkPublished" runat="server" Text="发布" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td colspan="6">
                <FCKeditorV2:FCKeditor ID="txtDescription" runat="server" AutoDetectLanguage="false"
                    Height="350" Width="100%" DefaultLanguage="zh-cn" />
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
                <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="NotesGroup" 
                    onclick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="返回" OnClientClick="javascript:window.location='Notes.aspx';return false;" />
            </td>
        </tr>
    </table>
</asp:Content>
