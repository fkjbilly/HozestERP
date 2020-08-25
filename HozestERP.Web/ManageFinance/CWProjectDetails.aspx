<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" CodeBehind="CWProjectDetails.aspx.cs" Inherits="HozestERP.Web.ManageFinance.CWProjectDetails" %>
  

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <td style="width: 25px; height: 8px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 200px">
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
                <asp:HiddenField ID="hidParentID" runat="server" />
                <asp:HiddenField ID="hidID" runat="server" />
            </td>
            <td>
                父节点：
            </td>
            <td>
                <asp:HiddenField ID="hidAreaID" runat="server" />
                <asp:DropDownList ID="ddlParentModule" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                项目名称<font color="red">*</font>:
            </td>
            <td>
                <HozestERP:SimpleTextBox ID="txtProjectExplanation" runat="server" Width="100%" ErrorMessage="项目名称为必填."
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td>
            </td>
            <td>
                项目类型<font color="red">*</font>：
            </td>
            <td>
               <HozestERP:CodeControl ID="ccTableTypeId" runat="server" CodeType="206" Width="100%" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td>
                序列<font color="red">*</font>：
            </td>
            <td colspan="4">
                 <HozestERP:NumericTextBox ID="txtDisplayOrder" runat="server" Width="100%" RangeErrorMessage="请输入正确的整数."
                                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup" MaximumValue="999999"
                                    MinimumValue="-999999" />
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> 
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ValidationGroup="ModuleValidationGroup" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" OnClientClick="return confirm('您确定要删除此条记录.');" />
            </td>
            <td>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        function Refesh(Id) {
            window.parent.IframeTree.location = window.parent.IframeTree.location;
            alert("保存成功．");
            if (!isNaN(moduleID)) {
                window.location = "CWProjectDetails.aspx?Id=" + Id;
            }
        }

        function BtnDelete() {
            window.parent.IframeTree.location = window.parent.IframeTree.location;
            alert("删除成功．");
            window.location = "CWProjectDetails.aspx";
        }
    
    </script>
</asp:Content>
