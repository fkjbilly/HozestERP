<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="SafeInventoryList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.SafeInventoryList" %>

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
       .InventoryGap
       {
           color:Red;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px; text-align: right;">
                厂家编码
            </td>
              <td style="width: 150px;">
                <asp:TextBox ID="txtPlatFormCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                商品名称
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtProductName" runat="server" Width="100%"></asp:TextBox>
            </td>
              <td style="width: 60px; text-align: right;">
                项目
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right">
                店铺
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlNick" runat="server"  OnSelectedIndexChanged="ddlNick_Change"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 50px; text-align: center">
                仓库
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlWareHourses" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvInventory" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" ShowFooter="true" OnRowDataBound="grdvInventory_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        仓库编码
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        仓库
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        厂家编码
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        商品名称
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        规格型号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        库存警戒值
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        当前库存
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        存货缺口
                    </th>
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="仓库编码" SortExpression="WfId">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WfId")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="仓库" SortExpression="WfName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("WfName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="PlatformMerchantCode">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PlatformMerchantCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称" SortExpression="ProductName">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("ProductName").ToString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="规格型号" SortExpression="Specifications">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存警戒值" SortExpression="WarningValue">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WarningValue")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="当前库存" SortExpression="StockNumber">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("StockNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="存货缺口">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblInventoryGap" runat="server" Text="0"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
