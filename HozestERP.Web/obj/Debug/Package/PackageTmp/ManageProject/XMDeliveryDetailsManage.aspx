<%@  Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
AutoEventWireup="true" CodeBehind="XMDeliveryDetailsManage.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMDeliveryDetailsManage" %> 

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 

<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
<script type="text/javascript">
    function autoCompleteBind() {
        $(".ProductName").autocomplete({
            source: function (request, response) {
                jQuery.ajax({
                    url: "XMScalpingApplicationReturnedHandler.ashx?action=ProductName",
                    data: "q=" + encodeURI(request.term),
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.ProductName + ", 编码:" + item.ManufacturersCode + ", 尺寸:" + item.Specifications,
                                value: item.ProductName,
                                product: item
                            }
                        }));
                    }
                });
            }
        }, {
            select: function (e, i, j) {
                $("#<%= grdXMDeliveryDetailsManage.ClientID%> :hidden[id*='hfProductId']").val(i.item.product.Id);
                $("#<%= grdXMDeliveryDetailsManage.ClientID%> :text[id*='txtPlatformMerchantCode']").val(i.item.product.ManufacturersCode);
                $("#<%= grdXMDeliveryDetailsManage.ClientID%> :text[id*='txtEditSpecifications']").val(i.item.product.Specifications); 
            }
        });
    } 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <span class="detailTitle"  style="float: left;">发货单明细</span>  
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>    
            <tr> 

            <td style="width: 80px"  align="right">
                发货单号:
                </td>
            <td style="width: 150px;">
              <asp:Label ID="lblDeliveryNumber" runat="server"></asp:Label> 
            </td> 
            <td style="width: 80px" align="right"> 
              <%--  收货人地址:--%>
            </td>
            <td style="width: 150px">    
             <%-- <asp:Label ID="lblOrderCode" runat="server"></asp:Label>  --%>
            </td> 
                  
            <td></td>
            <td></td>
            </tr> 
          
            <tr> 
            <td colspan="6">  
                    <asp:GridView ID="grdXMDeliveryDetailsManage" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowDataBound="grdXMDeliveryDetailsManage_RowDataBound" OnRowCancelingEdit="grdXMDeliveryDetailsManage_RowCancelingEdit"
                        OnRowDeleting="grdXMDeliveryDetailsManage_RowDeleting" OnRowEditing="grdXMDeliveryDetailsManage_RowEditing"
                        OnRowUpdating="grdXMDeliveryDetailsManage_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>  
                          <asp:TemplateField HeaderText="商品名称">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                <ItemStyle Width="120px" Wrap="false"></ItemStyle>
                                <ItemTemplate>
                                <%# Eval("PrdouctName")%>
                                 </ItemTemplate>
                                <EditItemTemplate>
                                    <input runat="server" id="txtProductName" class="TextBox ProductName" style="text-align: left;  
                                        width: 90%" type="text" value='<%# Eval("PrdouctName")%>' />
                                    <input id="hfProductId" type="hidden" runat="server"  value='<%# Eval("ProductlId")%>' />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductName"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="商品名称不能为空."
                                        ValidationGroup="DetailsValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="商品编码" SortExpression="PlatformMerchantCode">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                 <%# Eval("PlatformMerchantCode")%>
                                </ItemTemplate>
                                 <EditItemTemplate>   
                                      <asp:TextBox ID="txtPlatformMerchantCode" runat="server" Width="90%" Text='<%# Eval("PlatformMerchantCode") %>'   
                                      ValidationGroup="DetailsValidationGroup" ></asp:TextBox>
                                 </EditItemTemplate>
                            </asp:TemplateField>  

                            
                             <asp:TemplateField HeaderText="尺寸" >
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>   
                                 <%# Eval("Specifications")%>
                                <%-- <asp:TextBox ID="txtSpecifications" runat="server" ReadOnly="true" > </asp:TextBox> --%>
                                </ItemTemplate>
                                 <EditItemTemplate>   
                                 <asp:TextBox ID="txtEditSpecifications" runat="server"   Text='<%# Eval("Specifications")%>'> </asp:TextBox> 
                                 </EditItemTemplate>
                            </asp:TemplateField>  
                             
                            <asp:TemplateField HeaderText="数量" SortExpression="">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("ProductNum")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                 <HozestERP:SimpleTextBox ID="txtProductNum" runat="server"   Text='<%# Eval("ProductNum") %>'  Columns="50" title="请输入数量~:int!" Width="90%"  
                                   ValidationGroup="DetailsValidationGroup" ErrorMessage="数量为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>   
                               
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                <ItemStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMDeliveryDetailsManage.Edit %>" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                        Visible="<% $CRMIsActionAllowed:ManageProject.XMDeliveryDetailsManage.Delete %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="DetailsValidationGroup"
                                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageProject.XMDeliveryDetailsManage.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMDeliveryDetailsManage.Cancel %>" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView> 
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
            </td>
            
        </tr>
    </table>
     <script type="text/javascript">

         $(function () {
             autoCompleteBind();
         });
    </script>
</asp:Content>




