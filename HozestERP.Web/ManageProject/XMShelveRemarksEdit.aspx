<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMShelveRemarksEdit.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMShelveRemarksEdit" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="text-align: right;">
                    说明：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustomerRemark" TextMode="MultiLine" Height="80px"
                        Width="95%"></asp:TextBox>
                    <asp:Label runat="server" ID="lblCustomerRemark"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
