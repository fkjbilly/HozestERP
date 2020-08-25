<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" CodeBehind="XMPostAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMPostAdd" %>
  
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
<%--<script type="text/javascript"> 
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
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <span class="detailTitle"  style="float: left;">岗位信息</span> 

    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody> 

           <tr> 
             <td style="width: 140px" align="right">
                岗位名称<font color="red">*</font>:
             </td>  
             <td width="200px">  
              <input runat="server" id="txtPostCode" class="TextBox ScalpingCode" style="text-align: left;  width: 95%" type="text"/>
                    <%--<input id="hfPostId" type="hidden" runat="server" />--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPostCode"  Font-Name="verdana" Font-Size="9pt"
                        runat="server" Display="None" ErrorMessage="岗位名称不能为空."  ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"  TargetControlID="RequiredFieldValidator1" 
                        HighlightCssClass="validatorCalloutHighlight"  PopupPosition="TopRight" />
             </td>
            <td style="width: 140px" align="right">
                 排序<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                 <%--<input id="hfOrderTypeId" type="hidden" runat="server" />--%>
                    <asp:TextBox ID="txtOrderType" runat="server" Width="95%" Enabled="true"></asp:TextBox> 
             </td>

            <td style="width: 140px" align="right">
                 是否停用<font color="red">*</font>:
            </td>  
            <td width="200px"> 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="IsEnable" runat="server" AutoPostBack="True"/>
                    </ContentTemplate>
                    </asp:UpdatePanel>
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
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageProject.XMPostAdd.Save %>"/>
            </td>
            
        </tr>
    </table>

   <script type="text/javascript">
       $(function () {

           autoCompleteBindPostAdd();
       });
    </script>

</asp:Content>


