<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMNickSetAdvertingField.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMNickSetAdvertingField" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfSelectAllID" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="hdfIDs" runat="server" ViewStateMode="Enabled" />
    <table>
        <tr>
            <td>
                <font face="verdana" size="4">广告费</font>
                <!---->
            </td>
        </tr>
    </table>
    <asp:Repeater ID="rptAdvertingField" runat="server" OnItemDataBound="rptAdvertingField_ItemDataBound">
        <HeaderTemplate>
            <table>
                <tr>
        </HeaderTemplate>
        <ItemTemplate>
            <td style="height: 24px;" align="center ">
                <input id="ck" type="checkbox" runat="server" value='<%# Eval("Id")%>' name='field' />
                <%# Eval("FieldName")%>
            </td>
        </ItemTemplate>
        <SeparatorTemplate>
        </SeparatorTemplate>
        <FooterTemplate>
            </tr></table>
        </FooterTemplate>
    </asp:Repeater>
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
    <script type="text/javascript">
        $("#<%=btnSave.ClientID %>").click(function () {
            var value = '';
            $("input[type=checkbox]").each(function () {
                if (this.checked) {
                    value += $(this).val() + ',';
                }
            });
            value = value.length > 0 ? value.substr(0, value.length - 1) : '';
            document.getElementById("<%=hdfSelectAllID.ClientID %>").value = value;
        })

        $(document).ready(function () {
            var c = document.getElementById("<%=hdfIDs.ClientID %>").value;
            var strs = new Array();
            strs = c.split(","); //字符分割 
            $.each(strs, function (i, q) {
                $("input[type=checkbox]").each(function () {
                    if ($(this).val() == q) {
                        $(this).prop("checked", "checked");
                    }
                });
            });
        });
    </script>
</asp:Content>
