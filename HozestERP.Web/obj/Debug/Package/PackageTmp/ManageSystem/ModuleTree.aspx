<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleTree.aspx.cs" Inherits="HozestERP.Web.ManageSystem.ModuleTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="trModules" runat="server" ShowLines="True" ExpandDepth="2">
            <NodeStyle Height="18px" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
