<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="PurchaseAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.PurchaseAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(function () {
            var tr = $(".detailTable").find("tr");
            if ($(".detailTable :checkbox").prop("checked")) {
                document.getElementById("<%=hiddAutoID.ClientID %>").value = true;
                $(tr[0]).find("td[id=autoNumber]").find("#<%=txtPurchaseNumber.ClientID%>").attr("readonly", true);
            }
            else {
                document.getElementById("<%=hiddAutoID.ClientID %>").value = false;
                $(tr[0]).find("td[id=autoNumber]").find("#<%=txtPurchaseNumber.ClientID%>").attr("readonly", false);
            }

            $(".detailTable :checkbox").click(function () {
                var is = $(this).prop("checked");
                if (is == true) {
                    document.getElementById("<%=hiddAutoID.ClientID %>").value = true;
                    $(tr[0]).find("td[id=autoNumber]").find("#<%=txtPurchaseNumber.ClientID%>").attr("readonly", true);
                }
                else {
                    document.getElementById("<%=hiddAutoID.ClientID %>").value = false;
                    $(tr[0]).find("td[id=autoNumber]").find("#<%=txtPurchaseNumber.ClientID%>").attr("readonly", false);
                }
            });
        });

        function autoCompleteBind(platformId) {
            $(".ProductName").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "ProductList.ashx?action=ProductName&&pid=" + platformId,
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.ProductName + ", 编码:" + item.ManufacturersCode + ", 尺寸:" + item.Specifications + ", 成本价:" + item.Costprice,
                                    value: item.ProductName,
                                    order: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    var list = $(".ProductName");
                    if (list != null && list.length > 0) {

                        var productcode = $(this).parent().prev().find("input[id=txtProductCode]");      //获取商品名称控件
                        productcode.val(i.item.order.ManufacturersCode);                                       //赋值
                        productcode.prev().val(i.item.order.ProductId);
                        var Specifications = productcode.parent().next().next().next().find("input[id=lblSpecifications]");     //
                        Specifications.val(i.item.order.Specifications);
                        var unit = Specifications.parent().next().next().find("input[id=txtUnit]");
                        unit.val(i.item.order.ProductUnit);
                        var price = $(unit).parent().next().find("input[id=txtProductPrice]");
                        price.val(i.item.order.Costprice);
                    }
                }
            });
        }
    </script>
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
        .table tr td
        {
            border: solid 1px #9BC2DB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfJsonContent" runat="server" />
    <asp:HiddenField ID="hdfPlatFormTypeIDs" runat="server" />
    <asp:HiddenField ID="hiddType" runat="server" />
    <asp:HiddenField ID="hiddAutoID" runat="server" />
    <asp:Label ID="lblTitle" runat="server">    <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    采购单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;" id="autoNumber">
                    <asp:Label ID="lblNumber" runat="server"></asp:Label>
                    <asp:TextBox ID="txtPurchaseNumber" runat="server" Width="60%"></asp:TextBox>
                    <input name="autoID" type="checkbox" value="" id="chkAutoID" runat="server" clientidmode="Static" />
                    <asp:Literal ID="lbl1" runat="server" Text="自动生成"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                    交货日期:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <input id="txtDeliveryDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 80%;" />
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    供应商:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlSuppliers" runat="server" Width="80%" onchange="JavaScript:selectDpList(this)">
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    联系人:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" id="Contacter">
                    <asp:TextBox ID="txtContacter" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    联系电话:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" id="Tel">
                    <asp:TextBox ID="txtTel" runat="server" Width="80%"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    传真:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" id="Fax">
                    <asp:TextBox ID="txtFax" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    采购时间:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <input id="txtPurchaseDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 80%;" />
                </td>
                <td style="width: 140px" align="right">
                    付款方式:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPayType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    买家会员名:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtBuyerName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    收件人:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtResiveName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    收件人手机:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtRecivesMobile" runat="server"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    发出工厂:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtSendFactory" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    运费:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtLogisticsFee" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    交货地址:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtDeliveryAddresss" runat="server" Width="92.5%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    卖家备注:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="TextBox1" runat="server" Text="" Width="92.5%" TextMode="MultiLine"
                        Height="60px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备注<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtNote" runat="server" Text="" Width="92.5%" TextMode="MultiLine"
                        Height="60px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <%=TableStr %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnPurchaseSingleIsAudit" SkinID="button4" runat="server" Text="部门审核"
                    OnClick="btnPurchaseSingleIsAudit_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.IsAudit %>"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnPurchaseSingleIsAuditFalse" SkinID="button4" runat="server" Text="部门反审核"
                    OnClick="btnPurchaseSingleIsAuditFalse_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.IsAuditFalse %>"
                    OnClientClick="on_buttonClientClick();" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function selectDpList(dp) {
            var sValue = dp.value;
            $.ajax({ url: "SupplierInfo.ashx?supId=" + sValue,
                type: "GET",
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var tr = $(".detailTable").find("tr");
                    $(tr[1]).find("td[id=Contacter]").find("#<%=txtContacter.ClientID%>").val(json["Contacter"]);
                    $(tr[2]).find("td[id=Tel]").find("#<%=txtTel.ClientID%>").val(json["Tel"]);
                    $(tr[2]).find("td[id=Fax]").find("#<%=txtFax.ClientID%>").val(json["Fax"]);
                }
            });
        }

        function BindSelect(arg) {
            $.ajax({
                url: "GetPlatFormList.ashx",
                type: "GET",
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var option = "";
                    for (var i = 0; i < json.length; i++) {
                        option += "<option value=\"" + json[i]["ID"] + "\">" + json[i]["Name"] + "</option>";
                    }
                    arg.html(option);
                }
            });
        }

        $(document).ready(function () {
            //绑定平台下拉框
            $("#MyPurchaseProductList").find("tr[id=mytr]").each(function (i, val) {
                BindSelect($(this).find("td[id=tdplatform]").children().eq(0));
            });

            $("#MyPurchaseProductList").find("tr[id=mytr]").each(function (i, val) {
                var id = $(this).find("td[id=tdplatform]").children().eq(0).attr("selectValue");
                $(this).find("td[id=tdplatform]").children().eq(0);
                //遍历所有option 绑定对应平台
                $(this).find("td[id=tdplatform]").children().eq(0).find("option[value=" + id + "]").attr('selected', 'selected');
            });
            //autoCopleteBind();
            //新增一行
            $(document).on("click", "#imgAdd", function () {
                var tr = "<tr  id=\"mytr\"><td><input id=\"hiddProductId\" type=\"hidden\" /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value=''   type=\"text\"/></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"></select></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\"  id=\"lblSpecifications\" value='' /></td><td  style=\"width:5%\"><input  id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='0' /></td><td  style=\"width:3%\"><input  id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td style=\"width:8%\"><input  id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:8%\"><input  id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td></tr>";
                $("#MyPurchaseProductList").append(tr);
                BindSelect($(this).parent().parent().next().find("td[id=tdplatform]").children());
                // jQuery 1.7+
            });
            //删除
            $(document).on("click", "#imgDelete", function () {
                var type = document.getElementById("<%=hiddType.ClientID %>").value;
                if (type == 0) {
                    if ($(this).parent().parent().prev().attr("id") == 'mytr') {
                        $(this).parent().parent().remove();
                    }
                }
                else {
                    $(this).parent().parent().remove();
                }
            });

            $(document).on("keyup", "#txtProductName", function () {
                autoCompleteBind($(this).parent().next().children().val());
            });

            function IsNum(s) {
                if (s != null && s != "") {
                    return !isNaN(s);
                }
                return false;
            }

            //通过采购数量自动计算采购金额 级税金
            $(document).on("change", "#txtProductPrice", function () {
                var productPrice = $(this).val();      //采购单价
                if (!IsNum(productPrice)) {
                    alert('采购单价不能为非数字！');
                    return;
                }
                var count = $(this).parent().prev().prev().find("input[id=txtProductCount]").val();     //产品数量
                var money = Number(productPrice) * Number(count);                                           //采购金额
                $(this).parent().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
            });

            $(document).on("change", "#txtProductCount", function () {
                var count = $(this).val();
                if (IsNum(count)) {
                    var productPrice = $(this).parent().next().next().find("input[id=txtProductPrice]").val();
                    var money = Number(productPrice) * Number(count);                                           //采购金额
                    $(this).parent().next().next().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
                }
                else {
                    alert('采购数量不能为非数字');
                }
            });

            $(document).on("change", "#ddlPlatForm", function () {
                var productId = $(this).parent().prev().prev().find("input[id=hiddProductId]").val();
                var value = "";
                $.ajax({
                    url: "ProductList.ashx?action=ProductId&&pId=" + $(this).val() + "&&productId=" + productId,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        value = data["Costprice"];
                    }
                });

                //如果返回对应平台采购单价为0的话  重新赋值其他平台不为零的值
                if (value == 0) {
                    $.ajax({
                        url: "ProductList.ashx?action=ProductId2&&productId=" + productId,
                        type: "GET",
                        dataType: "json",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            value = data["Costprice"];
                        }
                    });
                }
                $(this).parent().next().next().next().next().find("input[id=txtProductPrice]").val(value);

                //重新计算金额
                var count = $(this).parent().next().next().find("input[id=txtProductCount]").val();    //商品数量
                if (count != '' && value != 0) {
                    var money = Number(count) * Number(value);
                    $(this).parent().next().next().next().next().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
                }
            });
        });

        function on_buttonClientClick() {
            getJsonContent();
        }

        function getJsonContent() {
            var json = '[';
            $("#MyPurchaseProductList").find("tr[id=mytr]").each(function (i, val) {
                if (i == 0) {
                    json = json + '{';
                }
                else {
                    json = json + ',{';
                }
                $(this).find("input").each(function () {
                    var t = $(this).val();
                    var id = $(this).attr("id");
                    json = json + '"' + id + '"' + ':' + '"' + t + '",';
                });
                json = json + 'PlatformTypeId' + ':' + '"' + $(this).find("td[id=tdplatform]").children().val() + '",';
                json = json.substring(0, json.length - 1);
                json = json + '}';
            });
            json = json + ']';
            document.getElementById("<%=hdfJsonContent.ClientID %>").value = json;
        }
    </script>
</asp:Content>
