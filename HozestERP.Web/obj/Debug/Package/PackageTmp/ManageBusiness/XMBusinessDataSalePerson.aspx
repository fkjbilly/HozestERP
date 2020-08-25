<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMBusinessDataSalePerson.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.XMBusinessDataSalePerson" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../Script/highcharts.js" type="text/javascript"></script>
    <script type="text/javascript">
        var index = 0;
        $(document).ready(function () {
            // Loadpie();
            LodaChartData('column');  //line
        });
        function LodaChartData(SeriesType) {
            var hititle = document.getElementById("<%=hititle.ClientID %>").value;
            var hicontent = document.getElementById("<%=hiddcontent.ClientID %>").value;

            var chart = new Highcharts.Chart({
                chart: {
                    renderTo: 'container',          //放置图表的容器
                    plotBackgroundColor: "#fff",
                    plotBorderWidth: null,
                    defaultSeriesType: SeriesType   //图表类型line, spline, area, areaspline, column, bar, pie , scatter 
                },
                title: {
                    text: hititle
                },
                xAxis: {//X轴数据

                },
                yAxis: {//Y轴显示文字
                    title: {
                        text: '业务金额'
                    }
                },
                tooltip: {
                    enabled: true,
                    formatter: function () {
                        return this.series.name + ': ' + Highcharts.numberFormat(this.y, 1);
                    }
                },
                plotOptions: {
                    column: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: true//是否显示title
                    }
                },
                series: eval(hicontent)
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hititle" runat="server" />
    <asp:HiddenField ID="hiddcontent" runat="server" />
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
            <td style="width: 50px" align="right">
                部门:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddlBelongingDep" Width="90%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                项目:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlBelongingProject" Width="90%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                摘要:
            </td>
            <td style="width: 250px;">
                <asp:TextBox ID="txtAbstract" Width="90%" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 70px; height: 35px;" align="right">
                收入/支出:
            </td>
            <td style="width: 105px;">
                <asp:DropDownList ID="ddlFinancialType" Width="100%" runat="server">
                    <asp:ListItem Value="1" Selected="True">收入</asp:ListItem>
                    <asp:ListItem Value="0">支出</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 100px" align="right">
                收款/支付方式:
            </td>
            <td style="width: 105px;">
                <asp:DropDownList ID="ddlPaymentCollectionType" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                审核:
            </td>
            <td style="width: 80px;">
                <asp:DropDownList ID="ddlAudit" Width="90%" runat="server">
                    <asp:ListItem Value="-1">--所有--</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: center" colspan="6">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMBusinessDataSalePerson.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <div id="container" style="height: 680px;">
    </div>
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" SkinID="GridViewThemen"
        ShowFooter="true"  OnRowDataBound="grdvClients_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="交款人/报销人" SortExpression="AssociatedPerson">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Eval("AssociatedPerson") == null || Eval("AssociatedPerson").ToString() == "") ? "未认领" : Eval("AssociatedPerson")%>
                </ItemTemplate>
                <FooterTemplate>
                    合计
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="Amount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Amount")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumAmount" runat="server"></asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
