<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" 
CodeBehind="XMScalpingPaymentDetails.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMScalpingPaymentDetails" %>
  
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
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>  
                 <td style="width: 90px">
                 刷单单号:
                </td>
                <td style="width: 150px">
                     <asp:TextBox runat="server" ID="txtScalpingCode" Width="100%" ReadOnly="true"></asp:TextBox>
                </td> 
                <td style="width: 40px">
                </td> 
                 <td style="text-align: right">
                    <%--<asp:Button ID="btnSearch"  runat="server" Text="查询" OnClick="btnSearch_Click" />--%>
                </td>
            </tr>   
            <tr>
            <td style="height: 5px;">
            </td>
            </tr> 
         
             
        </table> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdXMScalpingPaymentDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        SkinID="GridViewThemen"  OnRowDataBound="grdXMScalpingPaymentDetails_RowDataBound" 
         ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="刷单单号"  SortExpression="">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
               <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).ScalpingNo != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).ScalpingNo.ScalpingCode: ""%>
            </ItemTemplate> 
          </asp:TemplateField>
             <asp:TemplateField HeaderText="平台"  SortExpression="">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                  <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).PlatformTypeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).PlatformTypeName.CodeName : ""%>
            </ItemTemplate> 
           </asp:TemplateField> 
            <asp:TemplateField HeaderText="店铺"  SortExpression="">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).NickName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMScalping).NickName.nick : ""%>
            </ItemTemplate> 
          </asp:TemplateField>
          
           <asp:TemplateField HeaderText="订单号"  SortExpression="OrderCode">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("OrderCode")%>
            </ItemTemplate> 
          </asp:TemplateField>
          
           <asp:TemplateField HeaderText="旺旺号"  SortExpression="WantID">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("WantID")%>
            </ItemTemplate> 
          </asp:TemplateField> 
          
           <asp:TemplateField HeaderText="商品"  SortExpression="ProductName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("ProductName")%>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="销售价"  SortExpression="SalePrice">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("SalePrice")%>
            </ItemTemplate> 
          </asp:TemplateField>
           <asp:TemplateField HeaderText="佣金"  SortExpression="Fee">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <FooterStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <asp:Label ID="lblFee" Text='<%# Eval("Fee")%>' runat="server"></asp:Label> 
                <asp:TextBox ID="txtFee"   Text='<%# Eval("Fee") %>'  runat="server" Visible="false"></asp:TextBox>
                 <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgManufacturersInventoryVaule" runat="server"  Text="" ForeColor="red"></asp:Label>
                 </div>
            </ItemTemplate>   
          </asp:TemplateField>
          
           <asp:TemplateField HeaderText="扣点"  SortExpression="Deduction">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("Deduction")%>
            </ItemTemplate> 
          </asp:TemplateField>
          

            
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                 
            </td> 
        </tr>
    </table>
</asp:Content>

