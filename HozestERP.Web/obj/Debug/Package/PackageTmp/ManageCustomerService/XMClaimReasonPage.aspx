<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMClaimReasonPage.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMClaimReasonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">

        function window1Init() {
            CompanyX.btnEdit.setVisible(false);
            CompanyX.btnSave.setVisible(true);
        }

        function formLoad() {
            var data = CompanyX.GridPanel1.getSelectionModel().getSelected();
            if (typeof (data) == "undefined") {
                alert("请选择一条记录");
            }
            else {
                CompanyX.Window1.show();
                CompanyX.fromPanel1.reset();
                CompanyX.fromPanel1.getForm().loadRecord(data);
                CompanyX.cbProject.setValue(data.data.ProjectName);
                CompanyX.txtReason.setValue(data.data.Reason);
                CompanyX.btnEdit.setVisible(true);
                CompanyX.btnSave.setVisible(false);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel runat="server" ID="GridPanel1" Title="理赔原因管理" Margins="0 0 5 5" Region="Center" StripeRows="true" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Icon="Add" Text="添加" Handler="function(){ CompanyX.Window1.show(document.body, function(){CompanyX.fromPanel1.reset();window1Init();});}"></ext:Button>
                                <ext:Button runat="server" Icon="BookEdit" Text="编辑">
                                    <Listeners>
                                        <Click Handler="formLoad()" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Store>
                        <ext:Store runat="server" ID="StoreReason" OnRefreshData="Data_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID"></ext:RecordField>
                                        <ext:RecordField Name="ProjectName"></ext:RecordField>
                                        <ext:RecordField Name="Reason"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column Header="项目" Width="100" DataIndex="ProjectName" />
                            <ext:Column Header="原因" Width="300" DataIndex="Reason" />
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
        <ext:Window ID="Window1" runat="server" Title="原因" BodyStyle="background:#fff;"
            CloseAction="Hide" Hidden="true" Width="400" AutoHeight="true"
            Constrain="true" Icon="NoteEdit" Frame="true" Modal="true" ButtonAlign="Center" AutoScroll="true">
            <Items>
                <ext:FormPanel ID="fromPanel1" runat="server" Region="Center" Frame="true"
                    MonitorValid="true">
                    <Items>
                        <ext:TextField runat="server" ID="txtID" Hidden="true" DataIndex="ID"></ext:TextField>
                        <ext:ComboBox runat="server" ID="cbProject" Editable="false" FieldLabel="项目" AnchorHorizontal="95%" DisplayField="ProjectName" ValueField="Id" EmptyText="请选择" AllowBlank="false">
                            <Store>
                                <ext:Store runat="server" ID="StoreProject">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="Id"></ext:RecordField>
                                                <ext:RecordField Name="ProjectName"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:TextArea runat="server" ID="txtReason" FieldLabel="原因" AnchorHorizontal="95%"></ext:TextArea>
                    </Items>
                    <Listeners>
                        <ClientValidation Handler="#{btnSave}.setDisabled(!valid);#{btnEdit}.setDisabled(!valid);" />
                    </Listeners>
                    <Buttons>
                        <ext:Button Text="保存" ID="btnSave" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnSave_Click" Success="CompanyX.Window1.hide();#{StoreReason}.reload()">
                                    <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" Text="修改" ID="btnEdit">
                            <DirectEvents>
                                <Click OnEvent="btnEdit_Click" Success="CompanyX.Window1.hide();#{StoreReason}.reload()">
                                    <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" Text="关闭" Handler="function(){CompanyX.Window1.hide();}">
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
