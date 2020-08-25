<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLogisticsFeeDetail.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMLogisticsFeeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function Summary() {
            var fee = 0;
            var data = CompanyX.Store1.data.items;
            var n = CompanyX.Store1.getCount();
            for (var i = 0; i < n; i++) {
                fee = fee + data[i].data.Fee;
            }

            if (fee != 0)
            {
                var a = new Ext.data.Record({
                    ID: 0,
                    OrderID: 0,
                    Type: 0,
                    Fee: fee,
                    Note: ""
                })
                CompanyX.Store1.insert(n, a);
                CompanyX.Store1.commitChanges();
            }
        }

        function rowSelect() {
            var data = CompanyX.GridPanel1.getSelectionModel().getSelected();
            if (data.data.Type !=0) {
                CompanyX.edit.setDisabled(false);
            }
            else {
                CompanyX.edit.setDisabled(true);
            }
        }

        function prepareCommand(command, record)
        {
            if (record.data["Type"]==3)
            {
                command.hidden = false;
            }
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel runat="server" ID="GridPanel1" Region="Center" StripeRows="true" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button ID="btn_SaveClick" runat="server" Text="添加" Icon="Add" Handler="function(){ CompanyX.Window1.show(document.body, function(){CompanyX.fromPanel1.reset();CompanyX.btnSave.setVisible(true);CompanyX.btnEdit.setVisible(false);});}" />
                                <ext:Button runat="server" ID="edit" Text="编辑" Disabled="true" Icon="BookEdit"  Handler="function(){
                                            CompanyX.Window1.show(document.body, function(){
                                                CompanyX.fromPanel1.reset();
                                                CompanyX.btnSave.setVisible(false);
                                                CompanyX.btnEdit.setVisible(true);
                                                var data=CompanyX.GridPanel1.getSelectionModel().getSelected();
                                                if (typeof (data) == 'undefined')
                                                {
                                                    alert('请选择一条记录');
                                                    CompanyX.Window1.hide();
                                                }
                                                else
                                                {
                                                    CompanyX.fromPanel1.getForm().loadRecord(data);
                                                }
                                        });
                                    }" />
                                <ext:Button ID="btn_ReCalculateClick" runat="server" Text="重新计算费用" Icon="Add">
                                    <DirectEvents>
                                        <Click OnEvent="btnCalculate_Click" Success="#{Store1}.reload();">
                                            <EventMask ShowMask="true" Msg="正在提交中……" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="XMLogisticsFeeDetail.ashx">
                                </ext:HttpProxy>
                            </Proxy>
                            <BaseParams>
                                <ext:Parameter Name="ID" Value="GetQueryString('ID')" Mode="Raw"></ext:Parameter>
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="ID" Root="data" TotalProperty="total">
                                    <Fields>
                                        <ext:RecordField Name="ID" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="OrderID" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Type" Type="Auto"></ext:RecordField>
                                        <ext:RecordField Name="Fee" Type="Float"></ext:RecordField>
                                        <ext:RecordField Name="Note" Type="Auto"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <Listeners>
                                <DataChanged Handler="Summary();" Delay="300" />
                            </Listeners>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:TemplateColumn runat="server" DataIndex="" MenuDisabled="true" Header="类型" Width="100">
                                <Template runat="server">
                                    <Html>
                                        <tpl if="Type ==0">
                                            总计：
                                        </tpl>
                                        <tpl if="Type ==1">
                                            主线费用
                                        </tpl>
                                        <tpl if="Type ==2">
                                            支线费用
                                        </tpl>
                                        <tpl if="Type ==3">
                                            自定义费用
                                        </tpl>
                                    </Html>
                                </Template>
                            </ext:TemplateColumn>
                            <ext:Column DataIndex="Fee" Header="费用" Width="100" />
                            <ext:Column DataIndex="Note" Header="备注" Width="200" />
                            <ext:Column Header="操作" DataIndex="" Width="45">
                                <Commands>
                                    <ext:ImageCommand CommandName="delete" Icon="Cancel" Hidden="true">
                                        <ToolTip Text="删除" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Handler="prepareCommand(command,record);" />
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="rowSelect();" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <DirectEvents>
                        <Command OnEvent="rowCommand" Success="#{Store1}.reload();">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <Confirmation ConfirmRequest="true" Title="提示" Message="确认执行此操作？" />
                            <ExtraParams>
                                <ext:Parameter Name="ID" Value="record.data['ID']" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                    <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
        <ext:Window ID="Window1" runat="server" Title="物流费用信息" BodyStyle="background:#fff;"
            CloseAction="Hide" Hidden="true" Width="335" Height="173" Layout="BorderLayout"
            Constrain="true" Icon="NoteEdit" Frame="true" Modal="true" ButtonAlign="Center" AutoScroll="true">
            <Items>
                <ext:FormPanel ID="fromPanel1" runat="server" Region="Center" Frame="true"
                    MonitorValid="true">
                    <Items>
                        <ext:TextField runat="server" ID="selectID" Hidden="true" DataIndex="ID"></ext:TextField>
                        <ext:NumberField ID="numPrice" runat="server" FieldLabel="费用" AllowBlank="false" Regex="^([1-9]\d{0,9}|0)([.]?|(\.\d{1,2})?)$"
                            MaxLength="50" MsgTarget="Side" AnchorHorizontal="93%" DataIndex="Fee" />
                        <ext:TextArea runat="server" ID="taNote" FieldLabel="备注" AnchorHorizontal="93%" DataIndex="Note"></ext:TextArea>
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
