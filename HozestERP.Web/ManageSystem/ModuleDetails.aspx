<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ModuleDetails.aspx.cs" Inherits="HozestERP.Web.ManageSystem.ModuleDetails" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="CRM" %>

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
                <asp:HiddenField ID="hidParentModuleID" runat="server" />
                <asp:HiddenField ID="hidModuleID" runat="server" />
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
                编号<font color="red">*</font>:
            </td>
            <td>
                <CRM:SimpleTextBox ID="txtModuleCode" runat="server" Width="100%" ErrorMessage="编号为必填."
                    ValidationGroup="ModuleValidationGroup" />
            </td>
            <td>
            </td>
            <td>
                名称<font color="red">*</font>：
            </td>
            <td>
                <CRM:SimpleTextBox ID="txtModuleName" runat="server" Width="100%" ErrorMessage="名称为必填."
                    ValidationGroup="ModuleValidationGroup" />
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
                地址<font color="red">*</font>：
            </td>
            <td colspan="4">
                <CRM:SimpleTextBox ID="txtHref" runat="server" Width="100%" ErrorMessage="地址为必填."
                    ValidationGroup="ModuleValidationGroup" />
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
            <td colspan="5" style="padding-right: 40px;">
                <fieldset title="属性" style="width: 100%;" class="fieldset">
                    <legend>属性</legend>
                    <table>
                        <tr>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                                <asp:CheckBox ID="chkExpand" runat="server" Text="是否展开" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPublished" runat="server" Text="是否发布" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkisTarget" runat="server" Text="是否单独页" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                                序列<font color="red">*</font>：
                            </td>
                            <td colspan="5">
                                <CRM:NumericTextBox ID="txtDisplayOrder" runat="server" Width="100%" RangeErrorMessage="请输入正确的整数."
                                    RequiredErrorMessage="请输入正确的整数." ValidationGroup="ModuleValidationGroup" MaximumValue="999999"
                                    MinimumValue="-999999" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 10px; height: 8px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10px; height: 8px;">
                            </td>
                            <td>
                                菜单图标样式：
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txticonCls" runat="server" Width="100%" Text="filesw"></asp:TextBox>
                            </td>
                            <td style="width: 25px;">
                            </td>
                            <td style="width: 100px;">
                                应用图标样式：
                            </td>
                            <td colspan="4" style="width: 180px;">
                                <asp:TextBox ID="txtAppIconCls" runat="server" Width="100%" Text="default.png"></asp:TextBox>
                            </td>
                            <td style="width: 8px; height: 8px">
                            </td>
                        </tr>
                    </table>
                </fieldset>
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
            <td colspan="5" style="padding-right: 40px;">
                <fieldset title="事件" style="width: 100%;" class="fieldset">
                    <legend>事件
                        <asp:Button ID="btnAddClick" runat="server" Text="新增事件" SkinID="button4" OnClick="btnAddClick_Click" /></legend>
                      
                    <script language="javascript" type="text/javascript">
                        function ShowDetail(URL) {
                            //var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:400px;dialogHeight:280px;center:yes;");
                            layer_show("新增事件", URL, 400, 280);
                            return true;
                        }
                    
                    </script>
                    <asp:GridView ID="grdvMessage" runat="server" AutoGenerateColumns="False" DataKeyNames="ModuleID"
                        SkinID="GridViewThemen" OnRowCommand="grdvMessage_RowCommand" OnRowDataBound="grdvMessage_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="动作">
                                <HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="GridHeard"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="KeyWord">
                                <HeaderStyle Wrap="False"   HorizontalAlign="Center" CssClass="GridHeard"></HeaderStyle>
                                <ItemTemplate>
                                   <div style="word-break:break-all;width:231px;overflow:auto;"><%# Eval("SystemKeyword") %></div> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Comment" HeaderText="说明">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <HeaderStyle Wrap="False" Width="80px" HorizontalAlign="Center" CssClass="GridHeard">
                                </HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DisplayOrder" HeaderText="顺序">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <HeaderStyle Width="80px" Wrap="False" HorizontalAlign="Center" CssClass="GridHeard">
                                </HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="详细" HeaderStyle-CssClass="GridHeard">
                                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("CustomerActionID") %>'
                                        SkinID="btnDetail" CommandName="detail"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="GridHeard">
                                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDetailDelete" runat="server" CommandArgument='<%# Eval("CustomerActionID") %>'
                                        SkinID="btnDetailDelete" CommandName="btnDelete" OnClientClick="return confirm('您确定要删除此条记录.');">
                                    </asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>

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
               <asp:Button ID="btnRefesh" style="display:none" runat="server" Text="刷新" OnClick="btnAddClick_Click" />
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        function RefeshGridView() {
            document.getElementById("ctl00_Contentplaceholder2_btnRefesh").click();
        }
       
        function Refesh(moduleID) {
            window.parent.IframeTree.location = window.parent.IframeTree.location;
            alert("保存成功．");
            if (!isNaN(moduleID)) {
                window.location = "ModuleDetails.aspx?ModuleID=" + moduleID;
            }
        }

        function BtnDelete() {
            window.parent.IframeTree.location = window.parent.IframeTree.location;
            alert("删除成功．");
            window.location = "ModuleDetails.aspx";
        }
    
    </script>
</asp:Content>


