<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="JdReturn.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.JdReturn" %>

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
    <style type="text/css">

    </style>
    <script type="text/javascript">
        function dataBind(Begin, End, NickIDs)
        {
            var total = 0;
            jQuery(function ($) {
                $.ajax({
                    url: "productSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=JdReturn&&Begin="+Begin+"&&End="+End+"&&NickIDs="+NickIDs,
                    success: function (json) {
                        var data = new Array();

                        for (var i = 0; i < json.length; i++) {
                            var count = Number(json[i].Value.toString());
                            total = total + count;
                            var obj = { name: '' + json[i].Name + '', value: count };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Pie_Count(data, '', "京东自营退货单统计-总计" + total + "件");
                        var container = $("#Div");
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                <tr>
                    <td style="width: 80px">
                        开始时间：
                    </td>
                    <td style="width: 120px">
                        <input id="txtBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                            runat="server" style="width: 100%;" />
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        结束时间：
                    </td>
                    <td style="width: 120px">
                        <input id="txtEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server"
                            style="width: 100%;" />
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        项目：
                    </td>
                    <td style="width: 90px">
                        <ext:ComboBox runat="server" ID="CbProject" AnchorHorizontal="95%" Editable="false" EmptyText="请选择" DisplayField="ProjectName" ValueField="Id">
                            <Store>
                                <ext:Store runat="server" ID="ProjectStore">
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
                            <DirectEvents>
                                <Select OnEvent="Project_Select"></Select>
                            </DirectEvents>
                        </ext:ComboBox>
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        店铺：
                    </td>
                    <td style="width: 90px">
                        <ext:ComboBox runat="server" ID="CbNick" AnchorHorizontal="95%" Editable="false" EmptyText="请选择" DisplayField="nick" ValueField="nick_id">
                            <Store>
                                <ext:Store runat="server" ID="NickStore">
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
                    <td style="width: 40px">
                    </td>
                    <td>
                        <asp:Button runat="server" Text="查询" ID="btnSearch1" onClick="btnSearch1_Click" />
                    </td>
                </tr>
            </table>
         <ext:ResourceManager ID="ResourceManager2" runat="server"/>
    <ext:GridPanel ID="GridPanel2" runat="server" Frame="true" Border="false" BodyCssClass="x-selectable" AutoScroll="true" Height="150">
        <Store>
            <ext:Store ID="store1" runat="server">
                <Reader>
                    <ext:JsonReader>
                        <Fields>
                            <ext:RecordField Name="ReturnType" />
                            <ext:RecordField Name="Cost" />
                            <ext:RecordField Name="ReturnMoney" />
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
                <ext:Column DataIndex="ReturnType" Header="退货类型" Width="65"/>
                <ext:Column DataIndex="Cost" Header="成本" Width="100"/>
                <ext:Column DataIndex="ReturnMoney" Header="退货金额" Width="100"/>
                <ext:Column DataIndex="Num" Header="数量" Width="65"/>
                <ext:Column DataIndex="CountProportion" Header="占比" Width="65"/>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
            <div id="Div" style="margin: 0 auto;" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
