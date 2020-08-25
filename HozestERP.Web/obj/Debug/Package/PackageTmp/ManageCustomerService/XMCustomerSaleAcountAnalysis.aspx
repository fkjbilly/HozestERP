<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMCustomerSaleAcountAnalysis.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMCustomerSaleAcountAnalysis" %>

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
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 40px">
                平台
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 80px">
                店铺名称
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 80px">
                付款时间
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 10px">
                &nbsp;&nbsp;至&nbsp;&nbsp;
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td style="width: 60px">
                客服小组
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlGroupID" runat="server" Width="100%" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlGroupID_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 80px">
                售前客服
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <asp:DropDownList ID="ddlCustomerService" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="9">
                <div id="DIVSearch" runat="server" style="float: right;">
                    <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                        OnClick="btnRefresh_Click" />
                    <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:XMCustomerSaleAcountAnalysis.Search %>"
                        OnClick="btnSearch_Click" />
                </div>
            </td>
            <td style="width: 20px">
                <asp:Button ID="btnDaochu" runat="server" Text="导出" Visible="<% $CRMIsActionAllowed:XMCustomerSaleAcountAnalysis.Daochu %>"
                    OnClick="btnDaochu_Click" />
            </td>
        </tr>
        <tr>
            <td style="height: 8px;">
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
            <asp:TemplateField HeaderText="客服小组" SortExpression="Group">
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
            <asp:TemplateField HeaderText="成交量" SortExpression="DealCount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblOrderCount" runat="server" Text='<%# Eval("DealCount")==null?"":Eval("DealCount").ToString()%>'
                        ToolTip='<%# Eval("DealCount") %>'></asp:Label>
                    <%--<%#Eval("OrderCount")%>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="成交金额" SortExpression="DealMoney">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblOrderPrice" runat="server" Text='<%# Eval("DealMoney")==null?"":Eval("DealMoney").ToString()%>'
                        ToolTip='<%# Eval("DealMoney") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
