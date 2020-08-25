<%@ Page Language="C#" CodeBehind="XMClaimAdd.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageProject.XMClaimAdd" %>

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
        function autoCompleteBind(type) {
            var str = "";
            if (type == 0) {
                str = $("#<%=txtApplicationNo.ClientID %>"); // document.getElementById("<%=txtApplicationNo.ClientID %>");
            }
            else {
                str = $("#<%=txtOrderCode.ClientID %>"); // document.getElementById("<%=txtOrderCode.ClientID %>");
            }
            str.autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "XMClaim.ashx?action=ClaimInfo",
                        data: "p=" + str[0].value + "&q=" + type,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                if (type == 0) {
                                    return {
                                        label: " 退换货单号：" + item.ApplicationNo + " 订单号：" + item.OrderCode,
                                        value: item.ApplicationNo,
                                        order: item
                                    };
                                }
                                else {
                                    return {
                                        label: " 订单号：" + item.OrderCode + " 店铺：" + item.NickName + " 平台：" + item.PlatformType + " 收货人：" + item.FullName,
                                        value: item.OrderCode,
                                        order: item
                                    };
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    if (type == 0) {
                        document.getElementById("<%=txtApplicationNo.ClientID %>").value = i.item.order.ApplicationNo;
                        document.getElementById("<%=txtOrderCode.ClientID %>").value = i.item.order.OrderCode;
                        document.getElementById("<%=txtPlatformType.ClientID %>").value = i.item.order.PlatformType;
                        document.getElementById("<%=hidPlatformType.ClientID %>").value = i.item.order.PlatformTypeId;
                        document.getElementById("<%=txtNick.ClientID %>").value = i.item.order.NickName;
                        document.getElementById("<%=hidNick.ClientID %>").value = i.item.order.NickId;
                        document.getElementById("<%=txtReturnTime.ClientID %>").value = i.item.order.ReturnTime;
                    }
                    else {
                        document.getElementById("<%=txtOrderCode.ClientID %>").value = i.item.order.OrderCode;
                        document.getElementById("<%=txtPlatformType.ClientID %>").value = i.item.order.PlatformType;
                        document.getElementById("<%=hidPlatformType.ClientID %>").value = i.item.order.PlatformTypeId;
                        document.getElementById("<%=txtNick.ClientID %>").value = i.item.order.NickName;
                        document.getElementById("<%=hidNick.ClientID %>").value = i.item.order.NickID;
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="right">
                    是否为退换货生成的索赔单:
                </td>
                <td align="left" colspan="3">
                    <asp:CheckBox ID="chkIsReturn" runat="server" Text="" OnCheckedChanged="chkIsReturn_CheckedChanged"
                        AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    退换货单号:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtApplicationNo" Width="100%" onkeyup="autoCompleteBind(0)"
                        AutoPostBack="true" OnTextChanged="ApplicationNo_Changed"></asp:TextBox>
                </td>
                <td style="width: 80px" align="right">
                    订单号:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtOrderCode" Width="100%" onkeyup="autoCompleteBind(1)"
                        AutoPostBack="true" OnTextChanged="ApplicationNo_Changed"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    平台类型:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtPlatformType" Width="100%"></asp:TextBox>
                    <asp:HiddenField ID="hidPlatformType" runat="server" />
                </td>
                <td style="width: 80px" align="right">
                    店铺:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtNick" Width="100%"></asp:TextBox>
                    <asp:HiddenField ID="hidNick" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    索赔类型:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlClaimType" Width="100%" runat="server">
                    </asp:DropDownList>
                    <td style="width: 80px" align="right">
                        索赔金额:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtAmount" Width="100%"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    发货人:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtConsignorName" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 80px" align="right">
                    托运公司:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtCompanyName" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    发货时间:
                </td>
                <td align="left">
                    <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 100%;" />
                </td>
                <td style="width: 80px" align="right">
                    到达时间:
                </td>
                <td align="left">
                    <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 100%;" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    物流单号:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtLogisticsNumber" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 80px" align="right">
                    货物名称:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtGoodsName" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    托运数量:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtCount" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 80px" align="right">
                    保价金额:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtInsuredAmount" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    起运地:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtBeginPlace" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 80px" align="right">
                    目的地:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtEndPlace" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    受损数量:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtBrokenPieces" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 80px" align="right">
                    入仓时间:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtReturnTime" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px" align="right">
                    受损状态:
                </td>
                <td align="left" colspan="3">
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox4" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox5" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox6" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 30px">
                                <asp:CheckBox ID="CheckBox7" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <strong>受损货物清单：</strong>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grdvZYNewsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        SkinID="GridViewThemen" OnRowCommand="grdvZYNewsList_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="5%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名" SortExpression="ProductName">
                                <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="型号" SortExpression="Model">
                                <HeaderStyle Width="10%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:Label ID="lblModel" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="货物价值" SortExpression="ProductValue">
                                <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Width="91%" ID="txtProductValue" Text="0">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="受损情况描述" SortExpression="Description">
                                <HeaderStyle Width="40%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Width="97%" ID="txtDescription">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="受损金额">
                                <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Width="91%" ID="txtAmount" Text="0">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="ToDelete" CausesValidation="False"
                                        OnClientClick="return confirm('您确定要删除此货物信息？');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimAdd.Save %>" />
            </td>
        </tr>
    </table>
</asp:Content>
