<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" CodeBehind="XMScalpingAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMScalpingAdd" %>
  
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
    function autoCompleteBindScalpingAdd() {
        $("#<%= txtScalpingCode.ClientID%>").autocomplete({
            source: function (request, response) {
                jQuery.ajax({
                    url: "../ManageFinance/ScalpingCodeHandler.ashx?action=SelectByAdvanceState",
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
 
    <span class="detailTitle"  style="float: left;">刷单信息</span> 

    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody> 

           <tr> 
             <td style="width: 140px" align="right">
                刷单单号<font color="red">*</font>:
             </td>  
             <td width="200px">  
              <input runat="server" id="txtScalpingCode" class="TextBox ScalpingCode" style="text-align: left;  width: 95%" type="text"/>
                    <input id="hfScalpingId" type="hidden" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtScalpingCode"  Font-Name="verdana" Font-Size="9pt"
                        runat="server" Display="None" ErrorMessage="刷单单号不能为空."  ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"  TargetControlID="RequiredFieldValidator1" 
                        HighlightCssClass="validatorCalloutHighlight"  PopupPosition="TopRight" />
             </td>
            <td style="width: 140px" align="right">
                 平台类型<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                 <input id="hfPlatformTypeId" type="hidden" runat="server" />
                    <asp:TextBox ID="txtPlatformType" runat="server" Width="95%" Enabled="false"></asp:TextBox> 
             </td>
            <td style="width: 140px" align="right">
                  店铺名称<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                 <input id="hfNickId" type="hidden" runat="server" /> 
                    <asp:TextBox ID="txtNickName" runat="server" Width="95%" Enabled="false"></asp:TextBox> 
            </td> 
            </tr> 
             
            <tr> 
             <td style="width: 140px" align="right">
                订单号<font color="red">*</font>:
             </td>  
             <td width="200px">   
             <asp:HiddenField ID="hidOrderCode" runat="server" /> 
             <HozestERP:SimpleTextBox ID="txtOrderCode" runat="server"  Width="95%"   ValidationGroup="ModuleValidationGroup" ErrorMessage="订单号为必填."/> 
             </td>
            <td style="width: 140px" align="right">
                 旺旺号<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                
            <HozestERP:SimpleTextBox ID="txtWantID" runat="server"   Width="95%"     ValidationGroup="ModuleValidationGroup" ErrorMessage="旺旺号为必填."/> 
            </td>
            <td style="width: 140px" align="right">
                  商品<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                
            <HozestERP:SimpleTextBox ID="txtProductName" runat="server"   Width="95%"     ValidationGroup="ModuleValidationGroup" ErrorMessage="商品为必填."/> 
            </td> 
            </tr>
            
            <tr> 
           <td style="width: 140px"  align="right">
                销售价<font color="red">*</font>:
            </td>
           <td style="width: 200px"> 
                <HozestERP:SimpleTextBox ID="txtSalePrice" runat="server"   Columns="50" Text="0.00" title="请输入销售价~:float!" Width="95%"  
                ValidationGroup="ModuleValidationGroup" ErrorMessage="销售价为必填."  />  
            </td>
              
            <td style="width: 140px" align="right">
                佣金<font color="red">*</font>:
            </td>
            <td style="width: 200px">
                 <HozestERP:SimpleTextBox ID="txtFee" runat="server"   Columns="50" Text="0.00" title="请输入佣金~:float!" Width="95%"  
                 ValidationGroup="ModuleValidationGroup" ErrorMessage="佣金为必填."/>  
            </td> 
             <td style="width: 140px" align="right">
                <%--扣点<font color="red">*</font>:--%>
            </td>
            <td style="width: 200px">
                <%-- <HozestERP:SimpleTextBox ID="txtDeduction" runat="server"   Columns="50" Text="0.00" title="请输入扣点~:float!" Width="95%"  
                 ValidationGroup="ModuleValidationGroup" ErrorMessage="扣点为必填."/>  --%>
            </td>
            </tr> 
           <%-- <tr>
              <td style="width: 140px" align="right">
                负责人<font color="red">*</font>:
            </td>
            <td style="width: 200px">
                    <HozestERP:SelectSingleCustomerControl ID="txtLeader" runat="server" ErrorMessage="负责人为必填."   style="text-align: left;  width: 95%" type="text" 
                    PopupPosition="BottomLeft"    ValidationGroup="ModuleValidationGroup"   SessionPageID="OperationLeader" />  
            </td>
              <td style="width: 140px" align="right">
                 渠道类型
            </td>
            <td style="width: 200px">
                   <HozestERP:CodeControl ID="ddType" runat="server" CodeType="190"    Width="95%" />
            </td>
              <td style="width: 140px" align="right">
                 
            </td>
            <td style="width: 200px">
                     
            </td>  
            </tr> --%>
              
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
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingAdd.Save %>"/>
            </td>
            
        </tr>
    </table>

   <script type="text/javascript">
       $(function () {

           autoCompleteBindScalpingAdd();
       });
    </script>

</asp:Content>


