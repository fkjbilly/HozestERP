<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMExpressListContrast.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMExpressListContrast" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
        .float
        {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 60px">
                年份
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlYear" Width="100%" runat="server">
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2024">2024</asp:ListItem>
                    <asp:ListItem Value="2022">2025</asp:ListItem>
                    <asp:ListItem Value="2023">2026</asp:ListItem>
                    <asp:ListItem Value="2024">2027</asp:ListItem>
                    <asp:ListItem Value="2022">2028</asp:ListItem>
                    <asp:ListItem Value="2023">2029</asp:ListItem>
                    <asp:ListItem Value="2024">2030</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                月份
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlMonth" Width="100%" runat="server">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 60px">
                快递公司
            </td>
            <td style="width: 200px">
                <asp:DropDownList ID="ddlExpress" runat="server" Width="50%">
                </asp:DropDownList>
            </td>
            <td style="text-align: right" colspan="8">
                <asp:Button ID="btnSearch" runat="server" Text="对比" OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
    </table>
    <div style="height: 10px">
    </div>
    <div>
        <div style="width: 50%; display: block; float: right;">
            <table border="0" cellpadding="0" cellspacing="0" class="float">
                <tr>
                    <td style="width: 4px">
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" SkinID="button6" Text="导出快递账单" OnClick="Button1_Click"
                            Visible="<% $CRMIsActionAllowed:ManageProject.XMExpressListContrast.ExportExpressList %>" />
                    </td>
                    <td style="width: 4px">
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 48%; display: block; float: right;">
            <table border="0" cellpadding="0" cellspacing="0" class="float">
                <tr>
                    <td style="width: 4px">
                    </td>
                    <td>
                        <asp:Button ID="btnExportDelviery" runat="server" SkinID="button6" Text="导出发货单" OnClick="btnExportDelviery_Click"
                            Visible="<% $CRMIsActionAllowed:ManageProject.XMExpressListContrast.ExportDelivery %>" />
                    </td>
                    <td style="width: 4px">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="height: 30px">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="width: 50%; display: block; float: left">
        发货单列表
        <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            Width="100%" SkinID="GridViewThemen">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年份" SortExpression="Year">
                    <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Year")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="月份" SortExpression="Month">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Month")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单号" SortExpression="Number">
                    <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Number")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="快递公司" SortExpression="ExpressName">
                    <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("ExpressName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="费用" SortExpression="Cost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Cost")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="width: 48%; display: block; float: right">
        快递账单列表
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            SkinID="GridViewThemen">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年份" SortExpression="Year">
                    <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Year")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="月份" SortExpression="Month">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Month")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单号" SortExpression="Number">
                    <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Number")%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="快递公司" SortExpression="ExpressName">
                    <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("ExpressName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="费用" SortExpression="Cost">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                    <ItemTemplate>
                        <%# Eval("Cost")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>
