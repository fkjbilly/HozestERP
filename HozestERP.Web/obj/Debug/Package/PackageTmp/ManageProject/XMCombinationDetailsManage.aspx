<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master" 
AutoEventWireup="true" CodeBehind="XMCombinationDetailsManage.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMCombinationDetailsManage" %>
 
<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
<script src="../Script/CommonManager.js" type="text/javascript"></script>
   <style type="text/css">
 .yangshi{font-weight:bold}  
 </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
    
        <tr> 
            <td style="width: 100px"align="right">
                <span class="yangshi">店铺名称:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px" align="left">
                <asp:Label ID="lblNickId" runat="server"></asp:Label> 
            </td>
           <%--
            <td style="width: 100px" align="right">
                <span class="yangshi">品&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;牌:</span>
            </td> 
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left">
                <asp:Label ID="lblBrandTypeId" runat="server"></asp:Label> 
            </td>--%>
             
            <td style="width: 100px" align="right">
                <span class="yangshi">产&nbsp;品&nbsp;名&nbsp;称:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left">
                <asp:Label ID="lblProductName" runat="server"></asp:Label> 
            </td> 
            <td style="width: 100px" align="right">
                <span class="yangshi">厂家编码:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left">
                <asp:Label ID="lblManufacturersCode" runat="server"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> 
         
        <%--<tr> 
            <td style="width: 100px" align="right">
               <span class="yangshi">尺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;寸:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left">
                <asp:Label ID="lblSpecifications" runat="server"></asp:Label> 
            </td> 
            <td style="width: 100px" align="right">
               <span class="yangshi">厂家库存:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left">
                <asp:Label ID="lblManufacturersInventory" runat="server"></asp:Label> 
            </td> 
             <td style="width: 100px" align="right">
                <span class="yangshi">预警库存数:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left">  
                <asp:Label ID="lblWarningQuantity" runat="server"></asp:Label> 
            </td> 
              <td style="width: 100px" align="right">
                <span class="yangshi">颜&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;色:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left"> 
                <asp:Label ID="lblProductColors" runat="server"></asp:Label> 
            </td>
        </tr> 
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr> 
              <td style="width: 100px" align="right">
                <span class="yangshi">计量单位:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 260px"  align="left"> 
                <asp:Label ID="lblProductUnit" runat="server"></asp:Label> 
            </td> 
            <td style="width: 100px" align="right">
                <span class="yangshi">是否赠品:</span>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
           <td style="width: 260px"  align="left"> 
               <asp:CheckBox ID="ckbIsPremiums" runat="server" AutoPostBack="True"  Enabled="false" /> 
            </td> 
        </tr>   --%>
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
        </tr>
        <tr> 
            <td colspan="12">
                <div id="DivPR_PrductDetails" runat="server">
                    <asp:GridView ID="gvAdvanceApplicationDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                        SkinID="GridViewThemen" OnRowDataBound="gvAdvanceApplicationDetail_RowDataBound" OnRowCancelingEdit="gvAdvanceApplicationDetail_RowCancelingEdit"
                        OnRowDeleting="gvAdvanceApplicationDetail_RowDeleting" OnRowEditing="gvAdvanceApplicationDetail_RowEditing"
                        OnRowUpdating="gvAdvanceApplicationDetail_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="平台类型" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>  
                             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCombinationDetails).PlatformTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCombinationDetails).PlatformTypeName.CodeName : ""%>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                     <HozestERP:CodeControl ID="ccPlatformTypeId" runat="server" CodeType="182" Width="90%" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品编码" SortExpression="">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                <%# Eval("PlatformMerchantCode")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                             <asp:HiddenField ID="hfPlatformMerchantCode" runat="server" Value='<%# Eval("PlatformMerchantCode") %>' />
                             <HozestERP:SimpleTextBox ID="txtPlatformMerchantCode" runat="server"   Text='<%# Eval("PlatformMerchantCode") %>'  Columns="50" 
                              title="请输入料号~:int!" Width="90%"   ValidationGroup="ModuleValidationGroup" ErrorMessage="料号为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="产品类型" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCombinationDetails).ProductTypeCodeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCombinationDetails).ProductTypeCodeName.CodeName : ""%>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                    <HozestERP:CodeControl ID="ccProductTypeId" runat="server" CodeType="188"  Width="90%" /> 
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="平台库存" SortExpression="Status">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                  <%# Eval("PlatformInventory")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                 <asp:TextBox ID="txtPlatformInventory" runat="server" Width="90%" Text='<%# Eval("PlatformInventory") %>' MaxLength="20"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                             <asp:TemplateField HeaderText="链接" SortExpression="">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                <%--<asp:Label ID="lblstrUrl"  runat="server"></asp:Label> --%>
                                <a  runat="server" target="_blank"  href='<%# Eval("strUrl")%>'><img src="../App_Themes/Default/Image/tupian.jpg" style="width: 15px; height: 15px" /></a>
                                </ItemTemplate>
                                <EditItemTemplate>
                             <HozestERP:SimpleTextBox ID="txtstrUrl" runat="server"   Text='<%# Eval("strUrl") %>' Width="90%"   ValidationGroup="ModuleValidationGroup" ErrorMessage="连接为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出厂价" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                <%# Eval("Costprice")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                           <HozestERP:SimpleTextBox ID="txtCostprice" runat="server"   Text='<%# Eval("Costprice") %>'  Columns="50"  title="请输入出厂价~:float!" Width="90%"  
            ValidationGroup="ModuleValidationGroup" ErrorMessage="出厂价为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="销售价" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                <%# Eval("Saleprice")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                           <HozestERP:SimpleTextBox ID="txtSaleprice" runat="server"   Text='<%# Eval("Saleprice") %>'  Columns="50"  title="请输入销售价~:float!" Width="90%"  
            ValidationGroup="ModuleValidationGroup" ErrorMessage="销售价为必填."/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="特供价" SortExpression="">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate> 
                                <%# Eval("TCostprice")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                            <asp:TextBox ID="txtTCostprice" runat="server" Width="90%" Text='<%# Eval("TCostprice") %>' MaxLength="8"></asp:TextBox> 
                           <asp:Label ID="lblTCostpriceVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="开始日期"  SortExpression="TDateTimeStart">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                     <asp:Label ID="lblTDateTimeStart" runat="server" Text='<%# Eval("TDateTimeStart")==null?"":DateTime.Parse(Eval("TDateTimeStart").ToString()).ToString("yyyy-MM-dd")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                   <input id="txtTDateTimeStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"  runat="server" style=" width:85%;"
                                     value='<%#Eval("TDateTimeStart")==null?"":DateTime.Parse(Eval("TDateTimeStart").ToString()).ToString("yyyy-MM-dd")%>' />
                                      <asp:Label ID="lblTDateTimeStartValue" runat="server" Text="" ForeColor="red"></asp:Label>
                                </EditItemTemplate> 
                             </asp:TemplateField> 

                              <asp:TemplateField HeaderText="结束日期"  SortExpression="TDateTimeEnd">
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                     <asp:Label ID="lblTDateTimeEnd" runat="server" Text='<%# Eval("TDateTimeEnd")==null?"":DateTime.Parse(Eval("TDateTimeEnd").ToString()).ToString("yyyy-MM-dd")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                   <input id="txtTDateTimeEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"  runat="server" style=" width:85%;"
                                     value='<%#Eval("TDateTimeEnd")==null?"":DateTime.Parse(Eval("TDateTimeEnd").ToString()).ToString("yyyy-MM-dd")%>' /> 
                                      <asp:Label ID="lblTDateTimeEndValue" runat="server" Text="" ForeColor="red"></asp:Label>
                                </EditItemTemplate> 
                             </asp:TemplateField> 

                             <asp:TemplateField HeaderText="主推"  SortExpression="IsMainPush">
                                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                     <CRM:ImageCheckBox ID="imgChkIsMainPush" runat="server" Checked='<%# Eval("IsMainPush")==null?false: Eval("IsMainPush")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                     <asp:CheckBox ID="chkIsMainPush" runat="server" Checked='<%# Eval("IsMainPush")==null?false: Eval("IsMainPush")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField> 

                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                <ItemStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationDetailsManage.Edit %>" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                        Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationDetailsManage.Delete %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="ModuleValidationGroup"
                                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationDetailsManage.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationDetailsManage.Cancel %>" />
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
            <td>
                
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
