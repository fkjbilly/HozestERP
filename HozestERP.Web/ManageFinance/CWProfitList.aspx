<%@  Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Root.Master" 
CodeBehind="CWProfitList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.CWProfitList" %>
 

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
<script src="../Script/CommonManager.js" type="text/javascript"></script>

   <style type="text/css"> 
       .TDLeft
        { 
             font-weight:bold;
             text-align:left;
        } 
         .TDRight
        {  
             text-align:right;
        } 
        
        .TDValue
        {
            text-align:right;  
        }  
    
          
   </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
          <%-- 条件查询--%>
          <tr>
          <td colspan="2" style="width:100%" > 
         
          <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>   
                 <td style="width: 80px">
                 项目类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlXMProjectTypeId" runat="server" Width="100%"  Enabled="true" OnSelectedIndexChanged="ddlXMProjectTypeId_SelectedIndexChanged"    AutoPostBack="true">
                    </asp:DropDownList>
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 项目名称:
                </td>
                <td style="width: 150px">

                 <asp:DropDownList ID="ddlXMProjectNameId" runat="server" Width="100%"  Enabled="true" OnSelectedIndexChanged="ddlXMProjectNameId_SelectedIndexChanged"    AutoPostBack="true"> 
                        </asp:DropDownList>
                         
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 店铺名称:
                </td>
                <td style="width: 150px">
                     <asp:DropDownList ID="ddlNickList" runat="server" Width="100%"  Enabled="true">  
                        </asp:DropDownList>
                </td>  
                 <td style="width: 40px">
                </td>
                   <td style="width: 80px">
                    平台类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%" Enabled="true" OnSelectedIndexChanged="ddlPlatformTypeId_SelectedIndexChanged"    AutoPostBack="true">
                    </asp:DropDownList>
                </td>
               
            </tr>
             <tr>
            <td style="height: 5px;">
            </td>
            </tr>  
             <tr> 
               <td style="width: 80px">
                    时间类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="100%" Enabled="true"> 
                        <asp:ListItem Value="1" Text="创单时间" ></asp:ListItem>
                        <asp:ListItem Value="2" Text="付款时间" ></asp:ListItem>
                        <asp:ListItem Value="3" Text="发货时间"></asp:ListItem> 
                        <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem> 
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                 <td style="width: 80px">
                    时间:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlDateTime" runat="server" Width="100%" Enabled="true"> 
                        <asp:ListItem Value="本月" Text="本月" ></asp:ListItem>
                        <asp:ListItem Value="本季" Text="本季" ></asp:ListItem>
                        <asp:ListItem Value="本年" Text="本年"></asp:ListItem>  
                    </asp:DropDownList> 
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                  
                </td>
                <td style="width: 150px">

               
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                
                </td>
                <td style="text-align: right">
                 <asp:Button ID="btnOrderInfoSalesDetailsExport" runat="server" Text="导出" SkinID="button2" CssClass="reachedAndGoal"
                    OnClick="btnOrderInfoSalesDetailsExport_Click" Visible="<% $CRMIsActionAllowed:XMProductManage.CWProfitList.Export %>" />
                 &nbsp; &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"/>  
               <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"  
                OnClick="btnRefresh_Click" /> 
            </td> 
            </tr>
          </table>
          </td> 
          </tr>

           <tr>
            <td style="height: 5px;">
            </td>
            </tr>  
          <%--列表--%>
          <tr>  
          <td style=" width:50%;">   
          <table  border="0" cellpadding="2" cellspacing="2" style="width: 100%">
          <tr>
          <td>
            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
            <ContentTemplate>
          <table border="1" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr style="background-color:rgb(220,220,220);  font-weight:bold; text-align:center;"  >
            <td style="width: 150px">项目名称</td> <td style="width: 150px">
           <%--  <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td style="width: 150px">年度累计数</td><td style="width: 150px">月度达成率</td><td style="width: 150px">年度达成率</td></tr>
            <tr><td class="TDLeft">营业收入</td> 
            <td class="TDValue">
            <%--<asp:Label ID="lblYYSRMonthMoney" runat="server"></asp:Label>--%>
            <asp:LinkButton ID="lblYYSRMonthMoney" runat="server"  ToolTip="查看订单明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton> 
            </td>
            <td   class="TDValue"><asp:Label ID="lblYYSRYearMoney" runat="server"></asp:Label></td><td  class="TDValue"><asp:Label ID="lblYYSRMonthProfit" runat="server"></asp:Label></td><td  class="TDValue"><asp:Label ID="lblYYSRYearProfit" runat="server"></asp:Label></td></tr>
            
            <tr><td class="TDLeft">增值税</td> <td class="TDValue">
           <%--  <asp:UpdatePanel ID="UpdatePanel29" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblZZSMonthMoney" runat="server"></asp:Label>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td>
                <td  class="TDValue"><asp:Label ID="lblZZSRearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblZZSMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblZZSYearProfit" runat="server"></asp:Label></td></tr>
            
            <tr><td class="TDLeft" >营业成本</td> <td class="TDValue">
           <%--  <asp:UpdatePanel ID="UpdatePanel30" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblYYCBMonthMoney" runat="server"></asp:Label>
          <%--  </ContentTemplate>
            </asp:UpdatePanel> --%>
            </td>
                <td  class="TDValue"><asp:Label ID="lblYYCBYearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblYYCBMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblYYCBYearProfit" runat="server"></asp:Label></td></tr>
            <tr><td  class="TDRight" >进货成本</td> 
            <td class="TDValue">
            <%--<asp:Label ID="lblJHCBMonthMoney" runat="server"></asp:Label>--%>
            <asp:LinkButton ID="lblJHCBMonthMoney" runat="server"  ToolTip="查看产品明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton>
            </td>
            <td  class="TDValue"><asp:Label ID="lblJHCBYearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblJHCBMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblJHCBYearProfit" runat="server"></asp:Label></td></tr>
            <tr><td class="TDRight">赠品成本</td> 
            <td class="TDValue">
            <%--<asp:Label ID="lblZPCBMonthMoney" runat="server"></asp:Label>--%>
            <asp:LinkButton ID="lblZPCBMonthMoney" runat="server"  ToolTip="查看赠品明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton>
            </td>
            <td  class="TDValue"><asp:Label ID="lblZPCBYearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblZPCBMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblZPCBYearProfit" runat="server"></asp:Label></td></tr>
            <tr><td class="TDRight">平台成本费用</td> 
            <td  class="TDValue">
           <%-- <asp:Label ID="lblPTCBFYMonthMoney" runat="server"></asp:Label> --%>
           <%--  <asp:UpdatePanel ID="UpdatePanel26" runat="server">
            <ContentTemplate>--%>
            <asp:LinkButton ID="lblPTCBFYMonthMoney" runat="server"  ToolTip="查看平台费用明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton> 
          <%-- </ContentTemplate>
           </asp:UpdatePanel>--%>
            </td>
            <td  class="TDValue">
           <%--  <asp:UpdatePanel ID="UpdatePanel27" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblPTCBFYYearMoney" runat="server"></asp:Label>
          <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblPTCBFYMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblPTCBFYYearProfit" runat="server"></asp:Label></td></tr>
            <tr><td class="TDRight">运费</td> 
            <td class="TDValue">
           <%--  <asp:UpdatePanel ID="UpdatePanel28" runat="server">
            <ContentTemplate>  <asp:Label ID="lblYFMonthMoney" runat="server">  </asp:Label>--%>
            <asp:TextBox ID="txtYFMonthMoney" runat="server"  ReadOnly="true"  Width="98%"  style="text-align:right"  ></asp:TextBox>

          <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td>
                <td  class="TDValue"><asp:Label ID="lblYFYearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblYFMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblYFYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">刷拍成本</td> <td class="TDValue">
           <%--<asp:Label ID="lblSPCBMonthMoney" runat="server"></asp:Label>--%>
           <asp:LinkButton ID="lblSPCBMonthMoney" runat="server"  ToolTip="查看刷单明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton>
           </td>
           <td class="TDValue"><asp:Label ID="lblSPCBYearMoney" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblSPCBMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblSPCBYearProfit" runat="server"></asp:Label></td></tr>
           
           <tr><td class="TDRight">返现成本</td> 
           <td class="TDValue">
          <%-- <asp:Label ID="lblFXCBMonthMoney" runat="server"></asp:Label>--%>
           <asp:LinkButton ID="lblFXCBMonthMoney" runat="server"  ToolTip="查看返现明细" Style="color: Blue; text-decoration: underline;" ></asp:LinkButton> 
           </td>
           <td  class="TDValue"><asp:Label ID="lblFXCBYearMoney" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblFXCBMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblFXCBYearProfit" runat="server"></asp:Label></td></tr>
           
           <tr><td class="TDLeft">毛利</td> <td class="TDValue"><asp:Label ID="lblMLMonthMoney" runat="server"></asp:Label></td>
               <td  class="TDValue"><asp:Label ID="lblMLYearMoney" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblMLMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblMLYearProfit" runat="server"></asp:Label></td></tr> 
           
           </table>
           </ContentTemplate>
           </asp:UpdatePanel>
          </td>
          </tr>
          <tr>
          <td>
           <asp:UpdatePanel ID="UpdatePanel32" runat="server">
            <ContentTemplate>
           <%--加权限--%>
           <div id="DIVPingTaiFeiYong" runat="server" visible="<% $CRMIsActionAllowed:ManageFinance.CWProfitList.PingTaiFeiYong %>">
            <table border="1" cellpadding="2" cellspacing="2" style="width: 100%">
           <tr>  
           <td class="TDLeft" style="width: 150px">直接人工</td> <td  class="TDValue" style="width: 150px">
          <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblZJRGMonthMoney" runat="server"></asp:Label>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
           </td><td  class="TDValue" style="width: 150px">
           <%-- <asp:UpdatePanel ID="UpdatePanel14" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblZJRGYearMoney" runat="server"></asp:Label>
        <%--   </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td class="TDValue" style="width: 150px"><asp:Label ID="lblZJRGMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue" style="width: 150px"><asp:Label ID="lblZJRGYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">运营部门人员工资</td> <td>  
          <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>--%>
           <asp:TextBox ID="txtRYGZMonthMoney" runat="server"  ReadOnly="true"  Width="98%"  style="text-align:right" ></asp:TextBox>
         <%--  </ContentTemplate>
           </asp:UpdatePanel>--%>
            </td> <td  class="TDValue">
            <%-- <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblRYGZYearMoney" runat="server"></asp:Label>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblRYGZMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblRYGZYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">运营部门人员社保</td> <td> 
          <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
           <asp:TextBox ID="txtRYSBMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox> 
         <%--  </ContentTemplate>
           </asp:UpdatePanel>--%>
            </td> <td  class="TDValue">
          <%--   <asp:UpdatePanel ID="UpdatePanel16" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblRYSBYearMoney" runat="server"></asp:Label>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblRYSBMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblRYSBYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">运营部门人员奖金</td> <td>
         <%--  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>--%>
            <asp:TextBox ID="txtRYJJMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td> <td  class="TDValue">
           <%--  <asp:UpdatePanel ID="UpdatePanel17" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblRYJJYearMoney" runat="server"></asp:Label>
         <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblRYJJMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblRYJJYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDLeft">营业费用</td> <td  class="TDValue">
            <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblYYFYMonthMoney" runat="server"></asp:Label>
         <%--  </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td class="TDValue">
          <%--  <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblYYFYYearMoney" runat="server"></asp:Label>
         <%--  </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td class="TDValue"><asp:Label ID="lblYYFYMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblYYFYYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">运营部门销售奖金</td> <td>
            <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>--%>
           <asp:TextBox ID="txtXSJJMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
          <%-- </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td  class="TDValue">
           <%-- <asp:UpdatePanel ID="UpdatePanel19" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblXSJJYearMoney" runat="server"></asp:Label>
          <%-- </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td class="TDValue"><asp:Label ID="lblXSJJMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblXSJJYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">差旅费</td> <td>
            <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>--%>
           <asp:TextBox ID="txtCLFMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
          <%-- </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td  class="TDValue">
           <%-- <asp:UpdatePanel ID="UpdatePanel20" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblCLFYearMoney" runat="server"></asp:Label>
         <%--  </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td class="TDValue"><asp:Label ID="lblCLFMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblCLFYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">办公费用</td> <td>
            <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>--%>
           <asp:TextBox ID="txtBGFYMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
         <%--  </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td  class="TDValue">
           <%-- <asp:UpdatePanel ID="UpdatePanel21" runat="server">
            <ContentTemplate>--%>
           <asp:Label ID="lblBGFYYearMoney" runat="server"></asp:Label>
        <%--   </ContentTemplate>
           </asp:UpdatePanel>--%>
           </td><td class="TDValue"><asp:Label ID="lblBGFYMonthProfit" runat="server"></asp:Label></td>
               <td class="TDValue"><asp:Label ID="lblBGFYYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">其他费用</td> <td>
            <%--  <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>--%>
            <asp:TextBox ID="txtQTFYMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td  class="TDValue">
            <%-- <asp:UpdatePanel ID="UpdatePanel22" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblQTFYYearMoney" runat="server"></asp:Label>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblQTFYMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblQTFYYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">固定资产折旧</td> <td>
             <%-- <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>--%>
            <asp:TextBox ID="txtGDZCMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td  class="TDValue">
            <%-- <asp:UpdatePanel ID="UpdatePanel23" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblGDZCYearMoney" runat="server"></asp:Label>
          <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblGDZCMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblGDZCYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDRight">摊销费用</td> <td>
             <%-- <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>--%>
            <asp:TextBox ID="txtTXFYMonthMoney" runat="server" Width="98%"  style="text-align:right" ></asp:TextBox>
          <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td  class="TDValue">
            <%-- <asp:UpdatePanel ID="UpdatePanel24" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblTXFYYearMoney" runat="server"></asp:Label>
         <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblTXFYMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblTXFYYearProfit" runat="server"></asp:Label></td></tr>
           <tr><td class="TDLeft">广告费补贴</td> <td>
            <%--  <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>--%>
            <asp:TextBox ID="txtGGFMonthMoney" runat="server" Width="98%"  style="text-align:right"  ></asp:TextBox>
           <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td  class="TDValue">
           <%--  <asp:UpdatePanel ID="UpdatePanel25" runat="server">
            <ContentTemplate>--%>
            <asp:Label ID="lblGGFYearMoney" runat="server"></asp:Label>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            </td><td class="TDValue"><asp:Label ID="lblGGFMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblGGFYearProfit" runat="server"></asp:Label></td></tr> 
           <tr><td class="TDLeft">营业税金及附加</td> <td class="TDValue"><asp:Label ID="lblYYSJMonthMoney" runat="server"></asp:Label></td>
                <td  class="TDValue"><asp:Label ID="lblYYSJYearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblYYSJMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblYYSJYearProfit" runat="server"></asp:Label></td>
                </tr>
           <tr><td class="TDLeft">税前利润</td> <td class="TDValue"><asp:Label ID="lblSQLRMonthMoney" runat="server"></asp:Label></td>
                <td  class="TDValue"><asp:Label ID="lblSQLRYearMoney" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblSQLRMonthProfit" runat="server"></asp:Label></td>
                <td class="TDValue"><asp:Label ID="lblSQLRYearProfit" runat="server"></asp:Label></td>
                </tr>
            </table> 
           </div>
           </ContentTemplate>
           </asp:UpdatePanel>
          </td>
          </tr>
          </table> 
          </td> 
          <td style=" width:50%;"></td>
          </tr>
         
        </table> 
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server"> 
    
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
       <tr>
            <td style="width: 4px">
             </td> 
        </tr>
    </table>
</asp:Content>

