<%@ Page Language="C#" CodeBehind="BusinessDataOtherAdd.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" Inherits="HozestERP.Web.ManageBusiness.BusinessDataOtherAdd" %>
   
<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register src="../Modules/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %> 
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomer" TagPrefix="SHIBR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript">
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="3">
    <tbody>
            <tr><td></td></tr>
            <tr>
            <td style="width:10%" align="right">
            客户:
            </td>
            <td align="left" width="40%">
            <asp:TextBox runat="server" ID="txtObject" Width="90%"></asp:TextBox>
            </td>
            <td></td>
            <td style="width:10%" align="right">
            业务类型:
            </td>
            <td align="left" width="40%">
            <CRM:CodeControl ID="ddlBusinessType" runat="server" CodeType="218" EmptyValue="false"
                    Width="90%" />
            </td>
            </tr>

            <tr><td></td></tr>

            <tr>
            <td align="right">
             金额类型: 
             </td>  
             <td align="left">
              <CRM:CodeControl ID="ddlAmountType" runat="server" CodeType="214" EmptyValue="false"
                    Width="90%" />
             </td> 
             <td></td>
             <td align="right">
             金额: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtAmount" Width="90%"></asp:TextBox>
             </td>
            </tr>

            <tr><td></td></tr>

            <tr>
            <td align="right">
             归属部门: 
             </td>
             <td align="left">
              <asp:DropDownList ID="ddlBelongingDep" Width="90%" runat="server" OnSelectedIndexChanged="ddlBelongingDep_Changed" AutoPostBack="true">
                </asp:DropDownList>
             </td> 
             <td></td>
             <td align="right">
             归属项目: 
             </td>  
             <td align="left">
              <asp:DropDownList ID="ddlBelongingProject" Width="90%" runat="server">
                </asp:DropDownList>
             </td>
            </tr>            

            <tr><td></td></tr>

            <tr>
             <td align="right">
             归属人: 
             </td>  
             <td align="left">
              <SHIBR:SelectSingleCustomer ID="ShibrBelongingName" runat="server" ErrorMessage="请选择姓名？"
                    PopupPosition="BottomRight" ValidationGroup="DismissonGroup" CustomerStatus="2" SessionPageID="ShibrBelongingName">
               </SHIBR:SelectSingleCustomer>
             </td>
            </tr>      

            <tr><td></td></tr>

            <tr>
            <td align="right">
             备注: 
             </td>  
             <td align="left" colspan="4">
              <asp:TextBox runat="server" ID="txtRemark" Width="96%" TextMode="MultiLine" Rows="5" Height="75px" Wrap="true"></asp:TextBox>
             </td>
            </tr>

            <tr><td colspan="5" align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataOtherAdd.Save %>"/>
            </td>
            </tr>
    </tbody>
  </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>

