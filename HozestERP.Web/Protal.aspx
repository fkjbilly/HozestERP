<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Protal.aspx.cs" Inherits="HozestERP.Web.Protal"
    EnableEventValidation="false" EnableTheming="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .x-column-padding
        {
            padding: 10px 0px 10px 10px;
        }
        
        .x-column-padding1
        {
            padding: 10px;
        }
        
        .x-panel-header.WratherCls
        {
            background-image: url("images/ICON/damotouicon.ico");
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-color: transparent;
        }
        .x-window-header.BulletCls, .x-panel-header.BulletCls
        {
            background-image: url("images/ICON/ballat.gif");
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-color: transparent;
        }
        .x-panel-header.MeetingCls
        {
            background-image: url("images/ICON/meetingIcon.png");
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-color: transparent;
        }
        .x-panel-header.DongtaiCls
        {
            background-image: url("images/ICON/dongtai.png");
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-color: transparent;
        }
        .append
        {
            background-image: url(images/ICON/append.gif) !important;
        }
        .down
        {
            background-image: url(images/ICON/down.gif) !important;
        }
        .up
        {
            background-image: url(images/ICON/up.gif) !important;
        }
        .PanelOverCls
        {
            overflow: auto;
        }
        .ProtalHeader
        {
            width: 100%;
            height: 67px;
            padding-top: 0px;
            padding-right: 0px;
            padding-bottom: 0px;
            padding-left: 0px;
            font-family: 微软雅黑,Verdana, Arial;
            font-size: 12px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 8px;
            margin-left: 0px;
            border-top-color: #8db2e3;
            border-right-color: #8db2e3;
            border-bottom-color: #8db2e3;
            border-left-color: #8db2e3;
            border-top-width: 0px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-bottom-style: solid;
            border-left-style: solid;
            float: left;
            background-image: url('images/top_bg.gif');
            background-attachment: scroll;
            background-repeat: repeat-x;
            background-position-x: 0%;
            background-position-y: 0%;
            background-color: transparent;
        }
        .smsbox
        {
            background: url("images/desktop_icons.png") no-repeat scroll -174px 0 transparent;
        }
        .smsbox:hover, .smsbox:active
        {
            background: url("images/desktop_icons.png") no-repeat scroll -174px -25px transparent;
        }
        .nocbox
        {
            background: url("images/desktop_icons.png") no-repeat scroll -323px 0 transparent;
        }
        .nocbox:hover, .nocbox:active
        {
            background: url("images/desktop_icons.png") no-repeat scroll -323px -25px transparent;
        }
       .nocbox:hover, .nocbox:active, .smsbox:hover, .smsbox:active, a.ipanel_tab:link, a.ipanel_tab:hover, a.ipanel_tab:active, a.ipanel_tab:visited
        {
            display: inline-block;
            height: 25px;
            line-height: 25px;
            margin-right: 10px;
            text-align: center;
            text-decoration: none;
            width: 30px;
            z-index: 5;
        }
        
        .x-btn button
        {
            font: 13px  微软雅黑,arial,tahoma,verdana,helvetica;
        }
    </style>
    <title></title>
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript" src="Script/SetProtal.js"></script>
    <script language="javascript">
        function ShowSetPerson(paramThis) {
            try {
                window.parent.newTab('PersonSet250', "ManageSystem/PersonalInfo.aspx", "个人中心");
            }
            catch (e) {
                return true;
            }
            return false;
        }
    </script>
