<%@  Page  Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="PremiumsDetailsSS.aspx.cs" Inherits="HozestERP.Web.ManageFinance.PremiumsDetailsSS" %>
   
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>  
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>  
                 <td style="width: 80px">
                    项目类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlXMProjectTypeId" runat="server" Width="100%"  Enabled="true"  OnSelectedIndexChanged="ddlXMProjectTypeId_SelectedIndexChanged"    AutoPostBack="true">
                    </asp:DropDownList>
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 项目名称:
                </td>
                <td style="width: 150px">

                 <asp:DropDownList ID="ddlXMProjectNameId" runat="server" Width="100%"  Enabled="true"  OnSelectedIndexChanged="ddlXMProjectNameId_SelectedIndexChanged"    AutoPostBack="true"> 
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
                    <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%" Enabled="true">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
            <td style="height: 5px;">
            </td>
            </tr>  
             <tr> 
<%--               <td style="width: 80px; display:none;">
                    时间类型:
                </td>
                <td style="width: 150px display:none;">
                    <asp:DropDownList ID="ddlOrderStatus" runat="server" Width="100%" Enabled="true"> 
                        <asp:ListItem Value="1" Text="创单时间" ></asp:ListItem>
                        <asp:ListItem Value="2" Text="付款时间" ></asp:ListItem>
                        <asp:ListItem Value="3" Text="发货时间"></asp:ListItem> 
                        <asp:ListItem Value="4" Text="交易成功时间"></asp:ListItem> 
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>--%>
                 <td style="width: 80px">
                    时间
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <hozesterp:datepicker ID="txtBeginDate" runat="server" Format="yyyy-MM-dd" 
                        Width="80%">
                    </hozesterp:datepicker>
                </td>
                <td>
                    至
                </td>
                <td style="width: 120px" nowrap="nowrap">
                    <hozesterp:datepicker ID="txtEndDate" runat="server" Format="yyyy-MM-dd" 
                        Width="80%"></hozesterp:datepicker>
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 
                </td>
                <td style="width: 150px">

                <%-- <input id="txtOrderInfoModifiedEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate" runat="server" style=" width:90%;"/>--%>
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 <%--厂家编码:--%>
                </td>
                <%--<td style="width: 150px">
                     <asp:TextBox runat="server" ID="txtManufacturersCode" Width="100%" Enabled="false"></asp:TextBox>
                </td>  --%>
                 <td style="text-align: right">
                 <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Visible="<% $CRMIsActionAllowed:ManageProject.XMDelivery.Search %>" />  
               <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"  
                OnClick="btnRefresh_Click" /> 
            </td> 
            </tr>
        </table>
    </asp:Panel>
</asp:Content> 
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server"> 
    <asp:GridView ID="grdPremiumsDetailsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen" OnRowDataBound="grdPremiumsDetailsList_RowDataBound" 
         ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="订单号"  SortExpression="OrderCode">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <%# Eval("OrderCode")%>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="旺旺Id"  SortExpression="WantID">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <%# Eval("WantID")%>
            </ItemTemplate> 
           </asp:TemplateField> 
             <asp:TemplateField HeaderText="商品名称"  SortExpression="ProductName">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <%# Eval("ProductName")%>
            </ItemTemplate> 
           </asp:TemplateField> 
            <asp:TemplateField HeaderText="商品编码"  SortExpression="PlatformMerchantCode">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("PlatformMerchantCode")%>
            </ItemTemplate> 
          </asp:TemplateField>
                     <asp:TemplateField HeaderText="数量"  SortExpression="ProductNum">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("ProductNum")%>
            </ItemTemplate> 
          </asp:TemplateField>  
           <asp:TemplateField HeaderText="总价"  SortExpression="FactoryPrice">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("FactoryPrice")%>
            </ItemTemplate> 
          </asp:TemplateField>   
            
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
     
</asp:Content>



