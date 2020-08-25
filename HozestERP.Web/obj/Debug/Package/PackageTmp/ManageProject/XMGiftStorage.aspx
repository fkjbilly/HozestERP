<%@ Page Language="C#" CodeBehind="XMGiftStorage.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" Inherits="HozestERP.Web.ManageProject.XMGiftStorage" %>

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
        function autoCompleteBind() {
            var nick = "";
            var index = "";
            var s = 1;
            var strCookie = document.cookie;
            //将多cookie切割为多个名/值对
            var arrCookie = strCookie.split("; ");

            var ID;
            //遍历cookie数组，处理每个cookie对
            for (var z = 0; z < arrCookie.length; z++) {
                var arr = arrCookie[z].split("=");
                //找到名称为userId的cookie，并返回它的值
                if ("NickId" == arr[0]) {
                    nick = arr[1];
                }
                if ("EditIndex" == arr[0]) {
                    index = arr[1];
                }
            }
            $(".ProductCode").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "XMGiftStorageGetList.ashx",
                        data: "q=" + encodeURI(request.term) + "&p=" + nick,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: " 商品编码：" + item.ManufacturersCode + " 产品：" + item.ProductName + " 尺寸：" + item.Specifications,
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
                    if (list != null && list.length > 0) {
                        var lblProductName = $("#<%= grdvZYNewsList.ClientID%> :input[id*='lblProductName']");
                        for (var a = 0; a < lblProductName.length; a++) {
                            if (a.toString() == index) {
                                lblProductName[a].value = i.item.order.ProductName;
                                break;
                            }
                        }
                        var lblSpecifications = $("#<%= grdvZYNewsList.ClientID%> :input[id*='lblSpecifications']");
                        for (var a = 0; a < lblSpecifications.length; a++) {
                            if (a.toString() == index) {
                                lblSpecifications[a].value = i.item.order.Specifications;
                                break;
                            }
                        }
                        document.cookie = "ProductId=" + i.item.order.Id + ";path=/ManageProject";
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 80px" align="right">
                    开始时间:
                </td>
                <td align="left">
                    <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 100%;" />
                </td>
                <td style="width: 80px" align="right">
                    结束时间:
                </td>
                <td align="left">
                    <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 100%;" />
                </td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" ValidationGroup="ModuleValidationGroup"
                        OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMGiftStorage.Search %>" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grdvZYNewsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        SkinID="GridViewThemen" OnRowEditing="grdvClients_RowEditing" OnRowUpdating="grdvClients_RowUpdating"
                        OnRowCancelingEdit="grdvClients_RowCancelingEdit">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <HeaderStyle Wrap="False" Width="4%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductName">
                                <HeaderStyle Width="20%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("ProductName")%>'
                                        readonly="readonly" runat="server" id="lblProductName" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                                <HeaderStyle Width="20%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("ManufacturersCode") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input runat="server" id="txtProductCode" class="TextBox ProductCode" onkeyup="autoCompleteBind()"
                                        style="text-align: left; width: 90%" type="text" value='<%# Eval("ManufacturersCode") %>' />
                                    <input id="hfProductID" type="hidden" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品编码不能为空."
                                        ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="尺寸" SortExpression="Specifications">
                                <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <input style="background: transparent; border: 0; width: 50px;" value='<%# Eval("Specifications")%>'
                                        readonly="readonly" runat="server" id="lblSpecifications" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="批次" SortExpression="Batch">
                                <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("Batch")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="入库数量" SortExpression="Count">
                                <HeaderStyle Width="16%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Width="88%" ID="txtCount" Text="0" onkeyup="value=value.replace(/[^\w\.]/ig,&quot;&quot;);"
                                        onkeypress="var key = window.event?event.keyCode:event.which;return ((key&lt;=57 &amp;&amp; key&gt;46) || ( key==46) || (key==8) || (key==9)  || (key==0) || (key==13));"
                                        onpaste="return clipboardData.getData(&quot;text&quot;).match(/^d+$/gi)!=null"
                                        MaxLength="12">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺Id" SortExpression="NicklId">
                                <HeaderStyle Width="0%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("NicklId")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="产品Id" SortExpression="ProductId">
                                <HeaderStyle Width="0%" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("ProductId")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="False" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        OnClientClick="return ReadOnly();" ToolTip="编辑" CommandName="Edit" CausesValidation="False"
                                        Visible="<% $CRMIsActionAllowed:XMGiftStorage.Edit %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMGiftStorage.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMGiftStorage.Cancel %>" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                    OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMGiftStorage.Save %>" />
            </td>
        </tr>
    </table>
</asp:Content>
