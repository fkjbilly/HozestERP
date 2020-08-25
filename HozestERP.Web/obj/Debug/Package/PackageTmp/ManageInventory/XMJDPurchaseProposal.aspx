<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMJDPurchaseProposal.aspx.cs" Inherits="HozestERP.Web.ManageInventory.XMJDPurchaseProposal" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeOverflow(change) {
            var div = document.getElementById("DivGridView");
            if (change == "1") {
                div.style.overflow = "scroll";
            }
            else {
                div.style.overflow = "hidden";
            }
        }
    
    </script>
    <style type="text/css">
        .headbackground
        {
            background-color: #EEEEEE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px; text-align: right;">
                厂家编码
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtPlatFormCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                商品名称
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtProductName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 40px; text-align: right">
                项目
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 40px; text-align: right">
                店铺
            </td>
            <td style="width: 80px">
                <asp:DropDownList ID="ddlNick" runat="server" OnSelectedIndexChanged="ddlNick_Change"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 50px; text-align: center">
                仓库
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlWareHourses" runat="server">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript"></script>
    <div style="height: 100%; width: 55%; border: 0px; display: block; float: left; overflow: hidden;"
        id="DivFrozen">
        <%=TableStr %>
    </div>
    <div style="overflow: scroll; height: 100%; float: left; width: 45%; margin-left: -3px"
        id="DivGridView">
        <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            SkinID="GridViewThemen" OnRowDataBound="grdvClients_RowDataBound" ShowFooter="true">
            <Columns>
                <asp:TemplateField HeaderText="前第1周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" Height="27px" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <ItemStyle Height="30px" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        前第1周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_0" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第2周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" Height="27px" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第2周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_1" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第3周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" Height="27px" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第3周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_2" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第4周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" Height="27px" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第4周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_3" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第5周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第5周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_4" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第6周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第6周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_5" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第7周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第7周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_6" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="前第8周销量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        前第8周销量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSaleCount_7" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="历史四周销量和">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        历史四周销量和
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblLastFourWeekSaleCount" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="历史八周销量和">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        历史八周销量和
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblLastEnghtWeekSaleCount" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="预测总数">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        预测总数
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblYCCount" runat="server"></asp:Literal>
                        <asp:TextBox ID="txtYCCount" runat="server" Visible="false" onkeypress="if(event.keyCode==13){return false;}"></asp:TextBox>
                        <div style="text-align: center; width: 100%;">
                            <asp:HiddenField ID="hiddID" runat="server" Value='<%#Eval("Id") %>' />
                            <asp:Label ID="lblMsgYCCount" runat="server" Text="" ForeColor="red"></asp:Label>
                            <asp:HiddenField ID="hiddWareHouresID" runat="server" Value='<%#Eval("WfId") %>' />
                            <asp:HiddenField ID="hiddPlatformMerchantCode" runat="server" Value='<%#Eval("PlatformMerchantCode") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ID="imgBtnEdit" TabIndex="-1" OnClick="imgBtnEdit_Click" runat="server"
                            ImageUrl="~/App_Themes/Default/Image/update.gif" ToolTip="编辑" Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDPurchaseProposal.YCCountEdit %>" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="imgBtnUpdate" TabIndex="-1" OnClick="imgBtnUpdate_Click" runat="server"
                            ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDPurchaseProposal.YCCountUpdate %>" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="imgBtnCancel" TabIndex="-1" OnClick="imgBtnCancel_Click" runat="server"
                            ImageUrl="~/App_Themes/Default/Image/Cancel.gif" ToolTip="取消" Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDPurchaseProposal.Cancel %>"
                            CausesValidation="False" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="当前可用库存">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        当前可用库存
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblStockNumber" runat="server" Text='<%# Eval("StockNumber")%>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="建议采购数量">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        建议采购数量
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblSuggestCount" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备货周期">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                    <HeaderTemplate>
                        备货周期
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblCike" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnEstablishPurchase" SkinID="button6" runat="server" Text="导出数据"
                    OnClick="btnEstablishPurchase_Click" Visible="<% $CRMIsActionAllowed:ManageInventory.XMJDPurchaseProposal.EstablishPurchase %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button SkinID="button6" ID="btnJDRealTimeInventoryExport" runat="server" Text="京东库存导入"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.JDRealTimeInventoryExport %>" />
            </td>
        </tr>
    </table>
</asp:Content>
