<%@ Page Language="C#" CodeBehind="XMAfterSalesDataDetail.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" Inherits="HozestERP.Web.ManageCustomerService.XMAfterSalesDataDetail" %>

   
<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register src="../Modules/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %> 
<%@ Register Src="~/Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="HozestERP" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>

<%@ Register Src="~/Modules/SelectSingleCustomerControl.ascx" TagName="SelectSingleCustomerControl" TagPrefix="HozestERP" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 

<script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
<link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"  type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:GridView ID="grdvZYNewsList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
    SkinID="GridViewThemen" onrowdatabound="grdvZYNewsList_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="3%" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="订单号"  SortExpression="OrderNO">
            <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# Eval("OrderNO")%>
            </ItemTemplate> 
        </asp:TemplateField>
         <asp:TemplateField HeaderText="平台"  SortExpression="PlatformType">
            <HeaderStyle Width="5%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("PlatformType")%>
            </ItemTemplate> 
        </asp:TemplateField>
          <asp:TemplateField HeaderText="店铺名称" SortExpression="NickName">
            <HeaderStyle Width="15%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
              <%# Eval("NickName")%>
            </ItemTemplate> 
              
        </asp:TemplateField>
        <asp:TemplateField HeaderText="买家"  SortExpression="Buyer">
            <HeaderStyle Width="12%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# Eval("Buyer")%>
            </ItemTemplate> 
        </asp:TemplateField>
         <asp:TemplateField HeaderText="问题"  SortExpression="QuestionType">
            <HeaderStyle Width="20%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# (DataBinder.Eval(Container, "DataItem.QuestionType") as HozestERP.BusinessLogic.Codes.CodeList).CodeName == null ? "" : (DataBinder.Eval(Container, "DataItem.QuestionType") as HozestERP.BusinessLogic.Codes.CodeList).CodeName%>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderText="是否退货"  SortExpression="IsReturns">
            <HeaderStyle Width="5%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# Eval("IsReturns")%>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderText="处理人"  SortExpression="SrvAfterCustomer">
            <HeaderStyle Width="10%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# (DataBinder.Eval(Container, "DataItem.SrvAfterCustomer") as HozestERP.BusinessLogic.CustomerManagement.CustomerInfo).FullName == null ? "" : (DataBinder.Eval(Container, "DataItem.SrvAfterCustomer") as HozestERP.BusinessLogic.CustomerManagement.CustomerInfo).FullName%>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderText="处理结果"  SortExpression="ResultsType">
            <HeaderStyle Width="10%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# Eval("ResultsType") == null ? "" : ((DataBinder.Eval(Container, "DataItem.ResultsType") as HozestERP.BusinessLogic.Codes.CodeList).CodeName == null ? "" : (DataBinder.Eval(Container, "DataItem.ResultsType") as HozestERP.BusinessLogic.Codes.CodeList).CodeName)%>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderText="状态"  SortExpression="Status">
            <HeaderStyle Width="5%" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# (int)Eval("Status") == 0 ? "提交中" : ((int)Eval("Status") == 1 ? "处理中" : ((int)Eval("Status") == 2 ? "完成" : "状态为空"))%>
            </ItemTemplate> 
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">

</asp:Content>

