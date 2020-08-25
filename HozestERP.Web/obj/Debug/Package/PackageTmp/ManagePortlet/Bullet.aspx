<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bullet.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.Bullet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
            var bulletins = base.BulletinService.GetStartBulletin();
            foreach (var item in bulletins)
            {
                string color = item.PriorType.CodeNO;
        %>
        <p>
            <a onclick="javascript:ShowModalDialog('BulletinsDetail.aspx?BulletinID=' + '<%=item.BulletinID %>');return false;"
                style="cursor: pointer;color:<%=color%>">[<%=item.BulletinType.CodeName %>]&nbsp;<%=Server.HtmlEncode(item.BulletinTitle)%>&nbsp;&nbsp;&nbsp;
                <%=DateTimeHelper.ConvertToUserTime(item.ReleasedDate, DateTimeKind.Utc).ToString("yyyy-MM-dd")%></a>
        </p>
        <%
            }
        %>
    </div>
    </form>
</body>
</html>
