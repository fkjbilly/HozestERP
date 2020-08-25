<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="CompanyOperation.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.CompanyOperation" %>

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

        var total = 0;

        $(document).ready(function () {
            dataBind("week");
        });

        function randomString(len) {
            len = len || 32;
            var $chars = 'ABCDEFGHJKMNPQRSTWXYZabcdefhijkmnprstwxyz2345678';    /****默认去掉了容易混淆的字符oOLl,9gq,Vv,Uu,I1****/
            var maxPos = $chars.length;
            var pwd = '';
            for (i = 0; i < len; i++) {
                pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
            }
            return pwd;
        }

        function ToJsonLine(list) {
            var data = new Array();
            for (var i = 0; i < list.length; i++) {
                var obj = { name: '' + list[i].Name + '', group: '' + list[i].Group + '', value: list[i].Value };
                data.push(obj);
            }
            return data;
        }

        function ToJsonPie(list) {
            total = 0;
            var data = new Array();
            for (var i = 0; i < list.length; i++) {
                var obj = { name: '' + list[i].Name + '', value: list[i].Value };
                data.push(obj);
                total = total + list[i].Value;
            }
            return data;
        }

        function NewTab(no) {
            var title = "";
            if (no == "1") {
                title = "总目标";
            }
            else if (no == "2") {
                title = "总营业业绩";
            }
            else if (no == "3") {
                title = "总营业成本";
            }
            else if (no == "4") {
                title = "营业费用";
            }
            else if (no == "5") {
                title = "增值税";
            }
            else if (no == "6") {
                title = "毛利";
            }
            ShowNewTabDetail('ManageBusiness/CompanyOperationTab.aspx?Id=' + no, 'Tab' + randomString(5), title + '详细饼图');
        }

        function ToStr(list) {
            var str = "";
            var data = new Array();
            for (var i = 0; i < list.length; i++) {
                str = str + list[i].Name + ',' + list[i].Value + ":";
            }
            return str;
        }

        function dataBind(DateType) {
            var PageType = document.getElementById("HidPageType").value;
            var CustomYear = document.getElementById("<%=ddlYear.ClientID%>").value;
            var CustomMonth = document.getElementById("<%=ddlMonth.ClientID%>").value;
            var ProjectID = document.getElementById("<%=ddlXMProjectNameId.ClientID%>").value;
            var NickID = document.getElementById("<%=ddlNickList.ClientID%>").value;
            jQuery(function ($) {
                $.ajax({ url: "companyOperation.ashx?action=companyOperation&DateType=" + DateType + "&Year=" + CustomYear + "&Month=" + CustomMonth + "&ProjectId=" + ProjectID + "&NickId=" + NickID,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "PageType=" + PageType,
                    success: function (json) {
                        var data = ToJsonLine(json[0])
                        var opt = HighChart.ChartOptionTemplates.Line(data, '', "", DateType, CustomYear, CustomMonth);
                        var container = $("#container");
                        HighChart.RenderChart(opt, container);

                        var data2 = ToJsonPie(json[2])
                        var opt2 = HighChart.ChartOptionTemplates.Pie_Simple(data2, '', "<b>总营业业绩</b> \n " + total.toFixed(2) + "元");
                        var container2 = $("#Div2");
                        HighChart.RenderChart(opt2, container2);
                        document.cookie = "data2=" + ToStr(json[2]) + ";path=/ManageBusiness";

                        var target = total;
                        var data1 = ToJsonPie(json[1])

                        if (total != 0) {
                            target = ((target / total) * 100).toFixed(2);
                        }
                        else {
                            target = 0;
                        }

                        var Target = "";
                        if (target != 0) {
                            Target = target + "%";
                        }

                        var opt1 = HighChart.ChartOptionTemplates.Pie_Simple(data1, '', "<b>总目标　</b> \n " + total.toFixed(2) + "元 \n " + Target);
                        var container1 = $("#Div1");
                        HighChart.RenderChart(opt1, container1);
                        document.cookie = "data1=" + ToStr(json[1]) + ";path=/ManageBusiness";

                        var data3 = ToJsonPie(json[3])
                        var opt3 = HighChart.ChartOptionTemplates.Pie_Simple(data3, '', "<b>总营业成本</b> \n " + total.toFixed(2) + "元");
                        var container3 = $("#Div3");
                        HighChart.RenderChart(opt3, container3);
                        document.cookie = "data3=" + ToStr(json[3]) + ";path=/ManageBusiness";

                        var data4 = ToJsonPie(json[4])
                        var opt4 = HighChart.ChartOptionTemplates.Pie_Simple(data4, '', "<b>营业费用</b> \n " + total.toFixed(2) + "元");
                        var container4 = $("#Div4");
                        HighChart.RenderChart(opt4, container4);
                        document.cookie = "data4=" + ToStr(json[4]) + ";path=/ManageBusiness";

                        var data5 = ToJsonPie(json[5])
                        var opt5 = HighChart.ChartOptionTemplates.Pie_Simple(data5, '', "<b>增值税</b> \n " + total.toFixed(2) + "元");
                        var container5 = $("#Div5");
                        HighChart.RenderChart(opt5, container5);
                        document.cookie = "data5=" + ToStr(json[5]) + ";path=/ManageBusiness";

                        var data6 = ToJsonPie(json[6])
                        var opt6 = HighChart.ChartOptionTemplates.Pie_Simple(data6, '', "<b>毛利</b> \n " + total.toFixed(2) + "元");
                        var container6 = $("#Div6");
                        HighChart.RenderChart(opt6, container6);
                        document.cookie = "data6=" + ToStr(json[6]) + ";path=/ManageBusiness";
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
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
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
                    <td style="width: 20px">
                    </td>
                    <td style="width: 100px" align="right">
                        项目名称：
                    </td>
                    <td style="width: 200px;" align="left">
                        <asp:DropDownList ID="ddlXMProjectNameId" runat="server" Width="100%" Enabled="true"
                            OnSelectedIndexChanged="ddlXMProjectNameId_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20px">
                    </td>
                    <td style="width: 100px" align="right">
                        店铺名称：
                    </td>
                    <td style="width: 200px;" align="left">
                        <asp:DropDownList ID="ddlNickList" runat="server" Width="100%" Enabled="true">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
            </table>
            <table cellpadding="2" cellspacing="2" style="width: 100%; height: 100%;" border="0px">
                <tr>
                    <td style="width: 6%;" align="center">
                        <font size='5'><b>本月关键数据指标</b></font>
                    </td>
                    <td style="border-top: 1px solid #999999; border-left: 1px solid #999999; border-right: 1px solid #999999;
                        border-bottom: 1px solid #999999; width: 16%;" align="center">
                        <div id="Div1" style="margin: 0 auto; height: 200px;" onclick="NewTab(1);" />
                    </td>
                    <td style="border-top: 1px solid #999999; border-left: 1px solid #999999; border-right: 1px solid #999999;
                        border-bottom: 1px solid #999999; width: 16%;" align="center">
                        <div id="Div2" style="margin: 0 auto; height: 200px;" onclick="NewTab(2);" />
                    </td>
                    <td style="border-top: 1px solid #999999; border-left: 1px solid #999999; border-right: 1px solid #999999;
                        border-bottom: 1px solid #999999; width: 16%;" align="center">
                        <div id="Div3" style="margin: 0 auto; height: 200px;" onclick="NewTab(3);" />
                    </td>
                    <td style="border-top: 1px solid #999999; border-left: 1px solid #999999; border-right: 1px solid #999999;
                        border-bottom: 1px solid #999999; width: 16%;" align="center">
                        <div id="Div4" style="margin: 0 auto; height: 200px;" onclick="NewTab(4);" />
                    </td>
                    <td style="border-top: 1px solid #999999; border-left: 1px solid #999999; border-right: 1px solid #999999;
                        border-bottom: 1px solid #999999; width: 16%;" align="center">
                        <div id="Div5" style="margin: 0 auto; height: 200px;" onclick="NewTab(5);" />
                    </td>
                    <td style="border-top: 1px solid #999999; border-left: 1px solid #999999; border-right: 1px solid #999999;
                        border-bottom: 1px solid #999999; width: 17%;" align="center">
                        <div id="Div6" style="margin: 0 auto; height: 200px;" onclick="NewTab(6);" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
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
                        <div id="container" style="margin: 0 auto; height: 500px; width: 1050px;" />
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
