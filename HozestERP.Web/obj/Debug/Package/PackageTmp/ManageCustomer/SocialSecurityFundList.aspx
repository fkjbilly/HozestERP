<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="SocialSecurityFundList.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.SocialSecurityFundList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
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
            <td style="width: 50px">
                部门：
            </td>
            <td style="width: 200px;">
                <asp:DropDownList ID="ddlDepartment" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 50px">
                姓名：
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtFullName" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 50px">
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
            <td style="width: 50px">
                月份：
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                    <asp:ListItem Value="-1">--全年--</asp:ListItem>
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
    <table>
        <tr>
            <td valign="top" style="border-right: none;">
                <div style="height: 100%; width: 600px; border: 0px; margin-top：0px;" id="DivFrozen">
                    <%=TableStr %>
                </div>
            </td>
            <td valign="top" style="border-left: none;">
                <div style="overflow: scroll; height: 100%; width: 650px; border: 0px;" id="DivGridView">
                    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound" OnRowCreated="grdvClients_RowCreated">
                        <Columns>
                            <%--                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="50px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="年月" SortExpression="YearMonth">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("YearMonth")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名" SortExpression="FullName">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("FullName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="部门性质" SortExpression="ParentDepName">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("ParentDepName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="部门" SortExpression="DepartmentName">
                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("DepartmentName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="管理职级" SortExpression="RankManagement">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("RankManagement")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="岗位" SortExpression="Post">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("Post")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="户籍" SortExpression="HouseholdRegister">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("HouseholdRegister")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="险种" SortExpression="InsuranceType">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("InsuranceType")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="养老基数" SortExpression="PensionBase">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("PensionBase")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="养老公司部分" SortExpression="PensionCompany">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("PensionCompany")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="养老个人部分" SortExpression="PensionPerson">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("PensionPerson")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="医疗基数" SortExpression="MedicalCareBase">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("MedicalCareBase")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="医疗公司部分" SortExpression="MedicalCareCompany">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("MedicalCareCompany")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="医疗个人部分" SortExpression="MedicalCarePerson">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("MedicalCarePerson")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="失业基数" SortExpression="UnemploymentBase">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("UnemploymentBase")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="失业公司部分" SortExpression="UnemploymentCompany">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("UnemploymentCompany")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="失业个人部分" SortExpression="UnemploymentPerson">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("UnemploymentPerson")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="工伤基数" SortExpression="InjuryJobBase">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("InjuryJobBase")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="工伤公司部分" SortExpression="InjuryJobCompany">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("InjuryJobCompany")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="生育基数" SortExpression="BirthBase">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("BirthBase")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="生育公司部分" SortExpression="BirthCompany">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("BirthCompany")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公积金基数" SortExpression="AccumulationFundBase">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("AccumulationFundBase")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公积金公司部分" SortExpression="AccumulationCompany">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("AccumulationCompany")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公积金个人部分" SortExpression="AccumulationFundPerson">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("AccumulationFundPerson")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公司承担" SortExpression="CompanyTotal">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("CompanyTotal")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="个人承担" SortExpression="PersonTotal">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("PersonTotal")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="总计" SortExpression="Total">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("Total")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomer.SocialSecurityFundList.Edit %>" />
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageCustomer.SocialSecurityFundList.Delete %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImportSocialSecurityFund" SkinID="button6" runat="server" Text="导入社保公积金"
                    Visible="<% $CRMIsActionAllowed:ManageCustomer.SocialSecurityFundList.ImportSocialSecurityFund %>" />
            </td>
        </tr>
    </table>
</asp:Content>
