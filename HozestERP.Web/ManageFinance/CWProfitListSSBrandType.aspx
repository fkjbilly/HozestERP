<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="CWProfitListSSBrandType.aspx.cs" Inherits="HozestERP.Web.ManageFinance.CWProfitListSSBrandType" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .TDLeft
        {
            font-weight: bold;
            text-align: left;
        }
        .TDRight
        {
            text-align: right;
        }
        
        .TDValue
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <%-- 条件查询--%>
        <tr>
            <td colspan="2" style="width: 100%">
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td style="width: 80px">
                            项目类型:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlXMProjectTypeId" runat="server" Width="100%" Enabled="true"
                                OnSelectedIndexChanged="ddlXMProjectTypeId_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td style="width: 90px">
                            项目名称:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlXMProjectNameId" runat="server" Width="100%" Enabled="true"
                                OnSelectedIndexChanged="ddlXMProjectNameId_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td style="width: 90px">
                            店铺名称:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlNickList" runat="server" Width="100%" Enabled="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td style="width: 80px">
                            平台类型:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%" Enabled="true"
                                OnSelectedIndexChanged="ddlPlatformTypeId_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px">
                            时间类型:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="100%" Enabled="true">
                                <asp:ListItem Value="1" Text="创单时间"></asp:ListItem>
                                <asp:ListItem Value="2" Text="付款时间"></asp:ListItem>
                                <asp:ListItem Value="3" Text="发货时间"></asp:ListItem>
                                <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td style="width: 40px">
                            品牌:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlBrandType" runat="server" Width="100%" Enabled="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td style="width: 80px">
                            时间
                        </td>
                        <td style="width: 120px" nowrap="nowrap">
                            <HozestERP:DatePicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                            </HozestERP:DatePicker>
                        </td>
                        <td>
                            至
                        </td>
                        <td style="width: 120px" nowrap="nowrap">
                            <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                            </HozestERP:DatePicker>
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td style="text-align: right">
                            <%--<asp:Button ID="btnOrderInfoSalesDetailsExport" runat="server" Text="导出" SkinID="button2"
                                CssClass="reachedAndGoal" OnClick="btnOrderInfoSalesDetailsExport_Click" Visible="<% $CRMIsActionAllowed:XMProductManage.CWProfitList.Export %>" />--%>
                            &nbsp; &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                                OnClick="btnRefresh_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <%--列表--%>
        <tr>
            <td style="width: 100%;">
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                <ContentTemplate>
                                    <table border="1" cellpadding="2" cellspacing="2" style="width: 100%">
                                        <tr style="background-color: rgb(220,220,220); font-weight: bold; text-align: center;">
                                            <td rowspan="2">
                                                营业收入
                                            </td>
                                            <td rowspan="2">
                                                退款金额
                                            </td>
                                            <%--<td rowspan="2">
                                                增值税
                                            </td>--%>
                                            <td colspan="2">
                                                营业成本：<asp:Label ID="lblYYCBMonthMoney" runat="server"></asp:Label>
                                            </td>
                                            <%--<td rowspan="2">
                                                广告费
                                            </td>
                                            <td rowspan="2">
                                                毛利
                                            </td>
                                            <td rowspan="2">
                                                毛利率
                                            </td>--%>
                                        </tr>
                                        <tr style="background-color: rgb(220,220,220); text-align: center;">
                                            <td>
                                                进货成本
                                            </td>
                                            <td>
                                                退货成本
                                            </td>
                                            <%--<td>
                                                赠品成本
                                            </td>
                                            <td width="120">
                                                运费
                                            </td>
                                            <td>
                                                刷拍成本
                                            </td>
                                            <td>
                                                返现成本
                                            </td>
                                            <td>
                                                平台扣点
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lblYYSRMonthMoney" runat="server" ToolTip="查看订单明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lblReturnMoney" runat="server" ToolTip="查看退款金额明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <%--<td>
                                                <asp:Label ID="lblZZSMonthMoney" runat="server"></asp:Label>
                                            </td>--%>
                                            <td>
                                                <asp:LinkButton ID="lblJHCBMonthMoney" runat="server" ToolTip="查看产品明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lblReturnCost" runat="server" ToolTip="查看退货成本明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <%--<td>
                                                <asp:LinkButton ID="lblZPCBMonthMoney" runat="server" ToolTip="查看赠品明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtYFMonthMoney" runat="server" ReadOnly="true" Width="98%" Style="text-align: right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lblSPCBMonthMoney" runat="server" ToolTip="查看刷单明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lblFXCBMonthMoney" runat="server" ToolTip="查看返现明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lblPTCBFYMonthMoney" runat="server" ToolTip="查看平台费用明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lblFEEMoney" runat="server" ToolTip="查看广告费用明细" Style="color: Blue;
                                                    text-decoration: underline;"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMLMonthMoney" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMLBL" runat="server"></asp:Label>
                                            </td>--%>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50%;">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
        </tr>
    </table>
</asp:Content>
