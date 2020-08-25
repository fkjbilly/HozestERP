<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMApplicationAdd.aspx.cs" Inherits="HozestERP.Web.ManageApplication.XMApplicationAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">

        function autoCompleteBind() {
            var a = $("input#ctl00_ContentPlaceHolder1_PlatformTypeId").val();
            var s = 1;
            $('.ProductNum').focus(function () {
                var list = $(".ProductNum");
                var strCookie = document.cookie;
                //将多cookie切割为多个名/值对
                var arrCookie = strCookie.split("; ");

                var ID;
                //遍历cookie数组，处理每个cookie对
                for (var z = 0; z < arrCookie.length; z++) {
                    var arr = arrCookie[z].split("=");
                    //找到名称为userId的cookie，并返回它的值
                    if ("FocusID" == arr[0]) {
                        ID = arr[1];
                        break;
                    }
                }
                var Id = ID.replace("txtProductNum", "");
                var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                for (var a = 0; a < txtProductNum.length; a++) {
                    if (txtProductNum[a].id.indexOf(Id) != -1) {
                        s = txtProductNum[a].value;
                        break;
                    }
                }

            });
            $('.ProductNum').blur(function () {
                var list = $(".ProductNum");
                var strCookie = document.cookie;
                //将多cookie切割为多个名/值对
                var arrCookie = strCookie.split("; ");

                var ID;
                //遍历cookie数组，处理每个cookie对
                for (var z = 0; z < arrCookie.length; z++) {
                    var arr = arrCookie[z].split("=");
                    //找到名称为userId的cookie，并返回它的值
                    if ("FocusID" == arr[0]) {
                        ID = arr[1];
                        break;
                    }
                }

                var Id = ID.replace("txtProductNum", "");
                var lblFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']");

                var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                for (var a = 0; a < lblFactoryPrice.length; a++) {
                    if (lblFactoryPrice[a].id.indexOf(Id) != -1) {
                        lblFactoryPrice[a].value = lblFactoryPrice[a].value * txtProductNum[a].value / s;
                        break;
                    }
                }
                var lblTCostprice = $("#<%= grdvClients.ClientID%> :input[id*='lblTCostprice']");
                for (var a = 0; a < lblTCostprice.length; a++) {
                    if (lblTCostprice[a].id.indexOf(Id) != -1) {
                        lblTCostprice[a].value = lblTCostprice[a].value * txtProductNum[a].value / s;
                        break;
                    }
                }
                var txtSalesPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtSalesPrice']");
                for (var a = 0; a < txtSalesPrice.length; a++) {
                    if (txtSalesPrice[a].id.indexOf(Id) != -1) {
                        txtSalesPrice[a].value = txtSalesPrice[a].value * txtProductNum[a].value / s;
                        break;
                    }
                }
            });

            $(".ProductCode").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "../ManageProject/XMOrderInfoProductDetaisRead.ashx",
                        data: "q=" + encodeURI(request.term) + "&p=" + $("input#ctl00_ContentPlaceHolder1_PlatformTypeId").val(),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.ManufacturersCode + " 产品：" + item.ProductName + " 尺寸：" + item.Specifications + " 商品编码：" + item.ProductUnit,
                                    value: item.ManufacturersCode,
                                    order: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    var list = $(".ProductCode");
                    var strCookie = document.cookie;
                    //将多cookie切割为多个名/值对
                    var arrCookie = strCookie.split("; ");
                    var ID;
                    //遍历cookie数组，处理每个cookie对
                    for (var z = 0; z < arrCookie.length; z++) {
                        var arr = arrCookie[z].split("=");
                        //找到名称为userId的cookie，并返回它的值
                        if ("FocusID" == arr[0]) {
                            ID = arr[1];
                            break;
                        }
                    }
                    var Id = ID.replace("txtProductCode", "");
                    if (list != null && list.length > 0) {
                        var hfProductID = $("#<%= grdvClients.ClientID%> :hidden[id*='hfProductID']");
                        for (var a = 0; a < hfProductID.length; a++) {
                            if (hfProductID[a].id.indexOf(Id) != -1) {
                                hfProductID[a].value = i.item.order.Id;
                                break;
                            }
                        }
                        var lblProductName = $("#<%= grdvClients.ClientID%> :input[id*='lblProductName']");
                        for (var a = 0; a < lblProductName.length; a++) {
                            if (lblProductName[a].id.indexOf(Id) != -1) {
                                lblProductName[a].value = i.item.order.ProductName;
                                break;
                            }
                        }
                        var lblProductName2 = $("#<%= GridView6.ClientID%> :input[id*='lblProductName2']");
                        for (var a = 0; a < lblProductName2.length; a++) {
                            if (lblProductName2[a].id.indexOf(Id) != -1) {
                                lblProductName2[a].value = i.item.order.ProductName;
                                break;
                            }
                        }
                        var lblProductName3 = $("#<%= GridView1.ClientID%> :input[id*='lblProductName3']");
                        for (var a = 0; a < lblProductName3.length; a++) {
                            if (lblProductName3[a].id.indexOf(Id) != -1) {
                                lblProductName3[a].value = i.item.order.ProductName;
                                break;
                            }
                        }
                        var lblSpecifications = $("#<%= grdvClients.ClientID%> :input[id*='lblSpecifications']");
                        for (var a = 0; a < lblSpecifications.length; a++) {
                            if (lblSpecifications[a].id.indexOf(Id) != -1) {
                                lblSpecifications[a].value = i.item.order.Specifications;
                                break;
                            }
                        }
                        var lblSpecifications3 = $("#<%= GridView1.ClientID%> :input[id*='lblSpecifications3']");
                        for (var a = 0; a < lblSpecifications3.length; a++) {
                            if (lblSpecifications3[a].id.indexOf(Id) != -1) {
                                lblSpecifications3[a].value = i.item.order.Specifications;
                                break;
                            }
                        }
                        var lblSpecifications2 = $("#<%= GridView6.ClientID%> :input[id*='lblSpecifications2']");
                        for (var a = 0; a < lblSpecifications2.length; a++) {
                            if (lblSpecifications2[a].id.indexOf(Id) != -1) {
                                lblSpecifications2[a].value = i.item.order.Specifications;
                                break;
                            }
                        }
                        var lblManufacturers = $("#<%= grdvClients.ClientID%> :input[id*='lblManufacturers']");
                        for (var a = 0; a < lblManufacturers.length; a++) {
                            if (lblManufacturers[a].id.indexOf(Id) != -1) {
                                lblManufacturers[a].value = i.item.order.ProductUnit;
                                break;
                            }
                        }
                        var lblManufacturers3 = $("#<%= GridView1.ClientID%> :input[id*='lblManufacturers3']");
                        for (var a = 0; a < lblManufacturers3.length; a++) {
                            if (lblManufacturers3[a].id.indexOf(Id) != -1) {
                                lblManufacturers3[a].value = i.item.order.ProductUnit;
                                break;
                            }
                        }
                        var lblManufacturers2 = $("#<%= GridView6.ClientID%> :input[id*='lblManufacturers2']");
                        for (var a = 0; a < lblManufacturers2.length; a++) {
                            if (lblManufacturers2[a].id.indexOf(Id) != -1) {
                                lblManufacturers2[a].value = i.item.order.ProductUnit;
                                break;
                            }
                        }
                        var lblFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']");
                        var lblFactoryPrice3 = $("#<%= GridView1.ClientID%> :input[id*='lblFactoryPrice3']");
                        var lblFactoryPrice2 = $("#<%= GridView6.ClientID%> :input[id*='lblFactoryPrice2']");
                        var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                        for (var a = 0; a < lblFactoryPrice.length; a++) {
                            if (lblFactoryPrice[a].id.indexOf(Id) != -1) {
                                lblFactoryPrice[a].value = i.item.order.Costprice * txtProductNum[a].value;
                                break;
                            }
                        }
                        var txtProductNum3 = $("#<%= GridView1.ClientID%> :input[id*='txtProductNum3']");
                        for (var a = 0; a < lblFactoryPrice3.length; a++) {
                            if (lblFactoryPrice3[a].id.indexOf(Id) != -1) {
                                lblFactoryPrice3[a].value = i.item.order.Costprice * txtProductNum3[a].value;
                                break;
                            }
                        }
                        var txtProductNum2 = $("#<%= GridView6.ClientID%> :input[id*='txtProductNum2']");
                        for (var a = 0; a < lblFactoryPrice2.length; a++) {
                            if (lblFactoryPrice2[a].id.indexOf(Id) != -1) {
                                lblFactoryPrice2[a].value = i.item.order.Costprice * txtProductNum2[a].value;
                                break;
                            }
                        }

                        var lblTCostprice = $("#<%= grdvClients.ClientID%> :input[id*='lblTCostprice']");
                        for (var a = 0; a < lblTCostprice.length; a++) {
                            if (lblTCostprice[a].id.indexOf(Id) != -1) {
                                lblTCostprice[a].value = i.item.order.TCostprice * txtProductNum[a].value;
                                break;
                            }
                        }

                        var txtSalesPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtSalesPrice']");
                        for (var a = 0; a < txtSalesPrice.length; a++) {
                            if (txtSalesPrice[a].id.indexOf(Id) != -1) {
                                txtSalesPrice[a].value = i.item.order.Saleprice * txtProductNum[a].value;
                                break;
                            }
                        }
                        var txtSalesPrice3 = $("#<%= GridView1.ClientID%> :input[id*='txtSalesPrice3']");
                        for (var a = 0; a < txtSalesPrice3.length; a++) {
                            if (txtSalesPrice3[a].id.indexOf(Id) != -1) {
                                txtSalesPrice3[a].value = i.item.order.Saleprice * txtProductNum3[a].value;
                                break;
                            }
                        }
                        var txtSalesPrice2 = $("#<%= GridView6.ClientID%> :input[id*='txtSalesPrice2']");
                        for (var a = 0; a < txtSalesPrice2.length; a++) {
                            if (txtSalesPrice2[a].id.indexOf(Id) != -1) {
                                txtSalesPrice2[a].value = i.item.order.Saleprice * txtProductNum2[a].value;
                                break;
                            }
                        }
                        //$("#<%= grdvClients.ClientID%> :hidden[id*='hfProductID']").val(i.item.order.Id);
                        //$("#<%= grdvClients.ClientID%> :input[id*='lblProductName']").val(i.item.order.ProductName);
                        //$("#<%= grdvClients.ClientID%> :input[id*='lblSpecifications']").val(i.item.order.Specifications);
                        //                    $("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']").val(i.item.order.FactoryPrice);
                        //                    $("#<%= grdvClients.ClientID%> :input[id*='lblTCostprice']").val(i.item.order.TCostprice);
                        //                    $("#<%= grdvClients.ClientID%> :text[id*='txtNumber']").select();


                    }
                }
            });

            $(".ApplicaType2").change(function () {
                var b = $(".ApplicaType2").val();
                if (b == "4") {
                    $("#ss").hide();
                    $(".huanhuo").hide();
                    $("#dy").show();
                }
                else if (b == "5" || b == "7") {
                    $("#ss").hide();
                    $(".huanhuo").show();
                    $("#dy").hide();
                }
                else if (b == "6") {
                    $("#ss").show();
                    $(".huanhuo").show();
                    $("#dy").hide();
                }
            })

            $(function () {
                var b = $(".ApplicaType2").val();
                if (b == "4") {
                    $("#ss").hide();
                    $(".huanhuo").hide();
                    $("#dy").show();
                }
                else if (b == "5" || b == "7") {
                    $("#ss").hide();
                    $(".huanhuo").show();
                    $("#dy").hide();
                }
                else if (b == "6") {
                    $("#ss").show();
                    $(".huanhuo").show();
                    $("#dy").hide();
                }
            })

            $(".OrderCode").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "../ManageProject/XMScalpingApplicationReturnedHandler.ashx?action=QuestionOrderCode",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.OrderCode + ",平台：" + item.PlatformName + " ,店铺：" + item.NickName,
                                    value: item.OrderCode,
                                    orderInfo: item
                                }
                            }));
                        }
                    });
                }
            }
        , {
            select: function (e, i, j) {
                //$("#ctl00_ContentPlaceHolder1_PlatformTypeId").val(i.item.orderInfo.PlatformTypeId);
                //$("#ctl00_ContentPlaceHolder1_NickId").val(i.item.orderInfo.NickID);
                //$("#ctl00_ContentPlaceHolder1_PlatformType").val(i.item.orderInfo.PlatformName);
                //$("#ctl00_ContentPlaceHolder1_Nick").val(i.item.orderInfo.NickName);
                $("#<%= ddlPlatform.ClientID%>").val(i.item.orderInfo.PlatformTypeId);
                $("#ctl00_ContentPlaceHolder1_backPrice").html("已支付金额：" + i.item.orderInfo.PayPrice);//退款金额
                jQuery.ajax({
                        url: "../ManageFinance/ScalpingCodeHandler.ashx?action=selectNickByPlatform",
                        data: "platformID=" + i.item.orderInfo.PlatformTypeId,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            var items = "<option value='-1'>---所有---</option>";

                            $.each(data, function (i, item) {
                                items += "<option value=\"" + item.nick_id + "\">" + item.nick + "</option>";
                            });
                            $("#<%= ddlNick1.ClientID%>").html(items);
                            $("#<%= ddlNick1.ClientID%>").val(i.item.orderInfo.NickID);
                            $("#<%= txtHidden1.ClientID%>").val(i.item.orderInfo.NickID);
                        }
                    });
//                $("#ctl00_ContentPlaceHolder1_Amount").val(i.item.orderInfo.PayPrice);//退款金额
            }
        }
        );

            $(".ReservepriceOrder2").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "../ManageProject/XMScalpingApplicationReturnedHandler.ashx?action=QuestionOrderCode",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.OrderCode + ",平台：" + item.PlatformName + " ,店铺：" + item.NickName,
                                    value: item.OrderCode,
                                    orderInfo: item
                                }
                            }));
                        }
                    });
                }
            }
        , {
            select: function (e, i, j) {
            }
        }
        );
        }

        function NumberCheck(textID) {
            $(textID).focus(function () {
                if (textID.value.replace(/^[0-9]*$/, "") != "") {
                    $(this).val("");
                } else if (parseInt($(textID).val()) <= 0) {
                    $(this).val("");
                }
            }).blur(function () {
                if (textID.value.replace(/^[0-9]*$/, "") != "") {
                    $(this).val("");
                } else if (parseInt($(textID).val()) <= 0) {
                    $(this).val("");
                }
            });
        }

        function GetFocus(id) {
            document.cookie = "FocusID=" + id;
        }

        function RemoveRow(grid, store)
        {
            grid.getRowEditor().stopEditing();
                
            var s = grid.getSelectionModel().getSelections();
                
            for (var i = 0, r; r = s[i]; i++) {
                store.remove(r);
            }
        }

        function platformSelect(id)
        {
                     jQuery.ajax({
                        url: "../ManageFinance/ScalpingCodeHandler.ashx?action=selectNickByPlatform",
                        data: "platformID=" + id,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            var items = "<option value='-1'>---所有---</option>";

                            $.each(data, function (i, item) {
                                items += "<option value=\"" + item.nick_id + "\">" + item.nick + "</option>";
                            });
                            $("#<%= ddlNick1.ClientID%>").html(items);
                        }
                    });
        }

        function nickSelect(id)
        {
            $("#<%= txtHidden1.ClientID%>").val(id);
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <span class="detailTitle" style="float: left;">退换货申请</span>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    申请单号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV13" runat="server">
                        <asp:HiddenField ID="HiddenField7" runat="server" />
                    </div>
                    <div id="DIV14" runat="server">
                        <input runat="server" id="ApplicationNo" readonly class="TextBox ScalpingCode" style="text-align: left;
                            width: 95%" type="text" />
                        <input id="Hidden1" type="hidden" runat="server" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    申请类型<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV15" runat="server">
                        <asp:HiddenField ID="HiddenField8" runat="server" />
                    </div>
                    <div id="DIV16" runat="server">
                        <select id="ApplicaType2" runat="server" class="ApplicaType2">
                            <option value="4">未发货退款</option>
                            <option value="5">先退货后退款</option>
                            <option value="8">退运费</option>
                            <option value="6">换货</option>
                            <option value="7">先退款后退货</option>
                        </select>
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    申请时间<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="addtime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    退换货订单号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIVLableScalpingNo" runat="server">
                        <asp:HiddenField ID="hdScalpingId" runat="server" />
                    </div>
                    <div id="DIVScalpingNo" runat="server">
                        <input runat="server" onserverchange="submit1_Click" id="txtOrderCode" class="TextBox OrderCode"
                            style="text-align: left; width: 95%" type="text" />
                      <!--  <asp:Button runat="server" ID="search" Text="查询商品" SkinID="button4" OnClick="submit1_Click" /> -->
                        <input id="hfScalpingId" type="hidden" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOrderCode"
                            Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="订单号不能为空."
                            ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                            TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                            PopupPosition="TopRight" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    平台<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPlatform" Width="90%" runat="server" onchange="platformSelect(this.value);">
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    店铺<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <select id="ddlNick1" runat="server" style="width:90%" onchange="nickSelect(this.value)">
                    </select>
                    <asp:HiddenField ID="txtHidden1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    退款金额<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV4" runat="server">
                        <input runat="server" id="Amount"  class="TextBox ScalpingCode" style="text-align: left;
                            width: 95%" type="text" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    <label runat="server" id="backPrice">已支付金额：0</label>
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    &nbsp;</td>
                <td style="width: 140px" align="right">
                    退回仓库:</td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <ext:ComboBox runat="server" ID="DdlFactory" Editable="false" DisplayField="CodeName" ValueField="CodeID" EmptyText="请选择" SelectedIndex="0">
                        <Store>
                            <ext:Store runat="server" ID="FactoryStore">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="CodeID"></ext:RecordField>
                                            <ext:RecordField Name="CodeName"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    补价订单<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV19" runat="server">
                        <input runat="server" id="ReservepriceOrder2" class="TextBox ReservepriceOrder2"
                            style="width: 184px;" type="text" />
                        <%--                           <asp:TextBox ID="ReservepriceOrder" class="TextBox PriceOrder"  runat="server"> </asp:TextBox>--%>
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    完成时间<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                        <asp:Label ID="FinishTime" runat="server"></asp:Label>
                </td>
                <td style="width: 140px" align="right">
                    退货原因:</td>
                <td style="width: 218px; border-right: 1px soild red;">
                   <ext:ComboBox runat="server" ID="ddlReturnCategoryList" Editable="false" DisplayField="CodeName" ValueField="CodeID" EmptyText="请选择" SelectedIndex="0">
                        <Store>
                            <ext:Store runat="server" ID="StoreReturnCategory">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="CodeID"></ext:RecordField>
                                            <ext:RecordField Name="CodeName"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
            </tr>
        <!--    <tr class="huanhuo">
                <td style="width: 140px" align="right">
                    退货商品<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="5">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="Clients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
                        OnRowDataBound="grdCount_RowDataBound">
                        <%--OnRowDataBound="grdManage_RowDataBound"--%>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                        scope="col">
                                        &nbsp;
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>--%>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        厂家编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品名称
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        尺寸
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        数量
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        出厂价
                                    </th>
                                  <%--  <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        特供价
                                    </th>--%>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        销售价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        退换货数量
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th>--%>
                                    <%--<th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th> --%>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <%--        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> --%>
                            <%--             <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox> 
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="商品编码">
                                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--<%#Eval("PlatformMerchantCode")%>--%>
                                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                                         runat="server" id="lblManufacturers3" />
                                    <input id="hfProductID2" type="hidden" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="厂家编码">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" value='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoProductDetails).Manufacturers %>'
                                        id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)" style="text-align: left;
                                        width: 90%" type="text" />
                                    <input id="hfProductID" type="hidden" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品编码不能为空."
                                        ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                         runat="server" id="lblProductName3" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="尺寸">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                                         runat="server" id="lblSpecifications3" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server"  value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        id="txtProductNum3" class="TextBox ProductNum" style="width: 50px;" type="text"
                                        onfocus="GetFocus(this.id)" />
                                    <%--                <asp:TextBox runat="server" class="TextBox ProductNum"  ID="txtProductNum" Text='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>' Width="50px"></asp:TextBox>
                                    --%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox  runat="server" ID="lblFactoryPrice3" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--         <asp:TemplateField HeaderText="特供价"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="lblTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>' Width="50px"></asp:TextBox>
            </ItemTemplate> 
         </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="销售价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox  runat="server" ID="txtSalesPrice3" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退换货数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Ids" runat="server" Value='<%# Eval("ID")%>' />
                                    <asp:TextBox runat="server" ID="txtcount" Text='1' Width="50px"></asp:TextBox>
                                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoProductDetails).count %>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>' 
                                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存"
                                        CommandName="OrderProductUpdate" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate %>" />
                                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMOrderInfoDelete"
                                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.Delete %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="Clients2_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
                        OnRowDataBound="grdCount_RowDataBound">
                        <%--OnRowDataBound="grdManage_RowDataBound"--%>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                        scope="col">
                                        &nbsp;
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>--%>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        厂家编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品名称
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        尺寸
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        数量
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        出厂价
                                    </th>
                                  <%--  <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        特供价
                                    </th>--%>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        销售价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        退换货数量
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th>--%>
                                    <%--<th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th> --%>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <%--        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> --%>
                            <%--             <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox> 
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="商品编码">
                                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--<%#Eval("PlatformMerchantCode")%>--%>
                                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                                         runat="server" id="lblManufacturers2" />
                                    <input id="hfProductID2" type="hidden" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="厂家编码">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" value='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplicationExchange).Manufacturers %>'
                                        id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)" style="text-align: left;
                                        width: 90%" type="text" />
                                    <input id="hfProductID" type="hidden" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品编码不能为空."
                                        ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                         runat="server" id="lblProductName2" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="尺寸">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                                         runat="server" id="lblSpecifications2" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server"  value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        id="txtProductNum2" class="TextBox ProductNum" style="width: 50px;" type="text"
                                        onfocus="GetFocus(this.id)" />
                                    <%--                <asp:TextBox runat="server" class="TextBox ProductNum"  ID="txtProductNum" Text='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>' Width="50px"></asp:TextBox>
                                    --%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox  runat="server" ID="lblFactoryPrice2" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--         <asp:TemplateField HeaderText="特供价"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="lblTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>' Width="50px"></asp:TextBox>
            </ItemTemplate> 
         </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="销售价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox  runat="server" ID="txtSalesPrice2" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退换货数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Ids" runat="server" Value='<%# Eval("ID")%>' />
                                    <asp:TextBox runat="server" ID="txtcount" Text='1' Width="50px"></asp:TextBox>
                                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoProductDetails).count %>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>' 
                                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存"
                                        CommandName="OrderProductUpdate" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate %>" />
                                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMOrderInfoDelete"
                                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.Delete %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="Clientsb_RowCommand" OnRowDataBound="grdCount2_RowDataBound">
                        <%--OnRowDataBound="grdManage_RowDataBound"--%>
                        <EmptyDataTemplate>
                            <%--            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">

                  <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                            scope="col">
                            &nbsp;
                        </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        商品编码
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        厂家编码
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        商品名称
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        尺寸
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        数量
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        出厂价
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        特供价
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        销售价
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        退换货数量
                    </th>
                </tr>
            </table>--%>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="" ControlStyle-Height="0px">
                                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--<%#Eval("PlatformMerchantCode")%>--%>
                                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                                        readonly="readonly" runat="server" id="lblManufacturers" />
                                    <input id="hfProductID2" type="hidden" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="厂家编码">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" readonly value='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplicationExchange).Manufacturers %>'
                                        id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)" style="text-align: left;
                                        width: 90%" type="text" />
                                    <input id="hfProductID" type="hidden" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                        readonly="readonly" runat="server" id="lblProductName" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                                        readonly="readonly" runat="server" id="lblSpecifications" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" readonly value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        id="txtProductNum" class="TextBox ProductNum" style="width: 50px;" type="text"
                                        onfocus="GetFocus(this.id)" />
                                    <%--                <asp:TextBox runat="server" class="TextBox ProductNum"  ID="txtProductNum" Text='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>' Width="50px"></asp:TextBox>
                                    --%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox ReadOnly runat="server" ID="lblFactoryPrice" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--         <asp:TemplateField HeaderText="特供价"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="lblTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>' Width="50px"></asp:TextBox>
            </ItemTemplate> 
         </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox ReadOnly runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Ids" runat="server" Value='<%# Eval("ID")%>' />
                                    <asp:TextBox runat="server" ID="txtcount" Text='0' Width="50px"></asp:TextBox>
                                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoProductDetails).count %>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--                <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>' ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存"
                    CommandName="OrderProductUpdate" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate %>" />--%>
                                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMOrderInfoDelete"
                                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.Delete %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="Clients_RowCommand" OnRowDeleting="grdvClients_RowDeleting">
                        <%--OnRowDataBound="grdManage_RowDataBound"--%>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                        scope="col">
                                        &nbsp;
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>--%>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        厂家编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品名称
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        尺寸
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        数量
                    </th>--%>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        出厂价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        特供价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        销售价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        退换货数量
                                    </th>
                                    <%--                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th>--%>
                                    <%--<th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th> --%>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <%--             <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox> 
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="商品编码">
                                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--<%#Eval("PlatformMerchantCode")%>--%>
                                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                                        readonly="readonly" runat="server" id="lblManufacturers" />
                                    <input id="hfProductID2" type="hidden" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="厂家编码">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" value='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplicationExchange).Manufacturers %>'
                                        id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)" style="text-align: left;
                                        width: 90%" type="text" />
                                    <input id="hfProductID" type="hidden" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品编码不能为空."
                                        ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                        readonly="readonly" runat="server" id="lblProductName" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="尺寸">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                                        readonly="readonly" runat="server" id="lblSpecifications" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--         <asp:TemplateField HeaderText="数量"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <input runat="server" ReadOnly value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
 id="txtProductNum" class="TextBox ProductNum"  style=" width:50px;" type="text" onfocus="GetFocus(this.id)" />
        </ItemTemplate> 
         </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="出厂价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox ReadOnly runat="server" ID="lblFactoryPrice" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--         <asp:TemplateField HeaderText="特供价"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="lblTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>' Width="50px"></asp:TextBox>
            </ItemTemplate> 
         </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="销售价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox ReadOnly runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退换货数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Ids" runat="server" Value='<%# Eval("ID")%>' />
                                    <asp:TextBox runat="server" ReadOnly ID="txtcount" Text='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--                <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>' ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存"
                    CommandName="OrderProductUpdate" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate %>" />--%>
                                    <%--
                     <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="XMOrderInfoDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.Delete %>" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>  -->
       <!--     <tr class="huanhuo">
                <td style="width: 140px" align="right">
                    退商品零件<font color="red">*</font>:
                </td>
                <td colspan="5">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="Clients4_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
                        OnRowDataBound="grdCount4_RowDataBound">
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                        scope="col">
                                        &nbsp;
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        零件名称
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        数量
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        出厂价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        销售价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        退货零件数量
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        操作
                                    </th>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="零件名称">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" id="lblProductName" value='<%# Eval("ProductName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        id="txtProductNum" class="TextBox ProductNum" style="width: 50px;" type="text"
                                        onfocus="GetFocus(this.id)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="lblFactoryPrice" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="销售价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退货零件数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Ids" runat="server" Value='<%# Eval("ID")%>' />
                                    <asp:TextBox runat="server" ID="txtcount" Text='1' Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>'
                                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" CommandName="OrderProductUpdate"
                                        CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>" />
                                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMOrderInfoDelete"
                                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="Clients_RowCommand" OnRowDeleting="grdvClients_RowDeleting">
                        <%--OnRowDataBound="grdManage_RowDataBound"--%>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                        scope="col">
                                        &nbsp;
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        零件名称
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        出厂价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        销售价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        退换货数量
                                    </th>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="零件名称">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                        readonly="readonly" runat="server" id="lblProductName" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox ReadOnly runat="server" ID="lblFactoryPrice" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="销售价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox ReadOnly runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退换货数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="Ids" runat="server" Value='<%# Eval("ID")%>' />
                                    <asp:TextBox runat="server" ReadOnly ID="txtcount" Text='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr> -->
           <!-- <tr id="ss" style="display: none;">
                <td style="width: 140px" align="right">
                    换货商品<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="5">
                    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
                        OnRowDataBound="grdvClients_RowDataBound">
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                        scope="col">
                                        &nbsp;
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        厂家编码
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        商品名称
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        尺寸
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        数量
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        出厂价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                        scope="col">
                                        特供价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        销售价
                                    </th>
                                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                        操作
                                    </th>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <%--        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> --%>
                            <%--             <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox> 
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="商品编码">
                                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%--<%#Eval("PlatformMerchantCode")%>--%>
                                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                                        readonly="readonly" runat="server" id="lblManufacturers" />
                                    <input id="hfProductID2" type="hidden" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="厂家编码">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" value='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplicationExchange).Manufacturers %>'
                                        id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)" style="text-align: left;
                                        width: 90%" type="text" />
                                    <input id="hfProductID" type="hidden" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品编码不能为空."
                                        ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                        readonly="readonly" runat="server" id="lblProductName" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="尺寸">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                                        readonly="readonly" runat="server" id="lblSpecifications" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="数量">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input runat="server" value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>'
                                        id="txtProductNum" class="TextBox ProductNum" style="width: 50px;" type="text"
                                        onfocus="GetFocus(this.id)" />
                                    <%--                <asp:TextBox runat="server" class="TextBox ProductNum"  ID="txtProductNum" Text='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>' Width="50px"></asp:TextBox>
                                    --%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="lblFactoryPrice" Text='<%# Eval("FactoryPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--         <asp:TemplateField HeaderText="特供价"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="lblTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>' Width="50px"></asp:TextBox>
            </ItemTemplate> 
         </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="销售价">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>'
                                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" CommandName="OrderProductUpdate"
                                        CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>" />
                                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMOrderInfoDelete"
                                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录！');" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>" />
                                    <asp:ImageButton ID="imgBtnSpareAddress" runat="server" CommandArgument='<%# Eval("Id") %>'
                                        ImageUrl="~/App_Themes/Blue/Image/Minutes.png" ToolTip="备用地址" CommandName="SpareAddress"
                                        CausesValidation="False" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr> -->
            <tr>
                <td id="dy" colspan="6">
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    推送千胜系统<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV3" runat="server">
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                    <div id="DIV5" runat="server">
                        <CRM:ImageCheckBox ID="IsSend" runat="server" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    主管审核状态<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV21" runat="server">
                        <asp:HiddenField ID="HiddenField11" runat="server" />
                    </div>
                    <div id="DIV22" runat="server">
                        <CRM:ImageCheckBox ID="SupervisorStatus" runat="server" />
                    </div>
                </td>
                <td colspan="2">
                </td>
                <%--<td style="width: 140px" align="right">
                    财务审核状态<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV23" runat="server">
                        <asp:HiddenField ID="HiddenField12" runat="server" />
                    </div>
                    <div id="DIV24" runat="server">
                        <CRM:ImageCheckBox ID="FinancialStatus" runat="server" />
                    </div>
                </td>--%>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备注<font color="red">*</font>:
                </td>
                <td colspan="5" style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV9" runat="server">
                        <asp:HiddenField ID="HiddenField5" runat="server" />
                    </div>
                    <div id="DIV10" runat="server">
                        <asp:TextBox ID="LeaderComments" runat="server" TextMode="MultiLine" Height="50"
                            Width="700"> </asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    退回物流单号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtReturnLogisticsNumber" runat="server" Width="100%"/>
                </td>
                <td style="width: 140px" align="right">
                    运费<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtLogisticsFee" runat="server" Width="100%"/>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <ext:TabPanel runat="server" Height="260" Width="950" ActiveIndex="0" ID="TabPanel">
                        <Items>
                            <ext:Panel runat="server" Title="退货商品">
                                <Items>
                                    <ext:GridPanel ID="GridPanel1" runat="server" Height="235" Frame="true" BodyCssClass="x-selectable" AutoScroll="true">
                                        <Store>
                                            <ext:Store ID="store1" runat="server">
                                                <Reader>
                                                    <ext:JsonReader>
                                                        <Fields>
                                                            <ext:RecordField Name="PlatformMerchantCode" Type="Auto" />
                                                            <ext:RecordField Name="Manufacturers" Type="Auto" />
                                                            <ext:RecordField Name="ProductName" Type="Auto" />
                                                            <ext:RecordField Name="Specifications" Type="Auto" />
                                                            <ext:RecordField Name="ProductNum" Type="Int" />
                                                            <ext:RecordField Name="FactoryPrice" Type="Auto" />
                                                            <ext:RecordField Name="SalesPrice" Type="Auto" />
                                                            <ext:RecordField Name="countNum" Type="Int" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Plugins>
                                            <ext:RowEditor runat="server" ClicksToEdit="2" SaveText="保存" CancelText="取消"></ext:RowEditor>
                                        </Plugins>
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:Button runat="server" Text="添加商品" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{window1}.show();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="移除商品" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="RemoveRow(#{GridPanel1},#{store1})" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" ID="btnOrderSearch" Text="查询商品" Icon="Seasons" ToolTip="查询订单商品信息">
                                                        <DirectEvents>
                                                            <Click OnEvent="btnOrderSearch_Click">
                                                                <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                                            </Click>
                                                        </DirectEvents>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>
                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server"></ext:RowSelectionModel>
                                        </SelectionModel>
                                        <ColumnModel>
                                            <Columns>
                                                <ext:Column DataIndex="PlatformMerchantCode" Header="商品编码" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:Column DataIndex="Manufacturers" Header="厂家编码" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:Column DataIndex="ProductName" Header="商品名称" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:Column DataIndex="Specifications" Header="尺寸" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:NumberColumn DataIndex="ProductNum" Header="数量" Width="50" Align="Center">
