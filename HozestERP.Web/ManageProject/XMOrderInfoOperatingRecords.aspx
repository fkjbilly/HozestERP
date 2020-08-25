<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMOrderInfoOperatingRecords.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMOrderInfoOperatingRecords" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../TopTaobao/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px">
                属性名称
            </td>
            <td style="width: 120px;">
                <asp:TextBox ID="txtPropertyName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px">
            </td>
            <td style="width: 80px;">
            </td>
            <td style="width: 120px;">
                <td style="width: 20px">
                </td>
                <td style="width: 80px">
                </td>
                <td style="width: 120px">
                    <td style="width: 20px">
                    </td>
                    <td style="width: 80px">
                    </td>
                    <td style="width: 120px">
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowDataBound="grdvClients_RowDataBound">
        <EmptyDataTemplate>
            <table style="width: 95%; border: 0px;">
                <tbody>
                    <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                        <th align="center" class="GridHeard" nowrap="" style="width: 20px; white-space: nowrap;"
                            scope="col">
                            &nbsp;
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                            属性名称
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                            原值
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                            新值
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                            修改人
                        </th>
                        <th align="center" class="GridHeard" nowrap="" style="white-space: nowrap;" scope="col">
                            修改时间
                        </th>
                    </tr>
                </tbody>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <%--  <asp:BoundField DataField="PropertyName" SortExpression="PropertyName"  HeaderText="属性名称">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
            </asp:BoundField> 
           <asp:BoundField DataField="OldValue" SortExpression="OldValue" HeaderText="原值">
                <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="False"/>
            </asp:BoundField>
            <asp:BoundField DataField="NewValue" SortExpression="NewValue" HeaderText="新值">
                <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="False" />
            </asp:BoundField>   --%>
            <asp:TemplateField HeaderText="属性名称">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblPropertyName" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="原值">
                <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblOldValue" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="新值">
                <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblNewValue" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改人">
                <HeaderStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblUpdatorID" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UpdateTime" SortExpression="UpdateTime" HeaderText="修改时间"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                <HeaderStyle HorizontalAlign="Center" Width="140px" Wrap="False" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
