<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMClaimInfo.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMClaimInfo" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
        .AdjustFactoryPriceImg
        {
            width: 16px;
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px; text-align: right;">
                姓名
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtRealName" runat="server" Width="97%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                订单号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="97%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right;">
                理赔单号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtClaimCode" runat="server" Width="97%"></asp:TextBox>
            </td>
            <td style="width: 60px; text-align: right">
                创单时间
            </td>
            <td style="width: 100px">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 97%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 100px">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 97%;" />
            </td>
            <td style="width: 60px; text-align: right;">
                责任人
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtResponsiblePerson" runat="server" Width="97%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 40px; text-align: right;">
                项目
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 40px; text-align: right;">
                店铺
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 40px; text-align: right;">
                是否退回
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlIsReturn" runat="server" Width="100%">
                    <asp:ListItem Value="-1">--所有--</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="6">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClaimInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvClaimInfo_RowDataBound" OnRowCommand="grdvClaimInfo_RowCommand"
        ShowFooter="true">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" scope="col" style="white-space: nowrap;">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        理赔单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        订单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        客户姓名
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        客户电话
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        是否退回
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        创单时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        创单人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        财务确认
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
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
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                    <asp:HiddenField ID="hdSupplierID" Value='<%#Eval("Id")%>' runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="理赔单号" SortExpression="ClaimRef">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ClaimRef")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="客户姓名" SortExpression="FullName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("FullName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="客户电话" SortExpression="Tel">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("Tel")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否退回" SortExpression="ProductsMoney">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsReturn" runat="server" Width="20%" Checked='<%# Eval("IsReturn")==null? false :  Eval("IsReturn")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创单时间" SortExpression="CreateDate">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创单人">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateID") == null ? "" : CustomerName(Eval("CreateID").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="财务确认">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsAudit" runat="server" Width="20%" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgClaimDetail" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="查看理赔单" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfo.ProductDetails %>" />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑理赔单" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfo.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfo.Delete %>" OnClientClick="return confirm('您确定要删除此条记录？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfo.Add %>"
                    SkinID="button4" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfo.AllDelete %>"
                    OnClientClick="return CheckSelect(this,99);" OnClick="btnDelete_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
            <asp:Button ID="btnClaimInfoExport" SkinID="button6" runat="server" Text="导出数据"
                    OnClick="btnClaimInfoExport_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfo.ExportClaimInfo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnRowInfoExport" SkinID="button6" runat="server" Text="导出word" 
                    OnClick="btnRowInfoExport_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImport" SkinID="button6" runat="server" Text="导入数据"/>
            </td>
        </tr>
    </table>
</asp:Content>
