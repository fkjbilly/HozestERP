<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMJDSaleCoefficientManage.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMJDSaleCoefficientManage" %>

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
        .InventoryAbnormal
        {
            background-color: Red;
        }
        .InventoryNormal
        {
            background-color: Yellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 50px; text-align: center">
                月份
            </td>
            <td style="width: 60px">
                <asp:DropDownList ID="ddlMonth" runat="server">
                    <asp:ListItem Text="所有" Value="-1"></asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 40px; text-align: right">
                项目
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 40px; text-align: right">
                店铺
            </td>
            <td style="width: 80px">
                <asp:DropDownList ID="ddlNick" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
                <asp:Button ID="btnSalesTypeAdd" SkinID="button6" runat="server" Text="新建销售系数" Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDSaleCoefficientManage.Add%>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvJDSaleCoeffcient" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" OnRowDataBound="grdvJDSaleCoeffcient_RowDataBound"
        OnRowCommand="grdvJDSaleCoeffcient_RowCommand" ShowFooter="true">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        月份
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        所属店铺
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        系数
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        更新时间
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
            <asp:TemplateField HeaderText="月份" SortExpression="Month">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Month")+"月份"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺" SortExpression="NickName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("NickName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="系数" SortExpression="Value">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("Value")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDSaleCoefficientManage.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDSaleCoefficientManage.Delete %>"
                        OnClientClick="return confirm('您确定要删除此条记录？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
