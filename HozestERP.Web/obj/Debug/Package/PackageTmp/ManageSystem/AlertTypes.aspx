<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="AlertTypes.aspx.cs" Inherits="HozestERP.Web.ManageSystem.AlertTypes" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">
                提示类型
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtRmdnameSearch" runat="server" MaxLength="50"></asp:TextBox>
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
    <asp:GridView ID="grdAlertTypes" runat="server" Width="100%" AutoGenerateColumns="False"
        DataKeyNames="ID" SkinID="GridViewThemen" 
        OnRowUpdating="grdAlertTypes_RowUpdating" OnRowEditing="grdAlertTypes_RowEditing"
        OnRowCancelingEdit="grdAlertTypes_RowCancelingEdit" OnRowDeleting="grdAlertTypes_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemStyle Width="500px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <%#(Container.DataItem as Sys_AlertSettings).Rmdname %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtRmdname" runat="server"  Text='<%#Eval("Rmdname") %>'  Width="100%" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemStyle Width="500px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <%#(Container.DataItem as Sys_AlertSettings).Remarks %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtRemarks" runat="server"  Text='<%#Eval("Remarks") %>'  Width="100%" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="lbtEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        CommandName="Edit" CausesValidation="False"  />
                    <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="lbtUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        CommandName="Update" CausesValidation="True" />
                    <asp:ImageButton ID="LinkButton2" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        CommandName="Cancel" CausesValidation="False" /></EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
   
</asp:Content>
