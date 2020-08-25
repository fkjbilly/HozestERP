<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMDailySaleInfo.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMDailySaleInfo" %>

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
            <td style="width: 60px; text-align: right;">
                厂家编码
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtPurChaseCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                商品名称
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtPorductName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px; text-align: right">
                销售日期
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
            <td style="width: 60px; text-align: right;">
                项目
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right;">
                店铺
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddlNick" runat="server">
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
    <asp:GridView ID="grdvDailySaleInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" ShowFooter="true"    OnRowCommand="grdvDailySaleInfo_RowCommand">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" scope="col" style="white-space: nowrap;">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        厂家编码
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        商品名称
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        销售日期
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        下单量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        商品浏览量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        访客数
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        下单转换率
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        累计关注量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        加入购物车量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        购物车转换率
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        评价数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        好评数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        好评率
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        站内流量比
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        站外流量比
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
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                    <asp:HiddenField ID="hdSupplierID" Value='<%#Eval("Id")%>' runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="PlatformMerchantCode">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PlatformMerchantCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称" SortExpression="ProductName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("ProductName")%>k
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售日期" SortExpression="CreateDate">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateDate")!=null?Convert.ToDateTime(Eval("CreateDate")).ToShortDateString(): DateTime.Now.ToShortDateString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="下单量" SortExpression="OrderQuantity">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderQuantity")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品浏览量" SortExpression="MerchandiseViewCount">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("MerchandiseViewCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="访客数" SortExpression="VisitorNumber">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("VisitorNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="下单转换率" SortExpression="ConversionRate">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ConversionRate") + "%"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="累计关注量" SortExpression="CumulativeAttention">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CumulativeAttention")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="加入购物车量" SortExpression="AddCartCount">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("AddCartCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="购物车转换率" SortExpression="CartConversionRate">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CartConversionRate") + "%"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="评价数量" SortExpression="EvaluationQuantity">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("EvaluationQuantity")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="好评数量" SortExpression="PraiseQuantity">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PraiseQuantity")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="好评率" SortExpression="PraiseRate">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PraiseRate") + "%"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="站内流量比" SortExpression="FlowRate">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FlowRate") + "%"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="站外流量比" SortExpression="ExterFlowRate">
                <HeaderStyle Width="110px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ExterFlowRate") + "%"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.XMDailySaleInfo.Delete %>" OnClientClick="return confirm('您确定要删除此条记录？');" />
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
                <asp:Button ID="btnImportDaliySale" SkinID="button4" runat="server" Text="导入日销量"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.XMDailySaleInfo.ImportDaliySale %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" Visible="<% $CRMIsActionAllowed:ManageInventory.XMDailySaleInfo.AllDelete %>"
                    OnClientClick="return CheckSelect(this,99);" OnClick="btnDelete_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExportDaliySale" SkinID="button4" runat="server" Text="导出日销量"
                    
                    Visible="<% $CRMIsActionAllowed:ManageInventory.XMDailySaleInfo.ExportDaliySale %>" 
                    onclick="btnExportDaliySale_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
