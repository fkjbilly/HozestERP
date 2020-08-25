<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master"
    CodeBehind="XMDelivery.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMDelivery" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .headbackground {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }

        .gridlist {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }

        .x-selectable, .x-selectable * {
         -moz-user-select: text !important;
        -webkit-user-select: text !important; 
        font-size:12px;
        font-family:'Microsoft YaHei';

        }            
     
             
    </style>
    <script type="text/javascript">

        function SaveDeliveryIDs() {
            var IdStr = "";
            var Ids = "";
            $("input[type=checkbox]").each(function (i, item) {
                if (item.checked == true && item.id.indexOf("_chkSelected") != -1) {
                    IdStr = item.id.replace("_chkSelected", "_hdDId");
                    var one = document.getElementById(IdStr);
                    if (one != null) {
                        var value = one.value.replace("on", "");
                        if (Ids == "") {
                            Ids = value;
                        }
                        else {
                            Ids += "," + value;
                        }
                    }
                }
            });
            jQuery(function ($) {
                $.ajax({
                    url: "../ManageCustomer/xMChoseExpress.ashx?Ids=" + Ids,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: "action=Delivery",
                    success: function (json) {
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function GetDeliveryIDs(obj)
        {
            var Ids = "";
            for (var i = 0; i < obj.length; i++)
            {
                if (obj[i].IsPrint != true && (obj[i].projectId == 19 || obj[i].projectId == 23 || obj[i].projectId==24))
                {
                    alert('发货单号'+obj[i].DeliveryNumber+'未被打印');
                    return false;
                }
                Ids = Ids + obj[i].Id+",";
            }
            Ids = Ids.substring(0, Ids.length - 1);
            //alert(Ids);
            //alert(1);
            jQuery(function ($) {
                $.ajax({
                    url: "../ManageCustomer/xMChoseExpress.ashx?Ids=" + Ids,
                    type: "GET",
                    dataType: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: "action=Delivery",
                    success: function (json) {
                    },
                    error: function (x, e) {
                    },
                    complete: function (x) {
                    }
                });
            });
        }

        function prepareCommand(command, record)
        {
            if (!record.data['IsShelve'] && command.command == 'Remark')
            {
                command.hidden = true;
            }
        }

        var testRenderer = function (value, metadata, record, rowIndex, colIndex, store) {
            //alert(record.data['IsLogisticsInfoLate']);
            if (record.data['IsLogisticsInfoLate'])
            {
                metadata.attr = String.format('style="background-color:{0};"', 'red');
            }
            //metadata.attr = String.format('style="background-color:{0};"', 'red');
            return value;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">订单编号
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtOrderCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">厂家编码
            </td>
            <td style="width: 200px">
                <%--<asp:TextBox ID="txtManufacturersCode" runat="server" Width="100%"></asp:TextBox>--%>
                <ext:TextField ID="txtManufacturersCode1" runat="server" EmptyText="多个编码用 , 分隔"></ext:TextField>
                <span>包含 <asp:CheckBox ID="chkCodeContain" runat="server" Checked="true" /></span>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">创单时间
            </td>
            <td style="width: 200px">
                <input id="txtCreateDateBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">到
            </td>
            <td style="width: 200px">
                <input id="txtCreateDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 100%;" />
            </td>
        </tr>
        <tr>
            <td style="height: 5px;"></td>
        </tr>
        <tr>
            <td style="width: 100px">项目名称
            </td>
            <td style="width: 200px">
                <%--<asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>--%>
                        <ext:Store runat="server" ID="CB1Store" AutoDataBind="false">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="ProjectName"></ext:RecordField>
                                        <ext:RecordField Name="Id"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                <ext:ComboBox runat="server" ID="ddXMProject" DisplayField="ProjectName" ValueField="Id" StoreID="CB1Store" Width="200" Editable="false">
                    <Listeners>
                        <Select Handler="#{ddlNick}.clearValue(); #{CB2Store}.reload();"  />
                        
                    </Listeners>
                </ext:ComboBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">店铺名称
            </td>
            <td style="width: 200px">
                <%--<asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                </asp:DropDownList>--%>
                <ext:Store runat="server" ID="CB2Store" AutoDataBind="false" OnRefreshData="ddXMProject_SelectedIndexChanged">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                            <ext:RecordField Name="nick"></ext:RecordField>
                            <ext:RecordField Name="nick_id"></ext:RecordField>
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <%--<DirectEvents>
                        <Load OnEvent="ddXMProject_SelectedIndexChanged">
                            <EventMask ShowMask="true" Msg="正在处理..." ></EventMask>
                        </Load>
                    </DirectEvents>--%>
                </ext:Store>
                <ext:ComboBox runat="server" ID="ddlNick" StoreID="CB2Store" DisplayField="nick" ValueField="nick_id" Width="200" Editable="false">

                </ext:ComboBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">打印时间
            </td>
            <td style="width: 200px">
                <input id="txtPrintBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">到
            </td>
            <td style="width: 200px">
                <input id="txtPrintEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate"
                    runat="server" style="width: 100%;" />
            </td>
        </tr>
        <tr>
            <td style="height: 5px;"></td>
        </tr>
        <tr>
            <td style="width: 100px">发货方
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlShipper" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">是否打印
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddPrintQuantity" runat="server" Width="100%">
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未打印"></asp:ListItem>
                    <asp:ListItem Value="1" Text="已打印"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">发货单类型
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddDeliveryTypeId" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">电话
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtMobileAndTel" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;"></td>
        </tr>
        <tr>
            <td style="width: 100px">发货单号
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtDeliveryNumber" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">收货人姓名
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtFullName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">是否发货
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddIsDelivery" runat="server" Width="100%">
                    <asp:ListItem Value="0" Text="否" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
            <td>打印批次
            </td>
            <td>
                <asp:TextBox ID="txtPrintBatch" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 5px;"></td>
        </tr>
        <tr>
            <td style="width: 100px">收货地址
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtDeliveryAddress" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">是否挂起
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlIsShelve" runat="server" Width="100%">
                    <asp:ListItem Value="0" Text="否" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="-1" Text="--所有--"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
            <td>无订单号
            </td>
            <td>
                <asp:CheckBox ID="chkNoOrder" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 5px;"></td>
        </tr>
        <tr>
            <td style="width: 100px">物流单号
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtLogisticsNumber" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">是否打印发货单
            </td>
            <td style="width: 200px">
                <ext:ComboBox runat="server" ID="cbIsPrint" Editable="false" Width="200">
                    <Items>
                        <ext:ListItem Text="---所有---" Value="-1"/>
                        <ext:ListItem Text="是" Value="1"/>
                        <ext:ListItem Text="否" Value="0" />
                    </Items>
                </ext:ComboBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">物流公司
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtLogisticsCompany" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20px"></td>
            <td>单礼包
            </td>
            <td>
                <asp:CheckBox ID="chkpackage" runat="server" />
            </td>
        </tr>
         <tr>
            <td style="width: 100px">核销状态
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddVerification" runat="server" Width="90%" >
                </asp:DropDownList>
            </td>
            <td style="width: 20px"></td>
           
            <td style="width: 20px"></td>
            <td style="text-align: right" colspan="9">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.Search %>" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript">

        function ShowHidde(sid, evt) {
            var b = "";
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
                var a = b.replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = $(this).attr("id"); //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            } else {
                evt = evt || window.event;
                var target = evt.target || evt.srcElement;
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
        }
    </script>
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound"
        ShowFooter="true">
        <%--<EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" nowrap="" style="width: 50px; white-space: nowrap;"
                        scope="col">&nbsp;
                    </th>
                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">发货单类型
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">发货单号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        订单编号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">发货方
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">收货人姓名
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">电话
                    </th>
                      <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        商品编号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">物流单号
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">物流公司
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">配送费用
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">是否发货
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">操作
                    </th>
                </tr>
            </table>
        </EmptyDataTemplate>--%>
        <%--<Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="javascript:void(0);" tabindex="-1">
                        <img id='img<%# Eval("Id")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("Id")%>',event)" /></a>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdDId" Value='<%# Eval("Id")%>' runat="server" />
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="50px" HorizontalAlign="Center"></HeaderStyle>
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
            <asp:TemplateField HeaderText="发货单类型" SortExpression="DeliveryNumber">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货单号" SortExpression="DeliveryNumber">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货方" SortExpression="ShipperName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ShipperName")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="订单编号"  SortExpression="OrderCode">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <asp:LinkButton ID="lbtnOrderNo" runat="server"   CommandArgument='<%# Eval("Id") %>' Text='<%# Eval("OrderCode")%>'
                        ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton>
            </ItemTemplate> 
        </asp:TemplateField>
            <asp:TemplateField HeaderText="收货人姓名" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("FullName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="电话" SortExpression="OrderCode">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="LblMobileAndTel" runat="server"></asp:Label>
                    <%# Eval("Mobile") == null ? (Eval("Tel")==null?"": Eval("Tel")) : Eval("Mobile")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流单号" SortExpression="LogisticsNumber">
                <HeaderStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
                <FooterStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblLogisticsNumber" Text='<%# Eval("LogisticsNumber")%>' runat="server"></asp:Label>
                    <asp:TextBox ID="txtLogisticsNumber" Text='<%# Eval("LogisticsNumber") %>' runat="server"
                        Visible="false" onkeypress="if(event.keyCode==13){return false;}"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgLogisticsNumberVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ID="imgBtnLogisticsEdit" TabIndex="-1" OnClick="imgBtnLogisticsNumberEdit_Click"
                        runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif" ToolTip="编辑"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.LogisticsEdit %>" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnLogisticsUpdate" TabIndex="-1" OnClick="imgBtnLogisticsNumberUpdate_Click"
                        runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.LogisticsUpdate %>" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnLogisticsCancel" TabIndex="-1" OnClick="imgBtnLogisticsNumberCancel_Click"
                        runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif" ToolTip="取消"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.LogisticsCancel %>"
                        CausesValidation="False" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流公司">
                <HeaderStyle Width="180px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%-- <asp:Label ID="lblLogisticsId" Text='<%# Eval("LogisticsId")!=null?GetCompanyCustom(Eval("LogisticsId").ToString()):""%>' runat="server"></asp:Label> --%>
                    <%--<asp:Label ID="lblLogisticsId" runat="server" Text='<%# Eval("LogisticsCompany")%>'></asp:Label>
                    <asp:DropDownList ID="ddLogisticsId" runat="server" Width="90%" Visible="false" TabIndex="-1">
                    </asp:DropDownList>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgLogisticsIdVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="配送费用" SortExpression="Price">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Price")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="打印次数" SortExpression="PrintQuantity">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblPrintQuantity" runat="server" Text='<%# Eval("PrintQuantity").ToString()=="0"?"未打印": Eval("PrintQuantity").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="打印批次" SortExpression="PrintBatch">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblPrintBatch" runat="server" Text='<%# Eval("PrintBatch") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="打印时间" SortExpression="PrintDateTime">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblPrintDateTime" runat="server" Text='<%# Eval("PrintDateTime")==null?"":DateTime.Parse(Eval("PrintDateTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否挂起" SortExpression="IsShelve">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsShelve" runat="server" Width="20%" Checked='<%# Eval("IsShelve")==null?false: Eval("IsShelve")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否发货" SortExpression="IsDelivery">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsDelivery" runat="server" Width="20%" Checked='<%# Eval("IsDelivery")==null?false: Eval("IsDelivery")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgDeliveryDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="产品明细" CommandName="look" CausesValidation="False" TabIndex="-1" Visible="<% $CRMIsActionAllowed:XMDelivery.DeliveryDetails %>" />
                    <asp:ImageButton ID="imgBtnShelveRemarks" runat="server" CommandArgument='<%# Eval("Id") %>'
                        ImageUrl="~/App_Themes/Blue/Image/22.gif" ToolTip="挂起说明" CommandName="ShelveRemarks"
                        CausesValidation="False" />
                    <%--下拉tr--%>
                    <%--<tr id="div<%# Eval("Id") %>" style="background-color: White; display: none; border: 0px;"
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
                                                            <td colspan="100%" style="text-align: left;">
                                                                <span style="font-size: 18px; font-family: 隶书;">收货信息</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>收货人姓名：</b>
                                                            </td>
                                                            <td style="text-align: left; width: 100px;">
                                                                <%# Eval("FullName")%>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>省：</b>
                                                            </td>
                                                            <td style="text-align: left; width: 100px;">
                                                                <%# Eval("Province")%>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>收货地址：</b>
                                                            </td>
                                                            <td colspan="5" style="text-align: left; width: 710px;">
                                                                <%# Eval("DeliveryAddress")%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>手机：</b>
                                                            </td>
                                                            <td style="text-align: left; width: 100px;">
                                                                <%# Eval("Mobile")%>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>市：</b>
                                                            </td>
                                                            <td style="text-align: left; width: 100px;">
                                                                <%# Eval("City")%>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>备用收货地址：</b>
                                                            </td>
                                                            <td colspan="5" style="text-align: left; width: 710px;">
                                                                <%# Eval("DeliveryAddressSpare")%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>电话：</b>
                                                            </td>
                                                            <td style="text-align: left; width: 100px;">
                                                                <%# Eval("Tel")%>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>区/县：</b>
                                                            </td>
                                                            <td style="text-align: left; width: 100px;">
                                                                <%# Eval("County")%>
                                                            </td>
                                                            <td style="text-align: right; width: 90px;">
                                                                <b>备注：</b>
                                                            </td>
                                                            <td colspan="5" style="text-align: left; width: 710px;">
                                                                <%# Eval("OrderRemarks")%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <div style="background-color: White; width: 100%; border: 0px;">
                                                    <td colspan="100%">
                                                        <asp:GridView ID="grdXMDeliveryDetailsManage" runat="server" AutoGenerateColumns="False"
                                                            DataKeyNames="Id" SkinID="GridViewThemen" OnRowDataBound="grdXMDeliveryDetailsManage_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                         <asp:HiddenField ID="hdId"   runat="server" /> 
                                                                 <asp:HiddenField ID="hdDeliveryId" Value='<%# Eval("Id")%>' runat="server" />  
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center" CssClass="headbackground"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="headbackground"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="订单号">
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" CssClass="headbackground" />
                                                                    <ItemStyle Width="120px" Wrap="false"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOrderNo" runat="server"></asp:Label>
                                                                        <%# Eval("OrderNo")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="仓库">
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" CssClass="headbackground" />
                                                                    <ItemStyle Width="120px" Wrap="false"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <%# Eval("WarehouseName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="类型">
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" CssClass="headbackground" />
                                                                    <ItemStyle Width="120px" Wrap="false"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDetailsTypeId" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="商品名称">
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" CssClass="headbackground" />
                                                                    <ItemStyle Width="120px" Wrap="false"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <%# Eval("PrdouctName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="商品编码" SortExpression="PlatformMerchantCode">
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                                    <ItemTemplate>
                                                                        <%# Eval("PlatformMerchantCode")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="尺寸">
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                                    <ItemTemplate>
                                                                        <%# Eval("Specifications")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="数量" SortExpression="">
                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" CssClass="headbackground" />
                                                                    <ItemTemplate>
                                                                        <%# Eval("ProductNum")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </div>
                                            </tr>
                                            <tr>
                                                <td colspan="100%">
                                                    <asp:Button ID="imgbtnChange" SkinID="button4" runat="server" Text="重新排单" CommandArgument='<%# Eval("Id") %>'
                                                        CommandName="XMDeliveryChange" OnClientClick="return confirm('确认重新排单？');" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ReSingleRow %>" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                                    <asp:Button ID="btnSplit" SkinID="button4" runat="server" Text="订单拆分" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.Split %>"
                                                        CommandArgument='<%# Container.DataItemIndex %>' CommandName="XMDeliverySplit"
                                                        OnClientClick="return confirm('确认拆分订单？');" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                     
                    <asp:ImageButton ID="imgbtnOrderInfoDetail" runat="server" SkinID="btnDetail" ToolTip="详情" CommandArgument='<%# Eval("ID") %>'
                         CommandName="XMOrderInfoDetail"  Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoList.SeeXMOrderInfoDetail %>" >
                         </asp:ImageButton>  
                    <asp:ImageButton ID="imgbtnOperatingRecords" runat="server" ToolTip="操作记录" CommandArgument='<%# Eval("ID") %>'
                         CommandName="XMOrderInfoOperatingRecords"  ImageUrl="~/App_Themes/Default/Image/Records.png" 
                          Visible="<% $CRMIsActionAllowed:ManageProject.XMOrderInfoList.OperatingRecords %>"  >
                         </asp:ImageButton>

                    <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除"
                    CommandName="XMOrderInfoDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"   />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>--%>
    </asp:GridView> 

    <ext:ResourceManager ID="ResourceManager1" runat="server"/>

    <ext:GridPanel ID="GridPaneltest"
        runat="server"
        Margins="0 0 5 5"
        Region="Center"
        Frame="true"
        Height="305" BodyCssClass="x-selectable"
        >
        <Store>
            <ext:Store
                ID="Store1"
                runat="server" >
                <Reader>
                    <ext:JsonReader IDProperty="Id">
                        <Fields>
                            <ext:RecordField Name="Id" />
                            <ext:RecordField Name="DeliveryTypeName" />
                            <ext:RecordField Name="DeliveryNumber" />
                            <ext:RecordField Name="ShipperName" />
                            <ext:RecordField Name="LogisticsNumber" />
                            <ext:RecordField Name="LogisticsCompany" />
                            <ext:RecordField Name="Price" />
                            <ext:RecordField Name="PrintQuantity" />
                            <ext:RecordField Name="PrintBatch" />
                            <ext:RecordField Name="PrintDateTime" />
                            <ext:RecordField Name="IsShelve" />
                            <ext:RecordField Name="IsDelivery" />
                            <ext:RecordField Name="VerificationStatus" />
                            <ext:RecordField Name="FullName" />
                            <ext:RecordField Name="Province" />
                            <ext:RecordField Name="DeliveryAddress" />
                            <ext:RecordField Name="Mobile" />
                            <ext:RecordField Name="City" />
                            <ext:RecordField Name="DeliveryAddressSpare" />
                            <ext:RecordField Name="Tel" />
                            <ext:RecordField Name="County" />
                            <ext:RecordField Name="OrderRemarks" />
                            <ext:RecordField Name="IsPrint" />
                            <ext:RecordField Name="IsLogisticsInfoLate" />
                            <ext:RecordField Name="projectId" />
                            <ext:RecordField Name="IsPlatformDeliver" />
                            <ext:RecordField Name="DeliveryTypeId" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
        </Store>

        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:Column ColumnID="Id" Hidden="true" DataIndex="Id" />
                <ext:Column DataIndex="DeliveryTypeName" Header="发货单类型" Width="65"/>
                <ext:Column DataIndex="DeliveryNumber" Header="发货单号" Width="150">
                    <Renderer Fn="testRenderer"/>
                </ext:Column>
                <ext:Column DataIndex="ShipperName" Header="发货方" Width="50" />
                <ext:Column DataIndex="FullName" Header="收货人姓名" Width="70"/>
                
                <ext:TemplateColumn runat="server" DataIndex="" MenuDisabled="true" Header="电话" Width="100">
                    <Template runat="server">
                        <Html>                          
                            <tpl if="Mobile ==''">
                                {Tel}
						    </tpl>  
                            <tpl if="Mobile !=''">
                                {Mobile}
						    </tpl>  
                            
                        </Html>
                    </Template>
                </ext:TemplateColumn>
                <ext:Column DataIndex="LogisticsNumber" Header="物流单号" Width="105" Sortable="true">
                    <Editor>
                        <ext:TextField runat="server" EmptyText="请输入物流单号">
                        </ext:TextField>
                    </Editor>
                </ext:Column>
                <ext:Column DataIndex="LogisticsCompany" Header="物流公司" Width="90" >
                    <Editor>
                        <ext:ComboBox runat="server" DisplayField="LogisticsName" ValueField="LogisticsId" ID="CompanyCheck" Editable="false" EmptyText="请输入物流公司">
                            
                            <Store>
                                <ext:Store runat="server" ID="LogisticsCompanyStore">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="LogisticsName"></ext:RecordField>
                                                <ext:RecordField Name="LogisticsId"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                    </Editor>
                </ext:Column>
                <ext:Column DataIndex="City" Header="城市" Width="60" />
               <%--  <ext:TemplateColumn runat="server" DataIndex="" MenuDisabled="true" Header="打印次数" Width="60">
                    <Template runat="server">
                        <Html>                          
                            <tpl if="PrintQuantity ==0">
                                未打印
						    </tpl>  
                            <tpl if="PrintQuantity !=0">
                                {PrintQuantity}
						    </tpl>  
                            
                        </Html>
                    </Template>
                </ext:TemplateColumn>
                <ext:Column DataIndex="PrintBatch" Header="打印批次" Width="60" /> --%>
                <ext:DateColumn DataIndex="PrintDateTime" Header="打印时间" Width="115" Format="yyyy-MM-dd HH:mm" />
                <ext:Column DataIndex="Price" Header="运费" Width="40" >
                    <Editor>
                        <ext:TextField runat="server" EmptyText="请输入运费">
                        </ext:TextField>
                    </Editor>
                </ext:Column>
                <ext:BooleanColumn DataIndex="IsShelve" Header="挂起"  Width="34" TrueText="是" FalseText='<div style="color:#F00">否</div>'>

                </ext:BooleanColumn>
                <ext:BooleanColumn DataIndex="IsDelivery" Header="发货"  Width="34" TrueText="是" FalseText='<div style="color:#F00">否</div>'>

                </ext:BooleanColumn >

                 <ext:TemplateColumn DataIndex="VerificationStatus" Header="核销状态"  Width="60">
                     <Template runat="server">
                        <Html>    
                                <tpl if="VerificationStatus == '1'">
                                    全部核销
						        </tpl>  
                                <tpl if="VerificationStatus == '2'">
                                    部分核销
						        </tpl>
                                <tpl if="VerificationStatus == '3'">
                                    未核销
						        </tpl>  
                                 <tpl if="VerificationStatus == '' || VerificationStatus == null">
                                    未核销
						        </tpl>  
                        </Html>
                    </Template>
                 </ext:TemplateColumn>

                <ext:BooleanColumn DataIndex="IsPrint" Header="发货单"  Width="50" TrueText="是" FalseText='<div style="color:#F00">否</div>'>
                    
                </ext:BooleanColumn >

                <ext:BooleanColumn DataIndex="IsPlatformDeliver" Header="平台发货"  Width="60" TrueText="是" FalseText='<div style="color:#F00">否</div>'>
                    
                </ext:BooleanColumn >
<%--                <ext:CommandColumn Header="操作" Width="30" >
                    <Commands>
                        <ext:GridCommand Icon="BookEdit" CommandName="Remark">
                                <ToolTip Text="挂起说明" />

                        </ext:GridCommand>
                        
                    </Commands>
                   
                </ext:CommandColumn>--%>
                <ext:Column Header="操作" DataIndex="" Width="45">
                    <Commands>
                        <ext:ImageCommand CommandName="Remark" Icon="BookEdit" >
                                <ToolTip Text="挂起说明" />
                            </ext:ImageCommand>
                        <ext:ImageCommand CommandName="Logistics" Icon="Lorry">
                            <ToolTip Text="查看物流" />
                        </ext:ImageCommand>
                    </Commands>

                    <PrepareCommand Handler="prepareCommand(command,record);" />
                </ext:Column>
                
            </Columns>

        </ColumnModel>

        <SelectionModel>
            <ext:CheckboxSelectionModel runat="server" Mode="Simple" ID="CheckboxSelectionModel1" CheckOnly="true"></ext:CheckboxSelectionModel>
        </SelectionModel>

<%--        <Listeners>
            <Command Handler="alert(record.data['Id'])"></Command>
        </Listeners>--%>

        <DirectEvents>
            <Command OnEvent="RowCommand">
                <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                <ExtraParams>
                    <ext:Parameter Name="ID" Value="record.data['Id']" Mode="Raw"></ext:Parameter>
                    <ext:Parameter Name="Name" Value="command" Mode="Raw"></ext:Parameter>
                </ExtraParams>
            </Command>
        </DirectEvents>

        <Plugins>
            <%--<ext:EditableGrid runat="server" />--%>
            <ext:RowEditor runat="server" ClicksToEdit="2" ID="rowedit1" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.LogisticsEdit %>" SaveText="保存" CancelText="取消">
<%--                <Listeners>
                    <BeforeEdit Handler="alert(#{Store1}.data.get(rowIndex).get('Id'));" />
                </Listeners>--%>
                <DirectEvents>
                    <BeforeEdit OnEvent="RowBeforeEdit">
                        <EventMask ShowMask="true" Msg="正在处理..." CustomTarget="={#{rowedit1}.body}"></EventMask>
                        <ExtraParams>
                            <ext:Parameter Name="DeliveryId" Value="#{Store1}.data.get(rowIndex).get('Id')" Mode="Raw"></ext:Parameter>
                        </ExtraParams>
                    </BeforeEdit>
                </DirectEvents>
                <DirectEvents>
                    <AfterEdit OnEvent="RowAfterEdit">
                        <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                        <ExtraParams>
                            <ext:Parameter Name="LogisticsNumber" Value="#{Store1}.data.get(rowIndex).get('LogisticsNumber')" Mode="Raw"></ext:Parameter>
                            <ext:Parameter Name="DeliveryId" Value="#{Store1}.data.get(rowIndex).get('Id')" Mode="Raw"></ext:Parameter>
                            <ext:Parameter Name="LogisticsFee" Value="#{Store1}.data.get(rowIndex).get('Price')" Mode="Raw"></ext:Parameter>
                        </ExtraParams>
                    </AfterEdit>
                </DirectEvents>
            </ext:RowEditor>
            <ext:RowExpander ID="RowExpander1" runat="server" ExpandOnDblClick="false">
                                          
                <Component>
                              
                        <ext:Panel ID="Panel2" runat="server">
                        <Items>
                         <ext:Panel ID="Panel1" runat="server"></ext:Panel>

                         <ext:GridPanel ID="GridPanel2"
                                    runat="server"
                                    Region="South"
                                    Frame="true"
                                    Height="100" 
                                    AnchorVertical="60%">
                                    
                            <Store>
                                <ext:Store
                                    ID="Store2"
                                    runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="Id">
                                            <Fields>
                                                <ext:RecordField Name="DeliveryId" />
                                                <ext:RecordField Name="OrderNo" />
                                                <ext:RecordField Name="WarehouseName" />
                                                <ext:RecordField Name="PrdouctName" />
                                                <ext:RecordField Name="PlatformMerchantCode" />
                                                <ext:RecordField Name="Specifications" />
                                                <ext:RecordField Name="ProductNum" />
                                                <ext:RecordField Name="DetailsTypeId" />
                                                <ext:RecordField Name="SourceID" Type="Auto"/>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>

                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                        <ext:Column DataIndex="OrderNo" Header="订单号" Width="150" />
                                        <ext:Column DataIndex="WarehouseName" Header="仓库" Width="150" />
                                        <ext:TemplateColumn runat="server" DataIndex="" MenuDisabled="true" Header="类型" Width="150">
                                                <Template runat="server">
                                                    <Html>                          
                                                        <tpl if="DetailsTypeId ==11">
                                                            赠品
						                                </tpl>  
                                                        <tpl if="DetailsTypeId ==10">
                                                            赔付
						                                </tpl> 
                                                        <tpl if="DetailsTypeId ==13">
                                                            正常订单
						                                </tpl>
                                                        <tpl if="DetailsTypeId ==14">
                                                            退换货
						                                </tpl>  
                                                        <tpl if="DetailsTypeId ==15">
                                                            发票
						                                </tpl>  

                                                    </Html>
                                                </Template>
                                        </ext:TemplateColumn>
                                        <ext:Column DataIndex="PrdouctName" Header="商品名称" Width="150" />
                                        <ext:Column DataIndex="PlatformMerchantCode" Header="商品编码" Width="150" />
                                        <ext:Column DataIndex="Specifications" Header="尺寸" Width="150" />
                                        <ext:Column DataIndex="ProductNum" Header="数量" Width="150" />
                                </Columns>

                            </ColumnModel>

                            <SelectionModel>
                                <%--<ext:CheckboxSelectionModel runat="server" ID="CheckboxSelectionModel2"></ext:CheckboxSelectionModel>--%>      
                                      <ext:RowSelectionModel runat="server"></ext:RowSelectionModel>
                            </SelectionModel>


                            </ext:GridPanel>

                            <ext:Panel runat="server">
                                <Items>
                                    <ext:TableLayout runat="server" Columns="3">
                                        <Cells>
                                            <ext:Cell>
                                                <ext:Button ID="cell_button_1" runat="server" Icon="ReverseBlue" Text="重新排单" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ReSingleRow %>" >

                                                <DirectEvents>
                                                    <Click OnEvent="cell_button_1_click">
                                                        <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                                        <ExtraParams>
                                                            <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                                                        </ExtraParams>
                                                        <Confirmation ConfirmRequest="true" Title="提示" Message="确认重新排单?"/>
                                                    </Click>
                                                </DirectEvents>
                                                </ext:Button>
                                            </ext:Cell>
                                            <ext:Cell>
                                                <ext:Button ID="cell_button_2" runat="server" Icon="ReverseBlue" Text="订单拆分" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.Split %>">
                                                    <DirectEvents>
                                                        <Click OnEvent="cell_button_2_click">
                                                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                                            <ExtraParams>
                                                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPanel2}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                                                            </ExtraParams>
                                                            <Confirmation ConfirmRequest="true" Title="提示" Message="确认订单拆分?"/>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </ext:Cell>
                                        </Cells>
                                    </ext:TableLayout>
                                </Items>
                            </ext:Panel>

                        </Items>
                    </ext:Panel>
                </Component>
                
<%--                <Listeners>
                    <BeforeExpand Handler="Ext.Msg.notify('Row collapsing', 'Row � '+record.length);" />
                </Listeners>--%>
                
                <DirectEvents>
                    <BeforeExpand OnEvent="Unnamed_Event">
                        <EventMask ShowMask="true" Msg="正在处理..." CustomTarget="={#{Panel2}.body}"></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="ID" Value="record.data['Id']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="FullName" Value="record.data['FullName']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="Province" Value="record.data['Province']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="DeliveryAddress" Value="record.data['DeliveryAddress']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="Mobile" Value="record.data['Mobile']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="City" Value="record.data['City']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="DeliveryAddressSpare" Value="record.data['DeliveryAddressSpare']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="Tel" Value="record.data['Tel']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="County" Value="record.data['County']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="OrderRemarks" Value="record.data['OrderRemarks']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="PrintQuantity" Value="record.data['PrintQuantity']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="PrintBatch" Value="record.data['PrintBatch']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="PrintDateTime" Value="record.data['PrintDateTime']" Mode="Raw"></ext:Parameter>
                                <ext:Parameter Name="rowIndex" Value="rowIndex" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                    </BeforeExpand>
                </DirectEvents>
            </ext:RowExpander>
        </Plugins>

        <LoadMask Msg="Loading" ShowMask="true" />

    </ext:GridPanel>

    <ext:Window 
            ID="Window2" 
            runat="server" 
            Icon="House" 
            Title="挂起说明" 
            Hidden="true" 
            Width="420" 
            Height="143"
            Padding="10" 
            X="275"
            Y="150">
        <Items>
            <ext:FormPanel ID="FormPanel1" 
                    runat="server" 
                    Border="false" 
                    MonitorValid="true"
                    BodyStyle="background-color:transparent;"
                    Layout="Form">
                <Items>
                    <ext:TextField ID="HiddenID" runat="server" FieldLabel="ID" DataIndex="DeliveryID" Hidden="true"/>

                    <ext:TextArea ID="tRemark" runat="server" DataIndex="Context" AllowBlank="false" FieldLabel="说明" Width="260"></ext:TextArea>

                </Items>
            </ext:FormPanel>
        </Items>
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button ID="btnSaveRecord" runat="server" Icon="Disk" Text="保存">
                        <DirectEvents>
                            <Click OnEvent="WindowSave" Before="return #{FormPanel1}.getForm().isValid();"></Click>
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:Window>

        <ext:Window ID="Window1" 
            runat="server" 
            Width="1100"
            Height="600" 
            Title="物流信息" 
            Hidden="true">

    </ext:Window>

    <ext:Panel 
            ID="pnlFlexRatio" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
            </LayoutConfig>
            <Items>
                <ext:Button ID="btnPostExport" runat="server" Text="导出发货单" Icon="ControlStartBlue" Visible="<%$CRMIsActionAllowed:ManageProject.XMDelivery.PostExport %>">
                <DirectEvents>
                    <Click OnEvent="PostExport_Click" IsUpload="true">

                    </Click>
                </DirectEvents>
                </ext:Button>
                <ext:Button ID="But_pldyyd" runat="server" Text="批量打印运单" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.pldyyd %>">
                    <DirectEvents>
                        <Click OnEvent="pldyyd_Click" IsUpload="true">

                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnImportLogisticsNumber" runat="server" Text="导入物流单号" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ImportLogisticsNumber %>"/>
                <ext:Button ID="btnBulkShipments" runat="server" Text="批量发货" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.BulkShipments %>">
                    <DirectEvents>
                        <Click OnEvent="BulkShipments_click1" Timeout="300000">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnOrdrInfMerger" runat="server" Text="订单合并" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.OrdrInfMerger %>">
                    <DirectEvents>
                        <Click OnEvent="OrdrInfMerger_Click">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnImportDeliver" runat="server" Text="导入发货" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ImportDeliver %>"/>
                <ext:Button ID="btnDeliverExport" runat="server" Text="手动发货导出" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.DeliverExport %>">
                    <DirectEvents>
                        <Click OnEvent="DeliverExport_Click" IsUpload="true">
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDirectThermalPrint" runat="server" Text="热敏打印" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.DirectThermalPrint %>">

                </ext:Button>
                <ext:Button ID="btnCancelWaybill" runat="server" Text="取消面单号" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.CancelWaybill %>">
                    <DirectEvents>
                        <Click OnEvent="CancelWaybill_Click">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnShelveDelivery" runat="server" Text="挂起发货单" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ShelveDelivery %>">
                    <DirectEvents>
                        <Click OnEvent="ShelveDelivery_Click">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnUnShelveDelivery" runat="server" Text="取消挂起" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.UnShelveDelivery %>">
                    <DirectEvents>
                        <Click OnEvent="UnShelveDelivery_Click">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnImportLogisticsCost" runat="server" Text="导入物流费用" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ImportLogisticsCost %>"/>
                <ext:Button ID="btnXLMOrderInfo" runat="server" Text="生成喜临门订单" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.XLMOrderInfo %>">
                    <DirectEvents>
                        <Click OnEvent="XLMOrderInfo_Click" Timeout="300000">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                  <ext:Button ID="btnPrintDelivery" runat="server" Text="打印发货单" Icon="ControlStartBlue" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.PrintDelivery %>">
                    <DirectEvents>
                        <Click OnEvent="PrintDelivery">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:Panel>
    <ext:Panel runat="server" Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
            </LayoutConfig>
        <Items>
                <ext:Button ID="btnPlatformDeliver" runat="server" Text="平台发货" Icon="ControlStartBlue">
                    <DirectEvents>
                        <Click OnEvent="btnPlatformDeliver_Click" Timeout="300000">
                            <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Name="data" Value="Ext.encode(#{GridPaneltest}.getRowsValues({selectedOnly:true}))" Mode="Raw"></ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
        </Items>
    </ext:Panel>
    
</asp:Content>
<%--<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>--%>
            <%--<td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnPostExport" SkinID="button6" runat="server" Text="导出发货清单" OnClick="btnPostExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.PostExport %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="But_pldyyd" SkinID="button6" runat="server" Text="批量打印运单" OnClick="But_pldyyd_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.pldyyd %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnImportLogisticsNumber" SkinID="button6" runat="server" Text="导入物流单号"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ImportLogisticsNumber %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnBulkShipments" SkinID="button4" runat="server" Text="批量发货" OnClick="btnBulkShipments_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.BulkShipments %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnOrdrInfMerger" SkinID="button4" runat="server" Text="订单合并" OnClick="btnOrdrInfMerger_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.OrdrInfMerger %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnImportDeliver" SkinID="button4" runat="server" Text="导入发货" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ImportDeliver %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnDeliverExport" SkinID="button6" runat="server" Text="手动发货导出" OnClick="btnDeliverExport_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.DeliverExport %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnDirectThermalPrint" SkinID="button6" runat="server" Text="赠品热敏打印"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.DirectThermalPrint %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnCancelWaybill" SkinID="button6" runat="server" Text="赠品取消面单号"
                    OnClick="btnCancelWaybill_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.CancelWaybill %>" />
            </td>
            <td style="width: 4px"></td>--%>
<%--            <td>
                <asp:Button ID="btnShelveDelivery1" SkinID="button6" runat="server" Text="挂起发货单" OnClick="btnShelveDelivery_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ShelveDelivery %>" />
            </td>--%>
            <%--<td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnUnShelveDelivery" SkinID="button6" runat="server" Text="取消挂起"
                    OnClick="btnUnShelveDelivery_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.UnShelveDelivery %>" />
            </td>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnImportLogisticsCost" SkinID="button6" runat="server" Text="导入物流费用"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.ImportLogisticsCost %>" />
            </td>--%>
<%--        </tr>--%>
        <%--<tr>
            <td style="height: 5px;"></td>
        </tr>
        <tr>
            <td style="width: 4px"></td>
            <td>
                <asp:Button ID="btnXLMOrderInfo" SkinID="button6" runat="server" Text="生成喜临门订单" OnClick="btnXLMOrderInfo_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.XLMOrderInfo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnXLMLogistics" SkinID="button6" runat="server" Text="获取喜临门物流" OnClick="btnXLMLogistics_Click"
                    Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.XLMLogistics %>" />
            </td>
        </tr>--%>
<%--    </table>
</asp:Content>--%>
