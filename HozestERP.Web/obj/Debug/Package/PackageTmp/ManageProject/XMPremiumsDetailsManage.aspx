<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMPremiumsDetailsManage.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMPremiumsDetailsManage" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <%--<script type="text/javascript">
    function autoCompleteBind() {
        $(".ProductName").autocomplete({
            source: function (request, response) {
                jQuery.ajax({
                    url: "XMScalpingApplicationReturnedHandler.ashx?action=PremiumsDetails",
                    data: "q=" + encodeURI(request.term),
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.ProductName + ", 编码:" + item.ManufacturersCode + ", 尺寸:" + item.Specifications + ", 出厂价:" + item.Costprice,
                                value: item.ProductName,
                                product: item
                            }
                        }));
                    }
                });
            }
        }, {
            select: function (e, i, j) {
                $("#<%= grdPremiumsDetailsManage.ClientID%> :hidden[id*='hfProductId']").val(i.item.product.Id);  
                $("#<%= grdPremiumsDetailsManage.ClientID%> :text[id*='txtPlatformMerchantCode']").val(i.item.product.ManufacturersCode);
                $("#<%= grdPremiumsDetailsManage.ClientID%> :text[id*='txtEditSpecifications']").val(i.item.product.Specifications);
                $("#<%= grdPremiumsDetailsManage.ClientID%> :text[id*='txtFactoryPrice']").val(i.item.product.Costprice); 
            }
        });
    } 
    </script>
    --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="detailTitle" style="float: left;">赠品信息</span>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="right">
                    订单号:
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblOrderCode" runat="server"></asp:Label>
                </td>
                <td style="width: 80px" align="right">
                    旺旺号:
                </td>
                <td style="width: 150px;">
                    <asp:Label ID="lblWantId" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="grdPremiumsDetailsManage" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="Id" OnRowEditing="grdPremiumsDetailsManage_RowEditing" OnRowCancelingEdit="grdPremiumsDetailsManage_RowCancelingEdit"
                        OnRowUpdating="grdPremiumsDetailsManage_RowUpdating" SkinID="GridViewThemen"
                        OnRowDataBound="grdPremiumsDetailsManage_RowDataBound" OnRowDeleting="grdPremiumsDetailsManage_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                <ItemStyle Width="120px" Wrap="false"></ItemStyle>
                                <ItemTemplate>
                                    <%# Eval("PrdouctName")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input id="hfProductId" type="hidden" runat="server" />
                                    <%--       <input runat="server" id="txtProductName" class="TextBox ProductName" style="text-align: left;  
                                        width: 90%" type="text" />
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductName"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品名称不能为空."
                                        ValidationGroup="DetailsValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />--%>
                                    <asp:TextBox ID="txtProductName" runat="server" Width="90%" Text='<%# Eval("PrdouctName") %>'
                                        ValidationGroup="DetailsValidationGroup"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品编码" SortExpression="PlatformMerchantCode">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("PlatformMerchantCode")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPlatformMerchantCode" runat="server" Width="90%" Text='<%# Eval("PlatformMerchantCode") %>'
                                        ValidationGroup="DetailsValidationGroup" ></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="发货方" SortExpression="ShipperName">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("ShipperName")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlShipper" runat="server" Width="90%">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="尺寸">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSpecifications" runat="server"></asp:Label>
                                    <%-- <asp:TextBox ID="txtSpecifications" runat="server" ReadOnly="true" > </asp:TextBox> --%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditSpecifications" runat="server"> </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价" SortExpression="FactoryPrice">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("FactoryPrice")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFactoryPrice" runat="server" Text='<%# Eval("FactoryPrice") %>'
                                        ValidationGroup="DetailsValidationGroup"> </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="数量" SortExpression="">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("ProductNum")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProductNum" runat="server" Text='<%# Eval("ProductNum") %>' ValidationGroup="DetailsValidationGroup"> </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                <ItemStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsDetailsManage.Edit %>" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                        Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsDetailsManage.Delete %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                                        ValidationGroup="DetailsValidationGroup" ToolTip="保存" CommandName="Update" CausesValidation="True"
                                        Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsDetailsManage.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMPremiumsDetailsManage.Cancel %>" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%-- </div>--%>
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
            </td>
        </tr>
    </table>
    <%--   <script type="text/javascript">

         $(function () {
             autoCompleteBind();
         });
    </script>--%>
</asp:Content>
