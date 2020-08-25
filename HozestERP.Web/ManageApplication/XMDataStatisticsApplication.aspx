<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="XMDataStatisticsApplication.aspx.cs" Inherits="HozestERP.Web.ManageApplication.XMDataStatisticsApplication" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/highcharts.js" type="text/javascript"></script>
    <script src="../Script/HighChart.js" type="text/javascript"></script>
    <script src="../Script/WaitBox.js" type="text/javascript"></script>
    <script type="text/javascript">
        function dataBindHuan(ddlPlatform, nickid, timetype, ApplicaType, BeginDate, EndDate) {
            var total = 0;
            var total1 = 0;

            jQuery(function ($) {
                $.ajax({
                    url: "applicationSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=applicationSalesHuan&&ddlPlatform=" + ddlPlatform + "&&nickid=" + nickid + "&&timetype=" + timetype + "&&ApplicaType=" + ApplicaType + "&&BeginDate=" + BeginDate + "&&EndDate=" + EndDate,
                    success: function (json) {
                        var data = new Array();

                        for (var i = 0; i < json.length; i++) {
                            var count = Number(json[i].Value.toString());
                            total = total + count;
                            var obj = { name: '' + json[i].Name + '', value: count };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Pie_Count(data, '', "换货统计-总计" + total + "件");
                        var container = $("#DivHuan");
                        HighChart.RenderChart(opt, container);
                        Closediv();
                    },
                    error: function (x, e) {
                        Closediv();
                    },
                    complete: function (x) {
                        Closediv();
                    }
                });

                $.ajax({
                    url: "applicationSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=applicationSalesTui&&ddlPlatform=" + ddlPlatform + "&&nickid=" + nickid + "&&timetype=" + timetype + "&&ApplicaType=" + ApplicaType + "&&BeginDate=" + BeginDate + "&&EndDate=" + EndDate,
                    success: function (json) {
                        var data = new Array();

                        for (var i = 0; i < json.length; i++) {
                            var count = Number(json[i].Value.toString());
                            total1 = total1 + count;
                            var obj = { name: '' + json[i].Name + '', value: count };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Pie_Count(data, '', "退货统计-总计" + total1 + "件");
                        var container = $("#DivTui");
                        HighChart.RenderChart(opt, container);
                        Closediv();
                    },
                    error: function (x, e) {
                        Closediv();
                    },
                    complete: function (x) {
                        Closediv();
                    }
                });
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <ext:ResourceManager runat="server" />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
           <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
              <tr>
                <td style="width: 200px">
                    <ext:ComboBox runat="server" ID="ddlPlatformEXT" Editable="false" AnchorHorizontal="95%" EmptyText="请选择" FieldLabel="平台" DisplayField="CodeName" ValueField="CodeID" LabelWidth="60">
                        <Store>
                            <ext:Store runat="server" ID="StorePlatform">
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
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 240px">
                    <ext:ComboBox runat="server" ID="ddlNickEXT" Editable="false" AnchorHorizontal="98%" EmptyText="请选择" FieldLabel="店铺名称" DisplayField="nick" ValueField="nick_id" LabelWidth="60">
                        <Store>
                            <ext:Store runat="server" ID="SoreNick">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="nick_id"></ext:RecordField>
                                            <ext:RecordField Name="nick"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 88px">
                    <ext:ComboBox runat="server" ID="timetypeEXT" Editable="false" AnchorHorizontal="95%" SelectedIndex="0">
                        <Items>
                            <ext:ListItem Text="申请时间" Value="1" />
                            <ext:ListItem Text="完成时间" Value="2" />
                            <ext:ListItem Text="入库时间" Value="3" />
                        </Items>
                    </ext:ComboBox>
                </td>
                <td style="width: 120px" nowrap="nowrap">
                                            <input id="txtBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                            runat="server" style="width: 100%;" />
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                    &nbsp;&nbsp;至&nbsp;&nbsp;
                </td>
                <td style="width: 120px" nowrap="nowrap">
                        <input id="txtEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server"
                            style="width: 100%;" />
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 200px">
                    <ext:ComboBox runat="server" ID="ApplicaTypeEXT" Editable="false" AnchorHorizontal="95%" FieldLabel="申请类型" EmptyText="请选择" LabelWidth="60">
                        <Items>
                            <ext:ListItem Text="售后" Value="9" />
                            <ext:ListItem Text="售中" Value="10" />
                            <ext:ListItem Text="未发货退款" Value="4" />
                            <ext:ListItem Text="先退货后退款" Value="5" />
                            <ext:ListItem Text="退运费" Value="8" />
                            <ext:ListItem Text="换货" Value="6" />
                            <ext:ListItem Text="先退款后退货" Value="7" />
                        </Items>
                    </ext:ComboBox>
                </td>
                <td style="width: 20px">
                </td>
                  <td>
                      <asp:Button runat="server" ID="btnSearch" Text="查询" OnClick="btnSearch_Click"/>
                  </td>
            </tr>
        </table>
            <ext:Panel runat="server" Height="558">
                <Items>
                <ext:ColumnLayout runat="server" Split="true" FitHeight="true">
                <Columns>
                    <ext:LayoutColumn ColumnWidth="0.5">
                        <ext:Panel runat="server" Title="退货统计" Html="<div id='DivTui' style='margin: 0 auto;' />">
                            <Items>
                               <ext:GridPanel ID="GridPanelTui" runat="server" Frame="true" Border="false" BodyCssClass="x-selectable" AutoScroll="true" Height="150">
                                   <Store>
                                       <ext:Store ID="StoreTui" runat="server">
                                           <Reader>
                                               <ext:JsonReader>
                                                   <Fields>
                                                            <ext:RecordField Name="ManufacturersCode" />
                                                            <ext:RecordField Name="ProductName" />
                                                            <ext:RecordField Name="Num" />
                                                            <ext:RecordField Name="CountProportion" />
                                                   </Fields>
                                               </ext:JsonReader>
                                           </Reader>
                                       </ext:Store>
                                   </Store>
                                   <SelectionModel>
                                        <ext:RowSelectionModel runat="server"></ext:RowSelectionModel>
                                   </SelectionModel>
                                   <ColumnModel>
                                       <Columns>
                                                <ext:Column DataIndex="ManufacturersCode" Header="厂家编码" Width="100"/>
                                                <ext:Column DataIndex="ProductName" Header="商品名称" Width="120"/>
                                                <ext:Column DataIndex="Num" Header="退货数量" Width="65"/>
                                                <ext:Column DataIndex="CountProportion" Header="占比" Width="65"/>
                                       </Columns>
                                   </ColumnModel>
                               </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </ext:LayoutColumn>
                    
                    <ext:LayoutColumn ColumnWidth="0.5">
                        <ext:Panel runat="server" Title="换货统计"  Html="<div id='DivHuan' style='margin: 0 auto;' />">
                            <Items>
                                <ext:GridPanel ID="GridPanelHuan" runat="server" Frame="true" Border="false" BodyCssClass="x-selectable" AutoScroll="true" Height="150">
                                   <Store>
                                       <ext:Store ID="StoreHuan" runat="server">
                                           <Reader>
                                               <ext:JsonReader>
                                                   <Fields>
                                                            <ext:RecordField Name="ManufacturersCode" />
                                                            <ext:RecordField Name="ProductName" />
                                                            <ext:RecordField Name="Num" />
                                                            <ext:RecordField Name="CountProportion" />
                                                   </Fields>
                                               </ext:JsonReader>
                                           </Reader>
                                       </ext:Store>
                                   </Store>
                                   <SelectionModel>
                                        <ext:RowSelectionModel runat="server"></ext:RowSelectionModel>
                                   </SelectionModel>
                                   <ColumnModel>
                                       <Columns>
                                                <ext:Column DataIndex="ManufacturersCode" Header="厂家编码" Width="100"/>
                                                <ext:Column DataIndex="ProductName" Header="商品名称" Width="120"/>
                                                <ext:Column DataIndex="Num" Header="换货数量" Width="65"/>
                                                <ext:Column DataIndex="CountProportion" Header="占比" Width="65"/>
                                       </Columns>
                                   </ColumnModel>
                               </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </ext:LayoutColumn>
                </Columns>
            </ext:ColumnLayout>
                </Items>
            </ext:Panel>

                    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

