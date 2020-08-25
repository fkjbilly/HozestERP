<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="AlertSettings.aspx.cs" Inherits="HozestERP.Web.ManageSystem.AlertSettings" %>

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
                <asp:TextBox ID="txtRmdname" runat="server" MaxLength="50"></asp:TextBox>
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
    <asp:GridView ID="grdAlertTimeSet" runat="server" Width="100%" AutoGenerateColumns="False"
        DataKeyNames="ID" SkinID="GridViewThemen" OnRowDataBound="grdAlertTimeSet_RowDataBound"
        OnRowUpdating="grdAlertTimeSet_RowUpdating" OnRowEditing="grdAlertTimeSet_RowEditing"
        OnRowCancelingEdit="grdAlertTimeSet_RowCancelingEdit">
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
                    <%#(Container.DataItem as Sys_AlertTimeSet).AlertSettings!=null?(Container.DataItem as Sys_AlertTimeSet).AlertSettings.Rmdname.ToString():""%>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="时间间隔">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemStyle Width="500px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlCycletime" runat="server" SelectedValue='<%# Eval("Cycletime") %>'
                        Enabled="false">
                        <asp:ListItem Text="15分钟" Value="900000"></asp:ListItem>
                        <asp:ListItem Text="半小时" Value="1800000"></asp:ListItem>
                        <asp:ListItem Text="1小时" Value="3600000"></asp:ListItem>
                        <asp:ListItem Text="3小时" Value="10800000"></asp:ListItem>
                        <asp:ListItem Text="6小时" Value="21600000"></asp:ListItem>
                        <asp:ListItem Text="不提示" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCycletime" runat="server" SelectedValue='<%# Eval("Cycletime") %>'>
                        <asp:ListItem Text="15分钟" Value="900000"></asp:ListItem>
                        <asp:ListItem Text="半小时" Value="1800000"></asp:ListItem>
                        <asp:ListItem Text="1小时" Value="3600000"></asp:ListItem>
                        <asp:ListItem Text="3小时" Value="10800000"></asp:ListItem>
                        <asp:ListItem Text="6小时" Value="21600000"></asp:ListItem>
                        <asp:ListItem Text="不提示" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="lbtEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        CommandName="Edit" CausesValidation="False" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="lbtUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        CommandName="Update" CausesValidation="True" />
                    <asp:ImageButton ID="LinkButton2" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        CommandName="Cancel" CausesValidation="False" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
   
</asp:Content>
