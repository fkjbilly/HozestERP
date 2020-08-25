<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderWarning.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.OrderWarning" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">

        function ShowModalDialog(Url) {
            window.open(Url, "", "width=800,height=500,resizable=yes,scrollbars=yes");
        }
    </script>
</head>
<body style="background-color:White;">
    <form id="form1" runat="server">
    <div class="portlet_content">
        <%
            var bulletin = base.BulletinService.GetOrderWarning();
        %>
        <p>
            <a onclick="javascript:ShowModalDialog('OrderWarningDetails.aspx');return false;"
                style="cursor: pointer;color:red"><%=Server.HtmlEncode(bulletin.BulletinTitle)%></a>
        </p>

    </div>
    </form>
</body>
</html>
