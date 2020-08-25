<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="CustomerSearch.aspx.cs" Inherits="HozestERP.Web.ManageCustomer.CustomerSearch" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="SHIBR" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="SHIBR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
               <%-- <td style="width: 80px">
                    工号
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtJobNumber" runat="server"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>--%>
                <td style="width: 60px">
                    姓名
                </td>
                <td style="width: 150px">
                    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    归属部门
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <%--<td style="width: 100px">
                    <asp:CheckBox ID="chkChildDepartment" runat="server" Text="包含子组织" />
                </td>--%>
                <td style="width: 40px">
                </td>
                 <td style="width: 40px">
                    性别
                </td>
                <td style="width: 120px">
                    <SHIBR:CodeControl ID="ddlGender" runat="server" CodeType="85" EmptyValue="true"
                        Width="100%" />
                </td>
                <td style="width: 40px">
                </td>
                <td> <asp:CheckBox ID="chkDelete" runat="server" Text="已删除" />
                </td>
                 <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
             
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvMessage" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
        SkinID="GridViewThemen" OnRowCommand="grdvMessage_RowCommand" OnRowDataBound="grdvMessage_RowDataBound">
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
           <%-- <asp:BoundField DataField="JobNumber" HeaderText="工号">
                <ItemStyle Width="100px"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="用户名">
                <ItemTemplate>
                    <%# (Container.DataItem as CustomerInfo).SCustomer.Username%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名">
                <ItemTemplate>
                    <a href="" onclick='return ShowDetail("<%# HozestERP.Common.Utils.CommonHelper.GetStoreLocation() %>ManageCustomer/CustomerInfoDetailBase.aspx?CustomerID=<%#Eval("CustomerID") %>", "CustomerDetail<%#Eval("CustomerID") %>", "<%# Eval("FullName") %> 详细基本资料");'
                        title="用户详细信息" style="text-decoration: underline;">
                        <%# Eval("FullName") %></a>
                </ItemTemplate>
                <ItemStyle Width="200px"></ItemStyle>
                <HeaderStyle Wrap="False"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <%# Eval("Gender") != null? (Eval("Gender") as HozestERP.BusinessLogic.Codes.CodeList).CodeName:""  %>
                </ItemTemplate>
                <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
           <%-- <asp:BoundField DataField="Birthday" HeaderText="生日" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="所属部门">
                <ItemTemplate>
                    <%# (Container.DataItem as CustomerInfo).SDepartment!=null?(Container.DataItem as CustomerInfo).SDepartment.DepName :""%>
                </ItemTemplate>
                <HeaderStyle Wrap="False"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="变动类型">
                <ItemTemplate>
                 <%# (Container.DataItem as CustomerInfo).ChangeType != null ? (Container.DataItem as CustomerInfo).ChangeType.CodeName : ""%>
                  <%--  <%# CommonHelper.GetDescription(typeof(CustomerStatusEnum), (Container.DataItem as CustomerInfo).CustomerStatus.ToString())%>--%>
                </ItemTemplate>
                <HeaderStyle Wrap="False"></HeaderStyle>
                <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="活动">
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkActive" runat="server" Checked='<%# (Container.DataItem as CustomerInfo).SCustomer.Active%>' />
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="40px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("CustomerID") %>'
                        SkinID="btnDetail" CommandName="Detail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
            </td>

             <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnDataEmpty"  SkinID="button4" runat="server" Text="数据清空"  OnClick="btnDataEmpty_Click" />
        
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
