<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" CodeBehind="AdvanceApplicationAdd.aspx.cs" Inherits="HozestERP.Web.ManageFinance.AdvanceApplicationAdd" %> 
<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register src="../Modules/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %> 
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>

<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 

<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
<script type="text/javascript">
    function autoCompleteBindScalpingCode() {
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
 
    <span class="detailTitle"  style="float: left;">暂支申请</span> 

    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody> 
        <tr>
        <td style="width: 140px"  align="right">
                暂支类型<font color="red">*</font>:
                </td>
            <td style="width: 200px;">
             <asp:DropDownList runat="server" ID="ddTheAdvanceType" OnSelectedIndexChanged="ddTheAdvanceType_SelectedIndexChanged"
              AutoPostBack="true"  Width="95%" ValidationGroup="ModuleValidationGroup">
                  </asp:DropDownList> 
            <%--<HozestERP:CodeControl ID="ddTheAdvanceType" runat="server" CodeType="184" EmptyValue="true"  Width="95%" />--%> 
            </td> 
            <td colspan="4"></td>
        </tr>  
            <tr> 
            <td id="TD2" runat="server" colspan="6">
                <table >
                    <tr> 
                       <td style="width: 139px; border-bottom:0px; border-right:1px soild red;"  align="right">
                            刷单单号<font color="red">*</font>:
                        </td> 
                          <td    style="width: 218px; border-bottom:0px; border-right:1px soild red;">
                          <div id="DIVLableScalpingNo" runat="server">
                          <asp:Label ID="lblScalpingNo" runat="server" Text="Label"></asp:Label>
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
                        <td style="width: 145px; border-bottom:0px; border-right:1px soild red;" align="right"> 
                            平台类型<font color="red">*</font>:
                        </td>
                        <td style="width: 216px; border-bottom:0px; border-right:1px soild red;">    
                            <input id="hfPlatformTypeId" type="hidden" runat="server" />
                            <asp:TextBox ID="txtPlatformType" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="lblPlatformType" runat="server"></asp:Label>
                             
                           <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="95%"  ValidationGroup="ModuleValidationGroup"
                             ErrorMessage="平台类型为必填.">
                            </asp:DropDownList> --%>
                            </td>
                         <td style="width: 140px; border-bottom:0px; border-right:1px soild red;"  align="right">
                            店铺名称<font color="red">*</font>:
                            </td>
                        <td style="width: 200px; border-bottom:0px;  border-right:0px">
            
                            <input id="hfNickId" type="hidden" runat="server" /> 
                            <asp:TextBox ID="txtNickName" runat="server" Width="95%" Enabled="false"></asp:TextBox>
                             <%--<asp:Label ID="lblNickName" runat="server"></asp:Label>
                           
                            <asp:DropDownList ID="ddNickId" runat="server" Width="95%"  ValidationGroup="ModuleValidationGroup">
                            </asp:DropDownList> --%>
                        </td>  
                    </tr> 
                </table>  
            </td> 
            </tr>
            
            <tr> 
             <td style="width: 140px" align="right">
                申请部门<font color="red">*</font>:
               </td>  
                <td width="200px"> 

                <asp:DropDownList ID="ddApplicationDepartment" runat="server" Width="95%" >
                </asp:DropDownList> 
                </td>
            <td style="width: 140px" align="right">
                申请受款人和账号<font color="red">*</font>:
            </td>
            <td colspan="3" style="width: 500px"  >   
                <HozestERP:SimpleTextBox ID="txtApplicationPayee" runat="server"  Text="请输入银行账号或支付宝账号"
             OnFocus="javascript:if(this.value=='请输入银行账号或支付宝账号') {this.value='';this.style.color='blue'}"
              OnBlur="javascript:if(this.value==''){this.value='请输入银行账号或支付宝账号';this.style.color='red'}" 
              ForeColor="Gray"   Width="98%"  ValidationGroup="ModuleValidationGroup"  ErrorMessage="申请受款人为必填."/>
            </td> 
              
            </tr>
            <tr>
             <td style="width: 140px" align="right">
                暂支事由<font color="red">*</font>:
            </td>
            <td colspan="5">  
             <HozestERP:SimpleTextBox ID="txtTheAdvanceSubject" runat="server"  Width="99%" Height="45"   TextMode="MultiLine"   
             ValidationGroup="ModuleValidationGroup" ErrorMessage="暂支事由为必填."/> 
            </td> 
             
            </tr>
            <tr> 
           <td style="width: 140px"  align="right">
                暂支金额<font color="red">*</font>:
            </td>
           <td style="width: 200px"> 
            <HozestERP:SimpleTextBox ID="txtTheAdvanceMoney" runat="server"   Columns="50" Text="0.00" title="请输入暂支金额~:float!" Width="95%"  
            ValidationGroup="ModuleValidationGroup" ErrorMessage="暂支金额为必填."/>  
            </td>
              <td style="width: 140px"  align="right">
                预计归还日期:
            </td>
           <td  style="width: 200px"> 
           <asp:Label ID="lblForecastReturnTime" runat="server"></asp:Label>
            <%--<input id="txtForecastReturnTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"  runat="server" style=" width:95%;"/>--%>
              </td> 

            <td style="width: 140px" align="right">
                科目:
            </td>
            <td style="width: 200px">
                  <asp:TextBox ID="txtSubject" runat="server"   Width="95%"></asp:TextBox>
            </td> 
            
            </tr> 
            <tr>
              <td style="width: 140px" align="right">
                申请人<font color="red">*</font>:
            </td>
            <td style="width: 200px">
             <HozestERP:SelectSingleCustomerControl ID="txtApplicants" runat="server" ErrorMessage="申请人为必填."  
                    PopupPosition="BottomLeft"    ValidationGroup="ModuleValidationGroup"   SessionPageID="OperationApplicants" /> 
                  <%--<asp:TextBox ID="txtApplicants" runat="server"   Width="80%"  ValidationGroup=""></asp:TextBox>--%>
            </td>
              <td style="width: 140px" align="right">
                 
            </td>
            <td style="width: 200px">
                   
            </td>
              <td style="width: 140px" align="right">
                 
            </td>
            <td style="width: 200px">
                     
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
                <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationAdd.Save %>"/>
            </td>
            
        </tr>
    </table>

   <script type="text/javascript">
       $(function () {
       
           autoCompleteBindScalpingCode();
       });
    </script>

</asp:Content>


