<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="OpenProfitOtherDataInput.aspx.cs" Inherits="HozestERP.Web.ManageFinance.OpenProfitOtherDataInput" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript"> 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellspacing="0">
        <tr>
            <td style="width: 70px; height: 30px;" align="right">
                年份:
            </td>
            <td width="150px" align="center">
                <asp:Label ID="lblYear" runat="server"> </asp:Label>
            </td>
            <td style="width: 70px; height: 30px;" align="right">
                月份:
            </td>
            <td width="150px" align="center">
                <asp:Label ID="lblMonth" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 70px; height: 30px;" align="right">
                项目:
            </td>
            <td width="150px" align="center">
                <asp:Label ID="lblProject" runat="server"> </asp:Label>
            </td>
            <td style="width: 70px; height: 30px;" align="right">
                店铺:
            </td>
            <td width="150px" align="center">
                <asp:Label ID="lblNick" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table>
                    <tr>
                        <td style="height: 30px;" align="right">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label><font color="red">*</font>:
                        </td>
                        <td align="center">
                            <HozestERP:SimpleTextBox ID="txtProjectExplanationValue" runat="server" ValidationGroup="ModuleValidationGroup"
                                ErrorMessage="为必填！" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="text-align: right;">
                <asp:Button ID="Button1" SkinID="Button2" runat="server" Text="确定" OnClick="btnSave_Click"
                    ValidationGroup="ModuleValidationGroup" />
            </td>
        </tr>
    </table>
</asp:Content>
