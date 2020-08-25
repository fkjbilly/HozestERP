<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMOrderInfoHLLList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderInfoHLLList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px">
                项目名称
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                店铺名称
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlNick" Width="90%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                平台类型
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="90%" OnSelectedIndexChanged="ddPlatformTypeId_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                订单状态
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddOrderStatusId" runat="server" Width="90%" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 60px">
                订单编号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                姓名
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtFullName" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                网名
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtWantID" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
            </td>
            <td style="width: 120px">
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 60px; padding-top: 20px;">
                <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="100%" Enabled="true">
                    <asp:ListItem Value="1" Text="创单时间"></asp:ListItem>
                    <asp:ListItem Value="2" Text="付款时间"></asp:ListItem>
                    <asp:ListItem Value="3" Text="发货时间"></asp:ListItem>
                    <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;
            </td>
            <td style="width: 120px">
                <input id="txtPayDateStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 90%;" />
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                到
            </td>
            <td style="width: 120px">
                <input id="txtPayDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 90%;" />
            </td>
            <td colspan="5">
            </td>
            <td style="width: 120px;" style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoList.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                        scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        平台
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        店铺名称
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        订单编号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        网名
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        创单时间
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        姓名
                    </th>
                    <%--<th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        电话
                    </th>--%>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        手机
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        收货地址
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 80px; white-space: nowrap;"
                        scope="col">
                        备注
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        来源
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        财务审核
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        是否排单
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
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
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台" SortExpression="PlatformTypeId">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="PlatformTypeId" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称" SortExpression="NickID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# base.XMNickService.ReturnNickNameByID(int.Parse(Eval("NickID").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单编号" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网名" SortExpression="WantID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WantID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创单时间" SortExpression="PayDate">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("OrderInfoCreateDate")==null?"":DateTime.Parse(Eval("OrderInfoCreateDate").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="FullName">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FullName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="电话" SortExpression="Tel">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Tel")%>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="手机" SortExpression="Mobile">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Mobile")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收货地址">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="来源" SortExpression="SourceType">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SourceType") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否审核">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsAudit" runat="server" Width="20%" Checked='<%# IsAudit(Eval("ID").ToString())%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="财务审核" SortExpression="FinancialAudit">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinancialAudit" runat="server" Width="20%" Checked='<%# Eval("FinancialAudit")==null?true: Eval("FinancialAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否排单">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsSingleRow" runat="server" Width="20%" Checked='<%# IsSingleRow(Eval("ID").ToString())%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnOrderInfoDetail" runat="server" SkinID="btnDetail" ToolTip="详情"
                        CommandArgument='<%# Eval("ID") %>' CommandName="XMOrderInfoDetail" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoHLLList.SeeXMOrderInfoDetail %>">
                    </asp:ImageButton>
                    <asp:ImageButton ID="imgbtnOperatingRecords" runat="server" ToolTip="操作记录" CommandArgument='<%# Eval("ID") %>'
                        CommandName="XMOrderInfoOperatingRecords" ImageUrl="~/App_Themes/Default/Image/Records.png"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoHLLList.OperatingRecords %>">
                    </asp:ImageButton>
                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMOrderInfoDelete"
                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoHLLList.XMOrderInfoDelete %>" />
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
                <asp:Button ID="btnOrderInfoExport" SkinID="button6" runat="server" Text="导出订单数据"
                    OnClick="btnOrderInfoExport_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoHLLList.Export %>" />
            </td>
        </tr>
    </table>
</asp:Content>
