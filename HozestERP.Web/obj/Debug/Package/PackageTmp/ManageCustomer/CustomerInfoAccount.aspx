<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoAccount.aspx.cs"
    Inherits="HozestERP.Web.ManageCustomer.CustomerInfoAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Script/CommonManager.js"></script>
        <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
        border="0" cellspacing="0" cellpadding="3" width="99%">
        <%    if (base.SettingManager.GetSettingValueBoolean("Display.AllowCustomerSelectTheme"))
              {
        %>
        <tr>
            <th colspan="2" style="text-align: center; font-weight: bold; font-size: 17px; letter-spacing: 10px;">
                我的账户
            </th>
        </tr>
        <tr>
            <td width="120">
                主题：
            </td>
            <td>
                <asp:DropDownList ID="ddlThemes" runat="server" Width="130">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
            </td>
        </tr>
        <%
              } %>
        <tr>
            <th colspan="3" style="text-align: center; font-weight: bold; font-size: 14px;">
                用户角色信息
            </th>
        </tr>
        <tr>
            <td width="160">
                用户名：
            </td>
            <td>
                <asp:Literal ID="litUserName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                角色：
            </td>
            <td>
                <asp:Literal ID="litRole" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                部门：
            </td>
            <td>
                <asp:Literal ID="litDep" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                所属项目：&nbsp;&nbsp;&nbsp;
                <input type="button" id="btnProjectRole" runat="server" value="设置项目" />
            </td>
            <td>
                <asp:Literal ID="litProjectList" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
