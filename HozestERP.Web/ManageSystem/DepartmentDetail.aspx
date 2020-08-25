<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/TwoCommonEdit.Master"
    AutoEventWireup="true" CodeBehind="DepartmentDetail.aspx.cs" Inherits="HozestERP.Web.ManageSystem.DepartmentDetail" %>

<%@ MasterType VirtualPath="~/MasterPages/TwoCommonEdit.Master" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomer"
    TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:UpdatePanel ID="upaltreeView" runat="server" style="position:absolute;">
        <ContentTemplate>
            <div >
                <asp:TreeView ID="trDepartment" runat="server" ShowLines="True" 
                    OnSelectedNodeChanged="trDepartment_SelectedNodeChanged" >
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
                上级单位：
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="100%" >
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
                部门编号<font color="red">*</font>：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtCode" runat="server" Width="100%" ErrorMessage="单位编号为必填."
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td>
            </td>
            <td>
                部门名称<font color="red">*</font>：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtName" runat="server" Width="100%" ErrorMessage="单位名称为必填."
                    ValidationGroup="ModuleValidationGroup" />
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
                部门类型<font color="red">*</font>：
            </td>
            <td>
                <asp:DropDownList ID="ddlDepType" runat="server" Width="100%">
                    <asp:ListItem Text="事业部" Value="0"></asp:ListItem>
                    <asp:ListItem Text="行政部" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                部门主管<font color="red">*</font>：
            </td>
            <td>                
                <SHIBR:SelectSingleCustomer ID="SelectCustomer" runat="server" ErrorMessage="请选择姓名."
                    PopupPosition="BottomRight" ValidationGroup="DismissonGroup" CustomerStatus="2" SessionPageID="DepartmentDetail">
                </SHIBR:SelectSingleCustomer>
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
                部门电话<font color="red">*</font>：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtTel" runat="server" Width="100%" ErrorMessage="单位电话为必填."
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td>
            </td>
            <td>
                部门地址<font color="red">*</font>：
            </td>
            <td>
                <SHIBR:SimpleTextBox ID="txtAddress" runat="server" Width="100%" ErrorMessage="单位电话为必填."
                    ValidationGroup="ModuleValidationGroup" />
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
                排序<font color="red">*</font>:
            </td>
            <td>
                <SHIBR:NumericTextBox ID="txtDisplayOrder" runat="server" Width="100%" RangeErrorMessage="请输入正确的整数."
                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup" MaximumValue="999999"
                    MinimumValue="-999999" />
            </td>
            <td>
            </td>
            <td colspan="2">
                <asp:CheckBox ID="chkPublished" runat="server" Text="&nbsp;发布" />
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
                描述:
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="100%" Height="80"></asp:TextBox>
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
                        <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ModuleValidationGroup"
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
            <script type="text/javascript" language="javascript">
                function Refesh(DepartmentID) {
                    alert("保存成功．");
                    var fromtrre = window.parent.document.getElementById("IframeTree");
                    fromtrre.location = "DepartmentTree.aspx?EnterpriseID=<%=this.EnterpriseID %>";
                    if (!isNaN(DepartmentID)) {
                        window.location = "DepartmentDetail.aspx?DepartmentID=" + DepartmentID + "&EnterpriseID=<%=this.EnterpriseID %>";
                    }
                }

                function BtnDelete() {
                    window.parent.IframeTree.location = "DepartmentTree.aspx?EnterpriseID=<%=this.EnterpriseID %>";
                    alert("删除成功．");
                    window.location = "DepartmentDetail.aspx?EnterpriseID=<%=this.EnterpriseID %>";
                }
    
            </script>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
