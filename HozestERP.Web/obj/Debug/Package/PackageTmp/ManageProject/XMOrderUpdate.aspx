<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/CommonEdit.Master"
    CodeBehind="XMOrderUpdate.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderUpdate" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tr>
            <td style="width: 40%; text-align: right; font-size: 20px; font-weight: 200; height: 50px;">
                订单号：
            </td>
            <td style="width: 220px;">
                <asp:TextBox runat="server" ID="txtSearchOrderCode" Width="200px"></asp:TextBox>
            </td>
            <td style="text-align: left;">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdate.Search %>" />
                <asp:Button ID="btnUpdate" runat="server" Text="单个订单" SkinID="button4" OnClick="btnUpdate_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdate.Update %>" />
                <asp:Button ID="btnUpdateAllorder" runat="server" Text="全部订单" SkinID="button4" OnClick="btnUpdateAllorder_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdate.UpdateAllorder %>" />
                <asp:Label ID="jieguo" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
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
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                店铺：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label runat="server" ID="lblNickId"></asp:Label>
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
                                <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                完成时间：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtCompletionTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                发货时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:Label ID="txtDeliveryTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                付款时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:Label ID="txtPayDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                创单时间：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:Label ID="txtOrderInfoCreateDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                数据来源：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtSourceType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                旺旺ID：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtWantID" runat="server"></asp:Label>
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
                                <asp:Label ID="txtProductPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                配送费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtDistributePrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                保价费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtSupportPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                税金：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtTaxes" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                折扣：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtDiscount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                商品促销优惠：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtProductPromotion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                订单促销优惠：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtOrderPromotion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                订单总额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtOrderPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                已支付金额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtPayPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                到帐金额：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtReceivablePrice" runat="server"></asp:Label>
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
                                <asp:Label ID="txtDistributeMethod" runat="server"></asp:Label>
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
                                <asp:Label ID="txtProductWeight" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                支付方式：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtPayMethod" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                支付费用：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtInvoicePrice" runat="server"></asp:Label>
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
                                <asp:Label ID="txtInvoiceNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                发票抬头：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtInvoiceHead" runat="server"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td style="text-align: right; width: 130px;">
                                归属客服：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtCustomerService" runat="server"></asp:Label>
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
                                <asp:Label ID="txtAppointDeliveryTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                姓名：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtFullName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                手机：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtMobile" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                电话：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtTel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                地区：
                            </td>
                            <td style="text-align: left; width: 150px;">
                                <asp:Label ID="txtAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:Label ID="txtDeliveryAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 130px;">
                                备用地址：
                            </td>
                            <td style="text-align: left; width: 180px;">
                                <asp:Label ID="txtDeliveryAddressSpare" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateConsignee" runat="server" Text="修改收货人信息" SkinID="button6"
                                    ValidationGroup="ModuleValidationGroup" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdate.UpdateConsignee %>" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <table>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tr>
            <td>
                <span style="font-size: 18px; font-family: 隶书;">订单商品信息</span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    SkinID="GridViewThemen">
                    <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                                <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                                    scope="col">
                                    &nbsp;
                                </th>
                                <%--<th align="center" class="GridHeard" nowrap="" scope="col">
                                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                                </th>--%>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    商品编码
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    商品名称
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    尺寸
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                    scope="col">
                                    数量
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                    scope="col">
                                    出厂价
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                                    scope="col">
                                    特供价
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    销售价
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    是否抵库
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    截止发货日
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    是否审核
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    是否加急
                                </th>
                                <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                                    状态
                                </th>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                            </HeaderTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                                <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="商品编码">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("PlatformMerchantCode")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="商品名称">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("ProductName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="尺寸">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("Specifications")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数量">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("ProductNum")==null?"0":Eval("ProductNum")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="出厂价">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("FactoryPrice") == null ? "0" : Eval("FactoryPrice")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="特供价">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="销售价">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否抵库" SortExpression="ISArrivedLibrary">
                            <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <CRM:ImageCheckBox ID="chkISArrivedLibrary" runat="server" Width="20%" Checked='<%# Eval("ISArrivedLibrary")==null?false: Eval("ISArrivedLibrary")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否审核" SortExpression="IsAudit">
                            <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <CRM:ImageCheckBox ID="chkIsAudit" runat="server" Width="20%" Checked='<%# Eval("IsAudit")==null?false: Eval("IsAudit")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否加急" SortExpression="IsExpedited">
                            <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <CRM:ImageCheckBox ID="chkIsExpedited" runat="server" Width="20%" Checked='<%# Eval("IsExpedited")==null?false: Eval("IsExpedited")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态">
                            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                            <ItemTemplate>
                                <%# Eval("Status")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnUpdateProductDetails" runat="server" Text="修改商品信息" SkinID="button6"
                    ValidationGroup="ModuleValidationGroup" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdate.UpdateProductDetails %>" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tr>
            <td style="width:14%;">
                <span style="font-size: 18px; font-family: 隶书;">订单备注信息</span>
            </td>
            <td>
            <asp:Button ID="btnUpdateCustomerServiceRemark" runat="server" Text="修改备注信息" SkinID="button6"
                                    ValidationGroup="ModuleValidationGroup" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdate.UpdateCustomerServiceRemark %>" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%" border="0" cellspacing="0" cellpadding="3">
                    <tbody>
                        <tr>
                            <td style="width: 20%; text-align: right;">
                                买家留言：
                            </td>
                            <td style="width: 80%;">
                                <asp:Label runat="server" ID="txtRemark"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right;">
                                客服备注：
                            </td>
                            <td style="width: 80%;">
                                <asp:Label runat="server" ID="txtCustomerRemark"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
