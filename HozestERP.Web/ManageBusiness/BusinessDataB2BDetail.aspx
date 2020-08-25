<%@ Page Language="C#" CodeBehind="BusinessDataB2BDetail.aspx.cs" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" Inherits="HozestERP.Web.ManageBusiness.BusinessDataB2BDetail" %>
   
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
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="3">
    <tbody>
            <tr>
            <td style="width:12%" align="right">
            合同编号:
            </td>
            <td align="left" width="30%">
            <asp:TextBox runat="server" ID="txtContractNumber" Width="90%"></asp:TextBox>
            </td>
            <td align="left" width="5%">
            <asp:Button ID="btnContractNumber" runat="server" OnClick="btnContractNumber_Click" Text="修改"  ValidationGroup="ModuleValidationGroup"
            Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.ContractNumberSave %>"/>
            </td>

            <td style="width:10%" align="right">
            合同金额:
            </td>
            <td align="left" width="40%">
            <asp:TextBox runat="server" ID="txtContractAmount" Width="70%"></asp:TextBox>
            </td>
            </tr>

            <tr>
            <td align="right">
             客户公司: 
             </td>
             <td align="left">
              <asp:TextBox runat="server" ID="txtClientCompany" Width="90%"></asp:TextBox>
             </td> 
             <td></td>
             <td align="right">
             打款人: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtPayPerson" Width="70%"></asp:TextBox>
             </td>
            </tr>

            <tr>
            <td align="right">
             提交时间: 
             </td>  
             <td align="left">
              <input id="txtSubmitDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate" runat="server" style=" width:90%;"/>
             </td> 
             <td></td>
             <td align="right">
             提交年限: 
             </td>  
             <td align="left" style="width:135px">
              <asp:TextBox runat="server" ID="txtSubmitLimit" Width="70%"></asp:TextBox>
             </td>
            </tr>

            <tr>
            <td align="right">
             归属部门: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtDepartmentName" Width="90%" ReadOnly="true"></asp:TextBox>
             </td> 
             <td></td>
             <td align="right">
             提交人: 
             </td>  
             <td align="left" style="width:135px">
              <asp:TextBox runat="server" ID="txtAuthorName" Width="70%" ReadOnly="true"></asp:TextBox>
             </td>
            </tr>

            <tr>
             <td align="right">
             实际到款金额: 
             </td>  
             <td align="left">
              <asp:TextBox runat="server" ID="txtActualAmount" Width="90%" ReadOnly="true"></asp:TextBox>
             </td>
            </tr>

            <tr><td colspan="5" align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存"  ValidationGroup="ModuleValidationGroup"
                    OnClick="btnSave_Click"  Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.Save %>"/>

                    <asp:Button ID="btnSpendingAuthority" runat="server" Text="支付查看权限"  ValidationGroup="ModuleValidationGroup"
                         Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.SpendingAuthority %>"/>
            </td></tr>

            <tr><td colspan="5">

            <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                       OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound" SkinID="GridViewThemen" ShowFooter="true"
                       OnRowEditing="grdvClients_RowEditing" OnRowUpdating="grdvClients_RowUpdating" OnRowCancelingEdit="grdvClients_RowCancelingEdit">
           <editrowstyle backcolor="LightCyan"
          forecolor="DarkBlue" HorizontalAlign="Left" VerticalAlign="Middle"/>
    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle Wrap="False" Width="25px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 
                      
         <asp:TemplateField HeaderText="金额类型"  SortExpression="AmountTypeName">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <%# Eval("AmountTypeName")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:DropDownList ID="ddlAmountType" runat="server" Width="85%">
                 </asp:DropDownList>
            </EditItemTemplate>
         </asp:TemplateField> 

         <asp:TemplateField HeaderText="金额"  SortExpression="Amount">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <%# Eval("Amount")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtAmount" Text='<%# Eval("Amount")%>' runat="server" Width="80%" />
            </EditItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="域名"  SortExpression="DomainName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("DomainName")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtDomainName" runat="server" Width="85%" Text='<%# Eval("DomainName")%>'/>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="业务类型"  SortExpression="BusinessTypeName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("BusinessTypeName")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:DropDownList ID="ddlBusinessType" runat="server" Width="92%">
                 </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="备注1"  SortExpression="Remark1">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("Remark1")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtRemark1" runat="server" Width="85%" Text='<%# Eval("Remark1")%>'/>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="备注2"  SortExpression="Remark2">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("Remark2")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtRemark2" runat="server" Width="85%" Text='<%# Eval("Remark2")%>'/>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="财务审核" HeaderStyle-HorizontalAlign="Center" SortExpression="FinancialStatus">
               <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# Eval("FinancialStatus")%>' /> 
                </ItemTemplate>
            </asp:TemplateField>

        <asp:TemplateField HeaderText="审核人"  SortExpression="AuditPersonName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("AuditPersonName")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderText="审核时间"  SortExpression="AuditDate">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("AuditDate")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="服务开始时间"  SortExpression="ServiceBeginDate">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("ServiceBeginDate")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <input id="txtServiceBeginDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate" runat="server" style=" width:85%;" text='<%# Eval("ServiceBeginDate")%>'/>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="服务结束时间"  SortExpression="ServiceEndDate">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("ServiceEndDate")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <input id="txtServiceEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="Wdate" runat="server" style=" width:85%;" text='<%# Eval("ServiceEndDate")%>'/>
            </EditItemTemplate>
        </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="归属人"  SortExpression="BelongingName">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("BelongingName")%>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox ID="txtBelongingName" runat="server" Width="85%" text='<%# Eval("BelongingName")%>'/>
            </EditItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="提交人"  SortExpression="AuthorName">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("AuthorName")%>
            </ItemTemplate> 
        </asp:TemplateField>         

        <asp:TemplateField HeaderText="操作"> 
             <HeaderStyle HorizontalAlign="Center" Width="120px" Wrap="False" />
            <ItemTemplate>
                <asp:ImageButton ID="imgBtnAudit" runat="server" ImageUrl="~/App_Themes/Default/Image/audit.jpg" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="审核" CommandName="Audit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.Audit %>" />

                <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.Edit %>" />

                <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="删除" CommandName="Del" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.Delete %>" />
                
            </ItemTemplate>
            <EditItemTemplate>  
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存"
                        CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.EditSave %>"/>
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif" ToolTip="取消"
                        CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2BDetail.EditCancel %>"/>
              </EditItemTemplate>
        </asp:TemplateField>
           
    </Columns>
</asp:GridView>
            </td></tr>
    </tbody>
  </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
</asp:Content>

