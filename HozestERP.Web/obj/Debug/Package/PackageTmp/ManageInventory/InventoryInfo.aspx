<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="InventoryInfo.aspx.cs" Inherits="HozestERP.Web.ManageInventory.InventoryInfo" %>

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
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
        .AdjustFactoryPriceImg
        {
            width: 16px;
            height: 16px;
        }
        .InventoryAbnormal
        {
            background-color: Red;
        }
        .InventoryNormal
        {
            background-color: Yellow;
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
            <td style="width: 40px; text-align: right">
                项目
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 40px; text-align: right">
                店铺
            </td>
            <td style="width: 80px">
                <asp:DropDownList ID="ddlNick" runat="server" OnSelectedIndexChanged="ddlNick_Change"
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
            <td style="width: 50px; text-align: center">
                销售状态
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlSaleStatus" runat="server">
                    <asp:ListItem Text="所有" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="滞销" Value="1000"></asp:ListItem>
                    <asp:ListItem Text="脱销" Value="1001"></asp:ListItem>
                    <asp:ListItem Text="无销量无库存" Value="1002"></asp:ListItem>
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
        SkinID="GridViewThemen" OnRowDataBound="grdvInventory_RowDataBound" OnRowCommand="grdvInventory_RowCommand"
        ShowFooter="true">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
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
                        所在仓库
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        城市
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        库存数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        可订购数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        库存警戒值
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        销售状态
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        入仓量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        更新时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        操作
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
            <asp:TemplateField HeaderText="厂家编码" SortExpression="PlatformMerchantCode">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PlatformMerchantCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称" SortExpression="ProductName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="规格型号" SortExpression="Specifications">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所在仓库" SortExpression="WfName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WfName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="城市" SortExpression="CityName">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  getCityName(Eval("WfId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存数量" SortExpression="StockNumber">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("StockNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="可订购数量" SortExpression="CanOrderCount">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CanOrderCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存警戒值" SortExpression="WarningValue">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WarningValue")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售状态">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Literal ID="ltSaleStatus" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入仓量" SortExpression="CanStorageCount">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CanStorageCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryInfo.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryInfo.Delete %>" OnClientClick="return confirm('您确定要删除此条记录？');" />
                    <asp:ImageButton ID="ImageBarcodeDetail" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/details.gif"
                        ToolTip="查看产品条形码" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryInfo.BarcodeDetail %>" />
                     <asp:ImageButton ID="imgStoragedSetReturn" runat="server" ToolTip="已入库生成退货单" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryInfo.StoragedSetReturn %>"
                        ImageUrl="~/images/u39_original.png" />
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
                  <asp:Button ID="btnExport" runat="server" SkinID="button6" Text="导出库存数据" OnClick="btnExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryInfo.Export %>" />
            </td>
        </tr>
    </table>
</asp:Content>
