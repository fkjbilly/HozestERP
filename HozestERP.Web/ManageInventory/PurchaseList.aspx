<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="PurchaseList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.PurchaseList" %>

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
                采购单号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtPurChaseCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 65px; text-align: right;">
                供应商
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlSupplierList" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 55px; text-align: right">
                制单日期
            </td>
            <td style="width: 100px">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 100px">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 50px; text-align: right;">
                审核状态
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlVerify" runat="server">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="未审核" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已审核" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 50px; text-align: right;">
                入库状态
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlStorageStatus" runat="server">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="待入库" Value="0"></asp:ListItem>
                    <asp:ListItem Text="部分入库" Value="1"></asp:ListItem>
                    <asp:ListItem Text="全部入库" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 60px; text-align: right;">
                发出工厂
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlEmitFactory" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 65px; text-align: right;">
                生成千胜订单
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlBuildOrder" runat="server" Width="80%">
                    <asp:ListItem Text="---所有---" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="否" Value="0"></asp:ListItem>
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="8">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
                <asp:Button ID="btnPurchaseAdd" SkinID="button6" runat="server" Text="新建采购单" Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.Add%>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvPurChase" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvPurChase_RowDataBound" OnRowCommand="grdvPurChase_RowCommand"
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
                        采购单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        交货时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        交货地址
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        供应商
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        供应商联系人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        电话
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        采购金额
                    </th>
                       <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        未审核金额
                    </th>
                     <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        已审核金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务员
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        部门审核
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        付款审核
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        入库状态
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
            <asp:TemplateField HeaderText="采购单号" SortExpression="PurchaseNumber">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PurchaseNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="交货时间" SortExpression="DealDate">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("DealDate") == null ? DateTime.Now.ToShortDateString() : Convert.ToDateTime(Eval("DealDate")).ToShortDateString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="交货地址" SortExpression="DealAddress">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblDealAddress" runat="server"><%# Eval("DealAddress")%></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="供应商" SortExpression="SuppliersName">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SuppliersName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="供应商联系人" SortExpression="Contact">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Contact")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="电话" SortExpression="Tel">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Tel")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="采购金额" SortExpression="ProductsMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductsMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="未审核金额" SortExpression="NotAuditProductsMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                     <asp:Label ID="lblNotAuditProductsMoney" runat="server"> <%# getAuditProductsMoney(Eval("Id").ToString(),false)%></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="已审核金额" SortExpression="AuditProductsMoney">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                     <asp:Label ID="lblAuditProductsMoney" runat="server"> <%# getAuditProductsMoney(Eval("Id").ToString(),true)%></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务员" SortExpression="BizUserId">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizUserId") == null ? "" : CustomerName(Eval("BizUserId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部门审核" SortExpression="IsAudit">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="IsAudit" runat="server" Checked='<%# getIsAudit(Convert.ToInt32(Eval("Id")))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# getIsAudit(Convert.ToInt32(Eval("Id")))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="生成千胜订单">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="IsBuildOrder" runat="server" Checked='<%# Eval("IsBuildOrder") == null ? false :Eval("IsBuildOrder")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库状态">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblPurchaseStatus" runat="server"> <%# getStorageStauts(Eval("BillStatus").ToString())%></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgProductDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="查看采购订单" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.ProductDetails %>" />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑采购订单" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.Delete %>" OnClientClick="return confirm('您确定要删除此条记录？');" />
                    <asp:ImageButton ID="imgRejected" runat="server" ToolTip="生成入库单" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.PurchaseRejected %>"
                        ImageUrl="~/App_Themes/Default/Image/AdjustFactoryPrice.png" CssClass="AdjustFactoryPriceImg" />
                    <asp:ImageButton ID="imgReturned" runat="server" ToolTip="生成未入库采购退货单" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.PurchaseReturned %>"
                        ImageUrl="~/images/u39_original.png" />
                    <asp:ImageButton ID="imgPay" runat="server" ToolTip="生成应付账款" CommandArgument='<%#Eval("Id")%>'  CausesValidation="false"
                        CommandName="Pay"
                         ImageUrl="~/images/TreeLeaf.gif" OnClick="imgPay_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    <ext:Window ID="window1" Padding="5" runat="server" Width="350" Height="170" Hidden="true" Title="新建应付账款单">
        <Items>
            <ext:FormPanel ID="FormPanel1" runat="server" Border="false" MonitorValid="true" BodyStyle="background-color:transparent;" Layout="FormLayout" Region="Center" LabelWidth="60">
                <Items>
                    <ext:NumberField runat="server" ID="txtAmount" FieldLabel="请款金额" AnchorHorizontal="93%" AllowBlank="false"  MsgTarget="Side"/>
                    <ext:TextArea runat="server" ID="txtReason" FieldLabel="请款原因" AnchorHorizontal="93%" AutoScroll="true"></ext:TextArea>
                </Items>
                <Listeners>
                            <ClientValidation Handler="#{btnSave}.setDisabled(!valid)" />
                </Listeners>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="btnSave" Text="保存" runat="server">
                <DirectEvents>
                    <Click OnEvent="btnSave_Click">

                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsAudit" SkinID="button4" runat="server" Text="部门审核" OnClick="btnIsAudit_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.IsAudit %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnIsAuditFalse" SkinID="button4" runat="server" Text="部门反审核" OnClick="btnIsAuditFalse_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.IsAuditFalse %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button SkinID="button6" ID="btnJDSelfPurchaseSupportExport" runat="server" Text="京东自营导入"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.JDSelfPurchaseSupportExport %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button SkinID="button6" ID="btnBuildOrder" runat="server" Text="生成千胜订单" OnClick="btnBuildOrder_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.PurchaseList.BuildOrder %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImportLogisticsFee" runat="server" SkinID="button6" Text="导入物流费用" />
            </td>
        </tr>
    </table>
</asp:Content>
