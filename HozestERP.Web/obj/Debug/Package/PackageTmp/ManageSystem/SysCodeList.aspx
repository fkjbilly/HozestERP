<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysCodeList.aspx.cs" Inherits="HozestERP.Web.ManageSystem.SysCodeList" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BindData();
        }
    }

    protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        this.BindData();
    }

    private void BindData()
    {
        var store = this.GridPanel1.GetStore();


        var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(this.CodeTypeID);

        store.DataSource = codeLists;
        store.DataBind();
    }

    public int CodeTypeID
    {
        get
        {
            return CommonHelper.QueryStringInt("CodeTypeID");
        }
    }

    protected void btnSaveFileFolder_Click(object sender, EventArgs e)
    {
        try
        {
            int codeID = 0;
            int.TryParse(this.hidCodeID.Text, out codeID);
            var codelist = base.CodeService.GetCodeListInfoByCodeID(codeID);

            if (codelist != null)
            {
                codelist.CodeName = this.txtCodeName.Text.Trim();
                codelist.CodeNO = this.txtCodeNo.Text.Trim();
                codelist.CodeTypeID = this.CodeTypeID;
                codelist.Deleted = this.chkDelete.Checked;
                codelist.DisplayOrder = int.Parse(this.txtDisplayOrder.Text);
                base.CodeService.UpdateCodeList(codelist);
            }
            else
            {
                codelist = new HozestERP.BusinessLogic.Codes.CodeList();
                codelist.CodeName = this.txtCodeName.Text.Trim();
                codelist.CodeNO = this.txtCodeNo.Text.Trim();
                codelist.CodeTypeID = this.CodeTypeID;
                codelist.Deleted = this.chkDelete.Checked;
                codelist.DisplayOrder = int.Parse(this.txtDisplayOrder.Text);
                base.CodeService.InsertCodeList(codelist);
            }
            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示信息",
                Message = "公用代码修改成功!",
                Icon = MessageBox.Icon.INFO,
                Buttons = MessageBox.Button.OK,
            });
            this.BindData();
            this.CodeListWindow.Hide();
        }
        catch (Exception err)
        {
            base.ProcessException(err);
        }
    }


    [DirectMethod(Namespace = "CompanyX")]
    public void DeleteCode(int codeID)
    {
        try
        {
            base.CodeService.DeleteCodeList(codeID);
            this.BindData();
            X.MessageBox.Show(new MessageBoxConfig()
            {
                Title = "提示信息",
                Message = "公用代码删除成功!",
                Icon = MessageBox.Icon.INFO,
                Buttons = MessageBox.Button.OK,
            });
        }
        catch (Exception err)
        {
            base.ProcessException(err);
        }
    }
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>浙江博鸿小菜食品有限公司--Bohong Food</title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var DeletedChange = function (value) {
            return String.format(template, value ? "red" : "green", value ? "停用" : "启用")
        };
        var GridCommand = function (commandName, record) {
            if (commandName == "Edit") {
                CompanyX.CodeListWindow.show(document.body, function () { CompanyX.fromPanel1.setValue(record) });
            }
            else {
                Ext.MessageBox.confirm('提示信息', '确定删除您选中的记录吗？', function (btn) {
                    if (btn == "yes") {
                        CompanyX.DeleteCode(record.CodeID);
                    }
                });
            }
        }
        var rowclickFn = function (grid, rowindex, e) {
            GridCommand("Edit", grid.getSelectionModel().getSelected().data);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:GridPanel ID="GridPanel1" Region="Center" runat="server" StripeRows="true" AutoExpandColumn="CodeName"
                AutoScroll="true">
                <TopBar>
                    <ext:Toolbar>
                        <Items>
                            <ext:Button Text="添加公用代码" Icon="Add" Handler="function(){ CompanyX.CodeListWindow.show(document.body, function(){CompanyX.fromPanel1.reset();});}">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Store>
                    <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
                        <Reader>
                            <ext:JsonReader IDProperty="CodeID">
                                <Fields>
                                    <ext:RecordField Name="CodeID" Type="Int" />
                                    <ext:RecordField Name="CodeTypeID" Type="Int" />
                                    <ext:RecordField Name="CodeNO" Type="String" />
                                    <ext:RecordField Name="CodeName" Type="String" />
                                    <ext:RecordField Name="DisplayOrder" Type="Int" />
                                    <ext:RecordField Name="Deleted" Type="Boolean" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn />
                        <ext:Column ColumnID="CodeName" Header="名称" Width="160" DataIndex="CodeName" />
                        <ext:Column Header="编号" Width="75" DataIndex="CodeNO">
                        </ext:Column>
                        <ext:Column Header="排序" Width="75" DataIndex="DisplayOrder">
                        </ext:Column>
                        <ext:Column Header="状态" Width="75" DataIndex="Deleted">
                            <Renderer Fn="DeletedChange" />
                        </ext:Column>
                        <ext:CommandColumn Width="60">
                            <Commands>
                                <ext:GridCommand Icon="Delete" CommandName="Delete">
                                    <ToolTip Text="删除" />
                                </ext:GridCommand>
                                <ext:CommandSeparator />
                                <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                    <ToolTip Text="修改" />
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
    <ext:Window ID="CodeListWindow" runat="server" Title="公用代码维护" BodyStyle="background:#fff;"
        CloseAction="Hide" Hidden="true" Width="400" Height="180" Layout="BorderLayout"
        Constrain="true" Icon="NoteEdit" Frame="true" Modal="true" ButtonAlign="Center">
        <Items>
            <ext:FormPanel ID="fromPanel1" runat="server" Region="Center" Frame="true" DefaultAnchor="92%"
                MonitorValid="true">
                <Items>
                    <ext:Hidden ID="hidCodeID" runat="server" FieldLabel="CodeID" DataIndex="CodeID" />
                    <ext:TextField ID="txtCodeNo" runat="server" FieldLabel="编号" DataIndex="CodeNO" AllowBlank="false"
                        MaxLength="50" MsgTarget="Side" />
                    <ext:TextField ID="txtCodeName" runat="server" FieldLabel="名称" DataIndex="CodeName"
                        AllowBlank="false" MaxLength="100" MsgTarget="Side" />
                    <ext:NumberField ID="txtDisplayOrder" runat="server" FieldLabel="排序" DataIndex="DisplayOrder"
                        AllowBlank="false" MsgTarget="Side" AllowDecimals="false" />
                    <ext:Checkbox ID="chkDelete" runat="server"  FieldLabel="" BoxLabel="停用" DataIndex="Deleted">
                    </ext:Checkbox>
                </Items>
                <Listeners>
                    <ClientValidation Handler="#{btnSaveFileFolder}.setDisabled(!valid);" />
                </Listeners>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button Text="保存" ID="btnSaveFileFolder" runat="server">
                <DirectEvents>
                    <Click OnEvent="btnSaveFileFolder_Click">
                        <EventMask ShowMask="true" Msg="正在提交中……" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button Text="关闭" Handler="function(){CompanyX.CodeListWindow.hide();}">
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
