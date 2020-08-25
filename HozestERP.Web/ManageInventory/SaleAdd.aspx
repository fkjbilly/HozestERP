<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SaleAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.SaleAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function autoCompleteBind(platformId) {
            $(".ProductName").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "ProductList.ashx?action=SaleAdd&&pid=" + platformId,
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.ProductName + ", 编码:" + item.ManufacturersCode + ", 尺寸:" + item.Specifications + ", 销售价:" + item.Saleprice,
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
                        price.val(i.item.order.Saleprice);
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .table
        {
            width: 100%;
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
            border: solid 1px #9BC2DB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfJsonContent" runat="server" />
    <asp:HiddenField ID="hiddType" runat="server" />
    <asp:Label ID="lblTitle" runat="server">   <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    销售单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lblMessage" runat="server">  <font color="red">保存后自动生成</font></asp:Label>
                    <asp:Literal ID="lblRef" runat="server"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                    业务日期:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <input id="txtDeliveryDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 50%;" />
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    客户姓名
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtCustomerName" runat="server" Width="50%"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    联系电话
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtTel" runat="server" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    客户地址
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    付款方式
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPayment" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    项目
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddXMProject" Width="40%" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    快递费
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtExpressFee" runat="server" Width="50%"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    配件费
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtPartsFee" runat="server" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    安装费
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtInstallFee" runat="server" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备注
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtNote" runat="server" Text="" Width="80%" TextMode="MultiLine"
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.SaleAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <script type="text/javascript">

        function IsNum(s) {
            if (s != null && s != "") {
                return !isNaN(s);
            }
            return false;
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
            $("#MyPurchaseProductList").find("tr[id=mytr]").each(function (i, val) {
                BindSelect($(this).find("td[id=tdplatform]").children());
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
                var tr = "<tr  id=\"mytr\"><td><input id=\"hiddProductId\" type=\"hidden\" /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"></select></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\"  id=\"lblSpecifications\" value='' /></td><td><input  id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input  id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><input  id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input  id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td></tr>";
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

            //通过采购数量自动计算采购金额 级税金
            $(document).on("change", "#txtProductPrice", function () {
                var productPrice = $(this).val();      //销售单价
                if (!IsNum(productPrice)) {
                    alert('销售单价不能为非数字！');
                    return;
                }
                var count = $(this).parent().prev().prev().find("input[id=txtProductCount]").val();     //销售数量
                var money = Number(productPrice) * Number(count);                                           //销售金额
                $(this).parent().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
            });

            $(document).on("change", "#txtProductCount", function () {
                var count = $(this).val();
                if (!IsNum(count)) {
                    alert('商品数量不能为非数字！');
                    return;
                }
                var productPrice = $(this).parent().next().next().find("input[id=txtProductPrice]").val();
                var money = Number(productPrice) * Number(count);                                           //销售金额
                $(this).parent().next().next().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
            });

            $(document).on("change", "#ddlPlatForm", function () {
                var productId = $(this).parent().prev().prev().find("input[id=hiddProductId]").val();
                var value = "";
                $.ajax({
                    url: "ProductList.ashx?action=SaleProductId&&pId=" + $(this).val() + "&&productId=" + productId,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        value = data["Saleprice"];
                    }
                });
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
