<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMInvoiceInfoAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMInvoiceInfoAdd" %>

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
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">

        function GetFocus(id) {
            var count = 0;
            var unitPrice = 0;
            var Id = id.replace("lblCount", "");
            Id = Id.replace("lblUnitPrice", "");
            var lblCount = $("#<%= grdvClients.ClientID%> :input[id*='lblCount']");
            for (var a = 0; a < lblCount.length; a++) {
                if (lblCount[a].id.indexOf(Id) != -1) {
                    count = lblCount[a].value;
                    break;
                }
            }
            var lblUnitPrice = $("#<%= grdvClients.ClientID%> :input[id*='lblUnitPrice']");
            for (var a = 0; a < lblUnitPrice.length; a++) {
                if (lblUnitPrice[a].id.indexOf(Id) != -1) {
                    unitPrice = lblUnitPrice[a].value;
                    break;
                }
            }
            var lblAmount = $("#<%= grdvClients.ClientID%> :input[id*='lblAmount']");
            for (var a = 0; a < lblAmount.length; a++) {
                if (lblAmount[a].id.indexOf(Id) != -1) {
                    lblAmount[a].value = (parseFloat(count) * parseFloat(unitPrice)).toFixed(2).toString();
                    break;
                }
            }

        }

        function autoCompleteBind() {

            $("#<%= txtOrderCode.ClientID%>").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        async: false,
                        url: "xMInvoiceInfo.ashx?action=GetProductInfoList",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.OrderCode + "平台：" + item.PlatformName + " 店铺：" + item.NickName,
                                    value: item.OrderCode,
                                    scalping: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {

                    jQuery(function ($) {
                        $.ajax({ url: "xMInvoiceInfo.ashx",
                            //async: false,
                            type: "GET",
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            data: "action=SelectProductInfo",
                            success: function (json) {
                                if (json == "1") {
                                    $("#ctl00_Contentplaceholder2_grdvClients_ctl02_lblProductName").val(i.item.scalping.ProductName);
                                    $("#ctl00_Contentplaceholder2_grdvClients_ctl02_lblProductUnit>").val(i.item.scalping.ProductUnit);
                                    $("#ctl00_Contentplaceholder2_grdvClients_ctl02_lblCount").val(i.item.scalping.Count);
                                    $("#ctl00_Contentplaceholder2_grdvClients_ctl02_lblUnitPrice").val(i.item.scalping.UnitPrice);
                                    $("#ctl00_Contentplaceholder2_grdvClients_ctl02_lblAmount").val(i.item.scalping.Amount);
                                }
                            },
                            error: function (x, e) {
                            },
                            complete: function (x) {
                            }
                        });
                    });
                }
            });
        }
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="detailTitle" style="float: left;">发票信息</span>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="right">
                    发票类型<font color="red">*</font>:
                </td>
                <td style="width: 150px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlInvoiceType" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlInvoiceType_Changed">
                    </asp:DropDownList>
                    <asp:CheckBox ID="chkcom" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CheckBox1_CheckedChanged" Text="是否公司" />
                </td>
                <td style="width: 65px" align="right">
                    发票编号<font color="red">*</font>:
                </td>
                <td style="width: 200px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtInvoiceNo" runat="server" Width="75%" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    订单号<font color="red">*</font>:
                </td>
                <td>
                    <asp:TextBox ID="txtOrderCode" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right">
                    发票抬头<font color="red">*</font>:
                </td>
                <td>
                    <asp:TextBox ID="txtInvoiceHeader" runat="server" Width="75%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    税号:
                </td>
                <td>
                    <asp:TextBox ID="txtDutyParagraph" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right">
                    地址:
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Width="75%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    电话:
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right">
                    开户行:
                </td>
                <td>
                    <asp:TextBox ID="txtBankAccount" runat="server" Width="75%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    账号:
                </td>
                <td>
                    <asp:TextBox ID="txtAccountNumber" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        OnRowDataBound="grdvClients_RowDataBound" SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品名称">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input style="background: transparent; width: 90%;" value='<%# Eval("ProductName")%>'
                        runat="server" id="lblProductName" type="text" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单位">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductUnit")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input style="background: transparent; width: 90%;" value='<%# Eval("ProductUnit")%>'
                        runat="server" id="lblProductUnit" type="text" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Count")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input style="background: transparent; width: 90%;" class="TextBox Count" value='<%# Eval("Count")==null?"1":Eval("Count")%>'
                        runat="server" id="lblCount" type="text" onblur="GetFocus(this.id)" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("UnitPrice")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input style="background: transparent; width: 90%;" class="TextBox UnitPrice" value='<%# Eval("UnitPrice")%>'
                        runat="server" id="lblUnitPrice" type="text" onblur="GetFocus(this.id)" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="总价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Amount")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input style="background: transparent; width: 90%;" class="TextBox Amount" value='<%# Eval("Amount")%>'
                        runat="server" id="lblAmount" type="text" readonly="readonly" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" CommandName="ToEdit" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%# Eval("ID") %>' ToolTip="删除" CommandName="ToDelete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            autoCompleteBind();
        });
    </script>
</asp:Content>
