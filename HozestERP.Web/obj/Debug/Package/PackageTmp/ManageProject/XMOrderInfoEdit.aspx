<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMOrderInfoEdit.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderInfoEdit" %>

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
                                订单状态：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="lblOrderStatus" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                完成时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtCompletionTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                                    runat="server" style="width: 80%;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                发货时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtDeliveryTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                                    runat="server" style="width: 80%;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                付款时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtPayDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"
                                    runat="server" style="width: 80%;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                创单时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtOrderInfoCreateDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                                    class="Wdate" disabled="True" runat="server" style="width: 80%;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                数据来源：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtSourceType" Width="80%"></asp:TextBox>
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
                                是否刷单：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ckbIsScalping" runat="server" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px" align="right">
                                是否返现：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ckbIsCashBack" runat="server" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px" align="right">
                                是否已发赠品：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ckbIsSentGifts" runat="server" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px" align="right">
                                是否已评价：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ckbIsEvaluate" runat="server" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 280px;" valign="top">
                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <span style="font-size: 18px; font-family: 隶书;">商品价格</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                商品总额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtProductPrice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                配送费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtDistributePrice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                保价费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtSupportPrice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                税金：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtTaxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                折扣：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtDiscount"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                商家优惠：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtProductPromotion"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                平台优惠：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtOrderPromotion"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                订单总额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtOrderPrice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                已支付金额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtPayPrice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                到帐金额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtReceivablePrice"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 280px;" valign="top">
                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <span style="font-size: 18px; font-family: 隶书;">订单其他信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                配送方式：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtDistributeMethod"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                配送保价：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ckbIsDistributed" runat="server" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                商品重量：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtProductWeight"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                支付方式：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtPayMethod"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                支付费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtInvoicePrice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                是否开票：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="ckbIsInvoiced" runat="server" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                订单发票号：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtInvoiceNo"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                发票抬头：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtInvoiceHead"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td style="text-align: right; width: 130px;">
                                归属客服：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtCustomerService"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                物流费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtLogisticsFee"></asp:TextBox>
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
                                预约发货时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <input id="txtAppointDeliveryTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                                    class="Wdate" runat="server" style="width: 80%;" />
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
                                地区：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
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
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                备用地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:TextBox runat="server" ID="txtDeliveryAddressSpare" Style="width: 80%; height: 45px;"
                                    TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                商品体积：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox runat="server" ID="txtVolume"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    买家留言：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Height="45px" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    客服备注：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtCustomerRemark" TextMode="MultiLine" Height="45px"
                        Width="80%"></asp:TextBox>
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
                <asp:Button ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoEdit.XMOrderInfoEdit %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnIsAudit" runat="server" Text="审核" OnClick="btnIsAudit_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoEdit.XMOrderInfoIsAudit %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoEdit.XMOrderInfoSave %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="取消" OnClick="btnClose_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoEdit.XMOrderInfoClose %>" />
            </td>
        </tr>
    </table>
</asp:Content>
