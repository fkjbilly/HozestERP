<%@ Page Language="C#" CodeBehind="XMCombinationManageAdd.aspx.cs" MasterPageFile="~/MasterPages/Root.Master"
 AutoEventWireup="true" Inherits="HozestERP.Web.ManageProject.XMCombinationManageAdd" %>
   
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="3">
    <tbody>
            <tr ><td colspan="2"><a style=" color:#000099; font-size:15px;">捆绑产品基本信息</a></td></tr> 
            <tr> 
            <td style="width:80px" align="left">
             店铺名称: 
             </td>  
            <td align="left">
              <asp:DropDownList ID="ddlNickId" runat="server" Width="155px">
                </asp:DropDownList>
             </td>  
             </tr>
            <tr>
             <td style="width:80px" align="left">
             产品名称: 
             </td>  
             <td align="left">
            <asp:TextBox runat="server" ID="ddlProductName" Width="150px"></asp:TextBox>
             </td>  
             </tr>

            <tr>
             <td style="width:80px" align="left">
             厂家编号: 
             </td>  
             <td align="left">
            <asp:TextBox runat="server" ID="ddlManufacturersCode" Width="150px"></asp:TextBox>
             </td>  
             </tr>

            <tr>
             <td style="width:80px" align="left">
             产品重量: 
             </td>  
             <td align="left">
            <asp:TextBox runat="server" ID="ddlProductWeight" Width="150px"></asp:TextBox>克(g)
             </td>  
             </tr>
            <tr ><td colspan="2"><a style=" color:#000099; font-size:15px;">捆绑产品</a></td></tr> 
            <tr >
            <td colspan="2">
            <asp:Button ID="btnProductAdd" runat="server" Text="捆绑产品" SkinID="button4"
               ValidationGroup="ModuleValidationGroup" Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationManageAdd.Add %>"/>
            </td>
            </tr> 
    </tbody>
  </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand">
        <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 

          <asp:TemplateField HeaderText="厂家编号"  SortExpression="ManufacturersCode">
            <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("ManufacturersCode")%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="产品名称"  SortExpression="ProductName">
            <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("ProductName")%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="数量"  SortExpression="ProductCount">
            <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="ddlCount" Width="185px"></asp:TextBox>
            </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField HeaderText="删除"  SortExpression="FactoryNum">
          <HeaderStyle HorizontalAlign="Center" Wrap="False" />
           <ItemTemplate>
           <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="删除" CommandName="Del" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationManageAdd.Delete %>" />
           </ItemTemplate>
          </asp:TemplateField>
    </Columns>
   </asp:GridView>
   </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table style="width: 96%;" align="right" border="0" cellpadding="0" cellspacing="0">
        <tr align="right">
            <td align="right"> 
                <asp:Button ID="btnDeleteAll" runat="server" Text="全部删除" ValidationGroup="ModuleValidationGroup" SkinID="button4"
                Onclick="btnDeleteAll_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationManageAdd.DeleteAll %>" />
            </td>
           
        </tr>
    </table>

    <table style="width: 100%;" align="left">
        <tr align="left">
            <td align="left">
             <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageProject.XMCombinationDetailsManage.Save %>"/>
             <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"   OnClick="btnRefresh_Click" />
             <%--<asp:Button ID="btnCancel" runat="server" Text="返回"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnCancel_Click"  Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMDSRAdd.Cancel %>"/>--%>
            </td>
        </tr>
    </table>
</asp:Content>

