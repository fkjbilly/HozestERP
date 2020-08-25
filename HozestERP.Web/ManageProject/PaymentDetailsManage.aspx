<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
 AutoEventWireup="true" CodeBehind="PaymentDetailsManage.aspx.cs" Inherits="HozestERP.Web.ManageProject.PaymentDetailsManage" %>
   
<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 

<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript">
      function autoCompleteBind() {
          $(".ProductName").autocomplete({
              source: function (request, response) {
                  jQuery.ajax({
                      url: "XMScalpingApplicationReturnedHandler.ashx?action=PremiumsDetails",
                      data: "q=" + encodeURI(request.term),
                      type: "GET",
                      dataType: "json",
                      success: function (data) {
                          response($.map(data, function (item) {
                              return {
                                  label: item.ProductName + ", 编码:" + item.ManufacturersCode + ", 尺寸:" + item.Specifications + ", 出厂价:" + item.Costprice,
                                  value: item.ProductName,
                                  product: item
                              }
                          }));
                      }
                  });
              }
          }, {
              select: function (e, i, j) {
                  $("#<%= hfProductId.ClientID%>").val(i.item.product.Id);
                  $("#<%= txtEditSpecifications.ClientID%>").val(i.item.product.Specifications);
              }
          });
      } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table   border="0" cellspacing="0"  > 
           <tr>
            <td style="width: 100px"  align="right">
                    赔付类型<font color="red">*</font>:
                    </td>
                <td style="width: 200px;">
                 <asp:DropDownList runat="server" ID="ddlDealPaymentTypeId" OnSelectedIndexChanged="ddlDealPaymentId_SelectedIndexChanged"
                  AutoPostBack="true"  Width="95%" ValidationGroup="ModuleValidationGroup">
                      </asp:DropDownList>  
                </td> 
                <td></td>
            </tr>  
             <tr>
                  <td id="TD1" runat="server" colspan="3" style="width:100%;">
                        <table  style="width:100%;">
                                <tr> 
                                   <td style="width: 100px"  align="right">
                                     赔付金额<font color="red">*</font>:
                                    </td>
                                    <td style="width: 200px;">
                                     <HozestERP:SimpleTextBox ID="txtPaymentMoney" runat="server"   Columns="50" Text="0.00" title="请输入赔付金额~:float!" Width="95%"  
                                         ValidationGroup="ModuleValidationGroup" ErrorMessage="赔付金额为必填."/> 
                                    </td> 
                                    <td></td>
                              </tr>
                        </table>
                    </td> 
               </tr> 
             <tr>
                  <td id="TD2" runat="server" colspan="3" style="width:100%;">
                        <table >
                                <tr> 
                                   <td style="width: 100px"  align="right">
                                     商品名称<font color="red">*</font>:
                                    </td>
                                    <td style="width: 200px;">
                                      <asp:UpdatePanel ID="up" runat="server">
                                        <ContentTemplate>  
                                           <input runat="server" id="txtProductName" class="TextBox ProductName" style="text-align: left;   width: 95%" type="text" />
                                               <asp:Label ID="lblMag" runat="server" Text="" ForeColor="Red"></asp:Label> 
                                   
                                            <input id="hfProductId" type="hidden" runat="server" />
                                         </ContentTemplate>
                                      </asp:UpdatePanel> 

                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductName" Font-Name="verdana" Font-Size="9pt" runat="server" 
                                            Display="None" ErrorMessage="商品名称不能为空."  ValidationGroup="ModuleValidationGroup">*</asp:RequiredFieldValidator>
                                       <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                                TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"  PopupPosition="TopRight" />
                                     </td> 
                                    <td style="width: 100px"  align="right">
                                    尺寸
                                    </td>
                                    <td style="width: 200px;"> 
                                    <asp:TextBox ID="txtEditSpecifications" runat="server" ReadOnly="true" Width="95%"  > </asp:TextBox> 
                                    </td>
                                    <td style="width: 100px"  align="right">
                                    数量<font color="red">*</font>
                                    </td>
                                    <td style="width: 200px;">
                                     <HozestERP:SimpleTextBox ID="txtProductNum" runat="server"    Columns="50" title="请输入数量~:int!" Width="95%"  
                                           ValidationGroup="ModuleValidationGroup" ErrorMessage="数量为必填."/>
                                   </td>
                              </tr>
                        </table>
                    </td> 
               </tr> 
                
    </table> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0"> 
        <tr>
         <td style="text-align:right;">
          
         <asp:Button ID="btnSave" SkinID="Button2" runat="server" Text="确定" OnClick="btnSave_Click"  ValidationGroup="ModuleValidationGroup" />
        </td>
        
        </tr>
    </table>
     <script type="text/javascript">

         $(function () {
             autoCompleteBind();
         });
    </script>
</asp:Content>

