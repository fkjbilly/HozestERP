<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMScalpingList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMScalpingList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <script language="javascript" type="text/javascript">
        var RefreshSearch = function () {
            window.parent.frames[1].RefreshSearch()
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    平台类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    店铺名称:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlNickId" runat="server" Width="100%" OnSelectedIndexChanged="ddlNickId_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 60px;">
                    创单时间
                </td>
                <td style="width: 160px">
                    <input id="txtOrderCreateDateStart" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 90%;" />
                </td>
                <td style="width: 10px">
                    到
                </td>
                <td style="width: 160px">
                    <input id="txtOrderCreateDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                        class="Wdate" runat="server" style="width: 90%;" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td style="width: 90px">
                    订单号:
                </td>
                <td style="width: 150px">
                    <asp:TextBox runat="server" ID="txtOrderCode" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 90px">
                    刷单单号:
                </td>
                <td style="width: 150px">
                    <asp:TextBox runat="server" ID="txtScalpingCode" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 60px">
                    是否异常
                </td>
                <td style="width: 80px">
                    <asp:DropDownList ID="ddIsAbnormal" runat="server" Width="90%">
                        <asp:ListItem Value="-1" Text="--所有--" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="0" Text="否"></asp:ListItem>
                        <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td>
                    <asp:CheckBox ID="chkfukuan" runat="server" Text="已付款" />
                </td>
                <td>
                </td>
                <td style="text-align: right" colspan="6">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                        OnClick="btnRefresh_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdXMScalpingList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowCommand="grdXMScalpingList_RowCommand" OnRowDataBound="grdXMScalpingList_RowDataBound"
        ShowFooter="true">
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
            <asp:TemplateField HeaderText="刷单单号" SortExpression="">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).ScalpingNo != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).ScalpingNo.ScalpingCode: ""%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台" SortExpression="">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).PlatformTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).PlatformTypeName.CodeName : ""%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺" SortExpression="">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).NickName.nick : ""%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创单时间" SortExpression="OrderInfoCreateDate">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderInfoCreateDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="旺旺号" SortExpression="WantID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WantID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品" SortExpression="ProductName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="销售价" SortExpression="SalePrice">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("SalePrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="佣金" SortExpression="Fee">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblFee" Text='<%# Eval("Fee")%>' runat="server"></asp:Label>
                    <asp:TextBox ID="txtFee" Text='<%# Eval("Fee") %>' runat="server" Visible="false"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgManufacturersInventoryVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ID="imgBtnFeeEdit" OnClick="imgBtnFeeEdit_Click" runat="server"
                        ImageUrl="~/App_Themes/Default/Image/update.gif" ToolTip="编辑" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnFeeUpdate" OnClick="imgBtnFeeUpdate_Click" runat="server"
                        ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnFeeCancel" OnClick="imgBtnFeeCancel_Click" runat="server"
                        ImageUrl="~/App_Themes/Default/Image/Cancel.gif" ToolTip="取消" CausesValidation="False" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="扣点" SortExpression="Deduction">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Deduction")%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="负责人"  SortExpression="">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).LeaderName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).LeaderName.FullName : ""%>
            </ItemTemplate> 
          </asp:TemplateField>

            <asp:TemplateField HeaderText="渠道类型"  SortExpression="">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).TypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).TypeName.CodeName : ""%>
            </ItemTemplate> 
          </asp:TemplateField> --%>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnEdit" runat="server" SkinID="btnDetail" ToolTip="编辑" CommandArgument='<%# Eval("ID") %>'
                        CommandName="Edit" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.Edit %>">
                    </asp:ImageButton>
                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("ID") %>' runat="server"
                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="ScalpingDelete"
                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingListt.Delete %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.Add %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="hidBtnMatchScalpingCode" runat="server" Style="width: 0px; display: none;"
                    ToolTip="匹配刷单单号" OnClick="hidBtnMatchScalpingCode_Click" />
                <asp:Button ID="hidBtnMatchScalpingCodePrompt" runat="server" Style="width: 0px;
                    display: none;" ToolTip="匹配刷单单号" OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')"
                    OnClick="hidBtnMatchScalpingCodePrompt_Click" />
                <asp:Button ID="btnMatchScalpingCode" SkinID="button6" runat="server" Text="匹配刷单单号"
                    ControlID="btnAllMatchScalpingCode" OnClick="btnMatchScalpingCode_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.MatchScalpingCode %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImportingPage" runat="server" SkinID="button6" Text="导入刷单记录" Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.ImportingPage %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnScalpingAudit" runat="server" OnClick="btnScalpingAudit_Click"
                    OnClientClick="return confirm('确定要转为正式订单？');" SkinID="button6" Text="转为正式订单"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.ScalpingAudit %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="But_pldyyd" SkinID="button6" runat="server" Text="批量打印运单" OnClick="But_pldyyd_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.pldyyd %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExortData" SkinID="button6" runat="server" Text="导出数据" OnClick="btnExortData_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMScalpingList.ExportScalpingData %>" />
            </td>
        </tr>
    </table>
</asp:Content>
