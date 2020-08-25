<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRoles.aspx.cs"
    Inherits="HozestERP.Web.ManageSystem.CustomerRoles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript" language="javascript">
        function nodeLoad(node) {
            CompanyX.NodeLoad(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        function SelectNode(node) {
            var a = node;
            var title = a.text;
            while (a.parentNode) {
                a = a.parentNode;
                if (a.id != "0" && a.text != undefined) {
                    title = a.text + "/" + title;
                }
            }
            CompanyX.pnlRoleModule.setTitle(title + " 模块权限");
            CompanyX.pnlRoleModule.load({ showMask: true, url: 'CustomerRoleModule.aspx?CustomerRoleID=' + node.id + '&rnd=' + Math.round(), mode: 'iframe', maskMsg: '正在初始化 ' + title + ' 模块权限，请稍等...' });

        }
        var RefreshCustomerRoleTree = function () {
            CompanyX.RefreshCustomerRoleTreeLoad({
                success: function (result) {
                    var nodes = eval(result);
                    if (nodes.length > 0) {
                        CompanyX.customerRoleTree.initChildren(nodes);
                    }
                    else {
                        CompanyX.customerRoleTree.getRootNode().removeChildren();
                    }
                }
            });
        }

        var TreeCheckChange = function (treeNode, check) {
            treeNode.expand();  // 展开树 
            if (!treeNode.isLeaf()) {
                treeNode.eachChild(function (child) {
                    child.ui.toggleCheck(check);
                    child.attributes.checked = check;
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TreePanel runat="server" ID="customerRoleTree" Region="West" Width="160" Split="true"
                CollapseMode="Mini" Title="角色" Border="true" RootVisible="false" AutoScroll="true">
                <Root>
                    <ext:AsyncTreeNode NodeID="0" Text="角色" Expanded="true">
                    </ext:AsyncTreeNode>
                </Root>
                <Listeners>
                    <BeforeLoad Fn="nodeLoad" />
                    <Click Fn="" />
                </Listeners>
                <Tools>
                    <ext:Tool Type="Refresh" Qtip="Refresh" Handler="RefreshCustomerRoleTree();" />
                </Tools>
            </ext:TreePanel>
            <ext:Panel ID="pnlRoleModule" Region="Center" Icon="Application">
                <AutoLoad ShowMask="true" Url="CustomerRoleModule.aspx" Mode="IFrame" MaskMsg="正在初始化 模块权限，请稍等...">
                </AutoLoad>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
