<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"  
CodeBehind="XMPostList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMPostList" %> 
  
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server"> 
<script language="javascript" type="text/javascript">
    var RefreshSearch = function () {
        window.parent.frames[1].RefreshSearch()
    }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
          <td style="width: 80px; text-align: right;">
                岗位名称:
            </td>
            <td style="width: 150px;">
<asp:TextBox ID="post" runat="server" Width="95%" Enabled="true"></asp:TextBox> 
            </td>
            <td style="width: 80px; text-align: right;">
                是否停用:
            </td>
            <td style="width: 150px;">
<asp:DropDownList ID="IsEnable" runat="server" Width="95%"  ValidationGroup="ModuleValidationGroup">
                </asp:DropDownList>
            </td>

            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr> 
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvXMPost" runat="server" AutoGenerateColumns="False" DataKeyNames="Id "
        SkinID="GridViewThemen" OnRowCommand="gvXMPost_RowCommand"
        OnRowDataBound="gvXMPost_RowDataBound">
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

            <asp:TemplateField HeaderText="岗位名称" SortExpression="Post">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <%# Eval("Post")%>
            </ItemTemplate> 
        </asp:TemplateField>

<%--         <asp:TemplateField HeaderText="创建人" SortExpression="CreatorID">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
              <%# Eval("CreatorID")%>
            </ItemTemplate> 
        </asp:TemplateField>

         <asp:TemplateField HeaderText="创建时间" SortExpression="CreatorTime">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("CreatorTime")%>

             </ItemTemplate> 
        </asp:TemplateField> --%>

                 <asp:TemplateField HeaderText="是否停用" SortExpression="isEnable">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <CRM:ImageCheckBox ID="imgChkIsEnable" runat="server" Checked='<%# Eval("isEnable")==null?false: Eval("isEnable")%>' />

             </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMPostList.Edit %>" /> 

                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="PostDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMPostList.Delete %>" />
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
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMPostList.Add %>" />
            </td>
             
        </tr>
    </table>
</asp:Content>


