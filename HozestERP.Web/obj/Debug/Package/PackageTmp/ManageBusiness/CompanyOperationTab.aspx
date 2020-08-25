<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="CompanyOperationTab.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.CompanyOperationTab" %>

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

        function ToJsonPie(Str) {
            var data = new Array();
            var list = new Array();
            list = Str.split(":");
            for (var i = 0; i < list.length; i++) {
                var item = new Array();
                item = list[i].split(",");
                if (item[0] != "") {
                    var obj = { name: '' + item[0] + '', value: parseFloat(item[1]) };
                    data.push(obj);
                    total = total + parseFloat(item[1]);
                }
            }
            return data;
        }

        function dataBind() {
            var Id = document.getElementById("HidId").value;
            var Str = "";
            var Dividend = "";
            var title = "";
            var strCookie = document.cookie;
            var arrCookie = strCookie.split("; ");
            for (var i = 0; i < arrCookie.length; i++) {
                var arr = arrCookie[i].split("=");
                if ("data" + Id == arr[0]) {
                    Str = arr[1];
                }
                if (Id == "1") {
                    if ("data2" == arr[0]) {
                        Dividend = arr[1];
                    }
                }
            }

            var data = ToJsonPie(Str);

            if (Id == "1") {
                title = "<b>总目标</b>" + total.toFixed(2) + "元";
                createTable(data, Dividend, Id);
            }
            else if (Id == "2") {
                title = "<b>总营业业绩</b>" + total.toFixed(2) + "元";
                createTable(data, Dividend, Id);
            }
            else if (Id == "3") {
                title = "总营业成本";
            }
            else if (Id == "4") {
                title = "营业费用";
            }
            else if (Id == "5") {
                title = "增值税";
            }
            else if (Id == "6") {
                title = "毛利";
            }

            if (Id != "1" && Id != "2") {
                title = "<b>" + title + "</b>" + total.toFixed(2) + "元";
            }
            var opt = HighChart.ChartOptionTemplates.Pie(data, '', title);
            var container = $("#Div");
            HighChart.RenderChart(opt, container);
        }

        function createTable(data, Dividend, Id) {
            var div = document.getElementById("DivTable");
            var table = document.createElement("table"); //创建table
            table.border = "1";

            if (Id == "1") {
                createRow(table, "项目（店铺）", "目标业绩", "当前业绩", "达成率");
                var data1 = ToJsonPie(Dividend);

                for (var i = 0; i < data.length; i++) {
                    var exist = false;
                    for (var j = 0; j < data1.length; j++) {
                        if (data[i].name == data1[j].name) {
                            exist = true;
                            var Percentage = "";
                            if (data[i].value != 0) {
                                Percentage = (data1[j].value * 100 / data[i].value).toFixed(2).toString() + "%";
                            }
                            else {
                                Percentage = "0 %";
                            }
                            createRow(table, data[i].name, data[i].value, data1[j].value, Percentage);
                        }
                    }
                    if(!exist)
                    {
                        createRow(table, data[i].name, data[i].value, 0, "0 %");
                    }
                }
            }
            else if (Id == "2") {
                createRow(table, "项目（店铺）", "本项目（店铺）业绩", "总业绩", "占比");

                for (var i = 0; i < data.length; i++) {
                    if (total != 0) {
                        Percentage = (data[i].value * 100 / total.toFixed(2)).toFixed(2).toString() + "%";
                    }
                    else {
                        Percentage = "0 %";
                    }
                    createRow(table, data[i].name, data[i].value, total.toFixed(2), Percentage);
                }
            }
            div.appendChild(table);
        }

        function createRow(table, value1, value2, value3, value4) {

            var width = document.getElementById("Div").offsetWidth; //获得宽度
            var wd = (parseInt(width) / 4).toString();
            var row = table.insertRow(); //创建一行 

            var cell = row.insertCell(); //创建一个单元
            cell.align = "center";
            cell.width = wd; //更改cell的各种属性 
            cell.style.backgroundColor = "#999999";
            cell.innerHTML = value1;
            var cell = row.insertCell(); //创建一个单元
            cell.align = "center";
            cell.width = wd; //更改cell的各种属性 
            cell.style.backgroundColor = "#999999";
            cell.innerHTML = value2;
            var cell = row.insertCell(); //创建一个单元
            cell.align = "center";
            cell.width = wd; //更改cell的各种属性 
            cell.style.backgroundColor = "#999999";
            cell.innerHTML = value3;
            var cell = row.insertCell(); //创建一个单元
            cell.align = "center";
            cell.width = wd; //更改cell的各种属性 
            cell.style.backgroundColor = "#999999";
            cell.innerHTML = value4;
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
            <input type="hidden" id="HidId" value='<%=Id %>' />
            <div id="Div" style="margin: 0 auto;" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <div id="DivTable">
    </div>
</asp:Content>
