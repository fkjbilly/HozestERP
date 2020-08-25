<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="OperatingResults.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.OperatingResults" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/highcharts.js" type="text/javascript"></script>
    <script src="../Script/HighChart.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            dataBind("week");
        });

        function dataBind(DateType) {
            var Year = document.getElementById("<%=ddlYear.ClientID %>").value;
            var Month = document.getElementById("<%=ddlMonth.ClientID %>").value;
            var PageType = document.getElementById("HidPageType").value;
            //var CheckedValue = $('input:radio[type="radio"]:checked').val();
            jQuery(function ($) {
                $.ajax({ url: "operatingResults.ashx?action=operatingResults&DateType=" + DateType + "&Year=" + Year + "&Month=" + Month,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "PageType=" + PageType,
                    success: function (json) {
                        var data = new Array();
                        for (var i = 0; i < json.length; i++) {
                            var obj = { name: '' + json[i].Name + '', group: '' + json[i].Group + '', value: json[i].Value };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Line(data, '', "", DateType, Year, Month);
                        var container = $("#container");
                        HighChart.RenderChart(opt, container);
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }
 
    </script>
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
        
        .button
        {
            padding: 10px;
            width: 300px;
            height: 50px;
            border: 5px solid #dedede;
            -moz-border-radius: 15px; /* Gecko browsers */
            -webkit-border-radius: 15px; /* Webkit browsers */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <input type="hidden" id="HidPageType" value='<%=PageType %>' />
            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                <tr>
                    <th>
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td style="width: 80px">
                                </td>
                                <td style="width: 100px" align="right">
                                    年份：
                                </td>
                                <td style="width: 200px;" align="left">
                                    <asp:DropDownList ID="ddlYear" Width="100%" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td style="width: 100px" align="right">
                                    月份：
                                </td>
                                <td style="width: 200px" align="left">
                                    <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                                        <asp:ListItem Value="-1" Selected="True">---全年---</asp:ListItem>
                                        <asp:ListItem Value="1">1月</asp:ListItem>
                                        <asp:ListItem Value="2">2月</asp:ListItem>
                                        <asp:ListItem Value="3">3月</asp:ListItem>
                                        <asp:ListItem Value="4">4月</asp:ListItem>
                                        <asp:ListItem Value="5">5月</asp:ListItem>
                                        <asp:ListItem Value="6">6月</asp:ListItem>
                                        <asp:ListItem Value="7">7月</asp:ListItem>
                                        <asp:ListItem Value="8">8月</asp:ListItem>
                                        <asp:ListItem Value="9">9月</asp:ListItem>
                                        <asp:ListItem Value="10">10月</asp:ListItem>
                                        <asp:ListItem Value="11">11月</asp:ListItem>
                                        <asp:ListItem Value="12">12月</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 320px">
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;" valign="top">
                        <table width="100%" style="height: 105">
                            <tr>
                                <td style="height: 35px" align="center">
                                    <asp:Button ID="btnWeek" runat="server" Text="近一周" OnClick="btnWeek_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 35px" align="center">
                                    <asp:Button ID="btnMonth" runat="server" Text="本月" OnClick="btnMonth_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 35px" align="center">
                                    <asp:Button ID="btnYear" runat="server" Text="本年" OnClick="btnYear_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table width="100%" style="height: 105">
                            <tr>
                                <td width="850px" style="height: 100%;">
                                    <div id="container" style="margin: 0 auto; height: 400px; width: 850px;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 15%;" valign="top" align="center">
                    </td>
                </tr>
            </table>
            <table cellpadding="2" cellspacing="2" style="width: 100%; height: 100%;" border="1px"
                bordercolor="#999999">
                <%=TableList %>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
