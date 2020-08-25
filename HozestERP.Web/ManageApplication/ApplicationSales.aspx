<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="ApplicationSales.aspx.cs" Inherits="HozestERP.Web.ManageApplication.ApplicationSales" %>

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
    <script type="text/javascript">

        $(document).ready(function () {
            SelProjectIdBind('', '');
        });

        function SelProjectIdBind(projectId, nickId) {
            var ProjectId = document.getElementById("SelProjectId");
            jQuery(function ($) {
                $.ajax({ url: "../ManageBusiness/productSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=ProjectIdBind",
                    success: function (json) {
                        list = json.split(";");
                        var no = 0;
                        for (var i = 0; i < list.length; i++) {
                            var item = new Array();
                            item = list[i].split(",");
                            if (item[0] != "") {
                                no++;
                                ProjectId.options.add(new Option(item[0], item[1]));
                                if (projectId != "" && projectId == item[1]) {
                                    ProjectId.options[no - 1].selected = true;
                                }
                            }
                        }
                        ProjectIdChange(nickId);
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function ProjectIdChange(nickId) {
            var ProjectId = document.getElementById("SelProjectId");
            var NickList = document.getElementById("SelNickList");
            NickList.innerHTML = "";
            jQuery(function ($) {
                $.ajax({ url: "../ManageBusiness/productSales.ashx?ProjectId=" + ProjectId.value,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=NickList",
                    success: function (json) {
                        var no = 0;
                        list = json.split(";");
                        for (var i = list.length - 1; i >= 0; i--) {
                            var item = new Array();
                            item = list[i].split(",");
                            if (item[0] != "") {
                                no++;
                                NickList.options.add(new Option(item[0], item[1]));
                                if (nickId != "" && nickId == item[1]) {
                                    NickList.options[no - 1].selected = true;
                                }
                            }
                        }

                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function ShowHidde(sid, evt) {
            var b = "";
            //还原其他所有行
            $("tr[id^=div]").each(function () {
                var a = $(this).attr("id").replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = a; //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            });
            //如果点击同一个
            if (sid == b) {
                var a = b.replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = $(this).attr("id"); //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            } else {
                evt = evt || window.event;
                var target = evt.target || evt.srcElement;
                var objDiv = document.getElementById("div" + sid);
                if (window.ActiveXObject) {
                    objDiv.style.display = objDiv.style.display == "none" ? "block" : "none";
                }
                else {
                    objDiv.style.display = objDiv.style.display == "none" ? "table-row" : "none";
                }
                target.title = objDiv.style.display == "none" ? "Show" : "Hide";
                var imgid = 'img' + sid;
                document.getElementById(imgid).src = objDiv.style.display == "none" ? "../images/folder.gif" : "../images/folderopen.gif";
            }
        }

        function dataBind(ProjectId, NickId) {
            //showdiv("<br/>查找中，请等待‥‥‥<br/>");
            var total = 0;
            jQuery(function ($) {
                $.ajax({ url: "applicationSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=applicationSales",
                    success: function (json) {
                        var data = new Array();

                        for (var i = 0; i < json.length; i++) {
                            var count = Number(json[i].Value.toString());
                            total = total + count;
                            var obj = { name: '' + json[i].Name + '', value: count };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Pie_Count(data, '', "退换货退货统计-总计" + total + "件");
                        var container = $("#Div");
                        HighChart.RenderChart(opt, container);
                        Closediv();
                        SelProjectIdBind(ProjectId, NickId);
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                <tr>
                    <td style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        申请时间：
                    </td>
                    <td style="width: 120px">
                        <input id="txtBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                            runat="server" style="width: 100%;" />
                    </td>
                    <td style="width: 40px" align="center">
                        到
                    </td>
                    <td style="width: 120px">
                        <input id="txtEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server"
                            style="width: 100%;" />
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        申请类型：
                    </td>
                    <td style="width: 120px">
                        <asp:DropDownList ID="ddlApplicaType" Width="100%" runat="server">
                            <asp:ListItem Value="-1">--所有--</asp:ListItem>
                            <%--<asp:ListItem Value="9">售后</asp:ListItem>
                        <asp:ListItem Value="10">售中</asp:ListItem>
                        <asp:ListItem Value="4">未发货退款</asp:ListItem>--%>
                            <asp:ListItem Value="5">先退货后退款</asp:ListItem>
                            <%--<asp:ListItem Value="8">退运费</asp:ListItem>--%>
                            <asp:ListItem Value="6">换货</asp:ListItem>
                            <asp:ListItem Value="7">先退款后退货</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 20px">
                    </td>
                    <td style="width: 70px">
                        货物状态：
                    </td>
                    <td style="width: 80px">
                        <asp:CheckBox ID="chkGoodsNotConfirmSendOut" runat="server" Text="未确认发出" />
                    </td>
                    <td style="width: 80px">
                        <asp:CheckBox ID="chkGoodsConfirmSendOut" runat="server" Text="已发出" />
                    </td>
                    <td style="width: 80px">
                        <asp:CheckBox ID="chkGoodsConfirmReturn" runat="server" Text="已确认退回" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="12">
                        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                            <tr>
                                <td style="width: 100px">
                                    项目名称：
                                </td>
                                <td style="width: 150px">
                                    <select id="SelProjectId" onchange="ProjectIdChange('')" style="width: 100%;" name="SelProjectId">
                                    </select>
                                </td>
                                <td style="width: 40px">
                                </td>
                                <td style="width: 60px">
                                    店铺名称：
                                </td>
                                <td style="width: 150px">
                                    <select id="SelNickList" style="width: 100%;" name="SelNickList">
                                    </select>
                                </td>
                                <td style="text-align: right" style="width: 300px">
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" OnClientClick="return Showdiv('<br/>查找中，请等待‥‥‥<br/>');" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div id="Div" style="margin: 0 auto;" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvContent" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="javascript:void(0);">
                        <img id='img<%# Eval("ID")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("ID")%>',event)" /></a>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="50px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请类型">
                <ItemTemplate>
                    <%# Eval("ApplicaTypeName")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
                <FooterTemplate>
                    <b>合计</b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="货物状态">
                <ItemTemplate>
                    <%# Eval("GoodsStatusName")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品名称">
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
                <FooterTemplate>
                    <%--<b>合计</b>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="汇总">
                <ItemTemplate>
                    <%# Eval("Count")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
                <FooterTemplate>
                    <b>
                        <%=TotalCount%></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="成本">
                <ItemTemplate>
                    <%# Eval("Cost")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
                <FooterTemplate>
                    <b>
                        <%=TotalCost%></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="该产品件数占比">
                <ItemTemplate>
                    <%# Eval("CountProportion")%>
                    <!--下拉tr-->
                    <tr id='div<%#Eval("ID")%>' style="background-color: White; display: none; border: 0px;"
                        class="gridlist">
                        <td colspan="100%" style="width: 100%; height: 100%;">
                            <div style="background-color: White;">
                                <div style="position: relative; left: 0px; overflow: auto; width: 100%;">
                                    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
                                        <tbody>
                                            <tr>
                                                <td colspan="100%" valign="top">
                                                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                                                        <tr>
                                                            <th style='width: 20%; text-align: center;'>
                                                                厂家编码
                                                            </th>
                                                            <th style='width: 20%; text-align: center;'>
                                                                尺寸
                                                            </th>
                                                            <th style='width: 20%; text-align: center;'>
                                                                件数
                                                            </th>
                                                            <th style='width: 20%; text-align: center;'>
                                                                出厂价
                                                            </th>
                                                            <th style='width: 20%; text-align: center;'>
                                                                销售成本
                                                            </th>
                                                            <th style='width: 20%; text-align: center;'>
                                                                该尺寸件数占比
                                                            </th>
                                                        </tr>
                                                        <%# Eval("Table")%>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <div style="background-color: White; width: 100%; border: 0px;">
                                                    <td colspan="100%">
                                                    </td>
                                                </div>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <ItemStyle Width="200px"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                <FooterTemplate>
                    <b>
                        <%=TotalPercentage%></b>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <%--<asp:Button ID="btnExport" runat="server" Text="导出" Visible="<% $CRMIsActionAllowed:ManageBusiness.ProductSales.Export %>"
                    OnClick="btnExport_Click" />--%>
            </td>
        </tr>
    </table>
</asp:Content>
