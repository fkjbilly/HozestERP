<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMApplicationList.aspx.cs" Inherits="HozestERP.Web.ManageApplication.XMApplicationList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/ImageButtonSelectSingleCustomerControl.ascx" TagName="ImageButtonSelectSingleCustomerControl"
    TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        div.demo
        {
            border: 1px solid #CCC;
            background: red;
            position: fixed;
            height: 100%;
            z-index: 0;
            top: 4px;
            left: 4px;
            right: 4px;
            margin-bottom: 5px;
            position: relative;
            overflow: auto;
            width: 99.1%;
            line-height: normal;
            white-space: normal;
        }
        
        .cblQuestionType input
        {
            margin-left: 10px;
        }
        
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
    </style>
     <script type="text/javascript">
         function SaveApplicationIds() {

             var IdStr = "";
             var Ids = "";
             $("input[type=checkbox]").each(function (i, item) {
                 if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                     IdStr = item.id.replace("_chkSelected", "_hdApplicationId");
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
                 $.ajax({ url: "../ManageProject/xMOrderInfoList.ashx?Ids=" + Ids,
                     type: "GET",
                     dataType: "json",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     data: "action=SaveApplicationIds",
                     success: function (json) {
                     },
                     error: function (x, e) {
                     },
                     complete: function (x) {
                     }
                 });
             });
         }

         function SaveReturnIDs()
         {
             var IdStr = "";
             var Ids = "";
             $("input[type=checkbox]").each(function (i, item) {
                 if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                     IdStr = item.id.replace("_chkSelected", "_hdApplicationId");
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
                 $.ajax({
                     url: "XMApplicationList.ashx?Ids=" + Ids,
                     type: "GET",
                     dataType: "json",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     data: "action=SaveReturnIDs",
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
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    平台
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    店铺名称
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 88px">
                    <asp:DropDownList ID="timetype" Width="100%" runat="server">
                        <asp:ListItem Value="1">申请时间</asp:ListItem>
                        <asp:ListItem Value="2">完成时间</asp:ListItem>
                        <asp:ListItem Value="3">入库时间</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                    &nbsp;&nbsp;至&nbsp;&nbsp;
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    是否送出
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="Send" runat="server" Width="80%">
                        <asp:ListItem Value="-1">--所有--</asp:ListItem>
                        <asp:ListItem Value="1">已送出</asp:ListItem>
                        <asp:ListItem Value="0">未送出</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    客服审核
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="Supervisor" runat="server" Width="80%">
                        <asp:ListItem Value="-1">--所有--</asp:ListItem>
                        <asp:ListItem Value="1">已审核</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr>
                <td style="width: 65px">
                    财务审核
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="Financial" runat="server" Width="80%">
                        <asp:ListItem Value="-1">--所有--</asp:ListItem>
                        <asp:ListItem Value="1">已审核</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    订单号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtSrvAfterCustomerID" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    申请类型
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="ApplicaType" Width="100%" runat="server">
                        <asp:ListItem Value="-1">--所有--</asp:ListItem>
                        <asp:ListItem Value="4">未发货退款</asp:ListItem>
                        <asp:ListItem Value="5">先退货后退款</asp:ListItem>
                        <asp:ListItem Value="8">退运费</asp:ListItem>
                        <asp:ListItem Value="6">换货</asp:ListItem>
                        <asp:ListItem Value="7">先退款后退货</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    手机号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtTel" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    姓名
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtFullName" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td colspan="2">
                    <div id="DIVSearch" runat="server" style="float: left;">
                        <asp:Button ID="hidBtnSearch" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                            OnClick="hidBtnSearch_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:ManageApplication.Search %>"
                            OnClick="btnSearch_Click" />
                    </div>
                </td>
                <td style="width: 120px" nowrap="nowrap">
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 120px" nowrap="nowrap">
                </td>
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvQuestion" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowDataBound="gvQuestion_RowDataBound" OnRowCancelingEdit="gvQuestion_RowCancelingEdit"
        OnRowDeleting="gvQuestion_RowDeleting" OnRowEditing="gvQuestion_RowEditing" OnRowUpdating="gvQuestion_RowUpdating"
        Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <%-- <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>--%>
                    <asp:HiddenField ID="hdQuestionId" Value='' runat="server" />
                    <%--<%# Eval("Id")%>--%>
                    <%--<asp:HiddenField ID="hdQIdRowId" Value='<%# Container.DataItemIndex%>' runat="server" />--%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="40px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" value="on" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdApplicationId" Value='<%#Eval("ID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请单号" SortExpression="ApplicationNo">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ApplicationNo")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<%# Eval("CustomerID")%>--%>
                    <asp:Label ID="lbltxtNickName" Visible="false" runat="server" Text=''></asp:Label>
                    <asp:TextBox ID="txtNickName" runat="server" Width="90%" Text=''></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请时间" SortExpression="CreateDate">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("CreateDate")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<%# Eval("ReceptionDate")== null ? DateTime.Now.ToString("yyyy-MM-dd"):Eval("ReceptionDate") %>--%>
                    <asp:Label ID="lbltxtPayDateStart" runat="server" Text=''></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 120px; word-wrap: break-word;">
                        <asp:LinkButton ID="lbtnOrderNo" runat="server" CommandArgument='<%# Eval("OrderCode")%>'
                            ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<%# Eval("OrderNO")%>--%>
                    <asp:Label ID="lblOrderNO" runat="server" Text='' Visible="false"></asp:Label>
                    <input runat="server" id="txtOrderCode" class="TextBox OrderCode" value='<%# Eval("OrderCode")%>'
                        style="text-align: left; width: 90%" type="text" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOrderCode"
                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="订单号不能为空."
                        ValidationGroup="XMCashBackApplicationValidationGroup">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                        PopupPosition="TopRight" />
                    <%--<asp:Label ID="lblOrderNO" runat="server" Text='<%# Eval("OrderNO")%>' Visible="false"></asp:Label>
                 <HozestERP:SimpleTextBox ID="txtEditOrderNO" runat="server" Width="90%" Text='<%# Eval("OrderNO")%>'
                  ErrorMessage="订单号不能为空."   ValidationGroup="QuestionValidationGroup"    />--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台" SortExpression="PlatformTypeId">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="40px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 40px; word-wrap: break-word;">
                        <%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplication).PlatformType%>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblPlatform" Visible="false" runat="server" Text='<%# Eval("PlatformTypeId")%>'></asp:Label>
                    <asp:DropDownList ID="Platform" runat="server" Width="95%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称" SortExpression="PlatformTypeId">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplication).NickName%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlNick" runat="server" Width="95%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请类型" SortExpression="ApplicationType">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblApplicationType" runat="server" Text='<%# Eval("ApplicationType")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--                <asp:Label ID="lbltxtNickName"  Visible="false" runat="server" Text=''></asp:Label>
               <%-- <input id="hftxtNickId" type="hidden" runat="server" value='<%# Eval("NickID")%>'  />--%>
                    <asp:TextBox ID="txtNickName" runat="server" Width="90%" Text=''></asp:TextBox>--%>
                    <%-- <asp:DropDownList ID="ddlEditNick" Width="95%" runat="server">
                </asp:DropDownList>--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="退款金额" HeaderStyle-HorizontalAlign="Center" SortExpression="Amount">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="Amount" runat="server"><%# Eval("Amount")%></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="补价订单" SortExpression="ReservepriceOrder">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 120px; word-wrap: break-word;">
                        <asp:LinkButton ID="lbtnReservepriceOrder" runat="server" CommandArgument='<%# Eval("ReservepriceOrder")%>'
                            ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="主管审核" HeaderStyle-HorizontalAlign="Center" SortExpression="SupervisorStatus">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="SupervisorStatus" runat="server" Checked='<%# Eval("SupervisorStatus")==null?false: Eval("SupervisorStatus")%>' />
                    <%--<asp:Label ID="SupervisorStatus" runat="server" Text='<%# Eval("SupervisorStatus")%>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流发出" HeaderStyle-HorizontalAlign="Center" SortExpression="GoodsConfirmSendOut">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="GoodsConfirmSendOut" runat="server" Checked='<%# Eval("GoodsConfirmSendOut")==null?false: Eval("GoodsConfirmSendOut")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="货款已退" HeaderStyle-HorizontalAlign="Center" SortExpression="MoneyConfirmReturn">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="MoneyConfirmReturn" runat="server" Checked='<%# Eval("MoneyConfirmReturn")==null?false: Eval("MoneyConfirmReturn")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="仓库签收" HeaderStyle-HorizontalAlign="Center" SortExpression="GoodsConfirmReturn">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="GoodsConfirmReturn" runat="server" Checked='<%# Eval("GoodsConfirmReturn")==null?false: Eval("GoodsConfirmReturn")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="推送千胜" HeaderStyle-HorizontalAlign="Center" SortExpression="SupervisorStatus">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="IsSend" runat="server" Checked='<%# Eval("IsSend")==null?false: Eval("IsSend")%>' />
                    <%--<asp:Label ID="SupervisorStatus" runat="server" Text='<%# Eval("SupervisorStatus")%>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否排单" HeaderStyle-HorizontalAlign="Center" SortExpression="IsSingleRow">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="IsSingleRow" runat="server" Checked='<%# Eval("IsSingleRow")==null?false: Eval("IsSingleRow")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="财务审核" HeaderStyle-HorizontalAlign="Center" SortExpression="FinancialStatus">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# Eval("FinancialStatus")==null?false: Eval("FinancialStatus")%>' />
                    <asp:Label ID="FinancialStatus" runat="server" Text='<%# Eval("FinancialStatus")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="入仓时间" SortExpression="ReturnTime">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("ReturnTime")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<%# Eval("ReceptionDate")== null ? DateTime.Now.ToString("yyyy-MM-dd"):Eval("ReceptionDate") %>--%>
                    <asp:Label ID="lbltxtPayDateStart" runat="server" Text=''></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="完成时间" SortExpression="FinishTime">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("FinishTime")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<%# Eval("ReceptionDate")== null ? DateTime.Now.ToString("yyyy-MM-dd"):Eval("ReceptionDate") %>--%>
                    <asp:Label ID="lbltxtPayDateStart" runat="server" Text=''></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <%--            <asp:TemplateField HeaderText="状态" HeaderStyle-HorizontalAlign="Center" SortExpression="Status">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblQuestionStatus" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%--                    <asp:ImageButton ID="imgBtnList" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"  ValidationGroup="ClientValidationGroup"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" 
                        Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.ListEdit %>" /> --%>
                    <%--                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"  ValidationGroup="ClientValidationGroup"
                        ToolTip="组长点评" CommandName="Edit" CausesValidation="False" 
                        Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.ListEdit %>" /> --%>
                    <asp:ImageButton ID="ImgBtnCR" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageApplication.Details %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageApplication.Delete %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <%--                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="QuestionValidationGroup" 
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.Cancel %>" />--%>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    <table border="0" cellpadding="0" cellspacing="0" width="25%">
        <tr>
            <td style="height: 8px; width: 20px;">
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnManagerAdd_Click" Visible="<% $CRMIsActionAllowed:ManageApplication.Add %>" />
            </td>
            <td style="width: 50px;">
                <div id="DIVDelete" runat="server">
                    <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" Visible="<% $CRMIsActionAllowed:ManageApplication.AllDelete %>"
                        OnClientClick="return CheckSelect(this,99);" OnClick="btnDelete_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                <div id="DIV1" runat="server">
                    <asp:Button ID="Button1" runat="server" SkinID="button4" Text="主管审核" Visible="<% $CRMIsActionAllowed:ManageApplication.Supervisor %>"
                        OnClick="btnSup_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                <div id="DIV3" runat="server">
                    <asp:Button ID="Button3" runat="server" SkinID="button4" Text="主管反审核" Visible="<% $CRMIsActionAllowed:ManageApplication.NoSupervisor %>"
                        OnClick="btnSupNo_Click" />
                </div>
            </td>
            <%--<td style="width: 50px;">
                <div id="DIV2" runat="server">
                    <asp:Button ID="Button2" runat="server" SkinID="button4" Text="财务审核" Visible="<% $CRMIsActionAllowed:ManageApplication.Financial %>"
                        OnClick="btnFin_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                <div id="DIV4" runat="server">
                    <asp:Button ID="Button4" runat="server" SkinID="button4" Text="财务反审核" Visible="<% $CRMIsActionAllowed:ManageApplication.NoFinancial %>"
                        OnClick="btnFinNo_Click" />
                </div>
            </td>--%>
            <td style="width: 50px;">
                <div id="DIV5" runat="server">
                    <asp:Button ID="Button5" runat="server" SkinID="button4" Text="生成发货单" Visible="<% $CRMIsActionAllowed:ManageApplication.ToDeliver %>"
                        OnClick="btnDeliver_Click" />
                </div>
            </td>
            <td style="width: 50px;">
                      <asp:Button ID="btnManualPlanBill" SkinID="button6" runat="server" Text="批量手动排单"
                   Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoList.ManualPlanBill %>" />
            </td>

            <%--  <asp:Button ID="hidBtnDealPaymentDealWith" runat="server" Style="width: 0px; display: none;" ToolTip="赔付处理结果"   OnClick="hidBtnDealPaymentDealWith_Click" /> 
            --%>
            <td style="width: 50px;">
                <asp:Button ID="btnGoodsConfirmSendOut" runat="server" SkinID="button6" Text="客户确认发出"
                    Visible="<% $CRMIsActionAllowed:ManageApplication.GoodsConfirmSendOut %>" OnClick="btnGoodsConfirmSendOut_Click" />
            </td>
            <td style="width: 130px;padding-left:5px">
                <ext:Button runat="server" ID="btnGoodsConfirmReturn" Text="仓库签收" SkinID="button6" Visible="<% $CRMIsActionAllowed:ManageApplication.GoodsConfirmReturn %>" Width="120">
                    <DirectEvents>
                        <Click OnEvent="btnGoodsConfirmReturn_Click">

                        </Click>
                    </DirectEvents>
                </ext:Button>
<%--                <asp:Button ID="btnGoodsConfirmReturn" runat="server" SkinID="button6" Text="仓库签收"
                    Visible="<% $CRMIsActionAllowed:ManageApplication.GoodsConfirmReturn %>" OnClick="btnGoodsConfirmReturn_Click" />--%>
            </td>
             <td style="width: 50px;">
                <asp:Button ID="btnSendQS" runat="server" SkinID="button6" Text="推送千胜"
                    Visible="<% $CRMIsActionAllowed:ManageApplication.SendQS %>" OnClick="btnSendQS_Click" />
            </td>
            <td style="width: 50px;">
                <asp:Button ID="btnMoneyConfirmReturn" runat="server" SkinID="button6" Text="货款确认退回"
                    Visible="<% $CRMIsActionAllowed:ManageApplication.MoneyConfirmReturn %>" OnClick="btnMoneyConfirmReturn_Click" />
            </td>
            <td style="width: 50px;">
                <asp:Button ID="btnpaidan" runat="server" SkinID="button6" Text="无订单排单" Visible="<% $CRMIsActionAllowed:ManageApplication.NoOrderPaiDan %>"/>
            </td>
            <td style="width: 50px;">
                <asp:Button ID="btnImportLogisticsFee" runat="server" SkinID="button6" Text="导入物流费用" />
            </td>
        </tr>
        <tr>
            <td style="height: 8px;">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
    </table>
    <ext:Window ID="window1" runat="server" Width="300" Height="150" Hidden="true">
        <Items>
            <ext:FormPanel ID="FormPanel1" runat="server" Border="false" MonitorValid="true" BodyStyle="background-color:transparent;" Layout="FormLayout">
                <Items>
                    <ext:ComboBox runat="server" ID="ddlProject" Editable="false" FieldLabel="项目" AnchorHorizontal="98%" DisplayField="ProjectName" ValueField="Id" EmptyText="选择项目">
                        <Store>
                            <ext:Store runat="server" ID="projectStore">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="ProjectName"></ext:RecordField>
                                            <ext:RecordField Name="Id"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <DirectEvents>
                            <Select OnEvent="project_Select">

                            </Select>
                        </DirectEvents>
                    </ext:ComboBox>
                    <ext:ComboBox runat="server" ID="ddlHouse" Editable="false" FieldLabel="仓库" AnchorHorizontal="98%" DisplayField="Name" ValueField="Id" EmptyText="选择仓库">
                        <Store>
                            <ext:Store runat="server" ID="houseStore">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="Name"></ext:RecordField>
                                            <ext:RecordField Name="Id"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:DateField runat="server" ID="dfReturnTime" FieldLabel="入仓时间" AnchorHorizontal="98%" Format="yyyy-MM-dd"></ext:DateField>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSave" Text="保存" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnSave_Click">

                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Window>
</asp:Content>
