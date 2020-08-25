<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"  
CodeBehind="XMScalpingApplicationList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMScalpingApplicationList" %> 
  
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
                平台类型:
            </td>
            <td style="width: 150px;">
                <HozestERP:CodeControl ID="ccPlatformTypeId" runat="server" Width="90%"  EmptyValue="true"   CodeType="182" /> 
            </td>

            <td style="width: 80px; text-align: right;">
                店铺名称:
            </td>
            <td style="width: 150px;">
                <asp:DropDownList ID="ddlNick" runat="server" Width="100%" OnSelectedIndexChanged="ddlNick_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList> 
            </td>
            <td style="width: 80px; text-align: right;">
                刷单单号:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtScalpingCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr> 
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvXMScalpingApplication" runat="server" AutoGenerateColumns="False" DataKeyNames="ScalpingId "
        SkinID="GridViewThemen" OnRowCommand="gvXMScalpingApplication_RowCommand"
        OnRowDataBound="gvXMScalpingApplication_RowDataBound">
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
                    <asp:HiddenField ID="hdID" Value='<%#Eval("ScalpingId ")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="平台" SortExpression="PlatformTypeId">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalpingApplication).PlatformTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalpingApplication).PlatformTypeName : ""%>
            </ItemTemplate> 
        </asp:TemplateField>

         <asp:TemplateField HeaderText="店铺" SortExpression="NickId">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
              <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalpingApplication).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalpingApplication).NickName : ""%>
            </ItemTemplate> 
        </asp:TemplateField>

         <asp:TemplateField HeaderText="刷单单号" SortExpression="ScalpingCode">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("ScalpingCode")%>
             </ItemTemplate> 
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="开始日期"  SortExpression="ScalpingBeginTime">
            <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                    <asp:Label ID="lblScalpingBeginTime" runat="server" Text='<%# Eval("ScalpingBeginTime")==null?"":DateTime.Parse(Eval("ScalpingBeginTime").ToString()).ToString("yyyy-MM-dd")%>'></asp:Label>
            </ItemTemplate> 
         </asp:TemplateField> 
         <asp:TemplateField HeaderText="结束日期"  SortExpression="ScalpingEndTime">
            <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                    <asp:Label ID="lblScalpingEndTime" runat="server" Text='<%# Eval("ScalpingEndTime")==null?"":DateTime.Parse(Eval("ScalpingEndTime").ToString()).ToString("yyyy-MM-dd")%>'></asp:Label>
            </ItemTemplate> 
         </asp:TemplateField> 
          
        <asp:TemplateField HeaderText="说明" SortExpression="Explanation">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
               <asp:Label ID="lblExplanation"  runat="server"></asp:Label> 
            </ItemTemplate> 
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="部门审核" SortExpression="ManagerIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsAudit" runat="server" Width="20%" Checked='<%# Eval("ManagerIsAudit")==null?false: Eval("ManagerIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>

        <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationList.Edit %>" /> 

                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("ScalpingId") %>' runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="ScalpingApplicationDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationList.Delete %>" />
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
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationList.Add %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerIsAudit"  SkinID="button4" runat="server" Text="部门审核" OnClick="btnManagerIsAudit_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationList.ManagerIsAudit %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerIsAuditNO"  SkinID="button4" runat="server" Text="部门反审核" OnClick="btnManagerIsAuditNO_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingApplicationList.ManagerIsAuditNO %>" />
            </td>
             
        </tr>
    </table>
</asp:Content>


