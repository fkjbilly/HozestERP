<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="LogisticsCostStatistics.aspx.cs" Inherits="HozestERP.Web.ManageProject.LogisticsCostStatistics" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../Script/highcharts.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var t = document.getElementById("<%=hiddContent.ClientID %>").value;
            $('#container').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: '物流费用统计-店铺'
                },
                tooltip: {
                    pointFormat: '<b>{point.percentage:.2f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}  {point.percentage:.2f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    data: eval(t)
                }]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hiddContent" runat="server" />
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 60px; height: 35px;" align="right">
                开始日期:
            </td>
            <td style="width: 100px;">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px" align="right">
                结束日期:
            </td>
            <td style="width: 100px;">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                项目:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.LogisticsCostStatistics.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="text-align: center;height:30px;font-size:medium" >
        <asp:Label ID="lbTotalPrice" runat="server"></asp:Label>
    </div>
    <div id="container" style="min-width: 400px; height: 400px">
    </div>
    <asp:GridView ID="grdvLogisticsCost" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvLogisticsCost_RowDataBound" ShowFooter="true">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        发货单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        订单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        物流单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        创单时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        物流公司
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        物流费用
                    </th>
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货单号" SortExpression="DeliveryNumber">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" 物流单号" SortExpression="LogisticsNumber">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("LogisticsNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" 创单时间" SortExpression="CreateDate">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("CreateDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" 物流公司" SortExpression="SaleAddress">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblLogisticsId" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流费用" SortExpression="Price">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Price")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
