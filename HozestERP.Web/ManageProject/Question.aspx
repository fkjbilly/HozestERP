<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="Question.aspx.cs" Inherits="HozestERP.Web.ManageProject.Question" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/ImageButtonSelectSingleCustomerControl.ascx" TagName="ImageButtonSelectSingleCustomerControl"
    TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
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
    <script type="text/javascript">

        function doLink(nick) {
            if (nick != "") {
                window.open("../TopTaobao/InitData.aspx?StoreName=" + encodeURIComponent(nick), "Detail");
            }
        }

    </script>
    <script type="text/javascript">

        function autoCompleteBind() {
            $(".OrderCode").autocomplete({
                source: function (request, response) {
                    jQuery.ajax({
                        url: "XMScalpingApplicationReturnedHandler.ashx?action=QuestionOrderCode",
                        data: "q=" + encodeURI(request.term),
                        type: "GET",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.OrderCode + ",平台：" + item.OfflinePlatformName + " ,店铺：" + item.OfflineNickName + " ,买家：" + item.WantID,
                                    value: item.OrderCode,
                                    orderInfo: item
                                }
                            }));
                        }
                    });
                }
            }
        , {
            select: function (e, i, j) {
                $("#<%= gvQuestion.ClientID%> :hidden[id*='hfPlatformId']").val(i.item.orderInfo.PlatformTypeId);
                $("#<%= gvQuestion.ClientID%> :hidden[id*='hftxtNickId']").val(i.item.orderInfo.NickID);
                $("#<%= gvQuestion.ClientID%> :hidden[id*='hftxtWantID']").val(i.item.orderInfo.WantID);
                $("#<%= gvQuestion.ClientID%> :text[id*='txtPlatformName']").val(i.item.orderInfo.OfflinePlatformName);
                $("#<%= gvQuestion.ClientID%> :text[id*='txtNickName']").val(i.item.orderInfo.OfflineNickName);
                $("#<%= gvQuestion.ClientID%> :text[id*='txtWantID']").val(i.item.orderInfo.WantID);
            }
        }
        );
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 80px">
                    订单号
                </td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtOrderNO" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    项目名称
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                        AutoPostBack="true">
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
                    问题创建日期
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
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
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
                    状态
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="100%">
                        <asp:ListItem Value="-1" Text="--- 所有 ---"></asp:ListItem>
                        <asp:ListItem Value="0" Text="提交中" style="background-color: red"></asp:ListItem>
                        <asp:ListItem Value="1" Text="处理中" style="background-color: yellow"></asp:ListItem>
                        <asp:ListItem Value="2" Text="完成" style="background-color: green"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <%-- <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    姓名
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtFullName" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    退款单号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtRefundLogisticsNo" runat="server" Width="100%"></asp:TextBox>
                </td> --%>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    售后
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtSrvAfterCustomerID" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    最后提交时间
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="lastStartDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                    &nbsp;&nbsp;至&nbsp;&nbsp;
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="lastEndDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    买家
                </td>
                <td style="width: 160px">
                    <asp:TextBox ID="txtBuyer" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    是否超时
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlTheResults" runat="server" Width="100%">
                        <asp:ListItem Value="-1" Text="--- 所有 ---"></asp:ListItem>
                        <asp:ListItem Value="1" Text="否" style="background-color: green"></asp:ListItem>
                        <asp:ListItem Value="2" Text="是" style="background-color: red"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                    问题等级
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlQuestionLevel" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
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
            <tr>
                <td style="width: 80px">
                    问题类型
                </td>
                <td colspan="6">
                    <asp:DropDownList ID="ddlQCategory" runat="server" Width="30%">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td style="width: 20px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <%-- <asp:Button ID="Button1" SkinID="button6" runat="server" Text="生成退换货申请" Visible="<% $CRMIsActionAllowed:Question.Search %>"
                        OnClick="btnManagerAdd2_Click" /> --%>
                </td>
                <td colspan="2">
                    <div id="DIVSearch" runat="server" style="float: left;">
                        <asp:Button ID="hidBtnSearch" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                            OnClick="hidBtnSearch_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:Question.Search %>"
                            OnClick="btnSearch_Click" />
                    </div>
                    <div id="DIVExport" runat="server">
                        <asp:Button ID="btnExport" runat="server" SkinID="button4" Text="导出数据" OnClick="btnExport_Click"
                            Visible="<% $CRMIsActionAllowed:ManageProject.Question.Export %>" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" language="javascript">
        var indexi = -1;
        function ShowHidde(sid, evt) {
            var b = "";
            var openType = "";
            var customerID = sid;

            //还原其他所有行
            $("tr[id^=div]").each(function () {
                var a = $(this).attr("id").replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = a; //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            });
            //如果点击同一个
            if (sid == b) {
                openType = "0";

                var a = b.replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = $(this).attr("id"); //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
                indexi = -1;
            } else {
                openType = "1";

                //             evt = evt || window.event;
                //             var target = evt.target || evt.srcElement;
                var objDiv = document.getElementById("div" + sid);
                if (window.ActiveXObject) {
                    objDiv.style.display = objDiv.style.display == "none" ? "block" : "none";
                }
                else {
                    objDiv.style.display = objDiv.style.display == "none" ? "table-row" : "none";
                }
                //target.title = objDiv.style.display == "none" ? "Show" : "Hide";
                var imgid = 'img' + sid;
                document.getElementById(imgid).src = objDiv.style.display == "none" ? "../images/folder.gif" : "../images/folderopen.gif";
                indexi = sid;
            }
            document.cookie = "openQuestionType=" + openType;
            document.cookie = "QuestioncustomerID=" + customerID;

        }
        //indexId:div索引, ResultMsgClientID：赋值的控件, PaymentValue：要赋的值
        function LoadDetailsBoundIndexId(indexId, ResultMsgClientID, PaymentValue) {
            //结果处理说明赋值
            var s = document.getElementById(ResultMsgClientID).value = PaymentValue;
            var obja = document.getElementById("div" + indexId);
            if (window.ActiveXObject) {
                obja.style.display = "block";
            }
            else {
                obja.style.display = "table-row";
            }
            var imga = 'img' + indexId;
            document.getElementById(imga).src = "../images/folderopen.gif";
        }


        function LoadDetailsBound() {
            var obja = document.getElementById("div" + indexi);
            if (window.ActiveXObject) {
                obja.style.display = "block";
            }
            else {
                obja.style.display = "table-row";
            }
            var imga = 'img' + indexi;
            document.getElementById(imga).src = "../images/folderopen.gif";
        }


        function CustomerWangNoOpen() {
            var strCookie = document.cookie;
            //将多cookie切割为多个名/值对
            var arrCookie = strCookie.split("; ");
            var openType;
            var customerID;
            //遍历cookie数组，处理每个cookie对
            for (var i = 0; i < arrCookie.length; i++) {
                var arr = arrCookie[i].split("=");
                //到名称为userId的cookie，并返回它的值
                if ("openQuestionType" == arr[0]) {
                    openType = arr[1];
                }
                if ("QuestioncustomerID" == arr[0]) {
                    customerID = arr[1];
                }
            }
            if (openType == "1") {
                ShowHidde(customerID, null);
            }
        }

    </script>
    <asp:GridView ID="gvQuestion" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowCommand="gvQuestion_RowCommand" OnRowDataBound="gvQuestion_RowDataBound"
        OnRowCancelingEdit="gvQuestion_RowCancelingEdit" OnRowDeleting="gvQuestion_RowDeleting"
        OnRowEditing="gvQuestion_RowEditing" OnRowUpdating="gvQuestion_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="javascript:void(0);">
                        <img id='img<%# Eval("ID")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("ID")%>',event)" /></a>
                    <%# Container.DataItemIndex + 1 %>
                    <%-- <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>--%>
                    <asp:HiddenField ID="hdQuestionId" Value='<%# Eval("ID")%>' runat="server" />
                    <%--<asp:HiddenField ID="hdQIdRowId" Value='<%# Container.DataItemIndex%>' runat="server" />--%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="40px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="false" />
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
            <%--<asp:TemplateField HeaderText="是否解决">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                <ItemTemplate>
                     <CRM:ImageCheckBox ID="imgChkIsSolve" runat="server" Checked='<%# Eval("IsSolve")==null?false: Eval("IsSolve")%>' ToolTip="已解决" />
                       
                    <asp:ImageButton ID="imgBtnIsSolveNO" runat="server" ImageUrl="~/images/unchecked.gif"   
                        ToolTip="否"  CommandName="XMQuestionIsSolveNO" CausesValidation="False"   CommandArgument='<%# Eval("ID") %>'
                         OnClientClick="return confirm('您确定要解决.');"    />

                     <asp:ImageButton ID="imgBtnIsSolveOK" runat="server" ImageUrl="~/images/unchecked.gif"   
                        ToolTip="是"  CommandName="XMQuestionIsSolveOK" CausesValidation="False"   CommandArgument='<%# Eval("ID") %>'
                         OnClientClick="return confirm('您确定要解决.');"   />
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="订单号" SortExpression="OrderNO">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnOrderNo" runat="server" CommandArgument='<%# Eval("ID") %>'
                        ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblOrderNO" runat="server" Text='<%# Eval("OrderNO")%>' Visible="false"></asp:Label>
                    <input runat="server" id="txtOrderCode" class="TextBox OrderCode" value='<%# Eval("OrderNO")%>'
                        style="text-align: left; width: 90%" type="text" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOrderCode"
                        Font-Name="verdana" Font-Size="9pt" runat="server" Display="None" ErrorMessage="订单号不能为空！"
                        ValidationGroup="XMCashBackApplicationValidationGroup">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                        PopupPosition="TopRight" />
                    <%--<asp:Label ID="lblOrderNO" runat="server" Text='<%# Eval("OrderNO")%>' Visible="false"></asp:Label>
                 <HozestERP:SimpleTextBox ID="txtEditOrderNO" runat="server" Width="90%" Text='<%# Eval("OrderNO")%>'
                  ErrorMessage="订单号不能为空."   ValidationGroup="QuestionValidationGroup"    />--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平台">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestion).PlatformType %>--%>
                    <%# Eval("PlatformType")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input id="hfPlatformId" type="hidden" runat="server" value='<%# Eval("PlatformID")%>' />
                    <asp:TextBox ID="txtPlatformName" runat="server" ReadOnly="true" Width="80%" Text='<%# Eval("PlatformType") %>'></asp:TextBox>
                    <%--<asp:TextBox ID="txtPlatformName" runat="server" ReadOnly="true" Width="80%" Text='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestion).PlatformType %>'></asp:TextBox>--%>
                    <%-- <HozestERP:CodeControl ID="ccPlatformID" runat="server" CodeType="182" Width="95%" />--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名称">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestion).NickName%>--%>
                    <%# Eval("NickName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input id="hftxtNickId" type="hidden" runat="server" value='<%# Eval("NickID")%>' />
                    <asp:TextBox ID="txtNickName" runat="server" ReadOnly="true" Width="90%" Text='<%# Eval("NickName")%>'></asp:TextBox>
                    <%--<asp:TextBox ID="txtNickName" runat="server" ReadOnly="true" Width="90%" Text='<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestion).NickName%>'></asp:TextBox>--%>
                    <%-- <asp:DropDownList ID="ddlEditNick" Width="95%" runat="server">
                </asp:DropDownList>--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="买家" SortExpression="Buyer">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Buyer")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <input id="hftxtWantID" type="hidden" runat="server" value='<%# Eval("Buyer")%>' />
                    <asp:TextBox ID="txtWantID" runat="server" ReadOnly="true" Width="90%" Text='<%# Eval("Buyer")%>'> </asp:TextBox>
                    <%--<HozestERP:SimpleTextBox ID="txtBuyer" runat="server" Width="90%" Text='<%# Eval("Buyer")%>' ErrorMessage="买家不能为空." 
                    ValidationGroup="QuestionValidationGroup"     />--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="问题等级" SortExpression="">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("QuestionLevelName.CodeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="问题" SortExpression="">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblQuestionTypeID" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最后提交时间" SortExpression="">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblLastSubmitTime" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否退换" SortExpression="">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="imgChkIsReturns" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="处理人" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblSrvAfterCustomerID" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最近联系时间" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblContactTime" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="联系内容" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblContactContent" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="处理结果" HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblResultsId" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态" HeaderStyle-HorizontalAlign="Center" SortExpression="Status">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblQuestionStatus" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnList" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ValidationGroup="ClientValidationGroup" ToolTip="编辑" CommandName="Edit" CausesValidation="False"
                        Visible="<% $CRMIsActionAllowed:Question.GridView.ListEdit %>" />
                    <asp:ImageButton ID="ImgBtnCR" runat="server" ImageUrl="~/App_Themes/Default/Image/u228_original.gif"
                        ToolTip="沟通记录" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:Question.GridView.CommunicationRecord %>" />
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="生成退换货申请" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageApplication.Add %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:Question.GridView.Delete %>" />
                    <!--下拉tr-->
                    <tr id="div<%# Eval("ID") %>" style="background-color: White; display: none; border: 0px;"
                        class="gridlist">
                        <td colspan="100%" style="border: 0px">
                            <div style="background-color: White; width: 100%; border: 0px;">
                                <div class="demo">
                                    <!---绑定内层Gridview--->
                                    <asp:GridView ID="gvQuestionDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                        SkinID="GridViewThemen" OnRowDataBound="gvQuestionDetail_RowDataBound" OnRowUpdating="gvQuestionDetail_RowUpdating"
                                        OnRowCommand="gvQuestionDetail_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                    <asp:HiddenField ID="hdQId" runat="server" />
                                                    <asp:HiddenField ID="hdId" Value='<%# Eval("ID")%>' runat="server" />
                                                    <asp:HiddenField ID="hdDealDataItemIndex" Value='<%# Container.DataItemIndex %>'
                                                        runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:HiddenField ID="hdQId" runat="server" />
                                                    <asp:HiddenField ID="hdDealDataItemIndex" Value='<%# Container.DataItemIndex %>'
                                                        runat="server" />
                                                </EditItemTemplate>
                                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center" CssClass="headbackground">
                                                </HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="问题描述" SortExpression="">
                                                <HeaderStyle Width="190px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" MaxLength="150" Text='<%# Eval("Description") %>'
                                                        Width="240px" Height="60px" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDescriptionEdit" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtDescriptionEdit" TextMode="MultiLine" Text='<%# Eval("Description") %>'
                                                        Width="240px" Height="60px" runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="问题类型" SortExpression="">
                                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuestionType" runat="server" Text='<%# Eval("QuestionCategoryType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlQuestionCategory" runat="server" Width="80%">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="是否退货" SortExpression="">
                                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>
                                                    <CRM:ImageCheckBox ID="imgChkIsSolve" runat="server" Checked='<%# Eval("IsReturns ")==null?false: Eval("IsReturns ")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlIsReturns" runat="server" Width="85%">
                                                        <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="处理结果说明" SortExpression="">
                                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtResultMsgEdit" TextMode="MultiLine" MaxLength="150" Text='<%# Eval("ResultMsg") %>'
                                                        Width="240px" Height="60px" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanelResultMsg" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtResultMsgEdit" TextMode="MultiLine" Text='<%# Eval("ResultMsg") %>'
                                                                Width="240px" Height="60px" runat="server"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="处理结果" SortExpression="">
                                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>
                                                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).ResultsType != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).ResultsType.CodeName : ""%>--%>
                                                    <%# Eval("ResultsType")!= null ?Eval("ResultsType.CodeName"):""%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <%--<HozestERP:CodeControl ID="ccResultsId" runat="server" CodeType="201" Width="85%" />  OnSelectedIndexChanged="ccResultsId_SelectedIndexChanged"  AutoPostBack="true" --%>
                                                    <asp:DropDownList ID="ccResultsId" Width="90%" runat="server">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="问题等级" SortExpression="">
                                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuestionLevel" runat="server" Text='<%# Eval("QuestionLevelName.CodeName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <HozestERP:CodeControl ID="ccQuestionLevel" runat="server" CodeType="213" Width="85%" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="状态" SortExpression="Status">
                                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <div style="text-align: center; width: 100%;">
                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div style="text-align: center; width: 100%;">
                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                    </div>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="80px">
                                                        <%--<asp:ListItem Value="1" Text="处理中" style="background-color: yellow"></asp:ListItem>--%>
                                                        <asp:ListItem Value="2" Text="完成" style="background-color: green"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="客服" SortExpression="">
                                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvBeforeCustomer != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvBeforeCustomer.FullName : ""%>--%>
                                                    <%--<asp:Label ID="lblSrvBeforeCustomerID" runat="server"></asp:Label>--%>
                                                    <%# Eval("SrvBeforeCustomer") != null ? Eval("SrvBeforeCustomer.FullName") : ""%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div style="text-align: center; width: 100%;">
                                                        <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvBeforeCustomer != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvBeforeCustomer.FullName : ""%>--%>
                                                        <%-- <asp:Label ID="lblSrvBeforeCustomerID" runat="server"></asp:Label>--%>
                                                        <%# Eval("SrvBeforeCustomer") != null ? Eval("SrvBeforeCustomer.FullName") : ""%>
                                                    </div>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="售后" SortExpression="">
                                                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvAfterCustomer != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvAfterCustomer.FullName : ""%>--%>
                                                    <%-- <asp:Label ID="lblSrvAfterCustomerID" runat="server"></asp:Label>--%>
                                                    <%# Eval("SrvAfterCustomer") != null ? Eval("SrvAfterCustomer.FullName") : ""%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div style="text-align: center; width: 100%;">
                                                        <%--<%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvAfterCustomer != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMQuestionDetail).SrvAfterCustomer.FullName : ""%>--%>
                                                        <%--<asp:Label ID="lblSrvAfterCustomerID" runat="server"></asp:Label>--%>
                                                        <%# Eval("SrvAfterCustomer") != null ? Eval("SrvAfterCustomer.FullName") : ""%>
                                                    </div>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="提交时间" SortExpression="">
                                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <%# Eval("CreateTime") == null ? "" : DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                                    <%--<asp:Label ID="lblCreateTime" runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="接单时间" SortExpression="">
                                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <%# Eval("OrdersTime") == null ? "" : DateTime.Parse(Eval("OrdersTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="完成时间" SortExpression="">
                                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                <ItemTemplate>
                                                    <%# Eval("LastModifyTime") == null ? "" : DateTime.Parse(Eval("LastModifyTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                                    <%--<asp:Label ID="lblLastModifyTime" runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="操作">
                                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" CssClass="headbackground" />
                                                <ItemStyle Wrap="false" />
                                                <ItemTemplate>
                                                    <%--总监编辑按钮--%>
                                                    <asp:ImageButton ID="imgBtnDirector" runat="server" ImageUrl="~/App_Themes/Blue/Image/Minutes.png"
                                                        ToolTip="编辑" CommandName="ChildDirectorEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.DirectorEdit %>"
                                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                                    <%--编辑按钮--%>
                                                    <asp:ImageButton ID="imgBtnDealEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                                        ToolTip="编辑" CommandName="ChildEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Edit %>"
                                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                                    <asp:ImageButton ID="imgBtnDealUpload" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/up.gif"
                                                        ToolTip="上传附件" CommandName="Upload" CausesValidation="False" Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Upload %>" />
                                                    <%--  <asp:ImageButton ID="imgBtnDealPremiums" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/up.gif"
                                                        ToolTip="赠品" CommandName="ChildPremiums" CausesValidation="False"   
                                                         Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Premiums %>"  CommandArgument='<%# Container.DataItemIndex %>'  />

                                                          <asp:ImageButton ID="imgBtnDealCashBack" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/gift1.png"
                                                        ToolTip="赠品/返现" CommandName="ChildCashBackAndChildPremiums" CausesValidation="False"  
                                                         Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.CashBack %>"  CommandArgument='<%# Container.DataItemIndex %>'  />--%>
                                                    <asp:ImageButton ID="imgBtnDealPayment" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/money.png"
                                                        ToolTip="赔付" CommandName="ChildPayment" CausesValidation="False" Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Payment %>"
                                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                                    <CRM:ImageButtonSelectSingleCustomerControl ID="btnTransfer" runat="server" BtnImageUrl="~/App_Themes/Blue/Image/ButtonImages/zhuan.gif"
                                                        BtnToolTip="移交" SessionPageID="Transfer" OnSelectedCustomer="btnTransfer_SelectedCustomer"
                                                        Visible="<% $CRMIsActionAllowed:ManageProject.Question.Transfer %>" CommandName="ChildTransfer"
                                                        CommandArgument='<%# Eval("ID")%>' />
                                                    <asp:ImageButton ID="imgBtnDealDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif"
                                                        ToolTip="删除" CommandName="ChildDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                                        Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Delete %>" CommandArgument='<%# Container.DataItemIndex %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="imgBtnDealUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                                                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Save %>"
                                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                                    <asp:ImageButton ID="imgBtnDealCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                                        ToolTip="取消" CommandName="ChildCancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:QuestionEdit.GridView.Cancel %>"
                                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ValidationGroup="QuestionValidationGroup" ToolTip="保存" CommandName="Update" CausesValidation="True"
                        Visible="<% $CRMIsActionAllowed:Question.GridView.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:Question.GridView.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <%--<td  style="height: 8px; width:20px;">
                <asp:Button ID="btnAdd" runat="server" Text="新增"  Visible="<% $CRMIsActionAllowed:ManageProject.Question.Add %>" />
            </td>--%>
            <td style="width: 120px;">
                <div id="DIVDelete" runat="server">
                    <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" Visible="<% $CRMIsActionAllowed:ManageProject.Question.AllDelete %>"
                        OnClientClick="return CheckSelect(this,99);" OnClick="btnDelete_Click" />
                </div>
            </td>
            <td style="height: 8px; width: 20px;">
            </td>
            <td style="width: 120px;">
                <%--  <asp:Button ID="hidBtnDealPaymentDealWith" runat="server" Style="width: 0px; display: none;" ToolTip="赔付处理结果"   OnClick="hidBtnDealPaymentDealWith_Click" /> 
                --%>
            </td>
        </tr>
        <tr>
            <td style="height: 8px;">
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div id="DIVCompleteRateResult" runat="server">
                    <table width="100%" align="center" class="Borderline" style="background: none repeat 0 0 #F2F2F2;">
                        <tr>
                            <td style="width: 49%;">
                                <table width="100%" align="center" class="Borderline" style="background: none repeat 0 0 #F2F2F2;">
                                    <tbody>
                                        <tr>
                                            <td style="padding: 3; color: Green;">
                                                <font color="#FF0000" style="font-weight: bold;">及时接单率计算方式说明：</font>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;及时接单率结果=接单的问题总数（两个时间范围之间）/提交问题的总数*100%&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 8px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 120px; color: Green; font-weight: bold;" nowrap="nowrap">
                                                <asp:UpdatePanel ID="pnlCompleteRateResult" runat="server">
                                                    <ContentTemplate>
                                                        及时接单率：<span><asp:Label BackColor="Red" ForeColor="White" ID="lblCompleteRateResult"
                                                            runat="server" Text="无"></asp:Label>
                                                        </span>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td style="width: 40px;">
                            </td>
                            <td style="width: 49%;">
                                <table width="100%" align="center" class="Borderline" style="background: none repeat 0 0 #F2F2F2;">
                                    <tbody>
                                        <tr>
                                            <td style="padding: 3; color: Green;">
                                                <font color="#FF0000" style="font-weight: bold;">退货挽回率计算方式说明：</font>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;退货挽回率结果=是退货总条数-实际退货总条数（两个时间范围之间）/是退货总条数*100%&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 8px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 120px; color: Green; font-weight: bold;" nowrap="nowrap">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        退货挽回率：<span><asp:Label BackColor="Red" ForeColor="White" ID="lblReturnsRedeemRate"
                                                            runat="server" Text="无"></asp:Label>
                                                        </span>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            autoCompleteBind();
        });
    </script>
</asp:Content>
