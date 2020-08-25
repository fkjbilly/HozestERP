<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="BudgetSettingList.aspx.cs" Inherits="HozestERP.Web.ManageSystem.BudgetSettingList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script type="text/javascript">
    
    </script>
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
            <td style="width: 80px">
                科目名称：
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtName" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
                是否为管理费用：
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlIsCost" Width="100%" runat="server">
                    <asp:ListItem Value="-1">--所有--</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="11">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript"></script>
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound">
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
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="InfoID" Value='<%#Eval("ID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预算科目名称" SortExpression="Name">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="管理费用" HeaderStyle-HorizontalAlign="Center" SortExpression="IsCost">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="ickIsCost" runat="server" Checked='<%# Eval("IsCost")==null?false: Eval("IsCost")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageSystem.BudgetSettingList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageSystem.BudgetSettingList.Delete %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 8px; width: 20px;">
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageSystem.BudgetSettingList.Add %>" />
            </td>
            <td style="width: 50px;">
                <div id="DIV1" runat="server">
                    <asp:Button ID="btnAudit" runat="server" SkinID="button6" Text="加入管理费用" Visible="<% $CRMIsActionAllowed:ManageSystem.BudgetSettingList.Audit %>"
                        OnClick="btnAudit_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                <div id="DIV2" runat="server">
                    <asp:Button ID="btnNoAudit" runat="server" SkinID="button6" Text="退出管理费用" Visible="<% $CRMIsActionAllowed:ManageSystem.BudgetSettingList.NoAudit %>"
                        OnClick="btnNoAudit_Click" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
