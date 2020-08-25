<%@ Page Language="C#" CodeBehind="CashbackPremiums.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageProject.CashbackPremiums" %>

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
            var list = $(".TextBox");
            var DropDownListList = $(".DropDownList");
            var PrdouctName = "";
            for (var i = 0; i < list.length; i++) {
                if (list[i].id.indexOf("txtPrdouctName") != -1) {
                    if (type == 1) {
                        PrdouctName = list[i].value;
                    }
                    else {
                        PrdouctName = "~!@%^*~!@";
                    }
                    break;
                }
            }
            list.autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "CashbackPremiumsGetProduct.ashx",
                        data: "p=" + PrdouctName,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: "商品名称:" + item.ProductName + "  尺寸:" + item.Specifications + "  出厂价:" + item.Costprice + "  厂家编码:" + item.ManufacturersCode + "  商品编码:" + item.PlatformMerchantCode,
                                    value: item.ProductName,
                                    order: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, q, j) {
                    document.getElementById("<%=hidDetailId.ClientID %>").value = q.item.order.DetailId;
                    for (var i = 0; i < list.length; i++) {
                        if (list[i].id.indexOf("txtPrdouctName") != -1) {
                            list[i].value = q.item.order.ProductName;
                        }
                        if (list[i].id.indexOf("txtPlatformMerchantCode") != -1) {
                            list[i].value = q.item.order.ManufacturersCode;
                        }
                        if (list[i].id.indexOf("txtSpecifications") != -1) {
                            list[i].value = q.item.order.Specifications;
                        }
                        if (list[i].id.indexOf("txtFactoryPrice") != -1) {
                            list[i].value = q.item.order.Costprice;
                        }
                    }
                    for (var i = 0; i < DropDownListList.length; i++) {
                        if (DropDownListList[i].id.indexOf("ddlShipper") != -1) {
                            DropDownListList[i].value = q.item.order.Shipper;
                        }
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <font size="3" color="blue"><strong>返现管理</strong></font>
    <asp:GridView ID="gvCashback" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowDataBound="gvCashback_RowDataBound" OnRowUpdating="gvCashback_RowUpdating"
        OnRowCommand="gvCashback_RowCommand" OnRowEditing="gvCashback_RowEditing" OnRowDeleting="gvCashback_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdId" Value='<%# Eval("ID")%>' runat="server" />
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center" CssClass="headbackground">
                </HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%# Eval("OrderCode")%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="旺旺号" SortExpression="">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("WantNo")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%# Eval("WantNo")%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BuyerName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtBuyerName" Width="80px" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请类型" SortExpression="">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# (int)Eval("ApplicationTypeId")==9?"返现":"赔付"%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlApplicationType" Width="90%" runat="server">
                        <asp:ListItem Value="10" Text="赔付"></asp:ListItem>
                        <asp:ListItem Value="9" Text="返现"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收款账号" SortExpression="">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BuyerAlipayNo")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtBuyerAlipayNo" Width="120px" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CashBackMoney")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCashBackMoney" Width="80px" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="返现状态" SortExpression="">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="ImgCashBackStatus" runat="server" Checked='<%# Eval("CashBackStatus")==null? false: ((int)Eval("CashBackStatus")==0?false:true)%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="ChkCashBackStatus" Width="30px" runat="server" Enabled="false" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核状态" SortExpression="">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="ImgManagerStatus" runat="server" Checked='<%# (int)Eval("ManagerStatus")==3 ? false: true%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="ChkManagerStatus" Width="30px" runat="server" Enabled="false" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="赔付方" SortExpression="">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("PaymentPersonName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlPaymentPerson" Width="90%" runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" CssClass="headbackground" />
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Edit %>"
                        CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Delete %>" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Save %>"
                        CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="ToCancel" CausesValidation="False" CommandArgument='<%# Container.DataItemIndex %>' />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <font size="3" color="blue"><strong>赠品管理</strong></font>
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 250px" align="right">
                    订单号<font color="red">*</font>:
                </td>
                <td style="width: 200px; border-right: 1px soild red;">
                    <asp:TextBox ID="TxtOrderCode" Width="150px" runat="server" Enabled="false"></asp:TextBox>
                </td>
                <td style="width: 100px" align="right">
                    旺旺号<font color="red">*</font>:
                </td>
                <td style="width: 300px; border-right: 1px soild red;">
                    <asp:TextBox ID="TxtWangNo" Width="150px" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    申请类型<font color="red">*</font>:
                </td>
                <td style="border-right: 1px soild red;">
                    <asp:DropDownList ID="DdApplicationType" runat="server" Width="155px">
                        <asp:ListItem Value="10" Text="赔付"></asp:ListItem>
                        <asp:ListItem Value="11" Text="赠品"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    赔付方<font color="red">*</font>:
                </td>
                <td style="border-right: 1px soild red;">
                    <asp:DropDownList ID="DdlPaymentPerson" runat="server" Width="155px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    赠品状态<font color="red">*</font>:
                </td>
                <td style="border-right: 1px soild red;">
                    <div id="DIV6" runat="server">
                        <CRM:ImageCheckBox ID="LblCashBackStatus" runat="server" />
                    </div>
                </td>
                <td align="right">
                    项目审核<font color="red">*</font>:
                </td>
                <td style="border-right: 1px soild red;">
                    <div id="DIV12" runat="server">
                        <CRM:ImageCheckBox ID="LblManagerStatus" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    是否评价<font color="red">*</font>:
                </td>
                <td style="border-right: 1px soild red;">
                    <div id="DIV4" runat="server">
                        <CRM:ImageCheckBox ID="Ispj" runat="server" />
                    </div>
                </td>
                <td align="right">
                    是否排单<font color="red">*</font>:
                </td>
                <td style="border-right: 1px soild red;">
                    <div id="DIV8" runat="server">
                        <CRM:ImageCheckBox ID="Issh" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right">
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Add %>" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:HiddenField ID="hidDetailId" runat="server" />
    <asp:GridView ID="gvPremiums" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowUpdating="gvPremiums_RowUpdating" OnRowCommand="gvPremiums_RowCommand"
        OnRowEditing="gvPremiums_RowEditing" OnRowDeleting="gvPremiums_RowDeleting" OnRowDataBound="gvPremiums_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdIdp" Value='<%# Eval("Id")%>' runat="server" />
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center" CssClass="headbackground">
                </HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称" SortExpression="">
                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("PrdouctName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrdouctName" Width="150px" runat="server" onkeyup="autoCompleteBind(1)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("PlatformMerchantCode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPlatformMerchantCode" Width="150px" runat="server" Enabled="false"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="发货方" SortExpression="">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("ShipperName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlShipper" runat="server" Width="85px">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="尺寸" SortExpression="">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSpecifications" Width="150px" runat="server" Enabled="false"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量" SortExpression="">
                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemTemplate>
                    <%# Eval("ProductNum")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductNum" Width="150px" runat="server" onkeyup="autoCompleteBind(0)"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出厂价" SortExpression="">
                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FactoryPrice")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFactoryPrice" Width="150px" runat="server" Enabled="false"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" CssClass="headbackground" />
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Edit1 %>"
                        CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Delete1 %>" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageProject.CashbackPremiums.Save1 %>"
                        CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="ToCancel" CausesValidation="False" CommandArgument='<%# Container.DataItemIndex %>' />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>
