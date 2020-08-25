<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="XMClaimInfoAdd.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMClaimInfoAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function autoCompleteBind(str) {
            $("#<%=txtOrderCode.ClientID %>").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "XMClaim.ashx?action=ClaimInfo",
                        data: "p=" + str + "&q=1",
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: " 订单号：" + item.OrderCode + " 店铺：" + item.NickName + " 平台：" + item.PlatformType + " 收货人：" + item.FullName + "手机：" + item.Mobile,
                                    value: item.OrderCode,
                                    order: item
                                }
                            }));
                        }
                    });
                }
            }, {
                select: function (e, i, j) {
                    var list = $("#<%=txtOrderCode.ClientID %>");
                    if (list != null && list.length > 0) {
                        document.getElementById("<%=txtOrderCode.ClientID %>").value = i.item.order.OrderCode;
                        document.getElementById("<%=txtRealName.ClientID %>").value = i.item.order.FullName;
                        document.getElementById("<%=txtTel.ClientID %>").value = i.item.order.Mobile;
                        document.getElementById("<%=ddlNick.ClientID %>").value = i.item.order.NickID;
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .table
        {
            border-collapse: collapse;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
            color: #9BC2DB;
            text-align: center;
        }
        .table tr th
        {
            border: solid 1px #9BC2DB;
            background: #9BC2DB;
            color: #FFF;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
        }
        .table tr td
        {
            border: solid 1px #9BC2DB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    理赔单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lblMessage" runat="server">  <font color="red">保存后自动生成</font></asp:Label>
                    <asp:Literal ID="lblRef" runat="server"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                    订单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtOrderCode" runat="server" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    客户姓名
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtRealName" runat="server" Width="50%"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    客户电话
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtTel" runat="server" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    退回单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtReturnCode" runat="server" Width="50%"></asp:TextBox>
                </td>
                <td style="width: 140px" align="right">
                    是否退回
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:CheckBox ID="ckbIsRerturn" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 140px" align="right">
                    项目
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="width: 140px" align="right">
                    店铺
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:DropDownList ID="ddlNick" Width="90%" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="myTr">
                <td style="width: 140px" align="right">
                    理赔类型
                </td>
                <td style="width: 218px; border-right: 1px soild red;" id="tdClaimType">
                    <asp:CheckBoxList ID="cblClaimType" CssClass="cblQuestionType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="cblClaimType_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </td>
                <td style="width: 140px" align="right">
                    发出物流单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:TextBox ID="txtLogisticsNumber" runat="server" Width="50%" OnTextChanged="txtLogisticsNumber_Changed"
                        AutoPostBack="true"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <asp:UpdatePanel ID="UpFigureMap" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td align="right" style="width: 20%">
                        <asp:FileUpload ID="FileUpFigureMap" runat="server" />
                    </td>
                    <td align="left" style="width: 80%">
                        <asp:Button ID="btnFigureMap" runat="server" Text="添加" OnClick="btnFigureMap_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 100%;">
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:HyperLink ID="Link1" runat="server" Target="_blank">
                                        <img id="ImgFigure1" runat="server" /></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <asp:HyperLink ID="Link2" runat="server" Target="_blank">
                                        <img id="ImgFigure2" runat="server" /></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <asp:HyperLink ID="Link3" runat="server" Target="_blank">
                                        <img id="ImgFigure3" runat="server" /></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <asp:HyperLink ID="Link4" runat="server" Target="_blank">
                                        <img id="ImgFigure4" runat="server" /></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <asp:HyperLink ID="Link5" runat="server" Target="_blank">
                                        <img id="ImgFigure5" runat="server" /></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <asp:HyperLink ID="Link6" runat="server" Target="_blank">
                                        <img id="ImgFigure6" runat="server" /></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="imgFigureMapDel1" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandName="1" ToolTip="删除" OnClick="imgFigureMapDel_Click" OnClientClick="return confirm('您确定要删除此图么？');" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imgFigureMapDel2" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandName="2" ToolTip="删除" OnClick="imgFigureMapDel_Click" OnClientClick="return confirm('您确定要删除此图么？');" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imgFigureMapDel3" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandName="3" ToolTip="删除" OnClick="imgFigureMapDel_Click" OnClientClick="return confirm('您确定要删除此图么？');" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imgFigureMapDel4" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandName="4" ToolTip="删除" OnClick="imgFigureMapDel_Click" OnClientClick="return confirm('您确定要删除此图么？');" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imgFigureMapDel5" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandName="5" ToolTip="删除" OnClick="imgFigureMapDel_Click" OnClientClick="return confirm('您确定要删除此图么？');" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imgFigureMapDel6" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        CommandName="6" ToolTip="删除" OnClick="imgFigureMapDel_Click" OnClientClick="return confirm('您确定要删除此图么？');" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnFigureMap" />
        </Triggers>
    </asp:UpdatePanel>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdvClaimProductDetails" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Id" SkinID="GridViewThemen" OnRowCancelingEdit="grdvClaimProductDetails_RowCancelingEdit"
        OnRowDeleting="grdvClaimProductDetails_RowDeleting" OnRowEditing="grdvClaimProductDetails_RowEditing"
        OnRowUpdating="grdvClaimProductDetails_RowUpdating" OnRowDataBound="grdvClaimProductDetails_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("ManufacturersCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品编码">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("PlatformMerchantCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("PrdouctName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductNum")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductNum" runat="server" Width="90%"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfoAdd.ProductDetailsEdit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfoAdd.ProductDetailsDelete %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdvClaimType" runat="server" AutoGenerateColumns="False" DataKeyNames="CodeID"
                SkinID="GridViewThemen" OnRowDataBound="grdvClaimType_RowDataBound">
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                &nbsp;
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                编号
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                理赔类型
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                理赔金额
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                受损情况
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                原因
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                责任人
                            </th>
                            <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                                确认
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
                    <asp:TemplateField HeaderText="编号" SortExpression="CodeID">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <%# Eval("CodeID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="理赔类型" SortExpression="CodeName">
                        <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <%# Eval("CodeName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="理赔金额">
                        <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="txtClaimAcount" runat="server" Width="90%"></asp:TextBox>
                            <asp:HiddenField ID="hiddCodeID" Value='<%#Eval("CodeID")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="受损情况">
                        <HeaderStyle Width="250px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:CheckBoxList ID="cblDamagedCondition" CssClass="cblQuestionType" runat="server"
                                RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
                            </asp:CheckBoxList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="原因">
                        <HeaderStyle Width="250px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="txtClaimReason" runat="server" Width="98%"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="责任人">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:TextBox ID="txtResponsiblePerson" runat="server" Width="90%"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="确认">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                        <ItemTemplate>
                            <asp:CheckBox ID="cbkIConfirm" runat="server" Checked="false" Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cblClaimType" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:GridView ID="grdvClaimInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClaimInfo_RowCommand" OnRowDataBound="grdvClaimInfo_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        理赔类型
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        理赔金额
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        受损情况
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        原因
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        责任人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        确认人
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        确认时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        确认
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
                <HeaderStyle Wrap="False" Width="15px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="理赔类型" SortExpression="CodeName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CodeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="理赔金额">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox ID="txtClaimAcount" runat="server" Width="90%" Text='<%#Eval("ClaimAcount")%>'></asp:TextBox>
                    <asp:HiddenField ID="hiddCodeID" runat="server" Value='<%#Eval("ClaimTypeID")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="受损情况">
                <HeaderStyle Width="250px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:CheckBoxList ID="cblDamagedCondition" CssClass="cblQuestionType" runat="server"
                        RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
                    </asp:CheckBoxList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="原因">
                <HeaderStyle Width="250px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%--<asp:TextBox ID="txtClaimReason" runat="server" Width="95%" Text='<%#Eval("Reason")%>'></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlReason" runat="server" Width="95%"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="责任人">
                <HeaderStyle Width="35px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:TextBox ID="txtResponsiblePerson" runat="server" Width="85%" Text='<%# Eval("ResponsiblePerson") == null ? "" : Eval("ResponsiblePerson")%>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="确认人" SortExpression="ConfirmPerson">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ConfirmPerson") == null ? "" : CustomerName(Eval("ConfirmPerson").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="确认时间" SortExpression="ConfirmDate">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ConfirmDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="确认">
                <HeaderStyle Width="25px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:CheckBox ID="cbkIConfirm" runat="server" Checked='<%#Eval("IsConfirm")%>' Enabled='false' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="10px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Blue/Image/MeetingConfirm.png"
                        CommandArgument='<%#Eval("Id")%>' ToolTip="确认" CommandName="Comfirm" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfoAdd.IsConfirm %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick="on_buttonClientClick();"
                    ValidationGroup="ModuleValidationGroup" OnClick="btnSave_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimInfoAdd.Save %>" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on("keyup", "#<%=txtOrderCode.ClientID %>", function () {
                autoCompleteBind($(this).val());
            });
        });
    </script>
</asp:Content>
