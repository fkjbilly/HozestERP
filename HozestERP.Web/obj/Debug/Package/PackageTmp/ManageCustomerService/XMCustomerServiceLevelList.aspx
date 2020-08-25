<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" 
 CodeBehind="XMCustomerServiceLevelList.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMCustomerServiceLevelList" %>

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
                等级名称: 
            </td>
        <td style="width: 120px;">
                <asp:TextBox runat="server" ID="RankName" Width="100%"></asp:TextBox>
            </td>
        <td style="text-align: right">
           <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceLevelList.Search %>" /> 
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
         
         <asp:TemplateField HeaderText="等级名称"  SortExpression="RankName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
            <asp:Label ID="lblRankName" runat="server" Text='<%# Eval("RankName").ToString().Length>15?Eval("RankName").ToString().Substring(0,15)+"..":Eval("RankName").ToString()%>' ToolTip='<%# Eval("RankName")%>'></asp:Label>
            </ItemTemplate>   
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="等级编号"  SortExpression="RankNumber">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblRankNumber" runat="server" Text='<%# Eval("RankNumber").ToString().Length>15?Eval("RankNumber").ToString().Substring(0,15)+"..":Eval("RankNumber").ToString()%>'  ToolTip='<%# Eval("RankNumber")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="底薪"  SortExpression="BasicSalary">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <asp:Label ID="lblBasicSalary" runat="server" Text='<%# Eval("BasicSalary")==null?"":Eval("BasicSalary").ToString().Length>15?Eval("BasicSalary").ToString().Substring(0,15)+"..":Eval("BasicSalary").ToString()%>' ToolTip='<%# Eval("BasicSalary") %>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField>

         <asp:TemplateField HeaderText="奖金基数"  SortExpression="BonusBase">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <asp:Label ID="lblBonusBase" runat="server" Text='<%# Eval("BonusBase")==null?"":Eval("BonusBase").ToString().Length>15?Eval("BonusBase").ToString().Substring(0,15)+"..":Eval("BonusBase").ToString()%>'  ToolTip='<%# Eval("BonusBase")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceLevelList.Edit %>" />

                   <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("Id")%>'
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceLevelList.Delete %>" />
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
                <asp:Button ID="btnAdd" runat="server" Text="新增"  Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceLevelList.Add %>" />
            </td>
           
        </tr>
    </table>
</asp:Content>

