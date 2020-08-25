<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="CustomerAction.aspx.cs" Inherits="HozestERP.Web.ManageSystem.CustomerAction" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <script type="text/javascript">
       function closeWindows() {

           parent.RefeshGridView();
           layer_close();
           //window.parent.location.reload();
       }
      
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                动作：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtName" runat="server" Width="90%" ErrorMessage="动作为必填."
                    ValidationGroup="ModuleValidationGroup" PopupPosition="BottomLeft" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                KeyWord：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtKeyWord" runat="server" Width="90%" ErrorMessage="KeyWord为必填."
                    ValidationGroup="ModuleValidationGroup" PopupPosition="BottomLeft" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtKeyWord$txtValue"
                    Display="None" SetFocusOnError="True" ErrorMessage="<font size=2>你输入的KeyWord已经存在，请重新输入！</font>"
                    OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="ModuleValidationGroup"></asp:CustomValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" PopupPosition="BottomLeft"
                    TargetControlID="CustomValidator1" BehaviorID="VMasterWangNo">
                </ajaxToolkit:ValidatorCalloutExtender>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                顺序:
            </td>
            <td>
                <SHIBR:NumericTextBox ID="txtDisplayOrder" runat="server" Width="90%" RangeErrorMessage="请输入正确的整数."
                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup" MaximumValue="999999"
                    MinimumValue="-999999" PopupPosition="BottomLeft" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                说明:
            </td>
            <td colspan="2">
                <asp:TextBox TextMode="MultiLine" ID="txtComment" runat="server" Width="90%" Height="40"
                    MaxLength="150"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ValidationGroup="ModuleValidationGroup" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="关闭" OnClientClick="javascript:closeWindows();" />
            </td>
        </tr>
    </table>

</asp:Content>

