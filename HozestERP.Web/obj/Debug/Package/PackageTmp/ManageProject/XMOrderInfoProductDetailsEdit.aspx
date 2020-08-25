<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMOrderInfoProductDetailsEdit.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderInfoProductDetailsEdit" %>

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
            var a = $("input#ctl00_ContentPlaceHolder2_pingtai2").val();
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
                var lblFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']");
                var hdFactoryPrice = $("#<%= grdvClients.ClientID%> :hidden[id*='hiddFactoryPrice']");
                var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                for (var a = 0; a < lblFactoryPrice.length; a++) {
                    if (lblFactoryPrice[a].id.indexOf(Id) != -1) {
                        lblFactoryPrice[a].value = hdFactoryPrice[a].value * txtProductNum[a].value;
                        break;
                    }
                }
                var lblTCostprice = $("#<%= grdvClients.ClientID%> :input[id*='lblTCostprice']");
                for (var a = 0; a < lblTCostprice.length; a++) {
                    if (lblTCostprice[a].id.indexOf(Id) != -1) {
                        lblTCostprice[a].value = lblTCostprice[a].value * txtProductNum[a].value ;
                        break;
                    }
                }
                var txtSalesPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtSalesPrice']");
                var hdSalePrice = $("#<%= grdvClients.ClientID%> :hidden[id*='hiddSalesPrice']");
                for (var a = 0; a < txtSalesPrice.length; a++) {
                    if (txtSalesPrice[a].id.indexOf(Id) != -1) {
                        txtSalesPrice[a].value = hdSalePrice[a].value * txtProductNum[a].value;
                        break;
                    }
                }
            });
            $(".ProductCode").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "XMOrderInfoProductDetaisRead.ashx",
                        data: "q=" + encodeURI(request.term) + "&p=" + a,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.ManufacturersCode + " 产品：" + item.ProductName + " 尺寸：" + item.Specifications + " 商品编码：" + item.ProductUnit,
                                    value: item.ManufacturersCode,
                                    order: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    var list = $(".ProductCode");
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

                    var Id = ID.replace("txtProductCode", "");
                    if (list != null && list.length > 0) {
                        var hfProductID = $("#<%= grdvClients.ClientID%> :hidden[id*='hfProductID']");
                        for (var a = 0; a < hfProductID.length; a++) {
                            if (hfProductID[a].id.indexOf(Id) != -1) {
                                hfProductID[a].value = i.item.order.Id;
                                break;
                            }
                        }
                        var lblProductName = $("#<%= grdvClients.ClientID%> :input[id*='lblProductName']");
                        for (var a = 0; a < lblProductName.length; a++) {
                            if (lblProductName[a].id.indexOf(Id) != -1) {
                                lblProductName[a].value = i.item.order.ProductName;
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
                        var lblManufacturers = $("#<%= grdvClients.ClientID%> :input[id*='lblManufacturers']");
                        for (var a = 0; a < lblManufacturers.length; a++) {
                            if (lblManufacturers[a].id.indexOf(Id) != -1) {
                                lblManufacturers[a].value = i.item.order.ProductUnit;
                                break;
                            }
                        }

                        var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                        for (var a = 0; a < txtProductNum.length; a++) {
                            if (txtProductNum[a].id.indexOf(Id) != -1) {
                                txtProductNum[a].value = 1;
                                break;
                            }
                        }

                        var lblFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']");
                        var txtProductNum = $("#<%= grdvClients.ClientID%> :input[id*='txtProductNum']");
                        var hdFactoryPrice = $("#<%= grdvClients.ClientID%> :hidden[id*='hiddFactoryPrice']");
                        for (var a = 0; a < lblFactoryPrice.length; a++) {
                            if (lblFactoryPrice[a].id.indexOf(Id) != -1) {
                                lblFactoryPrice[a].value = i.item.order.Costprice * txtProductNum[a].value;
                                hdFactoryPrice[a].value = i.item.order.Costprice;
                                break;
                            }
                        }

                        var lblTCostprice = $("#<%= grdvClients.ClientID%> :input[id*='lblTCostprice']");
                        for (var a = 0; a < lblTCostprice.length; a++) {
                            if (lblTCostprice[a].id.indexOf(Id) != -1) {
                                lblTCostprice[a].value = i.item.order.TCostprice * txtProductNum[a].value;
                                break;
                            }
                        }
                        var txtSalesPrice = $("#<%= grdvClients.ClientID%> :input[id*='txtSalesPrice']");
                        for (var a = 0; a < txtSalesPrice.length; a++) {
                            if (txtSalesPrice[a].id.indexOf(Id) != -1) {
                                txtSalesPrice[a].value = i.item.order.Saleprice * txtProductNum[a].value;
                                break;
                            }
                        }



                        //$("#<%= grdvClients.ClientID%> :hidden[id*='hfProductID']").val(i.item.order.Id);
                        //$("#<%= grdvClients.ClientID%> :input[id*='lblProductName']").val(i.item.order.ProductName);
                        //$("#<%= grdvClients.ClientID%> :input[id*='lblSpecifications']").val(i.item.order.Specifications);
                        //$("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']").val(i.item.order.FactoryPrice);
                        //$("#<%= grdvClients.ClientID%> :input[id*='lblTCostprice']").val(i.item.order.TCostprice);
                        //$("#<%= grdvClients.ClientID%> :text[id*='txtNumber']").select();
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
    <asp:HiddenField ID="pingtai2" runat="server" />
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
        OnRowDataBound="grdvClients_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                        scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
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
                        单价（销售价）
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
                        是否排单
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th>
                    <%--<th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th> --%>
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
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品编码">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%--<%#Eval("PlatformMerchantCode")%>--%>
                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                        readonly="readonly" runat="server" id="lblManufacturers" />
                    <input id="hfProductID2" type="hidden" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input runat="server" id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)"
                        style="text-align: left; width: 90%" type="text" value='<%# Eval("TManufacturersCode")%>' />
                    <input id="hfProductID" type="hidden" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品编码不能为空."
                        ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                        PopupPosition="TopRight" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                        readonly="readonly" runat="server" id="lblProductName" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
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
                    <asp:HiddenField ID="hiddFactoryPrice" runat="server" Value='<%# Eval("FactoryPrice")%>' />
                    <asp:TextBox runat="server" ID="lblFactoryPrice" onfocus="GetFocus(this.id)" Text='<%# Eval("FactoryPrice")%>'
                        Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="特供价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="lblTCostprice" Text='<%# Eval("TCostprice") == null ? "0" : Eval("TCostprice")%>'
                        Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                 <asp:HiddenField ID="hiddSalesPrice" runat="server" Value='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>' />
                    <asp:TextBox runat="server" ID="txtSalesPrice" Text='<%# Eval("SalesPrice") == null ? "0" : Eval("SalesPrice")%>'
                        Width="50px"></asp:TextBox>
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
            <asp:TemplateField HeaderText="是否排单" SortExpression="IsExpedited">
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
                        CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.Delete %>" />
                    <asp:ImageButton ID="imgBtnSpareAddress" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Blue/Image/Minutes.png" ToolTip="备用地址" CommandName="SpareAddress"
                        CausesValidation="False" />
                    <asp:ImageButton ID="imgBtnSpareRemarks" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Blue/Image/22.gif" ToolTip="备用备注" CommandName="SpareRemarks"
                        CausesValidation="False" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="操作"> 
            <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
            <ItemTemplate>
                <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除"
                    CommandName="XMOrderInfoDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');" />
            </ItemTemplate>
        </asp:TemplateField>--%>
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
            <td style="width: 70px">
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
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoList.GetDelivery %>" />
            </td>
        </tr>
    </table>
</asp:Content>
