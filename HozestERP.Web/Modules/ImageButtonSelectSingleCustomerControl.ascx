<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageButtonSelectSingleCustomerControl.ascx.cs"
    Inherits="HozestERP.Web.Modules.ImageButtonSelectSingleCustomerControl" %>
    
    <script language="javascript" type="text/javascript">
        function Show<asp:Literal ID="lblScript" runat="server"></asp:Literal>CustomerDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:650px;dialogHeight:400px;center:yes;");
            return true;
        }
    </script>
      
<asp:ImageButton ID="btnAllocationOfClients" runat="server" Text="分配客户"   
 onclick="btnAllocationOfClients_Click"   />

