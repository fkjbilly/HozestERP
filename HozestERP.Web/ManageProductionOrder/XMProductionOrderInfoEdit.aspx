<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMProductionOrderInfoEdit.aspx.cs" Inherits="HozestERP.Web.ManageProductionOrder.XMProductionOrderInfoEdit" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 310px;" valign="top">
                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <span style="font-size: 18px; font-family: 隶书;">基础信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                平台：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label runat="server" ID="lblPlatformTypeId"></asp:Label>
                                <input id="hfPlatformTypeId" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                店铺：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label runat="server" ID="lblNickName"></asp:Label>
                                <input id="hfNickId" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                订单编号：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="lblOrderCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                生产单号：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox ID="txtProductionNumber" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                预计入库时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtCompletionTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                                    runat="server" style="width: 80%;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                生产单状态：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Literal runat="server" ID="lblStatus"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                旺旺ID：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtWantID" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px" align="right">
                                是否排单：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Literal ID="lblSingleRowStatus" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                备注：
                            </td>
                            <td >
                                <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Height="45px" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 280px;" valign="top">
                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <span style="font-size: 18px; font-family: 隶书;">收货人信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                姓名：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtFullName"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                手机：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                电话：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                所在省份：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtProvince"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                所在城市：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                所在镇乡：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtCountory"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtDeliveryAddress" Style="width: 80%; height: 45px;"
                                    TextMode="MultiLine"></asp:TextBox>
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
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderInfoEdit.XMProductionOrderInfoSave %>" />
            </td>
        </tr>
    </table>
</asp:Content>
