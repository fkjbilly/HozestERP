<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoSet.aspx.cs"
    Inherits="HozestERP.Web.ManageCustomer.CustomerInfoSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
        border="0" cellspacing="0" cellpadding="3" width="99%">
        <tr>
            <th colspan="2" style="text-align: center; font-weight: bold; font-size: 17px;letter-spacing:10px;">
                修改密码
            </th>
        </tr>
        <tr>
            <td width="120">
                原始密码：
            </td>
            <td>
                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="130"  
                Visible="<% $CRMIsActionAllowed:CustomerInfoSet.NotHasOldPwd%>"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="120">
                新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="130"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPwd"
                    ErrorMessage="新密码不能为空." ToolTip="新密码不能为空." ValidationGroup="ChangePassword" />
            </td>
        </tr>
        <tr>
            <td width="120">
                密码确认：
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="130"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                    ErrorMessage="密码确认不能为空." ToolTip="密码确认不能为空." ValidationGroup="ChangePassword" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword"
                    ControlToValidate="txtNewPwd" Display="Dynamic" ErrorMessage="新密码和密码确认不一致" ValidationGroup="ChangePassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="btnPwdSave" runat="server" OnClick="btnPwdSave_Click" Text="保存" ValidationGroup="ChangePassword" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
