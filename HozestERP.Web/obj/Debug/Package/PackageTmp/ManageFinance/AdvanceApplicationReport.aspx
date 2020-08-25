<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="AdvanceApplicationReport.aspx.cs" Inherits="HozestERP.Web.ManageFinance.AdvanceApplicationReport" %>
   
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="HozestERP" %> 
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
               <td style="width: 80px">
                    暂支类型：
                </td>
                <td style="width: 120px">
                <asp:DropDownList runat="server" ID="ddTheAdvanceType" OnSelectedIndexChanged="ddTheAdvanceType_SelectedIndexChanged" AutoPostBack="true"  Width="80%" >
                </asp:DropDownList>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    店铺名称：
                </td>
                <td style="width: 120px">
                   <asp:DropDownList ID="ddlNickId" runat="server" Width="80%">
                    </asp:DropDownList>
                </td> 
                   <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    暂支状态：
                </td>
                <td style="width: 120px">
                  <asp:DropDownList ID="ddAdvanceState" runat="server" Width="100%" >
                        <asp:ListItem Value="-1" Text="--所有--" ></asp:ListItem>
                        <asp:ListItem Value="0" Text="未处理" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="暂支使用中"></asp:ListItem> 
                        <asp:ListItem Value="2" Text="暂支结束"></asp:ListItem> 
                        </asp:DropDownList>
                   <%-- <asp:DropDownList ID="ddAdvanceState" runat="server" Width="80%" > 
                        </asp:DropDownList> --%>
                </td> 
            </tr>
             <tr>
            <td style="height: 5px;">
            </td>
            </tr> 
            <tr>
               
                <td style="width: 80px">
                    申请人：
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtApplicantsName" runat="server" Width="80%"></asp:TextBox>
                </td>
            <td style="width: 40px">
                </td>
                 
                <td style="width: 90px">
                刷单单号:
                </td>
                <td style="width: 150px">
                        <asp:TextBox runat="server" ID="txtScalpingCode" Width="80%"></asp:TextBox>
                </td> 
                    
                </td> 
                 <td style="width: 40px">
                </td>
                <td></td>
                <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" language="javascript">
        function ShowHidde(sid, evt) {
            evt = evt || window.event;
            var target = evt.target || evt.srcElement;
            var objDiv = document.getElementById("div" + sid);
            if (window.ActiveXObject) {
                objDiv.style.display = objDiv.style.display == "none" ? "block" : "none";
            }
            else {
                objDiv.style.display = objDiv.style.display == "none" ? "table-row" : "none";
            }
            target.title = objDiv.style.display == "none" ? "Show" : "Hide";
            var imgid = 'img' + sid;
            document.getElementById(imgid).src = objDiv.style.display == "none" ? "../images/folder.gif" : "../images/folderopen.gif";
        }
    </script> 
    <asp:GridView ID="gvAdvanceApplication" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" onrowdatabound="gvAdvanceApplication_RowDataBound" >
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="javascript:void(0);"><img id='img<%# Eval("Id")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("Id")%>',event)" /></a>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="40px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField> 

             <asp:TemplateField HeaderText="平台"  SortExpression="PlatformTypeId">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" /> 
            <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
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
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
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
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkManagerIsAudit" runat="server" Width="20%" Checked='<%# Eval("ManagerIsAudit")==null?false: Eval("ManagerIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="财务审核" SortExpression="FinanceIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceIsAudit" runat="server" Width="20%" Checked='<%# Eval("FinanceIsAudit")==null?false: Eval("FinanceIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="公司审核" SortExpression="DirectorIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkDirectorIsAudit" runat="server" Width="20%" Checked='<%# Eval("DirectorIsAudit")==null?false: Eval("DirectorIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="财务确认" SortExpression="FinanceOkIsAudit">
             <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkFinanceOkIsAudit" runat="server" Width="20%" Checked='<%# Eval("FinanceOkIsAudit")==null?false: Eval("FinanceOkIsAudit")%>' />
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="暂支状态"  SortExpression="AdvanceState">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <asp:Label ID="lblAdvanceState" runat="server"></asp:Label>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="暂支金额"  SortExpression="TheAdvanceMoney">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
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
            <ItemTemplate>
               <asp:Label ID="lblForecastReturnTime" runat="server"></asp:Label>
               <!--下拉tr-->
                    <tr id="div<%# Eval("Id") %>" style=" background-color:White; display:none;">
                        <td colspan="100%" style=" width:100%; height:100%;">
                            <div style="background-color:White;">
                                <div style=" position: relative; left: 0px; overflow: auto;
                                    width: 100%;">
                                    <!---绑定内层Gridview--->
                                    <asp:GridView ID="gvAdvanceApplicationDetail" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="Id" BorderStyle="None"
                                    onrowdatabound="gvAdvanceApplicationDetail_RowDataBound">
                                        <Columns>
                                             <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                   <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="False" Width="30px" HorizontalAlign="Center"></HeaderStyle>
                                           </asp:TemplateField> 
                                            <asp:TemplateField HeaderText="暂支类型" SortExpression="">
                                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>  
                                             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).AdvanceTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).AdvanceTypeName.CodeName: ""%>
                                                </ItemTemplate> 
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="领/还款类型" SortExpression="">
                                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate> 
                                             <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).PayTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).PayTypeName.CodeName: ""%>
                                                </ItemTemplate> 
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="金额" SortExpression="">
                                                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>  
                                                   <asp:Label ID="lblTheAdvanceMoneyD" runat="server"></asp:Label> 
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="领/还款人" SortExpression="Status">
                                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate>
                                                 <asp:Label ID="lblRecipientsFunName" runat="server"></asp:Label> 
                                            <%-- <%# (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).RecipientsFunName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageFinance.AdvanceApplicationDetail).RecipientsFunName.FullName: ""%>--%>
                                                </ItemTemplate> 
                                            </asp:TemplateField> 
                                            <asp:TemplateField HeaderText="确认时间" SortExpression="">
                                                <HeaderStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Width="200px" HorizontalAlign="Center" Wrap="False" />
                                                <ItemTemplate> 
                                                  <%# Eval("CreateTime") == null ? "" : DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                                </ItemTemplate> 
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
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


