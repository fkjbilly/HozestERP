<%@ Control Language="C#" AutoEventWireup="true" Inherits="HozestERP.Web.Modules.EmailTextBox"
    CodeBehind="EmailTextBox.ascx.cs" %>
<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
    Display="None">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revValue" runat="server" ControlToValidate="txtValue"
    ValidationExpression=".+@.+\..+" ErrorMessage="邮箱格式有错."
    Display="None" />
    
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rvValueE" TargetControlID="revValue"
    HighlightCssClass="validatorCalloutHighlight" />
