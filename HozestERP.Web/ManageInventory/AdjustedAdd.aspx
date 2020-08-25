<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="AdjustedAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.AdjustedAdd" %>

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
    <asp:Label ID="lblTitle" runat="server">     <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    调整单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lblMessage" runat="server">  <font color="red">保存后自动生成</font></asp:Label>
                    <asp:Literal ID="lblRef" runat="server"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    项目
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
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
                        <Select Handler="#{ddlwareHouses}.clearValue(); #{CB2Store}.reload();"  />
                        
                    </Listeners>
                </ext:ComboBox>
                </td>
                <td style="width: 140px" align="right">
                    仓库
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <ext:Store runat="server" ID="CB2Store" AutoDataBind="false" OnRefreshData="ddXMProject_SelectedIndexChanged">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                            <ext:RecordField Name="Name"></ext:RecordField>
                            <ext:RecordField Name="Id"></ext:RecordField>
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <%--<DirectEvents>
                        <Load OnEvent="ddXMProject_SelectedIndexChanged">
                            <EventMask ShowMask="true" Msg="正在处理..." ></EventMask>
                        </Load>
                    </DirectEvents>--%>
                </ext:Store>
                <ext:ComboBox runat="server" ID="ddlwareHouses" StoreID="CB2Store" DisplayField="Name" ValueField="Id" Width="200" Editable="false"></ext:ComboBox>
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
                    付款方式
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPayment" runat="server">
                       
                    </asp:DropDownList>
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.AdjustedAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
        <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    <script type="text/javascript">
        $(document).ready(function () {

            //通过采购数量自动计算采购金额 级税金
            $(document).on("change", "#txtProductPrice", function () {
                var productPrice = $(this).val();      //采购单价
                var count = $(this).parent().prev().prev().find("input[id=txtProductCount]").val();     //产品数量
                var money = Number(productPrice) * Number(count);                                           //采购金额
                $(this).parent().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
                var taxRate = $(this).parent().next().next().find("input[id=txtTaxRate]").val();    //税率
                var tax = Number(money) * (Number(taxRate) / 100);
                var moneywithtax = Number(money) + Number(tax);
                $(this).parent().next().next().next().find("input[id=txtTax]").val(tax.toFixed(2).toString());
                $(this).parent().next().next().next().next().find("input[id=txtMoneyWithTax]").val(moneywithtax.toFixed(2).toString());
            });

            $(document).on("change", "#txtProductCount", function () {
                var count = $(this).val();
                var productPrice = $(this).parent().next().next().find("input[id=txtProductPrice]").val();
                var money = Number(productPrice) * Number(count);                                           //采购金额
                $(this).parent().next().next().next().find("input[id=txtProductMoney]").val(money.toFixed(2).toString());
                var taxRate = $(this).parent().next().next().next().next().find("input[id=txtTaxRate]").val();    //税率
                var tax = Number(money) * (Number(taxRate) / 100);
                var moneywithtax = Number(money) + Number(tax);
                $(this).parent().next().next().next().next().next().find("input[id=txtTax]").val(tax.toFixed(2).toString());
                $(this).parent().next().next().next().next().next().next().find("input[id=txtMoneyWithTax]").val(moneywithtax.toFixed(2).toString());
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
                json = json.substring(0, json.length - 1);
                json = json + '}';
            });
            json = json + ']';
            document.getElementById("<%=hdfJsonContent.ClientID %>").value = json;
        }
    </script>
</asp:Content>
