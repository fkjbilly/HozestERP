<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PsnAccount.aspx.cs" Inherits="HozestERP.Web.ManageSystem.PsnAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
        border="0" cellspacing="0" cellpadding="3" width="99%">
        
        <%    if (base.SettingManager.GetSettingValueBoolean("Display.AllowCustomerSelectTheme"))
              {
        %>
        <tr>
            <th colspan="2" style="text-align: center; font-weight: bold; font-size: 17px;letter-spacing:10px;">
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
            <th colspan="2" style="text-align: center; font-weight: bold; font-size: 14px;">
                用户角色信息
            </th>
        </tr>
        <tr>
            <td width="120">
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
    </table>
    </form>
</body>
</html>
