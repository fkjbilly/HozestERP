<%@ Page Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="ProductDetails.aspx.cs" Inherits="HozestERP.Web.ManageFinance.ProductDetails" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    平台类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%" Enabled="false">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    项目类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlXMProjectTypeId" runat="server" Width="100%" Enabled="false">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 90px">
                    项目名称:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlXMProject" runat="server" Width="100%" Enabled="false">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 90px">
                    店铺名称:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlNickList" runat="server" Width="100%" Enabled="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    时间类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="100%" Enabled="false">
                        <asp:ListItem Value="1" Text="创单时间"></asp:ListItem>
                        <asp:ListItem Value="2" Text="付款时间"></asp:ListItem>
                        <asp:ListItem Value="3" Text="发货时间"></asp:ListItem>
                        <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    开始日期:
                </td>
                <td style="width: 150px">
                    <input id="txtOrderInfoModifiedStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 90%;" />
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 90px">
                    结束日期:
                </td>
                <td style="width: 150px">
                    <input id="txtOrderInfoModifiedEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 90%;" />
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 90px">
                    <%--厂家编码:--%>
                </td>
                <td style="width: 150px">
                    <%--<asp:TextBox runat="server" ID="txtManufacturersCode" Width="100%" Enabled="false"></asp:TextBox>--%>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdProductDetailsList" runat="server" AutoGenerateColumns="False"
        DataKeyNames="ID" SkinID="GridViewThemen" OnRowDataBound="grdProductDetailsList_RowDataBound"
        ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="项目名称" SortExpression="ProjectName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProjectName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台名称" SortExpression="PlatformTypeName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PlatformTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称" SortExpression="NickName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("NickName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货时间" SortExpression="DeliveryTime">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DeliveryTime")==null?"":DateTime.Parse(Eval("DeliveryTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="付款时间" SortExpression="PayDate">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("PayDate")==null?"":DateTime.Parse(Eval("PayDate").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商家编码" SortExpression="PlatformMerchantCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PlatformMerchantCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸" SortExpression="Specifications">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订购数量" SortExpression="ProductNum">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductNum")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="成交金额" SortExpression="PayPrice">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PayPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
