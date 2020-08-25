<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="JDSaleRejectedList.aspx.cs" Inherits="HozestERP.Web.ManageInventory.JDSaleRejectedList" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px; text-align: right;">
                退货单号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtRejectedCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 55px; text-align: right">
                业务时间
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
                退回工厂
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="DdlFactory" Width="90%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 50px; text-align: right;">
                推送千胜
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlXBIsConfirm" runat="server" Width="90%">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="未确认" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已确认" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 60px; text-align: right;">
                备件单号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtPrepareRef" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 55px; text-align: right">
                京东确认
            </td>
            <td style="width: 100px">
                <input id="txtJDBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 100px">
                <input id="txtJDEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 50px; text-align: right;">
                京东确认
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlJDIsConfirm" runat="server" Width="90%">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="未确认" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已确认" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; text-align: right;">
                退货类型
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlReturnCategoryList" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 55px; text-align: right">
                喜临门确认
            </td>
            <td style="width: 100px">
                <input id="txtXLMBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px; text-align: center">
                至
            </td>
            <td style="width: 100px">
                <input id="txtXLMEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 50px; text-align: right;">
                喜临门确认
            </td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlXLIIsConfirm" runat="server" Width="90%">
                    <asp:ListItem Text="所有" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="未确认" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已确认" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td style="width: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 60px; text-align: right;">
                项目
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width:60px; text-align: right;">
                店铺
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 50px; text-align: right;">
                备&nbsp; 注</td>
            <td colspan="3">
                <asp:TextBox ID="txtNote" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="text-align: right" colspan="2">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
                <asp:Button ID="btnRejectedAdd" SkinID="button6" runat="server" Text="新建退货单" Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.Add%>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvJdRejecedInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvJdRejecedInfo_RowDataBound" OnRowCommand="grdvJdRejecedInfo_RowCommand"
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
                        退货单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        备件单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        店铺
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        退货金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        退货类型
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        退回工厂
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务员
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        业务时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        录单人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        京东确认
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        京东确认时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        新邦确认
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        喜临门确认
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        喜临门确认时间
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
            <asp:TemplateField HeaderText="退货单号" SortExpression="Ref">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Ref")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备件单号">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("PrepareRef")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺" SortExpression="NickName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("NickName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="退货金额" SortExpression="ReturnMoney">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReturnMoney")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="退货类型" SortExpression="ReturnCategoryName">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ReturnCategoryName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="退回工厂" SortExpression="FactoryName">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FactoryName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务员">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizUserId") == null ? "" : CustomerName(Eval("BizUserId").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="业务时间" SortExpression="Tel">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("BizDt")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="录单人">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CreateID") == null ? "" : CustomerName(Eval("CreateID").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="京东确认" SortExpression="JDIsConfirm">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="JDIsConfirm" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="京东确认时间">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("JDConfirmDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="推送千胜" SortExpression="XBIsConfirm">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="XBIsConfirm" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="喜临门确认">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="XLMIsConfirm" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="喜临门确认时间">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("XLMConfirmDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgProductDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="查看京东自营退货单" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.ProductDetails %>" />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑京东自营退货单" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="删除" CommandName="Del" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.Delete %>"
                        OnClientClick="return confirm('您确定要删除此条记录？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnJDIsConfirm" SkinID="button6" runat="server" Text="京东确认" OnClick="btnJDIsConfirm_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.JDIsConfirm %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnXBIsConfirm" SkinID="button6" runat="server" Text="推送千胜" OnClick="btnSendQS_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.XBIsConfirm %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnXLMIsConfirm" SkinID="button6" runat="server" Text="喜临门确认" OnClick="btnXLMIsConfirm_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.JDSaleRejectedList.XLMIsConfirm %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExport" SkinID="button6" runat="server" Text="导出" OnClick="btnExport_Click" />
            </td>   
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImportLogisticsFee" runat="server" SkinID="button6" Text="导入物流费用" />
            </td>
        </tr>
    </table>
        <ext:Window ID="window1" runat="server" Width="300" Height="100" Hidden="true" Title="确认时间">
        <Items>
            <ext:FormPanel ID="FormPanel1" runat="server" Border="false" MonitorValid="true" BodyStyle="background-color:transparent;" Layout="FormLayout">
                <Items>
                    <ext:DateField runat="server" ID="dfJdComfirmDate" FieldLabel="京东确认时间" AnchorHorizontal="98%" Format="yyyy-MM-dd"></ext:DateField>
                </Items>
                <Buttons>
                    <ext:Button ID="btnJdSave" Text="保存" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnJdSave_Click">

                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Window>
    <ext:Window ID="window2" runat="server" Width="300" Height="100" Hidden="true" Title="确认时间">
        <Items>
            <ext:FormPanel ID="FormPanel2" runat="server" Border="false" MonitorValid="true" BodyStyle="background-color:transparent;" Layout="FormLayout">
                <Items>
                    <ext:DateField runat="server" ID="dfXlmComfirmDate" FieldLabel="喜临门确认时间" AnchorHorizontal="98%" Format="yyyy-MM-dd"></ext:DateField>
                </Items>
                <Buttons>
                    <ext:Button ID="btnXlmSave" Text="保存" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnXlmSave_Click">

                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Window>
</asp:Content>
