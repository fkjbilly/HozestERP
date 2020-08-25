<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMBusinessDataB2BServiceType.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.XMBusinessDataB2BServiceType" %>

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
                    text: 'B2B数据分析-业务类型'
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
                            format: '<b>{point.name}</b>: {point.percentage:.2f} %',
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
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMBusinessDataB2BServiceType.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <div id="container" style="min-width: 400px; height: 400px">
    </div>
    <%--<asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" SkinID="GridViewThemen">
        <Columns>
            <asp:TemplateField HeaderText="收入/支出" SortExpression="AssociatedPerson">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  (bool)Eval("IsIncome") == true ? "收入" : "支出"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="Amount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Amount")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</asp:Content>
