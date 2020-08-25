<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMJingMoTongJi.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMJingMoTongJi" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/UpdaeProcess.ascx" TagName="UpdateProcess" TagPrefix="SHIBR" %>
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
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 70px" align="right">
                开始日期:
            </td>
            <td style="width: 120px;">
                <input id="ddlBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 70px" align="right">
                结束日期:
            </td>
            <td style="width: 120px;">
                <input id="ddlEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 70px" align="right">
                组别:
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlGroupID" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 70px" align="right">
                姓名:
            </td>
            <td style="width: 120px;">
                <asp:TextBox runat="server" ID="ddlName" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 70px" align="right">
                项目名称:
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 70px" align="right">
                店铺名称
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlNick" Width="90%" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" colspan="12" >
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMJingMoTongJi.Search %>" />
                <%--   <asp:Button ID="btnExport" runat="server" Text="导出" OnClick="btnExport_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMPreSalesSalaryList.Export %>" />--%>
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdDId" Value='<%# Eval("ID")%>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="25px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="组别" SortExpression="Group">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblGroup" runat="server" Text='<%# Eval("Group")==null?"":Eval("Group").ToString().Length>15?Eval("Group").ToString().Substring(0,15)+"..":Eval("Group").ToString()%>'
                        ToolTip='<%# Eval("Group") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="Name">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")==null?"":Eval("Name").ToString().Length>15?Eval("Name").ToString().Substring(0,15)+"..":Eval("Name").ToString()%>'
                        ToolTip='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单数量" SortExpression="OrderCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblOrderCount" runat="server" Text='<%# Eval("OrderCount")==null?"":Eval("OrderCount").ToString()%>'
                        ToolTip='<%# Eval("OrderCount") %>'></asp:Label>
                    <%--<%#Eval("OrderCount")%>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单金额" SortExpression="OrderPrice">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblOrderPrice" runat="server" Text='<%# Eval("OrderPrice")==null?"":Eval("OrderPrice").ToString()%>'
                        ToolTip='<%# Eval("OrderPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
