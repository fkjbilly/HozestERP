<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SetFinanceFields.aspx.cs" Inherits="HozestERP.Web.ManageProject.SetFinanceFields" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfSelectAllID" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="hdfIDs" runat="server"  ViewStateMode="Enabled"/>
    <asp:Repeater ID="rptParentField" runat="server" OnItemDataBound="rptParentField_OnItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <!--父节点名称-->
                        <asp:HiddenField ID="hdfParentID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input id="ck" type="checkbox" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                            name='field' />
                        <font face="verdana" size="4">
                            <%# DataBinder.Eval(Container.DataItem, "FieldName")%></font>
                        <!---->
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rptChildField" runat="server" OnItemDataBound="rptChildField_ItemDataBound">
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
                </FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
        <FooterTemplate>
            </tr> </table>
        </FooterTemplate>
        <SeparatorTemplate>
        </SeparatorTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    OnClick="btnSave_Click" OnClientClick="add();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function add() {
            var value = '';
            $("input[type=checkbox]").each(function () {
                if (this.checked) {
                    value += $(this).val() + ',';
                }
            });
            value = value.length > 0 ? value.substr(0, value.length - 1) : '';
            document.getElementById("<%=hdfSelectAllID.ClientID %>").value = value;
        }

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
