<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="InventoryAcountList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.InventoryAcountList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        
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
            <td style="width: 60px; text-align: right">
                项目
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right">
                店铺
            </td>
            <td style="width: 100px">
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
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvInventoryLedger" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" ShowFooter="true" OnRowDataBound="grdvInventoryLedger_RowDataBound">
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
                        单位
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        仓库
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        在途数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        在途单价
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        在途金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        入库数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        入库单价
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        入库金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        出库数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        出库单价
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        出库金额
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
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单位" SortExpression="ProductUnit">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("ProductUnit")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="仓库" SortExpression="WfName">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("WfName")%>
                </ItemTemplate>
                <FooterTemplate>
                    合计
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="在途数量" SortExpression="AfloatCount">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("AfloatCount")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumAfloatCount" runat="server">100</asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="在途单价" SortExpression="AfloatPrice">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("AfloatPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="在途金额" SortExpression="AfloatMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("AfloatMoney")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumAfloatMoney" runat="server"></asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库数量" SortExpression="InCount">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InCount")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumInCount" runat="server"></asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库单价" SortExpression="InPrice">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库金额" SortExpression="InMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InMoney")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumInMoney" runat="server"></asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库数量" SortExpression="OutCount">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OutCount")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumOutCount" runat="server"></asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库单价" SortExpression="OutPrice">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OutPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库金额" SortExpression="OutMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OutMoney")%>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Literal ID="lblSumOutMoney" runat="server"></asp:Literal>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgInventoryLederDetail" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="库存总账明细" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.InventoryAcountList.imgInventoryLederDetail %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
