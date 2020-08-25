<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="Settings.aspx.cs" Inherits="HozestERP.Web.ManageSystem.Settings" %>

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
                <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
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
            //var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:600px;dialogHeight:350px;scroll:no;center:yes;");
            layer_show("添加参数", URL, 600, 350);
            return true;
        }
    </script>
    <asp:GridView ID="grdNotice" runat="server" AutoGenerateColumns="False" DataKeyNames="SettingID"
        SkinID="GridViewThemen" OnRowDataBound="grdNotice_RowDataBound" OnRowCommand="grdNotice_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="名称">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="Value" HeaderText="值">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="说明">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle Width="40%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="编辑">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("SettingID") %>'
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
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" OnClientClick="return ShowDetail('SettingsDetails.aspx');" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnClearCache" runat="server" Text="清除缓存" OnClick="btnClearCache_Click" SkinID="button4" />
                <asp:Button ID="btnRefesh" style="display:none" runat="server" Text="刷新" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
   <script type="text/javascript">
       function RefeshGridView() {
           document.getElementById("ctl00_Contentplaceholder3_btnRefesh").click();
       }
   </script>
</asp:Content>
