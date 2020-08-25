<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="ProductSales.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.ProductSales" %>

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
            SelWarehouseBind('', '');
        });

        function SelProjectIdBind(projectId, nickId) {
            var ProjectId = document.getElementById("SelProjectId");
            jQuery(function ($) {
                $.ajax({ url: "productSales.ashx",
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

        function SelWarehouseBind(warehouseId, provinceName) {
            var Warehouse = document.getElementById("SelWarehouse");
            jQuery(function ($) {
                $.ajax({ url: "productSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=WarehouseBind",
                    success: function (json) {
                        list = json.split(";");
                        var no = 0;
                        for (var i = 0; i < list.length; i++) {
                            var item = new Array();
                            item = list[i].split(",");
                            if (item[0] != "") {
                                no++;
                                Warehouse.options.add(new Option(item[0], item[1]));
                                if (warehouseId != "" && warehouseId == item[1]) {
                                    Warehouse.options[no - 1].selected = true;
                                }
                            }
                        }
                        WarehouseChange(provinceName);
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
                $.ajax({ url: "productSales.ashx?ProjectId=" + ProjectId.value,
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

        function WarehouseChange(provinceName) {
            var Warehouse = document.getElementById("SelWarehouse");
            var ProvinceName = document.getElementById("SelProvinceName");
            ProvinceName.innerHTML = "";
            jQuery(function ($) {
                $.ajax({ url: "productSales.ashx?Warehouse=" + Warehouse.value,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=Province",
                    success: function (json) {
                        var no = 0;
                        list = json.split(";");
                        for (var i = list.length - 1; i >= 0; i--) {
                            var item = new Array();
                            item = list[i].split(",");
                            if (item[0] != "") {
                                no++;
                                ProvinceName.options.add(new Option(item[0], item[1]));
                                if (provinceName != "" && provinceName == item[1]) {
                                    ProvinceName.options[no - 1].selected = true;
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

        function dataBind(ProjectId, NickId, WarehouseId, ProvinceName) {
            //showdiv("<br/>查找中，请等待‥‥‥<br/>");
            var total = 0;
            jQuery(function ($) {
                $.ajax({ url: "productSales.ashx",
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "action=productSales",
                    success: function (json) {
                        var data = new Array();

                        for (var i = 0; i < json.length; i++) {
                            var count = Number(json[i].Value.toString());
                            total = total + count;
                            var obj = { name: '' + json[i].Name + '', value: count };
                            data.push(obj);
                        }
                        var opt = HighChart.ChartOptionTemplates.Pie_Count(data, '', "产品销量统计-总计" + total + "件");
                        var container = $("#Div");
                        HighChart.RenderChart(opt, container);
                        Closediv();
                        SelProjectIdBind(ProjectId, NickId);
                        SelWarehouseBind(WarehouseId, ProvinceName);
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
                    <td style="width: 80px">
                        开始时间：
                    </td>
                    <td style="width: 120px">
                        <input id="txtBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                            runat="server" style="width: 100%;" />
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        结束时间：
                    </td>
                    <td style="width: 120px">
                        <input id="txtEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server"
                            style="width: 100%;" />
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        项目名称：
                    </td>
                    <td style="width: 120px">
                        <select id="SelProjectId" onchange="ProjectIdChange('')" style="width: 100%;" name="SelProjectId">
                        </select>
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        店铺名称：
                    </td>
                    <td style="width: 120px">
                        <select id="SelNickList" style="width: 100%;" name="SelNickList">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px">
                        仓库:
                    </td>
                    <td style="width: 120px">
                        <select id="SelWarehouse" onchange="WarehouseChange('')" style="width: 100%;" name="SelWarehouse">
                        </select>
                    </td>
                    <td style="width: 40px">
                    </td>
                    <td style="width: 80px">
                        省/直辖市:
                    </td>
                    <td style="width: 40px">
                        <select id="SelProvinceName" style="width: 100%;" name="SelProvinceName">
                        </select>
                    </td>
                    <td colspan="6">
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" OnClientClick="return Showdiv('<br/>查找中，请等待‥‥‥<br/>');" />
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
                <HeaderStyle Wrap="False" Width="30px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品名称">
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
                <FooterTemplate>
                    <b>合计</b>
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
                                                                出厂价
                                                            </th>
                                                            <th style='width: 20%; text-align: center;'>
                                                                件数
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
                <asp:Button ID="btnExport" runat="server" Text="导出" Visible="<% $CRMIsActionAllowed:ManageBusiness.ProductSales.Export %>"
                    OnClick="btnExport_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
