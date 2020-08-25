<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" 
 CodeBehind="CWPlatformSpendingDetails.aspx.cs" Inherits="HozestERP.Web.ManageFinance.CWPlatformSpendingDetails" %>
   
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <%--   <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />--%>
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr> 
               <td style="width: 80px">
                   说明:
                </td>
                <td style="width: 200px">
                    <asp:Label ID="lblExplanationValue" runat="server" ForeColor="Red" style="width:100%; "> </asp:Label>
                </td> 
                <td></td>
            </tr>
             <tr>
            <td style="height: 5px;">
            </td>
            </tr> 
            
        </table> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvCWPlatformSpendingDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
    SkinID="GridViewThemen"   OnRowDataBound="grdvCWPlatformSpendingDetails_RowDataBound" ShowFooter="true" > 
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">

                  <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                            scope="col">
                            &nbsp;
                        </th>
                    <th align="center" class="GridHeard" nowrap="" scope="col">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>

                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        平台名称
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        明细
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                        金额
                    </th>
                    <th align="center" class="GridHeard" nowrap="" style="width: 90px; white-space: nowrap;"
                        scope="col">
                        备注
                    </th> 
                </tr>
            </table>
        </EmptyDataTemplate>
    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 

             <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox> 
                    <asp:HiddenField ID="hdPSId" Value='<%#Eval("PSId")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>  

         <asp:TemplateField HeaderText="平台名称"  >
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle HorizontalAlign="Center"  Wrap="false" />
            <ItemTemplate>
            <%-- <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.CWPlatformSpendingMapping).PlatformName %> 
            <input style="background:transparent;border:0; width:100px; " value='<%# Eval("PlatformName")%>' readonly="readonly" runat="server" id="lblPlatformName" />--%>
             <asp:Label ID="lblPlatformName" runat="server"></asp:Label>

            </ItemTemplate> 
         </asp:TemplateField> 

         <asp:TemplateField HeaderText="明细"  >
            <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle HorizontalAlign="NotSet" Wrap="false" />
            <ItemTemplate>
                <input style="background:transparent;border:0; width:150px; " value='<%# Eval("ProjectExplanation")%>' readonly="readonly" runat="server" id="lblProjectExplanation" />
            </ItemTemplate> 
         </asp:TemplateField> 

         <asp:TemplateField HeaderText="金额"  >
            <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle HorizontalAlign="Right" Wrap="false" />
            <FooterStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:TextBox runat="server" ID="txtCountMoney" Text='<%# Eval("CountMoney")==null?"0":Eval("CountMoney")%>' Width="90%"  style="text-align:right" ></asp:TextBox>
                 <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgCountMoneyVaule" runat="server"  Text="" ForeColor="red"></asp:Label>
                 </div>
            </ItemTemplate> 

             <FooterTemplate>  
              <asp:ImageButton ID="imgBtnCountMoneySave" OnClick="imgBtnCountMoneySave_Click" runat="server"  ImageUrl="~/App_Themes/Default/Image/save.gif" ToolTip="保存" 
              Visible="<% $CRMIsActionAllowed:ManageFinance.CWPlatformSpendingDetails.save %>" /> 
            </FooterTemplate> 

         </asp:TemplateField> 

         <asp:TemplateField HeaderText="备注"  >
            <HeaderStyle Width="300px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtRemark" Text='<%# Eval("Remark")%>' Width="95%" Height="35px"></asp:TextBox>
            </ItemTemplate> 
         </asp:TemplateField>   

    </Columns>
</asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    
</asp:Content>

