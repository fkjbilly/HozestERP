<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="Bulletins.aspx.cs" Inherits="HozestERP.Web.ManageOA.Bulletins" %>

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
                <td style="width: 50px">
                    标题
                </td>
                <td style="width: 150px">
                    <asp:TextBox ID="txtBulletinTitle" runat="server"></asp:TextBox>
                </td>
                <td style="width: 80px">
                    发布日期
                </td>
                <td style="width: 160px">
                    <HozestERP:DatePicker ID="txtStartDateTime" runat="server" Format="yyyy-MM-dd"></HozestERP:DatePicker>
                </td>
                <td style="width: 30px">
                    至
                </td>
                <td style="width: 170px">
                    <HozestERP:DatePicker ID="txtEndDateTime" runat="server" Format="yyyy-MM-dd"></HozestERP:DatePicker>
                </td>
                <td style="width: 70px">
                    类型
                </td>
                <td>
                    <HozestERP:CodeControl ID="ddlBulletinType" runat="server" CodeType="104" EmptyValue="true"
                        Width="120px" />
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowDetail(Url) {
            window.open(Url, "", "width=800,height=500,resizable=yes,scrollbars=yes");
            // window.showModalDialog(Url, null, "dialogwidth:800px; dialogheight:500px;status:0;help:0;certer:1");
            return false;
        }
    </script>
    <asp:GridView ID="grdBulletin" runat="server" Width="100%" AutoGenerateColumns="False"
        DataKeyNames="BulletinID" SkinID="GridViewThemen" OnRowDataBound="grdBulletin_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tbody>
                    <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                        <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            &nbsp;
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            标题
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap; width: 70px;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            类型
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap; width: 70px;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            优先级
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 100px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            发布人
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 100px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            发布日期
                        </th>
                        <th class="GridHeard" style="width: 30px;" nowrap="" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            查看
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
            <asp:BoundField DataField="BulletinTitle" HeaderText="标题">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
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
            <asp:BoundField DataField="CreatorFullName" HeaderText="发布人">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="100px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EffectiveDate" HeaderText="发布日期" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="100px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="查看">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("BulletinID") %>'
                        SkinID="btnDetail" CommandName="Detail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
