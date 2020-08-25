<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="XMWarehouseList.aspx.cs" Inherits="HozestERP.Web.ManageStock.XMWarehouseList" %>

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
        <td style="width: 70px" align="right">
                省: 
            </td>
        <td style="width: 120px;">
                 <asp:DropDownList ID="ddlProvince" runat="server" Width="100%" OnSelectedIndexChanged="ddlProvince_Change" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        <td style="width: 70px" align="right">
               市:
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlCity" runat="server" Width="100%" OnSelectedIndexChanged="ddlCity_Change" AutoPostBack="true">
               </asp:DropDownList>
            </td>
             <td style="width: 100px" align="right">
               区（县）:
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlCounty" runat="server" Width="100%">
               </asp:DropDownList>
            </td>
             <td style="width: 80px" align="right">
               仓库名:
            </td>
        <td style="width: 120px;">
               <asp:TextBox runat="server" ID="txtWarehouseName" Width="100%"></asp:TextBox>
            </td>
        <td style="text-align: right">
           <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageStock.XMWarehouseList.Search %>" /> 
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
         <asp:TemplateField HeaderText="省" SortExpression="ProvinceName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
              <asp:Label ID="lblProvinceName" runat="server" Text='<%# Eval("ProvinceName").ToString().Length>15?Eval("ProvinceName").ToString().Substring(0,15)+"..":Eval("ProvinceName").ToString()%>'  ToolTip='<%# Eval("ProvinceName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          
         <asp:TemplateField HeaderText="市" SortExpression="CityName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
               <asp:Label ID="lblCityName" runat="server" Text='<%# Eval("CityName").ToString().Length>15?Eval("CityName").ToString().Substring(0,15)+"..":Eval("CityName").ToString()%>'  ToolTip='<%# Eval("CityName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
          
        <asp:TemplateField HeaderText="区(县)"  SortExpression="CountyName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
               <asp:Label ID="lblCountyName" runat="server" Text='<%# Eval("CountyName").ToString().Length>15?Eval("CountyName").ToString().Substring(0,15)+"..":Eval("CountyName").ToString()%>'  ToolTip='<%# Eval("CountyName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="仓库名"  SortExpression="WarehouseName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
            <asp:Label ID="lblWarehouseName" runat="server" Text='<%# Eval("WarehouseName").ToString().Length>15?Eval("WarehouseName").ToString().Substring(0,15)+"..":Eval("WarehouseName").ToString()%>' ToolTip='<%# Eval("WarehouseName")%>'></asp:Label>
            </ItemTemplate>   
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="库位"  SortExpression="Position">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Position").ToString().Length>15?Eval("Position").ToString().Substring(0,15)+"..":Eval("Position").ToString()%>'  ToolTip='<%# Eval("Position")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageStock.XMWarehouseList.Edit %>" />

                   <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageStock.XMWarehouseList.Delete %>" />
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
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageStock.XMWarehouseList.Add %>" />
            </td>
           
        </tr>
    </table>
</asp:Content>
