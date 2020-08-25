<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderWarningDetails.aspx.cs" Inherits="HozestERP.Web.ManagePortlet.OrderWarningDetails" %>

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
                <ext:GridPanel runat="server" ID="GridPanel1" Title="异常订单详情" Margins="0 0 5 5" Icon="UserSuit" Region="Center" StripeRows="true" AutoScroll="true" Height="500">
                     <Store>
                        <ext:Store runat="server" ID="StoreWorker" OnRefreshData="Data_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="orderCode">
                                    <Fields>
                                        <ext:RecordField Name="orderCode"></ext:RecordField>
                                        <ext:RecordField Name="reason"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn />
                            <ext:Column Header="订单号" Width="150" DataIndex="orderCode" />
                            <ext:Column Header="订单总价" Width="100" DataIndex="reason" />
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
