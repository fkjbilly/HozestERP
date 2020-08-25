<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMClaimList.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMClaimList" %>

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
        
        .gridlist 
        {
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

                <td style="width: 88px">
                    索赔单生成时间
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <input id="txtBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server" style=" width:100%;"/>
                </td>
                <td style="width: 20px">
                </td>
                <td style="width: 20px">
                    &nbsp;&nbsp;至&nbsp;&nbsp;
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <input id="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server" style=" width:100%;"/>
                </td>

            </tr>
            <tr>
                <td style="height: 8px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    索赔单号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtClaimNumber" runat="server" Width="100%"></asp:TextBox>
                </td><td></td>
                <td style="width: 80px">
                    订单号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtOrderCode" runat="server" Width="100%"></asp:TextBox>
                </td><td></td>
                <td style="width: 80px">
                    退换货单号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtApplicationNo" runat="server" Width="100%"></asp:TextBox>
                </td><td></td>
                
                <td style="width: 80px">
                    索赔类型
                </td>
                
                <td style="width: 120px">
                   <asp:DropDownList ID="ddlClaimType" Width="100%" runat="server">
                    </asp:DropDownList>
                </td><td></td>
                
                <td style="width: 65px">
                    财务审核
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="Financial" runat="server" Width="80%">
                        <asp:ListItem Value="-1">--所有--</asp:ListItem>
                        <asp:ListItem Value="1">已审核</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                    </asp:DropDownList>
                </td><td></td>
                    <td colspan="2"> 
                <div id="DIVSearch" runat="server" style="float:left;" >
                
               <asp:Button ID="hidBtnSearch" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"  
                OnClick="hidBtnSearch_Click" /> 

                <asp:Button ID="btnSearch" runat="server" Text="查询" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.Search %>"
                        OnClick="btnSearch_Click" /> 
                </div> 
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

        <asp:GridView ID="gvQuestion" runat="server"  AutoGenerateColumns="False" DataKeyNames="ID"
                        SkinID="GridViewThemen" OnRowDataBound="gvQuestion_RowDataBound"
                        OnRowCommand="gvQuestion_RowCommand" Width="100%"> 
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                   <asp:HiddenField ID="hdQuestionId" Value='' runat="server" /><%--<%# Eval("Id")%>--%>
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

            <asp:TemplateField HeaderText="索赔单号" SortExpression="ClaimNumber" >
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                   <%# Eval("ClaimNumber")%>
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="索赔单生成时间" SortExpression="ClaimDate">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("ClaimDate")%>              
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="退换货单号" SortExpression="ApplicationNo">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                <%# Eval("ApplicationNo")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="订单号" SortExpression="OrderCode">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                <%# Eval("OrderCode")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="平台" SortExpression="PlatformType">
                <HeaderStyle Width="68px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                <%# Eval("PlatformType")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="店铺名称" SortExpression="NickName">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                       <%# Eval("NickName")%>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="索赔类型" SortExpression="ClaimTypeName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                       <%# Eval("ClaimTypeName")%>
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="索赔金额" HeaderStyle-HorizontalAlign="Center" SortExpression="Amount">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Amount")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="财务审核" HeaderStyle-HorizontalAlign="Center" SortExpression="FinancialStatus">
               <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# Eval("FinancialStatus")==null?false: Eval("FinancialStatus")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="入仓时间" SortExpression="ReturnTime">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("ReturnTime")%>              
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="完成时间" SortExpression="FinishTime">
               <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="True" />
                <ItemTemplate>
                    <%# Eval("FinishTime")%>              
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="操作">
               <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate> 

                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="ToEdit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.Edit %>" />

                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/delect.gif" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="删除" CommandName="ToDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.Delete %>" />
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width:8%;">
                <asp:Button ID="btnAdd" runat="server" Text="新增" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.Add %>" SkinID="button4"/>
            </td>
            <%--<td style=" width:50px;"> 
             <div id="DIVDelete" runat="server">
                <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" 
                 Visible="<% $CRMIsActionAllowed:ManageApplication.AllDelete %>" 
                 OnClientClick="return CheckSelect(this,99);"  OnClick="btnDelete_Click" />
              </div>
             </td>--%>
            
             <td style="width:8%;">
                <asp:Button ID="btnFin" runat="server" Text="财务审核" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.Financial %>" 
                 OnClick="btnFin_Click" SkinID="button4"/>
             </td>
             <td style="width:8%;">
                <asp:Button ID="btnFinNo" runat="server" Text="财务反审核" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.NoFinancial %>" 
                  OnClick="btnFinNo_Click"  SkinID="button4"/>
             </td>
             <td style="width:8%;">
                <asp:Button ID="btnExport" runat="server" Text="导出索赔单" Visible="<% $CRMIsActionAllowed:ManageProject.XMClaimList.Export %>" 
                  OnClick="btnExport_Click"  SkinID="button4"/>
             </td>
             <td style="width:68%;"></td>
        </tr>
    </table>  
</asp:Content>
