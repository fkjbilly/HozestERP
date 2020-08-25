<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMDeliveryProductInventoryList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMDeliveryProductInventoryList"
    EnableEventValidation="true" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 80px; text-align: right;">
                项目:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                店铺:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                年份:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlYear" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                月份:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                    <asp:ListItem Value="1">1月</asp:ListItem>
                    <asp:ListItem Value="2">2月</asp:ListItem>
                    <asp:ListItem Value="3">3月</asp:ListItem>
                    <asp:ListItem Value="4">4月</asp:ListItem>
                    <asp:ListItem Value="5">5月</asp:ListItem>
                    <asp:ListItem Value="6">6月</asp:ListItem>
                    <asp:ListItem Value="7">7月</asp:ListItem>
                    <asp:ListItem Value="8">8月</asp:ListItem>
                    <asp:ListItem Value="9">9月</asp:ListItem>
                    <asp:ListItem Value="10">10月</asp:ListItem>
                    <asp:ListItem Value="11">11月</asp:ListItem>
                    <asp:ListItem Value="12">12月</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="10px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdID" Value='<%#Eval("ID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="项目" SortExpression="ProjectName">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProjectName") == "" ? this.ddlXMProject.SelectedItem.Text.Trim() : Eval("ProjectName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺" SortExpression="NickName">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("NickName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="时间" SortExpression="YearMonth">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("YearMonth")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersCode") == null ? "" : Eval("ManufacturersCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸" SortExpression="Specifications">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="剩余库存" SortExpression="SurplusInventory">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SurplusInventory")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库数量" SortExpression="StorageCount">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("StorageCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库金额" SortExpression="StorageAmount">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("StorageAmount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库数量" SortExpression="DeliveryCount">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库金额" SortExpression="DeliveryAmount">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryAmount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存数量" SortExpression="InventoryCount">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InventoryCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存金额" SortExpression="InventoryAmount">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InventoryAmount")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExport" SkinID="button2" runat="server" Text="导出" Visible="<% $CRMIsActionAllowed:XMDeliveryProductInventoryList.btnExport %>"
                    OnClick="btnExport_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
