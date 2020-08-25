<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMCustomerServiceWangNoList.aspx.cs"
    Inherits="HozestERP.Web.ManageCustomerService.XMCustomerServiceWangNoList" %>

<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/UpdaeProcess.ascx" TagName="UpdateProcess" TagPrefix="SHIBR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客服与旺旺关系管理</title>
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
                <td style="width: 700px; height: 7px">
                </td>
                <td style="width: 300px;">
                </td>
            </tr>
            <tr>
               
                <td style="vertical-align: top; height: 100%;">
                    <table border="0" style="width: 100%; height: 100%;" cellspacing="0" cellpadding="0"
                        class="Borderline">
                        <tbody>
                            <tr class="EidtHead">
                                <td style="vertical-align: middle;">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="vertical-align: middle">
                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Text="旺旺号选择"></asp:Label>
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
                                                        <td style="width: 70px" align="right">
                                                            项目名称
                                                        </td>
                                                        <td style="width: 150px">
                                                            <asp:DropDownList ID="ddlNickId" runat="server" Width="100%"></asp:DropDownList>
                                                        </td>
                                                        <td style="width: 70px" align="right">
                                                            平台类型
                                                        </td>
                                                        <td style="width: 150px">
                                                            <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%"></asp:DropDownList>
                                                        </td>
                                                         <td style="width: 70px" align="right">
                                                            旺旺号
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:TextBox ID="ddlWangNo" runat="server"></asp:TextBox>
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
                                                <div style="width: 100%; height: 100%; overflow: auto; position: relative;">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="position: absolute; width: 100%;">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
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
                                                                    <asp:TemplateField HeaderText="项目名称">
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).NickName.nick : ""%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="平台类型">
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).PlatformTypeCodeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMWangNo).PlatformTypeCodeName.CodeName : ""%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="旺旺号">
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="170px" HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <%# Eval("WangNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="选择">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                                                SkinID="btnDetailAdd" CommandName="SelectCustomer"></asp:ImageButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="GridHeard" HorizontalAlign="Center" />
                                                                        <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <SHIBR:GridNevigator ID="GridNevigator1" runat="server" PageSize="10" OnPageChange="GridNevigator1_PageChange"  OnPageSizeChange="GridNevigator1_PageSizeChange"/>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                                                            <asp:AsyncPostBackTrigger ControlID="btnSelectAll" />
                                                        </Triggers>
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
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td align="left" id="tdContent2" runat="server" style="height: 40px;">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSelectAll" runat="server" Text="全选" OnClick="btnSelectAll_Click" />
                                            </td>
                                            <td style="width: 10px">
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSelect" runat="server" Text="确认" OnClick="btnSelect_Click" />
                                            </td>
                                            <td style="width: 10px">
                                            </td> <td>
                                                <asp:Button ID="btnRemove"  SkinID="button4" runat="server" Text="移除全部" OnClick="btnRemove_Click" />
                                            </td>
                                            <td style="width: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </td>
               
                <td style="vertical-align: top; height: 100%; table-layout: fixed;">
                    <table id="Table2" runat="server" border="0" style="width: 100%; height: 100%; background-color: White;"
                        cellspacing="0" cellpadding="0" class="Borderline">
                        <tr>
                            <td colspan="1" style="width: 8px; height: 4px">
                            </td>
                            <td colspan="6" style="height: 4px">
                            </td>
                            <td colspan="1" style="height: 4px">
                            </td>
                        </tr>
                        <tr id="tr2" class="EidtHead">
                            <td colspan="1" id="TD2">
                            </td>
                            <td colspan="6">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="vertical-align: middle">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="已选择旺旺号"></asp:Label>
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
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="position: absolute; width: 100%;">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdSelectCustomer" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                                SkinID="GridViewThemen" ShowHeader="false" OnRowCommand="grdSelectCustomer_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="旺旺号">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <%# Eval("WangNo")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="删除">
                                                        <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                                SkinID="btnDetailDelete" CommandName="DetailDelete"></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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
            </tr>
            <tr>
                <td style="height: 8px">
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
