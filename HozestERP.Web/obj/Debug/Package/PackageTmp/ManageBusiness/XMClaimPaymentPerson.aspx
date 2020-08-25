<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMClaimPaymentPerson.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.XMClaimPaymentPerson" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                交款人/报销人：
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtPaymentPerson" runat="server"></asp:TextBox>
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
            <td style="width: 260px;">
                <asp:Button ID="btnSave" runat="server" Text="保存" Visible="<%$CRMIsActionAllowed:ManageBusiness.XMClaimPaymentPerson.SavePaymentPerson %>"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
