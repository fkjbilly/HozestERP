<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="OperatingCost.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.OperatingCost" %>

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
            var PageType = document.getElementById("HidPageType").value;
            var CheckedValue = $('input:radio[type="radio"]:checked').val();
            jQuery(function ($) {
                $.ajax({ url: "operatingCost.ashx?action=operatingCost&DateType=" + DateType + "&PageType=" + PageType,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "ProjectID=" + CheckedValue,
                    success: function (json) {
                        var data = new Array();
                        for (var i = 0; i < json.length; i++) {
                            var obj = { name: '' + json[i].Name + '', group: '' + json[i].Group + '', value: json[i].Value };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Line(data, '', "", DateType, "", "");
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
                    <td>
                    </td>
                    <td align="center">
                        <font size='5'><b>
                            <asp:Label ID="lblTitle" runat="server"></asp:Label></b></font>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;" valign="top">
                        <table width="100%" style="height: 105">
                            <tr>
                                <td style="height: 35px" align="center">
                                    <input type="button" id="btnWeek" value="近一周" onclick="return dataBind('week');"
                                        style="width: 65px;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 35px" align="center">
                                    <input type="button" id="btnMonth" value="本月" onclick="return dataBind('month');"
                                        style="width: 65px;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 35px" align="center">
                                    <input type="button" id="btnYear" value="本年" onclick="return dataBind('year');" style="width: 65px;" />
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
                        <asp:RadioButtonList ID="rblProjectList" runat="server" RepeatDirection="Vertical"
                            CellPadding="7" CellSpacing="0" AutoPostBack="true" RepeatColumns="2" OnSelectedIndexChanged="rblProjectList_Changed">
                        </asp:RadioButtonList>
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
