<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMProductionOrderDetailEdit.aspx.cs" Inherits="HozestERP.Web.ManageProductionOrder.XMProductionOrderDetailEdit" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
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
            $(".ProductCode").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "/ManageProject/XMOrderInfoProductDetaisRead.ashx",
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

                        var lblProductWeight = $("#<%= grdvClients.ClientID%> :input[id*='lblProductWeight']");
                        for (var a = 0; a < lblProductWeight.length; a++) {
                            if (lblProductWeight[a].id.indexOf(Id) != -1) {
                                lblProductWeight[a].value = i.item.order.ProductWeight;
                                break;
                            }
                        }

                        var lblProductVolume = $("#<%= grdvClients.ClientID%> :input[id*='lblProductVolume']");
                        for (var a = 0; a < lblProductVolume.length; a++) {
                            if (lblProductVolume[a].id.indexOf(Id) != -1) {
                                lblProductVolume[a].value = i.item.order.ProductVolume;
                                break;
                            }
                        }
                    }
                }
            });
        }

        function GetFocus(id) {
            document.cookie = "FocusID=" + id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        重量
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        体积
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        生产单号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        预计入库时间
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        是否发货
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        是否排单
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
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
                    <input style="background: transparent; border: 0; width: 98%;" value='<%# Eval("PlatformMerchantCode") %>'
                        readonly="readonly" runat="server" id="lblManufacturers" />
                    <input id="hfProductID2" type="hidden" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input runat="server" id="txtProductCode" class="TextBox ProductCode" onfocus="GetFocus(this.id)"
                        style="text-align: left; width: 90%" type="text" value='<%# Eval("ManufacturersCode") %>' />
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
            <asp:TemplateField HeaderText="重量">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="lblProductWeight" onfocus="GetFocus(this.id)"
                        Text='<%# Eval("ProductWeight")%>' Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="体积">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="lblProductVolume" Text='<%# Eval("ProductVolume")%>'
                        Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="生产单号">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtProductionNumber" Text='<%# Eval("ProductionNumber")%>'
                        Width="80px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预计入库时间">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <input id="txtCompletionTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 80%;" value='<%#Eval("EstimateStorageDate") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否入库">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:CheckBox ID="chkStatus" runat="server" Checked='<%# Eval("Status")==null?false: Eval("Status")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否排单">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsSingleRow" runat="server" Checked='<%# Eval("IsSingleRow")==null?false: Eval("IsSingleRow")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" CommandName="OrderProductUpdate"
                        CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoProductDetailsEdit.Delete %>" />
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
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnIsDelivery" runat="server" Text="已入库" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnIsDelivery_Click" Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderDetailEdit.IsDelviery %>" />
            </td>
        </tr>
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
                    Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderDetailEdit.OneSingleRow %>" />
            </td>
        </tr>
    </table>
</asp:Content>
