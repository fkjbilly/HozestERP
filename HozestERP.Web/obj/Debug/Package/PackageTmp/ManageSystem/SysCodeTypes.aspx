<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysCodeTypes.aspx.cs" Inherits="HozestERP.Web.ManageSystem.SysCodeTypes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript" language="javascript">

        function SelectNode(node) {
            var a = node;
            var title = a.text;
            while (a.parentNode) {
                a = a.parentNode;
                if (a.text != undefined) {
                    title = a.text + "/" + title;
                }
            }
            var parentNodeID = 0;
            if (node.parentNode) {
                parentNodeID = node.parentNode.id;
            }
            CompanyX.pnlCenter.setTitle(title);
            CompanyX.pnlCenter.load({ showMask: true, url: 'SysCodeList.aspx?CodeTypeID=' + node.id + '&rnd=' + Math.round(), mode: 'iframe', maskMsg: '正在初始化 ' + title + '，请稍等...' });

        }      

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TreePanel runat="server" ID="customerTree" Region="West" Width="160" Split="true"
                CollapseMode="Mini" Title="公用代码类别" Border="false" RootVisible="false" AutoScroll="true">
            </ext:TreePanel>
            <ext:Panel ID="pnlCenter" Region="Center" Title="基本信息维护">
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
