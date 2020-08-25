<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="StoragedRejectedAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.StoragedRejectedAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfJsonContent" runat="server" />
    <asp:Label ID="lblTitle" runat="server">   <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    退货单号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lblMessage" runat="server">  <font color="red">保存后自动生成</font></asp:Label>
                    <asp:Literal ID="lblRef" runat="server"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                    入库单号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Literal ID="lblStorageCode" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    供应商
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlSuppliers" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    付款方式
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPayment" runat="server">
                    </asp:DropDownList>
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
                    退货仓库
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Literal ID="lblRejectedWareHoueses" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备注<font color="red">*</font>:
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.StoragedRejectedAdd.Save %>"
                    OnClick="btnSave_Click" OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnSingleRejectedDelivery" SkinID="button4" runat="server" Text="提交出库"
                    OnClick="btnSingleRejectedDelivery_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.StoragedRejectedList.SubmitDelivery %>" />
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

        //删除
        $(document).on("click", "#imgDelete", function () {
            $(this).parent().parent().remove();
        });

        $(document).on("change", "#txtProductCount", function () {
            var num = $(this).val();      //退货数量
            if (!IsNum(num)) {
                alert('退货数量不能为非数字！');
                return;
            }
            var price = $(this).parent().next().next().html();
            var money = Number(num) * Number(price);
            $(this).parent().next().next().next().html(money.toFixed(2).toString());
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
                var PlatformMerchantCode = $(this).find("td[id=PlatformMerchantCode]").html();
                var ProductCount = $(this).find("td[id=count]").find("input[id=txtProductCount]").val();       //可退货数量
                var count = $(this).find("td[id=counts]").find("input[id=txtCount]").val();
                var price = $(this).find("td[id=Price]").html();
                var money = $(this).find("td[id=ProductMoney]").html();
                json = json + '"PlatformMerchantCode"' + ':' + '"' + PlatformMerchantCode + '",' + '"ProductCount"' + ':' + '"' + ProductCount + '",'
                + '"Count"' + ':' + '"' + count + '",' + '"price"' + ':' + '"' + price + '",' + '"money"' + ':' + '"' + money + '",'
                json = json.substring(0, json.length - 1);
                json = json + '}';
            });
            json = json + ']';
            document.getElementById("<%=hdfJsonContent.ClientID %>").value = json;
        }

    </script>
</asp:Content>
