<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportPreOrderInfo.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.ImportPreOrderInfo" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
          <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;" align="center">
                平台类型
            </td>
            <td style="width: 200px;">
                <asp:DropDownList ID="ddPlatformTypeId" runat="server" Width="160px">
                   <asp:ListItem Value="250" Text="天猫"></asp:ListItem>
                   <asp:ListItem Value="251" Text="京东"></asp:ListItem>
            </asp:DropDownList></td>
             
            <td style="width: 80px;" align="center">
                店铺名称
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlNick" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
             <td style="width: 80px;" align="center">
                导入类型
            </td>
            <td style="width: 160px">
                <asp:DropDownList ID="excelType" runat="server" Width="100%">
                <asp:ListItem Value="1" Text="京东"></asp:ListItem>
                <asp:ListItem Value="2" Text="超级店长旧"></asp:ListItem>
                <asp:ListItem Value="3" Text="赤兔"></asp:ListItem>
                <asp:ListItem Value="4" Text="超级店长新"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;" align="center">
                选择源EXCEL
            </td>
            <td style="width: 200px;">
                <asp:FileUpload ID="DataFilePath" runat="server" Width="100%" /> 
            </td>
            <%--<td style="width: 200px;">
            <div id="DIVDataFilePath2" runat="server">
                <asp:FileUpload  ID ="DataFilePath2" runat="server"  Width="100%" />
            </div>
            </td>--%>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                导入结果
            </td>
            <td colspan="7">
                <asp:TextBox ID="txtResult" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnImport" runat="server" Text="导入" OnClick="btnImport_Click" Visible="<% $CRMIsActionAllowed:ImportPreOrderInfo.Import %>" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnImport" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
