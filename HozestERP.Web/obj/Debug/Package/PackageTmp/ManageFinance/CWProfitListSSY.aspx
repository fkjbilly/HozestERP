<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="CWProfitListSSY.aspx.cs" Inherits="HozestERP.Web.ManageFinance.CWProfitListSSY" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
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
                            部门类型:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlDepartmentType" runat="server" Width="100%" OnSelectedIndexChanged="ddlDepartmentType_SelectedIndexChanged"
                                AutoPostBack="true">
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
                            项目类型:
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList ID="ddlXMProjectTypeId" runat="server" Width="100%" Enabled="true"
                                OnSelectedIndexChanged="ddlXMProjectTypeId_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            年份：
                        </td>
                        <td style="width: 40px">
                            <input id="txtYearStr" onfocus="WdatePicker({dateFmt:'yyyy'})" class="Wdate" runat="server"
                                style="width: 100%;" />
                        </td>
                        <td style="width: 40px">
                        </td>
                        <td>
                            月份：
                        </td>
                        <td style="width: 40px">
                            <input id="txtMonthStr" onfocus="WdatePicker({dateFmt:'M'})" class="Wdate" runat="server"
                                style="width: 100%;" />
                        </td>
                        <td colspan="5">
                        </td>
                        <td>
                            <asp:Button ID="btnOrderInfoSalesDetailsExport" runat="server" Text="导出" SkinID="button2"
                                CssClass="reachedAndGoal" OnClick="btnOrderInfoSalesDetailsExport_Click" Visible="<% $CRMIsActionAllowed:XMProductManage.CWProfitList.Export %>" />
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
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="FinancialFieldId"
        SkinID="GridViewThemen" OnRowDataBound="grdvClients_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="财务科目">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FinancialFieldName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目标">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("MonthTarget")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="实际">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("MonthTotal")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="全年预算">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("YearTarget")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="全年累计">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("YearTotal")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="查看明细">
                <HeaderStyle Width="10px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgInfoDetail" runat="server" ImageUrl="~/App_Themes/Default/Image/icon_select.gif"
                        ToolTip="查看明细" CommandArgument='<%# Eval("FinancialFieldId") %>' CommandName="InfoDetail"
                        Visible="<% $CRMIsActionAllowed:ManageFinance.CWProfitListSSY.SearchInfoDetail %>">
                    </asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
