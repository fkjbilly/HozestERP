<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMNickAdvertingCostDetail.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMNickAdvertingCostDetail" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .floatRight
        {
            float: right;
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <font face="verdana" size="4">广告费</font>
                <!---->
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdvAdvertingFieldDetails" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" ShowFooter="false" ShowHeader="false">
        <EmptyDataTemplate>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                <ItemTemplate>
                    <asp:Label ID="lbFieldName" runat="server" Text='<%# Eval("FieldName")%>' CssClass="floatRight"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                <FooterStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:HiddenField ID="hiddFieldID" runat="server" Value='<%# Eval("FieldId")%>' />
                    <asp:TextBox runat="server" ID="txtCost" Text='<%# Eval("Cost")==null?"0":Eval("Cost")%>'
                        Width="90%" Style="text-align: right"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgCountMoneyVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="text-align: right">
                <asp:Button ID="btnSave" runat="server" Text="保存" Visible="<% $CRMIsActionAllowed:ManageProject.XMNickAdvertingCostDetail.Save %>"
                    SkinID="button4" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
