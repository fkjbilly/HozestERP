<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dyYD.aspx.cs" Inherits="HozestERP.Web.ManageProject.dyYD" %>

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
                <asp:RadioButton ID="Rad_EMS" runat="server" Text="EMS快递" GroupName="pd_yd" Visible="false" />
                <asp:RadioButton ID="Rad_YTO" runat="server" Text="圆通速递" GroupName="pd_yd" Visible="true" />
                <asp:RadioButton ID="Rad_ZTO" runat="server" Text="中通快递" GroupName="pd_yd" Visible="false" />
                <asp:RadioButton ID="Rad_STO" runat="server" Text="申通快递" GroupName="pd_yd" Checked="true" />
                &nbsp;<asp:Label ID="lblcount" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblKDcode" runat="server" Text="快递单号："></asp:Label>
                <asp:TextBox ID="txtStartCode" runat="server"></asp:TextBox>
                ---<asp:TextBox ID="txtEndCode" runat="server"></asp:TextBox>
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
