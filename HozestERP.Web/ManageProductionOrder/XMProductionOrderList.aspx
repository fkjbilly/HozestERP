<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMProductionOrderList.aspx.cs" Inherits="HozestERP.Web.ManageProductionOrder.XMProductionOrderList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function SaveOrderInfoIDs() {
            var IdStr = "";
            var Ids = "";
            $("input[type=checkbox]").each(function (i, item) {
                if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                    IdStr = item.id.replace("_chkSelected", "_hdNickManageInfoID");
                    var value = document.getElementById(IdStr).value.replace("on", "");
                    if (Ids == "") {
                        Ids = value;
                    }
                    else {
                        Ids += "," + value;
                    }
                }
            });

            jQuery(function ($) {
                $.ajax({ url: "/ManageProject/xMOrderInfoList.ashx?Ids=" + Ids,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: "action=SaveOrderInfoIDs",
                    success: function (json) {
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px">
                项目名称
            </td>
            <td style="width: 120px;">
                <asp:DropDownList ID="ddXMProject" Width="90%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                店铺名称
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlNick" Width="90%" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                平台类型
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="90%">
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                状态
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddOrderStatusId" runat="server" Width="90%">
                    <asp:ListItem Text="所有" Value="-1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="未入库" Value="1000"></asp:ListItem>
                    <asp:ListItem Text="部分入库" Value="1002"></asp:ListItem>
                    <asp:ListItem Text="已入库" Value="1004"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 60px">
                订单编号
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                姓名
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtFullName" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                网名
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtWantID" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                排单
            </td>
            <td style="width: 120px;" valign="middle" align="left">
                <asp:DropDownList ID="ddlSingleRow" runat="server" Width="90%" >
                    <asp:ListItem Value="-1">---所有---</asp:ListItem>
                    <asp:ListItem Value="1">已排单</asp:ListItem>
                    <asp:ListItem Value="0">未排单</asp:ListItem>
                    <asp:ListItem Value="2">部分排单</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 60px">
                产品编码
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtManufacturersCode" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                地址
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtAddress" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                手机号码
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtMobile" runat="server" Width="90%"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                入库状态
            </td>
            <td style="width: 120px">
                <asp:DropDownList ID="ddlStorageStatus" runat="server" Width="90%" >
                    <asp:ListItem Value="-1">---所有---</asp:ListItem>
                    <asp:ListItem Value="1004">已入库</asp:ListItem>
                    <asp:ListItem Value="1000">未入库</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 60px;">
                预计入库时间：
            </td>
            <td style="width: 120px">
                <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                到
            </td>
            <td style="width: 120px">
                <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px">
            </td>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td colspan="10">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="width: 20px; white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        平台
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        店铺名称
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        订单编号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        网名
                    </th>
                    <th align="center" class="GridHeard" style="width: 90px; white-space: nowrap;" scope="col">
                        生产单号
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        姓名
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        手机
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        收货地址
                    </th>
                    <th align="center" class="GridHeard" style="width: 80px; white-space: nowrap;" scope="col">
                        备注
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        预计入库时间
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        入库状态
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        是否排单
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
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdNickManageInfoID" Value='<%#Eval("OrderInfoID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台" SortExpression="PlatformTypeId">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Literal ID="PlatformTypeId" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称" SortExpression="NickID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# base.XMNickService.ReturnNickNameByID(int.Parse(Eval("NickID").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单编号" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网名" SortExpression="WantID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("WantID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="生产单号" SortExpression="ProductionNumber">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("ProductionNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="FullName">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FullName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="手机" SortExpression="Mobile">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Mobile")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="收货地址">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("DeliveryAddress")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预计入库时间" SortExpression="EstimateStorageDate">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("EstimateStorageDate")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库状态">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Literal ID="lblStorageStatus" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否排单">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:NotBoolImageCheckBox ID="chkIsSingleRow" runat="server" Width="20%" SelectedValue='<%# IsSingleRow(Eval("ID").ToString())%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnProductionOrderDetail" runat="server" SkinID="btnDetail"
                        ToolTip="详情" CommandArgument='<%# Eval("Id") %>' CommandName="XMProductionOrderDetail"
                        Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderList.SeeXMProductionOrderDetail %>">
                    </asp:ImageButton>
                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server"
                        ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除" CommandName="XMProductionOrderInfoDelete"
                        CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');" Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderList.XMOrderInfoDelete %>" />
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
                <asp:Button ID="btnBatchSingleRow" SkinID="button6" runat="server" Text="批量排单" Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderList.SingleRow %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnImportProductionNumber" SkinID="button6" runat="server" Text="导入生产单号"
                    Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderList.ImportProductionNumber %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnStorage" OnClick="btnStorage_Click" SkinID="button6" runat="server"
                    Text="已入库" Visible="<% $CRMIsActionAllowed:ManageProductionOrder.XMProductionOrderList.Storage %>" />
            </td>
        </tr>
    </table>
</asp:Content>
