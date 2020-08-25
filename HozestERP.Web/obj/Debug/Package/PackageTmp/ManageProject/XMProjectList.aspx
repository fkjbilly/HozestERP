<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" 
 CodeBehind="XMProjectList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMProjectList" 
EnableEventValidation="true"%>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>

<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<script src="../TopTaobao/My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
<script src="../Script/CommonManager.js" type="text/javascript"></script>--%>
<style type="text/css">
        .iconSize
        {
            width: 16px;
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server"> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr> 
            <td style="width: 100px; text-align: right;">
                项目名称:
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtProjectName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 100px; text-align: right;"> 
            项目类型:
            </td> 
            <td style="width: 120px;">
                 <HozestERP:CodeControl ID="ccSProjectTypeId" runat="server" CodeType="189"  EmptyValue="true"  Width="100%"  />
            </td>
             <td style="width: 100px; text-align: right;"> 
            是否在运营:
            </td> 
            <td style="width: 120px">
                <asp:DropDownList ID="ddIsEnable" runat="server" Width="100%"  onselectedindexchanged="ddIsEnable_SelectedIndexChanged" AutoPostBack="True"> 
                <asp:ListItem Value="-1" Text="---所有---"></asp:ListItem>
                <asp:ListItem Value="1" Text="是" Selected="True"></asp:ListItem>
                <asp:ListItem Value="0" Text="否"></asp:ListItem> 
                </asp:DropDownList> 
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"/>
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"   OnClick="btnRefresh_Click" />
            </td>
        </tr> 
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvXMProjectList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCancelingEdit="gvXMProjectList_RowCancelingEdit" 
        OnRowEditing="gvXMProjectList_RowEditing" OnRowUpdating="gvXMProjectList_RowUpdating"
        OnRowDataBound="gvXMProjectList_RowDataBound">
        <Columns>
    
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
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
        <asp:TemplateField HeaderText="项目名称" SortExpression="ProjectName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
             <%# Eval("ProjectName")%>
            </ItemTemplate>
             <EditItemTemplate>
                  <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName")%>' Visible="false"></asp:Label>
                  <asp:TextBox ID="txtProjectName" runat="server" Width="90%" Text='<%# Eval("ProjectName") %>'   ValidationGroup="XMProjectValidationGroup" ></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgProjectNameVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>
        </asp:TemplateField>
          
          <asp:TemplateField HeaderText="项目类型"  SortExpression="ProjectTypeId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
               <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMProject).ProjectTypeCodeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMProject).ProjectTypeCodeName.CodeName : ""%>
            </ItemTemplate>
            <EditItemTemplate> 
             <HozestERP:CodeControl ID="ccProjectTypeId" runat="server" CodeType="189"  Width="95%" />
            </EditItemTemplate>
        </asp:TemplateField> 
          
         <asp:TemplateField HeaderText="负责人"  SortExpression="customerId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                 <asp:Label ID="lblcustomerId" runat="server"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate> 
            <HozestERP:SelectSingleCustomerControl ID="txtcustomerId" runat="server" ErrorMessage="负责人为必填."  
                    PopupPosition="BottomLeft"    ValidationGroup="XMProjectValidationGroup"   SessionPageID="OperationCustomer" />  
            </EditItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="客户"  SortExpression="ClientId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                 <asp:Label ID="lblClientId" runat="server"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate> 
            <HozestERP:SelectSingleCustomerControl ID="txtClientId" runat="server"  PopupPosition="BottomLeft"  ValidationGroup="false"  SessionPageID="OperationClient"  />  
            </EditItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="所属部门"  SortExpression="Remark">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="90%" ></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="备注"  SortExpression="Remark">
            <HeaderStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("Remark")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtRemark" runat="server" Width="90%" Text='<%# Eval("Remark") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>  
         
         <asp:TemplateField HeaderText="运费比例%" SortExpression="ShipmentProportion" Visible="<% $CRMIsActionAllowed:XMProjectList.ShipmentProportion %>">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
             <%# Eval("ShipmentProportion")%>
            </ItemTemplate>
             <EditItemTemplate> 
                  <asp:TextBox ID="txtShipmentProportion" runat="server" Width="90%" Text='<%# Eval("ShipmentProportion") %>'></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgShipmentProportionVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>
        </asp:TemplateField>
          

         <asp:TemplateField HeaderText="是否在运营"  SortExpression="IsEnable">
            <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                 <CRM:ImageCheckBox ID="imgChkIsEnable" runat="server" Checked='<%# Eval("IsEnable")==null?false: Eval("IsEnable")%>' />
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:CheckBox ID="chkIsEnable" runat="server" Checked='<%# Eval("IsEnable")==null?false: Eval("IsEnable")%>' />
            </EditItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="扣点设置">
         <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" /> 
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDeduction" runat="server" CommandArgument='<%# Eval("Id") %>'
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMProjectList.Deduction %>" SkinID="btnDetail">
                    </asp:ImageButton>
                </ItemTemplate> 
        </asp:TemplateField> 

        
        <asp:TemplateField HeaderText="限额设置">
         <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" /> 
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnCashBack" runat="server" CommandArgument='<%# Eval("Id") %>'
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMProjectList.CashBack %>" SkinID="btnDetail">
                    </asp:ImageButton>
                </ItemTemplate> 
        </asp:TemplateField> 


          <asp:TemplateField HeaderText="预算录入">
                <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnCostSave" runat="server" CommandArgument='<%# Eval("Id") %>'
                         SkinID="btnDetail"  Visible="<% $CRMIsActionAllowed:ManageProject.XMProjectList.FinancialInsert %>"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>

        <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectList.Edit %>" />
                         
                <asp:ImageButton ID="imgBtnLook" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif" ToolTip="产品管理"
                    CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectList.Product %>"/>
                      <asp:ImageButton ID="imgBtnSetField" runat="server" ToolTip="设置财务字段" CausesValidation="False"
                        ImageUrl="~/App_Themes/Default/Image/SetFinancialField.png"  CssClass="iconSize" Visible="<% $CRMIsActionAllowed:XMProjectList.SetFinancialField %>"/>
                   <%-- <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:XMProjectList.Delete %>" />--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ValidationGroup="XMProjectValidationGroup" 
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMProjectList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProjectList.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>     
    </Columns>
</asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            
            <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnImportProject" SkinID="button4"  runat="server" Text="导入产品"  
                     Visible="<% $CRMIsActionAllowed:ManageProject.XMProjectList.aspx.ImportProject %>"  />
            </td>
             
        </tr>
    </table>
</asp:Content>

