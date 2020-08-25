<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="InventoryAcountDetail.aspx.cs" Inherits="HozestERP.Web.ManageInventory.InventoryAcountDetail" %>

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
            <td style="width: 80px; text-align: right">
                业务日期
            </td>
            <td style="width: 120px">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 120px">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
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
    <asp:GridView ID="grdvInventoryLedgerDetail" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" ShowFooter="true" OnRowDataBound="grdvInventoryLedgerDetail_RowDataBound">
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
                        余额数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        余额单价
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        余额金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务类型
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务单号
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
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单位" SortExpression="ProductUnit">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("ProductUnit")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库数量" SortExpression="InCount">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InCount")%>
                </ItemTemplate>
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
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库数量" SortExpression="OutCount">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OutCount")%>
                </ItemTemplate>
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
            </asp:TemplateField>
            <asp:TemplateField HeaderText="余额数量" SortExpression="BalanceCount">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BalanceCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="余额单价" SortExpression="BalancePrice">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BalancePrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="余额金额" SortExpression="BalanceMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BalanceMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务人">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizUserId") == null ? "" : CustomerName(Eval("BizUserId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务类型">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("RefType") == null ? "" : GetRefType(Eval("RefType").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务时间" SortExpression="BizDate">
                <HeaderStyle Width="85px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizDate") == "" ? DateTime.Now.ToShortDateString() : Convert.ToDateTime(Eval("BizDate")).ToShortDateString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务单号" SortExpression="RefNumber">
                <HeaderStyle Width="95px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("RefNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
