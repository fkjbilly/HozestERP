<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
 AutoEventWireup="true" CodeBehind="XMCashBackApplicationDistribution.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMCashBackApplicationDistribution" %>
  

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table   border="0" cellspacing="0"  > 
             <tr>
          
            <td style="width: 105px; text-align:right">
                <%--<asp:Label ID="lblExplanation" runat="server"></asp:Label>--%>未通过说明<font color="red">*</font>:
                </td>
            <td style="width: 500px; text-align:left">  
               <HozestERP:SimpleTextBox ID="txtExplanation" runat="server"  Width="95%" Height="80"   TextMode="MultiLine"   
             ValidationGroup="ModuleValidationGroup" ErrorMessage="未通过说明为必填."/> 

               </td>  
        </tr>  
    </table> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0"> 
        <tr>
         <td style="text-align:right;">
          
         <asp:Button ID="Button1" SkinID="Button2" runat="server" Text="确定" OnClick="btnSave_Click"  ValidationGroup="ModuleValidationGroup" />
        </td>
        
        </tr>
    </table>
    
</asp:Content>
