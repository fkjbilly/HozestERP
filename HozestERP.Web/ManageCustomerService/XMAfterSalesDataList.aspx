<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="XMAfterSalesDataList.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMAfterSalesDataList" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 100%">
      <tr>
        <td style="width: 70px" align="right">
               开始日期:
            </td>
        <td style="width: 120px;">
               <input id="ddlBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server" style=" width:100%;"/>
            </td>

        <td style="width: 70px" align="right">
               结束日期:
            </td>
        <td style="width: 120px;">
               <input id="ddlEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" runat="server" style=" width:100%;"/>
            </td>

        <td style="width: 70px" align="right">
               组别: 
            </td>
        <td style="width: 120px;">
               <asp:DropDownList ID="ddlGroupID" runat="server" Width="100%">
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
               <asp:DropDownList ID="ddlRank" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        <td style="text-align: right">
           <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMAfterSalesDataList.Search %>" /> 
           <asp:Button ID="btnFile" runat="server" Text="存档" OnClick="btnFile_Click" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMAfterSalesDataList.File %>" OnClientClick="return confirm('您确定要将该月数据存档？');"/>
           <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"   OnClick="btnRefresh_Click" />
        </td> 
      </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDeleting="grdvClients_RowDeleting"
        OnRowDataBound="grdvClients_RowDataBound">
        <Columns>
    
         <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="组别" SortExpression="GroupName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
               <asp:Label ID="lblGroup" runat="server" Text='<%# Eval("GroupName")==null?"":Eval("GroupName").ToString().Length>15?Eval("GroupName").ToString().Substring(0,15)+"..":Eval("GroupName").ToString()%>' ToolTip='<%# Eval("GroupName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          
         <asp:TemplateField HeaderText="客服"  SortExpression="CustomerName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("CustomerName")==null?"":Eval("CustomerName").ToString().Length>15?Eval("CustomerName").ToString().Substring(0,15)+"..":Eval("CustomerName").ToString()%>' ToolTip='<%# Eval("CustomerName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
          
        <asp:TemplateField HeaderText="需求退货客户"  SortExpression="DemandReturn">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>  
               <asp:LinkButton ID="lblDemandReturn" runat="server" Text='<%# Eval("DemandReturn").ToString().Length>15?Eval("DemandReturn").ToString().Substring(0,15)+"..":Eval("DemandReturn").ToString()%>' ToolTip='<%# Eval("DemandReturn")%>' Font-Underline="true" ForeColor="Blue"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="实际退货"  SortExpression="ActualReturn">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
            <asp:LinkButton ID="lblActualReturn" runat="server" Text='<%# Eval("ActualReturn").ToString().Length>15?Eval("ActualReturn").ToString().Substring(0,15)+"..":Eval("ActualReturn").ToString()%>' ToolTip='<%# Eval("ActualReturn")%>' Font-Underline="true" ForeColor="Blue"></asp:LinkButton>
            </ItemTemplate>   
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="退货挽回率"  SortExpression="ReturnRate">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblReturnRate" runat="server" Text='<%# Eval("ReturnRate").ToString().Length>15?Eval("ReturnRate").ToString().Substring(0,15)+"..":Eval("ReturnRate").ToString()%>'  ToolTip='<%# Eval("ReturnRate")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="个人工作量"  SortExpression="PersonalWorkload">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:LinkButton ID="lblPersonalWorkload" runat="server" Text='<%# Eval("PersonalWorkload").ToString().Length>15?Eval("PersonalWorkload").ToString().Substring(0,15)+"..":Eval("PersonalWorkload").ToString()%>'  ToolTip='<%# Eval("PersonalWorkload")%>' Font-Underline="true" ForeColor="Blue"></asp:LinkButton>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="售后出错"  SortExpression="ErrorCount">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblErrorCount" runat="server" Text='<%# Eval("ErrorCount").ToString().Length>15?Eval("ErrorCount").ToString().Substring(0,15)+"..":Eval("ErrorCount").ToString()%>'  ToolTip='<%# Eval("ErrorCount")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="天猫综合指数"  SortExpression="TMIndex">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblTMIndex" runat="server" Text='<%# Eval("TMIndex").ToString().Length>15?Eval("TMIndex").ToString().Substring(0,15)+"..":Eval("TMIndex").ToString()%>'  ToolTip='<%# Eval("TMIndex")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="DSR得分"  SortExpression="DSRScore">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblDSRScore" runat="server" Text='<%# Eval("DSRScore").ToString().Length>15?Eval("DSRScore").ToString().Substring(0,15)+"..":Eval("DSRScore").ToString()%>'  ToolTip='<%# Eval("DSRScore")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="响应时间"  SortExpression="ResponseTime">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblResponseTime" runat="server" Text='<%# Eval("ResponseTime").ToString().Length>15?Eval("ResponseTime").ToString().Substring(0,15)+"..":Eval("ResponseTime").ToString()%>'  ToolTip='<%# Eval("ResponseTime")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="京东响应"  SortExpression="JDResponseTime">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblJDResponseTime" runat="server" Text='<%# Eval("JDResponseTime").ToString().Length>15?Eval("JDResponseTime").ToString().Substring(0,15)+"..":Eval("JDResponseTime").ToString()%>'  ToolTip='<%# Eval("JDResponseTime")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="京东售后"  SortExpression="JDCustomerService">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblJDCustomerService" runat="server" Text='<%# Eval("JDCustomerService").ToString().Length>15?Eval("JDCustomerService").ToString().Substring(0,15)+"..":Eval("JDCustomerService").ToString()%>'  ToolTip='<%# Eval("JDCustomerService")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="客户投诉"  SortExpression="CustomerComplaints">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblCustomerComplaints" runat="server" Text='<%# Eval("CustomerComplaints").ToString().Length>15?Eval("CustomerComplaints").ToString().Substring(0,15)+"..":Eval("CustomerComplaints").ToString()%>'  ToolTip='<%# Eval("CustomerComplaints")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="评价加分"  SortExpression="EvaluationPoints">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
                   <asp:Label ID="lblEvaluationPoints" runat="server" Text='<%# Eval("EvaluationPoints").ToString().Length>15?Eval("EvaluationPoints").ToString().Substring(0,15)+"..":Eval("EvaluationPoints").ToString()%>'  ToolTip='<%# Eval("EvaluationPoints")%>'></asp:Label>
            </ItemTemplate> 
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="已存档" SortExpression="IsFile">
             <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkIsFile" runat="server" Width="20%" Checked='<%# Eval("IsFile")==null?false: Eval("IsFile")%>' />
                </ItemTemplate>
            </asp:TemplateField>

         <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageCustomerService.XMAfterSalesDataList.Edit %>" />
                </ItemTemplate>
            
            </asp:TemplateField>     
    </Columns>
</asp:GridView>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
