<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMReturnMoneyList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMReturnMoneyList" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>

                <td style="width: 80px">
                    项目名称
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlXMProjectNameId" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>

                <td style="width: 20px">
                </td>

                <td style="width: 80px">
                    平台类型
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlPlatform" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 20px">
                </td>

                 <td style="width: 80px">
                    时间类型
                </td>
                <td style="width: 160px">
                    <asp:DropDownList ID="ddlTimeType" runat="server" Width="100%" Enabled="true"> 
                        <asp:ListItem Value="1" Text="创单时间" ></asp:ListItem>
                        <asp:ListItem Value="2" Text="付款时间" ></asp:ListItem>
                        <asp:ListItem Value="3" Text="发货时间"></asp:ListItem> 
                        <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem> 
                    </asp:DropDownList>
                </td>                

                 <td style="width: 20px">
                </td>

                <td style="width: 88px">完成时间</td>
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
                    <HozestERP:DatePicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" Width="80%"></HozestERP:DatePicker>
                </td>

            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    订单号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtOrderCode" runat="server" Width="100%"></asp:TextBox>
                </td> 
                <td style="width: 40px">
                </td>
                <td style="width: 40px">
                    品牌:
                </td>
                <td style="width: 90px">
                    <asp:DropDownList ID="ddlBrandType" runat="server" Width="100%" Enabled="true">
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
                 项目类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlXMProjectTypeId" runat="server" Width="100%"  Enabled="true" OnSelectedIndexChanged="ddlXMProjectTypeId_SelectedIndexChanged"    AutoPostBack="true">
                    </asp:DropDownList>
                </td> 

              <td colspan="6" align="right"> 
                <div id="DIVSearch" runat="server" style="float:right;" >
                
               <asp:Button ID="hidBtnSearch" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"  
                OnClick="hidBtnSearch_Click" /> 

                <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:ManageApplication.Search %>"
                        OnClick="btnSearch_Click" /> 
                </div> 
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

        <asp:GridView ID="gvQuestion" runat="server"  AutoGenerateColumns="False" DataKeyNames="ID"
                        SkinID="GridViewThemen" OnRowDataBound="gvQuestion_RowDataBound" Width="100%"> 
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    <asp:HiddenField ID="hdQuestionId" Value='' runat="server" />
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="40px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="false" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="申请单号" SortExpression="ApplicationNo" >
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                   <%# Eval("ApplicationNo")%>
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="申请时间" SortExpression="CreateDate">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("CreateDate")%>              
                </ItemTemplate>
            </asp:TemplateField>

           <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" Wrap="True"/>
                
                <ItemTemplate>
                <div style=" width:120px; word-wrap:break-word;">
                 <asp:LinkButton ID="lbtnOrderNo" runat="server"   CommandArgument='<%# Eval("OrderCode")%>'
                        ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton> 
                    </div>    
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="平台" SortExpression="PlatformTypeId">
                <HeaderStyle Width="68px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="68px" HorizontalAlign="Center" Wrap="True" />
                    <ItemTemplate>
                    <div style="width: 68px; word-wrap:break-word;">
                        <%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplication).PlatformType%>
                     </div>
                    </ItemTemplate>                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="店铺名称" SortExpression="PlatformTypeId">
                 <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                       <%# (Container.DataItem as HozestERP.BusinessLogic.ManageApplication.XMApplication).NickName%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="申请类型" SortExpression="ApplicationType">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                  <asp:Label ID="lblApplicationType"  runat="server" Text='<%# Eval("ApplicationType")%>'></asp:Label> 
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="退款金额" HeaderStyle-HorizontalAlign="Center" SortExpression="Amount">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="Amount" runat="server"><%# Eval("Amount")%></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="补价订单" SortExpression="ReservepriceOrder">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                <div style=" width:120px; word-wrap:break-word;">
                 <asp:LinkButton ID="lbtnReservepriceOrder" runat="server"   CommandArgument='<%# Eval("ReservepriceOrder")%>'
                        ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton> 
                        </div>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="是否送出" HeaderStyle-HorizontalAlign="Center" SortExpression="SupervisorStatus">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                <CRM:ImageCheckBox ID="IsSend" runat="server" Checked='<%# Eval("IsSend")==null?false: Eval("IsSend")%>' /> 
                </ItemTemplate>
            </asp:TemplateField>

                        <asp:TemplateField HeaderText="主管审核" HeaderStyle-HorizontalAlign="Center" SortExpression="SupervisorStatus">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                <CRM:ImageCheckBox ID="SupervisorStatus" runat="server" Checked='<%# Eval("SupervisorStatus")==null?false: Eval("SupervisorStatus")%>' />
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="财务审核" HeaderStyle-HorizontalAlign="Center" SortExpression="FinancialStatus">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# Eval("FinancialStatus")==null?false: Eval("FinancialStatus")%>' />
                </ItemTemplate>
            </asp:TemplateField>
                         <asp:TemplateField HeaderText="入仓时间" SortExpression="ReturnTime">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("ReturnTime")%>              
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="完成时间" SortExpression="FinishTime">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("FinishTime")%>              
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
