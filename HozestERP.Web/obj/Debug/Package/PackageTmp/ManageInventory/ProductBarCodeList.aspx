<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="ProductBarCodeList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.ProductBarCodeList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
        .AdjustFactoryPriceImg
        {
            width: 16px;
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px; text-align: right;">
                条形码
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtPlatFormCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px;">
                厂家编码
            </td>
            <td style="width: 100px;">
                <asp:Literal ID="ltPlatFormCode" runat="server"></asp:Literal>
            </td>
            <td style="width: 80px;">
                商品名称
            </td>
            <td style="width: 100px;">
                <asp:Literal ID="ltProductName" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table>
        <tr>
           <td style="height:10px"></td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 80px;">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 70px;">
                <asp:Button ID="btnSaveBarCodes" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    OnClick="btnSaveBarCodes_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
          <td style="height:10px"></td>
        </tr>
    </table>
    <asp:GridView ID="grdvBarCodeList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" ShowFooter="true" OnRowUpdating="grdvBarCodeList_RowUpdating"
        OnRowCancelingEdit="grdvBarCodeList_RowCancelingEdit" OnRowEditing="grdvBarCodeList_RowEditing"
        OnRowDataBound="grdvBarCodeList_RowDataBound" OnRowCommand="grdvBarCodeList_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="条形码" SortExpression="BarCode">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BarCode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtBarCodes" runat="server" Width="90%" Text=' <%# Eval("BarCode") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                <ItemTemplate>
                    <asp:HiddenField ID="hiddPID" runat="server" Value='<%# Eval("SpdId") %>' />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.ProductBarCodeList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.ProductBarCodeList.Delete %>"
                        OnClientClick="return confirm('您确定要删除此条记录？');" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageInventory.ProductBarCodeList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.ProductBarCodeList.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <%--    <asp:ImageButton ID="imgBtnFeeUpdate" OnClick="imgBtnFeeUpdate_Click" runat="server"
        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存"  Visible="false"  />--%>
</asp:Content>
