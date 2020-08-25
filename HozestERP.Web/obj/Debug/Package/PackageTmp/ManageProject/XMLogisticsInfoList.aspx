<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMLogisticsInfoList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMLogisticsInfoList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvLogistic" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCancelingEdit="gvLogistic_RowCancelingEdit" OnRowEditing="gvLogistic_RowEditing"
        OnRowUpdating="gvLogistic_RowUpdating" OnRowDataBound="gvLogistic_RowDataBound"
        OnRowDeleting="gvLogistic_OnRowDeleting" OnRowCreated="gvLogistic_RowCreated">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="10px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流时间" SortExpression="LogisticsDate">
                <HeaderStyle Width="55px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("LogisticsDate")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input id="txtLogisticTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 90%;" value='<%#Eval("LogisticsDate")==null?"":DateTime.Parse(Eval("LogisticsDate").ToString()).ToString()%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流单号" SortExpression="LogisticsNumber">
                <HeaderStyle Width="55px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("LogisticsNumber")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--  <asp:Label ID="lblNick" runat="server" Text='<%# Eval("nick")%>' Visible="false"></asp:Label>--%>
                    <asp:TextBox ID="txtLogisticNumber" runat="server" Width="90%" Text=' <%# Eval("LogisticsNumber") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流公司" SortExpression="LogisticsCompany">
                <HeaderStyle Width="55px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("LogisticsCompany")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLogisticCompany" runat="server" Width="90%" Text=' <%# Eval("LogisticsCompany") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流信息" SortExpression="Note">
                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Note")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNote" runat="server" Width="95%" Text=' <%# Eval("Note") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否已导出" SortExpression="IsExport">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsExport" runat="server" Width="20%" Checked='<%# Eval("IsExport") == null ? false : Eval("IsExport")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMLogisticsInfoList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%# Eval("Id") %>' ToolTip="删除" CommandName="Delete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:XMLogisticsInfoList.Delete %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        CommandArgument='<%# Eval("Id") %>' ToolTip="保存" CommandName="Update" CausesValidation="True"
                        Visible="<% $CRMIsActionAllowed:XMLogisticsInfoList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMLogisticsInfoList.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
