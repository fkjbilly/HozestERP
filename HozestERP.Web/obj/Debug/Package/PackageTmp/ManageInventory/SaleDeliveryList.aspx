<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="SaleDeliveryList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.SaleDeliveryList" %>

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
        .AdjustFactoryPriceImg
        {
            width: 16px;
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px; text-align: right;">
                出库单号:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtPurChaseCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right">
                制单日期
            </td>
            <td style="width: 100px">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 100px">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 50px; text-align: right;">
                销售单号
            </td>
            <td style="width: 100px;">
                <asp:TextBox ID="txtSaleRef" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                业务员
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlBizPerson" runat="server" Width="90%">
                </asp:DropDownList>
            </td>
            <td style="width: 50px; text-align: right;">
                状态:
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="待出库" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已出库" Value="1000"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 50px; text-align: right;">
                项&nbsp;&nbsp;目
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right;">
                出库仓库
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlWareHourses" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="8">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />&nbsp;
                <asp:Button ID="btnExport" runat="server" SkinID="button6" Text="导出销量明细" OnClick="btnExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.Export %>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvSaleDelivery" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvSaleDelivery_RowDataBound" OnRowCommand="grdvSaleDelivery_RowCommand"
        ShowFooter="true">
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
                        出库单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        销售单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        仓库
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        店铺
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务员
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        支付方式
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        录单人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        录单时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        审核状态
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        状态
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
            <asp:TemplateField HeaderText="出库单号" SortExpression="Ref">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Ref")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售单号" SortExpression="SaleRef">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SaleRef")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="仓库" SortExpression="WareHouseName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("WareHouseName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺" SortExpression="NickName">
                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("NickName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="SaleMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SaleMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务员" SortExpression="Contact">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizUserId") == null ? "" : CustomerName(Eval("BizUserId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务时间" SortExpression="BizDt">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizDt")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="支付方式">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("PayType")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="录单人">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateID") == null ? "" : CustomerName(Eval("CreateID").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核状态" SortExpression="IsAudit">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsAudit" runat="server" Width="20%" Checked='<%# Eval("IsAudit")==null? false :  Eval("IsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态" SortExpression="BillStatus">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BillStatus").ToString()=="0"?"待出库":"已出库"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgProductDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="查看销售出库单" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.ProductDetails %>" />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑销售出库单" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.Delete %>" OnClientClick="return confirm('您确定要删除此条记录？');" />
                    <asp:ImageButton ID="imgSaleReturned" runat="server" ToolTip="生成销售退货单" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.SaleReturned %>"
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
                <asp:Button ID="btnDeliveryIsAudit" SkinID="button4" runat="server" Text="审核" OnClick="btnDeliveryIsAudit_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.DeliveryIsAudit %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDeliveryIsAuditFalse" SkinID="button4" runat="server" Text="反审核"
                    OnClick="btnDeliveryIsAuditFalse_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.DeliveryIsAuditFalse %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelivery" SkinID="button4" runat="server" Text="提交出库" OnClick="btnDelivery_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.SubmitDelivery %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImortDelivery" SkinID="button6" runat="server" Text="京东销量导入" Visible="<% $CRMIsActionAllowed:ManageInventory.SaleDeliveryList.btnImortDelivery %>" />
            </td>
        </tr>
    </table>
</asp:Content>
