<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEditNoUpdatePanel.Master"
    AutoEventWireup="true" CodeBehind="LogDetails.aspx.cs" Inherits="HozestERP.Web.ManageSystem.LogDetails" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEditNoUpdatePanel.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="detailTitle" style="float: left;">查看活动日志详细信息
        <asp:Button ID="btnClose" runat="server" Text="返回" OnClick="btnClose_Click" />
    </span>
    <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" Style="float: right;
        margin-right: 10px; margin-bottom: 2px;" OnClientClick="return window.confirm('您确定要删除此条日志信息?');" />
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table border="0" cellpadding="0" cellspacing="3" style="width: 100%;" class="detailTable">
        <tbody>
            <tr>
                <th style="width: 100px; text-align: right;">
                    日志类型：
                </th>
                <td>
                    <asp:Literal ID="lblLogType" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    来重程度：
                </th>
                <td>
                    <asp:Literal ID="lblSeverity" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    信息：
                </th>
                <td>
                    <asp:Literal ID="lblMessage" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    异常：
                </th>
                <td>
                    <asp:Literal ID="lblException" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    IP地址：
                </th>
                <td>
                    <asp:Literal ID="lblIPAddress" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    用户：
                </th>
                <td>
                    <asp:Literal ID="lblCustomer" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    来源地址：
                </th>
                <td>
                    <asp:Literal ID="lblPageURL" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    请求地址：
                </th>
                <td>
                    <asp:Literal ID="lblReferrerURL" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; text-align: right;">
                    创建于：
                </th>
                <td>
                    <asp:Literal ID="lblCreatedOn" runat="server"></asp:Literal>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td style="width: 10px">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
