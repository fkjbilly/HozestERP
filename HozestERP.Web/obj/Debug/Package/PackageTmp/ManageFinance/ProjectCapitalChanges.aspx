<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="ProjectCapitalChanges.aspx.cs" Inherits="HozestERP.Web.ManageFinance.ProjectCapitalChanges" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 60px">
                年份:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlYear" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                月份:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                    <asp:ListItem Value="-1" Selected="True">---全年---</asp:ListItem>
                    <asp:ListItem Value="1">1月</asp:ListItem>
                    <asp:ListItem Value="2">2月</asp:ListItem>
                    <asp:ListItem Value="3">3月</asp:ListItem>
                    <asp:ListItem Value="4">4月</asp:ListItem>
                    <asp:ListItem Value="5">5月</asp:ListItem>
                    <asp:ListItem Value="6">6月</asp:ListItem>
                    <asp:ListItem Value="7">7月</asp:ListItem>
                    <asp:ListItem Value="8">8月</asp:ListItem>
                    <asp:ListItem Value="9">9月</asp:ListItem>
                    <asp:ListItem Value="10">10月</asp:ListItem>
                    <asp:ListItem Value="11">11月</asp:ListItem>
                    <asp:ListItem Value="12">12月</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px">
                项目:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlProject" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnExport" SkinID="button4" runat="server" Text="导出数据" OnClick="btnExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.ProjectCapitalChanges.Export %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <div align="center" style="width: 100%; border: 0px; margin-top：0px;">
        <p>
        </p>
        <font size='5'><b>
            <%=Title %></b></font>
        <p>
        </p>
        <table align="center" style="width: 70%; border: 1px; background-color: #A52A2A;">
            <tr style="height: 40px; border: 1px;">
                <th style="border: 1px solid; width: 50%;">
                    <font size='4'><b>项目</b></font>
                </th>
                <th style="border: 1px solid; width: 25%;">
                    <font size='4'><b>发生额</b></font>
                </th>
                <th style="border: 1px solid; width: 25%;">
                    <font size='4'><b>累计</b></font>
                </th>
            </tr>
            <%=TableStr %></table>
    </div>
</asp:Content>
