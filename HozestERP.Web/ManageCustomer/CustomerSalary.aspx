<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="CustomerSalary.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.CustomerSalary" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
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
            <td style="width: 100px">
                部门：
            </td>
            <td style="width: 200px;">
                <asp:DropDownList ID="ddlDepartment" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
                姓名：
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="ddlFullName" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
                年份：
            </td>
            <td style="width: 200px">
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
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
                月份：
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                    <asp:ListItem Value="1">01</asp:ListItem>
                    <asp:ListItem Value="2">02</asp:ListItem>
                    <asp:ListItem Value="3">03</asp:ListItem>
                    <asp:ListItem Value="4">04</asp:ListItem>
                    <asp:ListItem Value="5">05</asp:ListItem>
                    <asp:ListItem Value="6">06</asp:ListItem>
                    <asp:ListItem Value="7">07</asp:ListItem>
                    <asp:ListItem Value="8">08</asp:ListItem>
                    <asp:ListItem Value="9">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="11">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript"></script>
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound"
        ShowFooter="true">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" nowrap="" style="width: 50px; white-space: nowrap;"
                        scope="col">
                        &nbsp;
                    </th>
                    <%--<th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>--%>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        部门
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        姓名
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        身份证号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        性别
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        基本工资
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        绩效工资
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        实发工资
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th>
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%--<a href="javascript:void(0);"><img id='img<%# Eval("Id")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("Id")%>',event)" /></a>--%>
                    <%# Container.DataItemIndex + 1 %>
                    <%--<asp:HiddenField ID="hdDId" Value='<%# Eval("Id")%>' runat="server" />--%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="50px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>  
                </ItemTemplate>
            </asp:TemplateField> --%>
            <asp:TemplateField HeaderText="部门" SortExpression="DepartmentName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DepartmentName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="FullName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FullName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="身份证号" SortExpression="IDNumber">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("IDNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="性别" SortExpression="Gender">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Gender.CodeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="基本工资" SortExpression="BasePay">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BasePay")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="绩效工资" SortExpression="MeritPay">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("MeritPay")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="实发工资" SortExpression="RealSalary">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("RealSalary")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomer.CustomerSalary.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageCustomer.CustomerSalary.Delete %>" />
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
                <asp:Button ID="btnImportCustomerSalary" SkinID="button4" runat="server" Text="导入月薪资"
                    Visible="<% $CRMIsActionAllowed:ManageCustomer.CustomerSalary.ImportCustomerSalary %>" />
            </td>
        </tr>
    </table>
</asp:Content>
