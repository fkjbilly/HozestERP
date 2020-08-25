<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SettingsDetails.aspx.cs" Inherits="HozestERP.Web.ManageSystem.SettingsDetails"
    ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function closeWindows() {
         parent.RefeshGridView();
         layer_close();
         //window.parent.location.reload();
     }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 60px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
                名称:
            </td>
            <td>
                <CRM:SimpleTextBox ID="txtName" runat="server" ErrorMessage="名称不能为空." Width="100%"
                    PopupPosition="BottomRight" ValidationGroup="NotesGroup" />
            </td>
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
            <td>
                值:
            </td>
            <td>
                <CRM:SimpleTextBox ID="txtValue" TextMode="MultiLine" Height="100px" runat="server" ErrorMessage="值不能为空." Width="100%"
                    PopupPosition="BottomRight" ValidationGroup="NotesGroup" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtValue$txtValue"
                    ValidationExpression="^[\s\S]{0,2000}$" runat="server" ValidationGroup="NotesGroup"
                    Display="None" ErrorMessage="值不能超过2000字" />
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                    TargetControlID="RegularExpressionValidator1" HighlightCssClass="validatorCalloutHighlight"
                    PopupPosition="TopRight" />
            </td>
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
            <td>
                说明:
            </td>
            <td>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="70" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
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
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="NotesGroup" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" 
                    onclick="btnDelete_Click"  OnClientClick="return confirm('您确定要删除此条记录.');" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="关闭" OnClientClick="javascript:closeWindows();" />
            </td>
        </tr>
    </table>
</asp:Content>
