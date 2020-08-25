<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMNickAdvertisingCost.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMNickAdvertisingCost" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .floatRight
        {
            float: right;
            margin-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                时间
            </td>
            <td style="width: 120px">
                <input id="txtLogStartTime" runat="server" onfocus="WdatePicker()" class="Wdate"
                    readonly="readonly" />
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                到
            </td>
            <td style="width: 120px">
                <input id="txtLogEndTime" runat="server" onfocus="WdatePicker()" class="Wdate" readonly="readonly" />
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 20px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSetAdvertingFields" SkinID="button4" runat="server" Text="设置字段"
                    Visible='<% $CRMIsActionAllowed:ManageProject.XMNickAdvertisingCost.SetAdField %>' />
                <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:ManageProject.XMNickAdvertisingCost.Search %>"
                    OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvCWPlatformSpendingDetails" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" OnRowDataBound="grdvCWPlatformSpendingDetails_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                        scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        店铺名称
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        时间
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        广告费用
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        操作
                    </th>
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="50px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称">
                <HeaderStyle  HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                <ItemTemplate>
                    <%# Eval("NickName") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="时间">
                <HeaderStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="NotSet" Wrap="false" />
                <ItemTemplate>
                    <input style="background: transparent; border: 0; width: 150px;text-align:center" value='<%#  Convert.ToDateTime(Eval("Feedate")).ToString("yyyy-MM-dd")%>'
                        readonly="readonly" runat="server" id="lblProjectExplanation" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="广告费用">
                <HeaderStyle Width="450px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                <FooterStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lbFee" runat="server" Text='<%# Eval("Fee")==null?"0":Eval("Fee")%>'
                        CssClass="floatRight"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMNickAdvertisingCost.Edit %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
