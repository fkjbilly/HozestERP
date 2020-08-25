<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMPremiumsList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMPremiumsList"
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
               function SavePremiunsInfoIDs() {
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px; text-align: right;">
                项目名称:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                店铺名称:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 80px; text-align: right;">
                平台:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 90px; text-align: right;">
                订单号:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 90px; text-align: right;">
                旺旺号:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtWantNo" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 90px; text-align: right;">
                申请类型:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddPremiumsTypeId" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="11" Text="赠品"></asp:ListItem>
                    <asp:ListItem Value="10" Text="赔付"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <%-- <td style="width: 60px; text-align: right;">
            财务审核:
            </td>
         <td style="width: 120px;">
            <asp:DropDownList ID="ddFinanceIsAudit" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="0" Text="否" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="是"></asp:ListItem> 
             </asp:DropDownList> 
         </td>--%>
            <td style="width: 80px; text-align: right;">
                创建日期:
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <HozestERP:DatePicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                </HozestERP:DatePicker>
            </td>
            <td align="center">
                至
            </td>
            <td style="width: 120px" nowrap="nowrap">
                <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                </HozestERP:DatePicker>
            </td>
            <%--<td style="width: 90px; text-align: right;">
                赠品状态:
            </td>
            <td style="width: 150px">
                <asp:DropDownList ID="ddPremiumsStatus" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="6" Text="未排单"></asp:ListItem>
                    <asp:ListItem Value="7" Text="已排单"></asp:ListItem>
                </asp:DropDownList>
            </td>--%>
            <%-- <td style="width: 60px; text-align: right;">
            总监审核:
            </td>
         <td style="width: 120px;">
            <asp:DropDownList ID="ddDirectorStatus" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="3" Text="未审核" ></asp:ListItem>
                        <asp:ListItem Value="4" Text="已审核"></asp:ListItem> 
                        <asp:ListItem Value="5" Text="未通过"></asp:ListItem> 
             </asp:DropDownList> 
         </td> --%>
            <td style="width: 90px; text-align: right;">
                是否排单:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddIsSingleRow" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 90px; text-align: right;">
                项目审核:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddManagerStatus" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="3" Text="未审核"></asp:ListItem>
                    <asp:ListItem Value="4" Text="已审核"></asp:ListItem>
                    <%--<asp:ListItem Value="5" Text="未通过"></asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td style="text-align: right; text-align: right;">
                产品:
            </td>
            <td style="text-align: right">
                <asp:TextBox ID="txtActivityExplanation" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 80px; text-align: right;">
                <asp:Label ID="lblFullName" Text="姓名:" runat="server"></asp:Label>
            </td>
            <td style="width: 160px">
                <asp:TextBox ID="txtFullName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px; text-align: right;">
                <asp:Label ID="lblMobile" Text="手机:" runat="server"></asp:Label>
            </td>
            <td style="width: 160px">
                <asp:TextBox ID="txtMobile" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td colspan="7">
            </td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<%--
OnRowCancelingEdit="gvXMPremiumsList_RowCancelingEdit" 
        OnRowEditing="gvXMPremiumsList_RowEditing" OnRowUpdating="gvXMPremiumsList_RowUpdating"--%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvXMPremiumsList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="gvXMPremiumsList_RowDataBound" OnRowDeleting="gvXMPremiumsList_RowDeleting">
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
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnOrderNo" runat="server" CommandArgument='<%# Eval("Id") %>'
                        Text='<%# Eval("OrderCode")%>' ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                    <%-- <%# Eval("OrderCode")%>--%>
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
            <asp:TemplateField HeaderText="旺旺号" SortExpression="WantId">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WantId")%>
                </ItemTemplate>
                <%-- <EditItemTemplate> 
             
                <asp:Label ID="lblWantId" runat="server" Text='<%# Eval("WantId")%>' Visible="false"></asp:Label>
                  <asp:TextBox ID="txtWantNo" runat="server" Width="90%" Text='<%# Eval("WantId") %>'   ValidationGroup="XMCashBackApplicationValidationGroup" ></asp:TextBox>
                
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="活动说明" SortExpression="ActivityExplanation">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ActivityExplanation")%>
                </ItemTemplate>
                <%--  <EditItemTemplate> 
                  <asp:TextBox ID="txtActivityExplanation" runat="server" Width="90%" Text='<%# Eval("ActivityExplanation") %>'   ValidationGroup="XMCashBackApplicationValidationGroup" ></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgActivityExplanationVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="赔付方" SortExpression="PaymentPersonName">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PaymentPersonName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请类型" SortExpression="PremiumsTypeId">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblPremiumsTypeId" runat="server"></asp:Label>
                </ItemTemplate>
                <%-- <EditItemTemplate> 
               <asp:DropDownList ID="ddPremiumsTypeIdEdit" runat="server" Width="90%" > 
                        <asp:ListItem Value="11" Text="赠品" ></asp:ListItem>
                        <asp:ListItem Value="10" Text="赔付"></asp:ListItem>  
             </asp:DropDownList> 
             </EditItemTemplate>--%>
            </asp:TemplateField>
            <%-- <asp:TemplateField HeaderText="财务审核" SortExpression="FinanceIsAudit">
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
            <asp:TemplateField HeaderText="赠品状态" SortExpression="PremiumsStatus">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblPremiumsStatus" runat="server"></asp:Label>
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
            <%--  <asp:TemplateField HeaderText="项目未审核说明" SortExpression="ManagerExplanation">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblManagerExplanation" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
       <asp:TemplateField HeaderText="总监审核" SortExpression="DirectorStatus">
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
            <asp:TemplateField HeaderText="是否核对" SortExpression="IsEvaluation">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsEvaluation" runat="server" Width="20%" Checked='<%# Eval("IsEvaluation")==null?false: Eval("IsEvaluation")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="核对者" SortExpression="EvaluationName">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Eval("EvaluationName")%>
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
            <asp:TemplateField HeaderText="更新时间" SortExpression="UpdateTime">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("UpdateTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <%--<asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMPremiumsList.Edit %>" />--%>
                    <asp:ImageButton ID="ImgBtnCR" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMPremiumsList.update %>" />
                    <%--<asp:ImageButton ID="imgPremiumsDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="赠品信息" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMPremiumsList.PremiumsDetails %>" />--%>
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:XMPremiumsList.Delete %>" />
                    <asp:ImageButton ID="imgBtnSpareAddress" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Blue/Image/Minutes.png" ToolTip="备用地址" CommandName="SpareAddress"
                        CausesValidation="False" />
                </ItemTemplate>
                <%--   <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="XMCashBackApplicationValidationGroup" 
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMPremiumsList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMPremiumsList.Cancel %>" />
                </EditItemTemplate>--%>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <%--  <td style="width: 4px">
            </td>
            <td>  
                <asp:Button ID="btnFinanceIsAudit"  SkinID="button4" runat="server" Text="财务审核" OnClick="btnFinanceIsAudit_Click" Visible="<% $CRMIsActionAllowed:XMPremiumsList.FinanceIsAudit %>" />
            </td> --%>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerStatus" SkinID="button4" runat="server" Text="项目审核" OnClick="btnManagerStatus_Click"
                    Visible="<% $CRMIsActionAllowed:XMPremiumsList.ManagerStatus %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerStatusNo" SkinID="button4" runat="server" Text="项目反审核"
                    OnClick="btnManagerStatusNo_Click" Visible="<% $CRMIsActionAllowed:XMPremiumsList.ManagerStatusNo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnFinanceStatus" SkinID="button4" runat="server" Text="财务审核"  OnClick="btnFinanceStatus_Click" 
                    Visible="<% $CRMIsActionAllowed:XMPremiumsList.FinanceStatus %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnFinanceStatusNo" SkinID="button4" runat="server" Text="财务反审核" OnClick="btnFinanceStatusNo_Click" 
                   Visible="<% $CRMIsActionAllowed:XMPremiumsList.FinanceStatusNo %>" />
            </td>
            <%--<td style="width: 4px">
            </td>
            <td>   
               <asp:Button ID="hidBtnManagerStatusNO" runat="server" Style="width: 0px; display: none;" ToolTip="项目未通过"   OnClick="hidBtnManagerStatusNO_Click" /> 
               <asp:Button ID="hidManagerStatusNOM" runat="server" Style="width: 0px; display: none;" ToolTip="运营未通过" OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')" 
                 OnClick="hidBtnManagerStatusNOM_Click" />  
                <asp:Button ID="btnManagerStatusNO"  SkinID="button4" runat="server" Text="项目未通过" OnClick="btnManagerStatusNO_Click" 
                Visible="<% $CRMIsActionAllowed:XMPremiumsList.ManagerStatusNO %>" />
            </td> 
            <td style="width: 4px">
            </td>
            <td>  
                <asp:Button ID="btnDirectorStatus"  SkinID="button4" runat="server" Text="总监审核" OnClick="btnDirectorStatus_Click" Visible="<% $CRMIsActionAllowed:XMPremiumsList.DirectorStatus %>" />
            </td> 
            <td style="width: 4px">
            </td>
            <td>   
             <asp:Button ID="hidBtnDirectorStatusNO" runat="server" Style="width: 0px; display: none;" ToolTip="总监未通过"   OnClick="hidBtnDirectorStatusNO_Click" /> 
               <asp:Button ID="hidBtnDirectorStatusNOD" runat="server" Style="width: 0px; display: none;" ToolTip="总监未通过" OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')" 
                 OnClick="hidBtnDirectorStatusNOD_Click" />  
                <asp:Button ID="btnDirectorStatusNO"  SkinID="button4" runat="server" Text="总监未通过" OnClick="btnDirectorStatusNO_Click"
                 Visible="<% $CRMIsActionAllowed:XMPremiumsList.DirectorStatusNO %>" />
            </td> --%>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsSingleRow" SkinID="button2" runat="server" Text="排单" 
                    Visible="<% $CRMIsActionAllowed:XMPremiumsList.IsSingleRow %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsEvaluation" SkinID="button2" runat="server" Text="核对" OnClick="btnIsEvaluation_Click"
                    Visible="<% $CRMIsActionAllowed:XMPremiumsList.IsEvaluation %>" />
            </td>
            <td>
                <asp:Button ID="btnPremiumsAdd" SkinID="button2" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:XMPremiumsListAdd.add %>" />
            </td>
            <td>
                <asp:Button ID="btnExportInfoList" SkinID="button2" runat="server" Text="导出" OnClick="btnExportInfoList_Click"
                    Visible="<% $CRMIsActionAllowed:XMPremiumsListAdd.ExportInfoList %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnBigGiftPacks" SkinID="button6" runat="server" Text="9.9大礼包导入" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnNoOrderImport" SkinID="button6" runat="server" Text="无订单赠品导入" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnPremiumsImport" SkinID="button6" runat="server" Text="赠品导入" />
            </td>
        </tr>
    </table>
    <%-- <script type="text/javascript">

         $(function () {
             autoCompleteBind();
         });
    </script>--%>
</asp:Content>
