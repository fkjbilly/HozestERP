<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMDataAnalysis.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMDataAnalysis" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/ImageButtonSelectSingleCustomerControl.ascx" TagName="ImageButtonSelectSingleCustomerControl"  TagPrefix="CRM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../Script/jquery-1.4.min.js" type="text/javascript"></script>
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />

   <style type="text/css">
	div.demo{
		border:1px solid #CCC;
		background:red;
		position:fixed;
		height:100%;
		z-index:0;
		top:4px; left:4px; right:4px; 
		margin-bottom:5px;
		 position:relative; 
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
            border-top-color:transparent;
            border-bottom-color:transparent;
            border-left-color:transparent;
            border-right-color:transparent; 
        }
        
        .gridlist {
            background: none repeat 0% 0% #FFF;
            color:#444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border:0px;
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

</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 40px">
                    平台
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 10px">
                </td>

                <td style="width: 80px">
                    店铺名称
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlNick" Width="100%" runat="server">
                    </asp:DropDownList>
                </td>

                 <td style="width: 10px">
                </td>

                <td style="width: 80px">
                    接待日期
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" Width="80%">
                    </HozestERP:DatePicker>
                </td>
                <td style="width: 10px">
                    &nbsp;&nbsp;至&nbsp;&nbsp;
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%"></HozestERP:DatePicker>
                </td>
                <td style="width: 10px">
                </td>
                <td style="width: 80px">
                    售前客服
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <asp:DropDownList ID="ddlCustomerService" Width="100%" runat="server">
                    </asp:DropDownList>
                </td>
            
                 <td style="width: 10px">
                </td>
                </tr>
                <tr>
                <td style="width: 40px">
                    班次
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlShift" runat="server" Width="100%">
                    <asp:ListItem Value="-1">--- 所有 ---</asp:ListItem>
                    <asp:ListItem Value="0">早班</asp:ListItem>
                    <asp:ListItem Value="1">晚班</asp:ListItem>
                    </asp:DropDownList>
                </td>
              <td colspan="11"> 
                <div id="DIVSearch" runat="server" style="float:right;" >
                
               <asp:Button ID="hidBtnSearch" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"  
                OnClick="hidBtnSearch_Click" /> 

                <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:XMDataAnalysis.Search %>"
                        OnClick="btnSearch_Click" /> 

                </div> 
              </td>       

                <td style="width: 20px">
                                <asp:Button ID="btnDaochu" runat="server" Text="导出" Visible="<% $CRMIsActionAllowed:XMDataAnalysis.Daochu %>"
                        OnClick="btnDaochu_Click" /> 
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
<asp:GridView ID="gvQuestion" runat="server"  AutoGenerateColumns="False" DataKeyNames="Id" SkinID="GridViewThemen"> 
        <Columns>
            <asp:TemplateField>
                <HeaderStyle Wrap="False" Width="40px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="false" />
                <ItemTemplate>
                   <a href="javascript:void(0);"><img id='img<%# Eval("ID")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("ID")%>',event)" /></a>
                   <%# Container.DataItemIndex + 1 %>
                   <asp:HiddenField ID="hdQuestionId" Value='<%# Eval("ID")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="组别" SortExpression="Group">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("Group")%>              
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="客服" SortExpression="CustomerID">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                   <%# (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMDataAnalysy).CreateName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageCustomerService.XMDataAnalysy).CreateName.FullName : ""%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="咨询量" HeaderStyle-HorizontalAlign="Center">
               <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                   <%# Eval("ConsultationCount")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="成交量" HeaderStyle-HorizontalAlign="Center">
               <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                   <%# Eval("DealCount")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="成交人数" SortExpression="NoTurnoverType">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DealPeopleCount")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="转化率" SortExpression="DateReason">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# (decimal)Eval("ConversionRate") == 0 ? "0" : (Math.Round((decimal)Eval("ConversionRate")*100, 2).ToString()+"%") %>
                    </div>           
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="成交金额" SortExpression="">
               <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                  <%# Eval("DealTotal")%>

                  <!--下拉tr-->
                    <tr id='div<%#Eval("ID")%>' style=" background-color:White; display:none; border:0px;" class="gridlist"> 
                        <td colspan="100%" style=" width:100%; height:100%;">
                            <div style="background-color:White;">
                                <div style=" position: relative; left: 0px; overflow: auto;
                                    width: 100%;">

                                    <table class="detailTable1" width="100%" border="0" cellspacing="0" cellpadding="3">
                                        <tbody>  
                                            <tr>
                                                <td colspan="100%" valign="top">
                                                    <table class="detailTableo" width="100%" border="0" cellspacing="0" cellpadding="3">
                                                               <tr>
                                                               <th>序号</th>
                                                               <th>平台</th>
                                                               <th>店铺名称</th>
                                                               <%--<th>接待日期</th>--%>
                                                               <th>咨询量</th>
                                                               <th>成交量</th>
                                                               <th>成交人数</th>
                                                               <th>转化率</th>
                                                               <th>成交金额</th>
                                                               </tr>
                                                               <%# Eval("DetailTab")%>
                                                    </table>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                             <div style="background-color:White; width:100%; border:0px;" > 
                                            <td  colspan="100%">
                                            
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
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
