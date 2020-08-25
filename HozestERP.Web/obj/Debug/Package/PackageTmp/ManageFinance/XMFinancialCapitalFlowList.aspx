<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMFinancialCapitalFlowList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMFinancialCapitalFlowList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">

        $(function () {
            BindAssociatedPerson();
        })

        function BindAssociatedPerson() {
            var begin = document.getElementById("<%=txtBeginDate.ClientID %>").value;
            var end = document.getElementById("<%=txtEndDate.ClientID %>").value;
            jQuery.ajax({
                url: "xMFinancialCapitalFlow.ashx?action=BindAssociatedPerson",
                contentType: "application/json; charset=utf-8",
                data: "Begin=" + begin + "&End=" + end,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                    var AssociatedPerson = document.getElementById("<%=ddlAssociatedPerson.ClientID %>");
                    AssociatedPerson.options.length = 0;
                    AssociatedPerson.options.add(new Option("---所有---", "-1"));
                    for (var i = 0; i < data.length; i++) {
                        AssociatedPerson.options.add(new Option(data[i].AssociatedPerson, data[i].AssociatedPerson)); //这个兼容IE与firefox
                    }
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            })
        }

        function RecordAssociatedPersonValue() {
            var AssociatedPerson = document.getElementById("<%=ddlAssociatedPerson.ClientID %>").value;
            jQuery.ajax({
                url: "xMFinancialCapitalFlow.ashx?action=RecordAssociatedPersonValue",
                contentType: "application/json; charset=utf-8",
                data: "AssociatedPerson=" + AssociatedPerson,
                type: "GET",
                dataType: "json",
                async: false,
                success: function (data) {
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            })
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 60px; height: 35px;" align="right">
                开始日期:
            </td>
            <td style="width: 100px;">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    onchange="BindAssociatedPerson()" runat="server" style="width: 97%;" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 60px" align="right">
                结束日期:
            </td>
            <td style="width: 100px;">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    onchange="BindAssociatedPerson()" runat="server" style="width: 97%;" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                公司:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlBelongingCompany" Width="100%" runat="server" OnSelectedIndexChanged="ddlBelongingCompany_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                部门:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlBelongingDep" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                项目:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlBelongingProject" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                摘要:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtAbstract" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 70px; height: 35px;" align="right">
                收入/支出:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlFinancialType" Width="100%" runat="server">
                    <asp:ListItem Value="-1">--所有--</asp:ListItem>
                    <asp:ListItem Value="1">收入</asp:ListItem>
                    <asp:ListItem Value="0">支出</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" align="right">
                收款/支付方式:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlPaymentCollectionType" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                审核:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlAudit" Width="100%" runat="server">
                    <asp:ListItem Value="-1">--所有--</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 40px" align="right">
                交款人:
            </td>
            <td style="width: 100px;">
                <%--<asp:TextBox ID="txtAssociatedPerson" Width="90%" runat="server"></asp:TextBox>--%>
                <select id="ddlAssociatedPerson" runat="server" onchange="RecordAssociatedPersonValue()"
                    style="width: 142px;">
                </select>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 50px" align="right">
                收款类别:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlReceivablesType" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 50px" align="right">
                对应预算科目:
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlBudgetType" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="6">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
                &nbsp;
                <asp:Button ID="btnExport" runat="server" SkinID="button4" Text="导出数据" OnClick="btnExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.Export %>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
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
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox" OnCheckedChanged="chkSelected_CheckedChanged"
                        AutoPostBack="true"></asp:CheckBox>
                    <asp:HiddenField ID="InfoID" Value='<%#Eval("ID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="日期" SortExpression="Date">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# ((DateTime)Eval("Date")).ToString("yyyy-MM-dd")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收入/支出" SortExpression="IsIncome">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (bool)Eval("IsIncome")==true?"收入":"支出"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="摘要" SortExpression="Abstract">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Abstract")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="交款人/报销人" SortExpression="AssociatedPerson">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("AssociatedPerson")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收款类别" SortExpression="ReceivablesTypeName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReceivablesTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="对应预算科目" SortExpression="BudgetTypeName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BudgetTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="公司" SortExpression="CompanyName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CompanyName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部门" SortExpression="DepartmentIDName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DepartmentIDName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="项目" SortExpression="ProjectName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProjectName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="Amount">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Amount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收款/支付方式" SortExpression="PaymentCollectionTypeName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PaymentCollectionTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注" SortExpression="Remark">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Remark")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核" HeaderStyle-HorizontalAlign="Center" SortExpression="Audit">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="Audit" runat="server" Checked='<%# Eval("Audit")==null?false: Eval("Audit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="ToEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="ToDel" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.Delete %>" />
                    <asp:ImageButton ID="imgBtnClaimedSalePerson" runat="server" ImageUrl="~/App_Themes/Default/Image/33.gif"
                        ToolTip="认领业务员" CommandName="ClaimedSalePerson" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.ClaimedSalePerson %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 8px; width: 20px;">
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.Add %>" />
            </td>
            <td style="width: 50px;">
                <div id="DIV1" runat="server">
                    <asp:Button ID="btnAudit" runat="server" SkinID="button4" Text="审核" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.Audit %>"
                        OnClick="btnAudit_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                <div id="DIV2" runat="server">
                    <asp:Button ID="btnNoAudit" runat="server" SkinID="button4" Text="反审核" Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.NoAudit %>"
                        OnClick="btnNoAudit_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                <asp:Button ID="btnPaymentPerson" runat="server" SkinID="button6" Text="交款人/报销人"
                    Visible="<% $CRMIsActionAllowed:ManageFinance.XMFinancialCapitalFlowList.PaymentPerson %>" />
            </td>
        </tr>
    </table>
</asp:Content>
