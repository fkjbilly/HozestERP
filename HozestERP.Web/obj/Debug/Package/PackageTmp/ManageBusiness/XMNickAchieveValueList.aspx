<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMNickAchieveValueList.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.XMNickAchieveValueList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                时间
            </td>
            <td style="width: 120px">
                <input id="txtLogStartTime" runat="server" onfocus="WdatePicker()" class="Wdate"
                    readonly="readonly" />
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                到
            </td>
            <td style="width: 120px">
                <input id="txtLogEndTime" runat="server" onfocus="WdatePicker()" class="Wdate" readonly="readonly" />
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 20px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMNickAchieveValueList.Search %>"
                    OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvNickTitle" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCancelingEdit="gvNickTitle_RowCancelingEdit" OnRowDeleting="gvNickTitle_RowDeleting"
        OnRowEditing="gvNickTitle_RowEditing" OnRowUpdating="gvNickTitle_RowUpdating"
        OnRowDataBound="gvNickTitle_RowDataBound" ShowFooter="true">
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
                        日期
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        销售量
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        销售额
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        客单价
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
                    <asp:HiddenField ID="hdId" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="日期" SortExpression="DateTime">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime")==null?"":DateTime.Parse(Eval("DateTime").ToString()).ToString("yyyy-MM-dd")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="hfLogTime" runat="server" Value=' <%#Eval("DateTime")==null?"":DateTime.Parse(Eval("DateTime").ToString()).ToString("yyyy-MM-dd")%>' />
                    <input id="txtLogTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 90%;" value=' <%#Convert.ToDateTime(Eval("DateTime").ToString()).Year==1?DateTime.Now.ToString("yyyy-MM-dd"):DateTime.Parse(Eval("DateTime").ToString()).ToString("yyyy-MM-dd")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售量" SortExpression="SaleCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SaleCount")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtArriveSalesNum" runat="server" value="0" Width="90%" Text='<%# Eval("SaleCount") %>'></asp:TextBox>
                    <asp:Label ID="lblArriveSalesNum" runat="server" Text="" ForeColor="red"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售额" SortExpression="SalePrice">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SalePrice")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtArriveSalesMoney" value="0" runat="server" Width="90%" Text='<%# Eval("SalePrice") %>'></asp:TextBox>
                    <asp:Label ID="lblArriveSalesMoney" runat="server" Text="" ForeColor="red"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="成本" SortExpression="Cost">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Cost")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCost" value="0" runat="server" Width="90%" Text='<%# Eval("Cost") %>'></asp:TextBox>
                    <asp:Label ID="lblCost" runat="server" Text="" ForeColor="red"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="客单价" SortExpression="GuestUnitPrice">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("GuestUnitPrice")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNickPerTicketSales" runat="server" value="0" Width="90%" Text='<%# Eval("GuestUnitPrice") %>'></asp:TextBox>
                    <asp:Label ID="lblNickPerTicketSales" runat="server" Text="" ForeColor="red"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMNickAchieveValueList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageBusiness.XMNickAchieveValueList.Delete %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMNickAchieveValueList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMNickAchieveValueList.Cancel %>" />
                </EditItemTemplate>
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
                <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" Visible="<% $CRMIsActionAllowed:ManageBusiness.XMNickAchieveValueList.AllDelete %>"
                    OnClientClick="return CheckSelect(this,99);" OnClick="btnDelete_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
            </td>
            <td style="width: 4px">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
