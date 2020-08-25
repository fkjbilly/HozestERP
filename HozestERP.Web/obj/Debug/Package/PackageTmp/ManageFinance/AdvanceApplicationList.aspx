<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="AdvanceApplicationList.aspx.cs" Inherits="HozestERP.Web.ManageFinance.AdvanceApplicationList" %> 

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
<script language="javascript" type="text/javascript">
    var RefreshSearch = function () {
        window.parent.frames[1].RefreshSearch()
    }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr> 
               <td style="width: 80px">
                    平台类型:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlPlatformTypeId" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                 <td style="width: 80px">
                    店铺名称:
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlNickId" runat="server" Width="100%">
                    </asp:DropDownList>
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 暂支状态:
                </td>
                <td style="width: 150px">

                 <asp:DropDownList ID="ddAdvanceState" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="0" Text="未处理" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="暂支使用中"></asp:ListItem> 
                        <asp:ListItem Value="2" Text="暂支结束"></asp:ListItem> 
                        </asp:DropDownList>

                    <%--<asp:DropDownList ID="ddAdvanceState" runat="server" Width="100%" > 
                        </asp:DropDownList>--%> 
                </td> 
                <td style="width: 40px">
                </td>
                 <td style="width: 90px">
                 刷单单号:
                </td>
                <td style="width: 150px">
                     <asp:TextBox runat="server" ID="txtScalpingCode" Width="100%"></asp:TextBox>
                </td>  
            </tr>
             <tr>
            <td style="height: 5px;">
            </td>
            </tr> 
            <tr> 
             
             
                <td style="width: 100px">
                 
                 <asp:Label ID="lblManagerIsAudit" Text="店铺审核:" runat="server"></asp:Label> 
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddManagerIsAudit" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="0" Text="否" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="是"></asp:ListItem> 
                        </asp:DropDownList> 
                </td>  
                <td style="width: 40px">
                </td> 
                 <td style="width:100px">
                 <asp:Label ID="lblFinanceIsAudit" Text="财务审核:" runat="server"></asp:Label> 
                 
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddFinanceIsAudit" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="0" Text="否" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="是"></asp:ListItem> 
                        </asp:DropDownList> 
                </td> 
                  
                 <td style="width: 40px">
                </td> 
                 <td style="width:100px">
                 <asp:Label ID="lblFinanceOkIsAudit" Text="财务确认:" runat="server"></asp:Label> 
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddFinanceOkIsAudit" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="0" Text="否" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="是"></asp:ListItem> 
                        </asp:DropDownList> 
                </td> 
                <td></td>
                <td></td>
                 <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
             
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdAdvanceApplicationList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCommand="grdAdvanceApplicationList_RowCommand" OnRowDataBound="grdAdvanceApplicationList_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField> 

             <asp:TemplateField HeaderText="平台"  SortExpression="PlatformTypeId">
            <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                  <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).PlatformTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).PlatformTypeName.CodeName : ""%>
            </ItemTemplate> 
           </asp:TemplateField> 
            <asp:TemplateField HeaderText="店铺"  SortExpression="OrderCode">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).NickName.nick : ""%>
            </ItemTemplate> 
          </asp:TemplateField>
            <asp:TemplateField HeaderText="刷单单号"  SortExpression="ScalpingId">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).ScalpingNo != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).ScalpingNo.ScalpingCode : ""%>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="申请部门"  SortExpression="OrderCode">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).DepartmentName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).DepartmentName.DepName : ""%>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="申请受款人"  SortExpression="">
            <HeaderStyle Width="100px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="100px" HorizontalAlign="Center" Wrap="true" />
            <ItemTemplate>
                <%# Eval("ApplicationPayee")%>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="申请人"  SortExpression="Applicants">
            <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).ApplicantsName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplication).ApplicantsName.FullName : ""%>
            </ItemTemplate> 
          </asp:TemplateField>
             <asp:TemplateField HeaderText="店铺审核" SortExpression="ManagerIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsAudit" runat="server" Width="20%" Checked='<%# Eval("ManagerIsAudit")==null?false: Eval("ManagerIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="财务审核" SortExpression="FinanceIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceIsAudit" runat="server" Width="20%" Checked='<%# Eval("FinanceIsAudit")==null?false: Eval("FinanceIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="公司审核" SortExpression="DirectorIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkDirectorIsAudit" runat="server" Width="20%" Checked='<%# Eval("DirectorIsAudit")==null?false: Eval("DirectorIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="财务确认" SortExpression="FinanceOkIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceOkIsAudit" runat="server" Width="20%" Checked='<%# Eval("FinanceOkIsAudit")==null?false: Eval("FinanceOkIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>  
          <%--  
            <asp:TemplateField HeaderText="运营确认" SortExpression="OperationIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkOperationIsAudit" runat="server" Width="20%" Checked='<%# Eval("OperationIsAudit")==null?false: Eval("OperationIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
