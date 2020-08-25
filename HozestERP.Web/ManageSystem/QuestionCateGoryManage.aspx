<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/TwoCommonEdit.Master"
    AutoEventWireup="true" CodeBehind="QuestionCateGoryManage.aspx.cs" Inherits="HozestERP.Web.ManageSystem.QuestionCateGoryManage" %>

<%@ MasterType VirtualPath="~/MasterPages/TwoCommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:UpdatePanel ID="upaltreeView" runat="server" style="position: absolute;">
        <ContentTemplate>
            <div>
                <asp:TreeView ID="trQuestionCategory" runat="server" ShowLines="True" OnSelectedNodeChanged="trQuestionCategory_SelectedNodeChanged">
                    <NodeStyle Height="18px" />
                    <SelectedNodeStyle BackColor="#9C9CF8" />
                </asp:TreeView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                <asp:DropDownList ID="ddlQuestionCategory" runat="server" Width="100%">
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
               类型编号：
            </td>
            <td>
                <asp:TextBox ID="txtCategoryCode" runat="server" Width="80%" Text="" />
            </td>
            <td>
            </td>
            <td>
                类型名称<font color="red">*</font>：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtCategoryName" runat="server" Width="80%" 
                    ErrorMessage="字段名称不能为空." ValidationGroup="ClientValidationGroup" />
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
                   <SHIBR:NumericTextBox ID="txtDisplayOrder" runat="server" Width="100%" RangeErrorMessage="请输入正确的整数."
                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ClientValidationGroup" MaximumValue="999999"
                    MinimumValue="-999999" />
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
