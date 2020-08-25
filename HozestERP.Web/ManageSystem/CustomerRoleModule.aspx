<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRoleModule.aspx.cs"
    Inherits="HozestERP.Web.ManageSystem.CustomerRoleModule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script language="javascript" type="text/javascript">
        var TreeCheckChange = function (treeNode, check) {
            treeNode.expand();  // 展开树 
            if (!treeNode.isLeaf()) {
                treeNode.eachChild(function (child) {
                    child.ui.toggleCheck(check);
                    child.attributes.checked = check;
                });
            }
        }
        function SelectNode(node) {
            var ddf = node.getOwnerTree().dropDownField;
            ddf.setValue(node.id, node.text);
        }
        var prepare = function (grid, toolbar, groupId, records) {
            // you can prepare ready toolbar
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager2" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel ID="pnlRoleModule" Icon="Application" Region="North" Height="200" Layout="BorderLayout"
                Border="false">
                <TopBar>
                    <ext:Toolbar>
                        <Items>
                            <ext:Button Text="新增节点" ID="btnAdd" runat="server" Icon="Add">
                                <DirectEvents>
                                    <Click OnEvent="btnAdd_Click">
                                        <EventMask ShowMask="true" Msg="正在新增节点……" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:Button Text="保存" ID="btnSave" runat="server" Icon="Disk">
                                <DirectEvents>
                                    <Click OnEvent="btnSave_Click">
                                        <EventMask ShowMask="true" Msg="正在提交中……" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:Button Text="删除" ID="btnDelete" runat="server" Icon="Delete">
                                <DirectEvents>
                                    <Click OnEvent="btnDelete_Click">
                                        <Confirmation ConfirmRequest="true" Message="删除后不可恢复,确定删除所选的数据吗?" Title="温馨提示" />
                                        <EventMask ShowMask="true" Msg="正在删除中……" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:FormPanel ID="fromPanel1" runat="server" Frame="true" Region="Center" DefaultAnchor="98%"
                        MonitorValid="true" ButtonAlign="Left" Border="false">
                        <Items>
                            <ext:DropDownField FieldLabel="父角色" ID="dropDownField" runat="server" Editable="false"
                                Width="300" TriggerIcon="SimpleArrowDown" Mode="ValueText" AllowBlank="false">
                                <Component>
                                    <ext:TreePanel ID="treCustomerRole" runat="server" Height="300" Shadow="None" UseArrows="true"
                                        AutoScroll="true" Animate="true" EnableDD="true" ContainerScroll="true" RootVisible="true">
                                    </ext:TreePanel>
                                </Component>
                                <Listeners>
                                    <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                                </Listeners>
                            </ext:DropDownField>
                            <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="false" MaxLength="100"
                                MsgTarget="Side" />
                            <ext:TextArea ID="txtDescription" runat="server" FieldLabel="说明" AllowBlank="true"
                                Height="80" MsgTarget="Side" />
                            <ext:Checkbox ID="chkActive" runat="server" FieldLabel="" BoxLabel="发布" DataIndex="Deleted">
                            </ext:Checkbox>
                        </Items>
                        <Listeners>
                            <ClientValidation Handler="#{btnSave}.setDisabled(!valid);#{btnAdd}.setDisabled(!valid);" />
                        </Listeners>
                    </ext:FormPanel>
                </Items>
            </ext:Panel>
            <ext:TabPanel ID="tabCenter" Region="Center" EnableTabScroll="true" LayoutOnTabChange="true"
                Border="false">
                <Items>
                    <ext:Panel Title="模块权限" Region="Center" Layout="BorderLayout" Icon="Application">
                        <Items>
                        
                            <ext:TreePanel runat="server" ID="moduleTree" Region="Center" Split="true" CollapseMode="Mini"
                                Border="false" RootVisible="false" AutoScroll="true">
                                <Listeners>
                                    <CheckChange Fn="TreeCheckChange" />
                                </Listeners>
                            </ext:TreePanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel Title="功能权限" Region="Center" Layout="BorderLayout" Icon="Application">
                        <Items>
                            <ext:GridPanel ID="GridPanel1" runat="server" Region="Center" AutoExpandColumn="FullModuleName"
                                Border="false">
                                <Store>
                                    <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh" GroupField="FullModuleName"
                                        OnBeforeStoreChanged="HandleChanges" SkipIdForNewRecords="false" RefreshAfterSaving="None">
                                        <Reader>
                                            <ext:JsonReader IDProperty="CustomerActionID">
                                                <Fields>
                                                    <ext:RecordField Name="ACLID" Type="Int" />
                                                    <ext:RecordField Name="CustomerActionID" Type="Int" />
                                                    <ext:RecordField Name="FullModuleName" Type="String" />
                                                    <ext:RecordField Name="Name" Type="String" />
                                                    <ext:RecordField Name="Allow" Type="Boolean" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn>
                                        </ext:RowNumbererColumn>
                                        <ext:Column Header="模块" Width="160" DataIndex="FullModuleName" />
                                        <ext:CheckColumn Width="10" DataIndex="Allow" Editable="true" />
                                        <ext:Column ColumnID="FullModuleName" Header="功能" Width="100" DataIndex="Name">
                                        </ext:Column>
                                        <ext:CommandColumn Hidden="true">
                                            <GroupCommands>
                                                <ext:GridCommand Icon="TableRow" CommandName="SelectGroup">
                                                    <ToolTip Title="选择" Text="选择组中的所有行." />
                                                </ext:GridCommand>
                                            </GroupCommands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <Listeners>
                                    <GroupCommand Handler="if(command === 'SelectGroup'){for(var i=0;i<records.length;i++){records[i].set('Allow', true); } this.getSelectionModel().selectRecords(records, true); return;}" />
                                </Listeners>
                                <SelectionModel>
                                    <ext:RowSelectionModel />
                                </SelectionModel>
                                <SaveMask ShowMask="true" Msg="正在保存数据，请稍等..." />
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                                <View>
                                    <ext:GroupingView ID="GroupingView1" HideGroupedColumn="true" runat="server" ForceFit="true"
                                        GroupTextTpl='{text} ({[values.rs.length]} {[values.rs.length > 1 ? "Items" : "Item"]})'
                                        EnableRowBody="true">
                                    </ext:GroupingView>
                                </View>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                   
                    <ext:Panel ID="pnlCustomer" runat="server" Title="人员权限" Region="Center" Icon="PluginLink">
                        <AutoLoad ShowMask="true" Mode="IFrame" MaskMsg="正在初始化 人员权限，请稍等...">
                        </AutoLoad>
                    </ext:Panel>

                     <ext:Panel ID="pnlStaffPrivileges" runat="server" Title="包含用户" Region="Center" Icon="PluginLink">
                        <AutoLoad ShowMask="true" Mode="IFrame" MaskMsg="正在初始化 人员权限，请稍等...">
                        </AutoLoad>
                    </ext:Panel>

                    <ext:Panel ID="pnlDepartment" runat="server" Title="包含部门" Region="Center" Icon="PluginLink">
                        <AutoLoad ShowMask="true" Mode="IFrame" MaskMsg="正在初始化 人员权限，请稍等...">
                        </AutoLoad>
                    </ext:Panel>
                    <ext:Panel Title="提示类型" Region="Center" Layout="BorderLayout" Icon="Application">

                        <Items>
                            
                            <ext:TreePanel runat="server" ID="AlertSettingsTreePanel" Region="Center" Split="true" CollapseMode="Mini"
                                Border="false" RootVisible="false" AutoScroll="true">
                                <Listeners>
                                    <CheckChange Fn="TreeCheckChange" />
                                </Listeners>
                            </ext:TreePanel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
