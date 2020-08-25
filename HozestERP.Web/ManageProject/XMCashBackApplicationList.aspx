<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMCashBackApplicationList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMCashBackApplicationList"
    EnableEventValidation="true" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <%--<script type="text/javascript">
    function autoCompleteBind() {
        $(".OrderCode").autocomplete({
            source: function (request, response) {
                jQuery.ajax({
                    url: "XMScalpingApplicationReturnedHandler.ashx?action=OrderCode",
                    data: "q=" + encodeURI(request.term),
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.OrderCode + "旺旺号：" + item.WantID + " 姓名：" + item.FullName,
                                value: item.OrderCode,
                                orderInfo: item
                            }
                        }));
                    }
                });
            }
        }
        , {
            select: function (e, i, j) {
                $("#<%= gvXMCashBackApplicationList.ClientID%> :text[id*='txtWantNo']").val(i.item.orderInfo.WantID);
                $("#<%= gvXMCashBackApplicationList.ClientID%> :text[id*='txtBuyerName']").val(i.item.orderInfo.FullName);
            }
        }
        );
    } 
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px">
                项目名称
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 80px">
                店铺名称
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px">
                平台
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right;">
                订单号:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                旺旺号:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtWantNo" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                收款账号:
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtBuyerAlipayNo" runat="server" Width="100%"></asp:TextBox>
            </td>
            <%--<td></td>
            <td></td>--%>
        </tr>
        <tr>
            <td style="width: 80px">
                创建日期
            </td>
            <td style="width: 160px">
                <HozestERP:DatePicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                </HozestERP:DatePicker>
            </td>
            <td style="width: 80px">
                至
            </td>
            <td style="width: 160px">
                <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                </HozestERP:DatePicker>
            </td>
            <td style="width: 80px">
                返现状态:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddCashBackStatus" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未返现"></asp:ListItem>
                    <asp:ListItem Value="1" Text="已返现"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right;">
                申请类型:
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddApplicationTypeId" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="9" Text="返现"></asp:ListItem>
                    <asp:ListItem Value="10" Text="赔付"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 60px; text-align: right;">
                &nbsp;
            </td>
            <td style="width: 120px;">
                &nbsp;
            </td>
            <td style="width: 60px; text-align: right;">
                &nbsp;
            </td>
            <td style="width: 120px">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<%-- OnRowCancelingEdit="gvXMCashBackApplicationList_RowCancelingEdit" 
        OnRowEditing="gvXMCashBackApplicationList_RowEditing"  OnRowUpdating="gvXMCashBackApplicationList_RowUpdating"--%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvXMCashBackApplicationList" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" OnRowDataBound="gvXMCashBackApplicationList_RowDataBound"
        OnRowDeleting="gvXMCashBackApplicationList_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
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
                    <asp:HiddenField ID="hdID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnOrderNo" runat="server" CommandArgument='<%# Eval("Id") %>'
                        Text='<%# Eval("OrderCode")%>' ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                    <%--  <%# Eval("OrderCode")%>--%>
                </ItemTemplate>
                <%--  <EditItemTemplate> 
                <asp:Label ID="lblOrderCode" runat="server" Text='<%# Eval("OrderCode")%>' Visible="false"></asp:Label>
                <input runat="server" id="txtOrderCode" class="TextBox OrderCode" value='<%# Eval("OrderCode")%>' style="text-align: left;   width: 90%" type="text" />   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOrderCode"
                    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="订单号不能为空."
                    ValidationGroup="XMCashBackApplicationValidationGroup">*</asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                    PopupPosition="TopRight" />
             </EditItemTemplate> --%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="旺旺号" SortExpression="WantNo">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WantNo")%>
                </ItemTemplate>
                <%--  <EditItemTemplate> 
                  <asp:TextBox ID="txtWantNo" runat="server" Width="90%" Text='<%# Eval("WantNo") %>'   ValidationGroup="XMCashBackApplicationValidationGroup" ></asp:TextBox>
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="BuyerName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BuyerName")%>
                </ItemTemplate>
                <%--  <EditItemTemplate> 
                  <asp:TextBox ID="txtBuyerName" runat="server" Width="90%" Text='<%# Eval("BuyerName") %>'   ValidationGroup="XMCashBackApplicationValidationGroup" ></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgBuyerNameVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请类型" SortExpression="ApplicationTypeId">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblApplicationTypeId" runat="server"></asp:Label>
                </ItemTemplate>
                <%--  <EditItemTemplate> 
               <asp:DropDownList ID="ddApplicationTypeIdEdit" runat="server" Width="100%" > 
                        <asp:ListItem Value="9" Text="返现" ></asp:ListItem>
                        <asp:ListItem Value="10" Text="赔付"></asp:ListItem>  
             </asp:DropDownList> 
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收款账号" SortExpression="BuyerAlipayNo">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BuyerAlipayNo")%>
                </ItemTemplate>
                <%-- <EditItemTemplate> 
                  <asp:TextBox ID="txtBuyerAlipayNo" runat="server" Width="90%" Text='<%# Eval("BuyerAlipayNo") %>'   ValidationGroup="XMCashBackApplicationValidationGroup" ></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgBuyerAlipayNoVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="赔付方" SortExpression="PaymentPersonName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PaymentPersonName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金额" SortExpression="CashBackMoney">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CashBackMoney")%>
                </ItemTemplate>
                <%-- <EditItemTemplate> 
                  <asp:TextBox ID="txtCashBackMoney" runat="server" Width="90%" Text='<%# Eval("CashBackMoney") %>'   ValidationGroup="XMCashBackApplicationValidationGroup" ></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgCashBackMoneyVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="财务审核" SortExpression="FinanceIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceIsAudit" runat="server" Width="20%" Checked='<%# Eval("FinanceIsAudit")==null?false: Eval("FinanceIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="创建时间" SortExpression="CreateTime">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="返现状态" SortExpression="CashBackStatus">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblCashBackStatus" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="项目审核" SortExpression="ManagerStatus">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblManagerStatus" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="财务审核" SortExpression="FinanceIsAudit">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblFinanceIsAudit" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="更新时间" SortExpression="UpdateTime">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("UpdateTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="项目未审核说明" SortExpression="ManagerExplanation">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblManagerExplanation" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="情况说明" SortExpression="FactSheets">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
             <%# Eval("FactSheets")%>
            </ItemTemplate>
             <EditItemTemplate> 
                  <asp:TextBox ID="txtFactSheets" runat="server" Width="90%" Text='<%# Eval("FactSheets") %>' ></asp:TextBox> 
             </EditItemTemplate>
        </asp:TemplateField> 

       <%-- <asp:TemplateField HeaderText="总监审核" SortExpression="DirectorStatus">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblDirectorStatus" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="总监未审核说明" SortExpression="DirectorExplanation">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblDirectorExplanation" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnCR" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.update %>" />
                    <%-- <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.Edit %>" />--%>
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.Delete %>" />
                </ItemTemplate>
                <%-- <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="XMCashBackApplicationValidationGroup" 
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.Cancel %>" />
                </EditItemTemplate>--%>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <%-- <td style="width: 4px">
            </td>
            <td>  
                <asp:Button ID="btnFinanceIsAudit"  SkinID="button4" runat="server" Text="财务审核" OnClick="btnFinanceIsAudit_Click" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.FinanceIsAudit %>" />
            </td> --%>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerStatus" SkinID="button4" runat="server" Text="项目审核" OnClick="btnManagerStatus_Click"
                    Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.ManagerStatus %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerStatusNo" SkinID="button4" runat="server" Text="项目反审核"
                    OnClick="btnManagerStatusNo_Click" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.ManagerStatusNo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnFinanceStatus" SkinID="button4" runat="server" Text="财务审核" OnClick="btnFinanceStatus_Click" 
                   Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.FinanceStatus %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnFinanceStatusNo" SkinID="button4" runat="server" Text="财务反审核" OnClick="btnFinanceStatusNo_Click" 
                   Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.FinanceStatusNo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="AddCash" SkinID="button2" runat="server" Text="新增" OnClick="btnManagerAdd_Click"
                    Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.add %>" />
            </td>
            <%-- <td style="width: 4px">
            </td>
            <td>   
               <asp:Button ID="hidBtnManagerStatusNO" runat="server" Style="width: 0px; display: none;" ToolTip="项目未通过"   OnClick="hidBtnManagerStatusNO_Click" /> 
               <asp:Button ID="hidManagerStatusNOM" runat="server" Style="width: 0px; display: none;" ToolTip="项目未通过" OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')" 
                 OnClick="hidBtnManagerStatusNOM_Click" />  
                <asp:Button ID="btnManagerStatusNO"  SkinID="button4" runat="server" Text="项目未通过" OnClick="btnManagerStatusNO_Click" 
                Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.ManagerStatusNO %>" />
            </td> 
            <td style="width: 4px">
            </td>
            <td>  
                <asp:Button ID="btnDirectorStatus"  SkinID="button4" runat="server" Text="总监审核" OnClick="btnDirectorStatus_Click" Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.DirectorStatus %>" />
            </td> 
            <td style="width: 4px">
            </td>
            <td>   
             <asp:Button ID="hidBtnDirectorStatusNO" runat="server" Style="width: 0px; display: none;" ToolTip="总监未通过"   OnClick="hidBtnDirectorStatusNO_Click" /> 
               <asp:Button ID="hidBtnDirectorStatusNOD" runat="server" Style="width: 0px; display: none;" ToolTip="总监未通过" OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')" 
                 OnClick="hidBtnDirectorStatusNOD_Click" />  
                <asp:Button ID="btnDirectorStatusNO"  SkinID="button4" runat="server" Text="总监未通过" OnClick="btnDirectorStatusNO_Click"
                 Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.DirectorStatusNO %>" />
            </td> --%>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnCashBackStatus" SkinID="button2" runat="server" Text="返现" OnClick="btnCashBackStatus_Click"
                    Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.CashBackStatus %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExportInfoList" SkinID="button2" runat="server" Text="导出" OnClick="btnExportInfoList_Click"
                     />
            </td>
            <td>
                <%--<asp:Button ID="btnCashBackStatusNO"  SkinID="button4" runat="server" Text="异常未返现" OnClick="btnCashBackStatusNO_Click"
                 Visible="<% $CRMIsActionAllowed:XMCashBackApplicationList.CashBackStatusNO %>" />--%>
            </td>
        </tr>
    </table>
    <%--<script type="text/javascript">

         $(function () {
             autoCompleteBind();
         });
    </script>--%>
</asp:Content>
