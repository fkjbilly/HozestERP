<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="JDSaleRejectedAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.JDSaleRejectedAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
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
                $(tr[0]).find("td[id=autoNumber]").find("#<%=txtSaleRejectedNumber.ClientID%>").attr("readonly", true);
            }
            else {
                document.getElementById("<%=hiddAutoID.ClientID %>").value = false;
                $(tr[0]).find("td[id=autoNumber]").find("#<%=txtSaleRejectedNumber.ClientID%>").attr("readonly", false);
            }

            $(".detailTable :checkbox").click(function () {
                var is = $(this).prop("checked");
                if (is == true) {
                    document.getElementById("<%=hiddAutoID.ClientID %>").value = true;
                    $(tr[0]).find("td[id=autoNumber]").find("#<%=txtSaleRejectedNumber.ClientID%>").attr("readonly", true);
                }
                else {
                    document.getElementById("<%=hiddAutoID.ClientID %>").value = false;
                    $(tr[0]).find("td[id=autoNumber]").find("#<%=txtSaleRejectedNumber.ClientID%>").attr("readonly", false);
                }
            });
        });
        
        function autoCompleteBind(platformId) {
            $(".ProductName").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "ProductList.ashx?action=PdInfo",
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
                        var price = $(Specifications).parent().next().next().find("input[id=txtProductPrice]");
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
    <asp:HiddenField ID="hiddType" runat="server" />
    <asp:HiddenField ID="hiddIDs" runat="server" />
    <asp:HiddenField ID="hiddAutoID" runat="server" />
    <asp:Label ID="lblTitle" runat="server">    <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    退货单号
                </td>
                <!--<td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lblMessage" runat="server">  <font color="red">保存后自动生成</font></asp:Label>
                    <asp:Literal ID="lblRef" runat="server"></asp:Literal>
                </td>-->

                <td style="width: 218px; border-right: 1px soild red;" id="autoNumber">
                    <asp:Label ID="lblNumber" runat="server"></asp:Label>
                    <asp:TextBox ID="txtSaleRejectedNumber" runat="server" Width="60%"></asp:TextBox>
                    <input name="autoID" type="checkbox" value="" id="chkAutoID" runat="server" clientidmode="Static" />
                    <asp:Literal ID="lbl1" runat="server" Text="自动生成"></asp:Literal>
                </td>

                <td style="width: 140px" align="right">
                    退回工厂
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <ext:ComboBox runat="server" ID="DdlFactory" Editable="false" DisplayField="CodeName" ValueField="CodeID" EmptyText="请选择">
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
                    项目
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <%-- <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>--%>
                    <ext:Store runat="server" ID="CB1Store" AutoDataBind="false">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="ProjectName"></ext:RecordField>
                                        <ext:RecordField Name="Id"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                <ext:ComboBox runat="server" ID="ddXMProject" DisplayField="ProjectName" ValueField="Id" StoreID="CB1Store" Width="200" Editable="false">
                    <Listeners>
                        <Select Handler="#{ddlNick}.clearValue(); #{CB2Store}.reload();"  />
                        
                    </Listeners>
                </ext:ComboBox>
                </td>
                <td style="width: 140px" align="right">
                    店铺
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <%-- <asp:DropDownList ID="ddlNick" Width="90%" runat="server">
                    </asp:DropDownList>--%>
                 <ext:Store runat="server" ID="CB2Store" AutoDataBind="false" OnRefreshData="ddXMProject_SelectedIndexChanged">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                            <ext:RecordField Name="nick"></ext:RecordField>
                            <ext:RecordField Name="nick_id"></ext:RecordField>
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <%--<DirectEvents>
                        <Load OnEvent="ddXMProject_SelectedIndexChanged">
                            <EventMask ShowMask="true" Msg="正在处理..." ></EventMask>
                        </Load>
                    </DirectEvents>--%>
                </ext:Store>
                <ext:ComboBox runat="server" ID="ddlNick" StoreID="CB2Store" DisplayField="nick" ValueField="nick_id" Width="200" Editable="false"></ext:ComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    业务时间
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <input id="txtStorageDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 100%;" />
                </td>
                <td style="width: 140px" align="right">
                    退货原因
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlReturnCategoryList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备件单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <ext:TextField ID="txtPrepareRef" runat="server"></ext:TextField>
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSingleJDIsConfirm" SkinID="button6" runat="server" Text="京东确认"
                    OnClientClick="on_SingleConfirmClientClick();" OnClick="btnSingleJDIsConfirm_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.JDIsConfirm %>" />
            </td>
           <%-- <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSingleXBIsConfirm" SkinID="button6" runat="server" Text="推送千胜"
                    OnClientClick="on_SingleConfirmClientClick();" OnClick="btnSingleXBIsConfirm_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.XBIsConfirm %>" />
            </td>--%>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSingleXLMIsConfirm" SkinID="button6" runat="server" Text="喜临门确认"
                    OnClientClick="on_SingleConfirmClientClick();" OnClick="btnSingleXLMIsConfirm_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.XLMIsConfirm %>" />
            </td>
        </tr>
    </table>
            <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    <script type="text/javascript">
        $(document).ready(function () {
            //autoCopleteBind();
            //新增一行
            $(document).on("click", "#imgAdd", function () {
                var tr = "<tr  id=\"mytr\"><td id=\"box\"><input id=\"ck\" type=\"checkbox\" value=''</td><td><input id=\"hiddProductId\" type=\"hidden\" /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value=''   type=\"text\"/></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\"  id=\"lblSpecifications\" value='' /></td><td  style=\"width:5%\"><input  id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='0' /></td><td style=\"width:8%\"><input  id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:8%\"><input  id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td><td><img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  /></td><td><img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  /></td><td><img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  /></td></tr>";
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

            $(document).on("change", "#txtProductPrice", function () {
                var productPrice = $(this).val();
                if (!IsNum(productPrice)) {
                    alert('退货单价不能为非数字！');
                    return;
                }
                var count = $(this).parent().prev().find("input[id=txtProductCount]").val();     //产品数量
                var money = Number(productPrice) * Number(count);
                $(this).parent().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
            });

            $(document).on("change", "#txtProductCount", function () {
                var count = $(this).val();
                if (IsNum(count)) {
                    var productPrice = $(this).parent().next().find("input[id=txtProductPrice]").val();
                    var money = Number(productPrice) * Number(count);
                    $(this).parent().next().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
                }
                else {
                    alert('退货数量不能为非数字');
                }
            });
        });

        function on_buttonClientClick() {
            getJsonContent();
        }

        function on_SingleConfirmClientClick() {
            var value = '';
            $("#box input[type='checkbox']").each(function () {
                if (this.checked) {
                    value += $(this).val() + ',';
                }
            });
            value = value.length > 0 ? value.substr(0, value.length - 1) : '';
            document.getElementById("<%=hiddIDs.ClientID %>").value = value;
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
                json = json.substring(0, json.length - 1);
                json = json + '}';
            });
            json = json + ']';
            document.getElementById("<%=hdfJsonContent.ClientID %>").value = json;
        }
    </script>
</asp:Content>
