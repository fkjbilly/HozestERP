<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="EnterprisesDetails.aspx.cs" Inherits="HozestERP.Web.ManageSystem.EnterprisesDetails"
    ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/EmailTextBox.ascx" TagName="EmailTextBox" TagPrefix="CRM" %>
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
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                名称<font color="red">*</font>:
            </td>
            <td style="width: 200px;">
                <CRM:SimpleTextBox ID="txtEntName" runat="server" ErrorMessage="名称不能为空." PopupPosition="BottomRight"
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                电话:
            </td>
            <td>
                <asp:TextBox ID="txtEntTel" runat="server"></asp:TextBox>
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
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                传真:
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtEntFax" runat="server"></asp:TextBox>
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                电子邮件:
            </td>
            <td>
                <CRM:EmailTextBox ID="txtEntEmail" runat="server" PopupPosition="BottomRight"
                    ValidationGroup="ModuleValidationGroup" />
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
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                网址:
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtEntWebSite" runat="server"></asp:TextBox>
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                邮编:
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtEntZip" runat="server"> </asp:TextBox>
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
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                开户行:
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtEntBank" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                序列<font color="red">*</font>:
            </td>
            <td style="width: 200px;">
                <CRM:NumericTextBox ID="txtDisplayOrder" runat="server" RangeErrorMessage="请输入正确的整数."
                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup" MaximumValue="999999"
                    MinimumValue="-999999" />
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
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                地址:
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtEntAddress" runat="server" Width="436px"></asp:TextBox>
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
            <td style="width: 100px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                账号:
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtEntBankAccount" runat="server" Width="436px"></asp:TextBox>
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
            <td style="width: 100px;">
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
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="关闭" OnClientClick="javascript:window.close();" />
            </td>
        </tr>
    </table>
</asp:Content>
