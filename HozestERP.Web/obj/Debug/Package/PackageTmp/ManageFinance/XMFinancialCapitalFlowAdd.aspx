<%@ Page Language="C#" CodeBehind="XMFinancialCapitalFlowAdd.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageFinance.XMFinancialCapitalFlowAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        var $191 = $;
    </script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <script src="../Script/jquery.bgiframe.pack.js" type="text/javascript"></script>
    <script src="../Script/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Script/jquery.combobox.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="../Script/jquery.combobox.css" />
    <script type="text/javascript">

        jQuery(function ($) {
            Load();
            var editType = document.getElementById("<%=hiddEditType.ClientID %>").value;
            if (editType == 'ClaimSalePerson') {
                var ComboReceivables = document.getElementById("txtComboReceivables");
                var ComboBudget = document.getElementById("txtComboBudget");
                var FinancialType = document.getElementById("ddlFinancialType");
                ComboBudget.disabled = true;
                ComboReceivables.disabled = true;
                FinancialType.disabled = true;
            }
        });

        function Load() {
            GetCodeList(224, $('.ComboReceivables'));
            GetCodeList(225, $('.ComboBudget'));
            ReceivablesBudgetBind();
        }

        function GetCodeList(CodeTypeID, obj) {
            $.ajax({ url: "FinancialCapitalFlow.ashx?CodeTypeID=" + CodeTypeID.toString(),
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: "action=ReceivablesBudget",
                success: function (json) {
                    var str = "";
                    var data = new Array();
                    for (var i = 0; i < json.length; i++) {
                        data.push(json[i].Name);
                    }
                    obj.combobox(data);
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            });
        }

        function ReceivablesBudgetBind() {
            var Receivables = document.getElementById("HidReceivables");
            var Budget = document.getElementById("HidBudget");
            var Financial = document.getElementById("HidFinancial");
            if (Receivables.value != "") {
                document.getElementById("txtComboReceivables").value = Receivables.value;
            }
            if (Budget.value != "") {
                document.getElementById("txtComboBudget").value = Budget.value;
            }
            if (Financial.value != "") {
                var select = document.getElementById("ddlFinancialType");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == Financial.value) {
                        select.options[i].selected = true;
                        break;
                    }
                }
            }
            FinancialTypeChange();
        }

        function FinancialTypeChange() {
            var ComboReceivables = document.getElementById("txtComboReceivables");
            var ComboBudget = document.getElementById("txtComboBudget");
            var Financial = $("#ddlFinancialType option:selected").val();
            if (Financial == "1") {
                ComboReceivables.disabled = false;
                ComboBudget.disabled = true;
                ComboBudget.value = "";
                GetCodeList(224, $('.ComboReceivables'));
                GetCodeList(-1, $('.ComboBudget'));
            }
            else if (Financial == "0") {
                ComboReceivables.disabled = true;
                ComboBudget.disabled = false;
                ComboReceivables.value = "";
                GetCodeList(225, $('.ComboBudget'));
                GetCodeList(-1, $('.ComboReceivables'));
            }
            else {
                ComboReceivables.disabled = true;
                ComboBudget.disabled = true;
                ComboReceivables.value = "";
                ComboBudget.value = "";
                GetCodeList(-1, $('.ComboBudget'));
                GetCodeList(-1, $('.ComboReceivables'));
            }
        }

        function autoCompleteBind() {
            var str = $191("#<%=txtAbstract.ClientID %>");
            str.autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "FinancialCapitalFlow.ashx?action=autocomplete",
                        data: "p=" + str[0].value,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: "公司：" + item.ClientCompany + "； 打款人：" + item.PayPerson + "； 合同金额：" + item.ContractAmount,
                                    value: item.ClientCompany + " " + item.PayPerson.replace("空", ""),
                                    order: item
                                };
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    document.getElementById("<%=txtAbstract.ClientID %>").value = i.item.value;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="HidReceivables" value="<%=ReceivablesValue %>" />
    <input type="hidden" id="HidBudget" value="<%=BudgetValue %>" />
    <input type="hidden" id="HidFinancial" value="<%=FinancialValue %>" />
    <asp:HiddenField ID="hiddEditType" runat="server" />
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="right">
                    日期:
                </td>
                <td align="left" style="width: 120px">
                    <input id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server"
                        style="width: 88%;" />
                </td>
                <td style="width: 80px" align="right">
                    交款/报销人:
                </td>
                <td align="left" style="width: 120px">
                    <asp:TextBox ID="txtPerson" runat="server" Width="88%">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    摘要:
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtAbstract" Width="96%" runat="server" onkeyup="autoCompleteBind()">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    公司:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlBelongingCompany" Width="90%" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlBelongingCompany_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    部门类型:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlBelongingDep" Width="90%" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlBelongingDep_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="width: 80px" align="right">
                    项目:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlBelongingProject" Width="90%" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    支付/收款方式:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPaymentCollectionType" Width="90%" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 80px" align="right">
                    金额:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtAmount" Width="88%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    收入/支出:
                </td>
                <td align="left">
                    <select id="ddlFinancialType" name="ddlFinancialType" style="width: 90%" onchange="FinancialTypeChange()">
                        <option value=""></option>
                        <option value="1">收入</option>
                        <option value="0">支出</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    收款类别:
                </td>
                <td align="left">
                    <input type="text" name="txtComboReceivables" class="ComboReceivables" id="txtComboReceivables"
                        style="width: 90%" />
                </td>
                <td style="width: 80px" align="right">
                    对应预算科目:
                </td>
                <td align="left">
                    <input type="text" name="txtComboBudget" class="ComboBudget" id="txtComboBudget"
                        style="width: 90%" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    备注:
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtRemark" Width="96%" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowAdd.Save %>" />
            </td>
        </tr>
    </table>
</asp:Content>
