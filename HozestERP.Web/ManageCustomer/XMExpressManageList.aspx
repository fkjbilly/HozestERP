<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMExpressManageList.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.XMExpressManageList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">

        function SaveExpressManageIDs() {
            var IdStr = "";
            var Ids = "";
            $("input[type=checkbox]").each(function (i, item) {
                if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                    IdStr = item.id.replace("_chkSelected", "_InfoID");
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
                $.ajax({ url: "xMChoseExpress.ashx?Ids=" + Ids,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: "action=ExpressManage",
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 70px" align="right">
                寄件单号:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtCourierNumber" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 70px" align="right">
                寄件部门:
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="90%">
                </asp:DropDownList>
            </td>
            <td style="width: 70px" align="right">
                寄件人:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtSender" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 70px" align="right">
                收件人:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtReceivingName" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 70px" align="right">
                是否打印:
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlPrint" runat="server" Width="90%">
                    <asp:ListItem Value="-1">---所有---</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound">
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
                    <asp:HiddenField ID="InfoID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" 快递公司" SortExpression="ExpressName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ExpressName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="寄件单号" SortExpression="CourierNumber">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CourierNumber") == null ? "" : Eval("CourierNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="寄件部门" SortExpression="DepartmentName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DepartmentName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="寄件日期" SortExpression="SendDate">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SendDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="寄件人" SortExpression="SenderName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SenderName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收件人" SortExpression="ReceivingName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReceivingName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收件单位" SortExpression="ReceivingCompany">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReceivingCompany")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收件电话" SortExpression="ReceivingTel">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReceivingTel")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收件地址" SortExpression="ReceivingAddress">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReceivingAddress").ToString().Length > 8 ? Eval("ReceivingAddress").ToString().Substring(0,8)+"..." : Eval("ReceivingAddress").ToString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="价格" SortExpression="Price">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Price")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="备注" SortExpression="Remarks">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Remarks")%>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="打印次数" SortExpression="PrintCount">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PrintCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="打印时间" SortExpression="PrintDate">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PrintDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="ToEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomer.XMExpressManageList.Edit %>" />
                    <asp:ImageButton ID="imgBtnEditAll" runat="server" ImageUrl="../App_Themes/Blue/Image/Minutes.png"
                        ToolTip="编辑所有快递单" CommandName="ToEditAll" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomer.XMExpressManageList.imgBtnEditAll %>" />
                    <asp:ImageButton ID="imgBtnCopy" runat="server" ImageUrl="~/App_Themes/Default/Image/22.gif" 
                         ToolTip="复制" CommandName="toCopy" CausesValidation="False"/>
                    <asp:ImageButton ID="imgBtnLogisticsInfo" runat="server" ImageUrl="~/App_Themes/Default/Image/Records.png"
                         ToolTip="物流信息" CommandName="toLogisticsInfo" CommandArgument='<%#Eval("ID")%>' CausesValidation="False" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="ToDelete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageCustomer.XMExpressManageList.Delete %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <ext:ResourceManager ID="ResourceManager" runat="server"/>
    <ext:Window ID="Window1" 
            runat="server" 
            Width="1100"
            Height="600" 
            Title="物流信息" 
            Hidden="true">
    </ext:Window>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageCustomer.XMExpressManageList.Add %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDirectThermalPrint" SkinID="button6" runat="server" Text="热敏打印"
                    Visible="<% $CRMIsActionAllowed:ManageCustomer.XMExpressManageList.DirectThermalPrint %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnCancelWaybill" SkinID="button6" runat="server" Text="取消寄件单号" OnClick="btnCancelWaybill_Click"
                    Visible="<% $CRMIsActionAllowed:ManageCustomer.XMExpressManageList.CancelWaybill %>" />
            </td>
        </tr>
    </table>
</asp:Content>
