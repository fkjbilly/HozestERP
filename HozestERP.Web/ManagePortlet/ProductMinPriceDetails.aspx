<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductMinPriceDetails.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.ProductMinPriceDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server"/>
                <ext:GridPanel runat="server" ID="GridPanel1" Title="未设置最低售价商品详情详情" Margins="0 0 5 5" Icon="UserSuit" Region="Center" StripeRows="true" AutoScroll="true" Height="500">
                     <Store>
                        <ext:Store runat="server" ID="StoreWorker" OnRefreshData="Data_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="Id">
                                    <Fields>
                                        <ext:RecordField Name="Id"></ext:RecordField>
                                        <ext:RecordField Name="ProductName"></ext:RecordField>
                                        <ext:RecordField Name="ManufacturersCode"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column Header="商品名称" Width="150" DataIndex="ProductName" />
                            <ext:Column Header="商品编码" Width="150" DataIndex="ManufacturersCode" />
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
    </div>
    </form>
</body>
</html>
