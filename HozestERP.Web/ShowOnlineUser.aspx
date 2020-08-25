<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOnlineUser.aspx.cs"
    Inherits="HozestERP.Web.ShowOnlineUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript">
        function onLineUserNodeLoad(node) {
            var netID = 0;
            if (node.attributes.NetID != undefined) {
                netID = node.attributes.NetID;
            }
            CompanyX.OnLineUserNodeLoad(node.id, netID, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        function AllUserNodeLoad(node) {
            var netID = 0;
            if (node.attributes.NetID != undefined) {
                netID = node.attributes.NetID;
            }
            CompanyX.AllUserNodeLoad(node.id, netID, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
    </script>
    <style>
        .group
        {
            background-image: url(images/ShortcutTouch/group.png) !important;
        }
        .user
        {
            background-image: url(images/ShortcutTouch/user.png) !important;
        }
        .U01
        {
            background-image: url(images/ShortcutTouch/U01.png) !important;
        }
        .U11
        {
            background-image: url(images/ShortcutTouch/U11.png) !important;
        }
        .U00
        {
            background-image: url(images/ShortcutTouch/U00.png) !important;
        }
        .U10
        {
            background-image: url(images/ShortcutTouch/U10.png) !important;
        }
        .root
        {
            background-image: url(images/ShortcutTouch/root.png) !important;
        }
        .x-panel-tl, .x-panel-header, .x-tree-node, .x-tab-strip, .x-menu-list-item
        {
            font-family: 微软雅黑;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager2" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TabPanel ID="TabPanel1" Region="Center" EnableTabScroll="true" LayoutOnTabChange="true">
                <Items>
                    <ext:TreePanel ID="treOnlineUser" runat="server" Region="West" Width="120" Border="true"
                        AutoScroll="true" Split="true" RootVisible="false" Title="&nbsp;&nbsp;在&nbsp;&nbsp;线"
                        IconCls="user">
                        <Root>
                            <ext:AsyncTreeNode NodeID="0" Text="在线用户" Expanded="true">
                            </ext:AsyncTreeNode>
                        </Root>
                        <Listeners>
                            <BeforeLoad Fn="onLineUserNodeLoad" />
                        </Listeners>
                    </ext:TreePanel>
                    <ext:TreePanel ID="TreePanel1" runat="server" Region="West" Width="120" Border="true"
                        AutoScroll="true" Split="true" RootVisible="false" Title="&nbsp;&nbsp;全&nbsp;&nbsp;部"
                        IconCls="group">
                        <Root>
                            <ext:AsyncTreeNode NodeID="0" Text="菜单" Expanded="true">
                            </ext:AsyncTreeNode>
                        </Root>
                        <Listeners>
                            <BeforeLoad Fn="AllUserNodeLoad" />
                        </Listeners>
                    </ext:TreePanel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
