<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoDetailAvatar.aspx.cs"
    Inherits="HozestERP.Web.ManageCustomer.CustomerInfoDetailAvatar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Modules/UpdateImageControl.ascx" TagName="UpdateImageControl"
    TagPrefix="CRM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <table class="detailTable" style="float: left; background-color: White; margin: 5px 5px 5px 5px;"
        border="0" cellspacing="0" cellpadding="3" width="99%">
        <tr>
            <th colspan="2" style="text-align: center; font-weight: bold; font-size: 17px;letter-spacing:10px;">
                头像修改
            </th>
        </tr>
        <tr>
            <td width="120">
                上传头像：
            </td>
            <td>
                <CRM:UpdateImageControl ID="imgUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="保存修改" SkinID="button4" 
                    onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
