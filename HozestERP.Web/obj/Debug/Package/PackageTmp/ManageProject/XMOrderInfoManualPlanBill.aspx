<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMOrderInfoManualPlanBill.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderInfoManualPlanBill" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
        <tr>
         <td style="width: 60px; text-align: right;">
                项目
            </td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
            <tr>
                <td style="width: 100px" align="right">
                    发库仓库
                </td>
                <td style="width: 200px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlWareHourses" runat="server" Width="97%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 60px; text-align: right;">
                礼包
                </td>
                <td>
                    <asp:CheckBox ID="chkCodeContain" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
