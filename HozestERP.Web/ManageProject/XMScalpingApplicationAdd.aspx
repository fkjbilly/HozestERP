<%@  Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
AutoEventWireup="true" CodeBehind="XMScalpingApplicationAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMScalpingApplicationAdd" %> 
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
                                    label: item.ProductName + " 编码：" + item.ManufacturersCode,
                                    value: item.ProductName,
                                    product: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    $("#<%= gvScalpingApplicationDetails.ClientID%> :hidden[id*='hfProductId']").val(i.item.product.Id); 
                }
            });
        } 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <span class="detailTitle"  style="float: left;">刷单申请</span> 

    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>    
            <tr> 
            <td style="width: 140px" align="right"> 
                平台类型<font color="red">*</font>:
            </td>
            <td style="width: 200px">   
                <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="95%"  ValidationGroup="ModuleValidationGroup"
                 ErrorMessage="平台类型为必填.">
                </asp:DropDownList> 
                </td> 
                 <td style="width: 140px"  align="right">
                店铺名称<font color="red">*</font>:
                </td>
            <td style="width: 200px;">
                <asp:DropDownList ID="ddNickId" runat="server" Width="95%"  ValidationGroup="ModuleValidationGroup">
                </asp:DropDownList> 
            </td> 
                 <td style="width: 140px"  align="right">
                刷单申请编码:
            </td> 
              <td    style="width: 200px"> 
              <asp:Label ID="lblScalpingNo" runat="server"></asp:Label>
                <%--<asp:TextBox ID="txtScalpingNo" runat="server"   Width="95%" ></asp:TextBox>--%>
                         
              </td> 
              
            </tr> 
            <tr> 
             <td style="width: 140px" align="right">
                刷单开始日期<font color="red">*</font>:
               </td>  
                <td width="200px">  
            <input id="txtScalpingBeginTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
              runat="server" style=" width:95%;"   ValidationGroup="ModuleValidationGroup" />
             
                </td>
                <td style="width: 140px" align="right">
                刷单结束日期<font color="red">*</font>:
               </td>  
                <td width="200px">  
                  <input id="txtScalpingEndTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" 
                   runat="server" style=" width:95%;"  ValidationGroup="ModuleValidationGroup" />
                </td>
               <td style="width: 140px" align="right">
                部门审核:
               </td>  
                <td width="200px">    
                 <asp:CheckBox ID="ckbManagerIsAudit" runat="server" AutoPostBack="True"  Enabled="false"/> 
                </td> 
              
            </tr>
            <tr>
             <td style="width: 140px" align="right">
                说明<font color="red">*</font>:
            </td>
            <td colspan="5">  
             <HozestERP:SimpleTextBox ID="txtExplanation" runat="server"  Width="99%" Height="45"   TextMode="MultiLine"   
             ValidationGroup="ModuleValidationGroup" ErrorMessage="说明为必填."/> 
            </td>  
            </tr>
             
            <tr> 
            <td colspan="6"> 
                 <div id="DivScalpingApplicationDetails" runat="server">
                    <asp:GridView ID="gvScalpingApplicationDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="ScalpingDetailsId"
                        SkinID="GridViewThemen" OnRowDataBound="gvScalpingApplicationDetails_RowDataBound" OnRowCancelingEdit="gvScalpingApplicationDetails_RowCancelingEdit"
                        OnRowDeleting="gvScalpingApplicationDetails_RowDeleting" OnRowEditing="gvScalpingApplicationDetails_RowEditing"
                        OnRowUpdating="gvScalpingApplicationDetails_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>


                          <asp:TemplateField HeaderText="产品名称">
                                <HeaderStyle Width="160px" HorizontalAlign="Center" />
                                <ItemStyle Width="160px" Wrap="false"></ItemStyle>
                                <ItemTemplate>
                                     <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalpingApplicationDetails).Product != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalpingApplicationDetails).Product.ProductName : ""%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input runat="server" id="txtProductName" class="TextBox ProductName" style="text-align: left;  
                                        width: 90%" type="text" />
                                    <input id="hfProductId" type="hidden" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProductName"
                                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="产品名称不能为空."
                                        ValidationGroup="DetailsValidationGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                        PopupPosition="TopRight" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="刷单时间"  SortExpression="ScalpingTime">
                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                     <asp:Label ID="lblScalpingTime" runat="server" Text='<%# Eval("ScalpingTime")==null?"":DateTime.Parse(Eval("ScalpingTime").ToString()).ToString("yyyy-MM-dd")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                   <input id="txtScalpingTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"  runat="server" style=" width:85%;"
                                     value='<%#Eval("ScalpingTime")==null?"":DateTime.Parse(Eval("ScalpingTime").ToString()).ToString("yyyy-MM-dd")%>' />
                                      <asp:Label ID="lblScalpingTime1" runat="server" Text="" ForeColor="red"></asp:Label>
                                </EditItemTemplate> 
                             </asp:TemplateField> 

                            <asp:TemplateField HeaderText="所需流量" SortExpression="">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("RequiredFlow")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <HozestERP:SimpleTextBox ID="txtRequiredFlow" runat="server"   Text='<%# Eval("RequiredFlow") %>'  Columns="50"  
                                    title="请输入所需流量~:float!" Width="90%"    ValidationGroup="DetailsValidationGroup" Display="None" ErrorMessage="所需流量为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="自然流量" SortExpression="">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("NaturalFlow")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <HozestERP:SimpleTextBox ID="txtNaturalFlow" runat="server"   Text='<%# Eval("NaturalFlow") %>'  Columns="50"  title="请输入自然流量~:float!" Width="90%"  
            ValidationGroup="DetailsValidationGroup" ErrorMessage="自然流量为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="流量缺口" SortExpression="">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                 <asp:Label ID="lblFlowGap" runat="server"></asp:Label>
                                </ItemTemplate> 
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="预计成交" SortExpression="">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("ForecastDeal")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--<asp:TextBox ID="txtTheAdvanceMoney"   Text='<%# Eval("TheAdvanceMoney") %>'  runat="server"></asp:TextBox>--%>
                                    <HozestERP:SimpleTextBox ID="txtForecastDeal" runat="server"   Text='<%# Eval("ForecastDeal") %>'  Columns="50"  title="请输入预计成交~:int!" Width="90%"  
            ValidationGroup="DetailsValidationGroup" ErrorMessage="预计成交为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="预计刷单数量" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("ForecastScalpingQuantity")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                 <HozestERP:SimpleTextBox ID="txtForecastScalpingQuantity" runat="server"   Text='<%# Eval("ForecastScalpingQuantity") %>'  Columns="50"  title="请输入预计刷单数量~:int!" Width="90%"  
            ValidationGroup="DetailsValidationGroup" ErrorMessage="预计刷单数量为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="转化率控制%" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("ConversionRate")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <HozestERP:SimpleTextBox ID="txtConversionRate" runat="server"   Text='<%# Eval("ConversionRate") %>'  Columns="50"  
                                    title="请输入转化率控制~:float!" Width="90%"    ValidationGroup="DetailsValidationGroup" ErrorMessage="转化率控制为必填."/>
                                     <asp:Label ID="lblConversionRate" runat="server" Text="" ForeColor="red"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="客单价" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("CustomerPrice")%>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                    <HozestERP:SimpleTextBox ID="txtCustomerPrice" runat="server"   Text='<%# Eval("CustomerPrice") %>'  Columns="50"  
                                    title="请输入客单价~:float!" Width="90%"   ValidationGroup="DetailsValidationGroup"   Display="None" ErrorMessage="客单价为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>  
                            
                            <asp:TemplateField HeaderText="销售额" SortExpression="">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <asp:Label ID="lblSales" runat="server"></asp:Label>
                                </ItemTemplate> 
                            </asp:TemplateField>  

                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                <ItemStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationAddDetails.Edit %>" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                        Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationAddDetails.Delete %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="DetailsValidationGroup"
                                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationAddDetails.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationAddDetails.Cancel %>" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
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
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationAdd.Save %>"/>
            </td>
            
        </tr>
    </table>
     <script type="text/javascript"> 
         
         $(function () { 
             autoCompleteBind();
         });
    </script>
</asp:Content>



