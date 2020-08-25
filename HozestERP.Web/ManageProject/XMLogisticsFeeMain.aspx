<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLogisticsFeeMain.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMLogisticsFeeMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel runat="server" Region="North" Title="查询" Height="70" Padding="5" Frame="true" Layout="ColumnLayout" Icon="Information">
                    <Items>
                        <ext:TextField ID="txtProvince" runat="server" FieldLabel="省" MaxLength="20"  ColumnWidth="0.2" LabelWidth="50"/>
                        <ext:TextField ID="txtCity" runat="server" FieldLabel="市" MaxLength="20" LabelAlign="Right" ColumnWidth="0.2"  LabelWidth="60"/>
                        <ext:TextField ID="txtArea" runat="server" FieldLabel="区" MaxLength="20" LabelAlign="Right" ColumnWidth="0.2"  LabelWidth="60"/>
                        <ext:Label runat="server" ColumnWidth="0.02"></ext:Label>
                        <ext:Button ID="btnSearch" runat="server" Text="查询" Width="75" ColumnWidth="0.1" LabelWidth="60">
                            <Listeners>
                                <Click Handler="#{Store1}.reload();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Label runat="server" ColumnWidth="0.28"></ext:Label>
                    </Items>
                </ext:Panel>
                <ext:GridPanel runat="server" ID="GridPanel1" Region="Center" StripeRows="true" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Text="添加" Icon="Add">
                                    <DirectEvents>
                                        <Click OnEvent="add_Click">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" Text="修改" Icon="BookEdit">
                                    <DirectEvents>
                                        <Click OnEvent="edit_Click">
                                            <ExtraParams>
                                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" Text="导入数据" Icon="TabAdd">
                                    <Listeners>
                                        <Click Handler="ShowWindowDetail('导入发货','./ManageProject/ImportLogisticsFeeMain.aspx',750,300);" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="删除" Icon="Delete">
                                    <DirectEvents>
                                        <Click OnEvent="btnDeleteClick" Success="#{Store1}.reload()">
                                            <EventMask ShowMask="true" Msg="正在提交中……" />
                                            <Confirmation ConfirmRequest="true" Title="提示" Message="确认删除?"/>
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
                        <ext:Store ID="Store1" runat="server">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="XMLogisticsFeeMain.ashx"></ext:HttpProxy>
                            </Proxy>
                            <BaseParams>
                                <ext:Parameter Name="province" Value="#{txtProvince}.getValue()" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="city" Value="#{txtCity}.getValue()" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="area" Value="#{txtArea}.getValue()" Mode="Raw"></ext:Parameter>
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="ID" Root="data" TotalProperty="total">
                                    <Fields>
                                        <ext:RecordField Name="ID" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Project" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="WareHouse" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Province" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="City" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Area" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Logistics" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Fee" Type="Auto"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column DataIndex="Project" Header="项目" Width="90" />
                            <ext:Column DataIndex="WareHouse" Header="发货仓" Width="90" />
                            <ext:Column DataIndex="Province" Header="省" Width="90" />
                            <ext:Column DataIndex="City" Header="市" Width="90" />
                            <ext:Column DataIndex="Area" Header="地区" Width="90" />
                            <ext:Column DataIndex="Logistics" Header="快递公司" Width="90" />
                            <ext:Column DataIndex="Fee" Header="费用" Width="90" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel runat="server"></ext:CheckboxSelectionModel>
                    </SelectionModel>
                    <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="记录数:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="1" />
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
        <ext:Window ID="Window1" runat="server" Title="物流费用信息" BodyStyle="background:#fff;"
            CloseAction="Hide" Hidden="true" Width="335" Height="265" Layout="BorderLayout"
            Constrain="true" Icon="NoteEdit" Frame="true" Modal="true" ButtonAlign="Center" AutoScroll="true">
            <Items>
                <ext:FormPanel ID="fromPanel1" runat="server" Region="Center" Frame="true"
                    MonitorValid="true">
                    <Items>
                        <ext:TextField runat="server" ID="selectID" Hidden="true"></ext:TextField>
                        <ext:ComboBox ID="cbProject" runat="server" Editable="false" FieldLabel="项目" DisplayField="ProjectName" ValueField="Id" EmptyText="选择项目" AllowBlank="false" MsgTarget="Side" s>
                            <Store>
                                <ext:Store runat="server" ID="Store2">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="ProjectName"></ext:RecordField>
                                                <ext:RecordField Name="Id"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbWarehouse" runat="server" Editable="false" FieldLabel="发货点" DisplayField="CodeName" ValueField="CodeID" EmptyText="选择发货点" AllowBlank="false" MsgTarget="Side">
                            <Store>
                                <ext:Store runat="server" ID="Store3">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="CodeName"></ext:RecordField>
                                                <ext:RecordField Name="CodeID"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbProvince" runat="server" Editable="false" FieldLabel="省" DisplayField="City" ValueField="City" EmptyText="选择省份" AllowBlank="false" MsgTarget="Side">
                            <Store>
                                <ext:Store runat="server" ID="Store4">
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
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbCity" runat="server" Editable="false" FieldLabel="市" DisplayField="City" ValueField="City" EmptyText="选择城市">
                            <Store>
                                <ext:Store runat="server" ID="Store5">
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
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbArea" runat="server" Editable="false" FieldLabel="区" DisplayField="City" ValueField="City" EmptyText="选择区域">
                            <Store>
                                <ext:Store runat="server" ID="Store6">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="City"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbLogistics" runat="server" Editable="false" FieldLabel="物流公司" DisplayField="CodeName" ValueField="CodeID" EmptyText="选择物流公司" AllowBlank="false" MsgTarget="Side">
                            <Store>
                                <ext:Store runat="server" ID="Store7">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="CodeID"></ext:RecordField>
                                                <ext:RecordField Name="CodeName"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:NumberField ID="numPrice" runat="server" FieldLabel="费用" AllowBlank="false" Regex="^([1-9]\d{0,9}|0)([.]?|(\.\d{1,2})?)$"
                            MaxLength="50" MsgTarget="Side" AnchorHorizontal="93%" />
                    </Items>
                    <Listeners>
                        <ClientValidation Handler="#{btnSave}.setDisabled(!valid);#{btnEdit}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button Text="保存" ID="btnSave" runat="server" Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click" Success="#{Store1}.reload();CompanyX.Window1.hide();">
                            <EventMask ShowMask="true" Msg="正在提交中……" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="修改" ID="btnEdit" Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnEdit_Click" Success="#{Store1}.reload();CompanyX.Window1.hide();">
                            <EventMask ShowMask="true" Msg="正在提交中……" />
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
