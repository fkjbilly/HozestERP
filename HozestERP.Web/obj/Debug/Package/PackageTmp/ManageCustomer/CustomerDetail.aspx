<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEditNoUpdatePanel.Master"
    AutoEventWireup="true" CodeBehind="CustomerDetail.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.CustomerDetail" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEditNoUpdatePanel.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="detailTitle">基本信息</span>
    <hr size="1" style="color: #cccccc;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <th width="100px" align="right">
                    归属部门
                </th>
                <td colspan="3">
                    <asp:Literal ID="lblDepartment" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    在职状态
                </th>
                <td width="200px">
                    <asp:Literal ID="lblCustomerStatus" runat="server"></asp:Literal>
                </td>
                <td width="30%" align="center" rowspan="6">
                    <asp:Image ID="imgProduct" runat="server" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    员工工号
                </th>
                <td width="200px">
                    <asp:Literal ID="lblJobNumber" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    员工姓名
                </th>
                <td width="200px">
                    <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                </td>
                 <th width="100px" align="right">
                    是否生育
                </th>
                <td width="200px">
                    <asp:Literal ID="lblChildbearing" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th align="right">
                    性别
                </th>
                <td width="200px">
                    <asp:Literal ID="lblGender" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    民族
                </th>
                <td width="200px">
                    <asp:Literal ID="lblNationality" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    生肖
                </th>
                <td width="200px">
                    <asp:Literal ID="lblAnimal" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th align="right">
                    户籍地
                </th>
                <td width="200px">
                    <asp:Literal ID="lblRegisteredResidence" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    出生日期
                </th>
                <td width="200px">
                    <asp:Literal ID="lblBirthday" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    婚姻状况
                </th>
                <td width="200px">
                    <asp:Literal ID="lblMarriage" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th align="right">
                    血型
                </th>
                <td width="200px">
                    <asp:Literal ID="lblBloodType" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    政治面貌
                </th>
                <td width="200px">
                    <asp:Literal ID="lblPoliticalStatus" runat="server"></asp:Literal>
                </td>
                <th width="100px" align="right">
                    身高
                </th>
                <td width="200px">
                    <asp:Literal ID="lblStature" runat="server"></asp:Literal>CM
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>
