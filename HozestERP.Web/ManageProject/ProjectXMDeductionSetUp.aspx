<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" 
 CodeBehind="ProjectXMDeductionSetUp.aspx.cs" Inherits="HozestERP.Web.ManageProject.ProjectXMDeductionSetUp"  EnableEventValidation="true" %> 

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server"> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px; text-align: right;">
                项目名称:
            </td>
            <td style="width: 150px;">  
                <asp:TextBox ID="txtProjectName" runat="server" Width="100%"  ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 80px; text-align: right;">
                平台类型:
            </td>
            <td style="width: 150px;">  
                <HozestERP:CodeControl ID="ddPlatformTypeId" runat="server" Width="90%"  EmptyValue="true"   CodeType="182" /> 
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr> 
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvProjectDeduction" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCancelingEdit="gvProjectDeduction_RowCancelingEdit" OnRowDeleting="gvProjectDeduction_RowDeleting"
        OnRowEditing="gvProjectDeduction_RowEditing" OnRowUpdating="gvProjectDeduction_RowUpdating"
        OnRowDataBound="gvProjectDeduction_RowDataBound">
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
            <asp:TemplateField HeaderText="项目名称" SortExpression="PlatformTypeId">
            <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <asp:Label ID="lblProjesctNameI" runat="server"></asp:Label> 
            </ItemTemplate>
             <EditItemTemplate> 
               <asp:Label runat="server" ID="lblProjesctName"></asp:Label>
             </EditItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="平台名称" SortExpression="PlatformTypeId">
            <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
              <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMDeductionSetUp).PlatformTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMDeductionSetUp).PlatformTypeName.CodeName : ""%>
            </ItemTemplate>
             <EditItemTemplate> 
             
             <asp:HiddenField ID="hfPlatformTypeId" runat="server" Value='<%# Eval("PlatformTypeId") %>' />
                <HozestERP:CodeControl ID="ccPlatformTypeId" runat="server" Width="90%"  EmptyValue="true"   CodeType="182"  ValidationGroup="DeductionValidationGroup"/> 
             </EditItemTemplate>
        </asp:TemplateField> 
          
        <asp:TemplateField HeaderText="平台扣点%" SortExpression="Deduction">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                <%# Eval("Deduction")%>
                 </ItemTemplate>
             <EditItemTemplate>
                  <asp:TextBox ID="txtDeduction" runat="server" Width="90%" Text='<%# Eval("Deduction") %>' MaxLength="20" ValidationGroup="DeductionValidationGroup"></asp:TextBox>
                  <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgDeductionVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
             </EditItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="平台负责人" SortExpression="PlatformTypePersonId">
                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>            
             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMDeductionSetUp).PlatformTypePersonName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMDeductionSetUp).PlatformTypePersonName.FullName : ""%>
              </ItemTemplate>
                <EditItemTemplate>
                    <HozestERP:SelectSingleCustomerControl ID="txtPlatformTypePersonId" runat="server" ErrorMessage="平台负责人为必填."  
                        PopupPosition="BottomLeft"    ValidationGroup="DeductionValidationGroup"   SessionPageID="OperationPlatformTypePerson" /> 
                </EditItemTemplate>
          </asp:TemplateField>  
        
         <asp:TemplateField HeaderText="备注"  SortExpression="Remarks">
            <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("Remarks")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtRemarks" runat="server" Width="90%" Text='<%# Eval("Remarks") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField> 
        

        <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ProjectXMDeductionSetUp.Edit %>" />
                         

                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ProjectXMDeductionSetUp.Delete %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True"  ValidationGroup="DeductionValidationGroup" Visible="<% $CRMIsActionAllowed:ProjectXMDeductionSetUp.Save %>" />

                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ProjectXMDeductionSetUp.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>     
    </Columns>
</asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    
</asp:Content>


