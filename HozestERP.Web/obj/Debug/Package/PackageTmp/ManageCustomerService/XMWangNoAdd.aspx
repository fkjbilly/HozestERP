<%@ Page Language="C#" CodeBehind="XMWangNoAdd.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" Inherits="HozestERP.Web.ManageCustomerService.XMWangNoAdd" %>

   
<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register src="../Modules/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %> 
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>

<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 

<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
    <tbody>
            <tr> 
            <td style="width:80px" align="right">
             店铺名称: 
             </td>  
            <td align="left">
              <asp:DropDownList ID="ddlNickId" runat="server" Width="100%">
                </asp:DropDownList>
             </td>  
             </tr>
            <tr>
             <td style="width:80px" align="right">
             平台类型: 
             </td>  
             <td align="left">
              <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%">
              </asp:DropDownList>
             </td>  
             </tr>

            <tr>
             <td style="width:80px" align="right">
             旺旺号: 
             </td>  
             <td align="left">
            <asp:TextBox runat="server" ID="WangNo" Width="100%"></asp:TextBox>
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
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMWangNoAdd.Save %>"/>
            </td>
            
        </tr>
    </table>

   
</asp:Content>

