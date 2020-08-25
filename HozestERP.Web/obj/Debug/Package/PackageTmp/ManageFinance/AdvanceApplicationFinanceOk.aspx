<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
 AutoEventWireup="true" CodeBehind="AdvanceApplicationFinanceOk.aspx.cs" Inherits="HozestERP.Web.ManageFinance.AdvanceApplicationFinanceOk" %> 

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table   border="0" cellspacing="0"  > 
             <tr>
          
            <td style="width: 60px; text-align:right">
                领款人<font color="red">*</font>:
                </td>
            <td style="width: 200px; text-align:left"> 
               <HozestERP:SelectSingleCustomerControl ID="txtFinanceOk" runat="server" ErrorMessage="领款人为必填."  
                    PopupPosition="BottomLeft"    ValidationGroup="ModuleValidationGroup"   SessionPageID="OperationFinanceOk" /> 
               </td>
               <td style="width: 80px; text-align:right">
                领款类型<font color="red">*</font>:
                </td>
                <td style="width: 200px; text-align:left"> 
                <HozestERP:CodeControl ID="ccPayTypeId" runat="server" CodeType="186"  Width="100%" />
                </td>
                 

        </tr>  
    </table> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0"> 
   <%--   --%>
        <tr>
         <td style="text-align:right;">
          
         <asp:Button ID="Button1" SkinID="Button2" runat="server" Text="确定" OnClick="btnSave_Click"  ValidationGroup="ModuleValidationGroup" />
        </td>
        
        </tr>
    </table>
    
</asp:Content>
