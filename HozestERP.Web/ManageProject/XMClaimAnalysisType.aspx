<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMClaimAnalysisType.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMClaimAnalysisType"
    EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .table
        {
            border-collapse: collapse;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
            color: #9BC2DB;
            text-align: center;
        }
        .table tr th
        {
            border: solid 1px #9BC2DB;
            background: #9BC2DB;
            color: #FFF;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
        }
        .table tr th.th_border
        {
            border-right: solid 1px #9BC2DB;
            border-left: solid 1px #9BC2DB;
        }
        .table tr td
        {
            color: Black;
            border: solid 1px #9BC2DB;
        }
    </style>
    <script type="text/javascript">

        $(function () {
            BindCreateID();
        })

        function BindCreateID() {
            var begin = document.getElementById("<%=txtBeginDate.ClientID %>").value;
            var end = document.getElementById("<%=txtEndDate.ClientID %>").value;
            jQuery.ajax({
                url: "XMClaim.ashx?action=BindCreateID",
                contentType: "application/json; charset=utf-8",
                data: "Begin=" + begin + "&End=" + end,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                    var CreateID = document.getElementById("<%=ddlCreateID.ClientID %>");
                    CreateID.options.length = 0;
                    CreateID.options.add(new Option("---所有---", "-1"));
                    for (var i = 0; i < data.length; i++) {
                        CreateID.options.add(new Option(data[i].CreateName, data[i].CreateID)); //这个兼容IE与firefox
                    }
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            })

            jQuery.ajax({
                url: "XMClaim.ashx?action=BindResponsiblePerson",
                contentType: "application/json; charset=utf-8",
                data: "Begin=" + begin + "&End=" + end,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                    var ResponsiblePerson = document.getElementById("<%=ddlResponsiblePerson.ClientID %>");
                    ResponsiblePerson.options.length = 0;
                    ResponsiblePerson.options.add(new Option("---所有---", "-1"));
                    for (var i = 0; i < data.length; i++) {
                        ResponsiblePerson.options.add(new Option(data[i].ResponsiblePerson, data[i].ResponsiblePerson)); //这个兼容IE与firefox
                    }
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            })
        }

        function RecordResponsiblePersonValue() {
            var ResponsiblePerson = document.getElementById("<%=ddlResponsiblePerson.ClientID %>").value;
            jQuery.ajax({
                url: "XMClaim.ashx?action=RecordResponsiblePersonValue",
                contentType: "application/json; charset=utf-8",
                data: "ResponsiblePerson=" + ResponsiblePerson,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            })
        }

        function RecordCreateIDValue() {
            var CreateID = document.getElementById("<%=ddlCreateID.ClientID %>").value;
            jQuery.ajax({
                url: "XMClaim.ashx?action=RecordCreateIDValue",
                contentType: "application/json; charset=utf-8",
                data: "CreateID=" + CreateID,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            })
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 50px">
                客户姓名
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 50px">
                订单号
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtOrderCode" runat="server"></asp:TextBox>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                理赔单号
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtClaimRef" runat="server"></asp:TextBox>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                创单时间
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    onchange="BindCreateID()" runat="server" style="width: 100%;" />
            </td>
            <td style="width: 10px">
                &nbsp;&nbsp;至&nbsp;&nbsp;
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    onchange="BindCreateID()" runat="server" style="width: 100%;" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                是否退回
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                项目
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                店铺
            </td>
            <td style="width: 130px">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                责任人
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <select id="ddlResponsiblePerson" runat="server" onchange="RecordResponsiblePersonValue()" style="width:139px;">
                </select>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                创建人
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <select id="ddlCreateID" runat="server" name="ddlCreateID" onchange="RecordCreateIDValue()" style="width:139px;">
                </select>
            </td>
            <td style="text-align: right" colspan="5">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <%=TableStr %>
</asp:Content>
