<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMWorkerInfo.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMWorkerInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript">
        function window1Init() {
            CompanyX.btnEdit.setVisible(false);
            CompanyX.btnSave.setVisible(true);
        }

        function formLoad() {
            //var data = CompanyX.GridPanel1.getSelectionModel().getSelected();
            //if (typeof (data) == "undefined") {
            //    alert("请选择一条记录");
            //}
            //else {
            //    CompanyX.Window1.show();
            //    CompanyX.fromPanel1.reset();
            //    CompanyX.fromPanel1.getForm().loadRecord(data);
            //    CompanyX.cbProvince.setValue(data.data.Province.split(","));
            //    CompanyX.cbCity.setValue(data.data.City.split(","));
            //    CompanyX.cbRegion.setValue(data.data.Regin.split(","));
            //    CompanyX.btnEdit.setVisible(true);
            //    CompanyX.btnSave.setVisible(false);
            //}
            CompanyX.btnEdit.setVisible(true);
            CompanyX.btnSave.setVisible(false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1"
                    runat="server"
                    Region="North"
                    Title="查询"
                    Height="70"
                    Padding="5"
                    Frame="true"
                    Layout="ColumnLayout"
                    Icon="Information">
                    <Items>
                        <ext:TextField ID="txtUserName" runat="server" FieldLabel="姓名" MaxLength="20"  LabelWidth="40"/>
                        <ext:TextField ID="txtProvince" runat="server" FieldLabel="省" MaxLength="20"  LabelWidth="40" LabelAlign="Right"/>
                        <ext:TextField ID="txtCity" runat="server" FieldLabel="市" MaxLength="20"  LabelWidth="40" LabelAlign="Right"/>
                        <ext:TextField ID="txtRegion" runat="server" FieldLabel="区" MaxLength="20"  LabelWidth="40" LabelAlign="Right"/>
                        <ext:Button ID="Button1" runat="server" Text="查询" Width="75" LabelWidth="60" >
                            <Listeners>
                                <Click Handler="#{StoreWorker}.reload()" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Panel>
                <ext:GridPanel runat="server" ID="GridPanel1" Title="安装师傅信息" Margins="0 0 5 5" Icon="UserSuit" Region="Center" StripeRows="true" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Icon="Add" Text="添加" Handler="function(){ CompanyX.Window1.show(document.body, function(){CompanyX.fromPanel1.reset();window1Init();});}"></ext:Button>
                                <ext:Button runat="server" Icon="BookEdit" Text="编辑">
                                    <DirectEvents>
                                        <Click OnEvent="formLoad_Click">
                                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                            <ExtraParams>
                                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                    <Listeners>
                                        <Click Handler="formLoad()" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Icon="Delete" Text="删除">
                                    <DirectEvents>
                                        <Click OnEvent="deleteInfo_Click" Success="#{StoreWorker}.reload()">
                                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                            <ExtraParams>
                                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Store>
                        <ext:Store runat="server" ID="StoreWorker" OnRefreshData="Data_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID"></ext:RecordField>
                                        <ext:RecordField Name="FullName"></ext:RecordField>
                                        <ext:RecordField Name="Tel"></ext:RecordField>
                                        <ext:RecordField Name="Province"></ext:RecordField>
                                        <ext:RecordField Name="City"></ext:RecordField>
                                        <ext:RecordField Name="Regin"></ext:RecordField>
                                        <ext:RecordField Name="LevelType"></ext:RecordField>
                                        <ext:RecordField Name="PayMethod"></ext:RecordField>
                                        <ext:RecordField Name="InstallationType"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column Header="姓名" Width="100" DataIndex="FullName" />
                            <ext:Column Header="联系方式" Width="100" DataIndex="Tel" />
                            <ext:Column Header="省" Width="100" DataIndex="Province" />
                            <ext:Column Header="市" Width="100" DataIndex="City" />
                            <ext:Column Header="区" Width="100" DataIndex="Regin" />
                            <ext:Column Header="师傅等级" Width="100" DataIndex="LevelType" />
                            <ext:Column Header="收款方式" Width="100" DataIndex="PayMethod" />
                            <ext:Column Header="安装类型" Width="100" DataIndex="InstallationType" />
                        </Columns>
                    </ColumnModel>

                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                        </ext:RowSelectionModel>
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
        <ext:Window ID="Window1" runat="server" Title="师傅信息" BodyStyle="background:#fff;"
            CloseAction="Hide" Hidden="true" Width="400" AutoHeight="true"
            Constrain="true" Icon="NoteEdit" Frame="true" Modal="true" ButtonAlign="Center" AutoScroll="true">
            <Items>
                <ext:FormPanel ID="fromPanel1" runat="server" Region="Center" Frame="true"
                    MonitorValid="true">
                    <Items>
                        <ext:TextField runat="server" ID="txtID" Hidden="true" DataIndex="ID"></ext:TextField>
                        <ext:TextField runat="server" ID="txtName" FieldLabel="姓名" MsgTarget="Side" DataIndex="FullName" AnchorHorizontal="95%" />
                        <ext:TextField runat="server" ID="txtTel" FieldLabel="联系方式" MsgTarget="Side" DataIndex="Tel" AnchorHorizontal="95%" />
                        <ext:TextField runat="server" ID="txtLevel" FieldLabel="师傅等级" MsgTarget="Side" DataIndex="LevelType" AnchorHorizontal="95%" />
                        <ext:TextField runat="server" ID="txtPayMethod" FieldLabel="收款方式" MsgTarget="Side" DataIndex="PayMethod" AnchorHorizontal="95%" />
                        <ext:TextField runat="server" ID="txtInstallationType" FieldLabel="安装类型" MsgTarget="Side" DataIndex="InstallationType" AnchorHorizontal="95%" />
                        <ext:MultiCombo runat="server" ID="cbProvince" Editable="false" FieldLabel="省" AnchorHorizontal="95%" DisplayField="City" ValueField="City" EmptyText="选择省份" Mode="Local">
                            <Store>
                                <ext:Store runat="server" ID="provinceStore">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="City"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <DirectEvents>
                                <Select OnEvent="province_Select">
                                </Select>

                            </DirectEvents>
                        </ext:MultiCombo>
                        <ext:MultiCombo runat="server" ID="cbCity" Editable="false" FieldLabel="市" AnchorHorizontal="95%" DisplayField="City" ValueField="City" EmptyText="选择城市">
                            <Store>
                                <ext:Store runat="server" ID="cityStore">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="City"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <DirectEvents>
                                <Select OnEvent="city_Select">
                                </Select>
                            </DirectEvents>
                        </ext:MultiCombo>
                        <ext:MultiCombo runat="server" ID="cbRegion" Editable="false" FieldLabel="区" AnchorHorizontal="95%" DisplayField="City" ValueField="City" EmptyText="选择区">
                            <Store>
                                <ext:Store runat="server" ID="regionStore">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="City"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:MultiCombo>
                    </Items>
                    <Listeners>
                        <ClientValidation Handler="#{btnSave}.setDisabled(!valid);#{btnEdit}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button Text="保存" ID="btnSave" runat="server">
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click" Success="CompanyX.Window1.hide();#{StoreWorker}.reload()">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="修改" ID="btnEdit">
                    <DirectEvents>
                        <Click OnEvent="btnEdit_Click" Success="CompanyX.Window1.hide();#{StoreWorker}.reload()">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="关闭" Handler="function(){CompanyX.Window1.hide();}">
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
