<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="XMWangNoList.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMWangNoList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
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
        <td style="width: 70px" align="right">
               平台类型:
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%">
               </asp:DropDownList>
            </td>

         <td style="width: 70px" align="right">
               旺旺号:
            </td>
        <td style="width: 120px;">
               <asp:TextBox runat="server" ID="ddlWangNo" Width="100%"></asp:TextBox>
            </td>
        <td style="text-align: right">
           <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMWangNoList.Search %>" /> 
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
         <asp:TemplateField HeaderText="店铺名称" SortExpression="NickId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
              <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).NickName.nick : ""%>
            </ItemTemplate>
        </asp:TemplateField>
          
         <asp:TemplateField HeaderText="平台类型">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
               <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).PlatformTypeCodeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).PlatformTypeCodeName.CodeName : ""%>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="旺旺号"  SortExpression="WangNo">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <asp:Label ID="lblWangNo" runat="server" Text='<%# Eval("WangNo")==null?"":Eval("WangNo").ToString().Length>15?Eval("WangNo").ToString().Substring(0,15)+"..":Eval("WangNo").ToString()%>' ToolTip='<%# Eval("WangNo") %>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField>


         <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMWangNoList.Edit %>" />

                   <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMWangNoList.Delete %>" />
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
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMWangNoList.Add %>" />
            </td>
           
        </tr>
    </table>
</asp:Content>
