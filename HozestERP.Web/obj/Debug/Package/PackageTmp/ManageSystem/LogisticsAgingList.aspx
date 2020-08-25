<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="LogisticsAgingList.aspx.cs" Inherits="HozestERP.Web.ManageSystem.LogisticsAgingList" %>

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
            <td style="width: 70px">
                始发城市:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtDepartureCity" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px;">
            </td>
            <td style="width: 70px" align="right">
                目的城市:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtDestinationCity" runat="server" Width="100%">
                </asp:TextBox>
            </td>
            <td style="width: 20px;">
            </td>
            <td style="width: 70px" align="right">
                途径城市:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtPathway" runat="server" Width="100%">
                </asp:TextBox>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="线路" SortExpression="Line">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Line")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="始发省" SortExpression="DepartureProvince">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DepartureProvince")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="始发城市" SortExpression="DepartureCity">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DepartureCity")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="途径城市" SortExpression="Pathway">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Pathway")==null?"":Eval("Pathway")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预计到达时效" SortExpression="PathwayDate">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PathwayDate") == null ? "" : Eval("PathwayDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目的省" SortExpression="DestinationProvince">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DestinationProvince")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目的城市" SortExpression="DestinationCity">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DestinationCity")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预计到达时效" SortExpression="DestinationDate">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DestinationDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="南方北方" SortExpression="IsSouth">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (bool)Eval("IsSouth")== true? "南方":"北方"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="ToEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageSystem.LogisticsAgingList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="ToDelete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageSystem.LogisticsAgingList.Delete %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageSystem.LogisticsAgingList.Add %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImport" runat="server" Text="导入" Visible="<% $CRMIsActionAllowed:ManageSystem.LogisticsAgingList.btnImport %>" />
            </td>
        </tr>
    </table>
</asp:Content>
