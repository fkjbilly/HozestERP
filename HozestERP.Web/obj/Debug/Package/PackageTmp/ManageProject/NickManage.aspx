<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="NickManage.aspx.cs" Inherits="HozestERP.Web.ManageProject.NickManage" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px">
                项目名称:
            </td>
            <td style="width: 160px;">
                <asp:DropDownList ID="ddSearchProjectId" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                店铺名称:
            </td>
            <td style="width: 160px;">
                <asp:TextBox ID="txtNick" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                <%--  店长--%>
                是否在运营:
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddIsEnable" runat="server" Width="100%" OnSelectedIndexChanged="ddIsEnable_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem Value="1" Text="是" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                    <asp:ListItem Value="-1" Text="---所有---"></asp:ListItem>
                </asp:DropDownList>
                <%-- <asp:TextBox ID="txtShopManager" runat="server" Width="100%"></asp:TextBox>--%>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
                <%-- 归属角色--%>
            </td>
            <td style="width: 120px">
                <%-- <asp:DropDownList ID="ddlRole" runat="server" Width="90%">
                </asp:DropDownList>--%>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:NickManage.Search %>"
                    OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvNick" runat="server" AutoGenerateColumns="False" DataKeyNames="nick_id"
        SkinID="GridViewThemen" OnRowCancelingEdit="gvNick_RowCancelingEdit" OnRowEditing="gvNick_RowEditing"
        OnRowUpdating="gvNick_RowUpdating" OnRowDataBound="gvNick_RowDataBound"    OnRowDeleting="gvNick_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="项目名称" SortExpression="ProjectId">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProjectName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddProjectId" Width="95%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称" SortExpression="nick">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("nick")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNick" runat="server" Text='<%# Eval("nick")%>' Visible="false"></asp:Label>
                    <asp:TextBox ID="txtNick" runat="server" Width="90%" Text=' <%# Eval("nick") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属平台" SortExpression="PlatformTypeId">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                <%#selectPlatformTypeName(Convert.ToInt32(Eval("PlatformTypeId") == null ? "0" : Eval("PlatformTypeId").ToString()))%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="80%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <%--        <asp:TemplateField HeaderText="运营专员">
                <HeaderStyle  Width="80px"  HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblOperationCommissioner" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="文案专员">
                <HeaderStyle  Width="80px"  HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblCopywriterCommissioner" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="推广专员">
                <HeaderStyle  Width="80px"  HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblPromotionSpecialist" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="店长">
                <HeaderStyle   Width="80px"  HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblShopOwner" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="项目经理">
                <HeaderStyle   Width="80px"  HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblProjectManager" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <%--<asp:TemplateField HeaderText="店长"  SortExpression="shopManager">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("shopManager")%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtShopManager" runat="server" Width="90%" Text=' <%# Eval("shopManager") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="归属角色"  SortExpression="customerRole.Name">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# (Container.DataItem as XMNick).customerRole == null ? "" : (Container.DataItem as XMNick).customerRole.Name%>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlRole" runat="server" Width="90%">
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="添加人" SortExpression="createPerson">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("createPerson")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="人员分配">
                <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnCustomer" runat="server" CommandArgument='<%# Eval("nick_id") %>'
                        Visible="<% $CRMIsActionAllowed:NickManage.Customer %>" SkinID="btnDetail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预算录入">
                <HeaderStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnCostSave" runat="server" CommandArgument='<%# Eval("nick_id") %>'
                         SkinID="btnDetail" ></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否在运营" SortExpression="isEnable">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="imgChkIsEnable" runat="server" Checked='<%# Eval("isEnable")==null?false: Eval("isEnable")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkIsEnable" runat="server" Checked='<%# Eval("isEnable")==null?false: Eval("isEnable")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:NickManage.Edit %>" />

                     <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除"
                    CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" 
                     Visible="<% $CRMIsActionAllowed:NickManage.Delete %>" />
                    <asp:ImageButton ID="imgBtnLook" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="目标值设定" CommandName="look" CausesValidation="False" />
                    <asp:ImageButton ID="imgBtnSetField" runat="server" ToolTip="设置财务字段" CausesValidation="False"
                        ImageUrl="~/App_Themes/Default/Image/icon_folder_close.gif"  CssClass="iconSize" Visible="<% $CRMIsActionAllowed:XMProjectList.SetFinancialField %>"/>
                    <%--<asp:ImageButton ID="imgProduct" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif" ToolTip="产品管理"
                    CommandName="look" CausesValidation="False"  Visible="<% $CRMIsActionAllowed:Product.Search %>" />--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:NickManage.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:NickManage.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
