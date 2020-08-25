<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMReturnCostList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMReturnCostList" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="Clients_RowCommand">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                        scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        订单号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        商品编码
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        厂家编码
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
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="订单号">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# GetOrderCode(Eval("ApplicationId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品编码">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PlatformMerchantCode") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplicationExchange).Manufacturers%>
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
                    <%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="退货成本">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%--<%# Eval("FactoryPrice")%>--%>
                    <%# (int)Eval("IsApplication") == 2 ? Eval("FactoryPrice") : ((int)Eval("IsApplication") == 1 ? "-" + Eval("FactoryPrice").ToString() : "0")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="销售价"  >
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
            </ItemTemplate> 
         </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>
