<%@ Page Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"  AutoEventWireup="true" 
CodeBehind="XMOrderInfoRemarkEdit.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderInfoRemarkEdit" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %> 
<%@ Register src="../Modules/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %> 
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>  
            <tr>
                <td style=" width:20%; text-align:right;">
                    备注：
                </td>
                <td style=" width:80%;">
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Height="45px" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style=" width:20%; text-align:right;">
                    客服备注：
                </td>
                <td style=" width:80%;">
                    <asp:TextBox runat="server" ID="txtCustomerRemark" TextMode="MultiLine" Height="45px" Width="80%"></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoRemarkEdit.XMOrderInfoRemarkSave %>"/>
            </td>
        </tr>
    </table>
</asp:Content>
