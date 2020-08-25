<%@ Page Language="C#" CodeBehind="CustomerSalaryDetail.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" Inherits="HozestERP.Web.ManageCustomer.CustomerSalaryDetail" %>
   
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
<script type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="3">
    <tbody>
    <tr>
        <td colspan='8' align="center"><font size='5'><strong>薪资单</strong></font></td>
    </tr>
    <tr><td colspan='8'></tr>
    <tr>
        <td colspan='4' align="left"><font color='blue' size='3'><b>个人信息</b></font></td>
        <td colspan='4' align="right"><font size='3'><b><%=Year%>年<%=Month%>月</b></font></td>
    </tr>
            <tr>
            <td style="width:60px" align="right">
            姓名:
            </td>
            <td align="left">
            <asp:TextBox runat="server" ID="txtName" Width="100%" ReadOnly="true"></asp:TextBox>
            </td>

            <td style="width:60px" align="right">
            部门:
            </td>
            <td align="left">
            <asp:TextBox runat="server" ID="txtDepartment" Width="100%" ReadOnly="true"></asp:TextBox>
            </td>

            <td style="width:60px" align="right">
             性别: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtGender" Width="100%" ReadOnly="true"></asp:TextBox>
             </td> 

             <td style="width:60px" align="right">
             身份证号: 
             </td>  
             <td align="left" style="width:135px">
              <asp:TextBox runat="server" ID="txtIDNumber" Width="100%" ReadOnly="true"></asp:TextBox>
             </td>
             
            </tr>
    <tr><td colspan='8'></tr>
    <tr>
        <td colspan='8' align="left"><font color='blue' size='3'><b>薪资明细</b></font></td>
    </tr>

            <tr>

             <td style="width:60px" align="right">
             基本工资: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtBasePay" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             基本扣款: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtBasePayDebit" Width="100%" ></asp:TextBox>
             </td> 

             <td style="width:60px" align="right">
             补款: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtReplenishment" Width="100%" ></asp:TextBox>
             </td> 

             <td style="width:60px" align="right">
             其他扣款: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtDebit" Width="100%" ></asp:TextBox>
             </td>

             </tr>
             
             <tr>

             <td style="width:60px" align="right">
             绩效工资: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtMeritPay" Width="100%" ></asp:TextBox>
             </td> 

             <td style="width:60px" align="right">
             绩效系数: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtPerformanceCoefficient" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             绩效扣款: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtAbsenceDutyDebit" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             实发绩效: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtRealPerformance" Width="100%" ></asp:TextBox>
             </td>

            </tr>

            <tr>
             <td style="width:60px" align="right">
             业绩提成: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtPerformanceRoyalty" Width="100%" ></asp:TextBox>
             </td>
             <td style="width:60px" align="right">
             奖励: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtReward" Width="100%" ></asp:TextBox>
             </td> 

             <td style="width:60px" align="right">
             补贴: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtSubsidies" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             <font><strong>应发工资:</strong></font>
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtShouldSalary" Width="100%" ></asp:TextBox>
             </td>            
             
            </tr>
    <tr><td colspan='8'></tr>
    <tr>
        <td colspan='8' align="left"><font color='blue' size='3'><b>个人社保公积金总额</b></font></td>
    </tr>

            <tr>

             <td style="width:60px" align="right">
             养老: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtPension" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             医疗: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtMedicalCare" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             失业: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtUnemployment" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             公积金: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtAccumulationFund" Width="100%" ></asp:TextBox>
             </td>

            </tr>

            <tr>

             <td style="width:60px" align="right">
             <font><strong>代扣总额: </strong></font>
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtSocialSecurityTotal" Width="100%" ></asp:TextBox>
             </td>

             </tr>
    <tr><td colspan='8'></tr>
    <tr>
        <td colspan='8' align="left"><font color='blue' size='3'><b>其他</b></font></td>
    </tr>

             <tr>

             <td style="width:60px" align="right">
             通讯费: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtCommunicationFee" Width="100%" ></asp:TextBox>
             </td> 

             <td style="width:60px" align="right">
             个税: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtIndividualIncomeTax" Width="100%" ></asp:TextBox>
             </td>

             <td style="width:60px" align="right">
             财务扣款: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtFinanceCharge" Width="100%" ></asp:TextBox>
             </td>

            </tr>
            <tr><td colspan='8'></tr>
            <tr>

             <td style="heigh:100%" align="right" colspan="4">
             <font size='4'><strong>实发工资:</strong></font>
             </td>

             <td align="left" style="heigh:100%" colspan="4">
              <asp:TextBox runat="server" ID="txtRealSalary" Width="25%" BorderWidth="0px" 
                     Font-Bold="True" Font-Size="Large" ></asp:TextBox>
             </td>

            </tr>

    </tbody>
  </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
  <table border="0" cellpadding="0" cellspacing="0"> 

        <tr>
        <td style="width: 10px"></td> 
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageCustomer.CustomerSalaryDetail.Save %>"/>
            </td>
            
        </tr>
    </table>

   
</asp:Content>

