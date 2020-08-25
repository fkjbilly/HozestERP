<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMProjectCostDetail.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMProjectCostDetail" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeOverflow(change) {
            var div = document.getElementById("DivGridView");
            if (change == "1") {
                div.style.overflow = "scroll";
            }
            else {
                div.style.overflow = "hidden";
            }
        }
    
    </script>
    <style type="text/css">
        .headbackground
        {
            background-color: #EEEEEE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                年份：
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlYear" Width="100%" runat="server">
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2024">2024</asp:ListItem>
                    <asp:ListItem Value="2022">2025</asp:ListItem>
                    <asp:ListItem Value="2023">2026</asp:ListItem>
                    <asp:ListItem Value="2024">2027</asp:ListItem>
                    <asp:ListItem Value="2022">2028</asp:ListItem>
                    <asp:ListItem Value="2023">2029</asp:ListItem>
                    <asp:ListItem Value="2024">2030</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 20px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnSetField" runat="server" Text="设置" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.SetFinancialFieldPorject %>" />&nbsp;
                <asp:Button ID="btnIsAudit" SkinID="button4" runat="server" Text="审核" OnClick="btnIsAudit_Click"
                    Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.IsAudit %>" />&nbsp;
                <asp:Button ID="btnIsAuditFalse" SkinID="button4" runat="server" Text="反审核" OnClick="btnIsAuditFalse_Click"
                    Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.IsAuditFalse %>" />&nbsp;
                <asp:Button ID="btnImportCost" SkinID="button4" runat="server" Text="导入数据" 
                    Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.ImportCost %>" /> &nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <div style="height: 100%; width: 30%; border: 0px; display: block; float: left; overflow: hidden;"
        id="DivFrozen">
        <%=TableStr %>
    </div>
    <div style="overflow: scroll; height: 100%; float: left; width: 70%; margin-left: -3px"
        id="DivGridView">
        <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,FinancialFieldID"
            SkinID="GridViewThemen" OnRowCreated="grdvClients_RowCreated" OnRowDataBound="grdvClients_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="1月份" SortExpression="OneMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        1月份
                        <CRM:ImageCheckBox ID="FinancialStatus1" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_1" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("OneMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="2月份" SortExpression="TwoMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        2月份
                        <CRM:ImageCheckBox ID="FinancialStatus2" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_2" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("TwoMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3月份" SortExpression="ThreeMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        3月份
                        <CRM:ImageCheckBox ID="FinancialStatus3" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_3" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("ThreeMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="4月份" SortExpression="FourMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        4月份
                        <CRM:ImageCheckBox ID="FinancialStatus4" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_4" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("FourMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="5月份" SortExpression="FiveMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        5月份
                        <CRM:ImageCheckBox ID="FinancialStatus5" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_5" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("FiveMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="6月份" SortExpression="SixMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        6月份
                        <CRM:ImageCheckBox ID="FinancialStatus6" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_6" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("SixMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="7月份" SortExpression="SevenMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        7月份
                        <CRM:ImageCheckBox ID="FinancialStatus7" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_7" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("SevenMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="8月份" SortExpression="EightMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        8月份
                        <CRM:ImageCheckBox ID="FinancialStatus8" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_8" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("EightMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="9月份" SortExpression="NineMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        9月份
                        <CRM:ImageCheckBox ID="FinancialStatus9" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_9" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("NineMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="10月份" SortExpression="TenMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        10月份
                        <CRM:ImageCheckBox ID="FinancialStatus10" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_10" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("TenMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="11月份" SortExpression="ElevenMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        11月份
                        <CRM:ImageCheckBox ID="FinancialStatus11" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_11" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("ElevenMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="12月份" SortExpression="TwelMonthCost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        12月份
                        <CRM:ImageCheckBox ID="FinancialStatus12" runat="server" Checked='true' Visible="false" />
                        <asp:ImageButton ID="imgBtnEdit_12" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                            ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectCostDetail.Edit %>" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("TwelMonthCost")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--          <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomer.SocialSecurityFundList.Edit %>" />
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageCustomer.SocialSecurityFundList.Delete %>" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
            </Columns>
            <HeaderStyle BorderStyle="None" />
        </asp:GridView>
    </div>
</asp:Content>
