<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="Enterprises.aspx.cs" Inherits="HozestERP.Web.ManageSystem.Enterprises" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">
                名称
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:600px;dialogHeight:290px;scroll:no;center:yes;");
            return true;
        }
    </script>
    <asp:GridView ID="grdEnterprise" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="EntId"
        SkinID="GridViewThemen" OnRowDataBound="grdNotice_RowDataBound" OnRowCommand="grdNotice_RowCommand">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EntName" HeaderText="名称">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EntTel" HeaderText="电话">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EntFax" HeaderText="传真">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EntAddress" HeaderText="地址">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EntEmail" HeaderText="电子邮件">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EntBank" HeaderText="开户行">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
                        <asp:BoundField DataField="EntBankAccount" HeaderText="账号">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("EntId") %>'
                        SkinID="btnDetail" CommandName="Detail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" OnClientClick="return ShowDetail('EnterprisesDetails.aspx');" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" OnClientClick="return confirm('您确定要删除.');" />
            </td>
        </tr>
    </table>
</asp:Content>
