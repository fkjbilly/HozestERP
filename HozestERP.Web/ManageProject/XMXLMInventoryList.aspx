<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMXLMInventoryList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMXLMInventoryList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 70px">
                仓库:
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlWarehouse" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 70px">
                厂家编码:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtManufacturersCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 70px" align="right">
                品名规格:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtProductName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="仓库" SortExpression="WarehouseName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WarehouseName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="品名规格" SortExpression="ProductName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName") == null ? "" : Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="规格" SortExpression="Specifications">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications") == null ? "" : Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="物资类别" SortExpression="Type">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Type") == null ? "" : Eval("Type")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="条形码" SortExpression="BarCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BarCode") == null ? "" : Eval("BarCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单位" SortExpression="Unit">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Unit") == null ? "" : Eval("Unit")%>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="可销售库存" SortExpression="Inventory">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Inventory")%>
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
                <asp:Button ID="btnImport" runat="server" Text="导入" Visible="<% $CRMIsActionAllowed:ManageProject.XMXLMInventoryList.Import %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnXLMSynchro" runat="server" SkinID="button4" Text="库存同步" OnClick="btnXLMSynchro_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMXLMInventoryList.XLMSynchro %>" />
            </td>
        </tr>
    </table>
</asp:Content>
