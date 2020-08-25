<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMMonthInventoryStatistics.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMMonthInventoryStatistics" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 50px">
                年份：
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlYear" Width="100%" runat="server">
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2024">2024</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 50px">
                月份：
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                    <asp:ListItem Value="1">01</asp:ListItem>
                    <asp:ListItem Value="2">02</asp:ListItem>
                    <asp:ListItem Value="3">03</asp:ListItem>
                    <asp:ListItem Value="4">04</asp:ListItem>
                    <asp:ListItem Value="5">05</asp:ListItem>
                    <asp:ListItem Value="6">06</asp:ListItem>
                    <asp:ListItem Value="7">07</asp:ListItem>
                    <asp:ListItem Value="8">08</asp:ListItem>
                    <asp:ListItem Value="9">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 50px">
                项目
            </td>
            <td style="width: 200px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 50px">
                仓库
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlWareHourses" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound"
        OnRowCreated="grdvClients_RowCreated">
        <Columns>
            <asp:TemplateField HeaderText="年份" SortExpression="Year">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Year")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="月份" SortExpression="Month">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Month")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称" SortExpression="ProductName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="规格型号" SortExpression="Specifications">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属仓库">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WareHouseName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量" SortExpression="InitialCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InitialCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="InitialMoney">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InitialMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量" SortExpression="StorageCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("StorageCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="StorageMoney">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("StorageMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量" SortExpression="DeliveryCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="DeliveryMoney">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量" SortExpression="InventoryCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InventoryCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="InventoryMoney">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InventoryMoney")%>
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
                <asp:Button ID="BtnInventoryStatistics" runat="server" Text="月库存统计导出" OnClick="BtnInventoryStatistics_Click"  SkinID="button6"  />
            </td>
        </tr>
    </table>
</asp:Content>
