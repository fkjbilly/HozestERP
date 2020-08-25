<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="SetRolesOfCustomer.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.SetRolesOfCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfSelectAllID" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="HiddenField1" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="HiddenField2" runat="server" ViewStateMode="Enabled" />
    <asp:HiddenField ID="hdfIDs" runat="server" ViewStateMode="Enabled" />
    <input id="chkAll" type="checkbox" onclick="checkAll(this);" /><label>全选</label>
    <asp:Repeater ID="rptProjectList" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td id="box">
                        <asp:HiddenField ClientIDMode="Static" ID="hdfParentID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input id="ck" type="checkbox" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                            name='items' />
                        <font face="verdana" size="4">
                            <%# DataBinder.Eval(Container.DataItem, "ProjectName")%></font>
                    </td>
                </tr>
            </table>
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
        function checkAll(obj) {
            $("#box input[type='checkbox']").prop('checked', $(obj).prop('checked'));
        }
        function add() {
            var value = '';
            $("#box input[type='checkbox']").each(function () {
                if (this.checked) {
                    value += $(this).prev().val() + ',';
                }
            });
            value = value.length > 0 ? value.substr(0, value.length - 1) : '';
            document.getElementById("<%=hdfSelectAllID.ClientID %>").value = value;
        }

        $(document).ready(function () {
            var c = document.getElementById("<%=HiddenField1.ClientID %>").value;
            var strs = new Array();
            var t = 0;
            strs = c.split(","); //字符分割 
            $.each(strs, function (i, q) {
                $("#box input[type='checkbox']").each(function () {
                    if ($(this).prev().val() == q) {
                        $(this).prop("checked", "checked");
                        t++;
                    }
                });
            });
            var d = document.getElementById("<%=HiddenField2.ClientID %>").value;
            if (d == t) {
                $("#chkAll").prop("checked", "checked");
            }
        });
    </script>
</asp:Content>
