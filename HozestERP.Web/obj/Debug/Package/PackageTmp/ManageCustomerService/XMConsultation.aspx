<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMConsultation.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMConsultations" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/ImageButtonSelectSingleCustomerControl.ascx" TagName="ImageButtonSelectSingleCustomerControl"
    TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        function autoCompleteBind() {
            var str = "";
            str = $("#<%= gvQuestion.ClientID%> :input[id*='txtManufacturersCode']");

            str.autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "xMConsultation.ashx",
                        data: "ManufacturersCode=" + str[0].value,
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: " 厂家编码：" + item.Group + " 产品名称：" + item.Name,
                                    value: item.Group,
                                    order: item
                                };
                            }));
                        }
                    });
                }
            }, 
            {
                select: function (e, i, j) {
                    $("#<%= gvQuestion.ClientID%> :input[id*='txtManufacturersCode']")[0].value = i.item.order.Group;
                }
            });
        }
    </script>
    <style type="text/css">
        div.demo
        {
            border: 1px solid #CCC;
            background: red;
            position: fixed;
            height: 100%;
            z-index: 0;
            top: 4px;
            left: 4px;
            right: 4px;
            margin-bottom: 5px;
            position: relative;
            overflow: auto;
            width: 99.1%;
            line-height: normal;
            white-space: normal;
        }
        
        .cblQuestionType input
        {
            margin-left: 10px;
        }
        
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
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    平台
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    店铺名称
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    接待日期
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                    &nbsp;&nbsp;至&nbsp;&nbsp;
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    是否下单
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <asp:DropDownList ID="ddlIsOrder" Width="100%" runat="server">
                        <asp:ListItem Value="-1">所有</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    顾客id
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtSrvAfterCustomerID" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    接待客服
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="creat" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    跟进次数
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="count" runat="server" Width="80%">
                        <asp:ListItem Value="-1">所有</asp:ListItem>
                        <asp:ListItem Value="0">0次</asp:ListItem>
                        <asp:ListItem Value="1">1次</asp:ListItem>
                        <asp:ListItem Value="2">2次</asp:ListItem>
                        <asp:ListItem Value="3">大于3次</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 55px">
                    跟进等级
                </td>
                <td style="width: 80px">
                    <asp:DropDownList ID="FollowGrade2" runat="server" Width="80%">
                        <asp:ListItem Value="-1">所有</asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <div id="DIVSearch" runat="server" style="float: left;">
                        <asp:Button ID="hidBtnSearch" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                            OnClick="hidBtnSearch_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:XMConsultation.Search %>"
                            OnClick="btnSearch_Click" />
                    </div>
                </td>
                <td style="width: 20px">
                    <asp:Button ID="Button1" runat="server" Text="导出" Visible="<% $CRMIsActionAllowed:XMConsultation.Daochu %>"
                        OnClick="btnDaochu_Click" />
                </td>
                <td style="width: 80px">
                </td>
                <td style="width: 120px" nowrap="nowrap">
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 120px" nowrap="nowrap">
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
    <asp:GridView ID="gvQuestion" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="gvQuestion_RowDataBound" OnRowCancelingEdit="gvQuestion_RowCancelingEdit"
        OnRowDeleting="gvQuestion_RowDeleting" OnRowEditing="gvQuestion_RowEditing" OnRowUpdating="gvQuestion_RowUpdating"
        Width="100%">
        <Columns>
            <asp:TemplateField>
                <HeaderStyle Wrap="False" Width="40px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="false" />
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdQuestionId" Value='<%# Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台" SortExpression="PlatformTypeId">
                <HeaderStyle Width="68px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="68px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 68px; word-wrap: break-word;">
                        <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).PlatformType%>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblPlatform" Visible="false" runat="server" Text='<%# Eval("PlatformTypeId")%>'></asp:Label>
                    <asp:DropDownList ID="Platform" runat="server" Width="95%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称" SortExpression="NickId">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).NickName%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlNick" runat="server" Width="95%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="顾客id" SortExpression="CustomerID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("CustomerID")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lbltxtNickName" Visible="false" runat="server" Text='<%# Eval("CustomerID")%>'></asp:Label>
                    <asp:TextBox ID="txtNickName" runat="server" Width="85%" Text='<%# Eval("CustomerID")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="接待客服" SortExpression="">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).CreateName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).CreateName.FullName : ""%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="接待日期" SortExpression="ReceptionDate">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("ReceptionDate")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lbltxtPayDateStart" runat="server" Text='<%# Eval("ReceptionDate")== null ? DateTime.Now.ToString("yyyy-MM-dd"):Eval("ReceptionDate") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否下单" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsOrder" runat="server" Width="20%" Checked='<%# Eval("IsOrder")==null?false: Eval("IsOrder")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkIsOrder" TextAlign="Right" AutoPostBack="True" runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="订单单号" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("OrderCode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtOrderCode" runat="server" Width="85%" Text='<%# Eval("OrderCode")%>'> </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="未成交类型" SortExpression="NoTurnoverType">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# ((string)Eval("NoTurnoverType")) == "-1" ? "" : Eval("NoTurnoverType")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlNoTurnoverType" runat="server" Width="80%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 110px; word-wrap: break-word;">
                        <%# Eval("ManufacturersCode")%>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtManufacturersCode" onkeyup="autoCompleteBind()" runat="server"
                        Width="85%" Text='<%# Eval("ManufacturersCode")%>'> </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="当日未成交原因" SortExpression="DateReason">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 110px; word-wrap: break-word;">
                        <%# Eval("DateReason")%>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <input id="hftxtWantID3" type="hidden" runat="server" value='<%# Eval("DateReason")%>' />
                    <asp:TextBox ID="txtWantID3" runat="server" Width="90%" Text='<%# Eval("DateReason")%>'
                        TextMode="MultiLine"> </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="跟进等级" HeaderStyle-HorizontalAlign="Center" SortExpression="FollowGrade">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# ((string)Eval("FollowGrade")) == "-1" ? "" : Eval("FollowGrade")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="FollowGrade" runat="server" Width="80%">
                        <asp:ListItem Value="-1" Text=""></asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最近跟进日期" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 65px; word-wrap: break-word;">
                        <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).ContactTime%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最近跟进内容" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 110px; word-wrap: break-word;">
                        <label title='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).ContactContent %>'>
                            <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).ContactContent.Length > 30 ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).ContactContent.Substring(0, 30) + "..." : (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).ContactContent%>
                        </label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="跟进总次数" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).XMConsultationDetails%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="不跟进原因" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMConsultation).NoCauseType%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="NoCause" runat="server" Width="80%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="组长点评" SortExpression="">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <div style="width: 150px; word-wrap: break-word;">
                        <%# Eval("LeaderComments")%>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <input id="LeaderComments2" type="hidden" runat="server" value='<%# Eval("LeaderComments")%>' />
                    <asp:Label Visible="false" runat="server" ID="LeaderComments3"><%# Eval("LeaderComments")%></asp:Label>
                    <asp:TextBox ReadOnly="true" ID="LeaderComments" Visible="false" runat="server" Width="90%"
                        Text='<%# Eval("LeaderComments")%>' TextMode="MultiLine"> </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnList" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ValidationGroup="ClientValidationGroup" ToolTip="编辑" CommandName="Edit" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.ListEdit %>" />
                    <asp:ImageButton ID="ImgBtnCR" runat="server" ImageUrl="~/App_Themes/Default/Image/u228_original.gif"
                        ToolTip="沟通记录" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.CommunicationRecord %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                        Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.Delete %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ValidationGroup="QuestionValidationGroup" ToolTip="保存" CommandName="Update" CausesValidation="True"
                        Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMConsultation.GridView.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 120px;">
                <div id="DIVDelete" runat="server">
                    <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" Visible="<% $CRMIsActionAllowed:XMConsultation.AllDelete %>"
                        OnClientClick="return CheckSelect(this,99);" OnClick="btnDelete_Click" />
                </div>
            </td>
            <td style="height: 8px; width: 20px;">
            </td>
            <td style="width: 120px;">
            </td>
        </tr>
        <tr>
            <td style="height: 8px;">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
    </table>
</asp:Content>
