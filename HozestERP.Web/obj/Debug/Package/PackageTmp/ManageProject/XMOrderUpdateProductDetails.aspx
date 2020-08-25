<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMOrderUpdateProductDetails.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderUpdateProductDetails" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">

        function autoCompleteBind() {
            var PlatformTypeId = $("input#ctl00_ContentPlaceHolder2_hidPlatformTypeId").val();
            var s = 1;

            $('.ProductNum').focus(function () {
                var list = $(".ProductNum");
                var strCookie = document.cookie;
                //将多cookie切割为多个名/值对
                var arrCookie = strCookie.split("; ");

                var ID;
                //遍历cookie数组，处理每个cookie对
                for (var z = 0; z < arrCookie.length; z++) {
                    var arr = arrCookie[z].split("=");
                    //找到名称为userId的cookie，并返回它的值
                    if ("FocusID" == arr[0]) {
                        ID = arr[1];
                        break;
                    }
                }
                var Id = ID.replace("txtProductNum", "");
                var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                for (var a = 0; a < txtProductNum.length; a++) {
                    if (txtProductNum[a].id.indexOf(Id) != -1) {
                        s = txtProductNum[a].value;
                        break;
                    }
                }
            });

            $('.ProductNum').blur(function () {
                var list = $(".ProductNum");
                var strCookie = document.cookie;
                //将多cookie切割为多个名/值对
                var arrCookie = strCookie.split("; ");

                var ID;
                //遍历cookie数组，处理每个cookie对
                for (var z = 0; z < arrCookie.length; z++) {
                    var arr = arrCookie[z].split("=");
                    //找到名称为userId的cookie，并返回它的值
                    if ("FocusID" == arr[0]) {
                        ID = arr[1];
                        break;
                    }
                }

                var Id = ID.replace("txtProductNum", "");
                var txtFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtFactoryPrice']");

                var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                for (var a = 0; a < txtFactoryPrice.length; a++) {
                    if (txtFactoryPrice[a].id.indexOf(Id) != -1) {
                        txtFactoryPrice[a].value = txtFactoryPrice[a].value * txtProductNum[a].value / s;
                        break;
                    }
                }
                var txtTCostprice = $("#<%= grdvClients.ClientID%> :input[id*='txtTCostprice']");
                for (var a = 0; a < txtTCostprice.length; a++) {
                    if (txtTCostprice[a].id.indexOf(Id) != -1) {
                        txtTCostprice[a].value = txtTCostprice[a].value * txtProductNum[a].value / s;
                        break;
                    }
                }
                var txtSalesPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtSalesPrice']");
                for (var a = 0; a < txtSalesPrice.length; a++) {
                    if (txtSalesPrice[a].id.indexOf(Id) != -1) {
                        txtSalesPrice[a].value = txtSalesPrice[a].value * txtProductNum[a].value / s;
                        break;
                    }
                }
            });

            $(".ProductName").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "xMOrderUpdateProductDetails.ashx",
                        data: "ProductName=" + encodeURI(request.term) + "&PlatformTypeId=" + PlatformTypeId,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: "产品：" + item.ProductName + " 尺寸：" + item.Specifications + " 商品编码：" + item.PlatformMerchantCode + " 厂家编码：" + item.ManufacturersCode,
                                    value: item.ProductName,
                                    order: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    var list = $(".ProductName");
                    var strCookie = document.cookie;
                    //将多cookie切割为多个名/值对
                    var arrCookie = strCookie.split("; ");
                    var ID;
                    //遍历cookie数组，处理每个cookie对
                    for (var z = 0; z < arrCookie.length; z++) {
                        var arr = arrCookie[z].split("=");
                        //找到名称为userId的cookie，并返回它的值
                        if ("FocusID" == arr[0]) {
                            ID = arr[1];
                            break;
                        }
                    }

                    var Id = ID.replace("txtProductName", "");
                    var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                    for (var a = 0; a < txtProductNum.length; a++) {
                        if (txtProductNum[a].id.indexOf(Id) != -1) {
                            txtProductNum[a].value = 1;
                            break;
                        }
                    }
                    var txtProductName = $("#<%= grdvClients.ClientID%> :input[id*='txtProductName']");
                    for (var a = 0; a < txtProductName.length; a++) {
                        if (txtProductName[a].id.indexOf(Id) != -1) {
                            txtProductName[a].value = i.item.order.ProductName;
                            break;
                        }
                    }
                    var lblSpecifications = $("#<%= grdvClients.ClientID%> :input[id*='lblSpecifications']");
                    for (var a = 0; a < lblSpecifications.length; a++) {
                        if (lblSpecifications[a].id.indexOf(Id) != -1) {
                            lblSpecifications[a].value = i.item.order.Specifications;
                            break;
                        }
                    }
                    var lblManufacturersCode = $("#<%= grdvClients.ClientID%> :input[id*='lblManufacturersCode']");
                    for (var a = 0; a < lblManufacturersCode.length; a++) {
                        if (lblManufacturersCode[a].id.indexOf(Id) != -1) {
                            lblManufacturersCode[a].value = i.item.order.ManufacturersCode;
                            break;
                        }
                    }
                    var txtFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtFactoryPrice']");
                    for (var a = 0; a < txtFactoryPrice.length; a++) {
                        if (txtFactoryPrice[a].id.indexOf(Id) != -1) {
                            txtFactoryPrice[a].value = i.item.order.Costprice;
                            break;
                        }
                    }
                    var txtTCostprice = $("#<%= grdvClients.ClientID%> :input[id*='txtTCostprice']");
                    for (var a = 0; a < txtTCostprice.length; a++) {
                        if (txtTCostprice[a].id.indexOf(Id) != -1) {
                            txtTCostprice[a].value = i.item.order.TCostprice == null ? "0" : i.item.order.TCostprice;
                            break;
                        }
                    }
                    var txtSalesPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtSalesPrice']");
                    for (var a = 0; a < txtSalesPrice.length; a++) {
                        if (txtSalesPrice[a].id.indexOf(Id) != -1) {
                            txtSalesPrice[a].value = i.item.order.Saleprice;
                            break;
                        }
                    }
                    var lblPlatformMerchantCode = $("#<%= grdvClients.ClientID%> :input[id*='lblPlatformMerchantCode']");
                    for (var a = 0; a < lblPlatformMerchantCode.length; a++) {
                        if (lblPlatformMerchantCode[a].id.indexOf(Id) != -1) {
                            lblPlatformMerchantCode[a].value = i.item.order.PlatformMerchantCode;
                            break;
                        }
                    }
                }
            });
        }

        function NumberCheck(textID) {
            $(textID).focus(function () {
                if (textID.value.replace(/^[0-9]*$/, "") != "") {
                    $(this).val("");
                } else if (parseInt($(textID).val()) <= 0) {
                    $(this).val("");
                }
            }).blur(function () {
                if (textID.value.replace(/^[0-9]*$/, "") != "") {
                    $(this).val("");
                } else if (parseInt($(textID).val()) <= 0) {
                    $(this).val("");
                }
            });
        }

        function GetFocus(id) {
            document.cookie = "FocusID=" + id;
        }

    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="hidPlatformTypeId" runat="server" />
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
        OnRowDataBound="grdvClients_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input style="text-align: left; width: 90%" onfocus="GetFocus(this.id)" class="TextBox ProductName"
                        type="text" value='<%# Eval("ProductName")%>' runat="server" id="txtProductName" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input style="background: transparent; border: 0; width: 99%;" value='<%# Eval("TManufacturersCode")%>'
                        readonly="readonly" runat="server" id="lblManufacturersCode" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品编码">
                <HeaderStyle Width="75px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input style="background: transparent; border: 0; width: 99%;" value='<%# Eval("PlatformMerchantCode") %>'
                        readonly="readonly" runat="server" id="lblPlatformMerchantCode" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                        readonly="readonly" runat="server" id="lblSpecifications" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input class="TextBox ProductNum" style="width: 50px;" onfocus="GetFocus(this.id)"
                        value='<%# Eval("ProductNum")==null?"1":Eval("ProductNum")%>' runat="server"
                        id="txtProductNum" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出厂价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtFactoryPrice" onfocus="GetFocus(this.id)" Text='<%# Eval("FactoryPrice")%>'
                        Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="特供价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>'
                        Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                        Width="50px"></asp:TextBox>
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
            <asp:TemplateField HeaderText="是否排单" SortExpression="IsSingleRow">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsSingleRow" runat="server" Width="20%" Checked='<%# Eval("IsSingleRow")==null?false: Eval("IsSingleRow")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" CommandName="OrderProductUpdate"
                        CausesValidation="False" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');" />
                    <asp:ImageButton ID="imgBtnSpareAddress" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Blue/Image/Minutes.png" ToolTip="备用地址" CommandName="SpareAddress"
                        CausesValidation="False" />
                    <asp:ImageButton ID="imgBtnSpareRemarks" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Blue/Image/22.gif" ToolTip="备用备注" CommandName="SpareRemarks"
                        CausesValidation="False" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            autoCompleteBind();
        });
    </script>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td style="width: 70px" align="left">
                排单仓库:
            </td>
            <td style="width: 75px">
                <asp:DropDownList ID="ddlWarehouseID" runat="server" Width="95%">
                </asp:DropDownList>
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnGetDelivery" SkinID="button4" runat="server" Text="排单" OnClick="btnGetDelivery_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderUpdateProductDetails.GetDelivery %>" />
            </td>
        </tr>
    </table>
</asp:Content>
