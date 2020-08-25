<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMPayRequestList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMPayRequestList" %>

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
        .pointor
        {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                采购单号：
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtPurchaseRef" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 80px">
                申请人：
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtRequester" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 80px">
                申请时间
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
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                财务审核：
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlFinancialStatus" runat="server" Width="90%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                </asp:DropDownList>
            </td>
<%--            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                公司审核：
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddIsAudit" runat="server" Width="90%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                </asp:DropDownList>
            </td>--%>
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                财务确认：
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddFinanceOkIsAudit" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
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
    <asp:GridView ID="gvPayRequest" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="gvPayRequest_RowCommand" OnRowDataBound="gvPayRequest_RowDataBound"
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
                        采购单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        申请部门
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        付款方式
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        用款日期
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        银行账号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        财务审核
                    </th>
<%--                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        公司审核
                    </th>--%>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        财务确认
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        申请人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        申请日期
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
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="采购单号" SortExpression="PurchaseRef">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:HyperLink ID="hlPurchaseInfo" runat="server" Text='<%# Eval("PurchaseRef")%>'  CssClass="pointor"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请部门">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# getDepartment(Eval("ApplicantID").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="PayAmounts">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PayAmounts")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="付款方式" SortExpression="PayMentName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PayMentName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用款日期" SortExpression="UserDate">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("UserDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="银行账号" SortExpression="BankAcount">
                <HeaderStyle Width="85px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BankAcount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="财务审核" SortExpression="FinancialStatus">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceIsAudit" runat="server" Width="20%" Checked='<%# Eval("FinancialStatus")%>' />
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText="公司审核" SortExpression="IsAudit">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsAudit" runat="server" Width="20%" Checked='<%# Eval("IsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="财务确认" SortExpression="FinancialConfirm">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceIsConfirm" runat="server" Width="20%" Checked='<%# Eval("FinancialConfirm")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请人" SortExpression="Requester">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Requester")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请日期" SortExpression="RequstDate">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("RequstDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.Edit%>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.Del%>" />
                    <asp:ImageButton ID="imagebtnPrint" runat="server" ToolTip="打印查看" ImageUrl="~/App_Themes/Default/Image/print.gif" />
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
                <asp:Button ID="btnFinanceIsAudit" SkinID="button4" runat="server" Text="财务审核" OnClick="btnFinanceIsAudit_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.FinanceIsAudit %>" />
            </td>
            <td>
                <asp:Button ID="btnFinanceIsAuditNO" SkinID="button4" runat="server" Text="财务反审核"
                    OnClick="btnFinanceIsAuditNO_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.FinanceIsAuditNO %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsAudit" SkinID="button4" runat="server" Text="公司审核" OnClick="btnIsAudit_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.IsAudit %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsAuditNO" SkinID="button4" runat="server" Text="公司反审核" OnClick="btnIsAuditNO_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.IsAuditNO %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="hidBtnFinanceOkF" runat="server" SkinID="button4" Text="财务确认" ToolTip="财务确认"
                    OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')" OnClick="hidBtnFinanceOkF_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMPayRequestList.FinanceOkF %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td style="height: 8px; width: 20px;">
                <asp:Button ID="btnAdd" runat="server" Text="新增" SkinID="button4" />
            </td>
        </tr>
    </table>
</asp:Content>