--%>
            <asp:TemplateField HeaderText="暂支状态"  SortExpression="AdvanceState">
            <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <asp:Label ID="lblAdvanceState" runat="server"></asp:Label>
            </ItemTemplate> 
          </asp:TemplateField> 
           <asp:TemplateField HeaderText="暂支金额"  SortExpression="TheAdvanceMoney">
            <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("TheAdvanceMoney")%>
            </ItemTemplate> 
          </asp:TemplateField>
          <asp:TemplateField HeaderText="未领款"  SortExpression="">
            <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <asp:Label ID="lblWLK" runat="server"></asp:Label>
            </ItemTemplate> 
          </asp:TemplateField>

          <asp:TemplateField HeaderText="未还款"  SortExpression="">
            <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <asp:Label ID="lblWHK" runat="server"></asp:Label>
            </ItemTemplate> 
          </asp:TemplateField>

          <asp:TemplateField HeaderText="归还日期"  SortExpression="">
            <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <asp:Label ID="lblForecastReturnTime" runat="server"></asp:Label>
            </ItemTemplate> 
          </asp:TemplateField>

            <asp:TemplateField HeaderText="操作"> 
             <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
            <ItemStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate> 
             <asp:ImageButton ID="imgbtnAdvanceApplicationDetail" runat="server" SkinID="btnDetail" ToolTip="明细" CommandArgument='<%# Eval("Id") %>'
                         CommandName="AdvanceApplicationDetail"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationBtnDetails %>" >
                         </asp:ImageButton>&nbsp; &nbsp;
                         
             <asp:ImageButton ID="ImagebtnPrint" runat="server"  ToolTip="打印查看" ImageUrl="~/App_Themes/Default/Image/print.gif"
             CommandArgument='<%# Eval("Id") %>'  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationbtnPrint %>" >
                         </asp:ImageButton>

                <asp:ImageButton ID="imgBtnDelete" CommandArgument='<%# Eval("Id") %>' runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" ToolTip="删除"
                    CommandName="AdvanceApplicationDelete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"  
                    Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationDelete %>" />
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationAdd %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerIsAudit"  SkinID="button4" runat="server" Text="店铺审核" OnClick="btnManagerIsAudit_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationManagerIsAudit %>" />
            </td>

            
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnManagerIsAuditNO"  SkinID="button4" runat="server" Text="店铺反审核" OnClick="btnManagerIsAuditNO_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationManagerIsAuditNO %>" />
            </td>
             <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnFinanceIsAudit"  SkinID="button4" runat="server" Text="财务审核"  OnClick="btnFinanceIsAudit_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceIsAudit %>" />
            </td>
             <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnFinanceIsAuditNO"  SkinID="button4" runat="server" Text="财务反审核"  OnClick="btnFinanceIsAuditNO_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceIsAuditNO %>" />
            </td> 
             <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnDirectorIsAudit"  SkinID="button4" runat="server" Text="公司审核"  OnClick="btnDirectorIsAudit_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationDirectorIsAudit %>" />
            </td>
            
             <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnDirectorIsAuditNO"  SkinID="button6" runat="server" Text="公司反审核"  OnClick="btnDirectorIsAuditNO_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationDirectorIsAuditNO %>" />
            </td>

            <%-- <td style="width: 4px">
            </td>
            <td>  
               <asp:Button ID="hidBtnFinanceOk" runat="server" Style="width: 0px; display: none;" ToolTip="财务确认"   OnClick="hidBtnFinanceOk_Click" /> 
               <asp:Button ID="hidBtnFinanceOkF" runat="server" Style="width: 0px; display: none;" ToolTip="财务确认" OnClientClick="return CheckSelectByAlert(this,99, '您是否确认？')"   OnClick="hidBtnFinanceOkF_Click" /> 
             <asp:Button ID="btnFinanceOk" SkinID="button4" runat="server" Text="财务确认"   ControlID="btnAllFinanceOk"  OnClick="btnFinanceOk_Click"
              Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceOk %>"   />   
            </td>  
            <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnOperationIsAudit"  SkinID="button4" runat="server" Text="运营确认"  OnClick="btnOperationIsAudit_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationOperationIsAudit %>"/>
            </td>
--%>
             <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnFinanceEnd"  SkinID="button4" runat="server" Text="暂支结束"  OnClick="btnFinanceEnd_Click"  Visible="<% $CRMIsActionAllowed:ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceEnd %>"/>
        
            </td>
             

            <td style="width: 4px">
            </td>
            <td>
                <%--<asp:Button ID="btnOppositeDelete" runat="server" Text="反删除" 
                    onclick="btnOppositeDelete_Click" />--%>
            </td>
        </tr>
    </table>
</asp:Content>
