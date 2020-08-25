<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
 AutoEventWireup="true" CodeBehind="XMCommunicationRecordEdit.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMCommunicationRecordEdit" %>
  

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 8px; height: 8px">
            </td> 
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 150px" nowrap="nowrap">
                订单编号 
            </td>
            <td style="width: 260px">
                <asp:Label ID="lblOrderNO" runat="server"></asp:Label> 
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 150px" nowrap="nowrap">
                店铺名称
            </td>
            <td style="width: 260px"> 
                <asp:Label ID="lblNick" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr> 
         
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px" nowrap="nowrap">
               平台  
            </td>
            <td style="width: 260px"> 
                <asp:Label ID="lblPlatform" runat="server"></asp:Label>
            </td>
            <td>
            </td>
            <td style="width: 100px" nowrap="nowrap">
                
            </td>
            <td style="width: 260px">
                
            </td>
        </tr>  
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td colspan="5">
                <div id="DivPR_PrductDetails" runat="server">
                    <asp:GridView ID="gvXMCommunicationRecord" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        SkinID="GridViewThemen" OnRowDataBound="gvXMCommunicationRecord_RowDataBound" OnRowCancelingEdit="gvXMCommunicationRecord_RowCancelingEdit"
                        OnRowDeleting="gvXMCommunicationRecord_RowDeleting" OnRowEditing="gvXMCommunicationRecord_RowEditing"
                        OnRowUpdating="gvXMCommunicationRecord_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="联系时间" SortExpression="">
                                <HeaderStyle Width="190px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                     <asp:Label ID="lblContactTime"  runat="server" Text='<%# DateTime.Parse(Eval("ContactTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                <asp:Label ID="lblContactTime" runat="server"></asp:Label>
                                <input id="txtContactTime"  disabled="true" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  
                                value='<%#Eval("ContactTime")==null?"":DateTime.Parse(Eval("ContactTime").ToString()).ToString("yyyy-MM-dd")%>'
                                class="Wdate" runat="server" style=" width:95%;" />
                                </EditItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="联系主题" SortExpression="">
                                <HeaderStyle Width="190px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                   <%# Eval("ContactTheme") %> 
                                </ItemTemplate>
                                <EditItemTemplate>  
                                    <asp:Label ID="lblContactTheme" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtContactTheme" TextMode="MultiLine" Text='<%# Eval("ContactTheme") %>'
                                        Width="240px" Height="60px" runat="server" ></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="联系内容" SortExpression="">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                    <%# Eval("ContactContent") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                
                                    <asp:Label ID="lblContactContent" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtContactContent" TextMode="MultiLine" Text='<%# Eval("ContactContent") %>'
                                        Width="240px" Height="60px" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>   
                             <asp:TemplateField HeaderText="创建人" SortExpression="">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                                <ItemTemplate>
                                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCommunicationRecord).CreateName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCommunicationRecord).CreateName.FullName : ""%>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCommunicationRecord).CreateName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMCommunicationRecord).CreateName.FullName : ""%>
                                </EditItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="操作">
                                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                                <ItemStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMCommunicationRecordEdit.GridView.Edit %>" />&nbsp;&nbsp;
                                   
                                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录.');"
                                        Visible="<% $CRMIsActionAllowed:XMCommunicationRecordEdit.GridView.Delete %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                                        ToolTip="保存" CommandName="Update"   CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMCommunicationRecordEdit.GridView.Save %>" />
                                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMCommunicationRecordEdit.GridView.Cancel %>" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td> 
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

