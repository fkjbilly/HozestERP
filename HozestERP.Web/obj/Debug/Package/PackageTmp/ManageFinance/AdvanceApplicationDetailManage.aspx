<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
AutoEventWireup="true" CodeBehind="AdvanceApplicationDetailManage.aspx.cs" Inherits="HozestERP.Web.ManageFinance.AdvanceApplicationDetailManage" %> 

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
 <style type="text/css">
 .yangshi{font-weight:bold}  
 </style> 
<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
<script type="text/javascript">
    function autoCompleteBindScalpingCodeManag() {
        $("#<%= txtScalpingCode.ClientID%>").autocomplete({
            source: function (request, response) {
                jQuery.ajax({
                    url: "ScalpingCodeHandler.ashx?action=SelectBy",
                    data: "q=" + encodeURI(request.term),
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.ScalpingCode + "平台：" + item.PlatformTypeName + " 店铺：" + item.NickName,
                                value: item.ScalpingCode,
                                scalping: item
                            }
                        }));
                    }
                });
            }
        }, {
            select: function (e, i, j) {
                $("#<%= hfScalpingId.ClientID%>").val(i.item.scalping.ScalpingId);
                $("#<%= hfPlatformTypeId.ClientID%>").val(i.item.scalping.PlatformTypeId);
                $("#<%= hfNickId.ClientID%>").val(i.item.scalping.NickId);
                $("#<%= txtPlatformType.ClientID%>").val(i.item.scalping.PlatformTypeName);
                $("#<%= txtNickName.ClientID%>").val(i.item.scalping.NickName);
            }
        });
    } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td> 
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px" nowrap="nowrap">
               <span class="yangshi">暂 支 类 型</span>:
            </td>
            <td style="width: 260px"  align="left">
                <asp:Label ID="lblTheAdvanceTypeId" runat="server"></asp:Label> 
                <asp:DropDownList runat="server" ID="ddTheAdvanceType" OnSelectedIndexChanged="ddTheAdvanceType_SelectedIndexChanged"
              AutoPostBack="true"  Width="95%" ValidationGroup="ModuleValidationGroup">
                  </asp:DropDownList> 
            </td>
            <td  colspan="6">
            </td> 
        </tr>
        
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> 
         <tr> 
            <td id="TD2" runat="server" colspan="9">
                <table  style="width:100%">
                    <tr> 
                       <td style="width: 8px; height: 8px">
                          </td>
                       <td style="border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: 0px;  width:11.5%;"  
                            nowrap="nowrap" >
                           <span class="yangshi"> 刷 单 单 号</span>:
                        </td> 
                          <td   id="tdScalpingCode" runat="server" style="border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: 0px; width:21.5%; "  
                            align="left" >
                          <div id="DIVLableScalpingNo" runat="server">

                           <asp:LinkButton ID="lbtnOrderNo" runat="server" 
                        ToolTip="查看订单回款明细" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>


                         <%-- <asp:Label ID="lblScalpingNo" runat="server" Text="Label" Width="95%"></asp:Label>  --%>

                           <asp:HiddenField ID="hdScalpingId" runat="server" />
                           </div>
                          <div id="DIVScalpingNo" runat="server">
                          <asp:UpdatePanel ID="up" runat="server">
                          <ContentTemplate>  
                                <input runat="server" id="txtScalpingCode" class="TextBox ScalpingCode" style="text-align: left;  width: 95%" type="text"  />
                                   <asp:Label ID="lblMag" runat="server" Text="" ForeColor="Red"></asp:Label> 
                                   
                                <input id="hfScalpingId" type="hidden" runat="server" />
                          </ContentTemplate>
                          </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtScalpingCode"  Font-Name="verdana" Font-Size="9pt"
                                 runat="server" Display="None" ErrorMessage="刷单单号不能为空."  ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"  TargetControlID="RequiredFieldValidator1" 
                                 HighlightCssClass="validatorCalloutHighlight"  PopupPosition="TopRight" />
                         </div>
                          </td> 
                        <td style="width: 8px; height: 8px">
                        </td>
                        <td style="width: 11.5%; border-bottom:0px; border-right:1px soild red;" nowrap="nowrap"> 
                           <span class="yangshi">平 台 类 型</span>:
                        </td>
                        <td style="border-bottom-style: none; border-bottom-color: inherit; border-bottom-width: 0px; width:21.5%;"   
                            align="left"  >    
                            <input id="hfPlatformTypeId" type="hidden" runat="server" />
                            <asp:Label ID="lblPlatformType" runat="server" Width="95%"></asp:Label>    
                            <asp:TextBox ID="txtPlatformType" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            </td>
                            
                            <td style="width: 8px; height: 8px">
                            </td>
                         <td style="width: 11.5%; border-bottom:0px; border-right:1px soild red;"  nowrap="nowrap">
                           <span class="yangshi">店铺名称</span>:
                            </td>
                        <td style=" border-bottom:0px;  border-right:0px; width:21.5%;"   align="left"> 
                            <input id="hfNickId" type="hidden" runat="server" /> 
                            <asp:Label ID="lblNickName" runat="server" Width="95%"></asp:Label>    
                            <asp:TextBox ID="txtNickName" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                        </td>  
                    </tr> 
                </table>  
            </td> 
            </tr>

        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> 
         
        <tr> 
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px" nowrap="nowrap">
               <span class="yangshi">申 请 部 门</span>:
            </td>
            <td style="width: 260px" align="left">
                <asp:Label ID="lblApplicationDepartment" runat="server" ></asp:Label> 
                <asp:DropDownList ID="ddApplicationDepartment" runat="server" Width="95%" >
                </asp:DropDownList>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px" nowrap="nowrap">
               <span class="yangshi">受款人和账号</span>:
            </td>
            <td style="width: 260px" align="left" colspan="4">
                <asp:Label ID="lblApplicationPayee" runat="server"></asp:Label> 
                <HozestERP:SimpleTextBox ID="txtApplicationPayee" runat="server"  Text="请输入银行账号或支付宝账号"
             OnFocus="javascript:if(this.value=='请输入银行账号或支付宝账号') {this.value='';this.style.color='blue'}"
              OnBlur="javascript:if(this.value==''){this.value='请输入银行账号或支付宝账号';this.style.color='red'}" 
              ForeColor="Gray"   Width="98%"  ValidationGroup="ModuleValidationGroup"  ErrorMessage="申请受款人为必填."/>
            </td> 
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
       
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px" nowrap="nowrap">
                <span class="yangshi">暂 支 事 由</span>:
            </td>
            <td colspan="7" align="left">
             <asp:Label ID="lblTheAdvanceSubject" runat="server"  Style="width: 80%; height: 45px;"    TextMode="MultiLine"></asp:Label> 
             <HozestERP:SimpleTextBox ID="txtTheAdvanceSubject" runat="server"  Width="99%" Height="45"   TextMode="MultiLine"   
             ValidationGroup="ModuleValidationGroup" ErrorMessage="暂支事由为必填."/> 
            </td> 
             
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
             <td style="width: 100px" nowrap="nowrap">
                <span class="yangshi">暂支金额</span>:
            </td>
            <td style="width: 260px" align="left">  
                <asp:Label ID="lblTheAdvanceMoney" runat="server"></asp:Label> <font color="red"><asp:Label ID="lblSUMTheAdvanceMoney" runat="server"></asp:Label> </font>
            <HozestERP:SimpleTextBox ID="txtTheAdvanceMoney" runat="server"   Columns="50" Text="0.00" title="请输入暂支金额~:float!" Width="95%"  
            ValidationGroup="ModuleValidationGroup" ErrorMessage="暂支金额为必填."/>  
            </td>
            <td style="width: 8px; height: 8px">
            </td>
              <td style="width: 100px" nowrap="nowrap">
                <font class="yangshi">预计归还日期:</font>
            </td>
            <td style="width: 260px" align="left"> 
                <asp:Label ID="lblForecastReturnTime" runat="server"></asp:Label> 
            <%--<input id="txtForecastReturnTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"  runat="server" style=" width:95%;"/>--%>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
              <td style="width: 100px" nowrap="nowrap">
                <font class="yangshi">科&nbsp;&nbsp;&nbsp; &nbsp;  目:</font>
            </td>
            <td style="width: 260px" align="left"> 
                <asp:Label ID="lblSubject" runat="server"></asp:Label> 
                  <asp:TextBox ID="txtSubject" runat="server"   Width="95%"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> 
        <tr> 
         <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap">
            <span class="yangshi">申&nbsp; 请&nbsp; 人</span>:
            </td>
           <td style="width: 260px" align="left"> 
                <asp:Label ID="lblApplicants" runat="server"></asp:Label> 
             <HozestERP:SelectSingleCustomerControl ID="txtApplicants" runat="server" ErrorMessage="申请人为必填."  
                    PopupPosition="BottomLeft"    ValidationGroup="ModuleValidationGroup"   SessionPageID="OperationApplicants" /> 
            </td>

        <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px" nowrap="nowrap">
            <font class="yangshi">暂  支  状  态:</font>
            </td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblAdvanceState" runat="server"></asp:Label> 
            </td>
       
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">付款时间:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblPaymentTine" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> <tr>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">店 铺 审 核:</font></td>
           <td style="width: 260px" align="left"> 
                <asp:Label ID="lblManagerPeople" runat="server"></asp:Label> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">店铺是否审核:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:CheckBox ID="ckbManagerIsAudit" runat="server" AutoPostBack="True"  Enabled="false" /> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">店铺审核时间:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblManagerTime" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr> 
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">财 务 审 核:</font></td>
           <td style="width: 260px" align="left"> 
                <asp:Label ID="lblFinancePeople" runat="server"></asp:Label> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">财务是否审核:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:CheckBox ID="ckbFinanceIsAudit" runat="server" AutoPostBack="True" Enabled="false" /> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">财务审核时间:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblFinanceAuditTime" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr> 
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">公 司 审 核:</font></td>
           <td style="width: 260px" align="left"> 
                <asp:Label ID="lblDirectorPeople" runat="server"></asp:Label> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">公司是否审核:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:CheckBox ID="chbDirectorIsAudit" runat="server" AutoPostBack="True"  Enabled="false"/> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">公司审核时间:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblDirectorTime" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr> 
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">财 务 确 认:</font></td>
           <td style="width: 260px" align="left"> 
                <asp:Label ID="lblFinanceOkPeople" runat="server"></asp:Label> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">财务是否确认:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:CheckBox ID="ckbFinanceOkIsAudit" runat="server" AutoPostBack="True"  Enabled="false"/> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">确&nbsp; 认&nbsp; 时&nbsp; 间:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblFinanceOkTime" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr> 
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">暂支结束确认人:</font></td>
           <td style="width: 260px" align="left"> 
                <asp:Label ID="lblFinanceAdvanceEndPeople" runat="server"></asp:Label> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">暂支是否结束:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:CheckBox ID="ckbFinanceAdvanceEndIsAudit" runat="server" AutoPostBack="True" Enabled="false" /> 
            </td>
        <td style="width: 8px; height: 8px">
            </td>
            <td  style="width: 100px" nowrap="nowrap"><font class="yangshi">结&nbsp; 束&nbsp; 时&nbsp; 间:</font></td>
           <td style="width: 260px" align="left"> 
               <asp:Label ID="lblFinanceAdvanceEndTime" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td colspan="8">
                <div id="DivPR_PrductDetails" runat="server">
                    <asp:GridView ID="gvAdvanceApplicationDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowDataBound="gvAdvanceApplicationDetail_RowDataBound" OnRowCancelingEdit="gvAdvanceApplicationDetail_RowCancelingEdit"
                        OnRowDeleting="gvAdvanceApplicationDetail_RowDeleting" OnRowEditing="gvAdvanceApplicationDetail_RowEditing"
                        OnRowUpdating="gvAdvanceApplicationDetail_RowUpdating" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="暂支类型" SortExpression="">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>  
                             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).AdvanceTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).AdvanceTypeName.CodeName: ""%>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                     <HozestERP:CodeControl ID="ccAdvanceTypeId" runat="server" CodeType="185" Width="85%" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="领/还款类型" SortExpression="">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).PayTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).PayTypeName.CodeName: ""%>
                             
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <HozestERP:CodeControl ID="ccPayTypeId" runat="server" CodeType="186"  Width="85%" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="金额" SortExpression="">
                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%--<%# Eval("TheAdvanceMoney")%>--%>
                                   <asp:Label ID="lblTheAdvanceMoneyD" runat="server"></asp:Label> 
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--<asp:TextBox ID="txtTheAdvanceMoney"   Text='<%# Eval("TheAdvanceMoney") %>'  runat="server"></asp:TextBox>--%>
                                    <HozestERP:SimpleTextBox ID="txtTheAdvanceMoney" runat="server"   Text='<%# Eval("TheAdvanceMoney") %>'  Columns="50"  title="请输入暂支金额~:float!" Width="95%"  
            ValidationGroup="DetailValidationGroup" ErrorMessage="暂支金额为必填."/>
                                </EditItemTemplate>
                                 <FooterTemplate>
                              <b><asp:Label ID="lblSYTheAdvanceMoney" runat="server"></asp:Label><%--<%= SYTheAdvanceMoney()%>--%></b>
                              </FooterTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="领/还款人" SortExpression="">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                   <asp:Label ID="lblRecipientsFunName" runat="server"></asp:Label> 
                            <%-- <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).RecipientsFunName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).RecipientsFunName.FullName: ""%>--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <HozestERP:SelectSingleCustomerControl ID="txtRecipientsId" runat="server" ErrorMessage="领/还款人为必填."  
                                     PopupPosition="BottomLeft"    ValidationGroup="DetailValidationGroup"   SessionPageID="OperationApplicants" /> 
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="确认时间" SortExpression="">
                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("CreateTime") == null ? "" : DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                </ItemTemplate> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                <ItemStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationDetail.Edit %>" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                        Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationDetail.Delete %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="DetailValidationGroup"
                                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationDetail.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationDetail.Cancel %>" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
          <tr>
        <td style="width: 10px">
            </td> 
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationDetailManage.Save %>"/>
            </td>
            
        </tr>
    </table>

       <script type="text/javascript">
           $(function () {
               autoCompleteBindScalpingCodeManag();
           });
    </script>
</asp:Content>
