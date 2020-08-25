<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRoleDepartmentMapping.aspx.cs"
 Inherits="HozestERP.Web.ManageSystem.CustomerRoleDepartmentMapping" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager2" runat="server" Namespace="CompanyX" />
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
                        CompanyX.DeleteDepartment(record.DepartmentID);
                    }
                });
            }
        }
        var rowclickFn = function (grid, rowindex, e) {
            GridCommand("Delete", grid.getSelectionModel().getSelected().data);
        }
    </script>
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
              <ext:GridPanel ID="GridPanel1" Region="Center" runat="server" StripeRows="true" AutoExpandColumn="DepName"
                AutoScroll="true">
                <TopBar>
                    <ext:Toolbar>
                        <Items>
                        <ext:ComboBox ID="ddlList" runat="server" Editable="false">
                        </ext:ComboBox>
                        
                            <ext:Button Text="添加部门" ID="btnAddCustomer" runat="server" Icon="Add"  >
                                <DirectEvents>
                                    <Click OnEvent="btnAdd_Click">
                                        <EventMask ShowMask="true" Msg="正在添加部门,请稍等……" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Store>
                    <ext:Store ID="Store1" runat="server">
                        <Reader>
                            <ext:JsonReader IDProperty="DepartmentID">
                                <Fields>
                                    <ext:RecordField Name="DepartmentID" Type="Int" />
                                    <ext:RecordField Name="DepName" Type="String" />
                                    <ext:RecordField Name="DepCode" Type="String" />
                                    <ext:RecordField Name="EntName" ServerMapping="SEnterprise.EntName" Type="String" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn />
                        <ext:Column Header="部门编号" Width="75" DataIndex="DepCode" />
                        <ext:Column ColumnID="DepName" Header="部门" Width="150" DataIndex="DepName">
                        </ext:Column>
                        <ext:Column Header="所属公司" Width="150" DataIndex="EntName"   >
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

    </form>
</body>
</html>
