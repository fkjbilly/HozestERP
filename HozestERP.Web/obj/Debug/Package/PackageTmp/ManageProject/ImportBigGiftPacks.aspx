<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportBigGiftPacks.aspx.cs" Inherits="HozestERP.Web.ManageProject.ImportBigGiftPacks" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                选择源EXCEL
            </td>
            <td style="width: 400px;">
                <asp:FileUpload ID="DataFilePath" runat="server" Width="100%" />
            </td>
            <td>
            </td>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <%--<tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
            <td style="width: 100px;">
                &nbsp;
            </td>
            <td style="width: 400px;">
                <asp:HyperLink ID="DownTemp" runat="server" ForeColor="Red" NavigateUrl="~/Template/导入物流单号模板.xls">下载导入物流单号模板</asp:HyperLink>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;</td>
            <td style="width: 80px;">
                平台</td>
            <td style="width: 400px;">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">京东</asp:ListItem>
                    <asp:ListItem Value="2">天猫</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 8px; height: 8px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
                
            </td>
            
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 100px;">
                导入结果
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtResult" runat="server" Width="100%" Height="80px" TextMode="MultiLine"></asp:TextBox>
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
                        <asp:Button ID="btnImport" SkinID="Button2" runat="server" Text="导入" OnClick="btnImport_Click" />
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
