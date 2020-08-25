<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="CWProfitListAnalysisSSY.aspx.cs" Inherits="HozestERP.Web.ManageFinance.CWProfitListAnalysisSSY" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/highcharts.js" type="text/javascript"></script>
    <script src="../Script/HighChart.js" type="text/javascript"></script>
    <script src="../Script/WaitBox.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(function ($) {
            BindDepartmentType();
        });

        function BindProjectId(mark) {
            var DepartmentType = document.getElementById("ddlDepartmentType");
            var ddlProjectId = document.getElementById("ddlProjectId");
            var DepartmentTypeID = DepartmentType.value;
            jQuery(function ($) {
                $.ajax({ url: "cWProfitListAnalysisSSY.ashx?DepartmentTypeID=" + DepartmentTypeID,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=BindProjectId",
                    success: function (json) {
                        ddlProjectId.length = 0;
                        for (var i = 0; i < json.length; i++) {
                            var op = document.createElement("option");
                            ddlProjectId.appendChild(op);
                            op.text = json[i].Name;
                            op.value = json[i].Value;
                        }
                        if (mark == 1) {
                            document.getElementById("<%=btnSearch.ClientID %>").click();
                        }
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function BindDepartmentType() {
            var ddlDepartmentType = document.getElementById("ddlDepartmentType");
            jQuery(function ($) {
                $.ajax({ url: "cWProfitListAnalysisSSY.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=BindDepartmentType",
                    success: function (json) {
                        for (var i = 0; i < json.length; i++) {
                            var op = document.createElement("option");
                            ddlDepartmentType.appendChild(op);
                            op.text = json[i].CodeName;
                            op.value = json[i].CodeID;
                        }
                        BindProjectId(1);
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function GetFormatData(Data) {
            var data = new Array();
            for (var i = 0; i < Data.length; i++) {
                var obj = { name: '' + Data[i].Name + '', group: '' + Data[i].Group + '', value: Data[i].Value };
                data.push(obj);
            }
            return data;
        }

        function dataBind(year) {
            jQuery(function ($) {
                $.ajax({ url: "cWProfitListAnalysisSSY.ashx?Year=" + year,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=Analysis",
                    success: function (json) {
                        var monthData = GetFormatData(json[0]);
                        var yearData = GetFormatData(json[1]);
                        var reachData = GetFormatData(json[2]);
                        var growthData = GetFormatData(json[3]);

                        var opt = HighChart.ChartOptionTemplates.Bars(monthData, '', '', '', "月目标实现对比图");
                        var opt1 = HighChart.ChartOptionTemplates.Bars(yearData, '', '', '', "年目标实现对比图");
                        var opt2 = HighChart.ChartOptionTemplates.FinanceLine(reachData, '', "月达成率");
                        var opt3 = HighChart.ChartOptionTemplates.FinanceLine(growthData, '', "月增长率");

                        var container = $("#container");
                        var container1 = $("#container1");
                        var container2 = $("#container2");
                        var container3 = $("#container3");

                        HighChart.RenderChart(opt, container);
                        HighChart.RenderChart(opt1, container1);
                        HighChart.RenderChart(opt2, container2);
                        HighChart.RenderChart(opt3, container3);

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <%-- 条件查询--%>
        <tr>
            <td colspan="2" style="width: 100%">
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td style="width: 90px" align="right">
                            类别:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlType" runat="server" Width="100%" Enabled="true">
                                <asp:ListItem Value="1">收入</asp:ListItem>
                                <asp:ListItem Value="2">成本</asp:ListItem>
                                <asp:ListItem Value="3">毛利</asp:ListItem>
                                <asp:ListItem Value="4">利润 </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 90px" align="right">
                            部门类型:
                        </td>
                        <td style="width: 150px">
                            <select id="ddlDepartmentType" name="ddlDepartmentType" onchange="BindProjectId(0)"
                                style="width: 150px;">
                            </select>
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 90px" align="right">
                            项目名称:
                        </td>
                        <td style="width: 150px">
                            <select id="ddlProjectId" name="ddlProjectId" style="width: 150px;">
                            </select>
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 90px" align="right">
                            年份：
                        </td>
                        <td style="width: 150px">
                            <input id="txtYearStr" onfocus="WdatePicker({dateFmt:'yyyy'})" class="Wdate" runat="server"
                                style="width: 100%;" />
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 90px" align="right">
                            月份：
                        </td>
                        <td style="width: 150px" align="right">
                            <input id="txtMonthStr" onfocus="WdatePicker({dateFmt:'M'})" class="Wdate" runat="server"
                                style="width: 100%;" />
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" OnClientClick="return Showdiv('<br/>查找中，请等待‥‥‥<br/>');" />
                            <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                                OnClick="btnRefresh_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table border="1" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr style="height: 40px; background-color: #BFBFBF; font-size: large;" align="center">
            <th>
                类别
            </th>
            <th>
                月目标
            </th>
            <th>
                月实际
            </th>
            <th>
                月达成率
            </th>
            <th>
                去年该月同期
            </th>
            <th>
                月增长率
            </th>
            <th>
                年目标
            </th>
            <th>
                年实际
            </th>
            <th>
                年达成率
            </th>
            <th>
                去年同期
            </th>
            <th>
                年增长率
            </th>
        </tr>
        <%=TabStr %>
    </table>
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 70%">
                <div id="container" style="margin: 0 auto; height: 400px; width: 100%;" />
            </td>
            <td style="width: 30%">
                <div id="container1" style="margin: 0 auto; height: 400px; width: 100%;" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="container2" style="margin: 0 auto; height: 400px; width: 100%;" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="container3" style="margin: 0 auto; height: 400px; width: 100%;" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
