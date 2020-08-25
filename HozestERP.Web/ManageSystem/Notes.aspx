<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="Notes.aspx.cs" Inherits="HozestERP.Web.ManageSystem.Notes" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">
                内容
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtConent" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td style="width: 40px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 120px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowDetail(URL) {
            window.location = URL;
            //var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:800px;dialogHeight:600px;scroll:no;center:yes;");
            return false;
        }
    </script>
    <asp:GridView ID="grdNotice" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowDataBound="grdNotice_RowDataBound" OnRowCommand="grdNotice_RowCommand">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tbody>
                    <tr class="GridHeader" style="height: 22px; font-weight: bold;border:0px;">
                        <th align="center" class="GridHeard" style="width:30px;" nowrap="" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" onmouseover="SetHeadCellsCss('Over',this);"
                            onmouseout="SetHeadCellsCss('out',this);" scope="col">
                            标题
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 120px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            发布时间
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 150px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            发布者
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 60px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            发布
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="width: 120px; white-space: nowrap;"
                            onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            启用时间
                        </th>
                        <th class="GridHeard" nowrap="" style="width:30px;" onmouseover="SetHeadCellsCss('Over',this);" onmouseout="SetHeadCellsCss('out',this);"
                            scope="col">
                            详细
                        </th>
                    </tr>
                </tbody>
            </table>
        </EmptyDataTemplate>
        <Columns>
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
            <asp:BoundField DataField="Title" HeaderText="标题">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="发布时间">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("DateTime"), DateTimeKind.Utc).ToString("yyyy-MM-dd")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="120px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Promulgator" HeaderText="发布者">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="发布">
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkPublished" runat="server" Checked='<%#Eval("Published")%>' />
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="启用时间">
                <ItemTemplate>
                    <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("StartTime"), DateTimeKind.Utc).ToString("yyyy-MM-dd")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="120px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
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
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" OnClientClick="return ShowDetail('NotesDetails.aspx');" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" OnClientClick="return confirm('您确定要删除.');" />
            </td>
        </tr>
    </table>
</asp:Content>
