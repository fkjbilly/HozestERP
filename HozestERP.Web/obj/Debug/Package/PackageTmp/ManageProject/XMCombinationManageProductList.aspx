<%@ Page Language="C#" CodeBehind="XMCombinationManageProductList.aspx.cs" MasterPageFile="~/MasterPages/Root.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageProject.XMCombinationManageProductList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="left">
                    产品名称:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="ddlProductName" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 80px" align="left">
                    厂家编号:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="ddlManufacturersCode" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 80px" align="left">
                </td>
                <td align="left">
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" ValidationGroup="ModuleValidationGroup"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationManageProductList.Search %>" />
                </td>
            </tr>
        </tbody>
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
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductName">
                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编号" SortExpression="ManufacturersCode">
                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存" SortExpression="ManufacturersInventory">
                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersInventory")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="录入日期" SortExpression="CreateDate">
                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateDate")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table style="width: 100%;" align="left">
        <tr align="left">
            <td align="left">
                <asp:Button ID="btnSave" runat="server" Text="添加" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationManageProductList.Save %>" />
            </td>
        </tr>
    </table>
</asp:Content>
