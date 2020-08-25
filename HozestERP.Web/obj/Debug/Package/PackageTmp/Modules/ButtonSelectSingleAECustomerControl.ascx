<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonSelectSingleAECustomerControl.ascx.cs" Inherits="HozestERP.Web.Modules.ButtonSelectSingleAECustomerControl" %>
    <script language="javascript" type="text/javascript">
        function Show<asp:Literal ID="lblScript" runat="server"></asp:Literal>CustomerDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:650px;dialogHeight:400px;center:yes;");
            return true;
        }
    </script>

<asp:Button ID="btnAllocationOfClients" runat="server" Text="分配客户" 
    SkinID="button4" onclick="btnAllocationOfClients_Click" />
