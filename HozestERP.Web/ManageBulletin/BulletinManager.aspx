<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="BulletinManager.aspx.cs" Inherits="HozestERP.Web.ManageOA.BulletinManager" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    标题
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtBulletinTitle" runat="server"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    状态
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="ddlBulletinStatus" runat="server" Width="90%">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    类型
                </td>
                <td style="width: 120px">
                    <HozestERP:CodeControl ID="ddlBulletinType" runat="server" CodeType="104" EmptyValue="true"
                        Width="100%" />
                </td>
                <td style="text-align: right">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    发布日期
                </td>
                <td colspan="2">
                    <HozestERP:DatePicker ID="txtStartDateTime" runat="server" Format="yyyy-MM-dd"></HozestERP:DatePicker>
                </td>
                <td style="width: 80px">
                    至
                </td>
                <td colspan="5">
                    <HozestERP:DatePicker ID="txtEndDateTime" runat="server" Format="yyyy-MM-dd"></HozestERP:DatePicker>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdBulletin" runat="server" Width="100%" AutoGenerateColumns="False"
        DataKeyNames="BulletinID" SkinID="GridViewThemen" OnRowDataBound="grdBulletin_RowDataBound"
        OnRowCommand="grdBulletin_RowCommand">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                <tbody>
                    <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                        <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            &nbsp;
                        </th>
                        <th align="center" class="GridHeard" nowrap="" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            标题
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            状态
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            类型
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            优先级
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 110px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            发布时间
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 100px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            生效日期
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 100px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            失效日期
                        </th>
                        <th class="GridHeard" nowrap="" onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            详细
                        </th>
                    </tr>
                </tbody>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BulletinTitle" HeaderText="标题">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <%# CommonHelper.GetDescription(typeof(HozestERP.BusinessLogic.ManageBulletin.BulletinStatusEnum), (Container.DataItem as HozestERP.BusinessLogic.ManageBulletin.Bulletin).BulletinStatuss.ToString())%>
                </ItemTemplate>
                <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类型">
                <ItemTemplate>
                    <%# Eval("BulletinType") != null ? (Eval("BulletinType") as HozestERP.BusinessLogic.Codes.CodeList).CodeName : ""%>
                </ItemTemplate>
                <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="优先级">
                <ItemTemplate>
                    <%# Eval("PriorType") != null ? (Eval("PriorType") as HozestERP.BusinessLogic.Codes.CodeList).CodeName : ""%>
                </ItemTemplate>
                <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="ReleasedDate" HeaderText="发布时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="110px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EffectiveDate" HeaderText="生效日期" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="100px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="InvalidDate" HeaderText="失效日期" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="100px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("BulletinID") %>'
                        SkinID="btnDetail" CommandName="Detail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" OnClientClick="return confirm('您确定要删除.');" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnReleased" runat="server" Text="公告发布" SkinID="button4" OnClick="btnReleased_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnEnd" runat="server" Text="公告终止" SkinID="button4" OnClientClick="return confirm('您确定终止公告.');"
                    OnClick="btnEnd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