<%--                                                    <Editor>
                                                        <ext:NumberField runat="server" AllowBlank="false" />
                                                    </Editor>--%>
                                                </ext:NumberColumn>
                                                <ext:NumberColumn DataIndex="FactoryPrice" Header="出厂价" Format="0,0.00" Width="80" Align="Center">
                                                </ext:NumberColumn>
                                                <ext:NumberColumn DataIndex="SalesPrice" Header="销售价" Format="0,0.00" Width="80" Align="Center">
                                                </ext:NumberColumn>
                                                <ext:NumberColumn DataIndex="countNum" Header="退货数量" Width="80" Align="Center">
                                                    <Editor>
                                                        <ext:NumberField runat="server" AllowBlank="false"/>
                                                    </Editor>
                                                </ext:NumberColumn>
                                            </Columns>
                                        </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel runat="server" Title="换货商品">
                                <Items>
                                    <ext:GridPanel ID="GridPanel2" runat="server" Height="235" Frame="true" BodyCssClass="x-selectable" AutoScroll="true">
                                        <Store>
                                            <ext:Store ID="store2" runat="server">
                                                <Reader>
                                                    <ext:JsonReader>
                                                        <Fields>
                                                            <ext:RecordField Name="PlatformMerchantCode" Type="Auto" />
                                                            <ext:RecordField Name="Manufacturers" Type="Auto" />
                                                            <ext:RecordField Name="ProductName" Type="Auto" />
                                                            <ext:RecordField Name="Specifications" Type="Auto" />
                                                            <ext:RecordField Name="ProductNum" Type="Int" />
                                                            <ext:RecordField Name="FactoryPrice" Type="Auto" />
                                                            <ext:RecordField Name="SalesPrice" Type="Auto" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Plugins>
                                            <ext:RowEditor runat="server" ClicksToEdit="2" SaveText="保存" CancelText="取消"></ext:RowEditor>
                                        </Plugins>
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:Button runat="server" Text="添加商品" Icon="Add">
                                                       <DirectEvents>
                                                            <Click OnEvent="addProduct_Click">

                                                            </Click>
                                                        </DirectEvents>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="移除商品" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="RemoveRow(#{GridPanel2},#{store2})" />
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>
                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server"></ext:RowSelectionModel>
                                        </SelectionModel>
                                        <ColumnModel>
                                            <Columns>
                                                <ext:Column DataIndex="PlatformMerchantCode" Header="商品编码" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:Column DataIndex="Manufacturers" Header="厂家编码" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:Column DataIndex="ProductName" Header="商品名称" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:Column DataIndex="Specifications" Header="尺寸" Width="90" Align="Center">
                                                </ext:Column>
                                                <ext:NumberColumn DataIndex="ProductNum" Header="换货数量" Width="90" Align="Center">
                                                    <Editor>
                                                        <ext:NumberField runat="server" AllowBlank="false"/>
                                                    </Editor>
                                                </ext:NumberColumn>
                                                <ext:NumberColumn DataIndex="FactoryPrice" Header="出厂价" Format="0,0.00" Width="80" Align="Center">
                                                </ext:NumberColumn>
                                                <ext:NumberColumn DataIndex="SalesPrice" Header="销售价" Format="0,0.00" Width="80" Align="Center">
                                                </ext:NumberColumn>
                                            </Columns>
                                        </ColumnModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel runat="server" Title="备用地址">
                                <Items>
                                    <ext:Panel runat="server" Title="收货人信息" Frame="true" Padding="5" Height="235" ButtonAlign="Left">
                                        <Items>
                                            <ext:Container runat="server" Layout="ColumnLayout" Height="45">
                                                <Items>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".33">
                                                        <Items>
                                                            <ext:TextField runat="server" ID="txtFullName" FieldLabel="姓名" AnchorHorizontal="95%" />
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".33">
                                                        <Items>
                                                            <ext:TextField runat="server" ID="txtTel" FieldLabel="电话" AnchorHorizontal="95%" />
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".33">
                                                        <Items>
                                                            <ext:TextField runat="server" ID="txtMobile" FieldLabel="手机" AnchorHorizontal="95%" />
                                                        </Items>
                                                    </ext:Container>
                                                </Items>
                                            </ext:Container>
                                            <ext:Container runat="server" Layout="ColumnLayout" Height="45">
                                                <Items>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".33">
                                                        <Items>
                                                            <ext:ComboBox runat="server" ID="province" Editable="false" FieldLabel="省" AnchorHorizontal="95%" DisplayField="City" ValueField="City" EmptyText="选择省份">
                                                                <Store>
                                                                    <ext:Store runat="server" ID="provinceStore">
                                                                        <Reader>
                                                                            <ext:JsonReader>
                                                                                <Fields>
                                                                                    <ext:RecordField Name="City"></ext:RecordField>
                                                                                </Fields>
                                                                            </ext:JsonReader>
                                                                        </Reader>
                                                                    </ext:Store>
                                                                </Store>
                                                                <DirectEvents>
                                                                    <Select OnEvent="province_Select">

                                                                    </Select>
                                                                </DirectEvents>
                                                            </ext:ComboBox>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".33">
                                                        <Items>
                                                             <ext:ComboBox runat="server" ID="city" Editable="false" FieldLabel="市" AnchorHorizontal="95%" DisplayField="City" ValueField="City" EmptyText="选择城市">
                                                                <Store>
                                                                    <ext:Store runat="server" ID="cityStore">
                                                                        <Reader>
                                                                            <ext:JsonReader>
                                                                                <Fields>
                                                                                    <ext:RecordField Name="City"></ext:RecordField>
                                                                                </Fields>
                                                                            </ext:JsonReader>
                                                                        </Reader>
                                                                    </ext:Store>
                                                                </Store>
                                                                 <DirectEvents>
                                                                     <Select OnEvent="city_Select">

                                                                     </Select>
                                                                 </DirectEvents>
                                                            </ext:ComboBox>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".33">
                                                        <Items>
                                                             <ext:ComboBox runat="server" ID="region" Editable="false" FieldLabel="区" AnchorHorizontal="95%" DisplayField="City" ValueField="City" EmptyText="选择区">
                                                                <Store>
                                                                    <ext:Store runat="server" ID="regionStore">
                                                                        <Reader>
                                                                            <ext:JsonReader>
                                                                                <Fields>
                                                                                    <ext:RecordField Name="City"></ext:RecordField>
                                                                                </Fields>
                                                                            </ext:JsonReader>
                                                                        </Reader>
                                                                    </ext:Store>
                                                                </Store>
                                                            </ext:ComboBox>
                                                        </Items>
                                                    </ext:Container>
                                                </Items>
                                            </ext:Container>
                                            <ext:Container runat="server" Layout="ColumnLayout" Height="90">
                                                <Items>
                                                    <ext:Container runat="server" LabelAlign="Top" Layout="FormLayout" ColumnWidth=".99">
                                                        <Items>
                                                            <ext:TextArea runat="server" ID="txtAddress" FieldLabel="地址" AnchorHorizontal="98%" AutoScroll="true"></ext:TextArea>
                                                        </Items>
                                                    </ext:Container>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
                    <ext:Window ID="window1" runat="server" Width="800" Height="605" Hidden="true" AutoScroll="true">
                        <Items>
                            <ext:Panel ID="panel1" runat="server" Region="North" Title="查询" Height="70" Padding="5" Frame="true" Layout="ColumnLayout" Icon="Information">
                                <Items>
                                    <ext:TextField ID="txtProductName" runat="server" FieldLabel="商品名称" MaxLength="20"  ColumnWidth="0.3" />
                                    <ext:TextField ID="txtPlatformMerchantCode" runat="server" FieldLabel="商品编码" MaxLength="20"  ColumnWidth="0.3"/>
                                    <ext:TextField ID="txtManufacturersCode" runat="server" FieldLabel="厂家编码" MaxLength="20"  ColumnWidth="0.3" />
                                    <ext:Button ID="btnProductSearch" runat="server" Text="查询" ColumnWidth="0.1">
                                        <Listeners>
                                            <Click Handler="#{storeProduct}.reload()" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Panel>
                            <ext:GridPanel ID="gridPanelProduct" runat="server" AutoWidth="true" AutoHeight="true">
                                <Store>
                                    <ext:Store ID="storeProduct" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Method="POST" Url="ProductChoseList.ashx" />
                                        </Proxy>
                                        <BaseParams>
                                            <ext:Parameter Name="productName" Value="#{txtProductName}.getValue()" Mode="Raw"></ext:Parameter>
                                            <ext:Parameter Name="platformMerchantCode" Value="#{txtPlatformMerchantCode}.getValue()" Mode="Raw"></ext:Parameter>
                                            <ext:Parameter Name="manufacturersCode" Value="#{txtManufacturersCode}.getValue()" Mode="Raw"></ext:Parameter>
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID" Root="data" TotalProperty="total">
                                                <Fields>
                                                    <ext:RecordField Name="ID" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="PlatformMerchantCode" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="ManufacturersCode" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="ProductName" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="Specifications" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="Costprice" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="Saleprice" Type="Auto"></ext:RecordField>
                                                    <ext:RecordField Name="PlatformTypeName" Type="Auto"></ext:RecordField>
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn />
                                        <ext:Column DataIndex="PlatformTypeName" Header="平台类型" Width="90" />
                                        <ext:Column DataIndex="PlatformMerchantCode" Header="商品编码" Width="100" />
                                        <ext:Column DataIndex="ManufacturersCode" Header="厂家编码" Width="90" />
                                        <ext:Column DataIndex="ProductName" Header="商品名称" Width="90" />
                                        <ext:Column DataIndex="Specifications" Header="尺寸" Width="90" />
                                        <ext:Column DataIndex="Costprice" Header="出厂价" Width="90" />
                                        <ext:Column DataIndex="Saleprice" Header="销售价" Width="90" />
                                    </Columns>
                                </ColumnModel>
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" ID="btnAdd" Text="添加" Icon="Add">
                                                <DirectEvents>
                                                    <Click OnEvent="btnAdd_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="data" Value="Ext.encode(#{gridPanelProduct}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                                                        </ExtraParams>
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <SelectionModel>
                                    <ext:CheckboxSelectionModel runat="server" ID="cbsm"></ext:CheckboxSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="记录数:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="60" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="80" />
                                                    <ext:ListItem Text="90" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                       </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Window>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <ext:Panel runat="server" Layout="HBoxLayout">
        <Defaults>
            <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
        </Defaults>
        <LayoutConfig>
            <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
        </LayoutConfig>
        <Items>
                            <ext:Button ID="btSave" runat="server" Text="保存" Width="75" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>">
                    <DirectEvents>
                        <Click OnEvent="btSave_Click">
                            <ExtraParams>
                                <ext:Parameter Name="data1" Value="Ext.encode(#{GridPanel1}.getRowsValues())" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="data2" Value="Ext.encode(#{GridPanel2}.getRowsValues())" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>     
                <ext:Button ID="btnFinish" runat="server" Text="完成" Width="75" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Fin %>">
                    <DirectEvents>
                        <Click OnEvent="btnSaveSwan_Click">
                            <Confirmation ConfirmRequest="true" Title="提示" Message="确认完成？"/>
                        </Click>
                    </DirectEvents>
                </ext:Button> 
<%--                <ext:Button ID="btnReturnLogistics" runat="server" Text="修改退回单号" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.UpdateReturnLogisticsNumber %>">
                    <DirectEvents>
                        <Click OnEvent="btnReturnLogisticsNumber_Click">

                        </Click>
                    </DirectEvents>
                </ext:Button>--%>
        </Items>
    </ext:Panel>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td style="float:left">
      <!--          <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>" />
                <asp:Button ID="Button3" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave2_Click" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Update %>" /> -->

                <%--<asp:Button ID="Button1" runat="server" Text="送出" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSaveSchu_Click" Visible="false" /> --%>
                <%--<asp:Button ID="Button2" runat="server" Text="完成" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSaveSwan_Click" Visible="<% $CRMIsActionAllowed:XMApplicationAdd.Fin %>" />--%>
                <%--<asp:Button ID="btnReturnLogisticsNumber" runat="server" SkinID="button6" Text="修改退回单号"
                    ValidationGroup="ModuleValidationGroup" OnClick="btnReturnLogisticsNumber_Click"
                    Visible="<% $CRMIsActionAllowed:XMApplicationAdd.UpdateReturnLogisticsNumber %>" />--%>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            autoCompleteBind();
        });
    </script>
</asp:Content>
