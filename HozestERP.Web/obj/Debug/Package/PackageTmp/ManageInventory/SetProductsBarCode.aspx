<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SetProductsBarCode.aspx.cs" Inherits="HozestERP.Web.ManageInventory.SetProductsBarCode" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
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
            color: Black;
            border: solid 1px #9BC2DB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfJsonContent" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td style="float: right">
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:SetProductBarCode.Save %>"
                    OnClientClick="on_buttonClientClick();" />
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style="height: 8px">
            </td>
        </tr>
    </table>
    <%=TableStr %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtBarCodes")[0].focus();
            var strs = '';
            $(document).on("keydown", "#txtBarCodes", function (event) {
                if (event.keyCode == 13) {
                    var a = 0;
                    var barcode = $(this).val();             //获取条形码
                    if (barcode == '') {
                        alert('请输入条形码！');
                    }
                    else {
                        if (strs == '') {
                            var tr = "<tr id=\"mytr\"><td id=\"barCodes\">" + barcode + "</td><td><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td></tr>";
                            $("#MyPurchaseProductList").append(tr);
                        }
                        else {
                            if (strs.length > 0) {
                                var p = strs.substring(0, strs.length - 1);
                                var arr = new Array(); //定义一数组 
                                arr = p.split(";"); //字符分割 
                                for (i = 0; i < arr.length; i++) {
                                    if (barcode == arr[i]) {                 //判断扫入的条形码是否已经存在 
                                        a = 1;
                                    }
                                }
                            }
                            if (a == 1) {
                                alert('条形码已经存在，请重新录入！');
                                $(this).val('');
                                return false;
                            }
                            else {
                                var tr = "<tr id=\"mytr\"><td id=\"barCodes\">" + barcode + "</td><td><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td></tr>";
                                $("#MyPurchaseProductList").append(tr);
                            }
                        }
                        strs = strs + barcode + ";";
                    }
                    $(this).val('');
                    return false;
                }
            });
            //删除
            $(document).on("click", "#imgDelete", function () {
                $(this).parent().parent().remove();
            });
        });

        function on_buttonClientClick() {
            getJsonContent();
        }

        function getJsonContent() {
            var str = '';
            $("#MyPurchaseProductList").find("tr[id=mytr]").each(function (i, val) {
                $(this).find("td[id=barCodes]").each(function () {
                    str = str + $(this).html() + ";";
                });
            });
            if (str != '') {
                document.getElementById("<%=hdfJsonContent.ClientID %>").value = str;
            }
        }
    </script>
</asp:Content>
