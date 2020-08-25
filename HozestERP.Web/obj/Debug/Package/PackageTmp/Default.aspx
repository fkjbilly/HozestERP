<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="HozestERP.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>和众互联ERP系统</title>
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript" src="Script/Default.js"></script>
    <script type="text/javascript" src="Script/CommonManager.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Region="North" Border="false" Height="54">
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="57" align="center" valign="top" background="App_Themes/<%=this.Page.Theme %>/image/Top_down.gif">
                                <table width="90%" height="57" border="0" cellpadding="0" cellspacing="0" background="App_Themes/<%=this.Page.Theme %>/image/Top_d.gif">
                                    <tr>
                                        <td width="29">
                                            <img src="App_Themes/<%=this.Page.Theme %>/image/Top_left.gif" width="29" height="57" />
                                        </td>
                                        <td>
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="45%" align="right" valign="bottom">
                                                    </td>
                                                    <td width="441" align="center">
                                                        <img src="App_Themes/<%=this.Page.Theme %>/image/Login.gif" width="441" height="57" />
                                                    </td>
                                                    <td width="55%" valign="bottom" align="right">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="Login">
                                                            <tr>
     <%--                                                           <td align="center">
                                                                    <a href="" id="btnShortTouch" onclick="javascript:ShowShortTouchWindow(this);return false;"
                                                                        target="ContentPage">毛利计算</a>
                                                                </td>--%>
                                                            <%--    <td>
                                                                    <img src="App_Themes/<%=this.Page.Theme %>/image/Top_lie.gif" width="2" height="30" />
                                                                </td>--%>
                                                               <%-- <td style="width:100px;">
                                                                    <a href="TopTaobao/Index.aspx" target="_blank" style="cursor: pointer;
                                                                        color: #EDD8D5;">直通车首页</a>
                                                                </td>--%>
                                                               <%-- <td align="center">
                                                                    <img src="App_Themes/<%=this.Page.Theme %>/image/Top_lie.gif" width="2" height="30" />
                                                                </td>
                                                                <td style="width: 60px;">
                                                                    <a id="lnkOnlineUser" href="#" onclick="SetOnlineUserStatus();" style="cursor: pointer;
                                                                        color: #EDD8D5;">在线(0)</a>
                                                                </td>--%>
                                                                <td align="center">
                                                                    <img src="App_Themes/<%=this.Page.Theme %>/image/Top_lie.gif" width="2" height="30" />
                                                                </td>
                                                                <td align="center">
                                                                    <a style="cursor: pointer" onclick="Go('refresh');">刷新</a>
                                                                </td>
                                                                    <td align="center">
                                                                    <img src="App_Themes/<%=this.Page.Theme %>/image/Top_lie.gif" width="2" height="30" />
                                                                </td>
                                                                <td align="center">
                                                                    <a style="cursor: pointer" onclick="Go('full');">全屏</a>
                                                                </td>
                                                                <td align="center">
                                                                    <img src="App_Themes/<%=this.Page.Theme %>/image/Top_lie.gif" width="2" height="30" />
                                                                </td>
                                                                <td align="center">
                                                                    <a href="Logout.aspx" target="_parent" onclick="return window.confirm('确定要注销吗？')">
                                                                        注销</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="27">
                                            <img src="App_Themes/<%=this.Page.Theme %>/image/Top_right.gif" width="27" height="57" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ext:Panel>
           <%-- <ext:Panel ID="pnlModule" runat="server"  Split="true" Region="West"   Collapsed="true"
                Width="170" Layout="AccordionLayout" Border="true" Collapsible="true" CollapseMode="Mini"
                Title="<div class='start_menu'></div>">--%>
                 <ext:Panel ID="pnlModule" runat="server"  Split="true" Region="West"  
                Width="170" Layout="AccordionLayout" Border="true" Collapsible="true" CollapseMode="Mini"
                Title="<div class='start_menu'></div>">
                <LayoutConfig>
                    <ext:AccordionLayoutConfig Animate="true" />
                </LayoutConfig>
            </ext:Panel>
            <ext:TabPanel ID="TabPanel1"  runat ="server" Region="Center" EnableTabScroll="true" LayoutOnTabChange="true">
                <Items>
                <%-- <ext:Panel  ID="plNavigationSearch" Title="发货提醒" Collapsed="false" IconCls="homerkh"   Visible="<% $CRMIsActionAllowed:Default.NavigationSearch %>">
                        <AutoLoad ShowMask="true" Url="Navigation.aspx" Mode="IFrame" MaskMsg="正在初始化 发货提醒，请稍等...">
                        </AutoLoad>
                    </ext:Panel>--%>
                    <ext:Panel Title="桌  面" Collapsed="false" IconCls="indexicon">
                        <AutoLoad ShowMask="true" Url="Protal.aspx" Mode="IFrame" MaskMsg="正在初始化 桌面，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                   <%-- <ext:Panel runat="server"  ID="PanelPages" Title="" Collapsed="false">
                        <AutoLoad ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等...">
                        </AutoLoad> 
                    </ext:Panel>--%>
                </Items>
                <Plugins>
                    <ext:TabCloseMenu CloseAllTabsText="关闭所有页面" CloseOtherTabsText="除之外全部关闭" CloseTabText="关闭">
                    </ext:TabCloseMenu>
                </Plugins>
            </ext:TabPanel>
            <ext:Panel ID="Panel2" runat="server" Region="South" Border="false" Height="15">
                <Content>
                    <table border="0" cellspacing="0" style="width: 100%; border-top: #0e3659 thin solid;
                        margin: 0px;">
                        <tr>
                            <td style="text-align: right; width: 100%;" border="0" cellspacing="0" cellpadding="0"
                                class="botton" valign="top">
                                <span style="font-size: 7pt; font-family: Verdana">Copyright &copy; 2012, <b style="font-size: 10px;">
                                    和众互联ERP系统</b> Hozest All rights reserved</span>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ext:Panel>
        </Items>
    </ext:Viewport>
<%--    <ext:TaskManager ID="TaskManager1" runat="server">
        <Tasks>
            <ext:Task Interval="6000" AutoRun="true">
                <Listeners>
                    <Update  Fn="OnlineUserTask" />
                </Listeners>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>--%>
    <ext:TaskManager ID="TaskManager2" runat="server">
        <Tasks>
            <ext:Task Interval="3600000" AutoRun="true">
                <Listeners>
                    <Update  Fn="contractApprovalTask" />
                </Listeners>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>
    </form>
</body>
</html>