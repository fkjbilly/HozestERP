<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMCustomerServiceInfoList.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMCustomerServiceInfoList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl"
    TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/UpdaeProcess.ascx" TagName="UpdateProcess" TagPrefix="SHIBR" %>
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
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript">
        function ShowHidde(sid, evt) {
            var b = "";
            var openType = "";
            var customerID = sid;
            //还原其他所有行
            $("tr[id^=div]").each(function () {
                if (evt == null) {
                    return;
                }
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
            } else {
                openType = "1";
                //evt = evt || window.event;
                //var target = evt.target || evt.srcElement;
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
            }
            //var openType = objDiv.style.display;
            //var customerID = sid;
            document.cookie = "openType=" + openType;
            document.cookie = "customerID=" + customerID;
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
                //找到名称为userId的cookie，并返回它的值
                if ("openType" == arr[0]) {
                    openType = arr[1];
                }
                if ("customerID" == arr[0]) {
                    customerID = arr[1];
                }
            }
            if (openType == "1") {
                ShowHidde(customerID, null);
            }
        }

        function ShowSelectCustomerDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:800px;dialogHeight:450px;center:yes;");
            return true;
        }
        var GridCommand = function (commandName, record) {
            if (commandName == "Edit") {
            }
            else {
                Ext.MessageBox.confirm('提示信息', '确定删除您选中的记录吗？', function (btn) {
                    if (btn == "yes") {
                        CompanyX.DeleteCustomer(record.CustomerID);
                    }
                });
            }
        }
        var rowclickFn = function (grid, rowindex, e) {
            GridCommand("Delete", grid.getSelectionModel().getSelected().data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
        <tr>
            <td style="width: 70px">
                组别:
            </td>
            <td style="width: 120px;">
                <%--<asp:TextBox runat="server" ID="ddlGroup" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlGroup" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 70px" align="right">
                姓名:
            </td>
            <td style="width: 120px;">
                <asp:TextBox runat="server" ID="ddlName" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 70px" align="right">
                级别:
            </td>
            <td style="width: 120px;">
                <%--<asp:TextBox runat="server" ID="ddlRank" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlRank" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceInfoList.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
        OnRowDataBound="grdvClients_RowDataBound" OnRowEditing="grdvClients_RowEditing"
        OnRowUpdating="grdvClients_RowUpdating" OnRowCancelingEdit="grdvClients_RowCancelingEdit">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="javascript:void(0);">
                        <img id='img<%# Eval("ID")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("ID")%>',event)" /></a>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdDId" Value='<%# Eval("ID")%>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="组别" SortExpression="Group">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblGroup" runat="server" Text='<%# Eval("Group")==null?"":Eval("Group").ToString().Length>15?Eval("Group").ToString().Substring(0,15)+"..":Eval("Group").ToString()%>'
                        ToolTip='<%# Eval("Group") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="Name">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")==null?"":Eval("Name").ToString().Length>15?Eval("Name").ToString().Substring(0,15)+"..":Eval("Name").ToString()%>'
                        ToolTip='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="级别" SortExpression="RankName">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblRank" runat="server" Text='<%# Eval("RankName")==null?"":Eval("RankName").ToString().Length>15?Eval("RankName").ToString().Substring(0,15)+"..":Eval("RankName").ToString()%>'
                        ToolTip='<%# Eval("RankName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlRankList" runat="server" Width="97%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="赔付额" SortExpression="PaymentAmount">
                <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblPaymentAmount" runat="server" Text='<%# Eval("PaymentAmount")==null?"0":Eval("PaymentAmount").ToString().Length>15?Eval("PaymentAmount").ToString().Substring(0,15)+"..":Eval("PaymentAmount").ToString()%>'
                        ToolTip='<%# Eval("PaymentAmount") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtPaymentAmount" Width="95%"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnDistribution" runat="server" ImageUrl="~/App_Themes/Default/Image/add.gif"
                        ToolTip="分配" CommandName="Distribution" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceInfoList.Distribution %>" />
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceInfoList.Edit %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("ID")%>' ToolTip="删除" CommandName="Delete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此客服的等级及旺旺号信息？');" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceInfoList.Delete %>" />
                    <!--下拉tr-->
                    <tr id='div<%#Eval("ID")%>' style="background-color: White; display: none; border: 0px;"
                        class="gridlist">
                        <td colspan="100%" style="width: 100%; height: 100%;">
                            <div style="background-color: White;">
                                <div style="position: relative; left: 0px; overflow: auto; width: 100%;">
                                    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
                                        <tbody>
                                            <tr>
                                                <td colspan="100%" valign="top">
                                                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                                                        <tr>
                                                            <td style="text-align: left; width: 50px; font-weight: bold">
                                                                旺旺号：
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <%# Eval("WangNo")%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <div style="background-color: White; width: 100%; border: 0px;">
                                                    <td colspan="100%">
                                                    </td>
                                                </div>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceInfoList.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMCustomerServiceInfoList.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
