<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="AreaCode.aspx.cs" Inherits="HozestERP.Web.ManageSystem.AreaCode" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 100px">
                    内容
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtConent" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 120px">
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdAreaCode" runat="server" AutoGenerateColumns="false" SkinID="GridViewThemen" DataKeyNames="xmlid">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="PrePath" HeaderText="全称">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="名称">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Spell" HeaderText="拼音">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="shortening" HeaderText="简称">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Post" HeaderText="邮篇">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AreaID" HeaderText="区号">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CityType" HeaderText="类型">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="是否可用">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox" Checked='<%#bool.Parse(Eval("Enabled").ToString())?true:false%>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnPublished" runat="server" Text="设置" 
                    OnClick="btnPublished_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
