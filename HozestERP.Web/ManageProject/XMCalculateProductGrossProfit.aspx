<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMCalculateProductGrossProfit.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMCalculateProductGrossProfit" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .FloatRight
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" style="height: 100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 20px; height: 50px">
            </td>
            <td style="width: 93px; font-weight: bold; font-size: small">
                单品毛利计算
            </td>
            <td style="width: 200px">
                
            </td>
            <td>
            </td>
            <td style="width: 20px; height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                售价
            </td>
            <td style="width: 260px">
                <input type="text" id="txtSaleMoney" value="0" />
            </td>
            <td style="width: 8px; height: 8px" colspan="3">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                成本
            </td>
            <td style="width: 260px">
                <input type="text" id="txtCost" value="0" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                扣点
            </td>
            <td style="width: 260px" colspan="2">
                <input type="text" id="txtPoints" value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                其他扣点
            </td>
            <td style="width: 260px">
                <input type="text" id="txtQita" value="0" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                广告费
            </td>
            <td style="width: 260px">
                <input type="text" id="txtadvertising" value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                发货费
            </td>
            <td style="width: 260px">
                <input type="text" id="txtDeliverGoods" value="0" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                安装费
            </td>
            <td style="width: 260px" colspan="2">
                <input type="text" id="txtinstallAcount" value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                配件费
            </td>
            <td style="width: 260px">
                <input type="text" id="txtPartsCost" value="0" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                赠品费用
            </td>
            <td style="width: 260px" colspan="2">
                <input type="text" id="txtPremiunCost" value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                售后费用
            </td>
            <td style="width: 260px">
                <input type="text" id="txtCustomerServiceCost" value="0" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                税金
            </td>
            <td style="width: 260px" colspan="2">
                <input type="text" id="txtTaxCost" value="0" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 50px">
            </td>
            <td style="width: 93px; font-weight: bold; font-size: small">
                计算结果
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
            <td style="width: 20px; height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 20px">
            </td>
            <td style="width: 93px">
                毛利
            </td>
            <td style="width: 260px">
                <input type="text" id="txtMaoli" readonly="readonly" disabled="disabled" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 93px">
                毛利率
            </td>
            <td style="width: 260px" colspan="2">
                <input type="text" id="txtmalolilv" readonly="readonly" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 30px" colspan="7">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 400px;">
                <input type="button" id="btnCalculate" style="width: 120px;" value="计算毛利" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $("#btnCalculate").click(function () {
            var SaleMoney = $("#txtSaleMoney").val();    //售价
            var Cost = $("#txtCost").val();                    //成本
            var Points = $("#txtPoints").val();                //扣点
            var Qita = $("#txtQita").val();                     //其他扣点
            var advertising = $("#txtadvertising").val();    //广告费
            var DeliverGoods = $("#txtDeliverGoods").val();    //发货费用
            var installAcount = $("#txtinstallAcount").val();      //安装费用
            var PartsCost = $("#txtPartsCost").val();         //配件费用
            var PremiunCost = $("#txtPremiunCost").val();  //赠品费用
            var CustomerServiceCost = $("#txtCustomerServiceCost").val();     //售后费用
            var tax = $("#txtTaxCost").val();                              //税金

            var reg = "^[0-9]+(\.[0-9]{0,2})?$";     //正则表达式 （匹配浮点数保留两位小数）
            if (SaleMoney == '' || SaleMoney.match(reg) == null) {
                alert('请输入售价或输入售价格式不正确！');
                return;
            }
            if (Cost == '' || Cost.match(reg) == null) {
                alert('请输入成本或输入成本格式不正确！');
                return;
            }
            if (Points == '' || Points.match(reg) == null) {
                alert('请输入扣点或输入扣点格式不正确！');
                return;
            }
            if (Qita == '' || Qita.match(reg) == null) {
                alert('请输入其他扣点或输入其他扣点格式不正确！');
                return;
            }
            if (advertising == '' || advertising.match(reg) == null) {
                alert('请输入广告费或输入广告费格式不正确！');
                return;
            }
            if (DeliverGoods == '' || DeliverGoods.match(reg) == null) {
                alert('请输入发货费或输入发货费格式不正确！');
                return;
            }
            if (installAcount == '' || installAcount.match(reg) == null) {
                alert('请输入安装费或输入安装费格式不正确！');
                return;
            }
            if (PartsCost == '' || PartsCost.match(reg) == null) {
                alert('请输入配件费或输入配件费格式不正确！');
                return;
            }
            if (PremiunCost == '' || PremiunCost.match(reg) == null) {
                alert('请输入赠品费用或输入赠品费用格式不正确！');
                return;
            }
            if (CustomerServiceCost == '' || CustomerServiceCost.match(reg) == null) {
                alert('请输入售后费用或输入售后费用格式不正确！');
                return;
            }
            if (tax == '' || tax.match(reg) == null) {
                alert('请输入税金或输入税金格式不正确！');
                return;
            }
            //所有支出款项
            var total = Number(Cost) + Number(Points) + Number(Qita) + Number(advertising)
            + Number(DeliverGoods) + Number(installAcount) + Number(PartsCost) + Number(PremiunCost) + Number(CustomerServiceCost) + Number(tax);
            var maoli = Number(SaleMoney) - Number(total.toFixed(2));     //毛利=售价-所有支出
            $("#txtMaoli").val(maoli.toFixed(2));
            var baifenbi = "";
            if (Number(SaleMoney) != 0) {
                baifenbi = Math.round(maoli.toFixed(2) / Number(SaleMoney) * 10000) / 100.00 + "%";
            }
            else if (Number(SaleMoney) == 0) {
                baifenbi = "0%";
            }
            $("#txtmalolilv").val(baifenbi);

        });
    </script>
</asp:Content>
