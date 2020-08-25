<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMActivtyTypeInfo.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMActivtyTypeInfo" %>

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
                活动类型
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtActivityType" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
                <asp:Button ID="btnActivityTypeAdd" SkinID="button6" runat="server" Text="新建活动类型" Visible="<% $CRMIsActionAllowed:ManageInventory.XMActivtyTypeInfo.Add%>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvActivityType" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  OnRowDataBound="grdvActivityType_RowDataBound"
    OnRowCommand="grdvActivityType_RowCommand"     SkinID="GridViewThemen" ShowFooter="true">
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
                        活动类型
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        创建时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        创建人
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
            <asp:TemplateField HeaderText="活动类型" SortExpression="ActivityName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ActivityName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创建时间" SortExpression="CreateDate">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("CreateDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否可用">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                        <%# Eval("CreateID") == null ? "" : CustomerName(Eval("CreateID").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
                <ItemTemplate>
                        <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.XMActivtyTypeInfo.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.XMActivtyTypeInfo.Delete %>"
                        OnClientClick="return confirm('您确定要删除此条记录？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
