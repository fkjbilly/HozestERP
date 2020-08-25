<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SaleReturnAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.SaleReturnAdd" %>

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
    <asp:Label ID="lblTitle" runat="server">    <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    退货单号
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
                    <%--<asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
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
                        <Select Handler="#{ddlwareHouses}.clearValue(); #{CB2Store}.reload();"  />
                        
                    </Listeners>
                </ext:ComboBox>
                </td>
                <td style="width: 140px" align="right">
                    入库仓库
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <%--<asp:DropDownList ID="ddlWareHourses" runat="server">
                    </asp:DropDownList>--%>
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
                    Visible="<% $CRMIsActionAllowed:ManageInventory.SaleReturnAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSaleReturnStorge" SkinID="button4" runat="server" Text="提交入库"
                    OnClick="btnSaleReturnStorge_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.SaleReturnList.SubmitStorages %>" />
            </td>
        </tr>
    </table>
    <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    <script type="text/javascript">

        function IsNum(s) {
            if (s != null && s != "") {
                return !isNaN(s);
            }
            return false;
        }

        $(document).ready(function () {
            $(document).on("click", "#imgDelete", function () {
                if ($(this).parent().parent().prev().attr("id") == 'mytr') {
                    $(this).parent().parent().remove();
                }
            });
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
                var PID = $(this).find("td[id=PID]").find("input[id=hiddPID]").val();
                var kCount = $(this).find("td[id=counts]").find("input[id=txtKCount]").val();    //可退货数量
                var PlatformMerchantCode = $(this).find("td[id=PlatformMerchantCode]").html();
                var ProductCount = $(this).find("td[id=count]").find("input[id=txtProductCount]").val();    //退货数量
                var price = $(this).find("td[id=Price]").html();
                var money = $(this).find("td[id=ProductMoney]").html();
                json = json + '"PlatformMerchantCode"' + ':' + '"' + PlatformMerchantCode + '",' + '"KCount"' + ':' + '"' + kCount + '",' + '"ProductCount"' + ':' + '"' + ProductCount + '",'
                + '"price"' + ':' + '"' + price + '",' + '"money"' + ':' + '"' + money + '",' + '"PID"' + ':' + '"' + PID + '",'
                json = json.substring(0, json.length - 1);
                json = json + '}';
            });
            json = json + ']';
            document.getElementById("<%=hdfJsonContent.ClientID %>").value = json;
        }

    </script>
</asp:Content>
