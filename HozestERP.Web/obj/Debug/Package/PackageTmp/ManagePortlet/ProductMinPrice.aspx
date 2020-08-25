<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductMinPrice.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.ProductMinPrice" %>

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
            var bulletins = base.BulletinService.GetProductMin();
            foreach (var item in bulletins)
            {
                string color = "red";
        %>
        <p>
            <a onclick="javascript:ShowModalDialog('ProductMinPriceDetails.aspx?brandTypeId=' + '<%=item.BulletinID %>');return false;"
                style="cursor: pointer;color:<%=color%>"><%=Server.HtmlEncode(item.BulletinTitle)%></a>
        </p>
        <%
            }
        %>
    </div>
    </form>
</body>
</html>

