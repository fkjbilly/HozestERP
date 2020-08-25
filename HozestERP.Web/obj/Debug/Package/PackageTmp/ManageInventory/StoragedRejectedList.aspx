<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="StoragedRejectedList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.StoragedRejectedList" %>

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
            <td style="width: 60px; text-align: right;">
                退货单号:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtRejectedCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                产品名称:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtProductName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px; text-align: right">
                制单日期
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
            <td style="width: 80px; text-align: right;">
                供应商
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlSupplierList" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                是否审核
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlVerify" runat="server">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="未审核" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已审核" Value="1"></asp:ListItem>
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
    <asp:GridView ID="grdvRejected" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvRejected_RowDataBound" OnRowCommand="grdvRejected_RowCommand"
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
                        退货单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        供应商
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
            <asp:TemplateField HeaderText="退货单号">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("Ref")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="退货仓库" SortExpression="Ref">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#  Eval("ID") == null ? "" : getRejectWareHouses(int.Parse(Eval("ID").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="供应商" SortExpression="SupplierName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("SupplierName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="RejectionMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("RejectionMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务员" SortExpression="Contact">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizUserId") == null ? "" : CustomerName(Eval("BizUserId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务时间" SortExpression="BizDt">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizDt") == null ? DateTime.Now.ToShortDateString() :  Convert.ToDateTime(Eval("BizDt")).ToShortDateString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="支付方式">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PayType")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="录单人">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# CustomerName(Eval("CreateID").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# getIsAudit(Convert.ToInt32(Eval("Id")))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出库状态">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# getStatus(Eval("BillStatus") == null ? "0" : Eval("BillStatus").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgProductDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="查看已入库采购退货单" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.StoragedRejectedList.ProductDetails %>" />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑已入库采购退货单" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.StoragedRejectedList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.StoragedRejectedList.Delete %>"
                        OnClientClick="return confirm('您确定要删除此条记录？');" />
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
                <asp:Button ID="btnIsAudit" SkinID="button4" runat="server" Text="审核" OnClick="btnIsAudit_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.RejectedList.IsAudit %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsAuditFalse" SkinID="button4" runat="server" Text="反审核" OnClick="btnIsAuditFalse_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.RejectedList.IsAuditFalse %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnRejectedDelivery" SkinID="button4" runat="server" Text="提交出库"
                    OnClick="btnRejectedDelivery_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.StoragedRejectedList.SubmitDelivery %>" />
            </td>
        </tr>
    </table>
</asp:Content>
