<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMOrderUpdateConsignee.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderUpdateConsignee" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td valign="top">
                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <span style="font-size: 18px; font-family: 隶书;">收货人信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 60px;">
                                预约发货时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtAppointDeliveryTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                                    class="Wdate" runat="server" style="width: 80%;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 60px;">
                                姓名：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtFullName" Style="width: 80%;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 60px;">
                                手机：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtMobile" Style="width: 80%;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 60px;">
                                电话：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtTel" Style="width: 80%;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 60px;">
                                地区：
                            </td>
                            <td style="text-align: left; width: 240px;">
                                <asp:DropDownList ID="ddlProvince" Width="30%" runat="server" OnSelectedIndexChanged="ddlProvince_Changed"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCity" Width="30%" runat="server" OnSelectedIndexChanged="ddlCity_Changed"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCounty" Width="30%" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 60px;">
                                地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtDeliveryAddress" Style="width: 80%; height: 45px;"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="text-align: right; width: 60px;">
                                备用地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtDeliveryAddressSpare" Style="width: 80%; height: 45px;"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>--%>
                    </table>
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
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdateConsignee.ConsigneeSave %>" />
            </td>
        </tr>
    </table>
</asp:Content>
