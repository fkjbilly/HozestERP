<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="ProjectCustomerDistribution.aspx.cs" Inherits="HozestERP.Web.ManageProject.ProjectCustomerDistribution" %>
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/ImageButtonSelectSingleCustomerControl.ascx" TagName="ImageButtonSelectSingleCustomerControl"
    TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowSelectCustomerDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:800px;dialogHeight:600px;center:yes;");
            return true;
        }
        var GridCommand = function (commandName, record) {
            if (commandName == "Edit") {
            }
            else {
                Ext.MessageBox.confirm('提示信息', '确定删除您选中的记录吗？', function (btn) {
                    if (btn == "yes") {
                        CompanyX.DeleteCustomer(record.NickCustomerID);
                    }
                });
            }
        }
        var rowclickFn = function (grid, rowindex, e) {
            GridCommand("Delete", grid.getSelectionModel().getSelected().data);
        }
    </script>
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript"></script>
    <ext:ResourceManager ID="ResourceManager2" runat="server" Namespace="CompanyX" />

    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:GridPanel ID="GridPanel1" Region="Center" runat="server" StripeRows="true" AutoExpandColumn="FullName"
                AutoScroll="true">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button Text="添加人员" ID="btnAddCustomer" runat="server" Icon="Add" OnClientClick="return ShowSelectCustomerDetail('NickCustomerMappingSelected.aspx?PageID=ProjectCustomerDistribution');">
                                <DirectEvents>
                                    <Click OnEvent="btnAdd_Click">
                                        <EventMask ShowMask="true" Msg="正在添加人员,请稍等……" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button Text="清空所有人员" ID="btnDelete" runat="server" Icon="Add">
                                <DirectEvents>
                                    <Click OnEvent="btnDelete_Click">
                                        <EventMask ShowMask="true" Msg="正在清空所有人员,请稍等……" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Store>
                    <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
                        <Reader>
                            <ext:JsonReader IDProperty="NickCustomerID">
                                <Fields>
                                    <ext:RecordField Name="NickCustomerID" Type="Int" />
                                    <ext:RecordField Name="CustomerID" Type="Int" />
                                    <ext:RecordField Name="FullName" Type="String" />
                                    <ext:RecordField Name="DepartmentName" Type="String" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn />
                        <ext:Column Header="部门" Width="150" DataIndex="DepartmentName">
                        </ext:Column>
                        <ext:Column Header="姓名" Width="75" DataIndex="FullName" ColumnID="FullName">
                        </ext:Column>
                        <ext:CommandColumn Width="30">
                            <Commands>
                                <ext:GridCommand Icon="Delete" CommandName="Delete">
                                    <ToolTip Text="删除" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <Listeners>
                    <Command Handler="GridCommand(command, record.data);" />
                    <RowDblClick Fn="rowclickFn" />
                </Listeners>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                        <Items>
                            <ext:Label ID="Label1" runat="server" Text="记录数:" />
                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                <Items>
                                    <ext:ListItem Text="10" />
                                    <ext:ListItem Text="20" />
                                    <ext:ListItem Text="30" />
                                    <ext:ListItem Text="40" />
                                    <ext:ListItem Text="50" />
                                    <ext:ListItem Text="60" />
                                    <ext:ListItem Text="70" />
                                    <ext:ListItem Text="80" />
                                    <ext:ListItem Text="90" />
                                    <ext:ListItem Text="100" />
                                </Items>
                                <SelectedItem Value="10" />
                                <Listeners>
                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:PagingToolbar>
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
