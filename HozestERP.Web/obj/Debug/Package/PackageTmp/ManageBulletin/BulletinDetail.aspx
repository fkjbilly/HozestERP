<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEditNoUpdatePanel.Master"
    AutoEventWireup="true" CodeBehind="BulletinDetail.aspx.cs" Inherits="HozestERP.Web.ManageBulletin.BulletinDetail"
    ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEditNoUpdatePanel.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/UploadFile.ascx" TagName="UploadFile" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectCustomer.ascx" TagName="SelectCustomer" TagPrefix="HozestERP" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript" src="../Script/popup.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 180px;">
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 180px;">
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 180px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                标题<font color="red">*</font>:
            </td>
            <td colspan="8">
                <HozestERP:SimpleTextBox ID="txtBulletinTitle" runat="server" Width="99%" ErrorMessage="标题不能为空！"
                    PopupPosition="BottomRight" ValidationGroup="DismissonGroup"></HozestERP:SimpleTextBox>
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
                类型<font color="red">*</font>:
            </td>
            <td style="width: 180px;">
                <HozestERP:CodeControl ID="ddlBulletinType" runat="server" CodeType="240" EmptyValue="true"
                    Width="100%" />
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                优先级别:
            </td>
            <td style="width: 180px;">
                <HozestERP:CodeControl ID="ddlPriorType" runat="server" CodeType="241" EmptyValue="true"
                    Width="100%" />
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                状态:
            </td>
            <td style="width: 180px;">
                <asp:TextBox ID="txtBulletinStatus" runat="server" Width="100%" SkinID="ReadOnlyText"
                    ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td style="width: 100px;">
                发送的用户<font color="red">*</font>：
            </td>
            <td colspan="8">
                <HozestERP:SelectCustomer ID="SelectMapping" ErrorMessage="请选择要发送的用户." ValidationGroup="DismissonGroup"
                    runat="server" PopupPosition="BottomRight" TextMode="MultiLine" Height="40px"
                    SessionPageID="BulletinDetail"></HozestERP:SelectCustomer>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px; vertical-align: top;">
                内容<font color="red">*</font>:
            </td>
            <td colspan="8">
                <FCKeditorV2:FCKeditor ID="txtRemark" runat="server" AutoDetectLanguage="false" Height="400px"
                    Width="99%" DefaultLanguage="zh-cn" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td style="width: 100px">
                生效日期<font color="red">*</font>:
            </td>
            <td style="width: 180px;">
                <HozestERP:DatePicker ID="txtEffectiveDate" runat="server" Format="yyyy-MM-dd"></HozestERP:DatePicker>
                <asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="txtEffectiveDate$txtDateTime"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ValidationGroup="DismissonGroup"
                    ErrorMessage="生效日期为必填."></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" PopupPosition="BottomRight"
                    TargetControlID="rfvValue" HighlightCssClass="validatorCalloutHighlight" />
            </td>
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px;">
                失效日期:
            </td>
            <td style="width: 180px;">
                <HozestERP:DatePicker ID="txtInvalidDate" runat="server" Format="yyyy-MM-dd"></HozestERP:DatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtInvalidDate$txtDateTime"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ValidationGroup="DismissonGroup"
                    ErrorMessage="失效日期为必填."></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="Validatorcalloutextender1"
                    PopupPosition="BottomRight" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 4px">
            </td>
            <td colspan="9">
                <HozestERP:UploadFile ID="uploadfile" runat="server" TableName="OA_Bulletin" />
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
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="DismissonGroup"
                    OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="返回" OnClientClick="javascript:window.location='BulletinManager.aspx';return false;" />
            </td>
        </tr>
    </table>
</asp:Content>
