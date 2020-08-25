<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMPremiumsAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMPremiumsAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="../Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        #dialog
        {
            display: none;
        }
    </style>
    <script type="text/javascript">

        function autoCompleteBindScalpingCode() {
            $("#<%= txtScalpingCode.ClientID%>").autocomplete({
                source: function (request, response) {

                    jQuery.ajax({
                        url: "ProductDetail.ashx?action=RecordOrderCode",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                        }
                    });

                    jQuery.ajax({
                        url: "../ManageFinance/ScalpingCodeHandler.ashx?action=selectBywang",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.OrderCode + "平台：" + item.PlatformName + " 店铺：" + item.NickName,
                                    value: item.OrderCode,
                                    scalping: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    $("#<%= hfScalpingId.ClientID%>").val(i.item.scalping.OrderCode);
                    $("#<%= wangwang.ClientID%>").val(i.item.scalping.WantID);
                    $("#<%= wangwangdd.ClientID%>").val(i.item.scalping.WantID);
                }
            });
        }

        function autoCompleteBind() {
            var OrderCode = document.getElementById("<%=txtScalpingCode.ClientID %>").value;
            $(".ProductName").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "ProductDetail.ashx?action=GetProductList",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.PlatformMerchantCode + " 产品：" + item.ProductName + " 尺寸：" + item.Specifications,
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
                    var Id = ID.replace("lblProductName", "");
                    if (list != null && list.length > 0) {
                        var txtPlatformMerchantCode = $("#<%= grdvClients.ClientID%> :input[id*='txtProductCode']");
                        for (var a = 0; a < txtPlatformMerchantCode.length; a++) {
                            if (txtPlatformMerchantCode[a].id.indexOf(Id) != -1) {
                                txtPlatformMerchantCode[a].value = i.item.order.PlatformMerchantCode;
                            }
                        }

                        var hfProductID = $("#<%= grdvClients.ClientID%> :hidden[id*='hfProductID']");
                        for (var a = 0; a < hfProductID.length; a++) {
                            if (hfProductID[a].id.indexOf(Id) != -1) {
                                hfProductID[a].value = i.item.order.Id;
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

                        var lblFactoryPrice = $("#<%= grdvClients.ClientID%> :input[id*='lblFactoryPrice']");
                        for (var a = 0; a < lblFactoryPrice.length; a++) {
                            if (lblFactoryPrice[a].id.indexOf(Id) != -1) {
                                lblFactoryPrice[a].value = i.item.order.Costprice;
                                break;
                            }
                        }

                        var ddlShipper = $("#<%= grdvClients.ClientID%> :input[id*='ddlShipper']");
                        for (var a = 0; a < lblSpecifications.length; a++) {
                            if (ddlShipper[a].id.indexOf(Id) != -1) {
                                ddlShipper[a].value = i.item.order.Shipper;
                                break;
                            }
                        }

                        var hidProductId = $("#<%= grdvClients.ClientID%> :input[id*='hidProductId']");
                        for (var a = 0; a < hidProductId.length; a++) {
                            if (hidProductId[a].id.indexOf(Id) != -1) {
                                hidProductId[a].value = i.item.order.ProductId;
                                break;
                            }
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

        function SavePremiumsAddPage() {
            var Nick = "-1";
            var OrderCode = document.getElementById("<%=txtScalpingCode.ClientID %>").value;
            var wangwang = document.getElementById("<%=wangwangdd.ClientID %>").value;
            var ApplicationTypeId = document.getElementById("<%=ddlApplicationTypeId.ClientID %>").value;
            var PaymentPerson = document.getElementById("<%=ddlPaymentPerson.ClientID %>").value;
            var chk = document.getElementById("<%=chkNoOrderPremiums.ClientID %>").checked == false ? "0" : "1";
            var btnSave = document.getElementById("<%=btnSave.ClientID %>");
            var aaa = btnSave.OnClientClick = "";

            if (ApplicationTypeId != 10) {

                return true;
            }

            if (chk == "0") {
                Nick = document.getElementById("<%=ddlNick.ClientID %>").value;
            }

            jQuery(function ($) {
                $.ajax({ url: "XMClaim.ashx?OrderCode=" + OrderCode + "&wangwang=" + wangwang + "&ApplicationTypeId=" + ApplicationTypeId
                            + "&PaymentPerson=" + PaymentPerson + "&chk=" + chk + "&Nick=" + Nick,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: "action=SavePremiumsAddPage",
                    success: function (json) {
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function SavePremiunsInfoIDs() {
            var IdStr = "";
            var Ids = "";
            $("input[type=checkbox]").each(function (i, item) {
                if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                    IdStr = item.id.replace("_chkSelected", "_hdNickManageInfoID");
                    var value = document.getElementById(IdStr).value.replace("on", "");
                    if (Ids == "") {
                        Ids = value;
                    }
                    else {
                        Ids += "," + value;
                    }
                }
            });

            jQuery(function ($) {
                $.ajax({ url: "xMPremiunsInfoList.ashx?Ids=" + Ids,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: "action=SavePremiunsInfoIDs",
                    success: function (json) {
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="detailTitle" style="float: left;">赠品申请</span>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    正常赠品:
                </td>
                <td colspan="3">
                    <asp:CheckBox ID="chkNoOrderPremiums" runat="server" Checked="true" AutoPostBack="true"
                        OnCheckedChanged="chkNoOrderPremiums_Changed" />
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    <asp:Label ID="lblProjectName" runat="server" Text='项目名称<font color="red">*</font>:'> </asp:Label>
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlProject" Width="90%" runat="server" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    <asp:Label ID="lblNickName" runat="server" Text='店铺名称<font color="red">*</font>:'> </asp:Label>
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlNick" Width="90%" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    订单号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIVLableScalpingNo" runat="server">
                        <asp:HiddenField ID="hdScalpingId" runat="server" />
                    </div>
                    <div id="DIVScalpingNo" runat="server">
                        <input runat="server" id="txtScalpingCode" class="TextBox ScalpingCode" style="text-align: left;
                            width: 95%" type="text" />
                        <input id="hfScalpingId" type="hidden" runat="server" />
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtScalpingCode"
                            Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="订单号不能为空."
                            ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                            TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                            PopupPosition="TopRight" />--%>
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    旺旺号<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV1" runat="server">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div id="DIV2" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <input runat="server" id="wangwang" class="TextBox ScalpingCode" disabled="disabled"
                                    style="text-align: left; width: 95%" type="text" />
                                <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <input id="wangwangdd" type="hidden" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="wangwang"
                            Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="旺旺号不能为空."
                            ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                            TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                            PopupPosition="TopRight" />--%>
                    </div>
                </td>
            </tr>
            <tr>
                <%--        <td style="width: 140px"  align="right">
                姓名<font color="red">*</font>:
                </td>
                          <td    style="width: 218px; border-right:1px soild red;">
                          <div id="DIV3" runat="server">
                           <asp:HiddenField ID="HiddenField2" runat="server" />
                           </div>
                          <div id="DIV4" runat="server">
                           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                          <ContentTemplate>  
                                <input runat="server" id="name" class="TextBox ScalpingCode" style="text-align: left;  width: 95%" type="text"  />
                                   <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label> 
                                   
                                <input id="Hidden2" type="hidden" runat="server" />
                          </ContentTemplate>
                          </asp:UpdatePanel> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="name"  Font-Name="verdana" Font-Size="9pt"
                                 runat="server" Display="None" ErrorMessage="姓名不能为空."  ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"  TargetControlID="RequiredFieldValidator1" 
                                 HighlightCssClass="validatorCalloutHighlight"  PopupPosition="TopRight" />
                         </div>
                          </td> --%>
                <td style="width: 140px" align="right">
                    申请类型<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlApplicationTypeId" runat="server" Width="97%" AutoPostBack="true"
                        OnSelectedIndexChanged="ddApplicationTypeId_SelectedIndexChanged">
                        <asp:ListItem Value="11" Text="赠品"></asp:ListItem>
                        <asp:ListItem Value="10" Text="赔付"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    赔付方<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPaymentPerson" runat="server" Width="97%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    <asp:Label ID="lblResponsiblePerson" runat="server" Text='责任人<font color="red">*</font>:'> </asp:Label>
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtResponsiblePerson" runat="server" Width="90%"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    <asp:Label ID="lblClaimReason" runat="server" Text='原因<font color="red">*</font>:'> </asp:Label>
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtClaimReason" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <%--            <tr>
                        <td style="width: 140px"  align="right">
                收款账号<font color="red">*</font>:
                </td>
                          <td    style="width: 218px; border-right:1px soild red;">
                          <div id="DIV7" runat="server">
                           <asp:HiddenField ID="HiddenField4" runat="server" />
                           </div>
                          <div id="DIV8" runat="server">
                <HozestERP:SimpleTextBox ID="txtApplicationPayee" runat="server"  Text="" 
             OnFocus="javascript:if(this.value=='请输入银行账号或支付宝账号') {this.value='';this.style.color='blue'}"
              OnBlur="javascript:if(this.value==''){this.value='请输入银行账号或支付宝账号';this.style.color='red'}" 
              ForeColor="Gray"   Width="98%"  ValidationGroup="ModuleValidationGroup"  ErrorMessage="申请收款账号为必填."/>
                         </div>
                          </td> 
            </tr>--%>
            <tr>
                <td style="width: 140px" align="right">
                    赠品状态<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV5" runat="server">
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                    </div>
                    <div id="DIV6" runat="server">
                        <CRM:ImageCheckBox ID="lblCashBackStatus" runat="server" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    项目审核<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV11" runat="server">
                        <asp:HiddenField ID="HiddenField6" runat="server" />
                    </div>
                    <div id="DIV12" runat="server">
                        <CRM:ImageCheckBox ID="lblManagerStatus" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    是否核对<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV3" runat="server">
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                    <div id="DIV4" runat="server">
                        <CRM:ImageCheckBox ID="ispj" runat="server" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    是否排单<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV7" runat="server">
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                    </div>
                    <div id="DIV8" runat="server">
                        <CRM:ImageCheckBox ID="issh" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备注:
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtNote" runat="server" Text="" Width="92.5%" TextMode="MultiLine"
                        Height="60px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowDataBound="grdvClients_RowDataBound" SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand">
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
                        商品名称
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        发货方
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
                    <asp:HiddenField ID="hidProductId" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品编码">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input runat="server" id="txtProductCode" class="TextBox ProductCode" style="text-align: left;
                        border: 0; width: 90%" type="text" value='<%# Eval("PlatformMerchantCode") %>'
                        readonly="readonly" />
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
                    <input style="background: transparent; width: 90%;" class="TextBox ProductName" onfocus="GetFocus(this.id)"
                        value='<%# Eval("PrdouctName")%>' runat="server" id="lblProductName" type="text" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货方">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:DropDownList ID="ddlShipper" runat="server" Width="85px">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <input style="background: transparent; border: 0; width: 55px;" readonly="readonly"
                        runat="server" id="lblSpecifications" value='<%# GetSpecifications(Eval("PlatformMerchantCode")==null?"":Eval("PlatformMerchantCode").ToString())%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("ProductNum")==null?"0":Eval("ProductNum")%>'
                        ID="txtProductNum" Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出厂价">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="lblFactoryPrice" Text='<%# Eval("FactoryPrice")%>'
                        Width="50px"></asp:TextBox>
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
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" CommandName="ToAdd"
                        Visible="<% $CRMIsActionAllowed:XMPremiumsdetailsAdd.add %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%# Eval("Id") %>' ToolTip="删除" CommandName="ToDelete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:XMPremiumsdetailsAdd.Delete %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:XMPremiumsAdd.add %>" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSingleRow2" runat="server" Text="单个排单" ValidationGroup="ModuleValidationGroup"
                    Visible="<% $CRMIsActionAllowed:XMPremiumsAdd.SingleRow2%>" SkinID="button6" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            autoCompleteBindScalpingCode();
        });
        $(document).ready(function () {
            autoCompleteBind();
        });
    </script>
</asp:Content>
