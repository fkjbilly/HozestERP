<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dyFHD.aspx.cs" Inherits="HozestERP.Web.ManageProject.dyFHD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" media="print">
        .Noprint
        {
            display: none;
        }
        .PageNext
        {
            page-break-after: always;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Scripts>
            <asp:ScriptReference Path="~/Script/piliang.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:HiddenField ID="hid_plyd" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="Noprint">
                <asp:Button ID="but_dy" runat="server" Text=" 预  览" OnClick="but_dy_Click" />
                &nbsp;<asp:Button ID="but_qrdy" runat="server" Text="打  印" OnClick="but_qrdy_Click" />
            </div>
            <div id="div_dy" runat="server" style="font-size: 14px; text-align: center;">
                <asp:Label ID="lblMSG" runat="server" Text="Label"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
