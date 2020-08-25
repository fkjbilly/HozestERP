<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMCashBackApplicationAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMCashBackApplicationAdd" %>

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
    <script type="text/javascript">
        function autoCompleteBindScalpingCode() {
            $("#<%= txtScalpingCode.ClientID%>").autocomplete({
                source: function (request, response) {
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
                    $("#<%= ddlProject.ClientID%>").val(i.item.scalping.ProjectId);
                    jQuery.ajax({
                        url: "../ManageFinance/ScalpingCodeHandler.ashx?action=selectNickByProject",
                        data: "projectID=" + i.item.scalping.ProjectId,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            var items = "<option value='-1'>所有</option>";

                            $.each(data, function (i, item) {
                                items += "<option value=\"" + item.nick_id + "\">" + item.nick + "</option>";
                            });
                            $("#<%= ddlNick.ClientID%>").html(items);
                            $("#<%= ddlNick.ClientID%>").val(i.item.scalping.NickID);
                            $("#<%= txtHidden.ClientID%>").val(i.item.scalping.NickID);
                        }
                    });
                }
            });
        } 
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="detailTitle" style="float: left;">返现申请</span>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtScalpingCode"
                            Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="订单号不能为空."
                            ValidationGroup="ModuleValidationGroup" Enabled="false">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                            TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                            PopupPosition="TopRight" />
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
                    </div>
                </td>
                <td colspan="4">
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
                    <asp:TextBox ID="txtHidden" runat="server" Text=""></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    <asp:Label ID="lblNickName" runat="server" Text='店铺名称<font color="red">*</font>:'> </asp:Label>
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <select  ID="ddlNick" style="width:90%" runat="server">
                    </select>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    姓名:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV3" runat="server">
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                    <div id="DIV4" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <input runat="server" id="name" class="TextBox ScalpingCode" style="text-align: left;
                                    width: 95%" type="text" />
                                <input id="Hidden2" type="hidden" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    申请类型<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddApplicationTypeId" runat="server" Width="100%" AutoPostBack="true"   OnSelectedIndexChanged="ddApplicationTypeId_SelectedIndexChanged">
                        <asp:ListItem Value="9" Text="返现"></asp:ListItem>
                        <asp:ListItem Value="10" Text="赔付"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    收款账号:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV7" runat="server">
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                    </div>
                    <div id="DIV8" runat="server">
                            <input runat="server" id="txtApplicationPayee" class="TextBox ScalpingCode" style="text-align: left;
                            width: 98%" type="text" />
                    </div>
                </td>
                <td style="width: 140px" align="right">
                    金额<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV9" runat="server">
                        <asp:HiddenField ID="HiddenField5" runat="server" />
                    </div>
                    <div id="DIV10" runat="server">
                        <HozestERP:SimpleTextBox ID="txtTheAdvanceMoney" runat="server" Columns="50" Text="0.00"
                            title="请输入金额~:float!" Width="95%" ValidationGroup="ModuleValidationGroup" ErrorMessage="金额为必填." />
                    </div>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    返现状态<font color="red">*</font>:
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
                    审核状态<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <div id="DIV11" runat="server">
                        <asp:HiddenField ID="HiddenField6" runat="server" />
                    </div>
                    <div id="DIV12" runat="server">
                        <CRM:ImageCheckBox ID="lblManagerStatus" runat="server" />
                    </div>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    赔付方<font color="red">*</font>:
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlPaymentPerson" runat="server" Width="100%">
                    </asp:DropDownList>
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
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationdetailsAdd.Save %>" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {

            autoCompleteBindScalpingCode();
        });
    </script>
</asp:Content>
