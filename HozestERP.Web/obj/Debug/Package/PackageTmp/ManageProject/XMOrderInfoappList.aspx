<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="XMOrderInfoappList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMorderInfoappList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
      <tr>
        <td style="width: 70px">
                店铺名称: 
            </td>
        <td style="width: 120px;">
                 <asp:DropDownList ID="ddlNickId" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        <td style="width: 70px">
               平台类型:
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%">
               </asp:DropDownList>
            </td>
        <td style="text-align: right">
           <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoappList.Search %>" /> 
           <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"   OnClick="btnRefresh_Click" />
        </td> 
      </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
        OnRowDataBound="grdvClients_RowDataBound">
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
         <asp:TemplateField HeaderText="店铺名称" SortExpression="NickId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
              <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoApp).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoApp).NickName.nick : ""%>
            </ItemTemplate>
        </asp:TemplateField>
          
         <asp:TemplateField HeaderText="平台类型"  SortExpression="PlatformTypeId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
               <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoApp).PlatformTypeCodeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMOrderInfoApp).PlatformTypeCodeName.CodeName : ""%>
            </ItemTemplate>
        </asp:TemplateField> 
          
         <asp:TemplateField HeaderText="AppKey"  SortExpression="AppKey">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
            <asp:Label ID="lblAppKey" runat="server" Text='<%# Eval("AppKey").ToString().Length>15?Eval("AppKey").ToString().Substring(0,15)+"..":Eval("AppKey").ToString()%>' ToolTip='<%# Eval("AppKey")%>'></asp:Label>
            </ItemTemplate>   
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="AppSecret"  SortExpression="AppSecret">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblAppSecret" runat="server" Text='<%# Eval("AppSecret").ToString().Length>15?Eval("AppSecret").ToString().Substring(0,15)+"..":Eval("AppSecret").ToString()%>'  ToolTip='<%# Eval("AppSecret")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="CallbackUrl"  SortExpression="CallbackUrl">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <asp:Label ID="lblCallbackUrl" runat="server" Text='<%# Eval("CallbackUrl")==null?"":Eval("CallbackUrl").ToString().Length>15?Eval("CallbackUrl").ToString().Substring(0,15)+"..":Eval("CallbackUrl").ToString()%>' ToolTip='<%# Eval("CallbackUrl") %>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField>

         <asp:TemplateField HeaderText="AccessToken"  SortExpression="AccessToken">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <asp:Label ID="lblAccessToken" runat="server" Text='<%# Eval("AccessToken")==null?"":Eval("AccessToken").ToString().Length>15?Eval("AccessToken").ToString().Substring(0,15)+"..":Eval("AccessToken").ToString()%>'  ToolTip='<%# Eval("AccessToken")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="ServerUrl"  SortExpression="ServerUrl">
            <HeaderStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <asp:Label ID="lblServerUrl" runat="server" Text='<%# Eval("ServerUrl")==null?"": Eval("ServerUrl").ToString().Length>15?Eval("ServerUrl").ToString().Substring(0,15)+"..":Eval("ServerUrl").ToString()%>' ToolTip='<%# Eval("ServerUrl")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>    

         <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoappList.Edit %>" />

                   <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("Id")%>'
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoappList.Delete %>" />
                </ItemTemplate>
            
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
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoappList.Add %>" />
            </td>
           
        </tr>
    </table>
</asp:Content>
