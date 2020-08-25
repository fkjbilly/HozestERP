<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/TwoCommonEdit.Master"
    CodeBehind="FinanceFieldManage.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.FinanceFieldManage" %>

<%@ MasterType VirtualPath="~/MasterPages/TwoCommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:UpdatePanel ID="upaltreeView" runat="server" style="position: absolute;">
        <ContentTemplate>
            <div>
                <asp:TreeView ID="trFinanceField" runat="server" ShowLines="True" OnSelectedNodeChanged="trFinanceField_SelectedNodeChanged">
                    <NodeStyle Height="18px" />
                    <SelectedNodeStyle BackColor="#9C9CF8" />
                </asp:TreeView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder1" runat="server">
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
                上一级：
            </td>
            <td>
                <asp:DropDownList ID="ddlFields" runat="server" Width="80%">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
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
                字段编号：
            </td>
            <td>
                <asp:TextBox ID="txtFieldCode" runat="server" Width="80%" Text="" />
            </td>
            <td>
            </td>
            <td>
                字段名称<font color="red">*</font>：
            </td>
            <td>
                <HozestERP:SimpleTextBox ID="txtFieldName" runat="server" Width="80%" ErrorMessage="字段名称不能为空."
                    ValidationGroup="ClientValidationGroup" />
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
                排序<font color="red">*</font>：
            </td>
            <td>
                <HozestERP:NumericTextBox ID="txtDisplayOrder" runat="server" Width="80%" RangeErrorMessage="请输入正确的整数."
                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ClientValidationGroup" MaximumValue="999999"
                    MinimumValue="-999999" />
            </td>
            <td>
            </td>
            <td>
                管理字段
            </td>
            <td>
                <asp:DropDownList ID="ddlManagementField" runat="server" Width="80%">
                    <asp:ListItem Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <asp:UpdatePanel ID="upnlButton" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                            OnClick="btnSave_Click" />
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClientClick="return confirm('您确定要删除此条记录.');"
                            OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
