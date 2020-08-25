<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMSaleActivityAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMSaleActivityAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function autoCompleteBind() {
            $("#txtProductName").autocomplete({
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
                    var list = $("#txtProductName");
                    if (list != null && list.length > 0) {
                        var productcode = $(this).parent().next().next().next().find("input[id=txtPlatformMerchantCode]");      //获取商品名称控件
                        productcode.val(i.item.order.ManufacturersCode);                                       //赋值

                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                活动标题 <font color="red">*</font>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtActivityTitle" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                活动日期
            </td>
            <td style="width: 260px">
                <input id="dpLogDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 90%;" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
                活动类型
            </td>
            <td style="width: 260px">
                <asp:DropDownList ID="ddlActivityTypes" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                商品名称
            </td>
            <td style="width: 260px">
                <asp:TextBox ID="txtProductName" runat="server" Width="90%" CssClass="TextBox ProductName"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                厂家编码
            </td>
            <td style="width: 260px" id="PlatformMerchantCode">
                <asp:TextBox ID="txtPlatformMerchantCode" runat="server" Width="80%" CssClass="TextBox ProductCode"
                    ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                项目
            </td>
            <td style="width: 260px">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                店铺
            </td>
            <td style="width: 260px">
                <asp:DropDownList ID="ddlNick" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 120px">
                备注
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtRemark" runat="server" Width="90%" Height="60" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    Visible="<%$CRMIsActionAllowed:ManageInventory.XMSaleActivityAdd.Save %>" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on("keyup", "#txtProductName", function () {
                autoCompleteBind();
            });
        });
    </script>
</asp:Content>
