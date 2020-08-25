<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderMonitorDetails.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.OrderMonitorDetails" %>

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
        <ext:GridPanel runat="server" ID="GridPanel1" Title="差异订单详情" Margins="0 0 5 5" Icon="UserSuit" Region="Center" StripeRows="true" AutoScroll="true" Height="500">
                     <Store>
                        <ext:Store runat="server" ID="StoreWorker" OnRefreshData="Data_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="OrderCode">
                                    <Fields>
                                        <ext:RecordField Name="OrderCode"></ext:RecordField>
                                        <ext:RecordField Name="OrderPrice"></ext:RecordField>
                                        <ext:RecordField Name="minprice"></ext:RecordField>
                                        <ext:RecordField Name="cashbackmoney"></ext:RecordField>
                                        <ext:RecordField Name="price"></ext:RecordField>
                                        <ext:RecordField Name="amount"></ext:RecordField>
                                        <ext:RecordField Name="differenceprice"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column Header="订单号" Width="150" DataIndex="OrderCode" />
                            <ext:Column Header="订单总价" Width="100" DataIndex="OrderPrice" />
                            <ext:Column Header="最低销售价" Width="100" DataIndex="minprice" />
                            <ext:Column Header="返现" Width="100" DataIndex="cashbackmoney" />
                            <ext:Column Header="赠品" Width="100" DataIndex="price" />
                            <ext:Column Header="退换货" Width="100" DataIndex="amount" />
                            <ext:Column Header="差额" Width="100" DataIndex="differenceprice" />
                        </Columns>
                    </ColumnModel>

                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                        </ext:RowSelectionModel>
                    </SelectionModel>

                    <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
        </ext:GridPanel>
    </div>
    </form>
</body>
</html>
