<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMExpressManageAdd.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.XMExpressManageAdd" %>

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
                                <span style="font-size: 18px; font-family: 隶书;">快递信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                快递公司：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:DropDownList ID="ddlExpress" runat="server" Width="91%" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                寄件单号：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtCourierNumber" Style="width: 90%;" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                寄件部门：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:DropDownList ID="ddlDepartment" runat="server" Width="91%" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                寄件人：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtSender" Style="width: 90%;" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                收件人：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtReceivingName" Style="width: 90%;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                收件单位：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtReceivingCompany" Style="width: 90%;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                收件人电话：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtReceivingTel" Style="width: 90%;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                地区：
                            </td>
                            <td style="text-align: left; width: 180px;">
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
                            <td style="text-align: right; width: 50px;">
                                地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtAddress" Style="width: 90%; height: 45px;" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                价格：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtPrice" Style="width: 90%;" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                内件：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtGoods" Style="width: 90%; height: 37px;" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 50px;">
                                备注：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtRemarks" Style="width: 90%; height: 47px;" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
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
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