</head>
<body style="background-color: White; overflow: hidden;">
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel ID="Panel11" runat="server" Region="North" Border="true" BodyStyle="border-top-width: 0px;"
                Height="67">
                <Content>
                    <div class="ProtalHeader">
                        <ul style="width: 40%; margin-top: 6px; margin-left: 4px; float: left;">
                            <li style="width: 95%; line-height: 23px; margin-left: 5px; float: left;"><span style="font-size: 16px;
                                font-weight: bold;">欢迎您：</span> <a href="PersonSet.aspx" onclick="javascript:return ShowSetPerson(this);"
                                    target="ContentPage" style="color: #1367a3; font-size: 16px; font-weight: bold;">
                                    <asp:Literal ID="lblUserName" runat="server"></asp:Literal>
                                </a></li>
                            <li style="width: 95%; line-height: 23px; letter-spacing: 0.2em; margin-left: 5px;
                                float: left;"><span style="color: #939598; font-size: 14px;">今天是：<asp:Literal ID="lblDateTime"
                                    runat="server"></asp:Literal></span><span style="color: #939598; font-size: 10px;">(<asp:Literal ID="lblDayInfo"
                                    runat="server"></asp:Literal>)</span> </li>
                        </ul>
                        <%--<ul style="width: 34%; margin-top: 20px; float: left;">
                            <li style="width: 90%; text-align: right; float: right;">
                              <span style="float: left;padding-left:2px;"><ext:ComboBox ID="cbYear" runat="server" Width="100" EmptyText="请选择年份" AnchorHorizontal="100%"></ext:ComboBox></span>
                              <span style="float: left; padding-left:2px;"><ext:ComboBox ID="cbMonth" runat="server" Width="100" EmptyText="请选择月份" AnchorHorizontal="100%"></ext:ComboBox></span>
                              <span style="float: left;padding-left:3px;"><ext:Button ID="btnSearch" runat="server" Text="搜索" Handler="Search">
                              </ext:Button></span>
                            </li>
                        </ul>--%>
                        <ul style="width: 35%; margin-top: 6px; float: right;">
                            <li style="width: 90%; text-align: right; float: right;">
                                <iframe width="100%" height="50" src="http://m.weather.com.cn/m/pn11/weather.htm"
                                    frameborder="0" marginwidth="0" marginheight="0" scrolling="no" vspace="0" hspace="0"
                                    allowtransparency=""></iframe>
                            </li>
                        </ul>
                    </div>
                </Content>
            </ext:Panel>
            <ext:Panel ID="Panel4" runat="server" Region="Center" Layout="BorderLayout" Border="false">
                <Items>
                    <ext:Portal ID="Portal1" runat="server" Region="Center" Border="false" Layout="ColumnLayout"
                        Cls="x-portal" AutoScroll="true" ItemCls="PanelOverCls">
                        <Listeners>
                            <Drop Fn="CompanyX.Drop" Scope="CompanyX" />
                        </Listeners>
                    </ext:Portal>
                </Items>
                <BottomBar>
                    <ext:Toolbar>
                        <Items>
                            <ext:Button Text="桌面设置" IconCls="append" Handler="ShowEditPortel" runat="server"
                                ID="btnAddPortel">
                            </ext:Button>
                            <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:Button Text="收缩" IconCls="up" Handler="Collapse">
                            </ext:Button>
                            <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:Button Text="展开" IconCls="down" Handler="Expand">
                            </ext:Button>
                            <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:Button Text="反向" IconCls="down" Handler="ToggleCollapse">
                            </ext:Button>
                            <ext:ToolbarFill>
                            </ext:ToolbarFill>
                          <%--  <ext:HyperLink Cls="nocbox ipanel_tab">
                            </ext:HyperLink>
                            <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:HyperLink Cls="smsbox ipanel_tab">
                            </ext:HyperLink>--%>
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <!--Begin 桌面栏目维护设置-->
    <ext:Store ID="SPrimarySource" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="SDataSource1" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="SDataSource2" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="SDataSource3" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="SDataSource4" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Window ID="Window1" runat="server" Title="添加栏目" BodyStyle="background:#fff;"
        CloseAction="Hide" Hidden="true" Maximizable="true" Width="800" Height="600"
        Layout="BorderLayout" Constrain="true" IconCls="append">
        <Items>
            <ext:Panel Region="North" Height="40" Frame="true" BodyStyle="padding:3 3 3 10" LabelWidth="65"
                LabelAlign="Left" Border="false">
                <Items>
                    <ext:ComboBox FieldLabel="列数" HiddenName="ColumnIndex" Mode="Local" DisplayField="text"
                        ValueField="value" TriggerAction="All" EmptyText="请选择..." SelectOnFocus="true"
                        Editable="false" TabIndex="1" Anchor="100%" ID="cmbSelectColumn" runat="server">
                        <Items>
                            <ext:ListItem Text="1列" Value="1" />
                            <ext:ListItem Text="2列" Value="2" />
                            <ext:ListItem Text="3列" Value="3" />
                            <ext:ListItem Text="4列" Value="4" />
                        </Items>
                        <Listeners>
                            <Select Fn="SelectColumnIndex" />
                        </Listeners>
                    </ext:ComboBox>
                </Items>
            </ext:Panel>
            <ext:Panel Region="Center" Layout="BorderLayout" Border="false">
                <Items>
                    <ext:GridPanel Region="North" Height="200" Title="数据源" ID="gdPrimary" runat="server"
                        StoreID="SPrimarySource" StripeRows="true" Border="true" AutoExpandColumn="Name"
                        EnableDragDrop="true" DDGroup="secondGridDDGroup">
                        <LoadMask ShowMask="false" />
                        <SelectionModel>
                            <ext:RowSelectionModel ID="SelectedRowModel1" runat="server" />
                        </SelectionModel>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ColumnID="栏目" Header="栏目" Sortable="true" DataIndex="Name" />
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                    <ext:FormPanel Region="Center" ID="fpnlColumn" runat="server" Border="false" ColumnWidth="1"
                        Layout="ColumnLayout">
                        <Items>
                            <ext:Panel Border="true" Title="第一列" Layout="BorderLayout" ColumnWidth="0.25" ID="pnlColumn1">
                                <Items>
                                    <ext:Panel Region="North" Height="40" Frame="true" Border="false" LabelWidth="40"
                                        AutoScroll="false">
                                        <Items>
                                            <ext:NumberField FieldLabel="列宽" ID="txtColumnWidth1" runat="server" AllowBlank="false"
                                                BlankText="请输入列宽." Anchor="100%" Text="0">
                                            </ext:NumberField>
                                        </Items>
                                    </ext:Panel>
                                    <ext:GridPanel Region="Center" EnableDragDrop="true" DDGroup="firstGridDDGroup" ID="GridPanel1"
                                        runat="server" StoreID="SDataSource1" StripeRows="true" Header="false" Border="false"
                                        AutoExpandColumn="Name">
                                        <LoadMask ShowMask="false" />
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                                        </SelectionModel>
                                        <ColumnModel ID="ColumnModel2" runat="server">
                                            <Columns>
                                                <ext:Column ColumnID="栏目" Header="栏目" Sortable="true" DataIndex="Name" />
                                            </Columns>
                                        </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel Border="true" Title="第二列" Layout="BorderLayout" ColumnWidth="0.25" ID="pnlColumn2">
                                <Items>
                                    <ext:Panel Region="North" Height="40" Frame="true" Border="false" LabelWidth="40"
                                        AutoScroll="false">
                                        <Items>
                                            <ext:NumberField FieldLabel="列宽" ID="txtColumnWidth2" runat="server" AllowBlank="false"
                                                BlankText="请输入列宽." Anchor="100%" Text="0">
                                            </ext:NumberField>
                                        </Items>
                                    </ext:Panel>
                                    <ext:GridPanel Region="Center" EnableDragDrop="true" DDGroup="firstGridDDGroup" ID="GridPanel2"
                                        runat="server" StoreID="SDataSource2" StripeRows="true" Header="false" Border="false"
                                        AutoExpandColumn="Name">
                                        <LoadMask ShowMask="false" />
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel2" />
                                        </SelectionModel>
                                        <ColumnModel ID="ColumnModel3" runat="server">
                                            <Columns>
                                                <ext:Column ColumnID="栏目" Header="栏目" Sortable="true" DataIndex="Name" />
                                            </Columns>
                                        </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel Region="Center" Border="true" Title="第三列" Layout="BorderLayout" ColumnWidth="0.25"
                                ID="pnlColumn3" AutoScroll="false">
                                <Items>
                                    <ext:Panel Region="North" Height="40" Frame="true" Border="false" LabelWidth="40">
                                        <Items>
                                            <ext:NumberField FieldLabel="列宽" ID="txtColumnWidth3" runat="server" AllowBlank="false"
                                                BlankText="请输入列宽." Anchor="100%" Text="0">
                                            </ext:NumberField>
                                        </Items>
                                    </ext:Panel>
                                    <ext:GridPanel Region="Center" EnableDragDrop="true" DDGroup="firstGridDDGroup" ID="GridPanel3"
                                        runat="server" StoreID="SDataSource3" StripeRows="true" Header="false" Border="false"
                                        AutoExpandColumn="Name">
                                        <LoadMask ShowMask="false" />
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel3" />
                                        </SelectionModel>
                                        <ColumnModel ID="ColumnModel4" runat="server">
                                            <Columns>
                                                <ext:Column ColumnID="栏目" Header="栏目" Sortable="true" DataIndex="Name" />
                                            </Columns>
                                        </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel Region="Center" Border="true" Title="第四列" Layout="BorderLayout" ColumnWidth="0.25"
                                ID="pnlColumn4">
                                <Items>
                                    <ext:Panel Region="North" Height="40" Frame="true" Border="false" LabelWidth="40"
                                        AutoScroll="false">
                                        <Items>
                                            <ext:NumberField FieldLabel="列宽" ID="txtColumnWidth4" runat="server" AllowBlank="false"
                                                BlankText="请输入列宽." Anchor="100%" Text="0">
                                            </ext:NumberField>
                                        </Items>
                                    </ext:Panel>
                                    <ext:GridPanel Region="Center" ID="GridPanel4" runat="server" EnableDragDrop="true"
                                        DDGroup="firstGridDDGroup" StoreID="SDataSource4" StripeRows="true" Header="false"
                                        Border="false" AutoExpandColumn="Name">
                                        <LoadMask ShowMask="false" />
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel4" />
                                        </SelectionModel>
                                        <ColumnModel ID="ColumnModel5" runat="server">
                                            <Columns>
                                                <ext:Column ColumnID="栏目" Header="栏目" Sortable="true" DataIndex="Name" />
                                            </Columns>
                                        </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:FormPanel>
                </Items>
            </ext:Panel>
        </Items>
        <Buttons>
            <ext:Button ID="btnAdd" runat="server" Text="保存" Icon="Disk" Handler="Save">
            </ext:Button>
            <ext:Button Text="关闭" Icon="Cancel" Handler="function(){ Ext.getCmp('Window1').hide('btnAddPortel'); }">
            </ext:Button>
        </Buttons>
    </ext:Window>
    <!--End 桌面栏目维护设置-->
    </form>
</body>
</html>
