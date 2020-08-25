<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMInvoiceInfoList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMInvoiceInfoList"
    EnableEventValidation="true" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function CheckCheckBox(type) {
            var msg = "";
            var action = "";
            var count = 0;
            var IdStr = "";
            var Ids = "";
            $("input[type=checkbox]").each(function (i, item) {
                if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                    IdStr = item.id.replace("_chkSelected", "_hdID");
                    var value = document.getElementById(IdStr).value.replace("on", "");
                    if (Ids == "") {
                        Ids = value;
                    }
                    else {
                        Ids += "," + value;
                    }
                    count++;
                }
            });

            if (count == 0) {
                alert("你没有选择任何记录！");
                return false;
            }

            if (type == 1) {
                if (count > 1) {
                    alert("补开发票每次只能选择一条记录！");
                    return false;
                }
                action = "Supplement";
            }
            if (type == 2) {
                action = "Resume";
            }

            jQuery(function ($) {
                $.ajax({ url: "xMInvoiceInfo.ashx?action=" + action,
                    async: false,
                    type: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "Ids=" + Ids,
                    success: function (json) {
                        if (json != "") {
                            msg = json;
                            alert(msg);
                        }
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
            if (msg == "") {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 80px; text-align: right;">
                项目:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                店铺:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                发票状态:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlInvoiceStatus" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                发票类型:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlInvoiceType" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 90px; text-align: right;">
                是否排单:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddlSingleRow" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 90px; text-align: right;">
                订单号:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="97%"></asp:TextBox>
            </td>
            <td style="width: 90px; text-align: right;">
                发票抬头:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtInvoiceHeader" runat="server" Width="97%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right">
                创建时间
            </td>
            <td style="width: 100px">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 100px">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 90px; text-align: right;">
                是否开票:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddlIsBilling" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="2" style="text-align: right">
                <asp:Button ID="btnExport" runat="server" SkinID="button6" Text="导出发票数据" OnClick="btnExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMInvoiceInfoList.Export %>" />
            </td>
        </tr>
        <tr>
            <td style="width: 90px; text-align: right;">
                订单状态:</td>
            <td style="width: 150px;">
                <asp:DropDownList ID="dllOrderState" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="1" Text="确认收货" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="已发货"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 90px; text-align: right;">
                &nbsp;</td>
            <td style="width: 150px;">
                &nbsp;</td>
            <td style="width: 60px; text-align: right">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 20px; text-align: center">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 90px; text-align: right;">
                &nbsp;</td>
            <td style="width: 150px;">
                &nbsp;</td>
            <td colspan="2" style="text-align: right">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowDataBound=" grdvClients_RowDataBound" OnRowDeleting=" grdvClients_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="10px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdID" Value='<%#Eval("ID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发票编号" SortExpression="InvoiceNo">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InvoiceNo")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发票类型" SortExpression="InvoiceTypeName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InvoiceTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发票抬头" SortExpression="InvoiceHeader">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InvoiceHeader")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发票状态" SortExpression="InvoiceStatusName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("InvoiceStatusName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改人" SortExpression="UpdateName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("UpdateName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改时间" SortExpression="UpdateDate">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("UpdateDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否废弃">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsScrap" runat="server" Width="20%" Checked='<%# Eval("IsScrap")==null?false:Eval("IsScrap")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否开票">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsBilling" runat="server" Width="20%" Checked='<%# Eval("IsBilling")==null?false:Eval("IsBilling")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否排单">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsSingleRow" runat="server" Width="20%" Checked='<%# Eval("IsSingleRow")==null?false:Eval("IsSingleRow")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发票已开">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsDelivery" runat="server" Width="20%" Checked='<%# Eval("IsInvoiceOpen")==null?false:Eval("IsInvoiceOpen")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="ToEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.Update %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.Delete %>" />
                    <asp:ImageButton ID="imgBtnSpareAddress" runat="server" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/App_Themes/Blue/Image/Minutes.png" ToolTip="备用地址" CommandName="SpareAddress"
                        CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.SpareAddress %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnAdd" SkinID="button2" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.Add %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnSupplement" SkinID="button4" runat="server" Text="补开发票" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.Supplement %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnResume" SkinID="button4" runat="server" Text="重开发票" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.Resume %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsSingleRow" SkinID="button2" runat="server" Text="排单" OnClick="btnIsSingleRow_Click"
                    Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.IsSingleRow %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsScrap" SkinID="button2" runat="server" Text="废弃" OnClick="btnIsScrap_Click"
                    Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.IsScrap %>" OnClientClick="return confirm('发票废弃后，状态不可修改，请确认？');" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsBilling" SkinID="button2" runat="server" Text="开票" OnClick="btnIsBilling_Click"
                    Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.IsBilling %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnUnIsBilling" SkinID="button4" runat="server" Text="取消开票" OnClick="btnUnIsBilling_Click"
                    Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.UnIsBilling %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsInvoiceOpen" SkinID="button4" runat="server" Text="发票已开" OnClick="btnIsInvoiceOpen_Click" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.IsInvoiceOpen %>"/>
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnUnIsInvoiceOpen" SkinID="button4" runat="server" Text="发票未开" OnClick="btnUnIsInvoiceOpen_Click" Visible="<% $CRMIsActionAllowed:XMInvoiceInfoList.UnIsInvoiceOpen %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExportDZFP" SkinID="button6" runat="server" Text="导出电子发票" OnClick="btnExportDZFP_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
