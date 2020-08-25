<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateImageControl.ascx.cs"
    Inherits="HozestERP.Web.Modules.UpdateImageControl" %>

<script language="javascript" type="text/javascript">
    function ShowSelectSingleProductDetail(URL) {
        var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:450px;dialogHeight:350px;center:yes;");
        return true;
    }
</script>
<asp:Image ID="imgProduct" runat="server" /><input id="hidValue" runat="server" type="hidden" /><br />
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="lbtnUpImage" runat="server" onclick="lbtnUpImage_Click" >修改</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="lbtnRemove" runat="server" onclick="lbtnRemove_Click" >取消</asp:LinkButton>