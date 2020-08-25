<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="OnLineCustomers.aspx.cs" Inherits="HozestERP.Web.ManageSystem.OnLineCustomers" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">
                是否要启用在线用户
            </td>
            <td style="width: 120px">
                <asp:CheckBox runat="server" ID="cbEnabled"></asp:CheckBox>
            </td>
            <td>
                <asp:Button ID="btnSet" runat="server" Text="设置" onclick="btnSet_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" SkinID="GridViewThemen">
        <Columns>
            <asp:TemplateField HeaderText="用户" ItemStyle-Width="20%">
                <ItemTemplate>
                   <%-- <%# GetCustomerInfo((OnlineUserInfo)Container.DataItem)%>--%>
                     <%#Server.HtmlEncode(Eval("Username").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IP地址" ItemStyle-Width="10%">
                <ItemTemplate>
                    <%#Server.HtmlEncode(Eval("IPAddress").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="区域" ItemStyle-Width="15%">
                <ItemTemplate>
                   <%#Server.HtmlEncode(Eval("countryName").ToString())%>
                   <%-- <%#GetLocationInfo((OnlineUserInfo)Container.DataItem)%>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="登录时间" ItemStyle-Width="10%">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("CreatedOn"), DateTimeKind.Utc).ToString("T")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最后访问时间" ItemStyle-Width="10%">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("LastVisit"), DateTimeKind.Utc).ToString("T")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最后访问页面" ItemStyle-Width="35%">
                <ItemTemplate>
                <a href= "<%#Server.HtmlEncode(Eval("LastPageVisited").ToString())%>" target="_blank"> <%#Server.HtmlEncode(Eval("LastPageVisited").ToString())%></a>
                    <%-- <%#GetLastPageVisitedInfo((OnlineUserInfo)Container.DataItem)%>--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
