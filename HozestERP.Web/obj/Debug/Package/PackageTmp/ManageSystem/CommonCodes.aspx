<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/TwoCommonEdit.Master"
    AutoEventWireup="true" CodeBehind="CommonCodes.aspx.cs" Inherits="HozestERP.Web.ManageSystem.CommonCodes" %>

<%@ MasterType VirtualPath="~/MasterPages/TwoCommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;
        overflow: hidden;">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td valign="top" style="width: 100%; height: 100%; overflow: hidden;" class="Borderline">
                <div style="width: 100%; height: 100%; overflow: auto; position: relative;">
                    <asp:GridView ID="grdCode" runat="server" AutoGenerateColumns="False" DataKeyNames="CodeID"
                        SkinID="GridViewThemen" OnRowCommand="grdCode_RowCommand" Style="position: absolute;">
                        <EmptyDataTemplate>
                            <p>
                                没有您要查看的数据</p>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="CodeName" HeaderText="名称">
                                <HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="GridHeard"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CodeNO" HeaderText="编号">
                                <HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="GridHeard"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DisplayOrder" HeaderText="排序">
                                <HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="GridHeard"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="是否停用">
                                <ItemTemplate>
                                    <CRM:ImageCheckBox ID="chkDeleted" runat="server" Checked='<%#Eval("Deleted")%>' />
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="GridHeard">
                                </HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="详细" HeaderStyle-CssClass="GridHeard">
                                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("CodeID") %>'
                                        SkinID="btnDetail" CommandName="Detail"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td valign="top" class="Borderline" colspan="3" style="height: 60px; background-color: rgb(225, 229, 230);">
                <table border="0" cellpadding="0" cellspacing="0" style="">
                    <tr>
                        <td style="width: 8px; height: 8px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 200px">
                        </td>
                        <td style="width: 25px; height: 8px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 200px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px">
                        </td>
                        <td>
                            编号：
                        </td>
                        <td>
                            <CRM:SimpleTextBox ID="txtCodeNo" runat="server" ErrorMessage="编号不能为空." Width="99%"
                                PopupPosition="Right" ValidationGroup="NotesGroup" />
                        </td>
                        <td>
                        </td>
                        <td>
                            名称：
                        </td>
                        <td>
                            <CRM:SimpleTextBox ID="txtCodeName" runat="server" ErrorMessage="名称不能为空." Width="99%"
                                PopupPosition="Right" ValidationGroup="NotesGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px">
                        </td>
                        <td>
                            排序：
                        </td>
                        <td>
                            <CRM:NumericTextBox ID="txtDisplayOrder" runat="server" Width="100%" RangeErrorMessage="请输入正确的整数."
                                RequiredErrorMessage="请输入正确的整数." ValidationGroup="NotesGroup" MaximumValue="999999"
                                MinimumValue="-999999" />
                        </td>
                        <td>
                        </td>
                        <td>
                            是否停用：
                        </td>
                        <td>
                            <asp:CheckBox ID="chkDeleted" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" >
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="NotesGroup" OnClick="btnSave_Click" />
            </td>
            <td style="width: 10px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <asp:GridView ID="grdCodeType" runat="server" AutoGenerateColumns="False" DataKeyNames="CodeTypeID"
            SkinID="GridViewThemen" OnRowCommand="grdCodeType_RowCommand" Style="position: absolute;">
            <Columns>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnCode" runat="server" CommandArgument='<%# Eval("CodeTypeID") %>'
                            CommandName="btnCode" Text='<%#Eval("CodeTypeCode") + "_" + Eval("CodeTypeName") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="GridHeard"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
