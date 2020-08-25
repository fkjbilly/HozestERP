<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSingleCustomer.aspx.cs"
    Inherits="HozestERP.Web.Modules.SelectSingleCustomer" %>

<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/UpdaeProcess.ascx" TagName="UpdateProcess" TagPrefix="SHIBR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员选择</title>
    <base target="_self" />
    <meta http-equiv="expires" content="0" />
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <div id="bodyDiv">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
            <tr>
                <td style="width: 8px; height: 8px">
                </td>
                <td style="width: 200px;">
                </td>
                <td style="width: 8px; height: 8px">
                </td>
                <td>
                </td>
                <td style="width: 8px; height: 8px">
                </td>
            </tr>
            <tr>
                <td style="width: 8px; height: 8px">
                </td>
                <td style="vertical-align: top; height: 100%; table-layout: fixed;">
                    <table id="Table1" runat="server" border="0" style="width: 100%; height: 100%; background-color: White;"
                        cellspacing="0" cellpadding="0" class="Borderline">
                        <tr>
                            <td colspan="1" style="width: 8px; height: 4px">
                            </td>
                            <td colspan="6" style="height: 4px">
                            </td>
                            <td colspan="1" style="height: 4px">
                            </td>
                        </tr>
                        <tr id="tr1" class="EidtHead">
                            <td colspan="1" id="TD3">
                            </td>
                            <td colspan="6">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="vertical-align: middle">
                                            <asp:Label ID="lblLeftTitle" runat="server" Font-Bold="True" Text="部门选择"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="1">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                            </td>
                            <td colspan="6" style="height: 4px">
                            </td>
                            <td colspan="1">
                            </td>
                        </tr>
                        <tr style="height: 100%;">
                            <td colspan="1">
                            </td>
                            <td colspan="6" style="height: 100%; overflow: hidden;">
                                <div style="width: 100%; height: 100%; overflow: auto; position: relative;">
                                    <asp:UpdatePanel ID="upanletree" runat="server" style="position: absolute; width: 100%;">
                                        <ContentTemplate>
                                            <asp:TreeView ID="trDepartment" runat="server" ShowLines="True" OnSelectedNodeChanged="trDepartment_SelectedNodeChanged">
                                                <NodeStyle Height="18px" />
                                                <SelectedNodeStyle BackColor="#9C9CF8" />
                                            </asp:TreeView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                            <td colspan="1">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 4px">
                            </td>
                            <td style="height: 4px;" colspan="6" rowspan="1">
                            </td>
                            <td style="width: 4px">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 4px;">
                    &nbsp;
                </td>
                <td style="vertical-align: top; height: 100%;">
                    <table border="0" style="width: 100%; height: 100%;" cellspacing="0" cellpadding="0"
                        class="Borderline">
                        <tbody>
                            <tr class="EidtHead">
                                <td style="vertical-align: middle;">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="vertical-align: middle">
                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Text="人员选择"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td style="height: 4px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 12px;">
                                    <table id="SearchTab" runat="server" border="0" cellpadding="0" cellspacing="0" style="background-color: White;
                                        border-right: #ababab 1px solid; border-top: #ababab 1px solid; border-left: #ababab 1px solid;
                                        width: 100%; border-bottom: #ababab 1px solid;">
                                        <tr style="height: 4px">
                                            <td style="width: 4px">
                                            </td>
                                            <td style="vertical-align: top;">
                                            </td>
                                            <td style="width: 4px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4px">
                                            </td>
                                            <td style="vertical-align: top;">
                                                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 80px">
                                                            姓名
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 80px">
                                                            工号
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:TextBox ID="txtJobNumber" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 4px">
                                            </td>
                                        </tr>
                                        <tr style="height: 4px">
                                            <td style="width: 4px">
                                            </td>
                                            <td style="vertical-align: top;">
                                            </td>
                                            <td style="width: 4px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server">
                                <td style="height: 4px;">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table runat="server" id="tablework" border="0" style="width: 100%; height: 100%;
                                        background-color: White" cellspacing="0" cellpadding="0" class="Borderline">
                                        <tr>
                                            <td colspan="1" style="width: 8px; height: 4px">
                                            </td>
                                            <td colspan="6" style="height: 4px">
                                            </td>
                                            <td colspan="1" style="height: 4px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
                                            </td>
                                            <td colspan="6" style="height: 100%; overflow: hidden;">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="width: 100%; height: 100%;
                                                    overflow: auto; position: relative;">
                                                    <ContentTemplate>
                                                        <div style="position: absolute;width:100%;">
                                                            <asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
                                                                SkinID="GridViewThemen" OnRowCommand="grdCustomer_RowCommand">
                                                                <EmptyDataTemplate>
                                                                    <p>
                                                                        没有您要查看的数据</p>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center" CssClass="GridHeard">
                                                                        </HeaderStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="工号">
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <%# Eval("JobNumber")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="姓名">
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <%# Server.HtmlEncode(Eval("FullName").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="部门">
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <%# (Container.DataItem as CustomerInfo).SDepartment!=null?(Container.DataItem as CustomerInfo).SDepartment.DepName :""%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="选择">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("CustomerID") %>'
                                                                                SkinID="btnDetailAdd" CommandName="SelectCustomer"></asp:ImageButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <SHIBR:GridNevigator ID="GridNevigator1" runat="server" PageSize="10" OnPageChange="GridNevigator1_PageChange"
                                                                OnPageSizeChange="GridNevigator1_PageSizeChange" />
                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 4px">
                                            </td>
                                            <td style="height: 4px;" colspan="6" rowspan="1">
                                            </td>
                                            <td style="width: 4px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 8px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <SHIBR:UpdateProcess ID="UpdateProcess1" runat="server"></SHIBR:UpdateProcess>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
